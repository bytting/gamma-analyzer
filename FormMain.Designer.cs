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
            System.Windows.Forms.DataVisualization.Charting.ChartArea chartArea1 = new System.Windows.Forms.DataVisualization.Charting.ChartArea();
            System.Windows.Forms.DataVisualization.Charting.Legend legend1 = new System.Windows.Forms.DataVisualization.Charting.Legend();
            System.Windows.Forms.DataVisualization.Charting.Series series1 = new System.Windows.Forms.DataVisualization.Charting.Series();
            this.menu = new System.Windows.Forms.MenuStrip();
            this.menuItemFile = new System.Windows.Forms.ToolStripMenuItem();
            this.menuItemConnect = new System.Windows.Forms.ToolStripMenuItem();
            this.menuItemDisconnect = new System.Windows.Forms.ToolStripMenuItem();
            this.toolStripSeparator1 = new System.Windows.Forms.ToolStripSeparator();
            this.menuItemExit = new System.Windows.Forms.ToolStripMenuItem();
            this.status = new System.Windows.Forms.StatusStrip();
            this.statusLabel = new System.Windows.Forms.ToolStripStatusLabel();
            this.tools = new System.Windows.Forms.ToolStrip();
            this.btnBack = new System.Windows.Forms.ToolStripButton();
            this.btnConnect = new System.Windows.Forms.ToolStripButton();
            this.btnDisconnect = new System.Windows.Forms.ToolStripButton();
            this.lblConnectionStatus = new System.Windows.Forms.ToolStripLabel();
            this.cbStoreChn = new System.Windows.Forms.CheckBox();
            this.btnStopNetService = new System.Windows.Forms.Button();
            this.btnSendClose = new System.Windows.Forms.Button();
            this.tbLog = new System.Windows.Forms.TextBox();
            this.lbSpecList = new System.Windows.Forms.ListBox();
            this.tbSpecCount = new System.Windows.Forms.TextBox();
            this.label1 = new System.Windows.Forms.Label();
            this.tbSpecLivetime = new System.Windows.Forms.TextBox();
            this.tbSpecDelay = new System.Windows.Forms.TextBox();
            this.btnSendSession = new System.Windows.Forms.Button();
            this.btnStopSession = new System.Windows.Forms.Button();
            this.tabs = new TabControlWizard.TabControlWizard();
            this.pageSpec = new System.Windows.Forms.TabPage();
            this.chartSpec = new System.Windows.Forms.DataVisualization.Charting.Chart();
            this.splitContainer1 = new System.Windows.Forms.SplitContainer();
            this.tableLayoutPanel1 = new System.Windows.Forms.TableLayoutPanel();
            this.label4 = new System.Windows.Forms.Label();
            this.btnSelectSessionDir = new System.Windows.Forms.Button();
            this.tbFineGain = new System.Windows.Forms.TextBox();
            this.tbSessionDir = new System.Windows.Forms.TextBox();
            this.tbCoarseGain = new System.Windows.Forms.TextBox();
            this.label5 = new System.Windows.Forms.Label();
            this.tbVoltage = new System.Windows.Forms.TextBox();
            this.btnSetGain = new System.Windows.Forms.Button();
            this.tableLayoutPanel2 = new System.Windows.Forms.TableLayoutPanel();
            this.pageMenu = new System.Windows.Forms.TabPage();
            this.flowLayoutPanel1 = new System.Windows.Forms.FlowLayoutPanel();
            this.btnMenuSpec = new System.Windows.Forms.Button();
            this.menu.SuspendLayout();
            this.status.SuspendLayout();
            this.tools.SuspendLayout();
            this.tabs.SuspendLayout();
            this.pageSpec.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.chartSpec)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.splitContainer1)).BeginInit();
            this.splitContainer1.Panel1.SuspendLayout();
            this.splitContainer1.Panel2.SuspendLayout();
            this.splitContainer1.SuspendLayout();
            this.tableLayoutPanel1.SuspendLayout();
            this.pageMenu.SuspendLayout();
            this.flowLayoutPanel1.SuspendLayout();
            this.SuspendLayout();
            // 
            // menu
            // 
            this.menu.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.menuItemFile});
            this.menu.Location = new System.Drawing.Point(0, 0);
            this.menu.Name = "menu";
            this.menu.Padding = new System.Windows.Forms.Padding(8, 2, 0, 2);
            this.menu.Size = new System.Drawing.Size(1375, 24);
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
            this.status.Location = new System.Drawing.Point(0, 725);
            this.status.Name = "status";
            this.status.Padding = new System.Windows.Forms.Padding(1, 0, 19, 0);
            this.status.Size = new System.Drawing.Size(1375, 22);
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
            this.btnBack,
            this.btnConnect,
            this.btnDisconnect,
            this.lblConnectionStatus});
            this.tools.Location = new System.Drawing.Point(0, 24);
            this.tools.Name = "tools";
            this.tools.Size = new System.Drawing.Size(1375, 25);
            this.tools.TabIndex = 2;
            this.tools.Text = "toolStrip1";
            // 
            // btnBack
            // 
            this.btnBack.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image;
            this.btnBack.Image = ((System.Drawing.Image)(resources.GetObject("btnBack.Image")));
            this.btnBack.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.btnBack.Name = "btnBack";
            this.btnBack.Size = new System.Drawing.Size(23, 22);
            this.btnBack.Text = "toolStripButton1";
            this.btnBack.Click += new System.EventHandler(this.btnBack_Click);
            // 
            // btnConnect
            // 
            this.btnConnect.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image;
            this.btnConnect.Image = ((System.Drawing.Image)(resources.GetObject("btnConnect.Image")));
            this.btnConnect.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.btnConnect.Name = "btnConnect";
            this.btnConnect.Size = new System.Drawing.Size(23, 22);
            this.btnConnect.Text = "Connect";
            this.btnConnect.Click += new System.EventHandler(this.menuItemConnect_Click);
            // 
            // btnDisconnect
            // 
            this.btnDisconnect.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image;
            this.btnDisconnect.Image = ((System.Drawing.Image)(resources.GetObject("btnDisconnect.Image")));
            this.btnDisconnect.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.btnDisconnect.Name = "btnDisconnect";
            this.btnDisconnect.Size = new System.Drawing.Size(23, 22);
            this.btnDisconnect.Text = "Disconnect";
            this.btnDisconnect.Click += new System.EventHandler(this.menuItemDisconnect_Click);
            // 
            // lblConnectionStatus
            // 
            this.lblConnectionStatus.Alignment = System.Windows.Forms.ToolStripItemAlignment.Right;
            this.lblConnectionStatus.Name = "lblConnectionStatus";
            this.lblConnectionStatus.Size = new System.Drawing.Size(130, 22);
            this.lblConnectionStatus.Text = "<lblConnectionStatus>";
            // 
            // cbStoreChn
            // 
            this.cbStoreChn.AutoSize = true;
            this.tableLayoutPanel1.SetColumnSpan(this.cbStoreChn, 2);
            this.cbStoreChn.Location = new System.Drawing.Point(241, 131);
            this.cbStoreChn.Name = "cbStoreChn";
            this.cbStoreChn.Size = new System.Drawing.Size(123, 21);
            this.cbStoreChn.TabIndex = 16;
            this.cbStoreChn.Text = "Store CHN files";
            this.cbStoreChn.UseVisualStyleBackColor = true;
            // 
            // btnStopNetService
            // 
            this.btnStopNetService.Dock = System.Windows.Forms.DockStyle.Fill;
            this.btnStopNetService.Location = new System.Drawing.Point(481, 132);
            this.btnStopNetService.Margin = new System.Windows.Forms.Padding(5, 4, 5, 4);
            this.btnStopNetService.Name = "btnStopNetService";
            this.btnStopNetService.Size = new System.Drawing.Size(109, 24);
            this.btnStopNetService.TabIndex = 4;
            this.btnStopNetService.Text = "Stop service";
            this.btnStopNetService.UseVisualStyleBackColor = true;
            this.btnStopNetService.Click += new System.EventHandler(this.btnStopNetService_Click);
            // 
            // btnSendClose
            // 
            this.btnSendClose.Dock = System.Windows.Forms.DockStyle.Fill;
            this.btnSendClose.Location = new System.Drawing.Point(600, 132);
            this.btnSendClose.Margin = new System.Windows.Forms.Padding(5, 4, 5, 4);
            this.btnSendClose.Name = "btnSendClose";
            this.btnSendClose.Size = new System.Drawing.Size(115, 24);
            this.btnSendClose.TabIndex = 2;
            this.btnSendClose.Text = "Send close";
            this.btnSendClose.UseVisualStyleBackColor = true;
            this.btnSendClose.Click += new System.EventHandler(this.btnSendClose_Click);
            // 
            // tbLog
            // 
            this.tbLog.BackColor = System.Drawing.SystemColors.ButtonFace;
            this.tbLog.Dock = System.Windows.Forms.DockStyle.Bottom;
            this.tbLog.Location = new System.Drawing.Point(177, 550);
            this.tbLog.Margin = new System.Windows.Forms.Padding(5, 4, 5, 4);
            this.tbLog.Multiline = true;
            this.tbLog.Name = "tbLog";
            this.tbLog.ScrollBars = System.Windows.Forms.ScrollBars.Both;
            this.tbLog.Size = new System.Drawing.Size(1187, 93);
            this.tbLog.TabIndex = 0;
            // 
            // lbSpecList
            // 
            this.lbSpecList.BackColor = System.Drawing.SystemColors.ButtonFace;
            this.lbSpecList.Dock = System.Windows.Forms.DockStyle.Left;
            this.lbSpecList.FormattingEnabled = true;
            this.lbSpecList.ItemHeight = 16;
            this.lbSpecList.Location = new System.Drawing.Point(3, 3);
            this.lbSpecList.Name = "lbSpecList";
            this.lbSpecList.Size = new System.Drawing.Size(174, 640);
            this.lbSpecList.TabIndex = 0;
            this.lbSpecList.SelectedValueChanged += new System.EventHandler(this.lbSpecList_SelectedValueChanged);
            this.lbSpecList.DoubleClick += new System.EventHandler(this.lbSpecList_DoubleClick);
            // 
            // tbSpecCount
            // 
            this.tbSpecCount.Dock = System.Windows.Forms.DockStyle.Fill;
            this.tbSpecCount.Location = new System.Drawing.Point(241, 67);
            this.tbSpecCount.Name = "tbSpecCount";
            this.tbSpecCount.Size = new System.Drawing.Size(113, 23);
            this.tbSpecCount.TabIndex = 18;
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.tableLayoutPanel1.SetColumnSpan(this.label1, 2);
            this.label1.Location = new System.Drawing.Point(3, 64);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(228, 17);
            this.label1.TabIndex = 0;
            this.label1.Text = "Spectrum count, livetime and delay";
            // 
            // tbSpecLivetime
            // 
            this.tbSpecLivetime.Dock = System.Windows.Forms.DockStyle.Fill;
            this.tbSpecLivetime.Location = new System.Drawing.Point(360, 67);
            this.tbSpecLivetime.Name = "tbSpecLivetime";
            this.tbSpecLivetime.Size = new System.Drawing.Size(113, 23);
            this.tbSpecLivetime.TabIndex = 19;
            // 
            // tbSpecDelay
            // 
            this.tbSpecDelay.Dock = System.Windows.Forms.DockStyle.Fill;
            this.tbSpecDelay.Location = new System.Drawing.Point(479, 67);
            this.tbSpecDelay.Name = "tbSpecDelay";
            this.tbSpecDelay.Size = new System.Drawing.Size(113, 23);
            this.tbSpecDelay.TabIndex = 20;
            // 
            // btnSendSession
            // 
            this.btnSendSession.Dock = System.Windows.Forms.DockStyle.Fill;
            this.btnSendSession.Location = new System.Drawing.Point(600, 68);
            this.btnSendSession.Margin = new System.Windows.Forms.Padding(5, 4, 5, 4);
            this.btnSendSession.Name = "btnSendSession";
            this.btnSendSession.Size = new System.Drawing.Size(115, 24);
            this.btnSendSession.TabIndex = 17;
            this.btnSendSession.Text = "Start session";
            this.btnSendSession.UseVisualStyleBackColor = true;
            this.btnSendSession.Click += new System.EventHandler(this.btnSendSession_Click);
            // 
            // btnStopSession
            // 
            this.btnStopSession.Dock = System.Windows.Forms.DockStyle.Fill;
            this.btnStopSession.Location = new System.Drawing.Point(598, 99);
            this.btnStopSession.Name = "btnStopSession";
            this.btnStopSession.Size = new System.Drawing.Size(119, 26);
            this.btnStopSession.TabIndex = 21;
            this.btnStopSession.Text = "Stop session";
            this.btnStopSession.UseVisualStyleBackColor = true;
            this.btnStopSession.Click += new System.EventHandler(this.btnStopSession_Click);
            // 
            // tabs
            // 
            this.tabs.Controls.Add(this.pageSpec);
            this.tabs.Controls.Add(this.pageMenu);
            this.tabs.Dock = System.Windows.Forms.DockStyle.Fill;
            this.tabs.Location = new System.Drawing.Point(0, 49);
            this.tabs.Name = "tabs";
            this.tabs.SelectedIndex = 0;
            this.tabs.Size = new System.Drawing.Size(1375, 676);
            this.tabs.TabIndex = 4;
            // 
            // pageSpec
            // 
            this.pageSpec.BackColor = System.Drawing.SystemColors.ButtonFace;
            this.pageSpec.Controls.Add(this.chartSpec);
            this.pageSpec.Controls.Add(this.tbLog);
            this.pageSpec.Controls.Add(this.splitContainer1);
            this.pageSpec.Controls.Add(this.lbSpecList);
            this.pageSpec.Location = new System.Drawing.Point(4, 26);
            this.pageSpec.Name = "pageSpec";
            this.pageSpec.Padding = new System.Windows.Forms.Padding(3);
            this.pageSpec.Size = new System.Drawing.Size(1367, 646);
            this.pageSpec.TabIndex = 0;
            this.pageSpec.Text = "Spectrum";
            // 
            // chartSpec
            // 
            this.chartSpec.BackColor = System.Drawing.SystemColors.ButtonFace;
            chartArea1.Name = "ChartArea1";
            this.chartSpec.ChartAreas.Add(chartArea1);
            this.chartSpec.Dock = System.Windows.Forms.DockStyle.Fill;
            legend1.Name = "Legend1";
            this.chartSpec.Legends.Add(legend1);
            this.chartSpec.Location = new System.Drawing.Point(177, 183);
            this.chartSpec.Name = "chartSpec";
            series1.ChartArea = "ChartArea1";
            series1.Legend = "Legend1";
            series1.Name = "Series1";
            this.chartSpec.Series.Add(series1);
            this.chartSpec.Size = new System.Drawing.Size(1187, 367);
            this.chartSpec.TabIndex = 19;
            this.chartSpec.Text = "chart1";
            // 
            // splitContainer1
            // 
            this.splitContainer1.Dock = System.Windows.Forms.DockStyle.Top;
            this.splitContainer1.Location = new System.Drawing.Point(177, 3);
            this.splitContainer1.Name = "splitContainer1";
            // 
            // splitContainer1.Panel1
            // 
            this.splitContainer1.Panel1.Controls.Add(this.tableLayoutPanel1);
            // 
            // splitContainer1.Panel2
            // 
            this.splitContainer1.Panel2.Controls.Add(this.tableLayoutPanel2);
            this.splitContainer1.Size = new System.Drawing.Size(1187, 180);
            this.splitContainer1.SplitterDistance = 720;
            this.splitContainer1.TabIndex = 18;
            // 
            // tableLayoutPanel1
            // 
            this.tableLayoutPanel1.ColumnCount = 6;
            this.tableLayoutPanel1.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 16.66667F));
            this.tableLayoutPanel1.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 16.66667F));
            this.tableLayoutPanel1.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 16.66667F));
            this.tableLayoutPanel1.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 16.66667F));
            this.tableLayoutPanel1.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 16.66667F));
            this.tableLayoutPanel1.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 16.66667F));
            this.tableLayoutPanel1.Controls.Add(this.label4, 0, 0);
            this.tableLayoutPanel1.Controls.Add(this.btnSelectSessionDir, 5, 0);
            this.tableLayoutPanel1.Controls.Add(this.tbFineGain, 4, 1);
            this.tableLayoutPanel1.Controls.Add(this.tbSessionDir, 2, 0);
            this.tableLayoutPanel1.Controls.Add(this.tbCoarseGain, 3, 1);
            this.tableLayoutPanel1.Controls.Add(this.label5, 0, 1);
            this.tableLayoutPanel1.Controls.Add(this.tbVoltage, 2, 1);
            this.tableLayoutPanel1.Controls.Add(this.btnSetGain, 5, 1);
            this.tableLayoutPanel1.Controls.Add(this.label1, 0, 2);
            this.tableLayoutPanel1.Controls.Add(this.tbSpecCount, 2, 2);
            this.tableLayoutPanel1.Controls.Add(this.tbSpecLivetime, 3, 2);
            this.tableLayoutPanel1.Controls.Add(this.tbSpecDelay, 4, 2);
            this.tableLayoutPanel1.Controls.Add(this.btnSendSession, 5, 2);
            this.tableLayoutPanel1.Controls.Add(this.btnStopSession, 5, 3);
            this.tableLayoutPanel1.Controls.Add(this.cbStoreChn, 2, 4);
            this.tableLayoutPanel1.Controls.Add(this.btnStopNetService, 4, 4);
            this.tableLayoutPanel1.Controls.Add(this.btnSendClose, 5, 4);
            this.tableLayoutPanel1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.tableLayoutPanel1.Location = new System.Drawing.Point(0, 0);
            this.tableLayoutPanel1.Name = "tableLayoutPanel1";
            this.tableLayoutPanel1.RowCount = 6;
            this.tableLayoutPanel1.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 32F));
            this.tableLayoutPanel1.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 32F));
            this.tableLayoutPanel1.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 32F));
            this.tableLayoutPanel1.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 32F));
            this.tableLayoutPanel1.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 32F));
            this.tableLayoutPanel1.RowStyles.Add(new System.Windows.Forms.RowStyle());
            this.tableLayoutPanel1.Size = new System.Drawing.Size(720, 180);
            this.tableLayoutPanel1.TabIndex = 0;
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.tableLayoutPanel1.SetColumnSpan(this.label4, 2);
            this.label4.Location = new System.Drawing.Point(3, 0);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(152, 17);
            this.label4.TabIndex = 0;
            this.label4.Text = "Session base directory";
            // 
            // btnSelectSessionDir
            // 
            this.btnSelectSessionDir.Dock = System.Windows.Forms.DockStyle.Fill;
            this.btnSelectSessionDir.Location = new System.Drawing.Point(598, 3);
            this.btnSelectSessionDir.Name = "btnSelectSessionDir";
            this.btnSelectSessionDir.Size = new System.Drawing.Size(119, 26);
            this.btnSelectSessionDir.TabIndex = 2;
            this.btnSelectSessionDir.Text = "...";
            this.btnSelectSessionDir.UseVisualStyleBackColor = true;
            this.btnSelectSessionDir.Click += new System.EventHandler(this.btnSelectSessionDir_Click);
            // 
            // tbFineGain
            // 
            this.tbFineGain.Dock = System.Windows.Forms.DockStyle.Fill;
            this.tbFineGain.Location = new System.Drawing.Point(479, 35);
            this.tbFineGain.Name = "tbFineGain";
            this.tbFineGain.Size = new System.Drawing.Size(113, 23);
            this.tbFineGain.TabIndex = 14;
            // 
            // tbSessionDir
            // 
            this.tableLayoutPanel1.SetColumnSpan(this.tbSessionDir, 3);
            this.tbSessionDir.Dock = System.Windows.Forms.DockStyle.Fill;
            this.tbSessionDir.Location = new System.Drawing.Point(241, 3);
            this.tbSessionDir.Name = "tbSessionDir";
            this.tbSessionDir.ReadOnly = true;
            this.tbSessionDir.Size = new System.Drawing.Size(351, 23);
            this.tbSessionDir.TabIndex = 1;
            // 
            // tbCoarseGain
            // 
            this.tbCoarseGain.Dock = System.Windows.Forms.DockStyle.Fill;
            this.tbCoarseGain.Location = new System.Drawing.Point(360, 35);
            this.tbCoarseGain.Name = "tbCoarseGain";
            this.tbCoarseGain.Size = new System.Drawing.Size(113, 23);
            this.tbCoarseGain.TabIndex = 13;
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.tableLayoutPanel1.SetColumnSpan(this.label5, 2);
            this.label5.Location = new System.Drawing.Point(3, 32);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(193, 17);
            this.label5.TabIndex = 3;
            this.label5.Text = "Voltage, coarse and fine gain";
            // 
            // tbVoltage
            // 
            this.tbVoltage.Dock = System.Windows.Forms.DockStyle.Fill;
            this.tbVoltage.Location = new System.Drawing.Point(241, 35);
            this.tbVoltage.Name = "tbVoltage";
            this.tbVoltage.Size = new System.Drawing.Size(113, 23);
            this.tbVoltage.TabIndex = 12;
            // 
            // btnSetGain
            // 
            this.btnSetGain.Dock = System.Windows.Forms.DockStyle.Fill;
            this.btnSetGain.Location = new System.Drawing.Point(598, 35);
            this.btnSetGain.Name = "btnSetGain";
            this.btnSetGain.Size = new System.Drawing.Size(119, 26);
            this.btnSetGain.TabIndex = 7;
            this.btnSetGain.Text = "Set gain";
            this.btnSetGain.UseVisualStyleBackColor = true;
            this.btnSetGain.Click += new System.EventHandler(this.btnSetGain_Click);
            // 
            // tableLayoutPanel2
            // 
            this.tableLayoutPanel2.ColumnCount = 2;
            this.tableLayoutPanel2.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 50F));
            this.tableLayoutPanel2.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 50F));
            this.tableLayoutPanel2.Dock = System.Windows.Forms.DockStyle.Fill;
            this.tableLayoutPanel2.Location = new System.Drawing.Point(0, 0);
            this.tableLayoutPanel2.Name = "tableLayoutPanel2";
            this.tableLayoutPanel2.RowCount = 2;
            this.tableLayoutPanel2.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 50F));
            this.tableLayoutPanel2.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 50F));
            this.tableLayoutPanel2.Size = new System.Drawing.Size(463, 180);
            this.tableLayoutPanel2.TabIndex = 0;
            // 
            // pageMenu
            // 
            this.pageMenu.BackColor = System.Drawing.SystemColors.ButtonFace;
            this.pageMenu.Controls.Add(this.flowLayoutPanel1);
            this.pageMenu.Location = new System.Drawing.Point(4, 26);
            this.pageMenu.Name = "pageMenu";
            this.pageMenu.Padding = new System.Windows.Forms.Padding(3);
            this.pageMenu.Size = new System.Drawing.Size(1367, 646);
            this.pageMenu.TabIndex = 1;
            this.pageMenu.Text = "Menu";
            // 
            // flowLayoutPanel1
            // 
            this.flowLayoutPanel1.Controls.Add(this.btnMenuSpec);
            this.flowLayoutPanel1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.flowLayoutPanel1.Location = new System.Drawing.Point(3, 3);
            this.flowLayoutPanel1.Name = "flowLayoutPanel1";
            this.flowLayoutPanel1.Padding = new System.Windows.Forms.Padding(50);
            this.flowLayoutPanel1.Size = new System.Drawing.Size(1361, 640);
            this.flowLayoutPanel1.TabIndex = 1;
            // 
            // btnMenuSpec
            // 
            this.btnMenuSpec.Location = new System.Drawing.Point(53, 53);
            this.btnMenuSpec.Name = "btnMenuSpec";
            this.btnMenuSpec.Size = new System.Drawing.Size(200, 200);
            this.btnMenuSpec.TabIndex = 0;
            this.btnMenuSpec.Text = "Spectrum";
            this.btnMenuSpec.UseVisualStyleBackColor = true;
            this.btnMenuSpec.Click += new System.EventHandler(this.btnMenuSpec_Click);
            // 
            // FormMain
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(1375, 747);
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
            this.pageSpec.ResumeLayout(false);
            this.pageSpec.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.chartSpec)).EndInit();
            this.splitContainer1.Panel1.ResumeLayout(false);
            this.splitContainer1.Panel2.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.splitContainer1)).EndInit();
            this.splitContainer1.ResumeLayout(false);
            this.tableLayoutPanel1.ResumeLayout(false);
            this.tableLayoutPanel1.PerformLayout();
            this.pageMenu.ResumeLayout(false);
            this.flowLayoutPanel1.ResumeLayout(false);
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
        private System.Windows.Forms.Button btnSendClose;
        private System.Windows.Forms.TextBox tbLog;
        private System.Windows.Forms.Button btnStopNetService;
        private System.Windows.Forms.Button btnStopSession;
        private System.Windows.Forms.TextBox tbSpecDelay;
        private System.Windows.Forms.Button btnSendSession;
        private System.Windows.Forms.TextBox tbSpecLivetime;
        private System.Windows.Forms.TextBox tbSpecCount;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.ListBox lbSpecList;
        private System.Windows.Forms.CheckBox cbStoreChn;
        private TabControlWizard.TabControlWizard tabs;
        private System.Windows.Forms.TabPage pageSpec;
        private System.Windows.Forms.DataVisualization.Charting.Chart chartSpec;
        private System.Windows.Forms.SplitContainer splitContainer1;
        private System.Windows.Forms.TableLayoutPanel tableLayoutPanel1;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.Button btnSelectSessionDir;
        private System.Windows.Forms.TextBox tbFineGain;
        private System.Windows.Forms.TextBox tbSessionDir;
        private System.Windows.Forms.TextBox tbCoarseGain;
        private System.Windows.Forms.Label label5;
        private System.Windows.Forms.TextBox tbVoltage;
        private System.Windows.Forms.Button btnSetGain;
        private System.Windows.Forms.TableLayoutPanel tableLayoutPanel2;
        private System.Windows.Forms.TabPage pageMenu;
        private System.Windows.Forms.FlowLayoutPanel flowLayoutPanel1;
        private System.Windows.Forms.Button btnMenuSpec;
        private System.Windows.Forms.ToolStripButton btnBack;
    }
}

