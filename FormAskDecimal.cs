/*	
	Gamma Analyzer - Controlling application for Burn
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
using System.ComponentModel;
using System.Text;
using System.Windows.Forms;
using System.Globalization;

namespace crash
{
    public partial class FormAskDecimal : Form
    {
        private string description;

        public double Value;

        public FormAskDecimal(string desc, double? defaultValue)
        {
            InitializeComponent();
            description = desc;
            if(defaultValue != null)
                tbValue.Text = defaultValue.ToString();
            tbValue.KeyPress += CustomEvents.Numeric_KeyPress;
        }

        private void FormAskDecimal_Load(object sender, EventArgs e)
        {
            lblDescription.Text = description;
        }

        private void btnCancel_Click(object sender, EventArgs e)
        {
            DialogResult = DialogResult.Cancel;
            Close();
        }

        private void btnOk_Click(object sender, EventArgs e)
        {
            Value = Convert.ToDouble(tbValue.Text.Trim(), CultureInfo.CurrentCulture);
            DialogResult = DialogResult.OK;
            Close();
        }        
    }
}
