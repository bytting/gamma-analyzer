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
            this.menuItemSession = new System.Windows.Forms.ToolStripMenuItem();
            this.menuItemStartNewSession = new System.Windows.Forms.ToolStripMenuItem();
            this.menuItemStopSession = new System.Windows.Forms.ToolStripMenuItem();
            this.toolStripSeparator3 = new System.Windows.Forms.ToolStripSeparator();
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
            this.menuItemSaveAsCVS = new System.Windows.Forms.ToolStripMenuItem();
            this.menuItemView = new System.Windows.Forms.ToolStripMenuItem();
            this.menuItemShowLog = new System.Windows.Forms.ToolStripMenuItem();
            this.menuItemShowMap = new System.Windows.Forms.ToolStripMenuItem();
            this.menuItemShowWaterfall = new System.Windows.Forms.ToolStripMenuItem();
            this.menuItemROITable = new System.Windows.Forms.ToolStripMenuItem();
            this.menuItemShowROIHistory = new System.Windows.Forms.ToolStripMenuItem();
            this.menuItemShowROIChart = new System.Windows.Forms.ToolStripMenuItem();
            this.menuItemHelp = new System.Windows.Forms.ToolStripMenuItem();
            this.menuItemAbout = new System.Windows.Forms.ToolStripMenuItem();
            this.status = new System.Windows.Forms.StatusStrip();
            this.statusLabel = new System.Windows.Forms.ToolStripStatusLabel();
            this.lblLogMessages = new System.Windows.Forms.ToolStripStatusLabel();
            this.tools = new System.Windows.Forms.ToolStrip();
            this.btnBack = new System.Windows.Forms.ToolStripButton();
            this.toolStripSeparator2 = new System.Windows.Forms.ToolStripSeparator();
            this.btnShowLog = new System.Windows.Forms.ToolStripButton();
            this.toolStripSeparator8 = new System.Windows.Forms.ToolStripSeparator();
            this.btnConnect = new System.Windows.Forms.ToolStripButton();
            this.btnDisconnect = new System.Windows.Forms.ToolStripButton();
            this.toolStripSeparator6 = new System.Windows.Forms.ToolStripSeparator();
            this.btnStartNewSession = new System.Windows.Forms.ToolStripButton();
            this.btnStopSession = new System.Windows.Forms.ToolStripButton();
            this.btnSessionInfo = new System.Windows.Forms.ToolStripButton();
            this.toolStripSeparator5 = new System.Windows.Forms.ToolStripSeparator();
            this.btnShowMap = new System.Windows.Forms.ToolStripButton();
            this.btnShowWaterfallLive = new System.Windows.Forms.ToolStripButton();
            this.lblInterface = new System.Windows.Forms.ToolStripLabel();
            this.separatorInterface = new System.Windows.Forms.ToolStripSeparator();
            this.lblDetector = new System.Windows.Forms.ToolStripLabel();
            this.separatorDetector = new System.Windows.Forms.ToolStripSeparator();
            this.lblConnectionStatus = new System.Windows.Forms.ToolStripLabel();
            this.btnShowROITable = new System.Windows.Forms.ToolStripButton();
            this.btnShowROIHist = new System.Windows.Forms.ToolStripButton();
            this.btnShowROIChart = new System.Windows.Forms.ToolStripButton();
            this.menuItemRemoteCommands = new System.Windows.Forms.ToolStripDropDownButton();
            this.menuItemShutdownRemoteServer = new System.Windows.Forms.ToolStripMenuItem();
            this.btnSelectLayout = new System.Windows.Forms.ToolStripDropDownButton();
            this.menuItemLayoutSetup1 = new System.Windows.Forms.ToolStripMenuItem();
            this.menuItemLayoutSession1 = new System.Windows.Forms.ToolStripMenuItem();
            this.contextMenuSession = new System.Windows.Forms.ContextMenuStrip(this.components);
            this.menuItemSessionUnselect = new System.Windows.Forms.ToolStripMenuItem();
            this.menuItemSourceActivity = new System.Windows.Forms.ToolStripMenuItem();
            this.tabs = new System.Windows.Forms.TabControl();
            this.pageSetup = new System.Windows.Forms.TabPage();
            this.panelSetupGraph = new System.Windows.Forms.Panel();
            this.graphSetup = new ZedGraph.ZedGraphControl();
            this.contextMenuSetup = new System.Windows.Forms.ContextMenuStrip(this.components);
            this.menuItemResetCoefficients = new System.Windows.Forms.ToolStripMenuItem();
            this.menuItemStoreCoefficients = new System.Windows.Forms.ToolStripMenuItem();
            this.toolsSetup = new System.Windows.Forms.ToolStrip();
            this.toolStripLabel1 = new System.Windows.Forms.ToolStripLabel();
            this.tbSetupLivetime = new System.Windows.Forms.ToolStripTextBox();
            this.toolStripLabel2 = new System.Windows.Forms.ToolStripLabel();
            this.tbSetupSpectrumCount = new System.Windows.Forms.ToolStripTextBox();
            this.toolStripLabel3 = new System.Windows.Forms.ToolStripLabel();
            this.tbSetupDelay = new System.Windows.Forms.ToolStripTextBox();
            this.btnSetupStartTest = new System.Windows.Forms.ToolStripButton();
            this.btnSetupStopTest = new System.Windows.Forms.ToolStripButton();
            this.btnSetupResetCoefficients = new System.Windows.Forms.ToolStripButton();
            this.btnSetupStoreCoefficients = new System.Windows.Forms.ToolStripButton();
            this.panelSetup = new System.Windows.Forms.Panel();
            this.layoutConfigureDetector = new System.Windows.Forms.TableLayoutPanel();
            this.cboxSetupDetector = new System.Windows.Forms.ComboBox();
            this.cboxSetupChannels = new System.Windows.Forms.ComboBox();
            this.label6 = new System.Windows.Forms.Label();
            this.label4 = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.label3 = new System.Windows.Forms.Label();
            this.panel5 = new System.Windows.Forms.Panel();
            this.tbarSetupVoltage = new System.Windows.Forms.TrackBar();
            this.lblSetupVoltage = new System.Windows.Forms.Label();
            this.label9 = new System.Windows.Forms.Label();
            this.label10 = new System.Windows.Forms.Label();
            this.panel6 = new System.Windows.Forms.Panel();
            this.tbarSetupLLD = new System.Windows.Forms.TrackBar();
            this.lblSetupLLD = new System.Windows.Forms.Label();
            this.panel7 = new System.Windows.Forms.Panel();
            this.tbarSetupULD = new System.Windows.Forms.TrackBar();
            this.lblSetupULD = new System.Windows.Forms.Label();
            this.label7 = new System.Windows.Forms.Label();
            this.label8 = new System.Windows.Forms.Label();
            this.cboxSetupCoarseGain = new System.Windows.Forms.ComboBox();
            this.panel3 = new System.Windows.Forms.Panel();
            this.tbarSetupFineGain = new System.Windows.Forms.TrackBar();
            this.lblSetupFineGain = new System.Windows.Forms.Label();
            this.btnSetupSetParams = new System.Windows.Forms.Button();
            this.panel2 = new System.Windows.Forms.Panel();
            this.lblSetupCoefficients = new System.Windows.Forms.Label();
            this.lblSetupEnergy = new System.Windows.Forms.Label();
            this.lblSetupChannel = new System.Windows.Forms.Label();
            this.btnSetupBack = new System.Windows.Forms.Button();
            this.btnSetupNext = new System.Windows.Forms.Button();
            this.pageMenu = new System.Windows.Forms.TabPage();
            this.flowLayoutPanel1 = new System.Windows.Forms.FlowLayoutPanel();
            this.btnMenuSession = new System.Windows.Forms.Button();
            this.btnMenuPreferences = new System.Windows.Forms.Button();
            this.pageSessions = new System.Windows.Forms.TabPage();
            this.splitContainer2 = new System.Windows.Forms.SplitContainer();
            this.splitContainerSessionLeft = new System.Windows.Forms.SplitContainer();
            this.lbSession = new System.Windows.Forms.ListBox();
            this.panelNuclides = new System.Windows.Forms.Panel();
            this.lbNuclides = new System.Windows.Forms.ListBox();
            this.label12 = new System.Windows.Forms.Label();
            this.tbarNuclides = new System.Windows.Forms.TrackBar();
            this.label19 = new System.Windows.Forms.Label();
            this.graphSession = new ZedGraph.ZedGraphControl();
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
            this.lblBackground = new System.Windows.Forms.Label();
            this.lblComment = new System.Windows.Forms.Label();
            this.lblLivetime = new System.Windows.Forms.Label();
            this.lblRealtime = new System.Windows.Forms.Label();
            this.lblIndex = new System.Windows.Forms.Label();
            this.lblSessionDetector = new System.Windows.Forms.Label();
            this.toolsSession = new System.Windows.Forms.ToolStrip();
            this.btnOptions = new System.Windows.Forms.ToolStripDropDownButton();
            this.subtractBackgroundToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.panel1 = new System.Windows.Forms.Panel();
            this.lblSessionEnergy = new System.Windows.Forms.Label();
            this.lblSessionChannel = new System.Windows.Forms.Label();
            this.pagePreferences = new System.Windows.Forms.TabPage();
            this.tableLayoutPref = new System.Windows.Forms.TableLayoutPanel();
            this.lvDetectors = new System.Windows.Forms.ListView();
            this.columnHeaderSerialnumber = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.columnHeaderType = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.columnHeaderNumChannels = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.columnHeaderHV = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.columnHeaderCoarseGain = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.columnHeaderFineGain = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.columnHeaderLivetime = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.columnHeaderLLD = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.columnHeaderULD = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.columnHeaderRegScript = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.label1 = new System.Windows.Forms.Label();
            this.tbSessionDir = new System.Windows.Forms.TextBox();
            this.btnSetSessionDir = new System.Windows.Forms.Button();
            this.lvDetectorTypes = new System.Windows.Forms.ListView();
            this.columnHeaderName = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.columnHeaderMaxCH = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.columnHeaderMinHV = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.columnHeaderMaxHV = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.columnHeaderGScript = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.btnAddDetectorType = new System.Windows.Forms.Button();
            this.label17 = new System.Windows.Forms.Label();
            this.label18 = new System.Windows.Forms.Label();
            this.btnAddDetector = new System.Windows.Forms.Button();
            this.menu.SuspendLayout();
            this.status.SuspendLayout();
            this.tools.SuspendLayout();
            this.contextMenuSession.SuspendLayout();
            this.tabs.SuspendLayout();
            this.pageSetup.SuspendLayout();
            this.panelSetupGraph.SuspendLayout();
            this.contextMenuSetup.SuspendLayout();
            this.toolsSetup.SuspendLayout();
            this.panelSetup.SuspendLayout();
            this.layoutConfigureDetector.SuspendLayout();
            this.panel5.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.tbarSetupVoltage)).BeginInit();
            this.panel6.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.tbarSetupLLD)).BeginInit();
            this.panel7.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.tbarSetupULD)).BeginInit();
            this.panel3.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.tbarSetupFineGain)).BeginInit();
            this.panel2.SuspendLayout();
            this.pageMenu.SuspendLayout();
            this.flowLayoutPanel1.SuspendLayout();
            this.pageSessions.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.splitContainer2)).BeginInit();
            this.splitContainer2.Panel1.SuspendLayout();
            this.splitContainer2.Panel2.SuspendLayout();
            this.splitContainer2.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.splitContainerSessionLeft)).BeginInit();
            this.splitContainerSessionLeft.Panel1.SuspendLayout();
            this.splitContainerSessionLeft.Panel2.SuspendLayout();
            this.splitContainerSessionLeft.SuspendLayout();
            this.panelNuclides.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.tbarNuclides)).BeginInit();
            this.tableLayoutPanel2.SuspendLayout();
            this.toolsSession.SuspendLayout();
            this.panel1.SuspendLayout();
            this.pagePreferences.SuspendLayout();
            this.tableLayoutPref.SuspendLayout();
            this.SuspendLayout();
            // 
            // menu
            // 
            this.menu.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.menuItemFile,
            this.menuItemSession,
            this.menuItemView,
            this.menuItemHelp});
            this.menu.Location = new System.Drawing.Point(0, 0);
            this.menu.Name = "menu";
            this.menu.Padding = new System.Windows.Forms.Padding(7, 2, 0, 2);
            this.menu.Size = new System.Drawing.Size(1349, 24);
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
            // menuItemSession
            // 
            this.menuItemSession.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.menuItemStartNewSession,
            this.menuItemStopSession,
            this.toolStripSeparator3,
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
            // menuItemStartNewSession
            // 
            this.menuItemStartNewSession.Name = "menuItemStartNewSession";
            this.menuItemStartNewSession.Size = new System.Drawing.Size(209, 22);
            this.menuItemStartNewSession.Text = "Start new session";
            this.menuItemStartNewSession.Click += new System.EventHandler(this.menuItemStartNewSession_Click);
            // 
            // menuItemStopSession
            // 
            this.menuItemStopSession.Name = "menuItemStopSession";
            this.menuItemStopSession.Size = new System.Drawing.Size(209, 22);
            this.menuItemStopSession.Text = "Stop session";
            this.menuItemStopSession.Click += new System.EventHandler(this.menuItemStopSession_Click);
            // 
            // toolStripSeparator3
            // 
            this.toolStripSeparator3.Name = "toolStripSeparator3";
            this.toolStripSeparator3.Size = new System.Drawing.Size(206, 6);
            // 
            // menuItemLoadSession
            // 
            this.menuItemLoadSession.Name = "menuItemLoadSession";
            this.menuItemLoadSession.Size = new System.Drawing.Size(209, 22);
            this.menuItemLoadSession.Text = "Load &existing session";
            this.menuItemLoadSession.Click += new System.EventHandler(this.menuItemLoadSession_Click);
            // 
            // menuItemClearSession
            // 
            this.menuItemClearSession.Name = "menuItemClearSession";
            this.menuItemClearSession.Size = new System.Drawing.Size(209, 22);
            this.menuItemClearSession.Text = "C&lear session";
            this.menuItemClearSession.Click += new System.EventHandler(this.menuItemClearSession_Click);
            // 
            // menuItemSessionInfo
            // 
            this.menuItemSessionInfo.Name = "menuItemSessionInfo";
            this.menuItemSessionInfo.Size = new System.Drawing.Size(209, 22);
            this.menuItemSessionInfo.Text = "Edit &session info";
            this.menuItemSessionInfo.Click += new System.EventHandler(this.menuItemSessionInfo_Click);
            // 
            // toolStripSeparator4
            // 
            this.toolStripSeparator4.Name = "toolStripSeparator4";
            this.toolStripSeparator4.Size = new System.Drawing.Size(206, 6);
            // 
            // menuItemLoadBackgroundSession
            // 
            this.menuItemLoadBackgroundSession.Name = "menuItemLoadBackgroundSession";
            this.menuItemLoadBackgroundSession.Size = new System.Drawing.Size(209, 22);
            this.menuItemLoadBackgroundSession.Text = "Load &background session";
            this.menuItemLoadBackgroundSession.Click += new System.EventHandler(this.menuItemLoadBackgroundSession_Click);
            // 
            // menuItemClearBackground
            // 
            this.menuItemClearBackground.Name = "menuItemClearBackground";
            this.menuItemClearBackground.Size = new System.Drawing.Size(209, 22);
            this.menuItemClearBackground.Text = "Clear back&ground session";
            this.menuItemClearBackground.Click += new System.EventHandler(this.menuItemClearBackground_Click);
            // 
            // toolStripSeparator7
            // 
            this.toolStripSeparator7.Name = "toolStripSeparator7";
            this.toolStripSeparator7.Size = new System.Drawing.Size(206, 6);
            // 
            // menuItemExport
            // 
            this.menuItemExport.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.menuItemSaveAsCHN,
            this.menuItemSaveAsIRIX,
            this.menuItemSaveAsKMZ,
            this.menuItemSaveAsCVS});
            this.menuItemExport.Name = "menuItemExport";
            this.menuItemExport.Size = new System.Drawing.Size(209, 22);
            this.menuItemExport.Text = "E&xport session as ...";
            // 
            // menuItemSaveAsCHN
            // 
            this.menuItemSaveAsCHN.Name = "menuItemSaveAsCHN";
            this.menuItemSaveAsCHN.Size = new System.Drawing.Size(180, 22);
            this.menuItemSaveAsCHN.Text = "&CHN";
            this.menuItemSaveAsCHN.Click += new System.EventHandler(this.menuItemSaveAsCHN_Click);
            // 
            // menuItemSaveAsIRIX
            // 
            this.menuItemSaveAsIRIX.Name = "menuItemSaveAsIRIX";
            this.menuItemSaveAsIRIX.Size = new System.Drawing.Size(180, 22);
            this.menuItemSaveAsIRIX.Text = "&IRIX";
            // 
            // menuItemSaveAsKMZ
            // 
            this.menuItemSaveAsKMZ.Name = "menuItemSaveAsKMZ";
            this.menuItemSaveAsKMZ.Size = new System.Drawing.Size(180, 22);
            this.menuItemSaveAsKMZ.Text = "KM&Z";
            // 
            // menuItemSaveAsCVS
            // 
            this.menuItemSaveAsCVS.Name = "menuItemSaveAsCVS";
            this.menuItemSaveAsCVS.Size = new System.Drawing.Size(180, 22);
            this.menuItemSaveAsCVS.Text = "CVS (simple log file)";
            this.menuItemSaveAsCVS.Click += new System.EventHandler(this.menuItemSaveAsCVS_Click);
            // 
            // menuItemView
            // 
            this.menuItemView.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.menuItemShowLog,
            this.menuItemShowMap,
            this.menuItemShowWaterfall,
            this.menuItemROITable,
            this.menuItemShowROIHistory,
            this.menuItemShowROIChart});
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
            // menuItemROITable
            // 
            this.menuItemROITable.Name = "menuItemROITable";
            this.menuItemROITable.Size = new System.Drawing.Size(164, 22);
            this.menuItemROITable.Text = "Show ROI Table";
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
            this.statusLabel,
            this.lblLogMessages});
            this.status.Location = new System.Drawing.Point(0, 711);
            this.status.Name = "status";
            this.status.Padding = new System.Windows.Forms.Padding(1, 0, 17, 0);
            this.status.Size = new System.Drawing.Size(1349, 22);
            this.status.TabIndex = 1;
            this.status.Text = "statusStrip1";
            // 
            // statusLabel
            // 
            this.statusLabel.Name = "statusLabel";
            this.statusLabel.Size = new System.Drawing.Size(0, 17);
            // 
            // lblLogMessages
            // 
            this.lblLogMessages.Name = "lblLogMessages";
            this.lblLogMessages.Size = new System.Drawing.Size(107, 17);
            this.lblLogMessages.Text = "<lblLogMessages>";
            // 
            // tools
            // 
            this.tools.AutoSize = false;
            this.tools.GripStyle = System.Windows.Forms.ToolStripGripStyle.Hidden;
            this.tools.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.btnBack,
            this.toolStripSeparator2,
            this.btnShowLog,
            this.toolStripSeparator8,
            this.btnConnect,
            this.btnDisconnect,
            this.toolStripSeparator6,
            this.btnStartNewSession,
            this.btnStopSession,
            this.btnSessionInfo,
            this.toolStripSeparator5,
            this.btnShowMap,
            this.btnShowWaterfallLive,
            this.lblInterface,
            this.separatorInterface,
            this.lblDetector,
            this.separatorDetector,
            this.lblConnectionStatus,
            this.btnShowROITable,
            this.btnShowROIHist,
            this.btnShowROIChart,
            this.menuItemRemoteCommands,
            this.btnSelectLayout});
            this.tools.Location = new System.Drawing.Point(0, 24);
            this.tools.Name = "tools";
            this.tools.Size = new System.Drawing.Size(1349, 40);
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
            // toolStripSeparator8
            // 
            this.toolStripSeparator8.Name = "toolStripSeparator8";
            this.toolStripSeparator8.Size = new System.Drawing.Size(6, 40);
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
            this.btnConnect.Text = "toolStripButton1";
            this.btnConnect.ToolTipText = "Connect to remote device";
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
            this.btnDisconnect.Text = "toolStripButton1";
            this.btnDisconnect.ToolTipText = "Disconnect from remote device";
            this.btnDisconnect.Click += new System.EventHandler(this.menuItemDisconnect_Click);
            // 
            // toolStripSeparator6
            // 
            this.toolStripSeparator6.Name = "toolStripSeparator6";
            this.toolStripSeparator6.Size = new System.Drawing.Size(6, 40);
            // 
            // btnStartNewSession
            // 
            this.btnStartNewSession.AutoSize = false;
            this.btnStartNewSession.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image;
            this.btnStartNewSession.Image = global::crash.Properties.Resources.start_session_32;
            this.btnStartNewSession.ImageScaling = System.Windows.Forms.ToolStripItemImageScaling.None;
            this.btnStartNewSession.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.btnStartNewSession.Name = "btnStartNewSession";
            this.btnStartNewSession.Size = new System.Drawing.Size(38, 38);
            this.btnStartNewSession.Text = "toolStripButton1";
            this.btnStartNewSession.ToolTipText = "Create new session";
            this.btnStartNewSession.Click += new System.EventHandler(this.menuItemStartNewSession_Click);
            // 
            // btnStopSession
            // 
            this.btnStopSession.AutoSize = false;
            this.btnStopSession.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image;
            this.btnStopSession.Image = global::crash.Properties.Resources.stop_session_32;
            this.btnStopSession.ImageScaling = System.Windows.Forms.ToolStripItemImageScaling.None;
            this.btnStopSession.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.btnStopSession.Name = "btnStopSession";
            this.btnStopSession.Size = new System.Drawing.Size(38, 38);
            this.btnStopSession.Text = "toolStripButton1";
            this.btnStopSession.ToolTipText = "Stop session";
            this.btnStopSession.Click += new System.EventHandler(this.menuItemStopSession_Click);
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
            this.btnSessionInfo.ToolTipText = "Show session info";
            this.btnSessionInfo.Click += new System.EventHandler(this.menuItemSessionInfo_Click);
            // 
            // toolStripSeparator5
            // 
            this.toolStripSeparator5.Name = "toolStripSeparator5";
            this.toolStripSeparator5.Size = new System.Drawing.Size(6, 40);
            // 
            // btnShowMap
            // 
            this.btnShowMap.AutoSize = false;
            this.btnShowMap.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image;
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
            this.lblInterface.Font = new System.Drawing.Font("Segoe UI", 12F, System.Drawing.FontStyle.Bold);
            this.lblInterface.Name = "lblInterface";
            this.lblInterface.Size = new System.Drawing.Size(120, 37);
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
            // btnShowROIHist
            // 
            this.btnShowROIHist.AutoSize = false;
            this.btnShowROIHist.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image;
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
            this.btnShowROIChart.Image = global::crash.Properties.Resources.roitable_history_32;
            this.btnShowROIChart.ImageScaling = System.Windows.Forms.ToolStripItemImageScaling.None;
            this.btnShowROIChart.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.btnShowROIChart.Name = "btnShowROIChart";
            this.btnShowROIChart.Size = new System.Drawing.Size(38, 38);
            this.btnShowROIChart.Text = "toolStripButton1";
            this.btnShowROIChart.ToolTipText = "Show ROI live";
            this.btnShowROIChart.Click += new System.EventHandler(this.menuItemShowROIChart_Click);
            // 
            // menuItemRemoteCommands
            // 
            this.menuItemRemoteCommands.AutoSize = false;
            this.menuItemRemoteCommands.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image;
            this.menuItemRemoteCommands.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.menuItemShutdownRemoteServer});
            this.menuItemRemoteCommands.Image = global::crash.Properties.Resources.remote_control_32;
            this.menuItemRemoteCommands.ImageScaling = System.Windows.Forms.ToolStripItemImageScaling.None;
            this.menuItemRemoteCommands.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.menuItemRemoteCommands.Name = "menuItemRemoteCommands";
            this.menuItemRemoteCommands.Size = new System.Drawing.Size(38, 38);
            this.menuItemRemoteCommands.Text = "toolStripDropDownButton1";
            this.menuItemRemoteCommands.ToolTipText = "Remote commands";
            // 
            // menuItemShutdownRemoteServer
            // 
            this.menuItemShutdownRemoteServer.Name = "menuItemShutdownRemoteServer";
            this.menuItemShutdownRemoteServer.Size = new System.Drawing.Size(203, 22);
            this.menuItemShutdownRemoteServer.Text = "&Shutdown remote server";
            this.menuItemShutdownRemoteServer.Click += new System.EventHandler(this.menuItemShutdownRemoteServer_Click);
            // 
            // btnSelectLayout
            // 
            this.btnSelectLayout.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image;
            this.btnSelectLayout.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.menuItemLayoutSetup1,
            this.menuItemLayoutSession1});
            this.btnSelectLayout.Image = ((System.Drawing.Image)(resources.GetObject("btnSelectLayout.Image")));
            this.btnSelectLayout.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.btnSelectLayout.Name = "btnSelectLayout";
            this.btnSelectLayout.Size = new System.Drawing.Size(29, 37);
            this.btnSelectLayout.Text = "toolStripDropDownButton1";
            this.btnSelectLayout.ToolTipText = "Select pre-defined layout";
            // 
            // menuItemLayoutSetup1
            // 
            this.menuItemLayoutSetup1.Name = "menuItemLayoutSetup1";
            this.menuItemLayoutSetup1.Size = new System.Drawing.Size(152, 22);
            this.menuItemLayoutSetup1.Text = "Layout Setup";
            this.menuItemLayoutSetup1.Click += new System.EventHandler(this.menuItemLayoutSetup1_Click);
            // 
            // menuItemLayoutSession1
            // 
            this.menuItemLayoutSession1.Name = "menuItemLayoutSession1";
            this.menuItemLayoutSession1.Size = new System.Drawing.Size(152, 22);
            this.menuItemLayoutSession1.Text = "Layout Session";
            this.menuItemLayoutSession1.Click += new System.EventHandler(this.menuItemLayoutSession1_Click);
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
            // tabs
            // 
            this.tabs.Appearance = System.Windows.Forms.TabAppearance.FlatButtons;
            this.tabs.Controls.Add(this.pageSetup);
            this.tabs.Controls.Add(this.pageMenu);
            this.tabs.Controls.Add(this.pageSessions);
            this.tabs.Controls.Add(this.pagePreferences);
            this.tabs.Dock = System.Windows.Forms.DockStyle.Fill;
            this.tabs.Location = new System.Drawing.Point(0, 64);
            this.tabs.Name = "tabs";
            this.tabs.SelectedIndex = 0;
            this.tabs.Size = new System.Drawing.Size(1349, 647);
            this.tabs.TabIndex = 5;
            this.tabs.SelectedIndexChanged += new System.EventHandler(this.tabs_SelectedIndexChanged);
            // 
            // pageSetup
            // 
            this.pageSetup.BackColor = System.Drawing.SystemColors.ButtonFace;
            this.pageSetup.Controls.Add(this.panelSetupGraph);
            this.pageSetup.Controls.Add(this.panelSetup);
            this.pageSetup.Controls.Add(this.panel2);
            this.pageSetup.Location = new System.Drawing.Point(4, 27);
            this.pageSetup.Name = "pageSetup";
            this.pageSetup.Size = new System.Drawing.Size(1341, 616);
            this.pageSetup.TabIndex = 2;
            this.pageSetup.Text = "Setup";
            // 
            // panelSetupGraph
            // 
            this.panelSetupGraph.Controls.Add(this.graphSetup);
            this.panelSetupGraph.Controls.Add(this.toolsSetup);
            this.panelSetupGraph.Dock = System.Windows.Forms.DockStyle.Fill;
            this.panelSetupGraph.Location = new System.Drawing.Point(0, 143);
            this.panelSetupGraph.Name = "panelSetupGraph";
            this.panelSetupGraph.Size = new System.Drawing.Size(1341, 445);
            this.panelSetupGraph.TabIndex = 26;
            // 
            // graphSetup
            // 
            this.graphSetup.ContextMenuStrip = this.contextMenuSetup;
            this.graphSetup.Dock = System.Windows.Forms.DockStyle.Fill;
            this.graphSetup.IsShowPointValues = true;
            this.graphSetup.Location = new System.Drawing.Point(0, 25);
            this.graphSetup.Name = "graphSetup";
            this.graphSetup.ScrollGrace = 0D;
            this.graphSetup.ScrollMaxX = 0D;
            this.graphSetup.ScrollMaxY = 0D;
            this.graphSetup.ScrollMaxY2 = 0D;
            this.graphSetup.ScrollMinX = 0D;
            this.graphSetup.ScrollMinY = 0D;
            this.graphSetup.ScrollMinY2 = 0D;
            this.graphSetup.Size = new System.Drawing.Size(1341, 420);
            this.graphSetup.TabIndex = 24;
            this.graphSetup.UseExtendedPrintDialog = true;
            this.graphSetup.MouseDoubleClick += new System.Windows.Forms.MouseEventHandler(this.graphSetup_MouseDoubleClick);
            this.graphSetup.MouseMove += new System.Windows.Forms.MouseEventHandler(this.graphSetup_MouseMove);
            // 
            // contextMenuSetup
            // 
            this.contextMenuSetup.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.menuItemResetCoefficients,
            this.menuItemStoreCoefficients});
            this.contextMenuSetup.Name = "contextMenuSetup";
            this.contextMenuSetup.Size = new System.Drawing.Size(167, 48);
            // 
            // menuItemResetCoefficients
            // 
            this.menuItemResetCoefficients.Name = "menuItemResetCoefficients";
            this.menuItemResetCoefficients.Size = new System.Drawing.Size(166, 22);
            this.menuItemResetCoefficients.Text = "&Reset coefficients";
            this.menuItemResetCoefficients.Click += new System.EventHandler(this.menuItemResetCoefficients_Click);
            // 
            // menuItemStoreCoefficients
            // 
            this.menuItemStoreCoefficients.Name = "menuItemStoreCoefficients";
            this.menuItemStoreCoefficients.Size = new System.Drawing.Size(166, 22);
            this.menuItemStoreCoefficients.Text = "&Store coefficients";
            this.menuItemStoreCoefficients.Click += new System.EventHandler(this.menuItemStoreCoefficients_Click);
            // 
            // toolsSetup
            // 
            this.toolsSetup.GripStyle = System.Windows.Forms.ToolStripGripStyle.Hidden;
            this.toolsSetup.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.toolStripLabel1,
            this.tbSetupLivetime,
            this.toolStripLabel2,
            this.tbSetupSpectrumCount,
            this.toolStripLabel3,
            this.tbSetupDelay,
            this.btnSetupStartTest,
            this.btnSetupStopTest,
            this.btnSetupResetCoefficients,
            this.btnSetupStoreCoefficients});
            this.toolsSetup.Location = new System.Drawing.Point(0, 0);
            this.toolsSetup.Name = "toolsSetup";
            this.toolsSetup.Size = new System.Drawing.Size(1341, 25);
            this.toolsSetup.TabIndex = 0;
            this.toolsSetup.Text = "toolStrip1";
            // 
            // toolStripLabel1
            // 
            this.toolStripLabel1.Name = "toolStripLabel1";
            this.toolStripLabel1.Size = new System.Drawing.Size(52, 22);
            this.toolStripLabel1.Text = "Livetime";
            // 
            // tbSetupLivetime
            // 
            this.tbSetupLivetime.Name = "tbSetupLivetime";
            this.tbSetupLivetime.Size = new System.Drawing.Size(100, 25);
            this.tbSetupLivetime.ToolTipText = "Livetime used by the new session, in seconds";
            // 
            // toolStripLabel2
            // 
            this.toolStripLabel2.Name = "toolStripLabel2";
            this.toolStripLabel2.Size = new System.Drawing.Size(92, 22);
            this.toolStripLabel2.Text = "Spectrum count";
            // 
            // tbSetupSpectrumCount
            // 
            this.tbSetupSpectrumCount.Name = "tbSetupSpectrumCount";
            this.tbSetupSpectrumCount.Size = new System.Drawing.Size(100, 25);
            this.tbSetupSpectrumCount.ToolTipText = "Number of spectrums to take (empty for infinite)";
            // 
            // toolStripLabel3
            // 
            this.toolStripLabel3.Name = "toolStripLabel3";
            this.toolStripLabel3.Size = new System.Drawing.Size(36, 22);
            this.toolStripLabel3.Text = "Delay";
            // 
            // tbSetupDelay
            // 
            this.tbSetupDelay.Name = "tbSetupDelay";
            this.tbSetupDelay.Size = new System.Drawing.Size(100, 25);
            this.tbSetupDelay.ToolTipText = "Delay between spectrums, in seconds";
            // 
            // btnSetupStartTest
            // 
            this.btnSetupStartTest.Image = ((System.Drawing.Image)(resources.GetObject("btnSetupStartTest.Image")));
            this.btnSetupStartTest.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.btnSetupStartTest.Name = "btnSetupStartTest";
            this.btnSetupStartTest.Size = new System.Drawing.Size(126, 22);
            this.btnSetupStartTest.Text = "Start test spectrum";
            this.btnSetupStartTest.Click += new System.EventHandler(this.btnSetupStartTest_Click);
            // 
            // btnSetupStopTest
            // 
            this.btnSetupStopTest.Image = ((System.Drawing.Image)(resources.GetObject("btnSetupStopTest.Image")));
            this.btnSetupStopTest.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.btnSetupStopTest.Name = "btnSetupStopTest";
            this.btnSetupStopTest.Size = new System.Drawing.Size(126, 22);
            this.btnSetupStopTest.Text = "Stop test spectrum";
            this.btnSetupStopTest.Click += new System.EventHandler(this.btnSetupStopTest_Click);
            // 
            // btnSetupResetCoefficients
            // 
            this.btnSetupResetCoefficients.Alignment = System.Windows.Forms.ToolStripItemAlignment.Right;
            this.btnSetupResetCoefficients.Image = ((System.Drawing.Image)(resources.GetObject("btnSetupResetCoefficients.Image")));
            this.btnSetupResetCoefficients.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.btnSetupResetCoefficients.Name = "btnSetupResetCoefficients";
            this.btnSetupResetCoefficients.Size = new System.Drawing.Size(120, 22);
            this.btnSetupResetCoefficients.Text = "Clear energy lines";
            this.btnSetupResetCoefficients.ToolTipText = "Reset the current energy calibration";
            this.btnSetupResetCoefficients.Click += new System.EventHandler(this.menuItemResetCoefficients_Click);
            // 
            // btnSetupStoreCoefficients
            // 
            this.btnSetupStoreCoefficients.Alignment = System.Windows.Forms.ToolStripItemAlignment.Right;
            this.btnSetupStoreCoefficients.Image = ((System.Drawing.Image)(resources.GetObject("btnSetupStoreCoefficients.Image")));
            this.btnSetupStoreCoefficients.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.btnSetupStoreCoefficients.Name = "btnSetupStoreCoefficients";
            this.btnSetupStoreCoefficients.Size = new System.Drawing.Size(152, 22);
            this.btnSetupStoreCoefficients.Text = "Store energy calibration";
            this.btnSetupStoreCoefficients.ToolTipText = "Store the current energy calibration";
            this.btnSetupStoreCoefficients.Click += new System.EventHandler(this.menuItemStoreCoefficients_Click);
            // 
            // panelSetup
            // 
            this.panelSetup.Controls.Add(this.layoutConfigureDetector);
            this.panelSetup.Dock = System.Windows.Forms.DockStyle.Top;
            this.panelSetup.Location = new System.Drawing.Point(0, 0);
            this.panelSetup.Name = "panelSetup";
            this.panelSetup.Size = new System.Drawing.Size(1341, 143);
            this.panelSetup.TabIndex = 25;
            // 
            // layoutConfigureDetector
            // 
            this.layoutConfigureDetector.ColumnCount = 6;
            this.layoutConfigureDetector.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 11.11111F));
            this.layoutConfigureDetector.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 22.22222F));
            this.layoutConfigureDetector.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 11.11111F));
            this.layoutConfigureDetector.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 22.22222F));
            this.layoutConfigureDetector.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 11.11111F));
            this.layoutConfigureDetector.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 22.22222F));
            this.layoutConfigureDetector.Controls.Add(this.cboxSetupDetector, 1, 1);
            this.layoutConfigureDetector.Controls.Add(this.cboxSetupChannels, 3, 1);
            this.layoutConfigureDetector.Controls.Add(this.label6, 0, 2);
            this.layoutConfigureDetector.Controls.Add(this.label4, 2, 1);
            this.layoutConfigureDetector.Controls.Add(this.label2, 0, 1);
            this.layoutConfigureDetector.Controls.Add(this.label3, 0, 0);
            this.layoutConfigureDetector.Controls.Add(this.panel5, 1, 2);
            this.layoutConfigureDetector.Controls.Add(this.label9, 4, 1);
            this.layoutConfigureDetector.Controls.Add(this.label10, 4, 2);
            this.layoutConfigureDetector.Controls.Add(this.panel6, 5, 1);
            this.layoutConfigureDetector.Controls.Add(this.panel7, 5, 2);
            this.layoutConfigureDetector.Controls.Add(this.label7, 2, 2);
            this.layoutConfigureDetector.Controls.Add(this.label8, 2, 3);
            this.layoutConfigureDetector.Controls.Add(this.cboxSetupCoarseGain, 3, 2);
            this.layoutConfigureDetector.Controls.Add(this.panel3, 3, 3);
            this.layoutConfigureDetector.Controls.Add(this.btnSetupSetParams, 5, 3);
            this.layoutConfigureDetector.Dock = System.Windows.Forms.DockStyle.Fill;
            this.layoutConfigureDetector.Location = new System.Drawing.Point(0, 0);
            this.layoutConfigureDetector.Name = "layoutConfigureDetector";
            this.layoutConfigureDetector.RowCount = 5;
            this.layoutConfigureDetector.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 28F));
            this.layoutConfigureDetector.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 32F));
            this.layoutConfigureDetector.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 32F));
            this.layoutConfigureDetector.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 32F));
            this.layoutConfigureDetector.RowStyles.Add(new System.Windows.Forms.RowStyle());
            this.layoutConfigureDetector.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 20F));
            this.layoutConfigureDetector.Size = new System.Drawing.Size(1341, 143);
            this.layoutConfigureDetector.TabIndex = 23;
            // 
            // cboxSetupDetector
            // 
            this.cboxSetupDetector.Dock = System.Windows.Forms.DockStyle.Fill;
            this.cboxSetupDetector.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cboxSetupDetector.FormattingEnabled = true;
            this.cboxSetupDetector.Location = new System.Drawing.Point(152, 31);
            this.cboxSetupDetector.Name = "cboxSetupDetector";
            this.cboxSetupDetector.Size = new System.Drawing.Size(292, 23);
            this.cboxSetupDetector.TabIndex = 39;
            this.cboxSetupDetector.SelectedIndexChanged += new System.EventHandler(this.cboxSetupDetector_SelectedIndexChanged);
            // 
            // cboxSetupChannels
            // 
            this.cboxSetupChannels.Dock = System.Windows.Forms.DockStyle.Fill;
            this.cboxSetupChannels.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cboxSetupChannels.FormattingEnabled = true;
            this.cboxSetupChannels.Location = new System.Drawing.Point(599, 31);
            this.cboxSetupChannels.Name = "cboxSetupChannels";
            this.cboxSetupChannels.Size = new System.Drawing.Size(292, 23);
            this.cboxSetupChannels.TabIndex = 20;
            // 
            // label6
            // 
            this.label6.AutoSize = true;
            this.label6.Dock = System.Windows.Forms.DockStyle.Fill;
            this.label6.Font = new System.Drawing.Font("Microsoft Sans Serif", 9F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label6.Location = new System.Drawing.Point(3, 60);
            this.label6.Name = "label6";
            this.label6.Size = new System.Drawing.Size(143, 32);
            this.label6.TabIndex = 31;
            this.label6.Text = "Voltage";
            this.label6.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Dock = System.Windows.Forms.DockStyle.Fill;
            this.label4.Font = new System.Drawing.Font("Microsoft Sans Serif", 9F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label4.Location = new System.Drawing.Point(450, 28);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(143, 32);
            this.label4.TabIndex = 30;
            this.label4.Text = "#channels";
            this.label4.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Dock = System.Windows.Forms.DockStyle.Fill;
            this.label2.Font = new System.Drawing.Font("Microsoft Sans Serif", 9F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label2.Location = new System.Drawing.Point(3, 28);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(143, 32);
            this.label2.TabIndex = 18;
            this.label2.Text = "Detector";
            this.label2.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.layoutConfigureDetector.SetColumnSpan(this.label3, 6);
            this.label3.Dock = System.Windows.Forms.DockStyle.Fill;
            this.label3.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label3.ForeColor = System.Drawing.SystemColors.GrayText;
            this.label3.Location = new System.Drawing.Point(3, 0);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(1335, 28);
            this.label3.TabIndex = 0;
            this.label3.Text = "Configure detector";
            this.label3.TextAlign = System.Drawing.ContentAlignment.TopCenter;
            // 
            // panel5
            // 
            this.panel5.Controls.Add(this.tbarSetupVoltage);
            this.panel5.Controls.Add(this.lblSetupVoltage);
            this.panel5.Dock = System.Windows.Forms.DockStyle.Fill;
            this.panel5.Location = new System.Drawing.Point(152, 63);
            this.panel5.Name = "panel5";
            this.panel5.Size = new System.Drawing.Size(292, 26);
            this.panel5.TabIndex = 45;
            // 
            // tbarSetupVoltage
            // 
            this.tbarSetupVoltage.Dock = System.Windows.Forms.DockStyle.Fill;
            this.tbarSetupVoltage.Location = new System.Drawing.Point(0, 0);
            this.tbarSetupVoltage.Name = "tbarSetupVoltage";
            this.tbarSetupVoltage.Size = new System.Drawing.Size(278, 26);
            this.tbarSetupVoltage.TabIndex = 1;
            this.tbarSetupVoltage.TickStyle = System.Windows.Forms.TickStyle.None;
            this.tbarSetupVoltage.ValueChanged += new System.EventHandler(this.tbarSetupVoltage_ValueChanged);
            // 
            // lblSetupVoltage
            // 
            this.lblSetupVoltage.AutoSize = true;
            this.lblSetupVoltage.Dock = System.Windows.Forms.DockStyle.Right;
            this.lblSetupVoltage.Location = new System.Drawing.Point(278, 0);
            this.lblSetupVoltage.Name = "lblSetupVoltage";
            this.lblSetupVoltage.Size = new System.Drawing.Size(14, 15);
            this.lblSetupVoltage.TabIndex = 0;
            this.lblSetupVoltage.Text = "1";
            // 
            // label9
            // 
            this.label9.AutoSize = true;
            this.label9.Dock = System.Windows.Forms.DockStyle.Fill;
            this.label9.Font = new System.Drawing.Font("Microsoft Sans Serif", 9F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label9.Location = new System.Drawing.Point(897, 28);
            this.label9.Name = "label9";
            this.label9.Size = new System.Drawing.Size(143, 32);
            this.label9.TabIndex = 34;
            this.label9.Text = "LLD (%)";
            this.label9.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            // 
            // label10
            // 
            this.label10.AutoSize = true;
            this.label10.Dock = System.Windows.Forms.DockStyle.Fill;
            this.label10.Font = new System.Drawing.Font("Microsoft Sans Serif", 9F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label10.Location = new System.Drawing.Point(897, 60);
            this.label10.Name = "label10";
            this.label10.Size = new System.Drawing.Size(143, 32);
            this.label10.TabIndex = 35;
            this.label10.Text = "ULD (%)";
            this.label10.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            // 
            // panel6
            // 
            this.panel6.Controls.Add(this.tbarSetupLLD);
            this.panel6.Controls.Add(this.lblSetupLLD);
            this.panel6.Dock = System.Windows.Forms.DockStyle.Fill;
            this.panel6.Location = new System.Drawing.Point(1046, 31);
            this.panel6.Name = "panel6";
            this.panel6.Size = new System.Drawing.Size(292, 26);
            this.panel6.TabIndex = 45;
            // 
            // tbarSetupLLD
            // 
            this.tbarSetupLLD.Dock = System.Windows.Forms.DockStyle.Fill;
            this.tbarSetupLLD.Location = new System.Drawing.Point(0, 0);
            this.tbarSetupLLD.Maximum = 100;
            this.tbarSetupLLD.Name = "tbarSetupLLD";
            this.tbarSetupLLD.Size = new System.Drawing.Size(278, 26);
            this.tbarSetupLLD.TabIndex = 1;
            this.tbarSetupLLD.TickStyle = System.Windows.Forms.TickStyle.None;
            this.tbarSetupLLD.ValueChanged += new System.EventHandler(this.tbarSetupLLD_ValueChanged);
            // 
            // lblSetupLLD
            // 
            this.lblSetupLLD.AutoSize = true;
            this.lblSetupLLD.Dock = System.Windows.Forms.DockStyle.Right;
            this.lblSetupLLD.Location = new System.Drawing.Point(278, 0);
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
            this.panel7.Location = new System.Drawing.Point(1046, 63);
            this.panel7.Name = "panel7";
            this.panel7.Size = new System.Drawing.Size(292, 26);
            this.panel7.TabIndex = 46;
            // 
            // tbarSetupULD
            // 
            this.tbarSetupULD.Dock = System.Windows.Forms.DockStyle.Fill;
            this.tbarSetupULD.Location = new System.Drawing.Point(0, 0);
            this.tbarSetupULD.Maximum = 110;
            this.tbarSetupULD.Name = "tbarSetupULD";
            this.tbarSetupULD.Size = new System.Drawing.Size(278, 26);
            this.tbarSetupULD.TabIndex = 1;
            this.tbarSetupULD.TickStyle = System.Windows.Forms.TickStyle.None;
            this.tbarSetupULD.ValueChanged += new System.EventHandler(this.tbarSetupULD_ValueChanged);
            // 
            // lblSetupULD
            // 
            this.lblSetupULD.AutoSize = true;
            this.lblSetupULD.Dock = System.Windows.Forms.DockStyle.Right;
            this.lblSetupULD.Location = new System.Drawing.Point(278, 0);
            this.lblSetupULD.Name = "lblSetupULD";
            this.lblSetupULD.Size = new System.Drawing.Size(14, 15);
            this.lblSetupULD.TabIndex = 0;
            this.lblSetupULD.Text = "0";
            // 
            // label7
            // 
            this.label7.AutoSize = true;
            this.label7.Dock = System.Windows.Forms.DockStyle.Fill;
            this.label7.Font = new System.Drawing.Font("Microsoft Sans Serif", 9F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label7.Location = new System.Drawing.Point(450, 60);
            this.label7.Name = "label7";
            this.label7.Size = new System.Drawing.Size(143, 32);
            this.label7.TabIndex = 32;
            this.label7.Text = "Coarse gain";
            this.label7.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            // 
            // label8
            // 
            this.label8.AutoSize = true;
            this.label8.Dock = System.Windows.Forms.DockStyle.Fill;
            this.label8.Font = new System.Drawing.Font("Microsoft Sans Serif", 9F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label8.Location = new System.Drawing.Point(450, 92);
            this.label8.Name = "label8";
            this.label8.Size = new System.Drawing.Size(143, 32);
            this.label8.TabIndex = 33;
            this.label8.Text = "Fine gain";
            this.label8.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
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
            this.cboxSetupCoarseGain.Location = new System.Drawing.Point(599, 63);
            this.cboxSetupCoarseGain.Name = "cboxSetupCoarseGain";
            this.cboxSetupCoarseGain.Size = new System.Drawing.Size(292, 23);
            this.cboxSetupCoarseGain.TabIndex = 40;
            // 
            // panel3
            // 
            this.panel3.Controls.Add(this.tbarSetupFineGain);
            this.panel3.Controls.Add(this.lblSetupFineGain);
            this.panel3.Dock = System.Windows.Forms.DockStyle.Fill;
            this.panel3.Location = new System.Drawing.Point(599, 95);
            this.panel3.Name = "panel3";
            this.panel3.Size = new System.Drawing.Size(292, 26);
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
            this.tbarSetupFineGain.Size = new System.Drawing.Size(278, 26);
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
            this.lblSetupFineGain.Location = new System.Drawing.Point(278, 0);
            this.lblSetupFineGain.Name = "lblSetupFineGain";
            this.lblSetupFineGain.Size = new System.Drawing.Size(14, 15);
            this.lblSetupFineGain.TabIndex = 42;
            this.lblSetupFineGain.Text = "1";
            // 
            // btnSetupSetParams
            // 
            this.btnSetupSetParams.Dock = System.Windows.Forms.DockStyle.Fill;
            this.btnSetupSetParams.Font = new System.Drawing.Font("Microsoft Sans Serif", 8F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnSetupSetParams.Location = new System.Drawing.Point(1046, 95);
            this.btnSetupSetParams.Name = "btnSetupSetParams";
            this.btnSetupSetParams.Size = new System.Drawing.Size(292, 26);
            this.btnSetupSetParams.TabIndex = 16;
            this.btnSetupSetParams.Text = "Set detector params";
            this.btnSetupSetParams.UseVisualStyleBackColor = true;
            this.btnSetupSetParams.Click += new System.EventHandler(this.btnSetupSetParams_Click);
            // 
            // panel2
            // 
            this.panel2.Controls.Add(this.lblSetupCoefficients);
            this.panel2.Controls.Add(this.lblSetupEnergy);
            this.panel2.Controls.Add(this.lblSetupChannel);
            this.panel2.Controls.Add(this.btnSetupBack);
            this.panel2.Controls.Add(this.btnSetupNext);
            this.panel2.Dock = System.Windows.Forms.DockStyle.Bottom;
            this.panel2.Location = new System.Drawing.Point(0, 588);
            this.panel2.Name = "panel2";
            this.panel2.Size = new System.Drawing.Size(1341, 28);
            this.panel2.TabIndex = 22;
            // 
            // lblSetupCoefficients
            // 
            this.lblSetupCoefficients.AutoSize = true;
            this.lblSetupCoefficients.Dock = System.Windows.Forms.DockStyle.Left;
            this.lblSetupCoefficients.Location = new System.Drawing.Point(216, 0);
            this.lblSetupCoefficients.Name = "lblSetupCoefficients";
            this.lblSetupCoefficients.Size = new System.Drawing.Size(129, 15);
            this.lblSetupCoefficients.TabIndex = 6;
            this.lblSetupCoefficients.Text = "<lblSetupCoefficients>";
            // 
            // lblSetupEnergy
            // 
            this.lblSetupEnergy.AutoSize = true;
            this.lblSetupEnergy.Dock = System.Windows.Forms.DockStyle.Left;
            this.lblSetupEnergy.Location = new System.Drawing.Point(112, 0);
            this.lblSetupEnergy.Name = "lblSetupEnergy";
            this.lblSetupEnergy.Size = new System.Drawing.Size(104, 15);
            this.lblSetupEnergy.TabIndex = 5;
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
            this.lblSetupChannel.TabIndex = 4;
            this.lblSetupChannel.Text = "<lblSetupChannel>";
            // 
            // btnSetupBack
            // 
            this.btnSetupBack.Dock = System.Windows.Forms.DockStyle.Right;
            this.btnSetupBack.Font = new System.Drawing.Font("Microsoft Sans Serif", 9F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnSetupBack.Location = new System.Drawing.Point(1041, 0);
            this.btnSetupBack.Name = "btnSetupBack";
            this.btnSetupBack.Size = new System.Drawing.Size(150, 28);
            this.btnSetupBack.TabIndex = 3;
            this.btnSetupBack.Text = "Back";
            this.btnSetupBack.UseVisualStyleBackColor = true;
            this.btnSetupBack.Click += new System.EventHandler(this.btnSetupBack_Click);
            // 
            // btnSetupNext
            // 
            this.btnSetupNext.Dock = System.Windows.Forms.DockStyle.Right;
            this.btnSetupNext.Font = new System.Drawing.Font("Microsoft Sans Serif", 9F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnSetupNext.Location = new System.Drawing.Point(1191, 0);
            this.btnSetupNext.Name = "btnSetupNext";
            this.btnSetupNext.Size = new System.Drawing.Size(150, 28);
            this.btnSetupNext.TabIndex = 2;
            this.btnSetupNext.Text = "Start session";
            this.btnSetupNext.UseVisualStyleBackColor = true;
            this.btnSetupNext.Click += new System.EventHandler(this.btnSetupNext_Click);
            // 
            // pageMenu
            // 
            this.pageMenu.BackColor = System.Drawing.SystemColors.ButtonFace;
            this.pageMenu.Controls.Add(this.flowLayoutPanel1);
            this.pageMenu.Location = new System.Drawing.Point(4, 27);
            this.pageMenu.Name = "pageMenu";
            this.pageMenu.Size = new System.Drawing.Size(1341, 616);
            this.pageMenu.TabIndex = 3;
            this.pageMenu.Text = "Menu";
            // 
            // flowLayoutPanel1
            // 
            this.flowLayoutPanel1.Controls.Add(this.btnMenuSession);
            this.flowLayoutPanel1.Controls.Add(this.btnMenuPreferences);
            this.flowLayoutPanel1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.flowLayoutPanel1.Location = new System.Drawing.Point(0, 0);
            this.flowLayoutPanel1.Name = "flowLayoutPanel1";
            this.flowLayoutPanel1.Padding = new System.Windows.Forms.Padding(44, 47, 44, 47);
            this.flowLayoutPanel1.Size = new System.Drawing.Size(1341, 616);
            this.flowLayoutPanel1.TabIndex = 1;
            // 
            // btnMenuSession
            // 
            this.btnMenuSession.FlatAppearance.BorderSize = 0;
            this.btnMenuSession.FlatAppearance.MouseDownBackColor = System.Drawing.SystemColors.ButtonFace;
            this.btnMenuSession.FlatAppearance.MouseOverBackColor = System.Drawing.SystemColors.ButtonFace;
            this.btnMenuSession.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnMenuSession.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnMenuSession.Image = global::crash.Properties.Resources.map_128;
            this.btnMenuSession.ImageAlign = System.Drawing.ContentAlignment.TopCenter;
            this.btnMenuSession.Location = new System.Drawing.Point(47, 50);
            this.btnMenuSession.Name = "btnMenuSession";
            this.btnMenuSession.Size = new System.Drawing.Size(160, 170);
            this.btnMenuSession.TabIndex = 2;
            this.btnMenuSession.Text = "Sessions";
            this.btnMenuSession.TextAlign = System.Drawing.ContentAlignment.BottomCenter;
            this.btnMenuSession.UseVisualStyleBackColor = true;
            this.btnMenuSession.Click += new System.EventHandler(this.btnMenuSession_Click);
            // 
            // btnMenuPreferences
            // 
            this.btnMenuPreferences.FlatAppearance.BorderSize = 0;
            this.btnMenuPreferences.FlatAppearance.MouseDownBackColor = System.Drawing.SystemColors.ButtonFace;
            this.btnMenuPreferences.FlatAppearance.MouseOverBackColor = System.Drawing.SystemColors.ButtonFace;
            this.btnMenuPreferences.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnMenuPreferences.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnMenuPreferences.Image = global::crash.Properties.Resources.setup_128;
            this.btnMenuPreferences.ImageAlign = System.Drawing.ContentAlignment.TopCenter;
            this.btnMenuPreferences.Location = new System.Drawing.Point(213, 50);
            this.btnMenuPreferences.Name = "btnMenuPreferences";
            this.btnMenuPreferences.Size = new System.Drawing.Size(160, 170);
            this.btnMenuPreferences.TabIndex = 0;
            this.btnMenuPreferences.Text = "Preferences";
            this.btnMenuPreferences.TextAlign = System.Drawing.ContentAlignment.BottomCenter;
            this.btnMenuPreferences.UseVisualStyleBackColor = true;
            this.btnMenuPreferences.Click += new System.EventHandler(this.btnMenuPreferences_Click);
            // 
            // pageSessions
            // 
            this.pageSessions.BackColor = System.Drawing.SystemColors.ButtonFace;
            this.pageSessions.Controls.Add(this.splitContainer2);
            this.pageSessions.Location = new System.Drawing.Point(4, 27);
            this.pageSessions.Name = "pageSessions";
            this.pageSessions.Size = new System.Drawing.Size(1341, 616);
            this.pageSessions.TabIndex = 4;
            this.pageSessions.Text = "Sessions";
            // 
            // splitContainer2
            // 
            this.splitContainer2.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.splitContainer2.Dock = System.Windows.Forms.DockStyle.Fill;
            this.splitContainer2.FixedPanel = System.Windows.Forms.FixedPanel.Panel1;
            this.splitContainer2.Location = new System.Drawing.Point(0, 0);
            this.splitContainer2.Name = "splitContainer2";
            // 
            // splitContainer2.Panel1
            // 
            this.splitContainer2.Panel1.Controls.Add(this.splitContainerSessionLeft);
            // 
            // splitContainer2.Panel2
            // 
            this.splitContainer2.Panel2.Controls.Add(this.graphSession);
            this.splitContainer2.Panel2.Controls.Add(this.tableLayoutPanel2);
            this.splitContainer2.Panel2.Controls.Add(this.toolsSession);
            this.splitContainer2.Panel2.Controls.Add(this.panel1);
            this.splitContainer2.Size = new System.Drawing.Size(1341, 616);
            this.splitContainer2.SplitterDistance = 185;
            this.splitContainer2.SplitterWidth = 5;
            this.splitContainer2.TabIndex = 6;
            // 
            // splitContainerSessionLeft
            // 
            this.splitContainerSessionLeft.Dock = System.Windows.Forms.DockStyle.Fill;
            this.splitContainerSessionLeft.Location = new System.Drawing.Point(0, 0);
            this.splitContainerSessionLeft.Name = "splitContainerSessionLeft";
            this.splitContainerSessionLeft.Orientation = System.Windows.Forms.Orientation.Horizontal;
            // 
            // splitContainerSessionLeft.Panel1
            // 
            this.splitContainerSessionLeft.Panel1.Controls.Add(this.lbSession);
            // 
            // splitContainerSessionLeft.Panel2
            // 
            this.splitContainerSessionLeft.Panel2.Controls.Add(this.panelNuclides);
            this.splitContainerSessionLeft.Size = new System.Drawing.Size(183, 614);
            this.splitContainerSessionLeft.SplitterDistance = 332;
            this.splitContainerSessionLeft.TabIndex = 9;
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
            this.lbSession.Size = new System.Drawing.Size(183, 332);
            this.lbSession.TabIndex = 7;
            this.lbSession.SelectedIndexChanged += new System.EventHandler(this.lbSession_SelectedIndexChanged);
            // 
            // panelNuclides
            // 
            this.panelNuclides.Controls.Add(this.lbNuclides);
            this.panelNuclides.Controls.Add(this.label12);
            this.panelNuclides.Controls.Add(this.tbarNuclides);
            this.panelNuclides.Controls.Add(this.label19);
            this.panelNuclides.Dock = System.Windows.Forms.DockStyle.Fill;
            this.panelNuclides.Location = new System.Drawing.Point(0, 0);
            this.panelNuclides.Name = "panelNuclides";
            this.panelNuclides.Size = new System.Drawing.Size(183, 278);
            this.panelNuclides.TabIndex = 8;
            // 
            // lbNuclides
            // 
            this.lbNuclides.BackColor = System.Drawing.SystemColors.ButtonFace;
            this.lbNuclides.BorderStyle = System.Windows.Forms.BorderStyle.None;
            this.lbNuclides.Dock = System.Windows.Forms.DockStyle.Fill;
            this.lbNuclides.FormattingEnabled = true;
            this.lbNuclides.ItemHeight = 15;
            this.lbNuclides.Location = new System.Drawing.Point(0, 62);
            this.lbNuclides.Name = "lbNuclides";
            this.lbNuclides.Size = new System.Drawing.Size(183, 216);
            this.lbNuclides.TabIndex = 2;
            // 
            // label12
            // 
            this.label12.AutoSize = true;
            this.label12.Dock = System.Windows.Forms.DockStyle.Top;
            this.label12.Font = new System.Drawing.Font("Microsoft Sans Serif", 9F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label12.Location = new System.Drawing.Point(0, 47);
            this.label12.Name = "label12";
            this.label12.Size = new System.Drawing.Size(137, 15);
            this.label12.TabIndex = 3;
            this.label12.Text = "Nuclide suggestions";
            // 
            // tbarNuclides
            // 
            this.tbarNuclides.AutoSize = false;
            this.tbarNuclides.Dock = System.Windows.Forms.DockStyle.Top;
            this.tbarNuclides.Location = new System.Drawing.Point(0, 21);
            this.tbarNuclides.Name = "tbarNuclides";
            this.tbarNuclides.Size = new System.Drawing.Size(183, 26);
            this.tbarNuclides.TabIndex = 1;
            this.tbarNuclides.TickStyle = System.Windows.Forms.TickStyle.None;
            this.tbarNuclides.Value = 5;
            // 
            // label19
            // 
            this.label19.AutoSize = true;
            this.label19.Dock = System.Windows.Forms.DockStyle.Top;
            this.label19.Font = new System.Drawing.Font("Microsoft Sans Serif", 9F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label19.Location = new System.Drawing.Point(0, 0);
            this.label19.Name = "label19";
            this.label19.Padding = new System.Windows.Forms.Padding(3);
            this.label19.Size = new System.Drawing.Size(121, 21);
            this.label19.TabIndex = 0;
            this.label19.Text = "Energy tolerance";
            // 
            // graphSession
            // 
            this.graphSession.Dock = System.Windows.Forms.DockStyle.Fill;
            this.graphSession.IsShowPointValues = true;
            this.graphSession.Location = new System.Drawing.Point(0, 137);
            this.graphSession.Name = "graphSession";
            this.graphSession.ScrollGrace = 0D;
            this.graphSession.ScrollMaxX = 0D;
            this.graphSession.ScrollMaxY = 0D;
            this.graphSession.ScrollMaxY2 = 0D;
            this.graphSession.ScrollMinX = 0D;
            this.graphSession.ScrollMinY = 0D;
            this.graphSession.ScrollMinY2 = 0D;
            this.graphSession.Size = new System.Drawing.Size(1149, 457);
            this.graphSession.TabIndex = 5;
            this.graphSession.UseExtendedPrintDialog = true;
            this.graphSession.MouseDoubleClick += new System.Windows.Forms.MouseEventHandler(this.graphSession_MouseDoubleClick);
            this.graphSession.MouseMove += new System.Windows.Forms.MouseEventHandler(this.graphSession_MouseMove);
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
            this.tableLayoutPanel2.Controls.Add(this.lblBackground, 3, 0);
            this.tableLayoutPanel2.Controls.Add(this.lblComment, 1, 0);
            this.tableLayoutPanel2.Controls.Add(this.lblLivetime, 3, 1);
            this.tableLayoutPanel2.Controls.Add(this.lblRealtime, 2, 1);
            this.tableLayoutPanel2.Controls.Add(this.lblIndex, 1, 1);
            this.tableLayoutPanel2.Controls.Add(this.lblSessionDetector, 0, 1);
            this.tableLayoutPanel2.Dock = System.Windows.Forms.DockStyle.Top;
            this.tableLayoutPanel2.Location = new System.Drawing.Point(0, 25);
            this.tableLayoutPanel2.Name = "tableLayoutPanel2";
            this.tableLayoutPanel2.RowCount = 6;
            this.tableLayoutPanel2.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 20F));
            this.tableLayoutPanel2.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 20F));
            this.tableLayoutPanel2.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 20F));
            this.tableLayoutPanel2.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 20F));
            this.tableLayoutPanel2.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 20F));
            this.tableLayoutPanel2.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 20F));
            this.tableLayoutPanel2.Size = new System.Drawing.Size(1149, 112);
            this.tableLayoutPanel2.TabIndex = 0;
            // 
            // lblLatitudeStart
            // 
            this.lblLatitudeStart.AutoSize = true;
            this.lblLatitudeStart.Dock = System.Windows.Forms.DockStyle.Fill;
            this.lblLatitudeStart.Font = new System.Drawing.Font("Microsoft Sans Serif", 8F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblLatitudeStart.Location = new System.Drawing.Point(3, 40);
            this.lblLatitudeStart.Name = "lblLatitudeStart";
            this.lblLatitudeStart.Size = new System.Drawing.Size(281, 20);
            this.lblLatitudeStart.TabIndex = 0;
            this.lblLatitudeStart.Text = "<LatitudeStart>";
            this.lblLatitudeStart.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // lblLongitudeStart
            // 
            this.lblLongitudeStart.AutoSize = true;
            this.lblLongitudeStart.Dock = System.Windows.Forms.DockStyle.Fill;
            this.lblLongitudeStart.Font = new System.Drawing.Font("Microsoft Sans Serif", 8F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblLongitudeStart.Location = new System.Drawing.Point(290, 40);
            this.lblLongitudeStart.Name = "lblLongitudeStart";
            this.lblLongitudeStart.Size = new System.Drawing.Size(281, 20);
            this.lblLongitudeStart.TabIndex = 1;
            this.lblLongitudeStart.Text = "<LongitudeStart>";
            this.lblLongitudeStart.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // lblAltitudeStart
            // 
            this.lblAltitudeStart.AutoSize = true;
            this.lblAltitudeStart.Dock = System.Windows.Forms.DockStyle.Fill;
            this.lblAltitudeStart.Font = new System.Drawing.Font("Microsoft Sans Serif", 8F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblAltitudeStart.Location = new System.Drawing.Point(577, 40);
            this.lblAltitudeStart.Name = "lblAltitudeStart";
            this.lblAltitudeStart.Size = new System.Drawing.Size(281, 20);
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
            this.lblMaxCount.Size = new System.Drawing.Size(281, 20);
            this.lblMaxCount.TabIndex = 6;
            this.lblMaxCount.Text = "<MaxCount>";
            this.lblMaxCount.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // lblMinCount
            // 
            this.lblMinCount.AutoSize = true;
            this.lblMinCount.Dock = System.Windows.Forms.DockStyle.Fill;
            this.lblMinCount.Font = new System.Drawing.Font("Microsoft Sans Serif", 8F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblMinCount.Location = new System.Drawing.Point(290, 80);
            this.lblMinCount.Name = "lblMinCount";
            this.lblMinCount.Size = new System.Drawing.Size(281, 20);
            this.lblMinCount.TabIndex = 7;
            this.lblMinCount.Text = "<MinCount>";
            this.lblMinCount.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // lblTotalCount
            // 
            this.lblTotalCount.AutoSize = true;
            this.lblTotalCount.Dock = System.Windows.Forms.DockStyle.Fill;
            this.lblTotalCount.Font = new System.Drawing.Font("Microsoft Sans Serif", 8F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblTotalCount.Location = new System.Drawing.Point(577, 80);
            this.lblTotalCount.Name = "lblTotalCount";
            this.lblTotalCount.Size = new System.Drawing.Size(281, 20);
            this.lblTotalCount.TabIndex = 8;
            this.lblTotalCount.Text = "<TotalCount>";
            this.lblTotalCount.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // lblGpsTimeStart
            // 
            this.lblGpsTimeStart.AutoSize = true;
            this.lblGpsTimeStart.Dock = System.Windows.Forms.DockStyle.Fill;
            this.lblGpsTimeStart.Font = new System.Drawing.Font("Microsoft Sans Serif", 8F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblGpsTimeStart.Location = new System.Drawing.Point(864, 40);
            this.lblGpsTimeStart.Name = "lblGpsTimeStart";
            this.lblGpsTimeStart.Size = new System.Drawing.Size(282, 20);
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
            this.lblLatitudeEnd.Size = new System.Drawing.Size(281, 20);
            this.lblLatitudeEnd.TabIndex = 11;
            this.lblLatitudeEnd.Text = "<LatitudeEnd>";
            this.lblLatitudeEnd.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // lblLongitudeEnd
            // 
            this.lblLongitudeEnd.AutoSize = true;
            this.lblLongitudeEnd.Dock = System.Windows.Forms.DockStyle.Fill;
            this.lblLongitudeEnd.Font = new System.Drawing.Font("Microsoft Sans Serif", 8F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblLongitudeEnd.Location = new System.Drawing.Point(290, 60);
            this.lblLongitudeEnd.Name = "lblLongitudeEnd";
            this.lblLongitudeEnd.Size = new System.Drawing.Size(281, 20);
            this.lblLongitudeEnd.TabIndex = 12;
            this.lblLongitudeEnd.Text = "<LongitudeEnd>";
            this.lblLongitudeEnd.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // lblAltitudeEnd
            // 
            this.lblAltitudeEnd.AutoSize = true;
            this.lblAltitudeEnd.Dock = System.Windows.Forms.DockStyle.Fill;
            this.lblAltitudeEnd.Font = new System.Drawing.Font("Microsoft Sans Serif", 8F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblAltitudeEnd.Location = new System.Drawing.Point(577, 60);
            this.lblAltitudeEnd.Name = "lblAltitudeEnd";
            this.lblAltitudeEnd.Size = new System.Drawing.Size(281, 20);
            this.lblAltitudeEnd.TabIndex = 13;
            this.lblAltitudeEnd.Text = "<AltitudeEnd>";
            this.lblAltitudeEnd.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // lblGpsTimeEnd
            // 
            this.lblGpsTimeEnd.AutoSize = true;
            this.lblGpsTimeEnd.Dock = System.Windows.Forms.DockStyle.Fill;
            this.lblGpsTimeEnd.Font = new System.Drawing.Font("Microsoft Sans Serif", 8F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblGpsTimeEnd.Location = new System.Drawing.Point(864, 60);
            this.lblGpsTimeEnd.Name = "lblGpsTimeEnd";
            this.lblGpsTimeEnd.Size = new System.Drawing.Size(282, 20);
            this.lblGpsTimeEnd.TabIndex = 14;
            this.lblGpsTimeEnd.Text = "<GpsTimeEnd>";
            this.lblGpsTimeEnd.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // lblDoserate
            // 
            this.lblDoserate.AutoSize = true;
            this.lblDoserate.Dock = System.Windows.Forms.DockStyle.Fill;
            this.lblDoserate.Font = new System.Drawing.Font("Microsoft Sans Serif", 8F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblDoserate.Location = new System.Drawing.Point(864, 80);
            this.lblDoserate.Name = "lblDoserate";
            this.lblDoserate.Size = new System.Drawing.Size(282, 20);
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
            this.lblSession.Size = new System.Drawing.Size(281, 20);
            this.lblSession.TabIndex = 4;
            this.lblSession.Text = "<lblSession>";
            this.lblSession.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // lblBackground
            // 
            this.lblBackground.AutoSize = true;
            this.lblBackground.Dock = System.Windows.Forms.DockStyle.Fill;
            this.lblBackground.Font = new System.Drawing.Font("Microsoft Sans Serif", 8F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblBackground.Location = new System.Drawing.Point(864, 0);
            this.lblBackground.Name = "lblBackground";
            this.lblBackground.Size = new System.Drawing.Size(282, 20);
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
            this.lblComment.Location = new System.Drawing.Point(290, 0);
            this.lblComment.Name = "lblComment";
            this.lblComment.Size = new System.Drawing.Size(568, 20);
            this.lblComment.TabIndex = 17;
            this.lblComment.Text = "<lblComment>";
            this.lblComment.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // lblLivetime
            // 
            this.lblLivetime.AutoSize = true;
            this.lblLivetime.Dock = System.Windows.Forms.DockStyle.Fill;
            this.lblLivetime.Font = new System.Drawing.Font("Microsoft Sans Serif", 8F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblLivetime.Location = new System.Drawing.Point(864, 20);
            this.lblLivetime.Name = "lblLivetime";
            this.lblLivetime.Size = new System.Drawing.Size(282, 20);
            this.lblLivetime.TabIndex = 3;
            this.lblLivetime.Text = "<Livetime>";
            this.lblLivetime.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // lblRealtime
            // 
            this.lblRealtime.AutoSize = true;
            this.lblRealtime.Dock = System.Windows.Forms.DockStyle.Fill;
            this.lblRealtime.Font = new System.Drawing.Font("Microsoft Sans Serif", 8F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblRealtime.Location = new System.Drawing.Point(577, 20);
            this.lblRealtime.Name = "lblRealtime";
            this.lblRealtime.Size = new System.Drawing.Size(281, 20);
            this.lblRealtime.TabIndex = 2;
            this.lblRealtime.Text = "<Realtime>";
            this.lblRealtime.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // lblIndex
            // 
            this.lblIndex.AutoSize = true;
            this.lblIndex.Dock = System.Windows.Forms.DockStyle.Fill;
            this.lblIndex.Font = new System.Drawing.Font("Microsoft Sans Serif", 8F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblIndex.Location = new System.Drawing.Point(290, 20);
            this.lblIndex.Name = "lblIndex";
            this.lblIndex.Size = new System.Drawing.Size(281, 20);
            this.lblIndex.TabIndex = 5;
            this.lblIndex.Text = "<Index>";
            this.lblIndex.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // lblSessionDetector
            // 
            this.lblSessionDetector.AutoSize = true;
            this.lblSessionDetector.Dock = System.Windows.Forms.DockStyle.Fill;
            this.lblSessionDetector.Font = new System.Drawing.Font("Microsoft Sans Serif", 8F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblSessionDetector.Location = new System.Drawing.Point(3, 20);
            this.lblSessionDetector.Name = "lblSessionDetector";
            this.lblSessionDetector.Size = new System.Drawing.Size(281, 20);
            this.lblSessionDetector.TabIndex = 18;
            this.lblSessionDetector.Text = "<lblSessionDetector>";
            this.lblSessionDetector.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // toolsSession
            // 
            this.toolsSession.GripStyle = System.Windows.Forms.ToolStripGripStyle.Hidden;
            this.toolsSession.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.btnOptions});
            this.toolsSession.Location = new System.Drawing.Point(0, 0);
            this.toolsSession.Name = "toolsSession";
            this.toolsSession.Size = new System.Drawing.Size(1149, 25);
            this.toolsSession.TabIndex = 7;
            this.toolsSession.Text = "toolStrip1";
            // 
            // btnOptions
            // 
            this.btnOptions.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.subtractBackgroundToolStripMenuItem});
            this.btnOptions.Image = global::crash.Properties.Resources.options1_16;
            this.btnOptions.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.btnOptions.Name = "btnOptions";
            this.btnOptions.Size = new System.Drawing.Size(78, 22);
            this.btnOptions.Text = "Options";
            this.btnOptions.ToolTipText = "Session options";
            // 
            // subtractBackgroundToolStripMenuItem
            // 
            this.subtractBackgroundToolStripMenuItem.CheckOnClick = true;
            this.subtractBackgroundToolStripMenuItem.Name = "subtractBackgroundToolStripMenuItem";
            this.subtractBackgroundToolStripMenuItem.Size = new System.Drawing.Size(185, 22);
            this.subtractBackgroundToolStripMenuItem.Text = "Subtract background";
            // 
            // panel1
            // 
            this.panel1.Controls.Add(this.lblSessionEnergy);
            this.panel1.Controls.Add(this.lblSessionChannel);
            this.panel1.Dock = System.Windows.Forms.DockStyle.Bottom;
            this.panel1.Location = new System.Drawing.Point(0, 594);
            this.panel1.Name = "panel1";
            this.panel1.Size = new System.Drawing.Size(1149, 20);
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
            // pagePreferences
            // 
            this.pagePreferences.Controls.Add(this.tableLayoutPref);
            this.pagePreferences.Location = new System.Drawing.Point(4, 27);
            this.pagePreferences.Name = "pagePreferences";
            this.pagePreferences.Size = new System.Drawing.Size(1341, 616);
            this.pagePreferences.TabIndex = 5;
            this.pagePreferences.Text = "Preferences";
            this.pagePreferences.UseVisualStyleBackColor = true;
            // 
            // tableLayoutPref
            // 
            this.tableLayoutPref.ColumnCount = 3;
            this.tableLayoutPref.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 10F));
            this.tableLayoutPref.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 80F));
            this.tableLayoutPref.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 10F));
            this.tableLayoutPref.Controls.Add(this.lvDetectors, 1, 4);
            this.tableLayoutPref.Controls.Add(this.label1, 0, 1);
            this.tableLayoutPref.Controls.Add(this.tbSessionDir, 1, 1);
            this.tableLayoutPref.Controls.Add(this.btnSetSessionDir, 2, 1);
            this.tableLayoutPref.Controls.Add(this.lvDetectorTypes, 1, 3);
            this.tableLayoutPref.Controls.Add(this.btnAddDetectorType, 2, 3);
            this.tableLayoutPref.Controls.Add(this.label17, 0, 3);
            this.tableLayoutPref.Controls.Add(this.label18, 0, 4);
            this.tableLayoutPref.Controls.Add(this.btnAddDetector, 2, 4);
            this.tableLayoutPref.Dock = System.Windows.Forms.DockStyle.Fill;
            this.tableLayoutPref.Location = new System.Drawing.Point(0, 0);
            this.tableLayoutPref.Name = "tableLayoutPref";
            this.tableLayoutPref.RowCount = 6;
            this.tableLayoutPref.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 28F));
            this.tableLayoutPref.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 28F));
            this.tableLayoutPref.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 28F));
            this.tableLayoutPref.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 200F));
            this.tableLayoutPref.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 200F));
            this.tableLayoutPref.RowStyles.Add(new System.Windows.Forms.RowStyle());
            this.tableLayoutPref.Size = new System.Drawing.Size(1341, 616);
            this.tableLayoutPref.TabIndex = 1;
            // 
            // lvDetectors
            // 
            this.lvDetectors.Columns.AddRange(new System.Windows.Forms.ColumnHeader[] {
            this.columnHeaderSerialnumber,
            this.columnHeaderType,
            this.columnHeaderNumChannels,
            this.columnHeaderHV,
            this.columnHeaderCoarseGain,
            this.columnHeaderFineGain,
            this.columnHeaderLivetime,
            this.columnHeaderLLD,
            this.columnHeaderULD,
            this.columnHeaderRegScript});
            this.lvDetectors.Dock = System.Windows.Forms.DockStyle.Fill;
            this.lvDetectors.FullRowSelect = true;
            this.lvDetectors.Location = new System.Drawing.Point(137, 287);
            this.lvDetectors.MultiSelect = false;
            this.lvDetectors.Name = "lvDetectors";
            this.lvDetectors.Size = new System.Drawing.Size(1066, 194);
            this.lvDetectors.TabIndex = 8;
            this.lvDetectors.UseCompatibleStateImageBehavior = false;
            this.lvDetectors.View = System.Windows.Forms.View.Details;
            // 
            // columnHeaderSerialnumber
            // 
            this.columnHeaderSerialnumber.Text = "Serialnumber";
            // 
            // columnHeaderType
            // 
            this.columnHeaderType.Text = "Type";
            // 
            // columnHeaderNumChannels
            // 
            this.columnHeaderNumChannels.Text = "Num. Channels";
            // 
            // columnHeaderHV
            // 
            this.columnHeaderHV.Text = "Voltage";
            // 
            // columnHeaderCoarseGain
            // 
            this.columnHeaderCoarseGain.Text = "Coarse gain";
            // 
            // columnHeaderFineGain
            // 
            this.columnHeaderFineGain.Text = "Fine gain";
            // 
            // columnHeaderLivetime
            // 
            this.columnHeaderLivetime.Text = "Livetime";
            // 
            // columnHeaderLLD
            // 
            this.columnHeaderLLD.Text = "LLD";
            // 
            // columnHeaderULD
            // 
            this.columnHeaderULD.Text = "ULD";
            // 
            // columnHeaderRegScript
            // 
            this.columnHeaderRegScript.Text = "Reg. Script";
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(3, 28);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(100, 15);
            this.label1.TabIndex = 0;
            this.label1.Text = "Session directory";
            // 
            // tbSessionDir
            // 
            this.tbSessionDir.Dock = System.Windows.Forms.DockStyle.Fill;
            this.tbSessionDir.Location = new System.Drawing.Point(137, 31);
            this.tbSessionDir.Name = "tbSessionDir";
            this.tbSessionDir.ReadOnly = true;
            this.tbSessionDir.Size = new System.Drawing.Size(1066, 21);
            this.tbSessionDir.TabIndex = 1;
            // 
            // btnSetSessionDir
            // 
            this.btnSetSessionDir.Dock = System.Windows.Forms.DockStyle.Top;
            this.btnSetSessionDir.Location = new System.Drawing.Point(1209, 31);
            this.btnSetSessionDir.Name = "btnSetSessionDir";
            this.btnSetSessionDir.Size = new System.Drawing.Size(129, 22);
            this.btnSetSessionDir.TabIndex = 2;
            this.btnSetSessionDir.Text = "...";
            this.btnSetSessionDir.UseVisualStyleBackColor = true;
            this.btnSetSessionDir.Click += new System.EventHandler(this.btnSetSessionDir_Click);
            // 
            // lvDetectorTypes
            // 
            this.lvDetectorTypes.BackColor = System.Drawing.SystemColors.Window;
            this.lvDetectorTypes.Columns.AddRange(new System.Windows.Forms.ColumnHeader[] {
            this.columnHeaderName,
            this.columnHeaderMaxCH,
            this.columnHeaderMinHV,
            this.columnHeaderMaxHV,
            this.columnHeaderGScript});
            this.lvDetectorTypes.Dock = System.Windows.Forms.DockStyle.Fill;
            this.lvDetectorTypes.FullRowSelect = true;
            this.lvDetectorTypes.Location = new System.Drawing.Point(137, 87);
            this.lvDetectorTypes.MultiSelect = false;
            this.lvDetectorTypes.Name = "lvDetectorTypes";
            this.lvDetectorTypes.Size = new System.Drawing.Size(1066, 194);
            this.lvDetectorTypes.TabIndex = 3;
            this.lvDetectorTypes.UseCompatibleStateImageBehavior = false;
            this.lvDetectorTypes.View = System.Windows.Forms.View.Details;
            // 
            // columnHeaderName
            // 
            this.columnHeaderName.Text = "Name";
            this.columnHeaderName.Width = 100;
            // 
            // columnHeaderMaxCH
            // 
            this.columnHeaderMaxCH.Text = "Max channels";
            this.columnHeaderMaxCH.Width = 100;
            // 
            // columnHeaderMinHV
            // 
            this.columnHeaderMinHV.Text = "Min HV";
            this.columnHeaderMinHV.Width = 100;
            // 
            // columnHeaderMaxHV
            // 
            this.columnHeaderMaxHV.Text = "Max HV";
            this.columnHeaderMaxHV.Width = 100;
            // 
            // columnHeaderGScript
            // 
            this.columnHeaderGScript.Text = "G Script";
            this.columnHeaderGScript.Width = 100;
            // 
            // btnAddDetectorType
            // 
            this.btnAddDetectorType.Dock = System.Windows.Forms.DockStyle.Top;
            this.btnAddDetectorType.Location = new System.Drawing.Point(1209, 87);
            this.btnAddDetectorType.Name = "btnAddDetectorType";
            this.btnAddDetectorType.Size = new System.Drawing.Size(129, 23);
            this.btnAddDetectorType.TabIndex = 4;
            this.btnAddDetectorType.Text = "Add";
            this.btnAddDetectorType.UseVisualStyleBackColor = true;
            this.btnAddDetectorType.Click += new System.EventHandler(this.btnAddDetectorType_Click);
            // 
            // label17
            // 
            this.label17.AutoSize = true;
            this.label17.Location = new System.Drawing.Point(3, 84);
            this.label17.Name = "label17";
            this.label17.Size = new System.Drawing.Size(84, 15);
            this.label17.TabIndex = 5;
            this.label17.Text = "Detector types";
            // 
            // label18
            // 
            this.label18.AutoSize = true;
            this.label18.Location = new System.Drawing.Point(3, 284);
            this.label18.Name = "label18";
            this.label18.Size = new System.Drawing.Size(59, 15);
            this.label18.TabIndex = 6;
            this.label18.Text = "Detectors";
            // 
            // btnAddDetector
            // 
            this.btnAddDetector.Dock = System.Windows.Forms.DockStyle.Top;
            this.btnAddDetector.Location = new System.Drawing.Point(1209, 287);
            this.btnAddDetector.Name = "btnAddDetector";
            this.btnAddDetector.Size = new System.Drawing.Size(129, 23);
            this.btnAddDetector.TabIndex = 7;
            this.btnAddDetector.Text = "Add";
            this.btnAddDetector.UseVisualStyleBackColor = true;
            this.btnAddDetector.Click += new System.EventHandler(this.btnAddDetector_Click);
            // 
            // FormMain
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(7F, 15F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.SystemColors.ButtonFace;
            this.ClientSize = new System.Drawing.Size(1349, 733);
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
            this.contextMenuSession.ResumeLayout(false);
            this.tabs.ResumeLayout(false);
            this.pageSetup.ResumeLayout(false);
            this.panelSetupGraph.ResumeLayout(false);
            this.panelSetupGraph.PerformLayout();
            this.contextMenuSetup.ResumeLayout(false);
            this.toolsSetup.ResumeLayout(false);
            this.toolsSetup.PerformLayout();
            this.panelSetup.ResumeLayout(false);
            this.layoutConfigureDetector.ResumeLayout(false);
            this.layoutConfigureDetector.PerformLayout();
            this.panel5.ResumeLayout(false);
            this.panel5.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.tbarSetupVoltage)).EndInit();
            this.panel6.ResumeLayout(false);
            this.panel6.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.tbarSetupLLD)).EndInit();
            this.panel7.ResumeLayout(false);
            this.panel7.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.tbarSetupULD)).EndInit();
            this.panel3.ResumeLayout(false);
            this.panel3.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.tbarSetupFineGain)).EndInit();
            this.panel2.ResumeLayout(false);
            this.panel2.PerformLayout();
            this.pageMenu.ResumeLayout(false);
            this.flowLayoutPanel1.ResumeLayout(false);
            this.pageSessions.ResumeLayout(false);
            this.splitContainer2.Panel1.ResumeLayout(false);
            this.splitContainer2.Panel2.ResumeLayout(false);
            this.splitContainer2.Panel2.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.splitContainer2)).EndInit();
            this.splitContainer2.ResumeLayout(false);
            this.splitContainerSessionLeft.Panel1.ResumeLayout(false);
            this.splitContainerSessionLeft.Panel2.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.splitContainerSessionLeft)).EndInit();
            this.splitContainerSessionLeft.ResumeLayout(false);
            this.panelNuclides.ResumeLayout(false);
            this.panelNuclides.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.tbarNuclides)).EndInit();
            this.tableLayoutPanel2.ResumeLayout(false);
            this.tableLayoutPanel2.PerformLayout();
            this.toolsSession.ResumeLayout(false);
            this.toolsSession.PerformLayout();
            this.panel1.ResumeLayout(false);
            this.panel1.PerformLayout();
            this.pagePreferences.ResumeLayout(false);
            this.tableLayoutPref.ResumeLayout(false);
            this.tableLayoutPref.PerformLayout();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.MenuStrip menu;
        private System.Windows.Forms.StatusStrip status;
        private System.Windows.Forms.ToolStrip tools;
        private System.Windows.Forms.ToolStripMenuItem menuItemFile;
        private System.Windows.Forms.ToolStripMenuItem menuItemExit;
        private System.Windows.Forms.ToolStripMenuItem menuItemConnect;
        private System.Windows.Forms.ToolStripMenuItem menuItemDisconnect;
        private System.Windows.Forms.ToolStripSeparator toolStripSeparator1;
        private System.Windows.Forms.ToolStripStatusLabel statusLabel;
        private System.Windows.Forms.ToolStripLabel lblConnectionStatus;
        private System.Windows.Forms.ToolStripButton btnBack;
        private System.Windows.Forms.ToolStripSeparator toolStripSeparator2;
        private System.Windows.Forms.ToolStripButton btnShowWaterfallLive;
        private System.Windows.Forms.ToolStripLabel lblInterface;
        private System.Windows.Forms.ToolStripSeparator separatorInterface;
        private System.Windows.Forms.ToolStripButton btnShowROIChart;
        private System.Windows.Forms.ToolStripButton btnShowMap;
        private System.Windows.Forms.ToolStripButton btnShowLog;
        private System.Windows.Forms.ToolStripSeparator toolStripSeparator5;
        private System.Windows.Forms.ToolStripMenuItem menuItemHelp;
        private System.Windows.Forms.ToolStripMenuItem menuItemAbout;
        private System.Windows.Forms.ToolStripMenuItem menuItemSession;
        private System.Windows.Forms.ToolStripMenuItem menuItemLoadSession;
        private System.Windows.Forms.ToolStripMenuItem menuItemLoadBackgroundSession;
        private System.Windows.Forms.ToolStripButton btnShowROITable;
        private System.Windows.Forms.ToolStripLabel lblDetector;
        private System.Windows.Forms.ToolStripSeparator separatorDetector;
        private System.Windows.Forms.ContextMenuStrip contextMenuSession;
        private System.Windows.Forms.ToolStripMenuItem menuItemSessionUnselect;
        private System.Windows.Forms.ToolStripMenuItem menuItemSessionInfo;
        private System.Windows.Forms.ToolStripSeparator toolStripSeparator4;
        private System.Windows.Forms.ToolStripSeparator toolStripSeparator7;
        private System.Windows.Forms.ToolStripButton btnSessionInfo;
        private System.Windows.Forms.ToolStripMenuItem menuItemClearSession;
        private System.Windows.Forms.ToolStripMenuItem menuItemClearBackground;
        private System.Windows.Forms.ToolStripButton btnShowROIHist;
        private System.Windows.Forms.ToolStripMenuItem menuItemView;
        private System.Windows.Forms.ToolStripMenuItem menuItemShowMap;
        private System.Windows.Forms.ToolStripMenuItem menuItemShowWaterfall;
        private System.Windows.Forms.ToolStripMenuItem menuItemShowROIChart;
        private System.Windows.Forms.ToolStripMenuItem menuItemShowROIHistory;
        private System.Windows.Forms.ToolStripMenuItem menuItemBack;
        private System.Windows.Forms.ToolStripSeparator toolStripSeparator10;
        private System.Windows.Forms.ToolStripMenuItem menuItemShowLog;
        private System.Windows.Forms.ToolStripMenuItem menuItemExport;
        private System.Windows.Forms.ToolStripMenuItem menuItemSaveAsCHN;
        private System.Windows.Forms.ToolStripMenuItem menuItemSaveAsIRIX;
        private System.Windows.Forms.ToolStripMenuItem menuItemSaveAsKMZ;
        private System.Windows.Forms.ToolStripMenuItem menuItemSourceActivity;
        private System.Windows.Forms.TabControl tabs;
        private System.Windows.Forms.TabPage pageSetup;
        private System.Windows.Forms.Panel panel2;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Label label6;
        private System.Windows.Forms.ComboBox cboxSetupDetector;
        private System.Windows.Forms.ComboBox cboxSetupChannels;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.Label label7;
        private System.Windows.Forms.Label label8;
        private System.Windows.Forms.Label label9;
        private System.Windows.Forms.Label label10;
        private System.Windows.Forms.ComboBox cboxSetupCoarseGain;
        private System.Windows.Forms.Panel panel3;
        private System.Windows.Forms.TrackBar tbarSetupFineGain;
        private System.Windows.Forms.Label lblSetupFineGain;
        private System.Windows.Forms.Button btnSetupSetParams;
        private System.Windows.Forms.Panel panel6;
        private System.Windows.Forms.TrackBar tbarSetupLLD;
        private System.Windows.Forms.Label lblSetupLLD;
        private System.Windows.Forms.Panel panel7;
        private System.Windows.Forms.TrackBar tbarSetupULD;
        private System.Windows.Forms.Label lblSetupULD;
        private System.Windows.Forms.TabPage pageMenu;
        private System.Windows.Forms.FlowLayoutPanel flowLayoutPanel1;
        private System.Windows.Forms.Button btnMenuPreferences;
        private System.Windows.Forms.Button btnMenuSession;
        private System.Windows.Forms.TabPage pageSessions;
        private System.Windows.Forms.SplitContainer splitContainer2;
        private System.Windows.Forms.ListBox lbSession;
        private ZedGraph.ZedGraphControl graphSession;
        private System.Windows.Forms.Panel panel1;
        private System.Windows.Forms.Label lblSessionEnergy;
        private System.Windows.Forms.Label lblSessionChannel;
        private System.Windows.Forms.TableLayoutPanel tableLayoutPanel2;
        private System.Windows.Forms.Label lblLatitudeStart;
        private System.Windows.Forms.Label lblLongitudeStart;
        private System.Windows.Forms.Label lblAltitudeStart;
        private System.Windows.Forms.Label lblMaxCount;
        private System.Windows.Forms.Label lblMinCount;
        private System.Windows.Forms.Label lblTotalCount;
        private System.Windows.Forms.Label lblGpsTimeStart;
        private System.Windows.Forms.Label lblLatitudeEnd;
        private System.Windows.Forms.Label lblLongitudeEnd;
        private System.Windows.Forms.Label lblAltitudeEnd;
        private System.Windows.Forms.Label lblGpsTimeEnd;
        private System.Windows.Forms.Label lblDoserate;
        private System.Windows.Forms.Label lblSession;
        private System.Windows.Forms.Label lblBackground;
        private System.Windows.Forms.Label lblComment;
        private System.Windows.Forms.Label lblLivetime;
        private System.Windows.Forms.Label lblRealtime;
        private System.Windows.Forms.Label lblIndex;
        private System.Windows.Forms.Label lblSessionDetector;
        private System.Windows.Forms.Button btnSetupBack;
        private System.Windows.Forms.Button btnSetupNext;
        private System.Windows.Forms.TabPage pagePreferences;
        private System.Windows.Forms.TableLayoutPanel tableLayoutPref;
        private System.Windows.Forms.ListView lvDetectors;
        private System.Windows.Forms.ColumnHeader columnHeaderSerialnumber;
        private System.Windows.Forms.ColumnHeader columnHeaderType;
        private System.Windows.Forms.ColumnHeader columnHeaderNumChannels;
        private System.Windows.Forms.ColumnHeader columnHeaderHV;
        private System.Windows.Forms.ColumnHeader columnHeaderCoarseGain;
        private System.Windows.Forms.ColumnHeader columnHeaderFineGain;
        private System.Windows.Forms.ColumnHeader columnHeaderLivetime;
        private System.Windows.Forms.ColumnHeader columnHeaderLLD;
        private System.Windows.Forms.ColumnHeader columnHeaderULD;
        private System.Windows.Forms.ColumnHeader columnHeaderRegScript;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.TextBox tbSessionDir;
        private System.Windows.Forms.Button btnSetSessionDir;
        private System.Windows.Forms.ListView lvDetectorTypes;
        private System.Windows.Forms.ColumnHeader columnHeaderName;
        private System.Windows.Forms.ColumnHeader columnHeaderMaxCH;
        private System.Windows.Forms.ColumnHeader columnHeaderMinHV;
        private System.Windows.Forms.ColumnHeader columnHeaderMaxHV;
        private System.Windows.Forms.ColumnHeader columnHeaderGScript;
        private System.Windows.Forms.Button btnAddDetectorType;
        private System.Windows.Forms.Label label17;
        private System.Windows.Forms.Label label18;
        private System.Windows.Forms.Button btnAddDetector;
        private System.Windows.Forms.ToolStripButton btnStartNewSession;
        private System.Windows.Forms.ToolStripMenuItem menuItemStartNewSession;
        private System.Windows.Forms.ToolStripMenuItem menuItemStopSession;
        private System.Windows.Forms.ToolStripButton btnStopSession;
        private System.Windows.Forms.ToolStripDropDownButton menuItemRemoteCommands;
        private System.Windows.Forms.ToolStripMenuItem menuItemShutdownRemoteServer;
        private System.Windows.Forms.ToolStripSeparator toolStripSeparator3;
        private System.Windows.Forms.ToolStripMenuItem menuItemROITable;
        private System.Windows.Forms.Panel panelNuclides;
        private System.Windows.Forms.ListBox lbNuclides;
        private System.Windows.Forms.TrackBar tbarNuclides;
        private System.Windows.Forms.Label label19;
        private System.Windows.Forms.ToolStripButton btnConnect;
        private System.Windows.Forms.ToolStripButton btnDisconnect;
        private System.Windows.Forms.ToolStripSeparator toolStripSeparator8;
        private System.Windows.Forms.ToolStripSeparator toolStripSeparator6;
        private System.Windows.Forms.TableLayoutPanel layoutConfigureDetector;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.Panel panel5;
        private System.Windows.Forms.TrackBar tbarSetupVoltage;
        private System.Windows.Forms.Label lblSetupVoltage;
        private System.Windows.Forms.Panel panelSetup;
        private ZedGraph.ZedGraphControl graphSetup;
        private System.Windows.Forms.Label lblSetupEnergy;
        private System.Windows.Forms.Label lblSetupChannel;
        private System.Windows.Forms.SplitContainer splitContainerSessionLeft;
        private System.Windows.Forms.Label label12;
        private System.Windows.Forms.ContextMenuStrip contextMenuSetup;
        private System.Windows.Forms.ToolStripMenuItem menuItemResetCoefficients;
        private System.Windows.Forms.Label lblSetupCoefficients;
        private System.Windows.Forms.ToolStripMenuItem menuItemStoreCoefficients;
        private System.Windows.Forms.Panel panelSetupGraph;
        private System.Windows.Forms.ToolStrip toolsSetup;
        private System.Windows.Forms.ToolStripLabel toolStripLabel1;
        private System.Windows.Forms.ToolStripTextBox tbSetupLivetime;
        private System.Windows.Forms.ToolStripLabel toolStripLabel2;
        private System.Windows.Forms.ToolStripTextBox tbSetupSpectrumCount;
        private System.Windows.Forms.ToolStripLabel toolStripLabel3;
        private System.Windows.Forms.ToolStripTextBox tbSetupDelay;
        private System.Windows.Forms.ToolStripButton btnSetupStartTest;
        private System.Windows.Forms.ToolStripButton btnSetupStopTest;
        private System.Windows.Forms.ToolStripStatusLabel lblLogMessages;
        private System.Windows.Forms.ToolStripMenuItem menuItemSaveAsCVS;
        private System.Windows.Forms.ToolStripButton btnSetupResetCoefficients;
        private System.Windows.Forms.ToolStripButton btnSetupStoreCoefficients;
        private System.Windows.Forms.ToolStripDropDownButton btnSelectLayout;
        private System.Windows.Forms.ToolStripMenuItem menuItemLayoutSetup1;
        private System.Windows.Forms.ToolStrip toolsSession;
        private System.Windows.Forms.ToolStripMenuItem menuItemLayoutSession1;
        private System.Windows.Forms.ToolStripDropDownButton btnOptions;
        private System.Windows.Forms.ToolStripMenuItem subtractBackgroundToolStripMenuItem;
    }
}

