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

        public void SetSpectrumList(Session sess)
        {
            session = sess;
        }

        public void Repaint()
        {
            pane.Refresh();
        }

        private void FormWaterfall_FormClosing(object sender, FormClosingEventArgs e)
        {
            e.Cancel = true;
            Hide();
        }

        private void pane_Paint(object sender, PaintEventArgs e)
        {
            if (session == null || bmp == null)
                return;
                                    
            Graphics g = e.Graphics;
                        
            float scale = 255f / session.MaxChannelCount;
            int y = 0;

            int h = pane.Height > session.Spectrums.Count ? session.Spectrums.Count : pane.Height - 1;

            foreach(Spectrum s in session.Spectrums)
            {                                   
                int w = s.Channels.Count > pane.Width ? pane.Width : s.Channels.Count; // FIXME                                

                for (int x = 0; x < w; x++)
                {                    
                    int r = (int)(s.Channels[x] * scale);                    
                    Color c = Color.FromArgb(255, r, 0, 0);                    
                    bmp.SetPixel(x, y, c);
                }
                y++;
            }

            g.DrawImage(bmp, 0, 0);
        }

        private void pane_Resize(object sender, EventArgs e)
        {
            bmp = new Bitmap(pane.Width, pane.Height);
        }
    }
}
