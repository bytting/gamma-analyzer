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
            this.pane = new System.Windows.Forms.Panel();
            this.tbColorCeil = new System.Windows.Forms.TrackBar();
            this.status.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.tbColorCeil)).BeginInit();
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
            this.lblColorCeil});
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
            // pane
            // 
            this.pane.BackColor = System.Drawing.Color.Blue;
            this.pane.Dock = System.Windows.Forms.DockStyle.Fill;
            this.pane.Location = new System.Drawing.Point(0, 25);
            this.pane.Name = "pane";
            this.pane.Size = new System.Drawing.Size(955, 424);
            this.pane.TabIndex = 2;
            this.pane.Paint += new System.Windows.Forms.PaintEventHandler(this.pane_Paint);
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
            // FormWaterfallLive
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(1000, 471);
            this.Controls.Add(this.pane);
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
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.ToolStrip tools;
        private System.Windows.Forms.StatusStrip status;
        private System.Windows.Forms.Panel pane;
        private System.Windows.Forms.TrackBar tbColorCeil;
        private System.Windows.Forms.ToolStripStatusLabel lblColorCeil;
    }
}