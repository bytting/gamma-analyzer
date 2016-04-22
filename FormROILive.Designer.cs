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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(FormROILive));
            this.status = new System.Windows.Forms.StatusStrip();
            this.lblScaling = new System.Windows.Forms.ToolStripStatusLabel();
            this.lblSpectrum = new System.Windows.Forms.ToolStripStatusLabel();
            this.pane = new System.Windows.Forms.Panel();
            this.panel3 = new System.Windows.Forms.Panel();
            this.btnUpAll = new System.Windows.Forms.Button();
            this.btnUp = new System.Windows.Forms.Button();
            this.btnDown = new System.Windows.Forms.Button();
            this.btnDownAll = new System.Windows.Forms.Button();
            this.btnRightAll = new System.Windows.Forms.Button();
            this.btnRight = new System.Windows.Forms.Button();
            this.btnLeft = new System.Windows.Forms.Button();
            this.btnLeftAll = new System.Windows.Forms.Button();
            this.tools = new System.Windows.Forms.ToolStrip();
            this.status.SuspendLayout();
            this.panel3.SuspendLayout();
            this.SuspendLayout();
            // 
            // status
            // 
            this.status.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.lblScaling,
            this.lblSpectrum});
            this.status.Location = new System.Drawing.Point(0, 519);
            this.status.Name = "status";
            this.status.Size = new System.Drawing.Size(934, 22);
            this.status.TabIndex = 0;
            this.status.Text = "statusStrip1";
            // 
            // lblScaling
            // 
            this.lblScaling.Name = "lblScaling";
            this.lblScaling.Size = new System.Drawing.Size(74, 17);
            this.lblScaling.Text = "<lblScaling>";
            // 
            // lblSpectrum
            // 
            this.lblSpectrum.Name = "lblSpectrum";
            this.lblSpectrum.Size = new System.Drawing.Size(87, 17);
            this.lblSpectrum.Text = "<lblSpectrum>";
            // 
            // pane
            // 
            this.pane.BackColor = System.Drawing.SystemColors.ButtonFace;
            this.pane.Cursor = System.Windows.Forms.Cursors.Cross;
            this.pane.Dock = System.Windows.Forms.DockStyle.Fill;
            this.pane.Location = new System.Drawing.Point(0, 25);
            this.pane.Name = "pane";
            this.pane.Size = new System.Drawing.Size(934, 472);
            this.pane.TabIndex = 2;
            this.pane.Paint += new System.Windows.Forms.PaintEventHandler(this.pane_Paint);
            this.pane.MouseClick += new System.Windows.Forms.MouseEventHandler(this.pane_MouseClick);
            this.pane.MouseMove += new System.Windows.Forms.MouseEventHandler(this.pane_MouseMove);
            this.pane.Resize += new System.EventHandler(this.pane_Resize);
            // 
            // panel3
            // 
            this.panel3.Controls.Add(this.btnUpAll);
            this.panel3.Controls.Add(this.btnUp);
            this.panel3.Controls.Add(this.btnDown);
            this.panel3.Controls.Add(this.btnDownAll);
            this.panel3.Controls.Add(this.btnRightAll);
            this.panel3.Controls.Add(this.btnRight);
            this.panel3.Controls.Add(this.btnLeft);
            this.panel3.Controls.Add(this.btnLeftAll);
            this.panel3.Dock = System.Windows.Forms.DockStyle.Bottom;
            this.panel3.Location = new System.Drawing.Point(0, 497);
            this.panel3.Name = "panel3";
            this.panel3.Size = new System.Drawing.Size(934, 22);
            this.panel3.TabIndex = 4;
            // 
            // btnUpAll
            // 
            this.btnUpAll.Dock = System.Windows.Forms.DockStyle.Right;
            this.btnUpAll.FlatAppearance.BorderSize = 0;
            this.btnUpAll.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnUpAll.Image = global::crash.Properties.Resources.up_all_16;
            this.btnUpAll.Location = new System.Drawing.Point(734, 0);
            this.btnUpAll.Name = "btnUpAll";
            this.btnUpAll.Size = new System.Drawing.Size(50, 22);
            this.btnUpAll.TabIndex = 7;
            this.btnUpAll.UseVisualStyleBackColor = true;
            // 
            // btnUp
            // 
            this.btnUp.Dock = System.Windows.Forms.DockStyle.Right;
            this.btnUp.FlatAppearance.BorderSize = 0;
            this.btnUp.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnUp.Image = global::crash.Properties.Resources.up_16;
            this.btnUp.Location = new System.Drawing.Point(784, 0);
            this.btnUp.Name = "btnUp";
            this.btnUp.Size = new System.Drawing.Size(50, 22);
            this.btnUp.TabIndex = 6;
            this.btnUp.UseVisualStyleBackColor = true;
            // 
            // btnDown
            // 
            this.btnDown.Dock = System.Windows.Forms.DockStyle.Right;
            this.btnDown.FlatAppearance.BorderSize = 0;
            this.btnDown.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnDown.Image = global::crash.Properties.Resources.down_16;
            this.btnDown.Location = new System.Drawing.Point(834, 0);
            this.btnDown.Name = "btnDown";
            this.btnDown.Size = new System.Drawing.Size(50, 22);
            this.btnDown.TabIndex = 5;
            this.btnDown.UseVisualStyleBackColor = true;
            // 
            // btnDownAll
            // 
            this.btnDownAll.Dock = System.Windows.Forms.DockStyle.Right;
            this.btnDownAll.FlatAppearance.BorderSize = 0;
            this.btnDownAll.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnDownAll.Image = global::crash.Properties.Resources.down_all_16;
            this.btnDownAll.Location = new System.Drawing.Point(884, 0);
            this.btnDownAll.Name = "btnDownAll";
            this.btnDownAll.Size = new System.Drawing.Size(50, 22);
            this.btnDownAll.TabIndex = 4;
            this.btnDownAll.UseVisualStyleBackColor = true;
            // 
            // btnRightAll
            // 
            this.btnRightAll.Dock = System.Windows.Forms.DockStyle.Left;
            this.btnRightAll.FlatAppearance.BorderSize = 0;
            this.btnRightAll.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnRightAll.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnRightAll.Image = global::crash.Properties.Resources.right_all_16;
            this.btnRightAll.Location = new System.Drawing.Point(150, 0);
            this.btnRightAll.Name = "btnRightAll";
            this.btnRightAll.Size = new System.Drawing.Size(50, 22);
            this.btnRightAll.TabIndex = 3;
            this.btnRightAll.UseVisualStyleBackColor = true;
            this.btnRightAll.Click += new System.EventHandler(this.btnRightAll_Click);
            // 
            // btnRight
            // 
            this.btnRight.Dock = System.Windows.Forms.DockStyle.Left;
            this.btnRight.FlatAppearance.BorderSize = 0;
            this.btnRight.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnRight.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnRight.Image = global::crash.Properties.Resources.right_16;
            this.btnRight.Location = new System.Drawing.Point(100, 0);
            this.btnRight.Name = "btnRight";
            this.btnRight.Size = new System.Drawing.Size(50, 22);
            this.btnRight.TabIndex = 2;
            this.btnRight.UseVisualStyleBackColor = true;
            this.btnRight.Click += new System.EventHandler(this.btnRight_Click);
            // 
            // btnLeft
            // 
            this.btnLeft.Dock = System.Windows.Forms.DockStyle.Left;
            this.btnLeft.FlatAppearance.BorderSize = 0;
            this.btnLeft.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnLeft.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnLeft.Image = global::crash.Properties.Resources.left_16;
            this.btnLeft.Location = new System.Drawing.Point(50, 0);
            this.btnLeft.Name = "btnLeft";
            this.btnLeft.Size = new System.Drawing.Size(50, 22);
            this.btnLeft.TabIndex = 1;
            this.btnLeft.UseVisualStyleBackColor = true;
            this.btnLeft.Click += new System.EventHandler(this.btnLeft_Click);
            // 
            // btnLeftAll
            // 
            this.btnLeftAll.Dock = System.Windows.Forms.DockStyle.Left;
            this.btnLeftAll.FlatAppearance.BorderSize = 0;
            this.btnLeftAll.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnLeftAll.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnLeftAll.Image = global::crash.Properties.Resources.left_all_16;
            this.btnLeftAll.Location = new System.Drawing.Point(0, 0);
            this.btnLeftAll.Name = "btnLeftAll";
            this.btnLeftAll.Size = new System.Drawing.Size(50, 22);
            this.btnLeftAll.TabIndex = 0;
            this.btnLeftAll.UseVisualStyleBackColor = true;
            this.btnLeftAll.Click += new System.EventHandler(this.btnLeftAll_Click);
            // 
            // tools
            // 
            this.tools.Location = new System.Drawing.Point(0, 0);
            this.tools.Name = "tools";
            this.tools.Size = new System.Drawing.Size(934, 25);
            this.tools.TabIndex = 5;
            this.tools.Text = "toolStrip1";
            // 
            // FormROILive
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(934, 541);
            this.Controls.Add(this.pane);
            this.Controls.Add(this.tools);
            this.Controls.Add(this.panel3);
            this.Controls.Add(this.status);
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.MinimumSize = new System.Drawing.Size(320, 200);
            this.Name = "FormROILive";
            this.Text = "Crash - ROI Live";
            this.FormClosing += new System.Windows.Forms.FormClosingEventHandler(this.FormROITableLive_FormClosing);
            this.Load += new System.EventHandler(this.FormROITableLive_Load);
            this.status.ResumeLayout(false);
            this.status.PerformLayout();
            this.panel3.ResumeLayout(false);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.StatusStrip status;
        private System.Windows.Forms.Panel pane;
        private System.Windows.Forms.ToolStripStatusLabel lblScaling;
        private System.Windows.Forms.Panel panel3;
        private System.Windows.Forms.Button btnRightAll;
        private System.Windows.Forms.Button btnRight;
        private System.Windows.Forms.Button btnLeft;
        private System.Windows.Forms.Button btnLeftAll;
        private System.Windows.Forms.ToolStrip tools;
        private System.Windows.Forms.Button btnUpAll;
        private System.Windows.Forms.Button btnUp;
        private System.Windows.Forms.Button btnDown;
        private System.Windows.Forms.Button btnDownAll;
        private System.Windows.Forms.ToolStripStatusLabel lblSpectrum;
    }
}