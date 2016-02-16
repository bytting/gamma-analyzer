﻿/*	
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
        static ConcurrentQueue<burn.Message> sendq = null;
        static ConcurrentQueue<burn.Message> recvq = null;

        static burn.NetService netService = new burn.NetService(ref sendq, ref recvq);
        static Thread netThread = new Thread(netService.DoWork);

        FormConnect formConnect = new FormConnect();
        System.Windows.Forms.Timer timer = new System.Windows.Forms.Timer();

        BindingList<Spectrum> specList = new BindingList<Spectrum>();

        public FormMain()
        {
            InitializeComponent();
        }

        private void FormMain_Load(object sender, EventArgs e)
        {
            tabs.HideTabs = true;
            tabs.SelectedTab = pageMenu;

            lblConnectionStatus.ForeColor = Color.Red;
            lblConnectionStatus.Text = "Not connected";

            netThread.Start();
            while (!netThread.IsAlive);            
                    
            timer.Interval = 10;
            timer.Tick += timer_Tick;
            timer.Start();

            lbSpecList.DataSource = specList;
            lbSpecList.DisplayMember = "Label";
            lbSpecList.ValueMember = "Message";
        }

        void timer_Tick(object sender, EventArgs e)
        {
            while (!recvq.IsEmpty)
            {
                burn.Message msg;                
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

        private bool dispatchRecvMsg(burn.Message msg)
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

                case "set_gain_ok":
                    log("set gain: " + msg.arguments["voltage"] + " " + msg.arguments["coarse_gain"] + " " + msg.arguments["fine_gain"]);
                    break;

                case "spectrum":
                    Spectrum spec = new Spectrum(msg);
                    specList.Add(spec);
                    log("Spectrum " + spec.Label + " received");

                    string path = tbSessionDir.Text + Path.DirectorySeparatorChar + spec.Message.arguments["session_name"];
                    string jsonPath = path + Path.DirectorySeparatorChar + "json";
                    if (!Directory.Exists(jsonPath))
                        Directory.CreateDirectory(jsonPath);

                    string filename = jsonPath + Path.DirectorySeparatorChar + spec.Message.arguments["session_index"] + ".json";
                    TextWriter writer = new StreamWriter(filename);
                    writer.Write(msg.ToJson(true));
                    writer.Close();

                    if(cbStoreChn.Checked)
                    {
                        string chnPath = path + Path.DirectorySeparatorChar + "chn";
                        if (!Directory.Exists(chnPath))
                            Directory.CreateDirectory(chnPath);
                        filename = chnPath + Path.DirectorySeparatorChar + spec.Message.arguments["session_index"] + ".chn";                        
                        burn.CHN.Write(filename, msg);
                    }                    
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

            burn.Message msg = new burn.Message("connect");
            msg.AddParameter("host", formConnect.IP);
            msg.AddParameter("port", formConnect.Port);            
            sendq.Enqueue(msg);            
        }

        private void menuItemDisconnect_Click(object sender, EventArgs e)
        {
            sendq.Enqueue(new burn.Message("disconnect"));
        }        

        private void btnSendClose_Click(object sender, EventArgs e)
        {
            sendq.Enqueue(new burn.Message("close"));                        
        }

        private void btnSendSession_Click(object sender, EventArgs e)
        {
            if (String.IsNullOrEmpty(tbSessionDir.Text))
            {
                MessageBox.Show("Du må velge en session katalog");
                return;
            }                        

            if (String.IsNullOrEmpty(tbSpecLivetime.Text))
            {
                MessageBox.Show("Mangler livetime");
                return;
            }            

            int count = String.IsNullOrEmpty(tbSpecCount.Text) ? -1 : Convert.ToInt32(tbSpecCount.Text);
            float livetime = Convert.ToSingle(tbSpecLivetime.Text);
            float delay = String.IsNullOrEmpty(tbSpecDelay.Text) ? 0 : Convert.ToSingle(tbSpecDelay.Text);

            burn.Message msg = new burn.Message("new_session");
            msg.AddParameter("session_name", String.Format("{0:ddMMyyyy_HHmmss}", DateTime.Now));
            msg.AddParameter("iterations", count);
            msg.AddParameter("livetime", livetime);
            msg.AddParameter("delay", delay);
            sendq.Enqueue(msg);

            specList.Clear();
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

            burn.Message msg = new burn.Message("set_gain");
            msg.AddParameter("voltage", voltage);
            msg.AddParameter("coarse_gain", coarse);
            msg.AddParameter("fine_gain", fine);
            sendq.Enqueue(msg);
        }

        private void btnStopSession_Click(object sender, EventArgs e)
        {
            sendq.Enqueue(new burn.Message("stop_session"));
        }

        private void lbSpecList_DoubleClick(object sender, EventArgs e)
        {
            if (lbSpecList.SelectedItem == null)
                return;

            Spectrum spec = (Spectrum)lbSpecList.SelectedItem;
            MessageBox.Show(spec.Label);
        }

        private void btnSelectSessionDir_Click(object sender, EventArgs e)
        {
            FolderBrowserDialog dialog = new FolderBrowserDialog();
            if(dialog.ShowDialog() == DialogResult.OK)
            {
                tbSessionDir.Text = dialog.SelectedPath;
            }
        }

        private void btnMenuSpec_Click(object sender, EventArgs e)
        {
            tabs.SelectedTab = pageSpec;
        }

        private void btnBack_Click(object sender, EventArgs e)
        {
            tabs.SelectedTab = pageMenu;
        }

        private void lbSpecList_SelectedValueChanged(object sender, EventArgs e)
        {
            if (lbSpecList.SelectedItems.Count < 1)
                return;

            Spectrum spec = (Spectrum)lbSpecList.SelectedItems[0];
            string[] counts = spec.Message.arguments["channels"].Split(new char[] {' '});
            int index = 0;
            foreach(string ch in counts)
            {
                chartSpec.Series["Series1"].Points.AddXY(index, Convert.ToInt32(ch));
                index++;
            }
        }        
    }    

    public class Spectrum
    {
        private string mLabel;
        private burn.Message mMessage;

        public string Label { get { return mLabel; } }
        public burn.Message Message { get { return mMessage; } }

        public Spectrum(burn.Message msg)
        {
            mLabel = "Spectrum " + msg.arguments["session_index"];
            mMessage = msg;
        }
    }
}
