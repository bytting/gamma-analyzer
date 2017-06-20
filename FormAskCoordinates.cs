using System;
using System.ComponentModel;
using System.Text;
using System.Windows.Forms;
using System.Globalization;

namespace crash
{
    public partial class FormAskCoordinates : Form
    {
        public double Latitude;
        public double Longitude;

        public FormAskCoordinates()
        {
            InitializeComponent();
        }

        private void FormAskCoordinates_Load(object sender, EventArgs e)
        {
            tbLatitude.KeyPress += CustomEvents.Numeric_KeyPress;
            tbLongitude.KeyPress += CustomEvents.Numeric_KeyPress;
        }

        private void btnCancel_Click(object sender, EventArgs e)
        {
            DialogResult = DialogResult.Cancel;
            Close();
        }

        private void btnOk_Click(object sender, EventArgs e)
        {            
            if (String.IsNullOrEmpty(tbLatitude.Text.Trim()) || String.IsNullOrEmpty(tbLongitude.Text.Trim()))
            {
                MessageBox.Show("One or more required fields are empty");
                return;
            }

            Latitude = Convert.ToDouble(tbLatitude.Text.Trim(), CultureInfo.InvariantCulture);
            Longitude = Convert.ToDouble(tbLongitude.Text.Trim(), CultureInfo.InvariantCulture);

            DialogResult = DialogResult.OK;
            Close();
        }        
    }
}
