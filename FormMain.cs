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
using System.Threading;
using System.Threading.Tasks;
using System.Windows.Forms;
using Newtonsoft.Json;

namespace crash
{
    public partial class FormMain : Form
    {
        public TcpClient Client = null;
        NetworkStream ClientStream = null;                

        FormConnect form = new FormConnect();

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
            if (Client != null && Client.Connected)
            {
                MessageBox.Show("Already connected");
                return;
            }

            if(form.ShowDialog() == DialogResult.OK)
            {
                Client = form.Client;
                ClientStream = Client.GetStream();                                

                string peer = ((IPEndPoint)Client.Client.RemoteEndPoint).Address.ToString();
                lblConnectionStatus.ForeColor = Color.Green;
                lblConnectionStatus.Text = "Connected to " + peer;
            }
        }

        private void menuItemDisconnect_Click(object sender, EventArgs e)
        {
            if(Client != null && Client.Connected)            
                Client.Close();                            
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
                        
            Proto.Message msg = new Proto.Message("ping", null);
            Proto.IO.SendMessage(ClientStream, msg);
            
            Thread.Sleep(2000);

            if(Proto.IO.RecvMessage(ClientStream, ref msg))
            {
                tbInfo.Text += Environment.NewLine + "Object read, command: " + msg.command + Environment.NewLine;
            }
            else
            {
                tbInfo.Text += Environment.NewLine + "No object read" + Environment.NewLine;
            }            
        }

        private void btnSendClose_Click(object sender, EventArgs e)
        {
            if (Client == null || !Client.Connected)
            {
                MessageBox.Show("Not connected");
                return;
            }

            Proto.Message msg = new Proto.Message("close", null);
            Proto.IO.SendMessage(ClientStream, msg);

            Thread.Sleep(2000);

            if (Proto.IO.RecvMessage(ClientStream, ref msg))
            {
                tbInfo.Text += Environment.NewLine + "Object read, command: " + msg.command + Environment.NewLine;
            }
            else
            {
                tbInfo.Text += Environment.NewLine + "No object read" + Environment.NewLine;
            }
        }

        private void btnSendSession_Click(object sender, EventArgs e)
        {
            if (Client == null || !Client.Connected)
            {
                MessageBox.Show("Not connected");
                return;
            }

            Proto.Message msg = new Proto.Message("new_session", null);
            Proto.IO.SendMessage(ClientStream, msg);

            Thread.Sleep(2000);

            if (Proto.IO.RecvMessage(ClientStream, ref msg))
            {
                tbInfo.Text += Environment.NewLine + "Object read, command: " + msg.command + Environment.NewLine;
            }
            else
            {
                tbInfo.Text += Environment.NewLine + "No object read" + Environment.NewLine;
            }
        }
    }
}
