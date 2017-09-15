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
        Session session = null;
        List<ROIData> ROIList = null;        
        List<PointPairList> pointLists = new List<PointPairList>();
        GraphPane pane = null;        

        public FormROIHist(Session sess, List<ROIData> roiList)
        {
            InitializeComponent();
            session = sess;
            ROIList = roiList;            
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

            if (session == null || ROIList.Count == 0)
                return;

            foreach (ROIData rd in ROIList)
            {
                if (!rd.Active)
                    continue;

                if(rd.StartChannel < 0 || rd.StartChannel >= session.NumChannels || rd.EndChannel < 0 || rd.EndChannel >= session.NumChannels)
                {
                    Utils.Log.Warn("ROI entry " + rd.Name + " is outside spectrum");
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
