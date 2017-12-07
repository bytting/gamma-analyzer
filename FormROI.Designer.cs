namespace crash
{
    partial class FormROI
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(FormROI));
            this.pane = new System.Windows.Forms.Panel();
            this.paneMenu = new System.Windows.Forms.ContextMenuStrip(this.components);
            this.menuItemUnselect = new System.Windows.Forms.ToolStripMenuItem();
            this.tools = new System.Windows.Forms.ToolStrip();
            this.btnOptions = new System.Windows.Forms.ToolStripDropDownButton();
            this.btnSubtractBackground = new System.Windows.Forms.ToolStripMenuItem();
            this.buttonRightAll = new System.Windows.Forms.ToolStripButton();
            this.buttonRight = new System.Windows.Forms.ToolStripButton();
            this.buttonLeft = new System.Windows.Forms.ToolStripButton();
            this.buttonLeftAll = new System.Windows.Forms.ToolStripButton();
            this.labelScaling = new System.Windows.Forms.ToolStripLabel();
            this.labelSpectrum = new System.Windows.Forms.ToolStripLabel();
            this.paneMenu.SuspendLayout();
            this.tools.SuspendLayout();
            this.SuspendLayout();
            // 
            // pane
            // 
            this.pane.BackColor = System.Drawing.SystemColors.ButtonFace;
            this.pane.ContextMenuStrip = this.paneMenu;
            this.pane.Cursor = System.Windows.Forms.Cursors.Cross;
            this.pane.Dock = System.Windows.Forms.DockStyle.Fill;
            this.pane.Location = new System.Drawing.Point(0, 25);
            this.pane.Name = "pane";
            this.pane.Size = new System.Drawing.Size(656, 305);
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
            // tools
            // 
            this.tools.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.btnOptions,
            this.buttonRightAll,
            this.buttonRight,
            this.buttonLeft,
            this.buttonLeftAll,
            this.labelScaling,
            this.labelSpectrum});
            this.tools.Location = new System.Drawing.Point(0, 0);
            this.tools.Name = "tools";
            this.tools.Size = new System.Drawing.Size(656, 25);
            this.tools.TabIndex = 5;
            this.tools.Text = "toolStrip1";
            // 
            // btnOptions
            // 
            this.btnOptions.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.btnSubtractBackground});
            this.btnOptions.Image = global::crash.Properties.Resources.options1_16;
            this.btnOptions.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.btnOptions.Name = "btnOptions";
            this.btnOptions.Size = new System.Drawing.Size(78, 22);
            this.btnOptions.Text = "&Options";
            // 
            // btnSubtractBackground
            // 
            this.btnSubtractBackground.CheckOnClick = true;
            this.btnSubtractBackground.Name = "btnSubtractBackground";
            this.btnSubtractBackground.Size = new System.Drawing.Size(185, 22);
            this.btnSubtractBackground.Text = "Subtract &background";
            this.btnSubtractBackground.CheckedChanged += new System.EventHandler(this.btnSubtractBackground_CheckedChanged);
            // 
            // buttonRightAll
            // 
            this.buttonRightAll.Alignment = System.Windows.Forms.ToolStripItemAlignment.Right;
            this.buttonRightAll.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image;
            this.buttonRightAll.Image = global::crash.Properties.Resources.right_all_16;
            this.buttonRightAll.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.buttonRightAll.Name = "buttonRightAll";
            this.buttonRightAll.Size = new System.Drawing.Size(23, 22);
            this.buttonRightAll.Text = "Right All";
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
            this.buttonRight.Text = "Right";
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
            this.buttonLeft.Text = "Left";
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
            this.buttonLeftAll.Text = "Left All";
            this.buttonLeftAll.Click += new System.EventHandler(this.btnLeftAll_Click);
            // 
            // labelScaling
            // 
            this.labelScaling.Name = "labelScaling";
            this.labelScaling.Size = new System.Drawing.Size(86, 22);
            this.labelScaling.Text = "<labelScaling>";
            // 
            // labelSpectrum
            // 
            this.labelSpectrum.Name = "labelSpectrum";
            this.labelSpectrum.Size = new System.Drawing.Size(99, 22);
            this.labelSpectrum.Text = "<labelSpectrum>";
            // 
            // FormROI
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(7F, 15F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(656, 330);
            this.ControlBox = false;
            this.Controls.Add(this.pane);
            this.Controls.Add(this.tools);
            this.Font = new System.Drawing.Font("Arial", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.SizableToolWindow;
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.MaximizeBox = false;
            this.MinimizeBox = false;
            this.MinimumSize = new System.Drawing.Size(296, 134);
            this.Name = "FormROI";
            this.StartPosition = System.Windows.Forms.FormStartPosition.Manual;
            this.Text = "ROI";
            this.Load += new System.EventHandler(this.FormROITableLive_Load);
            this.paneMenu.ResumeLayout(false);
            this.tools.ResumeLayout(false);
            this.tools.PerformLayout();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Panel pane;
        private System.Windows.Forms.ToolStrip tools;
        private System.Windows.Forms.ToolStripDropDownButton btnOptions;
        private System.Windows.Forms.ContextMenuStrip paneMenu;
        private System.Windows.Forms.ToolStripMenuItem menuItemUnselect;
        private System.Windows.Forms.ToolStripButton buttonRightAll;
        private System.Windows.Forms.ToolStripButton buttonRight;
        private System.Windows.Forms.ToolStripButton buttonLeft;
        private System.Windows.Forms.ToolStripButton buttonLeftAll;
        private System.Windows.Forms.ToolStripLabel labelScaling;
        private System.Windows.Forms.ToolStripLabel labelSpectrum;
        private System.Windows.Forms.ToolStripMenuItem btnSubtractBackground;
    }
}