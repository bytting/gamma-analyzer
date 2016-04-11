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
    public partial class FormAddDetectorType : Form
    {
        public string Name { get; set; }
        public int MaxChannels { get; set; }
        public int MinHV { get; set; }
        public int MaxHV { get; set; }

        public FormAddDetectorType()
        {
            InitializeComponent();
        }

        private void btnCancel_Click(object sender, EventArgs e)
        {
            DialogResult = System.Windows.Forms.DialogResult.Cancel;
            Close();
        }

        private void btnOk_Click(object sender, EventArgs e)
        {
            if (String.IsNullOrEmpty(tbName.Text) 
                || String.IsNullOrEmpty(tbMaxChannels.Text) 
                || String.IsNullOrEmpty(tbMinHV.Text) 
                || String.IsNullOrEmpty(tbMaxHV.Text))
            {
                MessageBox.Show("One or more required fields missing");
                return;
            }

            try
            {
                Name = tbName.Text;
                MaxChannels = Convert.ToInt32(tbMaxChannels.Text);
                MinHV = Convert.ToInt32(tbMinHV.Text);
                MaxHV = Convert.ToInt32(tbMaxHV.Text);
            }
            catch
            {
                MessageBox.Show("Invalid format found");
                return;
            }

            DialogResult = System.Windows.Forms.DialogResult.OK;
            Close();
        }
    }
}
