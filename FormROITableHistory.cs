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
    public partial class FormROITableHistory : Form
    {
        Session session = null;
        Bitmap bmpPane = null;
        List<ROIData> roiList = new List<ROIData>();
        int SelectedSessionIndex1 = -1;
        int SelectedSessionIndex2 = -1;

        public delegate void SetSessionIndexEventHandler(object sender, SetSessionIndexEventArgs e);
        public event SetSessionIndexEventHandler SetSessionIndexEvent;

        public FormROITableHistory()
        {
            InitializeComponent();
            DoubleBuffered = true;
        }

        private void FormROITableHistory_FormClosing(object sender, FormClosingEventArgs e)
        {
            e.Cancel = true;
            Hide();
        }

        private void FormROITableHistory_Load(object sender, EventArgs e)
        {
            lblScaling.Text = "";

            pane_Resize(sender, e);
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

            if (roiList.Count < 1)
                return;

            Graphics g = Graphics.FromImage(bmpPane);
            g.Clear(SystemColors.ButtonFace);
            
            float scaling = -1f;

            foreach (ROIData rd in roiList)
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

            foreach(ROIData rd in roiList)
            {
                if (!rd.Active)
                    continue;

                Pen pen = new Pen(rd.Color, 2);
                int x = 0;
                int last_x = 0, last_y = pane.Height - 40;                

                foreach (Spectrum s in session.Spectrums)
                {
                    float weightedCount = s.GetCountInROI((int)rd.StartChannel, (int)rd.EndChannel) * scaling;
                    int y = pane.Height - 40 - (int)weightedCount;

                    if (x >= 0 && x < pane.Width && y >= 0 && y < pane.Height)
                    {
                        g.DrawLine(pen, last_x, last_y, x, y);
                    }
                    last_x = x;
                    last_y = y;
                    x++;

                    if ((x % 400) == 0)
                    {
                        FontFamily fontFamily = new FontFamily("Arial");
                        Font font = new Font(fontFamily, 10, FontStyle.Regular, GraphicsUnit.Pixel);
                        g.DrawString(weightedCount.ToString(), font, new SolidBrush(rd.Color), x, pane.Height - 20);
                    }
                    
                    bmpPane.SetPixel(x, bmpPane.Height - 1, Utils.ToColor(s.SessionIndex));
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
        }

        private void btnApply_Click(object sender, EventArgs e)
        {
            roiList.Clear();

            Color[] colorList = { Color.Red, Color.Blue, Color.Green, Color.Orange, Color.Cyan };
            int colorIndex = 0;

            foreach(DataGridViewRow row in gridROI.Rows)
            {
                if(row.Cells[0].Value == null
                    || row.Cells[1].Value == null
                    || row.Cells[2].Value == null
                    || row.Cells[3].Value == null)
                {
                    continue;
                }

                ROIData rd = new ROIData();
                rd.Name = row.Cells[0].Value.ToString();
                rd.StartChannel = Convert.ToSingle(row.Cells[1].Value);
                rd.EndChannel = Convert.ToSingle(row.Cells[2].Value);
                rd.Active = Convert.ToBoolean(row.Cells[3].Value);
                rd.Color = colorList[colorIndex];
                roiList.Add(rd);
                colorIndex++;
                row.Cells[4].Value = rd.Color.ToString();
            }

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
    }

    public class ROIData
    {
        public string Name { get; set; }
        public float StartChannel { get; set; }
        public float EndChannel { get; set; }
        public bool Active { get; set; }
        public Color Color { get; set; }
    }
}
