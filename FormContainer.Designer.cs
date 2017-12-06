namespace crash
{
    partial class FormContainer
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(FormContainer));
            this.menu = new System.Windows.Forms.MenuStrip();
            this.menuItemFile = new System.Windows.Forms.ToolStripMenuItem();
            this.menuItemFileExit = new System.Windows.Forms.ToolStripMenuItem();
            this.menuItemView = new System.Windows.Forms.ToolStripMenuItem();
            this.menuItemViewToolbar = new System.Windows.Forms.ToolStripMenuItem();
            this.menuItemViewStatus = new System.Windows.Forms.ToolStripMenuItem();
            this.menuItemLayout = new System.Windows.Forms.ToolStripMenuItem();
            this.menuItemLayoutMenu = new System.Windows.Forms.ToolStripMenuItem();
            this.menuItemLayoutSetup = new System.Windows.Forms.ToolStripMenuItem();
            this.menuItemLayoutSession = new System.Windows.Forms.ToolStripMenuItem();
            this.toolStripSeparator1 = new System.Windows.Forms.ToolStripSeparator();
            this.menuItemLayoutCascade = new System.Windows.Forms.ToolStripMenuItem();
            this.menuItemLayoutTileVertical = new System.Windows.Forms.ToolStripMenuItem();
            this.menuItemLayoutTileHorizontal = new System.Windows.Forms.ToolStripMenuItem();
            this.menuItemLayoutArrangeIcons = new System.Windows.Forms.ToolStripMenuItem();
            this.menuItemWindow = new System.Windows.Forms.ToolStripMenuItem();
            this.menuItemWindowROITable = new System.Windows.Forms.ToolStripMenuItem();
            this.menuItemWindowShowAll = new System.Windows.Forms.ToolStripMenuItem();
            this.toolStripSeparator2 = new System.Windows.Forms.ToolStripSeparator();
            this.menuItemHelp = new System.Windows.Forms.ToolStripMenuItem();
            this.menuItemHelpAbout = new System.Windows.Forms.ToolStripMenuItem();
            this.tools = new System.Windows.Forms.ToolStrip();
            this.btnLayoutMenu = new System.Windows.Forms.ToolStripButton();
            this.btnLayoutSetup = new System.Windows.Forms.ToolStripButton();
            this.btnLayoutSession = new System.Windows.Forms.ToolStripButton();
            this.toolStripSeparator3 = new System.Windows.Forms.ToolStripSeparator();
            this.btnROITable = new System.Windows.Forms.ToolStripButton();
            this.status = new System.Windows.Forms.StatusStrip();
            this.statusLabel = new System.Windows.Forms.ToolStripStatusLabel();
            this.menu.SuspendLayout();
            this.tools.SuspendLayout();
            this.status.SuspendLayout();
            this.SuspendLayout();
            // 
            // menu
            // 
            this.menu.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.menuItemFile,
            this.menuItemView,
            this.menuItemLayout,
            this.menuItemWindow,
            this.menuItemHelp});
            this.menu.Location = new System.Drawing.Point(0, 0);
            this.menu.MdiWindowListItem = this.menuItemWindow;
            this.menu.Name = "menu";
            this.menu.Padding = new System.Windows.Forms.Padding(7, 2, 0, 2);
            this.menu.Size = new System.Drawing.Size(1159, 24);
            this.menu.TabIndex = 0;
            this.menu.Text = "menu";
            // 
            // menuItemFile
            // 
            this.menuItemFile.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.menuItemFileExit});
            this.menuItemFile.Name = "menuItemFile";
            this.menuItemFile.Size = new System.Drawing.Size(37, 20);
            this.menuItemFile.Text = "&File";
            // 
            // menuItemFileExit
            // 
            this.menuItemFileExit.Name = "menuItemFileExit";
            this.menuItemFileExit.Size = new System.Drawing.Size(92, 22);
            this.menuItemFileExit.Text = "E&xit";
            this.menuItemFileExit.Click += new System.EventHandler(this.menuItemFileExit_Click);
            // 
            // menuItemView
            // 
            this.menuItemView.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.menuItemViewToolbar,
            this.menuItemViewStatus});
            this.menuItemView.Name = "menuItemView";
            this.menuItemView.Size = new System.Drawing.Size(44, 20);
            this.menuItemView.Text = "&View";
            // 
            // menuItemViewToolbar
            // 
            this.menuItemViewToolbar.Checked = true;
            this.menuItemViewToolbar.CheckOnClick = true;
            this.menuItemViewToolbar.CheckState = System.Windows.Forms.CheckState.Checked;
            this.menuItemViewToolbar.Name = "menuItemViewToolbar";
            this.menuItemViewToolbar.Size = new System.Drawing.Size(115, 22);
            this.menuItemViewToolbar.Text = "&Toolbar";
            this.menuItemViewToolbar.Click += new System.EventHandler(this.menuItemViewToolbar_Click);
            // 
            // menuItemViewStatus
            // 
            this.menuItemViewStatus.CheckOnClick = true;
            this.menuItemViewStatus.Name = "menuItemViewStatus";
            this.menuItemViewStatus.Size = new System.Drawing.Size(115, 22);
            this.menuItemViewStatus.Text = "&Status";
            this.menuItemViewStatus.Click += new System.EventHandler(this.menuItemViewStatus_Click);
            // 
            // menuItemLayout
            // 
            this.menuItemLayout.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.menuItemLayoutMenu,
            this.menuItemLayoutSetup,
            this.menuItemLayoutSession,
            this.toolStripSeparator1,
            this.menuItemLayoutCascade,
            this.menuItemLayoutTileVertical,
            this.menuItemLayoutTileHorizontal,
            this.menuItemLayoutArrangeIcons});
            this.menuItemLayout.Name = "menuItemLayout";
            this.menuItemLayout.Size = new System.Drawing.Size(55, 20);
            this.menuItemLayout.Text = "&Layout";
            // 
            // menuItemLayoutMenu
            // 
            this.menuItemLayoutMenu.Name = "menuItemLayoutMenu";
            this.menuItemLayoutMenu.Size = new System.Drawing.Size(151, 22);
            this.menuItemLayoutMenu.Text = "Menu";
            this.menuItemLayoutMenu.Click += new System.EventHandler(this.menuItemLayoutMenu_Click);
            // 
            // menuItemLayoutSetup
            // 
            this.menuItemLayoutSetup.Name = "menuItemLayoutSetup";
            this.menuItemLayoutSetup.Size = new System.Drawing.Size(151, 22);
            this.menuItemLayoutSetup.Text = "S&etup";
            this.menuItemLayoutSetup.Click += new System.EventHandler(this.menuItemLayoutSetup_Click);
            // 
            // menuItemLayoutSession
            // 
            this.menuItemLayoutSession.Name = "menuItemLayoutSession";
            this.menuItemLayoutSession.Size = new System.Drawing.Size(151, 22);
            this.menuItemLayoutSession.Text = "&Session";
            this.menuItemLayoutSession.Click += new System.EventHandler(this.menuItemLayoutSession_Click);
            // 
            // toolStripSeparator1
            // 
            this.toolStripSeparator1.Name = "toolStripSeparator1";
            this.toolStripSeparator1.Size = new System.Drawing.Size(148, 6);
            // 
            // menuItemLayoutCascade
            // 
            this.menuItemLayoutCascade.Name = "menuItemLayoutCascade";
            this.menuItemLayoutCascade.Size = new System.Drawing.Size(151, 22);
            this.menuItemLayoutCascade.Text = "&Cascade";
            this.menuItemLayoutCascade.Click += new System.EventHandler(this.menuItemLayoutCascade_Click);
            // 
            // menuItemLayoutTileVertical
            // 
            this.menuItemLayoutTileVertical.Name = "menuItemLayoutTileVertical";
            this.menuItemLayoutTileVertical.Size = new System.Drawing.Size(151, 22);
            this.menuItemLayoutTileVertical.Text = "Tile &Vertical";
            this.menuItemLayoutTileVertical.Click += new System.EventHandler(this.menuItemLayoutTileVertical_Click);
            // 
            // menuItemLayoutTileHorizontal
            // 
            this.menuItemLayoutTileHorizontal.Name = "menuItemLayoutTileHorizontal";
            this.menuItemLayoutTileHorizontal.Size = new System.Drawing.Size(151, 22);
            this.menuItemLayoutTileHorizontal.Text = "Tile &Horizontal";
            this.menuItemLayoutTileHorizontal.Click += new System.EventHandler(this.menuItemLayoutTileHorizontal_Click);
            // 
            // menuItemLayoutArrangeIcons
            // 
            this.menuItemLayoutArrangeIcons.Name = "menuItemLayoutArrangeIcons";
            this.menuItemLayoutArrangeIcons.Size = new System.Drawing.Size(151, 22);
            this.menuItemLayoutArrangeIcons.Text = "&Arrange Icons";
            this.menuItemLayoutArrangeIcons.Click += new System.EventHandler(this.menuItemLayoutArrangeIcons_Click);
            // 
            // menuItemWindow
            // 
            this.menuItemWindow.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.menuItemWindowROITable,
            this.menuItemWindowShowAll,
            this.toolStripSeparator2});
            this.menuItemWindow.Name = "menuItemWindow";
            this.menuItemWindow.Size = new System.Drawing.Size(63, 20);
            this.menuItemWindow.Text = "&Window";
            // 
            // menuItemWindowROITable
            // 
            this.menuItemWindowROITable.Name = "menuItemWindowROITable";
            this.menuItemWindowROITable.Size = new System.Drawing.Size(172, 22);
            this.menuItemWindowROITable.Text = "Show ROI &Table";
            this.menuItemWindowROITable.Click += new System.EventHandler(this.menuItemWindowROITable_Click);
            // 
            // menuItemWindowShowAll
            // 
            this.menuItemWindowShowAll.Name = "menuItemWindowShowAll";
            this.menuItemWindowShowAll.Size = new System.Drawing.Size(172, 22);
            this.menuItemWindowShowAll.Text = "Show &All Windows";
            this.menuItemWindowShowAll.Click += new System.EventHandler(this.menuItemWindowShowAll_Click);
            // 
            // toolStripSeparator2
            // 
            this.toolStripSeparator2.Name = "toolStripSeparator2";
            this.toolStripSeparator2.Size = new System.Drawing.Size(169, 6);
            // 
            // menuItemHelp
            // 
            this.menuItemHelp.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.menuItemHelpAbout});
            this.menuItemHelp.Name = "menuItemHelp";
            this.menuItemHelp.Size = new System.Drawing.Size(44, 20);
            this.menuItemHelp.Text = "&Help";
            // 
            // menuItemHelpAbout
            // 
            this.menuItemHelpAbout.Name = "menuItemHelpAbout";
            this.menuItemHelpAbout.Size = new System.Drawing.Size(107, 22);
            this.menuItemHelpAbout.Text = "&About";
            this.menuItemHelpAbout.Click += new System.EventHandler(this.menuItemHelpAbout_Click);
            // 
            // tools
            // 
            this.tools.GripStyle = System.Windows.Forms.ToolStripGripStyle.Hidden;
            this.tools.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.btnLayoutMenu,
            this.btnLayoutSetup,
            this.btnLayoutSession,
            this.toolStripSeparator3,
            this.btnROITable});
            this.tools.Location = new System.Drawing.Point(0, 24);
            this.tools.Name = "tools";
            this.tools.Size = new System.Drawing.Size(1159, 25);
            this.tools.TabIndex = 1;
            this.tools.Text = "tools";
            // 
            // btnLayoutMenu
            // 
            this.btnLayoutMenu.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image;
            this.btnLayoutMenu.Image = ((System.Drawing.Image)(resources.GetObject("btnLayoutMenu.Image")));
            this.btnLayoutMenu.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.btnLayoutMenu.Name = "btnLayoutMenu";
            this.btnLayoutMenu.Size = new System.Drawing.Size(23, 22);
            this.btnLayoutMenu.Text = "toolStripButton1";
            this.btnLayoutMenu.Visible = false;
            this.btnLayoutMenu.Click += new System.EventHandler(this.menuItemLayoutMenu_Click);
            // 
            // btnLayoutSetup
            // 
            this.btnLayoutSetup.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image;
            this.btnLayoutSetup.Image = global::crash.Properties.Resources.layout1;
            this.btnLayoutSetup.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.btnLayoutSetup.Name = "btnLayoutSetup";
            this.btnLayoutSetup.Size = new System.Drawing.Size(23, 22);
            this.btnLayoutSetup.Text = "toolStripButton1";
            this.btnLayoutSetup.Click += new System.EventHandler(this.menuItemLayoutSetup_Click);
            // 
            // btnLayoutSession
            // 
            this.btnLayoutSession.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image;
            this.btnLayoutSession.Image = global::crash.Properties.Resources.layout2;
            this.btnLayoutSession.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.btnLayoutSession.Name = "btnLayoutSession";
            this.btnLayoutSession.Size = new System.Drawing.Size(23, 22);
            this.btnLayoutSession.Text = "toolStripButton1";
            this.btnLayoutSession.Click += new System.EventHandler(this.menuItemLayoutSession_Click);
            // 
            // toolStripSeparator3
            // 
            this.toolStripSeparator3.Name = "toolStripSeparator3";
            this.toolStripSeparator3.Size = new System.Drawing.Size(6, 25);
            // 
            // btnROITable
            // 
            this.btnROITable.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image;
            this.btnROITable.Image = global::crash.Properties.Resources.roi_table_32;
            this.btnROITable.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.btnROITable.Name = "btnROITable";
            this.btnROITable.Size = new System.Drawing.Size(23, 22);
            this.btnROITable.Text = "toolStripButton1";
            this.btnROITable.Click += new System.EventHandler(this.menuItemWindowROITable_Click);
            // 
            // status
            // 
            this.status.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.statusLabel});
            this.status.Location = new System.Drawing.Point(0, 612);
            this.status.Name = "status";
            this.status.Padding = new System.Windows.Forms.Padding(1, 0, 16, 0);
            this.status.Size = new System.Drawing.Size(1159, 22);
            this.status.TabIndex = 4;
            this.status.Text = "status";
            this.status.Visible = false;
            // 
            // statusLabel
            // 
            this.statusLabel.Name = "statusLabel";
            this.statusLabel.Size = new System.Drawing.Size(82, 17);
            this.statusLabel.Text = "<statusLabel>";
            // 
            // FormContainer
            // 
            this.AllowDrop = true;
            this.AutoScaleDimensions = new System.Drawing.SizeF(7F, 15F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.SystemColors.Control;
            this.ClientSize = new System.Drawing.Size(1159, 634);
            this.Controls.Add(this.status);
            this.Controls.Add(this.tools);
            this.Controls.Add(this.menu);
            this.Font = new System.Drawing.Font("Arial", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.IsMdiContainer = true;
            this.MainMenuStrip = this.menu;
            this.Name = "FormContainer";
            this.Text = "Gamma Analyzer";
            this.WindowState = System.Windows.Forms.FormWindowState.Maximized;
            this.FormClosing += new System.Windows.Forms.FormClosingEventHandler(this.FormContainer_FormClosing);
            this.Load += new System.EventHandler(this.FormContainer_Load);
            this.menu.ResumeLayout(false);
            this.menu.PerformLayout();
            this.tools.ResumeLayout(false);
            this.tools.PerformLayout();
            this.status.ResumeLayout(false);
            this.status.PerformLayout();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.MenuStrip menu;
        private System.Windows.Forms.ToolStrip tools;
        private System.Windows.Forms.ToolStripMenuItem menuItemFile;
        private System.Windows.Forms.ToolStripMenuItem menuItemFileExit;
        private System.Windows.Forms.StatusStrip status;
        private System.Windows.Forms.ToolStripMenuItem menuItemView;
        private System.Windows.Forms.ToolStripMenuItem menuItemViewToolbar;
        private System.Windows.Forms.ToolStripMenuItem menuItemViewStatus;
        private System.Windows.Forms.ToolStripStatusLabel statusLabel;
        private System.Windows.Forms.ToolStripMenuItem menuItemLayout;
        private System.Windows.Forms.ToolStripMenuItem menuItemHelp;
        private System.Windows.Forms.ToolStripMenuItem menuItemHelpAbout;
        private System.Windows.Forms.ToolStripMenuItem menuItemLayoutCascade;
        private System.Windows.Forms.ToolStripMenuItem menuItemLayoutTileVertical;
        private System.Windows.Forms.ToolStripMenuItem menuItemLayoutTileHorizontal;
        private System.Windows.Forms.ToolStripMenuItem menuItemLayoutArrangeIcons;
        private System.Windows.Forms.ToolStripMenuItem menuItemLayoutSession;
        private System.Windows.Forms.ToolStripSeparator toolStripSeparator1;
        private System.Windows.Forms.ToolStripMenuItem menuItemWindow;
        private System.Windows.Forms.ToolStripMenuItem menuItemWindowROITable;
        private System.Windows.Forms.ToolStripMenuItem menuItemWindowShowAll;
        private System.Windows.Forms.ToolStripSeparator toolStripSeparator2;
        private System.Windows.Forms.ToolStripMenuItem menuItemLayoutSetup;
        private System.Windows.Forms.ToolStripButton btnLayoutSetup;
        private System.Windows.Forms.ToolStripButton btnLayoutSession;
        private System.Windows.Forms.ToolStripSeparator toolStripSeparator3;
        private System.Windows.Forms.ToolStripButton btnROITable;
        private System.Windows.Forms.ToolStripMenuItem menuItemLayoutMenu;
        private System.Windows.Forms.ToolStripButton btnLayoutMenu;
    }
}