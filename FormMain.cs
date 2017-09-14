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
using System.Collections.Generic;
using System.Collections.Concurrent;
using System.ComponentModel;
using System.IO;
using System.Drawing;
using System.Text;
using System.Linq;
using System.Windows.Forms;
using System.Threading;
using System.Globalization;
using System.Xml;
using System.Xml.Serialization;
using Newtonsoft.Json;
using ZedGraph;
using MathNet.Numerics;
using System.Data.SQLite;

namespace crash
{
    public partial class FormMain : Form
    {
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
        FormMap formMap = null;

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
        string previewSessionName = String.Empty;

        TabPage returnFromSetup = null;

        // Spectrum used to accumulate counts for setup UI
        Spectrum previewSpec = null;

        Detector selectedDetector = null;
        int selectedChannel = 0;

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

        public FormMain()
        {
            InitializeComponent();

            Thread.CurrentThread.CurrentCulture = CultureInfo.InvariantCulture;
            Thread.CurrentThread.CurrentUICulture = CultureInfo.InvariantCulture;
        }

        private void FormMain_Load(object sender, EventArgs e)
        {
            try
            {                
                // Hide tabs on tabcontrol
                tabs.ItemSize = new Size(0, 1);
                tabs.SizeMode = TabSizeMode.Fixed;
                tabs.SelectedTab = pageMenu;

                tbSetupFineGain.KeyPress += CustomEvents.Numeric_KeyPress;

                // Create directories and files
                if (!Directory.Exists(GAEnvironment.SettingsPath))
                    Directory.CreateDirectory(GAEnvironment.SettingsPath);

                if (!Directory.Exists(GAEnvironment.GEScriptPath))
                    Directory.CreateDirectory(GAEnvironment.GEScriptPath);                
                
                InstallDir = Path.GetDirectoryName(Environment.GetCommandLineArgs()[0]) + Path.DirectorySeparatorChar;

                if (!File.Exists(GAEnvironment.NuclideLibraryFile))
                    File.Copy(InstallDir + "template_nuclides.lib", GAEnvironment.NuclideLibraryFile);

                if (!File.Exists(GAEnvironment.GEScriptPath + Path.DirectorySeparatorChar + "Nai-2tom.lua"))
                    File.Copy(InstallDir + "template_Nai-2tom.lua", GAEnvironment.GEScriptPath + Path.DirectorySeparatorChar + "Nai-2tom.lua");

                if (!File.Exists(GAEnvironment.GEScriptPath + Path.DirectorySeparatorChar + "Nai-3tom.lua"))
                    File.Copy(InstallDir + "template_Nai-3tom.lua", GAEnvironment.GEScriptPath + Path.DirectorySeparatorChar + "Nai-3tom.lua");

                // Load settings
                LoadSettings();
                menuItemConvertToLocalTime.Checked = settings.DisplayLocalTime;

                LoadNuclideLibrary();

                // Create forms
                formWaterfallLive = new FormWaterfallLive(settings.ROIList);                
                formROILive = new FormROILive(settings.ROIList);                
                formMap = new FormMap();                

                // Set up custom events
                formWaterfallLive.SetSessionIndexEvent += SetSessionIndexEvent;
                formROILive.SetSessionIndexEvent += SetSessionIndexEvent;
                formMap.SetSessionIndexEvent += SetSessionIndexEvent;

                tbNewLivetime.KeyPress += CustomEvents.Integer_KeyPress;

                // Populate UI
                tbPreferencesSessionDir.Text = settings.SessionRootDirectory;
                PopulateDetectorList();
                PopulateDetectors();

                lblLogMessages.Text = "";
                lblSessionSelChannel.Text = "";
                lblSessionsDatabase.Text = "";
                lblSetupChannel.Text = "";
                lblSessionChannel.Text = "";
                lblSessionEnergy.Text = "";
                lblSetupEnergy.Text = "";

                lblSessionDetector.Text = "";
                lblBackground.Text = "";
                lblComment.Text = "";
                ClearSpectrumInfo();
                ClearStatus();

                // Start networking thread
                netThread.Start();
                while (!netThread.IsAlive) ;

                // Start timer listening for network messages
                timer.Interval = 10;
                timer.Tick += timer_Tick;
                timer.Start();
            }
            catch(Exception ex)
            {
                MessageBox.Show(ex.Message + Path.DirectorySeparatorChar + ex.StackTrace, "Error");
                Environment.Exit(1);
            }
        }        

        void timer_Tick(object sender, EventArgs e)
        {
            // Process waiting network messages
            while (!recvq.IsEmpty)
            {
                burn.ProtocolMessage msg;
                if (recvq.TryDequeue(out msg))
                    dispatchRecvMsg(msg);
            }            
        }        

        private void FormMain_FormClosing(object sender, FormClosingEventArgs e)
        {
            // Stop networking thread
            if (netService.IsRunning())
                btnStopNetService_Click(sender, e);

            // Stop timer listening for network messages
            timer.Stop();

            // Save settings
            SaveSettings();            
        }

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

            string cmd = msg.Params["command"].ToString();

            if (cmd != "spectrum")
                lblLogMessages.Text = cmd;

            switch (cmd)
            {
                case "get_status_success":
                    Utils.Log.Add("Get status success");

                    double freeDisk = Convert.ToDouble(msg.Params["free_disk_space"], CultureInfo.InvariantCulture);
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
                    }
                    btnSetupStartTest.Enabled = false;
                    btnSetupStopTest.Enabled = true;
                    break;

                case "start_session_busy":
                    // Session already started
                    Utils.Log.Add(msg.Params["message"].ToString());
                    break;

                case "start_session_error":
                    // Creation of new session failed, log error message
                    Utils.Log.Add(msg.Params["message"].ToString());
                    break;

                case "sync_session_success":
                    // Session sync successful
                    Utils.Log.Add(msg.Params["message"].ToString());
                    break;

                case "sync_session_noexist":
                    // Session sync failed, does not exist
                    Utils.Log.Add(msg.Params["message"].ToString());
                    break;

                case "sync_session_wrongname":
                    // Session sync failed, wrong name
                    Utils.Log.Add(msg.Params["message"].ToString());
                    break;

                case "sync_session_error":
                    // Session sync failed
                    Utils.Log.Add(msg.Params["message"].ToString());
                    break;

                case "stop_session_success":
                    // Stop session successful, update state
                    Utils.Log.Add("Session stopped");
                    btnSetupStartTest.Enabled = true;
                    btnSetupStopTest.Enabled = false;
                    break;

                case "stop_session_noexist":
                    // Stopping a session that does not exist
                    Utils.Log.Add(msg.Params["message"].ToString());
                    break;

                case "stop_session_wrongname":
                    // Stopping a session that is not running
                    Utils.Log.Add(msg.Params["message"].ToString());
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
                    Utils.Log.Add(msg.Params["command"].ToString());

                    // Update state                    
                    panelSetupGraph.Enabled = true;
                    btnSetupClose.Enabled = true;
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
                        if (!File.Exists(sessionPath))
                        {
                            Utils.Log.Add("Unable to find session database: " + sessionPath);
                            return false;
                        }

