/*	
	Crash - Controlling application for Burn
    Copyright (C) 2016  Dag Robole

    This program is free software: you can redistribute it and/or modify
    it under the terms of the GNU General Public License as published by
    the Free Software Foundation, either version 3 of the License, or
    (at your option) any later version.

    This program is distributed in the hope that it will be useful,
    but WITHOUT ANY WARRANTY; without even the implied warranty of
    MERCHANTABILITY or FITNESS FOR A PARTICULAR PURPOSE.  See the
    GNU General Public License for more details.

    You should have received a copy of the GNU General Public License
    along with this program.  If not, see <http://www.gnu.org/licenses/>.
*/
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.IO;
using System.Data;
using System.Net;
using System.Net.Sockets;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using Newtonsoft.Json;

namespace crash
{
    public partial class FormMain : Form
    {
        public TcpClient Client = null;
        NetworkStream ClientStream = null;
        StreamReader ClientReader = null;
        StreamWriter ClientWriter = null;

        public FormMain()
        {
            InitializeComponent();
        }

        private void FormMain_Load(object sender, EventArgs e)
        {            
            lblConnectionStatus.ForeColor = Color.Red;
            lblConnectionStatus.Text = "Not connected";               
        }

        private void menuItemExit_Click(object sender, EventArgs e)
        {
            menuItemDisconnect_Click(sender, e);
            Close();
        }

        private void menuItemConnect_Click(object sender, EventArgs e)
        {            
            FormConnect form = new FormConnect();
            if(form.ShowDialog() == DialogResult.OK)
            {
                Client = form.Client;
                ClientStream = Client.GetStream();
                ClientReader = new StreamReader(ClientStream);
                ClientWriter = new StreamWriter(ClientStream);

                string peer = ((IPEndPoint)Client.Client.RemoteEndPoint).Address.ToString();
                lblConnectionStatus.ForeColor = Color.Green;
                lblConnectionStatus.Text = "Connected to " + peer;
            }
        }

        private void menuItemDisconnect_Click(object sender, EventArgs e)
        {
            if(Client != null && Client.Connected)
            {
                ClientWriter.Close();
                ClientReader.Close();
                Client.Close();
            }
            ClientWriter = null;
            ClientReader = null;
            Client = null;

            lblConnectionStatus.ForeColor = Color.Red;
            lblConnectionStatus.Text = "Not connected";            
        }

        private void btnSendHello_Click(object sender, EventArgs e)
        {
            if(Client == null || !Client.Connected)
            {
                MessageBox.Show("Not connected");
                return;
            }

            Proto.Request msg = new Proto.Request("controller", "ping", null);
            string json = JsonConvert.SerializeObject(msg);            
            
            ClientWriter.Write(json);
            ClientWriter.Flush();            

            string response = ClientReader.ReadLine();
            tbInfo.Text += Environment.NewLine + response;            
        }

        private void btnSendClose_Click(object sender, EventArgs e)
        {
            if (Client == null || !Client.Connected)
            {
                MessageBox.Show("Not connected");
                return;
            }

            Proto.Request msg = new Proto.Request("controller", "close", null);
            string json = JsonConvert.SerializeObject(msg);

            ClientWriter.Write(json);
            ClientWriter.Flush();

            string response = ClientReader.ReadLine();
            tbInfo.Text += Environment.NewLine + response;            
        }        
    }
}
