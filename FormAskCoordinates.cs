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
            // FIXME: conversion and sanity checks
            Latitude = Convert.ToDouble(tbLatitude.Text.Trim());
            Longitude = Convert.ToDouble(tbLongitude.Text.Trim());
            DialogResult = DialogResult.OK;
            Close();
        }        
    }
}
