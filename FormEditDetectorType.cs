using System;
using System.IO;
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
    public partial class FormEditDetectorType : Form
    {
        DetectorType DetType = null;

        public FormEditDetectorType(DetectorType detType)
        {
            InitializeComponent();
            DetType = detType;
        }

        private void FormEditDetectorType_Load(object sender, EventArgs e)
        {
            tbName.Text = DetType.Name;
        }

        private void btnCancel_Click(object sender, EventArgs e)
        {
            DialogResult = System.Windows.Forms.DialogResult.Cancel;
            Close();
        }

        private void btnOk_Click(object sender, EventArgs e)
        {            
            // FIXME: more fields
            DetType.GEScript = tbGEScript.Text.Trim();
            DialogResult = System.Windows.Forms.DialogResult.OK;
            Close();
        }

        private void btnBrowseGEScript_Click(object sender, EventArgs e)
        {
            OpenFileDialog dialog = new OpenFileDialog();
            dialog.InitialDirectory = CrashEnvironment.GEScriptPath;
            if (dialog.ShowDialog() == System.Windows.Forms.DialogResult.OK)
                tbGEScript.Text = dialog.SafeFileName;
        }        
    }
}
