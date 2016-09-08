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
// Authors: Dag robole,

using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace crash
{
    public partial class FormWaterfallLive : Form
    {
        private Session session = null;        
        private Bitmap bmpPane = null;
        private bool colorCeilInitialized = false;
        private List<ROIData> ROIList = null;

        private int SelectedSessionIndex1 = -1;
        private int SelectedSessionIndex2 = -1;
        public delegate void SetSessionIndexEventHandler(object sender, SetSessionIndexEventArgs e);
        public event SetSessionIndexEventHandler SetSessionIndexEvent;

        private bool resizeing = false;
        private int leftX = 1, topY = 0;

        private FontFamily fontFamily = new FontFamily("Arial");
        private Font font = null;

        public FormWaterfallLive(List<ROIData> roiList)
        {
            InitializeComponent();
            DoubleBuffered = true;
            ROIList = roiList;
        }        

        private void FormWaterfall_Load(object sender, EventArgs e)
        {
            font = new Font(fontFamily, 11, FontStyle.Regular, GraphicsUnit.Pixel);

            lblColorCeil.Text = "";
            lblChannel.Text = "";
            lblSessionId.Text = "";
            lblEnergy.Text = "";

            pane_Resize(sender, e);        
            UpdateStats();
        }    

        private void UpdateStats()
        {
            lblColorCeil.Text = "Color ceiling: " + tbColorCeil.Value + " [" + tbColorCeil.Minimum + ", " + tbColorCeil.Maximum + "]";
        }

        public void SetSession(Session sess)
        {
            session = sess;            
        }

        public void UpdatePane()
        {            
            if (session == null || bmpPane == null || WindowState == FormWindowState.Minimized)
                return;

            tbColorCeil.Maximum = (int)session.MaxChannelCount;
            tbColorCeil.Minimum = (int)session.MinChannelCount;

            if (!colorCeilInitialized)            
                tbColorCeil.Value = tbColorCeil.Maximum;            

            UpdateStats();            

            if (tbColorCeil.Value < 1)
                return;

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
            int y = 0;            

            for (int i = session.Spectrums.Count - 1 - topY; i >= 0; i--)
            {
                if (y >= bmpPane.Height)
                    break;

                if (i >= session.Spectrums.Count) // FIXME
                    continue;

                Spectrum s = session.Spectrums[i];                
                int w = s.Channels.Count > bmpPane.Width ? bmpPane.Width : s.Channels.Count; // FIXME

                if (y < 0 || y >= bmpPane.Height) // FIXME
                    continue; 

                bmpPane.SetPixel(0, y, Utils.ToColor(s.SessionIndex));

                for (int x = 1; x < w; x++)
                {
                    if (leftX + x >= s.Channels.Count) // FIXME
                        break;

                    int a = 255, r = 0, g = 0, b = 255;
                    float cps = s.Channels[leftX + x];
                    if (btnSubtractBackground.Checked && session.Background != null)
                    {
                        if (leftX + x < session.Background.Length) // FIXME
                        {
                            cps -= session.Background[leftX + x];
                            if (cps < 0)
                                cps = 0;
                        }
                    }                        
                    
                    int sectorSkip = CalcSectorSkip(cps, sectorSize);

                    float adj = (cps - (float)sectorSkip * sectorSize) * scale;
                    if (adj < 0)
                        adj = 0;
                    if (adj > 255)                    
                        adj = 255;                                            

                    if (sectorSkip == 0)
                    {
                        g += (int)adj;
                    }
                    else if (sectorSkip == 1)
                    {
                        g = 255;
                        b -= (int)adj;
                    }
                    else if (sectorSkip == 2)
                    {
                        g = 255;
                        b = 0;
                        r += (int)adj;
                    }
                    else
                    {
                        g = 255;
                        b = 0;
                        r = 255;
                        g -= (int)adj;
                    }

                    if (x < 0 || x >= bmpPane.Width || y < 0 || y >= bmpPane.Height) // FIXME
                        continue;

                    bmpPane.SetPixel(x, y, Color.FromArgb(a, r, g, b));

                    if (((leftX + x) % 200) == 0)
                    {
                        int ch = leftX + x;
                        graphics.DrawString(ch.ToString(), font, whiteBrush, x, bmpPane.Height - 20);                        
                    }                    
                }                

                if(s.SessionIndex == SelectedSessionIndex1)
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
                foreach (ROIData rd in ROIList)
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

        private void FormWaterfall_FormClosing(object sender, FormClosingEventArgs e)
        {
            e.Cancel = true;
            Hide();
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

        private int CalcSectorSkip(float cps, float sectorSize)
        {
            if (cps < sectorSize)
                return 0;
            else if (cps < sectorSize * 2f)
                return 1;
            else if (cps < sectorSize * 3f)
                return 2;
            else return 3;
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

            if (e.Button == MouseButtons.Left && SetSessionIndexEvent != null)
            {
                SetSessionIndexEventArgs args = new SetSessionIndexEventArgs();
                if (ModifierKeys.HasFlag(Keys.Shift) && SelectedSessionIndex1 != -1)
                {                    
                    args.StartIndex = SelectedSessionIndex1;
                    args.EndIndex = Utils.ToArgb(bmpPane.GetPixel(0, e.Y));                
                }
                else
                {                    
                    args.StartIndex = args.EndIndex = Utils.ToArgb(bmpPane.GetPixel(0, e.Y));                    
                }
                SetSessionIndexEvent(this, args);
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
            // Show channel
            int mouseChannel = leftX + e.X;
            lblChannel.Text = "Ch: " + String.Format("{0:###0}", mouseChannel);

            // Show session index
            if(e.Y < session.Spectrums.Count - 1 && e.Y >= 0 && e.Y <= bmpPane.Height)
            {
                int sessionId = Utils.ToArgb(bmpPane.GetPixel(0, e.Y));
                lblSessionId.Text = "Idx: " + sessionId.ToString();
            }
            else lblSessionId.Text = "";

            // Show energy
            if (session.IsLoaded && Utils.EnergyCalculationFunc != null)
            {
                double E = Utils.EnergyCalculationFunc((double)e.X);
                lblEnergy.Text = "En: " + String.Format("{0:###0.0###}", E);
            }
            else lblEnergy.Text = "";
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
            if (SetSessionIndexEvent != null)
            {
                SetSessionIndexEventArgs args = new SetSessionIndexEventArgs();
                args.StartIndex = args.EndIndex = -1;
                SetSessionIndexEvent(this, args);
            }
        }

        private void btnSubtractBackground_CheckedChanged(object sender, EventArgs e)
        {                 
            UpdatePane();
        }
    }
}
