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
    public partial class FormAskZeroPolynomial : Form
    {
        public double ZeroPolynomial;
        private int Channel;
        public bool SaveToSettings;
        private Detector Det;

        public FormAskZeroPolynomial(Detector det, int chan, bool canUpdateSettingsDetector)
        {
            InitializeComponent();
            Det = det.Clone();            
            Channel = chan;
            lblChannel.Text = Channel.ToString();
            if (Det.EnergyCurveCoefficients.Count > 0)
                tbZeroPolynomial.Text = Det.EnergyCurveCoefficients[0].ToString();
            if (!canUpdateSettingsDetector)
                cbSaveSettings.Enabled = false;
        }

        private void FormAskZeroPolynomial_Load(object sender, EventArgs e)
        {
            tbZeroPolynomial.KeyPress += CustomEvents.Numeric_KeyPress;
        }

        private void btnOk_Click(object sender, EventArgs e)
        {
            try
            {
                ZeroPolynomial = Convert.ToDouble(tbZeroPolynomial.Text.Trim());
            }
            catch
            {
                MessageBox.Show("Invalid number format");
                return;
            }

            SaveToSettings = cbSaveSettings.Checked;

            DialogResult = DialogResult.OK;
            Close();
        }

        private void btnCancel_Click(object sender, EventArgs e)
        {
            DialogResult = DialogResult.Cancel;
            Close();
        }

        private void tbZeroPolynomial_TextChanged(object sender, EventArgs e)
        {            
            double testZero;
            try
            {
                testZero = Convert.ToDouble(tbZeroPolynomial.Text.Trim());                
            }
            catch
            {
                return;
            }

            if(Det.EnergyCurveCoefficients.Count > 0)
                Det.EnergyCurveCoefficients[0] = testZero;
            lblEnergy.Text = Det.GetEnergy(Channel).ToString();
        }
    }
}
