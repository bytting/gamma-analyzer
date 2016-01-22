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
        public TcpClient Client = null;

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
            
            try
            {
                Client = new TcpClient();
                string ip = tbIP.Text;
                int port = Convert.ToInt32(tbPort.Text);

                Client.Connect(ip, port);
                DialogResult = DialogResult.OK;
                Close();
            }
            catch(Exception ex)
            {
                MessageBox.Show(ex.Message);
            }            
        }
    }
}
