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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(FormWaterfallLive));
            this.tools = new System.Windows.Forms.ToolStrip();
            this.status = new System.Windows.Forms.StatusStrip();
            this.lblColorCeil = new System.Windows.Forms.ToolStripStatusLabel();
            this.lblMouseInfo = new System.Windows.Forms.ToolStripStatusLabel();
            this.pane = new System.Windows.Forms.Panel();
            this.tbColorCeil = new System.Windows.Forms.TrackBar();
            this.panel1 = new System.Windows.Forms.Panel();
            this.btnRightAll = new System.Windows.Forms.Button();
            this.btnRight = new System.Windows.Forms.Button();
            this.btnLeft = new System.Windows.Forms.Button();
            this.btnLeftAll = new System.Windows.Forms.Button();
            this.status.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.tbColorCeil)).BeginInit();
            this.panel1.SuspendLayout();
            this.SuspendLayout();
            // 
            // tools
            // 
            this.tools.Location = new System.Drawing.Point(0, 0);
            this.tools.Name = "tools";
            this.tools.Size = new System.Drawing.Size(1000, 25);
            this.tools.TabIndex = 0;
            this.tools.Text = "toolStrip1";
            // 
            // status
            // 
            this.status.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.lblColorCeil,
            this.lblMouseInfo});
            this.status.Location = new System.Drawing.Point(0, 449);
            this.status.Name = "status";
            this.status.Size = new System.Drawing.Size(1000, 22);
            this.status.TabIndex = 1;
            this.status.Text = "statusStrip1";
            // 
            // lblColorCeil
            // 
            this.lblColorCeil.Name = "lblColorCeil";
            this.lblColorCeil.Size = new System.Drawing.Size(85, 17);
            this.lblColorCeil.Text = "<lblColorCeil>";
            // 
            // lblMouseInfo
            // 
            this.lblMouseInfo.Name = "lblMouseInfo";
            this.lblMouseInfo.Size = new System.Drawing.Size(93, 17);
            this.lblMouseInfo.Text = "<lblMouseInfo>";
            // 
            // pane
            // 
            this.pane.BackColor = System.Drawing.Color.Blue;
            this.pane.Cursor = System.Windows.Forms.Cursors.Cross;
            this.pane.Dock = System.Windows.Forms.DockStyle.Fill;
            this.pane.Location = new System.Drawing.Point(0, 25);
            this.pane.Name = "pane";
            this.pane.Size = new System.Drawing.Size(955, 402);
            this.pane.TabIndex = 2;
            this.pane.Paint += new System.Windows.Forms.PaintEventHandler(this.pane_Paint);
            this.pane.MouseDown += new System.Windows.Forms.MouseEventHandler(this.pane_MouseDown);
            this.pane.MouseMove += new System.Windows.Forms.MouseEventHandler(this.pane_MouseMove);
            this.pane.Resize += new System.EventHandler(this.pane_Resize);
            // 
            // tbColorCeil
            // 
            this.tbColorCeil.Dock = System.Windows.Forms.DockStyle.Right;
            this.tbColorCeil.Location = new System.Drawing.Point(955, 25);
            this.tbColorCeil.Name = "tbColorCeil";
            this.tbColorCeil.Orientation = System.Windows.Forms.Orientation.Vertical;
            this.tbColorCeil.Size = new System.Drawing.Size(45, 424);
            this.tbColorCeil.TabIndex = 3;
            this.tbColorCeil.Scroll += new System.EventHandler(this.tbColorCeil_Scroll);
            this.tbColorCeil.ValueChanged += new System.EventHandler(this.tbColorCeil_ValueChanged);
            // 
            // panel1
            // 
            this.panel1.Controls.Add(this.btnRightAll);
            this.panel1.Controls.Add(this.btnRight);
            this.panel1.Controls.Add(this.btnLeft);
            this.panel1.Controls.Add(this.btnLeftAll);
            this.panel1.Dock = System.Windows.Forms.DockStyle.Bottom;
            this.panel1.Location = new System.Drawing.Point(0, 427);
            this.panel1.Name = "panel1";
            this.panel1.Size = new System.Drawing.Size(955, 22);
            this.panel1.TabIndex = 4;
            // 
            // btnRightAll
            // 
            this.btnRightAll.Dock = System.Windows.Forms.DockStyle.Left;
            this.btnRightAll.FlatAppearance.BorderSize = 0;
            this.btnRightAll.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnRightAll.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnRightAll.Location = new System.Drawing.Point(225, 0);
            this.btnRightAll.Name = "btnRightAll";
            this.btnRightAll.Size = new System.Drawing.Size(75, 22);
            this.btnRightAll.TabIndex = 3;
            this.btnRightAll.Text = ">>";
            this.btnRightAll.UseVisualStyleBackColor = true;
            this.btnRightAll.Click += new System.EventHandler(this.btnRightAll_Click);
            // 
            // btnRight
            // 
            this.btnRight.Dock = System.Windows.Forms.DockStyle.Left;
            this.btnRight.FlatAppearance.BorderSize = 0;
            this.btnRight.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnRight.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnRight.Location = new System.Drawing.Point(150, 0);
            this.btnRight.Name = "btnRight";
            this.btnRight.Size = new System.Drawing.Size(75, 22);
            this.btnRight.TabIndex = 2;
            this.btnRight.Text = ">";
            this.btnRight.UseVisualStyleBackColor = true;
            this.btnRight.Click += new System.EventHandler(this.btnRight_Click);
            // 
            // btnLeft
            // 
            this.btnLeft.Dock = System.Windows.Forms.DockStyle.Left;
            this.btnLeft.FlatAppearance.BorderSize = 0;
            this.btnLeft.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnLeft.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnLeft.Location = new System.Drawing.Point(75, 0);
            this.btnLeft.Name = "btnLeft";
            this.btnLeft.Size = new System.Drawing.Size(75, 22);
            this.btnLeft.TabIndex = 1;
            this.btnLeft.Text = "<";
            this.btnLeft.UseVisualStyleBackColor = true;
            this.btnLeft.Click += new System.EventHandler(this.btnLeft_Click);
            // 
            // btnLeftAll
            // 
            this.btnLeftAll.Dock = System.Windows.Forms.DockStyle.Left;
            this.btnLeftAll.FlatAppearance.BorderSize = 0;
            this.btnLeftAll.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnLeftAll.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnLeftAll.Location = new System.Drawing.Point(0, 0);
            this.btnLeftAll.Name = "btnLeftAll";
            this.btnLeftAll.Size = new System.Drawing.Size(75, 22);
            this.btnLeftAll.TabIndex = 0;
            this.btnLeftAll.Text = "<<";
            this.btnLeftAll.UseVisualStyleBackColor = true;
            this.btnLeftAll.Click += new System.EventHandler(this.btnLeftAll_Click);
            // 
            // FormWaterfallLive
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(1000, 471);
            this.Controls.Add(this.pane);
            this.Controls.Add(this.panel1);
            this.Controls.Add(this.tbColorCeil);
            this.Controls.Add(this.status);
            this.Controls.Add(this.tools);
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.MinimumSize = new System.Drawing.Size(300, 300);
            this.Name = "FormWaterfallLive";
            this.Text = "Crash - Waterfall Live";
            this.FormClosing += new System.Windows.Forms.FormClosingEventHandler(this.FormWaterfall_FormClosing);
            this.Load += new System.EventHandler(this.FormWaterfall_Load);
            this.status.ResumeLayout(false);
            this.status.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.tbColorCeil)).EndInit();
            this.panel1.ResumeLayout(false);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.ToolStrip tools;
        private System.Windows.Forms.StatusStrip status;
        private System.Windows.Forms.Panel pane;
        private System.Windows.Forms.TrackBar tbColorCeil;
        private System.Windows.Forms.ToolStripStatusLabel lblColorCeil;
        private System.Windows.Forms.Panel panel1;
        private System.Windows.Forms.Button btnRightAll;
        private System.Windows.Forms.Button btnRight;
        private System.Windows.Forms.Button btnLeft;
        private System.Windows.Forms.Button btnLeftAll;
        private System.Windows.Forms.ToolStripStatusLabel lblMouseInfo;
    }
}