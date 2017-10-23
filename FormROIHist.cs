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
using System.Drawing;
using System.Text;
using System.Windows.Forms;
using ZedGraph;
using log4net;

namespace crash
{
    public partial class FormROIHist : Form
    {
        private GASettings settings = null;
        private ILog log = null;

        private Session session = null;
        private List<PointPairList> pointLists = new List<PointPairList>();
        private GraphPane pane = null;        

        public FormROIHist(GASettings s, ILog l, Session sess)
        {
            InitializeComponent();

            settings = s;
            log = l;
            session = sess;
        }

        private void FormROIHist_Load(object sender, EventArgs e)
        {
            pane = graph.GraphPane;
            //pane.YAxis.Type = AxisType.Log;
            UpdateROIList();                     
        }        

        public void UpdateROIList()
        {
            foreach (PointPairList list in pointLists)
                list.Clear();        

            pointLists.Clear();

            if (session == null || settings.ROIList.Count == 0)
                return;

            foreach (ROIData rd in settings.ROIList)
            {
                if (!rd.Active)
                    continue;

                if(rd.StartChannel < 0 || rd.StartChannel >= session.NumChannels || rd.EndChannel < 0 || rd.EndChannel >= session.NumChannels)
                {
                    log.Warn("ROI entry " + rd.Name + " is outside spectrum");
                    continue;
                }

                int i = 0;
                PointPairList list = new PointPairList();
                foreach (Spectrum spec in session.Spectrums)
                {
                    float cnt = spec.GetCountInROI((int)rd.StartChannel, (int)rd.EndChannel);
                    list.Add(i, cnt);
                    i++;
                }

                LineItem line = pane.AddCurve(rd.Name, list, Color.FromName(rd.ColorName), SymbolType.None);
                line.Line.IsSmooth = true;
                line.Line.SmoothTension = 0.5f;
            }

            graph.AxisChange();
            graph.RestoreScale(pane);
        }        
    }
}
