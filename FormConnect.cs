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
    public partial class FormConnect : Form
    {
        private CrashSettings settings;        

        public FormConnect(CrashSettings s)
        {
            InitializeComponent();
            settings = s;
        }

        private void FormConnect_Load(object sender, EventArgs e)
        {
            tbIP.Text = settings.LastIP;
            tbPort.Text = settings.LastPort;
            tbPort.KeyPress += CustomEvents.Integer_KeyPress;
        }

        private void btnCancel_Click(object sender, EventArgs e)
        {
            DialogResult = System.Windows.Forms.DialogResult.Cancel;
            Close();
        }

        private void btnOk_Click(object sender, EventArgs e)
        {
            settings.LastIP = tbIP.Text.Trim();
            settings.LastPort = tbPort.Text.Trim();
            DialogResult = System.Windows.Forms.DialogResult.OK;
            Close();
        }        
    }
}
