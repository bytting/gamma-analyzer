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
    public partial class FormSourceActivity : Form
    {
        private CrashSettings mSettings = null;
        private Spectrum mSpectrum = null;

        public FormSourceActivity(CrashSettings settings, Spectrum spec)
        {
            InitializeComponent();
            mSettings = settings;
            mSpectrum = spec;
        }

        private void FormSourceActivity_Load(object sender, EventArgs e)
        {
            lblSessionSpectrum.Text = mSpectrum.SessionName + " - " + mSpectrum.SessionIndex;
            if (!String.IsNullOrEmpty(mSettings.LastApiKey))
                tbApiKey.Text = mSettings.LastApiKey;
        }

        private void btnCancel_Click(object sender, EventArgs e)
        {
            DialogResult = DialogResult.Cancel;
            Close();
        }

        private void btnOk_Click(object sender, EventArgs e)
        {
            DialogResult = DialogResult.OK;
            Close();
        }

        private void btnGetElevation_Click(object sender, EventArgs e)
        {
            tbElevation.Text = "";
            double elevation = mSpectrum.GetElevation(tbApiKey.Text);
            if (elevation == double.MinValue)
            {                
                MessageBox.Show("Unable to get a valid elevation");
                return;
            }                

            tbElevation.Text = String.Format("{0:###0.0##}", elevation);
            mSettings.LastApiKey = tbApiKey.Text;
        }                
    }
}
