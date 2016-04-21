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
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace crash
{
    public partial class FormPreferences : Form
    {
        CrashSettings settings;

        public FormPreferences(CrashSettings s)
        {
            InitializeComponent();
            settings = s;
        }

        private void FormPreferences_Load(object sender, EventArgs e)
        {
            tbSessionDir.Text = settings.SessionRootDirectory;
            PopulateDetectorTypeList();
            PopulateDetectorList();
        }

        private void PopulateDetectorTypeList()
        {
            lvDetectorTypes.Items.Clear();
            foreach (DetectorType dt in settings.DetectorTypes)
            {
                ListViewItem item = new ListViewItem(new string[] { dt.Name, dt.MaxNumChannels.ToString(), dt.MinHV.ToString(), dt.MaxHV.ToString(), dt.GScript });
                item.Tag = dt;
                lvDetectorTypes.Items.Add(item);
            }
        }

        private void PopulateDetectorList()
        {
            lvDetectors.Items.Clear();
            foreach (Detector d in settings.Detectors)
            {
                ListViewItem item = new ListViewItem(new string[] {                     
                    d.Serialnumber, 
                    d.TypeName, 
                    d.CurrentNumChannels.ToString(), 
                    d.CurrentHV.ToString(), 
                    d.CurrentCoarseGain.ToString(), 
                    d.CurrentFineGain.ToString(),                    
                    d.CurrentLivetime.ToString(),
                    d.CurrentLLD.ToString(),
                    d.CurrentULD.ToString()
                });
                item.Tag = d;
                lvDetectors.Items.Add(item);
            }
        }

        private void btnCancel_Click(object sender, EventArgs e)
        {
            DialogResult = System.Windows.Forms.DialogResult.Cancel;
            Close();
        }

        private void btnOk_Click(object sender, EventArgs e)
        {
            settings.SessionRootDirectory = tbSessionDir.Text;
            DialogResult = System.Windows.Forms.DialogResult.OK;
            Close();
        }

        private void btnSetSessionDir_Click(object sender, EventArgs e)
        {
            FolderBrowserDialog dialog = new FolderBrowserDialog();
            if (dialog.ShowDialog() == DialogResult.OK)
            {
                tbSessionDir.Text = dialog.SelectedPath;
            }
        }

        private void btnAddDetectorType_Click(object sender, EventArgs e)
        {
            FormAddDetectorType form = new FormAddDetectorType();
            if(form.ShowDialog() == System.Windows.Forms.DialogResult.OK)
            {
                settings.DetectorTypes.Add(new DetectorType(form.TypeName, form.MaxChannels, form.MinHV, form.MaxHV, form.GScript));
                PopulateDetectorTypeList();
            }
        }               

        private void btnAddDetector_Click(object sender, EventArgs e)
        {
            FormAddDetector form = new FormAddDetector(settings.DetectorTypes);
            if (form.ShowDialog() == System.Windows.Forms.DialogResult.OK)
            {
                Detector det = new Detector();
                det.TypeName = form.DetectorType;
                det.Serialnumber = form.Serialnumber;
                det.CurrentNumChannels = form.NumChannels;
                det.CurrentHV = form.HV;
                det.CurrentCoarseGain = form.CoarseGain;
                det.CurrentFineGain = form.FineGain;
                det.CurrentLivetime = form.Livetime;
                det.CurrentLLD = form.LLD;
                det.CurrentULD = form.ULD;
                settings.Detectors.Add(det);

                PopulateDetectorList();
            }
        }
    }
}
