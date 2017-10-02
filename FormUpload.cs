using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using log4net;

namespace crash
{
    public partial class FormUpload : Form
    {
        ILog Log = null;

        public FormUpload(ILog log)
        {
            InitializeComponent();
            Log = log;
        }

        public string GetHostname()
        {
            return tbHostname.Text.Trim();
        }
    }
}
