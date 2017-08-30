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
    public partial class FormSessionInfo : Form
    {
        private Session session = null;

        public FormSessionInfo(Session sess, string title)
        {
            InitializeComponent();
            Text = "Gamma Analyzer - " + title;
            session = sess;
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
