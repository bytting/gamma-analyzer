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
using log4net;

namespace crash
{
    public partial class FormSessionInfo : Form
    {
        private GASettings settings = null;
        private ILog log = null;
        private Session session = null;

        public FormSessionInfo(GASettings s, ILog l, Session sess, string title)
        {
            InitializeComponent();
            
            settings = s;
            log = l;
            session = sess;
            Text = "Gamma Analyzer - " + title;
        }

        private void FormSessionInfo_Load(object sender, EventArgs e)
        {
            lblName.Text = session.Name + " (" + session.Detector.TypeName + ")";
            lblDetector.Text = session.Detector.Serialnumber;
            lblLivetime.Text = session.Livetime.ToString();
            lblNumChannels.Text = session.NumChannels.ToString();
            lblHV.Text = session.Detector.Voltage.ToString();
            lblCoarseGain.Text = session.Detector.CoarseGain.ToString();
            lblFineGain.Text = session.Detector.FineGain.ToString();
            lblLLDULD.Text = session.Detector.LLD.ToString() + ", " + session.Detector.ULD.ToString();            
            tbComment.Text = session.Comment;
            tbGEFactorCode.Text = session.Detector.GEScript;
        }

        private void btnCancel_Click(object sender, EventArgs e)

        {
            Close();
        }
        private void btnOk_Click(object sender, EventArgs e)
        {
            session.Comment = tbComment.Text;
            Close();
        }        
    }
}
