using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Globalization;

namespace crash
{
    public partial class FormAddDetector : Form
    {
        private Detector Det = null;
        private List<DetectorType> DetectorTypes = null;        

        public string DetectorType { get; set; }
        public string Serialnumber { get; set; }
        public int NumChannels { get; set; }
        public int HV { get; set; }
        public double CoarseGain { get; set; }
        public double FineGain { get; set; }        
        public int Livetime { get; set; }
        public int LLD { get; set; }
        public int ULD { get; set; }
        public string PluginName { get; set; }

        public FormAddDetector(Detector detector, List<DetectorType> detectorTypes)
        {
            InitializeComponent();
            Det = detector;
            DetectorTypes = detectorTypes;        
        }

        private void FormAddDetector_Load(object sender, EventArgs e)
        {            
            tbCoarseGain.KeyPress += CustomEvents.Numeric_KeyPress;
            tbFineGain.KeyPress += CustomEvents.Numeric_KeyPress;
            tbLivetime.KeyPress += CustomEvents.Integer_KeyPress;
            tbLLD.KeyPress += CustomEvents.Integer_KeyPress;
            tbULD.KeyPress += CustomEvents.Integer_KeyPress;

            cboxDetectorTypes.Items.AddRange(DetectorTypes.ToArray());

            if(Det != null)
            {
                int idx = cboxDetectorTypes.FindStringExact(Det.TypeName);
                if (idx != -1)
                    cboxDetectorTypes.SelectedItem = cboxDetectorTypes.Items[idx];
                tbSerialnumber.Text = Det.Serialnumber;
                tbSerialnumber.ReadOnly = true;
                idx = cboxNumChannels.FindStringExact(Det.NumChannels.ToString());
                if (idx != -1)
                    cboxNumChannels.SelectedItem = cboxNumChannels.Items[idx];
                tbarCurrHV.Value = (Det.HV == 0) ? 1 : Det.HV;
                tbCoarseGain.Text = Det.CoarseGain.ToString();
                tbFineGain.Text = Det.FineGain.ToString();
                tbLivetime.Text = Det.Livetime.ToString();
                tbLLD.Text = Det.LLD.ToString();
                tbULD.Text = Det.ULD.ToString();
                tbPluginName.Text = Det.PluginName;
            }
        }
        
        private void btnCancel_Click(object sender, EventArgs e)
        {
            DialogResult = DialogResult.Cancel;
            Close();
        }

        private void btnOk_Click(object sender, EventArgs e)
        {
            if (String.IsNullOrEmpty(cboxDetectorTypes.Text.Trim()) 
                || String.IsNullOrEmpty(tbSerialnumber.Text.Trim())
                || String.IsNullOrEmpty(cboxNumChannels.Text.Trim())                
                || String.IsNullOrEmpty(tbCoarseGain.Text.Trim())
                || String.IsNullOrEmpty(tbFineGain.Text.Trim())                
                || String.IsNullOrEmpty(tbLivetime.Text.Trim())
                || String.IsNullOrEmpty(tbLLD.Text.Trim())
                || String.IsNullOrEmpty(tbULD.Text.Trim())
                || String.IsNullOrEmpty(tbPluginName.Text.Trim()))
            {
                MessageBox.Show("One or more required fields missing");
                return;
            }

            try
            {
                DetectorType = cboxDetectorTypes.Text.Trim();
                Serialnumber = tbSerialnumber.Text.Trim();
                NumChannels = Convert.ToInt32(cboxNumChannels.Text.Trim());
                HV = tbarCurrHV.Value;
                CoarseGain = Convert.ToDouble(tbCoarseGain.Text.Trim());
                FineGain = Convert.ToDouble(tbFineGain.Text.Trim());
                Livetime = Convert.ToInt32(tbLivetime.Text.Trim());
                LLD = Convert.ToInt32(tbLLD.Text.Trim());
                ULD = Convert.ToInt32(tbULD.Text.Trim());
                PluginName = tbPluginName.Text.Trim();
            }
            catch
            {
                MessageBox.Show("Invalid format found");
                return;
            }

            DialogResult = DialogResult.OK;
            Close();
        }

        private void cboxDetectorTypes_SelectedIndexChanged(object sender, EventArgs e)
        {
            cboxNumChannels.Items.Clear();
            DetectorType dt = (DetectorType)cboxDetectorTypes.SelectedItem;
            for(int i = 256; i <= dt.MaxNumChannels; i *= 2)            
                cboxNumChannels.Items.Add(i.ToString());            

            tbarCurrHV.Maximum = dt.MaxHV;
            tbarCurrHV.Minimum = dt.MinHV;
            tbarCurrHV.Value = dt.MinHV;
        }

        private void tbarCurrHV_ValueChanged(object sender, EventArgs e)
        {
            lblCurrHV.Text = tbarCurrHV.Value.ToString();
        }                        
    }
}
