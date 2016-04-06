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
using System.Xml;
using System.Xml.Serialization;
using ZedGraph;

namespace crash
{
    public partial class FormMain : Form
    {
        private static string SettingsPath = Environment.GetFolderPath(Environment.SpecialFolder.CommonDocuments) + Path.DirectorySeparatorChar + "crash";
        private static string SettingsFile = SettingsPath + Path.DirectorySeparatorChar + "settings.xml";
        
        Settings settings = new Settings();

        static ConcurrentQueue<burn.Message> sendq = null;
        static ConcurrentQueue<burn.Message> recvq = null;

        static burn.NetService netService = new burn.NetService(ref sendq, ref recvq);
        static Thread netThread = new Thread(netService.DoWork);
        
        System.Windows.Forms.Timer timer = new System.Windows.Forms.Timer();

        bool connected = false;
        Session session = null;        
        
        FormConnect formConnect = new FormConnect();        
        FormWaterfallLive formWaterfallLive = new FormWaterfallLive();
        FormWaterfallHistory formWaterfallHist = new FormWaterfallHistory();
        FormROITableHistory formROIHistory = new FormROITableHistory();
        FormMap formMap = new FormMap();        

        PointPairList setupGraphList = new PointPairList();
        PointPairList sessionGraphList = new PointPairList();        

        public FormMain()
        {
            InitializeComponent();            
        }

        private void FormMain_Load(object sender, EventArgs e)
        {
            formWaterfallLive.SetSessionIndexEvent += SetSessionIndexEvent;
            formMap.SetSessionIndexEvent += SetSessionIndexEvent;
            formROIHistory.SetSessionIndexEvent += SetSessionIndexEvent;

            tabs.HideTabs = true;
            tabs.SelectedTab = pageMenu;

            lblConnectionStatus.ForeColor = Color.Red;
            lblConnectionStatus.Text = "Not connected";

            if (!Directory.Exists(SettingsPath))
                Directory.CreateDirectory(SettingsPath);

            if (File.Exists(SettingsFile))            
                LoadSettings();

            LoadBackgroundSessions();

            netThread.Start();
            while (!netThread.IsAlive);            
                    
            timer.Interval = 10;
            timer.Tick += timer_Tick;
            timer.Start();                                    
        }

        void SetSessionIndexEvent(object sender, SetSessionIndexEventArgs e)
        {
            if (e.StartIndex >= lbSession.Items.Count || e.EndIndex >= lbSession.Items.Count || e.StartIndex < 0 || e.EndIndex < 0)
                return;

            lbSession.ClearSelected();

            if (e.StartIndex > e.EndIndex)
            {
                int tmp = e.StartIndex;
                e.StartIndex = e.EndIndex;
                e.EndIndex = tmp;
            }

            if (e.StartIndex == e.EndIndex)
            {
                int idx1 = lbSession.FindStringExact(session.Name + " - " + e.StartIndex.ToString());
                if (idx1 != ListBox.NoMatches)             
                    lbSession.SetSelected(idx1, true);                
            }
            else
            {
                int idx1 = lbSession.FindStringExact(session.Name + " - " + e.StartIndex.ToString());
                int idx2 = lbSession.FindStringExact(session.Name + " - " + e.EndIndex.ToString());
                for(int i=idx1; i<idx2; i++)
                {
                    lbSession.SetSelected(i, true);
                }
            }
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

            SaveSettings();
        }        

