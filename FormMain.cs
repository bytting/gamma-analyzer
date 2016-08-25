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
// Authors: Dag robole,

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
using System.Globalization;
using ZedGraph;
//using IronPython.Hosting;
//using IronPython.Runtime;
using Microsoft.Scripting;
using Microsoft.Scripting.Hosting;
using Newtonsoft.Json;

namespace crash
{
    public partial class FormMain : Form
    {        
        CrashSettings settings = new CrashSettings();

        static ConcurrentQueue<burn.Message> sendq = null;
        static ConcurrentQueue<burn.Message> recvq = null;

        static burn.NetService netService = new burn.NetService(ref sendq, ref recvq);
        static Thread netThread = new Thread(netService.DoWork);
        
        System.Windows.Forms.Timer timer = new System.Windows.Forms.Timer();

        bool connected = false;
        Session session = new Session();
        //Session background = new Session();

        FormConnect formConnect = null;
        FormWaterfallLive formWaterfallLive = null;
        FormROILive formROILive = null;
        FormMap formMap = null;        

        PointPairList setupGraphList = new PointPairList();
        PointPairList sessionGraphList = new PointPairList();
        PointPairList bkgGraphList = new PointPairList();

        Detector selectedDetector = null;
        DetectorType selectedDetectorType = null;
        
        float bkgScale = 1f;
        bool selectionRun = false;

        public FormMain()
        {
            InitializeComponent();            
        }

        private void FormMain_Load(object sender, EventArgs e)
        {            
            if (!Directory.Exists(CrashEnvironment.SettingsPath))
                Directory.CreateDirectory(CrashEnvironment.SettingsPath);            

            if (!Directory.Exists(CrashEnvironment.GEScriptPath))
                Directory.CreateDirectory(CrashEnvironment.GEScriptPath);

            try
            {
                string InstallDir = (new FileInfo(System.Reflection.Assembly.GetEntryAssembly().Location)).Directory + Path.DirectorySeparatorChar.ToString();

                File.Copy(InstallDir + "template_settings.xml", CrashEnvironment.SettingsFile, false);
                File.Copy(InstallDir + "template_Nai-2tom.py", CrashEnvironment.GEScriptPath + Path.DirectorySeparatorChar + "Nai-2tom.py", false);
                File.Copy(InstallDir + "template_Nai-3tom.py", CrashEnvironment.GEScriptPath + Path.DirectorySeparatorChar + "Nai-3tom.py", false);
            }
            catch { }
            
            LoadSettings();            

            formConnect = new FormConnect();
            formWaterfallLive = new FormWaterfallLive(settings.ROIList);
            formROILive = new FormROILive(settings.ROIList);            
            formMap = new FormMap();

            tabs.HideTabs = true;
            tabs.SelectedTab = pageMenu;

            lblConnectionStatus.ForeColor = Color.Red;
            lblConnectionStatus.Text = "Not connected";            
            lblSetupChannel.Text = "";
            lblSessionChannel.Text = "";
            lblSessionEnergy.Text = "";
            lblSetupEnergy.Text = "";
            lblDetector.Text = "";
            separatorDetector.Visible = false;

            lblBackground.Text = "";
            lblComment.Text = "";
            ClearSpectrumInfo();            

            formWaterfallLive.SetSessionIndexEvent += SetSessionIndexEvent;
            formMap.SetSessionIndexEvent += SetSessionIndexEvent;
            formROILive.SetSessionIndexEvent += SetSessionIndexEvent;

            PopulateDetectors();            

            netThread.Start();
            while (!netThread.IsAlive);            
                    
            timer.Interval = 10;
            timer.Tick += timer_Tick;
            timer.Start();            
        }        

