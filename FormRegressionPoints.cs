using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Globalization;

namespace crash
{
    public partial class FormRegressionPoints : Form
    {        
        Detector detector = null;

        public FormRegressionPoints(Detector det)
        {
            InitializeComponent();        
            detector = det;
        }

        private void FormSetRegressionPoints_Load(object sender, EventArgs e)
        {
            lblDescription.Text = "Detector: " + detector.Serialnumber;

            tbLowChannel.KeyPress += CustomEvents.Integer_KeyPress;
            tbHighChannel.KeyPress += CustomEvents.Integer_KeyPress;
            tbLowEnergy.KeyPress += CustomEvents.Numeric_KeyPress;
            tbHighEnergy.KeyPress += CustomEvents.Numeric_KeyPress;
        }

        private void btnCancel_Click(object sender, EventArgs e)
        {            
            Close();
        }

        private void btnOk_Click(object sender, EventArgs e)
        {            
            if(!String.IsNullOrEmpty(tbLowChannel.Text) && !String.IsNullOrEmpty(tbLowEnergy.Text))            
                detector.RegressionPoint1 = new PointF(Convert.ToSingle(tbLowChannel.Text), Convert.ToSingle(tbLowEnergy.Text));

            if (!String.IsNullOrEmpty(tbHighChannel.Text) && !String.IsNullOrEmpty(tbHighEnergy.Text))
                detector.RegressionPoint2 = new PointF(Convert.ToSingle(tbHighChannel.Text), Convert.ToSingle(tbHighEnergy.Text));                

            Close();
        }

        private void Numeric_KeyPress(object sender, KeyPressEventArgs e)
        {

        }
    }
}