        public void LoadBackgroundSessions()
        {
            cboxBackground.Items.Clear();
            cboxBackground.Items.Add("");
            string[] sessionDirectories = Directory.GetDirectories(settings.SessionDirectory);
            foreach(string sessDir in sessionDirectories)
            {
                cboxBackground.Items.Add(new DirectoryInfo(sessDir).Name);
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

        private bool dispatchRecvMsg(burn.Message msg)
        {            
            switch (msg.Command)
            {
                case "connect_ok":
                    lblConnectionStatus.ForeColor = Color.Green;
                    lblConnectionStatus.Text = "Connected to " + msg.Arguments["host"] + ":" + msg.Arguments["port"];
                    Utils.Log.Add("Connected to " + msg.Arguments["host"] + ":" + msg.Arguments["port"]);
                    connected = true;
                    break;

                case "connect_failed":
                    lblConnectionStatus.ForeColor = Color.Red;
                    lblConnectionStatus.Text = "Connection failed for " + msg.Arguments["host"] + ":" + msg.Arguments["port"] + " " + msg.Arguments["message"];
                    Utils.Log.Add("Connection failed for " + msg.Arguments["host"] + ":" + msg.Arguments["port"] + " " + msg.Arguments["message"]);
                    connected = false;
                    break;

                case "disconnect_ok":
                    lblConnectionStatus.ForeColor = Color.Red;
                    lblConnectionStatus.Text = "Not connected";
                    Utils.Log.Add("Disconnected from peer");
                    connected = false;
                    break;

                case "close_ok":
                    netService.RequestStop();
                    netThread.Join();
                    lblConnectionStatus.ForeColor = Color.Red;
                    lblConnectionStatus.Text = "Not connected";
                    Utils.Log.Add("Disconnected from peer, peer closed");
                    break;

                case "new_session_ok":
                    bool prev = msg.Arguments["preview"] == "1";
                    if(prev)
                        Utils.Log.Add("Preview received");
                    else
                    {
                        string session_name = msg.Arguments["session_name"];
                        Utils.Log.Add("New session created: " + session_name);
                        
                        session = new Session(session_name);
                        formWaterfallLive.SetSession(session);
                        formROIHistory.SetSession(session);
                        formMap.SetSession(session);                        
                    }                        
                    break;

                case "new_session_failed":
                    Utils.Log.Add("New session failed: " + msg.Arguments["message"]);
                    break;

                case "stop_session_ok":
                    Utils.Log.Add("Session stopped");
                    break;

                case "session_finished":
                    Utils.Log.Add("Session " + msg.Arguments["session_name"] + " finished");
                    LoadBackgroundSessions();
                    break;

                case "error":
                    Utils.Log.Add("Error: " + msg.Arguments["message"]);
                    break;

                case "error_socket":
                    Utils.Log.Add("Socket error: " + msg.Arguments["error_code"] + " " + msg.Arguments["message"]);
                    break;                

                case "set_gain_ok":
                    Utils.Log.Add("set gain: " + msg.Arguments["voltage"] + " " + msg.Arguments["coarse_gain"] + " " + msg.Arguments["fine_gain"]);
                    break;

                case "spectrum":
                    Spectrum spec = new Spectrum(msg);
                    Utils.Log.Add(spec.Label + " received");

                    string path;

                    if (spec.IsPreview)
                    {
                        path = SettingsPath;                        

                        GraphPane pane = graphSetup.GraphPane;
                        pane.Chart.Fill = new Fill(SystemColors.ButtonFace);
                        pane.Fill = new Fill(SystemColors.ButtonFace);                        

                        pane.Title.Text = "Setup";
                        pane.XAxis.Title.Text = "Channel";
                        pane.YAxis.Title.Text = "Counts";

                        setupGraphList.Clear();
                        for (int i = 0; i < spec.Channels.Count; i++)
                            setupGraphList.Add((double)i, (double)spec.Channels[i]);

                        pane.XAxis.Scale.Min = 0;
                        pane.XAxis.Scale.Max = spec.MaxCount;

                        pane.YAxis.Scale.Min = 0;
                        pane.YAxis.Scale.Max = spec.MaxCount + (spec.MaxCount / 10.0);

                        pane.CurveList.Clear();

                        LineItem curve = pane.AddCurve("Spectrum", setupGraphList, Color.Red, SymbolType.None);
                        curve.Line.Fill = new Fill(SystemColors.ButtonFace, Color.Red, 45F);                        
                        pane.Chart.Fill = new Fill(SystemColors.ButtonFace, SystemColors.ButtonFace);
                        pane.Legend.Fill = new Fill(SystemColors.ButtonFace, SystemColors.ButtonFace);                        
                        pane.Fill = new Fill(SystemColors.ButtonFace, SystemColors.ButtonFace);                        

                        graphSetup.RestoreScale(pane);
                        graphSetup.AxisChange();
                        graphSetup.Refresh();                        
                    }
                    else
                    {                        
                        path = settings.SessionDirectory + Path.DirectorySeparatorChar + spec.SessionName;                        
                        session.Add(spec);

                        // Add list node
                        lbSession.Items.Insert(0, spec);

                        formMap.AddMarker(spec);
                        formWaterfallLive.UpdatePane();
                        formROIHistory.UpdatePane();
                    }                        

                    string jsonPath = path + Path.DirectorySeparatorChar + "json";
                    if (!Directory.Exists(jsonPath))
                        Directory.CreateDirectory(jsonPath);

                    string filename = jsonPath + Path.DirectorySeparatorChar + spec.SessionIndex + ".json";
                    TextWriter writer = new StreamWriter(filename);
                    writer.Write(msg.ToJson(true));
                    writer.Close();

                    if(cbStoreChn.Checked)
                    {
                        string chnPath = path + Path.DirectorySeparatorChar + "chn";
                        if (!Directory.Exists(chnPath))
                            Directory.CreateDirectory(chnPath);
                        filename = chnPath + Path.DirectorySeparatorChar + spec.SessionIndex + ".chn";                        
                        burn.CHN.Write(filename, msg);
                    }
                    break;

                default:
                    string info = msg.Command + " -> ";
                    foreach (KeyValuePair<string, string> item in msg.Arguments)
                        info += item.Key + ":" + item.Value + ", ";
                    Utils.Log.Add("Unhandeled command: " + info);
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
            formConnect.IP = settings.LastIP;
            formConnect.Port = settings.LastPort;
            if (formConnect.ShowDialog() != System.Windows.Forms.DialogResult.OK)
                return;

            settings.LastIP = formConnect.IP;
            settings.LastPort = formConnect.Port;

            burn.Message msg = new burn.Message("connect", null);
            msg.AddParameter("host", formConnect.IP);
            msg.AddParameter("port", formConnect.Port);            
            sendq.Enqueue(msg);           
        }

        private void menuItemDisconnect_Click(object sender, EventArgs e)
        {        
            if(connected)
                if (MessageBox.Show("Are you sure you want to disconnect?", "Confirmation", MessageBoxButtons.YesNo) == DialogResult.No)
                    return;

            sendq.Enqueue(new burn.Message("disconnect", null));
        }        

        private void btnSendClose_Click(object sender, EventArgs e)
        {
            if (MessageBox.Show("Are you sure you want to close the remote server?", "Confirmation", MessageBoxButtons.YesNo) == DialogResult.No)
                return;

            sendq.Enqueue(new burn.Message("close", null));                        
        }

        private void btnSendSession_Click(object sender, EventArgs e)
        {
            if (String.IsNullOrEmpty(settings.SessionDirectory))
            {
                MessageBox.Show("You must provide a session directory under preferences");
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

            lbSession.Items.Clear();

            burn.Message msg = new burn.Message("new_session", null);
            msg.AddParameter("session_name", String.Format("{0:ddMMyyyy_HHmmss}", DateTime.Now));
            msg.AddParameter("preview", 0);
            msg.AddParameter("iterations", count);
            msg.AddParameter("livetime", livetime);
            msg.AddParameter("delay", delay);
            sendq.Enqueue(msg);            
        }        

        private void btnStopNetService_Click(object sender, EventArgs e)
        {
            netService.RequestStop();
            netThread.Join();
        }                
        
        private void btnStopSession_Click(object sender, EventArgs e)
        {
            sendq.Enqueue(new burn.Message("stop_session", null));
        }
        
        private void btnMenuSpec_Click(object sender, EventArgs e)
        {
            tabs.SelectedTab = pageSetup;
        }

        private void btnBack_Click(object sender, EventArgs e)
        {
            tabs.SelectedTab = pageMenu;
        }        

        private void btnMenuMap_Click(object sender, EventArgs e)
        {
            tabs.SelectedTab = pageSession;
        }        

        private void btnMenuSession_Click(object sender, EventArgs e)
        {
            tabs.SelectedTab = pageSession;
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

        private void menuItemPreferences_Click(object sender, EventArgs e)
        {
            FormPreferences form = new FormPreferences(settings);
            form.ShowDialog();
        }

        private void btnShowWaterfall_Click(object sender, EventArgs e)
        {
            formWaterfallLive.Show();
            formWaterfallLive.BringToFront();
            formWaterfallLive.UpdatePane();
        }
                
        private void btnMenuBackgrounds_Click(object sender, EventArgs e)
        {
            tabs.SelectedTab = pageBackground;
        }

        private void tabs_SelectedIndexChanged(object sender, EventArgs e)
        {
            lblInterface.Text = tabs.SelectedTab.Text;

            if (tabs.SelectedTab == pageMenu)
                btnBack.Enabled = false;
            else btnBack.Enabled = true;

            if (tabs.SelectedTab == pageSession)
            {
                btnShowWaterfallLive.Visible = true;
                btnShowWaterfallHist.Visible = true;
            }
            else
            {
                btnShowWaterfallLive.Visible = false;
                btnShowWaterfallHist.Visible = false;
            }
        }        

        private void btnShowWaterfallHist_Click(object sender, EventArgs e)
        {
            //formWaterfallHist.Show();
            //formWaterfallHist.BringToFront();
        }                

        private void btnShowROIChart_Click(object sender, EventArgs e)
        {
            formROIHistory.Show();
            formROIHistory.BringToFront();
        }

        private void btnShowMap_Click(object sender, EventArgs e)
        {
            formMap.Show();
            formMap.BringToFront();
        }

        private void btnShowLog_Click(object sender, EventArgs e)
        {
            Utils.Log.Show();
            Utils.Log.BringToFront();
        }

        public void ShowSpectrum(string title, float[] channels, float maxCount)
        {
            GraphPane pane = graphSession.GraphPane;
            pane.Chart.Fill = new Fill(SystemColors.ButtonFace);
            pane.Fill = new Fill(SystemColors.ButtonFace);

            pane.Title.Text = title;
            pane.XAxis.Title.Text = "Channel";
            pane.YAxis.Title.Text = "Counts";

            sessionGraphList.Clear();
            for (int i = 0; i < channels.Length; i++)
                sessionGraphList.Add((double)i, (double)channels[i]);

            pane.XAxis.Scale.Min = 0;
            pane.XAxis.Scale.Max = maxCount;

            pane.YAxis.Scale.Min = 0;
            pane.YAxis.Scale.Max = maxCount + (maxCount / 10.0);

            pane.CurveList.Clear();

            LineItem curve = pane.AddCurve("Spectrum", sessionGraphList, Color.Red, SymbolType.None);
            curve.Line.Fill = new Fill(SystemColors.ButtonFace, Color.Red, 45F);
            pane.Chart.Fill = new Fill(SystemColors.ButtonFace, SystemColors.ButtonFace);
            pane.Legend.Fill = new Fill(SystemColors.ButtonFace, SystemColors.ButtonFace);
            pane.Fill = new Fill(SystemColors.ButtonFace, SystemColors.ButtonFace);

            graphSession.RestoreScale(pane);
            graphSession.AxisChange();
            graphSession.Refresh();
        }

        private void lbSession_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (lbSession.SelectedItems.Count < 1)
                return;
            else if (lbSession.SelectedItems.Count == 1)
            {
                Spectrum s = lbSession.SelectedItem as Spectrum;
                ShowSpectrum(s.SessionName + " - " + s.SessionIndex.ToString(), s.Channels.ToArray(), s.MaxCount);
                lblRealtime.Text = "Realtime:" + s.Realtime.ToString();
                lblLivetime.Text = "Livetime:" + s.Livetime.ToString();
                lblSession.Text = "Session name: " + s.SessionName;
                lblIndex.Text = "Session index: " + s.SessionIndex.ToString();
                lblLatitudeStart.Text = "Lat. start: " + s.LatitudeStart.ToString();
                lblLongitudeStart.Text = "Lon. start: " + s.LongitudeStart.ToString();
                lblAltitudeStart.Text = "Alt. start: " + s.AltitudeStart.ToString();
                lblLatitudeEnd.Text = "Lat. end: " + s.LatitudeEnd.ToString();
                lblLongitudeEnd.Text = "Lon. end: " + s.LongitudeEnd.ToString();
                lblAltitudeEnd.Text = "Alt. end: " + s.AltitudeEnd.ToString();
                lblGpsTimeStart.Text = "Gps time start: " + s.GpsTimeStart.ToString();
                lblGpsTimeEnd.Text = "Gps time end: " + s.GpsTimeEnd.ToString();
                lblMaxCount.Text = "Max count: " + s.MaxCount.ToString();
                lblMinCount.Text = "Min count: " + s.MinCount.ToString();
                lblTotalCount.Text = "Total count: " + s.TotalCount.ToString();

                formWaterfallLive.SetSelectedSessionIndex(s.SessionIndex);
                formMap.SetSelectedSessionIndex(s.SessionIndex);
                formROIHistory.SetSelectedSessionIndex(s.SessionIndex);
            }
            else
            {
                int selMin = lbSession.SelectedIndices[0], selMax = lbSession.SelectedIndices[0];

                for (int i = 0; i < lbSession.SelectedIndices.Count; i++)
                {
                    if (selMin > lbSession.SelectedIndices[i])
                        selMin = lbSession.SelectedIndices[i];
                    if (selMax < lbSession.SelectedIndices[i])
                        selMax = lbSession.SelectedIndices[i];
                }

                if (selMin == selMax)
                    return;

                Spectrum s1 = (Spectrum)lbSession.Items[selMax];
                Spectrum s2 = (Spectrum)lbSession.Items[selMin];

                int chanCount = (int)s1.NumChannels;

                string title = "Merged: " + s1.SessionIndex.ToString() + " - " + s2.SessionIndex.ToString();
                float[] chans = new float[chanCount];
                float maxChan = 0f;
                for(int i=0; i<lbSession.SelectedItems.Count; i++)
                {
                    Spectrum s = (Spectrum)lbSession.SelectedItems[i];
                    for(int j=0; j<s.NumChannels; j++)
                    {
                        chans[j] += s.Channels[j];
                        if(chans[j] > maxChan)
                            maxChan = chans[j];
                    }
                }

                ShowSpectrum(title, chans, maxChan);                

                formWaterfallLive.SetSelectedSessionIndices(s1.SessionIndex, s2.SessionIndex);
                formMap.SetSelectedSessionIndices(s1.SessionIndex, s2.SessionIndex);
                formROIHistory.SetSelectedSessionIndices(s1.SessionIndex, s2.SessionIndex);
            }
        }        

        private void btnShow3D_Click(object sender, EventArgs e)
        {            
        }
    }    
}
