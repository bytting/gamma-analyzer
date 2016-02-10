/*	
	Crash - Controlling application for Burn
    Copyright (C) 2016  Norwegian Radiation Protection Authority

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
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading;
using System.Windows.Forms;

namespace crash
{
    public partial class FormMain : Form
    {
        static ConcurrentQueue<Proto.Message> sendq = new ConcurrentQueue<Proto.Message>();
        static ConcurrentQueue<Proto.Message> recvq = new ConcurrentQueue<Proto.Message>();        

        static NetService netService = new NetService(sendq, recvq);
        static Thread netThread = new Thread(netService.DoWork);

        FormConnect formConnect = new FormConnect();
        System.Windows.Forms.Timer timer = new System.Windows.Forms.Timer();

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
                    
            timer.Interval = 10;
            timer.Tick += timer_Tick;
            timer.Start();
        }

        void timer_Tick(object sender, EventArgs e)
        {
            while (!recvq.IsEmpty)
            {
                Proto.Message msg;                
                if (recvq.TryDequeue(out msg))
                    dispatchRecvMsg(msg);                                    
            }            
        }

        private void FormMain_FormClosing(object sender, FormClosingEventArgs e)
        {
            if (netService.IsRunning())
                btnStopNetService_Click(sender, e);
            timer.Stop();
        }

        private bool dispatchRecvMsg(Proto.Message msg)
        {
            switch (msg.command)
            {
                case "connect_ok":
                    lblConnectionStatus.ForeColor = Color.Green;
                    lblConnectionStatus.Text = "Connected to " + msg.arguments["host"] + ":" + msg.arguments["port"];
                    log("Connected to " + msg.arguments["host"] + ":" + msg.arguments["port"]);
                    break;

                case "connect_failed":
                    lblConnectionStatus.ForeColor = Color.Red;
                    lblConnectionStatus.Text = "Connection failed for " + msg.arguments["host"] + ":" + msg.arguments["port"] + " " + msg.arguments["message"];
                    log("Connection failed for " + msg.arguments["host"] + ":" + msg.arguments["port"] + " " + msg.arguments["message"]);
                    break;

                case "disconnect_ok":
                    lblConnectionStatus.ForeColor = Color.Red;
                    lblConnectionStatus.Text = "Not connected";
                    log("Disconnected from peer");
                    break;

                case "close_ok":
                    netService.RequestStop();
                    netThread.Join();
                    lblConnectionStatus.ForeColor = Color.Red;
                    lblConnectionStatus.Text = "Not connected";
                    log("Disconnected from peer, peer closed");
                    break;

                case "new_session_ok":
                    log("New session created: " + msg.arguments["session_name"]);
                    break;

                case "new_session_failed":
                    log("New session failed: " + msg.arguments["message"]);
                    break;

                case "stop_session_ok":
                    log("Session stopped");
                    break;

                case "error":
                    log("Error: " + msg.arguments["message"]);
                    break;

                case "error_socket":
                    log("Socket error: " + msg.arguments["error_code"] + " " + msg.arguments["message"]);
                    break;

                case "get_fix_ok":
                    log("GPS Fix - Lat: " + msg.arguments["latitude"] + " Lon: " + msg.arguments["longitude"] + " Alt: " + msg.arguments["altitude"]);
                    break;

                case "set_gain_ok":
                    log("set gain: " + msg.arguments["voltage"] + " " + msg.arguments["coarse_gain"] + " " + msg.arguments["fine_gain"]);
                    break;

                case "get_spectrum_ok":
                    log(
                        "session name: " + msg.arguments["session_name"] + 
                        "uncorr. total count: " + msg.arguments["uncorrected_total_count"] + 
                        " channel count: " + msg.arguments["channel_count"] + 
                        " computational limit: " + msg.arguments["computational_limit"] +
                        " status: " + msg.arguments["status"] +
                        " livetime: " + msg.arguments["livetime"] +
                        " realtime: " + msg.arguments["realtime"]);
                    log(msg.arguments["channels"]);
                    string[] items = msg.arguments["channels"].Split(new char[] {' '});
                    log("Items: " + items.Length.ToString());
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

        private void log(string message)
        {
            tbLog.Text += Environment.NewLine + DateTime.Now.ToString("yyyy-MM-dd HH:mm:ss") + ": " + message;
        }        

        private void menuItemExit_Click(object sender, EventArgs e)
        {
            menuItemDisconnect_Click(sender, e);
            Close();
        }

        private void menuItemConnect_Click(object sender, EventArgs e)
        {
            if (formConnect.ShowDialog() != System.Windows.Forms.DialogResult.OK)
                return;

            Proto.Message msg = new Proto.Message("connect");
            msg.AddParameter("host", formConnect.IP);
            msg.AddParameter("port", formConnect.Port);            
            sendq.Enqueue(msg);            
        }

        private void menuItemDisconnect_Click(object sender, EventArgs e)
        {            
            sendq.Enqueue(new Proto.Message("disconnect"));
        }

        private void btnSendHello_Click(object sender, EventArgs e)
        {                                    
            sendq.Enqueue(new Proto.Message("ping"));            
        }

        private void btnSendClose_Click(object sender, EventArgs e)
        {            
            sendq.Enqueue(new Proto.Message("close"));                        
        }

        private void btnSendSession_Click(object sender, EventArgs e)
        {
            if (String.IsNullOrEmpty(tbSpecCount.Text))
            {
                MessageBox.Show("Mangler count");
                return;
            }

            if (String.IsNullOrEmpty(tbSpecLivetime.Text))
            {
                MessageBox.Show("Mangler livetime");
                return;
            }

            if (String.IsNullOrEmpty(tbSpecDelay.Text))
            {
                MessageBox.Show("Mangler delay");
                return;
            }

            int count = Convert.ToInt32(tbSpecCount.Text);
            float livetime = Convert.ToSingle(tbSpecLivetime.Text);
            float delay = Convert.ToSingle(tbSpecDelay.Text);

            Proto.Message msg = new Proto.Message("new_session");
            msg.AddParameter("session_name", String.Format("{0:ddMMyyyy_HHmmss}", DateTime.Now));
            msg.AddParameter("iterations", count);
            msg.AddParameter("livetime", livetime);
            msg.AddParameter("delay", delay);
            sendq.Enqueue(msg);
        }

        private void btnSendFix_Click(object sender, EventArgs e)
        {            
            sendq.Enqueue(new Proto.Message("get_fix"));
        }

        private void btnStopNetService_Click(object sender, EventArgs e)
        {
            netService.RequestStop();
            netThread.Join();
        }                

        private void btnSetGain_Click(object sender, EventArgs e)
        {
            if (String.IsNullOrEmpty(tbVoltage.Text))
            {
                MessageBox.Show("Mangler voltage");
                return;
            }

            if (String.IsNullOrEmpty(tbCoarseGain.Text))
            {
                MessageBox.Show("Mangler coarse gain");
                return;
            }

            if (String.IsNullOrEmpty(tbFineGain.Text))
            {
                MessageBox.Show("Mangler fine gain");
                return;
            }

            int voltage = Convert.ToInt32(tbVoltage.Text);
            float coarse = Convert.ToInt32(tbCoarseGain.Text);
            float fine = Convert.ToInt32(tbFineGain.Text);

            Proto.Message msg = new Proto.Message("set_gain");
            msg.AddParameter("voltage", voltage);
            msg.AddParameter("coarse_gain", coarse);
            msg.AddParameter("fine_gain", fine);
            sendq.Enqueue(msg);
        }

        private void btnStopSession_Click(object sender, EventArgs e)
        {
            sendq.Enqueue(new Proto.Message("stop_session"));
        }        
    }
}
