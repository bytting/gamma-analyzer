namespace crash
{
    partial class FormROITableHistory
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(FormROITableHistory));
            this.statusStrip1 = new System.Windows.Forms.StatusStrip();
            this.toolStrip1 = new System.Windows.Forms.ToolStrip();
            this.pane = new System.Windows.Forms.Panel();
            this.panel1 = new System.Windows.Forms.Panel();
            this.gridROI = new System.Windows.Forms.DataGridView();
            this.panel2 = new System.Windows.Forms.Panel();
            this.label1 = new System.Windows.Forms.Label();
            this.btnApply = new System.Windows.Forms.Button();
            this.Label = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.ChannelFrom = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.ChannelTo = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.Active = new System.Windows.Forms.DataGridViewCheckBoxColumn();
            this.LineColor = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.lblScaling = new System.Windows.Forms.ToolStripStatusLabel();
            this.statusStrip1.SuspendLayout();
            this.panel1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.gridROI)).BeginInit();
            this.panel2.SuspendLayout();
            this.SuspendLayout();
            // 
            // statusStrip1
            // 
            this.statusStrip1.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.lblScaling});
            this.statusStrip1.Location = new System.Drawing.Point(0, 635);
            this.statusStrip1.Name = "statusStrip1";
            this.statusStrip1.Size = new System.Drawing.Size(1095, 22);
            this.statusStrip1.TabIndex = 0;
            this.statusStrip1.Text = "statusStrip1";
            // 
            // toolStrip1
            // 
            this.toolStrip1.Location = new System.Drawing.Point(0, 0);
            this.toolStrip1.Name = "toolStrip1";
            this.toolStrip1.Size = new System.Drawing.Size(1095, 25);
            this.toolStrip1.TabIndex = 1;
            this.toolStrip1.Text = "toolStrip1";
            // 
            // pane
            // 
            this.pane.BackColor = System.Drawing.SystemColors.ButtonFace;
            this.pane.Dock = System.Windows.Forms.DockStyle.Fill;
            this.pane.Location = new System.Drawing.Point(0, 25);
            this.pane.Name = "pane";
            this.pane.Size = new System.Drawing.Size(697, 610);
            this.pane.TabIndex = 2;
            this.pane.Paint += new System.Windows.Forms.PaintEventHandler(this.pane_Paint);
            this.pane.Resize += new System.EventHandler(this.pane_Resize);
            // 
            // panel1
            // 
            this.panel1.Controls.Add(this.gridROI);
            this.panel1.Controls.Add(this.panel2);
            this.panel1.Dock = System.Windows.Forms.DockStyle.Right;
            this.panel1.Location = new System.Drawing.Point(697, 25);
            this.panel1.Name = "panel1";
            this.panel1.Size = new System.Drawing.Size(398, 610);
            this.panel1.TabIndex = 3;
            // 
            // gridROI
            // 
            this.gridROI.AutoSizeColumnsMode = System.Windows.Forms.DataGridViewAutoSizeColumnsMode.Fill;
            this.gridROI.BackgroundColor = System.Drawing.SystemColors.ButtonFace;
            this.gridROI.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.gridROI.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
            this.Label,
            this.ChannelFrom,
            this.ChannelTo,
            this.Active,
            this.LineColor});
            this.gridROI.Dock = System.Windows.Forms.DockStyle.Fill;
            this.gridROI.Location = new System.Drawing.Point(0, 55);
            this.gridROI.Name = "gridROI";
            this.gridROI.RowHeadersVisible = false;
            this.gridROI.Size = new System.Drawing.Size(398, 555);
            this.gridROI.TabIndex = 1;
            // 
            // panel2
            // 
            this.panel2.Controls.Add(this.btnApply);
            this.panel2.Controls.Add(this.label1);
            this.panel2.Dock = System.Windows.Forms.DockStyle.Top;
            this.panel2.Location = new System.Drawing.Point(0, 0);
            this.panel2.Name = "panel2";
            this.panel2.Size = new System.Drawing.Size(398, 55);
            this.panel2.TabIndex = 0;
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(40, 18);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(65, 13);
            this.label1.TabIndex = 0;
            this.label1.Text = "ROI settings";
            // 
            // btnApply
            // 
            this.btnApply.Location = new System.Drawing.Point(283, 18);
            this.btnApply.Name = "btnApply";
            this.btnApply.Size = new System.Drawing.Size(103, 23);
            this.btnApply.TabIndex = 1;
            this.btnApply.Text = "Apply";
            this.btnApply.UseVisualStyleBackColor = true;
            this.btnApply.Click += new System.EventHandler(this.btnApply_Click);
            // 
            // Label
            // 
            this.Label.HeaderText = "Name";
            this.Label.Name = "Label";
            // 
            // ChannelFrom
            // 
            this.ChannelFrom.HeaderText = "From";
            this.ChannelFrom.Name = "ChannelFrom";
            // 
            // ChannelTo
            // 
            this.ChannelTo.HeaderText = "To";
            this.ChannelTo.Name = "ChannelTo";
            // 
            // Active
            // 
            this.Active.HeaderText = "Active";
            this.Active.Name = "Active";
            // 
            // LineColor
            // 
            this.LineColor.HeaderText = "Color";
            this.LineColor.Name = "LineColor";
            this.LineColor.ReadOnly = true;
            // 
            // lblScaling
            // 
            this.lblScaling.Name = "lblScaling";
            this.lblScaling.Size = new System.Drawing.Size(118, 17);
            this.lblScaling.Text = "toolStripStatusLabel1";
            // 
            // FormROITableHistory
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(1095, 657);
            this.Controls.Add(this.pane);
            this.Controls.Add(this.panel1);
            this.Controls.Add(this.toolStrip1);
            this.Controls.Add(this.statusStrip1);
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.Name = "FormROITableHistory";
            this.Text = "Crash - ROI History";
            this.FormClosing += new System.Windows.Forms.FormClosingEventHandler(this.FormROITableHistory_FormClosing);
            this.Load += new System.EventHandler(this.FormROITableHistory_Load);
            this.statusStrip1.ResumeLayout(false);
            this.statusStrip1.PerformLayout();
            this.panel1.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.gridROI)).EndInit();
            this.panel2.ResumeLayout(false);
            this.panel2.PerformLayout();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.StatusStrip statusStrip1;
        private System.Windows.Forms.ToolStrip toolStrip1;
        private System.Windows.Forms.Panel pane;
        private System.Windows.Forms.Panel panel1;
        private System.Windows.Forms.Panel panel2;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.DataGridView gridROI;
        private System.Windows.Forms.Button btnApply;
        private System.Windows.Forms.DataGridViewTextBoxColumn Label;
        private System.Windows.Forms.DataGridViewTextBoxColumn ChannelFrom;
        private System.Windows.Forms.DataGridViewTextBoxColumn ChannelTo;
        private System.Windows.Forms.DataGridViewCheckBoxColumn Active;
        private System.Windows.Forms.DataGridViewTextBoxColumn LineColor;
        private System.Windows.Forms.ToolStripStatusLabel lblScaling;
    }
}