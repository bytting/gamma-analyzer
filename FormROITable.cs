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
    public partial class FormROITable : Form
    {
        private List<ROIData> ROIList = null;

        public FormROITable(List<ROIData> roiList)
        {
            InitializeComponent();
            ROIList = roiList;
        }

        private void FormROITable_Load(object sender, EventArgs e)
        {
            tbStart1.KeyPress += CustomEvents.Integer_KeyPress;
            tbStart2.KeyPress += CustomEvents.Integer_KeyPress;
            tbStart3.KeyPress += CustomEvents.Integer_KeyPress;
            tbStart4.KeyPress += CustomEvents.Integer_KeyPress;
            tbStart5.KeyPress += CustomEvents.Integer_KeyPress;
            tbStart6.KeyPress += CustomEvents.Integer_KeyPress;
            tbStart7.KeyPress += CustomEvents.Integer_KeyPress;
            tbStart8.KeyPress += CustomEvents.Integer_KeyPress;

            tbEnd1.KeyPress += CustomEvents.Integer_KeyPress;
            tbEnd2.KeyPress += CustomEvents.Integer_KeyPress;
            tbEnd3.KeyPress += CustomEvents.Integer_KeyPress;
            tbEnd4.KeyPress += CustomEvents.Integer_KeyPress;
            tbEnd5.KeyPress += CustomEvents.Integer_KeyPress;
            tbEnd6.KeyPress += CustomEvents.Integer_KeyPress;
            tbEnd7.KeyPress += CustomEvents.Integer_KeyPress;
            tbEnd8.KeyPress += CustomEvents.Integer_KeyPress;

            for(int i=0; i<ROIList.Count; i++)
            {
                ((TextBox)tableLayoutROI.GetControlFromPosition(0, i + 1)).Text = ROIList[i].Name;
                ((TextBox)tableLayoutROI.GetControlFromPosition(1, i + 1)).Text = ROIList[i].StartChannel.ToString();
                ((TextBox)tableLayoutROI.GetControlFromPosition(2, i + 1)).Text = ROIList[i].EndChannel.ToString();
                ((CheckBox)tableLayoutROI.GetControlFromPosition(3, i + 1)).Checked = ROIList[i].Active;
            }            
        }        

        private void btnOk_Click(object sender, EventArgs e)
        {
            ROIList.Clear();
            if(!String.IsNullOrEmpty(tbName1.Text) && !String.IsNullOrEmpty(tbStart1.Text) && !String.IsNullOrEmpty(tbEnd1.Text))
                ROIList.Add(new ROIData(tbName1.Text, Convert.ToInt32(tbStart1.Text), Convert.ToInt32(tbEnd1.Text), cbActive1.Checked, KnownColor.Red.ToString()));
            if(!String.IsNullOrEmpty(tbName2.Text) && !String.IsNullOrEmpty(tbStart2.Text) && !String.IsNullOrEmpty(tbEnd2.Text))
                ROIList.Add(new ROIData(tbName2.Text, Convert.ToInt32(tbStart2.Text), Convert.ToInt32(tbEnd2.Text), cbActive2.Checked, KnownColor.Blue.ToString()));
            if(!String.IsNullOrEmpty(tbName3.Text) && !String.IsNullOrEmpty(tbStart3.Text) && !String.IsNullOrEmpty(tbEnd3.Text))
                ROIList.Add(new ROIData(tbName3.Text, Convert.ToInt32(tbStart3.Text), Convert.ToInt32(tbEnd3.Text), cbActive3.Checked, KnownColor.Green.ToString()));
            if(!String.IsNullOrEmpty(tbName4.Text) && !String.IsNullOrEmpty(tbStart4.Text) && !String.IsNullOrEmpty(tbEnd4.Text))
                ROIList.Add(new ROIData(tbName4.Text, Convert.ToInt32(tbStart4.Text), Convert.ToInt32(tbEnd4.Text), cbActive4.Checked, KnownColor.Lime.ToString()));
            if(!String.IsNullOrEmpty(tbName5.Text) && !String.IsNullOrEmpty(tbStart5.Text) && !String.IsNullOrEmpty(tbEnd5.Text))
                ROIList.Add(new ROIData(tbName5.Text, Convert.ToInt32(tbStart5.Text), Convert.ToInt32(tbEnd5.Text), cbActive5.Checked, KnownColor.Yellow.ToString()));
            if(!String.IsNullOrEmpty(tbName6.Text) && !String.IsNullOrEmpty(tbStart6.Text) && !String.IsNullOrEmpty(tbEnd6.Text))
                ROIList.Add(new ROIData(tbName6.Text, Convert.ToInt32(tbStart6.Text), Convert.ToInt32(tbEnd6.Text), cbActive6.Checked, KnownColor.Aqua.ToString()));
            if(!String.IsNullOrEmpty(tbName7.Text) && !String.IsNullOrEmpty(tbStart7.Text) && !String.IsNullOrEmpty(tbEnd7.Text))
                ROIList.Add(new ROIData(tbName7.Text, Convert.ToInt32(tbStart7.Text), Convert.ToInt32(tbEnd7.Text), cbActive7.Checked, KnownColor.Fuchsia.ToString()));
            if(!String.IsNullOrEmpty(tbName8.Text) && !String.IsNullOrEmpty(tbStart8.Text) && !String.IsNullOrEmpty(tbEnd8.Text))
                ROIList.Add(new ROIData(tbName8.Text, Convert.ToInt32(tbStart8.Text), Convert.ToInt32(tbEnd8.Text), cbActive8.Checked, KnownColor.Maroon.ToString()));
        }
    }
}
