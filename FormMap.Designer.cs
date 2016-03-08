namespace crash
{
    partial class FormMap
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(FormMap));
            this.toolsMap = new System.Windows.Forms.ToolStrip();
            this.toolStripLabel2 = new System.Windows.Forms.ToolStripLabel();
            this.cboxMapProvider = new System.Windows.Forms.ToolStripComboBox();
            this.toolStripLabel1 = new System.Windows.Forms.ToolStripLabel();
            this.cboxMapMode = new System.Windows.Forms.ToolStripComboBox();
            this.toolStripLabel3 = new System.Windows.Forms.ToolStripLabel();
            this.tbLat = new System.Windows.Forms.ToolStripTextBox();
            this.tbLon = new System.Windows.Forms.ToolStripTextBox();
            this.btnGoToLatLon = new System.Windows.Forms.ToolStripButton();
            this.gmap = new GMap.NET.WindowsForms.GMapControl();
            this.status = new System.Windows.Forms.StatusStrip();
            this.toolsMap.SuspendLayout();
            this.SuspendLayout();
            // 
            // toolsMap
            // 
            this.toolsMap.GripStyle = System.Windows.Forms.ToolStripGripStyle.Hidden;
            this.toolsMap.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.toolStripLabel2,
            this.cboxMapProvider,
            this.toolStripLabel1,
            this.cboxMapMode,
            this.toolStripLabel3,
            this.tbLat,
            this.tbLon,
            this.btnGoToLatLon});
            this.toolsMap.LayoutStyle = System.Windows.Forms.ToolStripLayoutStyle.HorizontalStackWithOverflow;
            this.toolsMap.Location = new System.Drawing.Point(0, 0);
            this.toolsMap.Name = "toolsMap";
            this.toolsMap.Size = new System.Drawing.Size(851, 25);
            this.toolsMap.TabIndex = 4;
            this.toolsMap.Text = "toolStrip1";
            // 
            // toolStripLabel2
            // 
            this.toolStripLabel2.Name = "toolStripLabel2";
            this.toolStripLabel2.Size = new System.Drawing.Size(81, 22);
            this.toolStripLabel2.Text = "Map provider:";
            // 
            // cboxMapProvider
            // 
            this.cboxMapProvider.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cboxMapProvider.FlatStyle = System.Windows.Forms.FlatStyle.Standard;
            this.cboxMapProvider.Items.AddRange(new object[] {
            "Google Map",
            "Google Map Terrain",
            "Open Street Map",
            "Open Street Map Quest",
            "ArcGIS World Topo",
            "Bing Map"});
            this.cboxMapProvider.Name = "cboxMapProvider";
            this.cboxMapProvider.Size = new System.Drawing.Size(132, 25);
            this.cboxMapProvider.SelectedIndexChanged += new System.EventHandler(this.cboxMapProvider_SelectedIndexChanged);
            // 
            // toolStripLabel1
            // 
            this.toolStripLabel1.Name = "toolStripLabel1";
            this.toolStripLabel1.Size = new System.Drawing.Size(68, 22);
            this.toolStripLabel1.Text = "Map mode:";
            // 
            // cboxMapMode
            // 
            this.cboxMapMode.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cboxMapMode.FlatStyle = System.Windows.Forms.FlatStyle.Standard;
            this.cboxMapMode.Items.AddRange(new object[] {
            "Server",
            "Cache",
            "Server and Cache"});
            this.cboxMapMode.Name = "cboxMapMode";
            this.cboxMapMode.Size = new System.Drawing.Size(121, 25);
            this.cboxMapMode.SelectedIndexChanged += new System.EventHandler(this.cboxMapMode_SelectedIndexChanged);
            // 
            // toolStripLabel3
            // 
            this.toolStripLabel3.Name = "toolStripLabel3";
            this.toolStripLabel3.Size = new System.Drawing.Size(77, 22);
            this.toolStripLabel3.Text = "Go to lat/lon:";
            // 
            // tbLat
            // 
            this.tbLat.Name = "tbLat";
            this.tbLat.Size = new System.Drawing.Size(100, 25);
            this.tbLat.KeyPress += new System.Windows.Forms.KeyPressEventHandler(this.tbLatLon_KeyPress);
            // 
            // tbLon
            // 
            this.tbLon.Name = "tbLon";
            this.tbLon.Size = new System.Drawing.Size(100, 25);
            this.tbLon.KeyPress += new System.Windows.Forms.KeyPressEventHandler(this.tbLatLon_KeyPress);
            // 
            // btnGoToLatLon
            // 
            this.btnGoToLatLon.Image = ((System.Drawing.Image)(resources.GetObject("btnGoToLatLon.Image")));
            this.btnGoToLatLon.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.btnGoToLatLon.Name = "btnGoToLatLon";
            this.btnGoToLatLon.Size = new System.Drawing.Size(42, 22);
            this.btnGoToLatLon.Text = "Go";
            this.btnGoToLatLon.Click += new System.EventHandler(this.btnGoToLatLon_Click);
            // 
            // gmap
            // 
            this.gmap.Bearing = 0F;
            this.gmap.CanDragMap = true;
            this.gmap.Dock = System.Windows.Forms.DockStyle.Fill;
            this.gmap.EmptyTileColor = System.Drawing.Color.Navy;
            this.gmap.GrayScaleMode = false;
            this.gmap.HelperLineOption = GMap.NET.WindowsForms.HelperLineOptions.DontShow;
            this.gmap.LevelsKeepInMemmory = 5;
            this.gmap.Location = new System.Drawing.Point(0, 25);
            this.gmap.MarkersEnabled = true;
            this.gmap.MaxZoom = 18;
            this.gmap.MinZoom = 0;
            this.gmap.MouseWheelZoomType = GMap.NET.MouseWheelZoomType.MousePositionAndCenter;
            this.gmap.Name = "gmap";
            this.gmap.NegativeMode = false;
            this.gmap.PolygonsEnabled = true;
            this.gmap.RetryLoadTile = 0;
            this.gmap.RoutesEnabled = true;
            this.gmap.ScaleMode = GMap.NET.WindowsForms.ScaleModes.Integer;
            this.gmap.SelectedAreaFillColor = System.Drawing.Color.FromArgb(((int)(((byte)(33)))), ((int)(((byte)(65)))), ((int)(((byte)(105)))), ((int)(((byte)(225)))));
            this.gmap.ShowTileGridLines = false;
            this.gmap.Size = new System.Drawing.Size(851, 561);
            this.gmap.TabIndex = 5;
            this.gmap.Zoom = 12D;
            // 
            // status
            // 
            this.status.Location = new System.Drawing.Point(0, 586);
            this.status.Name = "status";
            this.status.Size = new System.Drawing.Size(851, 22);
            this.status.TabIndex = 6;
            this.status.Text = "statusStrip1";
            // 
            // FormMap
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(851, 608);
            this.Controls.Add(this.gmap);
            this.Controls.Add(this.status);
            this.Controls.Add(this.toolsMap);
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.Name = "FormMap";
            this.Text = "Crash - Map";
            this.FormClosing += new System.Windows.Forms.FormClosingEventHandler(this.FormMap_FormClosing);
            this.Load += new System.EventHandler(this.FormMap_Load);
            this.toolsMap.ResumeLayout(false);
            this.toolsMap.PerformLayout();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.ToolStrip toolsMap;
        private System.Windows.Forms.ToolStripLabel toolStripLabel2;
        private System.Windows.Forms.ToolStripComboBox cboxMapProvider;
        private System.Windows.Forms.ToolStripLabel toolStripLabel1;
        private System.Windows.Forms.ToolStripComboBox cboxMapMode;
        private GMap.NET.WindowsForms.GMapControl gmap;
        private System.Windows.Forms.StatusStrip status;
        private System.Windows.Forms.ToolStripLabel toolStripLabel3;
        private System.Windows.Forms.ToolStripTextBox tbLat;
        private System.Windows.Forms.ToolStripTextBox tbLon;
        private System.Windows.Forms.ToolStripButton btnGoToLatLon;
    }
}