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
using System.ComponentModel;
using System.Drawing;
using System.Text;
using System.Xml;
using System.Xml.Serialization;
using System.Threading;
using System.Globalization;
using System.Windows.Forms;
using log4net;
using log4net.Core;
using log4net.Appender;
using log4net.Layout;
using log4net.Repository.Hierarchy;

namespace crash
{
    public enum UILayout { Menu, Session1, Session2, Setup };

    public partial class FormContainer : Form
    {
        private ILog log = null;

        UILayout currentLayout = UILayout.Menu;
        FormWindowState lastWindowState = FormWindowState.Maximized;

        // Structure with application settings stored on disk
        private GASettings settings = new GASettings();

        public string installDir;

        // External forms
        private FormMain formMain = null;
        private FormLog formLog = null;
        private FormWaterfall formWaterfall = null;
        private FormROI formROI = null;
        private FormMap formMap = null;

        public FormContainer()
        {
            InitializeComponent();

            Thread.CurrentThread.CurrentCulture = CultureInfo.InvariantCulture;
            Thread.CurrentThread.CurrentUICulture = CultureInfo.InvariantCulture;
        }

        private void FormContainer_Load(object sender, EventArgs e)
        {
            try
            {
                formLog = new FormLog(this);
                formLog.Left = -1000;
                IntPtr iptr = formLog.Handle; // Force window handle creation
                log = GetLog(formLog.GetTextBox());

                // Create directories and files
                if (!Directory.Exists(GAEnvironment.SettingsPath))
                    Directory.CreateDirectory(GAEnvironment.SettingsPath);

                if (!Directory.Exists(GAEnvironment.GEScriptPath))
                    Directory.CreateDirectory(GAEnvironment.GEScriptPath);

                installDir = Path.GetDirectoryName(Environment.GetCommandLineArgs()[0]) + Path.DirectorySeparatorChar;

                if (!File.Exists(GAEnvironment.NuclideLibraryFile))
                    File.Copy(installDir + "template_nuclides.lib", GAEnvironment.NuclideLibraryFile);

                if (!File.Exists(GAEnvironment.GEScriptPath + Path.DirectorySeparatorChar + "osprey-nai2.lua"))
                    File.Copy(installDir + "template_osprey-nai2.lua", GAEnvironment.GEScriptPath + Path.DirectorySeparatorChar + "osprey-nai2.lua");

                if (!File.Exists(GAEnvironment.GEScriptPath + Path.DirectorySeparatorChar + "osprey-nai3.lua"))
                    File.Copy(installDir + "template_osprey-nai3.lua", GAEnvironment.GEScriptPath + Path.DirectorySeparatorChar + "osprey-nai3.lua");

                LoadSettings();

                formWaterfall = new FormWaterfall(this, settings, log);
                formWaterfall.Left = -1000;
                formROI = new FormROI(this, settings, log);
                formROI.Left = -1000;
                formMap = new FormMap(this, settings, log);
                formMap.Left = -1000;
                formMain = new FormMain(this, settings, log);
                formMain.Left = -1000;
                
                menuItemLayoutMenu_Click(sender, e);

                statusLabel.Text = "";
            }
            catch (Exception ex)
            {
                log.Fatal(ex.Message, ex);
                MessageBox.Show("Unable to load application. See log for details", "Error");

                if (formMain != null)
                {
                    formMain.Shutdown();
                    formMain.Close();
                }

                if (formMap != null)
                    formMap.Close();

                if (formROI != null)                
                    formROI.Close();

                if (formWaterfall != null)
                {
                    formWaterfall.Shutdown();
                    formWaterfall.Close();
                }

                if (formLog != null)
                    formLog.Close();

                Environment.Exit(1);
            }
        }

