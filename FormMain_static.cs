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
// Authors: Dag Robole,

using System;
using System.IO;
using System.Xml;
using System.Xml.Serialization;
using System.Drawing;
using System.Collections.Generic;
using System.Collections.Concurrent;
using System.Text;
using System.Threading;
using System.Globalization;
using System.Windows.Forms;
using ZedGraph;
using Newtonsoft.Json;

namespace crash
{
    public partial class FormMain
    {
        CrashSettings settings = new CrashSettings();

        static ConcurrentQueue<burn.Message> sendq = null;
        static ConcurrentQueue<burn.Message> recvq = null;

        static burn.NetService netService = new burn.NetService(ref sendq, ref recvq);
        static Thread netThread = new Thread(netService.DoWork);

        System.Windows.Forms.Timer timer = new System.Windows.Forms.Timer();

        bool connected = false;
        Session session = new Session();
        
        FormWaterfallLive formWaterfallLive = null;
        FormROILive formROILive = null;
        FormMap frmMap = null;

        PointPairList setupGraphList = new PointPairList();
        PointPairList sessionGraphList = new PointPairList();
        PointPairList bkgGraphList = new PointPairList();        

        float bkgScale = 1f;
        bool selectionRun = false;        
        bool sessionRunning = false;

        List<NuclideInfo> NuclideLibrary = new List<NuclideInfo>();

        Spectrum previewSpec = null;
        List<EnergyComp> energyLines = new List<EnergyComp>();
        List<double> coefficients = new List<double>();

        private void SaveSettings()
        {
            using (StreamWriter sw = new StreamWriter(CrashEnvironment.SettingsFile))
            {
                XmlSerializer x = new XmlSerializer(settings.GetType());
                x.Serialize(sw, settings);
            }
        }

        private void LoadSettings()
        {
            if (!File.Exists(CrashEnvironment.SettingsFile))
                return;

            using (StreamReader sr = new StreamReader(CrashEnvironment.SettingsFile))
            {
                XmlSerializer x = new XmlSerializer(settings.GetType());
                settings = x.Deserialize(sr) as CrashSettings;
            }
        }

        private bool LoadNuclideLibrary()
        {
            if (!File.Exists(CrashEnvironment.NuclideLibraryFile))
                return false;

            using (TextReader reader = File.OpenText(CrashEnvironment.NuclideLibraryFile))
            {
                NuclideLibrary.Clear();
                char[] itemDelims = new char[] { ' ', '\t' };
                char[] energyDelims = new char[] { ':' };
                string line;
                while ((line = reader.ReadLine()) != null)
                {
                    line = line.Trim();
                    if (String.IsNullOrEmpty(line) || line.StartsWith("#"))
                        continue;
                    string[] items = line.Split(itemDelims, StringSplitOptions.RemoveEmptyEntries);
                    string name = items[0];
                    double halfLife = Convert.ToDouble(items[1], CultureInfo.InvariantCulture);
                    string halfLifeUnit = items[2];

                    NuclideInfo ni = new NuclideInfo(name, halfLife, halfLifeUnit);

                    for (int i = 3; i < items.Length; i++)
                    {
                        string[] energy = items[i].Split(energyDelims, StringSplitOptions.RemoveEmptyEntries);
                        double e = Convert.ToDouble(energy[0], CultureInfo.InvariantCulture);
                        double p = Convert.ToDouble(energy[1], CultureInfo.InvariantCulture);
                        ni.Energies.Add(new NuclideEnergy(e, p));
                    }

                    NuclideLibrary.Add(ni);
                }             
            }
            return true;
        }

        private void sendMsg(burn.Message msg)
        {
            sendq.Enqueue(msg);
        }

