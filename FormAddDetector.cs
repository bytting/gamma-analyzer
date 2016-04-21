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

        public FormAddDetector(List<DetectorType> detectorTypes)
        {
            InitializeComponent();
            DetectorTypes = detectorTypes;        
        }

        private void FormAddDetector_Load(object sender, EventArgs e)
        {
            foreach (DetectorType dt in DetectorTypes)
            {
                cboxDetectorTypes.Items.Add(dt.Name);
            }
        }

        private void Numeric_KeyPress(object sender, KeyPressEventArgs e)
        {
            char sep = Convert.ToChar(CultureInfo.CurrentCulture.NumberFormat.NumberDecimalSeparator);

            if (!Char.IsNumber(e.KeyChar) && !Char.IsControl(e.KeyChar) && e.KeyChar != sep)
                e.Handled = true;
        }

        private void Integer_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (!Char.IsNumber(e.KeyChar) && !Char.IsControl(e.KeyChar))
                e.Handled = true;
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
                || String.IsNullOrEmpty(tbHV.Text)
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
                HV = Convert.ToInt32(tbHV.Text);
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
    }
}
