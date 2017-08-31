﻿namespace crash
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
            this.menuItemExit = new System.Windows.Forms.ToolStripMenuItem();
            this.menuItemSession = new System.Windows.Forms.ToolStripMenuItem();
            this.menuItemStartNewSession = new System.Windows.Forms.ToolStripMenuItem();
            this.menuItemSyncCurrentSession = new System.Windows.Forms.ToolStripMenuItem();
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
            this.menuItemSaveAsKMZ = new System.Windows.Forms.ToolStripMenuItem();
            this.menuItemSaveAsCSV = new System.Windows.Forms.ToolStripMenuItem();
            this.menuItemChangeIPAddress = new System.Windows.Forms.ToolStripMenuItem();
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
            this.btnShowLog = new System.Windows.Forms.ToolStripButton();
            this.btnSessionInfo = new System.Windows.Forms.ToolStripButton();
            this.toolStripSeparator5 = new System.Windows.Forms.ToolStripSeparator();
            this.btnShowMap = new System.Windows.Forms.ToolStripButton();
            this.btnShowWaterfallLive = new System.Windows.Forms.ToolStripButton();
            this.lblInterface = new System.Windows.Forms.ToolStripLabel();
            this.separatorInterface = new System.Windows.Forms.ToolStripSeparator();
            this.btnShowROITable = new System.Windows.Forms.ToolStripButton();
            this.btnShowROIHist = new System.Windows.Forms.ToolStripButton();
            this.btnShowROIChart = new System.Windows.Forms.ToolStripButton();
            this.btnLayout3 = new System.Windows.Forms.ToolStripButton();
            this.btnLayout2 = new System.Windows.Forms.ToolStripButton();
            this.btnLayout1 = new System.Windows.Forms.ToolStripButton();
            this.contextMenuSession = new System.Windows.Forms.ContextMenuStrip(this.components);
            this.menuItemSessionUnselect = new System.Windows.Forms.ToolStripMenuItem();
            this.tabs = new System.Windows.Forms.TabControl();
            this.pageSetup = new System.Windows.Forms.TabPage();
            this.panelSetupGraph = new System.Windows.Forms.Panel();
            this.graphSetup = new ZedGraph.ZedGraphControl();
            this.contextMenuSetup = new System.Windows.Forms.ContextMenuStrip(this.components);
            this.menuItemResetCoefficients = new System.Windows.Forms.ToolStripMenuItem();
            this.menuItemStoreCoefficients = new System.Windows.Forms.ToolStripMenuItem();
            this.toolsSetup = new System.Windows.Forms.ToolStrip();
            this.btnSetupStartTest = new System.Windows.Forms.ToolStripButton();
            this.btnSetupStopTest = new System.Windows.Forms.ToolStripButton();
            this.btnSetupResetCoefficients = new System.Windows.Forms.ToolStripButton();
            this.btnSetupStoreCoefficients = new System.Windows.Forms.ToolStripButton();
            this.layoutConfigureDetector = new System.Windows.Forms.TableLayoutPanel();
            this.panel16 = new System.Windows.Forms.Panel();
            this.tbarSetupVoltage = new System.Windows.Forms.TrackBar();
            this.label6 = new System.Windows.Forms.Label();
            this.lblSetupVoltage = new System.Windows.Forms.Label();
            this.panel5 = new System.Windows.Forms.Panel();
            this.cboxSetupCoarseGain = new System.Windows.Forms.ComboBox();
            this.panel13 = new System.Windows.Forms.Panel();
            this.label7 = new System.Windows.Forms.Label();
            this.panel17 = new System.Windows.Forms.Panel();
            this.tbarSetupFineGain = new System.Windows.Forms.TrackBar();
            this.label8 = new System.Windows.Forms.Label();
            this.lblSetupFineGain = new System.Windows.Forms.Label();
            this.panel3 = new System.Windows.Forms.Panel();
            this.tbarSetupLLD = new System.Windows.Forms.TrackBar();
            this.label9 = new System.Windows.Forms.Label();
            this.lblSetupLLD = new System.Windows.Forms.Label();
            this.panel18 = new System.Windows.Forms.Panel();
            this.tbarSetupULD = new System.Windows.Forms.TrackBar();
            this.label10 = new System.Windows.Forms.Label();
            this.lblSetupULD = new System.Windows.Forms.Label();
            this.btnSetupSetParams = new System.Windows.Forms.Button();
            this.panel15 = new System.Windows.Forms.Panel();
            this.cboxSetupChannels = new System.Windows.Forms.ComboBox();
            this.panel19 = new System.Windows.Forms.Panel();
            this.label4 = new System.Windows.Forms.Label();
            this.panel14 = new System.Windows.Forms.Panel();
            this.cboxSetupDetector = new System.Windows.Forms.ComboBox();
            this.panel12 = new System.Windows.Forms.Panel();
            this.label2 = new System.Windows.Forms.Label();
            this.lblSetupIPAddress = new System.Windows.Forms.Label();
            this.panelSetupSession = new System.Windows.Forms.Panel();
            this.btnSetupCancel = new System.Windows.Forms.Button();
            this.btnSetupClose = new System.Windows.Forms.Button();
            this.lblSetupEnergy = new System.Windows.Forms.Label();
            this.lblSetupChannel = new System.Windows.Forms.Label();
            this.pageMenu = new System.Windows.Forms.TabPage();
            this.flowLayoutPanel1 = new System.Windows.Forms.FlowLayoutPanel();
            this.btnMenuSessions = new System.Windows.Forms.Button();
            this.btnMenuDetectors = new System.Windows.Forms.Button();
            this.btnMenuCalibration = new System.Windows.Forms.Button();
            this.btnMenuPreferences = new System.Windows.Forms.Button();
            this.pageSessions = new System.Windows.Forms.TabPage();
            this.splitContainer2 = new System.Windows.Forms.SplitContainer();
            this.splitContainerSessionLeft = new System.Windows.Forms.SplitContainer();
            this.lbSession = new System.Windows.Forms.ListBox();
            this.panelNuclides = new System.Windows.Forms.Panel();
            this.lbNuclides = new System.Windows.Forms.ListBox();
            this.contextMenuNuclides = new System.Windows.Forms.ContextMenuStrip(this.components);
            this.menuItemNuclidesUnselect = new System.Windows.Forms.ToolStripMenuItem();
            this.label12 = new System.Windows.Forms.Label();
            this.panel8 = new System.Windows.Forms.Panel();
            this.tbarNuclides = new System.Windows.Forms.TrackBar();
            this.lblSessionETOL = new System.Windows.Forms.Label();
            this.label19 = new System.Windows.Forms.Label();
            this.graphSession = new ZedGraph.ZedGraphControl();
            this.tableLayoutPanel2 = new System.Windows.Forms.TableLayoutPanel();
            this.lblLatitude = new System.Windows.Forms.Label();
            this.lblLongitude = new System.Windows.Forms.Label();
            this.lblAltitude = new System.Windows.Forms.Label();
            this.lblGpsTime = new System.Windows.Forms.Label();
            this.lblSession = new System.Windows.Forms.Label();
            this.lblBackground = new System.Windows.Forms.Label();
            this.lblComment = new System.Windows.Forms.Label();
            this.lblLivetime = new System.Windows.Forms.Label();
            this.lblRealtime = new System.Windows.Forms.Label();
            this.lblIndex = new System.Windows.Forms.Label();
            this.lblSessionDetector = new System.Windows.Forms.Label();
            this.lblMaxCount = new System.Windows.Forms.Label();
            this.lblMinCount = new System.Windows.Forms.Label();
            this.lblTotalCount = new System.Windows.Forms.Label();
            this.lblDoserate = new System.Windows.Forms.Label();
            this.toolsSession = new System.Windows.Forms.ToolStrip();
            this.btnOptions = new System.Windows.Forms.ToolStripDropDownButton();
            this.menuItemSubtractBackground = new System.Windows.Forms.ToolStripMenuItem();
            this.menuItemConvertToLocalTime = new System.Windows.Forms.ToolStripMenuItem();
            this.panel1 = new System.Windows.Forms.Panel();
            this.btnSessionsClose = new System.Windows.Forms.Button();
            this.lblSessionEnergy = new System.Windows.Forms.Label();
            this.lblSessionChannel = new System.Windows.Forms.Label();
            this.panelSessionsControl = new System.Windows.Forms.Panel();
            this.lblSessionsDatabase = new System.Windows.Forms.Label();
            this.btnSessionsBrowse = new System.Windows.Forms.Button();
            this.btnSessionsSync = new System.Windows.Forms.Button();
            this.btnSessionsStop = new System.Windows.Forms.Button();
            this.btnSessionsNew = new System.Windows.Forms.Button();
            this.pageDetectors = new System.Windows.Forms.TabPage();
            this.tableLayoutPref = new System.Windows.Forms.TableLayoutPanel();
            this.lvDetectors = new System.Windows.Forms.ListView();
            this.colSerialnumber = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.colType = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.colNumChannels = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.colMaxNumChannels = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.colHV = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.colMinHV = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.colMaxHV = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.colCoarseGain = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.colFineGain = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.colLivetime = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.colLLD = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.colULD = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.colPluginName = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.colGEScript = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.panel2 = new System.Windows.Forms.Panel();
            this.btnEditDetector = new System.Windows.Forms.Button();
            this.btnAddDetector = new System.Windows.Forms.Button();
            this.label18 = new System.Windows.Forms.Label();
            this.panel6 = new System.Windows.Forms.Panel();
            this.btnPreferencesClose = new System.Windows.Forms.Button();
            this.pageNew = new System.Windows.Forms.TabPage();
            this.tableNew = new System.Windows.Forms.TableLayoutPanel();
            this.tbNewComment = new System.Windows.Forms.TextBox();
            this.tbNewLivetime = new System.Windows.Forms.TextBox();
            this.label1 = new System.Windows.Forms.Label();
            this.label16 = new System.Windows.Forms.Label();
            this.panel9 = new System.Windows.Forms.Panel();
            this.btnNewCancel = new System.Windows.Forms.Button();
            this.btnNewStart = new System.Windows.Forms.Button();
            this.pageStatus = new System.Windows.Forms.TabPage();
            this.tableStatus = new System.Windows.Forms.TableLayoutPanel();
            this.label3 = new System.Windows.Forms.Label();
            this.btnStatusGet = new System.Windows.Forms.Button();
            this.tbStatusIPAddress = new System.Windows.Forms.TextBox();
            this.lblStatusDetectorConfigured = new System.Windows.Forms.Label();
            this.lblStatusSpectrumIndex = new System.Windows.Forms.Label();
            this.lblStatusSessionRunning = new System.Windows.Forms.Label();
            this.lblStatusFreeDiskSpace = new System.Windows.Forms.Label();
            this.panel7 = new System.Windows.Forms.Panel();
            this.btnStatusCancel = new System.Windows.Forms.Button();
            this.btnStatusNext = new System.Windows.Forms.Button();
            this.pagePreferences = new System.Windows.Forms.TabPage();
            this.tableLayoutPanel1 = new System.Windows.Forms.TableLayoutPanel();
            this.panel11 = new System.Windows.Forms.Panel();
            this.tbPreferencesSessionDir = new System.Windows.Forms.TextBox();
            this.btnPreferencesSetSessionDir = new System.Windows.Forms.Button();
            this.label5 = new System.Windows.Forms.Label();
            this.panel10 = new System.Windows.Forms.Panel();
            this.btnPreferencesCancel = new System.Windows.Forms.Button();
            this.btnPreferencesSave = new System.Windows.Forms.Button();
            this.openSessionDialog = new System.Windows.Forms.OpenFileDialog();
            this.menuItemLoadBackgroundSelection = new System.Windows.Forms.ToolStripMenuItem();
            this.menuItemSetAsBackground = new System.Windows.Forms.ToolStripMenuItem();
            this.menu.SuspendLayout();
            this.status.SuspendLayout();
            this.tools.SuspendLayout();
            this.contextMenuSession.SuspendLayout();
            this.tabs.SuspendLayout();
            this.pageSetup.SuspendLayout();
            this.panelSetupGraph.SuspendLayout();
            this.contextMenuSetup.SuspendLayout();
            this.toolsSetup.SuspendLayout();
            this.layoutConfigureDetector.SuspendLayout();
            this.panel16.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.tbarSetupVoltage)).BeginInit();
            this.panel5.SuspendLayout();
            this.panel13.SuspendLayout();
            this.panel17.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.tbarSetupFineGain)).BeginInit();
            this.panel3.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.tbarSetupLLD)).BeginInit();
            this.panel18.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.tbarSetupULD)).BeginInit();
            this.panel15.SuspendLayout();
            this.panel19.SuspendLayout();
            this.panel14.SuspendLayout();
            this.panel12.SuspendLayout();
            this.panelSetupSession.SuspendLayout();
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
            this.contextMenuNuclides.SuspendLayout();
            this.panel8.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.tbarNuclides)).BeginInit();
            this.tableLayoutPanel2.SuspendLayout();
            this.toolsSession.SuspendLayout();
            this.panel1.SuspendLayout();
            this.panelSessionsControl.SuspendLayout();
            this.pageDetectors.SuspendLayout();
            this.tableLayoutPref.SuspendLayout();
            this.panel2.SuspendLayout();
            this.panel6.SuspendLayout();
            this.pageNew.SuspendLayout();
            this.tableNew.SuspendLayout();
            this.panel9.SuspendLayout();
            this.pageStatus.SuspendLayout();
            this.tableStatus.SuspendLayout();
            this.panel7.SuspendLayout();
            this.pagePreferences.SuspendLayout();
            this.tableLayoutPanel1.SuspendLayout();
            this.panel11.SuspendLayout();
            this.panel10.SuspendLayout();
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
            this.menu.Size = new System.Drawing.Size(1350, 24);
            this.menu.TabIndex = 0;
            this.menu.Text = "menuStrip1";
            // 
            // menuItemFile
            // 
            this.menuItemFile.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.menuItemExit});
            this.menuItemFile.Name = "menuItemFile";
            this.menuItemFile.Size = new System.Drawing.Size(37, 20);
            this.menuItemFile.Text = "&File";
            // 
            // menuItemExit
            // 
            this.menuItemExit.Name = "menuItemExit";
            this.menuItemExit.Size = new System.Drawing.Size(92, 22);
            this.menuItemExit.Text = "E&xit";
            this.menuItemExit.Click += new System.EventHandler(this.menuItemExit_Click);
            // 
            // menuItemSession
            // 
            this.menuItemSession.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.menuItemStartNewSession,
            this.menuItemSyncCurrentSession,
            this.menuItemStopSession,
            this.toolStripSeparator3,
            this.menuItemLoadSession,
            this.menuItemClearSession,
            this.menuItemSessionInfo,
            this.toolStripSeparator4,
            this.menuItemLoadBackgroundSelection,
            this.menuItemLoadBackgroundSession,
            this.menuItemClearBackground,
            this.toolStripSeparator7,
            this.menuItemExport,
            this.menuItemChangeIPAddress});
            this.menuItemSession.Name = "menuItemSession";
            this.menuItemSession.Size = new System.Drawing.Size(58, 20);
            this.menuItemSession.Text = "&Session";
            // 
            // menuItemStartNewSession
            // 
            this.menuItemStartNewSession.Name = "menuItemStartNewSession";
            this.menuItemStartNewSession.Size = new System.Drawing.Size(217, 22);
            this.menuItemStartNewSession.Text = "Start new session";
            this.menuItemStartNewSession.Click += new System.EventHandler(this.menuItemStartNewSession_Click);
            // 
            // menuItemSyncCurrentSession
            // 
            this.menuItemSyncCurrentSession.Name = "menuItemSyncCurrentSession";
            this.menuItemSyncCurrentSession.Size = new System.Drawing.Size(217, 22);
            this.menuItemSyncCurrentSession.Text = "Sync current session";
            this.menuItemSyncCurrentSession.Click += new System.EventHandler(this.menuItemSyncCurrentSession_Click);
            // 
            // menuItemStopSession
            // 
            this.menuItemStopSession.Name = "menuItemStopSession";
            this.menuItemStopSession.Size = new System.Drawing.Size(217, 22);
            this.menuItemStopSession.Text = "Stop current session";
            this.menuItemStopSession.Click += new System.EventHandler(this.menuItemStopSession_Click);
            // 
            // toolStripSeparator3
            // 
            this.toolStripSeparator3.Name = "toolStripSeparator3";
            this.toolStripSeparator3.Size = new System.Drawing.Size(214, 6);
            // 
            // menuItemLoadSession
            // 
            this.menuItemLoadSession.Name = "menuItemLoadSession";
            this.menuItemLoadSession.Size = new System.Drawing.Size(217, 22);
            this.menuItemLoadSession.Text = "Load &existing session";
            this.menuItemLoadSession.Click += new System.EventHandler(this.menuItemLoadSession_Click);
            // 
            // menuItemClearSession
            // 
            this.menuItemClearSession.Name = "menuItemClearSession";
            this.menuItemClearSession.Size = new System.Drawing.Size(217, 22);
            this.menuItemClearSession.Text = "C&lear session";
            this.menuItemClearSession.Click += new System.EventHandler(this.menuItemClearSession_Click);
            // 
            // menuItemSessionInfo
            // 
            this.menuItemSessionInfo.Name = "menuItemSessionInfo";
            this.menuItemSessionInfo.Size = new System.Drawing.Size(217, 22);
            this.menuItemSessionInfo.Text = "Edit &session info";
            this.menuItemSessionInfo.Click += new System.EventHandler(this.menuItemSessionInfo_Click);
            // 
            // toolStripSeparator4
            // 
            this.toolStripSeparator4.Name = "toolStripSeparator4";
            this.toolStripSeparator4.Size = new System.Drawing.Size(214, 6);
            // 
            // menuItemLoadBackgroundSession
            // 
            this.menuItemLoadBackgroundSession.Name = "menuItemLoadBackgroundSession";
            this.menuItemLoadBackgroundSession.Size = new System.Drawing.Size(217, 22);
            this.menuItemLoadBackgroundSession.Text = "Load &background session";
            this.menuItemLoadBackgroundSession.Click += new System.EventHandler(this.menuItemLoadBackgroundSession_Click);
            // 
            // menuItemClearBackground
            // 
            this.menuItemClearBackground.Name = "menuItemClearBackground";
            this.menuItemClearBackground.Size = new System.Drawing.Size(217, 22);
            this.menuItemClearBackground.Text = "Clear back&ground session";
            this.menuItemClearBackground.Click += new System.EventHandler(this.menuItemClearBackground_Click);
            // 
            // toolStripSeparator7
            // 
            this.toolStripSeparator7.Name = "toolStripSeparator7";
            this.toolStripSeparator7.Size = new System.Drawing.Size(214, 6);
            // 
            // menuItemExport
            // 
            this.menuItemExport.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.menuItemSaveAsCHN,
            this.menuItemSaveAsKMZ,
            this.menuItemSaveAsCSV});
            this.menuItemExport.Name = "menuItemExport";
            this.menuItemExport.Size = new System.Drawing.Size(217, 22);
            this.menuItemExport.Text = "E&xport session as ...";
            // 
            // menuItemSaveAsCHN
            // 
            this.menuItemSaveAsCHN.Name = "menuItemSaveAsCHN";
            this.menuItemSaveAsCHN.Size = new System.Drawing.Size(180, 22);
            this.menuItemSaveAsCHN.Text = "&CHN";
            this.menuItemSaveAsCHN.ToolTipText = "Save session as multiple CHN files";
            this.menuItemSaveAsCHN.Click += new System.EventHandler(this.menuItemSaveAsCHN_Click);
            // 
            // menuItemSaveAsKMZ
            // 
            this.menuItemSaveAsKMZ.Name = "menuItemSaveAsKMZ";
            this.menuItemSaveAsKMZ.Size = new System.Drawing.Size(180, 22);
            this.menuItemSaveAsKMZ.Text = "KM&Z";
            this.menuItemSaveAsKMZ.ToolTipText = "Save session as a KMZ file";
            this.menuItemSaveAsKMZ.Click += new System.EventHandler(this.menuItemSaveAsKMZ_Click);
            // 
            // menuItemSaveAsCSV
            // 
            this.menuItemSaveAsCSV.Name = "menuItemSaveAsCSV";
            this.menuItemSaveAsCSV.Size = new System.Drawing.Size(180, 22);
            this.menuItemSaveAsCSV.Text = "CSV (simple log file)";
            this.menuItemSaveAsCSV.ToolTipText = "Save session as a CSV file";
            this.menuItemSaveAsCSV.Click += new System.EventHandler(this.menuItemSaveAsCSV_Click);
            // 
            // menuItemChangeIPAddress
            // 
            this.menuItemChangeIPAddress.Name = "menuItemChangeIPAddress";
            this.menuItemChangeIPAddress.Size = new System.Drawing.Size(217, 22);
            this.menuItemChangeIPAddress.Text = "Change IP address";
            this.menuItemChangeIPAddress.Click += new System.EventHandler(this.menuItemChangeIPAddress_Click);
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
            this.menuItemROITable.Click += new System.EventHandler(this.menuItemROITable_Click);
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
            this.status.Size = new System.Drawing.Size(1350, 22);
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
            this.btnShowLog,
            this.btnSessionInfo,
            this.toolStripSeparator5,
            this.btnShowMap,
            this.btnShowWaterfallLive,
            this.lblInterface,
            this.separatorInterface,
            this.btnShowROITable,
            this.btnShowROIHist,
            this.btnShowROIChart,
            this.btnLayout3,
            this.btnLayout2,
            this.btnLayout1});
            this.tools.Location = new System.Drawing.Point(0, 24);
            this.tools.Name = "tools";
            this.tools.Size = new System.Drawing.Size(1350, 40);
            this.tools.TabIndex = 2;
            this.tools.Text = "toolStrip1";
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
            // btnLayout3
            // 
            this.btnLayout3.Alignment = System.Windows.Forms.ToolStripItemAlignment.Right;
            this.btnLayout3.AutoSize = false;
            this.btnLayout3.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image;
            this.btnLayout3.Image = global::crash.Properties.Resources.layout3;
            this.btnLayout3.ImageScaling = System.Windows.Forms.ToolStripItemImageScaling.None;
            this.btnLayout3.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.btnLayout3.Name = "btnLayout3";
            this.btnLayout3.Size = new System.Drawing.Size(38, 38);
            this.btnLayout3.Text = "toolStripButton2";
            this.btnLayout3.Click += new System.EventHandler(this.menuItemLayoutSession2_Click);
            // 
            // btnLayout2
            // 
            this.btnLayout2.Alignment = System.Windows.Forms.ToolStripItemAlignment.Right;
            this.btnLayout2.AutoSize = false;
            this.btnLayout2.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image;
            this.btnLayout2.Image = global::crash.Properties.Resources.layout2;
            this.btnLayout2.ImageScaling = System.Windows.Forms.ToolStripItemImageScaling.None;
            this.btnLayout2.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.btnLayout2.Name = "btnLayout2";
            this.btnLayout2.Size = new System.Drawing.Size(38, 38);
            this.btnLayout2.Text = "toolStripButton3";
            this.btnLayout2.Click += new System.EventHandler(this.menuItemLayoutSession1_Click);
            // 
            // btnLayout1
            // 
            this.btnLayout1.Alignment = System.Windows.Forms.ToolStripItemAlignment.Right;
            this.btnLayout1.AutoSize = false;
            this.btnLayout1.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image;
            this.btnLayout1.Image = global::crash.Properties.Resources.layout1;
            this.btnLayout1.ImageScaling = System.Windows.Forms.ToolStripItemImageScaling.None;
            this.btnLayout1.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.btnLayout1.Name = "btnLayout1";
            this.btnLayout1.Size = new System.Drawing.Size(38, 38);
            this.btnLayout1.Text = "toolStripButton4";
            this.btnLayout1.Click += new System.EventHandler(this.menuItemLayoutSetup1_Click);
            // 
            // contextMenuSession
            // 
            this.contextMenuSession.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.menuItemSessionUnselect,
            this.menuItemSetAsBackground});
            this.contextMenuSession.Name = "contextMenuSession";
            this.contextMenuSession.Size = new System.Drawing.Size(172, 70);
            // 
            // menuItemSessionUnselect
            // 
            this.menuItemSessionUnselect.Name = "menuItemSessionUnselect";
            this.menuItemSessionUnselect.Size = new System.Drawing.Size(171, 22);
            this.menuItemSessionUnselect.Text = "&Unselect";
            this.menuItemSessionUnselect.Click += new System.EventHandler(this.menuItemSessionUnselect_Click);
            // 
            // tabs
            // 
            this.tabs.Appearance = System.Windows.Forms.TabAppearance.FlatButtons;
            this.tabs.Controls.Add(this.pageSetup);
            this.tabs.Controls.Add(this.pageMenu);
            this.tabs.Controls.Add(this.pageSessions);
            this.tabs.Controls.Add(this.pageDetectors);
            this.tabs.Controls.Add(this.pageNew);
            this.tabs.Controls.Add(this.pageStatus);
            this.tabs.Controls.Add(this.pagePreferences);
            this.tabs.Dock = System.Windows.Forms.DockStyle.Fill;
            this.tabs.Location = new System.Drawing.Point(0, 64);
            this.tabs.Name = "tabs";
            this.tabs.SelectedIndex = 0;
            this.tabs.Size = new System.Drawing.Size(1350, 647);
            this.tabs.TabIndex = 5;
            this.tabs.SelectedIndexChanged += new System.EventHandler(this.tabs_SelectedIndexChanged);
            // 
            // pageSetup
            // 
            this.pageSetup.BackColor = System.Drawing.SystemColors.ButtonFace;
            this.pageSetup.Controls.Add(this.panelSetupGraph);
            this.pageSetup.Controls.Add(this.layoutConfigureDetector);
            this.pageSetup.Controls.Add(this.panelSetupSession);
            this.pageSetup.Location = new System.Drawing.Point(4, 27);
            this.pageSetup.Name = "pageSetup";
            this.pageSetup.Size = new System.Drawing.Size(1342, 616);
            this.pageSetup.TabIndex = 2;
            this.pageSetup.Text = "Setup";
            // 
            // panelSetupGraph
            // 
            this.panelSetupGraph.Controls.Add(this.graphSetup);
            this.panelSetupGraph.Controls.Add(this.toolsSetup);
            this.panelSetupGraph.Dock = System.Windows.Forms.DockStyle.Fill;
            this.panelSetupGraph.Location = new System.Drawing.Point(0, 97);
            this.panelSetupGraph.Name = "panelSetupGraph";
            this.panelSetupGraph.Size = new System.Drawing.Size(1342, 487);
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
            this.graphSetup.Size = new System.Drawing.Size(1342, 462);
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
            this.btnSetupStartTest,
            this.btnSetupStopTest,
            this.btnSetupResetCoefficients,
            this.btnSetupStoreCoefficients});
            this.toolsSetup.Location = new System.Drawing.Point(0, 0);
            this.toolsSetup.Name = "toolsSetup";
            this.toolsSetup.Size = new System.Drawing.Size(1342, 25);
            this.toolsSetup.TabIndex = 0;
            this.toolsSetup.Text = "toolStrip1";
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
            // layoutConfigureDetector
            // 
            this.layoutConfigureDetector.ColumnCount = 3;
            this.layoutConfigureDetector.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 33.33333F));
            this.layoutConfigureDetector.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 33.33333F));
            this.layoutConfigureDetector.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 33.33333F));
            this.layoutConfigureDetector.Controls.Add(this.panel16, 0, 1);
            this.layoutConfigureDetector.Controls.Add(this.panel5, 1, 1);
            this.layoutConfigureDetector.Controls.Add(this.panel17, 2, 1);
            this.layoutConfigureDetector.Controls.Add(this.panel3, 0, 2);
            this.layoutConfigureDetector.Controls.Add(this.panel18, 1, 2);
            this.layoutConfigureDetector.Controls.Add(this.btnSetupSetParams, 2, 2);
            this.layoutConfigureDetector.Controls.Add(this.panel15, 2, 0);
            this.layoutConfigureDetector.Controls.Add(this.panel14, 1, 0);
            this.layoutConfigureDetector.Controls.Add(this.lblSetupIPAddress, 0, 0);
            this.layoutConfigureDetector.Dock = System.Windows.Forms.DockStyle.Top;
            this.layoutConfigureDetector.Location = new System.Drawing.Point(0, 0);
            this.layoutConfigureDetector.Name = "layoutConfigureDetector";
            this.layoutConfigureDetector.RowCount = 3;
            this.layoutConfigureDetector.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 32F));
            this.layoutConfigureDetector.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 32F));
            this.layoutConfigureDetector.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 32F));
            this.layoutConfigureDetector.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 20F));
            this.layoutConfigureDetector.Size = new System.Drawing.Size(1342, 97);
            this.layoutConfigureDetector.TabIndex = 23;
            // 
            // panel16
            // 
            this.panel16.Controls.Add(this.tbarSetupVoltage);
            this.panel16.Controls.Add(this.label6);
            this.panel16.Controls.Add(this.lblSetupVoltage);
            this.panel16.Dock = System.Windows.Forms.DockStyle.Fill;
            this.panel16.Location = new System.Drawing.Point(3, 35);
            this.panel16.Name = "panel16";
            this.panel16.Size = new System.Drawing.Size(441, 26);
            this.panel16.TabIndex = 50;
            // 
            // tbarSetupVoltage
            // 
            this.tbarSetupVoltage.Dock = System.Windows.Forms.DockStyle.Fill;
            this.tbarSetupVoltage.Location = new System.Drawing.Point(55, 0);
            this.tbarSetupVoltage.Name = "tbarSetupVoltage";
            this.tbarSetupVoltage.Size = new System.Drawing.Size(372, 26);
            this.tbarSetupVoltage.TabIndex = 1;
            this.tbarSetupVoltage.TickStyle = System.Windows.Forms.TickStyle.None;
            this.tbarSetupVoltage.ValueChanged += new System.EventHandler(this.tbarSetupVoltage_ValueChanged);
            // 
            // label6
            // 
            this.label6.AutoSize = true;
            this.label6.Dock = System.Windows.Forms.DockStyle.Left;
            this.label6.Font = new System.Drawing.Font("Microsoft Sans Serif", 9F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label6.Location = new System.Drawing.Point(0, 0);
            this.label6.Name = "label6";
            this.label6.Size = new System.Drawing.Size(55, 15);
            this.label6.TabIndex = 31;
            this.label6.Text = "Voltage";
            this.label6.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            // 
            // lblSetupVoltage
            // 
            this.lblSetupVoltage.AutoSize = true;
            this.lblSetupVoltage.Dock = System.Windows.Forms.DockStyle.Right;
            this.lblSetupVoltage.Location = new System.Drawing.Point(427, 0);
            this.lblSetupVoltage.Name = "lblSetupVoltage";
            this.lblSetupVoltage.Size = new System.Drawing.Size(14, 15);
            this.lblSetupVoltage.TabIndex = 0;
            this.lblSetupVoltage.Text = "1";
            // 
            // panel5
            // 
            this.panel5.Controls.Add(this.cboxSetupCoarseGain);
            this.panel5.Controls.Add(this.panel13);
            this.panel5.Dock = System.Windows.Forms.DockStyle.Fill;
            this.panel5.Location = new System.Drawing.Point(450, 35);
            this.panel5.Name = "panel5";
            this.panel5.Size = new System.Drawing.Size(441, 26);
            this.panel5.TabIndex = 51;
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
            this.cboxSetupCoarseGain.Location = new System.Drawing.Point(114, 0);
            this.cboxSetupCoarseGain.Name = "cboxSetupCoarseGain";
            this.cboxSetupCoarseGain.Size = new System.Drawing.Size(327, 23);
            this.cboxSetupCoarseGain.TabIndex = 40;
            // 
            // panel13
            // 
            this.panel13.Controls.Add(this.label7);
            this.panel13.Dock = System.Windows.Forms.DockStyle.Left;
            this.panel13.Location = new System.Drawing.Point(0, 0);
            this.panel13.Name = "panel13";
            this.panel13.Size = new System.Drawing.Size(114, 26);
            this.panel13.TabIndex = 41;
            // 
            // label7
            // 
            this.label7.AutoSize = true;
            this.label7.Dock = System.Windows.Forms.DockStyle.Fill;
            this.label7.Font = new System.Drawing.Font("Microsoft Sans Serif", 9F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label7.Location = new System.Drawing.Point(0, 0);
            this.label7.Name = "label7";
            this.label7.Size = new System.Drawing.Size(84, 15);
            this.label7.TabIndex = 32;
            this.label7.Text = "Coarse gain";
            this.label7.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            // 
            // panel17
            // 
            this.panel17.Controls.Add(this.tbarSetupFineGain);
            this.panel17.Controls.Add(this.label8);
            this.panel17.Controls.Add(this.lblSetupFineGain);
            this.panel17.Dock = System.Windows.Forms.DockStyle.Fill;
            this.panel17.Location = new System.Drawing.Point(897, 35);
            this.panel17.Name = "panel17";
            this.panel17.Size = new System.Drawing.Size(442, 26);
            this.panel17.TabIndex = 52;
            // 
            // tbarSetupFineGain
            // 
            this.tbarSetupFineGain.Dock = System.Windows.Forms.DockStyle.Fill;
            this.tbarSetupFineGain.LargeChange = 10;
            this.tbarSetupFineGain.Location = new System.Drawing.Point(67, 0);
            this.tbarSetupFineGain.Maximum = 5000;
            this.tbarSetupFineGain.Minimum = 1000;
            this.tbarSetupFineGain.Name = "tbarSetupFineGain";
            this.tbarSetupFineGain.Size = new System.Drawing.Size(361, 26);
            this.tbarSetupFineGain.TabIndex = 41;
            this.tbarSetupFineGain.TickStyle = System.Windows.Forms.TickStyle.None;
            this.tbarSetupFineGain.Value = 1000;
            this.tbarSetupFineGain.Scroll += new System.EventHandler(this.tbarSetupFineGain_Scroll);
            this.tbarSetupFineGain.ValueChanged += new System.EventHandler(this.tbarSetupFineGain_ValueChanged);
            // 
            // label8
            // 
            this.label8.AutoSize = true;
            this.label8.Dock = System.Windows.Forms.DockStyle.Left;
            this.label8.Font = new System.Drawing.Font("Microsoft Sans Serif", 9F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label8.Location = new System.Drawing.Point(0, 0);
            this.label8.Name = "label8";
            this.label8.Size = new System.Drawing.Size(67, 15);
            this.label8.TabIndex = 33;
            this.label8.Text = "Fine gain";
            this.label8.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            // 
            // lblSetupFineGain
            // 
            this.lblSetupFineGain.AutoSize = true;
            this.lblSetupFineGain.Dock = System.Windows.Forms.DockStyle.Right;
            this.lblSetupFineGain.Location = new System.Drawing.Point(428, 0);
            this.lblSetupFineGain.Name = "lblSetupFineGain";
            this.lblSetupFineGain.Size = new System.Drawing.Size(14, 15);
            this.lblSetupFineGain.TabIndex = 42;
            this.lblSetupFineGain.Text = "1";
            // 
            // panel3
            // 
            this.panel3.Controls.Add(this.tbarSetupLLD);
            this.panel3.Controls.Add(this.label9);
            this.panel3.Controls.Add(this.lblSetupLLD);
            this.panel3.Dock = System.Windows.Forms.DockStyle.Fill;
            this.panel3.Location = new System.Drawing.Point(3, 67);
            this.panel3.Name = "panel3";
            this.panel3.Size = new System.Drawing.Size(441, 27);
            this.panel3.TabIndex = 53;
            // 
            // tbarSetupLLD
            // 
            this.tbarSetupLLD.Dock = System.Windows.Forms.DockStyle.Fill;
            this.tbarSetupLLD.Location = new System.Drawing.Point(59, 0);
            this.tbarSetupLLD.Maximum = 100;
            this.tbarSetupLLD.Name = "tbarSetupLLD";
            this.tbarSetupLLD.Size = new System.Drawing.Size(368, 27);
            this.tbarSetupLLD.TabIndex = 1;
            this.tbarSetupLLD.TickStyle = System.Windows.Forms.TickStyle.None;
            this.tbarSetupLLD.ValueChanged += new System.EventHandler(this.tbarSetupLLD_ValueChanged);
            // 
            // label9
            // 
            this.label9.AutoSize = true;
            this.label9.Dock = System.Windows.Forms.DockStyle.Left;
            this.label9.Font = new System.Drawing.Font("Microsoft Sans Serif", 9F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label9.Location = new System.Drawing.Point(0, 0);
            this.label9.Name = "label9";
            this.label9.Size = new System.Drawing.Size(59, 15);
            this.label9.TabIndex = 34;
            this.label9.Text = "LLD (%)";
            this.label9.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            // 
            // lblSetupLLD
            // 
            this.lblSetupLLD.AutoSize = true;
            this.lblSetupLLD.Dock = System.Windows.Forms.DockStyle.Right;
            this.lblSetupLLD.Location = new System.Drawing.Point(427, 0);
            this.lblSetupLLD.Name = "lblSetupLLD";
            this.lblSetupLLD.Size = new System.Drawing.Size(14, 15);
            this.lblSetupLLD.TabIndex = 0;
            this.lblSetupLLD.Text = "0";
            // 
            // panel18
            // 
            this.panel18.Controls.Add(this.tbarSetupULD);
            this.panel18.Controls.Add(this.label10);
            this.panel18.Controls.Add(this.lblSetupULD);
            this.panel18.Dock = System.Windows.Forms.DockStyle.Fill;
            this.panel18.Location = new System.Drawing.Point(450, 67);
            this.panel18.Name = "panel18";
            this.panel18.Size = new System.Drawing.Size(441, 27);
            this.panel18.TabIndex = 54;
            // 
            // tbarSetupULD
            // 
            this.tbarSetupULD.Dock = System.Windows.Forms.DockStyle.Fill;
            this.tbarSetupULD.Location = new System.Drawing.Point(61, 0);
            this.tbarSetupULD.Maximum = 110;
            this.tbarSetupULD.Name = "tbarSetupULD";
            this.tbarSetupULD.Size = new System.Drawing.Size(366, 27);
            this.tbarSetupULD.TabIndex = 1;
            this.tbarSetupULD.TickStyle = System.Windows.Forms.TickStyle.None;
            this.tbarSetupULD.ValueChanged += new System.EventHandler(this.tbarSetupULD_ValueChanged);
            // 
            // label10
            // 
            this.label10.AutoSize = true;
            this.label10.Dock = System.Windows.Forms.DockStyle.Left;
            this.label10.Font = new System.Drawing.Font("Microsoft Sans Serif", 9F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label10.Location = new System.Drawing.Point(0, 0);
            this.label10.Name = "label10";
            this.label10.Size = new System.Drawing.Size(61, 15);
            this.label10.TabIndex = 35;
            this.label10.Text = "ULD (%)";
            this.label10.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            // 
            // lblSetupULD
            // 
            this.lblSetupULD.AutoSize = true;
            this.lblSetupULD.Dock = System.Windows.Forms.DockStyle.Right;
            this.lblSetupULD.Location = new System.Drawing.Point(427, 0);
            this.lblSetupULD.Name = "lblSetupULD";
            this.lblSetupULD.Size = new System.Drawing.Size(14, 15);
            this.lblSetupULD.TabIndex = 0;
            this.lblSetupULD.Text = "0";
            // 
            // btnSetupSetParams
            // 
            this.btnSetupSetParams.Dock = System.Windows.Forms.DockStyle.Right;
            this.btnSetupSetParams.Font = new System.Drawing.Font("Microsoft Sans Serif", 8F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnSetupSetParams.Location = new System.Drawing.Point(1012, 67);
            this.btnSetupSetParams.Name = "btnSetupSetParams";
            this.btnSetupSetParams.Size = new System.Drawing.Size(327, 27);
            this.btnSetupSetParams.TabIndex = 16;
            this.btnSetupSetParams.Text = "Set detector params";
            this.btnSetupSetParams.UseVisualStyleBackColor = true;
            this.btnSetupSetParams.Click += new System.EventHandler(this.btnSetupSetParams_Click);
            // 
            // panel15
            // 
            this.panel15.Controls.Add(this.cboxSetupChannels);
            this.panel15.Controls.Add(this.panel19);
            this.panel15.Dock = System.Windows.Forms.DockStyle.Fill;
            this.panel15.Location = new System.Drawing.Point(897, 3);
            this.panel15.Name = "panel15";
            this.panel15.Size = new System.Drawing.Size(442, 26);
            this.panel15.TabIndex = 49;
            // 
            // cboxSetupChannels
            // 
            this.cboxSetupChannels.Dock = System.Windows.Forms.DockStyle.Fill;
            this.cboxSetupChannels.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cboxSetupChannels.FormattingEnabled = true;
            this.cboxSetupChannels.Location = new System.Drawing.Point(115, 0);
            this.cboxSetupChannels.Name = "cboxSetupChannels";
            this.cboxSetupChannels.Size = new System.Drawing.Size(327, 23);
            this.cboxSetupChannels.TabIndex = 20;
            // 
            // panel19
            // 
            this.panel19.Controls.Add(this.label4);
            this.panel19.Dock = System.Windows.Forms.DockStyle.Left;
            this.panel19.Location = new System.Drawing.Point(0, 0);
            this.panel19.Name = "panel19";
            this.panel19.Size = new System.Drawing.Size(115, 26);
            this.panel19.TabIndex = 31;
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Dock = System.Windows.Forms.DockStyle.Fill;
            this.label4.Font = new System.Drawing.Font("Microsoft Sans Serif", 9F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label4.Location = new System.Drawing.Point(0, 0);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(73, 15);
            this.label4.TabIndex = 30;
            this.label4.Text = "#channels";
            this.label4.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            // 
            // panel14
            // 
            this.panel14.Controls.Add(this.cboxSetupDetector);
            this.panel14.Controls.Add(this.panel12);
            this.panel14.Dock = System.Windows.Forms.DockStyle.Fill;
            this.panel14.Location = new System.Drawing.Point(450, 3);
            this.panel14.Name = "panel14";
            this.panel14.Size = new System.Drawing.Size(441, 26);
            this.panel14.TabIndex = 48;
            // 
            // cboxSetupDetector
            // 
            this.cboxSetupDetector.Dock = System.Windows.Forms.DockStyle.Fill;
            this.cboxSetupDetector.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cboxSetupDetector.FormattingEnabled = true;
            this.cboxSetupDetector.Location = new System.Drawing.Point(114, 0);
            this.cboxSetupDetector.Name = "cboxSetupDetector";
            this.cboxSetupDetector.Size = new System.Drawing.Size(327, 23);
            this.cboxSetupDetector.TabIndex = 19;
            this.cboxSetupDetector.SelectedIndexChanged += new System.EventHandler(this.cboxSetupDetector_SelectedIndexChanged);
            // 
            // panel12
            // 
            this.panel12.Controls.Add(this.label2);
            this.panel12.Dock = System.Windows.Forms.DockStyle.Left;
            this.panel12.Location = new System.Drawing.Point(0, 0);
            this.panel12.Name = "panel12";
            this.panel12.Size = new System.Drawing.Size(114, 26);
            this.panel12.TabIndex = 20;
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Dock = System.Windows.Forms.DockStyle.Fill;
            this.label2.Font = new System.Drawing.Font("Microsoft Sans Serif", 9F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label2.Location = new System.Drawing.Point(0, 0);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(61, 15);
            this.label2.TabIndex = 18;
            this.label2.Text = "Detector";
            this.label2.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            // 
            // lblSetupIPAddress
            // 
            this.lblSetupIPAddress.AutoSize = true;
            this.lblSetupIPAddress.Dock = System.Windows.Forms.DockStyle.Fill;
            this.lblSetupIPAddress.Font = new System.Drawing.Font("Microsoft Sans Serif", 9F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblSetupIPAddress.Location = new System.Drawing.Point(3, 0);
            this.lblSetupIPAddress.Name = "lblSetupIPAddress";
            this.lblSetupIPAddress.Size = new System.Drawing.Size(441, 32);
            this.lblSetupIPAddress.TabIndex = 55;
            this.lblSetupIPAddress.Text = "<lblSetupIPAddress>";
            this.lblSetupIPAddress.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // panelSetupSession
            // 
            this.panelSetupSession.Controls.Add(this.btnSetupCancel);
            this.panelSetupSession.Controls.Add(this.btnSetupClose);
            this.panelSetupSession.Controls.Add(this.lblSetupEnergy);
            this.panelSetupSession.Controls.Add(this.lblSetupChannel);
            this.panelSetupSession.Dock = System.Windows.Forms.DockStyle.Bottom;
            this.panelSetupSession.Location = new System.Drawing.Point(0, 584);
            this.panelSetupSession.Name = "panelSetupSession";
            this.panelSetupSession.Size = new System.Drawing.Size(1342, 32);
            this.panelSetupSession.TabIndex = 22;
            // 
            // btnSetupCancel
            // 
            this.btnSetupCancel.Dock = System.Windows.Forms.DockStyle.Right;
            this.btnSetupCancel.Font = new System.Drawing.Font("Microsoft Sans Serif", 9F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnSetupCancel.Location = new System.Drawing.Point(1082, 0);
            this.btnSetupCancel.Name = "btnSetupCancel";
            this.btnSetupCancel.Size = new System.Drawing.Size(130, 32);
            this.btnSetupCancel.TabIndex = 7;
            this.btnSetupCancel.Text = "Cancel";
            this.btnSetupCancel.UseVisualStyleBackColor = true;
            this.btnSetupCancel.Click += new System.EventHandler(this.btnSetupCancel_Click);
            // 
            // btnSetupClose
            // 
            this.btnSetupClose.Dock = System.Windows.Forms.DockStyle.Right;
            this.btnSetupClose.Font = new System.Drawing.Font("Microsoft Sans Serif", 9F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnSetupClose.Location = new System.Drawing.Point(1212, 0);
            this.btnSetupClose.Name = "btnSetupClose";
            this.btnSetupClose.Size = new System.Drawing.Size(130, 32);
            this.btnSetupClose.TabIndex = 6;
            this.btnSetupClose.Text = "Done";
            this.btnSetupClose.UseVisualStyleBackColor = true;
            this.btnSetupClose.Click += new System.EventHandler(this.btnSetupClose_Click);
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
            // pageMenu
            // 
            this.pageMenu.BackColor = System.Drawing.SystemColors.ButtonFace;
            this.pageMenu.Controls.Add(this.flowLayoutPanel1);
            this.pageMenu.Location = new System.Drawing.Point(4, 27);
            this.pageMenu.Name = "pageMenu";
            this.pageMenu.Size = new System.Drawing.Size(1342, 616);
            this.pageMenu.TabIndex = 3;
            this.pageMenu.Text = "Menu";
            // 
            // flowLayoutPanel1
            // 
            this.flowLayoutPanel1.Controls.Add(this.btnMenuSessions);
            this.flowLayoutPanel1.Controls.Add(this.btnMenuDetectors);
            this.flowLayoutPanel1.Controls.Add(this.btnMenuCalibration);
            this.flowLayoutPanel1.Controls.Add(this.btnMenuPreferences);
            this.flowLayoutPanel1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.flowLayoutPanel1.Location = new System.Drawing.Point(0, 0);
            this.flowLayoutPanel1.Name = "flowLayoutPanel1";
            this.flowLayoutPanel1.Padding = new System.Windows.Forms.Padding(44, 47, 44, 47);
            this.flowLayoutPanel1.Size = new System.Drawing.Size(1342, 616);
            this.flowLayoutPanel1.TabIndex = 1;
            // 
            // btnMenuSessions
            // 
            this.btnMenuSessions.FlatAppearance.BorderSize = 0;
            this.btnMenuSessions.FlatAppearance.MouseDownBackColor = System.Drawing.SystemColors.ButtonFace;
            this.btnMenuSessions.FlatAppearance.MouseOverBackColor = System.Drawing.SystemColors.ButtonFace;
            this.btnMenuSessions.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnMenuSessions.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnMenuSessions.Image = global::crash.Properties.Resources.map_128;
            this.btnMenuSessions.Location = new System.Drawing.Point(47, 50);
            this.btnMenuSessions.Name = "btnMenuSessions";
            this.btnMenuSessions.Size = new System.Drawing.Size(200, 200);
            this.btnMenuSessions.TabIndex = 2;
            this.btnMenuSessions.Text = "Sessions";
            this.btnMenuSessions.TextAlign = System.Drawing.ContentAlignment.BottomCenter;
            this.btnMenuSessions.UseVisualStyleBackColor = true;
            this.btnMenuSessions.Click += new System.EventHandler(this.btnMenuSession_Click);
            // 
            // btnMenuDetectors
            // 
            this.btnMenuDetectors.FlatAppearance.BorderSize = 0;
            this.btnMenuDetectors.FlatAppearance.MouseDownBackColor = System.Drawing.SystemColors.ButtonFace;
            this.btnMenuDetectors.FlatAppearance.MouseOverBackColor = System.Drawing.SystemColors.ButtonFace;
            this.btnMenuDetectors.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnMenuDetectors.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnMenuDetectors.Image = global::crash.Properties.Resources.setup_128;
            this.btnMenuDetectors.Location = new System.Drawing.Point(253, 50);
            this.btnMenuDetectors.Name = "btnMenuDetectors";
            this.btnMenuDetectors.Size = new System.Drawing.Size(200, 200);
            this.btnMenuDetectors.TabIndex = 0;
            this.btnMenuDetectors.Text = "Detector Definitions";
            this.btnMenuDetectors.TextAlign = System.Drawing.ContentAlignment.BottomCenter;
            this.btnMenuDetectors.UseVisualStyleBackColor = true;
            this.btnMenuDetectors.Click += new System.EventHandler(this.btnMenuPreferences_Click);
            // 
            // btnMenuCalibration
            // 
            this.btnMenuCalibration.FlatAppearance.BorderSize = 0;
            this.btnMenuCalibration.FlatAppearance.MouseDownBackColor = System.Drawing.SystemColors.ButtonFace;
            this.btnMenuCalibration.FlatAppearance.MouseOverBackColor = System.Drawing.SystemColors.ButtonFace;
            this.btnMenuCalibration.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnMenuCalibration.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnMenuCalibration.Image = global::crash.Properties.Resources.calibrate128;
            this.btnMenuCalibration.Location = new System.Drawing.Point(459, 50);
            this.btnMenuCalibration.Name = "btnMenuCalibration";
            this.btnMenuCalibration.Size = new System.Drawing.Size(200, 200);
            this.btnMenuCalibration.TabIndex = 3;
            this.btnMenuCalibration.Text = "Calibrate Detectors";
            this.btnMenuCalibration.TextAlign = System.Drawing.ContentAlignment.BottomCenter;
            this.btnMenuCalibration.UseVisualStyleBackColor = true;
            this.btnMenuCalibration.Click += new System.EventHandler(this.btnMenuCalibration_Click);
            // 
            // btnMenuPreferences
            // 
            this.btnMenuPreferences.FlatAppearance.BorderSize = 0;
            this.btnMenuPreferences.FlatAppearance.MouseDownBackColor = System.Drawing.SystemColors.ButtonFace;
            this.btnMenuPreferences.FlatAppearance.MouseOverBackColor = System.Drawing.SystemColors.ButtonFace;
            this.btnMenuPreferences.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnMenuPreferences.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnMenuPreferences.Image = global::crash.Properties.Resources.preferences128;
            this.btnMenuPreferences.Location = new System.Drawing.Point(665, 50);
            this.btnMenuPreferences.Name = "btnMenuPreferences";
            this.btnMenuPreferences.Size = new System.Drawing.Size(200, 200);
            this.btnMenuPreferences.TabIndex = 4;
            this.btnMenuPreferences.Text = "Preferences";
            this.btnMenuPreferences.TextAlign = System.Drawing.ContentAlignment.BottomCenter;
            this.btnMenuPreferences.UseVisualStyleBackColor = true;
            this.btnMenuPreferences.Click += new System.EventHandler(this.btnMenuPreferences_Click_1);
            // 
            // pageSessions
            // 
            this.pageSessions.BackColor = System.Drawing.SystemColors.ButtonFace;
            this.pageSessions.Controls.Add(this.splitContainer2);
            this.pageSessions.Controls.Add(this.panelSessionsControl);
            this.pageSessions.Location = new System.Drawing.Point(4, 27);
            this.pageSessions.Name = "pageSessions";
            this.pageSessions.Size = new System.Drawing.Size(1342, 616);
            this.pageSessions.TabIndex = 4;
            this.pageSessions.Text = "Sessions";
            // 
            // splitContainer2
            // 
            this.splitContainer2.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.splitContainer2.Dock = System.Windows.Forms.DockStyle.Fill;
            this.splitContainer2.FixedPanel = System.Windows.Forms.FixedPanel.Panel1;
            this.splitContainer2.Location = new System.Drawing.Point(0, 30);
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
            this.splitContainer2.Size = new System.Drawing.Size(1342, 586);
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
            this.splitContainerSessionLeft.Size = new System.Drawing.Size(183, 584);
            this.splitContainerSessionLeft.SplitterDistance = 345;
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
            this.lbSession.Size = new System.Drawing.Size(183, 345);
            this.lbSession.TabIndex = 7;
            this.lbSession.SelectedIndexChanged += new System.EventHandler(this.lbSession_SelectedIndexChanged);
            // 
            // panelNuclides
            // 
            this.panelNuclides.Controls.Add(this.lbNuclides);
            this.panelNuclides.Controls.Add(this.label12);
            this.panelNuclides.Controls.Add(this.panel8);
            this.panelNuclides.Controls.Add(this.label19);
            this.panelNuclides.Dock = System.Windows.Forms.DockStyle.Fill;
            this.panelNuclides.Location = new System.Drawing.Point(0, 0);
            this.panelNuclides.Name = "panelNuclides";
            this.panelNuclides.Size = new System.Drawing.Size(183, 235);
            this.panelNuclides.TabIndex = 8;
            // 
            // lbNuclides
            // 
            this.lbNuclides.BackColor = System.Drawing.SystemColors.ButtonFace;
            this.lbNuclides.BorderStyle = System.Windows.Forms.BorderStyle.None;
            this.lbNuclides.ContextMenuStrip = this.contextMenuNuclides;
            this.lbNuclides.Dock = System.Windows.Forms.DockStyle.Fill;
            this.lbNuclides.FormattingEnabled = true;
            this.lbNuclides.ItemHeight = 15;
            this.lbNuclides.Location = new System.Drawing.Point(0, 63);
            this.lbNuclides.Name = "lbNuclides";
            this.lbNuclides.Size = new System.Drawing.Size(183, 172);
            this.lbNuclides.TabIndex = 2;
            this.lbNuclides.SelectedIndexChanged += new System.EventHandler(this.lbNuclides_SelectedIndexChanged);
            // 
            // contextMenuNuclides
            // 
            this.contextMenuNuclides.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.menuItemNuclidesUnselect});
            this.contextMenuNuclides.Name = "contextMenuNuclides";
            this.contextMenuNuclides.Size = new System.Drawing.Size(120, 26);
            // 
            // menuItemNuclidesUnselect
            // 
            this.menuItemNuclidesUnselect.Name = "menuItemNuclidesUnselect";
            this.menuItemNuclidesUnselect.Size = new System.Drawing.Size(119, 22);
            this.menuItemNuclidesUnselect.Text = "&Unselect";
            this.menuItemNuclidesUnselect.Click += new System.EventHandler(this.menuItemNuclidesUnselect_Click);
            // 
            // label12
            // 
            this.label12.AutoSize = true;
            this.label12.Dock = System.Windows.Forms.DockStyle.Top;
            this.label12.Font = new System.Drawing.Font("Microsoft Sans Serif", 9F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label12.Location = new System.Drawing.Point(0, 48);
            this.label12.Name = "label12";
            this.label12.Size = new System.Drawing.Size(137, 15);
            this.label12.TabIndex = 3;
            this.label12.Text = "Nuclide suggestions";
            // 
            // panel8
            // 
            this.panel8.Controls.Add(this.tbarNuclides);
            this.panel8.Controls.Add(this.lblSessionETOL);
            this.panel8.Dock = System.Windows.Forms.DockStyle.Top;
            this.panel8.Location = new System.Drawing.Point(0, 21);
            this.panel8.Name = "panel8";
            this.panel8.Size = new System.Drawing.Size(183, 27);
            this.panel8.TabIndex = 4;
            // 
            // tbarNuclides
            // 
            this.tbarNuclides.AutoSize = false;
            this.tbarNuclides.Dock = System.Windows.Forms.DockStyle.Fill;
            this.tbarNuclides.Location = new System.Drawing.Point(0, 0);
            this.tbarNuclides.Maximum = 200;
            this.tbarNuclides.Minimum = 1;
            this.tbarNuclides.Name = "tbarNuclides";
            this.tbarNuclides.Size = new System.Drawing.Size(162, 27);
            this.tbarNuclides.TabIndex = 1;
            this.tbarNuclides.TickStyle = System.Windows.Forms.TickStyle.None;
            this.tbarNuclides.Value = 20;
            this.tbarNuclides.ValueChanged += new System.EventHandler(this.tbarNuclides_ValueChanged);
            // 
            // lblSessionETOL
            // 
            this.lblSessionETOL.AutoSize = true;
            this.lblSessionETOL.Dock = System.Windows.Forms.DockStyle.Right;
            this.lblSessionETOL.Location = new System.Drawing.Point(162, 0);
            this.lblSessionETOL.Name = "lblSessionETOL";
            this.lblSessionETOL.Size = new System.Drawing.Size(21, 15);
            this.lblSessionETOL.TabIndex = 0;
            this.lblSessionETOL.Text = "20";
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
            this.graphSession.Location = new System.Drawing.Point(0, 110);
            this.graphSession.Name = "graphSession";
            this.graphSession.ScrollGrace = 0D;
            this.graphSession.ScrollMaxX = 0D;
            this.graphSession.ScrollMaxY = 0D;
            this.graphSession.ScrollMaxY2 = 0D;
            this.graphSession.ScrollMinX = 0D;
            this.graphSession.ScrollMinY = 0D;
            this.graphSession.ScrollMinY2 = 0D;
            this.graphSession.Size = new System.Drawing.Size(1150, 444);
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
            this.tableLayoutPanel2.Controls.Add(this.lblLatitude, 0, 2);
            this.tableLayoutPanel2.Controls.Add(this.lblLongitude, 1, 2);
            this.tableLayoutPanel2.Controls.Add(this.lblAltitude, 2, 2);
            this.tableLayoutPanel2.Controls.Add(this.lblGpsTime, 3, 2);
            this.tableLayoutPanel2.Controls.Add(this.lblSession, 0, 0);
            this.tableLayoutPanel2.Controls.Add(this.lblBackground, 3, 0);
            this.tableLayoutPanel2.Controls.Add(this.lblComment, 1, 0);
            this.tableLayoutPanel2.Controls.Add(this.lblLivetime, 3, 1);
            this.tableLayoutPanel2.Controls.Add(this.lblRealtime, 2, 1);
            this.tableLayoutPanel2.Controls.Add(this.lblIndex, 1, 1);
            this.tableLayoutPanel2.Controls.Add(this.lblSessionDetector, 0, 1);
            this.tableLayoutPanel2.Controls.Add(this.lblMaxCount, 0, 3);
            this.tableLayoutPanel2.Controls.Add(this.lblMinCount, 1, 3);
            this.tableLayoutPanel2.Controls.Add(this.lblTotalCount, 2, 3);
            this.tableLayoutPanel2.Controls.Add(this.lblDoserate, 3, 3);
            this.tableLayoutPanel2.Dock = System.Windows.Forms.DockStyle.Top;
            this.tableLayoutPanel2.Location = new System.Drawing.Point(0, 25);
            this.tableLayoutPanel2.Name = "tableLayoutPanel2";
            this.tableLayoutPanel2.RowCount = 5;
            this.tableLayoutPanel2.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 20F));
            this.tableLayoutPanel2.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 20F));
            this.tableLayoutPanel2.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 20F));
            this.tableLayoutPanel2.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 20F));
            this.tableLayoutPanel2.RowStyles.Add(new System.Windows.Forms.RowStyle());
            this.tableLayoutPanel2.Size = new System.Drawing.Size(1150, 85);
            this.tableLayoutPanel2.TabIndex = 0;
            // 
            // lblLatitude
            // 
            this.lblLatitude.AutoSize = true;
            this.lblLatitude.Dock = System.Windows.Forms.DockStyle.Fill;
            this.lblLatitude.Font = new System.Drawing.Font("Microsoft Sans Serif", 8F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblLatitude.Location = new System.Drawing.Point(3, 40);
            this.lblLatitude.Name = "lblLatitude";
            this.lblLatitude.Size = new System.Drawing.Size(281, 20);
            this.lblLatitude.TabIndex = 0;
            this.lblLatitude.Text = "<Latitude>";
            this.lblLatitude.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // lblLongitude
            // 
            this.lblLongitude.AutoSize = true;
            this.lblLongitude.Dock = System.Windows.Forms.DockStyle.Fill;
            this.lblLongitude.Font = new System.Drawing.Font("Microsoft Sans Serif", 8F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblLongitude.Location = new System.Drawing.Point(290, 40);
            this.lblLongitude.Name = "lblLongitude";
            this.lblLongitude.Size = new System.Drawing.Size(281, 20);
            this.lblLongitude.TabIndex = 1;
            this.lblLongitude.Text = "<Longitude>";
            this.lblLongitude.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // lblAltitude
            // 
            this.lblAltitude.AutoSize = true;
            this.lblAltitude.Dock = System.Windows.Forms.DockStyle.Fill;
            this.lblAltitude.Font = new System.Drawing.Font("Microsoft Sans Serif", 8F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblAltitude.Location = new System.Drawing.Point(577, 40);
            this.lblAltitude.Name = "lblAltitude";
            this.lblAltitude.Size = new System.Drawing.Size(281, 20);
            this.lblAltitude.TabIndex = 9;
            this.lblAltitude.Text = "<Altitude>";
            this.lblAltitude.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // lblGpsTime
            // 
            this.lblGpsTime.AutoSize = true;
            this.lblGpsTime.Dock = System.Windows.Forms.DockStyle.Fill;
            this.lblGpsTime.Font = new System.Drawing.Font("Microsoft Sans Serif", 8F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblGpsTime.Location = new System.Drawing.Point(864, 40);
            this.lblGpsTime.Name = "lblGpsTime";
            this.lblGpsTime.Size = new System.Drawing.Size(283, 20);
            this.lblGpsTime.TabIndex = 10;
            this.lblGpsTime.Text = "<GpsTimeStart>";
            this.lblGpsTime.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
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
            this.lblBackground.Size = new System.Drawing.Size(283, 20);
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
            this.lblLivetime.Size = new System.Drawing.Size(283, 20);
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
            // lblMaxCount
            // 
            this.lblMaxCount.AutoSize = true;
            this.lblMaxCount.Dock = System.Windows.Forms.DockStyle.Fill;
            this.lblMaxCount.Font = new System.Drawing.Font("Microsoft Sans Serif", 8F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblMaxCount.Location = new System.Drawing.Point(3, 60);
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
            this.lblMinCount.Location = new System.Drawing.Point(290, 60);
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
            this.lblTotalCount.Location = new System.Drawing.Point(577, 60);
            this.lblTotalCount.Name = "lblTotalCount";
            this.lblTotalCount.Size = new System.Drawing.Size(281, 20);
            this.lblTotalCount.TabIndex = 8;
            this.lblTotalCount.Text = "<TotalCount>";
            this.lblTotalCount.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // lblDoserate
            // 
            this.lblDoserate.AutoSize = true;
            this.lblDoserate.Dock = System.Windows.Forms.DockStyle.Fill;
            this.lblDoserate.Font = new System.Drawing.Font("Microsoft Sans Serif", 8F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblDoserate.Location = new System.Drawing.Point(864, 60);
            this.lblDoserate.Name = "lblDoserate";
            this.lblDoserate.Size = new System.Drawing.Size(283, 20);
            this.lblDoserate.TabIndex = 15;
            this.lblDoserate.Text = "<Doserate>";
            this.lblDoserate.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // toolsSession
            // 
            this.toolsSession.GripStyle = System.Windows.Forms.ToolStripGripStyle.Hidden;
            this.toolsSession.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.btnOptions});
            this.toolsSession.Location = new System.Drawing.Point(0, 0);
            this.toolsSession.Name = "toolsSession";
            this.toolsSession.Size = new System.Drawing.Size(1150, 25);
            this.toolsSession.TabIndex = 7;
            this.toolsSession.Text = "toolStrip1";
            // 
            // btnOptions
            // 
            this.btnOptions.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.menuItemSubtractBackground,
            this.menuItemConvertToLocalTime});
            this.btnOptions.Image = global::crash.Properties.Resources.options1_16;
            this.btnOptions.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.btnOptions.Name = "btnOptions";
            this.btnOptions.Size = new System.Drawing.Size(78, 22);
            this.btnOptions.Text = "Options";
            this.btnOptions.ToolTipText = "Session options";
            // 
            // menuItemSubtractBackground
            // 
            this.menuItemSubtractBackground.CheckOnClick = true;
            this.menuItemSubtractBackground.Name = "menuItemSubtractBackground";
            this.menuItemSubtractBackground.Size = new System.Drawing.Size(185, 22);
            this.menuItemSubtractBackground.Text = "Subtract background";
            // 
            // menuItemConvertToLocalTime
            // 
            this.menuItemConvertToLocalTime.Checked = true;
            this.menuItemConvertToLocalTime.CheckOnClick = true;
            this.menuItemConvertToLocalTime.CheckState = System.Windows.Forms.CheckState.Checked;
            this.menuItemConvertToLocalTime.Name = "menuItemConvertToLocalTime";
            this.menuItemConvertToLocalTime.Size = new System.Drawing.Size(185, 22);
            this.menuItemConvertToLocalTime.Text = "Show local time";
            this.menuItemConvertToLocalTime.ToolTipText = "Show dates using local time";
            this.menuItemConvertToLocalTime.CheckedChanged += new System.EventHandler(this.menuItemConvertToLocalTime_CheckedChanged);
            // 
            // panel1
            // 
            this.panel1.Controls.Add(this.btnSessionsClose);
            this.panel1.Controls.Add(this.lblSessionEnergy);
            this.panel1.Controls.Add(this.lblSessionChannel);
            this.panel1.Dock = System.Windows.Forms.DockStyle.Bottom;
            this.panel1.Location = new System.Drawing.Point(0, 554);
            this.panel1.Name = "panel1";
            this.panel1.Size = new System.Drawing.Size(1150, 30);
            this.panel1.TabIndex = 6;
            // 
            // btnSessionsClose
            // 
            this.btnSessionsClose.Dock = System.Windows.Forms.DockStyle.Right;
            this.btnSessionsClose.Font = new System.Drawing.Font("Microsoft Sans Serif", 9F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnSessionsClose.Location = new System.Drawing.Point(1020, 0);
            this.btnSessionsClose.Name = "btnSessionsClose";
            this.btnSessionsClose.Size = new System.Drawing.Size(130, 30);
            this.btnSessionsClose.TabIndex = 2;
            this.btnSessionsClose.Text = "Close";
            this.btnSessionsClose.UseVisualStyleBackColor = true;
            this.btnSessionsClose.Click += new System.EventHandler(this.btnSessionsClose_Click);
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
            // panelSessionsControl
            // 
            this.panelSessionsControl.Controls.Add(this.lblSessionsDatabase);
            this.panelSessionsControl.Controls.Add(this.btnSessionsBrowse);
            this.panelSessionsControl.Controls.Add(this.btnSessionsSync);
            this.panelSessionsControl.Controls.Add(this.btnSessionsStop);
            this.panelSessionsControl.Controls.Add(this.btnSessionsNew);
            this.panelSessionsControl.Dock = System.Windows.Forms.DockStyle.Top;
            this.panelSessionsControl.Location = new System.Drawing.Point(0, 0);
            this.panelSessionsControl.Name = "panelSessionsControl";
            this.panelSessionsControl.Size = new System.Drawing.Size(1342, 30);
            this.panelSessionsControl.TabIndex = 7;
            // 
            // lblSessionsDatabase
            // 
            this.lblSessionsDatabase.Dock = System.Windows.Forms.DockStyle.Fill;
            this.lblSessionsDatabase.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblSessionsDatabase.Location = new System.Drawing.Point(260, 0);
            this.lblSessionsDatabase.Name = "lblSessionsDatabase";
            this.lblSessionsDatabase.Padding = new System.Windows.Forms.Padding(0, 6, 0, 0);
            this.lblSessionsDatabase.Size = new System.Drawing.Size(822, 30);
            this.lblSessionsDatabase.TabIndex = 4;
            this.lblSessionsDatabase.Text = "<lblSessionsDatabase>";
            this.lblSessionsDatabase.TextAlign = System.Drawing.ContentAlignment.TopCenter;
            // 
            // btnSessionsBrowse
            // 
            this.btnSessionsBrowse.Dock = System.Windows.Forms.DockStyle.Left;
            this.btnSessionsBrowse.Font = new System.Drawing.Font("Microsoft Sans Serif", 9F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnSessionsBrowse.Location = new System.Drawing.Point(130, 0);
            this.btnSessionsBrowse.Name = "btnSessionsBrowse";
            this.btnSessionsBrowse.Size = new System.Drawing.Size(130, 30);
            this.btnSessionsBrowse.TabIndex = 3;
            this.btnSessionsBrowse.Text = "Open session";
            this.btnSessionsBrowse.UseVisualStyleBackColor = true;
            this.btnSessionsBrowse.Click += new System.EventHandler(this.menuItemLoadSession_Click);
            // 
            // btnSessionsSync
            // 
            this.btnSessionsSync.Dock = System.Windows.Forms.DockStyle.Right;
            this.btnSessionsSync.Font = new System.Drawing.Font("Microsoft Sans Serif", 9F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnSessionsSync.Location = new System.Drawing.Point(1082, 0);
            this.btnSessionsSync.Name = "btnSessionsSync";
            this.btnSessionsSync.Size = new System.Drawing.Size(130, 30);
            this.btnSessionsSync.TabIndex = 2;
            this.btnSessionsSync.Text = "Sync session";
            this.btnSessionsSync.UseVisualStyleBackColor = true;
            this.btnSessionsSync.Click += new System.EventHandler(this.menuItemSyncCurrentSession_Click);
            // 
            // btnSessionsStop
            // 
            this.btnSessionsStop.Dock = System.Windows.Forms.DockStyle.Right;
            this.btnSessionsStop.Font = new System.Drawing.Font("Microsoft Sans Serif", 9F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnSessionsStop.Location = new System.Drawing.Point(1212, 0);
            this.btnSessionsStop.Name = "btnSessionsStop";
            this.btnSessionsStop.Size = new System.Drawing.Size(130, 30);
            this.btnSessionsStop.TabIndex = 1;
            this.btnSessionsStop.Text = "Stop session";
            this.btnSessionsStop.UseVisualStyleBackColor = true;
            this.btnSessionsStop.Click += new System.EventHandler(this.menuItemStopSession_Click);
            // 
            // btnSessionsNew
            // 
            this.btnSessionsNew.Dock = System.Windows.Forms.DockStyle.Left;
            this.btnSessionsNew.Font = new System.Drawing.Font("Microsoft Sans Serif", 9F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnSessionsNew.Location = new System.Drawing.Point(0, 0);
            this.btnSessionsNew.Name = "btnSessionsNew";
            this.btnSessionsNew.Size = new System.Drawing.Size(130, 30);
            this.btnSessionsNew.TabIndex = 0;
            this.btnSessionsNew.Text = "New session";
            this.btnSessionsNew.UseVisualStyleBackColor = true;
            this.btnSessionsNew.Click += new System.EventHandler(this.menuItemStartNewSession_Click);
            // 
            // pageDetectors
            // 
            this.pageDetectors.Controls.Add(this.tableLayoutPref);
            this.pageDetectors.Controls.Add(this.panel6);
            this.pageDetectors.Location = new System.Drawing.Point(4, 27);
            this.pageDetectors.Name = "pageDetectors";
            this.pageDetectors.Size = new System.Drawing.Size(1342, 616);
            this.pageDetectors.TabIndex = 5;
            this.pageDetectors.Text = "Detectors";
            this.pageDetectors.UseVisualStyleBackColor = true;
            // 
            // tableLayoutPref
            // 
            this.tableLayoutPref.ColumnCount = 2;
            this.tableLayoutPref.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 88.88889F));
            this.tableLayoutPref.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 11.11111F));
            this.tableLayoutPref.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Absolute, 20F));
            this.tableLayoutPref.Controls.Add(this.lvDetectors, 0, 1);
            this.tableLayoutPref.Controls.Add(this.panel2, 1, 1);
            this.tableLayoutPref.Controls.Add(this.label18, 0, 0);
            this.tableLayoutPref.Dock = System.Windows.Forms.DockStyle.Fill;
            this.tableLayoutPref.Location = new System.Drawing.Point(0, 0);
            this.tableLayoutPref.Name = "tableLayoutPref";
            this.tableLayoutPref.RowCount = 2;
            this.tableLayoutPref.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 28F));
            this.tableLayoutPref.RowStyles.Add(new System.Windows.Forms.RowStyle());
            this.tableLayoutPref.Size = new System.Drawing.Size(1342, 586);
            this.tableLayoutPref.TabIndex = 1;
            // 
            // lvDetectors
            // 
            this.lvDetectors.Columns.AddRange(new System.Windows.Forms.ColumnHeader[] {
            this.colSerialnumber,
            this.colType,
            this.colNumChannels,
            this.colMaxNumChannels,
            this.colHV,
            this.colMinHV,
            this.colMaxHV,
            this.colCoarseGain,
            this.colFineGain,
            this.colLivetime,
            this.colLLD,
            this.colULD,
            this.colPluginName,
            this.colGEScript});
            this.lvDetectors.Dock = System.Windows.Forms.DockStyle.Fill;
            this.lvDetectors.FullRowSelect = true;
            this.lvDetectors.Location = new System.Drawing.Point(3, 31);
            this.lvDetectors.MultiSelect = false;
            this.lvDetectors.Name = "lvDetectors";
            this.lvDetectors.Size = new System.Drawing.Size(1186, 552);
            this.lvDetectors.TabIndex = 8;
            this.lvDetectors.UseCompatibleStateImageBehavior = false;
            this.lvDetectors.View = System.Windows.Forms.View.Details;
            // 
            // colSerialnumber
            // 
            this.colSerialnumber.Text = "Serialnumber";
            this.colSerialnumber.Width = 106;
            // 
            // colType
            // 
            this.colType.Text = "Type";
            this.colType.Width = 63;
            // 
            // colNumChannels
            // 
            this.colNumChannels.Text = "Num. Channels";
            this.colNumChannels.Width = 108;
            // 
            // colMaxNumChannels
            // 
            this.colMaxNumChannels.Text = "Max Num. Channels";
            this.colMaxNumChannels.Width = 108;
            // 
            // colHV
            // 
            this.colHV.Text = "Voltage";
            this.colHV.Width = 69;
            // 
            // colMinHV
            // 
            this.colMinHV.Text = "Min HV";
            // 
            // colMaxHV
            // 
            this.colMaxHV.Text = "Max HV";
            // 
            // colCoarseGain
            // 
            this.colCoarseGain.Text = "Coarse gain";
            this.colCoarseGain.Width = 96;
            // 
            // colFineGain
            // 
            this.colFineGain.Text = "Fine gain";
            this.colFineGain.Width = 87;
            // 
            // colLivetime
            // 
            this.colLivetime.Text = "Livetime";
            // 
            // colLLD
            // 
            this.colLLD.Text = "LLD";
            // 
            // colULD
            // 
            this.colULD.Text = "ULD";
            // 
            // colPluginName
            // 
            this.colPluginName.Text = "Plugin";
            // 
            // colGEScript
            // 
            this.colGEScript.Text = "GE Script";
            // 
            // panel2
            // 
            this.panel2.Controls.Add(this.btnEditDetector);
            this.panel2.Controls.Add(this.btnAddDetector);
            this.panel2.Dock = System.Windows.Forms.DockStyle.Fill;
            this.panel2.Location = new System.Drawing.Point(1195, 31);
            this.panel2.Name = "panel2";
            this.panel2.Size = new System.Drawing.Size(144, 552);
            this.panel2.TabIndex = 10;
            // 
            // btnEditDetector
            // 
            this.btnEditDetector.Dock = System.Windows.Forms.DockStyle.Top;
            this.btnEditDetector.Location = new System.Drawing.Point(0, 26);
            this.btnEditDetector.Name = "btnEditDetector";
            this.btnEditDetector.Size = new System.Drawing.Size(144, 26);
            this.btnEditDetector.TabIndex = 8;
            this.btnEditDetector.Text = "Edit";
            this.btnEditDetector.UseVisualStyleBackColor = true;
            this.btnEditDetector.Click += new System.EventHandler(this.btnEditDetector_Click);
            // 
            // btnAddDetector
            // 
            this.btnAddDetector.Dock = System.Windows.Forms.DockStyle.Top;
            this.btnAddDetector.Location = new System.Drawing.Point(0, 0);
            this.btnAddDetector.Name = "btnAddDetector";
            this.btnAddDetector.Size = new System.Drawing.Size(144, 26);
            this.btnAddDetector.TabIndex = 7;
            this.btnAddDetector.Text = "Add";
            this.btnAddDetector.UseVisualStyleBackColor = true;
            this.btnAddDetector.Click += new System.EventHandler(this.btnAddDetector_Click);
            // 
            // label18
            // 
            this.label18.AutoSize = true;
            this.label18.Location = new System.Drawing.Point(3, 0);
            this.label18.Name = "label18";
            this.label18.Size = new System.Drawing.Size(59, 15);
            this.label18.TabIndex = 6;
            this.label18.Text = "Detectors";
            // 
            // panel6
            // 
            this.panel6.Controls.Add(this.btnPreferencesClose);
            this.panel6.Dock = System.Windows.Forms.DockStyle.Bottom;
            this.panel6.Location = new System.Drawing.Point(0, 586);
            this.panel6.Name = "panel6";
            this.panel6.Size = new System.Drawing.Size(1342, 30);
            this.panel6.TabIndex = 2;
            // 
            // btnPreferencesClose
            // 
            this.btnPreferencesClose.Dock = System.Windows.Forms.DockStyle.Right;
            this.btnPreferencesClose.Font = new System.Drawing.Font("Microsoft Sans Serif", 9F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnPreferencesClose.Location = new System.Drawing.Point(1212, 0);
            this.btnPreferencesClose.Name = "btnPreferencesClose";
            this.btnPreferencesClose.Size = new System.Drawing.Size(130, 30);
            this.btnPreferencesClose.TabIndex = 0;
            this.btnPreferencesClose.Text = "Close";
            this.btnPreferencesClose.UseVisualStyleBackColor = true;
            this.btnPreferencesClose.Click += new System.EventHandler(this.btnPreferencesClose_Click);
            // 
            // pageNew
            // 
            this.pageNew.Controls.Add(this.tableNew);
            this.pageNew.Controls.Add(this.panel9);
            this.pageNew.Location = new System.Drawing.Point(4, 27);
            this.pageNew.Name = "pageNew";
            this.pageNew.Padding = new System.Windows.Forms.Padding(3);
            this.pageNew.Size = new System.Drawing.Size(1342, 616);
            this.pageNew.TabIndex = 6;
            this.pageNew.Text = "New";
            this.pageNew.UseVisualStyleBackColor = true;
            // 
            // tableNew
            // 
            this.tableNew.ColumnCount = 3;
            this.tableNew.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 33.33333F));
            this.tableNew.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 33.33333F));
            this.tableNew.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 33.33333F));
            this.tableNew.Controls.Add(this.tbNewComment, 1, 2);
            this.tableNew.Controls.Add(this.tbNewLivetime, 1, 1);
            this.tableNew.Controls.Add(this.label1, 0, 2);
            this.tableNew.Controls.Add(this.label16, 0, 1);
            this.tableNew.Dock = System.Windows.Forms.DockStyle.Fill;
            this.tableNew.Location = new System.Drawing.Point(3, 3);
            this.tableNew.Name = "tableNew";
            this.tableNew.RowCount = 5;
            this.tableNew.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 30F));
            this.tableNew.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 30F));
            this.tableNew.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 30F));
            this.tableNew.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 30F));
            this.tableNew.RowStyles.Add(new System.Windows.Forms.RowStyle());
            this.tableNew.Size = new System.Drawing.Size(1336, 580);
            this.tableNew.TabIndex = 0;
            // 
            // tbNewComment
            // 
            this.tbNewComment.Dock = System.Windows.Forms.DockStyle.Fill;
            this.tbNewComment.Location = new System.Drawing.Point(448, 63);
            this.tbNewComment.MaxLength = 512;
            this.tbNewComment.Name = "tbNewComment";
            this.tbNewComment.Size = new System.Drawing.Size(439, 21);
            this.tbNewComment.TabIndex = 1;
            // 
            // tbNewLivetime
            // 
            this.tbNewLivetime.Dock = System.Windows.Forms.DockStyle.Fill;
            this.tbNewLivetime.Location = new System.Drawing.Point(448, 33);
            this.tbNewLivetime.MaxLength = 5;
            this.tbNewLivetime.Name = "tbNewLivetime";
            this.tbNewLivetime.Size = new System.Drawing.Size(439, 21);
            this.tbNewLivetime.TabIndex = 6;
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Dock = System.Windows.Forms.DockStyle.Right;
            this.label1.Location = new System.Drawing.Point(381, 60);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(61, 30);
            this.label1.TabIndex = 0;
            this.label1.Text = "Comment";
            // 
            // label16
            // 
            this.label16.AutoSize = true;
            this.label16.Dock = System.Windows.Forms.DockStyle.Right;
            this.label16.Location = new System.Drawing.Point(389, 30);
            this.label16.Name = "label16";
            this.label16.Padding = new System.Windows.Forms.Padding(0, 2, 0, 0);
            this.label16.Size = new System.Drawing.Size(53, 30);
            this.label16.TabIndex = 7;
            this.label16.Text = "Livetime";
            // 
            // panel9
            // 
            this.panel9.Controls.Add(this.btnNewCancel);
            this.panel9.Controls.Add(this.btnNewStart);
            this.panel9.Dock = System.Windows.Forms.DockStyle.Bottom;
            this.panel9.Location = new System.Drawing.Point(3, 583);
            this.panel9.Name = "panel9";
            this.panel9.Size = new System.Drawing.Size(1336, 30);
            this.panel9.TabIndex = 1;
            // 
            // btnNewCancel
            // 
            this.btnNewCancel.Dock = System.Windows.Forms.DockStyle.Right;
            this.btnNewCancel.Font = new System.Drawing.Font("Microsoft Sans Serif", 9F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnNewCancel.Location = new System.Drawing.Point(1076, 0);
            this.btnNewCancel.Name = "btnNewCancel";
            this.btnNewCancel.Size = new System.Drawing.Size(130, 30);
            this.btnNewCancel.TabIndex = 1;
            this.btnNewCancel.Text = "Cancel";
            this.btnNewCancel.UseVisualStyleBackColor = true;
            this.btnNewCancel.Click += new System.EventHandler(this.btnNewCancel_Click);
            // 
            // btnNewStart
            // 
            this.btnNewStart.Dock = System.Windows.Forms.DockStyle.Right;
            this.btnNewStart.Font = new System.Drawing.Font("Microsoft Sans Serif", 9F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnNewStart.Location = new System.Drawing.Point(1206, 0);
            this.btnNewStart.Name = "btnNewStart";
            this.btnNewStart.Size = new System.Drawing.Size(130, 30);
            this.btnNewStart.TabIndex = 0;
            this.btnNewStart.Text = "Start session";
            this.btnNewStart.UseVisualStyleBackColor = true;
            this.btnNewStart.Click += new System.EventHandler(this.btnNewStart_Click);
            // 
            // pageStatus
            // 
            this.pageStatus.Controls.Add(this.tableStatus);
            this.pageStatus.Controls.Add(this.panel7);
            this.pageStatus.Location = new System.Drawing.Point(4, 27);
            this.pageStatus.Name = "pageStatus";
            this.pageStatus.Padding = new System.Windows.Forms.Padding(3);
            this.pageStatus.Size = new System.Drawing.Size(1342, 616);
            this.pageStatus.TabIndex = 7;
            this.pageStatus.Text = "Status";
            this.pageStatus.UseVisualStyleBackColor = true;
            // 
            // tableStatus
            // 
            this.tableStatus.ColumnCount = 3;
            this.tableStatus.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 33.33333F));
            this.tableStatus.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 33.33333F));
            this.tableStatus.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 33.33333F));
            this.tableStatus.Controls.Add(this.label3, 0, 1);
            this.tableStatus.Controls.Add(this.btnStatusGet, 2, 1);
            this.tableStatus.Controls.Add(this.tbStatusIPAddress, 1, 1);
            this.tableStatus.Controls.Add(this.lblStatusDetectorConfigured, 1, 6);
            this.tableStatus.Controls.Add(this.lblStatusSpectrumIndex, 1, 5);
            this.tableStatus.Controls.Add(this.lblStatusSessionRunning, 1, 4);
            this.tableStatus.Controls.Add(this.lblStatusFreeDiskSpace, 1, 3);
            this.tableStatus.Dock = System.Windows.Forms.DockStyle.Fill;
            this.tableStatus.Location = new System.Drawing.Point(3, 3);
            this.tableStatus.Name = "tableStatus";
            this.tableStatus.RowCount = 8;
            this.tableStatus.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 30F));
            this.tableStatus.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 30F));
            this.tableStatus.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 30F));
            this.tableStatus.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 30F));
            this.tableStatus.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 30F));
            this.tableStatus.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 30F));
            this.tableStatus.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 30F));
            this.tableStatus.RowStyles.Add(new System.Windows.Forms.RowStyle());
            this.tableStatus.Size = new System.Drawing.Size(1336, 580);
            this.tableStatus.TabIndex = 5;
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Dock = System.Windows.Forms.DockStyle.Right;
            this.label3.Location = new System.Drawing.Point(377, 30);
            this.label3.Name = "label3";
            this.label3.Padding = new System.Windows.Forms.Padding(0, 4, 0, 0);
            this.label3.Size = new System.Drawing.Size(65, 30);
            this.label3.TabIndex = 1;
            this.label3.Text = "IP Address";
            // 
            // btnStatusGet
            // 
            this.btnStatusGet.Dock = System.Windows.Forms.DockStyle.Left;
            this.btnStatusGet.Location = new System.Drawing.Point(893, 33);
            this.btnStatusGet.Name = "btnStatusGet";
            this.btnStatusGet.Size = new System.Drawing.Size(166, 24);
            this.btnStatusGet.TabIndex = 4;
            this.btnStatusGet.Text = "Check status";
            this.btnStatusGet.UseVisualStyleBackColor = true;
            this.btnStatusGet.Click += new System.EventHandler(this.btnStatusGet_Click);
            // 
            // tbStatusIPAddress
            // 
            this.tbStatusIPAddress.Dock = System.Windows.Forms.DockStyle.Fill;
            this.tbStatusIPAddress.Location = new System.Drawing.Point(448, 33);
            this.tbStatusIPAddress.MaxLength = 32;
            this.tbStatusIPAddress.Name = "tbStatusIPAddress";
            this.tbStatusIPAddress.Size = new System.Drawing.Size(439, 21);
            this.tbStatusIPAddress.TabIndex = 2;
            this.tbStatusIPAddress.TextChanged += new System.EventHandler(this.tbStatusIPAddress_TextChanged);
            // 
            // lblStatusDetectorConfigured
            // 
            this.lblStatusDetectorConfigured.AutoSize = true;
            this.lblStatusDetectorConfigured.Location = new System.Drawing.Point(448, 180);
            this.lblStatusDetectorConfigured.Name = "lblStatusDetectorConfigured";
            this.lblStatusDetectorConfigured.Size = new System.Drawing.Size(174, 15);
            this.lblStatusDetectorConfigured.TabIndex = 8;
            this.lblStatusDetectorConfigured.Text = "<lblStatusDetectorConfigured>";
            // 
            // lblStatusSpectrumIndex
            // 
            this.lblStatusSpectrumIndex.AutoSize = true;
            this.lblStatusSpectrumIndex.Location = new System.Drawing.Point(448, 150);
            this.lblStatusSpectrumIndex.Name = "lblStatusSpectrumIndex";
            this.lblStatusSpectrumIndex.Size = new System.Drawing.Size(151, 15);
            this.lblStatusSpectrumIndex.TabIndex = 7;
            this.lblStatusSpectrumIndex.Text = "<lblStatusSpectrumIndex>";
            // 
            // lblStatusSessionRunning
            // 
            this.lblStatusSessionRunning.AutoSize = true;
            this.lblStatusSessionRunning.Location = new System.Drawing.Point(448, 120);
            this.lblStatusSessionRunning.Name = "lblStatusSessionRunning";
            this.lblStatusSessionRunning.Size = new System.Drawing.Size(159, 15);
            this.lblStatusSessionRunning.TabIndex = 6;
            this.lblStatusSessionRunning.Text = "<lblStatusSessionRunning>";
            // 
            // lblStatusFreeDiskSpace
            // 
            this.lblStatusFreeDiskSpace.AutoSize = true;
            this.lblStatusFreeDiskSpace.Location = new System.Drawing.Point(448, 90);
            this.lblStatusFreeDiskSpace.Name = "lblStatusFreeDiskSpace";
            this.lblStatusFreeDiskSpace.Size = new System.Drawing.Size(152, 15);
            this.lblStatusFreeDiskSpace.TabIndex = 5;
            this.lblStatusFreeDiskSpace.Text = "<lblStatusFreeDiskSpace>";
            // 
            // panel7
            // 
            this.panel7.Controls.Add(this.btnStatusCancel);
            this.panel7.Controls.Add(this.btnStatusNext);
            this.panel7.Dock = System.Windows.Forms.DockStyle.Bottom;
            this.panel7.Location = new System.Drawing.Point(3, 583);
            this.panel7.Name = "panel7";
            this.panel7.Size = new System.Drawing.Size(1336, 30);
            this.panel7.TabIndex = 0;
            // 
            // btnStatusCancel
            // 
            this.btnStatusCancel.Dock = System.Windows.Forms.DockStyle.Right;
            this.btnStatusCancel.Font = new System.Drawing.Font("Microsoft Sans Serif", 9F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnStatusCancel.Location = new System.Drawing.Point(1076, 0);
            this.btnStatusCancel.Name = "btnStatusCancel";
            this.btnStatusCancel.Size = new System.Drawing.Size(130, 30);
            this.btnStatusCancel.TabIndex = 1;
            this.btnStatusCancel.Text = "Cancel";
            this.btnStatusCancel.UseVisualStyleBackColor = true;
            this.btnStatusCancel.Click += new System.EventHandler(this.btnStatusCancel_Click);
            // 
            // btnStatusNext
            // 
            this.btnStatusNext.Dock = System.Windows.Forms.DockStyle.Right;
            this.btnStatusNext.Font = new System.Drawing.Font("Microsoft Sans Serif", 9F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnStatusNext.Location = new System.Drawing.Point(1206, 0);
            this.btnStatusNext.Name = "btnStatusNext";
            this.btnStatusNext.Size = new System.Drawing.Size(130, 30);
            this.btnStatusNext.TabIndex = 0;
            this.btnStatusNext.Text = "Next";
            this.btnStatusNext.UseVisualStyleBackColor = true;
            this.btnStatusNext.Click += new System.EventHandler(this.btnStatusNext_Click);
            // 
            // pagePreferences
            // 
            this.pagePreferences.Controls.Add(this.tableLayoutPanel1);
            this.pagePreferences.Controls.Add(this.panel10);
            this.pagePreferences.Location = new System.Drawing.Point(4, 27);
            this.pagePreferences.Name = "pagePreferences";
            this.pagePreferences.Padding = new System.Windows.Forms.Padding(3);
            this.pagePreferences.Size = new System.Drawing.Size(1342, 616);
            this.pagePreferences.TabIndex = 8;
            this.pagePreferences.Text = "Preferences";
            this.pagePreferences.UseVisualStyleBackColor = true;
            // 
            // tableLayoutPanel1
            // 
            this.tableLayoutPanel1.ColumnCount = 2;
            this.tableLayoutPanel1.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 50F));
            this.tableLayoutPanel1.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 50F));
            this.tableLayoutPanel1.Controls.Add(this.panel11, 0, 1);
            this.tableLayoutPanel1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.tableLayoutPanel1.Location = new System.Drawing.Point(3, 3);
            this.tableLayoutPanel1.Name = "tableLayoutPanel1";
            this.tableLayoutPanel1.RowCount = 6;
            this.tableLayoutPanel1.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 28F));
            this.tableLayoutPanel1.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 28F));
            this.tableLayoutPanel1.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 28F));
            this.tableLayoutPanel1.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 28F));
            this.tableLayoutPanel1.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 28F));
            this.tableLayoutPanel1.RowStyles.Add(new System.Windows.Forms.RowStyle());
            this.tableLayoutPanel1.Size = new System.Drawing.Size(1336, 580);
            this.tableLayoutPanel1.TabIndex = 1;
            // 
            // panel11
            // 
            this.tableLayoutPanel1.SetColumnSpan(this.panel11, 2);
            this.panel11.Controls.Add(this.tbPreferencesSessionDir);
            this.panel11.Controls.Add(this.btnPreferencesSetSessionDir);
            this.panel11.Controls.Add(this.label5);
            this.panel11.Dock = System.Windows.Forms.DockStyle.Fill;
            this.panel11.Location = new System.Drawing.Point(3, 31);
            this.panel11.Name = "panel11";
            this.panel11.Size = new System.Drawing.Size(1330, 22);
            this.panel11.TabIndex = 0;
            // 
            // tbPreferencesSessionDir
            // 
            this.tbPreferencesSessionDir.Dock = System.Windows.Forms.DockStyle.Fill;
            this.tbPreferencesSessionDir.Location = new System.Drawing.Point(100, 0);
            this.tbPreferencesSessionDir.Name = "tbPreferencesSessionDir";
            this.tbPreferencesSessionDir.ReadOnly = true;
            this.tbPreferencesSessionDir.Size = new System.Drawing.Size(1100, 21);
            this.tbPreferencesSessionDir.TabIndex = 2;
            // 
            // btnPreferencesSetSessionDir
            // 
            this.btnPreferencesSetSessionDir.Dock = System.Windows.Forms.DockStyle.Right;
            this.btnPreferencesSetSessionDir.Font = new System.Drawing.Font("Microsoft Sans Serif", 9F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnPreferencesSetSessionDir.Location = new System.Drawing.Point(1200, 0);
            this.btnPreferencesSetSessionDir.Name = "btnPreferencesSetSessionDir";
            this.btnPreferencesSetSessionDir.Size = new System.Drawing.Size(130, 22);
            this.btnPreferencesSetSessionDir.TabIndex = 1;
            this.btnPreferencesSetSessionDir.Text = "...";
            this.btnPreferencesSetSessionDir.UseVisualStyleBackColor = true;
            this.btnPreferencesSetSessionDir.Click += new System.EventHandler(this.btnSetSessionDir_Click);
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.Dock = System.Windows.Forms.DockStyle.Left;
            this.label5.Location = new System.Drawing.Point(0, 0);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(100, 15);
            this.label5.TabIndex = 0;
            this.label5.Text = "Session directory";
            // 
            // panel10
            // 
            this.panel10.Controls.Add(this.btnPreferencesCancel);
            this.panel10.Controls.Add(this.btnPreferencesSave);
            this.panel10.Dock = System.Windows.Forms.DockStyle.Bottom;
            this.panel10.Location = new System.Drawing.Point(3, 583);
            this.panel10.Name = "panel10";
            this.panel10.Size = new System.Drawing.Size(1336, 30);
            this.panel10.TabIndex = 0;
            // 
            // btnPreferencesCancel
            // 
            this.btnPreferencesCancel.Dock = System.Windows.Forms.DockStyle.Right;
            this.btnPreferencesCancel.Font = new System.Drawing.Font("Microsoft Sans Serif", 9F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnPreferencesCancel.Location = new System.Drawing.Point(1076, 0);
            this.btnPreferencesCancel.Name = "btnPreferencesCancel";
            this.btnPreferencesCancel.Size = new System.Drawing.Size(130, 30);
            this.btnPreferencesCancel.TabIndex = 1;
            this.btnPreferencesCancel.Text = "Cancel";
            this.btnPreferencesCancel.UseVisualStyleBackColor = true;
            this.btnPreferencesCancel.Click += new System.EventHandler(this.btnPreferencesCancel_Click);
            // 
            // btnPreferencesSave
            // 
            this.btnPreferencesSave.Dock = System.Windows.Forms.DockStyle.Right;
            this.btnPreferencesSave.Font = new System.Drawing.Font("Microsoft Sans Serif", 9F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnPreferencesSave.Location = new System.Drawing.Point(1206, 0);
            this.btnPreferencesSave.Name = "btnPreferencesSave";
            this.btnPreferencesSave.Size = new System.Drawing.Size(130, 30);
            this.btnPreferencesSave.TabIndex = 0;
            this.btnPreferencesSave.Text = "Save";
            this.btnPreferencesSave.UseVisualStyleBackColor = true;
            this.btnPreferencesSave.Click += new System.EventHandler(this.btnPreferencesSave_Click);
            // 
            // openSessionDialog
            // 
            this.openSessionDialog.DefaultExt = "db";
            // 
            // menuItemLoadBackgroundSelection
            // 
            this.menuItemLoadBackgroundSelection.Name = "menuItemLoadBackgroundSelection";
            this.menuItemLoadBackgroundSelection.Size = new System.Drawing.Size(217, 22);
            this.menuItemLoadBackgroundSelection.Text = "Load background selection";
            this.menuItemLoadBackgroundSelection.Click += new System.EventHandler(this.menuItemLoadBackgroundSelection_Click);
            // 
            // menuItemSetAsBackground
            // 
            this.menuItemSetAsBackground.Name = "menuItemSetAsBackground";
            this.menuItemSetAsBackground.Size = new System.Drawing.Size(171, 22);
            this.menuItemSetAsBackground.Text = "Set as background";
            this.menuItemSetAsBackground.Click += new System.EventHandler(this.menuItemLoadBackgroundSelection_Click);
            // 
            // FormMain
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(7F, 15F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.SystemColors.ButtonFace;
            this.ClientSize = new System.Drawing.Size(1350, 733);
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
            this.Text = "Gamma Analyzer";
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
            this.layoutConfigureDetector.ResumeLayout(false);
            this.layoutConfigureDetector.PerformLayout();
            this.panel16.ResumeLayout(false);
            this.panel16.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.tbarSetupVoltage)).EndInit();
            this.panel5.ResumeLayout(false);
            this.panel13.ResumeLayout(false);
            this.panel13.PerformLayout();
            this.panel17.ResumeLayout(false);
            this.panel17.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.tbarSetupFineGain)).EndInit();
            this.panel3.ResumeLayout(false);
            this.panel3.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.tbarSetupLLD)).EndInit();
            this.panel18.ResumeLayout(false);
            this.panel18.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.tbarSetupULD)).EndInit();
            this.panel15.ResumeLayout(false);
            this.panel19.ResumeLayout(false);
            this.panel19.PerformLayout();
            this.panel14.ResumeLayout(false);
            this.panel12.ResumeLayout(false);
            this.panel12.PerformLayout();
            this.panelSetupSession.ResumeLayout(false);
            this.panelSetupSession.PerformLayout();
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
            this.contextMenuNuclides.ResumeLayout(false);
            this.panel8.ResumeLayout(false);
            this.panel8.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.tbarNuclides)).EndInit();
            this.tableLayoutPanel2.ResumeLayout(false);
            this.tableLayoutPanel2.PerformLayout();
            this.toolsSession.ResumeLayout(false);
            this.toolsSession.PerformLayout();
            this.panel1.ResumeLayout(false);
            this.panel1.PerformLayout();
            this.panelSessionsControl.ResumeLayout(false);
            this.pageDetectors.ResumeLayout(false);
            this.tableLayoutPref.ResumeLayout(false);
            this.tableLayoutPref.PerformLayout();
            this.panel2.ResumeLayout(false);
            this.panel6.ResumeLayout(false);
            this.pageNew.ResumeLayout(false);
            this.tableNew.ResumeLayout(false);
            this.tableNew.PerformLayout();
            this.panel9.ResumeLayout(false);
            this.pageStatus.ResumeLayout(false);
            this.tableStatus.ResumeLayout(false);
            this.tableStatus.PerformLayout();
            this.panel7.ResumeLayout(false);
            this.pagePreferences.ResumeLayout(false);
            this.tableLayoutPanel1.ResumeLayout(false);
            this.panel11.ResumeLayout(false);
            this.panel11.PerformLayout();
            this.panel10.ResumeLayout(false);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.MenuStrip menu;
        private System.Windows.Forms.StatusStrip status;
        private System.Windows.Forms.ToolStrip tools;
        private System.Windows.Forms.ToolStripMenuItem menuItemFile;
        private System.Windows.Forms.ToolStripMenuItem menuItemExit;
        private System.Windows.Forms.ToolStripStatusLabel statusLabel;
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
        private System.Windows.Forms.ToolStripMenuItem menuItemShowLog;
        private System.Windows.Forms.ToolStripMenuItem menuItemExport;
        private System.Windows.Forms.ToolStripMenuItem menuItemSaveAsCHN;
        private System.Windows.Forms.ToolStripMenuItem menuItemSaveAsKMZ;
        private System.Windows.Forms.TabControl tabs;
        private System.Windows.Forms.TabPage pageSetup;
        private System.Windows.Forms.Panel panelSetupSession;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Label label6;
        private System.Windows.Forms.ComboBox cboxSetupChannels;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.Label label7;
        private System.Windows.Forms.Label label8;
        private System.Windows.Forms.Label label9;
        private System.Windows.Forms.Label label10;
        private System.Windows.Forms.ComboBox cboxSetupCoarseGain;
        private System.Windows.Forms.TrackBar tbarSetupFineGain;
        private System.Windows.Forms.Label lblSetupFineGain;
        private System.Windows.Forms.Button btnSetupSetParams;
        private System.Windows.Forms.TrackBar tbarSetupLLD;
        private System.Windows.Forms.Label lblSetupLLD;
        private System.Windows.Forms.TrackBar tbarSetupULD;
        private System.Windows.Forms.Label lblSetupULD;
        private System.Windows.Forms.TabPage pageMenu;
        private System.Windows.Forms.FlowLayoutPanel flowLayoutPanel1;
        private System.Windows.Forms.Button btnMenuDetectors;
        private System.Windows.Forms.Button btnMenuSessions;
        private System.Windows.Forms.TabPage pageSessions;
        private System.Windows.Forms.SplitContainer splitContainer2;
        private System.Windows.Forms.ListBox lbSession;
        private ZedGraph.ZedGraphControl graphSession;
        private System.Windows.Forms.Panel panel1;
        private System.Windows.Forms.Label lblSessionEnergy;
        private System.Windows.Forms.Label lblSessionChannel;
        private System.Windows.Forms.TableLayoutPanel tableLayoutPanel2;
        private System.Windows.Forms.Label lblLatitude;
        private System.Windows.Forms.Label lblLongitude;
        private System.Windows.Forms.Label lblAltitude;
        private System.Windows.Forms.Label lblMaxCount;
        private System.Windows.Forms.Label lblMinCount;
        private System.Windows.Forms.Label lblTotalCount;
        private System.Windows.Forms.Label lblGpsTime;
        private System.Windows.Forms.Label lblDoserate;
        private System.Windows.Forms.Label lblSession;
        private System.Windows.Forms.Label lblBackground;
        private System.Windows.Forms.Label lblComment;
        private System.Windows.Forms.Label lblLivetime;
        private System.Windows.Forms.Label lblRealtime;
        private System.Windows.Forms.Label lblIndex;
        private System.Windows.Forms.Label lblSessionDetector;
        private System.Windows.Forms.TabPage pageDetectors;
        private System.Windows.Forms.TableLayoutPanel tableLayoutPref;
        private System.Windows.Forms.ListView lvDetectors;
        private System.Windows.Forms.ColumnHeader colSerialnumber;
        private System.Windows.Forms.ColumnHeader colType;
        private System.Windows.Forms.ColumnHeader colNumChannels;
        private System.Windows.Forms.ColumnHeader colHV;
        private System.Windows.Forms.ColumnHeader colCoarseGain;
        private System.Windows.Forms.ColumnHeader colFineGain;
        private System.Windows.Forms.ColumnHeader colLivetime;
        private System.Windows.Forms.ColumnHeader colLLD;
        private System.Windows.Forms.ColumnHeader colULD;
        private System.Windows.Forms.Label label18;
        private System.Windows.Forms.Button btnAddDetector;
        private System.Windows.Forms.ToolStripMenuItem menuItemStartNewSession;
        private System.Windows.Forms.ToolStripMenuItem menuItemStopSession;
        private System.Windows.Forms.ToolStripSeparator toolStripSeparator3;
        private System.Windows.Forms.ToolStripMenuItem menuItemROITable;
        private System.Windows.Forms.Panel panelNuclides;
        private System.Windows.Forms.ListBox lbNuclides;
        private System.Windows.Forms.TrackBar tbarNuclides;
        private System.Windows.Forms.Label label19;
        private System.Windows.Forms.TableLayoutPanel layoutConfigureDetector;
        private System.Windows.Forms.TrackBar tbarSetupVoltage;
        private System.Windows.Forms.Label lblSetupVoltage;
        private ZedGraph.ZedGraphControl graphSetup;
        private System.Windows.Forms.Label lblSetupEnergy;
        private System.Windows.Forms.Label lblSetupChannel;
        private System.Windows.Forms.SplitContainer splitContainerSessionLeft;
        private System.Windows.Forms.Label label12;
        private System.Windows.Forms.ContextMenuStrip contextMenuSetup;
        private System.Windows.Forms.ToolStripMenuItem menuItemResetCoefficients;
        private System.Windows.Forms.ToolStripMenuItem menuItemStoreCoefficients;
        private System.Windows.Forms.Panel panelSetupGraph;
        private System.Windows.Forms.ToolStrip toolsSetup;
        private System.Windows.Forms.ToolStripButton btnSetupStartTest;
        private System.Windows.Forms.ToolStripButton btnSetupStopTest;
        private System.Windows.Forms.ToolStripStatusLabel lblLogMessages;
        private System.Windows.Forms.ToolStripMenuItem menuItemSaveAsCSV;
        private System.Windows.Forms.ToolStripButton btnSetupResetCoefficients;
        private System.Windows.Forms.ToolStripButton btnSetupStoreCoefficients;
        private System.Windows.Forms.ToolStrip toolsSession;
        private System.Windows.Forms.ToolStripDropDownButton btnOptions;
        private System.Windows.Forms.ToolStripMenuItem menuItemSubtractBackground;
        private System.Windows.Forms.Panel panel2;
        private System.Windows.Forms.Button btnEditDetector;
        private System.Windows.Forms.Panel panel8;
        private System.Windows.Forms.Label lblSessionETOL;
        private System.Windows.Forms.ContextMenuStrip contextMenuNuclides;
        private System.Windows.Forms.ToolStripMenuItem menuItemNuclidesUnselect;
        private System.Windows.Forms.ToolStripMenuItem menuItemConvertToLocalTime;
        private System.Windows.Forms.Panel panelSessionsControl;
        private System.Windows.Forms.Button btnSessionsBrowse;
        private System.Windows.Forms.Button btnSessionsSync;
        private System.Windows.Forms.Button btnSessionsStop;
        private System.Windows.Forms.Button btnSessionsNew;
        private System.Windows.Forms.Label lblSessionsDatabase;
        private System.Windows.Forms.ToolStripMenuItem menuItemSyncCurrentSession;
        private System.Windows.Forms.TabPage pageNew;
        private System.Windows.Forms.TableLayoutPanel tableNew;
        private System.Windows.Forms.Panel panel9;
        private System.Windows.Forms.Button btnNewCancel;
        private System.Windows.Forms.Button btnNewStart;
        private System.Windows.Forms.TextBox tbNewLivetime;
        private System.Windows.Forms.Label label16;
        private System.Windows.Forms.Button btnSetupClose;
        private System.Windows.Forms.Panel panel14;
        private System.Windows.Forms.Panel panel15;
        private System.Windows.Forms.Panel panel16;
        private System.Windows.Forms.Panel panel5;
        private System.Windows.Forms.Panel panel17;
        private System.Windows.Forms.Panel panel3;
        private System.Windows.Forms.Panel panel18;
        private System.Windows.Forms.ToolStripButton btnLayout3;
        private System.Windows.Forms.ToolStripButton btnLayout2;
        private System.Windows.Forms.ToolStripButton btnLayout1;
        private System.Windows.Forms.ComboBox cboxSetupDetector;
        private System.Windows.Forms.Button btnMenuCalibration;
        private System.Windows.Forms.Button btnSessionsClose;
        private System.Windows.Forms.Panel panel6;
        private System.Windows.Forms.Button btnPreferencesClose;
        private System.Windows.Forms.TabPage pageStatus;
        private System.Windows.Forms.Panel panel7;
        private System.Windows.Forms.Button btnStatusNext;
        private System.Windows.Forms.TextBox tbStatusIPAddress;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.Button btnStatusGet;
        private System.Windows.Forms.Button btnStatusCancel;
        private System.Windows.Forms.Button btnSetupCancel;
        private System.Windows.Forms.TabPage pagePreferences;
        private System.Windows.Forms.Panel panel10;
        private System.Windows.Forms.Button btnPreferencesSave;
        private System.Windows.Forms.Button btnPreferencesCancel;
        private System.Windows.Forms.TableLayoutPanel tableLayoutPanel1;
        private System.Windows.Forms.Panel panel11;
        private System.Windows.Forms.Label label5;
        private System.Windows.Forms.TextBox tbPreferencesSessionDir;
        private System.Windows.Forms.Button btnPreferencesSetSessionDir;
        private System.Windows.Forms.Button btnMenuPreferences;
        private System.Windows.Forms.Label lblSetupIPAddress;
        private System.Windows.Forms.TextBox tbNewComment;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.OpenFileDialog openSessionDialog;
        private System.Windows.Forms.TableLayoutPanel tableStatus;
        private System.Windows.Forms.Label lblStatusFreeDiskSpace;
        private System.Windows.Forms.Label lblStatusSessionRunning;
        private System.Windows.Forms.Label lblStatusSpectrumIndex;
        private System.Windows.Forms.Label lblStatusDetectorConfigured;
        private System.Windows.Forms.Panel panel12;
        private System.Windows.Forms.Panel panel13;
        private System.Windows.Forms.Panel panel19;
        private System.Windows.Forms.ToolStripMenuItem menuItemChangeIPAddress;
        private System.Windows.Forms.ColumnHeader colPluginName;
        private System.Windows.Forms.ColumnHeader colGEScript;
        private System.Windows.Forms.ColumnHeader colMinHV;
        private System.Windows.Forms.ColumnHeader colMaxHV;
        private System.Windows.Forms.ColumnHeader colMaxNumChannels;
        private System.Windows.Forms.ToolStripMenuItem menuItemLoadBackgroundSelection;
        private System.Windows.Forms.ToolStripMenuItem menuItemSetAsBackground;
    }
}