        private bool dispatchRecvMsg(burn.Message msg)
        {
            Detector det = null;
            DetectorType detType = null;

            switch (msg.Command)
            {
                case "connect_ok":                    
                    Utils.Log.Add("RECV: Connected to " + msg.Arguments["host"] + ":" + msg.Arguments["port"]);

                    burn.Message msgPing = new burn.Message("ping", null);
                    sendMsg(msgPing);
                    Utils.Log.Add("SEND: Sending ping message");
                    break;

                case "connect_failed":
                    connected = false;                    
                    Utils.Log.Add("RECV: Connection failed for " + msg.Arguments["host"] + ":" + msg.Arguments["port"] + " " + msg.Arguments["message"]);                    
                    break;

                case "disconnect_ok":
                    connected = false;
                    lblConnectionStatus.ForeColor = Color.Red;
                    lblConnectionStatus.Text = "Not connected";
                    Utils.Log.Add("RECV: Disconnected from peer");

                    if (tabs.SelectedTab == pageSetup)
                        tabs.SelectedTab = pageSessions;
                    break;

                case "ping_ok":                    
                    connected = true;
                    lblConnectionStatus.ForeColor = Color.Green;
                    lblConnectionStatus.Text = "Connected to " + settings.LastIP + ":" + settings.LastPort;                    
                    Utils.Log.Add("RECV: Received ping_ok from peer");
                    break;

                case "close_ok":
                    netService.RequestStop();
                    netThread.Join();
                    connected = false;
                    lblConnectionStatus.ForeColor = Color.Red;
                    lblConnectionStatus.Text = "Not connected";
                    Utils.Log.Add("RECV: Disconnected from peer, peer closed");
                    break;

                case "new_session_ok":
                    bool prev = msg.Arguments["preview"].ToString() == "1";
                    if (prev)
                        Utils.Log.Add("RECV: Preview session started");
                    else
                    {
                        string sessionName = msg.Arguments["session_name"].ToString();
                        Utils.Log.Add("RECV: New session started: " + sessionName);

                        float livetime = Convert.ToSingle(msg.Arguments["livetime"]);
                        int iterations = Convert.ToInt32(msg.Arguments["iterations"]);

                        det = (Detector)cboxSetupDetector.SelectedItem;
                        detType = settings.DetectorTypes.Find(dt => dt.Name == det.TypeName);                        
                        session = new Session(settings.SessionRootDirectory, sessionName, "", livetime, iterations, det, detType);

                        SaveSession(session);                        

                        formWaterfallLive.SetSession(session);
                        formROILive.SetSession(session);
                        frmMap.SetSession(session);

                        sessionRunning = true;
                    }
                    btnSetupStartTest.Enabled = false;
                    btnSetupStopTest.Enabled = true;
                    break;

                case "new_session_failed":
                    Utils.Log.Add("RECV: New session failed: " + msg.Arguments["message"]);
                    break;

                case "stop_session_ok":
                    Utils.Log.Add("RECV: Session stopped");
                    sessionRunning = false;
                    btnSetupStartTest.Enabled = true;
                    btnSetupStopTest.Enabled = false;
                    break;

                case "session_finished":
                    Utils.Log.Add("RECV: Session " + msg.Arguments["session_name"] + " finished");
                    sessionRunning = false;
                    break;

                case "error":
                    Utils.Log.Add("RECV: Error: " + msg.Arguments["message"]);
                    break;

                case "error_socket":
                    Utils.Log.Add("RECV: Socket error: " + msg.Arguments["error_code"] + " " + msg.Arguments["message"]);
                    break;

                case "set_gain_ok":
                    Utils.Log.Add("RECV: set_gain ok: " + msg.Arguments["voltage"] + " " + msg.Arguments["coarse_gain"] + " "
                        + msg.Arguments["fine_gain"] + " " + msg.Arguments["num_channels"] + " " + msg.Arguments["lld"] + " "
                        + msg.Arguments["uld"]);

                    det = (Detector)cboxSetupDetector.SelectedItem;

                    det.CurrentHV = Convert.ToInt32(msg.Arguments["voltage"]);
                    det.CurrentCoarseGain = Convert.ToDouble(msg.Arguments["coarse_gain"]);
                    det.CurrentFineGain = Convert.ToDouble(msg.Arguments["fine_gain"]);
                    det.CurrentNumChannels = Convert.ToInt32(msg.Arguments["num_channels"]);
                    det.CurrentLLD = Convert.ToInt32(msg.Arguments["lld"]);
                    det.CurrentULD = Convert.ToInt32(msg.Arguments["uld"]);

                    btnSetupNext.Enabled = true;
                    panelSetupGraph.Enabled = true;
                    break;

                case "spectrum":

                    Spectrum spec = new Spectrum(msg);
                    spec.CalculateDoserate(session.Detector, session.GEFactor);

                    if (spec.IsPreview)
                    {
                        Utils.Log.Add("RECV: " + spec.Label + " preview spectrum received");

                        if (previewSpec == null)
                            previewSpec = spec;
                        else previewSpec = previewSpec.Merge(spec);                        

                        GraphPane pane = graphSetup.GraphPane;
                        pane.Chart.Fill = new Fill(SystemColors.ButtonFace);
                        pane.Fill = new Fill(SystemColors.ButtonFace);

                        pane.Title.Text = "Setup";
                        pane.XAxis.Title.Text = "Channel";
                        pane.YAxis.Title.Text = "Counts";

                        setupGraphList.Clear();
                        for (int i = 0; i < previewSpec.Channels.Count; i++)
                            setupGraphList.Add((double)i, (double)previewSpec.Channels[i]);

                        pane.XAxis.Scale.Min = 0;
                        pane.XAxis.Scale.Max = previewSpec.MaxCount;

                        pane.YAxis.Scale.Min = 0;
                        pane.YAxis.Scale.Max = previewSpec.MaxCount + (previewSpec.MaxCount / 10.0);

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

                        string sessionPath = settings.SessionRootDirectory + Path.DirectorySeparatorChar + session.Name;
                        string jsonPath = sessionPath + Path.DirectorySeparatorChar + "json";
                        if (!Directory.Exists(jsonPath))
                            Directory.CreateDirectory(jsonPath);

                        string json = JsonConvert.SerializeObject(msg, Newtonsoft.Json.Formatting.Indented);
                        using (TextWriter writer = new StreamWriter(jsonPath + Path.DirectorySeparatorChar + spec.SessionIndex + ".json"))
                        {
                            writer.Write(json);
                        }

                        session.Add(spec);

                        // Add list node
                        lbSession.Items.Insert(0, spec);

                        frmMap.AddMarker(spec);
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

        public void SaveSession(Session s)
        {
            string sessionSettingsFile = settings.SessionRootDirectory + Path.DirectorySeparatorChar + s.Name + Path.DirectorySeparatorChar + "session.json";
            string jSessionInfo = JsonConvert.SerializeObject(s, Newtonsoft.Json.Formatting.Indented);
            using (TextWriter writer = new StreamWriter(sessionSettingsFile))
            {
                writer.Write(jSessionInfo);
            }            
        }

        void SetSessionIndexEvent(object sender, SetSessionIndexEventArgs e)
        {
            if (e.StartIndex == -1 && e.EndIndex == -1)
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
                int idx1 = lbSession.FindStringExact(session.Name + " - " + e.StartIndex.ToString());
                if (idx1 != ListBox.NoMatches)
                    lbSession.SetSelected(idx1, true);
            }
            else
            {
                int idx1 = lbSession.FindStringExact(session.Name + " - " + e.StartIndex.ToString());
                int idx2 = lbSession.FindStringExact(session.Name + " - " + e.EndIndex.ToString());
                for (int i = idx1; i < idx2; i++)
                {
                    if (i == idx2 - 1)
                        selectionRun = false;

                    lbSession.SetSelected(i, true);

                    if (i == idx1)
                        selectionRun = true;
                }
            }
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
            lblSessionDetector.Text = "";
            graphSession.GraphPane.CurveList.Clear();
            graphSession.GraphPane.GraphObjList.Clear();
            graphSession.Invalidate();
            ClearSpectrumInfo();            

            formWaterfallLive.ClearSession();
            formROILive.ClearSession();
            frmMap.ClearSession();

            session.Clear();
        }

        private void ClearBackground()
        {
            session.SetBackground(null);

            lblBackground.Text = "";
            graphSession.Invalidate();
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

            if (session.Background != null)
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

        private void GetGraphPointFromMousePos(int posX, int posY, ZedGraphControl graph, out int x, out int y)
        {            
            int index = 0;
            object nearestobject = null;
            PointF clickedPoint = new PointF(posX, posY);
            graph.GraphPane.FindNearestObject(clickedPoint, this.CreateGraphics(), out nearestobject, out index);
            double dx, dy;
            graph.GraphPane.ReverseTransform(clickedPoint, out dx, out dy);
            x = (int)dx;
            y = (int)dy;
        }        

        private void PopulateDetectorTypeList()
        {
            lvDetectorTypes.Items.Clear();
            foreach (DetectorType dt in settings.DetectorTypes)
            {
                ListViewItem item = new ListViewItem(
                    new string[] { 
                        dt.Name, 
                        dt.MaxNumChannels.ToString(), 
                        dt.MinHV.ToString(), 
                        dt.MaxHV.ToString(),
                        dt.GEScript
                });
                item.Tag = dt;
                lvDetectorTypes.Items.Add(item);
            }
        }

        private void PopulateDetectors()
        {
            cboxSetupDetector.Items.Clear();
            foreach (Detector d in settings.Detectors)
                cboxSetupDetector.Items.Add(d);
        }

        private void PopulateDetectorList()
        {
            lvDetectors.Items.Clear();
            foreach (Detector d in settings.Detectors)
            {
                ListViewItem item = new ListViewItem(new string[] {                     
                    d.Serialnumber, 
                    d.TypeName, 
                    d.CurrentNumChannels.ToString(), 
                    d.CurrentHV.ToString(), 
                    d.CurrentCoarseGain.ToString(), 
                    d.CurrentFineGain.ToString(),                    
                    d.CurrentLivetime.ToString(),
                    d.CurrentLLD.ToString(),
                    d.CurrentULD.ToString()
                });
                item.Tag = d;
                lvDetectors.Items.Add(item);
            }
        }
    }
}
