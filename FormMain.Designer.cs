namespace crash
{
    partial class FormMain
    {
        /// <summary>
        /// Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Clean up any resources being used.
        /// </summary>
        /// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows Form Designer generated code

        /// <summary>
        /// Required method for Designer support - do not modify
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(FormMain));
            this.menu = new System.Windows.Forms.MenuStrip();
            this.menuItemFile = new System.Windows.Forms.ToolStripMenuItem();
            this.menuItemConnect = new System.Windows.Forms.ToolStripMenuItem();
            this.menuItemDisconnect = new System.Windows.Forms.ToolStripMenuItem();
            this.toolStripSeparator1 = new System.Windows.Forms.ToolStripSeparator();
            this.menuItemExit = new System.Windows.Forms.ToolStripMenuItem();
            this.status = new System.Windows.Forms.StatusStrip();
            this.statusLabel = new System.Windows.Forms.ToolStripStatusLabel();
            this.tools = new System.Windows.Forms.ToolStrip();
            this.btnConnect = new System.Windows.Forms.ToolStripButton();
            this.btnDisconnect = new System.Windows.Forms.ToolStripButton();
            this.lblConnectionStatus = new System.Windows.Forms.ToolStripLabel();
            this.tabs = new System.Windows.Forms.TabControl();
            this.pageSettings = new System.Windows.Forms.TabPage();
            this.btnSetGain = new System.Windows.Forms.Button();
            this.btnGetPreview = new System.Windows.Forms.Button();
            this.btnSendFix = new System.Windows.Forms.Button();
            this.btnStopNetService = new System.Windows.Forms.Button();
            this.btnSendSession = new System.Windows.Forms.Button();
            this.btnSendClose = new System.Windows.Forms.Button();
            this.btnSendHello = new System.Windows.Forms.Button();
            this.tbLog = new System.Windows.Forms.TextBox();
            this.pageSpectrometry = new System.Windows.Forms.TabPage();
            this.tbSpecCount = new System.Windows.Forms.TextBox();
            this.tbSpecLivetime = new System.Windows.Forms.TextBox();
            this.panel1 = new System.Windows.Forms.Panel();
            this.panel2 = new System.Windows.Forms.Panel();
            this.tbVoltage = new System.Windows.Forms.TextBox();
            this.tbCoarseGain = new System.Windows.Forms.TextBox();
            this.tbFineGain = new System.Windows.Forms.TextBox();
            this.menu.SuspendLayout();
            this.status.SuspendLayout();
            this.tools.SuspendLayout();
            this.tabs.SuspendLayout();
            this.pageSettings.SuspendLayout();
            this.panel1.SuspendLayout();
            this.panel2.SuspendLayout();
            this.SuspendLayout();
            // 
            // menu
            // 
            this.menu.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.menuItemFile});
            this.menu.Location = new System.Drawing.Point(0, 0);
            this.menu.Name = "menu";
            this.menu.Padding = new System.Windows.Forms.Padding(8, 2, 0, 2);
            this.menu.Size = new System.Drawing.Size(1129, 24);
            this.menu.TabIndex = 0;
            this.menu.Text = "menuStrip1";
            // 
            // menuItemFile
            // 
            this.menuItemFile.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.menuItemConnect,
            this.menuItemDisconnect,
            this.toolStripSeparator1,
            this.menuItemExit});
            this.menuItemFile.Name = "menuItemFile";
            this.menuItemFile.Size = new System.Drawing.Size(37, 20);
            this.menuItemFile.Text = "&File";
            // 
            // menuItemConnect
            // 
            this.menuItemConnect.Name = "menuItemConnect";
            this.menuItemConnect.Size = new System.Drawing.Size(133, 22);
            this.menuItemConnect.Text = "&Connect";
            this.menuItemConnect.Click += new System.EventHandler(this.menuItemConnect_Click);
            // 
            // menuItemDisconnect
            // 
            this.menuItemDisconnect.Name = "menuItemDisconnect";
            this.menuItemDisconnect.Size = new System.Drawing.Size(133, 22);
            this.menuItemDisconnect.Text = "&Disconnect";
            this.menuItemDisconnect.Click += new System.EventHandler(this.menuItemDisconnect_Click);
            // 
            // toolStripSeparator1
            // 
            this.toolStripSeparator1.Name = "toolStripSeparator1";
            this.toolStripSeparator1.Size = new System.Drawing.Size(130, 6);
            // 
            // menuItemExit
            // 
            this.menuItemExit.Name = "menuItemExit";
            this.menuItemExit.Size = new System.Drawing.Size(133, 22);
            this.menuItemExit.Text = "E&xit";
            this.menuItemExit.Click += new System.EventHandler(this.menuItemExit_Click);
            // 
            // status
            // 
            this.status.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.statusLabel});
            this.status.Location = new System.Drawing.Point(0, 690);
            this.status.Name = "status";
            this.status.Padding = new System.Windows.Forms.Padding(1, 0, 19, 0);
            this.status.Size = new System.Drawing.Size(1129, 22);
            this.status.TabIndex = 1;
            this.status.Text = "statusStrip1";
            // 
            // statusLabel
            // 
            this.statusLabel.Name = "statusLabel";
            this.statusLabel.Size = new System.Drawing.Size(0, 17);
            // 
            // tools
            // 
            this.tools.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.btnConnect,
            this.btnDisconnect,
            this.lblConnectionStatus});
            this.tools.Location = new System.Drawing.Point(0, 24);
            this.tools.Name = "tools";
            this.tools.Size = new System.Drawing.Size(1129, 25);
            this.tools.TabIndex = 2;
            this.tools.Text = "toolStrip1";
            // 
            // btnConnect
            // 
            this.btnConnect.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image;
            this.btnConnect.Image = ((System.Drawing.Image)(resources.GetObject("btnConnect.Image")));
            this.btnConnect.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.btnConnect.Name = "btnConnect";
            this.btnConnect.Size = new System.Drawing.Size(23, 22);
            this.btnConnect.Text = "toolStripButton1";
            this.btnConnect.Click += new System.EventHandler(this.menuItemConnect_Click);
            // 
            // btnDisconnect
            // 
            this.btnDisconnect.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image;
            this.btnDisconnect.Image = ((System.Drawing.Image)(resources.GetObject("btnDisconnect.Image")));
            this.btnDisconnect.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.btnDisconnect.Name = "btnDisconnect";
            this.btnDisconnect.Size = new System.Drawing.Size(23, 22);
            this.btnDisconnect.Text = "toolStripButton1";
            this.btnDisconnect.Click += new System.EventHandler(this.menuItemDisconnect_Click);
            // 
            // lblConnectionStatus
            // 
            this.lblConnectionStatus.Alignment = System.Windows.Forms.ToolStripItemAlignment.Right;
            this.lblConnectionStatus.Name = "lblConnectionStatus";
            this.lblConnectionStatus.Size = new System.Drawing.Size(130, 22);
            this.lblConnectionStatus.Text = "<lblConnectionStatus>";
            // 
            // tabs
            // 
            this.tabs.Controls.Add(this.pageSettings);
            this.tabs.Controls.Add(this.pageSpectrometry);
            this.tabs.Dock = System.Windows.Forms.DockStyle.Fill;
            this.tabs.Location = new System.Drawing.Point(0, 49);
            this.tabs.Margin = new System.Windows.Forms.Padding(5, 4, 5, 4);
            this.tabs.Name = "tabs";
            this.tabs.SelectedIndex = 0;
            this.tabs.Size = new System.Drawing.Size(1129, 641);
            this.tabs.TabIndex = 3;
            // 
            // pageSettings
            // 
            this.pageSettings.BackColor = System.Drawing.SystemColors.ButtonFace;
            this.pageSettings.Controls.Add(this.tbFineGain);
            this.pageSettings.Controls.Add(this.tbCoarseGain);
            this.pageSettings.Controls.Add(this.tbVoltage);
            this.pageSettings.Controls.Add(this.tbSpecLivetime);
            this.pageSettings.Controls.Add(this.tbSpecCount);
            this.pageSettings.Controls.Add(this.btnSetGain);
            this.pageSettings.Controls.Add(this.btnGetPreview);
            this.pageSettings.Controls.Add(this.panel2);
            this.pageSettings.Controls.Add(this.panel1);
            this.pageSettings.Controls.Add(this.tbLog);
            this.pageSettings.Location = new System.Drawing.Point(4, 25);
            this.pageSettings.Margin = new System.Windows.Forms.Padding(5, 4, 5, 4);
            this.pageSettings.Name = "pageSettings";
            this.pageSettings.Padding = new System.Windows.Forms.Padding(5, 4, 5, 4);
            this.pageSettings.Size = new System.Drawing.Size(1121, 612);
            this.pageSettings.TabIndex = 0;
            this.pageSettings.Text = "Settings";
            // 
            // btnSetGain
            // 
            this.btnSetGain.Location = new System.Drawing.Point(239, 8);
            this.btnSetGain.Name = "btnSetGain";
            this.btnSetGain.Size = new System.Drawing.Size(101, 28);
            this.btnSetGain.TabIndex = 7;
            this.btnSetGain.Text = "Set gain";
            this.btnSetGain.UseVisualStyleBackColor = true;
            this.btnSetGain.Click += new System.EventHandler(this.btnSetGain_Click);
            // 
            // btnGetPreview
            // 
            this.btnGetPreview.Location = new System.Drawing.Point(239, 60);
            this.btnGetPreview.Name = "btnGetPreview";
            this.btnGetPreview.Size = new System.Drawing.Size(101, 28);
            this.btnGetPreview.TabIndex = 6;
            this.btnGetPreview.Text = "Get preview";
            this.btnGetPreview.UseVisualStyleBackColor = true;
            this.btnGetPreview.Click += new System.EventHandler(this.btnGetPreview_Click);
            // 
            // btnSendFix
            // 
            this.btnSendFix.Dock = System.Windows.Forms.DockStyle.Top;
            this.btnSendFix.Location = new System.Drawing.Point(0, 56);
            this.btnSendFix.Margin = new System.Windows.Forms.Padding(5, 4, 5, 4);
            this.btnSendFix.Name = "btnSendFix";
            this.btnSendFix.Size = new System.Drawing.Size(129, 28);
            this.btnSendFix.TabIndex = 5;
            this.btnSendFix.Text = "Get fix";
            this.btnSendFix.UseVisualStyleBackColor = true;
            this.btnSendFix.Click += new System.EventHandler(this.btnSendFix_Click);
            // 
            // btnStopNetService
            // 
            this.btnStopNetService.Dock = System.Windows.Forms.DockStyle.Top;
            this.btnStopNetService.Location = new System.Drawing.Point(0, 28);
            this.btnStopNetService.Margin = new System.Windows.Forms.Padding(5, 4, 5, 4);
            this.btnStopNetService.Name = "btnStopNetService";
            this.btnStopNetService.Size = new System.Drawing.Size(129, 28);
            this.btnStopNetService.TabIndex = 4;
            this.btnStopNetService.Text = "Stop service";
            this.btnStopNetService.UseVisualStyleBackColor = true;
            this.btnStopNetService.Click += new System.EventHandler(this.btnStopNetService_Click);
            // 
            // btnSendSession
            // 
            this.btnSendSession.Dock = System.Windows.Forms.DockStyle.Top;
            this.btnSendSession.Location = new System.Drawing.Point(0, 28);
            this.btnSendSession.Margin = new System.Windows.Forms.Padding(5, 4, 5, 4);
            this.btnSendSession.Name = "btnSendSession";
            this.btnSendSession.Size = new System.Drawing.Size(132, 28);
            this.btnSendSession.TabIndex = 3;
            this.btnSendSession.Text = "New session";
            this.btnSendSession.UseVisualStyleBackColor = true;
            this.btnSendSession.Click += new System.EventHandler(this.btnSendSession_Click);
            // 
            // btnSendClose
            // 
            this.btnSendClose.Dock = System.Windows.Forms.DockStyle.Top;
            this.btnSendClose.Location = new System.Drawing.Point(0, 0);
            this.btnSendClose.Margin = new System.Windows.Forms.Padding(5, 4, 5, 4);
            this.btnSendClose.Name = "btnSendClose";
            this.btnSendClose.Size = new System.Drawing.Size(129, 28);
            this.btnSendClose.TabIndex = 2;
            this.btnSendClose.Text = "Send close";
            this.btnSendClose.UseVisualStyleBackColor = true;
            this.btnSendClose.Click += new System.EventHandler(this.btnSendClose_Click);
            // 
            // btnSendHello
            // 
            this.btnSendHello.Dock = System.Windows.Forms.DockStyle.Top;
            this.btnSendHello.Location = new System.Drawing.Point(0, 0);
            this.btnSendHello.Margin = new System.Windows.Forms.Padding(5, 4, 5, 4);
            this.btnSendHello.Name = "btnSendHello";
            this.btnSendHello.Size = new System.Drawing.Size(132, 28);
            this.btnSendHello.TabIndex = 1;
            this.btnSendHello.Text = "Send hello";
            this.btnSendHello.UseVisualStyleBackColor = true;
            this.btnSendHello.Click += new System.EventHandler(this.btnSendHello_Click);
            // 
            // tbLog
            // 
            this.tbLog.Dock = System.Windows.Forms.DockStyle.Bottom;
            this.tbLog.Location = new System.Drawing.Point(5, 112);
            this.tbLog.Margin = new System.Windows.Forms.Padding(5, 4, 5, 4);
            this.tbLog.Multiline = true;
            this.tbLog.Name = "tbLog";
            this.tbLog.ScrollBars = System.Windows.Forms.ScrollBars.Both;
            this.tbLog.Size = new System.Drawing.Size(1111, 496);
            this.tbLog.TabIndex = 0;
            // 
            // pageSpectrometry
            // 
            this.pageSpectrometry.BackColor = System.Drawing.SystemColors.ButtonFace;
            this.pageSpectrometry.Location = new System.Drawing.Point(4, 25);
            this.pageSpectrometry.Margin = new System.Windows.Forms.Padding(5, 4, 5, 4);
            this.pageSpectrometry.Name = "pageSpectrometry";
            this.pageSpectrometry.Padding = new System.Windows.Forms.Padding(5, 4, 5, 4);
            this.pageSpectrometry.Size = new System.Drawing.Size(1121, 612);
            this.pageSpectrometry.TabIndex = 1;
            this.pageSpectrometry.Text = "Spectrometry";
            // 
            // tbSpecCount
            // 
            this.tbSpecCount.Location = new System.Drawing.Point(358, 63);
            this.tbSpecCount.Name = "tbSpecCount";
            this.tbSpecCount.Size = new System.Drawing.Size(100, 23);
            this.tbSpecCount.TabIndex = 8;
            // 
            // tbSpecLivetime
            // 
            this.tbSpecLivetime.Location = new System.Drawing.Point(464, 63);
            this.tbSpecLivetime.Name = "tbSpecLivetime";
            this.tbSpecLivetime.Size = new System.Drawing.Size(100, 23);
            this.tbSpecLivetime.TabIndex = 9;
            // 
            // panel1
            // 
            this.panel1.Controls.Add(this.btnSendFix);
            this.panel1.Controls.Add(this.btnStopNetService);
            this.panel1.Controls.Add(this.btnSendClose);
            this.panel1.Dock = System.Windows.Forms.DockStyle.Right;
            this.panel1.Location = new System.Drawing.Point(987, 4);
            this.panel1.Name = "panel1";
            this.panel1.Size = new System.Drawing.Size(129, 108);
            this.panel1.TabIndex = 10;
            // 
            // panel2
            // 
            this.panel2.Controls.Add(this.btnSendSession);
            this.panel2.Controls.Add(this.btnSendHello);
            this.panel2.Dock = System.Windows.Forms.DockStyle.Left;
            this.panel2.Location = new System.Drawing.Point(5, 4);
            this.panel2.Name = "panel2";
            this.panel2.Size = new System.Drawing.Size(132, 108);
            this.panel2.TabIndex = 11;
            // 
            // tbVoltage
            // 
            this.tbVoltage.Location = new System.Drawing.Point(358, 8);
            this.tbVoltage.Name = "tbVoltage";
            this.tbVoltage.Size = new System.Drawing.Size(100, 23);
            this.tbVoltage.TabIndex = 12;
            // 
            // tbCoarseGain
            // 
            this.tbCoarseGain.Location = new System.Drawing.Point(465, 8);
            this.tbCoarseGain.Name = "tbCoarseGain";
            this.tbCoarseGain.Size = new System.Drawing.Size(100, 23);
            this.tbCoarseGain.TabIndex = 13;
            // 
            // tbFineGain
            // 
            this.tbFineGain.Location = new System.Drawing.Point(571, 8);
            this.tbFineGain.Name = "tbFineGain";
            this.tbFineGain.Size = new System.Drawing.Size(100, 23);
            this.tbFineGain.TabIndex = 14;
            // 
            // FormMain
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(1129, 712);
            this.Controls.Add(this.tabs);
            this.Controls.Add(this.tools);
            this.Controls.Add(this.status);
            this.Controls.Add(this.menu);
            this.Font = new System.Drawing.Font("Microsoft Sans Serif", 10F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.MainMenuStrip = this.menu;
            this.Margin = new System.Windows.Forms.Padding(5, 4, 5, 4);
            this.Name = "FormMain";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Crash";
            this.FormClosing += new System.Windows.Forms.FormClosingEventHandler(this.FormMain_FormClosing);
            this.Load += new System.EventHandler(this.FormMain_Load);
            this.menu.ResumeLayout(false);
            this.menu.PerformLayout();
            this.status.ResumeLayout(false);
            this.status.PerformLayout();
            this.tools.ResumeLayout(false);
            this.tools.PerformLayout();
            this.tabs.ResumeLayout(false);
            this.pageSettings.ResumeLayout(false);
            this.pageSettings.PerformLayout();
            this.panel1.ResumeLayout(false);
            this.panel2.ResumeLayout(false);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.MenuStrip menu;
        private System.Windows.Forms.StatusStrip status;
        private System.Windows.Forms.ToolStrip tools;
        private System.Windows.Forms.ToolStripMenuItem menuItemFile;
        private System.Windows.Forms.ToolStripMenuItem menuItemExit;
        private System.Windows.Forms.ToolStripButton btnConnect;
        private System.Windows.Forms.ToolStripMenuItem menuItemConnect;
        private System.Windows.Forms.ToolStripMenuItem menuItemDisconnect;
        private System.Windows.Forms.ToolStripSeparator toolStripSeparator1;
        private System.Windows.Forms.ToolStripButton btnDisconnect;
        private System.Windows.Forms.ToolStripStatusLabel statusLabel;
        private System.Windows.Forms.ToolStripLabel lblConnectionStatus;
        private System.Windows.Forms.TabControl tabs;
        private System.Windows.Forms.TabPage pageSettings;
        private System.Windows.Forms.TabPage pageSpectrometry;
        private System.Windows.Forms.Button btnSendClose;
        private System.Windows.Forms.Button btnSendHello;
        private System.Windows.Forms.TextBox tbLog;
        private System.Windows.Forms.Button btnSendSession;
        private System.Windows.Forms.Button btnStopNetService;
        private System.Windows.Forms.Button btnSendFix;
        private System.Windows.Forms.Button btnGetPreview;
        private System.Windows.Forms.Button btnSetGain;
        private System.Windows.Forms.TextBox tbFineGain;
        private System.Windows.Forms.TextBox tbCoarseGain;
        private System.Windows.Forms.TextBox tbVoltage;
        private System.Windows.Forms.TextBox tbSpecLivetime;
        private System.Windows.Forms.TextBox tbSpecCount;
        private System.Windows.Forms.Panel panel2;
        private System.Windows.Forms.Panel panel1;
    }
}

