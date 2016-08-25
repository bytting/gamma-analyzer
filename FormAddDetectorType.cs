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
        public string TypeName { get; set; }
        public int MaxChannels { get; set; }
        public int MinHV { get; set; }
        public int MaxHV { get; set; }
        public string GEScript { get; set; }

        public FormAddDetectorType()
        {
            InitializeComponent();    
        }

        private void FormAddDetectorType_Load(object sender, EventArgs e)
        {                        
        }
        
        private void btnCancel_Click(object sender, EventArgs e)
        {
            Close();
        }

        private void btnOk_Click(object sender, EventArgs e)
        {
            if (String.IsNullOrEmpty(tbName.Text) 
                || String.IsNullOrEmpty(cboxMaxChannels.Text)                 
                || String.IsNullOrEmpty(tbGScript.Text))
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
                TypeName = tbName.Text;
                MaxChannels = Convert.ToInt32(cboxMaxChannels.Text);
                MinHV = tbarMinHV.Value;
                MaxHV = tbarMaxHV.Value;
                GEScript = tbGScript.Text;
            }
            catch
            {
                MessageBox.Show("Invalid format found");
                return;
            }
            
            Close();
        }

        private void btnBrowseGScript_Click(object sender, EventArgs e)
        {
            OpenFileDialog dialog = new OpenFileDialog();
            dialog.InitialDirectory = CrashEnvironment.GEScriptPath;
            dialog.Filter = "Script Files (.py)|*.py";
            if (dialog.ShowDialog() == System.Windows.Forms.DialogResult.OK)
            {
                tbGScript.Text = dialog.FileName;
            }
        }

        private void tbarMinHV_ValueChanged(object sender, EventArgs e)
        {
            lblMinHV.Text = tbarMinHV.Value.ToString();
        }

        private void tbarMaxHV_ValueChanged(object sender, EventArgs e)
        {
            lblMaxHV.Text = tbarMaxHV.Value.ToString();
        }        
    }
}
