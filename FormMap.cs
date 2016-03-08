using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Globalization;
using GMap.NET;
using GMap.NET.MapProviders;
using GMap.NET.WindowsForms;
using GMap.NET.WindowsForms.Markers;

namespace crash
{
    public partial class FormMap : Form
    {
        Session session = null;
        GMapOverlay overlay = new GMapOverlay();

        public FormMap()
        {
            InitializeComponent();
        }

        private void FormMap_Load(object sender, EventArgs e)
        {
            gmap.Overlays.Add(overlay);
            gmap.Position = new GMap.NET.PointLatLng(59.946534, 10.598574);
        }

        private void cboxMapMode_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (!String.IsNullOrEmpty(cboxMapMode.Text))
            {
                switch (cboxMapMode.Text)
                {
                    case "Server":
                        GMaps.Instance.Mode = AccessMode.ServerOnly;
                        break;
                    case "Cache":
                        GMaps.Instance.Mode = AccessMode.CacheOnly;
                        break;
                    default:
                        GMaps.Instance.Mode = AccessMode.ServerAndCache;
                        break;
                }
            }
        }

        private void cboxMapProvider_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (!String.IsNullOrEmpty(cboxMapProvider.Text))
            {
                switch (cboxMapProvider.Text)
                {
                    case "Google Map":
                        gmap.MapProvider = GoogleMapProvider.Instance;
                        break;
                    case "Google Map Terrain":
                        gmap.MapProvider = GoogleTerrainMapProvider.Instance;
                        break;
                    case "Open Street Map":
                        gmap.MapProvider = OpenStreetMapProvider.Instance;
                        break;
                    case "Open Street Map Quest":
                        gmap.MapProvider = OpenStreetMapQuestProvider.Instance;
                        break;
                    case "ArcGIS World Topo":
                        gmap.MapProvider = ArcGIS_World_Topo_MapProvider.Instance;
                        break;
                    case "Bing Map":
                        gmap.MapProvider = BingMapProvider.Instance;
                        break;
                }
                //gmap.Position = new GMap.NET.PointLatLng(59.946534, 10.598574);
                //gmap.Zoom = 12;
            }
        }  
      
        public void SetSession(Session sess)
        {
            session = sess;
            overlay.Clear();            
        }

        public void AddMarker(Spectrum s)
        {
            if (session == null)
                return;

            // Add map marker                                                                                                
            GMarkerGoogle marker = new GMarkerGoogle(new PointLatLng(s.LatitudeStart, s.LongitudeStart), new Bitmap(@"C:\dev\crash\images\marker-blue-32.png"));
            overlay.Markers.Add(marker);
        }

        private void FormMap_FormClosing(object sender, FormClosingEventArgs e)
        {
            e.Cancel = true;
            Hide();
        }

        private void btnGoToLatLon_Click(object sender, EventArgs e)
        {
            if(String.IsNullOrEmpty(tbLat.Text) || String.IsNullOrEmpty(tbLon.Text))
            {
                MessageBox.Show("Missing one or more coordinates");
                return;
            }

            double lat = Convert.ToDouble(tbLat.Text);
            double lon = Convert.ToDouble(tbLon.Text);

            gmap.Position = new GMap.NET.PointLatLng(lat, lon);
        }        

        private void tbLatLon_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (!char.IsDigit(e.KeyChar)
                && e.KeyChar.ToString() != CultureInfo.CurrentCulture.NumberFormat.NumberDecimalSeparator
                && e.KeyChar != '\b')
            {
                e.Handled = true;
                return;
            }
        }
    }
}
