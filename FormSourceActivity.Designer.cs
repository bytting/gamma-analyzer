namespace crash
{
    partial class FormSourceActivity
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(FormSourceActivity));
            this.status = new System.Windows.Forms.StatusStrip();
            this.tools = new System.Windows.Forms.ToolStrip();
            this.layoutMain = new System.Windows.Forms.TableLayoutPanel();
            this.btnGetElevation = new System.Windows.Forms.Button();
            this.tbApiKey = new System.Windows.Forms.TextBox();
            this.label1 = new System.Windows.Forms.Label();
            this.tbElevation = new System.Windows.Forms.TextBox();
            this.label2 = new System.Windows.Forms.Label();
            this.panel1 = new System.Windows.Forms.Panel();
            this.btnOk = new System.Windows.Forms.Button();
            this.btnCancel = new System.Windows.Forms.Button();
            this.label3 = new System.Windows.Forms.Label();
            this.lblSessionSpectrum = new System.Windows.Forms.Label();
            this.layoutMain.SuspendLayout();
            this.panel1.SuspendLayout();
            this.SuspendLayout();
            // 
            // status
            // 
            this.status.Location = new System.Drawing.Point(0, 235);
            this.status.Name = "status";
            this.status.Size = new System.Drawing.Size(562, 22);
            this.status.TabIndex = 0;
            this.status.Text = "statusStrip1";
            // 
            // tools
            // 
            this.tools.Location = new System.Drawing.Point(0, 0);
            this.tools.Name = "tools";
            this.tools.Size = new System.Drawing.Size(562, 25);
            this.tools.TabIndex = 1;
            this.tools.Text = "toolStrip1";
            // 
            // layoutMain
            // 
            this.layoutMain.ColumnCount = 3;
            this.layoutMain.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 33.33333F));
            this.layoutMain.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 33.33333F));
            this.layoutMain.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 33.33333F));
            this.layoutMain.Controls.Add(this.tbApiKey, 1, 1);
            this.layoutMain.Controls.Add(this.btnGetElevation, 1, 2);
            this.layoutMain.Controls.Add(this.label1, 0, 1);
            this.layoutMain.Controls.Add(this.tbElevation, 2, 2);
            this.layoutMain.Controls.Add(this.label2, 0, 2);
            this.layoutMain.Controls.Add(this.label3, 0, 0);
            this.layoutMain.Controls.Add(this.lblSessionSpectrum, 1, 0);
            this.layoutMain.Dock = System.Windows.Forms.DockStyle.Fill;
            this.layoutMain.Location = new System.Drawing.Point(0, 25);
            this.layoutMain.Name = "layoutMain";
            this.layoutMain.RowCount = 7;
            this.layoutMain.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 28F));
            this.layoutMain.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 28F));
            this.layoutMain.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 28F));
            this.layoutMain.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 28F));
            this.layoutMain.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 28F));
            this.layoutMain.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 28F));
            this.layoutMain.RowStyles.Add(new System.Windows.Forms.RowStyle());
            this.layoutMain.Size = new System.Drawing.Size(562, 182);
            this.layoutMain.TabIndex = 2;
            // 
            // btnGetElevation
            // 
            this.btnGetElevation.Dock = System.Windows.Forms.DockStyle.Fill;
            this.btnGetElevation.Location = new System.Drawing.Point(190, 59);
            this.btnGetElevation.Name = "btnGetElevation";
            this.btnGetElevation.Size = new System.Drawing.Size(181, 22);
            this.btnGetElevation.TabIndex = 1;
            this.btnGetElevation.Text = "Get elevation";
            this.btnGetElevation.UseVisualStyleBackColor = true;
            this.btnGetElevation.Click += new System.EventHandler(this.btnGetElevation_Click);
            // 
            // tbApiKey
            // 
            this.layoutMain.SetColumnSpan(this.tbApiKey, 2);
            this.tbApiKey.Dock = System.Windows.Forms.DockStyle.Fill;
            this.tbApiKey.Location = new System.Drawing.Point(190, 31);
            this.tbApiKey.Name = "tbApiKey";
            this.tbApiKey.Size = new System.Drawing.Size(369, 20);
            this.tbApiKey.TabIndex = 2;
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.label1.Location = new System.Drawing.Point(3, 28);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(181, 28);
            this.label1.TabIndex = 3;
            this.label1.Text = "Enter Google API Key:";
            this.label1.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // tbElevation
            // 
            this.tbElevation.Dock = System.Windows.Forms.DockStyle.Fill;
            this.tbElevation.Location = new System.Drawing.Point(377, 59);
            this.tbElevation.Name = "tbElevation";
            this.tbElevation.ReadOnly = true;
            this.tbElevation.Size = new System.Drawing.Size(182, 20);
            this.tbElevation.TabIndex = 4;
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Dock = System.Windows.Forms.DockStyle.Fill;
            this.label2.Location = new System.Drawing.Point(3, 56);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(181, 28);
            this.label2.TabIndex = 5;
            this.label2.Text = "Elevation (requires internett)";
            this.label2.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // panel1
            // 
            this.panel1.Controls.Add(this.btnCancel);
            this.panel1.Controls.Add(this.btnOk);
            this.panel1.Dock = System.Windows.Forms.DockStyle.Bottom;
            this.panel1.Location = new System.Drawing.Point(0, 207);
            this.panel1.Name = "panel1";
            this.panel1.Size = new System.Drawing.Size(562, 28);
            this.panel1.TabIndex = 3;
            // 
            // btnOk
            // 
            this.btnOk.Dock = System.Windows.Forms.DockStyle.Right;
            this.btnOk.Location = new System.Drawing.Point(487, 0);
            this.btnOk.Name = "btnOk";
            this.btnOk.Size = new System.Drawing.Size(75, 28);
            this.btnOk.TabIndex = 0;
            this.btnOk.Text = "Ok";
            this.btnOk.UseVisualStyleBackColor = true;
            this.btnOk.Click += new System.EventHandler(this.btnOk_Click);
            // 
            // btnCancel
            // 
            this.btnCancel.Dock = System.Windows.Forms.DockStyle.Right;
            this.btnCancel.Location = new System.Drawing.Point(412, 0);
            this.btnCancel.Name = "btnCancel";
            this.btnCancel.Size = new System.Drawing.Size(75, 28);
            this.btnCancel.TabIndex = 1;
            this.btnCancel.Text = "Cancel";
            this.btnCancel.UseVisualStyleBackColor = true;
            this.btnCancel.Click += new System.EventHandler(this.btnCancel_Click);
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Dock = System.Windows.Forms.DockStyle.Fill;
            this.label3.Location = new System.Drawing.Point(3, 0);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(181, 28);
            this.label3.TabIndex = 6;
            this.label3.Text = "Spectrum";
            this.label3.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // lblSessionSpectrum
            // 
            this.lblSessionSpectrum.AutoSize = true;
            this.layoutMain.SetColumnSpan(this.lblSessionSpectrum, 2);
            this.lblSessionSpectrum.Dock = System.Windows.Forms.DockStyle.Fill;
            this.lblSessionSpectrum.Location = new System.Drawing.Point(190, 0);
            this.lblSessionSpectrum.Name = "lblSessionSpectrum";
            this.lblSessionSpectrum.Size = new System.Drawing.Size(369, 28);
            this.lblSessionSpectrum.TabIndex = 7;
            this.lblSessionSpectrum.Text = "<lblSessionSpectrum>";
            this.lblSessionSpectrum.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // FormSourceActivity
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(562, 257);
            this.Controls.Add(this.layoutMain);
            this.Controls.Add(this.panel1);
            this.Controls.Add(this.tools);
            this.Controls.Add(this.status);
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.Name = "FormSourceActivity";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterParent;
            this.Text = "Crash - Source Activity";
            this.Load += new System.EventHandler(this.FormSourceActivity_Load);
            this.layoutMain.ResumeLayout(false);
            this.layoutMain.PerformLayout();
            this.panel1.ResumeLayout(false);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.StatusStrip status;
        private System.Windows.Forms.ToolStrip tools;
        private System.Windows.Forms.TableLayoutPanel layoutMain;
        private System.Windows.Forms.TextBox tbApiKey;
        private System.Windows.Forms.Button btnGetElevation;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.TextBox tbElevation;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Panel panel1;
        private System.Windows.Forms.Button btnCancel;
        private System.Windows.Forms.Button btnOk;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.Label lblSessionSpectrum;
    }
}