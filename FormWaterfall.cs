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
        List<Spectrum> specs = null;        
        Bitmap bmp = null;
        float max = 0f;

        public FormWaterfall()
        {
            InitializeComponent();            
        }        

        private void FormWaterfall_Load(object sender, EventArgs e)
        {
            pane_Resize(sender, e);
        }

        public void SetSpectrumList(List<Spectrum> spectrumList)
        {            
            specs = spectrumList;            
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
            if (specs == null || bmp == null)
                return;
                                    
            Graphics g = e.Graphics;
            
            foreach (Spectrum s in specs)
            {
                string[] items = s.Message.Arguments["channels"].Split(new char[] { ' ' }, StringSplitOptions.RemoveEmptyEntries);                
                foreach (string item in items)
                {
                    float ch = Convert.ToSingle(item);
                    if (ch > max)
                        max = ch;
                }                
            }
            float scale = 255f / max;
            int y = 0;

            foreach(Spectrum s in specs)
            {                
                int channelCount = Convert.ToInt32(s.Message.Arguments["channel_count"]);
                int w = channelCount > pane.Width ? pane.Width : channelCount; // FIXME
                int h = pane.Height > specs.Count ? specs.Count : pane.Height;                
                
                string[] items = s.Message.Arguments["channels"].Split(new char[] { ' ' }, StringSplitOptions.RemoveEmptyEntries);                

                for (int x = 0; x < w; x++)
                {                        
                    float cps = Convert.ToSingle(items[x]);
                    cps *= scale;                        
                    Color c = Color.FromArgb(255, (int)cps, 0, 0);
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
