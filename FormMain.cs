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
using System.Xml;
using System.Xml.Serialization;
using GMap.NET;
using GMap.NET.MapProviders;
using GMap.NET.WindowsForms;
using GMap.NET.WindowsForms.Markers;

namespace crash
{
    public partial class FormMain : Form
    {
        private static string SettingsPath = Environment.GetFolderPath(Environment.SpecialFolder.CommonDocuments) + Path.DirectorySeparatorChar + "crash";
        private static string SettingsFile = SettingsPath + Path.DirectorySeparatorChar + "settings.xml";

        FormLog log = new FormLog();
        Settings settings = new Settings();

        static ConcurrentQueue<burn.Message> sendq = null;
        static ConcurrentQueue<burn.Message> recvq = null;

        static burn.NetService netService = new burn.NetService(ref sendq, ref recvq);
        static Thread netThread = new Thread(netService.DoWork);

        FormConnect formConnect = new FormConnect();
        System.Windows.Forms.Timer timer = new System.Windows.Forms.Timer();

        BindingList<Spectrum> specList = new BindingList<Spectrum>();
        bool connected = false;

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

            if (!Directory.Exists(SettingsPath))
                Directory.CreateDirectory(SettingsPath);

            if (File.Exists(SettingsFile))
            {
                LoadSettings();
            }

            netThread.Start();
            while (!netThread.IsAlive);            
                    
            timer.Interval = 10;
            timer.Tick += timer_Tick;
            timer.Start();

            lbSpecList.DataSource = specList;
            lbSpecList.DisplayMember = "Label";
            lbSpecList.ValueMember = "Message";            

            gmap.Position = new GMap.NET.PointLatLng(59.946534, 10.598574);
            /*GMapOverlay markersOverlay = new GMapOverlay("markers");                        
            GMarkerGoogle marker = new GMarkerGoogle(new PointLatLng(59.946534, 10.598574), new Bitmap(@"C:\dev\crash\images\marker-blue-32.png"));
            markersOverlay.Markers.Add(marker);
            gmap.Overlays.Add(markersOverlay);*/
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

        private void SaveSettings()
        {
            StreamWriter sw = new StreamWriter(SettingsFile);
            XmlSerializer x = new XmlSerializer(settings.GetType());
            x.Serialize(sw, settings);
            sw.Close();
        }

        private void LoadSettings()
        {
            StreamReader sr = new StreamReader(SettingsFile);
            XmlSerializer x = new XmlSerializer(settings.GetType());
            settings = x.Deserialize(sr) as Settings;
            sr.Close();
        }

        private void FormMain_FormClosing(object sender, FormClosingEventArgs e)
        {
            if (netService.IsRunning())
                btnStopNetService_Click(sender, e);
            timer.Stop();

            SaveSettings();
        }

