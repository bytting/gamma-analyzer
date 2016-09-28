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
using System.Collections.Generic;
using System.ComponentModel;
using System.IO;
using System.Drawing;
using System.Text;
using System.Windows.Forms;
using System.Threading;
using System.Globalization;
using Newtonsoft.Json;
using ZedGraph;
using MathNet.Numerics;

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
                tabs.SelectedTab = pageMenu;

                // Create directories and files
                if (!Directory.Exists(CrashEnvironment.SettingsPath))
                    Directory.CreateDirectory(CrashEnvironment.SettingsPath);

                if (!Directory.Exists(CrashEnvironment.GEScriptPath))
                    Directory.CreateDirectory(CrashEnvironment.GEScriptPath);                
                
                string InstallDir = Path.GetDirectoryName(Environment.GetCommandLineArgs()[0]) + Path.DirectorySeparatorChar;                

                if (!File.Exists(CrashEnvironment.SettingsFile))
                    File.Copy(InstallDir + "template_settings.xml", CrashEnvironment.SettingsFile, false);

                if (!File.Exists(CrashEnvironment.NuclideLibraryFile))
                    File.Copy(InstallDir + "template_nuclides.lib", CrashEnvironment.NuclideLibraryFile, false);

                if (!File.Exists(CrashEnvironment.GEScriptPath + Path.DirectorySeparatorChar + "Nai-2tom.py"))
                    File.Copy(InstallDir + "template_Nai-2tom.py", CrashEnvironment.GEScriptPath + Path.DirectorySeparatorChar + "Nai-2tom.py", true);

                if (!File.Exists(CrashEnvironment.GEScriptPath + Path.DirectorySeparatorChar + "Nai-3tom.py"))
                    File.Copy(InstallDir + "template_Nai-3tom.py", CrashEnvironment.GEScriptPath + Path.DirectorySeparatorChar + "Nai-3tom.py", true);

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

                tbSetupLivetime.KeyPress += CustomEvents.Integer_KeyPress;
                tbSetupSpectrumCount.KeyPress += CustomEvents.Integer_KeyPress;
                tbSetupDelay.KeyPress += CustomEvents.Integer_KeyPress;

                // Populate UI
                tbSessionDir.Text = settings.SessionRootDirectory;
                PopulateDetectorTypeList();
                PopulateDetectorList();
                PopulateDetectors();                

                lblConnectionStatus.ForeColor = Color.Red;
                lblConnectionStatus.Text = "Not connected";
                lblSetupChannel.Text = "";
                lblSessionChannel.Text = "";
                lblSessionEnergy.Text = "";
                lblSetupEnergy.Text = "";
                lblDetector.Text = "";
                separatorDetector.Visible = false;

                lblSessionDetector.Text = "";
                lblBackground.Text = "";
                lblComment.Text = "";
                ClearSpectrumInfo();                                               

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
                burn.Message msg;
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
            menuItemDisconnect_Click(sender, e);            
            Close();
        }

        private void menuItemConnect_Click(object sender, EventArgs e)
        {
            // Show connection form
            FormConnect form = new FormConnect(settings);
            if (form.ShowDialog() != DialogResult.OK)
                return;

            // Send a connect message to networking thread
            burn.Message msg = new burn.Message("connect", null);
            msg.AddParameter("host", settings.LastIP);
            msg.AddParameter("port", settings.LastPort);
            sendMsg(msg);

            Utils.Log.Add("Connecting to " + settings.LastIP + ":" + settings.LastPort + "...");
        }

        private void menuItemDisconnect_Click(object sender, EventArgs e)
        {
            if (!connected)            
                return;            

            if(sessionRunning)
            {
                MessageBox.Show("You must stop the running session first");
                return;
            }
                        
            if (MessageBox.Show("Are you sure you want to disconnect?", "Confirmation", MessageBoxButtons.YesNo) == DialogResult.No)
                return;
            
            // Send disconnect message to network thread
            sendMsg(new burn.Message("disconnect", null));
            Utils.Log.Add("Disconnecting from " + settings.LastIP + ":" + settings.LastPort);
            Thread.Sleep(2000); // FIXME: Graceful shutdown
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
            if(String.IsNullOrEmpty(cboxSetupDetector.Text.Trim()))
            {
                MessageBox.Show("No detector selected");
                return;
            }

            // Convert parameters
            int voltage = tbarSetupVoltage.Value;
            double coarse = 0f;
            double fine = 0f;
            int nchannels = 0;

            try
            {
                coarse = Convert.ToSingle(cboxSetupCoarseGain.Text);
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
            burn.Message msg = new burn.Message("set_gain", null);
            msg.AddParameter("voltage", voltage);
            msg.AddParameter("coarse_gain", coarse);
            msg.AddParameter("fine_gain", fine);
            msg.AddParameter("num_channels", nchannels);
            msg.AddParameter("lld", lld);
            msg.AddParameter("uld", uld);
            sendMsg(msg);

            Utils.Log.Add("SEND: set_gain");
        }        
        
        private void tabs_SelectedIndexChanged(object sender, EventArgs e)
        {
            // Update UI based on selected tab
            lblInterface.Text = tabs.SelectedTab.Text.ToUpper();

            menuItemBack.Enabled = false;
            btnBack.Enabled = false;
            menuItemSession.Visible = false;            

            if (tabs.SelectedTab == pagePreferences)
            {
                menuItemBack.Enabled = true;
                btnBack.Enabled = true;
            }            
            else if (tabs.SelectedTab == pageSessions)
            {
                menuItemBack.Enabled = true;
                btnBack.Enabled = true;
                menuItemSession.Visible = true;
            }
            else if (tabs.SelectedTab == pageSetup)
            {
                menuItemBack.Enabled = true;
                btnBack.Enabled = true;
                btnSetupNext.Enabled = false;
                btnSetupStopTest.Enabled = false;
                panelSetupGraph.Enabled = false;
                ClearSetup();
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
                lblLatitudeStart.Text = "Lat. start: " + s.LatitudeStart;
                lblLongitudeStart.Text = "Lon. start: " + s.LongitudeStart;
                lblAltitudeStart.Text = "Alt. start: " + s.AltitudeStart;
                lblLatitudeEnd.Text = "Lat. end: " + s.LatitudeEnd;
                lblLongitudeEnd.Text = "Lon. end: " + s.LongitudeEnd;
                lblAltitudeEnd.Text = "Alt. end: " + s.AltitudeEnd;
                lblGpsTimeStart.Text = "Time start: " + (menuItemConvertToLocalTime.Checked ? s.GpsTimeStart.ToLocalTime() : s.GpsTimeStart);
                lblGpsTimeEnd.Text = "Time end: " + (menuItemConvertToLocalTime.Checked ? s.GpsTimeEnd.ToLocalTime() : s.GpsTimeEnd);
                lblMaxCount.Text = "Max count: " + s.MaxCount;
                lblMinCount.Text = "Min count: " + s.MinCount;
                lblTotalCount.Text = "Total count: " + s.TotalCount;                
                if(s.Doserate == 0.0)
                    lblDoserate.Text = "";
                else lblDoserate.Text = "Doserate: " + String.Format("{0:###0.0##}", s.Doserate);

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
                lblLatitudeStart.Text = "Lat. start: " + s1.LatitudeStart;
                lblLongitudeStart.Text = "Lon. start: " + s1.LongitudeStart;
                lblAltitudeStart.Text = "Alt. start: " + s1.AltitudeStart;
                lblLatitudeEnd.Text = "Lat. end: " + s2.LatitudeEnd;
                lblLongitudeEnd.Text = "Lon. end: " + s2.LongitudeEnd;
                lblAltitudeEnd.Text = "Alt. end: " + s2.AltitudeEnd;
                lblGpsTimeStart.Text = "Time start: " + (menuItemConvertToLocalTime.Checked ? s1.GpsTimeStart.ToLocalTime() : s1.GpsTimeStart);
                lblGpsTimeEnd.Text = "Time end: " + (menuItemConvertToLocalTime.Checked ? s2.GpsTimeStart.ToLocalTime() : s2.GpsTimeStart);
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

        private void menuItemLoadSession_Click(object sender, EventArgs e)
        {
            // Sanity checks
            if(sessionRunning)
            {
                MessageBox.Show("A session is already running");
                return;
            }

            FolderBrowserDialog dialog = new FolderBrowserDialog();
            dialog.SelectedPath = settings.SessionRootDirectory;            
            dialog.Description = "Select session directory";
            dialog.ShowNewFolderButton = false;
            if(dialog.ShowDialog() == DialogResult.OK)
            {
                ClearSession();

                string sessionFile = dialog.SelectedPath + Path.DirectorySeparatorChar + "session.json";
                if (!File.Exists(sessionFile))
                {
                    Utils.Log.Add("ERROR: Can not load session. Directory " + dialog.SelectedPath + " has no session.json file");
                    return;
                }                    

                // Deserialize session object
                session = JsonConvert.DeserializeObject<Session>(File.ReadAllText(sessionFile));

                // Load GEFactor script
                if(!session.LoadGEFactor())                
                    Utils.Log.Add("WARNING: Loading GEFactor failed for session " + session.Name);

                // Load session spectrums
                if (!session.LoadSpectrums(dialog.SelectedPath))
                {
                    Utils.Log.Add("ERROR: Loading spectrums failed for session " + session.Name);
                    return;
                }
                
                // Update UI
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
            // Sanity checks
            if (!session.IsLoaded)
            {
                MessageBox.Show("Session is not loaded");
                return;
            }

            FolderBrowserDialog dialog = new FolderBrowserDialog();
            dialog.SelectedPath = settings.SessionRootDirectory;
            dialog.Description = "Select background session directory";
            dialog.ShowNewFolderButton = false;
            if (dialog.ShowDialog() == DialogResult.OK)
            {
                ClearBackground();
                Session bkgSess = new Session();

                string bkgSessionFile = dialog.SelectedPath + Path.DirectorySeparatorChar + "session.json";
                if (!File.Exists(bkgSessionFile))
                {
                    Utils.Log.Add("ERROR: Can not load background session. Directory " + dialog.SelectedPath + " has no session.json file");
                    return;
                }

                // Deserialize session object
                bkgSess = JsonConvert.DeserializeObject<Session>(File.ReadAllText(bkgSessionFile));
                if (!bkgSess.LoadGEFactor())
                    Utils.Log.Add("WARNING: Loading GEFactor failed for background session " + bkgSess.Name);

                // Load background spectrums
                if (!bkgSess.LoadSpectrums(dialog.SelectedPath))
                {
                    Utils.Log.Add("ERROR: Loading spectrums failed for background session " + bkgSess.Name);
                    return;
                }                

                // Make sure session and backgrouns has the same number of channels
                if (bkgSess.NumChannels != session.NumChannels)
                {
                    bkgSess.Clear();
                    MessageBox.Show("Cannot load a background with different number of channels than the session");
                    return;
                }

                // Store background in session
                session.SetBackground(bkgSess);

                lblBackground.Text = "Background: " + bkgSess.Name;
                Utils.Log.Add("Background " + bkgSess.Name + " loaded for session " + session.Name);
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

            if(cboxSetupDetector.SelectedItem == null)
            {
                lblSetupEnergy.Text = "";
                return;
            }

            // Show energy
            Detector det = (Detector)cboxSetupDetector.SelectedItem;            
            lblSetupEnergy.Text = "En: " + String.Format("{0:#######0.0###}", det.GetEnergy(x));                        
        }

        private void graphSession_MouseMove(object sender, MouseEventArgs e)
        {            
            int x, y;
            GetGraphPointFromMousePos(e.X, e.Y, graphSession, out x, out y);

            lblSessionChannel.Text = "Ch: " + String.Format("{0:####0}", x);

            // Show energy
            if (session.IsLoaded && session.Detector != null)            
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

        private void cboxSetupDetector_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (cboxSetupDetector.SelectedItem == null)
                return;

            Detector det = (Detector)cboxSetupDetector.SelectedItem;
            DetectorType detType = settings.DetectorTypes.Find(dt => dt.Name == det.TypeName);

            lblDetector.Text = "Detector " + det.Serialnumber;
            separatorDetector.Visible = true;

            cboxSetupChannels.Text = det.CurrentNumChannels.ToString();

            tbarSetupVoltage.Minimum = detType.MinHV;
            tbarSetupVoltage.Maximum = detType.MaxHV;
            tbarSetupVoltage.Value = det.CurrentHV;

            int coarse = Convert.ToInt32(det.CurrentCoarseGain);
            cboxSetupCoarseGain.SelectedIndex = cboxSetupCoarseGain.FindStringExact(coarse.ToString());
            tbarSetupFineGain.Value = (int)((double)det.CurrentFineGain * 1000d);
            tbarSetupLLD.Value = det.CurrentLLD;
            tbarSetupULD.Value = det.CurrentULD;
            cboxSetupChannels.Items.Clear();
            for (int i = 256; i <= detType.MaxNumChannels; i = i * 2)
                cboxSetupChannels.Items.Add(i.ToString());
            cboxSetupChannels.Text = det.CurrentNumChannels.ToString();

            tbSetupLivetime.Text = det.CurrentLivetime.ToString();            

            formWaterfallLive.SetDetector(det);
        }

        private void menuItemSessionInfo_Click(object sender, EventArgs e)
        {
            if(session == null || !session.IsLoaded)
            {
                MessageBox.Show("Can not open session info. No session loaded");
                return;
            }

            FormSessionInfo form = new FormSessionInfo(session, "Session Info");
            if(form.ShowDialog() == DialogResult.OK)
            {
                SaveSession(session);
                lblComment.Text = session.Comment;
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

        private void btnMenuPreferences_Click(object sender, EventArgs e)
        {
            tabs.SelectedTab = pagePreferences;
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
                tbSessionDir.Text = dialog.SelectedPath;
                settings.SessionRootDirectory = tbSessionDir.Text;
            }
        }

        private void menuItemStartNewSession_Click(object sender, EventArgs e)
        {
            if (!connected)
            {
                MessageBox.Show("You must connect first");
                return;
            }

            if (sessionRunning)
            {
                MessageBox.Show("A session is already running");
                return;
            }

            if (String.IsNullOrEmpty(settings.SessionRootDirectory))
            {
                MessageBox.Show("You must provide a session directory under preferences");
                return;
            }

            tabs.SelectedTab = pageSetup;
        }

        private void menuItemStopSession_Click(object sender, EventArgs e)
        {
            if (!sessionRunning)
            {
                MessageBox.Show("No session is running");
                return;
            }

            sendMsg(new burn.Message("stop_session", null));

            Utils.Log.Add("SEND: stop_session");
        }

        private void menuItemShutdownRemoteServer_Click(object sender, EventArgs e)
        {
            if (!connected)
            {
                MessageBox.Show("You must be connected before shutting down remote");
                return;
            }

            if (MessageBox.Show("Are you sure you want to close the remote server?", "Confirmation", MessageBoxButtons.YesNo) == DialogResult.No)
                return;

            sendMsg(new burn.Message("close", null));

            Utils.Log.Add("SEND: close");
        }

        private void btnSetupBack_Click(object sender, EventArgs e)
        {
            tabs.SelectedTab = pageSessions;
        }

        private void btnSetupNext_Click(object sender, EventArgs e)
        {
            SaveSettings();

            Detector det = (Detector)cboxSetupDetector.SelectedItem;
            
            if(!String.IsNullOrEmpty(tbSetupLivetime.Text.Trim()))
                det.CurrentLivetime = Convert.ToInt32(tbSetupLivetime.Text.Trim());            
            
            int iterations = String.IsNullOrEmpty(tbSetupSpectrumCount.Text.Trim()) ? -1 : Convert.ToInt32(tbSetupSpectrumCount.Text.Trim());

            float delay = 0f;
            if (!String.IsNullOrEmpty(tbSetupDelay.Text.Trim()))
                delay = Convert.ToSingle(tbSetupDelay.Text.Trim());

            ClearSession();

            burn.Message msg = new burn.Message("new_session", null);
            msg.AddParameter("session_name", String.Format("{0:ddMMyyyy_HHmmss}", DateTime.Now));
            msg.AddParameter("preview", 0);
            msg.AddParameter("iterations", iterations);
            msg.AddParameter("livetime", det.CurrentLivetime);
            msg.AddParameter("delay", delay);
            sendMsg(msg);

            Utils.Log.Add("SEND: new_session");
            tabs.SelectedTab = pageSessions;
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

            //LineObj line = new LineObj(Color.ForestGreen, (double)x, pane.YAxis.Scale.Min, (double)x, pane.YAxis.Scale.Max);
            //pane.GraphObjList.Add(line);

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
            if (sessionRunning)
            {
                MessageBox.Show("A session is already running");
                return;
            }                                    

            burn.Message msg = new burn.Message("new_session", null);
            msg.AddParameter("session_name", String.Format("{0:ddMMyyyy_HHmmss}", DateTime.Now));
            msg.AddParameter("preview", 1);
            msg.AddParameter("iterations", -1);
            msg.AddParameter("livetime", 1);
            msg.AddParameter("delay", 0);
            sendMsg(msg);

            ClearSetup();
            previewSpec = null;
            Utils.Log.Add("SEND: new_session (preview)");            
        }

        private void btnSetupStopTest_Click(object sender, EventArgs e)
        {
            sendMsg(new burn.Message("stop_session", null));
            Utils.Log.Add("SEND: stop_session for preview");
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
            // Show current energy curve
            Detector det = (Detector)cboxSetupDetector.SelectedItem;
            FormEnergyCurve form = new FormEnergyCurve(det, coefficients);
            if (form.ShowDialog() != DialogResult.OK)
                return;

            // Update selected detector with current energy curve coefficients
            det.EnergyCurveCoefficients.Clear();
            det.EnergyCurveCoefficients.AddRange(coefficients);            
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
        }

        private void menuItemLayoutSession2_Click(object sender, EventArgs e)
        {
            // Predefined layout: Organize windows
            int screenWidth = Screen.PrimaryScreen.Bounds.Width;
            int screenHeight = Screen.PrimaryScreen.Bounds.Height;
                        
            formWaterfallLive.Hide();
            formROILive.Hide();
            Utils.Log.Hide();

            WindowState = FormWindowState.Normal;
            Left = 0;
            Top = 0;
            Width = screenWidth / 2;
            Height = screenHeight;

            frmMap.Show();
            frmMap.WindowState = FormWindowState.Normal;
            frmMap.Left = screenWidth / 2;
            frmMap.Top = 0;
            frmMap.Width = screenWidth / 2;
            frmMap.Height = screenHeight;
        }

        private void menuItemLayoutSession3_Click(object sender, EventArgs e)
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
                    LineObj line = new LineObj(Color.Orange, (double)ch, pane.YAxis.Scale.Min, (double)ch, pane.YAxis.Scale.Max);
                    makeGraphObjectType(ref line.Tag, GraphObjectType.Energy);
                    pane.GraphObjList.Add(line);
                               
                    // Add probability text
                    TextObj label = new TextObj(ne.Probability.ToString(), (double)ch,  pane.YAxis.Scale.Max, CoordType.AxisXY2Scale, AlignH.Left, AlignV.Top);
                    makeGraphObjectType(ref label.Tag, GraphObjectType.Energy);                    
                    label.FontSpec.Border.IsVisible = false;
                    label.FontSpec.Size = 6f;
                    label.FontSpec.Fill.Color = SystemColors.ButtonFace;
                    label.ZOrder = ZOrder.D_BehindAxis;
                    pane.GraphObjList.Add(label);
                }                
            }

            // Update graph
            graphSession.RestoreScale(pane);
            graphSession.AxisChange();
            graphSession.Refresh();
        }

        private void menuItemSaveAsCSV_Click(object sender, EventArgs e)
        {
            if (!session.IsLoaded)
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
    }
}