        private ILog GetLog(RichTextBox tb)
        {
            if (log != null)
                throw new Exception("Log already initialized");
                
            Hierarchy hierarchy = (Hierarchy)LogManager.GetRepository();

            PatternLayout patternLayout = new PatternLayout();
            patternLayout.ConversionPattern = "%date [%thread] - %message%newline";
            patternLayout.ActivateOptions();

            RollingFileAppender roller = new RollingFileAppender();
            roller.AppendToFile = false;
            roller.File = GAEnvironment.SettingsPath + Path.DirectorySeparatorChar + "gamma-analyzer.log";
            roller.Layout = patternLayout;
            roller.MaxSizeRollBackups = 3;
            roller.MaximumFileSize = "10MB";
            roller.RollingStyle = RollingFileAppender.RollingMode.Size;
            roller.StaticLogFileName = true;
            roller.ActivateOptions();
            hierarchy.Root.AddAppender(roller);

            TextBoxAppender textBoxAppender = new TextBoxAppender(tb);
            textBoxAppender.Threshold = Level.All;
            textBoxAppender.Layout = patternLayout;
            textBoxAppender.ActivateOptions();
            hierarchy.Root.AddAppender(textBoxAppender);

            hierarchy.Root.Level = Level.All;
            hierarchy.Configured = true;

            return LogManager.GetLogger(System.Reflection.MethodBase.GetCurrentMethod().DeclaringType);
        }

        public void SaveSettings()
        {
            try
            {
                // Serialize settings to file
                using (StreamWriter sw = new StreamWriter(GAEnvironment.SettingsFile))
                {
                    XmlSerializer x = new XmlSerializer(settings.GetType());
                    x.Serialize(sw, settings);
                }
            }
            catch(Exception ex)
            {
                log.Error(ex.Message, ex);
            }
        }

        public void LoadSettings()
        {
            try
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
            catch (Exception ex)
            {
                log.Error(ex.Message, ex);
            }
        }

        public void AddSpectrum(Spectrum s)
        {
            try
            {
                formMap.AddMarker(s);
                formWaterfall.UpdatePane();
                formROI.UpdatePane();
            }
            catch(Exception ex)
            {
                log.Error(ex.Message, ex);
            }
        }

        public void ClearSession()
        {
            try
            {
                formMain.ClearSession();
                formWaterfall.ClearSession();
                formROI.ClearSession();
                formMap.ClearSession();
            }
            catch (Exception ex)
            {
                log.Error(ex.Message, ex);
            }
        }

        public void SetSelectedSessionIndex(int index)
        {
            try
            {
                formMain.SetSelectedSessionIndex(index);
                formWaterfall.SetSelectedSessionIndex(index);
                formMap.SetSelectedSessionIndex(index);
                formROI.SetSelectedSessionIndex(index);
            }
            catch (Exception ex)
            {
                log.Error(ex.Message, ex);
            }
        }

        public void SetSelectedSessionIndices(int index1, int index2)
        {
            if(index1 > index2)            
                Utils.Swap(ref index1, ref index2);

            try
            {
                formMain.SetSelectedSessionIndices(index1, index2);
                formWaterfall.SetSelectedSessionIndices(index1, index2);
                formMap.SetSelectedSessionIndices(index1, index2);
                formROI.SetSelectedSessionIndices(index1, index2);
            }
            catch (Exception ex)
            {
                log.Error(ex.Message, ex);
            }
        }

        public void SetSession(Session s)
        {
            try
            {
                formMain.SetSession(s);
                formWaterfall.SetSession(s);
                formWaterfall.SetDetector(s.Detector);
                formROI.SetSession(s);
                formMap.SetSession(s);

                formWaterfall.UpdatePane();
                formROI.UpdatePane();
            }
            catch (Exception ex)
            {
                log.Error(ex.Message, ex);
            }
        }

        private void menuItemFileExit_Click(object sender, EventArgs e)
        {
            Close();
        }

        private void menuItemViewToolbar_Click(object sender, EventArgs e)
        {
            tools.Visible = menuItemViewToolbar.Checked;
        }

        private void menuItemViewStatus_Click(object sender, EventArgs e)
        {
            status.Visible = menuItemViewStatus.Checked;
        }

        private void menuItemHelpAbout_Click(object sender, EventArgs e)
        {
            About about = new About();
            about.ShowDialog();
        }

