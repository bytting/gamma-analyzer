/*	
	Crash - Controlling application for Burn
    Copyright (C) 2016  Norwegian Radiation Protection Authority

    This program is free software: you can redistribute it and/or modify
    it under the terms of the GNU General Public License as published by
    the Free Software Foundation, either version 3 of the License, or
    (at your option) any later version.

    This program is distributed in the hope that it will be useful,
    but WITHOUT ANY WARRANTY; without even the implied warranty of
    MERCHANTABILITY or FITNESS FOR A PARTICULAR PURPOSE.  See the
    GNU General Public License for more details.

    You should have received a copy of the GNU General Public License
    along with this program.  If not, see <http://www.gnu.org/licenses/>.
*/
// Authors: Dag robole,

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
