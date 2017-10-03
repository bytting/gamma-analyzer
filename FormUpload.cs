using System;
using System.Collections.Generic;
using System.Collections.Concurrent;
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
        ConcurrentQueue<Spectrum> sendq = null;

        public FormUpload(ILog log, ConcurrentQueue<Spectrum> sendQueue)
        {
            InitializeComponent();
            Log = log;
            sendq = sendQueue;
        }

        public string GetHostname()
        {
            return tbHostname.Text.Trim();
        }

        private void btnUploadSession_Click(object sender, EventArgs e)
        {
            OpenFileDialog dialog = new OpenFileDialog();
            if (dialog.ShowDialog() != DialogResult.OK)
                return;

            Session session = DB.LoadSessionFile(Log, dialog.FileName);

            foreach(Spectrum spec in session.Spectrums)
            {
                sendq.Enqueue(spec);
            }
        }

        private void btnClose_Click(object sender, EventArgs e)
        {
            Close();
        }
    }
}
