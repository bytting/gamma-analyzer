namespace crash
{
    partial class FormSessionInfo
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(FormSessionInfo));
            this.tools = new System.Windows.Forms.ToolStrip();
            this.status = new System.Windows.Forms.StatusStrip();
            this.panel1 = new System.Windows.Forms.Panel();
            this.btnCancel = new System.Windows.Forms.Button();
            this.btnOk = new System.Windows.Forms.Button();
            this.tbComment = new System.Windows.Forms.TextBox();
            this.label1 = new System.Windows.Forms.Label();
            this.lblName = new System.Windows.Forms.Label();
            this.lblLivetime = new System.Windows.Forms.Label();
            this.lblDetector = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.tbGEScript = new System.Windows.Forms.TextBox();
            this.tableLayoutPanel1 = new System.Windows.Forms.TableLayoutPanel();
            this.label3 = new System.Windows.Forms.Label();
            this.label4 = new System.Windows.Forms.Label();
            this.label5 = new System.Windows.Forms.Label();
            this.label6 = new System.Windows.Forms.Label();
            this.lblNumChannels = new System.Windows.Forms.Label();
            this.lblHVLabel = new System.Windows.Forms.Label();
            this.lblHV = new System.Windows.Forms.Label();
            this.label7 = new System.Windows.Forms.Label();
            this.label8 = new System.Windows.Forms.Label();
            this.lblCoarseGain = new System.Windows.Forms.Label();
            this.lblFineGain = new System.Windows.Forms.Label();
            this.label9 = new System.Windows.Forms.Label();
            this.lblLLDULD = new System.Windows.Forms.Label();
            this.panel1.SuspendLayout();
            this.tableLayoutPanel1.SuspendLayout();
            this.SuspendLayout();
            // 
            // tools
            // 
            this.tools.Location = new System.Drawing.Point(0, 0);
            this.tools.Name = "tools";
            this.tools.Size = new System.Drawing.Size(738, 25);
            this.tools.TabIndex = 0;
            this.tools.Text = "toolStrip1";
            // 
            // status
            // 
            this.status.Location = new System.Drawing.Point(0, 411);
            this.status.Name = "status";
            this.status.Size = new System.Drawing.Size(738, 22);
            this.status.TabIndex = 1;
            this.status.Text = "statusStrip1";
            // 
            // panel1
            // 
            this.panel1.Controls.Add(this.btnCancel);
            this.panel1.Controls.Add(this.btnOk);
            this.panel1.Dock = System.Windows.Forms.DockStyle.Bottom;
            this.panel1.Location = new System.Drawing.Point(0, 386);
            this.panel1.Name = "panel1";
            this.panel1.Size = new System.Drawing.Size(738, 25);
            this.panel1.TabIndex = 2;
            // 
            // btnCancel
            // 
            this.btnCancel.DialogResult = System.Windows.Forms.DialogResult.Cancel;
            this.btnCancel.Dock = System.Windows.Forms.DockStyle.Right;
            this.btnCancel.Location = new System.Drawing.Point(588, 0);
            this.btnCancel.Name = "btnCancel";
            this.btnCancel.Size = new System.Drawing.Size(75, 25);
            this.btnCancel.TabIndex = 1;
            this.btnCancel.Text = "Cancel";
            this.btnCancel.UseVisualStyleBackColor = true;
            this.btnCancel.Click += new System.EventHandler(this.btnCancel_Click);
            // 
            // btnOk
            // 
            this.btnOk.DialogResult = System.Windows.Forms.DialogResult.OK;
            this.btnOk.Dock = System.Windows.Forms.DockStyle.Right;
            this.btnOk.Location = new System.Drawing.Point(663, 0);
            this.btnOk.Name = "btnOk";
            this.btnOk.Size = new System.Drawing.Size(75, 25);
            this.btnOk.TabIndex = 0;
            this.btnOk.Text = "Ok";
            this.btnOk.UseVisualStyleBackColor = true;
            this.btnOk.Click += new System.EventHandler(this.btnOk_Click);
            // 
            // tbComment
            // 
            this.tableLayoutPanel1.SetColumnSpan(this.tbComment, 3);
            this.tbComment.Dock = System.Windows.Forms.DockStyle.Fill;
            this.tbComment.Location = new System.Drawing.Point(113, 59);
            this.tbComment.MaxLength = 200;
            this.tbComment.Name = "tbComment";
            this.tbComment.Size = new System.Drawing.Size(622, 20);
            this.tbComment.TabIndex = 3;
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.label1.Location = new System.Drawing.Point(3, 56);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(104, 28);
            this.label1.TabIndex = 4;
            this.label1.Text = "Comment";
            this.label1.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // lblName
            // 
            this.lblName.AutoSize = true;
            this.lblName.Dock = System.Windows.Forms.DockStyle.Fill;
            this.lblName.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblName.Location = new System.Drawing.Point(113, 0);
            this.lblName.Name = "lblName";
            this.lblName.Size = new System.Drawing.Size(252, 28);
            this.lblName.TabIndex = 5;
            this.lblName.Text = "<lblName>";
            this.lblName.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // lblLivetime
            // 
            this.lblLivetime.AutoSize = true;
            this.lblLivetime.Dock = System.Windows.Forms.DockStyle.Fill;
            this.lblLivetime.Location = new System.Drawing.Point(481, 28);
            this.lblLivetime.Name = "lblLivetime";
            this.lblLivetime.Size = new System.Drawing.Size(254, 28);
            this.lblLivetime.TabIndex = 6;
            this.lblLivetime.Text = "<lblLivetime>";
            this.lblLivetime.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // lblDetector
            // 
            this.lblDetector.AutoSize = true;
            this.lblDetector.Dock = System.Windows.Forms.DockStyle.Fill;
            this.lblDetector.Location = new System.Drawing.Point(113, 28);
            this.lblDetector.Name = "lblDetector";
            this.lblDetector.Size = new System.Drawing.Size(252, 28);
            this.lblDetector.TabIndex = 7;
            this.lblDetector.Text = "<lblDetector>";
            this.lblDetector.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Dock = System.Windows.Forms.DockStyle.Fill;
            this.label2.Location = new System.Drawing.Point(3, 168);
            this.label2.Name = "label2";
            this.label2.Padding = new System.Windows.Forms.Padding(0, 6, 0, 0);
            this.label2.Size = new System.Drawing.Size(104, 193);
            this.label2.TabIndex = 8;
            this.label2.Text = "GE Script";
            this.label2.TextAlign = System.Drawing.ContentAlignment.TopCenter;
            // 
            // tbGEScript
            // 
            this.tableLayoutPanel1.SetColumnSpan(this.tbGEScript, 3);
            this.tbGEScript.Dock = System.Windows.Forms.DockStyle.Fill;
            this.tbGEScript.Font = new System.Drawing.Font("Courier New", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.tbGEScript.Location = new System.Drawing.Point(113, 171);
            this.tbGEScript.Multiline = true;
            this.tbGEScript.Name = "tbGEScript";
            this.tbGEScript.ReadOnly = true;
            this.tbGEScript.ScrollBars = System.Windows.Forms.ScrollBars.Both;
            this.tbGEScript.Size = new System.Drawing.Size(622, 187);
            this.tbGEScript.TabIndex = 9;
            this.tbGEScript.WordWrap = false;
            // 
            // tableLayoutPanel1
            // 
            this.tableLayoutPanel1.ColumnCount = 4;
            this.tableLayoutPanel1.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 15F));
            this.tableLayoutPanel1.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 35F));
            this.tableLayoutPanel1.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 15F));
            this.tableLayoutPanel1.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 35F));
            this.tableLayoutPanel1.Controls.Add(this.tbGEScript, 1, 6);
            this.tableLayoutPanel1.Controls.Add(this.tbComment, 1, 2);
            this.tableLayoutPanel1.Controls.Add(this.label2, 0, 6);
            this.tableLayoutPanel1.Controls.Add(this.label1, 0, 2);
            this.tableLayoutPanel1.Controls.Add(this.lblLivetime, 3, 1);
            this.tableLayoutPanel1.Controls.Add(this.lblDetector, 1, 1);
            this.tableLayoutPanel1.Controls.Add(this.label3, 0, 1);
            this.tableLayoutPanel1.Controls.Add(this.label4, 2, 1);
            this.tableLayoutPanel1.Controls.Add(this.lblName, 1, 0);
            this.tableLayoutPanel1.Controls.Add(this.label5, 0, 0);
            this.tableLayoutPanel1.Controls.Add(this.label6, 0, 3);
            this.tableLayoutPanel1.Controls.Add(this.lblNumChannels, 1, 3);
            this.tableLayoutPanel1.Controls.Add(this.lblHVLabel, 2, 3);
            this.tableLayoutPanel1.Controls.Add(this.lblHV, 3, 3);
            this.tableLayoutPanel1.Controls.Add(this.label7, 0, 4);
            this.tableLayoutPanel1.Controls.Add(this.label8, 2, 4);
            this.tableLayoutPanel1.Controls.Add(this.lblCoarseGain, 1, 4);
            this.tableLayoutPanel1.Controls.Add(this.lblFineGain, 3, 4);
            this.tableLayoutPanel1.Controls.Add(this.label9, 0, 5);
            this.tableLayoutPanel1.Controls.Add(this.lblLLDULD, 1, 5);
            this.tableLayoutPanel1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.tableLayoutPanel1.Location = new System.Drawing.Point(0, 25);
            this.tableLayoutPanel1.Name = "tableLayoutPanel1";
            this.tableLayoutPanel1.RowCount = 7;
            this.tableLayoutPanel1.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 28F));
            this.tableLayoutPanel1.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 28F));
            this.tableLayoutPanel1.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 28F));
            this.tableLayoutPanel1.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 28F));
            this.tableLayoutPanel1.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 28F));
            this.tableLayoutPanel1.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 28F));
            this.tableLayoutPanel1.RowStyles.Add(new System.Windows.Forms.RowStyle());
            this.tableLayoutPanel1.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 20F));
            this.tableLayoutPanel1.Size = new System.Drawing.Size(738, 361);
            this.tableLayoutPanel1.TabIndex = 10;
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Dock = System.Windows.Forms.DockStyle.Fill;
            this.label3.Location = new System.Drawing.Point(3, 28);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(104, 28);
            this.label3.TabIndex = 10;
            this.label3.Text = "Detector";
            this.label3.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Dock = System.Windows.Forms.DockStyle.Fill;
            this.label4.Location = new System.Drawing.Point(371, 28);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(104, 28);
            this.label4.TabIndex = 11;
            this.label4.Text = "Livetime";
            this.label4.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.Dock = System.Windows.Forms.DockStyle.Fill;
            this.label5.Location = new System.Drawing.Point(3, 0);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(104, 28);
            this.label5.TabIndex = 12;
            this.label5.Text = "Session";
            this.label5.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // label6
            // 
            this.label6.AutoSize = true;
            this.label6.Dock = System.Windows.Forms.DockStyle.Fill;
            this.label6.Location = new System.Drawing.Point(3, 84);
            this.label6.Name = "label6";
            this.label6.Size = new System.Drawing.Size(104, 28);
            this.label6.TabIndex = 13;
            this.label6.Text = "Num channels";
            this.label6.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // lblNumChannels
            // 
            this.lblNumChannels.AutoSize = true;
            this.lblNumChannels.Dock = System.Windows.Forms.DockStyle.Fill;
            this.lblNumChannels.Location = new System.Drawing.Point(113, 84);
            this.lblNumChannels.Name = "lblNumChannels";
            this.lblNumChannels.Size = new System.Drawing.Size(252, 28);
            this.lblNumChannels.TabIndex = 14;
            this.lblNumChannels.Text = "<lblNumChannels>";
            this.lblNumChannels.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // lblHVLabel
            // 
            this.lblHVLabel.AutoSize = true;
            this.lblHVLabel.Dock = System.Windows.Forms.DockStyle.Fill;
            this.lblHVLabel.Location = new System.Drawing.Point(371, 84);
            this.lblHVLabel.Name = "lblHVLabel";
            this.lblHVLabel.Size = new System.Drawing.Size(104, 28);
            this.lblHVLabel.TabIndex = 15;
            this.lblHVLabel.Text = "HV";
            this.lblHVLabel.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // lblHV
            // 
            this.lblHV.AutoSize = true;
            this.lblHV.Dock = System.Windows.Forms.DockStyle.Fill;
            this.lblHV.Location = new System.Drawing.Point(481, 84);
            this.lblHV.Name = "lblHV";
            this.lblHV.Size = new System.Drawing.Size(254, 28);
            this.lblHV.TabIndex = 16;
            this.lblHV.Text = "<lblHV>";
            this.lblHV.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // label7
            // 
            this.label7.AutoSize = true;
            this.label7.Dock = System.Windows.Forms.DockStyle.Fill;
            this.label7.Location = new System.Drawing.Point(3, 112);
            this.label7.Name = "label7";
            this.label7.Size = new System.Drawing.Size(104, 28);
            this.label7.TabIndex = 17;
            this.label7.Text = "Coarse gain";
            this.label7.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // label8
            // 
            this.label8.AutoSize = true;
            this.label8.Dock = System.Windows.Forms.DockStyle.Fill;
            this.label8.Location = new System.Drawing.Point(371, 112);
            this.label8.Name = "label8";
            this.label8.Size = new System.Drawing.Size(104, 28);
            this.label8.TabIndex = 18;
            this.label8.Text = "Fine gain";
            this.label8.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // lblCoarseGain
            // 
            this.lblCoarseGain.AutoSize = true;
            this.lblCoarseGain.Dock = System.Windows.Forms.DockStyle.Fill;
            this.lblCoarseGain.Location = new System.Drawing.Point(113, 112);
            this.lblCoarseGain.Name = "lblCoarseGain";
            this.lblCoarseGain.Size = new System.Drawing.Size(252, 28);
            this.lblCoarseGain.TabIndex = 19;
            this.lblCoarseGain.Text = "<lblCoarseGain>";
            this.lblCoarseGain.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // lblFineGain
            // 
            this.lblFineGain.AutoSize = true;
            this.lblFineGain.Dock = System.Windows.Forms.DockStyle.Fill;
            this.lblFineGain.Location = new System.Drawing.Point(481, 112);
            this.lblFineGain.Name = "lblFineGain";
            this.lblFineGain.Size = new System.Drawing.Size(254, 28);
            this.lblFineGain.TabIndex = 20;
            this.lblFineGain.Text = "<lblFineGain>";
            this.lblFineGain.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // label9
            // 
            this.label9.AutoSize = true;
            this.label9.Dock = System.Windows.Forms.DockStyle.Fill;
            this.label9.Location = new System.Drawing.Point(3, 140);
            this.label9.Name = "label9";
            this.label9.Size = new System.Drawing.Size(104, 28);
            this.label9.TabIndex = 21;
            this.label9.Text = "LLD, ULD";
            this.label9.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // lblLLDULD
            // 
            this.lblLLDULD.AutoSize = true;
            this.lblLLDULD.Dock = System.Windows.Forms.DockStyle.Fill;
            this.lblLLDULD.Location = new System.Drawing.Point(113, 140);
            this.lblLLDULD.Name = "lblLLDULD";
            this.lblLLDULD.Size = new System.Drawing.Size(252, 28);
            this.lblLLDULD.TabIndex = 22;
            this.lblLLDULD.Text = "<lblLLDULD>";
            this.lblLLDULD.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // FormSessionInfo
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(738, 433);
            this.Controls.Add(this.tableLayoutPanel1);
            this.Controls.Add(this.panel1);
            this.Controls.Add(this.status);
            this.Controls.Add(this.tools);
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.MaximizeBox = false;
            this.MinimizeBox = false;
            this.Name = "FormSessionInfo";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterParent;
            this.Text = "Crash - Session Info";
            this.Load += new System.EventHandler(this.FormSessionInfo_Load);
            this.panel1.ResumeLayout(false);
            this.tableLayoutPanel1.ResumeLayout(false);
            this.tableLayoutPanel1.PerformLayout();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.ToolStrip tools;
        private System.Windows.Forms.StatusStrip status;
        private System.Windows.Forms.Panel panel1;
        private System.Windows.Forms.Button btnCancel;
        private System.Windows.Forms.Button btnOk;
        private System.Windows.Forms.TextBox tbComment;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Label lblName;
        private System.Windows.Forms.Label lblLivetime;
        private System.Windows.Forms.Label lblDetector;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.TextBox tbGEScript;
        private System.Windows.Forms.TableLayoutPanel tableLayoutPanel1;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.Label label5;
        private System.Windows.Forms.Label label6;
        private System.Windows.Forms.Label lblNumChannels;
        private System.Windows.Forms.Label lblHVLabel;
        private System.Windows.Forms.Label lblHV;
        private System.Windows.Forms.Label label7;
        private System.Windows.Forms.Label label8;
        private System.Windows.Forms.Label lblCoarseGain;
        private System.Windows.Forms.Label lblFineGain;
        private System.Windows.Forms.Label label9;
        private System.Windows.Forms.Label lblLLDULD;
    }
}