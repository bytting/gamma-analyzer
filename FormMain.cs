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

                if (!Directory.Exists(CrashEnvironment.RegScriptPath))
                    Directory.CreateDirectory(CrashEnvironment.RegScriptPath);

                string InstallDir = (new FileInfo(System.Reflection.Assembly.GetEntryAssembly().Location)).Directory + Path.DirectorySeparatorChar.ToString();

                if (!File.Exists(CrashEnvironment.SettingsFile))
                    File.Copy(InstallDir + "template_settings.xml", CrashEnvironment.SettingsFile, false);

                if (!File.Exists(CrashEnvironment.NuclideLibraryFile))
                    File.Copy(InstallDir + "template_nuclides.lib", CrashEnvironment.NuclideLibraryFile, false);

                // FIXME
                try { File.Copy(InstallDir + "template_Nai-2tom.py", CrashEnvironment.GEScriptPath + Path.DirectorySeparatorChar + "Nai-2tom.py", false); }
                catch { }
                try { File.Copy(InstallDir + "template_Nai-3tom.py", CrashEnvironment.GEScriptPath + Path.DirectorySeparatorChar + "Nai-3tom.py", false); }
                catch { }

                LoadSettings();
                LoadNuclideLibrary();

                formWaterfallLive = new FormWaterfallLive(settings.ROIList);
                formROILive = new FormROILive(settings.ROIList);
                formMap = new FormMap();

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

                formWaterfallLive.SetSessionIndexEvent += SetSessionIndexEvent;
                formMap.SetSessionIndexEvent += SetSessionIndexEvent;
                formROILive.SetSessionIndexEvent += SetSessionIndexEvent;                

                netThread.Start();
                while (!netThread.IsAlive) ;

                timer.Interval = 10;
                timer.Tick += timer_Tick;
                timer.Start();
            }
            catch(Exception ex)
            {
                MessageBox.Show(ex.Message, "Error");
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
                lblSessionDetector.Text = "Det." + selectedDetector.Serialnumber + " (" + selectedDetector.TypeName + ")";
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
                if (formMap.Visible)
                    formMap.SetSelectedSessionIndex(s.SessionIndex);
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
                if (formMap.Visible)
                    formMap.SetSelectedSessionIndices(s1.SessionIndex, s2.SessionIndex);
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
                session.Load(dialog.SelectedPath);                                
                selectedDetector = session.Info.Detector;
                
                lblComment.Text = session.Info.Comment;

                formWaterfallLive.SetSession(session);
                formWaterfallLive.SetDetector(selectedDetector);
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
            int x, y;
            GetGraphPointFromMousePos(e.X, e.Y, graphSetup, out x, out y);            

            lblSetupChannel.Text = "Ch: " + String.Format("{0:####0}", x);

            // Show energy
            if (selectedDetector != null)
            {
                double en = selectedDetector.GetEnergy(x);
                lblSetupEnergy.Text = "En: " + String.Format("{0:#######0.0###}", en);
            }
            else lblSetupEnergy.Text = "";
        }

        private void graphSession_MouseMove(object sender, MouseEventArgs e)
        {            
            int x, y;
            GetGraphPointFromMousePos(e.X, e.Y, graphSession, out x, out y);

            lblSessionChannel.Text = "Ch: " + String.Format("{0:####0}", x);

            // Show energy
            if (session.IsLoaded && selectedDetector != null)
            {
                double en = selectedDetector.GetEnergy(x);            
                if (en == 0.0)
                    lblSessionEnergy.Text = "";
                else lblSessionEnergy.Text = "En: " + String.Format("{0:#######0.0###}", en);
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
            float livetime = (float)selectedDetector.CurrentLivetime;
            if (!String.IsNullOrEmpty(tbSetupLivetime.Text.Trim()))
                livetime = Convert.ToSingle(tbSetupLivetime.Text);
            int count = String.IsNullOrEmpty(tbSetupSpectrumCount.Text.Trim()) ? -1 : Convert.ToInt32(tbSetupSpectrumCount.Text.Trim());
            float delay = 0f;
            if (!String.IsNullOrEmpty(tbSetupDelay.Text.Trim()))
                delay = Convert.ToSingle(tbSetupDelay.Text.Trim());

            ClearSession();

            burn.Message msg = new burn.Message("new_session", null);
            msg.AddParameter("session_name", String.Format("{0:ddMMyyyy_HHmmss}", DateTime.Now));
            msg.AddParameter("preview", 0);
            msg.AddParameter("iterations", count);
            msg.AddParameter("livetime", livetime);
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
            
            energyList.Add(new EnergyComp((double)x, (double)form.Value));

            if(energyList.Count > 1)
            {
                lblSetupCoefficients.Text = "";
                List<double> xList = new List<double>();
                List<double> yList = new List<double>();
                foreach (EnergyComp ec in energyList)
                {
                    xList.Add((double)ec.Channel);
                    yList.Add((double)ec.Energy);
                }
                
                coeffList = new List<double>(Fit.Polynomial(xList.ToArray(), yList.ToArray(), energyList.Count - 1));                
            }

            GraphPane pane = graphSetup.GraphPane;            
            LineObj orangeLine = new LineObj(Color.Orange, (double)x, pane.YAxis.Scale.Min, (double)x, pane.YAxis.Scale.Max);
            pane.GraphObjList.Add(orangeLine);

            graphSetup.RestoreScale(pane);
            graphSetup.AxisChange();
            graphSetup.Refresh();
        }

        private void ShowEnergyCurve()
        {
            if (selectedDetector.EnergyCurveCoefficients.Count < 2)
                return;

            string curveName = "";
            int counter = 0;
            foreach(double coeff in selectedDetector.EnergyCurveCoefficients)
            {
                curveName += coeff.ToString("E") + " * x^" + counter.ToString() + " + ";
                counter++;
            }
            curveName = curveName.Substring(0, curveName.Length - 3);

            GraphPane pane = graphSetup.GraphPane;
            int w = (int)(pane.Rect.Right - pane.Rect.Left);
            double x, y;
            PointPairList list = new PointPairList();
            for (int i = 50; i < 1000; i++)
            {
                y = selectedDetector.GetEnergy(i);
                list.Add((double)i, y);
            }

            LineItem energyCurve = pane.AddCurve(curveName, list, Color.Green, SymbolType.None);

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
                Convert.ToDouble(tbSetupLivetime.Text.Trim());

            int iterations = -1;
            if (!String.IsNullOrEmpty(tbSetupSpectrumCount.Text.Trim()))
                iterations = Convert.ToInt32(tbSetupSpectrumCount.Text.Trim());

            int delay = 0;
            if (!String.IsNullOrEmpty(tbSetupDelay.Text.Trim()))
                delay = Convert.ToInt32(tbSetupDelay.Text);

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

            btnSetupStartTest.Enabled = false;
            btnSetupStopTest.Enabled = true;
        }

        private void btnSetupStopTest_Click(object sender, EventArgs e)
        {
            sendMsg(new burn.Message("stop_session", null));
            Utils.Log.Add("SEND: stop_session for preview");
            btnSetupStartTest.Enabled = true;
            btnSetupStopTest.Enabled = false;
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
            coeffList.Clear();
            GraphPane pane = graphSetup.GraphPane;
            pane.GraphObjList.Clear();
            lblSetupCoefficients.Text = "";
        }

        private void menuItemStoreCoefficients_Click(object sender, EventArgs e)
        {
            selectedDetector.EnergyCurveCoefficients.Clear();
            selectedDetector.EnergyCurveCoefficients.AddRange(coeffList);
            ShowEnergyCurve();
        }

        private void menuItemLayout1_Click(object sender, EventArgs e)
        {
            int screenWidth = Screen.PrimaryScreen.Bounds.Width;
            int screenHeight = Screen.PrimaryScreen.Bounds.Height;

            formMap.Show();
            formWaterfallLive.Show();
            formROILive.Hide();
            Utils.Log.Hide();

            Left = 0;
            Top = 0;
            Width = screenWidth;
            Height = (screenHeight / 3) * 2;

            formWaterfallLive.Left = 0;
            formWaterfallLive.Top = (screenHeight / 3) * 2;
            formWaterfallLive.Width = screenWidth / 2;
            formWaterfallLive.Height = screenHeight / 3;

            formMap.Left = screenWidth / 2;
            formMap.Top = (screenHeight / 3) * 2;
            formMap.Width = screenWidth / 2;
            formMap.Height = screenHeight / 3;
        }

        private void menuItemLayout2_Click(object sender, EventArgs e)
        {
            int screenWidth = Screen.PrimaryScreen.Bounds.Width;
            int screenHeight = Screen.PrimaryScreen.Bounds.Height;

            formMap.Show();
            formWaterfallLive.Hide();
            formROILive.Hide();
            Utils.Log.Show();

            Left = 0;
            Top = 0;
            Width = screenWidth;
            Height = (screenHeight / 3) * 2;

            Utils.Log.Left = 0;
            Utils.Log.Top = (screenHeight / 3) * 2;
            Utils.Log.Width = screenWidth / 2;
            Utils.Log.Height = screenHeight / 3;

            formMap.Left = screenWidth / 2;
            formMap.Top = (screenHeight / 3) * 2;
            formMap.Width = screenWidth / 2;
            formMap.Height = screenHeight / 3;
        }        
    }
}
