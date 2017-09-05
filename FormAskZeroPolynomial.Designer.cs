namespace crash
{
    partial class FormAskZeroPolynomial
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(FormAskZeroPolynomial));
            this.panel1 = new System.Windows.Forms.Panel();
            this.btnCancel = new System.Windows.Forms.Button();
            this.cbSaveSettings = new System.Windows.Forms.CheckBox();
            this.btnOk = new System.Windows.Forms.Button();
            this.lblInfo = new System.Windows.Forms.Label();
            this.lblEnergyInfo = new System.Windows.Forms.Label();
            this.lblEnergy = new System.Windows.Forms.Label();
            this.lblZeroPolynomialInfo = new System.Windows.Forms.Label();
            this.tbZeroPolynomial = new System.Windows.Forms.TextBox();
            this.lblChannelInfo = new System.Windows.Forms.Label();
            this.lblChannel = new System.Windows.Forms.Label();
            this.panel1.SuspendLayout();
            this.SuspendLayout();
            // 
            // panel1
            // 
            this.panel1.Controls.Add(this.btnCancel);
            this.panel1.Controls.Add(this.cbSaveSettings);
            this.panel1.Controls.Add(this.btnOk);
            this.panel1.Dock = System.Windows.Forms.DockStyle.Bottom;
            this.panel1.Location = new System.Drawing.Point(0, 164);
            this.panel1.Name = "panel1";
            this.panel1.Size = new System.Drawing.Size(440, 32);
            this.panel1.TabIndex = 0;
            // 
            // btnCancel
            // 
            this.btnCancel.Dock = System.Windows.Forms.DockStyle.Right;
            this.btnCancel.Location = new System.Drawing.Point(260, 0);
            this.btnCancel.Name = "btnCancel";
            this.btnCancel.Size = new System.Drawing.Size(90, 32);
            this.btnCancel.TabIndex = 2;
            this.btnCancel.Text = "Cancel";
            this.btnCancel.UseVisualStyleBackColor = true;
            this.btnCancel.Click += new System.EventHandler(this.btnCancel_Click);
            // 
            // cbSaveSettings
            // 
            this.cbSaveSettings.AutoSize = true;
            this.cbSaveSettings.CheckAlign = System.Drawing.ContentAlignment.MiddleRight;
            this.cbSaveSettings.Location = new System.Drawing.Point(13, 2);
            this.cbSaveSettings.Name = "cbSaveSettings";
            this.cbSaveSettings.Padding = new System.Windows.Forms.Padding(0, 3, 0, 0);
            this.cbSaveSettings.Size = new System.Drawing.Size(154, 22);
            this.cbSaveSettings.TabIndex = 1;
            this.cbSaveSettings.Text = "Adjust settings detector";
            this.cbSaveSettings.UseVisualStyleBackColor = true;
            // 
            // btnOk
            // 
            this.btnOk.Dock = System.Windows.Forms.DockStyle.Right;
            this.btnOk.Location = new System.Drawing.Point(350, 0);
            this.btnOk.Name = "btnOk";
            this.btnOk.Size = new System.Drawing.Size(90, 32);
            this.btnOk.TabIndex = 0;
            this.btnOk.Text = "Ok";
            this.btnOk.UseVisualStyleBackColor = true;
            this.btnOk.Click += new System.EventHandler(this.btnOk_Click);
            // 
            // lblInfo
            // 
            this.lblInfo.AutoSize = true;
            this.lblInfo.Font = new System.Drawing.Font("Arial", 9F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblInfo.Location = new System.Drawing.Point(15, 23);
            this.lblInfo.Name = "lblInfo";
            this.lblInfo.Size = new System.Drawing.Size(253, 15);
            this.lblInfo.TabIndex = 1;
            this.lblInfo.Text = "Adjust zero polynomial for session detector";
            // 
            // lblEnergyInfo
            // 
            this.lblEnergyInfo.AutoSize = true;
            this.lblEnergyInfo.Location = new System.Drawing.Point(15, 88);
            this.lblEnergyInfo.Name = "lblEnergyInfo";
            this.lblEnergyInfo.Size = new System.Drawing.Size(48, 15);
            this.lblEnergyInfo.TabIndex = 2;
            this.lblEnergyInfo.Text = "Energy:";
            // 
            // lblEnergy
            // 
            this.lblEnergy.AutoSize = true;
            this.lblEnergy.Location = new System.Drawing.Point(116, 88);
            this.lblEnergy.Name = "lblEnergy";
            this.lblEnergy.Size = new System.Drawing.Size(59, 15);
            this.lblEnergy.TabIndex = 3;
            this.lblEnergy.Text = "<Energy>";
            // 
            // lblZeroPolynomialInfo
            // 
            this.lblZeroPolynomialInfo.AutoSize = true;
            this.lblZeroPolynomialInfo.Location = new System.Drawing.Point(15, 120);
            this.lblZeroPolynomialInfo.Name = "lblZeroPolynomialInfo";
            this.lblZeroPolynomialInfo.Size = new System.Drawing.Size(98, 15);
            this.lblZeroPolynomialInfo.TabIndex = 4;
            this.lblZeroPolynomialInfo.Text = "Zero polynomial:";
            // 
            // tbZeroPolynomial
            // 
            this.tbZeroPolynomial.Location = new System.Drawing.Point(119, 114);
            this.tbZeroPolynomial.Name = "tbZeroPolynomial";
            this.tbZeroPolynomial.Size = new System.Drawing.Size(293, 21);
            this.tbZeroPolynomial.TabIndex = 5;
            this.tbZeroPolynomial.TextChanged += new System.EventHandler(this.tbZeroPolynomial_TextChanged);
            // 
            // lblChannelInfo
            // 
            this.lblChannelInfo.AutoSize = true;
            this.lblChannelInfo.Location = new System.Drawing.Point(15, 60);
            this.lblChannelInfo.Name = "lblChannelInfo";
            this.lblChannelInfo.Size = new System.Drawing.Size(57, 15);
            this.lblChannelInfo.TabIndex = 6;
            this.lblChannelInfo.Text = "Channel:";
            // 
            // lblChannel
            // 
            this.lblChannel.AutoSize = true;
            this.lblChannel.Location = new System.Drawing.Point(116, 60);
            this.lblChannel.Name = "lblChannel";
            this.lblChannel.Size = new System.Drawing.Size(68, 15);
            this.lblChannel.TabIndex = 7;
            this.lblChannel.Text = "<Channel>";
            // 
            // FormAskZeroPolynomial
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(7F, 15F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(440, 196);
            this.Controls.Add(this.lblChannel);
            this.Controls.Add(this.lblChannelInfo);
            this.Controls.Add(this.tbZeroPolynomial);
            this.Controls.Add(this.lblZeroPolynomialInfo);
            this.Controls.Add(this.lblEnergy);
            this.Controls.Add(this.lblEnergyInfo);
            this.Controls.Add(this.lblInfo);
            this.Controls.Add(this.panel1);
            this.Font = new System.Drawing.Font("Arial", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedDialog;
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.MaximizeBox = false;
            this.MinimizeBox = false;
            this.Name = "FormAskZeroPolynomial";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterParent;
            this.Text = "Gamma Analyzer - Zero polynomial";
            this.Load += new System.EventHandler(this.FormAskZeroPolynomial_Load);
            this.panel1.ResumeLayout(false);
            this.panel1.PerformLayout();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Panel panel1;
        private System.Windows.Forms.Label lblInfo;
        private System.Windows.Forms.Label lblEnergyInfo;
        private System.Windows.Forms.Label lblEnergy;
        private System.Windows.Forms.Label lblZeroPolynomialInfo;
        private System.Windows.Forms.TextBox tbZeroPolynomial;
        private System.Windows.Forms.Button btnOk;
        private System.Windows.Forms.CheckBox cbSaveSettings;
        private System.Windows.Forms.Label lblChannelInfo;
        private System.Windows.Forms.Label lblChannel;
        private System.Windows.Forms.Button btnCancel;
    }
}