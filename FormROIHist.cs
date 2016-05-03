using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using ZedGraph;

namespace crash
{
    public partial class FormROIHist : Form
    {
        List<ROIData> ROIList = null;        
        List<PointPairList> pointLists = new List<PointPairList>();
        GraphPane pane = null;        

        public FormROIHist(List<ROIData> roiList)
        {
            InitializeComponent();
            ROIList = roiList;
            pane = graph.GraphPane;
            //pane.YAxis.Type = AxisType.Log;
            UpdateROIList();
        }

        private void FormROIHist_Load(object sender, EventArgs e)
        {                                    
        }        

        public void UpdateROIList()
        {
            pointLists.Clear();
            foreach (ROIData rd in ROIList)
            {
                if (!rd.Active)
                    continue;

                PointPairList list = new PointPairList();
                pointLists.Add(list);
                LineItem line = pane.AddCurve(rd.Name, list, Color.FromName(rd.ColorName), SymbolType.None);
                line.Line.IsSmooth = true;
                line.Line.SmoothTension = 0.5f;
            }
        }        

        public void AddSpectrum(Spectrum spec)
        {
            for(int i=0; i<ROIList.Count; i++)
            {
                if (!ROIList[i].Active)
                    continue;

                float cnt = spec.GetCountInROI((int)ROIList[i].StartChannel, (int)ROIList[i].EndChannel);        

                pointLists[i].Add(pointLists[i].Count, cnt);
            }
            graph.AxisChange();
        }        

        public void Clear()
        {
            foreach (PointPairList list in pointLists)
                list.Clear();        
        }

        public void RestoreScale()
        {            
            graph.RestoreScale(pane);                                    
        }

        private void FormROIHist_FormClosing(object sender, FormClosingEventArgs e)
        {
            e.Cancel = true;
            Hide();
        }

        private void pane_Resize(object sender, EventArgs e)
        {            
        }
    }
}
