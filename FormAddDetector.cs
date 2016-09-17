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

            foreach (DetectorType dt in DetectorTypes)
                cboxDetectorTypes.Items.Add(dt);

            if(Det != null)
            {
                int idx = cboxDetectorTypes.FindStringExact(Det.TypeName);
                if (idx != -1)
                    cboxDetectorTypes.SelectedItem = cboxDetectorTypes.Items[idx];
                tbSerialnumber.Text = Det.Serialnumber;
                tbSerialnumber.ReadOnly = true;
                idx = cboxNumChannels.FindStringExact(Det.CurrentNumChannels.ToString());
                if (idx != -1)
                    cboxNumChannels.SelectedItem = cboxNumChannels.Items[idx];
                tbarCurrHV.Value = Det.CurrentHV;
                tbCoarseGain.Text = Det.CurrentCoarseGain.ToString();
                tbFineGain.Text = Det.CurrentFineGain.ToString();
                tbLivetime.Text = Det.CurrentLivetime.ToString();
                tbLLD.Text = Det.CurrentLLD.ToString();
                tbULD.Text = Det.CurrentULD.ToString();
            }
        }
        
        private void btnCancel_Click(object sender, EventArgs e)
        {
            DialogResult = System.Windows.Forms.DialogResult.Cancel;
            Close();
        }

        private void btnOk_Click(object sender, EventArgs e)
        {
            if (String.IsNullOrEmpty(cboxDetectorTypes.Text) 
                || String.IsNullOrEmpty(tbSerialnumber.Text)
                || String.IsNullOrEmpty(cboxNumChannels.Text)                
                || String.IsNullOrEmpty(tbCoarseGain.Text)
                || String.IsNullOrEmpty(tbFineGain.Text)                
                || String.IsNullOrEmpty(tbLivetime.Text)
                || String.IsNullOrEmpty(tbLLD.Text)
                || String.IsNullOrEmpty(tbULD.Text))
            {
                MessageBox.Show("One or more required fields missing");
                return;
            }

            try
            {
                DetectorType = cboxDetectorTypes.Text;
                Serialnumber = tbSerialnumber.Text;
                NumChannels = Convert.ToInt32(cboxNumChannels.Text);
                HV = tbarCurrHV.Value;
                CoarseGain = Convert.ToDouble(tbCoarseGain.Text);
                FineGain = Convert.ToDouble(tbFineGain.Text);                
                Livetime = Convert.ToInt32(tbLivetime.Text);
                LLD = Convert.ToInt32(tbLLD.Text);
                ULD = Convert.ToInt32(tbULD.Text);                
            }
            catch
            {
                MessageBox.Show("Invalid format found");
                return;
            }

            DialogResult = System.Windows.Forms.DialogResult.OK;
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