        private bool dispatchRecvMsg(burn.Message msg)
        {            
            switch (msg.Command)
            {
                case "connect_ok":
                    lblConnectionStatus.ForeColor = Color.Green;
                    lblConnectionStatus.Text = "Connected to " + msg.Arguments["host"] + ":" + msg.Arguments["port"];
                    log.Add("Connected to " + msg.Arguments["host"] + ":" + msg.Arguments["port"]);
                    connected = true;
                    break;

                case "connect_failed":
                    lblConnectionStatus.ForeColor = Color.Red;
                    lblConnectionStatus.Text = "Connection failed for " + msg.Arguments["host"] + ":" + msg.Arguments["port"] + " " + msg.Arguments["message"];
                    log.Add("Connection failed for " + msg.Arguments["host"] + ":" + msg.Arguments["port"] + " " + msg.Arguments["message"]);
                    connected = false;
                    break;

                case "disconnect_ok":
                    lblConnectionStatus.ForeColor = Color.Red;
                    lblConnectionStatus.Text = "Not connected";
                    log.Add("Disconnected from peer");
                    connected = false;
                    break;

                case "close_ok":
                    netService.RequestStop();
                    netThread.Join();
                    lblConnectionStatus.ForeColor = Color.Red;
                    lblConnectionStatus.Text = "Not connected";
                    log.Add("Disconnected from peer, peer closed");
                    break;

                case "new_session_ok":
                    bool prev = msg.Arguments["preview"] == "1";
                    if(prev)
                        log.Add("Preview saved");
                    else
                        log.Add("New session created: " + msg.Arguments["session_name"]);
                    break;

                case "new_session_failed":
                    log.Add("New session failed: " + msg.Arguments["message"]);
                    break;

                case "stop_session_ok":
                    log.Add("Session stopped");
                    break;

                case "error":
                    log.Add("Error: " + msg.Arguments["message"]);
                    break;

                case "error_socket":
                    log.Add("Socket error: " + msg.Arguments["error_code"] + " " + msg.Arguments["message"]);
                    break;                

                case "set_gain_ok":
                    log.Add("set gain: " + msg.Arguments["voltage"] + " " + msg.Arguments["coarse_gain"] + " " + msg.Arguments["fine_gain"]);
                    break;

                case "spectrum":
                    Spectrum spec = new Spectrum(msg);
                    specList.Add(spec);                    
                    log.Add("Spectrum " + spec.Label + " received");

                    string path;
                    bool preview = msg.Arguments["preview"] == "1";

                    if(preview)
                        path = SettingsPath;                    
                    else                    
                        path = tbSessionDir.Text + Path.DirectorySeparatorChar + spec.Message.Arguments["session_name"];                    

                    string jsonPath = path + Path.DirectorySeparatorChar + "json";
                    if (!Directory.Exists(jsonPath))
                        Directory.CreateDirectory(jsonPath);

                    string filename = jsonPath + Path.DirectorySeparatorChar + spec.Message.Arguments["session_index"] + ".json";
                    TextWriter writer = new StreamWriter(filename);
                    writer.Write(msg.ToJson(true));
                    writer.Close();

                    if(cbStoreChn.Checked)
                    {
                        string chnPath = path + Path.DirectorySeparatorChar + "chn";
                        if (!Directory.Exists(chnPath))
                            Directory.CreateDirectory(chnPath);
                        filename = chnPath + Path.DirectorySeparatorChar + spec.Message.Arguments["session_index"] + ".chn";                        
                        burn.CHN.Write(filename, msg);
                    }
                 
                    if(preview)
                    {
                        chartSetupSpec.Series["Series1"].Points.Clear();
                        string[] counts = msg.Arguments["channels"].Split(new char[] {' '});
                        int index = 0;
                        foreach(string ch in counts)
                        {
                            chartSetupSpec.Series["Series1"].Points.AddXY(index, Convert.ToInt32(ch));
                            index++;
                        }
                    }
                    break;

                default:
                    string info = msg.Command + " -> ";
                    foreach (KeyValuePair<string, string> item in msg.Arguments)
                        info += item.Key + ":" + item.Value + ", ";
                    log.Add("Unhandeled command: " + info);
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
            if (formConnect.ShowDialog() != System.Windows.Forms.DialogResult.OK)
                return;

            burn.Message msg = new burn.Message("connect", null);
            msg.AddParameter("host", formConnect.IP);
            msg.AddParameter("port", formConnect.Port);            
            sendq.Enqueue(msg);            
        }

        private void menuItemDisconnect_Click(object sender, EventArgs e)
        {        
            if(connected)
                if (MessageBox.Show("Are you sure you want to disconnect?", "Confirmation", MessageBoxButtons.YesNo) == System.Windows.Forms.DialogResult.No)
                    return;

            sendq.Enqueue(new burn.Message("disconnect", null));
        }        

        private void btnSendClose_Click(object sender, EventArgs e)
        {
            if (MessageBox.Show("Are you sure you want to close the remote server?", "Confirmation", MessageBoxButtons.YesNo) == System.Windows.Forms.DialogResult.No)
                return;

            sendq.Enqueue(new burn.Message("close", null));                        
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
                MessageBox.Show("You must specify a livetime");
                return;
            }            

            int count = String.IsNullOrEmpty(tbSpecCount.Text) ? -1 : Convert.ToInt32(tbSpecCount.Text);
            float livetime = Convert.ToSingle(tbSpecLivetime.Text);
            float delay = String.IsNullOrEmpty(tbSpecDelay.Text) ? 0 : Convert.ToSingle(tbSpecDelay.Text);

            burn.Message msg = new burn.Message("new_session", null);
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
        }

