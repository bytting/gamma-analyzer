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
using System.ComponentModel;
using System.Drawing;
using System.Text;
using System.Windows.Forms;
using log4net;

namespace crash
{
    public partial class FormROILive : Form
    {
        private FormContainer parent = null;
        private GASettings settings = null;
        private ILog log = null;

        private Session session = null;        
        private Bitmap bmpPane = null;        
        private int SelectedSessionIndex1 = -1;
        private int SelectedSessionIndex2 = -1;
        
        private int firstSpectrum = 0;

        public FormROILive(FormContainer p, GASettings s, ILog l)
        {
            InitializeComponent();
            
            DoubleBuffered = true;
            MdiParent = parent = p;
            settings = s;
            log = l;
        }        

        private void FormROITableLive_Load(object sender, EventArgs e)
        {
            try
            {
                labelScaling.Text = "";
                labelSpectrum.Text = "";
                pane_Resize(sender, e);
            }
            catch (Exception ex)
            {
                log.Error(ex.Message, ex);
            }
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

            if (settings.ROIList.Count < 1)
                return;

            Graphics g = Graphics.FromImage(bmpPane);
            g.Clear(SystemColors.ButtonFace);

            Pen penSelect = new Pen(Color.Black);
            penSelect.DashStyle = System.Drawing.Drawing2D.DashStyle.Dash;

            Pen penMarker = new Pen(Color.FromArgb(255, 120, 120, 120));
            penMarker.DashStyle = System.Drawing.Drawing2D.DashStyle.Dot;

            FontFamily fontFamily = new FontFamily("Arial");
            Font font = new Font(fontFamily, 10, FontStyle.Regular, GraphicsUnit.Pixel);
            
            float scaling = -1f;

            foreach (ROIData rd in settings.ROIList)
            {
                if (!rd.Active)
                    continue;

                if (rd.StartChannel < 0 || rd.StartChannel >= session.NumChannels || rd.EndChannel < 0 || rd.EndChannel >= session.NumChannels)
                {
                    log.Warn("ROI entry " + rd.Name + " is outside spectrum");
                    continue;
                }

                float s = (bmpPane.Height - 40) / session.GetMaxCountInROI((int)rd.StartChannel, (int)rd.EndChannel);

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

            labelScaling.Text = "Scale factor: " + String.Format("{0:0.0#}", scaling);

            foreach (ROIData rd in settings.ROIList)
            {
                if (!rd.Active)
                    continue;

                Pen pen = new Pen(Color.FromName(rd.ColorName), 1);
                int x = 0;
                int last_x = 0, last_y = pane.Height - 40;

                for (int i = firstSpectrum; i < firstSpectrum + bmpPane.Width; i++)
                {
                    if (i >= (int)session.Spectrums.Count)
                        break;                    

                    Spectrum s = session.Spectrums[i];
                    float weightedCount = s.GetCountInROI((int)rd.StartChannel, (int)rd.EndChannel) * scaling;                    

                    int y = pane.Height - 40 - (int)weightedCount;

                    if (x >= 0 && x < bmpPane.Width && y >= 0 && y < bmpPane.Height)                    
                        g.DrawLine(pen, last_x, last_y, x, y);                    
                    
                    bmpPane.SetPixel(x, bmpPane.Height - 1, Utils.ToColor(s.SessionIndex));

                    last_x = x;
                    last_y = y;
                    x++;
                }
            }

            for(int j=0; j<bmpPane.Width; j++)
            {
                int idx = Utils.ToArgb(bmpPane.GetPixel(j, bmpPane.Height - 1));

                if(idx % 100 == 0)                
                {
                    g.DrawLine(penMarker, new Point(j, 0), new Point(j, bmpPane.Height - 30));                                    
                    g.DrawString(idx.ToString(), font, new SolidBrush(Color.FromArgb(255, 125, 125, 125)), j, bmpPane.Height - 20);
                }

                if(idx == SelectedSessionIndex1)                
                    g.DrawLine(penSelect, new Point(j, 0), new Point(j, bmpPane.Height - 30));                                    

                if (idx == SelectedSessionIndex2 && SelectedSessionIndex1 != SelectedSessionIndex2)                
                    g.DrawLine(penSelect, new Point(j, 0), new Point(j, bmpPane.Height - 30));                
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
            if (pane.Width < 1 || pane.Height < 1 || WindowState == FormWindowState.Minimized)
                return;            

            bmpPane = new Bitmap(pane.Width, pane.Height);
            firstSpectrum = 0;

            UpdatePane();            
        }        

        private void pane_MouseClick(object sender, MouseEventArgs e)
        {
            if (session == null || bmpPane == null || WindowState == FormWindowState.Minimized)
                return;

            if (e.Button == MouseButtons.Left)
            {                                
                if (ModifierKeys.HasFlag(Keys.Shift) && SelectedSessionIndex1 != -1)                
                    parent.SetSelectedSessionIndices(SelectedSessionIndex1, Utils.ToArgb(bmpPane.GetPixel(e.X, bmpPane.Height - 1)));                
                else                
                    parent.SetSelectedSessionIndex(Utils.ToArgb(bmpPane.GetPixel(e.X, bmpPane.Height - 1)));                
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

            firstSpectrum = 0;

            UpdatePane();
        }

        private void btnRightAll_Click(object sender, EventArgs e)
        {
            if (session == null || bmpPane == null || WindowState == FormWindowState.Minimized)
                return;

            firstSpectrum = (int)session.Spectrums.Count - bmpPane.Width;
            if (firstSpectrum < 0)
                firstSpectrum = 0;

            UpdatePane();
        }

        private void btnLeft_Click(object sender, EventArgs e)
        {
            if (session == null || bmpPane == null || WindowState == FormWindowState.Minimized)
                return;

            firstSpectrum -= bmpPane.Width / 2;
            if (firstSpectrum < 0)
                firstSpectrum = 0;

            UpdatePane();
        }

        private void btnRight_Click(object sender, EventArgs e)
        {
            if (session == null || bmpPane == null || WindowState == FormWindowState.Minimized)
                return;

            int maxSpectrum = (int)session.Spectrums.Count - bmpPane.Width;
            if (maxSpectrum < 0)
                maxSpectrum = 0;

            firstSpectrum += bmpPane.Width / 2;
            if (firstSpectrum > maxSpectrum)
                firstSpectrum = maxSpectrum;            

            UpdatePane();
        }

        private void pane_MouseMove(object sender, MouseEventArgs e)
        {
            if (session == null || session.IsEmpty)
                return;

            int index = firstSpectrum + e.X;

            if(index < 0 || index >= session.Spectrums.Count)
            {
                labelSpectrum.Text = "";
                return;
            }                

            int sessionIndex = Utils.ToArgb(bmpPane.GetPixel(index, bmpPane.Height - 1));
            labelSpectrum.Text = "Idx: " + sessionIndex.ToString();
        }

        private void menuItemUnselect_Click(object sender, EventArgs e)
        {
            parent.SetSelectedSessionIndex(-1);
        }        
    }    
}