        private void menuItemLayoutCascade_Click(object sender, EventArgs e)
        {
            LayoutMdi(MdiLayout.Cascade);
        }

        private void menuItemLayoutTileVertical_Click(object sender, EventArgs e)
        {
            LayoutMdi(MdiLayout.TileVertical);
        }

        private void menuItemLayoutTileHorizontal_Click(object sender, EventArgs e)
        {
            LayoutMdi(MdiLayout.TileHorizontal);
        }

        private void menuItemLayoutArrangeIcons_Click(object sender, EventArgs e)
        {
            LayoutMdi(MdiLayout.ArrangeIcons);
        }

        private void menuItemLayoutMenu_Click(object sender, EventArgs e)
        {
            SetUILayout(UILayout.Menu);
        }

        private void menuItemLayoutSetup_Click(object sender, EventArgs e)
        {
            SetUILayout(UILayout.Setup);
        }

        private void menuItemLayoutSession_Click(object sender, EventArgs e)
        {
            SetUILayout(UILayout.Session1);
        }

        private void menuItemWindowROITable_Click(object sender, EventArgs e)
        {
            FormROITable form = new FormROITable(settings, log);
            form.ShowDialog();
        }

        private void ShowAllWindows()
        {
            formLog.Show();
            formLog.WindowState = FormWindowState.Normal;
            formROI.Show();
            formROI.WindowState = FormWindowState.Normal;
            formROI.UpdatePane();
            formMap.Show();
            formMap.WindowState = FormWindowState.Normal;
            formWaterfall.Show();
            formWaterfall.WindowState = FormWindowState.Normal;
            formWaterfall.UpdatePane();
            formMain.Show();
            formMain.WindowState = FormWindowState.Normal;
        }

        private void menuItemWindowShowAll_Click(object sender, EventArgs e)
        {
            ShowAllWindows();
        }        

        private void FormContainer_FormClosing(object sender, FormClosingEventArgs e)
        {
            try
            {
                SaveSettings();

                formMain.Shutdown();
                formMain.Close();
                formWaterfall.Shutdown();
                formWaterfall.Close();
                formROI.Close();
                formMap.Close();
                formLog.Close();
            }
            catch (Exception ex)
            {
                log.Error(ex.Message, ex);
            }
        }        

