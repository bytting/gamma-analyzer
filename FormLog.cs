using System;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Windows.Forms;

namespace crash
{
    public partial class FormLog : Form
    {
        public FormLog()
        {
            InitializeComponent();
        }

        private void FormLog_Load(object sender, EventArgs e)
        {

        }

        public void Add(string txt)
        {
            tbLog.Text += Environment.NewLine + DateTime.Now.ToString("yyyy-MM-dd HH:mm:ss") + ": " + txt;            
        }

        private void FormLog_FormClosing(object sender, FormClosingEventArgs e)
        {
            Hide();
            e.Cancel = true;
        }
    }
}