        private void btnStopSession_Click(object sender, EventArgs e)
        {
            sendq.Enqueue(new burn.Message("stop_session", null));
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
            tabs.SelectedTab = pageSetup;
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
            string[] counts = spec.Message.Arguments["channels"].Split(new char[] {' '});
            int index = 0;
            foreach(string ch in counts)
            {
                chartSetupSpec.Series["Series1"].Points.AddXY(index, Convert.ToInt32(ch));
                index++;
            }
        }

        private void btnMenuMap_Click(object sender, EventArgs e)
        {
            tabs.SelectedTab = pageSession;
        }

        private void cboxMapProvider_SelectedIndexChanged(object sender, EventArgs e)
        {            
            if(!String.IsNullOrEmpty(cboxMapProvider.Text))
            {
                switch(cboxMapProvider.Text)
                {
                    case "Google Map":
                        gmap.MapProvider = GoogleMapProvider.Instance;                        
                        break;
                    case "Google Map Terrain":
                        gmap.MapProvider = GoogleTerrainMapProvider.Instance;
                        break;
                    case "Open Street Map":
                        gmap.MapProvider = OpenStreetMapProvider.Instance;
                        break;
                    case "Open Street Map Quest":
                        gmap.MapProvider = OpenStreetMapQuestProvider.Instance;
                        break;
                    case "ArcGIS World Topo":
                        gmap.MapProvider = ArcGIS_World_Topo_MapProvider.Instance;
                        break;
                    case "Bing Map":
                        gmap.MapProvider = BingMapProvider.Instance;
                        break;
                }                                
                GMaps.Instance.Mode = AccessMode.ServerOnly;
                //gmap.Position = new GMap.NET.PointLatLng(59.946534, 10.598574);
                //gmap.Zoom = 12;
            }
        }

        private void btnMenuSession_Click(object sender, EventArgs e)
        {
            tabs.SelectedTab = pageSession;
        }

        private void btnMapMinimize_Click(object sender, EventArgs e)
        {
            splitRight.SplitterDistance = splitMain.Height - 25;            
        }

        private void btnMapMaximize_Click(object sender, EventArgs e)
        {
            splitRight.SplitterDistance = splitMain.Height / 2;
        }

        private void btnShowLog_Click(object sender, EventArgs e)
        {            
            log.Show();
            log.BringToFront();
        }

        private void btnSetupSetParams_Click(object sender, EventArgs e)
        {
            if (String.IsNullOrEmpty(tbSetupVoltage.Text))
            {
                MessageBox.Show("You must specify voltage");
                return;
            }

            if (String.IsNullOrEmpty(tbSetupCoarseGain.Text))
            {
                MessageBox.Show("You must specify coarse gain");
                return;
            }

            if (String.IsNullOrEmpty(tbSetupFineGain.Text))
            {
                MessageBox.Show("You must specify fine gain");
                return;
            }

            int voltage = Convert.ToInt32(tbSetupVoltage.Text);
            float coarse = Convert.ToInt32(tbSetupCoarseGain.Text);
            float fine = Convert.ToInt32(tbSetupFineGain.Text);

            burn.Message msg = new burn.Message("set_gain", null);
            msg.AddParameter("voltage", voltage);
            msg.AddParameter("coarse_gain", coarse);
            msg.AddParameter("fine_gain", fine);
            sendq.Enqueue(msg);
        }

        private void btnSetupStart_Click(object sender, EventArgs e)
        {
            if (String.IsNullOrEmpty(tbSetupLivetime.Text))
            {
                MessageBox.Show("You must specify a livetime");
                return;
            }

            burn.Message msg = new burn.Message("new_session", null);
            msg.AddParameter("session_name", String.Format("{0:ddMMyyyy_HHmmss}", DateTime.Now));
            msg.AddParameter("preview", 1);
            msg.AddParameter("iterations", 1);
            msg.AddParameter("livetime", Convert.ToSingle(tbSetupLivetime.Text));
            msg.AddParameter("delay", 0);
            sendq.Enqueue(msg);
        }

        private void btnSetupStop_Click(object sender, EventArgs e)
        {
            sendq.Enqueue(new burn.Message("stop_session", null));
        }

        private void btnSetupStoreParams_Click(object sender, EventArgs e)
        {
            // Update settings FIXME
            SaveSettings();
        }

        private void btnSendSession_Click_1(object sender, EventArgs e)
        {

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
            mLabel = "Spectrum " + msg.Arguments["session_index"];
            mMessage = msg;
        }
    }
}
