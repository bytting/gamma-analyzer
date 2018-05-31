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
using Newtonsoft.Json;
using ZedGraph;
using MathNet.Numerics;
using System.Data.SQLite;
using log4net;
using System.Net;

namespace crash
{
    public partial class FormMain : Form
    {        
        private FormContainer parent = null;
        private GASettings settings = null;
        private ILog log = null;

        // Concurrent queue used to pass messages to networking thread
        static ConcurrentQueue<burn.ProtocolMessage> sendq = null;
        // Concurrent queue used to receive messages from network thread
        static ConcurrentQueue<burn.ProtocolMessage> recvq = null;
        // FIXME: Create a proper API for communication with network thread

        // Networking thread        
        static burn.NetService netService = null;
        static Thread netThread = null;

        // Timer used to poll for network messages
        private System.Windows.Forms.Timer timer = new System.Windows.Forms.Timer();
        
        static NetUpload netUpload = null;
        static Thread netUploadThread = null;
        static ConcurrentQueue<Spectrum> sendUploadQ = null;

        // Currently loaded sessions
        private Session session = null, bkgSession = null;

        // Point lists with graph data
        private PointPairList setupGraphList = new PointPairList();
        private PointPairList sessionGraphList = new PointPairList();
        private PointPairList bkgGraphList = new PointPairList();

        // Livetime scale factor for currently loaded background
        private float bkgScale = 1f;

        // Structure containing loaded nuclide library
        private List<NuclideInfo> NuclideLibrary = new List<NuclideInfo>();

        private bool previewSession = false;
        private string previewSessionName = String.Empty;

        private TabPage returnFromSetup = null;

        // Spectrum used to accumulate counts for setup UI
        private Spectrum previewSpec = null;

        private Detector selectedDetector = null;
        private int selectedChannel = 0;

        // Array containing currently selected energies/channels
        private List<ChannelEnergy> energyLines = new List<ChannelEnergy>();

        // Array containing curve fitting coefficients
        private List<double> coefficients = new List<double>();

        private int currentGroundLevelIndex = -1;

        private bool uploadServiceAvailable = false;
        private bool uploadServiceActive = false;

        // Enumeration used to keep track of graph object types
        public enum GraphObjectType
        {
            Spectrum,
            Background,
            Energy,
            EnergyTolerance,
            EnergyCalibration            
        };

        public FormMain(FormContainer p, GASettings s, ILog l)
        {
            InitializeComponent();

            MdiParent = parent = p;
            settings = s;
            log = l;
        }

