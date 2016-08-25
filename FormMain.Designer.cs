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
            this.components = new System.ComponentModel.Container();
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(FormMain));
            this.menu = new System.Windows.Forms.MenuStrip();
            this.menuItemFile = new System.Windows.Forms.ToolStripMenuItem();
            this.menuItemBack = new System.Windows.Forms.ToolStripMenuItem();
            this.toolStripSeparator10 = new System.Windows.Forms.ToolStripSeparator();
            this.menuItemConnect = new System.Windows.Forms.ToolStripMenuItem();
            this.menuItemDisconnect = new System.Windows.Forms.ToolStripMenuItem();
            this.toolStripSeparator1 = new System.Windows.Forms.ToolStripSeparator();
            this.menuItemExit = new System.Windows.Forms.ToolStripMenuItem();
            this.menuItemEdit = new System.Windows.Forms.ToolStripMenuItem();
            this.menuItemROITable = new System.Windows.Forms.ToolStripMenuItem();
            this.menuItemRegressionPoints = new System.Windows.Forms.ToolStripMenuItem();
            this.menuItemPreferences = new System.Windows.Forms.ToolStripMenuItem();
            this.menuItemSession = new System.Windows.Forms.ToolStripMenuItem();
            this.menuItemLoadSession = new System.Windows.Forms.ToolStripMenuItem();
            this.menuItemClearSession = new System.Windows.Forms.ToolStripMenuItem();
            this.menuItemSessionInfo = new System.Windows.Forms.ToolStripMenuItem();
            this.toolStripSeparator4 = new System.Windows.Forms.ToolStripSeparator();
            this.menuItemLoadBackgroundSession = new System.Windows.Forms.ToolStripMenuItem();
            this.menuItemClearBackground = new System.Windows.Forms.ToolStripMenuItem();
            this.toolStripSeparator7 = new System.Windows.Forms.ToolStripSeparator();
            this.menuItemExport = new System.Windows.Forms.ToolStripMenuItem();
            this.menuItemSaveAsCHN = new System.Windows.Forms.ToolStripMenuItem();
            this.menuItemSaveAsIRIX = new System.Windows.Forms.ToolStripMenuItem();
            this.menuItemSaveAsKMZ = new System.Windows.Forms.ToolStripMenuItem();
            this.menuItemView = new System.Windows.Forms.ToolStripMenuItem();
            this.menuItemShowLog = new System.Windows.Forms.ToolStripMenuItem();
            this.menuItemShowMap = new System.Windows.Forms.ToolStripMenuItem();
            this.menuItemShowWaterfall = new System.Windows.Forms.ToolStripMenuItem();
            this.menuItemShowROIHistory = new System.Windows.Forms.ToolStripMenuItem();
            this.menuItemShowROIChart = new System.Windows.Forms.ToolStripMenuItem();
            this.menuItemShow3DMap = new System.Windows.Forms.ToolStripMenuItem();
            this.menuItemHelp = new System.Windows.Forms.ToolStripMenuItem();
            this.menuItemAbout = new System.Windows.Forms.ToolStripMenuItem();
            this.status = new System.Windows.Forms.StatusStrip();
            this.statusLabel = new System.Windows.Forms.ToolStripStatusLabel();
            this.tools = new System.Windows.Forms.ToolStrip();
            this.btnBack = new System.Windows.Forms.ToolStripButton();
            this.toolStripSeparator2 = new System.Windows.Forms.ToolStripSeparator();
            this.btnPreferences = new System.Windows.Forms.ToolStripButton();
            this.btnShowLog = new System.Windows.Forms.ToolStripButton();
            this.toolStripSeparator5 = new System.Windows.Forms.ToolStripSeparator();
            this.btnConnect = new System.Windows.Forms.ToolStripButton();
            this.btnDisconnect = new System.Windows.Forms.ToolStripButton();
            this.toolStripSeparator3 = new System.Windows.Forms.ToolStripSeparator();
            this.btnSessionInfo = new System.Windows.Forms.ToolStripButton();
            this.toolStripSeparator8 = new System.Windows.Forms.ToolStripSeparator();
            this.btnShowRegressionPoints = new System.Windows.Forms.ToolStripButton();
            this.btnShowROITable = new System.Windows.Forms.ToolStripButton();
            this.toolStripSeparator6 = new System.Windows.Forms.ToolStripSeparator();
            this.btnShowMap = new System.Windows.Forms.ToolStripButton();
            this.btnShowWaterfallLive = new System.Windows.Forms.ToolStripButton();
            this.lblInterface = new System.Windows.Forms.ToolStripLabel();
            this.separatorInterface = new System.Windows.Forms.ToolStripSeparator();
            this.lblDetector = new System.Windows.Forms.ToolStripLabel();
            this.separatorDetector = new System.Windows.Forms.ToolStripSeparator();
            this.lblConnectionStatus = new System.Windows.Forms.ToolStripLabel();
            this.btnShowROIHist = new System.Windows.Forms.ToolStripButton();
            this.btnShowROIChart = new System.Windows.Forms.ToolStripButton();
            this.btnShow3D = new System.Windows.Forms.ToolStripButton();
            this.tabs = new TabControlWizard.TabControlWizard();
            this.pageSetup = new System.Windows.Forms.TabPage();
            this.graphSetup = new ZedGraph.ZedGraphControl();
            this.panel2 = new System.Windows.Forms.Panel();
            this.lblSetupEnergy = new System.Windows.Forms.Label();
            this.lblSetupChannel = new System.Windows.Forms.Label();
            this.tableLayoutSetup = new System.Windows.Forms.TableLayoutPanel();
            this.label2 = new System.Windows.Forms.Label();
            this.label6 = new System.Windows.Forms.Label();
            this.label3 = new System.Windows.Forms.Label();
            this.cboxSetupDetector = new System.Windows.Forms.ComboBox();
            this.label5 = new System.Windows.Forms.Label();
            this.label11 = new System.Windows.Forms.Label();
            this.cboxSetupChannels = new System.Windows.Forms.ComboBox();
            this.label4 = new System.Windows.Forms.Label();
            this.label7 = new System.Windows.Forms.Label();
            this.btnSetupStart = new System.Windows.Forms.Button();
            this.btnSetupStop = new System.Windows.Forms.Button();
            this.label8 = new System.Windows.Forms.Label();
            this.label9 = new System.Windows.Forms.Label();
            this.label10 = new System.Windows.Forms.Label();
            this.cboxSetupCoarseGain = new System.Windows.Forms.ComboBox();
            this.panel3 = new System.Windows.Forms.Panel();
            this.tbarSetupFineGain = new System.Windows.Forms.TrackBar();
            this.lblSetupFineGain = new System.Windows.Forms.Label();
            this.panel4 = new System.Windows.Forms.Panel();
            this.btnSetupSetParams = new System.Windows.Forms.Button();
            this.panel5 = new System.Windows.Forms.Panel();
            this.tbarSetupVoltage = new System.Windows.Forms.TrackBar();
            this.lblSetupVoltage = new System.Windows.Forms.Label();
            this.panel6 = new System.Windows.Forms.Panel();
            this.tbarSetupLLD = new System.Windows.Forms.TrackBar();
            this.lblSetupLLD = new System.Windows.Forms.Label();
            this.panel7 = new System.Windows.Forms.Panel();
            this.tbarSetupULD = new System.Windows.Forms.TrackBar();
            this.lblSetupULD = new System.Windows.Forms.Label();
            this.panel8 = new System.Windows.Forms.Panel();
            this.tbarSetupLivetime = new System.Windows.Forms.TrackBar();
            this.lblSetupLivetime = new System.Windows.Forms.Label();
            this.pageMenu = new System.Windows.Forms.TabPage();
            this.flowLayoutPanel1 = new System.Windows.Forms.FlowLayoutPanel();
            this.btnMenuSetup = new System.Windows.Forms.Button();
            this.btnMenuSession = new System.Windows.Forms.Button();
            this.pageSession = new System.Windows.Forms.TabPage();
            this.splitContainer2 = new System.Windows.Forms.SplitContainer();
            this.lbSession = new System.Windows.Forms.ListBox();
            this.contextMenuSession = new System.Windows.Forms.ContextMenuStrip(this.components);
            this.menuItemSessionUnselect = new System.Windows.Forms.ToolStripMenuItem();
            this.menuItemSourceActivity = new System.Windows.Forms.ToolStripMenuItem();
            this.graphSession = new ZedGraph.ZedGraphControl();
            this.panel1 = new System.Windows.Forms.Panel();
            this.lblSessionEnergy = new System.Windows.Forms.Label();
            this.lblSessionChannel = new System.Windows.Forms.Label();
            this.tableLayoutPanel2 = new System.Windows.Forms.TableLayoutPanel();
            this.lblLatitudeStart = new System.Windows.Forms.Label();
            this.lblLongitudeStart = new System.Windows.Forms.Label();
            this.lblAltitudeStart = new System.Windows.Forms.Label();
            this.lblMaxCount = new System.Windows.Forms.Label();
            this.lblMinCount = new System.Windows.Forms.Label();
            this.lblTotalCount = new System.Windows.Forms.Label();
            this.lblGpsTimeStart = new System.Windows.Forms.Label();
            this.lblLatitudeEnd = new System.Windows.Forms.Label();
            this.lblLongitudeEnd = new System.Windows.Forms.Label();
            this.lblAltitudeEnd = new System.Windows.Forms.Label();
            this.lblGpsTimeEnd = new System.Windows.Forms.Label();
            this.lblDoserate = new System.Windows.Forms.Label();
            this.lblSession = new System.Windows.Forms.Label();
            this.lblLivetime = new System.Windows.Forms.Label();
            this.lblRealtime = new System.Windows.Forms.Label();
            this.lblIndex = new System.Windows.Forms.Label();
            this.lblBackground = new System.Windows.Forms.Label();
            this.lblComment = new System.Windows.Forms.Label();
            this.tblSession = new System.Windows.Forms.TableLayoutPanel();
            this.label1 = new System.Windows.Forms.Label();
            this.tbSpecCount = new System.Windows.Forms.TextBox();
            this.tbSpecLivetime = new System.Windows.Forms.TextBox();
            this.tbSpecDelay = new System.Windows.Forms.TextBox();
            this.btnSendSession = new System.Windows.Forms.Button();
            this.btnStopSession = new System.Windows.Forms.Button();
            this.btnSendClose = new System.Windows.Forms.Button();
            this.menu.SuspendLayout();
            this.status.SuspendLayout();
            this.tools.SuspendLayout();
            this.tabs.SuspendLayout();
            this.pageSetup.SuspendLayout();
            this.panel2.SuspendLayout();
            this.tableLayoutSetup.SuspendLayout();
            this.panel3.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.tbarSetupFineGain)).BeginInit();
            this.panel4.SuspendLayout();
            this.panel5.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.tbarSetupVoltage)).BeginInit();
            this.panel6.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.tbarSetupLLD)).BeginInit();
            this.panel7.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.tbarSetupULD)).BeginInit();
            this.panel8.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.tbarSetupLivetime)).BeginInit();
            this.pageMenu.SuspendLayout();
            this.flowLayoutPanel1.SuspendLayout();
            this.pageSession.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.splitContainer2)).BeginInit();
            this.splitContainer2.Panel1.SuspendLayout();
            this.splitContainer2.Panel2.SuspendLayout();
            this.splitContainer2.SuspendLayout();
            this.contextMenuSession.SuspendLayout();
            this.panel1.SuspendLayout();
            this.tableLayoutPanel2.SuspendLayout();
            this.tblSession.SuspendLayout();
            this.SuspendLayout();
            // 
            // menu
            // 
            this.menu.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.menuItemFile,
            this.menuItemEdit,
            this.menuItemSession,
            this.menuItemView,
            this.menuItemHelp});
            this.menu.Location = new System.Drawing.Point(0, 0);
            this.menu.Name = "menu";
            this.menu.Padding = new System.Windows.Forms.Padding(7, 2, 0, 2);
            this.menu.Size = new System.Drawing.Size(1110, 24);
            this.menu.TabIndex = 0;
            this.menu.Text = "menuStrip1";
            // 
            // menuItemFile
            // 
            this.menuItemFile.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.menuItemBack,
            this.toolStripSeparator10,
            this.menuItemConnect,
            this.menuItemDisconnect,
            this.toolStripSeparator1,
            this.menuItemExit});
            this.menuItemFile.Name = "menuItemFile";
            this.menuItemFile.Size = new System.Drawing.Size(37, 20);
            this.menuItemFile.Text = "&File";
            // 
            // menuItemBack
            // 
            this.menuItemBack.Name = "menuItemBack";
            this.menuItemBack.Size = new System.Drawing.Size(133, 22);
            this.menuItemBack.Text = "&Back";
            this.menuItemBack.Click += new System.EventHandler(this.menuItemBack_Click);
            // 
            // toolStripSeparator10
            // 
            this.toolStripSeparator10.Name = "toolStripSeparator10";
            this.toolStripSeparator10.Size = new System.Drawing.Size(130, 6);
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
            // menuItemEdit
            // 
            this.menuItemEdit.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.menuItemROITable,
            this.menuItemRegressionPoints,
            this.menuItemPreferences});
            this.menuItemEdit.Name = "menuItemEdit";
            this.menuItemEdit.Size = new System.Drawing.Size(39, 20);
            this.menuItemEdit.Text = "&Edit";
            // 
            // menuItemROITable
            // 
            this.menuItemROITable.Name = "menuItemROITable";
            this.menuItemROITable.Size = new System.Drawing.Size(167, 22);
            this.menuItemROITable.Text = "ROI Table";
            this.menuItemROITable.Click += new System.EventHandler(this.menuItemROITable_Click);
            // 
            // menuItemRegressionPoints
            // 
            this.menuItemRegressionPoints.Name = "menuItemRegressionPoints";
            this.menuItemRegressionPoints.Size = new System.Drawing.Size(167, 22);
            this.menuItemRegressionPoints.Text = "Regression &Points";
            this.menuItemRegressionPoints.Click += new System.EventHandler(this.menuItemRegressionPoints_Click);
            // 
            // menuItemPreferences
            // 
            this.menuItemPreferences.Name = "menuItemPreferences";
            this.menuItemPreferences.Size = new System.Drawing.Size(167, 22);
            this.menuItemPreferences.Text = "&Preferences";
            this.menuItemPreferences.Click += new System.EventHandler(this.menuItemPreferences_Click);
            // 
            // menuItemSession
            // 
            this.menuItemSession.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.menuItemLoadSession,
            this.menuItemClearSession,
            this.menuItemSessionInfo,
            this.toolStripSeparator4,
            this.menuItemLoadBackgroundSession,
            this.menuItemClearBackground,
            this.toolStripSeparator7,
            this.menuItemExport});
            this.menuItemSession.Name = "menuItemSession";
            this.menuItemSession.Size = new System.Drawing.Size(58, 20);
            this.menuItemSession.Text = "&Session";
            // 
            // menuItemLoadSession
            // 
            this.menuItemLoadSession.Name = "menuItemLoadSession";
            this.menuItemLoadSession.Size = new System.Drawing.Size(208, 22);
            this.menuItemLoadSession.Text = "Load &existing session";
            this.menuItemLoadSession.Click += new System.EventHandler(this.menuItemLoadSession_Click);
            // 
            // menuItemClearSession
            // 
            this.menuItemClearSession.Name = "menuItemClearSession";
            this.menuItemClearSession.Size = new System.Drawing.Size(208, 22);
            this.menuItemClearSession.Text = "C&lear session";
            this.menuItemClearSession.Click += new System.EventHandler(this.menuItemClearSession_Click);
            // 
            // menuItemSessionInfo
            // 
            this.menuItemSessionInfo.Name = "menuItemSessionInfo";
            this.menuItemSessionInfo.Size = new System.Drawing.Size(208, 22);
            this.menuItemSessionInfo.Text = "Edit &session info";
            this.menuItemSessionInfo.Click += new System.EventHandler(this.menuItemSessionInfo_Click);
            // 
            // toolStripSeparator4
            // 
            this.toolStripSeparator4.Name = "toolStripSeparator4";
            this.toolStripSeparator4.Size = new System.Drawing.Size(205, 6);
            // 
            // menuItemLoadBackgroundSession
            // 
            this.menuItemLoadBackgroundSession.Name = "menuItemLoadBackgroundSession";
            this.menuItemLoadBackgroundSession.Size = new System.Drawing.Size(208, 22);
            this.menuItemLoadBackgroundSession.Text = "Load &background session";
            this.menuItemLoadBackgroundSession.Click += new System.EventHandler(this.menuItemLoadBackgroundSession_Click);
            // 
            // menuItemClearBackground
            // 
            this.menuItemClearBackground.Name = "menuItemClearBackground";
            this.menuItemClearBackground.Size = new System.Drawing.Size(208, 22);
            this.menuItemClearBackground.Text = "Clear back&ground";
            this.menuItemClearBackground.Click += new System.EventHandler(this.menuItemClearBackground_Click);
            // 
            // toolStripSeparator7
            // 
            this.toolStripSeparator7.Name = "toolStripSeparator7";
            this.toolStripSeparator7.Size = new System.Drawing.Size(205, 6);
            // 
            // menuItemExport
            // 
            this.menuItemExport.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.menuItemSaveAsCHN,
            this.menuItemSaveAsIRIX,
            this.menuItemSaveAsKMZ});
            this.menuItemExport.Name = "menuItemExport";
            this.menuItemExport.Size = new System.Drawing.Size(208, 22);
            this.menuItemExport.Text = "E&xport session as ...";
            // 
            // menuItemSaveAsCHN
            // 
            this.menuItemSaveAsCHN.Name = "menuItemSaveAsCHN";
            this.menuItemSaveAsCHN.Size = new System.Drawing.Size(100, 22);
            this.menuItemSaveAsCHN.Text = "&CHN";
            this.menuItemSaveAsCHN.Click += new System.EventHandler(this.menuItemSaveAsCHN_Click);
            // 
            // menuItemSaveAsIRIX
            // 
            this.menuItemSaveAsIRIX.Name = "menuItemSaveAsIRIX";
            this.menuItemSaveAsIRIX.Size = new System.Drawing.Size(100, 22);
            this.menuItemSaveAsIRIX.Text = "&IRIX";
            // 
            // menuItemSaveAsKMZ
            // 
            this.menuItemSaveAsKMZ.Name = "menuItemSaveAsKMZ";
            this.menuItemSaveAsKMZ.Size = new System.Drawing.Size(100, 22);
            this.menuItemSaveAsKMZ.Text = "KM&Z";
            // 
            // menuItemView
            // 
            this.menuItemView.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.menuItemShowLog,
            this.menuItemShowMap,
            this.menuItemShowWaterfall,
            this.menuItemShowROIHistory,
            this.menuItemShowROIChart,
            this.menuItemShow3DMap});
            this.menuItemView.Name = "menuItemView";
            this.menuItemView.Size = new System.Drawing.Size(44, 20);
            this.menuItemView.Text = "&View";
            // 
            // menuItemShowLog
            // 
            this.menuItemShowLog.Name = "menuItemShowLog";
            this.menuItemShowLog.Size = new System.Drawing.Size(164, 22);
            this.menuItemShowLog.Text = "Show &log";
            this.menuItemShowLog.Click += new System.EventHandler(this.menuItemShowLog_Click);
            // 
            // menuItemShowMap
            // 
            this.menuItemShowMap.Name = "menuItemShowMap";
            this.menuItemShowMap.Size = new System.Drawing.Size(164, 22);
            this.menuItemShowMap.Text = "Show &map";
            this.menuItemShowMap.Click += new System.EventHandler(this.menuItemShowMap_Click);
            // 
            // menuItemShowWaterfall
            // 
            this.menuItemShowWaterfall.Name = "menuItemShowWaterfall";
            this.menuItemShowWaterfall.Size = new System.Drawing.Size(164, 22);
            this.menuItemShowWaterfall.Text = "Show &waterfall";
            this.menuItemShowWaterfall.Click += new System.EventHandler(this.menuItemShowWaterfall_Click);
            // 
            // menuItemShowROIHistory
            // 
            this.menuItemShowROIHistory.Name = "menuItemShowROIHistory";
            this.menuItemShowROIHistory.Size = new System.Drawing.Size(164, 22);
            this.menuItemShowROIHistory.Text = "Show ROI &history";
            this.menuItemShowROIHistory.Click += new System.EventHandler(this.menuItemShowROIHistory_Click);
            // 
            // menuItemShowROIChart
            // 
            this.menuItemShowROIChart.Name = "menuItemShowROIChart";
            this.menuItemShowROIChart.Size = new System.Drawing.Size(164, 22);
            this.menuItemShowROIChart.Text = "Show ROI l&ive";
            this.menuItemShowROIChart.Click += new System.EventHandler(this.menuItemShowROIChart_Click);
            // 
            // menuItemShow3DMap
            // 
            this.menuItemShow3DMap.Name = "menuItemShow3DMap";
            this.menuItemShow3DMap.Size = new System.Drawing.Size(164, 22);
            this.menuItemShow3DMap.Text = "Show 3&D map";
            this.menuItemShow3DMap.Click += new System.EventHandler(this.menuItemShow3DMap_Click);
            // 
            // menuItemHelp
            // 
            this.menuItemHelp.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.menuItemAbout});
            this.menuItemHelp.Name = "menuItemHelp";
            this.menuItemHelp.Size = new System.Drawing.Size(44, 20);
            this.menuItemHelp.Text = "&Help";
            // 
            // menuItemAbout
            // 
            this.menuItemAbout.Name = "menuItemAbout";
            this.menuItemAbout.Size = new System.Drawing.Size(107, 22);
            this.menuItemAbout.Text = "&About";
            this.menuItemAbout.Click += new System.EventHandler(this.menuItemAbout_Click);
            // 
            // status
            // 
            this.status.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.statusLabel});
            this.status.Location = new System.Drawing.Point(0, 664);
            this.status.Name = "status";
            this.status.Padding = new System.Windows.Forms.Padding(1, 0, 17, 0);
            this.status.Size = new System.Drawing.Size(1110, 22);
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
            this.tools.AutoSize = false;
            this.tools.GripStyle = System.Windows.Forms.ToolStripGripStyle.Hidden;
            this.tools.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.btnBack,
            this.toolStripSeparator2,
            this.btnPreferences,
            this.btnShowLog,
            this.toolStripSeparator5,
            this.btnConnect,
            this.btnDisconnect,
            this.toolStripSeparator3,
            this.btnSessionInfo,
            this.toolStripSeparator8,
            this.btnShowRegressionPoints,
            this.btnShowROITable,
            this.toolStripSeparator6,
            this.btnShowMap,
            this.btnShowWaterfallLive,
            this.lblInterface,
            this.separatorInterface,
            this.lblDetector,
            this.separatorDetector,
            this.lblConnectionStatus,
            this.btnShowROIHist,
            this.btnShowROIChart,
            this.btnShow3D});
            this.tools.Location = new System.Drawing.Point(0, 24);
            this.tools.Name = "tools";
            this.tools.Size = new System.Drawing.Size(1110, 40);
            this.tools.TabIndex = 2;
            this.tools.Text = "toolStrip1";
            // 
            // btnBack
            // 
            this.btnBack.AutoSize = false;
            this.btnBack.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image;
            this.btnBack.Image = global::crash.Properties.Resources.home_32;
            this.btnBack.ImageScaling = System.Windows.Forms.ToolStripItemImageScaling.None;
            this.btnBack.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.btnBack.Name = "btnBack";
            this.btnBack.Size = new System.Drawing.Size(38, 38);
            this.btnBack.Text = "toolStripButton1";
            this.btnBack.ToolTipText = "Back";
            this.btnBack.Click += new System.EventHandler(this.menuItemBack_Click);
            // 
            // toolStripSeparator2
            // 
            this.toolStripSeparator2.Name = "toolStripSeparator2";
            this.toolStripSeparator2.Size = new System.Drawing.Size(6, 40);
            // 
            // btnPreferences
            // 
            this.btnPreferences.AutoSize = false;
            this.btnPreferences.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image;
            this.btnPreferences.Image = global::crash.Properties.Resources.settings_32;
            this.btnPreferences.ImageScaling = System.Windows.Forms.ToolStripItemImageScaling.None;
            this.btnPreferences.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.btnPreferences.Name = "btnPreferences";
            this.btnPreferences.Size = new System.Drawing.Size(38, 38);
            this.btnPreferences.Text = "toolStripButton1";
            this.btnPreferences.ToolTipText = "Open Crash preferences";
            this.btnPreferences.Click += new System.EventHandler(this.menuItemPreferences_Click);
            // 
            // btnShowLog
            // 
            this.btnShowLog.AutoSize = false;
            this.btnShowLog.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image;
            this.btnShowLog.Image = global::crash.Properties.Resources.log_32;
            this.btnShowLog.ImageScaling = System.Windows.Forms.ToolStripItemImageScaling.None;
            this.btnShowLog.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.btnShowLog.Name = "btnShowLog";
            this.btnShowLog.Size = new System.Drawing.Size(38, 38);
            this.btnShowLog.Text = "toolStripButton1";
            this.btnShowLog.ToolTipText = "Show log";
            this.btnShowLog.Click += new System.EventHandler(this.menuItemShowLog_Click);
            // 
            // toolStripSeparator5
            // 
            this.toolStripSeparator5.Name = "toolStripSeparator5";
            this.toolStripSeparator5.Size = new System.Drawing.Size(6, 40);
            // 
            // btnConnect
            // 
            this.btnConnect.AutoSize = false;
            this.btnConnect.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image;
            this.btnConnect.Image = global::crash.Properties.Resources.connect_32;
            this.btnConnect.ImageScaling = System.Windows.Forms.ToolStripItemImageScaling.None;
            this.btnConnect.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.btnConnect.Name = "btnConnect";
            this.btnConnect.Size = new System.Drawing.Size(38, 38);
            this.btnConnect.Text = "Connect";
            this.btnConnect.Click += new System.EventHandler(this.menuItemConnect_Click);
            // 
            // btnDisconnect
            // 
            this.btnDisconnect.AutoSize = false;
            this.btnDisconnect.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image;
            this.btnDisconnect.Image = global::crash.Properties.Resources.disconnect_32;
            this.btnDisconnect.ImageScaling = System.Windows.Forms.ToolStripItemImageScaling.None;
            this.btnDisconnect.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.btnDisconnect.Name = "btnDisconnect";
            this.btnDisconnect.Size = new System.Drawing.Size(38, 38);
            this.btnDisconnect.Text = "Disconnect";
            this.btnDisconnect.Click += new System.EventHandler(this.menuItemDisconnect_Click);
            // 
            // toolStripSeparator3
            // 
            this.toolStripSeparator3.Name = "toolStripSeparator3";
            this.toolStripSeparator3.Size = new System.Drawing.Size(6, 40);
            // 
            // btnSessionInfo
            // 
            this.btnSessionInfo.AutoSize = false;
            this.btnSessionInfo.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image;
            this.btnSessionInfo.Image = global::crash.Properties.Resources.waterfall_history_32;
            this.btnSessionInfo.ImageScaling = System.Windows.Forms.ToolStripItemImageScaling.None;
            this.btnSessionInfo.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.btnSessionInfo.Name = "btnSessionInfo";
            this.btnSessionInfo.Size = new System.Drawing.Size(38, 38);
            this.btnSessionInfo.Text = "toolStripButton1";
            this.btnSessionInfo.Click += new System.EventHandler(this.menuItemSessionInfo_Click);
            // 
            // toolStripSeparator8
            // 
            this.toolStripSeparator8.Name = "toolStripSeparator8";
            this.toolStripSeparator8.Size = new System.Drawing.Size(6, 40);
            // 
            // btnShowRegressionPoints
            // 
            this.btnShowRegressionPoints.AutoSize = false;
            this.btnShowRegressionPoints.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image;
            this.btnShowRegressionPoints.Enabled = false;
            this.btnShowRegressionPoints.Image = global::crash.Properties.Resources.regression_points_32;
            this.btnShowRegressionPoints.ImageScaling = System.Windows.Forms.ToolStripItemImageScaling.None;
            this.btnShowRegressionPoints.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.btnShowRegressionPoints.Name = "btnShowRegressionPoints";
            this.btnShowRegressionPoints.Size = new System.Drawing.Size(38, 38);
            this.btnShowRegressionPoints.Text = "toolStripButton1";
            this.btnShowRegressionPoints.ToolTipText = "Show Regression points";
            this.btnShowRegressionPoints.Click += new System.EventHandler(this.menuItemRegressionPoints_Click);
            // 
            // btnShowROITable
            // 
            this.btnShowROITable.AutoSize = false;
            this.btnShowROITable.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image;
            this.btnShowROITable.Image = global::crash.Properties.Resources.roi_table_32;
            this.btnShowROITable.ImageScaling = System.Windows.Forms.ToolStripItemImageScaling.None;
            this.btnShowROITable.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.btnShowROITable.Name = "btnShowROITable";
            this.btnShowROITable.Size = new System.Drawing.Size(38, 38);
            this.btnShowROITable.Text = "toolStripButton1";
            this.btnShowROITable.ToolTipText = "Show ROI Table";
            this.btnShowROITable.Click += new System.EventHandler(this.menuItemROITable_Click);
            // 
            // toolStripSeparator6
            // 
            this.toolStripSeparator6.Name = "toolStripSeparator6";
            this.toolStripSeparator6.Size = new System.Drawing.Size(6, 40);
            // 
            // btnShowMap
            // 
            this.btnShowMap.AutoSize = false;
            this.btnShowMap.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image;
            this.btnShowMap.Enabled = false;
            this.btnShowMap.Image = global::crash.Properties.Resources.map_32;
            this.btnShowMap.ImageScaling = System.Windows.Forms.ToolStripItemImageScaling.None;
            this.btnShowMap.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.btnShowMap.Name = "btnShowMap";
            this.btnShowMap.Size = new System.Drawing.Size(38, 38);
            this.btnShowMap.Text = "toolStripButton2";
            this.btnShowMap.ToolTipText = "Show map";
            this.btnShowMap.Click += new System.EventHandler(this.menuItemShowMap_Click);
            // 
            // btnShowWaterfallLive
            // 
            this.btnShowWaterfallLive.AutoSize = false;
            this.btnShowWaterfallLive.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image;
            this.btnShowWaterfallLive.Enabled = false;
            this.btnShowWaterfallLive.Image = global::crash.Properties.Resources.waterfall_live_32;
            this.btnShowWaterfallLive.ImageScaling = System.Windows.Forms.ToolStripItemImageScaling.None;
            this.btnShowWaterfallLive.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.btnShowWaterfallLive.Name = "btnShowWaterfallLive";
            this.btnShowWaterfallLive.Size = new System.Drawing.Size(38, 38);
            this.btnShowWaterfallLive.Text = "toolStripButton2";
            this.btnShowWaterfallLive.ToolTipText = "Show waterfall live";
            this.btnShowWaterfallLive.Click += new System.EventHandler(this.menuItemShowWaterfall_Click);
            // 
            // lblInterface
            // 
            this.lblInterface.Alignment = System.Windows.Forms.ToolStripItemAlignment.Right;
            this.lblInterface.Font = new System.Drawing.Font("Segoe UI", 9F, System.Drawing.FontStyle.Bold);
            this.lblInterface.Name = "lblInterface";
            this.lblInterface.Size = new System.Drawing.Size(88, 37);
            this.lblInterface.Text = "<lblInterface>";
            // 
            // separatorInterface
            // 
            this.separatorInterface.Alignment = System.Windows.Forms.ToolStripItemAlignment.Right;
            this.separatorInterface.Name = "separatorInterface";
            this.separatorInterface.Size = new System.Drawing.Size(6, 40);
            // 
            // lblDetector
            // 
            this.lblDetector.Alignment = System.Windows.Forms.ToolStripItemAlignment.Right;
            this.lblDetector.Name = "lblDetector";
            this.lblDetector.Size = new System.Drawing.Size(81, 37);
            this.lblDetector.Text = "<lblDetector>";
            // 
            // separatorDetector
            // 
            this.separatorDetector.Alignment = System.Windows.Forms.ToolStripItemAlignment.Right;
            this.separatorDetector.Name = "separatorDetector";
            this.separatorDetector.Size = new System.Drawing.Size(6, 40);
            // 
            // lblConnectionStatus
            // 
            this.lblConnectionStatus.Alignment = System.Windows.Forms.ToolStripItemAlignment.Right;
            this.lblConnectionStatus.Name = "lblConnectionStatus";
            this.lblConnectionStatus.Size = new System.Drawing.Size(130, 37);
            this.lblConnectionStatus.Text = "<lblConnectionStatus>";
            // 
            // btnShowROIHist
            // 
            this.btnShowROIHist.AutoSize = false;
            this.btnShowROIHist.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image;
            this.btnShowROIHist.Enabled = false;
            this.btnShowROIHist.Image = global::crash.Properties.Resources.doserate_32;
            this.btnShowROIHist.ImageScaling = System.Windows.Forms.ToolStripItemImageScaling.None;
            this.btnShowROIHist.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.btnShowROIHist.Name = "btnShowROIHist";
            this.btnShowROIHist.Size = new System.Drawing.Size(38, 38);
            this.btnShowROIHist.Text = "toolStripButton1";
            this.btnShowROIHist.ToolTipText = "Show ROI History";
            this.btnShowROIHist.Click += new System.EventHandler(this.menuItemShowROIHistory_Click);
            // 
            // btnShowROIChart
            // 
            this.btnShowROIChart.AutoSize = false;
            this.btnShowROIChart.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image;
            this.btnShowROIChart.Enabled = false;
            this.btnShowROIChart.Image = global::crash.Properties.Resources.roitable_history_32;
            this.btnShowROIChart.ImageScaling = System.Windows.Forms.ToolStripItemImageScaling.None;
            this.btnShowROIChart.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.btnShowROIChart.Name = "btnShowROIChart";
            this.btnShowROIChart.Size = new System.Drawing.Size(38, 38);
            this.btnShowROIChart.Text = "toolStripButton1";
            this.btnShowROIChart.ToolTipText = "Show ROI live";
            this.btnShowROIChart.Click += new System.EventHandler(this.menuItemShowROIChart_Click);
            // 
            // btnShow3D
            // 
            this.btnShow3D.AutoSize = false;
            this.btnShow3D.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image;
            this.btnShow3D.Enabled = false;
            this.btnShow3D.Image = global::crash.Properties.Resources._3D_32;
            this.btnShow3D.ImageScaling = System.Windows.Forms.ToolStripItemImageScaling.None;
            this.btnShow3D.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.btnShow3D.Name = "btnShow3D";
            this.btnShow3D.Size = new System.Drawing.Size(38, 38);
            this.btnShow3D.Text = "toolStripButton1";
            this.btnShow3D.ToolTipText = "Show 3D session";
            this.btnShow3D.Click += new System.EventHandler(this.menuItemShow3DMap_Click);
            // 
            // tabs
            // 
            this.tabs.Controls.Add(this.pageSetup);
            this.tabs.Controls.Add(this.pageMenu);
            this.tabs.Controls.Add(this.pageSession);
            this.tabs.Dock = System.Windows.Forms.DockStyle.Fill;
            this.tabs.Location = new System.Drawing.Point(0, 64);
            this.tabs.Name = "tabs";
            this.tabs.SelectedIndex = 0;
            this.tabs.Size = new System.Drawing.Size(1110, 600);
            this.tabs.TabIndex = 4;
            this.tabs.SelectedIndexChanged += new System.EventHandler(this.tabs_SelectedIndexChanged);
            // 
            // pageSetup
            // 
            this.pageSetup.BackColor = System.Drawing.SystemColors.ButtonFace;
            this.pageSetup.Controls.Add(this.graphSetup);
            this.pageSetup.Controls.Add(this.panel2);
            this.pageSetup.Controls.Add(this.tableLayoutSetup);
            this.pageSetup.Location = new System.Drawing.Point(4, 25);
            this.pageSetup.Name = "pageSetup";
            this.pageSetup.Padding = new System.Windows.Forms.Padding(3);
            this.pageSetup.Size = new System.Drawing.Size(1102, 571);
            this.pageSetup.TabIndex = 0;
            this.pageSetup.Text = "Setup";
            // 
            // graphSetup
            // 
            this.graphSetup.Dock = System.Windows.Forms.DockStyle.Fill;
            this.graphSetup.IsShowPointValues = true;
            this.graphSetup.Location = new System.Drawing.Point(3, 171);
            this.graphSetup.Name = "graphSetup";
            this.graphSetup.ScrollGrace = 0D;
            this.graphSetup.ScrollMaxX = 0D;
            this.graphSetup.ScrollMaxY = 0D;
            this.graphSetup.ScrollMaxY2 = 0D;
            this.graphSetup.ScrollMinX = 0D;
            this.graphSetup.ScrollMinY = 0D;
            this.graphSetup.ScrollMinY2 = 0D;
            this.graphSetup.Size = new System.Drawing.Size(1096, 377);
            this.graphSetup.TabIndex = 21;
            this.graphSetup.UseExtendedPrintDialog = true;
            this.graphSetup.MouseMove += new System.Windows.Forms.MouseEventHandler(this.graphSetup_MouseMove);
            // 
            // panel2
            // 
            this.panel2.Controls.Add(this.lblSetupEnergy);
            this.panel2.Controls.Add(this.lblSetupChannel);
            this.panel2.Dock = System.Windows.Forms.DockStyle.Bottom;
            this.panel2.Location = new System.Drawing.Point(3, 548);
            this.panel2.Name = "panel2";
            this.panel2.Size = new System.Drawing.Size(1096, 20);
            this.panel2.TabIndex = 22;
            // 
            // lblSetupEnergy
            // 
            this.lblSetupEnergy.AutoSize = true;
            this.lblSetupEnergy.Dock = System.Windows.Forms.DockStyle.Left;
            this.lblSetupEnergy.Location = new System.Drawing.Point(112, 0);
            this.lblSetupEnergy.Name = "lblSetupEnergy";
            this.lblSetupEnergy.Size = new System.Drawing.Size(104, 15);
            this.lblSetupEnergy.TabIndex = 1;
            this.lblSetupEnergy.Text = "<lblSetupEnergy>";
            // 
            // lblSetupChannel
            // 
            this.lblSetupChannel.AutoSize = true;
            this.lblSetupChannel.Dock = System.Windows.Forms.DockStyle.Left;
            this.lblSetupChannel.Font = new System.Drawing.Font("Microsoft Sans Serif", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblSetupChannel.Location = new System.Drawing.Point(0, 0);
            this.lblSetupChannel.Name = "lblSetupChannel";
            this.lblSetupChannel.Size = new System.Drawing.Size(112, 15);
            this.lblSetupChannel.TabIndex = 0;
            this.lblSetupChannel.Text = "<lblSetupChannel>";
            // 
            // tableLayoutSetup
            // 
            this.tableLayoutSetup.ColumnCount = 7;
            this.tableLayoutSetup.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 10.33995F));
            this.tableLayoutSetup.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 21.07858F));
            this.tableLayoutSetup.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 10.33995F));
            this.tableLayoutSetup.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 21.07857F));
            this.tableLayoutSetup.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 5.744418F));
            this.tableLayoutSetup.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 10.33995F));
            this.tableLayoutSetup.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 21.07858F));
            this.tableLayoutSetup.Controls.Add(this.label2, 0, 1);
            this.tableLayoutSetup.Controls.Add(this.label6, 0, 2);
            this.tableLayoutSetup.Controls.Add(this.label3, 0, 0);
            this.tableLayoutSetup.Controls.Add(this.cboxSetupDetector, 1, 1);
            this.tableLayoutSetup.Controls.Add(this.label5, 5, 0);
            this.tableLayoutSetup.Controls.Add(this.label11, 5, 1);
            this.tableLayoutSetup.Controls.Add(this.cboxSetupChannels, 3, 1);
            this.tableLayoutSetup.Controls.Add(this.label4, 2, 1);
            this.tableLayoutSetup.Controls.Add(this.label7, 0, 3);
            this.tableLayoutSetup.Controls.Add(this.btnSetupStart, 6, 2);
            this.tableLayoutSetup.Controls.Add(this.btnSetupStop, 6, 3);
            this.tableLayoutSetup.Controls.Add(this.label8, 0, 4);
            this.tableLayoutSetup.Controls.Add(this.label9, 2, 2);
            this.tableLayoutSetup.Controls.Add(this.label10, 2, 3);
            this.tableLayoutSetup.Controls.Add(this.cboxSetupCoarseGain, 1, 3);
            this.tableLayoutSetup.Controls.Add(this.panel3, 1, 4);
            this.tableLayoutSetup.Controls.Add(this.panel4, 3, 4);
            this.tableLayoutSetup.Controls.Add(this.panel5, 1, 2);
            this.tableLayoutSetup.Controls.Add(this.panel6, 3, 2);
            this.tableLayoutSetup.Controls.Add(this.panel7, 3, 3);
            this.tableLayoutSetup.Controls.Add(this.panel8, 6, 1);
            this.tableLayoutSetup.Dock = System.Windows.Forms.DockStyle.Top;
            this.tableLayoutSetup.Location = new System.Drawing.Point(3, 3);
            this.tableLayoutSetup.Name = "tableLayoutSetup";
            this.tableLayoutSetup.RowCount = 6;
            this.tableLayoutSetup.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 36F));
            this.tableLayoutSetup.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 28F));
            this.tableLayoutSetup.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 28F));
            this.tableLayoutSetup.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 28F));
            this.tableLayoutSetup.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 28F));
            this.tableLayoutSetup.RowStyles.Add(new System.Windows.Forms.RowStyle());
            this.tableLayoutSetup.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 20F));
            this.tableLayoutSetup.Size = new System.Drawing.Size(1096, 168);
            this.tableLayoutSetup.TabIndex = 20;
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Dock = System.Windows.Forms.DockStyle.Fill;
            this.label2.Font = new System.Drawing.Font("Microsoft Sans Serif", 9F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label2.Location = new System.Drawing.Point(3, 36);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(107, 28);
            this.label2.TabIndex = 18;
            this.label2.Text = "Detector";
            this.label2.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // label6
            // 
            this.label6.AutoSize = true;
            this.label6.Dock = System.Windows.Forms.DockStyle.Fill;
            this.label6.Font = new System.Drawing.Font("Microsoft Sans Serif", 9F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label6.Location = new System.Drawing.Point(3, 64);
            this.label6.Name = "label6";
            this.label6.Size = new System.Drawing.Size(107, 28);
            this.label6.TabIndex = 31;
            this.label6.Text = "Voltage";
            this.label6.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.tableLayoutSetup.SetColumnSpan(this.label3, 2);
            this.label3.Dock = System.Windows.Forms.DockStyle.Fill;
            this.label3.Font = new System.Drawing.Font("Microsoft Sans Serif", 11F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label3.ForeColor = System.Drawing.SystemColors.GrayText;
            this.label3.Location = new System.Drawing.Point(3, 0);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(338, 36);
            this.label3.TabIndex = 36;
            this.label3.Text = "Configure detector";
            this.label3.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // cboxSetupDetector
            // 
            this.cboxSetupDetector.Dock = System.Windows.Forms.DockStyle.Fill;
            this.cboxSetupDetector.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cboxSetupDetector.FormattingEnabled = true;
            this.cboxSetupDetector.Location = new System.Drawing.Point(116, 39);
            this.cboxSetupDetector.Name = "cboxSetupDetector";
            this.cboxSetupDetector.Size = new System.Drawing.Size(225, 23);
            this.cboxSetupDetector.TabIndex = 39;
            this.cboxSetupDetector.SelectedIndexChanged += new System.EventHandler(this.cboxSetupDetector_SelectedIndexChanged);
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.tableLayoutSetup.SetColumnSpan(this.label5, 2);
            this.label5.Dock = System.Windows.Forms.DockStyle.Fill;
            this.label5.Font = new System.Drawing.Font("Microsoft Sans Serif", 11F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label5.ForeColor = System.Drawing.SystemColors.GrayText;
            this.label5.Location = new System.Drawing.Point(753, 0);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(340, 36);
            this.label5.TabIndex = 37;
            this.label5.Text = "Aquire spectrum";
            this.label5.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // label11
            // 
            this.label11.AutoSize = true;
            this.label11.Dock = System.Windows.Forms.DockStyle.Fill;
            this.label11.Font = new System.Drawing.Font("Microsoft Sans Serif", 9F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label11.Location = new System.Drawing.Point(753, 36);
            this.label11.Name = "label11";
            this.label11.Size = new System.Drawing.Size(107, 28);
            this.label11.TabIndex = 38;
            this.label11.Text = "Livetime (s)";
            this.label11.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            // 
            // cboxSetupChannels
            // 
            this.cboxSetupChannels.Dock = System.Windows.Forms.DockStyle.Fill;
            this.cboxSetupChannels.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cboxSetupChannels.FormattingEnabled = true;
            this.cboxSetupChannels.Location = new System.Drawing.Point(460, 39);
            this.cboxSetupChannels.Name = "cboxSetupChannels";
            this.cboxSetupChannels.Size = new System.Drawing.Size(225, 23);
            this.cboxSetupChannels.TabIndex = 20;
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Dock = System.Windows.Forms.DockStyle.Fill;
            this.label4.Font = new System.Drawing.Font("Microsoft Sans Serif", 9F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label4.Location = new System.Drawing.Point(347, 36);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(107, 28);
            this.label4.TabIndex = 30;
            this.label4.Text = "#channels";
            this.label4.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // label7
            // 
            this.label7.AutoSize = true;
            this.label7.Dock = System.Windows.Forms.DockStyle.Fill;
            this.label7.Font = new System.Drawing.Font("Microsoft Sans Serif", 9F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label7.Location = new System.Drawing.Point(3, 92);
            this.label7.Name = "label7";
            this.label7.Size = new System.Drawing.Size(107, 28);
            this.label7.TabIndex = 32;
            this.label7.Text = "Coarse gain";
            this.label7.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // btnSetupStart
            // 
            this.btnSetupStart.Dock = System.Windows.Forms.DockStyle.Fill;
            this.btnSetupStart.Location = new System.Drawing.Point(866, 67);
            this.btnSetupStart.Name = "btnSetupStart";
            this.btnSetupStart.Size = new System.Drawing.Size(227, 22);
            this.btnSetupStart.TabIndex = 26;
            this.btnSetupStart.Text = "Start";
            this.btnSetupStart.UseVisualStyleBackColor = true;
            this.btnSetupStart.Click += new System.EventHandler(this.btnSetupStart_Click);
            // 
            // btnSetupStop
            // 
            this.btnSetupStop.Dock = System.Windows.Forms.DockStyle.Fill;
            this.btnSetupStop.Location = new System.Drawing.Point(866, 95);
            this.btnSetupStop.Name = "btnSetupStop";
            this.btnSetupStop.Size = new System.Drawing.Size(227, 22);
            this.btnSetupStop.TabIndex = 25;
            this.btnSetupStop.Text = "Stop";
            this.btnSetupStop.UseVisualStyleBackColor = true;
            this.btnSetupStop.Click += new System.EventHandler(this.btnSetupStop_Click);
            // 
            // label8
            // 
            this.label8.AutoSize = true;
            this.label8.Dock = System.Windows.Forms.DockStyle.Fill;
            this.label8.Font = new System.Drawing.Font("Microsoft Sans Serif", 9F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label8.Location = new System.Drawing.Point(3, 120);
            this.label8.Name = "label8";
            this.label8.Size = new System.Drawing.Size(107, 28);
            this.label8.TabIndex = 33;
            this.label8.Text = "Fine gain";
            this.label8.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // label9
            // 
            this.label9.AutoSize = true;
            this.label9.Dock = System.Windows.Forms.DockStyle.Fill;
            this.label9.Font = new System.Drawing.Font("Microsoft Sans Serif", 9F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label9.Location = new System.Drawing.Point(347, 64);
            this.label9.Name = "label9";
            this.label9.Size = new System.Drawing.Size(107, 28);
            this.label9.TabIndex = 34;
            this.label9.Text = "LLD (%)";
            this.label9.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // label10
            // 
            this.label10.AutoSize = true;
            this.label10.Dock = System.Windows.Forms.DockStyle.Fill;
            this.label10.Font = new System.Drawing.Font("Microsoft Sans Serif", 9F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label10.Location = new System.Drawing.Point(347, 92);
            this.label10.Name = "label10";
            this.label10.Size = new System.Drawing.Size(107, 28);
            this.label10.TabIndex = 35;
            this.label10.Text = "ULD (%)";
            this.label10.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // cboxSetupCoarseGain
            // 
            this.cboxSetupCoarseGain.Dock = System.Windows.Forms.DockStyle.Fill;
            this.cboxSetupCoarseGain.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cboxSetupCoarseGain.FormattingEnabled = true;
            this.cboxSetupCoarseGain.Items.AddRange(new object[] {
            "1",
            "2",
            "4",
            "8"});
            this.cboxSetupCoarseGain.Location = new System.Drawing.Point(116, 95);
            this.cboxSetupCoarseGain.Name = "cboxSetupCoarseGain";
            this.cboxSetupCoarseGain.Size = new System.Drawing.Size(225, 23);
            this.cboxSetupCoarseGain.TabIndex = 40;
            // 
            // panel3
            // 
            this.panel3.Controls.Add(this.tbarSetupFineGain);
            this.panel3.Controls.Add(this.lblSetupFineGain);
            this.panel3.Dock = System.Windows.Forms.DockStyle.Fill;
            this.panel3.Location = new System.Drawing.Point(116, 123);
            this.panel3.Name = "panel3";
            this.panel3.Size = new System.Drawing.Size(225, 22);
            this.panel3.TabIndex = 42;
            // 
            // tbarSetupFineGain
            // 
            this.tbarSetupFineGain.Dock = System.Windows.Forms.DockStyle.Fill;
            this.tbarSetupFineGain.LargeChange = 10;
            this.tbarSetupFineGain.Location = new System.Drawing.Point(0, 0);
            this.tbarSetupFineGain.Maximum = 5000;
            this.tbarSetupFineGain.Minimum = 1000;
            this.tbarSetupFineGain.Name = "tbarSetupFineGain";
            this.tbarSetupFineGain.Size = new System.Drawing.Size(211, 22);
            this.tbarSetupFineGain.TabIndex = 41;
            this.tbarSetupFineGain.TickStyle = System.Windows.Forms.TickStyle.None;
            this.tbarSetupFineGain.Value = 1000;
            this.tbarSetupFineGain.Scroll += new System.EventHandler(this.tbarSetupFineGain_Scroll);
            this.tbarSetupFineGain.ValueChanged += new System.EventHandler(this.tbarSetupFineGain_ValueChanged);
            // 
            // lblSetupFineGain
            // 
            this.lblSetupFineGain.AutoSize = true;
            this.lblSetupFineGain.Dock = System.Windows.Forms.DockStyle.Right;
            this.lblSetupFineGain.Location = new System.Drawing.Point(211, 0);
            this.lblSetupFineGain.Name = "lblSetupFineGain";
            this.lblSetupFineGain.Size = new System.Drawing.Size(14, 15);
            this.lblSetupFineGain.TabIndex = 42;
            this.lblSetupFineGain.Text = "1";
            // 
            // panel4
            // 
            this.panel4.Controls.Add(this.btnSetupSetParams);
            this.panel4.Dock = System.Windows.Forms.DockStyle.Fill;
            this.panel4.Location = new System.Drawing.Point(460, 123);
            this.panel4.Name = "panel4";
            this.panel4.Size = new System.Drawing.Size(225, 22);
            this.panel4.TabIndex = 43;
            // 
            // btnSetupSetParams
            // 
            this.btnSetupSetParams.Dock = System.Windows.Forms.DockStyle.Fill;
            this.btnSetupSetParams.Font = new System.Drawing.Font("Microsoft Sans Serif", 8F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnSetupSetParams.Location = new System.Drawing.Point(0, 0);
            this.btnSetupSetParams.Name = "btnSetupSetParams";
            this.btnSetupSetParams.Size = new System.Drawing.Size(225, 22);
            this.btnSetupSetParams.TabIndex = 16;
            this.btnSetupSetParams.Text = "Set detector params";
            this.btnSetupSetParams.UseVisualStyleBackColor = true;
            this.btnSetupSetParams.Click += new System.EventHandler(this.btnSetupSetParams_Click);
            // 
            // panel5
            // 
            this.panel5.Controls.Add(this.tbarSetupVoltage);
            this.panel5.Controls.Add(this.lblSetupVoltage);
            this.panel5.Dock = System.Windows.Forms.DockStyle.Fill;
            this.panel5.Location = new System.Drawing.Point(116, 67);
            this.panel5.Name = "panel5";
            this.panel5.Size = new System.Drawing.Size(225, 22);
            this.panel5.TabIndex = 44;
            // 
            // tbarSetupVoltage
            // 
            this.tbarSetupVoltage.Dock = System.Windows.Forms.DockStyle.Fill;
            this.tbarSetupVoltage.Location = new System.Drawing.Point(0, 0);
            this.tbarSetupVoltage.Name = "tbarSetupVoltage";
            this.tbarSetupVoltage.Size = new System.Drawing.Size(211, 22);
            this.tbarSetupVoltage.TabIndex = 1;
            this.tbarSetupVoltage.TickStyle = System.Windows.Forms.TickStyle.None;
            this.tbarSetupVoltage.ValueChanged += new System.EventHandler(this.tbarSetupVoltage_ValueChanged);
            // 
            // lblSetupVoltage
            // 
            this.lblSetupVoltage.AutoSize = true;
            this.lblSetupVoltage.Dock = System.Windows.Forms.DockStyle.Right;
            this.lblSetupVoltage.Location = new System.Drawing.Point(211, 0);
            this.lblSetupVoltage.Name = "lblSetupVoltage";
            this.lblSetupVoltage.Size = new System.Drawing.Size(14, 15);
            this.lblSetupVoltage.TabIndex = 0;
            this.lblSetupVoltage.Text = "1";
            // 
            // panel6
            // 
            this.panel6.Controls.Add(this.tbarSetupLLD);
            this.panel6.Controls.Add(this.lblSetupLLD);
            this.panel6.Dock = System.Windows.Forms.DockStyle.Fill;
            this.panel6.Location = new System.Drawing.Point(460, 67);
            this.panel6.Name = "panel6";
            this.panel6.Size = new System.Drawing.Size(225, 22);
            this.panel6.TabIndex = 45;
            // 
            // tbarSetupLLD
            // 
            this.tbarSetupLLD.Dock = System.Windows.Forms.DockStyle.Fill;
            this.tbarSetupLLD.Location = new System.Drawing.Point(0, 0);
            this.tbarSetupLLD.Maximum = 100;
            this.tbarSetupLLD.Name = "tbarSetupLLD";
            this.tbarSetupLLD.Size = new System.Drawing.Size(211, 22);
            this.tbarSetupLLD.TabIndex = 1;
            this.tbarSetupLLD.TickStyle = System.Windows.Forms.TickStyle.None;
            this.tbarSetupLLD.ValueChanged += new System.EventHandler(this.tbarSetupLLD_ValueChanged);
            // 
            // lblSetupLLD
            // 
            this.lblSetupLLD.AutoSize = true;
            this.lblSetupLLD.Dock = System.Windows.Forms.DockStyle.Right;
            this.lblSetupLLD.Location = new System.Drawing.Point(211, 0);
            this.lblSetupLLD.Name = "lblSetupLLD";
            this.lblSetupLLD.Size = new System.Drawing.Size(14, 15);
            this.lblSetupLLD.TabIndex = 0;
            this.lblSetupLLD.Text = "0";
            // 
            // panel7
            // 
            this.panel7.Controls.Add(this.tbarSetupULD);
            this.panel7.Controls.Add(this.lblSetupULD);
            this.panel7.Dock = System.Windows.Forms.DockStyle.Fill;
            this.panel7.Location = new System.Drawing.Point(460, 95);
            this.panel7.Name = "panel7";
            this.panel7.Size = new System.Drawing.Size(225, 22);
            this.panel7.TabIndex = 46;
            // 
            // tbarSetupULD
            // 
            this.tbarSetupULD.Dock = System.Windows.Forms.DockStyle.Fill;
            this.tbarSetupULD.Location = new System.Drawing.Point(0, 0);
            this.tbarSetupULD.Maximum = 110;
            this.tbarSetupULD.Name = "tbarSetupULD";
            this.tbarSetupULD.Size = new System.Drawing.Size(211, 22);
            this.tbarSetupULD.TabIndex = 1;
            this.tbarSetupULD.TickStyle = System.Windows.Forms.TickStyle.None;
            this.tbarSetupULD.ValueChanged += new System.EventHandler(this.tbarSetupULD_ValueChanged);
            // 
            // lblSetupULD
            // 
            this.lblSetupULD.AutoSize = true;
            this.lblSetupULD.Dock = System.Windows.Forms.DockStyle.Right;
            this.lblSetupULD.Location = new System.Drawing.Point(211, 0);
            this.lblSetupULD.Name = "lblSetupULD";
            this.lblSetupULD.Size = new System.Drawing.Size(14, 15);
            this.lblSetupULD.TabIndex = 0;
            this.lblSetupULD.Text = "0";
            // 
            // panel8
            // 
            this.panel8.Controls.Add(this.tbarSetupLivetime);
            this.panel8.Controls.Add(this.lblSetupLivetime);
            this.panel8.Dock = System.Windows.Forms.DockStyle.Fill;
            this.panel8.Location = new System.Drawing.Point(866, 39);
            this.panel8.Name = "panel8";
            this.panel8.Size = new System.Drawing.Size(227, 22);
            this.panel8.TabIndex = 47;
            // 
            // tbarSetupLivetime
            // 
            this.tbarSetupLivetime.Dock = System.Windows.Forms.DockStyle.Fill;
            this.tbarSetupLivetime.Location = new System.Drawing.Point(0, 0);
            this.tbarSetupLivetime.Maximum = 256;
            this.tbarSetupLivetime.Minimum = 1;
            this.tbarSetupLivetime.Name = "tbarSetupLivetime";
            this.tbarSetupLivetime.Size = new System.Drawing.Size(213, 22);
            this.tbarSetupLivetime.TabIndex = 1;
            this.tbarSetupLivetime.TickStyle = System.Windows.Forms.TickStyle.None;
            this.tbarSetupLivetime.Value = 1;
            this.tbarSetupLivetime.ValueChanged += new System.EventHandler(this.tbarSetupLivetime_ValueChanged);
            // 
            // lblSetupLivetime
            // 
            this.lblSetupLivetime.AutoSize = true;
            this.lblSetupLivetime.Dock = System.Windows.Forms.DockStyle.Right;
            this.lblSetupLivetime.Location = new System.Drawing.Point(213, 0);
            this.lblSetupLivetime.Name = "lblSetupLivetime";
            this.lblSetupLivetime.Size = new System.Drawing.Size(14, 15);
            this.lblSetupLivetime.TabIndex = 0;
            this.lblSetupLivetime.Text = "1";
            // 
            // pageMenu
            // 
            this.pageMenu.BackColor = System.Drawing.SystemColors.ButtonFace;
            this.pageMenu.Controls.Add(this.flowLayoutPanel1);
            this.pageMenu.Location = new System.Drawing.Point(4, 25);
            this.pageMenu.Name = "pageMenu";
            this.pageMenu.Padding = new System.Windows.Forms.Padding(3);
            this.pageMenu.Size = new System.Drawing.Size(1102, 571);
            this.pageMenu.TabIndex = 1;
            this.pageMenu.Text = "Menu";
            // 
            // flowLayoutPanel1
            // 
            this.flowLayoutPanel1.Controls.Add(this.btnMenuSetup);
            this.flowLayoutPanel1.Controls.Add(this.btnMenuSession);
            this.flowLayoutPanel1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.flowLayoutPanel1.Location = new System.Drawing.Point(3, 3);
            this.flowLayoutPanel1.Name = "flowLayoutPanel1";
            this.flowLayoutPanel1.Padding = new System.Windows.Forms.Padding(44, 47, 44, 47);
            this.flowLayoutPanel1.Size = new System.Drawing.Size(1096, 565);
            this.flowLayoutPanel1.TabIndex = 1;
            // 
            // btnMenuSetup
            // 
            this.btnMenuSetup.FlatAppearance.BorderSize = 0;
            this.btnMenuSetup.FlatAppearance.MouseDownBackColor = System.Drawing.SystemColors.ButtonFace;
            this.btnMenuSetup.FlatAppearance.MouseOverBackColor = System.Drawing.SystemColors.ButtonFace;
            this.btnMenuSetup.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnMenuSetup.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnMenuSetup.Image = global::crash.Properties.Resources.setup_128;
            this.btnMenuSetup.ImageAlign = System.Drawing.ContentAlignment.TopCenter;
            this.btnMenuSetup.Location = new System.Drawing.Point(47, 50);
            this.btnMenuSetup.Name = "btnMenuSetup";
            this.btnMenuSetup.Size = new System.Drawing.Size(160, 170);
            this.btnMenuSetup.TabIndex = 0;
            this.btnMenuSetup.Text = "Calibrate";
            this.btnMenuSetup.TextAlign = System.Drawing.ContentAlignment.BottomCenter;
            this.btnMenuSetup.UseVisualStyleBackColor = true;
            this.btnMenuSetup.Click += new System.EventHandler(this.btnMenuSpec_Click);
            // 
            // btnMenuSession
            // 
            this.btnMenuSession.Enabled = false;
            this.btnMenuSession.FlatAppearance.BorderSize = 0;
            this.btnMenuSession.FlatAppearance.MouseDownBackColor = System.Drawing.SystemColors.ButtonFace;
            this.btnMenuSession.FlatAppearance.MouseOverBackColor = System.Drawing.SystemColors.ButtonFace;
            this.btnMenuSession.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnMenuSession.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnMenuSession.Image = global::crash.Properties.Resources.map_128;
            this.btnMenuSession.ImageAlign = System.Drawing.ContentAlignment.TopCenter;
            this.btnMenuSession.Location = new System.Drawing.Point(213, 50);
            this.btnMenuSession.Name = "btnMenuSession";
            this.btnMenuSession.Size = new System.Drawing.Size(160, 170);
            this.btnMenuSession.TabIndex = 2;
            this.btnMenuSession.Text = "Sessions";
            this.btnMenuSession.TextAlign = System.Drawing.ContentAlignment.BottomCenter;
            this.btnMenuSession.UseVisualStyleBackColor = true;
            this.btnMenuSession.Click += new System.EventHandler(this.btnMenuSession_Click);
            // 
            // pageSession
            // 
            this.pageSession.BackColor = System.Drawing.SystemColors.ButtonFace;
            this.pageSession.Controls.Add(this.splitContainer2);
            this.pageSession.Controls.Add(this.tblSession);
            this.pageSession.Location = new System.Drawing.Point(4, 25);
            this.pageSession.Name = "pageSession";
            this.pageSession.Padding = new System.Windows.Forms.Padding(3);
            this.pageSession.Size = new System.Drawing.Size(1102, 571);
            this.pageSession.TabIndex = 2;
            this.pageSession.Text = "Session";
            // 
            // splitContainer2
            // 
            this.splitContainer2.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.splitContainer2.Dock = System.Windows.Forms.DockStyle.Fill;
            this.splitContainer2.FixedPanel = System.Windows.Forms.FixedPanel.Panel1;
            this.splitContainer2.Location = new System.Drawing.Point(3, 51);
            this.splitContainer2.Name = "splitContainer2";
            // 
            // splitContainer2.Panel1
            // 
            this.splitContainer2.Panel1.Controls.Add(this.lbSession);
            // 
            // splitContainer2.Panel2
            // 
            this.splitContainer2.Panel2.Controls.Add(this.graphSession);
            this.splitContainer2.Panel2.Controls.Add(this.panel1);
            this.splitContainer2.Panel2.Controls.Add(this.tableLayoutPanel2);
            this.splitContainer2.Size = new System.Drawing.Size(1096, 517);
            this.splitContainer2.SplitterDistance = 185;
            this.splitContainer2.SplitterWidth = 5;
            this.splitContainer2.TabIndex = 6;
            // 
            // lbSession
            // 
            this.lbSession.BackColor = System.Drawing.SystemColors.ButtonFace;
            this.lbSession.BorderStyle = System.Windows.Forms.BorderStyle.None;
            this.lbSession.ContextMenuStrip = this.contextMenuSession;
            this.lbSession.Dock = System.Windows.Forms.DockStyle.Fill;
            this.lbSession.Font = new System.Drawing.Font("Microsoft Sans Serif", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lbSession.FormattingEnabled = true;
            this.lbSession.ItemHeight = 15;
            this.lbSession.Location = new System.Drawing.Point(0, 0);
            this.lbSession.Name = "lbSession";
            this.lbSession.SelectionMode = System.Windows.Forms.SelectionMode.MultiExtended;
            this.lbSession.Size = new System.Drawing.Size(183, 515);
            this.lbSession.TabIndex = 7;
            this.lbSession.SelectedIndexChanged += new System.EventHandler(this.lbSession_SelectedIndexChanged);
            // 
            // contextMenuSession
            // 
            this.contextMenuSession.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.menuItemSessionUnselect,
            this.menuItemSourceActivity});
            this.contextMenuSession.Name = "contextMenuSession";
            this.contextMenuSession.Size = new System.Drawing.Size(152, 48);
            // 
            // menuItemSessionUnselect
            // 
            this.menuItemSessionUnselect.Name = "menuItemSessionUnselect";
            this.menuItemSessionUnselect.Size = new System.Drawing.Size(151, 22);
            this.menuItemSessionUnselect.Text = "&Unselect";
            this.menuItemSessionUnselect.Click += new System.EventHandler(this.menuItemSessionUnselect_Click);
            // 
            // menuItemSourceActivity
            // 
            this.menuItemSourceActivity.Name = "menuItemSourceActivity";
            this.menuItemSourceActivity.Size = new System.Drawing.Size(151, 22);
            this.menuItemSourceActivity.Text = "&Source activity";
            this.menuItemSourceActivity.Click += new System.EventHandler(this.menuItemSourceActivity_Click);
            // 
            // graphSession
            // 
            this.graphSession.Dock = System.Windows.Forms.DockStyle.Fill;
            this.graphSession.IsShowPointValues = true;
            this.graphSession.Location = new System.Drawing.Point(0, 112);
            this.graphSession.Name = "graphSession";
            this.graphSession.ScrollGrace = 0D;
            this.graphSession.ScrollMaxX = 0D;
            this.graphSession.ScrollMaxY = 0D;
            this.graphSession.ScrollMaxY2 = 0D;
            this.graphSession.ScrollMinX = 0D;
            this.graphSession.ScrollMinY = 0D;
            this.graphSession.ScrollMinY2 = 0D;
            this.graphSession.Size = new System.Drawing.Size(904, 383);
            this.graphSession.TabIndex = 5;
            this.graphSession.UseExtendedPrintDialog = true;
            this.graphSession.MouseMove += new System.Windows.Forms.MouseEventHandler(this.graphSession_MouseMove);
            // 
            // panel1
            // 
            this.panel1.Controls.Add(this.lblSessionEnergy);
            this.panel1.Controls.Add(this.lblSessionChannel);
            this.panel1.Dock = System.Windows.Forms.DockStyle.Bottom;
            this.panel1.Location = new System.Drawing.Point(0, 495);
            this.panel1.Name = "panel1";
            this.panel1.Size = new System.Drawing.Size(904, 20);
            this.panel1.TabIndex = 6;
            // 
            // lblSessionEnergy
            // 
            this.lblSessionEnergy.AutoSize = true;
            this.lblSessionEnergy.Dock = System.Windows.Forms.DockStyle.Left;
            this.lblSessionEnergy.Location = new System.Drawing.Point(124, 0);
            this.lblSessionEnergy.Name = "lblSessionEnergy";
            this.lblSessionEnergy.Size = new System.Drawing.Size(116, 15);
            this.lblSessionEnergy.TabIndex = 1;
            this.lblSessionEnergy.Text = "<lblSessionEnergy>";
            // 
            // lblSessionChannel
            // 
            this.lblSessionChannel.AutoSize = true;
            this.lblSessionChannel.Dock = System.Windows.Forms.DockStyle.Left;
            this.lblSessionChannel.Font = new System.Drawing.Font("Microsoft Sans Serif", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblSessionChannel.Location = new System.Drawing.Point(0, 0);
            this.lblSessionChannel.Name = "lblSessionChannel";
            this.lblSessionChannel.Size = new System.Drawing.Size(124, 15);
            this.lblSessionChannel.TabIndex = 0;
            this.lblSessionChannel.Text = "<lblSessionChannel>";
            // 
            // tableLayoutPanel2
            // 
            this.tableLayoutPanel2.ColumnCount = 4;
            this.tableLayoutPanel2.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 25F));
            this.tableLayoutPanel2.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 25F));
            this.tableLayoutPanel2.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 25F));
            this.tableLayoutPanel2.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 25F));
            this.tableLayoutPanel2.Controls.Add(this.lblLatitudeStart, 0, 2);
            this.tableLayoutPanel2.Controls.Add(this.lblLongitudeStart, 1, 2);
            this.tableLayoutPanel2.Controls.Add(this.lblAltitudeStart, 2, 2);
            this.tableLayoutPanel2.Controls.Add(this.lblMaxCount, 0, 4);
            this.tableLayoutPanel2.Controls.Add(this.lblMinCount, 1, 4);
            this.tableLayoutPanel2.Controls.Add(this.lblTotalCount, 2, 4);
            this.tableLayoutPanel2.Controls.Add(this.lblGpsTimeStart, 3, 2);
            this.tableLayoutPanel2.Controls.Add(this.lblLatitudeEnd, 0, 3);
            this.tableLayoutPanel2.Controls.Add(this.lblLongitudeEnd, 1, 3);
            this.tableLayoutPanel2.Controls.Add(this.lblAltitudeEnd, 2, 3);
            this.tableLayoutPanel2.Controls.Add(this.lblGpsTimeEnd, 3, 3);
            this.tableLayoutPanel2.Controls.Add(this.lblDoserate, 3, 4);
            this.tableLayoutPanel2.Controls.Add(this.lblSession, 0, 0);
            this.tableLayoutPanel2.Controls.Add(this.lblLivetime, 2, 1);
            this.tableLayoutPanel2.Controls.Add(this.lblRealtime, 1, 1);
            this.tableLayoutPanel2.Controls.Add(this.lblIndex, 0, 1);
            this.tableLayoutPanel2.Controls.Add(this.lblBackground, 3, 0);
            this.tableLayoutPanel2.Controls.Add(this.lblComment, 1, 0);
            this.tableLayoutPanel2.Dock = System.Windows.Forms.DockStyle.Top;
            this.tableLayoutPanel2.Location = new System.Drawing.Point(0, 0);
            this.tableLayoutPanel2.Name = "tableLayoutPanel2";
            this.tableLayoutPanel2.RowCount = 6;
            this.tableLayoutPanel2.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 20F));
            this.tableLayoutPanel2.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 20F));
            this.tableLayoutPanel2.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 20F));
            this.tableLayoutPanel2.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 20F));
            this.tableLayoutPanel2.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 20F));
            this.tableLayoutPanel2.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 20F));
            this.tableLayoutPanel2.Size = new System.Drawing.Size(904, 112);
            this.tableLayoutPanel2.TabIndex = 0;
            // 
            // lblLatitudeStart
            // 
            this.lblLatitudeStart.AutoSize = true;
            this.lblLatitudeStart.Dock = System.Windows.Forms.DockStyle.Fill;
            this.lblLatitudeStart.Font = new System.Drawing.Font("Microsoft Sans Serif", 8F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblLatitudeStart.Location = new System.Drawing.Point(3, 40);
            this.lblLatitudeStart.Name = "lblLatitudeStart";
            this.lblLatitudeStart.Size = new System.Drawing.Size(220, 20);
            this.lblLatitudeStart.TabIndex = 0;
            this.lblLatitudeStart.Text = "<LatitudeStart>";
            this.lblLatitudeStart.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // lblLongitudeStart
            // 
            this.lblLongitudeStart.AutoSize = true;
            this.lblLongitudeStart.Dock = System.Windows.Forms.DockStyle.Fill;
            this.lblLongitudeStart.Font = new System.Drawing.Font("Microsoft Sans Serif", 8F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblLongitudeStart.Location = new System.Drawing.Point(229, 40);
            this.lblLongitudeStart.Name = "lblLongitudeStart";
            this.lblLongitudeStart.Size = new System.Drawing.Size(220, 20);
            this.lblLongitudeStart.TabIndex = 1;
            this.lblLongitudeStart.Text = "<LongitudeStart>";
            this.lblLongitudeStart.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // lblAltitudeStart
            // 
            this.lblAltitudeStart.AutoSize = true;
            this.lblAltitudeStart.Dock = System.Windows.Forms.DockStyle.Fill;
            this.lblAltitudeStart.Font = new System.Drawing.Font("Microsoft Sans Serif", 8F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblAltitudeStart.Location = new System.Drawing.Point(455, 40);
            this.lblAltitudeStart.Name = "lblAltitudeStart";
            this.lblAltitudeStart.Size = new System.Drawing.Size(220, 20);
            this.lblAltitudeStart.TabIndex = 9;
            this.lblAltitudeStart.Text = "<AltitudeStart>";
            this.lblAltitudeStart.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // lblMaxCount
            // 
            this.lblMaxCount.AutoSize = true;
            this.lblMaxCount.Dock = System.Windows.Forms.DockStyle.Fill;
            this.lblMaxCount.Font = new System.Drawing.Font("Microsoft Sans Serif", 8F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblMaxCount.Location = new System.Drawing.Point(3, 80);
            this.lblMaxCount.Name = "lblMaxCount";
            this.lblMaxCount.Size = new System.Drawing.Size(220, 20);
            this.lblMaxCount.TabIndex = 6;
            this.lblMaxCount.Text = "<MaxCount>";
            this.lblMaxCount.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // lblMinCount
            // 
            this.lblMinCount.AutoSize = true;
            this.lblMinCount.Dock = System.Windows.Forms.DockStyle.Fill;
            this.lblMinCount.Font = new System.Drawing.Font("Microsoft Sans Serif", 8F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblMinCount.Location = new System.Drawing.Point(229, 80);
            this.lblMinCount.Name = "lblMinCount";
            this.lblMinCount.Size = new System.Drawing.Size(220, 20);
            this.lblMinCount.TabIndex = 7;
            this.lblMinCount.Text = "<MinCount>";
            this.lblMinCount.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // lblTotalCount
            // 
            this.lblTotalCount.AutoSize = true;
            this.lblTotalCount.Dock = System.Windows.Forms.DockStyle.Fill;
            this.lblTotalCount.Font = new System.Drawing.Font("Microsoft Sans Serif", 8F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblTotalCount.Location = new System.Drawing.Point(455, 80);
            this.lblTotalCount.Name = "lblTotalCount";
            this.lblTotalCount.Size = new System.Drawing.Size(220, 20);
            this.lblTotalCount.TabIndex = 8;
            this.lblTotalCount.Text = "<TotalCount>";
            this.lblTotalCount.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // lblGpsTimeStart
            // 
            this.lblGpsTimeStart.AutoSize = true;
            this.lblGpsTimeStart.Dock = System.Windows.Forms.DockStyle.Fill;
            this.lblGpsTimeStart.Font = new System.Drawing.Font("Microsoft Sans Serif", 8F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblGpsTimeStart.Location = new System.Drawing.Point(681, 40);
            this.lblGpsTimeStart.Name = "lblGpsTimeStart";
            this.lblGpsTimeStart.Size = new System.Drawing.Size(220, 20);
            this.lblGpsTimeStart.TabIndex = 10;
            this.lblGpsTimeStart.Text = "<GpsTimeStart>";
            this.lblGpsTimeStart.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // lblLatitudeEnd
            // 
            this.lblLatitudeEnd.AutoSize = true;
            this.lblLatitudeEnd.Dock = System.Windows.Forms.DockStyle.Fill;
            this.lblLatitudeEnd.Font = new System.Drawing.Font("Microsoft Sans Serif", 8F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblLatitudeEnd.Location = new System.Drawing.Point(3, 60);
            this.lblLatitudeEnd.Name = "lblLatitudeEnd";
            this.lblLatitudeEnd.Size = new System.Drawing.Size(220, 20);
            this.lblLatitudeEnd.TabIndex = 11;
            this.lblLatitudeEnd.Text = "<LatitudeEnd>";
            this.lblLatitudeEnd.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // lblLongitudeEnd
            // 
            this.lblLongitudeEnd.AutoSize = true;
            this.lblLongitudeEnd.Dock = System.Windows.Forms.DockStyle.Fill;
            this.lblLongitudeEnd.Font = new System.Drawing.Font("Microsoft Sans Serif", 8F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblLongitudeEnd.Location = new System.Drawing.Point(229, 60);
            this.lblLongitudeEnd.Name = "lblLongitudeEnd";
            this.lblLongitudeEnd.Size = new System.Drawing.Size(220, 20);
            this.lblLongitudeEnd.TabIndex = 12;
            this.lblLongitudeEnd.Text = "<LongitudeEnd>";
            this.lblLongitudeEnd.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // lblAltitudeEnd
            // 
            this.lblAltitudeEnd.AutoSize = true;
            this.lblAltitudeEnd.Dock = System.Windows.Forms.DockStyle.Fill;
            this.lblAltitudeEnd.Font = new System.Drawing.Font("Microsoft Sans Serif", 8F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblAltitudeEnd.Location = new System.Drawing.Point(455, 60);
            this.lblAltitudeEnd.Name = "lblAltitudeEnd";
            this.lblAltitudeEnd.Size = new System.Drawing.Size(220, 20);
            this.lblAltitudeEnd.TabIndex = 13;
            this.lblAltitudeEnd.Text = "<AltitudeEnd>";
            this.lblAltitudeEnd.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // lblGpsTimeEnd
            // 
            this.lblGpsTimeEnd.AutoSize = true;
            this.lblGpsTimeEnd.Dock = System.Windows.Forms.DockStyle.Fill;
            this.lblGpsTimeEnd.Font = new System.Drawing.Font("Microsoft Sans Serif", 8F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblGpsTimeEnd.Location = new System.Drawing.Point(681, 60);
            this.lblGpsTimeEnd.Name = "lblGpsTimeEnd";
            this.lblGpsTimeEnd.Size = new System.Drawing.Size(220, 20);
            this.lblGpsTimeEnd.TabIndex = 14;
            this.lblGpsTimeEnd.Text = "<GpsTimeEnd>";
            this.lblGpsTimeEnd.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // lblDoserate
            // 
            this.lblDoserate.AutoSize = true;
            this.lblDoserate.Dock = System.Windows.Forms.DockStyle.Fill;
            this.lblDoserate.Font = new System.Drawing.Font("Microsoft Sans Serif", 8F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblDoserate.Location = new System.Drawing.Point(681, 80);
            this.lblDoserate.Name = "lblDoserate";
            this.lblDoserate.Size = new System.Drawing.Size(220, 20);
            this.lblDoserate.TabIndex = 15;
            this.lblDoserate.Text = "<Doserate>";
            this.lblDoserate.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // lblSession
            // 
            this.lblSession.AutoSize = true;
            this.lblSession.Dock = System.Windows.Forms.DockStyle.Fill;
            this.lblSession.Font = new System.Drawing.Font("Microsoft Sans Serif", 8F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblSession.Location = new System.Drawing.Point(3, 0);
            this.lblSession.Name = "lblSession";
            this.lblSession.Size = new System.Drawing.Size(220, 20);
            this.lblSession.TabIndex = 4;
            this.lblSession.Text = "<lblSession>";
            this.lblSession.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // lblLivetime
            // 
            this.lblLivetime.AutoSize = true;
            this.lblLivetime.Dock = System.Windows.Forms.DockStyle.Fill;
            this.lblLivetime.Font = new System.Drawing.Font("Microsoft Sans Serif", 8F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblLivetime.Location = new System.Drawing.Point(455, 20);
            this.lblLivetime.Name = "lblLivetime";
            this.lblLivetime.Size = new System.Drawing.Size(220, 20);
            this.lblLivetime.TabIndex = 3;
            this.lblLivetime.Text = "<Livetime>";
            this.lblLivetime.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // lblRealtime
            // 
            this.lblRealtime.AutoSize = true;
            this.lblRealtime.Dock = System.Windows.Forms.DockStyle.Fill;
            this.lblRealtime.Font = new System.Drawing.Font("Microsoft Sans Serif", 8F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblRealtime.Location = new System.Drawing.Point(229, 20);
            this.lblRealtime.Name = "lblRealtime";
            this.lblRealtime.Size = new System.Drawing.Size(220, 20);
            this.lblRealtime.TabIndex = 2;
            this.lblRealtime.Text = "<Realtime>";
            this.lblRealtime.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // lblIndex
            // 
            this.lblIndex.AutoSize = true;
            this.lblIndex.Dock = System.Windows.Forms.DockStyle.Fill;
            this.lblIndex.Font = new System.Drawing.Font("Microsoft Sans Serif", 8F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblIndex.Location = new System.Drawing.Point(3, 20);
            this.lblIndex.Name = "lblIndex";
            this.lblIndex.Size = new System.Drawing.Size(220, 20);
            this.lblIndex.TabIndex = 5;
            this.lblIndex.Text = "<Index>";
            this.lblIndex.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // lblBackground
            // 
            this.lblBackground.AutoSize = true;
            this.lblBackground.Dock = System.Windows.Forms.DockStyle.Fill;
            this.lblBackground.Font = new System.Drawing.Font("Microsoft Sans Serif", 8F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblBackground.Location = new System.Drawing.Point(681, 0);
            this.lblBackground.Name = "lblBackground";
            this.lblBackground.Size = new System.Drawing.Size(220, 20);
            this.lblBackground.TabIndex = 16;
            this.lblBackground.Text = "<lblBackground>";
            this.lblBackground.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // lblComment
            // 
            this.lblComment.AutoSize = true;
            this.tableLayoutPanel2.SetColumnSpan(this.lblComment, 2);
            this.lblComment.Dock = System.Windows.Forms.DockStyle.Fill;
            this.lblComment.Font = new System.Drawing.Font("Microsoft Sans Serif", 8F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblComment.Location = new System.Drawing.Point(229, 0);
            this.lblComment.Name = "lblComment";
            this.lblComment.Size = new System.Drawing.Size(446, 20);
            this.lblComment.TabIndex = 17;
            this.lblComment.Text = "<lblComment>";
            this.lblComment.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // tblSession
            // 
            this.tblSession.ColumnCount = 8;
            this.tblSession.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 22.22223F));
            this.tblSession.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 11.11111F));
            this.tblSession.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 11.11111F));
            this.tblSession.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 11.11111F));
            this.tblSession.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 11.11111F));
            this.tblSession.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 11.11111F));
            this.tblSession.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 11.11111F));
            this.tblSession.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 11.11111F));
            this.tblSession.Controls.Add(this.label1, 0, 0);
            this.tblSession.Controls.Add(this.tbSpecCount, 1, 0);
            this.tblSession.Controls.Add(this.tbSpecLivetime, 2, 0);
            this.tblSession.Controls.Add(this.tbSpecDelay, 3, 0);
            this.tblSession.Controls.Add(this.btnSendSession, 4, 0);
            this.tblSession.Controls.Add(this.btnStopSession, 5, 0);
            this.tblSession.Controls.Add(this.btnSendClose, 7, 0);
            this.tblSession.Dock = System.Windows.Forms.DockStyle.Top;
            this.tblSession.Location = new System.Drawing.Point(3, 3);
            this.tblSession.Name = "tblSession";
            this.tblSession.RowCount = 2;
            this.tblSession.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 30F));
            this.tblSession.RowStyles.Add(new System.Windows.Forms.RowStyle());
            this.tblSession.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 20F));
            this.tblSession.Size = new System.Drawing.Size(1096, 48);
            this.tblSession.TabIndex = 4;
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.label1.Font = new System.Drawing.Font("Microsoft Sans Serif", 9F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label1.Location = new System.Drawing.Point(3, 0);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(237, 30);
            this.label1.TabIndex = 0;
            this.label1.Text = "Spectrum count, livetime and delay";
            this.label1.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            // 
            // tbSpecCount
            // 
            this.tbSpecCount.Dock = System.Windows.Forms.DockStyle.Fill;
            this.tbSpecCount.Location = new System.Drawing.Point(246, 3);
            this.tbSpecCount.MaxLength = 5;
            this.tbSpecCount.Name = "tbSpecCount";
            this.tbSpecCount.Size = new System.Drawing.Size(115, 21);
            this.tbSpecCount.TabIndex = 18;
            // 
            // tbSpecLivetime
            // 
            this.tbSpecLivetime.Dock = System.Windows.Forms.DockStyle.Fill;
            this.tbSpecLivetime.Location = new System.Drawing.Point(367, 3);
            this.tbSpecLivetime.MaxLength = 5;
            this.tbSpecLivetime.Name = "tbSpecLivetime";
            this.tbSpecLivetime.Size = new System.Drawing.Size(115, 21);
            this.tbSpecLivetime.TabIndex = 19;
            // 
            // tbSpecDelay
            // 
            this.tbSpecDelay.Dock = System.Windows.Forms.DockStyle.Fill;
            this.tbSpecDelay.Location = new System.Drawing.Point(488, 3);
            this.tbSpecDelay.MaxLength = 5;
            this.tbSpecDelay.Name = "tbSpecDelay";
            this.tbSpecDelay.Size = new System.Drawing.Size(115, 21);
            this.tbSpecDelay.TabIndex = 20;
            // 
            // btnSendSession
            // 
            this.btnSendSession.Dock = System.Windows.Forms.DockStyle.Fill;
            this.btnSendSession.Location = new System.Drawing.Point(609, 3);
            this.btnSendSession.Name = "btnSendSession";
            this.btnSendSession.Size = new System.Drawing.Size(115, 24);
            this.btnSendSession.TabIndex = 17;
            this.btnSendSession.Text = "Start new session";
            this.btnSendSession.UseVisualStyleBackColor = true;
            this.btnSendSession.Click += new System.EventHandler(this.btnSendSession_Click);
            // 
            // btnStopSession
            // 
            this.btnStopSession.Dock = System.Windows.Forms.DockStyle.Fill;
            this.btnStopSession.Location = new System.Drawing.Point(730, 3);
            this.btnStopSession.Name = "btnStopSession";
            this.btnStopSession.Size = new System.Drawing.Size(115, 24);
            this.btnStopSession.TabIndex = 21;
            this.btnStopSession.Text = "Stop session";
            this.btnStopSession.UseVisualStyleBackColor = true;
            this.btnStopSession.Click += new System.EventHandler(this.btnStopSession_Click);
            // 
            // btnSendClose
            // 
            this.btnSendClose.Dock = System.Windows.Forms.DockStyle.Fill;
            this.btnSendClose.Location = new System.Drawing.Point(972, 3);
            this.btnSendClose.Name = "btnSendClose";
            this.btnSendClose.Size = new System.Drawing.Size(121, 24);
            this.btnSendClose.TabIndex = 2;
            this.btnSendClose.Text = "Send close";
            this.btnSendClose.UseVisualStyleBackColor = true;
            this.btnSendClose.Click += new System.EventHandler(this.btnSendClose_Click);
            // 
            // FormMain
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(7F, 15F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(1110, 686);
            this.Controls.Add(this.tabs);
            this.Controls.Add(this.tools);
            this.Controls.Add(this.status);
            this.Controls.Add(this.menu);
            this.Font = new System.Drawing.Font("Microsoft Sans Serif", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.MainMenuStrip = this.menu;
            this.MinimumSize = new System.Drawing.Size(640, 480);
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
            this.pageSetup.ResumeLayout(false);
            this.panel2.ResumeLayout(false);
            this.panel2.PerformLayout();
            this.tableLayoutSetup.ResumeLayout(false);
            this.tableLayoutSetup.PerformLayout();
            this.panel3.ResumeLayout(false);
            this.panel3.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.tbarSetupFineGain)).EndInit();
            this.panel4.ResumeLayout(false);
            this.panel5.ResumeLayout(false);
            this.panel5.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.tbarSetupVoltage)).EndInit();
            this.panel6.ResumeLayout(false);
            this.panel6.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.tbarSetupLLD)).EndInit();
            this.panel7.ResumeLayout(false);
            this.panel7.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.tbarSetupULD)).EndInit();
            this.panel8.ResumeLayout(false);
            this.panel8.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.tbarSetupLivetime)).EndInit();
            this.pageMenu.ResumeLayout(false);
            this.flowLayoutPanel1.ResumeLayout(false);
            this.pageSession.ResumeLayout(false);
            this.splitContainer2.Panel1.ResumeLayout(false);
            this.splitContainer2.Panel2.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.splitContainer2)).EndInit();
            this.splitContainer2.ResumeLayout(false);
            this.contextMenuSession.ResumeLayout(false);
            this.panel1.ResumeLayout(false);
            this.panel1.PerformLayout();
            this.tableLayoutPanel2.ResumeLayout(false);
            this.tableLayoutPanel2.PerformLayout();
            this.tblSession.ResumeLayout(false);
            this.tblSession.PerformLayout();
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
        private TabControlWizard.TabControlWizard tabs;
        private System.Windows.Forms.TabPage pageSetup;
        private System.Windows.Forms.TabPage pageMenu;
        private System.Windows.Forms.FlowLayoutPanel flowLayoutPanel1;
        private System.Windows.Forms.Button btnMenuSetup;
        private System.Windows.Forms.ToolStripButton btnBack;
        private System.Windows.Forms.ToolStripSeparator toolStripSeparator2;
        private System.Windows.Forms.TabPage pageSession;
        private System.Windows.Forms.Button btnMenuSession;
        private System.Windows.Forms.TableLayoutPanel tblSession;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.TextBox tbSpecCount;
        private System.Windows.Forms.TextBox tbSpecLivetime;
        private System.Windows.Forms.TextBox tbSpecDelay;
        private System.Windows.Forms.Button btnSendSession;
        private System.Windows.Forms.Button btnStopSession;
        private System.Windows.Forms.Button btnSendClose;
        private System.Windows.Forms.SplitContainer splitContainer2;
        private System.Windows.Forms.ToolStripSeparator toolStripSeparator3;
        private System.Windows.Forms.TableLayoutPanel tableLayoutSetup;
        private System.Windows.Forms.Button btnSetupSetParams;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.ComboBox cboxSetupChannels;
        private System.Windows.Forms.Button btnSetupStop;
        private System.Windows.Forms.Button btnSetupStart;
        private System.Windows.Forms.ToolStripMenuItem menuItemEdit;
        private System.Windows.Forms.ToolStripMenuItem menuItemPreferences;
        private System.Windows.Forms.ToolStripButton btnPreferences;
        private System.Windows.Forms.ToolStripButton btnShowWaterfallLive;
        private System.Windows.Forms.ToolStripLabel lblInterface;
        private System.Windows.Forms.ToolStripSeparator separatorInterface;
        private System.Windows.Forms.ToolStripButton btnShowROIChart;
        private System.Windows.Forms.ListBox lbSession;
        private ZedGraph.ZedGraphControl graphSetup;
        private System.Windows.Forms.ToolStripButton btnShowMap;
        private System.Windows.Forms.ToolStripButton btnShowLog;
        private System.Windows.Forms.ToolStripSeparator toolStripSeparator5;
        private System.Windows.Forms.TableLayoutPanel tableLayoutPanel2;
        private ZedGraph.ZedGraphControl graphSession;
        private System.Windows.Forms.Label lblLatitudeStart;
        private System.Windows.Forms.Label lblLongitudeStart;
        private System.Windows.Forms.Label lblRealtime;
        private System.Windows.Forms.Label lblLivetime;
        private System.Windows.Forms.Label lblSession;
        private System.Windows.Forms.Label lblIndex;
        private System.Windows.Forms.Label lblMaxCount;
        private System.Windows.Forms.Label lblMinCount;
        private System.Windows.Forms.Label lblTotalCount;
        private System.Windows.Forms.Label lblAltitudeStart;
        private System.Windows.Forms.Label lblGpsTimeStart;
        private System.Windows.Forms.Label lblLatitudeEnd;
        private System.Windows.Forms.Label lblLongitudeEnd;
        private System.Windows.Forms.Label lblAltitudeEnd;
        private System.Windows.Forms.Label lblGpsTimeEnd;
        private System.Windows.Forms.ToolStripButton btnShow3D;
        private System.Windows.Forms.Label lblDoserate;
        private System.Windows.Forms.ToolStripMenuItem menuItemHelp;
        private System.Windows.Forms.ToolStripMenuItem menuItemAbout;
        private System.Windows.Forms.ToolStripMenuItem menuItemSession;
        private System.Windows.Forms.ToolStripMenuItem menuItemLoadSession;
        private System.Windows.Forms.ToolStripMenuItem menuItemLoadBackgroundSession;
        private System.Windows.Forms.ToolStripButton btnShowROITable;
        private System.Windows.Forms.ToolStripMenuItem menuItemROITable;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.Label label6;
        private System.Windows.Forms.Label label7;
        private System.Windows.Forms.Label label8;
        private System.Windows.Forms.Label label9;
        private System.Windows.Forms.Label label10;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.Label label5;
        private System.Windows.Forms.Label label11;
        private System.Windows.Forms.ToolStripButton btnShowRegressionPoints;
        private System.Windows.Forms.ToolStripSeparator toolStripSeparator6;
        private System.Windows.Forms.ToolStripLabel lblDetector;
        private System.Windows.Forms.ToolStripSeparator separatorDetector;
        private System.Windows.Forms.Panel panel1;
        private System.Windows.Forms.Label lblSessionChannel;
        private System.Windows.Forms.Panel panel2;
        private System.Windows.Forms.Label lblSetupChannel;
        private System.Windows.Forms.ContextMenuStrip contextMenuSession;
        private System.Windows.Forms.ToolStripMenuItem menuItemSessionUnselect;
        private System.Windows.Forms.ComboBox cboxSetupDetector;
        private System.Windows.Forms.ToolStripMenuItem menuItemSessionInfo;
        private System.Windows.Forms.ToolStripSeparator toolStripSeparator4;
        private System.Windows.Forms.ToolStripSeparator toolStripSeparator7;
        private System.Windows.Forms.ToolStripButton btnSessionInfo;
        private System.Windows.Forms.ToolStripSeparator toolStripSeparator8;
        private System.Windows.Forms.Label lblBackground;
        private System.Windows.Forms.ToolStripMenuItem menuItemClearSession;
        private System.Windows.Forms.ToolStripMenuItem menuItemClearBackground;
        private System.Windows.Forms.ToolStripButton btnShowROIHist;
        private System.Windows.Forms.Label lblSessionEnergy;
        private System.Windows.Forms.ToolStripMenuItem menuItemView;
        private System.Windows.Forms.ToolStripMenuItem menuItemShowMap;
        private System.Windows.Forms.ToolStripMenuItem menuItemShowWaterfall;
        private System.Windows.Forms.ToolStripMenuItem menuItemShowROIChart;
        private System.Windows.Forms.ToolStripMenuItem menuItemShowROIHistory;
        private System.Windows.Forms.ToolStripMenuItem menuItemShow3DMap;
        private System.Windows.Forms.ToolStripMenuItem menuItemBack;
        private System.Windows.Forms.ToolStripSeparator toolStripSeparator10;
        private System.Windows.Forms.ToolStripMenuItem menuItemShowLog;
        private System.Windows.Forms.ToolStripMenuItem menuItemExport;
        private System.Windows.Forms.ToolStripMenuItem menuItemSaveAsCHN;
        private System.Windows.Forms.ToolStripMenuItem menuItemSaveAsIRIX;
        private System.Windows.Forms.ToolStripMenuItem menuItemSaveAsKMZ;
        private System.Windows.Forms.Label lblSetupEnergy;
        private System.Windows.Forms.ToolStripMenuItem menuItemRegressionPoints;
        private System.Windows.Forms.Label lblComment;
        private System.Windows.Forms.ToolStripMenuItem menuItemSourceActivity;
        private System.Windows.Forms.ComboBox cboxSetupCoarseGain;
        private System.Windows.Forms.Panel panel3;
        private System.Windows.Forms.TrackBar tbarSetupFineGain;
        private System.Windows.Forms.Label lblSetupFineGain;
        private System.Windows.Forms.Panel panel4;
        private System.Windows.Forms.Panel panel5;
        private System.Windows.Forms.Label lblSetupVoltage;
        private System.Windows.Forms.TrackBar tbarSetupVoltage;
        private System.Windows.Forms.Panel panel6;
        private System.Windows.Forms.TrackBar tbarSetupLLD;
        private System.Windows.Forms.Label lblSetupLLD;
        private System.Windows.Forms.Panel panel7;
        private System.Windows.Forms.Label lblSetupULD;
        private System.Windows.Forms.TrackBar tbarSetupULD;
        private System.Windows.Forms.Panel panel8;
        private System.Windows.Forms.TrackBar tbarSetupLivetime;
        private System.Windows.Forms.Label lblSetupLivetime;
    }
}