        void SetSessionIndexEvent(object sender, SetSessionIndexEventArgs e)
        {
            if(e.StartIndex == -1 && e.EndIndex == -1)
            {
                lbSession.ClearSelected();
                return;
            }

            if (e.StartIndex >= lbSession.Items.Count || e.EndIndex >= lbSession.Items.Count || e.StartIndex < 0 || e.EndIndex < 0)
                return;

            lbSession.ClearSelected();

            if (e.StartIndex < e.EndIndex) // Bizarre, but true
            {
                int tmp = e.StartIndex;
                e.StartIndex = e.EndIndex;
                e.EndIndex = tmp;
            }            

            if (e.StartIndex == e.EndIndex)
            {
                int idx1 = lbSession.FindStringExact(session.Info.Name + " - " + e.StartIndex.ToString());
                if (idx1 != ListBox.NoMatches)             
                    lbSession.SetSelected(idx1, true);                
            }
            else
            {
                int idx1 = lbSession.FindStringExact(session.Info.Name + " - " + e.StartIndex.ToString());
                int idx2 = lbSession.FindStringExact(session.Info.Name + " - " + e.EndIndex.ToString());
                for(int i=idx1; i<idx2; i++)
                {
                    if (i == idx2 - 1)
                        selectionRun = false;

                    lbSession.SetSelected(i, true);

                    if (i == idx1)
                        selectionRun = true;
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

        private void SaveSettings()
        {
            StreamWriter sw = new StreamWriter(CrashEnvironment.SettingsFile);
            XmlSerializer x = new XmlSerializer(settings.GetType());
            x.Serialize(sw, settings);
            sw.Close();
        }

        private void LoadSettings()
        {
            if (File.Exists(CrashEnvironment.SettingsFile))
            {
                StreamReader sr = new StreamReader(CrashEnvironment.SettingsFile);
                XmlSerializer x = new XmlSerializer(settings.GetType());
                settings = x.Deserialize(sr) as CrashSettings;
                sr.Close();
            }
        }        

        private bool dispatchRecvMsg(burn.Message msg)
        {            
            switch (msg.Command)
            {
                case "connect_ok":
                    lblConnectionStatus.ForeColor = Color.Green;
                    lblConnectionStatus.Text = "Connected to " + msg.Arguments["host"] + ":" + msg.Arguments["port"];
                    Utils.Log.Add("RECV: Connected to " + msg.Arguments["host"] + ":" + msg.Arguments["port"]);
                    connected = true;
                    break;

                case "connect_failed":
                    lblConnectionStatus.ForeColor = Color.Red;
                    lblConnectionStatus.Text = "Connection failed for " + msg.Arguments["host"] + ":" + msg.Arguments["port"] + " " + msg.Arguments["message"];
                    Utils.Log.Add("RECV: Connection failed for " + msg.Arguments["host"] + ":" + msg.Arguments["port"] + " " + msg.Arguments["message"]);
                    connected = false;
                    break;

                case "disconnect_ok":
                    lblConnectionStatus.ForeColor = Color.Red;
                    lblConnectionStatus.Text = "Not connected";
                    Utils.Log.Add("RECV: Disconnected from peer");
                    connected = false;
                    break;

                case "close_ok":
                    netService.RequestStop();
                    netThread.Join();
                    lblConnectionStatus.ForeColor = Color.Red;
                    lblConnectionStatus.Text = "Not connected";
                    Utils.Log.Add("RECV: Disconnected from peer, peer closed");
                    break;

                case "new_session_ok":
                    bool prev = msg.Arguments["preview"].ToString() == "1";
                    if(prev)
                        Utils.Log.Add("RECV: Preview received");
                    else
                    {
                        string sessionName = msg.Arguments["session_name"].ToString();
                        Utils.Log.Add("RECV: New session created: " + sessionName);

                        float livetime = Convert.ToSingle(msg.Arguments["livetime"]);
                        int iterations = Convert.ToInt32(msg.Arguments["iterations"]);

                        string geScript = File.ReadAllText(selectedDetectorType.GEScriptPath);
                        session = new Session(settings.SessionRootDirectory, sessionName, livetime, iterations, selectedDetector, geScript);
                        session.SaveInfo();

                        formWaterfallLive.SetSession(session);
                        formROILive.SetSession(session);
                        formMap.SetSession(session);                        
                    }                        
                    break;

                case "new_session_failed":
                    Utils.Log.Add("RECV: New session failed: " + msg.Arguments["message"]);
                    break;

                case "stop_session_ok":
                    Utils.Log.Add("RECV: Session stopped");
                    break;

                case "session_finished":
                    Utils.Log.Add("RECV: Session " + msg.Arguments["session_name"] + " finished");                    
                    break;

                case "error":
                    Utils.Log.Add("RECV: Error: " + msg.Arguments["message"]);
                    break;

                case "error_socket":
                    Utils.Log.Add("RECV: Socket error: " + msg.Arguments["error_code"] + " " + msg.Arguments["message"]);
                    break;                

                case "set_gain_ok":
                    Utils.Log.Add("RECV: set_gain ok: " + msg.Arguments["voltage"] + " " + msg.Arguments["coarse_gain"] + " " + msg.Arguments["fine_gain"]);
                    selectedDetector.CurrentHV = Convert.ToInt32(msg.Arguments["voltage"]);
                    selectedDetector.CurrentCoarseGain = Convert.ToDouble(msg.Arguments["coarse_gain"]);
                    selectedDetector.CurrentFineGain = Convert.ToDouble(msg.Arguments["fine_gain"]);
                    selectedDetector.CurrentNumChannels = Convert.ToInt32(msg.Arguments["num_channels"]);
                    selectedDetector.CurrentLLD = Convert.ToInt32(msg.Arguments["lld"]);
                    selectedDetector.CurrentULD = Convert.ToInt32(msg.Arguments["uld"]);
                    break;

                case "spectrum":

                    Spectrum spec = new Spectrum(msg);                    

                    if (spec.IsPreview)
                    {
                        Utils.Log.Add("RECV: " + spec.Label + " preview spectrum received");

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
                        Utils.Log.Add("RECV: " + spec.Label + " session spectrum received");

                        // Make sure session is allocated in case spectrums are ticking in                                              

                        string jsonPath = session.SessionPath + Path.DirectorySeparatorChar + "json";
                        if (!Directory.Exists(jsonPath))
                            Directory.CreateDirectory(jsonPath);

                        string json = JsonConvert.SerializeObject(msg, Newtonsoft.Json.Formatting.Indented);
                        TextWriter writer = new StreamWriter(jsonPath + Path.DirectorySeparatorChar + spec.SessionIndex + ".json");
                        writer.Write(json);
                        writer.Close();

                        if(session.IsLoaded)
                            spec.CalculateDoserate(session.Info.Detector, session.GEFactor);

                        session.Add(spec);

                        // Add list node
                        lbSession.Items.Insert(0, spec);

                        formMap.AddMarker(spec);
                        formWaterfallLive.UpdatePane();
                        formROILive.UpdatePane();                        
                    }                                            
                    break;

                default:
                    string info = msg.Command + " -> ";
                    foreach (KeyValuePair<string, object> item in msg.Arguments)
                        info += item.Key + ":" + item.Value.ToString() + ", ";
                    Utils.Log.Add("RECV: Unhandeled command: " + info);
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

            Utils.Log.Add("connect command sent");
        }

        private void menuItemDisconnect_Click(object sender, EventArgs e)
        {        
            if(connected)
                if (MessageBox.Show("Are you sure you want to disconnect?", "Confirmation", MessageBoxButtons.YesNo) == DialogResult.No)
                    return;

            sendq.Enqueue(new burn.Message("disconnect", null));

            Utils.Log.Add("SEND: disconnect");
        }        

        private void btnSendClose_Click(object sender, EventArgs e)
        {
            if (MessageBox.Show("Are you sure you want to close the remote server?", "Confirmation", MessageBoxButtons.YesNo) == DialogResult.No)
                return;

            sendq.Enqueue(new burn.Message("close", null));

            Utils.Log.Add("SEND: close");          
        }

        private void btnSendSession_Click(object sender, EventArgs e)
        {
            if (String.IsNullOrEmpty(settings.SessionRootDirectory))
            {
                MessageBox.Show("You must provide a session directory under preferences");
                return;
            }   
            
            if(selectedDetector == null)
            {
                MessageBox.Show("You must specify a detector under setup");
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

            ClearSession();

            burn.Message msg = new burn.Message("new_session", null);
            msg.AddParameter("session_name", String.Format("{0:ddMMyyyy_HHmmss}", DateTime.Now));
            msg.AddParameter("preview", 0);
            msg.AddParameter("iterations", count);
            msg.AddParameter("livetime", livetime);
            msg.AddParameter("delay", delay);
            sendq.Enqueue(msg);

            Utils.Log.Add("SEND: new_session");
        }

        private void ClearSpectrumInfo()
        {
            lblSession.Text = "";
            lblRealtime.Text = "";
            lblLivetime.Text = "";            
            lblIndex.Text = "";            
            lblLatitudeStart.Text = "";
            lblLongitudeStart.Text = "";
            lblAltitudeStart.Text = "";
            lblLatitudeEnd.Text = "";
            lblLongitudeEnd.Text = "";
            lblAltitudeEnd.Text = "";
            lblGpsTimeStart.Text = "";
            lblGpsTimeEnd.Text = "";
            lblMaxCount.Text = "";
            lblMinCount.Text = "";
            lblTotalCount.Text = "";
            lblDoserate.Text = "";
            lblSessionChannel.Text = "";
            lblSessionEnergy.Text = "";
        }

        private void ClearSession()
        {
            lbSession.Items.Clear();
            graphSession.GraphPane.CurveList.Clear();
            graphSession.GraphPane.GraphObjList.Clear();
            graphSession.Invalidate();
            ClearSpectrumInfo();

            formWaterfallLive.ClearSession();
            formROILive.ClearSession();
            formMap.ClearSession();

            session.Clear();            
        }

        private void ClearBackground()
        {
            session.SetBackground(null);

            lblBackground.Text = "";
            graphSession.Invalidate();            
        }

        private void btnStopNetService_Click(object sender, EventArgs e)
        {
            netService.RequestStop();
            netThread.Join();

            Utils.Log.Add("net service closed");
        }                
        
        private void btnStopSession_Click(object sender, EventArgs e)
        {
            sendq.Enqueue(new burn.Message("stop_session", null));

            Utils.Log.Add("SEND: stop_session");
        }
        
        private void btnMenuSpec_Click(object sender, EventArgs e)
        {
            tabs.SelectedTab = pageSetup;
        }        

        private void btnMenuSession_Click(object sender, EventArgs e)
        {
            tabs.SelectedTab = pageSession;
        }
        
        private void btnSetupSetParams_Click(object sender, EventArgs e)
        {
            /*if(!connected)
            {
                MessageBox.Show("Can not set parameters. Not connected");
                return;
            }*/                        

            int voltage = tbarSetupVoltage.Value;                        
            double coarse = 0f;
            double fine = 0f;

            try
            {
                coarse = Convert.ToSingle(cboxSetupCoarseGain.Text);
                fine = Convert.ToDouble((double)tbarSetupFineGain.Value / 1000d);
            }
            catch
            {
                MessageBox.Show("Gain: Invalid format (fine gain or coarse gain");
                return;
            }

            int nchannels = 256;
            int lld = 1;
            int uld = 256;

            nchannels = Convert.ToInt32(cboxSetupChannels.Text);
            
            lld = tbarSetupLLD.Value;
            uld = tbarSetupULD.Value;            
            if(lld > uld)
            {
                MessageBox.Show("LLD can not be bigger than ULD");
                return;
            }
            
            burn.Message msg = new burn.Message("set_gain", null);
            msg.AddParameter("voltage", voltage);
            msg.AddParameter("coarse_gain", coarse);
            msg.AddParameter("fine_gain", fine);
            msg.AddParameter("num_channels", nchannels);
            msg.AddParameter("lld", lld);
            msg.AddParameter("uld", uld);
            sendq.Enqueue(msg);

            Utils.Log.Add("SEND: set_gain");
        }

        private void btnSetupStart_Click(object sender, EventArgs e)
        {            
            double livetime = (double)tbarSetupLivetime.Value;                        

            burn.Message msg = new burn.Message("new_session", null);
            msg.AddParameter("session_name", String.Format("{0:ddMMyyyy_HHmmss}", DateTime.Now));
            msg.AddParameter("preview", 1);
            msg.AddParameter("iterations", 1);
            msg.AddParameter("livetime", livetime);
            msg.AddParameter("delay", 0);
            sendq.Enqueue(msg);

            Utils.Log.Add("SEND: new_session (preview)");
        }

        private void btnSetupStop_Click(object sender, EventArgs e)
        {
            sendq.Enqueue(new burn.Message("stop_session", null));

            Utils.Log.Add("SEND: stop_session");
        }

        private void menuItemPreferences_Click(object sender, EventArgs e)
        {
            FormPreferences form = new FormPreferences(settings);
            if(form.ShowDialog() == System.Windows.Forms.DialogResult.OK)
            {
                PopulateDetectors();
            }
        }
        
        private void tabs_SelectedIndexChanged(object sender, EventArgs e)
        {
            lblInterface.Text = tabs.SelectedTab.Text;

            btnBack.Enabled = true;
            btnShowMap.Enabled = false;
            menuItemShowMap.Enabled = false;
            btnShowWaterfallLive.Enabled = false;
            menuItemShowWaterfall.Enabled = false;
            btnShowROIChart.Enabled = false;
            menuItemShowROIChart.Enabled = false;
            btnShowROIHist.Enabled = false;
            menuItemShowROIHistory.Enabled = false;
            btnShow3D.Enabled = false;
            menuItemShow3DMap.Enabled = false;

            if (tabs.SelectedTab == pageMenu)            
                btnBack.Enabled = false;            

            if (tabs.SelectedTab == pageSession)
            {
                btnShowMap.Enabled = true;
                menuItemShowMap.Enabled = true;
                btnShowWaterfallLive.Enabled = true;
                menuItemShowWaterfall.Enabled = true;
                btnShowROIChart.Enabled = true;
                menuItemShowROIChart.Enabled = true;
                btnShowROIHist.Enabled = true;
                menuItemShowROIHistory.Enabled = true;
                btnShow3D.Enabled = true;
                menuItemShow3DMap.Enabled = true;
            }            
        }        

        public void ShowSpectrum(string title, float[] channels, float maxCount, float minCount)
        {
            GraphPane pane = graphSession.GraphPane;
            pane.Chart.Fill = new Fill(SystemColors.ButtonFace);
            pane.Fill = new Fill(SystemColors.ButtonFace);

            pane.Title.Text = title;
            pane.XAxis.Title.Text = "Channel";
            pane.YAxis.Title.Text = "Counts";                        

            pane.XAxis.Scale.Min = 0;
            pane.XAxis.Scale.Max = maxCount;

            pane.YAxis.Scale.Min = minCount;
            pane.YAxis.Scale.Max = maxCount + (maxCount / 10.0);

            pane.CurveList.Clear();            
            
            if(session.Background != null)            
            {                
                bkgGraphList.Clear();
                for (int i = 0; i < session.Background.Length; i++)
                    bkgGraphList.Add((double)i, (double)session.Background[i] * bkgScale);

                LineItem bkgCurve = pane.AddCurve("Background", bkgGraphList, Color.Blue, SymbolType.None);
                bkgCurve.Line.IsSmooth = true;
                bkgCurve.Line.SmoothTension = 0.5f;
            }
            
            sessionGraphList.Clear();            
            for (int i = 0; i < channels.Length; i++)
                sessionGraphList.Add((double)i, (double)channels[i]);

            LineItem curve = pane.AddCurve("Spectrum", sessionGraphList, Color.Red, SymbolType.None);
            curve.Line.IsSmooth = true;
            curve.Line.SmoothTension = 0.5f;
            
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
            {
                formWaterfallLive.SetSelectedSessionIndex(-1);
                formMap.SetSelectedSessionIndex(-1);
                formROILive.SetSelectedSessionIndex(-1);
                return;
            }                
            else if (lbSession.SelectedItems.Count == 1)
            {
                bkgScale = 1;
                Spectrum s = lbSession.SelectedItem as Spectrum;
                ShowSpectrum(s.SessionName + " - " + s.SessionIndex.ToString(), s.Channels.ToArray(), s.MaxCount, s.MinCount);
                lblRealtime.Text = "Realtime:" + ((double)s.Realtime) / 1000000.0;
                lblLivetime.Text = "Livetime:" + ((double)s.Livetime) / 1000000.0;
                lblSession.Text = "Session: " + s.SessionName;
                lblIndex.Text = "Index: " + s.SessionIndex;                
                lblLatitudeStart.Text = "Lat. start: " + s.LatitudeStart;
                lblLongitudeStart.Text = "Lon. start: " + s.LongitudeStart;
                lblAltitudeStart.Text = "Alt. start: " + s.AltitudeStart;
                lblLatitudeEnd.Text = "Lat. end: " + s.LatitudeEnd;
                lblLongitudeEnd.Text = "Lon. end: " + s.LongitudeEnd;
                lblAltitudeEnd.Text = "Alt. end: " + s.AltitudeEnd;
                lblGpsTimeStart.Text = "Gps time start: " + s.GpsTimeStart;
                lblGpsTimeEnd.Text = "Gps time end: " + s.GpsTimeEnd;
                lblMaxCount.Text = "Max count: " + s.MaxCount;
                lblMinCount.Text = "Min count: " + s.MinCount;
                lblTotalCount.Text = "Total count: " + s.TotalCount;
                if(s.Doserate == 0.0)
                    lblDoserate.Text = "";
                else lblDoserate.Text = "Doserate: " + String.Format("{0:###0.0##}", s.Doserate);

                formWaterfallLive.SetSelectedSessionIndex(s.SessionIndex);
                formMap.SetSelectedSessionIndex(s.SessionIndex);
                formROILive.SetSelectedSessionIndex(s.SessionIndex);
            }
            else
            {
                if (selectionRun == true)
                    return;

                bkgScale = (float)lbSession.SelectedIndices.Count;

                Spectrum s1 = (Spectrum)lbSession.Items[lbSession.SelectedIndices[lbSession.SelectedIndices.Count - 1]];
                Spectrum s2 = (Spectrum)lbSession.Items[lbSession.SelectedIndices[0]];

                double realTime = 0;
                double liveTime = 0;

                string title = "Merged: " + s1.SessionIndex + " - " + s2.SessionIndex;
                float[] chans = new float[(int)s1.NumChannels];
                float maxCnt = s1.MaxCount, minCnt = s1.MinCount;
                float totCnt = 0;                
                for(int i=0; i<lbSession.SelectedItems.Count; i++)
                {
                    Spectrum s = (Spectrum)lbSession.SelectedItems[i];
                    for(int j=0; j<s.NumChannels; j++)                    
                        chans[j] += s.Channels[j];                                            

                    if (s.MaxCount > maxCnt)
                        maxCnt = s.MaxCount;
                    if (s.MinCount < minCnt)
                        minCnt = s.MinCount;

                    totCnt += s.TotalCount;                

                    realTime += ((double)s.Realtime) / 1000000.0;
                    liveTime += ((double)s.Livetime) / 1000000.0;                    
                }

                ShowSpectrum(title, chans, maxCnt, minCnt);

                lblRealtime.Text = "Realtime:" + realTime;
                lblLivetime.Text = "Livetime:" + liveTime;
                lblSession.Text = "Session: " + s1.SessionName;
                lblIndex.Text = "Index: " + s1.SessionIndex + " - " + s2.SessionIndex;                
                lblLatitudeStart.Text = "Lat. start: " + s1.LatitudeStart;
                lblLongitudeStart.Text = "Lon. start: " + s1.LongitudeStart;
                lblAltitudeStart.Text = "Alt. start: " + s1.AltitudeStart;
                lblLatitudeEnd.Text = "Lat. end: " + s2.LatitudeEnd;
                lblLongitudeEnd.Text = "Lon. end: " + s2.LongitudeEnd;
                lblAltitudeEnd.Text = "Alt. end: " + s2.AltitudeEnd;
                lblGpsTimeStart.Text = "Gps time start: " + s1.GpsTimeStart;
                lblGpsTimeEnd.Text = "Gps time end: " + s2.GpsTimeEnd;
                lblMaxCount.Text = "Max count: " + maxCnt;
                lblMinCount.Text = "Min count: " + minCnt;
                lblTotalCount.Text = "Total count: " + totCnt;                
                lblDoserate.Text = "";

                formWaterfallLive.SetSelectedSessionIndices(s1.SessionIndex, s2.SessionIndex);
                formMap.SetSelectedSessionIndices(s1.SessionIndex, s2.SessionIndex);
                formROILive.SetSelectedSessionIndices(s1.SessionIndex, s2.SessionIndex);
            }
        }                        

        private void menuItemAbout_Click(object sender, EventArgs e)
        {
            About about = new About();
            about.ShowDialog();            
        }        

        private void PopulateDetectors()
        {
            cboxSetupDetector.Items.Clear();      
            cboxSetupDetector.Items.AddRange(settings.Detectors.ToArray());            
        }        

        private void menuItemLoadSession_Click(object sender, EventArgs e)
        {            
            FolderBrowserDialog dialog = new FolderBrowserDialog();            
            dialog.SelectedPath = settings.SessionRootDirectory;
            dialog.Description = "Select session directory";
            dialog.ShowNewFolderButton = false;
            if(dialog.ShowDialog() == System.Windows.Forms.DialogResult.OK)
            {
                ClearSession();
                session.Load(dialog.SelectedPath);
                lblComment.Text = session.Info.Comment;

                formWaterfallLive.SetSession(session);
                formROILive.SetSession(session);
                formMap.SetSession(session);                

                foreach(Spectrum s in session.Spectrums)
                {
                    lbSession.Items.Insert(0, s);
                    formMap.AddMarker(s);                    
                }                

                formWaterfallLive.UpdatePane();
                formROILive.UpdatePane();

                lblSession.Text = "Session: " + session.Info.Name;

                Utils.Log.Add("session " + session.Info.Name + " loaded");
            }
        }        

        private void menuItemLoadBackgroundSession_Click(object sender, EventArgs e)
        {
            if (!session.IsLoaded)
            {
                MessageBox.Show("Session is not loaded");
                return;
            }

            FolderBrowserDialog dialog = new FolderBrowserDialog();            
            dialog.SelectedPath = settings.SessionRootDirectory;
            dialog.Description = "Select background session directory";
            dialog.ShowNewFolderButton = false;
            if (dialog.ShowDialog() == System.Windows.Forms.DialogResult.OK)
            {
                ClearBackground();
                Session bkgSess = new Session();
                bkgSess.Load(dialog.SelectedPath);

                if (bkgSess.NumChannels != session.NumChannels)
                {
                    bkgSess.Clear();
                    MessageBox.Show("Cannot load a background with different number of channels than the session");
                    return;
                }

                session.SetBackground(bkgSess);

                lblBackground.Text = "Background: " + bkgSess.Info.Name;

                Utils.Log.Add("Background " + bkgSess.Info.Name + " loaded for session " + session.Info.Name);
            }
        }

        private void menuItemROITable_Click(object sender, EventArgs e)
        {
            FormROITable form = new FormROITable(settings.ROIList);
            form.ShowDialog();            
        }                

        private void graphSetup_MouseMove(object sender, MouseEventArgs e)
        {
            // Get point from graph
            int index = 0;
            object nearestobject = null;
            PointF clickedPoint = new PointF(e.X, e.Y);
            graphSetup.GraphPane.FindNearestObject(clickedPoint, this.CreateGraphics(), out nearestobject, out index);        
            double x, y;            
            graphSetup.GraphPane.ReverseTransform(clickedPoint, out x, out y);

            lblSetupChannel.Text = "Ch: " + String.Format("{0:###0}", x);

            // Show energy
            if (selectedDetector != null)
            {
                Detector det = selectedDetector;
                double slope = (det.RegPoint2Y - det.RegPoint1Y) / (det.RegPoint2X - det.RegPoint1X);
                double E = det.RegPoint1Y + ((double)x * slope - det.RegPoint1X * slope);
                lblSetupEnergy.Text = "En: " + String.Format("{0:###0.0###}", E);
            }
            else lblSetupEnergy.Text = "";
        }

        private void graphSession_MouseMove(object sender, MouseEventArgs e)
        {
            // Get point from graph
            int index = 0;
            object nearestobject = null;
            PointF clickedPoint = new PointF(e.X, e.Y);
            graphSession.GraphPane.FindNearestObject(clickedPoint, this.CreateGraphics(), out nearestobject, out index);
            double x, y;
            graphSession.GraphPane.ReverseTransform(clickedPoint, out x, out y);

            lblSessionChannel.Text = "Ch: " + String.Format("{0:###0}", x);

            // Show energy
            if (session.IsLoaded)
            {
                Detector det = session.Info.Detector;
                double slope = (det.RegPoint2Y - det.RegPoint1Y) / (det.RegPoint2X - det.RegPoint1X);
                double E = det.RegPoint1Y + ((double)x * slope - det.RegPoint1X * slope);
                lblSessionEnergy.Text = "En: " + String.Format("{0:###0.0###}", E);
            }
            else lblSessionEnergy.Text = "";
        }

        private void menuItemSessionUnselect_Click(object sender, EventArgs e)
        {
            lbSession.ClearSelected();            
        }

        private void cboxSetupDetector_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (cboxSetupDetector.SelectedItem == null)
                return;

            selectedDetector = (Detector)cboxSetupDetector.SelectedItem;
            selectedDetectorType = settings.DetectorTypes.Find(dt => dt.Name == selectedDetector.TypeName);

            lblDetector.Text = "Detector " + selectedDetector.Serialnumber;
            separatorDetector.Visible = true;
            
            btnMenuSession.Enabled = true;
            btnShowRegressionPoints.Enabled = true;

            cboxSetupChannels.Text = selectedDetector.CurrentNumChannels.ToString();

            tbarSetupVoltage.Minimum = selectedDetectorType.MinHV;
            tbarSetupVoltage.Maximum = selectedDetectorType.MaxHV;
            tbarSetupVoltage.Value = selectedDetector.CurrentHV;

            int coarse = Convert.ToInt32(selectedDetector.CurrentCoarseGain);
            cboxSetupCoarseGain.SelectedIndex = cboxSetupCoarseGain.FindStringExact(coarse.ToString());
            tbarSetupFineGain.Value = (int)((double)selectedDetector.CurrentFineGain * 1000d);
            tbarSetupLLD.Value = selectedDetector.CurrentLLD;
            tbarSetupULD.Value = selectedDetector.CurrentULD;
            cboxSetupChannels.Items.Clear();
            for(int i = 256; i <= selectedDetectorType.MaxNumChannels; i = i * 2)            
                cboxSetupChannels.Items.Add(i.ToString());
            cboxSetupChannels.Text = selectedDetector.CurrentNumChannels.ToString();

            tbarSetupLivetime.Value = (selectedDetector.CurrentLivetime <= tbarSetupLivetime.Maximum) ? selectedDetector.CurrentLivetime : 1;
        }

        private void menuItemSessionInfo_Click(object sender, EventArgs e)
        {
            if(session == null || !session.IsLoaded)
            {
                MessageBox.Show("Can not open session info. No session loaded");
                return;
            }

            FormSessionInfo form = new FormSessionInfo(session, "Session Info");
            if(form.ShowDialog() == System.Windows.Forms.DialogResult.OK)
            {
                session.SaveInfo();
                lblComment.Text = session.Info.Comment;
            }
        }        

        private void menuItemClearSession_Click(object sender, EventArgs e)
        {
            ClearSession();
        }

        private void menuItemClearBackground_Click(object sender, EventArgs e)
        {
            ClearBackground();
        }                

        private void menuItemShowMap_Click(object sender, EventArgs e)
        {
            formMap.Show();
            formMap.BringToFront();
        }

        private void menuItemShowWaterfall_Click(object sender, EventArgs e)
        {
            formWaterfallLive.Show();
            formWaterfallLive.BringToFront();
            formWaterfallLive.UpdatePane();
        }

        private void menuItemShowROIChart_Click(object sender, EventArgs e)
        {
            formROILive.Show();
            formROILive.BringToFront();
        }

        private void menuItemShowROIHistory_Click(object sender, EventArgs e)
        {
            FormROIHist form = new FormROIHist(session, settings.ROIList);
            form.ShowDialog();
        }

        private void menuItemShow3DMap_Click(object sender, EventArgs e)
        {
            MessageBox.Show("3D not implemented");
        }

        private void menuItemBack_Click(object sender, EventArgs e)
        {
            tabs.SelectedTab = pageMenu;
        }

        private void menuItemShowLog_Click(object sender, EventArgs e)
        {
            Utils.Log.Show();
            Utils.Log.BringToFront();
        }

        private void menuItemSaveAsCHN_Click(object sender, EventArgs e)
        {
            if (session.IsEmpty)
            {
                MessageBox.Show("No session active");
                return;
            }

            FolderBrowserDialog dialog = new FolderBrowserDialog();
            dialog.ShowNewFolderButton = true;
            dialog.Description = "Select folder to store CHN files";
            if (dialog.ShowDialog() == System.Windows.Forms.DialogResult.OK)
            {
                try
                {
                    SessionExporter.ExportAsCHN(session, dialog.SelectedPath);
                    Utils.Log.Add("session " + session.Info.Name + " stored with CHN format in " + dialog.SelectedPath);
                }
                catch (Exception ex)
                {
                    Utils.Log.Add("Failed to export session " + session.Info.Name + " with CHN format in " + dialog.SelectedPath);
                    MessageBox.Show("Failed to export session to CHN format: " + ex.Message);
                }
            }
        }

        private void menuItemRegressionPoints_Click(object sender, EventArgs e)
        {
            if (selectedDetector == null)
            {
                MessageBox.Show("You must select a detector first");
                return;
            }

            FormRegressionPoints form = new FormRegressionPoints(selectedDetector);
            form.Show();
        }

        private void menuItemSourceActivity_Click(object sender, EventArgs e)
        {
            if (lbSession.SelectedItems.Count != 1)
            {
                MessageBox.Show("You must select a single spectrum");
                return;
            }
                
            Spectrum s = lbSession.SelectedItem as Spectrum;
            FormSourceActivity form = new FormSourceActivity(settings, s);
            form.ShowDialog();
        }

        private void tbarSetupFineGain_Scroll(object sender, EventArgs e)
        {
            tbarSetupFineGain_ValueChanged(sender, e);
        }

        private void tbarSetupFineGain_ValueChanged(object sender, EventArgs e)
        {
            double fVal = (double)tbarSetupFineGain.Value / 1000d;
            lblSetupFineGain.Text = fVal.ToString("F3");
        }

        private void tbarSetupVoltage_ValueChanged(object sender, EventArgs e)
        {
            lblSetupVoltage.Text = tbarSetupVoltage.Value.ToString();
        }

        private void tbarSetupLLD_ValueChanged(object sender, EventArgs e)
        {
            lblSetupLLD.Text = tbarSetupLLD.Value.ToString();
        }

        private void tbarSetupULD_ValueChanged(object sender, EventArgs e)
        {
            lblSetupULD.Text = tbarSetupULD.Value.ToString();
        }

        private void tbarSetupLivetime_ValueChanged(object sender, EventArgs e)
        {
            lblSetupLivetime.Text = tbarSetupLivetime.Value.ToString();
        }
    }    
}
