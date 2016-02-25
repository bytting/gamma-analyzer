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
    public partial class FormWaterfall : Form
    {
        Session session = null;        
        Bitmap bmp = null;
        float max = 0f;

        public FormWaterfall()
        {
            InitializeComponent();
            DoubleBuffered = true;
        }        

        private void FormWaterfall_Load(object sender, EventArgs e)
        {            
            pane_Resize(sender, e);
        }

        public void SetSession(Session sess)
        {
            session = sess;
        }

        public void Repaint()
        {
            tbColorCeil.Maximum = (int)session.MaxChannelCount;
            tbColorCeil.Minimum = (int)session.MinChannelCount;
            pane.Refresh();
        }

        private void FormWaterfall_FormClosing(object sender, FormClosingEventArgs e)
        {
            e.Cancel = true;
            Hide();
        }

        private void pane_Paint(object sender, PaintEventArgs e)        
        {
            if (session == null || bmp == null || WindowState == FormWindowState.Minimized || pane.Height < 5)
                return;            

            float sectorSize = session.MaxChannelCount / 4f;
            float scale = 255f / sectorSize;
            int y = 0;

            int h = pane.Height > session.Spectrums.Count ? session.Spectrums.Count : pane.Height - 1;

            foreach(Spectrum s in session.Spectrums)
            {                                   
                int w = s.Channels.Count > pane.Width ? pane.Width : s.Channels.Count; // FIXME                                

                for (int x = 0; x < w; x++)
                {
                    int r=0, g=0, b=255;
                    float cps = s.Channels[x];
                    int sectorSkip = CalcSectorSkip(cps, sectorSize);

                    float adj = (cps - (float)sectorSkip * sectorSize) * scale;

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

                    if(x >= 0 && x < pane.Width && y >= 0 && y < pane.Height)
                        bmp.SetPixel(x, y, Color.FromArgb(r, g, b));
                }
                y++;
            }

            e.Graphics.DrawImage(bmp, 0, 0);
        }

        private void pane_Resize(object sender, EventArgs e)
        {
            if (WindowState == FormWindowState.Minimized)
                return;
            if (pane.Width < 5 || pane.Height < 5)
                return;

            bmp = new Bitmap(pane.Width, pane.Height);
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
    }
}
