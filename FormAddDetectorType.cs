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
        public string GScript { get; set; }

        public FormAddDetectorType()
        {
            InitializeComponent();    
        }

        private void FormAddDetectorType_Load(object sender, EventArgs e)
        {
            tbMaxChannels.KeyPress += CustomEvents.Integer_KeyPress;
            tbMinHV.KeyPress += CustomEvents.Integer_KeyPress;
            tbMaxHV.KeyPress += CustomEvents.Integer_KeyPress;
        }
        
        private void btnCancel_Click(object sender, EventArgs e)
        {
            DialogResult = System.Windows.Forms.DialogResult.Cancel;
            Close();
        }

        private void btnOk_Click(object sender, EventArgs e)
        {
            if (String.IsNullOrEmpty(tbName.Text) 
                || String.IsNullOrEmpty(tbMaxChannels.Text) 
                || String.IsNullOrEmpty(tbMinHV.Text)
                || String.IsNullOrEmpty(tbGScript.Text) 
                || String.IsNullOrEmpty(tbMaxHV.Text))
            {
                MessageBox.Show("One or more required fields missing");
                return;
            }

            try
            {
                TypeName = tbName.Text;
                MaxChannels = Convert.ToInt32(tbMaxChannels.Text);
                MinHV = Convert.ToInt32(tbMinHV.Text);
                MaxHV = Convert.ToInt32(tbMaxHV.Text);
                GScript = tbGScript.Text;
            }
            catch
            {
                MessageBox.Show("Invalid format found");
                return;
            }

            DialogResult = System.Windows.Forms.DialogResult.OK;
            Close();
        }

        private void btnBrowseGScript_Click(object sender, EventArgs e)
        {
            OpenFileDialog dialog = new OpenFileDialog();
            dialog.InitialDirectory = CrashEnvironment.GScriptPath;
            dialog.Filter = "Script Files (.py)|*.py";
            if (dialog.ShowDialog() == System.Windows.Forms.DialogResult.OK)
            {
                tbGScript.Text = dialog.FileName;
            }
        }        
    }
}
