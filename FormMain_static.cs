/*	
	Gamma Analyzer - Controlling application for Burn
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
using System.Data.SQLite;

namespace crash
{
    public partial class FormMain
    {
        bool appInitialized = false;

        // Structure with application settings stored on disk
        GASettings settings = new GASettings();
        
        // Concurrent queue used to pass messages to networking thread
        static ConcurrentQueue<burn.ProtocolMessage> sendq = null;
        // Concurrent queue used to receive messages from network thread
        static ConcurrentQueue<burn.ProtocolMessage> recvq = null;
        // FIXME: Create a proper API for communication with network thread

        // Networking thread
        static burn.NetService netService = new burn.NetService(ref sendq, ref recvq);
        static Thread netThread = new Thread(netService.DoWork);

        // Timer used to poll for network messages
        System.Windows.Forms.Timer timer = new System.Windows.Forms.Timer();        

        // Currently loaded sessions
        Session session = null, bkgSession = null;

        // External forms
        FormWaterfallLive formWaterfallLive = null;
        FormROILive formROILive = null;
        FormMap frmMap = null;

        // Point lists with graph data
        PointPairList setupGraphList = new PointPairList();
        PointPairList sessionGraphList = new PointPairList();
        PointPairList bkgGraphList = new PointPairList();

        string InstallDir;     

        // Livetime scale factor for currently loaded background
        float bkgScale = 1f;

        // Flag used for tracking multi selection of spectrums
        bool selectionRun = false;

        // Structure containing loaded nuclide library
        List<NuclideInfo> NuclideLibrary = new List<NuclideInfo>();

        bool previewSession = false;        

        TabPage returnFromSetup = null;

        // Spectrum used to accumulate counts for setup UI
        Spectrum previewSpec = null;

        Detector selectedDetector = null;

        // Array containing currently selected energies/channels
        List<ChannelEnergy> energyLines = new List<ChannelEnergy>();

        // Array containing curve fitting coefficients
        List<double> coefficients = new List<double>();

        // Enumeration used to keep track of graph object types
        public enum GraphObjectType
        {
            Spectrum,
            Background,
            Energy,
            EnergyTolerance,
            EnergyCalibration
        };

        public void makeGraphObjectType(ref object tag, GraphObjectType got)
        {
            // Create a graph object type
            tag = new GraphObjectType();
            tag = got;
        }

        public bool isGraphObjectType(object tag, GraphObjectType got)
        {
            // Check graph object type
            return tag != null && (GraphObjectType)tag == got;
        }

        private void SaveSettings()
        {
            // Serialize settings to file
            using (StreamWriter sw = new StreamWriter(GAEnvironment.SettingsFile))
            {
                XmlSerializer x = new XmlSerializer(settings.GetType());
                x.Serialize(sw, settings);
            }
        }

        private void LoadSettings()
        {
            if (!File.Exists(GAEnvironment.SettingsFile))
                SaveSettings();

            // Deserialize settings from file
            using (StreamReader sr = new StreamReader(GAEnvironment.SettingsFile))
            {
                XmlSerializer x = new XmlSerializer(settings.GetType());
                settings = x.Deserialize(sr) as GASettings;
            }
        }

        private bool LoadNuclideLibrary()
        {
            if (!File.Exists(GAEnvironment.NuclideLibraryFile))
                return false;

            // Load nuclide library from file
            using (TextReader reader = File.OpenText(GAEnvironment.NuclideLibraryFile))
            {
                NuclideLibrary.Clear();
                char[] itemDelims = new char[] { ' ', '\t' };
                char[] energyDelims = new char[] { ':' };
                string line;
                while ((line = reader.ReadLine()) != null)
                {
                    line = line.Trim();
                    if (String.IsNullOrEmpty(line) || line.StartsWith("#")) // Skip comments
                        continue;
                    string[] items = line.Split(itemDelims, StringSplitOptions.RemoveEmptyEntries);
                    string name = items[0];
                    double halfLife = Convert.ToDouble(items[1], CultureInfo.InvariantCulture);
                    string halfLifeUnit = items[2];

                    // Parse nuclide
                    NuclideInfo ni = new NuclideInfo(name, halfLife, halfLifeUnit);

                    // Parse energies
                    for (int i = 3; i < items.Length; i++)
                    {
                        string[] energy = items[i].Split(energyDelims, StringSplitOptions.RemoveEmptyEntries);
                        double e = Convert.ToDouble(energy[0], CultureInfo.InvariantCulture);
                        double p = Convert.ToDouble(energy[1], CultureInfo.InvariantCulture);
                        ni.Energies.Add(new NuclideEnergy(e, p));
                    }

                    // Store nuclide
                    NuclideLibrary.Add(ni);
                }             
            }
            return true;
        }

        private void sendMsg(burn.ProtocolMessage msg)
        {
            // Put a message on the network queue
            sendq.Enqueue(msg);
        }

        private bool dispatchRecvMsg(burn.ProtocolMessage msg)
        {
            // Handle messages received from network                        

            switch (msg.Params["command"].ToString())
            {
                case "get_status_success":                    
                    Utils.Log.Add("Get status success");

                    double freeDisk = Convert.ToDouble(msg.Params["free_disk_space"]);
                    freeDisk /= 1000000;
                    lblStatusFreeDiskSpace.Text = "Free disk space: " + freeDisk.ToString("#########0.0#") + " MB";

                    bool sessionRunning = Convert.ToBoolean(msg.Params["session_running"]);
                    lblStatusSessionRunning.Text = "Session running: " + sessionRunning;
                    if (!sessionRunning)
                        btnStatusNext.Enabled = true;

                    int spectrumIndex = Convert.ToInt32(msg.Params["spectrum_index"]);
                    lblStatusSpectrumIndex.Text = "Spectrum index: " + spectrumIndex;

                    bool detectorConfigured = Convert.ToBoolean(msg.Params["detector_configured"]);
                    lblStatusDetectorConfigured.Text = "Detector configured: " + detectorConfigured;

                    break;

                case "start_session_success":
                    // New session created successfully                    
                    if (previewSession)
                    {
                        // New session is a preview session, update log
                        Utils.Log.Add("Session started: " + msg.Params["session_name"]);
                    }
                    else
                    {
                        // New session is a normal session
                        string sessionName = msg.Params["session_name"].ToString();
                        Utils.Log.Add("Session started: " + sessionName);

                        ClearSession();

                        string ip = msg.Params["ip"].ToString();
                        float livetime = Convert.ToSingle(msg.Params["livetime"]);
                        string comment = msg.Params["comment"].ToString();
                        string sessionFile = settings.SessionRootDirectory + Path.DirectorySeparatorChar + sessionName + ".db";

                        DetectorType selectedDetectorType = settings.DetectorTypes.Find(dt => dt.Name == selectedDetector.TypeName);
                        session = new Session(ip, sessionFile, sessionName, comment, livetime, selectedDetector, selectedDetectorType);

                        // Create session database
                        CreateSessionFile(session);

                        lblSession.Text = session.Name;
                        lblComment.Text = session.Comment;

                        // Notify external forms about new session
                        formWaterfallLive.SetSession(session);
                        formROILive.SetSession(session);
                        frmMap.SetSession(session);

                        tabs.SelectedTab = pageSessions;
                    }
                    btnSetupStartTest.Enabled = false;
                    btnSetupStopTest.Enabled = true;
                    break;

                case "start_session_error":
                    // Creation of new session failed, log error message
                    Utils.Log.Add(msg.Params["message"].ToString());
                    break;

                case "stop_session_success":
                    // Stop session successful, update state
                    Utils.Log.Add("Session stopped");
                    btnSetupStartTest.Enabled = true;
                    btnSetupStopTest.Enabled = false;
                    break;

                case "stop_session_error":
                    // Session stopped successfully
                    Utils.Log.Add(msg.Params["message"].ToString());
                    break;

                case "error":
                    // An error occurred, log error message
                    Utils.Log.Add(msg.Params["message"].ToString());
                    break;                

                case "error_socket":
                    // An socket error occurred, log error message
                    Utils.Log.Add("Socket error: " + msg.Params["message"]);
                    break;

                case "detector_config_success":
                    // Set gain command executed successfully
                    Utils.Log.Add("detector_config_success: " + msg.Params["detector_type"] + " " + msg.Params["voltage"] + " " 
                        + msg.Params["coarse_gain"] + " " + msg.Params["fine_gain"] + " " + msg.Params["num_channels"] + " " 
                        + msg.Params["lld"] + " " + msg.Params["uld"]);

                    // Update selected detector parameters
                    selectedDetector.CurrentHV = Convert.ToInt32(msg.Params["voltage"]);
                    selectedDetector.CurrentCoarseGain = Convert.ToDouble(msg.Params["coarse_gain"], CultureInfo.InvariantCulture);
                    selectedDetector.CurrentFineGain = Convert.ToDouble(msg.Params["fine_gain"], CultureInfo.InvariantCulture);
                    selectedDetector.CurrentNumChannels = Convert.ToInt32(msg.Params["num_channels"]);
                    selectedDetector.CurrentLLD = Convert.ToInt32(msg.Params["lld"]);
                    selectedDetector.CurrentULD = Convert.ToInt32(msg.Params["uld"]);

                    SaveSettings();

                    // Update state                    
                    panelSetupGraph.Enabled = true;
                    break;

                case "spectrum":
                    // Session spectrum received successfully
                    Spectrum spec = new Spectrum(msg);                    

                    if (previewSession)
                    {
                        // Spectrum is a preview spectrum
                        Utils.Log.Add(spec.Label + " received");

                        // Merge spectrum with the preview spectrum
                        if (previewSpec == null)
                            previewSpec = spec;
                        else previewSpec.Merge(spec);

                        // Reset and prepare setup graph
                        GraphPane pane = graphSetup.GraphPane;
                        pane.Chart.Fill = new Fill(SystemColors.ButtonFace);
                        pane.Fill = new Fill(SystemColors.ButtonFace);

                        pane.Title.Text = "Setup";
                        pane.XAxis.Title.Text = "Channel";
                        pane.YAxis.Title.Text = "Counts";

                        // Update setup graph
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
                        // Normal session spectrum received
                        Utils.Log.Add(spec.Label + " received");

                        // Add spectrum to database
                        string sessionPath = settings.SessionRootDirectory + Path.DirectorySeparatorChar + spec.SessionName + ".db";
                        if(!File.Exists(sessionPath))
                        {
                            MessageBox.Show("Unable to find session database: " + sessionPath);
                            return false;
                        }

                        SQLiteConnection connection = new SQLiteConnection("Data Source=" + sessionPath + "; Version=3; FailIfMissing=True; Foreign Keys=True;");
                        connection.Open();
                        SQLiteCommand command = new SQLiteCommand(connection);
                        command.CommandText = "select id from session where name = @name";
                        command.Parameters.AddWithValue("@name", spec.SessionName);
                        int sessionId = Convert.ToInt32(command.ExecuteScalar());

                        command.Parameters.Clear();
                        command.CommandText = @"
insert into spectrums(session_id, session_name, session_index, start_time, latitude, latitude_error, longitude, longitude_error, altitude, altitude_error, track, track_error, speed, speed_error, climb, climb_error, livetime, realtime, total_count, num_channels, channels) 
values (@session_id, @session_name, @session_index, @start_time, @latitude, @latitude_error, @longitude, @longitude_error, @altitude, @altitude_error, @track, @track_error, @speed, @speed_error, @climb, @climb_error, @livetime, @realtime, @total_count, @num_channels, @channels)";

                        command.Parameters.AddWithValue("@session_id", sessionId);
                        command.Parameters.AddWithValue("@session_name", spec.SessionName);
                        command.Parameters.AddWithValue("@session_index", spec.SessionIndex);
                        command.Parameters.AddWithValue("@start_time", spec.GpsTime.ToString("yyyy-MM-ddTHH:mm:ss.fff", CultureInfo.InvariantCulture));
                        command.Parameters.AddWithValue("@latitude", spec.Latitude);
                        command.Parameters.AddWithValue("@latitude_error", spec.LatitudeError);
                        command.Parameters.AddWithValue("@longitude", spec.Longitude);
                        command.Parameters.AddWithValue("@longitude_error", spec.LongitudeError);
                        command.Parameters.AddWithValue("@altitude", spec.Altitude);
                        command.Parameters.AddWithValue("@altitude_error", spec.AltitudeError);
                        command.Parameters.AddWithValue("@track", spec.GpsTrack);
                        command.Parameters.AddWithValue("@track_error", spec.GpsTrackError);
                        command.Parameters.AddWithValue("@speed", spec.GpsSpeed);
                        command.Parameters.AddWithValue("@speed_error", spec.GpsSpeedError);
                        command.Parameters.AddWithValue("@climb", spec.GpsClimb);
                        command.Parameters.AddWithValue("@climb_error", spec.GpsClimbError);
                        command.Parameters.AddWithValue("@livetime", spec.Livetime);
                        command.Parameters.AddWithValue("@realtime", spec.Realtime);
                        command.Parameters.AddWithValue("@total_count", spec.TotalCount);
                        command.Parameters.AddWithValue("@num_channels", spec.NumChannels);
                        command.Parameters.AddWithValue("@channels", string.Join(" ", spec.Channels.ToArray()));                        
                        command.ExecuteNonQuery();

                        connection.Close();

                        // Add spectrum to session
                        if (session != null && session.IsLoaded && session.Name == spec.SessionName)
                        {
                            spec.CalculateDoserate(session.Detector, session.GEFactor);

                            session.Add(spec);

                            // Add spectrum to UI list
                            bool updateSelectedIndex = false;
                            if (lbSession.SelectedIndex == 0)
                                updateSelectedIndex = true;

                            lbSession.Items.Insert(0, spec);

                            if (updateSelectedIndex)
                            {
                                lbSession.ClearSelected();
                                lbSession.SetSelected(0, true);
                            }

                            // Notify external forms about new spectrum
                            frmMap.AddMarker(spec);
                            formWaterfallLive.UpdatePane();
                            formROILive.UpdatePane();
                        }                        
                    }
                    break;

                default:
                    // Unhandled message received, update log
                    Utils.Log.Add("Unknown message: " + msg.Params["command"].ToString()); // FIXME
                    break;
            }

            return true;
        }        

        public void CreateSessionFile(Session s)
        {
            SQLiteConnection.CreateFile(s.SessionFile);
            SQLiteConnection connection = new SQLiteConnection("Data Source=" + s.SessionFile + "; Version=3; FailIfMissing=True; Foreign Keys=True;");
            connection.Open();
            SQLiteCommand command = new SQLiteCommand(connection);

            command.CommandText = @"
CREATE TABLE `session` (
	`id` INTEGER NOT NULL PRIMARY KEY AUTOINCREMENT UNIQUE,
	`name` TEXT NOT NULL UNIQUE,
	`ip` TEXT NOT NULL,
	`comment` TEXT,
	`livetime` REAL NOT NULL,
	`detector_data` TEXT NOT NULL,
	`detector_type_data` TEXT NOT NULL
);

CREATE TABLE `spectrums` (
	`id` INTEGER NOT NULL PRIMARY KEY AUTOINCREMENT UNIQUE,
	`session_id` INTEGER NOT NULL,
	`session_name` TEXT NOT NULL,
	`session_index` INTEGER NOT NULL UNIQUE,
	`start_time` TEXT NOT NULL,
	`latitude` REAL NOT NULL,
	`latitude_error` REAL NOT NULL,
	`longitude` REAL NOT NULL,
	`longitude_error` REAL NOT NULL,
	`altitude` REAL NOT NULL,
	`altitude_error` REAL NOT NULL,
	`track` REAL NOT NULL,
	`track_error` REAL NOT NULL,
	`speed` REAL NOT NULL,
	`speed_error` REAL NOT NULL,
	`climb` REAL NOT NULL,
	`climb_error` REAL NOT NULL,
	`livetime` REAL NOT NULL,
	`realtime` REAL NOT NULL,
	`total_count` INTEGER NOT NULL,
	`num_channels` INTEGER NOT NULL,
	`channels` TEXT NOT NULL
);
";
            command.ExecuteNonQuery();

            command.CommandText = "insert into session(name, ip, comment, livetime, detector_data, detector_type_data) values (@name, @ip, @comment, @livetime, @detector_data, @detector_type_data)";

            string detectorData = JsonConvert.SerializeObject(s.Detector, Newtonsoft.Json.Formatting.None);
            string detectorTypeData = JsonConvert.SerializeObject(s.DetectorType, Newtonsoft.Json.Formatting.None);

            command.Parameters.Clear();
            command.Parameters.AddWithValue("@name", s.Name);
            command.Parameters.AddWithValue("@ip", s.IPAddress);
            command.Parameters.AddWithValue("@comment", s.Comment);
            command.Parameters.AddWithValue("@livetime", s.Livetime);
            command.Parameters.AddWithValue("@detector_data", detectorData);
            command.Parameters.AddWithValue("@detector_type_data", detectorTypeData);
            command.ExecuteNonQuery();
            connection.Close();
        }

        void SetSessionIndexEvent(object sender, SetSessionIndexEventArgs e)
        {
            // An external form has changed the spectrum selection, update UI
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
            // Clear info about currently selected spectrum
            lblSession.Text = "";
            lblRealtime.Text = "";
            lblLivetime.Text = "";
            lblIndex.Text = "";
            lblLatitude.Text = "";
            lblLongitude.Text = "";
            lblAltitude.Text = "";
            lblGpsTime.Text = "";            
            lblMaxCount.Text = "";
            lblMinCount.Text = "";
            lblTotalCount.Text = "";
            lblDoserate.Text = "";
            lblSessionChannel.Text = "";
            lblSessionEnergy.Text = "";
        }

        private void ClearSetup()
        {   
            // Clear info about current setup
            graphSetup.GraphPane.CurveList.Clear();
            graphSetup.GraphPane.GraphObjList.Clear();            
            graphSetup.Invalidate();
        }

        private void ClearSession()
        {
            // Clear currently loaded session
            lbSession.Items.Clear();
            lblSessionDetector.Text = "";
            graphSession.GraphPane.CurveList.Clear();
            graphSession.GraphPane.GraphObjList.Clear();
            graphSession.Invalidate();
            ClearSpectrumInfo();            

            // Notify external forms about clearing session
            formWaterfallLive.ClearSession();
            formROILive.ClearSession();
            frmMap.ClearSession();

            if (session != null)
                session.Clear();
        }

        private void ClearBackground()
        {            
            if (session == null)
                return;

            // Clear currently selected background and update state
            session.SetBackground(null);

            lblBackground.Text = "";
            graphSession.Invalidate();
        }

        public void ShowSpectrum(string title, float[] channels, float maxCount, float minCount)
        {
            if (session == null)
                return;

            // Reset spectrum graphpane
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

            // Update background graph
            if (session.Background != null)
            {
                bkgGraphList.Clear();
                for (int i = 0; i < session.Background.Length; i++)
                    bkgGraphList.Add((double)i, (double)session.Background[i] * bkgScale);

                LineItem bkgCurve = pane.AddCurve("Background", bkgGraphList, Color.Blue, SymbolType.None);
                bkgCurve.Line.IsSmooth = true;
                bkgCurve.Line.SmoothTension = 0.5f;
            }

            // Update spectrum graph
            sessionGraphList.Clear();
            for (int i = 0; i < channels.Length; i++)
                sessionGraphList.Add((double)i, (double)channels[i]);

            LineItem curve = pane.AddCurve("Spectrum", sessionGraphList, Color.Red, SymbolType.None);
            curve.Line.IsSmooth = true;
            curve.Line.SmoothTension = 0.5f;

            // Update state
            pane.Chart.Fill = new Fill(SystemColors.ButtonFace, SystemColors.ButtonFace);
            pane.Legend.Fill = new Fill(SystemColors.ButtonFace, SystemColors.ButtonFace);
            pane.Fill = new Fill(SystemColors.ButtonFace, SystemColors.ButtonFace);
        }        

        private void GetGraphPointFromMousePos(int posX, int posY, ZedGraphControl graph, out int x, out int y)
        {
            // Convert mouse position to graph position
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
            // Update preferences detector type UI
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

        private void PopulateDetectorList()
        {
            // Update preferences detector UI
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

        private void PopulateDetectors()
        {
            // Update setup detector UI            
            cboxSetupDetector.Items.Clear();
            foreach (Detector d in settings.Detectors)
            {
                cboxSetupDetector.Items.Add(d);
            }
        }

        int GetChannelFromEnergy(Detector det, double E, int startX, int endX)
        {
            // Locate a suitable channel for a given energy, return -1 if none is found

            // FIXME: O(log n) ?
            double epsilon = 2d;
            for (int x = startX; x < endX; x++)
            {
                double e = det.GetEnergy(x);
                if (Math.Abs(E - e) < epsilon)
                    return x;
            }
            return -1;
        }
    }
}
