namespace crash
{
    partial class FormPreferences
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(FormPreferences));
            this.tableLayoutPref = new System.Windows.Forms.TableLayoutPanel();
            this.lvDetectors = new System.Windows.Forms.ListView();
            this.columnHeaderSerialnumber = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.columnHeaderType = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.columnHeaderNumChannels = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.columnHeaderHV = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.columnHeaderCoarseGain = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.columnHeaderFineGain = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.columnHeaderLivetime = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.columnHeaderLLD = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.columnHeaderULD = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.label1 = new System.Windows.Forms.Label();
            this.tbSessionDir = new System.Windows.Forms.TextBox();
            this.btnSetSessionDir = new System.Windows.Forms.Button();
            this.lvDetectorTypes = new System.Windows.Forms.ListView();
            this.columnHeaderName = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.columnHeaderMaxCH = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.columnHeaderMinHV = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.columnHeaderMaxHV = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.columnHeaderGScript = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.btnAddDetectorType = new System.Windows.Forms.Button();
            this.label2 = new System.Windows.Forms.Label();
            this.label3 = new System.Windows.Forms.Label();
            this.btnAddDetector = new System.Windows.Forms.Button();
            this.panel1 = new System.Windows.Forms.Panel();
            this.btnCancel = new System.Windows.Forms.Button();
            this.btnOk = new System.Windows.Forms.Button();
            this.tools = new System.Windows.Forms.ToolStrip();
            this.status = new System.Windows.Forms.StatusStrip();
            this.tableLayoutPref.SuspendLayout();
            this.panel1.SuspendLayout();
            this.SuspendLayout();
            // 
            // tableLayoutPref
            // 
            this.tableLayoutPref.ColumnCount = 3;
            this.tableLayoutPref.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 15F));
            this.tableLayoutPref.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 70F));
            this.tableLayoutPref.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 15F));
            this.tableLayoutPref.Controls.Add(this.lvDetectors, 1, 7);
            this.tableLayoutPref.Controls.Add(this.label1, 0, 1);
            this.tableLayoutPref.Controls.Add(this.tbSessionDir, 1, 1);
            this.tableLayoutPref.Controls.Add(this.btnSetSessionDir, 2, 1);
            this.tableLayoutPref.Controls.Add(this.lvDetectorTypes, 1, 6);
            this.tableLayoutPref.Controls.Add(this.btnAddDetectorType, 2, 6);
            this.tableLayoutPref.Controls.Add(this.label2, 0, 6);
            this.tableLayoutPref.Controls.Add(this.label3, 0, 7);
            this.tableLayoutPref.Controls.Add(this.btnAddDetector, 2, 7);
            this.tableLayoutPref.Dock = System.Windows.Forms.DockStyle.Fill;
            this.tableLayoutPref.Location = new System.Drawing.Point(0, 25);
            this.tableLayoutPref.Name = "tableLayoutPref";
            this.tableLayoutPref.RowCount = 8;
            this.tableLayoutPref.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 28F));
            this.tableLayoutPref.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 28F));
            this.tableLayoutPref.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 28F));
            this.tableLayoutPref.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 28F));
            this.tableLayoutPref.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 28F));
            this.tableLayoutPref.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 28F));
            this.tableLayoutPref.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 200F));
            this.tableLayoutPref.RowStyles.Add(new System.Windows.Forms.RowStyle());
            this.tableLayoutPref.Size = new System.Drawing.Size(909, 550);
            this.tableLayoutPref.TabIndex = 0;
            // 
            // lvDetectors
            // 
            this.lvDetectors.Columns.AddRange(new System.Windows.Forms.ColumnHeader[] {
            this.columnHeaderSerialnumber,
            this.columnHeaderType,
            this.columnHeaderNumChannels,
            this.columnHeaderHV,
            this.columnHeaderCoarseGain,
            this.columnHeaderFineGain,
            this.columnHeaderLivetime,
            this.columnHeaderLLD,
            this.columnHeaderULD});
            this.lvDetectors.Dock = System.Windows.Forms.DockStyle.Fill;
            this.lvDetectors.FullRowSelect = true;
            this.lvDetectors.Location = new System.Drawing.Point(139, 371);
            this.lvDetectors.MultiSelect = false;
            this.lvDetectors.Name = "lvDetectors";
            this.lvDetectors.Size = new System.Drawing.Size(630, 251);
            this.lvDetectors.TabIndex = 8;
            this.lvDetectors.UseCompatibleStateImageBehavior = false;
            this.lvDetectors.View = System.Windows.Forms.View.Details;
            // 
            // columnHeaderSerialnumber
            // 
            this.columnHeaderSerialnumber.Text = "Serialnumber";
            // 
            // columnHeaderType
            // 
            this.columnHeaderType.Text = "Type";
            // 
            // columnHeaderNumChannels
            // 
            this.columnHeaderNumChannels.Text = "Num. Channels";
            // 
            // columnHeaderHV
            // 
            this.columnHeaderHV.Text = "Voltage";
            // 
            // columnHeaderCoarseGain
            // 
            this.columnHeaderCoarseGain.Text = "Coarse gain";
            // 
            // columnHeaderFineGain
            // 
            this.columnHeaderFineGain.Text = "Fine gain";
            // 
            // columnHeaderLivetime
            // 
            this.columnHeaderLivetime.Text = "Livetime";
            // 
            // columnHeaderLLD
            // 
            this.columnHeaderLLD.Text = "LLD";
            // 
            // columnHeaderULD
            // 
            this.columnHeaderULD.Text = "ULD";
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(3, 28);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(87, 13);
            this.label1.TabIndex = 0;
            this.label1.Text = "Session directory";
            // 
            // tbSessionDir
            // 
            this.tbSessionDir.Dock = System.Windows.Forms.DockStyle.Fill;
            this.tbSessionDir.Location = new System.Drawing.Point(139, 31);
            this.tbSessionDir.Name = "tbSessionDir";
            this.tbSessionDir.ReadOnly = true;
            this.tbSessionDir.Size = new System.Drawing.Size(630, 20);
            this.tbSessionDir.TabIndex = 1;
            // 
            // btnSetSessionDir
            // 
            this.btnSetSessionDir.Dock = System.Windows.Forms.DockStyle.Fill;
            this.btnSetSessionDir.Location = new System.Drawing.Point(775, 31);
            this.btnSetSessionDir.Name = "btnSetSessionDir";
            this.btnSetSessionDir.Size = new System.Drawing.Size(131, 22);
            this.btnSetSessionDir.TabIndex = 2;
            this.btnSetSessionDir.Text = "...";
            this.btnSetSessionDir.UseVisualStyleBackColor = true;
            this.btnSetSessionDir.Click += new System.EventHandler(this.btnSetSessionDir_Click);
            // 
            // lvDetectorTypes
            // 
            this.lvDetectorTypes.BackColor = System.Drawing.SystemColors.Window;
            this.lvDetectorTypes.Columns.AddRange(new System.Windows.Forms.ColumnHeader[] {
            this.columnHeaderName,
            this.columnHeaderMaxCH,
            this.columnHeaderMinHV,
            this.columnHeaderMaxHV,
            this.columnHeaderGScript});
            this.lvDetectorTypes.Dock = System.Windows.Forms.DockStyle.Fill;
            this.lvDetectorTypes.FullRowSelect = true;
            this.lvDetectorTypes.Location = new System.Drawing.Point(139, 171);
            this.lvDetectorTypes.MultiSelect = false;
            this.lvDetectorTypes.Name = "lvDetectorTypes";
            this.lvDetectorTypes.Size = new System.Drawing.Size(630, 194);
            this.lvDetectorTypes.TabIndex = 3;
            this.lvDetectorTypes.UseCompatibleStateImageBehavior = false;
            this.lvDetectorTypes.View = System.Windows.Forms.View.Details;
            // 
            // columnHeaderName
            // 
            this.columnHeaderName.Text = "Name";
            // 
            // columnHeaderMaxCH
            // 
            this.columnHeaderMaxCH.Text = "Max channels";
            // 
            // columnHeaderMinHV
            // 
            this.columnHeaderMinHV.Text = "Min HV";
            // 
            // columnHeaderMaxHV
            // 
            this.columnHeaderMaxHV.Text = "Max HV";
            // 
            // columnHeaderGScript
            // 
            this.columnHeaderGScript.Text = "G Script";
            // 
            // btnAddDetectorType
            // 
            this.btnAddDetectorType.Dock = System.Windows.Forms.DockStyle.Top;
            this.btnAddDetectorType.Location = new System.Drawing.Point(775, 171);
            this.btnAddDetectorType.Name = "btnAddDetectorType";
            this.btnAddDetectorType.Size = new System.Drawing.Size(131, 23);
            this.btnAddDetectorType.TabIndex = 4;
            this.btnAddDetectorType.Text = "Add";
            this.btnAddDetectorType.UseVisualStyleBackColor = true;
            this.btnAddDetectorType.Click += new System.EventHandler(this.btnAddDetectorType_Click);
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(3, 168);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(76, 13);
            this.label2.TabIndex = 5;
            this.label2.Text = "Detector types";
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(3, 368);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(53, 13);
            this.label3.TabIndex = 6;
            this.label3.Text = "Detectors";
            // 
            // btnAddDetector
            // 
            this.btnAddDetector.Dock = System.Windows.Forms.DockStyle.Top;
            this.btnAddDetector.Location = new System.Drawing.Point(775, 371);
            this.btnAddDetector.Name = "btnAddDetector";
            this.btnAddDetector.Size = new System.Drawing.Size(131, 23);
            this.btnAddDetector.TabIndex = 7;
            this.btnAddDetector.Text = "Add";
            this.btnAddDetector.UseVisualStyleBackColor = true;
            this.btnAddDetector.Click += new System.EventHandler(this.btnAddDetector_Click);
            // 
            // panel1
            // 
            this.panel1.Controls.Add(this.btnCancel);
            this.panel1.Controls.Add(this.btnOk);
            this.panel1.Dock = System.Windows.Forms.DockStyle.Bottom;
            this.panel1.Location = new System.Drawing.Point(0, 575);
            this.panel1.Name = "panel1";
            this.panel1.Size = new System.Drawing.Size(909, 26);
            this.panel1.TabIndex = 1;
            // 
            // btnCancel
            // 
            this.btnCancel.Dock = System.Windows.Forms.DockStyle.Right;
            this.btnCancel.Location = new System.Drawing.Point(713, 0);
            this.btnCancel.Name = "btnCancel";
            this.btnCancel.Size = new System.Drawing.Size(98, 26);
            this.btnCancel.TabIndex = 1;
            this.btnCancel.Text = "Cancel";
            this.btnCancel.UseVisualStyleBackColor = true;
            this.btnCancel.Click += new System.EventHandler(this.btnCancel_Click);
            // 
            // btnOk
            // 
            this.btnOk.Dock = System.Windows.Forms.DockStyle.Right;
            this.btnOk.Location = new System.Drawing.Point(811, 0);
            this.btnOk.Name = "btnOk";
            this.btnOk.Size = new System.Drawing.Size(98, 26);
            this.btnOk.TabIndex = 0;
            this.btnOk.Text = "Ok";
            this.btnOk.UseVisualStyleBackColor = true;
            this.btnOk.Click += new System.EventHandler(this.btnOk_Click);
            // 
            // tools
            // 
            this.tools.Location = new System.Drawing.Point(0, 0);
            this.tools.Name = "tools";
            this.tools.Size = new System.Drawing.Size(909, 25);
            this.tools.TabIndex = 2;
            this.tools.Text = "toolStrip1";
            // 
            // status
            // 
            this.status.Location = new System.Drawing.Point(0, 601);
            this.status.Name = "status";
            this.status.Size = new System.Drawing.Size(909, 22);
            this.status.TabIndex = 3;
            this.status.Text = "statusStrip1";
            // 
            // FormPreferences
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(909, 623);
            this.Controls.Add(this.tableLayoutPref);
            this.Controls.Add(this.panel1);
            this.Controls.Add(this.status);
            this.Controls.Add(this.tools);
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.MaximizeBox = false;
            this.MinimizeBox = false;
            this.Name = "FormPreferences";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterParent;
            this.Text = "Crash - Preferences";
            this.Load += new System.EventHandler(this.FormPreferences_Load);
            this.tableLayoutPref.ResumeLayout(false);
            this.tableLayoutPref.PerformLayout();
            this.panel1.ResumeLayout(false);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.TableLayoutPanel tableLayoutPref;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.TextBox tbSessionDir;
        private System.Windows.Forms.Button btnSetSessionDir;
        private System.Windows.Forms.Panel panel1;
        private System.Windows.Forms.Button btnCancel;
        private System.Windows.Forms.Button btnOk;
        private System.Windows.Forms.ListView lvDetectorTypes;
        private System.Windows.Forms.ColumnHeader columnHeaderName;
        private System.Windows.Forms.ColumnHeader columnHeaderMaxCH;
        private System.Windows.Forms.ColumnHeader columnHeaderMinHV;
        private System.Windows.Forms.ColumnHeader columnHeaderMaxHV;
        private System.Windows.Forms.Button btnAddDetectorType;
        private System.Windows.Forms.ColumnHeader columnHeaderGScript;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.Button btnAddDetector;
        private System.Windows.Forms.ListView lvDetectors;
        private System.Windows.Forms.ColumnHeader columnHeaderType;
        private System.Windows.Forms.ColumnHeader columnHeaderSerialnumber;
        private System.Windows.Forms.ColumnHeader columnHeaderNumChannels;
        private System.Windows.Forms.ColumnHeader columnHeaderHV;
        private System.Windows.Forms.ColumnHeader columnHeaderCoarseGain;
        private System.Windows.Forms.ColumnHeader columnHeaderFineGain;
        private System.Windows.Forms.ColumnHeader columnHeaderLivetime;
        private System.Windows.Forms.ColumnHeader columnHeaderLLD;
        private System.Windows.Forms.ColumnHeader columnHeaderULD;
        private System.Windows.Forms.ToolStrip tools;
        private System.Windows.Forms.StatusStrip status;
    }
}