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
using System.Text;
using System.Windows.Forms;
using log4net;

namespace crash
{
    public partial class FormAskZeroPolynomial : Form
    {
        private ILog log = null;
        private int channel;
        private Detector detector;

        public double ZeroPolynomial;        
        public bool SaveToSettings;        

        public FormAskZeroPolynomial(ILog l, Detector d, int chan, bool canUpdateSettingsDetector)
        {
            InitializeComponent();
            log = l;
            detector = d.Clone();            
            channel = chan;
            lblChannel.Text = channel.ToString();
            if (detector.EnergyCurveCoefficients.Count > 0)
                tbZeroPolynomial.Text = detector.EnergyCurveCoefficients[0].ToString();
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
            catch(Exception ex)
            {
                log.Error("Zero Polynomial: Invalid number format", ex);
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

            if(detector.EnergyCurveCoefficients.Count > 0)
                detector.EnergyCurveCoefficients[0] = testZero;
            lblEnergy.Text = detector.GetEnergy(channel).ToString();
        }
    }
}
