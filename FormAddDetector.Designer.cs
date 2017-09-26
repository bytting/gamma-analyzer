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
            this.tableParameters = new System.Windows.Forms.TableLayoutPanel();
            this.label1 = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.tbSerialnumber = new System.Windows.Forms.TextBox();
            this.label3 = new System.Windows.Forms.Label();
            this.cboxNumChannels = new System.Windows.Forms.ComboBox();
            this.label11 = new System.Windows.Forms.Label();
            this.label12 = new System.Windows.Forms.Label();
            this.label13 = new System.Windows.Forms.Label();
            this.label4 = new System.Windows.Forms.Label();
            this.label5 = new System.Windows.Forms.Label();
            this.label6 = new System.Windows.Forms.Label();
            this.tbFineGain = new System.Windows.Forms.TextBox();
            this.label8 = new System.Windows.Forms.Label();
            this.tbLivetime = new System.Windows.Forms.TextBox();
            this.label9 = new System.Windows.Forms.Label();
            this.tbLLD = new System.Windows.Forms.TextBox();
            this.label10 = new System.Windows.Forms.Label();
            this.tbULD = new System.Windows.Forms.TextBox();
            this.label7 = new System.Windows.Forms.Label();
            this.tbPluginName = new System.Windows.Forms.TextBox();
            this.label14 = new System.Windows.Forms.Label();
            this.tbMinHV = new System.Windows.Forms.TextBox();
            this.tbMaxHV = new System.Windows.Forms.TextBox();
            this.tbGEScript = new System.Windows.Forms.TextBox();
            this.tbTypeName = new System.Windows.Forms.TextBox();
            this.cboxMaxNumChannels = new System.Windows.Forms.ComboBox();
            this.tbHV = new System.Windows.Forms.TextBox();
            this.cboxCoarseGain = new System.Windows.Forms.ComboBox();
            this.panel1.SuspendLayout();
            this.tableParameters.SuspendLayout();
            this.SuspendLayout();
            // 
            // panel1
            // 
            this.panel1.Controls.Add(this.btnCancel);
            this.panel1.Controls.Add(this.btnOk);
            this.panel1.Dock = System.Windows.Forms.DockStyle.Bottom;
            this.panel1.Location = new System.Drawing.Point(0, 508);
            this.panel1.Name = "panel1";
            this.panel1.Size = new System.Drawing.Size(610, 30);
            this.panel1.TabIndex = 0;
            // 
            // btnCancel
            // 
            this.btnCancel.DialogResult = System.Windows.Forms.DialogResult.Cancel;
            this.btnCancel.Dock = System.Windows.Forms.DockStyle.Right;
            this.btnCancel.Location = new System.Drawing.Point(376, 0);
            this.btnCancel.Name = "btnCancel";
            this.btnCancel.Size = new System.Drawing.Size(117, 30);
            this.btnCancel.TabIndex = 1;
            this.btnCancel.Text = "Cancel";
            this.btnCancel.UseVisualStyleBackColor = true;
            this.btnCancel.Click += new System.EventHandler(this.btnCancel_Click);
            // 
            // btnOk
            // 
            this.btnOk.DialogResult = System.Windows.Forms.DialogResult.OK;
            this.btnOk.Dock = System.Windows.Forms.DockStyle.Right;
            this.btnOk.Location = new System.Drawing.Point(493, 0);
            this.btnOk.Name = "btnOk";
            this.btnOk.Size = new System.Drawing.Size(117, 30);
            this.btnOk.TabIndex = 0;
            this.btnOk.Text = "Ok";
            this.btnOk.UseVisualStyleBackColor = true;
            this.btnOk.Click += new System.EventHandler(this.btnOk_Click);
            // 
            // tableParameters
            // 
            this.tableParameters.ColumnCount = 2;
            this.tableParameters.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Absolute, 170F));
            this.tableParameters.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle());
            this.tableParameters.Controls.Add(this.label1, 0, 2);
            this.tableParameters.Controls.Add(this.label2, 0, 1);
            this.tableParameters.Controls.Add(this.tbSerialnumber, 1, 2);
            this.tableParameters.Controls.Add(this.label3, 0, 4);
            this.tableParameters.Controls.Add(this.cboxNumChannels, 1, 4);
            this.tableParameters.Controls.Add(this.label11, 0, 3);
            this.tableParameters.Controls.Add(this.label12, 0, 5);
            this.tableParameters.Controls.Add(this.label13, 0, 6);
            this.tableParameters.Controls.Add(this.label4, 0, 7);
            this.tableParameters.Controls.Add(this.label5, 0, 8);
            this.tableParameters.Controls.Add(this.label6, 0, 9);
            this.tableParameters.Controls.Add(this.tbFineGain, 1, 9);
            this.tableParameters.Controls.Add(this.label8, 0, 10);
            this.tableParameters.Controls.Add(this.tbLivetime, 1, 10);
            this.tableParameters.Controls.Add(this.label9, 0, 11);
            this.tableParameters.Controls.Add(this.tbLLD, 1, 11);
            this.tableParameters.Controls.Add(this.label10, 0, 12);
            this.tableParameters.Controls.Add(this.tbULD, 1, 12);
            this.tableParameters.Controls.Add(this.label7, 0, 13);
            this.tableParameters.Controls.Add(this.tbPluginName, 1, 13);
            this.tableParameters.Controls.Add(this.label14, 0, 14);
            this.tableParameters.Controls.Add(this.tbMinHV, 1, 5);
            this.tableParameters.Controls.Add(this.tbMaxHV, 1, 6);
            this.tableParameters.Controls.Add(this.tbGEScript, 1, 14);
            this.tableParameters.Controls.Add(this.tbTypeName, 1, 1);
            this.tableParameters.Controls.Add(this.cboxMaxNumChannels, 1, 3);
            this.tableParameters.Controls.Add(this.tbHV, 1, 7);
            this.tableParameters.Controls.Add(this.cboxCoarseGain, 1, 8);
            this.tableParameters.Dock = System.Windows.Forms.DockStyle.Fill;
            this.tableParameters.Location = new System.Drawing.Point(0, 0);
            this.tableParameters.Name = "tableParameters";
            this.tableParameters.RowCount = 16;
            this.tableParameters.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 26F));
            this.tableParameters.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 32F));
            this.tableParameters.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 32F));
            this.tableParameters.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 32F));
            this.tableParameters.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 32F));
            this.tableParameters.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 32F));
            this.tableParameters.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 32F));
            this.tableParameters.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 32F));
            this.tableParameters.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 32F));
            this.tableParameters.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 32F));
            this.tableParameters.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 32F));
            this.tableParameters.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 32F));
            this.tableParameters.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 32F));
            this.tableParameters.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 32F));
            this.tableParameters.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 32F));
            this.tableParameters.RowStyles.Add(new System.Windows.Forms.RowStyle());
            this.tableParameters.Size = new System.Drawing.Size(610, 508);
            this.tableParameters.TabIndex = 1;
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(3, 58);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(82, 15);
            this.label1.TabIndex = 0;
            this.label1.Text = "Serialnumber";
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(3, 26);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(78, 15);
            this.label2.TabIndex = 1;
            this.label2.Text = "Detector type";
            // 
            // tbSerialnumber
            // 
            this.tbSerialnumber.Dock = System.Windows.Forms.DockStyle.Fill;
            this.tbSerialnumber.Location = new System.Drawing.Point(173, 61);
            this.tbSerialnumber.Name = "tbSerialnumber";
            this.tbSerialnumber.Size = new System.Drawing.Size(434, 21);
            this.tbSerialnumber.TabIndex = 12;
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(3, 122);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(91, 15);
            this.label3.TabIndex = 3;
            this.label3.Text = "Num. channels";
            // 
            // cboxNumChannels
            // 
            this.cboxNumChannels.Dock = System.Windows.Forms.DockStyle.Fill;
            this.cboxNumChannels.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cboxNumChannels.FormattingEnabled = true;
            this.cboxNumChannels.Location = new System.Drawing.Point(173, 125);
            this.cboxNumChannels.Name = "cboxNumChannels";
            this.cboxNumChannels.Size = new System.Drawing.Size(434, 23);
            this.cboxNumChannels.TabIndex = 11;
            // 
            // label11
            // 
            this.label11.AutoSize = true;
            this.label11.Location = new System.Drawing.Point(3, 90);
            this.label11.Name = "label11";
            this.label11.Size = new System.Drawing.Size(113, 15);
            this.label11.TabIndex = 23;
            this.label11.Text = "Max num. channels";
            // 
            // label12
            // 
            this.label12.AutoSize = true;
            this.label12.Location = new System.Drawing.Point(3, 154);
            this.label12.Name = "label12";
            this.label12.Size = new System.Drawing.Size(68, 15);
            this.label12.TabIndex = 24;
            this.label12.Text = "Min voltage";
            // 
            // label13
            // 
            this.label13.AutoSize = true;
            this.label13.Location = new System.Drawing.Point(3, 186);
            this.label13.Name = "label13";
            this.label13.Size = new System.Drawing.Size(70, 15);
            this.label13.TabIndex = 25;
            this.label13.Text = "Max voltage";
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Location = new System.Drawing.Point(3, 218);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(47, 15);
            this.label4.TabIndex = 4;
            this.label4.Text = "Voltage";
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.Location = new System.Drawing.Point(3, 250);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(75, 15);
            this.label5.TabIndex = 5;
            this.label5.Text = "Coarse gain";
            // 
            // label6
            // 
            this.label6.AutoSize = true;
            this.label6.Location = new System.Drawing.Point(3, 282);
            this.label6.Name = "label6";
            this.label6.Size = new System.Drawing.Size(58, 15);
            this.label6.TabIndex = 6;
            this.label6.Text = "Fine gain";
            // 
            // tbFineGain
            // 
            this.tbFineGain.Dock = System.Windows.Forms.DockStyle.Fill;
            this.tbFineGain.Location = new System.Drawing.Point(173, 285);
            this.tbFineGain.Name = "tbFineGain";
            this.tbFineGain.Size = new System.Drawing.Size(434, 21);
            this.tbFineGain.TabIndex = 15;
            // 
            // label8
            // 
            this.label8.AutoSize = true;
            this.label8.Location = new System.Drawing.Point(3, 314);
            this.label8.Name = "label8";
            this.label8.Size = new System.Drawing.Size(87, 15);
            this.label8.TabIndex = 8;
            this.label8.Text = "Livetime (sec.)";
            // 
            // tbLivetime
            // 
            this.tbLivetime.Dock = System.Windows.Forms.DockStyle.Fill;
            this.tbLivetime.Location = new System.Drawing.Point(173, 317);
            this.tbLivetime.Name = "tbLivetime";
            this.tbLivetime.Size = new System.Drawing.Size(434, 21);
            this.tbLivetime.TabIndex = 17;
            // 
            // label9
            // 
            this.label9.AutoSize = true;
            this.label9.Location = new System.Drawing.Point(3, 346);
            this.label9.Name = "label9";
            this.label9.Size = new System.Drawing.Size(30, 15);
            this.label9.TabIndex = 9;
            this.label9.Text = "LLD";
            // 
            // tbLLD
            // 
            this.tbLLD.Dock = System.Windows.Forms.DockStyle.Fill;
            this.tbLLD.Location = new System.Drawing.Point(173, 349);
            this.tbLLD.Name = "tbLLD";
            this.tbLLD.Size = new System.Drawing.Size(434, 21);
            this.tbLLD.TabIndex = 18;
            // 
            // label10
            // 
            this.label10.AutoSize = true;
            this.label10.Location = new System.Drawing.Point(3, 378);
            this.label10.Name = "label10";
            this.label10.Size = new System.Drawing.Size(32, 15);
            this.label10.TabIndex = 10;
            this.label10.Text = "ULD";
            // 
            // tbULD
            // 
            this.tbULD.Dock = System.Windows.Forms.DockStyle.Fill;
            this.tbULD.Location = new System.Drawing.Point(173, 381);
            this.tbULD.Name = "tbULD";
            this.tbULD.Size = new System.Drawing.Size(434, 21);
            this.tbULD.TabIndex = 19;
            // 
            // label7
            // 
            this.label7.AutoSize = true;
            this.label7.Location = new System.Drawing.Point(3, 410);
            this.label7.Name = "label7";
            this.label7.Size = new System.Drawing.Size(77, 15);
            this.label7.TabIndex = 21;
            this.label7.Text = "Plugin name";
            // 
            // tbPluginName
            // 
            this.tbPluginName.Dock = System.Windows.Forms.DockStyle.Fill;
            this.tbPluginName.Location = new System.Drawing.Point(173, 413);
            this.tbPluginName.Name = "tbPluginName";
            this.tbPluginName.Size = new System.Drawing.Size(434, 21);
            this.tbPluginName.TabIndex = 22;
            // 
            // label14
            // 
            this.label14.AutoSize = true;
            this.label14.Location = new System.Drawing.Point(3, 442);
            this.label14.Name = "label14";
            this.label14.Size = new System.Drawing.Size(58, 15);
            this.label14.TabIndex = 26;
            this.label14.Text = "GE Script";
            // 
            // tbMinHV
            // 
            this.tbMinHV.Dock = System.Windows.Forms.DockStyle.Fill;
            this.tbMinHV.Location = new System.Drawing.Point(173, 157);
            this.tbMinHV.Name = "tbMinHV";
            this.tbMinHV.Size = new System.Drawing.Size(434, 21);
            this.tbMinHV.TabIndex = 29;
            // 
            // tbMaxHV
            // 
            this.tbMaxHV.Dock = System.Windows.Forms.DockStyle.Fill;
            this.tbMaxHV.Location = new System.Drawing.Point(173, 189);
            this.tbMaxHV.Name = "tbMaxHV";
            this.tbMaxHV.Size = new System.Drawing.Size(434, 21);
            this.tbMaxHV.TabIndex = 30;
            // 
            // tbGEScript
            // 
            this.tbGEScript.Dock = System.Windows.Forms.DockStyle.Fill;
            this.tbGEScript.Location = new System.Drawing.Point(173, 445);
            this.tbGEScript.Name = "tbGEScript";
            this.tbGEScript.Size = new System.Drawing.Size(434, 21);
            this.tbGEScript.TabIndex = 31;
            // 
            // tbTypeName
            // 
            this.tbTypeName.Dock = System.Windows.Forms.DockStyle.Fill;
            this.tbTypeName.Location = new System.Drawing.Point(173, 29);
            this.tbTypeName.Name = "tbTypeName";
            this.tbTypeName.Size = new System.Drawing.Size(434, 21);
            this.tbTypeName.TabIndex = 32;
            // 
            // cboxMaxNumChannels
            // 
            this.cboxMaxNumChannels.Dock = System.Windows.Forms.DockStyle.Fill;
            this.cboxMaxNumChannels.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cboxMaxNumChannels.FormattingEnabled = true;
            this.cboxMaxNumChannels.Items.AddRange(new object[] {
            ""});
            this.cboxMaxNumChannels.Location = new System.Drawing.Point(173, 93);
            this.cboxMaxNumChannels.Name = "cboxMaxNumChannels";
            this.cboxMaxNumChannels.Size = new System.Drawing.Size(434, 23);
            this.cboxMaxNumChannels.TabIndex = 33;
            this.cboxMaxNumChannels.SelectedIndexChanged += new System.EventHandler(this.cboxMaxNumChannels_SelectedIndexChanged);
            // 
            // tbHV
            // 
            this.tbHV.Dock = System.Windows.Forms.DockStyle.Fill;
            this.tbHV.Location = new System.Drawing.Point(173, 221);
            this.tbHV.Name = "tbHV";
            this.tbHV.Size = new System.Drawing.Size(434, 21);
            this.tbHV.TabIndex = 34;
            // 
            // cboxCoarseGain
            // 
            this.cboxCoarseGain.Dock = System.Windows.Forms.DockStyle.Fill;
            this.cboxCoarseGain.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cboxCoarseGain.FormattingEnabled = true;
            this.cboxCoarseGain.Items.AddRange(new object[] {
            "1",
            "2",
            "4",
            "8"});
            this.cboxCoarseGain.Location = new System.Drawing.Point(173, 253);
            this.cboxCoarseGain.Name = "cboxCoarseGain";
            this.cboxCoarseGain.Size = new System.Drawing.Size(434, 23);
            this.cboxCoarseGain.TabIndex = 35;
            // 
            // FormAddDetector
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(7F, 15F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(610, 538);
            this.Controls.Add(this.tableParameters);
            this.Controls.Add(this.panel1);
            this.Font = new System.Drawing.Font("Arial", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedSingle;
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.MaximizeBox = false;
            this.MinimizeBox = false;
            this.Name = "FormAddDetector";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterParent;
            this.Text = "Gamma Analyzer - Add Detector";
            this.Load += new System.EventHandler(this.FormAddDetector_Load);
            this.panel1.ResumeLayout(false);
            this.tableParameters.ResumeLayout(false);
            this.tableParameters.PerformLayout();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.Panel panel1;
        private System.Windows.Forms.TableLayoutPanel tableParameters;
        private System.Windows.Forms.Button btnCancel;
        private System.Windows.Forms.Button btnOk;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.Label label5;
        private System.Windows.Forms.Label label6;
        private System.Windows.Forms.Label label8;
        private System.Windows.Forms.Label label9;
        private System.Windows.Forms.Label label10;
        private System.Windows.Forms.ComboBox cboxNumChannels;
        private System.Windows.Forms.TextBox tbSerialnumber;
        private System.Windows.Forms.TextBox tbFineGain;
        private System.Windows.Forms.TextBox tbLivetime;
        private System.Windows.Forms.TextBox tbLLD;
        private System.Windows.Forms.TextBox tbULD;
        private System.Windows.Forms.Label label7;
        private System.Windows.Forms.TextBox tbPluginName;
        private System.Windows.Forms.Label label11;
        private System.Windows.Forms.Label label12;
        private System.Windows.Forms.Label label13;
        private System.Windows.Forms.Label label14;
        private System.Windows.Forms.TextBox tbMinHV;
        private System.Windows.Forms.TextBox tbMaxHV;
        private System.Windows.Forms.TextBox tbGEScript;
        private System.Windows.Forms.TextBox tbTypeName;
        private System.Windows.Forms.ComboBox cboxMaxNumChannels;
        private System.Windows.Forms.TextBox tbHV;
        private System.Windows.Forms.ComboBox cboxCoarseGain;
    }
}