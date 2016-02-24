namespace crash
{
    partial class FormWaterfall
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(FormWaterfall));
            this.toolStrip1 = new System.Windows.Forms.ToolStrip();
            this.statusStrip1 = new System.Windows.Forms.StatusStrip();
            this.pane = new System.Windows.Forms.Panel();
            this.tbInfo = new System.Windows.Forms.TextBox();
            this.SuspendLayout();
            // 
            // toolStrip1
            // 
            this.toolStrip1.Location = new System.Drawing.Point(0, 0);
            this.toolStrip1.Name = "toolStrip1";
            this.toolStrip1.Size = new System.Drawing.Size(1081, 25);
            this.toolStrip1.TabIndex = 0;
            this.toolStrip1.Text = "toolStrip1";
            // 
            // statusStrip1
            // 
            this.statusStrip1.Location = new System.Drawing.Point(0, 570);
            this.statusStrip1.Name = "statusStrip1";
            this.statusStrip1.Size = new System.Drawing.Size(1081, 22);
            this.statusStrip1.TabIndex = 1;
            this.statusStrip1.Text = "statusStrip1";
            // 
            // pane
            // 
            this.pane.Dock = System.Windows.Forms.DockStyle.Fill;
            this.pane.Location = new System.Drawing.Point(0, 25);
            this.pane.Name = "pane";
            this.pane.Size = new System.Drawing.Size(1081, 473);
            this.pane.TabIndex = 2;
            this.pane.Paint += new System.Windows.Forms.PaintEventHandler(this.pane_Paint);
            this.pane.Resize += new System.EventHandler(this.pane_Resize);
            // 
            // tbInfo
            // 
            this.tbInfo.Dock = System.Windows.Forms.DockStyle.Bottom;
            this.tbInfo.Location = new System.Drawing.Point(0, 498);
            this.tbInfo.Multiline = true;
            this.tbInfo.Name = "tbInfo";
            this.tbInfo.ReadOnly = true;
            this.tbInfo.Size = new System.Drawing.Size(1081, 72);
            this.tbInfo.TabIndex = 3;
            // 
            // FormWaterfall
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(1081, 592);
            this.Controls.Add(this.pane);
            this.Controls.Add(this.tbInfo);
            this.Controls.Add(this.statusStrip1);
            this.Controls.Add(this.toolStrip1);
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.Name = "FormWaterfall";
            this.Text = "Crash - Waterfall";
            this.FormClosing += new System.Windows.Forms.FormClosingEventHandler(this.FormWaterfall_FormClosing);
            this.Load += new System.EventHandler(this.FormWaterfall_Load);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.ToolStrip toolStrip1;
        private System.Windows.Forms.StatusStrip statusStrip1;
        private System.Windows.Forms.Panel pane;
        private System.Windows.Forms.TextBox tbInfo;
    }
}