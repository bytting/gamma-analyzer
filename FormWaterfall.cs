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
        Graphics g = null;
        Bitmap bm = null;
        int y;

        public FormWaterfall()
        {
            InitializeComponent();

            g = pane.CreateGraphics();
            bm = new Bitmap(1024, 800);
            y = 0;
        }

        private void FormWaterfall_Load(object sender, EventArgs e)
        {                                    
        }

        public void AddSpectrum(Spectrum spec)
        {   
            if(y > 800)
                return;
            
            for(int x=0; x<1024; x++)
            {
                bm.SetPixel(x, y, Color.Red);
            }

            g.DrawImage(bm, 0, 0);
            y++;
        }

        private void FormWaterfall_FormClosing(object sender, FormClosingEventArgs e)
        {
            e.Cancel = true;
            Hide();
        }
    }
}
