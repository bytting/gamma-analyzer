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
// Authors: Dag robole,

using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Drawing;
using System.Text;
using System.Windows.Forms;
using log4net;

namespace crash
{
    public partial class FormWaterfallLive : Form
    {
        private FormContainer parent = null;
        private GASettings settings = null;
        private ILog log = null;

        private Session session = null;
        private Bitmap bmpPane = null;
        private bool colorCeilInitialized = false;
        private Detector currentDetector = null;        
        private System.Windows.Forms.Timer timer = new System.Windows.Forms.Timer();
        bool needRepaint = false;

        private int SelectedSessionIndex1 = -1;
        private int SelectedSessionIndex2 = -1;

        private bool resizeing = false;
        private int leftX = 1, topY = 0;

        private FontFamily fontFamily = new FontFamily("Arial");
        private Font font = null;

        public FormWaterfallLive(FormContainer p, GASettings s, ILog l)
        {
            InitializeComponent();
            
            DoubleBuffered = true;
            MdiParent = parent = p;
            settings = s;
            log = l;
        }        

        private void FormWaterfall_Load(object sender, EventArgs e)
        {            
            font = new Font(fontFamily, 11, FontStyle.Regular, GraphicsUnit.Pixel);

            labelColorCeil.Text = "";
            labelChannel.Text = "";
            labelSpectrum.Text = "";
            labelEnergy.Text = "";

            timer.Interval = 500;
            timer.Tick += timer_Tick;
            timer.Start();

            pane_Resize(sender, e);        
            UpdateStats();
        }

        void timer_Tick(object sender, EventArgs e)
        {            

            if (session == null || bmpPane == null || WindowState == FormWindowState.Minimized)
                return;

            if (menuItemUseLogarithmicScale.Checked)
            {
                tbColorCeil.Maximum = (int)Math.Log(session.MaxChannelCount);
                tbColorCeil.Minimum = (int)Math.Log(session.MinChannelCount);
                if (tbColorCeil.Minimum < 0)
                    tbColorCeil.Minimum = 0;
            }
            else
            {
                tbColorCeil.Maximum = (int)session.MaxChannelCount;
                tbColorCeil.Minimum = (int)session.MinChannelCount;
            }

            if (!colorCeilInitialized)
                tbColorCeil.Value = tbColorCeil.Maximum;

            UpdateStats();

            if (tbColorCeil.Value < 1)
                return;

            if (!needRepaint)
                return;
            needRepaint = false;

            Graphics graphics = Graphics.FromImage(bmpPane);
            Pen penSelected = new Pen(Color.White);
            penSelected.DashStyle = System.Drawing.Drawing2D.DashStyle.Dash;
            SolidBrush whiteBrush = new SolidBrush(Color.White);
            Pen penROI = new Pen(Color.Black);
            penROI.DashStyle = System.Drawing.Drawing2D.DashStyle.Dot;

            graphics.Clear(Color.FromArgb(255, 0, 0, 255));

            float max = tbColorCeil.Value;
            float sectorSize = max / 4f;
            float scale = 255f / sectorSize;
            int sectorSkip, adjustment;            
            int y = 0;

            for (int i = session.Spectrums.Count - 1 - topY; i >= 0; i--)
            {
                if (y >= bmpPane.Height)
                    break;                

                Spectrum s = session.Spectrums[i];
                int w = s.Channels.Count > bmpPane.Width ? bmpPane.Width : s.Channels.Count;                

                bmpPane.SetPixel(0, y, Utils.ToColor(s.SessionIndex));

                for (int x = 1; x < w; x++)
                {
                    if (leftX + x >= s.Channels.Count)
                        break;

                    int a = 255, r = 0, g = 0, b = 255;

                    float cps = 0f;
                    if (menuItemUseLogarithmicScale.Checked)
                    {
                        cps = (float)Math.Log(s.Channels[leftX + x]);
                        if (cps < 0f)
                            cps = 0f;
                    }
                    else
                    {
                        cps = (float)s.Channels[leftX + x];
                    }

                    if (btnSubtractBackground.Checked && session.Background != null)
                    {
                        if (leftX + x < session.Background.Length)
                        {
                            float sub = 0f;
                            if (menuItemUseLogarithmicScale.Checked)
                            {
                                sub = (float)Math.Log(session.Background[leftX + x]);
                                if (sub < 0f)
                                    sub = 0f;
                            }
                            else
                            {
                                sub = (float)session.Background[leftX + x];
                            }

                            cps -= sub;

                            if (cps < 0)
                                cps = 0;
                        }
                    }

                    sectorSkip = CalculateSectorSkip(cps, sectorSize);

                    adjustment = CalculateColorAdjustment(cps, sectorSkip, sectorSize, scale);

                    AdjustColorComponents(sectorSkip, adjustment, ref r, ref g, ref b);                                        

                    bmpPane.SetPixel(x, y, Color.FromArgb(a, r, g, b));

                    if (((leftX + x) % 200) == 0)
                    {
                        int ch = leftX + x;
                        graphics.DrawString(ch.ToString(), font, whiteBrush, x, bmpPane.Height - 20);
                    }
                }

                if (s.SessionIndex == SelectedSessionIndex1)
                {
                    graphics.DrawLine(penSelected, new Point(1, y), new Point(bmpPane.Width, y));
                }

                if (s.SessionIndex == SelectedSessionIndex2 && SelectedSessionIndex1 != SelectedSessionIndex2)
                {
                    graphics.DrawLine(penSelected, new Point(1, y), new Point(bmpPane.Width, y));
                }

                y++;
            }

            if (btnROI.Checked)
            {
                foreach (ROIData rd in settings.ROIList)
                {
                    if (!rd.Active)
                        continue;

                    if (rd.StartChannel > leftX && rd.StartChannel < leftX + bmpPane.Width)
                    {
                        graphics.DrawLine(penSelected, new Point((int)rd.StartChannel - leftX, 0), new Point((int)rd.StartChannel - leftX, bmpPane.Height - 25));
                        graphics.DrawString(rd.Name, font, whiteBrush, (int)rd.StartChannel - leftX + 4, bmpPane.Height - 40);
                    }

                    if (rd.EndChannel > leftX && rd.EndChannel < leftX + bmpPane.Width)
                        graphics.DrawLine(penSelected, new Point((int)rd.EndChannel - leftX, 0), new Point((int)rd.EndChannel - leftX, bmpPane.Height - 25));
                }
            }

            pane.Refresh();
        }

