namespace crash
{
    partial class FormWaterfallHistory
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(FormWaterfallHistory));
            this.tools = new System.Windows.Forms.ToolStrip();
            this.status = new System.Windows.Forms.StatusStrip();
            this.SuspendLayout();
            // 
            // tools
            // 
            this.tools.Location = new System.Drawing.Point(0, 0);
            this.tools.Name = "tools";
            this.tools.Size = new System.Drawing.Size(895, 25);
            this.tools.TabIndex = 0;
            this.tools.Text = "toolStrip1";
            // 
            // status
            // 
            this.status.Location = new System.Drawing.Point(0, 552);
            this.status.Name = "status";
            this.status.Size = new System.Drawing.Size(895, 22);
            this.status.TabIndex = 1;
            this.status.Text = "statusStrip1";
            // 
            // FormWaterfallHistory
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(895, 574);
            this.Controls.Add(this.status);
            this.Controls.Add(this.tools);
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.Name = "FormWaterfallHistory";
            this.Text = "Crash - Waterfall History";
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.ToolStrip tools;
        private System.Windows.Forms.StatusStrip status;
    }
}