                        SQLiteConnection connection = new SQLiteConnection("Data Source=" + sessionPath + "; Version=3; FailIfMissing=True; Foreign Keys=True;");
                        connection.Open();
                        SQLiteCommand command = new SQLiteCommand(connection);
                        command.CommandText = "select id from session where name = @name";
                        command.Parameters.AddWithValue("@name", spec.SessionName);
                        object o = command.ExecuteScalar();
                        if(o == null || o == DBNull.Value)
                        {
                            Utils.Log.Add("Unable to find session name " + spec.SessionName + " in database");
                            return false;
                        }
                        int sessionId = Convert.ToInt32(o);

                        command.CommandText = "select count(*) from spectrum where session_index = @session_index";
                        command.Parameters.Clear();
                        command.Parameters.AddWithValue("@session_index", spec.SessionIndex);
                        int cnt = Convert.ToInt32(command.ExecuteScalar());
                        if (cnt > 0)
                        {
                            Utils.Log.Add("Spectrum " + spec.SessionIndex + " already exists in database " + spec.SessionName);
                            return false;
                        }

                        command.Parameters.Clear();
                        command.CommandText = @"
insert into spectrum(session_id, session_name, session_index, start_time, latitude, latitude_error, longitude, longitude_error, altitude, altitude_error, track, track_error, speed, speed_error, climb, climb_error, livetime, realtime, total_count, num_channels, channels) 
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
                            spec.CalculateDoserate(session.Detector, session.GEScriptFunc);
                            
                            session.Add(spec);

                            // Add spectrum to UI list
                            bool updateSelectedIndex = false;
                            if (lbSession.SelectedIndex == 0)
                                updateSelectedIndex = true;

                            int index = 0, last_index = 0;

                            for (int i = 0; i < lbSession.Items.Count; i++)
                            {
                                Spectrum s = lbSession.Items[i] as Spectrum;
                                last_index = s.SessionIndex;
                                if (last_index < spec.SessionIndex)
                                {
                                    index = i;
                                    break;
                                }
                            }

                            if (last_index > spec.SessionIndex)
                                lbSession.Items.Add(spec);
                            else
                                lbSession.Items.Insert(index, spec);

                            if (updateSelectedIndex)
                            {
                                lbSession.ClearSelected();
                                lbSession.SetSelected(0, true);
                            }

                            // Notify external forms about new spectrum
                            formMap.AddMarker(spec);
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
	`detector_data` TEXT NOT NULL	
);

CREATE TABLE `spectrum` (
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

            command.CommandText = "insert into session(name, ip, comment, livetime, detector_data) values (@name, @ip, @comment, @livetime, @detector_data)";

            string detectorData = JsonConvert.SerializeObject(s.Detector, Newtonsoft.Json.Formatting.None);

            command.Parameters.Clear();
            command.Parameters.AddWithValue("@name", s.Name);
            command.Parameters.AddWithValue("@ip", s.IPAddress);
            command.Parameters.AddWithValue("@comment", s.Comment);
            command.Parameters.AddWithValue("@livetime", s.Livetime);
            command.Parameters.AddWithValue("@detector_data", detectorData);
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
            formMap.ClearSession();

            if (session != null)
                session.Clear();
        }