        private int CalculateSectorSkip(float cps, float sectorSize)
        {
            if (cps < sectorSize)
                return 0;
            else if (cps < sectorSize * 2f)
                return 1;
            else if (cps < sectorSize * 3f)
                return 2;
            else return 3;
        }

        private int CalculateColorAdjustment(float cps, int sectorSkip, float sectorSize, float scale)
        {
            float a = (cps - (float)sectorSkip * sectorSize) * scale;
            if (a < 0)
                a = 0;
            else if (a > 255)
                a = 255;
            return (int)a;
        }

        private void AdjustColorComponents(int sectorSkip, int adjustment, ref int r, ref int g, ref int b)
        {
            if (sectorSkip == 0)
            {
                g += adjustment;
            }
            else if (sectorSkip == 1)
            {
                g = 255;
                b -= adjustment;
            }
            else if (sectorSkip == 2)
            {
                g = 255;
                b = 0;
                r += adjustment;
            }
            else
            {
                g = 255;
                b = 0;
                r = 255;
                g -= adjustment;
            }
        }

        private void UpdateStats()
        {
            labelColorCeil.Text = "Color ceiling: " + tbColorCeil.Value + " [" + tbColorCeil.Minimum + ", " + tbColorCeil.Maximum + "]";
        }

        public void SetSession(Session sess)
        {
            session = sess;            
        }

        public void SetDetector(Detector det)
        {
            currentDetector = det;            
        }

        public void UpdatePane()
        {
            needRepaint = true;
        }        

        private void pane_Paint(object sender, PaintEventArgs e)        
        {
            if (bmpPane == null || WindowState == FormWindowState.Minimized)
                return;
            
            e.Graphics.DrawImage(bmpPane, 0, 0);
        }

        private void pane_Resize(object sender, EventArgs e)
        {
            if (WindowState == FormWindowState.Minimized || pane.Width < 1 || pane.Height < 1 || resizeing == true)
                return;            

            bmpPane = new Bitmap(pane.Width, pane.Height);
            leftX = 1;
            UpdatePane();
        }        

        private void tbColorCeil_ValueChanged(object sender, EventArgs e)
        {
            if (tbColorCeil.Value <= tbColorCeil.Minimum)
                tbColorCeil.Value = tbColorCeil.Minimum + 1;

            UpdateStats();
        }

        private void tbColorCeil_Scroll(object sender, EventArgs e)
        {
            colorCeilInitialized = true;
            UpdatePane();
        }

        private void pane_MouseDown(object sender, MouseEventArgs e)
        {
            if (session == null || bmpPane == null || WindowState == FormWindowState.Minimized)
                return;

            if (e.Y < 0 || e.Y >= bmpPane.Height)
                return;

            if (e.Button == MouseButtons.Left)
            {                
                if (ModifierKeys.HasFlag(Keys.Shift) && SelectedSessionIndex1 != -1)                
                    parent.SetSelectedSessionIndices(SelectedSessionIndex1, Utils.ToArgb(bmpPane.GetPixel(0, e.Y)));                
                else                
                    parent.SetSelectedSessionIndex(Utils.ToArgb(bmpPane.GetPixel(0, e.Y)));
            }            
        }

