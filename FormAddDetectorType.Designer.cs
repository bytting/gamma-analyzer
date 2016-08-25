namespace crash
{
    partial class FormAddDetectorType
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(FormAddDetectorType));
            this.panel1 = new System.Windows.Forms.Panel();
            this.btnCancel = new System.Windows.Forms.Button();
            this.btnOk = new System.Windows.Forms.Button();
            this.tableLayoutPanel1 = new System.Windows.Forms.TableLayoutPanel();
            this.label1 = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.label3 = new System.Windows.Forms.Label();
            this.label4 = new System.Windows.Forms.Label();
            this.tbName = new System.Windows.Forms.TextBox();
            this.label5 = new System.Windows.Forms.Label();
            this.panel2 = new System.Windows.Forms.Panel();
            this.tbGScript = new System.Windows.Forms.TextBox();
            this.btnBrowseGScript = new System.Windows.Forms.Button();
            this.cboxMaxChannels = new System.Windows.Forms.ComboBox();
            this.panel3 = new System.Windows.Forms.Panel();
            this.tbarMinHV = new System.Windows.Forms.TrackBar();
            this.lblMinHV = new System.Windows.Forms.Label();
            this.panel4 = new System.Windows.Forms.Panel();
            this.tbarMaxHV = new System.Windows.Forms.TrackBar();
            this.lblMaxHV = new System.Windows.Forms.Label();
            this.panel1.SuspendLayout();
            this.tableLayoutPanel1.SuspendLayout();
            this.panel2.SuspendLayout();
            this.panel3.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.tbarMinHV)).BeginInit();
            this.panel4.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.tbarMaxHV)).BeginInit();
            this.SuspendLayout();
            // 
            // panel1
            // 
            this.panel1.Controls.Add(this.btnCancel);
            this.panel1.Controls.Add(this.btnOk);
            this.panel1.Dock = System.Windows.Forms.DockStyle.Bottom;
            this.panel1.Location = new System.Drawing.Point(0, 193);
            this.panel1.Name = "panel1";
            this.panel1.Size = new System.Drawing.Size(507, 30);
            this.panel1.TabIndex = 0;
            // 
            // btnCancel
            // 
            this.btnCancel.DialogResult = System.Windows.Forms.DialogResult.Cancel;
            this.btnCancel.Dock = System.Windows.Forms.DockStyle.Right;
            this.btnCancel.Location = new System.Drawing.Point(357, 0);
            this.btnCancel.Name = "btnCancel";
            this.btnCancel.Size = new System.Drawing.Size(75, 30);
            this.btnCancel.TabIndex = 1;
            this.btnCancel.Text = "Cancel";
            this.btnCancel.UseVisualStyleBackColor = true;
            this.btnCancel.Click += new System.EventHandler(this.btnCancel_Click);
            // 
            // btnOk
            // 
            this.btnOk.DialogResult = System.Windows.Forms.DialogResult.OK;
            this.btnOk.Dock = System.Windows.Forms.DockStyle.Right;
            this.btnOk.Location = new System.Drawing.Point(432, 0);
            this.btnOk.Name = "btnOk";
            this.btnOk.Size = new System.Drawing.Size(75, 30);
            this.btnOk.TabIndex = 0;
            this.btnOk.Text = "Ok";
            this.btnOk.UseVisualStyleBackColor = true;
            this.btnOk.Click += new System.EventHandler(this.btnOk_Click);
            // 
            // tableLayoutPanel1
            // 
            this.tableLayoutPanel1.ColumnCount = 2;
            this.tableLayoutPanel1.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 25F));
            this.tableLayoutPanel1.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 75F));
            this.tableLayoutPanel1.Controls.Add(this.label1, 0, 1);
            this.tableLayoutPanel1.Controls.Add(this.label2, 0, 2);
            this.tableLayoutPanel1.Controls.Add(this.label3, 0, 3);
            this.tableLayoutPanel1.Controls.Add(this.label4, 0, 4);
            this.tableLayoutPanel1.Controls.Add(this.tbName, 1, 1);
            this.tableLayoutPanel1.Controls.Add(this.label5, 0, 5);
            this.tableLayoutPanel1.Controls.Add(this.panel2, 1, 5);
            this.tableLayoutPanel1.Controls.Add(this.cboxMaxChannels, 1, 2);
            this.tableLayoutPanel1.Controls.Add(this.panel3, 1, 3);
            this.tableLayoutPanel1.Controls.Add(this.panel4, 1, 4);
            this.tableLayoutPanel1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.tableLayoutPanel1.Location = new System.Drawing.Point(0, 0);
            this.tableLayoutPanel1.Name = "tableLayoutPanel1";
            this.tableLayoutPanel1.RowCount = 7;
            this.tableLayoutPanel1.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 28F));
            this.tableLayoutPanel1.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 28F));
            this.tableLayoutPanel1.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 28F));
            this.tableLayoutPanel1.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 28F));
            this.tableLayoutPanel1.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 28F));
            this.tableLayoutPanel1.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 28F));
            this.tableLayoutPanel1.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 20F));
            this.tableLayoutPanel1.Size = new System.Drawing.Size(507, 193);
            this.tableLayoutPanel1.TabIndex = 1;
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(3, 28);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(35, 13);
            this.label1.TabIndex = 0;
            this.label1.Text = "Name";
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(3, 56);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(73, 13);
            this.label2.TabIndex = 1;
            this.label2.Text = "Max channels";
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(3, 84);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(42, 13);
            this.label3.TabIndex = 2;
            this.label3.Text = "Min HV";
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Location = new System.Drawing.Point(3, 112);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(45, 13);
            this.label4.TabIndex = 3;
            this.label4.Text = "Max HV";
            // 
            // tbName
            // 
            this.tbName.Dock = System.Windows.Forms.DockStyle.Fill;
            this.tbName.Location = new System.Drawing.Point(129, 31);
            this.tbName.Name = "tbName";
            this.tbName.Size = new System.Drawing.Size(375, 20);
            this.tbName.TabIndex = 4;
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.Location = new System.Drawing.Point(3, 140);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(43, 13);
            this.label5.TabIndex = 8;
            this.label5.Text = "G script";
            // 
            // panel2
            // 
            this.panel2.Controls.Add(this.tbGScript);
            this.panel2.Controls.Add(this.btnBrowseGScript);
            this.panel2.Dock = System.Windows.Forms.DockStyle.Fill;
            this.panel2.Location = new System.Drawing.Point(129, 143);
            this.panel2.Name = "panel2";
            this.panel2.Size = new System.Drawing.Size(375, 22);
            this.panel2.TabIndex = 9;
            // 
            // tbGScript
            // 
            this.tbGScript.Dock = System.Windows.Forms.DockStyle.Fill;
            this.tbGScript.Location = new System.Drawing.Point(0, 0);
            this.tbGScript.Name = "tbGScript";
            this.tbGScript.ReadOnly = true;
            this.tbGScript.Size = new System.Drawing.Size(300, 20);
            this.tbGScript.TabIndex = 0;
            // 
            // btnBrowseGScript
            // 
            this.btnBrowseGScript.Dock = System.Windows.Forms.DockStyle.Right;
            this.btnBrowseGScript.Location = new System.Drawing.Point(300, 0);
            this.btnBrowseGScript.Name = "btnBrowseGScript";
            this.btnBrowseGScript.Size = new System.Drawing.Size(75, 22);
            this.btnBrowseGScript.TabIndex = 1;
            this.btnBrowseGScript.Text = "...";
            this.btnBrowseGScript.UseVisualStyleBackColor = true;
            this.btnBrowseGScript.Click += new System.EventHandler(this.btnBrowseGScript_Click);
            // 
            // cboxMaxChannels
            // 
            this.cboxMaxChannels.Dock = System.Windows.Forms.DockStyle.Fill;
            this.cboxMaxChannels.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cboxMaxChannels.FormattingEnabled = true;
            this.cboxMaxChannels.Items.AddRange(new object[] {
            "256",
            "512",
            "1024",
            "2048"});
            this.cboxMaxChannels.Location = new System.Drawing.Point(129, 59);
            this.cboxMaxChannels.Name = "cboxMaxChannels";
            this.cboxMaxChannels.Size = new System.Drawing.Size(375, 21);
            this.cboxMaxChannels.TabIndex = 10;
            // 
            // panel3
            // 
            this.panel3.Controls.Add(this.tbarMinHV);
            this.panel3.Controls.Add(this.lblMinHV);
            this.panel3.Dock = System.Windows.Forms.DockStyle.Fill;
            this.panel3.Location = new System.Drawing.Point(129, 87);
            this.panel3.Name = "panel3";
            this.panel3.Size = new System.Drawing.Size(375, 22);
            this.panel3.TabIndex = 11;
            // 
            // tbarMinHV
            // 
            this.tbarMinHV.Dock = System.Windows.Forms.DockStyle.Fill;
            this.tbarMinHV.Location = new System.Drawing.Point(0, 0);
            this.tbarMinHV.Maximum = 1500;
            this.tbarMinHV.Name = "tbarMinHV";
            this.tbarMinHV.Size = new System.Drawing.Size(362, 22);
            this.tbarMinHV.TabIndex = 1;
            this.tbarMinHV.TickStyle = System.Windows.Forms.TickStyle.None;
            this.tbarMinHV.ValueChanged += new System.EventHandler(this.tbarMinHV_ValueChanged);
            // 
            // lblMinHV
            // 
            this.lblMinHV.AutoSize = true;
            this.lblMinHV.Dock = System.Windows.Forms.DockStyle.Right;
            this.lblMinHV.Location = new System.Drawing.Point(362, 0);
            this.lblMinHV.Name = "lblMinHV";
            this.lblMinHV.Size = new System.Drawing.Size(13, 13);
            this.lblMinHV.TabIndex = 0;
            this.lblMinHV.Text = "1";
            // 
            // panel4
            // 
            this.panel4.Controls.Add(this.tbarMaxHV);
            this.panel4.Controls.Add(this.lblMaxHV);
            this.panel4.Dock = System.Windows.Forms.DockStyle.Fill;
            this.panel4.Location = new System.Drawing.Point(129, 115);
            this.panel4.Name = "panel4";
            this.panel4.Size = new System.Drawing.Size(375, 22);
            this.panel4.TabIndex = 12;
            // 
            // tbarMaxHV
            // 
            this.tbarMaxHV.Dock = System.Windows.Forms.DockStyle.Fill;
            this.tbarMaxHV.Location = new System.Drawing.Point(0, 0);
            this.tbarMaxHV.Maximum = 1500;
            this.tbarMaxHV.Name = "tbarMaxHV";
            this.tbarMaxHV.Size = new System.Drawing.Size(362, 22);
            this.tbarMaxHV.TabIndex = 1;
            this.tbarMaxHV.TickStyle = System.Windows.Forms.TickStyle.None;
            this.tbarMaxHV.ValueChanged += new System.EventHandler(this.tbarMaxHV_ValueChanged);
            // 
            // lblMaxHV
            // 
            this.lblMaxHV.AutoSize = true;
            this.lblMaxHV.Dock = System.Windows.Forms.DockStyle.Right;
            this.lblMaxHV.Location = new System.Drawing.Point(362, 0);
            this.lblMaxHV.Name = "lblMaxHV";
            this.lblMaxHV.Size = new System.Drawing.Size(13, 13);
            this.lblMaxHV.TabIndex = 0;
            this.lblMaxHV.Text = "1";
            // 
            // FormAddDetectorType
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(507, 223);
            this.Controls.Add(this.tableLayoutPanel1);
            this.Controls.Add(this.panel1);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedSingle;
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.MaximizeBox = false;
            this.MinimizeBox = false;
            this.Name = "FormAddDetectorType";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterParent;
            this.Text = "Crash - Add Detector Type";
            this.Load += new System.EventHandler(this.FormAddDetectorType_Load);
            this.panel1.ResumeLayout(false);
            this.tableLayoutPanel1.ResumeLayout(false);
            this.tableLayoutPanel1.PerformLayout();
            this.panel2.ResumeLayout(false);
            this.panel2.PerformLayout();
            this.panel3.ResumeLayout(false);
            this.panel3.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.tbarMinHV)).EndInit();
            this.panel4.ResumeLayout(false);
            this.panel4.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.tbarMaxHV)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.Panel panel1;
        private System.Windows.Forms.Button btnCancel;
        private System.Windows.Forms.Button btnOk;
        private System.Windows.Forms.TableLayoutPanel tableLayoutPanel1;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.TextBox tbName;
        private System.Windows.Forms.Label label5;
        private System.Windows.Forms.Panel panel2;
        private System.Windows.Forms.TextBox tbGScript;
        private System.Windows.Forms.Button btnBrowseGScript;
        private System.Windows.Forms.ComboBox cboxMaxChannels;
        private System.Windows.Forms.Panel panel3;
        private System.Windows.Forms.TrackBar tbarMinHV;
        private System.Windows.Forms.Label lblMinHV;
        private System.Windows.Forms.Panel panel4;
        private System.Windows.Forms.TrackBar tbarMaxHV;
        private System.Windows.Forms.Label lblMaxHV;
    }
}