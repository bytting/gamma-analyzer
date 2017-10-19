namespace crash
{
    partial class FormWaterfallLive
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(FormWaterfallLive));
            this.tools = new System.Windows.Forms.ToolStrip();
            this.btnShow = new System.Windows.Forms.ToolStripDropDownButton();
            this.btnROI = new System.Windows.Forms.ToolStripMenuItem();
            this.menuItemUseLogarithmicScale = new System.Windows.Forms.ToolStripMenuItem();
            this.btnSubtractBackground = new System.Windows.Forms.ToolStripMenuItem();
            this.pane = new System.Windows.Forms.Panel();
            this.paneMenu = new System.Windows.Forms.ContextMenuStrip(this.components);
            this.menuItemUnselect = new System.Windows.Forms.ToolStripMenuItem();
            this.tbColorCeil = new System.Windows.Forms.TrackBar();
            this.panel2 = new System.Windows.Forms.Panel();
            this.buttonDownAll = new System.Windows.Forms.ToolStripButton();
            this.buttonDown = new System.Windows.Forms.ToolStripButton();
            this.buttonUp = new System.Windows.Forms.ToolStripButton();
            this.buttonUpAll = new System.Windows.Forms.ToolStripButton();
            this.buttonRightAll = new System.Windows.Forms.ToolStripButton();
            this.buttonRight = new System.Windows.Forms.ToolStripButton();
            this.buttonLeft = new System.Windows.Forms.ToolStripButton();
            this.buttonLeftAll = new System.Windows.Forms.ToolStripButton();
            this.labelColorCeil = new System.Windows.Forms.ToolStripLabel();
            this.labelSpectrum = new System.Windows.Forms.ToolStripLabel();
            this.labelChannel = new System.Windows.Forms.ToolStripLabel();
            this.labelEnergy = new System.Windows.Forms.ToolStripLabel();
            this.tools.SuspendLayout();
            this.paneMenu.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.tbColorCeil)).BeginInit();
            this.panel2.SuspendLayout();
            this.SuspendLayout();
            // 
            // tools
            // 
            this.tools.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.btnShow,
            this.buttonDownAll,
            this.buttonDown,
            this.buttonUp,
            this.buttonUpAll,
            this.buttonRightAll,
            this.buttonRight,
            this.buttonLeft,
            this.buttonLeftAll,
            this.labelColorCeil,
            this.labelSpectrum,
            this.labelChannel,
            this.labelEnergy});
            this.tools.Location = new System.Drawing.Point(0, 0);
            this.tools.Name = "tools";
            this.tools.Size = new System.Drawing.Size(844, 25);
            this.tools.TabIndex = 0;
            this.tools.Text = "toolStrip1";
            // 
            // btnShow
            // 
            this.btnShow.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.btnROI,
            this.menuItemUseLogarithmicScale,
            this.btnSubtractBackground});
            this.btnShow.Image = global::crash.Properties.Resources.options1_16;
            this.btnShow.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.btnShow.Name = "btnShow";
            this.btnShow.Size = new System.Drawing.Size(78, 22);
            this.btnShow.Text = "&Options";
            // 
            // btnROI
            // 
            this.btnROI.Checked = true;
            this.btnROI.CheckOnClick = true;
            this.btnROI.CheckState = System.Windows.Forms.CheckState.Checked;
            this.btnROI.Name = "btnROI";
            this.btnROI.Size = new System.Drawing.Size(216, 22);
            this.btnROI.Text = "Show &ROI lines";
            this.btnROI.CheckedChanged += new System.EventHandler(this.btnROI_CheckedChanged);
            // 
            // menuItemUseLogarithmicScale
            // 
            this.menuItemUseLogarithmicScale.Checked = true;
            this.menuItemUseLogarithmicScale.CheckOnClick = true;
            this.menuItemUseLogarithmicScale.CheckState = System.Windows.Forms.CheckState.Checked;
            this.menuItemUseLogarithmicScale.Name = "menuItemUseLogarithmicScale";
            this.menuItemUseLogarithmicScale.Size = new System.Drawing.Size(216, 22);
            this.menuItemUseLogarithmicScale.Text = "Use logarithmic color scale";
            this.menuItemUseLogarithmicScale.CheckedChanged += new System.EventHandler(this.menuItemUseLogarithmicScale_CheckedChanged);
            // 
            // btnSubtractBackground
            // 
            this.btnSubtractBackground.CheckOnClick = true;
            this.btnSubtractBackground.Name = "btnSubtractBackground";
            this.btnSubtractBackground.Size = new System.Drawing.Size(216, 22);
            this.btnSubtractBackground.Text = "Subtract &background";
            this.btnSubtractBackground.CheckedChanged += new System.EventHandler(this.btnSubtractBackground_CheckedChanged);
            // 
            // pane
            // 
            this.pane.BackColor = System.Drawing.Color.Blue;
            this.pane.ContextMenuStrip = this.paneMenu;
            this.pane.Cursor = System.Windows.Forms.Cursors.Cross;
            this.pane.Dock = System.Windows.Forms.DockStyle.Fill;
            this.pane.Location = new System.Drawing.Point(0, 25);
            this.pane.Name = "pane";
            this.pane.Size = new System.Drawing.Size(819, 309);
            this.pane.TabIndex = 2;
            this.pane.Paint += new System.Windows.Forms.PaintEventHandler(this.pane_Paint);
            this.pane.MouseDown += new System.Windows.Forms.MouseEventHandler(this.pane_MouseDown);
            this.pane.MouseMove += new System.Windows.Forms.MouseEventHandler(this.pane_MouseMove);
            this.pane.Resize += new System.EventHandler(this.pane_Resize);
            // 
            // paneMenu
            // 
            this.paneMenu.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.menuItemUnselect});
            this.paneMenu.Name = "paneMenu";
            this.paneMenu.Size = new System.Drawing.Size(120, 26);
            // 
            // menuItemUnselect
            // 
            this.menuItemUnselect.Name = "menuItemUnselect";
            this.menuItemUnselect.Size = new System.Drawing.Size(119, 22);
            this.menuItemUnselect.Text = "&Unselect";
            this.menuItemUnselect.Click += new System.EventHandler(this.menuItemUnselect_Click);
            // 
            // tbColorCeil
            // 
            this.tbColorCeil.Dock = System.Windows.Forms.DockStyle.Fill;
            this.tbColorCeil.Location = new System.Drawing.Point(0, 0);
            this.tbColorCeil.Name = "tbColorCeil";
            this.tbColorCeil.Orientation = System.Windows.Forms.Orientation.Vertical;
            this.tbColorCeil.Size = new System.Drawing.Size(25, 309);
            this.tbColorCeil.TabIndex = 3;
            this.tbColorCeil.Scroll += new System.EventHandler(this.tbColorCeil_Scroll);
            this.tbColorCeil.ValueChanged += new System.EventHandler(this.tbColorCeil_ValueChanged);
            // 
            // panel2
            // 
            this.panel2.Controls.Add(this.tbColorCeil);
            this.panel2.Dock = System.Windows.Forms.DockStyle.Right;
            this.panel2.Location = new System.Drawing.Point(819, 25);
            this.panel2.Name = "panel2";
            this.panel2.Size = new System.Drawing.Size(25, 309);
            this.panel2.TabIndex = 5;
            // 
            // buttonDownAll
            // 
            this.buttonDownAll.Alignment = System.Windows.Forms.ToolStripItemAlignment.Right;
            this.buttonDownAll.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image;
            this.buttonDownAll.Image = global::crash.Properties.Resources.down_all_16;
            this.buttonDownAll.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.buttonDownAll.Name = "buttonDownAll";
            this.buttonDownAll.Size = new System.Drawing.Size(23, 22);
            this.buttonDownAll.Text = "toolStripButton1";
            this.buttonDownAll.Click += new System.EventHandler(this.btnDownAll_Click);
            // 
            // buttonDown
            // 
            this.buttonDown.Alignment = System.Windows.Forms.ToolStripItemAlignment.Right;
            this.buttonDown.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image;
            this.buttonDown.Image = global::crash.Properties.Resources.down_16;
            this.buttonDown.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.buttonDown.Name = "buttonDown";
            this.buttonDown.Size = new System.Drawing.Size(23, 22);
            this.buttonDown.Text = "toolStripButton2";
            this.buttonDown.Click += new System.EventHandler(this.btnDown_Click);
            // 
            // buttonUp
            // 
            this.buttonUp.Alignment = System.Windows.Forms.ToolStripItemAlignment.Right;
            this.buttonUp.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image;
            this.buttonUp.Image = global::crash.Properties.Resources.up_16;
            this.buttonUp.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.buttonUp.Name = "buttonUp";
            this.buttonUp.Size = new System.Drawing.Size(23, 22);
            this.buttonUp.Text = "toolStripButton3";
            this.buttonUp.Click += new System.EventHandler(this.btnUp_Click);
            // 
            // buttonUpAll
            // 
            this.buttonUpAll.Alignment = System.Windows.Forms.ToolStripItemAlignment.Right;
            this.buttonUpAll.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image;
            this.buttonUpAll.Image = global::crash.Properties.Resources.up_all_16;
            this.buttonUpAll.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.buttonUpAll.Name = "buttonUpAll";
            this.buttonUpAll.Size = new System.Drawing.Size(23, 22);
            this.buttonUpAll.Text = "toolStripButton4";
            this.buttonUpAll.Click += new System.EventHandler(this.btnUpAll_Click);
            // 
            // buttonRightAll
            // 
            this.buttonRightAll.Alignment = System.Windows.Forms.ToolStripItemAlignment.Right;
            this.buttonRightAll.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image;
            this.buttonRightAll.Image = global::crash.Properties.Resources.right_all_16;
            this.buttonRightAll.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.buttonRightAll.Name = "buttonRightAll";
            this.buttonRightAll.Size = new System.Drawing.Size(23, 22);
            this.buttonRightAll.Text = "toolStripButton5";
            this.buttonRightAll.Click += new System.EventHandler(this.btnRightAll_Click);
            // 
            // buttonRight
            // 
            this.buttonRight.Alignment = System.Windows.Forms.ToolStripItemAlignment.Right;
            this.buttonRight.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image;
            this.buttonRight.Image = global::crash.Properties.Resources.right_16;
            this.buttonRight.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.buttonRight.Name = "buttonRight";
            this.buttonRight.Size = new System.Drawing.Size(23, 22);
            this.buttonRight.Text = "toolStripButton6";
            this.buttonRight.Click += new System.EventHandler(this.btnRight_Click);
            // 
            // buttonLeft
            // 
            this.buttonLeft.Alignment = System.Windows.Forms.ToolStripItemAlignment.Right;
            this.buttonLeft.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image;
            this.buttonLeft.Image = global::crash.Properties.Resources.left_16;
            this.buttonLeft.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.buttonLeft.Name = "buttonLeft";
            this.buttonLeft.Size = new System.Drawing.Size(23, 22);
            this.buttonLeft.Text = "toolStripButton7";
            this.buttonLeft.Click += new System.EventHandler(this.btnLeft_Click);
            // 
            // buttonLeftAll
            // 
            this.buttonLeftAll.Alignment = System.Windows.Forms.ToolStripItemAlignment.Right;
            this.buttonLeftAll.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image;
            this.buttonLeftAll.Image = global::crash.Properties.Resources.left_all_16;
            this.buttonLeftAll.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.buttonLeftAll.Name = "buttonLeftAll";
            this.buttonLeftAll.Size = new System.Drawing.Size(23, 22);
            this.buttonLeftAll.Text = "toolStripButton8";
            this.buttonLeftAll.Click += new System.EventHandler(this.btnLeftAll_Click);
            // 
            // labelColorCeil
            // 
            this.labelColorCeil.Name = "labelColorCeil";
            this.labelColorCeil.Size = new System.Drawing.Size(97, 22);
            this.labelColorCeil.Text = "<labelColorCeil>";
            // 
            // labelSpectrum
            // 
            this.labelSpectrum.Name = "labelSpectrum";
            this.labelSpectrum.Size = new System.Drawing.Size(99, 22);
            this.labelSpectrum.Text = "<labelSpectrum>";
            // 
            // labelChannel
            // 
            this.labelChannel.Name = "labelChannel";
            this.labelChannel.Size = new System.Drawing.Size(92, 22);
            this.labelChannel.Text = "<labelChannel>";
            // 
            // labelEnergy
            // 
            this.labelEnergy.Name = "labelEnergy";
            this.labelEnergy.Size = new System.Drawing.Size(84, 22);
            this.labelEnergy.Text = "<labelEnergy>";
            // 
            // FormWaterfallLive
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 14F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(844, 334);
            this.ControlBox = false;
            this.Controls.Add(this.pane);
            this.Controls.Add(this.panel2);
            this.Controls.Add(this.tools);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.SizableToolWindow;
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.MinimumSize = new System.Drawing.Size(256, 128);
            this.Name = "FormWaterfallLive";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterParent;
            this.Text = "Waterfall";
            this.Load += new System.EventHandler(this.FormWaterfall_Load);
            this.ResizeBegin += new System.EventHandler(this.FormWaterfallLive_ResizeBegin);
            this.ResizeEnd += new System.EventHandler(this.FormWaterfallLive_ResizeEnd);
            this.tools.ResumeLayout(false);
            this.tools.PerformLayout();
            this.paneMenu.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.tbColorCeil)).EndInit();
            this.panel2.ResumeLayout(false);
            this.panel2.PerformLayout();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.ToolStrip tools;
        private System.Windows.Forms.Panel pane;
        private System.Windows.Forms.TrackBar tbColorCeil;
        private System.Windows.Forms.Panel panel2;
        private System.Windows.Forms.ToolStripDropDownButton btnShow;
        private System.Windows.Forms.ToolStripMenuItem btnROI;
        private System.Windows.Forms.ContextMenuStrip paneMenu;
        private System.Windows.Forms.ToolStripMenuItem menuItemUnselect;
        private System.Windows.Forms.ToolStripMenuItem btnSubtractBackground;
        private System.Windows.Forms.ToolStripMenuItem menuItemUseLogarithmicScale;
        private System.Windows.Forms.ToolStripButton buttonDownAll;
        private System.Windows.Forms.ToolStripButton buttonDown;
        private System.Windows.Forms.ToolStripButton buttonUp;
        private System.Windows.Forms.ToolStripButton buttonUpAll;
        private System.Windows.Forms.ToolStripButton buttonRightAll;
        private System.Windows.Forms.ToolStripButton buttonRight;
        private System.Windows.Forms.ToolStripButton buttonLeft;
        private System.Windows.Forms.ToolStripButton buttonLeftAll;
        private System.Windows.Forms.ToolStripLabel labelColorCeil;
        private System.Windows.Forms.ToolStripLabel labelSpectrum;
        private System.Windows.Forms.ToolStripLabel labelChannel;
        private System.Windows.Forms.ToolStripLabel labelEnergy;
    }
}