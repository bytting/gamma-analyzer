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
    public partial class FormAskIP : Form
    {
        public string IPAddress;

        public FormAskIP(string defaultIP="")
        {
            InitializeComponent();
            tbIP.Text = defaultIP.Trim();
        }

        private void btnCancel_Click(object sender, EventArgs e)
        {
            DialogResult = DialogResult.Cancel;
            Close();
        }

        private void btnOk_Click(object sender, EventArgs e)
        {
            // FIXME: Sanity checks
            IPAddress = tbIP.Text.Trim();
            DialogResult = DialogResult.OK;
            Close();
        }
    }
}
