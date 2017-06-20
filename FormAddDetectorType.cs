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
    public partial class FormAddDetectorType : Form
    {
        private DetectorType DetType = null;

        public string TypeName { get; set; }
        public int MaxChannels { get; set; }
        public int MinHV { get; set; }
        public int MaxHV { get; set; }
        public string GEScript { get; set; }

        public FormAddDetectorType(DetectorType detType)
        {
            InitializeComponent();
            DetType = detType;
        }

        private void FormAddDetectorType_Load(object sender, EventArgs e)
        {
            if(DetType != null)
            {
                tbName.Text = DetType.Name;
                tbName.ReadOnly = true;
                int idx = cboxMaxChannels.FindStringExact(DetType.MaxNumChannels.ToString());
                if (idx != -1)
                    cboxMaxChannels.SelectedItem = cboxMaxChannels.Items[idx];
                tbarMinHV.Value = DetType.MinHV;
                tbarMaxHV.Value = DetType.MaxHV;
                tbGEScript.Text = DetType.GEScript;
            }
        }

        private void btnCancel_Click(object sender, EventArgs e)
        {
            DialogResult = DialogResult.Cancel;
            Close();
        }

        private void btnOk_Click(object sender, EventArgs e)
        {
            if (String.IsNullOrEmpty(tbName.Text.Trim()) 
                || String.IsNullOrEmpty(cboxMaxChannels.Text.Trim())
                || String.IsNullOrEmpty(tbGEScript.Text.Trim()))
            {
                MessageBox.Show("One or more required fields missing");
                return;
            }

            if(tbarMinHV.Value > tbarMaxHV.Value)
            {
                MessageBox.Show("Min HV can not be bigger than max HV");
                return;
            }

            try
            {
                TypeName = tbName.Text.Trim();
                MaxChannels = Convert.ToInt32(cboxMaxChannels.Text.Trim());
                MinHV = tbarMinHV.Value;
                MaxHV = tbarMaxHV.Value;
                GEScript = tbGEScript.Text.Trim();
            }
            catch
            {
                MessageBox.Show("Invalid format found");
                return;
            }

            DialogResult = DialogResult.OK;
            Close();
        }

        private void tbarMinHV_ValueChanged(object sender, EventArgs e)
        {
            lblMinHV.Text = tbarMinHV.Value.ToString();
        }

        private void tbarMaxHV_ValueChanged(object sender, EventArgs e)
        {
            lblMaxHV.Text = tbarMaxHV.Value.ToString();
        }

        private void btnBrowseGEScript_Click(object sender, EventArgs e)
        {
            OpenFileDialog dialog = new OpenFileDialog();
            dialog.InitialDirectory = GAEnvironment.GEScriptPath;
            if(dialog.ShowDialog() == DialogResult.OK)
                tbGEScript.Text = dialog.SafeFileName;
        }                
    }
}
