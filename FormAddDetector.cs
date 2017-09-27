using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Text;
using System.Windows.Forms;
using System.Globalization;
using log4net;

namespace crash
{
    public partial class FormAddDetector : Form
    {
        ILog Log = null;

        private Detector Det = null;

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

        public FormAddDetector(ILog log, Detector detector)
        {
            InitializeComponent();
            Log = log;
            Det = detector;            
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

            if (Det != null)
            {
                tbTypeName.Text = Det.TypeName;      
                tbSerialnumber.Text = Det.Serialnumber;
                tbSerialnumber.ReadOnly = true;
                int idx = cboxMaxNumChannels.FindStringExact(Det.MaxNumChannels.ToString());
                if (idx > -1)
                    cboxMaxNumChannels.SelectedItem = cboxMaxNumChannels.Items[idx];
                tbMinHV.Text = Det.MinVoltage.ToString();
                tbMaxHV.Text = Det.MaxVoltage.ToString();
                tbHV.Text = Det.Voltage.ToString();
                cboxCoarseGain.SelectedIndex = cboxCoarseGain.FindStringExact(Det.CoarseGain.ToString());
                tbFineGain.Text = Det.FineGain.ToString();
                tbLivetime.Text = Det.Livetime.ToString();
                tbLLD.Text = Det.LLD.ToString();
                tbULD.Text = Det.ULD.ToString();
                tbPluginName.Text = Det.PluginName;
                tbGEScript.Text = Det.GEScript;
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
                Log.Error("Add detector: Invalid number format", ex);
                MessageBox.Show("Invalid number format");
                return;
            }

            if (FineGain < 1.0 || FineGain > 5.0)
            {
                Log.Error("Fine gain out of range");
                MessageBox.Show("Fine gain out of range");
                return;
            }

            if (LLD < 0)
            {
                Log.Error("LLD can not be less than zero");
                MessageBox.Show("LLD can not be less than zero");
                return;
            }

            if (ULD > 130)
            {
                Log.Error("ULD can not be bigger than 130%");
                MessageBox.Show("ULD can not be bigger than 130%");
                return;
            }

            if (LLD > ULD)
            {
                Log.Error("LLD can not be bigger than ULD");
                MessageBox.Show("LLD can not be bigger than ULD");
                return;
            }

            if (HV < MinHV || HV > MaxHV)
            {
                Log.Error("Voltage out of range");
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

            if (Det != null)
            {
                int idx = cboxNumChannels.FindStringExact(Det.NumChannels.ToString());
                if (idx > -1)
                    cboxNumChannels.SelectedItem = cboxNumChannels.Items[idx];
                else
                    cboxNumChannels.SelectedItem = cboxNumChannels.Items[0];
            }
        }        
    }
}
