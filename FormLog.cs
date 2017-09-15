/*	
	Gamma Analyzer - Controlling application for Burn
    Copyright (C) 2016  Norwegian Radiation Protection Authority

    This program is free software: you can redistribute it and/or modify
    it under the terms of the GNU General Public License as published by
    the Free Software Foundation, either version 3 of the License, or
    (at your option) any later version.

    This program is distributed in the hope that it will be useful,
    but WITHOUT ANY WARRANTY; without even the implied warranty of
    MERCHANTABILITY or FITNESS FOR A PARTICULAR PURPOSE.  See the
    GNU General Public License for more details.

    You should have received a copy of the GNU General Public License
    along with this program.  If not, see <http://www.gnu.org/licenses/>.
*/
// Authors: Dag robole,

using System;
using System.IO;
using System.ComponentModel;
using System.Text;
using System.Linq;
using System.Windows.Forms;
using log4net;
using log4net.Appender;
using log4net.Repository.Hierarchy;

namespace crash
{
    public partial class FormLog : Form
    {
        private System.Windows.Forms.Timer timer = new System.Windows.Forms.Timer();
        private string LogFileName;
        StreamReader LogReader = null;
        long LogFileOffset = 0;

        public FormLog()
        {
            InitializeComponent();
        }

        private void FormLog_Load(object sender, EventArgs e)
        {
            var rootAppender = ((Hierarchy)LogManager.GetRepository())
                .Root.Appenders.OfType<FileAppender>().FirstOrDefault();

            string LogFileName = rootAppender != null ? rootAppender.File : string.Empty;

            // Fixme: exceptions
            LogReader = new StreamReader(new FileStream(LogFileName, FileMode.Open, FileAccess.Read, FileShare.ReadWrite));
            LogFileOffset = LogReader.BaseStream.Length;
            
            timer.Interval = 100;
            timer.Tick += timer_Tick;
            timer.Start();
        }

        void timer_Tick(object sender, EventArgs e)
        {
            if (LogReader.BaseStream.Length == LogFileOffset)
                return;
            
            LogReader.BaseStream.Seek(LogFileOffset, SeekOrigin.Begin);

            string line = "";
            while ((line = LogReader.ReadLine()) != null)
                lbLog.Items.Insert(0, line);

            LogFileOffset = LogReader.BaseStream.Position;
        }

        private void btnClear_Click(object sender, EventArgs e)
        {
            lbLog.Items.Clear();
        }

        private void FormLog_FormClosing(object sender, FormClosingEventArgs e)
        {
            e.Cancel = true;
            Hide();
        }

        public void Exiting()
        {            
            LogReader.Close();
        }
    }
}
