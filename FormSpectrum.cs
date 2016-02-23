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
    public partial class FormSpectrum : Form
    {
        public FormSpectrum()
        {
            InitializeComponent();            
        }

        private void FormSpectrum_Load(object sender, EventArgs e)
        {
        }

        public void ShowSpectrum(Spectrum s)
        {
            chartSession.Series["Series1"].Points.Clear();
            
            string[] counts = s.Message.Arguments["channels"].Split(new char[] { ' ' });
            int index = 0;
            foreach (string ch in counts)
            {
                chartSession.Series["Series1"].Points.AddXY(index, Convert.ToInt32(ch));
                index++;
            }
        }

        private void FormSpectrum_FormClosing(object sender, FormClosingEventArgs e)
        {
            e.Cancel = true;
            Hide();
        }
    }
}