        private void ClearBackground()
        {
            if (session == null)
                return;

            // Clear currently selected background and update state
            session.SetBackgroundSession(null);

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
            if (session.Background != null && !menuItemSubtractBackground.Checked)
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
            {
                double cnt = (double)channels[i];
                if (session.Background != null && menuItemSubtractBackground.Checked)
                {
                    cnt -= session.Background[i];
                    if (cnt < 0.0)
                        cnt = 0.0;
                }

                sessionGraphList.Add((double)i, cnt);
            }

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

        private void PopulateDetectorList()
        {
            // Update preferences detector UI
            lvDetectors.Items.Clear();
            foreach (Detector d in settings.Detectors)
            {
                ListViewItem item = new ListViewItem(new string[] {
                    d.Serialnumber,
                    d.TypeName,                    
                    d.NumChannels.ToString(),
                    d.MaxNumChannels.ToString(),                    
                    d.Voltage.ToString(),
                    d.MinVoltage.ToString(),
                    d.MaxVoltage.ToString(),
                    d.CoarseGain.ToString(),
                    d.FineGain.ToString(),
                    d.Livetime.ToString(),
                    d.LLD.ToString(),
                    d.ULD.ToString(),
                    d.PluginName,
                    d.GEScript
                });
                item.Tag = d;
                lvDetectors.Items.Add(item);
            }
        }

        private void PopulateDetectors()
        {
            // Update setup detector UI            
            cboxSetupDetector.Items.Clear();
            foreach(Detector det in settings.Detectors)
                cboxSetupDetector.Items.Add(det);
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

        private void menuItemExit_Click(object sender, EventArgs e)
        {            
            Close();
        }

        private void btnStopNetService_Click(object sender, EventArgs e)
        {
            // Stop networking thread
            netService.RequestStop();
            netThread.Join();

            Utils.Log.Add("net service closed");
        }        

        private void btnMenuSession_Click(object sender, EventArgs e)
        {
            tabs.SelectedTab = pageSessions;
        }
        
        private void btnSetupSetParams_Click(object sender, EventArgs e)
        {
            if (cboxSetupDetector.SelectedItem == null)
            {
                MessageBox.Show("No detector selected");
                return;
            }

            if (String.IsNullOrEmpty(tbStatusIPAddress.Text.Trim()))
            {
                MessageBox.Show("No IP address selected");
                return;
            }

            // Convert parameters            
            double coarse = 0f;
            double fine = 0f;
            int nchannels = 0;

            try
            {
                coarse = Convert.ToDouble(cboxSetupCoarseGain.Text, CultureInfo.InvariantCulture);
                fine = Convert.ToDouble(tbSetupFineGain.Text, CultureInfo.InvariantCulture);
                nchannels = Convert.ToInt32(cboxSetupChannels.Text);
            }
            catch
            {
                MessageBox.Show("Gain: Invalid format (fine gain or coarse gain");
                return;
            }
            
            int lld = tbarSetupLLD.Value;
            int uld = tbarSetupULD.Value;
            if(lld > uld)
            {
                MessageBox.Show("LLD can not be bigger than ULD");
                return;
            }

            // Update selected detector parameters
            selectedDetector.Voltage = tbarSetupVoltage.Value;
            selectedDetector.CoarseGain = coarse;
            selectedDetector.FineGain = fine;
            selectedDetector.NumChannels = nchannels;
            selectedDetector.LLD = lld;
            selectedDetector.ULD = uld;

            SaveSettings();

            // Create and send network message
            burn.ProtocolMessage msg = new burn.ProtocolMessage(tbStatusIPAddress.Text.Trim());
            msg.Params.Add("command", "detector_config");
            msg.Params.Add("detector_data", selectedDetector);
            sendMsg(msg);

            Utils.Log.Add("Sending detector_config");

            previewSession = true;
        }

        private void tabs_SelectedIndexChanged(object sender, EventArgs e)
        {
            // Update UI based on selected tab
            lblInterface.Text = tabs.SelectedTab.Text.ToUpper();

            tools.Visible = true;
            menuItemView.Visible = true;
            menuItemSession.Visible = false;
            menuItemCalibration.Visible = false;

            if (tabs.SelectedTab == pageDetectors)
            {
            }
            else if (tabs.SelectedTab == pageSessions)
            {
                menuItemSession.Visible = true;
                menuItemCalibration.Visible = true;
            }
            else if (tabs.SelectedTab == pageSetup)
            {
                btnSetupStopTest.Enabled = false;
                panelSetupGraph.Enabled = false;
                ClearSetup();
            }
            else if (tabs.SelectedTab == pageMenu)
            {
                menuItemView.Visible = false;
                menuItemCalibration.Visible = false;
                tools.Visible = false;
            }
        }             

        private void lbSession_SelectedIndexChanged(object sender, EventArgs e)
        {
            // Update session UI

            if (lbSession.SelectedItems.Count < 1)
            {
                // Clear UI
                formWaterfallLive.SetSelectedSessionIndex(-1);
                formMap.SetSelectedSessionIndex(-1);
                formROILive.SetSelectedSessionIndex(-1);
                return;
            }                
            else if (lbSession.SelectedItems.Count == 1)
            {            
                // Populate session UI with one spectrum
                bkgScale = 1;
                Spectrum s = lbSession.SelectedItem as Spectrum;
                ShowSpectrum(s.SessionName + " - " + s.SessionIndex.ToString(), s.Channels.ToArray(), s.MaxCount, s.MinCount);
                lblRealtime.Text = "Realtime:" + ((double)s.Realtime) / 1000000.0;
                lblLivetime.Text = "Livetime:" + ((double)s.Livetime) / 1000000.0;
                lblSession.Text = "Session: " + s.SessionName;
                lblSessionDetector.Text = "Det." + session.Detector.Serialnumber + " (" + session.Detector.TypeName + ")";
                lblIndex.Text = "Index: " + s.SessionIndex;
                lblLatitude.Text = "Latitude: " + s.Latitude.ToString("#00.0000000") + " ±" + s.LatitudeError.ToString("###0.0#");
                lblLongitude.Text = "Longitude: " + s.Longitude.ToString("#00.0000000") + " ±" + s.LongitudeError.ToString("###0.0#");
                lblAltitude.Text = "Altitude: " + s.Altitude.ToString("#####0.0#") + " ±" + s.AltitudeError.ToString("###0.0#");
                lblGpsTime.Text = "Time: " + (menuItemConvertToLocalTime.Checked ? s.GpsTime.ToLocalTime().ToString("yyyy-MM-dd HH:mm:ss") : s.GpsTime.ToString("yyyy-MM-dd HH:mm:ss"));
                lblMaxCount.Text = "Max count: " + s.MaxCount;
                lblMinCount.Text = "Min count: " + s.MinCount;
                lblTotalCount.Text = "Total count: " + s.TotalCount;                
                if(s.Doserate == 0.0)
                    lblDoserate.Text = "";
                else lblDoserate.Text = "Doserate (μSv/h): " + String.Format("{0:###0.0##}", s.Doserate / 1000.0);

                // Inform other forms of new spectrum selection
                if (formWaterfallLive.Visible)
                    formWaterfallLive.SetSelectedSessionIndex(s.SessionIndex);
                if (formMap.Visible)
                    formMap.SetSelectedSessionIndex(s.SessionIndex);
                if (formROILive.Visible)
                    formROILive.SetSelectedSessionIndex(s.SessionIndex);
            }
            else
            {
                // Populate session UI with multiple spectrums
                if (selectionRun == true)
                    return;

                bkgScale = (float)lbSession.SelectedIndices.Count; // Store scalefactor for background livetime

                Spectrum s1 = (Spectrum)lbSession.Items[lbSession.SelectedIndices[lbSession.SelectedIndices.Count - 1]];
                Spectrum s2 = (Spectrum)lbSession.Items[lbSession.SelectedIndices[0]];

                double realTime = 0;
                double liveTime = 0;

                // Merge spectrums
                string title = "Merged: " + s1.SessionIndex + " - " + s2.SessionIndex;
                float[] chans = new float[(int)s1.NumChannels];
                float maxCnt = s1.MaxCount, minCnt = s1.MinCount;
                float totCnt = 0;
                for(int i=0; i<lbSession.SelectedItems.Count; i++)
                {
                    Spectrum s = (Spectrum)lbSession.SelectedItems[i];
                    for (int j = 0; j < s.NumChannels; j++)
                    {
                        float cnt = s.Channels[j];
                        if (session.Background != null && menuItemSubtractBackground.Checked)
                        {
                            cnt -= session.Background[j];
                            if (cnt < 0f)
                                cnt = 0f;
                        }

                        chans[j] += cnt;
                    }

                    if (s.MaxCount > maxCnt)
                        maxCnt = s.MaxCount;
                    if (s.MinCount < minCnt)
                        minCnt = s.MinCount;

                    totCnt += s.TotalCount;

                    realTime += ((double)s.Realtime) / 1000000.0;
                    liveTime += ((double)s.Livetime) / 1000000.0;
                }

                // Populate controls
                ShowSpectrum(title, chans, maxCnt, minCnt);

                lblRealtime.Text = "Realtime:" + realTime;
                lblLivetime.Text = "Livetime:" + liveTime;
                lblSession.Text = "Session: " + s1.SessionName;
                lblIndex.Text = "Index: " + s1.SessionIndex + " - " + s2.SessionIndex;
                lblLatitude.Text = "Latitude: " + s1.Latitude.ToString("#00.0000000") + " ±" + s2.LatitudeError.ToString("###0.0#");
                lblLongitude.Text = "Longitude: " + s1.Longitude.ToString("#00.0000000") + " ±" + s2.LongitudeError.ToString("###0.0#");
                lblAltitude.Text = "Altitude: " + s1.Altitude.ToString("#####0.0#") + " ±" + s2.AltitudeError.ToString("###0.0#");
                lblGpsTime.Text = "Time: " + (menuItemConvertToLocalTime.Checked ? s1.GpsTime.ToLocalTime().ToString("yyyy-MM-dd HH:mm:ss") : s1.GpsTime.ToString("yyyy-MM-dd HH:mm:ss"));
                lblMaxCount.Text = "Max count: " + maxCnt;
                lblMinCount.Text = "Min count: " + minCnt;
                lblTotalCount.Text = "Total count: " + totCnt;
                lblDoserate.Text = "";

                // Notify external forms about new spectrum selection
                if (formWaterfallLive.Visible)
                    formWaterfallLive.SetSelectedSessionIndices(s1.SessionIndex, s2.SessionIndex);
                if (formMap.Visible)
                    formMap.SetSelectedSessionIndices(s1.SessionIndex, s2.SessionIndex);
                if (formROILive.Visible)
                    formROILive.SetSelectedSessionIndices(s1.SessionIndex, s2.SessionIndex);
            }

            // Update session graph            
            GraphPane pane = graphSession.GraphPane;
            pane.GraphObjList.Clear();
            graphSession.RestoreScale(pane);
            graphSession.AxisChange();
            graphSession.Refresh();            

            // Reset nuclide UI
            lbNuclides.Items.Clear();
        }

        private void menuItemAbout_Click(object sender, EventArgs e)
        {
            // Show about form
            About about = new About();
            about.ShowDialog();            
        }        

        Session LoadSessionFile(string sessionFile)
        {
            Session s = new Session();

            // Deserialize session object
            SQLiteConnection connection = new SQLiteConnection("Data Source=" + sessionFile + "; Version=3; FailIfMissing=True; Foreign Keys=True;");
            connection.Open();
            SQLiteCommand command = new SQLiteCommand(connection);
            command.CommandText = "select * from session";
            SQLiteDataReader reader = command.ExecuteReader();
            if (!reader.HasRows)            
                throw new Exception("No session was found in database: " + sessionFile);

            reader.Read();
            
            s.Name = reader["name"].ToString();
            s.IPAddress = reader["ip"].ToString();
            s.Comment = reader["comment"].ToString();
            s.Livetime = Convert.ToSingle(reader["livetime"], CultureInfo.InvariantCulture);
            s.Detector = JsonConvert.DeserializeObject<Detector>(reader["detector_data"].ToString());

            reader.Close();

            s.SessionFile = sessionFile;

            // Load GEFactor script
            if (!s.LoadGEFactor())
                Utils.Log.Add("Loading GEFactor failed for session " + s.Name);

            // Load session spectrums
            command.CommandText = "select * from spectrum order by session_index asc";
            reader = command.ExecuteReader();
            while (reader.Read())
            {
                Spectrum spec = new Spectrum();
                spec.SessionName = reader["session_name"].ToString();
                spec.SessionIndex = Convert.ToInt32(reader["session_index"]);
                spec.GpsTime = Convert.ToDateTime(reader["start_time"]);
                spec.Latitude = Convert.ToDouble(reader["latitude"], CultureInfo.InvariantCulture);
                spec.LatitudeError = Convert.ToDouble(reader["latitude_error"], CultureInfo.InvariantCulture);
                spec.Longitude = Convert.ToDouble(reader["longitude"], CultureInfo.InvariantCulture);
                spec.LongitudeError = Convert.ToDouble(reader["longitude_error"], CultureInfo.InvariantCulture);
                spec.Altitude = Convert.ToDouble(reader["altitude"], CultureInfo.InvariantCulture);
                spec.AltitudeError = Convert.ToDouble(reader["altitude_error"], CultureInfo.InvariantCulture);
                spec.GpsTrack = Convert.ToSingle(reader["track"], CultureInfo.InvariantCulture);
                spec.GpsTrackError = Convert.ToSingle(reader["track_error"], CultureInfo.InvariantCulture);
                spec.GpsSpeed = Convert.ToSingle(reader["speed"], CultureInfo.InvariantCulture);
                spec.GpsSpeedError = Convert.ToSingle(reader["speed_error"], CultureInfo.InvariantCulture);
                spec.GpsClimb = Convert.ToSingle(reader["climb"], CultureInfo.InvariantCulture);
                spec.GpsClimbError = Convert.ToSingle(reader["climb_error"], CultureInfo.InvariantCulture);
                spec.Livetime = Convert.ToInt32(reader["livetime"]);
                spec.Realtime = Convert.ToInt32(reader["realtime"]);
                spec.TotalCount = Convert.ToInt32(reader["total_count"]);
                spec.NumChannels = Convert.ToInt32(reader["num_channels"]);
                spec.LoadSpectrumString(reader["channels"].ToString());
                spec.CalculateDoserate(s.Detector, s.GEScriptFunc);
                s.Add(spec);
            }

            connection.Close();
            return s;
        }

        private void menuItemLoadSession_Click(object sender, EventArgs e)
        {
            openSessionDialog.InitialDirectory = settings.SessionRootDirectory;
            openSessionDialog.Title = "Select session file";
            if(openSessionDialog.ShowDialog() == DialogResult.OK)
            {
                ClearSession();

                session = LoadSessionFile(openSessionDialog.FileName);

                lblSessionsDatabase.Text = session.SessionFile + " [" + session.IPAddress + "]";

                // Update UI
                lblSession.Text = session.Name;
                lblComment.Text = session.Comment;

                // Inform other forms
                formWaterfallLive.SetSession(session);
                formWaterfallLive.SetDetector(session.Detector);
                formROILive.SetSession(session);
                formMap.SetSession(session);

                // Add spectrums to map
                foreach(Spectrum s in session.Spectrums)
                {
                    lbSession.Items.Insert(0, s);
                    formMap.AddMarker(s);
                }

                // Update plots
                formWaterfallLive.UpdatePane();
                formROILive.UpdatePane();

                lblSession.Text = "Session: " + session.Name;
                Utils.Log.Add("session " + session.Name + " loaded");
            }
        }        

        private void menuItemLoadBackgroundSession_Click(object sender, EventArgs e)
        {
            if(session == null || !session.IsLoaded)
            {
                MessageBox.Show("You must load a session first");
                return;
            }

            openSessionDialog.InitialDirectory = settings.SessionRootDirectory;
            openSessionDialog.Title = "Select background session file";
            if (openSessionDialog.ShowDialog() == DialogResult.OK)
            {
                ClearBackground();

                bkgSession = LoadSessionFile(openSessionDialog.FileName);

                // Make sure session and backgrouns has the same number of channels
                if (bkgSession.NumChannels != session.NumChannels)
                {
                    bkgSession.Clear();
                    MessageBox.Show("Cannot load a background with different number of channels than the session");
                    return;
                }

                // Store background in session
                session.SetBackgroundSession(bkgSession);

                lblBackground.Text = "Background: " + bkgSession.Name;
                Utils.Log.Add("Background " + bkgSession.Name + " loaded for session " + session.Name);
            }
        }

        private void menuItemROITable_Click(object sender, EventArgs e)
        {
            // Show ROI table form
            FormROITable form = new FormROITable(settings.ROIList);
            form.ShowDialog();
        }

        private void graphSetup_MouseMove(object sender, MouseEventArgs e)
        {
            int x, y;
            GetGraphPointFromMousePos(e.X, e.Y, graphSetup, out x, out y);

            // Show channel
            lblSetupChannel.Text = "Ch: " + String.Format("{0:####0}", x);

            // Show energy       
            if(selectedDetector != null)                 
                lblSetupEnergy.Text = "En: " + String.Format("{0:#######0.0###}", selectedDetector.GetEnergy(x));                        
        }

        private void graphSession_MouseMove(object sender, MouseEventArgs e)
        {            
            int x, y;
            GetGraphPointFromMousePos(e.X, e.Y, graphSession, out x, out y);

            lblSessionChannel.Text = "Ch: " + String.Format("{0:####0}", x);

            // Show energy
            if (session != null && session.IsLoaded && session.Detector != null)            
                lblSessionEnergy.Text = "En: " + String.Format("{0:#######0.0###}", session.Detector.GetEnergy(x));            
            else lblSessionEnergy.Text = "";
        }

        private void menuItemSessionUnselect_Click(object sender, EventArgs e)
        {
            // Unselect session spectrum
            lbSession.ClearSelected();
            graphSession.GraphPane.GraphObjList.Clear();
            graphSession.GraphPane.CurveList.Clear();

            graphSession.RestoreScale(graphSession.GraphPane);
            graphSession.AxisChange();
            graphSession.Refresh();
        }        

        private void menuItemSessionInfo_Click(object sender, EventArgs e)
        {
            if(session == null || !session.IsLoaded)
            {
                MessageBox.Show("Can not open session info. No session loaded");
                return;
            }

            FormSessionInfo form = new FormSessionInfo(session, "Session Info");
            form.ShowDialog();
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

        private void menuItemShowLog_Click(object sender, EventArgs e)
        {
            Utils.Log.Show();
            Utils.Log.BringToFront();
        }

        private void menuItemSaveAsCHN_Click(object sender, EventArgs e)
        {
            if (session == null || session.IsEmpty)
            {
                MessageBox.Show("No session active");
                return;
            }

            FolderBrowserDialog dialog = new FolderBrowserDialog();
            dialog.ShowNewFolderButton = true;
            dialog.Description = "Select folder to store CHN files";
            if (dialog.ShowDialog() == DialogResult.OK)
            {
                try
                {
                    SessionExporter.ExportAsCHN(session, dialog.SelectedPath);
                    Utils.Log.Add("session " + session.Name + " stored with CHN format in " + dialog.SelectedPath);
                }
                catch (Exception ex)
                {
                    Utils.Log.Add("Failed to export session " + session.Name + " with CHN format in " + dialog.SelectedPath);
                    MessageBox.Show("Failed to export session to CHN format: " + ex.Message);
                }
            }
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

        private void btnMenuPreferences_Click(object sender, EventArgs e)
        {
            tabs.SelectedTab = pageDetectors;
        }

        private void btnAddDetector_Click(object sender, EventArgs e)
        {
            FormAddDetector form = new FormAddDetector(null);
            if (form.ShowDialog() == DialogResult.Cancel)
                return;

            Detector det = new Detector();
            det.TypeName = form.DetectorType;
            det.Serialnumber = form.Serialnumber;
            det.MaxNumChannels = form.MaxNumChannels;
            det.NumChannels = form.NumChannels;
            det.MinVoltage = form.MinHV;
            det.MaxVoltage = form.MaxHV;
            det.Voltage = form.HV;
            det.CoarseGain = form.CoarseGain;
            det.FineGain = form.FineGain;
            det.Livetime = form.Livetime;
            det.LLD = form.LLD;
            det.ULD = form.ULD;
            det.PluginName = form.PluginName;
            det.GEScript = form.GEScript;
            settings.Detectors.Add(det);

            SaveSettings();

            PopulateDetectorList();
            PopulateDetectors();
        }

        private void btnSetSessionDir_Click(object sender, EventArgs e)
        {
            FolderBrowserDialog dialog = new FolderBrowserDialog();
            if (dialog.ShowDialog() == DialogResult.OK)
            {
                tbPreferencesSessionDir.Text = dialog.SelectedPath;
                settings.SessionRootDirectory = tbPreferencesSessionDir.Text;
            }
        }

        private void menuItemStartNewSession_Click(object sender, EventArgs e)
        {
            if (String.IsNullOrEmpty(settings.SessionRootDirectory))
            {
                MessageBox.Show("You must provide a session directory under preferences");
                return;
            }

            returnFromSetup = pageNew;
            btnStatusNext.Enabled = false;
            ClearStatus();
            tbStatusIPAddress.Text = settings.LastIP;            
            tabs.SelectedTab = pageStatus;
        }

        private void menuItemStopSession_Click(object sender, EventArgs e)
        {
            if(session == null)
            {
                MessageBox.Show("No session is active");
                return;
            }

            burn.ProtocolMessage msg = new burn.ProtocolMessage(session.IPAddress);
            msg.Params.Add("command", "stop_session");
            msg.Params.Add("session_name", session.Name);
            sendMsg(msg);

            Utils.Log.Add("Sending stop_session");
        }

        private void graphSession_MouseDoubleClick(object sender, MouseEventArgs e)
        {
            if (session == null || !session.IsLoaded)
                return;

            int x, y;
            GetGraphPointFromMousePos(e.X, e.Y, graphSession, out x, out y);

            double E = session.Detector.GetEnergy(x);

            GraphPane pane = graphSession.GraphPane;
            pane.GraphObjList.Clear();            

            LineObj line1 = new LineObj(Color.Black, (double)x - tbarNuclides.Value, pane.YAxis.Scale.Min, (double)x - tbarNuclides.Value, pane.YAxis.Scale.Max);
            makeGraphObjectType(ref line1.Tag, GraphObjectType.EnergyTolerance);
            line1.Line.Style = System.Drawing.Drawing2D.DashStyle.Dot;
            pane.GraphObjList.Add(line1);

            LineObj line2 = new LineObj(Color.Black, (double)x + tbarNuclides.Value, pane.YAxis.Scale.Min, (double)x + tbarNuclides.Value, pane.YAxis.Scale.Max);
            makeGraphObjectType(ref line2.Tag, GraphObjectType.EnergyTolerance);
            line2.Line.Style = System.Drawing.Drawing2D.DashStyle.Dot;
            pane.GraphObjList.Add(line2);

            graphSession.RestoreScale(pane);
            graphSession.AxisChange();
            graphSession.Refresh();

            // List nuclides            
            lbNuclides.Items.Clear();
            foreach(NuclideInfo ni in NuclideLibrary)
            {            
                foreach(NuclideEnergy ne in ni.Energies)
                {
                    if (ne.Energy > E - (double)tbarNuclides.Value && ne.Energy < E + (double)tbarNuclides.Value)
                    {
                        lbNuclides.Items.Add(ni);
                        break;
                    }
                }
            }
        }

        private void graphSetup_MouseDoubleClick(object sender, MouseEventArgs e)
        {
            int x, y;
            GetGraphPointFromMousePos(e.X, e.Y, graphSetup, out x, out y);

            FormAskDecimal form = new FormAskDecimal("Enter expected energy for channel " + x, null);
            if(form.ShowDialog() == DialogResult.Cancel)
                return;

            energyLines.Add(new ChannelEnergy((double)x, form.Value));

            if (energyLines.Count > 1)
            {                
                List<double> xList = new List<double>();
                List<double> yList = new List<double>();
                foreach (ChannelEnergy ec in energyLines)
                {
                    xList.Add((double)ec.Channel);
                    yList.Add((double)ec.Energy);
                }

                coefficients.Clear();
                coefficients.AddRange(Fit.Polynomial(xList.ToArray(), yList.ToArray(), energyLines.Count - 1));
            }

            GraphPane pane = graphSetup.GraphPane;            
            LineObj line = new LineObj(Color.DarkBlue, (double)x, pane.YAxis.Scale.Min, (double)x, pane.YAxis.Scale.Max);
            makeGraphObjectType(ref line.Tag, GraphObjectType.EnergyCalibration);
            pane.GraphObjList.Add(line);

            graphSetup.RestoreScale(pane);
            graphSetup.AxisChange();
            graphSetup.Refresh();
        }        

        private void btnSetupStartTest_Click(object sender, EventArgs e)
        {
            string ip = tbStatusIPAddress.Text.Trim();
            previewSessionName = String.Format("{0:ddMMyyyy_HHmmss}", DateTime.Now) + "-setup";

            burn.ProtocolMessage msg = new burn.ProtocolMessage(ip);
            msg.Params.Add("command", "start_session");            
            msg.Params.Add("session_name", previewSessionName);
            msg.Params.Add("ip", ip);
            msg.Params.Add("livetime", 1);
            msg.Params.Add("comment", "Setup session");
            sendMsg(msg);

            ClearSetup();
            previewSession = true;
            previewSpec = null;
            Utils.Log.Add("Sending start_session (setup)");
        }

        private void btnSetupStopTest_Click(object sender, EventArgs e)
        {
            if(String.IsNullOrEmpty(previewSessionName))
            {
                MessageBox.Show("No setup session name found");
                return;
            }

            burn.ProtocolMessage msg = new burn.ProtocolMessage(tbStatusIPAddress.Text.Trim());
            msg.Params.Add("command", "stop_session");
            msg.Params.Add("session_name", previewSessionName);
            sendMsg(msg);
            Utils.Log.Add("Sending stop_session (setup)");
        }

        private void menuItemResetCoefficients_Click(object sender, EventArgs e)
        {
            energyLines.Clear();            
            graphSetup.GraphPane.GraphObjList.RemoveAll(o => isGraphObjectType(o.Tag, GraphObjectType.EnergyCalibration));
            //graphSetup.RestoreScale(pane);
            graphSetup.AxisChange();
            graphSetup.Refresh();
        }

        private void menuItemStoreCoefficients_Click(object sender, EventArgs e)
        {   
            if(coefficients.Count < 2)
            {
                MessageBox.Show("Can not store less than 2 coefficients");
                return;
            }

            // Show current energy curve
            FormEnergyCurve form = new FormEnergyCurve(selectedDetector, coefficients);
            if (form.ShowDialog() != DialogResult.OK)
                return;

            // Update selected detector with current energy curve coefficients
            selectedDetector.EnergyCurveCoefficients.Clear();
            selectedDetector.EnergyCurveCoefficients.AddRange(coefficients);

            SaveSettings();
        }        

        private void menuItemLayoutSetup1_Click(object sender, EventArgs e)
        {
            // Predefined layout: Organize windows
            int screenWidth = Screen.PrimaryScreen.Bounds.Width;
            int screenHeight = Screen.PrimaryScreen.Bounds.Height;

            formMap.Hide();
            formWaterfallLive.Hide();
            formROILive.Hide();            

            WindowState = FormWindowState.Normal;
            Left = 0;
            Top = 0;
            Width = screenWidth;
            Height = screenHeight - (screenHeight / 5);

            Utils.Log.Show();
            Utils.Log.WindowState = FormWindowState.Normal;
            Utils.Log.Left = 0;
            Utils.Log.Top = screenHeight - (screenHeight / 5);
            Utils.Log.Width = screenWidth;
            Utils.Log.Height = screenHeight / 5;

            Activate();
        }

        private void menuItemLayoutSession1_Click(object sender, EventArgs e)
        {
            // Predefined layout: Organize windows
            int screenWidth = Screen.PrimaryScreen.Bounds.Width;
            int screenHeight = Screen.PrimaryScreen.Bounds.Height;
                        
            formROILive.Hide();
            Utils.Log.Hide();

            WindowState = FormWindowState.Normal;
            Left = 0;
            Top = 0;
            Width = screenWidth;
            Height = (screenHeight / 3) * 2;

            formWaterfallLive.Show();
            formWaterfallLive.WindowState = FormWindowState.Normal;
            formWaterfallLive.Left = 0;
            formWaterfallLive.Top = (screenHeight / 3) * 2;
            formWaterfallLive.Width = screenWidth / 2;
            formWaterfallLive.Height = screenHeight / 3;

            formMap.Show();
            formMap.WindowState = FormWindowState.Normal;
            formMap.Left = screenWidth / 2;
            formMap.Top = (screenHeight / 3) * 2;
            formMap.Width = screenWidth / 2;
            formMap.Height = screenHeight / 3;

            Activate();
        }

        private void menuItemLayoutSession2_Click(object sender, EventArgs e)
        {
            // Predefined layout: Organize windows
            int screenWidth = Screen.PrimaryScreen.Bounds.Width;
            int screenHeight = Screen.PrimaryScreen.Bounds.Height;
            int screenWidthThird = screenWidth / 3;
            int screenHeightThird = screenHeight / 3;
            int screenHeightHalfThird = screenHeightThird / 2;

            WindowState = FormWindowState.Normal;
            Left = 0;
            Top = 0;
            Width = screenWidthThird * 2;
            Height = screenHeightThird * 2;

            formMap.Show();
            formMap.WindowState = FormWindowState.Normal;
            formMap.Left = screenWidthThird * 2;
            formMap.Top = 0;
            formMap.Width = screenWidthThird;
            formMap.Height = screenHeightThird + screenHeightHalfThird;

            formROILive.Show();
            formROILive.WindowState = FormWindowState.Normal;
            formROILive.Left = screenWidthThird * 2;
            formROILive.Top = screenHeightThird + screenHeightHalfThird;
            formROILive.Width = screenWidthThird;
            formROILive.Height = screenHeightThird;

            Utils.Log.Show();
            Utils.Log.WindowState = FormWindowState.Normal;
            Utils.Log.Left = screenWidthThird * 2;
            Utils.Log.Top = (screenHeightThird * 2) + screenHeightHalfThird;
            Utils.Log.Width = screenWidthThird;
            Utils.Log.Height = screenHeightHalfThird;

            formWaterfallLive.Show();
            formWaterfallLive.WindowState = FormWindowState.Normal;
            formWaterfallLive.Left = 0;
            formWaterfallLive.Top = screenHeightThird * 2;
            formWaterfallLive.Width = screenWidthThird * 2;
            formWaterfallLive.Height = screenHeightThird;

            Activate();
        }

        private void btnEditDetector_Click(object sender, EventArgs e)
        {
            if (lvDetectors.SelectedItems.Count == 0)
                return;

            // Show edit detector form
            FormAddDetector form = new FormAddDetector((Detector)lvDetectors.SelectedItems[0].Tag);
            if (form.ShowDialog() == DialogResult.Cancel)
                return;

            // Update selected detector
            Detector det = (Detector)lvDetectors.SelectedItems[0].Tag;
            det.TypeName = form.DetectorType;
            det.Serialnumber = form.Serialnumber;
            det.MaxNumChannels = form.MaxNumChannels;
            det.NumChannels = form.NumChannels;
            det.MinVoltage = form.MinHV;
            det.MaxVoltage = form.MaxHV;
            det.Voltage = form.HV;
            det.CoarseGain = form.CoarseGain;
            det.FineGain = form.FineGain;
            det.Livetime = form.Livetime;
            det.LLD = form.LLD;
            det.ULD = form.ULD;
            det.PluginName = form.PluginName;
            det.GEScript = form.GEScript;

            SaveSettings();

            PopulateDetectorList();
            PopulateDetectors();
        }

        private void tbarNuclides_ValueChanged(object sender, EventArgs e)
        {
            // Update value label
            lblSessionETOL.Text = tbarNuclides.Value.ToString();
        }

        private void lbNuclides_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (session == null || !session.IsLoaded)
                return;            

            // Remove current nuclide lines from graph
            GraphPane pane = graphSession.GraphPane;
            pane.GraphObjList.RemoveAll(o => isGraphObjectType(o.Tag, GraphObjectType.Energy));

            if (lbNuclides.SelectedItems.Count > 0)
            {
                double offset_y = 0d;

                // Display lines for currently selected nuclide
                NuclideInfo ni = (NuclideInfo)lbNuclides.SelectedItems[0];
                foreach(NuclideEnergy ne in ni.Energies)
                {
                    int ch = GetChannelFromEnergy(session.Detector, ne.Energy, 0, (int)session.NumChannels);
                    if(ch == -1)
                    {
                        // If no channel is found, or energy is outside current spectrum, continue to next energy
                        Utils.Log.Add("No channel found for energy: " + ni.Name + " " + ne.Energy.ToString());
                        continue;
                    }

                    // Add energy line
                    LineObj line = new LineObj(Color.ForestGreen, (double)ch, pane.YAxis.Scale.Min, (double)ch, pane.YAxis.Scale.Max);
                    makeGraphObjectType(ref line.Tag, GraphObjectType.Energy);
                    pane.GraphObjList.Add(line);
                               
                    // Add probability text
                    TextObj label = new TextObj(ne.Probability.ToString() + " %", (double)ch, pane.YAxis.Scale.Max - offset_y, CoordType.AxisXY2Scale, AlignH.Left, AlignV.Top);
                    makeGraphObjectType(ref label.Tag, GraphObjectType.Energy);                    
                    label.FontSpec.Border.IsVisible = false;
                    label.FontSpec.Size = 9f;
                    label.FontSpec.Fill.Color = SystemColors.ButtonFace;
                    label.ZOrder = ZOrder.D_BehindAxis;
                    pane.GraphObjList.Add(label);
                    offset_y += pane.YAxis.Scale.Max / 25d;
                }                
            }

            // Update graph
            graphSession.RestoreScale(pane);
            graphSession.AxisChange();
            graphSession.Refresh();
        }

        private void menuItemSaveAsCSV_Click(object sender, EventArgs e)
        {
            if (session == null || !session.IsLoaded)
                return;

            // Show dialog for file selection
            SaveFileDialog dialog = new SaveFileDialog();
            dialog.Filter = "Log File (*.csv)|*.csv|All Files (*.*)|*.*";
            dialog.DefaultExt = "csv";
            dialog.FileName = session.Name;
            if (dialog.ShowDialog() != DialogResult.OK)
                return;

            SessionExporter.ExportAsCSV(session, dialog.FileName);            
        }

        private void menuItemNuclidesUnselect_Click(object sender, EventArgs e)
        {
            // Clear nuclide UI
            lbNuclides.ClearSelected();

            // Remove energy lines from graph
            GraphPane pane = graphSession.GraphPane;
            pane.GraphObjList.RemoveAll(o => o.Tag != null && (Int32)o.Tag == 2);   
         
            // Update graph
            graphSession.RestoreScale(pane);
            graphSession.AxisChange();
            graphSession.Refresh();
        }

        private void menuItemSaveAsKMZ_Click(object sender, EventArgs e)
        {
            if (session == null || session.IsEmpty)
            {
                MessageBox.Show("No session active");
                return;
            }

            SaveFileDialog dialog = new SaveFileDialog();
            dialog.Filter = "Kmz File (*.kmz)|*.kmz";
            dialog.DefaultExt = "kmz";
            dialog.FileName = session.Name;
            if (dialog.ShowDialog() != DialogResult.OK)
                return;

            SessionExporter.ExportAsKMZ(session, dialog.FileName);
        }

        private void menuItemConvertToLocalTime_CheckedChanged(object sender, EventArgs e)
        {
            settings.DisplayLocalTime = menuItemConvertToLocalTime.Checked;
        }

        private void btnNewStart_Click(object sender, EventArgs e)
        {   
            if(selectedDetector == null)
            {
                MessageBox.Show("No detector selected");
                return;
            }

            if (String.IsNullOrEmpty(tbNewLivetime.Text.Trim()))
            {
                MessageBox.Show("Livetime can not be empty");
                return;
            }

            int ltime = Convert.ToInt32(tbNewLivetime.Text.Trim());

            if (ltime <= 0)
            {
                MessageBox.Show("Livetime must be a positive number");
                return;
            }

            selectedDetector.Livetime = ltime;

            SaveSettings();

            string ip = tbStatusIPAddress.Text.Trim();
            float livetime = selectedDetector.Livetime;
            string comment = tbNewComment.Text.Trim();
            string sessionName = String.Format("{0:ddMMyyyy_HHmmss}", DateTime.Now);

            burn.ProtocolMessage msg = new burn.ProtocolMessage(ip);
            msg.Params.Add("command", "start_session");
            msg.Params.Add("session_name", sessionName);
            msg.Params.Add("ip", ip);
            msg.Params.Add("livetime", livetime);
            msg.Params.Add("comment", comment);            
            sendMsg(msg);

            previewSession = false;
            Utils.Log.Add("Sending start_session");

            ClearSession();
            
            string sessionFile = settings.SessionRootDirectory + Path.DirectorySeparatorChar + sessionName + ".db";            
            session = new Session(ip, sessionFile, sessionName, comment, livetime, selectedDetector);

            // Create session database
            CreateSessionFile(session);

            lblSessionsDatabase.Text = session.SessionFile + " [" + session.IPAddress + "]";

            lblSession.Text = session.Name;
            lblComment.Text = session.Comment;

            // Notify external forms about new session
            formWaterfallLive.SetSession(session);
            formROILive.SetSession(session);
            formMap.SetSession(session);

            tabs.SelectedTab = pageSessions;
        }

        private void btnNewCancel_Click(object sender, EventArgs e)
        {
            tabs.SelectedTab = pageSessions;
        }

        private void btnSetupClose_Click(object sender, EventArgs e)
        {
            if (returnFromSetup == pageNew)
            {
                tbNewLivetime.Text = selectedDetector.Livetime.ToString();
                tbNewComment.Text = "";
            }

            tabs.SelectedTab = returnFromSetup;
        }

        private void cboxSetupDetector_SelectedIndexChanged(object sender, EventArgs e)
        {
            selectedDetector = cboxSetupDetector.SelectedItem as Detector;
            
            cboxSetupChannels.Text = selectedDetector.NumChannels.ToString();

            tbarSetupVoltage.Minimum = selectedDetector.MinVoltage;
            tbarSetupVoltage.Maximum = selectedDetector.MaxVoltage;
            tbarSetupVoltage.Value = Utils.Clamp(selectedDetector.Voltage, tbarSetupVoltage.Minimum, tbarSetupVoltage.Maximum);

            int coarse = Convert.ToInt32(selectedDetector.CoarseGain);
            cboxSetupCoarseGain.SelectedIndex = cboxSetupCoarseGain.FindStringExact(coarse.ToString());

            tbSetupFineGain.Text = selectedDetector.FineGain.ToString();
            tbarSetupLLD.Value = Utils.Clamp(selectedDetector.LLD, tbarSetupLLD.Minimum, tbarSetupLLD.Maximum);
            tbarSetupULD.Value = Utils.Clamp(selectedDetector.ULD, tbarSetupULD.Minimum, tbarSetupULD.Maximum);

            cboxSetupChannels.Items.Clear();
            for (int i = 32; i <= selectedDetector.MaxNumChannels; i *= 2)
                cboxSetupChannels.Items.Add(i.ToString());
            cboxSetupChannels.Text = selectedDetector.NumChannels.ToString();
        }

        private void btnMenuCalibration_Click(object sender, EventArgs e)
        {
            if (String.IsNullOrEmpty(settings.SessionRootDirectory))
            {
                MessageBox.Show("You must provide a session directory under preferences");
                return;
            }

            returnFromSetup = pageMenu;
            btnStatusNext.Enabled = false;
            ClearStatus();
            tbStatusIPAddress.Text = settings.LastIP;
            tabs.SelectedTab = pageStatus;
        }

        private void btnSessionsClose_Click(object sender, EventArgs e)
        {
            formMap.Hide();
            formROILive.Hide();            
            formWaterfallLive.Hide();
            Utils.Log.Hide();

            tabs.SelectedTab = pageMenu;
        }

        private void btnPreferencesClose_Click(object sender, EventArgs e)
        {
            tabs.SelectedTab = pageMenu;
        }

        private void btnStatusGet_Click(object sender, EventArgs e)
        {
            burn.ProtocolMessage msg = new burn.ProtocolMessage(tbStatusIPAddress.Text.Trim());
            msg.Params.Add("command", "get_status");
            sendMsg(msg);
        }

        private void btnStatusCancel_Click(object sender, EventArgs e)
        {
            tabs.SelectedTab = pageMenu;
        }

        private void btnSetupCancel_Click(object sender, EventArgs e)
        {
            if (returnFromSetup == pageNew)
                tabs.SelectedTab = pageSessions;
            else tabs.SelectedTab = pageMenu;
        }

        private void btnStatusNext_Click(object sender, EventArgs e)
        {
            settings.LastIP = tbStatusIPAddress.Text;
            SaveSettings();

            lblSetupIPAddress.Text = "IP Address: " + settings.LastIP;
            btnSetupClose.Enabled = false;
            tabs.SelectedTab = pageSetup;            
        }

        private void btnPreferencesCancel_Click(object sender, EventArgs e)
        {
            tabs.SelectedTab = pageMenu;
        }

        private void btnMenuPreferences_Click_1(object sender, EventArgs e)
        {
            tabs.SelectedTab = pagePreferences;
        }

        private void btnPreferencesSave_Click(object sender, EventArgs e)
        {
            settings.SessionRootDirectory = tbPreferencesSessionDir.Text;
            SaveSettings();
            tabs.SelectedTab = pageMenu;
        }

        void ClearStatus()
        {
            lblStatusFreeDiskSpace.Text = "";
            lblStatusSessionRunning.Text = "";
            lblStatusSpectrumIndex.Text = "";
            lblStatusDetectorConfigured.Text = "";
            btnStatusNext.Enabled = false;
        }

        private void tbStatusIPAddress_TextChanged(object sender, EventArgs e)
        {
            ClearStatus();
        }

        private void menuItemSyncCurrentSession_Click(object sender, EventArgs e)
        {
            if (session == null)
            {
                MessageBox.Show("No session is active");
                return;
            }

            // Sync session
            int lastKnownIndex = session.Spectrums.Max(s => s.SessionIndex);

            var existingIndices = new List<int>();
            foreach(Spectrum s in session.Spectrums)
                existingIndices.Add(s.SessionIndex);

            var missingIndices = Enumerable.Range(0, lastKnownIndex).Except(existingIndices);
                                    
            burn.ProtocolMessage msg = new burn.ProtocolMessage(session.IPAddress);
            msg.Params.Add("command", "sync_session");            
            msg.Params.Add("session_name", session.Name);
            msg.Params.Add("last_index", lastKnownIndex);
            msg.Params.Add("indices_list", missingIndices.Take(50).ToArray()); // Max 50 indices at a time
            sendMsg(msg);

            Utils.Log.Add("Sending sync_session");
        }

        private void menuItemLoadBackgroundSelection_Click(object sender, EventArgs e)
        {
            if (session == null || !session.IsLoaded)
            {
                MessageBox.Show("You must load a session first");
                return;
            }

            if(lbSession.SelectedItems.Count < 1)
            {
                MessageBox.Show("No spectrums selected");
                return;
            }

            ClearBackground();

            int minIndex = -1, maxIndex = -1;
            List<Spectrum> spectrumSelection = new List<Spectrum>();
            foreach(object o in lbSession.SelectedItems)
            {
                Spectrum spec = o as Spectrum;
                spectrumSelection.Add(spec);

                if(minIndex == -1 && maxIndex == -1)
                {
                    minIndex = spec.SessionIndex;
                    maxIndex = spec.SessionIndex;
                }
                else
                {
                    if (spec.SessionIndex < minIndex)
                        minIndex = spec.SessionIndex;
                    if (spec.SessionIndex > maxIndex)
                        maxIndex = spec.SessionIndex;
                }
            }

            // Store background in session
            session.SetBackground(spectrumSelection);

            lblBackground.Text = "Background: " + minIndex + " -> " + maxIndex;
            Utils.Log.Add("Background selection " + minIndex + " -> " + maxIndex + " loaded for session " + session.Name);            
        }

        private void menuItemAdjustZero_Click(object sender, EventArgs e)
        {
            if (selectedChannel == 0)
            {
                MessageBox.Show("No channel selected");
                return;
            }

            if (session.Detector.EnergyCurveCoefficients.Count < 1)
            {
                MessageBox.Show("Detector has no energy curve coefficients");
                return;
            }

            bool canUpdateSettingsDetector = settings.Detectors.Exists(x => x.Serialnumber == session.Detector.Serialnumber);

            FormAskZeroPolynomial form = new FormAskZeroPolynomial(session.Detector, selectedChannel, canUpdateSettingsDetector);
            if(form.ShowDialog() == DialogResult.OK)
            {
                session.Detector.EnergyCurveCoefficients[0] = form.ZeroPolynomial;
                // FIXME: Save session.Detector to database

                string sessionPath = settings.SessionRootDirectory + Path.DirectorySeparatorChar + session.Name + ".db";
                if (!File.Exists(sessionPath))
                {
                    MessageBox.Show("Unable to find session database: " + sessionPath);
                    return;
                }

                SQLiteConnection connection = new SQLiteConnection("Data Source=" + sessionPath + "; Version=3; FailIfMissing=True; Foreign Keys=True;");
                connection.Open();
                SQLiteCommand command = new SQLiteCommand(connection);
                command.CommandText = "select id from session where name = @name";
                command.Parameters.AddWithValue("@name", session.Name);
                object o = command.ExecuteScalar();
                if (o == null || o == DBNull.Value)
                {
                    Utils.Log.Add("Unable to find session name " + session.Name + " in database");
                    return;
                }
                int sessionId = Convert.ToInt32(o);

                string detectorData = JsonConvert.SerializeObject(session.Detector, Newtonsoft.Json.Formatting.None);

                command.Parameters.Clear();
                command.CommandText = "update session set detector_data=@detector_data where id=@id";
                command.Parameters.AddWithValue("@detector_data", detectorData);
                command.Parameters.AddWithValue("@id", sessionId);
                command.ExecuteNonQuery();
                connection.Close();

                if (form.SaveToSettings)
                {
                    Detector settingsDetector = settings.Detectors.Find(x => x.Serialnumber == session.Detector.Serialnumber);
                    if(settingsDetector == null)
                    {
                        MessageBox.Show("Detector " + session.Detector.Serialnumber + " was not found in settings");
                        return;
                    }
                    settingsDetector.EnergyCurveCoefficients = session.Detector.EnergyCurveCoefficients;
                    SaveSettings();
                }
            }
        }

        private void graphSession_MouseClick(object sender, MouseEventArgs e)
        {
            int x, y;
            GetGraphPointFromMousePos(e.X, e.Y, graphSession, out x, out y);

            selectedChannel = x;
            lblSessionSelChannel.Text = "[" + String.Format("{0:####0}", selectedChannel) + "]";
        }

        private void menuItemChangeIPAddress_Click(object sender, EventArgs e)
        {
            if(session == null || !session.IsLoaded)
            {
                MessageBox.Show("You must load a session first");
                return;
            }

            FormAskIP form = new FormAskIP();
            if (form.ShowDialog() != DialogResult.OK)
                return;

            session.IPAddress = form.IPAddress;

            SQLiteConnection connection = new SQLiteConnection("Data Source=" + session.SessionFile + "; Version=3; FailIfMissing=True; Foreign Keys=True;");
            connection.Open();
            SQLiteCommand command = new SQLiteCommand(connection);
            command.CommandText = "update session set ip=@ip"; // FIXME: Updates all sessions in db
            command.Parameters.AddWithValue("@ip", session.IPAddress);
            command.ExecuteScalar();
            connection.Close();

            lblSessionsDatabase.Text = session.SessionFile + " [" + session.IPAddress + "]";
        }
    }
}