        private void FormMain_Load(object sender, EventArgs e)
        {
            try
            {
                netService = new burn.NetService(log, ref sendq, ref recvq);
                netThread = new Thread(netService.DoWork);
                
                netUpload = new NetUpload(log, ref sendUploadQ);
                netUploadThread = new Thread(netUpload.DoWork);

                // Hide tabs on tabcontrol
                tabs.ItemSize = new Size(0, 1);
                tabs.SizeMode = TabSizeMode.Fixed;
                tabs.SelectedTab = pageMenu;

                tbSetupVoltage.KeyPress += CustomEvents.Numeric_KeyPress;
                tbSetupFineGain.KeyPress += CustomEvents.Numeric_KeyPress;
                tbSetupLLD.KeyPress += CustomEvents.Integer_KeyPress;
                tbSetupULD.KeyPress += CustomEvents.Integer_KeyPress;

                menuItemConvertToLocalTime.Checked = settings.DisplayLocalTime;

                LoadNuclideLibrary();

                // Set up custom events
                tbNewLivetime.KeyPress += CustomEvents.Integer_KeyPress;

                // Populate UI
                tbPreferencesSessionDir.Text = settings.SessionRootDirectory;
                PopulateDetectorList();
                PopulateDetectors();

                lblGroundLevelIndex.Text = "";
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

                menu.Visible = false;

                // Start threads
                netThread.Start();
                while (!netThread.IsAlive) ;
                
                netUploadThread.Start();
                while (!netUploadThread.IsAlive) ;
                log.Info("net upload started");

                // Start timer listening for network messages
                timer.Interval = 10;
                timer.Tick += timer_Tick;
                timer.Start();
            }
            catch(Exception ex)
            {
                log.Error(ex.Message, ex);
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

        private bool LoadNuclideLibrary()
        {
            if (!File.Exists(GAEnvironment.NuclideLibraryFile))
                return false;

            try
            {
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
            }
            catch(Exception ex)
            {
                log.Error(ex.Message, ex);
                return false;
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

            try
            {
                string cmd = msg.Params["command"].ToString();

                log.Info("Received response: " + cmd);

                switch (cmd)
                {
                    case "get_status_success":
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
                            log.Info("Preview session started: " + msg.Params["session_name"]);
                        else
                        {
                            log.Info("Session started: " + msg.Params["session_name"]);

                            if(uploadServiceActive)
                            {
                                APISession apiSession = new APISession(session);
                                HttpWebRequest request = null;

                                try
                                {
                                    request = (HttpWebRequest)WebRequest.Create(settings.LastUploadHostname + "/sessions");
                                    string credentials = Convert.ToBase64String(ASCIIEncoding.ASCII.GetBytes(settings.LastUploadUsername + ":" + settings.LastUploadPassword));
                                    request.Headers.Add("Authorization", "Basic " + credentials);
                                    request.Timeout = 8000;
                                    request.Method = WebRequestMethods.Http.Post;
                                    request.Accept = "application/json";
                                    
                                    log.Info("Sending " + apiSession.Name + " to web service");

                                    var jsonRequest = JsonConvert.SerializeObject(apiSession);
                                    var sendData = Encoding.UTF8.GetBytes(jsonRequest);

                                    request.ContentType = "application/json";
                                    request.ContentLength = sendData.Length;

                                    using (var stream = request.GetRequestStream())
                                    {
                                        stream.Write(sendData, 0, sendData.Length);
                                    }

                                    string recvData;
                                    HttpStatusCode code = Utils.GetResponseData(request, out recvData);

                                    if (code == HttpStatusCode.OK)
                                    {
                                        log.Info(recvData);
                                    }
                                    else if (code == HttpStatusCode.RequestTimeout)
                                    {
                                        uploadServiceActive = false;
                                        log.Error("Request timeout");
                                    }
                                    else
                                    {
                                        uploadServiceActive = false;
                                        log.Error(code.ToString() + ": " + recvData);
                                    }
                                }
                                catch (Exception ex)
                                {
                                    log.Error(ex.Message);
                                }
                            }
                        }

                        btnSetupStartTest.Enabled = false;
                        btnSetupStopTest.Enabled = true;
                        break;

                    case "start_session_busy":
                        // Session already started
                        log.Info(msg.Params["message"].ToString());
                        break;

                    case "start_session_error":
                        // Creation of new session failed, log error message
                        log.Info(msg.Params["message"].ToString());
                        break;

                    case "dump_session_success":
                        // Session dump successful
                        log.Info(msg.Params["message"].ToString());
                        break;

                    case "dump_session_error":
                        // Session dump error
                        log.Info(msg.Params["message"].ToString());
                        break;

                    case "dump_session_none":
                        // Session dump none
                        log.Info(msg.Params["message"].ToString());
                        break;

                    case "sync_session_success":
                        // Session sync successful
                        log.Info(msg.Params["message"].ToString());
                        break;

                    case "sync_session_noexist":
                        // Session sync failed, does not exist
                        log.Info(msg.Params["message"].ToString());
                        break;

                    case "sync_session_wrongname":
                        // Session sync failed, wrong name
                        log.Info(msg.Params["message"].ToString());
                        break;

                    case "sync_session_error":
                        // Session sync failed
                        log.Info(msg.Params["message"].ToString());
                        break;

                    case "stop_session_success":
                        // Stop session successful, update state
                        log.Info("Session stopped");
                        btnSetupStartTest.Enabled = true;
                        btnSetupStopTest.Enabled = false;
                        btnSetupClose.Enabled = true;
                        btnSetupCancel.Enabled = true;
                        break;

                    case "stop_session_noexist":
                        // Stopping a session that does not exist
                        log.Info(msg.Params["message"].ToString());
                        break;

                    case "stop_session_wrongname":
                        // Stopping a session that is not running
                        log.Info(msg.Params["message"].ToString());
                        break;

                    case "stop_session_error":
                        // Session stopped successfully
                        log.Info(msg.Params["message"].ToString());
                        break;

                    case "error":
                        // An error occurred, log error message
                        log.Info(msg.Params["message"].ToString());
                        break;

                    case "error_socket":
                        // An socket error occurred, log error message
                        log.Info("Socket error: " + msg.Params["message"]);
                        break;

                    case "detector_config_success":
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
                            log.Info(spec.Label + " received");

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
                            log.Info(spec.Label + " received");

                            // Add spectrum to database
                            string sessionPath = settings.SessionRootDirectory + Path.DirectorySeparatorChar + spec.SessionName + ".db";
                            if (!File.Exists(sessionPath))
                            {
                                log.Error("Unable to find session database: " + sessionPath);
                                return false;
                            }

                            SQLiteConnection connection = new SQLiteConnection("Data Source=" + sessionPath + "; Version=3; FailIfMissing=True; Foreign Keys=True;");
                            connection.Open();
                            SQLiteCommand command = new SQLiteCommand(connection);
                            command.CommandText = "select id from session where name = @name";
                            command.Parameters.AddWithValue("@name", spec.SessionName);
                            object o = command.ExecuteScalar();
                            if (o == null || o == DBNull.Value)
                            {
                                log.Error("Unable to find session name " + spec.SessionName + " in database");
                                return false;
                            }
                            int sessionId = Convert.ToInt32(o);

                            command.CommandText = "select count(*) from spectrum where session_index = @session_index";
                            command.Parameters.Clear();
                            command.Parameters.AddWithValue("@session_index", spec.SessionIndex);
                            int cnt = Convert.ToInt32(command.ExecuteScalar());
                            if (cnt > 0)
                            {
                                log.Warn("Spectrum " + spec.SessionIndex + " already exists in database " + spec.SessionName);
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
                                try
                                {
                                    spec.CalculateDoserate(session.Detector, session.GEScriptFunc);
                                }
                                catch (Exception ex)
                                {
                                    log.Warn(ex.Message, ex);
                                }

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

                                parent.AddSpectrum(spec);

                                // Send spectrum to gamma-store
                                if(uploadServiceActive)
                                    sendUploadQ.Enqueue(spec);
                            }                            
                        }
                        break;

                    default:
                        // Unhandled message received, update log
                        log.Warn("Unknown message: " + msg.Params["command"].ToString()); // FIXME
                        break;
                }
            }
            catch(Exception ex)
            {
                log.Error(ex.Message, ex);
                return false;
            }

            return true;
        }

        public void CreateSessionFile(Session s)
        {
            try
            {
                SQLiteConnection.CreateFile(s.SessionFile);
                using (SQLiteConnection connection = new SQLiteConnection("Data Source=" + s.SessionFile + "; Version=3; FailIfMissing=True; Foreign Keys=True;"))
                {
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
                }
            }
            catch(Exception ex)
            {
                log.Error(ex.Message, ex);
            }
        }

        public void SetSelectedSessionIndex(int index)
        {
            int idx = lbSession.FindStringExact(session.Name + " - " + index);
            if (idx == -1)
                return;

            ClearSpectrumInfo();

            lbSession.SelectedIndexChanged -= lbSession_SelectedIndexChanged;
            lbSession.ClearSelected();
            lbSession.SetSelected(idx, true);
            lbSession.SelectedIndexChanged += lbSession_SelectedIndexChanged;

            // Populate session UI with one spectrum
            bkgScale = 1;

            Spectrum s = lbSession.Items[idx] as Spectrum;

            ShowSpectrum(s.SessionName + " - " + s.SessionIndex, s.Channels.ToArray(), s.MaxCount, s.MinCount);
            lblRealtime.Text = "Realtime:" + ((double)s.Realtime) / 1000000.0;
            lblLivetime.Text = "Livetime:" + ((double)s.Livetime) / 1000000.0;
            lblSession.Text = "Session: " + s.SessionName;
            lblSessionDetector.Text = "Det." + session.Detector.Serialnumber + " (" + session.Detector.TypeName + ")";
            lblIndex.Text = "Index: " + s.SessionIndex;
            lblLatitude.Text = "Latitude: " + s.Latitude.ToString("#00.0000000") + " ±" + s.LatitudeError.ToString("###0.0#");
            lblLongitude.Text = "Longitude: " + s.Longitude.ToString("#00.0000000") + " ±" + s.LongitudeError.ToString("###0.0#");
            lblAltitude.Text = "Altitude: " + s.Altitude.ToString("#####0.0#") + " ±" + s.AltitudeError.ToString("###0.0#");
            if(currentGroundLevelIndex > -1 && currentGroundLevelIndex < session.Spectrums.Count)
            {
                double relativeHeight = s.Altitude - session.Spectrums[currentGroundLevelIndex].Altitude;
                lblAltitude.Text += " (rel. " + relativeHeight.ToString("######0.0#") + ")";
            }
            lblGpsTime.Text = "Time: " + (menuItemConvertToLocalTime.Checked ? s.GpsTime.ToLocalTime().ToString("yyyy-MM-dd HH:mm:ss") : s.GpsTime.ToString("yyyy-MM-dd HH:mm:ss"));
            lblMaxCount.Text = "Max count: " + s.MaxCount;
            lblMinCount.Text = "Min count: " + s.MinCount;
            lblTotalCount.Text = "Total count: " + s.TotalCount;
            if (s.Doserate == 0.0)
                lblDoserate.Text = "";
            else lblDoserate.Text = "Doserate (μSv/h): " + String.Format("{0:###0.0##}", s.Doserate / 1000.0);
        }

        public void SetSelectedSessionIndices(int index1, int index2)
        {
            int idx1 = lbSession.FindStringExact(session.Name + " - " + index1);
            int idx2 = lbSession.FindStringExact(session.Name + " - " + index2);
            if (idx1 == -1 || idx2 == -1)
                return;            

            if (idx1 > idx2)            
                Utils.Swap(ref idx1, ref idx2);

            ClearSpectrumInfo();

            lbSession.SelectedIndexChanged -= lbSession_SelectedIndexChanged;
            lbSession.ClearSelected();
            for (int i = idx1; i <= idx2; i++)
                lbSession.SetSelected(i, true);
            lbSession.SelectedIndexChanged += lbSession_SelectedIndexChanged;

            bkgScale = (float)lbSession.SelectedIndices.Count; // Store scalefactor for background livetime

            Spectrum s1 = (Spectrum)lbSession.Items[idx2];
            Spectrum s2 = (Spectrum)lbSession.Items[idx1];

            double realTime = 0;
            double liveTime = 0;

            // Merge spectrums
            string title = "Merged: " + s1.SessionIndex + " - " + s2.SessionIndex;
            float[] chans = new float[(int)s1.NumChannels];
            float maxCnt = s1.MaxCount, minCnt = s1.MinCount;
            float totCnt = 0;
            for (int i = 0; i < lbSession.SelectedItems.Count; i++)
            {
                Spectrum s = (Spectrum)lbSession.SelectedItems[i];
                for (int j = 0; j < s.NumChannels; j++)
                    chans[j] += s.Channels[j];

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
            lblLatitude.Text = "";
            lblLongitude.Text = "";
            lblAltitude.Text = "";
            lblGpsTime.Text = "";
            lblMaxCount.Text = "Max count: " + maxCnt;
            lblMinCount.Text = "Min count: " + minCnt;
            lblTotalCount.Text = "Total count: " + totCnt;
            lblDoserate.Text = "";
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

            // Reset nuclide UI
            graphSession.GraphPane.GraphObjList.Clear();
            lbNuclides.Items.Clear();
        }

        private void ClearSetup()
        {
            // Clear info about current setup
            graphSetup.GraphPane.Title.Text = " ";
            graphSetup.GraphPane.CurveList.Clear();
            graphSetup.GraphPane.GraphObjList.Clear();
            graphSetup.Invalidate();
        }

        public void ClearSession()
        {
            // Clear currently loaded session
            lbSession.Items.Clear();
            lblSessionDetector.Text = "";
            lblComment.Text = "";
            lblBackground.Text = "";
            ClearSpectrumInfo();

            graphSession.GraphPane.Title.Text = " ";
            graphSession.GraphPane.CurveList.Clear();
            graphSession.GraphPane.GraphObjList.Clear();
            graphSession.Invalidate();

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

            try
            {
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
                        cnt -= session.Background[i] * bkgScale;
                        if (menuItemLockBackgroundToZero.Checked)
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

                graphSession.RestoreScale(pane);
                graphSession.AxisChange();
                graphSession.Refresh();
            }
            catch(Exception ex)
            {
                log.Error(ex.Message, ex);
            }
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

        private void btnMenuSession_Click(object sender, EventArgs e)
        {
            tabs.SelectedTab = pageSessions;
        }
        
        private void btnSetupSetParams_Click(object sender, EventArgs e)
        {
            try
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
                double coarseGain = 0d, fineGain = 0d;
                int voltage = 0, lld = 0, uld = 0, nchannels = 0;

                try
                {
                    coarseGain = Convert.ToDouble(cboxSetupCoarseGain.Text, CultureInfo.InvariantCulture);
                    fineGain = Convert.ToDouble(tbSetupFineGain.Text, CultureInfo.InvariantCulture);
                    voltage = Convert.ToInt32(tbSetupVoltage.Text);
                    lld = Convert.ToInt32(tbSetupLLD.Text);
                    uld = Convert.ToInt32(tbSetupULD.Text);
                    nchannels = Convert.ToInt32(cboxSetupChannels.Text);
                }
                catch
                {
                    MessageBox.Show("Invalid number format found");
                    return;
                }

                if (voltage < selectedDetector.MinVoltage || voltage > selectedDetector.MaxVoltage)
                {
                    MessageBox.Show("Voltage out of range");
                    return;
                }

                if (fineGain < 1.0 || fineGain > 5.0)
                {
                    MessageBox.Show("Fine gain out of range");
                    return;
                }

                if (lld < 0)
                {
                    MessageBox.Show("LLD can not be less than zero");
                    return;
                }

                if (uld > 130)
                {
                    MessageBox.Show("ULD can not be bigger than 130%");
                    return;
                }

                if (lld > uld)
                {
                    MessageBox.Show("LLD can not be bigger than ULD");
                    return;
                }

                // Update selected detector parameters
                selectedDetector.Voltage = voltage;
                selectedDetector.CoarseGain = coarseGain;
                selectedDetector.FineGain = fineGain;
                selectedDetector.NumChannels = nchannels;
                selectedDetector.LLD = lld;
                selectedDetector.ULD = uld;

                parent.SaveSettings();

                // Create and send network message
                burn.ProtocolMessage msg = new burn.ProtocolMessage(tbStatusIPAddress.Text.Trim());
                msg.Params.Add("command", "detector_config");
                msg.Params.Add("detector_data", selectedDetector);
                sendMsg(msg);

                log.Info("Sending detector_config");

                previewSession = true;
            }
            catch(Exception ex)
            {
                log.Error(ex.Message, ex);
            }
        }

        private void tabs_SelectedIndexChanged(object sender, EventArgs e)
        {
            // Update UI based on selected tab
            Text = "Session - " + tabs.SelectedTab.Text;
            
            menuItemView.Visible = true;
            menuItemSession.Visible = false;

            if (tabs.SelectedTab == pageDetectors)
            {
            }
            else if (tabs.SelectedTab == pageSessions)
            {
                parent.SetUILayout(UILayout.Session1);
                menuItemSession.Visible = true;
            }
            else if (tabs.SelectedTab == pageStatus)
            {
                uploadServiceAvailable = false;
                tbStatusIPAddressUpload.Text = settings.LastUploadHostname;
                tbStatusUploadUser.Text = settings.LastUploadUsername;
                tbStatusUploadPass.Text = settings.LastUploadPassword;

                parent.SetUILayout(UILayout.Setup);
            }
            else if (tabs.SelectedTab == pageSetup)
            {
                btnSetupStopTest.Enabled = false;
                panelSetupGraph.Enabled = false;
                ClearSetup();
            }
            else if (tabs.SelectedTab == pageMenu)
            {
                parent.SetUILayout(UILayout.Menu);
                menuItemView.Visible = false;
            }            
        }             

        private void lbSession_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (lbSession.SelectedItems.Count < 1)
            {                
                parent.SetSelectedSessionIndex(-1);
            }                
            else if (lbSession.SelectedItems.Count == 1)
            {
                Spectrum s = lbSession.SelectedItem as Spectrum;
                parent.SetSelectedSessionIndex(s.SessionIndex);
            }
            else
            {                
                Spectrum s1 = lbSession.SelectedItems[lbSession.SelectedIndices.Count - 1] as Spectrum;
                Spectrum s2 = lbSession.SelectedItems[0] as Spectrum;
                parent.SetSelectedSessionIndices(s1.SessionIndex, s2.SessionIndex);
            }
        }

        private void menuItemLoadSession_Click(object sender, EventArgs e)
        {
            try
            {
                if (Directory.Exists(settings.SessionRootDirectory))
                    openSessionDialog.InitialDirectory = settings.SessionRootDirectory;
                openSessionDialog.Title = "Select session database";
                openSessionDialog.Filter = "Session database (*.db)|*.db";
                if (openSessionDialog.ShowDialog() != DialogResult.OK)
                    return;

                parent.ClearSession();
                
                session = DB.LoadSessionFile(openSessionDialog.FileName);

                lblSessionsDatabase.Text = session.SessionFile + " [" + session.IPAddress + "]";

                // Update UI
                lblSession.Text = session.Name;
                lblComment.Text = session.Comment;

                parent.SetSession(session);

                log.Info("session " + session.Name + " loaded");

                burn.ProtocolMessage msg = new burn.ProtocolMessage(session.IPAddress);
                msg.Params.Add("command", "dump_session");
                sendMsg(msg);
            }
            catch (Exception ex)
            {
                log.Error(ex.Message, ex);
                return;
            }
        }

        public void SetSession(Session s)
        {
            foreach (Spectrum spec in s.Spectrums)            
                lbSession.Items.Insert(0, spec);

            lblSession.Text = "Session: " + session.Name;
        }

        private void menuItemLoadBackgroundSession_Click(object sender, EventArgs e)
        {
            if(session == null || !session.IsLoaded)
            {
                MessageBox.Show("You must load a session first");
                return;
            }

            try
            {
                openSessionDialog.InitialDirectory = settings.SessionRootDirectory;
                openSessionDialog.Title = "Select background session file";
                if (openSessionDialog.ShowDialog() == DialogResult.OK)
                {
                    ClearBackground();
                    
                    bkgSession = DB.LoadSessionFile(openSessionDialog.FileName);

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
                    log.Info("Background " + bkgSession.Name + " loaded for session " + session.Name);
                }
            }
            catch (Exception ex)
            {
                log.Error(ex.Message, ex);
                return;
            }
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

            lbNuclides.ClearSelected();
            lbNuclides.Items.Clear();
        }        

        private void menuItemSessionInfo_Click(object sender, EventArgs e)
        {
            if(session == null || !session.IsLoaded)
            {
                MessageBox.Show("Can not open session info. No session loaded");
                return;
            }

            FormSessionInfo form = new FormSessionInfo(settings, log, session, "Session Info");
            form.ShowDialog();
        }

        private void menuItemClearSession_Click(object sender, EventArgs e)
        {
            parent.ClearSession();
        }

        private void menuItemClearBackground_Click(object sender, EventArgs e)
        {
            ClearBackground();
        }

        private void menuItemShowROIHistory_Click(object sender, EventArgs e)
        {
            FormROIHist form = new FormROIHist(settings, log, session);
            form.ShowDialog();
        }        

        private void btnMenuPreferences_Click(object sender, EventArgs e)
        {
            tabs.SelectedTab = pageDetectors;
        }

        private void btnAddDetector_Click(object sender, EventArgs e)
        {
            FormAddDetector form = new FormAddDetector(log, null);
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
            
            parent.SaveSettings();

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
            if (String.IsNullOrEmpty(settings.SessionRootDirectory) || !Directory.Exists(settings.SessionRootDirectory))
            {
                MessageBox.Show("You must provide a valid session directory under preferences");
                return;
            }

            returnFromSetup = pageNew;
            btnStatusNext.Enabled = false;
            ClearStatus();
            tbStatusIPAddress.Text = settings.LastHostname;            
            tabs.SelectedTab = pageStatus;
        }

        private void menuItemStopSession_Click(object sender, EventArgs e)
        {
            if(session == null)
            {
                MessageBox.Show("No session is active");
                return;
            }

            try
            {
                burn.ProtocolMessage msg = new burn.ProtocolMessage(session.IPAddress);
                msg.Params.Add("command", "stop_session");
                msg.Params.Add("session_name", session.Name);
                sendMsg(msg);

                log.Info("Sending stop_session");
            }
            catch(Exception ex)
            {
                log.Error(ex.Message, ex);
            }
        }

        private void graphSession_MouseDoubleClick(object sender, MouseEventArgs e)
        {
            if (session == null || !session.IsLoaded)
                return;

            int x, y;
            GetGraphPointFromMousePos(e.X, e.Y, graphSession, out x, out y);

            double E = session.Detector.GetEnergy(x);
            if(E == 0.0)
            {
                log.Warn("Unable to get energy for detector " + session.Detector.Serialnumber);
                return;
            }

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
            try
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
                btnSetupClose.Enabled = false;
                btnSetupCancel.Enabled = false;
                log.Info("Sending start_session (setup)");
            }
            catch(Exception ex)
            {
                log.Error(ex.Message, ex);
            }
        }

        private void btnSetupStopTest_Click(object sender, EventArgs e)
        {
            if(String.IsNullOrEmpty(previewSessionName))
            {
                MessageBox.Show("No setup session name found");
                return;
            }

            try
            {
                burn.ProtocolMessage msg = new burn.ProtocolMessage(tbStatusIPAddress.Text.Trim());
                msg.Params.Add("command", "stop_session");
                msg.Params.Add("session_name", previewSessionName);
                sendMsg(msg);
                log.Info("Sending stop_session (setup)");
            }
            catch(Exception ex)
            {
                log.Error(ex.Message, ex);
            }
        }

        private void menuItemResetCoefficients_Click(object sender, EventArgs e)
        {
            energyLines.Clear();
            graphSetup.GraphPane.GraphObjList.RemoveAll(o => isGraphObjectType(o.Tag, GraphObjectType.EnergyCalibration));
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

            parent.SaveSettings();
        }        

        private void btnEditDetector_Click(object sender, EventArgs e)
        {
            if (lvDetectors.SelectedItems.Count == 0)
                return;

            // Show edit detector form
            FormAddDetector form = new FormAddDetector(log, (Detector)lvDetectors.SelectedItems[0].Tag);
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

            parent.SaveSettings();

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
                        log.Warn("No channel found for energy: " + ni.Name + " " + ne.Energy.ToString());
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

            try
            {
                SessionExporter.ExportAsCSV(log, session, dialog.FileName);
            }
            catch(Exception ex)
            {
                log.Error(ex.Message, ex);
            }
        }

        private void menuItemSaveAsCHN_Click(object sender, EventArgs e)
        {
            if (session == null || session.IsEmpty)
            {
                MessageBox.Show("No session active");
                return;
            }

            try
            {
                FolderBrowserDialog dialog = new FolderBrowserDialog();
                dialog.ShowNewFolderButton = true;
                dialog.Description = "Select folder to store CHN files";
                if (dialog.ShowDialog() == DialogResult.OK)
                {
                    SessionExporter.ExportAsCHN(log, session, dialog.SelectedPath);
                    log.Info("session " + session.Name + " stored with CHN format in " + dialog.SelectedPath);
                }
            }
            catch (Exception ex)
            {
                log.Error(ex.Message, ex);
            }
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

            try
            {
                SessionExporter.ExportAsKMZ(log, session, dialog.FileName);
            }
            catch (Exception ex)
            {
                log.Error(ex.Message, ex);
            }
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

            parent.SaveSettings();

            string ip = tbStatusIPAddress.Text.Trim();
            float livetime = selectedDetector.Livetime;
            string comment = tbNewComment.Text.Trim();
            string sessionName = String.Format("{0:yyyyMMdd_HHmmss}", DateTime.Now);

            parent.ClearSession();

            try
            {
                string sessionFile = settings.SessionRootDirectory + Path.DirectorySeparatorChar + sessionName + ".db";
                session = new Session(ip, sessionFile, sessionName, comment, livetime, selectedDetector);

                // Create session database
                CreateSessionFile(session);            

                log.Info("Sending start_session");

                burn.ProtocolMessage msg = new burn.ProtocolMessage(ip);
                msg.Params.Add("command", "start_session");
                msg.Params.Add("session_name", sessionName);
                msg.Params.Add("ip", ip);
                msg.Params.Add("livetime", livetime);
                msg.Params.Add("comment", comment);            
                sendMsg(msg);
            }
            catch (Exception ex)
            {
                log.Error(ex.Message, ex);
                return;
            }

            previewSession = false;

            lblSessionsDatabase.Text = session.SessionFile + " [" + session.IPAddress + "]";

            lblSession.Text = session.Name;
            lblComment.Text = session.Comment;

            parent.SetSession(session);

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
            tbSetupVoltage.Text = selectedDetector.Voltage.ToString();
            int coarse = Convert.ToInt32(selectedDetector.CoarseGain);
            cboxSetupCoarseGain.SelectedIndex = cboxSetupCoarseGain.FindStringExact(coarse.ToString());
            tbSetupFineGain.Text = selectedDetector.FineGain.ToString();
            tbSetupLLD.Text = selectedDetector.LLD.ToString();
            tbSetupULD.Text = selectedDetector.ULD.ToString();

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
            tbStatusIPAddress.Text = settings.LastHostname;
            tabs.SelectedTab = pageStatus;
        }

        private void btnSessionsClose_Click(object sender, EventArgs e)
        {
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

            btnStatusNext.Enabled = false;
            ClearStatus();
        }

        private void btnStatusCancel_Click(object sender, EventArgs e)
        {
            if (returnFromSetup == pageNew)
                tabs.SelectedTab = pageSessions;
            else tabs.SelectedTab = pageMenu;
        }

        private void btnSetupCancel_Click(object sender, EventArgs e)
        {
            if (returnFromSetup == pageNew)
                tabs.SelectedTab = pageSessions;
            else tabs.SelectedTab = pageMenu;
        }

        private void btnStatusNext_Click(object sender, EventArgs e)
        {
            settings.LastHostname = tbStatusIPAddress.Text;
            parent.SaveSettings();

            if(cbStatusReachback.Checked && uploadServiceAvailable)            
                uploadServiceActive = true;
            else uploadServiceActive = false;

            if (uploadServiceActive)
            {
                settings.LastUploadHostname = tbStatusIPAddressUpload.Text.Trim();
                settings.LastUploadUsername = tbStatusUploadUser.Text.Trim();
                settings.LastUploadPassword = tbStatusUploadPass.Text;
                parent.SaveSettings();

                netUpload.SetCredentials(settings.LastUploadHostname, settings.LastUploadUsername, settings.LastUploadPassword);
            }

            lblSetupIPAddress.Text = "IP Address: " + settings.LastHostname;
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
            parent.SaveSettings();
            tabs.SelectedTab = pageMenu;
        }

        void ClearStatus()
        {
            lblStatusFreeDiskSpace.Text = "";
            lblStatusSessionRunning.Text = "";
            lblStatusSpectrumIndex.Text = "";
            lblStatusDetectorConfigured.Text = "";
            lblStatusUpload.Text = "";
        }

        private void tbStatusIPAddress_TextChanged(object sender, EventArgs e)
        {
            btnStatusNext.Enabled = false;
            ClearStatus();
        }

        private void menuItemSyncCurrentSession_Click(object sender, EventArgs e)
        {
            if (session == null)
            {
                MessageBox.Show("No session is active");
                return;
            }

            try
            {
                // Sync session
                int lastKnownIndex = session.Spectrums.Max(s => s.SessionIndex);

                var existingIndices = new List<int>();
                foreach (Spectrum s in session.Spectrums)
                    existingIndices.Add(s.SessionIndex);

                var missingIndices = Enumerable.Range(0, lastKnownIndex).Except(existingIndices);

                burn.ProtocolMessage msg = new burn.ProtocolMessage(session.IPAddress);
                msg.Params.Add("command", "sync_session");
                msg.Params.Add("session_name", session.Name);
                msg.Params.Add("last_index", lastKnownIndex);
                msg.Params.Add("indices_list", missingIndices.Take(50).ToArray()); // Max 50 indices at a time
                sendMsg(msg);

                log.Info("Sending sync_session");
            }
            catch(Exception ex)
            {
                log.Error(ex.Message, ex);
            }
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
            log.Info("Background selection " + minIndex + " -> " + maxIndex + " loaded for session " + session.Name);            
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

            try
            {
                bool canUpdateSettingsDetector = settings.Detectors.Exists(x => x.Serialnumber == session.Detector.Serialnumber);

                FormAskZeroPolynomial form = new FormAskZeroPolynomial(log, session.Detector, selectedChannel, canUpdateSettingsDetector);
                if (form.ShowDialog() == DialogResult.OK)
                {
                    session.Detector.EnergyCurveCoefficients[0] = form.ZeroPolynomial;
                    // FIXME: Save session.Detector to database

                    string sessionPath = settings.SessionRootDirectory + Path.DirectorySeparatorChar + session.Name + ".db";
                    if (!File.Exists(sessionPath))
                    {
                        MessageBox.Show("Unable to find session database: " + sessionPath);
                        return;
                    }

                    using (SQLiteConnection connection = new SQLiteConnection("Data Source=" + sessionPath + "; Version=3; FailIfMissing=True; Foreign Keys=True;"))
                    {
                        connection.Open();
                        SQLiteCommand command = new SQLiteCommand(connection);
                        command.CommandText = "select id from session where name = @name";
                        command.Parameters.AddWithValue("@name", session.Name);
                        object o = command.ExecuteScalar();
                        if (o == null || o == DBNull.Value)
                        {
                            log.Error("Unable to find session name " + session.Name + " in database");
                            return;
                        }
                        int sessionId = Convert.ToInt32(o);

                        string detectorData = JsonConvert.SerializeObject(session.Detector, Newtonsoft.Json.Formatting.None);

                        command.Parameters.Clear();
                        command.CommandText = "update session set detector_data=@detector_data where id=@id";
                        command.Parameters.AddWithValue("@detector_data", detectorData);
                        command.Parameters.AddWithValue("@id", sessionId);
                        command.ExecuteNonQuery();
                    }

                    if (form.SaveToSettings)
                    {
                        Detector settingsDetector = settings.Detectors.Find(x => x.Serialnumber == session.Detector.Serialnumber);
                        if (settingsDetector == null)
                        {
                            MessageBox.Show("Detector " + session.Detector.Serialnumber + " was not found in settings");
                            return;
                        }
                        settingsDetector.EnergyCurveCoefficients = session.Detector.EnergyCurveCoefficients;
                        parent.SaveSettings();
                    }
                }
            }
            catch(Exception ex)
            {
                log.Error(ex.Message, ex);
            }
        }

        private void graphSession_MouseClick(object sender, MouseEventArgs e)
        {
            int x, y;
            GetGraphPointFromMousePos(e.X, e.Y, graphSession, out x, out y);

            selectedChannel = x;
            lblSessionSelChannel.Text = "[" + String.Format("{0:####0}", selectedChannel) + "]";
        }

        private void btnUploadSelectSession_Click(object sender, EventArgs e)
        {
            // FIXME: Don't run this while a session is running            

            try
            {
                if (String.IsNullOrEmpty(tbUploadHostname.Text.Trim())
                    || String.IsNullOrEmpty(tbUploadUsername.Text.Trim())
                    || String.IsNullOrEmpty(tbUploadPassword.Text))
                {
                    MessageBox.Show("You must specify a hostname, username and password");
                    return;
                }

                OpenFileDialog dialog = new OpenFileDialog();
                if (dialog.ShowDialog() != DialogResult.OK)
                    return;

                settings.LastUploadHostname = tbUploadHostname.Text.Trim();
                settings.LastUploadUsername = tbUploadUsername.Text.Trim();
                settings.LastUploadPassword = tbUploadPassword.Text;
                parent.SaveSettings();

                netUpload.SetCredentials(settings.LastUploadHostname, settings.LastUploadUsername, settings.LastUploadPassword);
                Session session = DB.LoadSessionFile(dialog.FileName);

                HttpWebRequest request = (HttpWebRequest)WebRequest.Create(settings.LastUploadHostname + "/sessions");
                string credentials = Convert.ToBase64String(ASCIIEncoding.ASCII.GetBytes(settings.LastUploadUsername + ":" + settings.LastUploadPassword));
                request.Headers.Add("Authorization", "Basic " + credentials);
                request.Timeout = 8000;
                request.Method = WebRequestMethods.Http.Post;
                request.Accept = "application/json";

                APISession apiSession = new APISession(session);

                var jsonRequest = JsonConvert.SerializeObject(apiSession);
                var sendData = Encoding.UTF8.GetBytes(jsonRequest);

                request.ContentType = "application/json";
                request.ContentLength = sendData.Length;

                using (var stream = request.GetRequestStream())
                {
                    stream.Write(sendData, 0, sendData.Length);
                }

                string recvData;
                HttpStatusCode code = Utils.GetResponseData(request, out recvData);

                if (code == HttpStatusCode.OK)
                {
                    log.Info(recvData);
                }
                else if (code == HttpStatusCode.RequestTimeout)
                {
                    log.Error("Request timeout");
                }
                else
                {
                    log.Error(code.ToString() + ": " + recvData);
                }

                foreach (Spectrum spec in session.Spectrums)
                {
                    sendUploadQ.Enqueue(spec);
                    System.Threading.Thread.Sleep(1);
                }
            }
            catch(Exception ex)
            {
                log.Error(ex);
            }
        }

        private void btnMenuUpload_Click(object sender, EventArgs e)
        {
            tbUploadHostname.Text = settings.LastUploadHostname;
            tbUploadUsername.Text = settings.LastUploadUsername;
            tbUploadPassword.Text = settings.LastUploadPassword;
            tbUploadLog.Text = String.Empty;
            tabs.SelectedTab = pageUpload;
        }

        private void btnUploadClose_Click(object sender, EventArgs e)
        {
            tabs.SelectedTab = pageMenu;
        }

        public void Shutdown()
        {            
            if (netUpload.IsRunning())
            {
                netUpload.RequestStop();
                netUploadThread.Join();
                log.Info("net upload closed");
            }

            if (netService.IsRunning())
            {
                netService.RequestStop();
                netThread.Join();
                log.Info("net service closed");
            }

            // Stop timer listening for network messages
            timer.Stop();
        }

        private void menuItemUseAsGroundLevel_Click(object sender, EventArgs e)
        {
            if (session == null || !session.IsLoaded)            
                return;

            if (lbSession.SelectedItems.Count != 1)
            {
                MessageBox.Show("Only a single spectrum can be used as ground level");
                return;
            }

            Spectrum spec = lbSession.SelectedItems[0] as Spectrum;
            currentGroundLevelIndex = spec.SessionIndex;
            lblGroundLevelIndex.Text = "Gnd idx: " + currentGroundLevelIndex;
        }

        private void btnStatusGetReachback_Click(object sender, EventArgs e)
        {
            lblStatusUpload.Text = "";
            uploadServiceAvailable = false;

            string url = tbStatusIPAddressUpload.Text.Trim();
            string username = tbStatusUploadUser.Text.Trim();
            string password = tbStatusUploadPass.Text.Trim();

            HttpWebRequest request = (HttpWebRequest)WebRequest.Create(url + "/sessions/names");
            string credentials = Convert.ToBase64String(ASCIIEncoding.ASCII.GetBytes(username + ":" + password));
            request.Headers.Add("Authorization", "Basic " + credentials);
            request.Timeout = 8000;
            request.Method = WebRequestMethods.Http.Get;
            request.Accept = "application/json";

            string data;
            HttpStatusCode code = Utils.GetResponseData(request, out data);

            if (code == HttpStatusCode.OK)
            {
                uploadServiceAvailable = true;
                lblStatusUpload.Text = "Web service available";
            }
            else if(code == HttpStatusCode.RequestTimeout)
            {                
                lblStatusUpload.Text = "Web service timeout";
            }
            else
            {            
                lblStatusUpload.Text = "Web service unavailable";
            }
        }

        private void cbStatusReachback_CheckedChanged(object sender, EventArgs e)
        {
            if(cbStatusReachback.Checked)
            {
                tbStatusIPAddressUpload.Enabled = true;
                tbStatusUploadUser.Enabled = true;
                tbStatusUploadPass.Enabled = true;
            }
            else
            {
                tbStatusIPAddressUpload.Enabled = false;
                tbStatusUploadUser.Enabled = false;
                tbStatusUploadPass.Enabled = false;
            }
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

            try
            {
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
            catch(Exception ex)
            {
                log.Error(ex.Message, ex);
            }
        }
    }
}
