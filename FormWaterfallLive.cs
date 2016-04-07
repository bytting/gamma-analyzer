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
        Session session = null;
        Bitmap bmpPane = null;
        bool colorCeilInitialized = false;
        private int SelectedSessionIndex1 = -1;
        private int SelectedSessionIndex2 = -1;

        public delegate void SetSessionIndexEventHandler(object sender, SetSessionIndexEventArgs e);
        public event SetSessionIndexEventHandler SetSessionIndexEvent;

        public FormWaterfallLive()
        {
            InitializeComponent();
            DoubleBuffered = true;            
        }        

        private void FormWaterfall_Load(object sender, EventArgs e)
        {
            lblColorCeil.Text = "";            

            pane_Resize(sender, e);        
            UpdateStats();
        }    

        private void UpdateStats()
        {
            lblColorCeil.Text = "Color ceiling (min, curr, max): " + tbColorCeil.Minimum + ", " + tbColorCeil.Value + ", " + tbColorCeil.Maximum;
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

            float max = tbColorCeil.Value;
            float sectorSize = max / 4f;            
            float scale = 255f / sectorSize;
            int y = 0;

            int h = pane.Height > session.Spectrums.Count ? session.Spectrums.Count : pane.Height - 1;            

            for (int i = h - 1; i >= 0; i--)
            {
                Spectrum s = session.Spectrums[i];                

                int w = s.Channels.Count > pane.Width ? pane.Width : s.Channels.Count; // FIXME
                
                bmpPane.SetPixel(0, y, Utils.ToColor(s.SessionIndex));

                for (int x = 1; x < w; x++)
                {
                    int a = 255, r = 0, g = 0, b = 255;
                    float cps = s.Channels[x];
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
                    
                    if (x > 0 && x < pane.Width && y >= 0 && y < pane.Height)
                        bmpPane.SetPixel(x, y, Color.FromArgb(a, r, g, b));
                }

                if(s.SessionIndex == SelectedSessionIndex1)
                {
                    Graphics g = Graphics.FromImage(bmpPane);
                    Pen pen = new Pen(Color.White);
                    pen.DashStyle = System.Drawing.Drawing2D.DashStyle.Dash;

                    g.DrawLine(pen, new Point(1, y), new Point(pane.Width, y));                    
                }

                if (s.SessionIndex == SelectedSessionIndex2 && SelectedSessionIndex1 != SelectedSessionIndex2)
                {
                    Graphics g = Graphics.FromImage(bmpPane);
                    Pen pen = new Pen(Color.White);
                    pen.DashStyle = System.Drawing.Drawing2D.DashStyle.Dash;

                    g.DrawLine(pen, new Point(1, y), new Point(pane.Width, y));
                }

                y++;
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
            if (WindowState == FormWindowState.Minimized)
                return;
            if (pane.Width < 1 || pane.Height < 1)
                return;

            bmpPane = new Bitmap(pane.Width, pane.Height);
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
            if (SetSessionIndexEvent != null)
            {                
                SetSessionIndexEventArgs args = new SetSessionIndexEventArgs();
                args.StartIndex = args.EndIndex = Utils.ToArgb(bmpPane.GetPixel(0, e.Y));            
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
    }
}
