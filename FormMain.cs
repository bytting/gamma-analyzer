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
using System.Collections.Concurrent;
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
        static BlockingCollection<Proto.Message> sendq = new BlockingCollection<Proto.Message>();
        static BlockingCollection<Proto.Message> recvq = new BlockingCollection<Proto.Message>();

        static NetService netService = new NetService(sendq, recvq);
        static Thread netThread = new Thread(netService.DoWork);

        FormConnect form = new FormConnect();        

        public FormMain()
        {
            InitializeComponent();
        }

        private void FormMain_Load(object sender, EventArgs e)
        {            
            lblConnectionStatus.ForeColor = Color.Red;
            lblConnectionStatus.Text = "Not connected";

            netThread.Start();
            while (!netThread.IsAlive);            

            Application.Idle += Application_Idle;
        }

        void Application_Idle(object sender, EventArgs e)
        {
            while (recvq.Count > 0)
            {
                Proto.Message msg;
                if (recvq.TryTake(out msg))
                    dispatchMsg(msg);                    
            }
        }        

        private void log(string message)
        {
            tbLog.Text += Environment.NewLine + DateTime.Now.ToShortDateString() + ": " + message;
        }

        private bool dispatchMsg(Proto.Message msg)
        {
            switch(msg.command)
            {
                case "connected":
                    lblConnectionStatus.ForeColor = Color.Green;
                    lblConnectionStatus.Text = "Connected to " + msg.arguments["host"] + ":" + msg.arguments["port"];
                    log("Connected to " + msg.arguments["host"] + ":" + msg.arguments["port"]);
                    break;

                case "connection_failed":
                    lblConnectionStatus.ForeColor = Color.Red;
                    lblConnectionStatus.Text = "Connection failed for " + msg.arguments["host"] + ":" + msg.arguments["port"];
                    log("Connection failed for " + msg.arguments["host"] + ":" + msg.arguments["port"]);
                    break;

                case "disconnected":
                    lblConnectionStatus.ForeColor = Color.Red;
                    lblConnectionStatus.Text = "Not connected";
                    log("Disconnected from peer");
                    break;

                case "closing":
                    netService.RequestStop();
                    netThread.Join();
                    lblConnectionStatus.ForeColor = Color.Red;
                    lblConnectionStatus.Text = "Not connected";
                    log("Disconnected from peer, peer closed");
                    break;

                default:
                    string info = msg.command + " -> ";
                    foreach (KeyValuePair<string, string> item in msg.arguments)                    
                        info += item.Key + ":" + item.Value + ", ";                    
                    log("Unhandeled command: " + info);
                    break;                    
            }
            return true;
        }

        private void menuItemExit_Click(object sender, EventArgs e)
        {
            menuItemDisconnect_Click(sender, e);
            Close();
        }

        private void menuItemConnect_Click(object sender, EventArgs e)
        {
            FormConnect form = new FormConnect();
            if (form.ShowDialog() != System.Windows.Forms.DialogResult.OK)
                return;

            Proto.Message msg = new Proto.Message("connect", new Dictionary<string, string>() {
                    {"host", form.IP}, 
                    {"port", form.Port}
            });
            sendq.Add(msg);            
        }

        private void menuItemDisconnect_Click(object sender, EventArgs e)
        {
            Proto.Message msg = new Proto.Message("disconnect", null);
            sendq.Add(msg);            
        }

        private void btnSendHello_Click(object sender, EventArgs e)
        {                        
            Proto.Message msg = new Proto.Message("ping", null);
            sendq.Add(msg);            
        }

        private void btnSendClose_Click(object sender, EventArgs e)
        {
            Proto.Message msg = new Proto.Message("close", null);
            sendq.Add(msg);                        
        }

        private void btnSendSession_Click(object sender, EventArgs e)
        {
            Proto.Message msg = new Proto.Message("new_session", null);
            sendq.Add(msg);                                    
        }

        private void btnStopNetService_Click(object sender, EventArgs e)
        {
            netService.RequestStop();
            netThread.Join();
        }

        private void FormMain_FormClosing(object sender, FormClosingEventArgs e)
        {
            if(netService.IsRunning())
                btnStopNetService_Click(sender, e);
        }
    }
}
