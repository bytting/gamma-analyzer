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
    public partial class FormSetRegressionPoints : Form
    {
        public int SelectedPoint { get; private set; }
        public double SelectedEnergy { get; private set; }

        private double X;

        public FormSetRegressionPoints(double x)
        {
            InitializeComponent();
            X = x;
        }

        private void FormSetRegressionPoints_Load(object sender, EventArgs e)
        {
            rbLow.Checked = true;
            lblX.Text = "Channel selected: " + X.ToString();
        }

        private void btnCancel_Click(object sender, EventArgs e)
        {
            DialogResult = System.Windows.Forms.DialogResult.Cancel;
            Close();
        }

        private void btnOk_Click(object sender, EventArgs e)
        {            
            if(String.IsNullOrEmpty(tbEnergy.Text.Trim()))
            {
                MessageBox.Show("One or more required fileds missing");
                return;
            }

            try
            {
                SelectedEnergy = Convert.ToDouble(tbEnergy.Text);
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
                return;
            }

            SelectedPoint = rbLow.Checked ? 1 : 2;

            DialogResult = System.Windows.Forms.DialogResult.OK;
            Close();
        }

        private void Numeric_KeyPress(object sender, KeyPressEventArgs e)
        {
            char sep = Convert.ToChar(CultureInfo.CurrentCulture.NumberFormat.NumberDecimalSeparator);

            if (!Char.IsNumber(e.KeyChar) && !Char.IsControl(e.KeyChar) && e.KeyChar != sep)
                e.Handled = true;
        }
    }
}
