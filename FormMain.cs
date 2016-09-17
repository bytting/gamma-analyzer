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
                tabs.ItemSize = new Size(0, 1);
                tabs.SizeMode = TabSizeMode.Fixed;
                tabs.SelectedTab = pageMenu;

                if (!Directory.Exists(CrashEnvironment.SettingsPath))
                    Directory.CreateDirectory(CrashEnvironment.SettingsPath);

                if (!Directory.Exists(CrashEnvironment.GEScriptPath))
                    Directory.CreateDirectory(CrashEnvironment.GEScriptPath);                

                //string InstallDir = (new FileInfo(System.Reflection.Assembly.GetEntryAssembly().Location)).Directory + Path.DirectorySeparatorChar.ToString();
                string InstallDir = Path.GetDirectoryName(Environment.GetCommandLineArgs()[0]) + Path.DirectorySeparatorChar;                

                if (!File.Exists(CrashEnvironment.SettingsFile))
                    File.Copy(InstallDir + "template_settings.xml", CrashEnvironment.SettingsFile, false);

                if (!File.Exists(CrashEnvironment.NuclideLibraryFile))
                    File.Copy(InstallDir + "template_nuclides.lib", CrashEnvironment.NuclideLibraryFile, false);

                if (!File.Exists(CrashEnvironment.GEScriptPath + Path.DirectorySeparatorChar + "Nai-2tom.py"))
                    File.Copy(InstallDir + "template_Nai-2tom.py", CrashEnvironment.GEScriptPath + Path.DirectorySeparatorChar + "Nai-2tom.py", true);

                if (!File.Exists(CrashEnvironment.GEScriptPath + Path.DirectorySeparatorChar + "Nai-3tom.py"))
                    File.Copy(InstallDir + "template_Nai-3tom.py", CrashEnvironment.GEScriptPath + Path.DirectorySeparatorChar + "Nai-3tom.py", true);

                LoadSettings();
                LoadNuclideLibrary();

                formWaterfallLive = new FormWaterfallLive(settings.ROIList);
                formWaterfallLive.SetSessionIndexEvent += SetSessionIndexEvent;
                formROILive = new FormROILive(settings.ROIList);
                formROILive.SetSessionIndexEvent += SetSessionIndexEvent;
                frmMap = new FormMap();
                frmMap.SetSessionIndexEvent += SetSessionIndexEvent;

                tbSetupLivetime.KeyPress += CustomEvents.Integer_KeyPress;
                tbSetupSpectrumCount.KeyPress += CustomEvents.Integer_KeyPress;
                tbSetupDelay.KeyPress += CustomEvents.Integer_KeyPress;

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

                netThread.Start();
                while (!netThread.IsAlive) ;

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

        private void menuItemExit_Click(object sender, EventArgs e)
        {
            menuItemDisconnect_Click(sender, e);            
            Close();
        }

        private void menuItemConnect_Click(object sender, EventArgs e)
        {
            FormConnect form = new FormConnect(settings);
            if (form.ShowDialog() != System.Windows.Forms.DialogResult.OK)
                return;

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
            
            sendMsg(new burn.Message("disconnect", null));
            Utils.Log.Add("Disconnecting from " + settings.LastIP + ":" + settings.LastPort);
            Thread.Sleep(2000); // FIXME
        }        

        private void btnStopNetService_Click(object sender, EventArgs e)
        {
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
            /*if(!connected)
            {
                MessageBox.Show("Can not set parameters. Not connected");
                return;
            }*/                        

            if(String.IsNullOrEmpty(cboxSetupDetector.Text.Trim()))
            {
                MessageBox.Show("No detector selected");
                return;
            }

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

            int nchannels = Convert.ToInt32(cboxSetupChannels.Text);            
            int lld = tbarSetupLLD.Value;
            int uld = tbarSetupULD.Value;
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
            sendMsg(msg);

            Utils.Log.Add("SEND: set_gain");
        }        
        
        private void tabs_SelectedIndexChanged(object sender, EventArgs e)
        {
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
            }            
        }                

        private void lbSession_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (lbSession.SelectedItems.Count < 1)
            {
                formWaterfallLive.SetSelectedSessionIndex(-1);
                frmMap.SetSelectedSessionIndex(-1);
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
                lblSessionDetector.Text = "Det." + session.Detector.Serialnumber + " (" + session.Detector.TypeName + ")";
                lblIndex.Text = "Index: " + s.SessionIndex;
                lblLatitudeStart.Text = "Lat. start: " + s.LatitudeStart;
                lblLongitudeStart.Text = "Lon. start: " + s.LongitudeStart;
                lblAltitudeStart.Text = "Alt. start: " + s.AltitudeStart;
                lblLatitudeEnd.Text = "Lat. end: " + s.LatitudeEnd;
                lblLongitudeEnd.Text = "Lon. end: " + s.LongitudeEnd;
                lblAltitudeEnd.Text = "Alt. end: " + s.AltitudeEnd;
                lblGpsTimeStart.Text = "Time start: " + s.GpsTimeStart;
                lblGpsTimeEnd.Text = "Time end: " + s.GpsTimeEnd;
                lblMaxCount.Text = "Max count: " + s.MaxCount;
                lblMinCount.Text = "Min count: " + s.MinCount;
                lblTotalCount.Text = "Total count: " + s.TotalCount;                
                if(s.Doserate == 0.0)
                    lblDoserate.Text = "";
                else lblDoserate.Text = "Doserate: " + String.Format("{0:###0.0##}", s.Doserate);

                if (formWaterfallLive.Visible)
                    formWaterfallLive.SetSelectedSessionIndex(s.SessionIndex);
                if (frmMap.Visible)
                    frmMap.SetSelectedSessionIndex(s.SessionIndex);
                if (formROILive.Visible)
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
                lblGpsTimeStart.Text = "Time start: " + s1.GpsTimeStart;
                lblGpsTimeEnd.Text = "Time end: " + s2.GpsTimeEnd;
                lblMaxCount.Text = "Max count: " + maxCnt;
                lblMinCount.Text = "Min count: " + minCnt;
                lblTotalCount.Text = "Total count: " + totCnt;
                lblDoserate.Text = "";

                if (formWaterfallLive.Visible)
                    formWaterfallLive.SetSelectedSessionIndices(s1.SessionIndex, s2.SessionIndex);
                if (frmMap.Visible)
                    frmMap.SetSelectedSessionIndices(s1.SessionIndex, s2.SessionIndex);
                if (formROILive.Visible)
                    formROILive.SetSelectedSessionIndices(s1.SessionIndex, s2.SessionIndex);
            }

            GraphPane pane = graphSession.GraphPane;            
            pane.GraphObjList.Clear();
            graphSession.RestoreScale(pane);
            graphSession.AxisChange();
            graphSession.Refresh();            
            lbNuclides.Items.Clear();
        }

        private void menuItemAbout_Click(object sender, EventArgs e)
        {
            About about = new About();
            about.ShowDialog();            
        }        

        private void menuItemLoadSession_Click(object sender, EventArgs e)
        {
            if(sessionRunning)
            {
                MessageBox.Show("A session is already running");
                return;
            }

            FolderBrowserDialog dialog = new FolderBrowserDialog();
            dialog.SelectedPath = settings.SessionRootDirectory;            
            dialog.Description = "Select session directory";
            dialog.ShowNewFolderButton = false;
            if(dialog.ShowDialog() == System.Windows.Forms.DialogResult.OK)
            {
                ClearSession();

                string sessionFile = dialog.SelectedPath + Path.DirectorySeparatorChar + "session.json";
                if (!File.Exists(sessionFile))
                {
                    Utils.Log.Add("ERROR: Can not load session. Directory " + dialog.SelectedPath + " has no session.json file");
                    return;
                }                    

                session = JsonConvert.DeserializeObject<Session>(File.ReadAllText(sessionFile));
                if(!session.LoadGEFactor())                
                    Utils.Log.Add("WARNING: Loading GEFactor failed for session " + session.Name);

                if (!session.LoadSpectrums(dialog.SelectedPath))
                {
                    Utils.Log.Add("ERROR: Loading spectrums failed for session " + session.Name);
                    return;
                }
                
                lblComment.Text = session.Comment;

                formWaterfallLive.SetSession(session);
                formWaterfallLive.SetDetector(session.Detector);
                formROILive.SetSession(session);
                frmMap.SetSession(session);

                foreach(Spectrum s in session.Spectrums)
                {
                    lbSession.Items.Insert(0, s);
                    frmMap.AddMarker(s);
                }

                formWaterfallLive.UpdatePane();
                formROILive.UpdatePane();

                lblSession.Text = "Session: " + session.Name;
                Utils.Log.Add("session " + session.Name + " loaded");
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

                string bkgSessionFile = dialog.SelectedPath + Path.DirectorySeparatorChar + "session.json";
                if (!File.Exists(bkgSessionFile))
                {
                    Utils.Log.Add("ERROR: Can not load background session. Directory " + dialog.SelectedPath + " has no session.json file");
                    return;
                }

                bkgSess = JsonConvert.DeserializeObject<Session>(File.ReadAllText(bkgSessionFile));
                if (!bkgSess.LoadGEFactor())
                    Utils.Log.Add("WARNING: Loading GEFactor failed for background session " + bkgSess.Name);

                if (!bkgSess.LoadSpectrums(dialog.SelectedPath))
                {
                    Utils.Log.Add("ERROR: Loading spectrums failed for background session " + bkgSess.Name);
                    return;
                }                

                if (bkgSess.NumChannels != session.NumChannels)
                {
                    bkgSess.Clear();
                    MessageBox.Show("Cannot load a background with different number of channels than the session");
                    return;
                }

                session.SetBackground(bkgSess);

                lblBackground.Text = "Background: " + bkgSess.Name;
                Utils.Log.Add("Background " + bkgSess.Name + " loaded for session " + session.Name);
            }
        }

        private void menuItemROITable_Click(object sender, EventArgs e)
        {
            FormROITable form = new FormROITable(settings.ROIList);
            form.ShowDialog();
        }

        private void graphSetup_MouseMove(object sender, MouseEventArgs e)
        {
            int x, y;
            GetGraphPointFromMousePos(e.X, e.Y, graphSetup, out x, out y);            

            lblSetupChannel.Text = "Ch: " + String.Format("{0:####0}", x);

            // Show energy
            if (session.Detector != null)            
                lblSetupEnergy.Text = "En: " + String.Format("{0:#######0.0###}", session.Detector.GetEnergy(x));            
            else lblSetupEnergy.Text = "";
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
            lbSession.ClearSelected();
        }        

        private void cboxSetupDetector_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (cboxSetupDetector.SelectedItem == null)
                return;

            Detector selectedDetector = (Detector)cboxSetupDetector.SelectedItem;
            DetectorType selectedDetectorType = settings.DetectorTypes.Find(dt => dt.Name == selectedDetector.TypeName);            

            lblDetector.Text = "Detector " + selectedDetector.Serialnumber;
            separatorDetector.Visible = true;

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

            tbSetupLivetime.Text = selectedDetector.CurrentLivetime.ToString();

            formWaterfallLive.SetDetector(selectedDetector);
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
            FormAddDetectorType form = new FormAddDetectorType();
            if (form.ShowDialog() == System.Windows.Forms.DialogResult.OK)
            {
                settings.DetectorTypes.Add(new DetectorType(form.TypeName, form.MaxChannels, form.MinHV, form.MaxHV, form.GEScript));
                PopulateDetectorTypeList();
            }
        }

        private void btnAddDetector_Click(object sender, EventArgs e)
        {
            FormAddDetector form = new FormAddDetector(settings.DetectorTypes);
            if (form.ShowDialog() == System.Windows.Forms.DialogResult.OK)
            {
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
            // TODO            
            int x, y;
            GetGraphPointFromMousePos(e.X, e.Y, graphSession, out x, out y);

            GraphPane pane = graphSession.GraphPane;
            pane.GraphObjList.Clear();

            LineObj greenLine = new LineObj(Color.Green, (double)x, pane.YAxis.Scale.Min, (double)x, pane.YAxis.Scale.Max);
            pane.GraphObjList.Add(greenLine);

            graphSession.RestoreScale(pane);
            graphSession.AxisChange();
            graphSession.Refresh();

            // List nuclides
            lbNuclides.Items.Clear();
            foreach(NuclideInfo ni in NuclideLibrary)
            {
                lbNuclides.Items.Add(ni);
            }
        }

        private void graphSetup_MouseDoubleClick(object sender, MouseEventArgs e)
        {
            int x, y;
            GetGraphPointFromMousePos(e.X, e.Y, graphSetup, out x, out y);

            FormAskDecimal form = new FormAskDecimal("Enter expected energy for channel " + x);
            if(form.ShowDialog() == System.Windows.Forms.DialogResult.Cancel)
                return;
            
            energyLines.Add(new EnergyComp((double)x, form.Value));

            if (energyLines.Count > 1)
            {                
                List<double> xList = new List<double>();
                List<double> yList = new List<double>();
                foreach (EnergyComp ec in energyLines)
                {
                    xList.Add((double)ec.Channel);
                    yList.Add((double)ec.Energy);
                }

                coefficients.Clear();
                coefficients.AddRange(Fit.Polynomial(xList.ToArray(), yList.ToArray(), energyLines.Count - 1));
            }

            GraphPane pane = graphSetup.GraphPane;            
            LineObj orangeLine = new LineObj(Color.Orange, (double)x, pane.YAxis.Scale.Min, (double)x, pane.YAxis.Scale.Max);
            pane.GraphObjList.Add(orangeLine);

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

            double livetime = 1d;
            if (!String.IsNullOrEmpty(tbSetupLivetime.Text.Trim()))
                livetime = Convert.ToDouble(tbSetupLivetime.Text.Trim());

            int iterations = -1;
            if (!String.IsNullOrEmpty(tbSetupSpectrumCount.Text.Trim()))
                iterations = Convert.ToInt32(tbSetupSpectrumCount.Text.Trim());

            int delay = 0;
            if (!String.IsNullOrEmpty(tbSetupDelay.Text.Trim()))
                delay = Convert.ToInt32(tbSetupDelay.Text.Trim());

            burn.Message msg = new burn.Message("new_session", null);
            msg.AddParameter("session_name", String.Format("{0:ddMMyyyy_HHmmss}", DateTime.Now));
            msg.AddParameter("preview", 1);
            msg.AddParameter("iterations", iterations);
            msg.AddParameter("livetime", livetime);
            msg.AddParameter("delay", delay);
            sendMsg(msg);

            graphSetup.GraphPane.CurveList.Clear();
            graphSetup.Refresh();
            previewSpec = null;
            Utils.Log.Add("SEND: new_session (preview)");            
        }

        private void btnSetupStopTest_Click(object sender, EventArgs e)
        {
            sendMsg(new burn.Message("stop_session", null));
            Utils.Log.Add("SEND: stop_session for preview");            
        }

        private void menuItemSaveAsCVS_Click(object sender, EventArgs e)
        {
            if (!session.IsLoaded)
                return;
            
            SaveFileDialog dialog = new SaveFileDialog();            
            if(dialog.ShowDialog() == System.Windows.Forms.DialogResult.OK)
            {
                StreamWriter writer = new StreamWriter(dialog.FileName, false, Encoding.UTF8);
                foreach(Spectrum s in session.Spectrums)
                {
                    writer.WriteLine(
                        s.SessionName + "|" 
                        + s.SessionIndex.ToString() + "|" 
                        + s.GpsTimeStart.ToString("yyyy-MM-ddTHH:mm:ss") + "|" 
                        + s.LatitudeStart.ToString(CultureInfo.InvariantCulture) + "|"
                        + s.LongitudeStart.ToString(CultureInfo.InvariantCulture) + "|"
                        + s.AltitudeStart.ToString(CultureInfo.InvariantCulture) + "|"
                        + s.Doserate.ToString(CultureInfo.InvariantCulture) 
                        + "|mSv/h");
                }
                writer.Close();
            }
        }

        private void menuItemResetCoefficients_Click(object sender, EventArgs e)
        {
            energyLines.Clear();            
            GraphPane pane = graphSetup.GraphPane;
            pane.GraphObjList.Clear();

            graphSetup.RestoreScale(pane);
            graphSetup.AxisChange();
            graphSetup.Refresh();
        }

        private void menuItemStoreCoefficients_Click(object sender, EventArgs e)
        {
            Detector det = (Detector)cboxSetupDetector.SelectedItem;
            FormEnergyCurve form = new FormEnergyCurve(det, coefficients);
            if (form.ShowDialog() != System.Windows.Forms.DialogResult.OK)
                return;

            det.EnergyCurveCoefficients.Clear();
            det.EnergyCurveCoefficients.AddRange(coefficients);            
        }        

        private void menuItemLayoutSetup1_Click(object sender, EventArgs e)
        {
            int screenWidth = Screen.PrimaryScreen.Bounds.Width;
            int screenHeight = Screen.PrimaryScreen.Bounds.Height;

            frmMap.Hide();
            formWaterfallLive.Hide();
            formROILive.Hide();            

            WindowState = FormWindowState.Normal;
            Left = 0;
            Top = 0;
            Width = screenWidth;
            Height = (screenHeight / 3) * 2;

            Utils.Log.Show();
            Utils.Log.WindowState = FormWindowState.Normal;
            Utils.Log.Left = 0;
            Utils.Log.Top = (screenHeight / 3) * 2;
            Utils.Log.Width = screenWidth;
            Utils.Log.Height = screenHeight / 3;            
        }

        private void menuItemLayoutSession1_Click(object sender, EventArgs e)
        {
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

        private void menuItemVersion_Click(object sender, EventArgs e)
        {
            string version = System.Reflection.Assembly.GetExecutingAssembly().GetName().Version.ToString();
            MessageBox.Show(version);
        }

        private void btnEditDetectorType_Click(object sender, EventArgs e)
        {
            if(lvDetectorTypes.SelectedItems.Count == 0)
                return;

            DetectorType detType = (DetectorType)lvDetectorTypes.SelectedItems[0].Tag;
            FormEditDetectorType form = new FormEditDetectorType(detType);
            form.ShowDialog();
        }                
    }
}