        public void SetSelectedSessionIndex(int index)
        {
            SelectedSessionIndex1 = SelectedSessionIndex2 = index;

            UpdatePane();            
        }

        public void SetSelectedSessionIndices(int index1, int index2)
        {
            SelectedSessionIndex1 = index1;
            SelectedSessionIndex2 = index2;

            UpdatePane();
        }

        public void ClearSession()
        {            
            if(bmpPane != null)
            {
                Graphics g = Graphics.FromImage(bmpPane);
                g.Clear(Color.FromArgb(0, 0, 255));
            }                
            session = null;
        }

        private void btnLeftAll_Click(object sender, EventArgs e)
        {
            if (session == null || bmpPane == null || WindowState == FormWindowState.Minimized)
                return;

            leftX = 1;

            UpdatePane();
        }

        private void btnLeft_Click(object sender, EventArgs e)
        {
            if (session == null || bmpPane == null || WindowState == FormWindowState.Minimized)
                return;

            leftX -= bmpPane.Width / 2;
            if (leftX < 1)
                leftX = 1;

            UpdatePane();
        }

        private void btnRight_Click(object sender, EventArgs e)
        {
            if (session == null || bmpPane == null || WindowState == FormWindowState.Minimized)
                return;

            int maxX = (int)session.NumChannels - bmpPane.Width;

            leftX += bmpPane.Width / 2;
            if (leftX > maxX)
                leftX = maxX;
            if (leftX < 1)
                leftX = 1;

            UpdatePane();
        }

        private void btnRightAll_Click(object sender, EventArgs e)
        {
            if (session == null || bmpPane == null || WindowState == FormWindowState.Minimized)
                return;

            leftX = (int)session.NumChannels - bmpPane.Width;
            if (leftX < 1)
                leftX = 1;

            UpdatePane();
        }

        private void pane_MouseMove(object sender, MouseEventArgs e)
        {
            if (session == null || bmpPane == null || WindowState == FormWindowState.Minimized)
                return;

            // Show channel
            int mouseChannel = leftX + e.X;
            labelChannel.Text = "Ch: " + String.Format("{0:###0}", mouseChannel);

            // Show session index
            if(e.Y < session.Spectrums.Count - 1 && e.Y >= 0 && e.Y <= bmpPane.Height)
            {
                int sessionId = Utils.ToArgb(bmpPane.GetPixel(0, e.Y));
                labelSpectrum.Text = "Idx: " + sessionId.ToString();
            }
            else labelSpectrum.Text = "";

            // Show energy
            if (session.IsLoaded && currentDetector != null)
            {
                //double E = Utils.EnergyCalculationFunc((double)e.X);
                double en = currentDetector.GetEnergy(e.X);
                labelEnergy.Text = "En: " + String.Format("{0:#######0.0###}", en);
            }
            else labelEnergy.Text = "";
        }

        private void btnUpAll_Click(object sender, EventArgs e)
        {
            if (session == null || bmpPane == null || WindowState == FormWindowState.Minimized)
                return;

            topY = 0;            
            UpdatePane();
        }

        private void btnUp_Click(object sender, EventArgs e)
        {
            if (session == null || bmpPane == null || WindowState == FormWindowState.Minimized)
                return;

            topY -= bmpPane.Height;
            if (topY < 0)
                topY = 0;

            UpdatePane();
        }

        private void btnDown_Click(object sender, EventArgs e)
        {
            if (session == null || bmpPane == null || WindowState == FormWindowState.Minimized)
                return;

            int maxY = session.Spectrums.Count - bmpPane.Height - 1;

            topY += bmpPane.Height;
            if (topY > maxY)
                topY = maxY;
            if (topY < 0)
                topY = 0;

            UpdatePane();
        }

        private void btnDownAll_Click(object sender, EventArgs e)
        {
            if (session == null || bmpPane == null || WindowState == FormWindowState.Minimized)
                return;

            topY = session.Spectrums.Count - 1 - bmpPane.Height;
            if (topY < 0)
                topY = 0;

            UpdatePane();
        }

        private void FormWaterfallLive_ResizeBegin(object sender, EventArgs e)
        {
            resizeing = true;            
        }

        private void FormWaterfallLive_ResizeEnd(object sender, EventArgs e)
        {
            resizeing = false;
            pane_Resize(sender, e);            
        }

        private void btnROI_CheckedChanged(object sender, EventArgs e)
        {
            UpdatePane();
        }

        private void menuItemUnselect_Click(object sender, EventArgs e)
        {
            parent.SetSelectedSessionIndex(-1);
        }

        private void menuItemUseLogarithmicScale_CheckedChanged(object sender, EventArgs e)
        {                        
            UpdatePane();
        }

        private void btnSubtractBackground_CheckedChanged(object sender, EventArgs e)
        {                 
            UpdatePane();
        }
    }
}
