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
using System.ComponentModel;
using System.IO;
using System.Drawing;
using System.Text;
using System.Windows.Forms;
using System.Globalization;
using Newtonsoft.Json;
using ZedGraph;
using MathNet.Numerics;
using System.Data.SQLite;

namespace crash
{
    public partial class FormMain : Form
    {
        public FormMain()
        {
            InitializeComponent();
        }

        private void FormMain_Load(object sender, EventArgs e)
        {
            try
            {                
                // Hide tabs on tabcontrol
                tabs.ItemSize = new Size(0, 1);
                tabs.SizeMode = TabSizeMode.Fixed;                

                // Create directories and files
                if (!Directory.Exists(GAEnvironment.SettingsPath))
                    Directory.CreateDirectory(GAEnvironment.SettingsPath);

                if (!Directory.Exists(GAEnvironment.GEScriptPath))
                    Directory.CreateDirectory(GAEnvironment.GEScriptPath);                
                
                InstallDir = Path.GetDirectoryName(Environment.GetCommandLineArgs()[0]) + Path.DirectorySeparatorChar;                

                if (!File.Exists(GAEnvironment.SettingsFile))
                    File.Copy(InstallDir + "template_settings.xml", GAEnvironment.SettingsFile, false);

                if (!File.Exists(GAEnvironment.NuclideLibraryFile))
                    File.Copy(InstallDir + "template_nuclides.lib", GAEnvironment.NuclideLibraryFile, false);

                if (!File.Exists(GAEnvironment.GEScriptPath + Path.DirectorySeparatorChar + "Nai-2tom.py"))
                    File.Copy(InstallDir + "template_Nai-2tom.py", GAEnvironment.GEScriptPath + Path.DirectorySeparatorChar + "Nai-2tom.py", true);

                if (!File.Exists(GAEnvironment.GEScriptPath + Path.DirectorySeparatorChar + "Nai-3tom.py"))
                    File.Copy(InstallDir + "template_Nai-3tom.py", GAEnvironment.GEScriptPath + Path.DirectorySeparatorChar + "Nai-3tom.py", true);

                // Load settings
                LoadSettings();
                menuItemConvertToLocalTime.Checked = settings.DisplayLocalTime;

                LoadNuclideLibrary();

                // Create forms
                formWaterfallLive = new FormWaterfallLive(settings.ROIList);                
                formROILive = new FormROILive(settings.ROIList);                
                frmMap = new FormMap();                

                // Set up custom events
                formWaterfallLive.SetSessionIndexEvent += SetSessionIndexEvent;
                formROILive.SetSessionIndexEvent += SetSessionIndexEvent;
                frmMap.SetSessionIndexEvent += SetSessionIndexEvent;

                tbNewLivetime.KeyPress += CustomEvents.Integer_KeyPress;

                // Populate UI
                tbPreferencesSessionDir.Text = settings.SessionRootDirectory;
                PopulateDetectorTypeList();
                PopulateDetectorList();
                PopulateDetectors();
                
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
            if (String.IsNullOrEmpty(tbStatusIPAddress.Text.Trim()))
            {
                MessageBox.Show("No IP address selected");
                return;
            }

            // Convert parameters
            int voltage = tbarSetupVoltage.Value;
            double coarse = 0f;
            double fine = 0f;
            int nchannels = 0;

            try
            {
                coarse = Convert.ToSingle(cboxSetupCoarseGain.Text, CultureInfo.InvariantCulture);
                fine = Convert.ToDouble((double)tbarSetupFineGain.Value / 1000d);
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

            // Create and send network message
            burn.ProtocolMessage msg = new burn.ProtocolMessage(tbStatusIPAddress.Text.Trim());
            msg.Params.Add("command", "detector_config");            
            msg.Params.Add("detector_type", "osprey");
            msg.Params.Add("voltage", voltage);
            msg.Params.Add("coarse_gain", coarse);
            msg.Params.Add("fine_gain", fine);
            msg.Params.Add("num_channels", nchannels);
            msg.Params.Add("lld", lld);
            msg.Params.Add("uld", uld);
            sendMsg(msg);

            previewSession = true;

            Utils.Log.Add("Sending detector_config");
        }

        private void tabs_SelectedIndexChanged(object sender, EventArgs e)
        {
            // Update UI based on selected tab
            lblInterface.Text = tabs.SelectedTab.Text.ToUpper();

            tools.Visible = true;
            menuItemView.Visible = true;
            menuItemSession.Visible = false;

            if (tabs.SelectedTab == pageDetectors)
            {
            }
            else if (tabs.SelectedTab == pageSessions)
            {
                menuItemSession.Visible = true;
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
                tools.Visible = false;
                menuItemLayoutSetup1_Click(sender, e);
            }
        }             

        private void lbSession_SelectedIndexChanged(object sender, EventArgs e)
        {
            // Update session UI

            if (lbSession.SelectedItems.Count < 1)
            {
                // Clear UI
                formWaterfallLive.SetSelectedSessionIndex(-1);
                frmMap.SetSelectedSessionIndex(-1);
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
                lblLatitude.Text = "Latitude: " + s.Latitude.ToString("00.0000000") + " ±" + s.LatitudeError.ToString("###0.0#");
                lblLongitude.Text = "Longitude: " + s.Longitude.ToString("00.0000000") + " ±" + s.LongitudeError.ToString("###0.0#");
                lblAltitude.Text = "Altitude: " + s.Altitude.ToString("#####0.0#") + " ±" + s.AltitudeError.ToString("###0.0#");
                lblGpsTime.Text = "Time: " + (menuItemConvertToLocalTime.Checked ? s.GpsTime.ToLocalTime() : s.GpsTime);
                lblMaxCount.Text = "Max count: " + s.MaxCount;
                lblMinCount.Text = "Min count: " + s.MinCount;
                lblTotalCount.Text = "Total count: " + s.TotalCount;                
                if(s.Doserate == 0.0)
                    lblDoserate.Text = "";
                else lblDoserate.Text = "Doserate (μSv/h): " + String.Format("{0:###0.0##}", s.Doserate / 1000.0);

                // Inform other forms of new spectrum selection
                if (formWaterfallLive.Visible)
                    formWaterfallLive.SetSelectedSessionIndex(s.SessionIndex);
                if (frmMap.Visible)
                    frmMap.SetSelectedSessionIndex(s.SessionIndex);
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

                // Populate controls
                ShowSpectrum(title, chans, maxCnt, minCnt);

                lblRealtime.Text = "Realtime:" + realTime;
                lblLivetime.Text = "Livetime:" + liveTime;
                lblSession.Text = "Session: " + s1.SessionName;
                lblIndex.Text = "Index: " + s1.SessionIndex + " - " + s2.SessionIndex;
                lblLatitude.Text = "Latitude: " + s1.Latitude.ToString("00.0000000") + " ±" + s2.LatitudeError.ToString("###0.0#");
                lblLongitude.Text = "Longitude: " + s1.Longitude.ToString("00.0000000") + " ±" + s2.LongitudeError.ToString("###0.0#");
                lblAltitude.Text = "Altitude: " + s1.Altitude.ToString("#####0.0#") + " ±" + s2.AltitudeError.ToString("###0.0#");
                lblGpsTime.Text = "Time: " + (menuItemConvertToLocalTime.Checked ? s1.GpsTime.ToLocalTime() : s1.GpsTime);                
                lblMaxCount.Text = "Max count: " + maxCnt;
                lblMinCount.Text = "Min count: " + minCnt;
                lblTotalCount.Text = "Total count: " + totCnt;
                lblDoserate.Text = "";

                // Notify external forms about new spectrum selection
                if (formWaterfallLive.Visible)
                    formWaterfallLive.SetSelectedSessionIndices(s1.SessionIndex, s2.SessionIndex);
                if (frmMap.Visible)
                    frmMap.SetSelectedSessionIndices(s1.SessionIndex, s2.SessionIndex);
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
            s.DetectorType = JsonConvert.DeserializeObject<DetectorType>(reader["detector_type_data"].ToString());

            reader.Close();
            // Load GEFactor script
            if (!s.LoadGEFactor())
                Utils.Log.Add("Loading GEFactor failed for session " + s.Name);

            // Load session spectrums
            command.CommandText = "select * from spectrums";
            reader = command.ExecuteReader();
            while (reader.Read())
            {
                Spectrum spec = new Spectrum();
                spec.SessionName = reader["session_name"].ToString();
                spec.SessionIndex = Convert.ToInt32(reader["session_index"]);
                spec.GpsTime = Convert.ToDateTime(reader["start_time"]);
                spec.Latitude = Convert.ToDouble(reader["latitude"]);
                spec.LatitudeError = Convert.ToDouble(reader["latitude_error"]);
                spec.Longitude = Convert.ToDouble(reader["longitude"]);
                spec.LongitudeError = Convert.ToDouble(reader["longitude_error"]);
                spec.Altitude = Convert.ToDouble(reader["altitude"]);
                spec.AltitudeError = Convert.ToDouble(reader["altitude_error"]);
                spec.GpsTrack = Convert.ToSingle(reader["track"]);
                spec.GpsTrackError = Convert.ToSingle(reader["track_error"]);
                spec.GpsSpeed = Convert.ToSingle(reader["speed"]);
                spec.GpsSpeedError = Convert.ToSingle(reader["speed_error"]);
                spec.GpsClimb = Convert.ToSingle(reader["climb"]);
                spec.GpsClimbError = Convert.ToSingle(reader["climb_error"]);
                spec.Livetime = Convert.ToInt32(reader["livetime"]);
                spec.Realtime = Convert.ToInt32(reader["realtime"]);
                spec.TotalCount = Convert.ToInt32(reader["total_count"]);
                spec.NumChannels = Convert.ToInt32(reader["num_channels"]);
                spec.LoadSpectrumString(reader["channels"].ToString());
                spec.CalculateDoserate(s.Detector, s.GEFactor);
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

                // Update UI
                lblSession.Text = session.Name;
                lblComment.Text = session.Comment;

                // Inform other forms
                formWaterfallLive.SetSession(session);
                formWaterfallLive.SetDetector(session.Detector);
                formROILive.SetSession(session);
                frmMap.SetSession(session);

                // Add spectrums to map
                foreach(Spectrum s in session.Spectrums)
                {
                    lbSession.Items.Insert(0, s);
                    frmMap.AddMarker(s);
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
                session.SetBackground(bkgSession);

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
            frmMap.Show();
            frmMap.BringToFront();
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

        private void btnMenuPreferences_Click(object sender, EventArgs e)
        {
            tabs.SelectedTab = pageDetectors;
        }

        private void btnAddDetectorType_Click(object sender, EventArgs e)
        {
            FormAddDetectorType form = new FormAddDetectorType(null);
            if (form.ShowDialog() == DialogResult.OK)
            {
                settings.DetectorTypes.Add(new DetectorType(form.TypeName, form.MaxChannels, form.MinHV, form.MaxHV, form.GEScript));
                PopulateDetectorTypeList();
            }
        }

        private void btnAddDetector_Click(object sender, EventArgs e)
        {
            FormAddDetector form = new FormAddDetector(null, settings.DetectorTypes);
            if (form.ShowDialog() == DialogResult.Cancel)
                return;

            Detector det = new Detector();
            det.TypeName = form.DetectorType;
            det.Serialnumber = form.Serialnumber;
            det.CurrentNumChannels = form.NumChannels;
            det.CurrentHV = form.HV;
            det.CurrentCoarseGain = form.CoarseGain;
            det.CurrentFineGain = form.FineGain;
            det.CurrentLivetime = form.Livetime;
            det.CurrentLLD = form.LLD;
            det.CurrentULD = form.ULD;
            settings.Detectors.Add(det);

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
            burn.ProtocolMessage msg = new burn.ProtocolMessage(session.IPAddress);
            msg.Params.Add("command", "stop_session");
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

            FormAskDecimal form = new FormAskDecimal("Enter expected energy for channel " + x);
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
            burn.ProtocolMessage msg = new burn.ProtocolMessage(tbStatusIPAddress.Text.Trim());
            msg.Params.Add("command", "start_session");            
            msg.Params.Add("session_name", String.Format("{0:ddMMyyyy_HHmmss}", DateTime.Now));
            msg.Params.Add("livetime", 1);
            sendMsg(msg);

            ClearSetup();
            previewSession = true;
            previewSpec = null;
            Utils.Log.Add("Sending start_session (setup)");
        }

        private void btnSetupStopTest_Click(object sender, EventArgs e)
        {
            burn.ProtocolMessage msg = new burn.ProtocolMessage(tbStatusIPAddress.Text.Trim());
            msg.Params.Add("command", "stop_session");
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

            frmMap.Hide();
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

            frmMap.Show();
            frmMap.WindowState = FormWindowState.Normal;
            frmMap.Left = screenWidth / 2;
            frmMap.Top = (screenHeight / 3) * 2;
            frmMap.Width = screenWidth / 2;
            frmMap.Height = screenHeight / 3;

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

            frmMap.Show();
            frmMap.WindowState = FormWindowState.Normal;
            frmMap.Left = screenWidthThird * 2;
            frmMap.Top = 0;
            frmMap.Width = screenWidthThird;
            frmMap.Height = screenHeightThird + screenHeightHalfThird;

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

        private void btnEditDetectorType_Click(object sender, EventArgs e)
        {
            if(lvDetectorTypes.SelectedItems.Count == 0)
                return;

            // Show edit detector type form
            DetectorType detType = (DetectorType)lvDetectorTypes.SelectedItems[0].Tag;
            FormAddDetectorType form = new FormAddDetectorType(detType);
            if (form.ShowDialog() == DialogResult.Cancel)
                return;
            
            // Update selected detector type
            detType.MaxNumChannels = form.MaxChannels;
            detType.MinHV = form.MinHV;
            detType.MaxHV = form.MaxHV;
            detType.GEScript = form.GEScript;
            PopulateDetectorTypeList();
        }

        private void btnEditDetector_Click(object sender, EventArgs e)
        {
            if (lvDetectors.SelectedItems.Count == 0)
                return;

            // Show edit detector form
            FormAddDetector form = new FormAddDetector((Detector)lvDetectors.SelectedItems[0].Tag, settings.DetectorTypes);
            if (form.ShowDialog() == DialogResult.Cancel)
                return;

            // Update selected detector
            Detector det = (Detector)lvDetectors.SelectedItems[0].Tag;
            det.TypeName = form.DetectorType;
            det.Serialnumber = form.Serialnumber;
            det.CurrentNumChannels = form.NumChannels;
            det.CurrentHV = form.HV;
            det.CurrentCoarseGain = form.CoarseGain;
            det.CurrentFineGain = form.FineGain;
            det.CurrentLivetime = form.Livetime;
            det.CurrentLLD = form.LLD;
            det.CurrentULD = form.ULD;

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

        private void menuItemUpdateCurrentSession_Click(object sender, EventArgs e)
        {
            // Update session
        }

        private void btnNewStart_Click(object sender, EventArgs e)
        {            
            if (!String.IsNullOrEmpty(tbNewLivetime.Text.Trim()))
                selectedDetector.CurrentLivetime = Convert.ToInt32(tbNewLivetime.Text.Trim());
            DetectorType detType = settings.DetectorTypes.Find(dt => dt.Name == selectedDetector.TypeName);

            SaveSettings();            

            burn.ProtocolMessage msg = new burn.ProtocolMessage(tbStatusIPAddress.Text.Trim());
            msg.Params.Add("command", "start_session");
            msg.Params.Add("session_name", String.Format("{0:ddMMyyyy_HHmmss}", DateTime.Now));
            msg.Params.Add("ip", tbStatusIPAddress.Text.Trim());
            msg.Params.Add("livetime", selectedDetector.CurrentLivetime);
            msg.Params.Add("comment", tbNewComment.Text.Trim());
            string jDetectorData = JsonConvert.SerializeObject(selectedDetector, Newtonsoft.Json.Formatting.None);
            string jDetectorTypeData = JsonConvert.SerializeObject(detType, Newtonsoft.Json.Formatting.None);
            msg.Params.Add("detector_data", jDetectorData);
            msg.Params.Add("detector_type_data", jDetectorTypeData);
            sendMsg(msg);

            previewSession = false;

            Utils.Log.Add("Sending start_session");            
        }

        private void btnNewCancel_Click(object sender, EventArgs e)
        {
            tabs.SelectedTab = pageSessions;
        }

        private void btnSetupClose_Click(object sender, EventArgs e)
        {
            if (returnFromSetup == pageNew)
            {
                tbNewLivetime.Text = selectedDetector.CurrentLivetime.ToString();
                tbNewComment.Text = "";
            }

            tabs.SelectedTab = returnFromSetup;
        }

        private void cboxSetupDetector_SelectedIndexChanged(object sender, EventArgs e)
        {
            selectedDetector = cboxSetupDetector.SelectedItem as Detector;
            DetectorType detType = settings.DetectorTypes.Find(dt => dt.Name == selectedDetector.TypeName);
            
            cboxSetupChannels.Text = selectedDetector.CurrentNumChannels.ToString();

            tbarSetupVoltage.Minimum = detType.MinHV;
            tbarSetupVoltage.Maximum = detType.MaxHV;
            tbarSetupVoltage.Value = selectedDetector.CurrentHV;

            int coarse = Convert.ToInt32(selectedDetector.CurrentCoarseGain);
            cboxSetupCoarseGain.SelectedIndex = cboxSetupCoarseGain.FindStringExact(coarse.ToString());
            tbarSetupFineGain.Value = (int)((double)selectedDetector.CurrentFineGain * 1000d);
            tbarSetupLLD.Value = selectedDetector.CurrentLLD;
            tbarSetupULD.Value = selectedDetector.CurrentULD;
            cboxSetupChannels.Items.Clear();
            for (int i = 256; i <= detType.MaxNumChannels; i = i * 2)
                cboxSetupChannels.Items.Add(i.ToString());
            cboxSetupChannels.Text = selectedDetector.CurrentNumChannels.ToString();
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

        private void FormMain_Paint(object sender, PaintEventArgs e)
        {
            if(!appInitialized)
            {
                appInitialized = true;
                tabs.SelectedTab = pageMenu;
            }            
        }
    }
}
