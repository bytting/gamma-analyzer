﻿/*	
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
// Authors: Dag Robole,

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