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
    public partial class FormROILive : Form
    {
        private List<ROIData> ROIList = null;
        private Session session = null;
        private Bitmap bmpPane = null;        
        private int SelectedSessionIndex1 = -1;
        private int SelectedSessionIndex2 = -1;

        public delegate void SetSessionIndexEventHandler(object sender, SetSessionIndexEventArgs e);
        public event SetSessionIndexEventHandler SetSessionIndexEvent;        

        private int first_channel = 0;

        public FormROILive(List<ROIData> roiList)
        {
            InitializeComponent();
            DoubleBuffered = true;
            ROIList = roiList;
        }        

        private void FormROITableLive_Load(object sender, EventArgs e)
        {
            lblScaling.Text = "";
            pane_Resize(sender, e);
        }
        
        private void FormROITableLive_FormClosing(object sender, FormClosingEventArgs e)
        {
            e.Cancel = true;
            Hide();
        }

        public void SetSession(Session sess)
        {
            session = sess;
        }

        public void UpdatePane()
        {
            if (session == null || bmpPane == null || WindowState == FormWindowState.Minimized)
                return;

            if (session.Spectrums.Count < 1)
                return;

            if (ROIList.Count < 1)
                return;

            Graphics g = Graphics.FromImage(bmpPane);
            g.Clear(SystemColors.ButtonFace);
            
            float scaling = -1f;

            foreach (ROIData rd in ROIList)
            {
                if (!rd.Active)
                    continue;                                

                float s = (pane.Height - 40) / session.GetMaxCountInROI((int)rd.StartChannel, (int)rd.EndChannel);

                if(scaling == -1f)
                {
                    scaling = s;
                }
                else
                {
                    if (s < scaling)
                        scaling = s;
                }
            }            

            lblScaling.Text = scaling.ToString();

            foreach (ROIData rd in ROIList)
            {
                if (!rd.Active)
                    continue;

                Pen pen = new Pen(Color.FromName(rd.ColorName), 2);
                int x = 0;
                int last_x = 0, last_y = pane.Height - 40;                

                for (int i = first_channel; i < first_channel + pane.Width; i++)
                {
                    if (i >= (int)session.Spectrums.Count)
                        break;

                    Spectrum s = session.Spectrums[i];
                    float weightedCount = s.GetCountInROI((int)rd.StartChannel, (int)rd.EndChannel) * scaling;
                    int y = pane.Height - 40 - (int)weightedCount;

                    if (x >= 0 && x < pane.Width && y >= 0 && y < pane.Height)
                    {
                        g.DrawLine(pen, last_x, last_y, x, y);
                    }                    

                    if ((x % 400) == 0)
                    {
                        FontFamily fontFamily = new FontFamily("Arial");
                        Font font = new Font(fontFamily, 10, FontStyle.Regular, GraphicsUnit.Pixel);
                        g.DrawString(weightedCount.ToString(), font, new SolidBrush(Color.FromName(rd.ColorName)), x, pane.Height - 20);
                    }
                    
                    bmpPane.SetPixel(x, bmpPane.Height - 1, Utils.ToColor(s.SessionIndex));

                    last_x = x;
                    last_y = y;
                    x++;
                }
            }

            for(int j=0; j<bmpPane.Width; j++)
            {
                int idx = Utils.ToArgb(bmpPane.GetPixel(j, bmpPane.Height - 1));

                if(idx == SelectedSessionIndex1)
                {
                    Pen penSel = new Pen(Color.Black);
                    penSel.DashStyle = System.Drawing.Drawing2D.DashStyle.Dash;
                    g.DrawLine(penSel, new Point(j, 0), new Point(j, bmpPane.Height - 2));                    
                }

                if (idx == SelectedSessionIndex2 && SelectedSessionIndex1 != SelectedSessionIndex2)
                {
                    Pen penSel = new Pen(Color.Black);
                    penSel.DashStyle = System.Drawing.Drawing2D.DashStyle.Dash;
                    g.DrawLine(penSel, new Point(j, 0), new Point(j, bmpPane.Height - 2));
                }
            }            

            pane.Refresh();
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
            first_channel = 0;
            UpdatePane();            
        }        

        private void pane_MouseClick(object sender, MouseEventArgs e)
        {
            if (SetSessionIndexEvent != null)
            {
                SetSessionIndexEventArgs args = new SetSessionIndexEventArgs();
                args.StartIndex = args.EndIndex = Utils.ToArgb(bmpPane.GetPixel(e.X, bmpPane.Height - 1));
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
                g.Clear(SystemColors.ButtonFace);
            }            
            session = null;            
        }

        private void btnLeftAll_Click(object sender, EventArgs e)
        {
            if (session == null || bmpPane == null || WindowState == FormWindowState.Minimized)
                return;

            first_channel = 0;
            UpdatePane();
        }

        private void btnRightAll_Click(object sender, EventArgs e)
        {
            if (session == null || bmpPane == null || WindowState == FormWindowState.Minimized)
                return;

            first_channel = (int)session.NumChannels - pane.Width;
            if (first_channel < 0)
                first_channel = 0;
            UpdatePane();
        }

        private void btnLeft_Click(object sender, EventArgs e)
        {
            if (session == null || bmpPane == null || WindowState == FormWindowState.Minimized)
                return;

            first_channel -= pane.Width;
            if (first_channel < 1)
                first_channel = 1;
            UpdatePane();
        }

        private void btnRight_Click(object sender, EventArgs e)
        {
            if (session == null || bmpPane == null || WindowState == FormWindowState.Minimized)
                return;

            int max_channel = (int)session.NumChannels - pane.Width;
            first_channel += pane.Width;
            if (first_channel > max_channel)
                first_channel = max_channel;
            if (first_channel < 0)
                first_channel = 0;
            UpdatePane();
        }                        
    }    
}
