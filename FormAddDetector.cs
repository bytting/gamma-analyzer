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
using System.Globalization;
using log4net;

namespace crash
{
    public partial class FormAddDetector : Form
    {
        private ILog log = null;
        private Detector detector = null;

        public string DetectorType { get; set; }
        public string Serialnumber { get; set; }
        public int MaxNumChannels { get; set; }
        public int NumChannels { get; set; }
        public int MinHV { get; set; }
        public int MaxHV { get; set; }
        public int HV { get; set; }
        public double CoarseGain { get; set; }
        public double FineGain { get; set; }        
        public int Livetime { get; set; }
        public int LLD { get; set; }
        public int ULD { get; set; }
        public string PluginName { get; set; }
        public string GEScript { get; set; }

        public FormAddDetector(ILog l, Detector d)
        {
            InitializeComponent();
            log = l;
            detector = d;            
        }

        private void FormAddDetector_Load(object sender, EventArgs e)
        {            
            tbMinHV.KeyPress += CustomEvents.Integer_KeyPress;
            tbMaxHV.KeyPress += CustomEvents.Integer_KeyPress;
            tbHV.KeyPress += CustomEvents.Integer_KeyPress;
            tbFineGain.KeyPress += CustomEvents.Numeric_KeyPress;
            tbLivetime.KeyPress += CustomEvents.Integer_KeyPress;
            tbLLD.KeyPress += CustomEvents.Integer_KeyPress;
            tbULD.KeyPress += CustomEvents.Integer_KeyPress;

            for (int i = 32; i < 65536; i *= 2)
                cboxMaxNumChannels.Items.Add(i.ToString());

            if (detector != null)
            {
                tbTypeName.Text = detector.TypeName;      
                tbSerialnumber.Text = detector.Serialnumber;
                tbSerialnumber.ReadOnly = true;
                int idx = cboxMaxNumChannels.FindStringExact(detector.MaxNumChannels.ToString());
                if (idx > -1)
                    cboxMaxNumChannels.SelectedItem = cboxMaxNumChannels.Items[idx];
                tbMinHV.Text = detector.MinVoltage.ToString();
                tbMaxHV.Text = detector.MaxVoltage.ToString();
                tbHV.Text = detector.Voltage.ToString();
                cboxCoarseGain.SelectedIndex = cboxCoarseGain.FindStringExact(detector.CoarseGain.ToString());
                tbFineGain.Text = detector.FineGain.ToString();
                tbLivetime.Text = detector.Livetime.ToString();
                tbLLD.Text = detector.LLD.ToString();
                tbULD.Text = detector.ULD.ToString();
                tbPluginName.Text = detector.PluginName;
                tbGEScript.Text = detector.GEScript;
            }
        }
        
        private void btnCancel_Click(object sender, EventArgs e)
        {
            DialogResult = DialogResult.Cancel;
            Close();
        }

        private void btnOk_Click(object sender, EventArgs e)
        {
            if (String.IsNullOrEmpty(tbSerialnumber.Text.Trim())
                || String.IsNullOrEmpty(tbTypeName.Text.Trim())
                || String.IsNullOrEmpty(cboxMaxNumChannels.Text.Trim())
                || String.IsNullOrEmpty(cboxNumChannels.Text.Trim())
                || String.IsNullOrEmpty(tbMinHV.Text.Trim())
                || String.IsNullOrEmpty(tbMaxHV.Text.Trim())
                || String.IsNullOrEmpty(tbHV.Text.Trim())
                || String.IsNullOrEmpty(tbFineGain.Text.Trim())                
                || String.IsNullOrEmpty(tbLivetime.Text.Trim())
                || String.IsNullOrEmpty(tbLLD.Text.Trim())
                || String.IsNullOrEmpty(tbULD.Text.Trim())
                || String.IsNullOrEmpty(tbPluginName.Text.Trim())
                || String.IsNullOrEmpty(tbGEScript.Text.Trim()))
            {
                MessageBox.Show("One or more required fields missing");
                return;
            }

            try
            {
                DetectorType = tbTypeName.Text.Trim();             
                Serialnumber = tbSerialnumber.Text.Trim();
                MaxNumChannels = Convert.ToInt32(cboxMaxNumChannels.SelectedItem);
                NumChannels = Convert.ToInt32(cboxNumChannels.SelectedItem);
                MinHV = Convert.ToInt32(tbMinHV.Text.Trim());
                MaxHV = Convert.ToInt32(tbMaxHV.Text.Trim());
                HV = Convert.ToInt32(tbHV.Text.Trim());
                CoarseGain = Convert.ToDouble(cboxCoarseGain.Text, CultureInfo.InvariantCulture);
                FineGain = Convert.ToDouble(tbFineGain.Text.Trim(), CultureInfo.InvariantCulture);
                Livetime = Convert.ToInt32(tbLivetime.Text.Trim());
                LLD = Convert.ToInt32(tbLLD.Text.Trim());
                ULD = Convert.ToInt32(tbULD.Text.Trim());
                PluginName = tbPluginName.Text.Trim();
                GEScript = tbGEScript.Text.Trim();
            }
            catch(Exception ex)
            {
                log.Error("Add detector: Invalid number format", ex);
                MessageBox.Show("Invalid number format");
                return;
            }

            if (FineGain < 1.0 || FineGain > 5.0)
            {
                log.Error("Fine gain out of range");
                MessageBox.Show("Fine gain out of range");
                return;
            }

            if (LLD < 0)
            {
                log.Error("LLD can not be less than zero");
                MessageBox.Show("LLD can not be less than zero");
                return;
            }

            if (ULD > 130)
            {
                log.Error("ULD can not be bigger than 130%");
                MessageBox.Show("ULD can not be bigger than 130%");
                return;
            }

            if (LLD > ULD)
            {
                log.Error("LLD can not be bigger than ULD");
                MessageBox.Show("LLD can not be bigger than ULD");
                return;
            }

            if (HV < MinHV || HV > MaxHV)
            {
                log.Error("Voltage out of range");
                MessageBox.Show("Voltage out of range");
                return;
            }

            DialogResult = DialogResult.OK;
            Close();
        }

        private void cboxMaxNumChannels_SelectedIndexChanged(object sender, EventArgs e)
        {
            int max = Convert.ToInt32(cboxMaxNumChannels.SelectedItem);

            cboxNumChannels.Items.Clear();
            for (int i = 32; i <= max; i *= 2)
                cboxNumChannels.Items.Add(i.ToString());

            if (detector != null)
            {
                int idx = cboxNumChannels.FindStringExact(detector.NumChannels.ToString());
                if (idx > -1)
                    cboxNumChannels.SelectedItem = cboxNumChannels.Items[idx];
                else
                    cboxNumChannels.SelectedItem = cboxNumChannels.Items[0];
            }
        }        
    }
}
