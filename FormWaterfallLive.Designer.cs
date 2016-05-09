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
            this.btnSubtractBackground = new System.Windows.Forms.ToolStripMenuItem();
            this.pane = new System.Windows.Forms.Panel();
            this.paneMenu = new System.Windows.Forms.ContextMenuStrip(this.components);
            this.menuItemUnselect = new System.Windows.Forms.ToolStripMenuItem();
            this.tbColorCeil = new System.Windows.Forms.TrackBar();
            this.panel1 = new System.Windows.Forms.Panel();
            this.lblSessionId = new System.Windows.Forms.Label();
            this.lblChannel = new System.Windows.Forms.Label();
            this.lblColorCeil = new System.Windows.Forms.Label();
            this.btnLeftAll = new System.Windows.Forms.Button();
            this.btnLeft = new System.Windows.Forms.Button();
            this.btnRight = new System.Windows.Forms.Button();
            this.btnRightAll = new System.Windows.Forms.Button();
            this.panel2 = new System.Windows.Forms.Panel();
            this.btnUpAll = new System.Windows.Forms.Button();
            this.btnUp = new System.Windows.Forms.Button();
            this.btnDown = new System.Windows.Forms.Button();
            this.btnDownAll = new System.Windows.Forms.Button();
            this.panel3 = new System.Windows.Forms.Panel();
            this.lblEnergy = new System.Windows.Forms.Label();
            this.tools.SuspendLayout();
            this.paneMenu.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.tbColorCeil)).BeginInit();
            this.panel1.SuspendLayout();
            this.panel2.SuspendLayout();
            this.SuspendLayout();
            // 
            // tools
            // 
            this.tools.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.btnShow});
            this.tools.Location = new System.Drawing.Point(0, 0);
            this.tools.Name = "tools";
            this.tools.Size = new System.Drawing.Size(853, 25);
            this.tools.TabIndex = 0;
            this.tools.Text = "toolStrip1";
            // 
            // btnShow
            // 
            this.btnShow.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.btnROI,
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
            this.btnROI.Size = new System.Drawing.Size(185, 22);
            this.btnROI.Text = "Show &ROI lines";
            this.btnROI.CheckedChanged += new System.EventHandler(this.btnROI_CheckedChanged);
            // 
            // btnSubtractBackground
            // 
            this.btnSubtractBackground.CheckOnClick = true;
            this.btnSubtractBackground.Name = "btnSubtractBackground";
            this.btnSubtractBackground.Size = new System.Drawing.Size(185, 22);
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
            this.pane.Size = new System.Drawing.Size(825, 401);
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
            this.tbColorCeil.Size = new System.Drawing.Size(28, 261);
            this.tbColorCeil.TabIndex = 3;
            this.tbColorCeil.Scroll += new System.EventHandler(this.tbColorCeil_Scroll);
            this.tbColorCeil.ValueChanged += new System.EventHandler(this.tbColorCeil_ValueChanged);
            // 
            // panel1
            // 
            this.panel1.Controls.Add(this.lblEnergy);
            this.panel1.Controls.Add(this.lblChannel);
            this.panel1.Controls.Add(this.btnLeftAll);
            this.panel1.Controls.Add(this.btnLeft);
            this.panel1.Controls.Add(this.btnRight);
            this.panel1.Controls.Add(this.btnRightAll);
            this.panel1.Controls.Add(this.lblSessionId);
            this.panel1.Controls.Add(this.lblColorCeil);
            this.panel1.Dock = System.Windows.Forms.DockStyle.Bottom;
            this.panel1.Location = new System.Drawing.Point(0, 426);
            this.panel1.Name = "panel1";
            this.panel1.Size = new System.Drawing.Size(825, 26);
            this.panel1.TabIndex = 4;
            // 
            // lblSessionId
            // 
            this.lblSessionId.AutoSize = true;
            this.lblSessionId.Dock = System.Windows.Forms.DockStyle.Left;
            this.lblSessionId.Font = new System.Drawing.Font("Microsoft Sans Serif", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblSessionId.Location = new System.Drawing.Point(84, 0);
            this.lblSessionId.Name = "lblSessionId";
            this.lblSessionId.Padding = new System.Windows.Forms.Padding(5, 2, 0, 0);
            this.lblSessionId.Size = new System.Drawing.Size(92, 17);
            this.lblSessionId.TabIndex = 6;
            this.lblSessionId.Text = "<lblSpectrum>";
            // 
            // lblChannel
            // 
            this.lblChannel.AutoSize = true;
            this.lblChannel.Dock = System.Windows.Forms.DockStyle.Left;
            this.lblChannel.Font = new System.Drawing.Font("Microsoft Sans Serif", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblChannel.Location = new System.Drawing.Point(176, 0);
            this.lblChannel.Name = "lblChannel";
            this.lblChannel.Padding = new System.Windows.Forms.Padding(5, 2, 0, 0);
            this.lblChannel.Size = new System.Drawing.Size(85, 17);
            this.lblChannel.TabIndex = 5;
            this.lblChannel.Text = "<lblChannel>";
            // 
            // lblColorCeil
            // 
            this.lblColorCeil.AutoSize = true;
            this.lblColorCeil.Dock = System.Windows.Forms.DockStyle.Left;
            this.lblColorCeil.Font = new System.Drawing.Font("Microsoft Sans Serif", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblColorCeil.Location = new System.Drawing.Point(0, 0);
            this.lblColorCeil.Name = "lblColorCeil";
            this.lblColorCeil.Padding = new System.Windows.Forms.Padding(0, 2, 0, 0);
            this.lblColorCeil.Size = new System.Drawing.Size(84, 17);
            this.lblColorCeil.TabIndex = 4;
            this.lblColorCeil.Text = "<lblColorCeil>";
            // 
            // btnLeftAll
            // 
            this.btnLeftAll.Dock = System.Windows.Forms.DockStyle.Right;
            this.btnLeftAll.FlatAppearance.BorderSize = 0;
            this.btnLeftAll.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnLeftAll.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnLeftAll.Image = global::crash.Properties.Resources.left_all_16;
            this.btnLeftAll.Location = new System.Drawing.Point(665, 0);
            this.btnLeftAll.Name = "btnLeftAll";
            this.btnLeftAll.Size = new System.Drawing.Size(40, 26);
            this.btnLeftAll.TabIndex = 0;
            this.btnLeftAll.UseVisualStyleBackColor = true;
            this.btnLeftAll.Click += new System.EventHandler(this.btnLeftAll_Click);
            // 
            // btnLeft
            // 
            this.btnLeft.Dock = System.Windows.Forms.DockStyle.Right;
            this.btnLeft.FlatAppearance.BorderSize = 0;
            this.btnLeft.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnLeft.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnLeft.Image = global::crash.Properties.Resources.left_16;
            this.btnLeft.Location = new System.Drawing.Point(705, 0);
            this.btnLeft.Name = "btnLeft";
            this.btnLeft.Size = new System.Drawing.Size(40, 26);
            this.btnLeft.TabIndex = 1;
            this.btnLeft.UseVisualStyleBackColor = true;
            this.btnLeft.Click += new System.EventHandler(this.btnLeft_Click);
            // 
            // btnRight
            // 
            this.btnRight.Dock = System.Windows.Forms.DockStyle.Right;
            this.btnRight.FlatAppearance.BorderSize = 0;
            this.btnRight.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnRight.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnRight.Image = global::crash.Properties.Resources.right_16;
            this.btnRight.Location = new System.Drawing.Point(745, 0);
            this.btnRight.Name = "btnRight";
            this.btnRight.Size = new System.Drawing.Size(40, 26);
            this.btnRight.TabIndex = 2;
            this.btnRight.UseVisualStyleBackColor = true;
            this.btnRight.Click += new System.EventHandler(this.btnRight_Click);
            // 
            // btnRightAll
            // 
            this.btnRightAll.Dock = System.Windows.Forms.DockStyle.Right;
            this.btnRightAll.FlatAppearance.BorderSize = 0;
            this.btnRightAll.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnRightAll.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnRightAll.Image = global::crash.Properties.Resources.right_all_16;
            this.btnRightAll.Location = new System.Drawing.Point(785, 0);
            this.btnRightAll.Name = "btnRightAll";
            this.btnRightAll.Size = new System.Drawing.Size(40, 26);
            this.btnRightAll.TabIndex = 3;
            this.btnRightAll.UseVisualStyleBackColor = true;
            this.btnRightAll.Click += new System.EventHandler(this.btnRightAll_Click);
            // 
            // panel2
            // 
            this.panel2.Controls.Add(this.tbColorCeil);
            this.panel2.Controls.Add(this.btnUpAll);
            this.panel2.Controls.Add(this.btnUp);
            this.panel2.Controls.Add(this.btnDown);
            this.panel2.Controls.Add(this.btnDownAll);
            this.panel2.Controls.Add(this.panel3);
            this.panel2.Dock = System.Windows.Forms.DockStyle.Right;
            this.panel2.Location = new System.Drawing.Point(825, 25);
            this.panel2.Name = "panel2";
            this.panel2.Size = new System.Drawing.Size(28, 427);
            this.panel2.TabIndex = 5;
            // 
            // btnUpAll
            // 
            this.btnUpAll.Dock = System.Windows.Forms.DockStyle.Bottom;
            this.btnUpAll.FlatAppearance.BorderSize = 0;
            this.btnUpAll.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnUpAll.Image = global::crash.Properties.Resources.up_all_16;
            this.btnUpAll.Location = new System.Drawing.Point(0, 261);
            this.btnUpAll.Name = "btnUpAll";
            this.btnUpAll.Size = new System.Drawing.Size(28, 35);
            this.btnUpAll.TabIndex = 7;
            this.btnUpAll.UseVisualStyleBackColor = true;
            this.btnUpAll.Click += new System.EventHandler(this.btnUpAll_Click);
            // 
            // btnUp
            // 
            this.btnUp.Dock = System.Windows.Forms.DockStyle.Bottom;
            this.btnUp.FlatAppearance.BorderSize = 0;
            this.btnUp.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnUp.Image = global::crash.Properties.Resources.up_16;
            this.btnUp.Location = new System.Drawing.Point(0, 296);
            this.btnUp.Name = "btnUp";
            this.btnUp.Size = new System.Drawing.Size(28, 35);
            this.btnUp.TabIndex = 6;
            this.btnUp.UseVisualStyleBackColor = true;
            this.btnUp.Click += new System.EventHandler(this.btnUp_Click);
            // 
            // btnDown
            // 
            this.btnDown.Dock = System.Windows.Forms.DockStyle.Bottom;
            this.btnDown.FlatAppearance.BorderSize = 0;
            this.btnDown.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnDown.Image = global::crash.Properties.Resources.down_16;
            this.btnDown.Location = new System.Drawing.Point(0, 331);
            this.btnDown.Name = "btnDown";
            this.btnDown.Size = new System.Drawing.Size(28, 35);
            this.btnDown.TabIndex = 5;
            this.btnDown.UseVisualStyleBackColor = true;
            this.btnDown.Click += new System.EventHandler(this.btnDown_Click);
            // 
            // btnDownAll
            // 
            this.btnDownAll.Dock = System.Windows.Forms.DockStyle.Bottom;
            this.btnDownAll.FlatAppearance.BorderSize = 0;
            this.btnDownAll.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnDownAll.Image = global::crash.Properties.Resources.down_all_16;
            this.btnDownAll.Location = new System.Drawing.Point(0, 366);
            this.btnDownAll.Name = "btnDownAll";
            this.btnDownAll.Size = new System.Drawing.Size(28, 35);
            this.btnDownAll.TabIndex = 4;
            this.btnDownAll.UseVisualStyleBackColor = true;
            this.btnDownAll.Click += new System.EventHandler(this.btnDownAll_Click);
            // 
            // panel3
            // 
            this.panel3.Dock = System.Windows.Forms.DockStyle.Bottom;
            this.panel3.Location = new System.Drawing.Point(0, 401);
            this.panel3.Name = "panel3";
            this.panel3.Size = new System.Drawing.Size(28, 26);
            this.panel3.TabIndex = 5;
            // 
            // lblEnergy
            // 
            this.lblEnergy.AutoSize = true;
            this.lblEnergy.Dock = System.Windows.Forms.DockStyle.Left;
            this.lblEnergy.Font = new System.Drawing.Font("Microsoft Sans Serif", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblEnergy.Location = new System.Drawing.Point(261, 0);
            this.lblEnergy.Name = "lblEnergy";
            this.lblEnergy.Padding = new System.Windows.Forms.Padding(5, 2, 0, 0);
            this.lblEnergy.Size = new System.Drawing.Size(77, 17);
            this.lblEnergy.TabIndex = 7;
            this.lblEnergy.Text = "<lblEnergy>";
            // 
            // FormWaterfallLive
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(853, 452);
            this.Controls.Add(this.pane);
            this.Controls.Add(this.panel1);
            this.Controls.Add(this.panel2);
            this.Controls.Add(this.tools);
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.MinimumSize = new System.Drawing.Size(500, 320);
            this.Name = "FormWaterfallLive";
            this.Text = "Crash - Waterfall Live";
            this.FormClosing += new System.Windows.Forms.FormClosingEventHandler(this.FormWaterfall_FormClosing);
            this.Load += new System.EventHandler(this.FormWaterfall_Load);
            this.ResizeBegin += new System.EventHandler(this.FormWaterfallLive_ResizeBegin);
            this.ResizeEnd += new System.EventHandler(this.FormWaterfallLive_ResizeEnd);
            this.tools.ResumeLayout(false);
            this.tools.PerformLayout();
            this.paneMenu.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.tbColorCeil)).EndInit();
            this.panel1.ResumeLayout(false);
            this.panel1.PerformLayout();
            this.panel2.ResumeLayout(false);
            this.panel2.PerformLayout();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.ToolStrip tools;
        private System.Windows.Forms.Panel pane;
        private System.Windows.Forms.TrackBar tbColorCeil;
        private System.Windows.Forms.Panel panel1;
        private System.Windows.Forms.Button btnRightAll;
        private System.Windows.Forms.Button btnRight;
        private System.Windows.Forms.Button btnLeft;
        private System.Windows.Forms.Button btnLeftAll;
        private System.Windows.Forms.Button btnUpAll;
        private System.Windows.Forms.Button btnUp;
        private System.Windows.Forms.Button btnDown;
        private System.Windows.Forms.Button btnDownAll;
        private System.Windows.Forms.Panel panel2;
        private System.Windows.Forms.Panel panel3;
        private System.Windows.Forms.Label lblChannel;
        private System.Windows.Forms.Label lblColorCeil;
        private System.Windows.Forms.ToolStripDropDownButton btnShow;
        private System.Windows.Forms.ToolStripMenuItem btnROI;
        private System.Windows.Forms.ContextMenuStrip paneMenu;
        private System.Windows.Forms.ToolStripMenuItem menuItemUnselect;
        private System.Windows.Forms.ToolStripMenuItem btnSubtractBackground;
        private System.Windows.Forms.Label lblSessionId;
        private System.Windows.Forms.Label lblEnergy;
    }
}