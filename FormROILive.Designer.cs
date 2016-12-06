namespace crash
{
    partial class FormROILive
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(FormROILive));
            this.pane = new System.Windows.Forms.Panel();
            this.paneMenu = new System.Windows.Forms.ContextMenuStrip(this.components);
            this.menuItemUnselect = new System.Windows.Forms.ToolStripMenuItem();
            this.panel3 = new System.Windows.Forms.Panel();
            this.lblSpectrum = new System.Windows.Forms.Label();
            this.lblScaling = new System.Windows.Forms.Label();
            this.btnLeftAll = new System.Windows.Forms.Button();
            this.btnLeft = new System.Windows.Forms.Button();
            this.btnRight = new System.Windows.Forms.Button();
            this.btnRightAll = new System.Windows.Forms.Button();
            this.tools = new System.Windows.Forms.ToolStrip();
            this.btnOptions = new System.Windows.Forms.ToolStripDropDownButton();
            this.paneMenu.SuspendLayout();
            this.panel3.SuspendLayout();
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
            this.pane.Size = new System.Drawing.Size(858, 423);
            this.pane.TabIndex = 2;
            this.pane.Paint += new System.Windows.Forms.PaintEventHandler(this.pane_Paint);
            this.pane.MouseClick += new System.Windows.Forms.MouseEventHandler(this.pane_MouseClick);
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
            // panel3
            // 
            this.panel3.Controls.Add(this.lblSpectrum);
            this.panel3.Controls.Add(this.lblScaling);
            this.panel3.Controls.Add(this.btnLeftAll);
            this.panel3.Controls.Add(this.btnLeft);
            this.panel3.Controls.Add(this.btnRight);
            this.panel3.Controls.Add(this.btnRightAll);
            this.panel3.Dock = System.Windows.Forms.DockStyle.Bottom;
            this.panel3.Location = new System.Drawing.Point(0, 448);
            this.panel3.Name = "panel3";
            this.panel3.Size = new System.Drawing.Size(858, 26);
            this.panel3.TabIndex = 4;
            // 
            // lblSpectrum
            // 
            this.lblSpectrum.AutoSize = true;
            this.lblSpectrum.Dock = System.Windows.Forms.DockStyle.Left;
            this.lblSpectrum.Font = new System.Drawing.Font("Microsoft Sans Serif", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblSpectrum.Location = new System.Drawing.Point(75, 0);
            this.lblSpectrum.Name = "lblSpectrum";
            this.lblSpectrum.Padding = new System.Windows.Forms.Padding(4, 2, 0, 0);
            this.lblSpectrum.Size = new System.Drawing.Size(91, 17);
            this.lblSpectrum.TabIndex = 5;
            this.lblSpectrum.Text = "<lblSpectrum>";
            // 
            // lblScaling
            // 
            this.lblScaling.AutoSize = true;
            this.lblScaling.Dock = System.Windows.Forms.DockStyle.Left;
            this.lblScaling.Font = new System.Drawing.Font("Microsoft Sans Serif", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblScaling.Location = new System.Drawing.Point(0, 0);
            this.lblScaling.Name = "lblScaling";
            this.lblScaling.Padding = new System.Windows.Forms.Padding(0, 2, 0, 0);
            this.lblScaling.Size = new System.Drawing.Size(75, 17);
            this.lblScaling.TabIndex = 4;
            this.lblScaling.Text = "<lblScaling>";
            // 
            // btnLeftAll
            // 
            this.btnLeftAll.Dock = System.Windows.Forms.DockStyle.Right;
            this.btnLeftAll.FlatAppearance.BorderSize = 0;
            this.btnLeftAll.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnLeftAll.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnLeftAll.Image = global::crash.Properties.Resources.left_all_16;
            this.btnLeftAll.Location = new System.Drawing.Point(698, 0);
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
            this.btnLeft.Location = new System.Drawing.Point(738, 0);
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
            this.btnRight.Location = new System.Drawing.Point(778, 0);
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
            this.btnRightAll.Location = new System.Drawing.Point(818, 0);
            this.btnRightAll.Name = "btnRightAll";
            this.btnRightAll.Size = new System.Drawing.Size(40, 26);
            this.btnRightAll.TabIndex = 3;
            this.btnRightAll.UseVisualStyleBackColor = true;
            this.btnRightAll.Click += new System.EventHandler(this.btnRightAll_Click);
            // 
            // tools
            // 
            this.tools.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.btnOptions});
            this.tools.Location = new System.Drawing.Point(0, 0);
            this.tools.Name = "tools";
            this.tools.Size = new System.Drawing.Size(858, 25);
            this.tools.TabIndex = 5;
            this.tools.Text = "toolStrip1";
            // 
            // btnOptions
            // 
            this.btnOptions.Image = global::crash.Properties.Resources.options1_16;
            this.btnOptions.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.btnOptions.Name = "btnOptions";
            this.btnOptions.Size = new System.Drawing.Size(78, 22);
            this.btnOptions.Text = "&Options";
            // 
            // FormROILive
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(858, 474);
            this.Controls.Add(this.pane);
            this.Controls.Add(this.panel3);
            this.Controls.Add(this.tools);
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.MinimumSize = new System.Drawing.Size(320, 320);
            this.Name = "FormROILive";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterParent;
            this.Text = "Gamma Analyzer - ROI Live";
            this.FormClosing += new System.Windows.Forms.FormClosingEventHandler(this.FormROITableLive_FormClosing);
            this.Load += new System.EventHandler(this.FormROITableLive_Load);
            this.paneMenu.ResumeLayout(false);
            this.panel3.ResumeLayout(false);
            this.panel3.PerformLayout();
            this.tools.ResumeLayout(false);
            this.tools.PerformLayout();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Panel pane;
        private System.Windows.Forms.Panel panel3;
        private System.Windows.Forms.Button btnRightAll;
        private System.Windows.Forms.Button btnRight;
        private System.Windows.Forms.Button btnLeft;
        private System.Windows.Forms.Button btnLeftAll;
        private System.Windows.Forms.ToolStrip tools;
        private System.Windows.Forms.Label lblSpectrum;
        private System.Windows.Forms.Label lblScaling;
        private System.Windows.Forms.ToolStripDropDownButton btnOptions;
        private System.Windows.Forms.ContextMenuStrip paneMenu;
        private System.Windows.Forms.ToolStripMenuItem menuItemUnselect;
    }
}