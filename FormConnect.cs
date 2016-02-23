using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Net.Sockets;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace crash
{    
    public partial class FormConnect : Form
    {
        public string IP;
        public string Port;

        public FormConnect()
        {
            InitializeComponent();
        }

        private void btnCancel_Click(object sender, EventArgs e)
        {
            DialogResult = DialogResult.Cancel;
            Close();
        }

        private void btnOk_Click(object sender, EventArgs e)
        {            
            if (String.IsNullOrEmpty(tbIP.Text))
            {
                MessageBox.Show("No IP address provided");
                return;
            }

            if (String.IsNullOrEmpty(tbPort.Text))
            {
                MessageBox.Show("No port provided");
                return;
            }

            IP = tbIP.Text;
            Port = tbPort.Text;
            DialogResult = DialogResult.OK;
            Close();                        
        }

        private void FormConnect_Shown(object sender, EventArgs e)
        {
            tbIP.Text = IP;
            tbPort.Text = Port;
        }
    }
}
