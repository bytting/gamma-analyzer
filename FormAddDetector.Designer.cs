namespace crash
{
    partial class FormAddDetector
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(FormAddDetector));
            this.panel1 = new System.Windows.Forms.Panel();
            this.btnCancel = new System.Windows.Forms.Button();
            this.btnOk = new System.Windows.Forms.Button();
            this.tableLayoutPanel1 = new System.Windows.Forms.TableLayoutPanel();
            this.label1 = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.cboxDetectorTypes = new System.Windows.Forms.ComboBox();
            this.label3 = new System.Windows.Forms.Label();
            this.label4 = new System.Windows.Forms.Label();
            this.label5 = new System.Windows.Forms.Label();
            this.label6 = new System.Windows.Forms.Label();
            this.label8 = new System.Windows.Forms.Label();
            this.label9 = new System.Windows.Forms.Label();
            this.label10 = new System.Windows.Forms.Label();
            this.cboxNumChannels = new System.Windows.Forms.ComboBox();
            this.tbSerialnumber = new System.Windows.Forms.TextBox();
            this.tbCoarseGain = new System.Windows.Forms.TextBox();
            this.tbFineGain = new System.Windows.Forms.TextBox();
            this.tbLivetime = new System.Windows.Forms.TextBox();
            this.tbLLD = new System.Windows.Forms.TextBox();
            this.tbULD = new System.Windows.Forms.TextBox();
            this.panel2 = new System.Windows.Forms.Panel();
            this.tbarCurrHV = new System.Windows.Forms.TrackBar();
            this.lblCurrHV = new System.Windows.Forms.Label();
            this.panel1.SuspendLayout();
            this.tableLayoutPanel1.SuspendLayout();
            this.panel2.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.tbarCurrHV)).BeginInit();
            this.SuspendLayout();
            // 
            // panel1
            // 
            this.panel1.Controls.Add(this.btnCancel);
            this.panel1.Controls.Add(this.btnOk);
            this.panel1.Dock = System.Windows.Forms.DockStyle.Bottom;
            this.panel1.Location = new System.Drawing.Point(0, 349);
            this.panel1.Name = "panel1";
            this.panel1.Size = new System.Drawing.Size(405, 27);
            this.panel1.TabIndex = 0;
            // 
            // btnCancel
            // 
            this.btnCancel.DialogResult = System.Windows.Forms.DialogResult.Cancel;
            this.btnCancel.Dock = System.Windows.Forms.DockStyle.Right;
            this.btnCancel.Location = new System.Drawing.Point(255, 0);
            this.btnCancel.Name = "btnCancel";
            this.btnCancel.Size = new System.Drawing.Size(75, 27);
            this.btnCancel.TabIndex = 1;
            this.btnCancel.Text = "Cancel";
            this.btnCancel.UseVisualStyleBackColor = true;
            this.btnCancel.Click += new System.EventHandler(this.btnCancel_Click);
            // 
            // btnOk
            // 
            this.btnOk.DialogResult = System.Windows.Forms.DialogResult.OK;
            this.btnOk.Dock = System.Windows.Forms.DockStyle.Right;
            this.btnOk.Location = new System.Drawing.Point(330, 0);
            this.btnOk.Name = "btnOk";
            this.btnOk.Size = new System.Drawing.Size(75, 27);
            this.btnOk.TabIndex = 0;
            this.btnOk.Text = "Ok";
            this.btnOk.UseVisualStyleBackColor = true;
            this.btnOk.Click += new System.EventHandler(this.btnOk_Click);
            // 
            // tableLayoutPanel1
            // 
            this.tableLayoutPanel1.ColumnCount = 2;
            this.tableLayoutPanel1.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 40F));
            this.tableLayoutPanel1.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 60F));
            this.tableLayoutPanel1.Controls.Add(this.label1, 0, 2);
            this.tableLayoutPanel1.Controls.Add(this.label2, 0, 1);
            this.tableLayoutPanel1.Controls.Add(this.cboxDetectorTypes, 1, 1);
            this.tableLayoutPanel1.Controls.Add(this.label3, 0, 3);
            this.tableLayoutPanel1.Controls.Add(this.label4, 0, 4);
            this.tableLayoutPanel1.Controls.Add(this.label5, 0, 5);
            this.tableLayoutPanel1.Controls.Add(this.label6, 0, 6);
            this.tableLayoutPanel1.Controls.Add(this.label8, 0, 7);
            this.tableLayoutPanel1.Controls.Add(this.label9, 0, 8);
            this.tableLayoutPanel1.Controls.Add(this.label10, 0, 9);
            this.tableLayoutPanel1.Controls.Add(this.cboxNumChannels, 1, 3);
            this.tableLayoutPanel1.Controls.Add(this.tbSerialnumber, 1, 2);
            this.tableLayoutPanel1.Controls.Add(this.tbCoarseGain, 1, 5);
            this.tableLayoutPanel1.Controls.Add(this.tbFineGain, 1, 6);
            this.tableLayoutPanel1.Controls.Add(this.tbLivetime, 1, 7);
            this.tableLayoutPanel1.Controls.Add(this.tbLLD, 1, 8);
            this.tableLayoutPanel1.Controls.Add(this.tbULD, 1, 9);
            this.tableLayoutPanel1.Controls.Add(this.panel2, 1, 4);
            this.tableLayoutPanel1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.tableLayoutPanel1.Location = new System.Drawing.Point(0, 0);
            this.tableLayoutPanel1.Name = "tableLayoutPanel1";
            this.tableLayoutPanel1.RowCount = 11;
            this.tableLayoutPanel1.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 32F));
            this.tableLayoutPanel1.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 32F));
            this.tableLayoutPanel1.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 32F));
            this.tableLayoutPanel1.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 32F));
            this.tableLayoutPanel1.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 32F));
            this.tableLayoutPanel1.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 32F));
            this.tableLayoutPanel1.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 32F));
            this.tableLayoutPanel1.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 32F));
            this.tableLayoutPanel1.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 32F));
            this.tableLayoutPanel1.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 32F));
            this.tableLayoutPanel1.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 32F));
            this.tableLayoutPanel1.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 20F));
            this.tableLayoutPanel1.Size = new System.Drawing.Size(405, 349);
            this.tableLayoutPanel1.TabIndex = 1;
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(3, 64);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(68, 13);
            this.label1.TabIndex = 0;
            this.label1.Text = "Serialnumber";
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(3, 32);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(71, 13);
            this.label2.TabIndex = 1;
            this.label2.Text = "Detector type";
            // 
            // cboxDetectorTypes
            // 
            this.cboxDetectorTypes.Dock = System.Windows.Forms.DockStyle.Fill;
            this.cboxDetectorTypes.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cboxDetectorTypes.FormattingEnabled = true;
            this.cboxDetectorTypes.Location = new System.Drawing.Point(165, 35);
            this.cboxDetectorTypes.Name = "cboxDetectorTypes";
            this.cboxDetectorTypes.Size = new System.Drawing.Size(237, 21);
            this.cboxDetectorTypes.TabIndex = 2;
            this.cboxDetectorTypes.SelectedIndexChanged += new System.EventHandler(this.cboxDetectorTypes_SelectedIndexChanged);
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(3, 96);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(137, 13);
            this.label3.TabIndex = 3;
            this.label3.Text = "Current number of channels";
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Location = new System.Drawing.Point(3, 128);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(59, 13);
            this.label4.TabIndex = 4;
            this.label4.Text = "Current HV";
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.Location = new System.Drawing.Point(3, 160);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(99, 13);
            this.label5.TabIndex = 5;
            this.label5.Text = "Current coarse gain";
            // 
            // label6
            // 
            this.label6.AutoSize = true;
            this.label6.Location = new System.Drawing.Point(3, 192);
            this.label6.Name = "label6";
            this.label6.Size = new System.Drawing.Size(84, 13);
            this.label6.TabIndex = 6;
            this.label6.Text = "Current fine gain";
            // 
            // label8
            // 
            this.label8.AutoSize = true;
            this.label8.Location = new System.Drawing.Point(3, 224);
            this.label8.Name = "label8";
            this.label8.Size = new System.Drawing.Size(108, 13);
            this.label8.TabIndex = 8;
            this.label8.Text = "Current livetime (sec.)";
            // 
            // label9
            // 
            this.label9.AutoSize = true;
            this.label9.Location = new System.Drawing.Point(3, 256);
            this.label9.Name = "label9";
            this.label9.Size = new System.Drawing.Size(64, 13);
            this.label9.TabIndex = 9;
            this.label9.Text = "Current LLD";
            // 
            // label10
            // 
            this.label10.AutoSize = true;
            this.label10.Location = new System.Drawing.Point(3, 288);
            this.label10.Name = "label10";
            this.label10.Size = new System.Drawing.Size(66, 13);
            this.label10.TabIndex = 10;
            this.label10.Text = "Current ULD";
            // 
            // cboxNumChannels
            // 
            this.cboxNumChannels.Dock = System.Windows.Forms.DockStyle.Fill;
            this.cboxNumChannels.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cboxNumChannels.FormattingEnabled = true;
            this.cboxNumChannels.Location = new System.Drawing.Point(165, 99);
            this.cboxNumChannels.Name = "cboxNumChannels";
            this.cboxNumChannels.Size = new System.Drawing.Size(237, 21);
            this.cboxNumChannels.TabIndex = 11;
            // 
            // tbSerialnumber
            // 
            this.tbSerialnumber.Dock = System.Windows.Forms.DockStyle.Fill;
            this.tbSerialnumber.Location = new System.Drawing.Point(165, 67);
            this.tbSerialnumber.Name = "tbSerialnumber";
            this.tbSerialnumber.Size = new System.Drawing.Size(237, 20);
            this.tbSerialnumber.TabIndex = 12;
            // 
            // tbCoarseGain
            // 
            this.tbCoarseGain.Dock = System.Windows.Forms.DockStyle.Fill;
            this.tbCoarseGain.Location = new System.Drawing.Point(165, 163);
            this.tbCoarseGain.Name = "tbCoarseGain";
            this.tbCoarseGain.Size = new System.Drawing.Size(237, 20);
            this.tbCoarseGain.TabIndex = 14;
            // 
            // tbFineGain
            // 
            this.tbFineGain.Dock = System.Windows.Forms.DockStyle.Fill;
            this.tbFineGain.Location = new System.Drawing.Point(165, 195);
            this.tbFineGain.Name = "tbFineGain";
            this.tbFineGain.Size = new System.Drawing.Size(237, 20);
            this.tbFineGain.TabIndex = 15;
            // 
            // tbLivetime
            // 
            this.tbLivetime.Dock = System.Windows.Forms.DockStyle.Fill;
            this.tbLivetime.Location = new System.Drawing.Point(165, 227);
            this.tbLivetime.Name = "tbLivetime";
            this.tbLivetime.Size = new System.Drawing.Size(237, 20);
            this.tbLivetime.TabIndex = 17;
            // 
            // tbLLD
            // 
            this.tbLLD.Dock = System.Windows.Forms.DockStyle.Fill;
            this.tbLLD.Location = new System.Drawing.Point(165, 259);
            this.tbLLD.Name = "tbLLD";
            this.tbLLD.Size = new System.Drawing.Size(237, 20);
            this.tbLLD.TabIndex = 18;
            // 
            // tbULD
            // 
            this.tbULD.Dock = System.Windows.Forms.DockStyle.Fill;
            this.tbULD.Location = new System.Drawing.Point(165, 291);
            this.tbULD.Name = "tbULD";
            this.tbULD.Size = new System.Drawing.Size(237, 20);
            this.tbULD.TabIndex = 19;
            // 
            // panel2
            // 
            this.panel2.Controls.Add(this.tbarCurrHV);
            this.panel2.Controls.Add(this.lblCurrHV);
            this.panel2.Dock = System.Windows.Forms.DockStyle.Fill;
            this.panel2.Location = new System.Drawing.Point(165, 131);
            this.panel2.Name = "panel2";
            this.panel2.Size = new System.Drawing.Size(237, 26);
            this.panel2.TabIndex = 20;
            // 
            // tbarCurrHV
            // 
            this.tbarCurrHV.Dock = System.Windows.Forms.DockStyle.Fill;
            this.tbarCurrHV.Location = new System.Drawing.Point(0, 0);
            this.tbarCurrHV.Name = "tbarCurrHV";
            this.tbarCurrHV.Size = new System.Drawing.Size(224, 26);
            this.tbarCurrHV.TabIndex = 1;
            this.tbarCurrHV.TickStyle = System.Windows.Forms.TickStyle.None;
            this.tbarCurrHV.ValueChanged += new System.EventHandler(this.tbarCurrHV_ValueChanged);
            // 
            // lblCurrHV
            // 
            this.lblCurrHV.AutoSize = true;
            this.lblCurrHV.Dock = System.Windows.Forms.DockStyle.Right;
            this.lblCurrHV.Location = new System.Drawing.Point(224, 0);
            this.lblCurrHV.Name = "lblCurrHV";
            this.lblCurrHV.Size = new System.Drawing.Size(13, 13);
            this.lblCurrHV.TabIndex = 0;
            this.lblCurrHV.Text = "1";
            // 
            // FormAddDetector
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(405, 376);
            this.Controls.Add(this.tableLayoutPanel1);
            this.Controls.Add(this.panel1);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedSingle;
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.MaximizeBox = false;
            this.MinimizeBox = false;
            this.Name = "FormAddDetector";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterParent;
            this.Text = "Gamma Analyzer - Add Detector";
            this.Load += new System.EventHandler(this.FormAddDetector_Load);
            this.panel1.ResumeLayout(false);
            this.tableLayoutPanel1.ResumeLayout(false);
            this.tableLayoutPanel1.PerformLayout();
            this.panel2.ResumeLayout(false);
            this.panel2.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.tbarCurrHV)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.Panel panel1;
        private System.Windows.Forms.TableLayoutPanel tableLayoutPanel1;
        private System.Windows.Forms.Button btnCancel;
        private System.Windows.Forms.Button btnOk;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.ComboBox cboxDetectorTypes;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.Label label5;
        private System.Windows.Forms.Label label6;
        private System.Windows.Forms.Label label8;
        private System.Windows.Forms.Label label9;
        private System.Windows.Forms.Label label10;
        private System.Windows.Forms.ComboBox cboxNumChannels;
        private System.Windows.Forms.TextBox tbSerialnumber;
        private System.Windows.Forms.TextBox tbCoarseGain;
        private System.Windows.Forms.TextBox tbFineGain;
        private System.Windows.Forms.TextBox tbLivetime;
        private System.Windows.Forms.TextBox tbLLD;
        private System.Windows.Forms.TextBox tbULD;
        private System.Windows.Forms.Panel panel2;
        private System.Windows.Forms.TrackBar tbarCurrHV;
        private System.Windows.Forms.Label lblCurrHV;
    }
}