        public void SetUILayout(UILayout layout)
        {
            int height, thirdHeight;

            switch (layout)
            {
                case UILayout.Menu:
                    formWaterfall.Hide();
                    formROI.Hide();
                    formMap.Hide();
                    formLog.Hide();
                    formMain.Show();
                    formMain.WindowState = FormWindowState.Normal;

                    height = ClientSize.Height - menu.Height - 4;
                    if (tools.Visible)
                        height -= tools.Height;
                    if (status.Visible)
                        height -= status.Height;

                    formMain.Left = ClientRectangle.Left;
                    formMain.Width = ClientSize.Width - 4;
                    formMain.Top = ClientRectangle.Top;
                    formMain.Height = height;

                    currentLayout = UILayout.Menu;
                    break;

                case UILayout.Setup:
                    formWaterfall.Hide();
                    formROI.Hide();
                    formMap.Hide();
                    formMain.Show();
                    formMain.WindowState = FormWindowState.Normal;
                    formLog.Show();
                    formLog.WindowState = FormWindowState.Normal;

                    height = ClientSize.Height - menu.Height - 4;
                    if (tools.Visible)
                        height -= tools.Height;
                    if (status.Visible)
                        height -= status.Height;

                    int mainHeight = (int)((double)height * 0.8);
                    int logHeight = (int)((double)height * 0.2);

                    formMain.Left = ClientRectangle.Left;
                    formMain.Width = ClientSize.Width - 4;
                    formMain.Top = ClientRectangle.Top;
                    formMain.Height = mainHeight;

                    formLog.Left = ClientRectangle.Left;
                    formLog.Width = ClientSize.Width - 4;
                    formLog.Top = mainHeight;
                    formLog.Height = logHeight;

                    currentLayout = UILayout.Setup;
                    break;

                case UILayout.Session1:
                    ShowAllWindows();

                    int thirdWidth = (ClientSize.Width - 4) / 3;
                    height = ClientSize.Height - menu.Height - 4;
                    if (tools.Visible)
                        height -= tools.Height;
                    if (status.Visible)
                        height -= status.Height;
                    thirdHeight = height / 3;

                    formMain.Left = ClientRectangle.Left;
                    formMain.Width = ClientRectangle.Left + thirdWidth * 2;
                    formMain.Top = ClientRectangle.Top;
                    formMain.Height = ClientRectangle.Top + thirdHeight * 2;

                    formWaterfall.Left = ClientRectangle.Left;
                    formWaterfall.Width = ClientRectangle.Left + thirdWidth * 2;
                    formWaterfall.Top = ClientRectangle.Top + thirdHeight * 2;
                    formWaterfall.Height = thirdHeight;

                    formMap.Left = formMain.Left + formMain.Width;
                    formMap.Width = thirdWidth;
                    formMap.Top = ClientRectangle.Top;
                    formMap.Height = thirdHeight + thirdHeight / 2;

                    formROI.Left = formMain.Left + formMain.Width;
                    formROI.Width = thirdWidth;
                    formROI.Top = formMap.Top + formMap.Height;
                    formROI.Height = thirdHeight;

                    formLog.Left = formMain.Left + formMain.Width;
                    formLog.Width = thirdWidth;
                    formLog.Top = formROI.Top + formROI.Height;
                    formLog.Height = thirdHeight - thirdHeight / 2;

                    currentLayout = UILayout.Session1;
                    break;

                case UILayout.Session2:
                    formWaterfall.Show();
                    formROI.Hide();
                    formMap.Show();
                    formMain.Show();
                    formLog.Hide();                    

                    int halfWidth = (ClientSize.Width - 4) / 2;
                    height = ClientSize.Height - menu.Height - 4;
                    if (tools.Visible)
                        height -= tools.Height;
                    if (status.Visible)
                        height -= status.Height;
                    thirdHeight = height / 3;

                    formMain.Left = ClientRectangle.Left;
                    formMain.Width = ClientRectangle.Left + halfWidth * 2;
                    formMain.Top = ClientRectangle.Top;
                    formMain.Height = ClientRectangle.Top + thirdHeight * 2;

                    formWaterfall.Left = ClientRectangle.Left;
                    formWaterfall.Width = ClientRectangle.Left + halfWidth;
                    formWaterfall.Top = ClientRectangle.Top + thirdHeight * 2;
                    formWaterfall.Height = thirdHeight;

                    formMap.Left = formMain.Left + formWaterfall.Width;
                    formMap.Width = halfWidth;
                    formMap.Top = ClientRectangle.Top + thirdHeight * 2;
                    formMap.Height = thirdHeight;

                    currentLayout = UILayout.Session2;
                    break;
            }
        }

        private void UpdateUILayout()
        {
            SetUILayout(currentLayout);
        }

        private void FormContainer_ResizeEnd(object sender, EventArgs e)
        {
            UpdateUILayout();
        }

        private void FormContainer_Resize(object sender, EventArgs e)
        {
            if (WindowState != lastWindowState)
            {
                lastWindowState = WindowState;
                if (WindowState == FormWindowState.Maximized || WindowState == FormWindowState.Normal)        
                    UpdateUILayout();
            }
        }

        private void menuItemLayoutSession2_Click(object sender, EventArgs e)
        {
            SetUILayout(UILayout.Session2);
        }
    }

    public class TextBoxAppender : AppenderSkeleton
    {
        private RichTextBox mTextBox;

        public TextBoxAppender(RichTextBox tb)
        {
            mTextBox = tb;
        }

        protected override void Append(LoggingEvent loggingEvent)
        {
            mTextBox.BeginInvoke((MethodInvoker)delegate
            {
                mTextBox.Text = RenderLoggingEvent(loggingEvent) + mTextBox.Text;
            });
        }
    }
}
