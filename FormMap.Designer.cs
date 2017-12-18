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
            this.ddbOptions = new System.Windows.Forms.ToolStripDropDownButton();
            this.menuItemIAEAColors = new System.Windows.Forms.ToolStripMenuItem();
            this.toolStripLabel2 = new System.Windows.Forms.ToolStripLabel();
            this.cboxMapProvider = new System.Windows.Forms.ToolStripComboBox();
            this.toolStripLabel1 = new System.Windows.Forms.ToolStripLabel();
            this.cboxMapMode = new System.Windows.Forms.ToolStripComboBox();
            this.btnZoomToMin = new System.Windows.Forms.ToolStripButton();
            this.btnZoomIn = new System.Windows.Forms.ToolStripButton();
            this.btnZoomOut = new System.Windows.Forms.ToolStripButton();
            this.btnZoomToMax = new System.Windows.Forms.ToolStripButton();
            this.gmnMap = new GMap.NET.WindowsForms.GMapControl();
            this.toolsMap.SuspendLayout();
            this.SuspendLayout();
            // 
            // toolsMap
            // 
            this.toolsMap.GripStyle = System.Windows.Forms.ToolStripGripStyle.Hidden;
            this.toolsMap.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.ddbOptions,
            this.toolStripLabel2,
            this.cboxMapProvider,
            this.toolStripLabel1,
            this.cboxMapMode,
            this.btnZoomToMin,
            this.btnZoomIn,
            this.btnZoomOut,
            this.btnZoomToMax});
            this.toolsMap.LayoutStyle = System.Windows.Forms.ToolStripLayoutStyle.HorizontalStackWithOverflow;
            this.toolsMap.Location = new System.Drawing.Point(0, 0);
            this.toolsMap.Name = "toolsMap";
            this.toolsMap.Size = new System.Drawing.Size(708, 25);
            this.toolsMap.TabIndex = 4;
            this.toolsMap.Text = "toolStrip1";
            // 
            // ddbOptions
            // 
            this.ddbOptions.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.menuItemIAEAColors});
            this.ddbOptions.Image = global::crash.Properties.Resources.options1_16;
            this.ddbOptions.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.ddbOptions.Name = "ddbOptions";
            this.ddbOptions.Size = new System.Drawing.Size(78, 22);
            this.ddbOptions.Text = "Options";
            // 
            // menuItemIAEAColors
            // 
            this.menuItemIAEAColors.CheckOnClick = true;
            this.menuItemIAEAColors.Name = "menuItemIAEAColors";
            this.menuItemIAEAColors.Size = new System.Drawing.Size(156, 22);
            this.menuItemIAEAColors.Text = "Use IAEA colors";
            this.menuItemIAEAColors.CheckedChanged += new System.EventHandler(this.menuItemIAEAColors_CheckedChanged);
            // 
            // toolStripLabel2
            // 
            this.toolStripLabel2.Name = "toolStripLabel2";
            this.toolStripLabel2.Size = new System.Drawing.Size(51, 22);
            this.toolStripLabel2.Text = "Provider";
            // 
            // cboxMapProvider
            // 
            this.cboxMapProvider.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cboxMapProvider.FlatStyle = System.Windows.Forms.FlatStyle.Standard;
            this.cboxMapProvider.Items.AddRange(new object[] {
            "Google Map",
            "Google Map Terrain",
            "Google Map Sattelite",
            "Open Street Map",
            "Open Street Map Quest",
            "ArcGIS World Topo",
            "ArcGIS World 2D",
            "ArcGIS World Shaded",
            "Bing Map",
            "Bing Map Hybrid",
            "Bing Map Satellite",
            "Yahoo Map",
            "Yahoo Map Hybrid",
            "Yahoo Map Satellite"});
            this.cboxMapProvider.Name = "cboxMapProvider";
            this.cboxMapProvider.Size = new System.Drawing.Size(120, 25);
            this.cboxMapProvider.SelectedIndexChanged += new System.EventHandler(this.cboxMapProvider_SelectedIndexChanged);
            // 
            // toolStripLabel1
            // 
            this.toolStripLabel1.Name = "toolStripLabel1";
            this.toolStripLabel1.Size = new System.Drawing.Size(38, 22);
            this.toolStripLabel1.Text = "Mode";
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
            this.cboxMapMode.Size = new System.Drawing.Size(105, 25);
            this.cboxMapMode.SelectedIndexChanged += new System.EventHandler(this.cboxMapMode_SelectedIndexChanged);
            // 
            // btnZoomToMin
            // 
            this.btnZoomToMin.Alignment = System.Windows.Forms.ToolStripItemAlignment.Right;
            this.btnZoomToMin.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image;
            this.btnZoomToMin.Image = global::crash.Properties.Resources.right_all_16;
            this.btnZoomToMin.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.btnZoomToMin.Name = "btnZoomToMin";
            this.btnZoomToMin.Size = new System.Drawing.Size(23, 22);
            this.btnZoomToMin.Text = "Zoom in all";
            this.btnZoomToMin.Click += new System.EventHandler(this.btnZoomToMin_Click);
            // 
            // btnZoomIn
            // 
            this.btnZoomIn.Alignment = System.Windows.Forms.ToolStripItemAlignment.Right;
            this.btnZoomIn.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image;
            this.btnZoomIn.Image = global::crash.Properties.Resources.right_16;
            this.btnZoomIn.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.btnZoomIn.Name = "btnZoomIn";
            this.btnZoomIn.Size = new System.Drawing.Size(23, 22);
            this.btnZoomIn.Text = "Zoom in";
            this.btnZoomIn.Click += new System.EventHandler(this.btnZoomIn_Click);
            // 
            // btnZoomOut
            // 
            this.btnZoomOut.Alignment = System.Windows.Forms.ToolStripItemAlignment.Right;
            this.btnZoomOut.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image;
            this.btnZoomOut.Image = global::crash.Properties.Resources.left_16;
            this.btnZoomOut.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.btnZoomOut.Name = "btnZoomOut";
            this.btnZoomOut.Size = new System.Drawing.Size(23, 22);
            this.btnZoomOut.Text = "Zoom out";
            this.btnZoomOut.Click += new System.EventHandler(this.btnZoomOut_Click);
            // 
            // btnZoomToMax
            // 
            this.btnZoomToMax.Alignment = System.Windows.Forms.ToolStripItemAlignment.Right;
            this.btnZoomToMax.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image;
            this.btnZoomToMax.Image = global::crash.Properties.Resources.left_all_16;
            this.btnZoomToMax.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.btnZoomToMax.Name = "btnZoomToMax";
            this.btnZoomToMax.Size = new System.Drawing.Size(23, 22);
            this.btnZoomToMax.Text = "Zoom out all";
            this.btnZoomToMax.Click += new System.EventHandler(this.btnZoomToMax_Click);
            // 
            // gmnMap
            // 
            this.gmnMap.Bearing = 0F;
            this.gmnMap.CanDragMap = true;
            this.gmnMap.Dock = System.Windows.Forms.DockStyle.Fill;
            this.gmnMap.EmptyTileColor = System.Drawing.Color.Navy;
            this.gmnMap.GrayScaleMode = false;
            this.gmnMap.HelperLineOption = GMap.NET.WindowsForms.HelperLineOptions.DontShow;
            this.gmnMap.LevelsKeepInMemmory = 5;
            this.gmnMap.Location = new System.Drawing.Point(0, 25);
            this.gmnMap.MarkersEnabled = true;
            this.gmnMap.MaxZoom = 24;
            this.gmnMap.MinZoom = 2;
            this.gmnMap.MouseWheelZoomType = GMap.NET.MouseWheelZoomType.MousePositionAndCenter;
            this.gmnMap.Name = "gmnMap";
            this.gmnMap.NegativeMode = false;
            this.gmnMap.PolygonsEnabled = true;
            this.gmnMap.RetryLoadTile = 0;
            this.gmnMap.RoutesEnabled = true;
            this.gmnMap.ScaleMode = GMap.NET.WindowsForms.ScaleModes.Integer;
            this.gmnMap.SelectedAreaFillColor = System.Drawing.Color.FromArgb(((int)(((byte)(33)))), ((int)(((byte)(65)))), ((int)(((byte)(105)))), ((int)(((byte)(225)))));
            this.gmnMap.ShowTileGridLines = false;
            this.gmnMap.Size = new System.Drawing.Size(708, 417);
            this.gmnMap.TabIndex = 7;
            this.gmnMap.Zoom = 10D;
            this.gmnMap.OnMarkerClick += new GMap.NET.WindowsForms.MarkerClick(this.gmap_OnMarkerClick);
            // 
            // FormMap
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(708, 442);
            this.ControlBox = false;
            this.Controls.Add(this.gmnMap);
            this.Controls.Add(this.toolsMap);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.SizableToolWindow;
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.MaximizeBox = false;
            this.MinimizeBox = false;
            this.MinimumSize = new System.Drawing.Size(256, 122);
            this.Name = "FormMap";
            this.StartPosition = System.Windows.Forms.FormStartPosition.Manual;
            this.Text = "Map";
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
        private System.Windows.Forms.ToolStripButton btnZoomToMax;
        private System.Windows.Forms.ToolStripButton btnZoomOut;
        private System.Windows.Forms.ToolStripButton btnZoomIn;
        private System.Windows.Forms.ToolStripButton btnZoomToMin;
        private GMap.NET.WindowsForms.GMapControl gmnMap;
        private System.Windows.Forms.ToolStripDropDownButton ddbOptions;
        private System.Windows.Forms.ToolStripMenuItem menuItemIAEAColors;
    }
}