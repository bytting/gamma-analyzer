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
        FormMap formMap = null;

        PointPairList setupGraphList = new PointPairList();
        PointPairList sessionGraphList = new PointPairList();
        PointPairList bkgGraphList = new PointPairList();

        Detector selectedDetector = null;
        DetectorType selectedDetectorType = null;

        float bkgScale = 1f;
        bool selectionRun = false;
        bool detectorReady = false;
        bool sessionRunning = false;

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

        private void sendMsg(burn.Message msg)
        {
            sendq.Enqueue(msg);
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
                    if (prev)
                        Utils.Log.Add("RECV: Preview session started");
                    else
                    {
                        string sessionName = msg.Arguments["session_name"].ToString();
                        Utils.Log.Add("RECV: New session started: " + sessionName);

                        float livetime = Convert.ToSingle(msg.Arguments["livetime"]);
                        int iterations = Convert.ToInt32(msg.Arguments["iterations"]);

                        string geScript = File.ReadAllText(selectedDetectorType.GEScriptPath);
                        session = new Session(settings.SessionRootDirectory, sessionName, livetime, iterations, selectedDetector, geScript);
                        session.SaveInfo();

                        formWaterfallLive.SetSession(session);
                        formROILive.SetSession(session);
                        formMap.SetSession(session);

                        sessionRunning = true;
                    }
                    break;

                case "new_session_failed":
                    Utils.Log.Add("RECV: New session failed: " + msg.Arguments["message"]);
                    break;

                case "stop_session_ok":
                    Utils.Log.Add("RECV: Session stopped");
                    sessionRunning = false;
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
                    selectedDetector.CurrentHV = Convert.ToInt32(msg.Arguments["voltage"]);
                    selectedDetector.CurrentCoarseGain = Convert.ToDouble(msg.Arguments["coarse_gain"]);
                    selectedDetector.CurrentFineGain = Convert.ToDouble(msg.Arguments["fine_gain"]);
                    selectedDetector.CurrentNumChannels = Convert.ToInt32(msg.Arguments["num_channels"]);
                    selectedDetector.CurrentLLD = Convert.ToInt32(msg.Arguments["lld"]);
                    selectedDetector.CurrentULD = Convert.ToInt32(msg.Arguments["uld"]);
                    detectorReady = true;
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

                        if (session.IsLoaded && Utils.EnergyCalculationFunc != null)
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
                int idx1 = lbSession.FindStringExact(session.Info.Name + " - " + e.StartIndex.ToString());
                if (idx1 != ListBox.NoMatches)
                    lbSession.SetSelected(idx1, true);
            }
            else
            {
                int idx1 = lbSession.FindStringExact(session.Info.Name + " - " + e.StartIndex.ToString());
                int idx2 = lbSession.FindStringExact(session.Info.Name + " - " + e.EndIndex.ToString());
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
            formMap.ClearSession();

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

        private void PopulateDetectors()
        {
            cboxSetupDetector.Items.Clear();
            cboxSetupDetector.Items.AddRange(settings.Detectors.ToArray());
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
                ListViewItem item = new ListViewItem(new string[] { dt.Name, dt.MaxNumChannels.ToString(), dt.MinHV.ToString(), dt.MaxHV.ToString(), dt.GEScriptPath });
                item.Tag = dt;
                lvDetectorTypes.Items.Add(item);
            }
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
