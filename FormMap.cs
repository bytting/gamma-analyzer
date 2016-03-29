/*	
	Crash - Controlling application for Burn
    Copyright (C) 2016  Norwegian Radiation Protection Authority

    This program is free software: you can redistribute it and/or modify
    it under the terms of the GNU General Public License as published by
    the Free Software Foundation, either version 3 of the License, or
    (at your option) any later version.

    This program is distributed in the hope that it will be useful,
    but WITHOUT ANY WARRANTY; without even the implied warranty of
    MERCHANTABILITY or FITNESS FOR A PARTICULAR PURPOSE.  See the
    GNU General Public License for more details.

    You should have received a copy of the GNU General Public License
    along with this program.  If not, see <http://www.gnu.org/licenses/>.
*/
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

        public delegate void SetSessionIndexEventHandler(object sender, SetSessionIndexEventArgs e);
        public event SetSessionIndexEventHandler SetSessionIndexEvent;

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
            CustomMarker marker = new CustomMarker(new PointLatLng(s.LatitudeStart, s.LongitudeStart));
            marker.Tag = s;
            marker.ToolTipMode = MarkerTooltipMode.OnMouseOver;
            marker.ToolTipText = s.ToString() 
                + Environment.NewLine + "Lat start: " + s.LatitudeStart 
                + Environment.NewLine + "Lon start: " + s.LongitudeStart 
                + Environment.NewLine + "Alt start: " + s.AltitudeStart;
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

        private void gmap_OnMarkerClick(GMapMarker item, MouseEventArgs e)
        {            
            if (SetSessionIndexEvent != null)
            {
                SetSessionIndexEventArgs args = new SetSessionIndexEventArgs();
                Spectrum s = (Spectrum)item.Tag;
                args.Index = s.SessionIndex;
                SetSessionIndexEvent(this, args);
            }
        }

        public void SetSelectedSessionIndex(int index)
        {            
            foreach(CustomMarker m in overlay.Markers)
            {
                Spectrum s = (Spectrum)m.Tag;
                if(s.SessionIndex == index)                
                    m.SetSelected(true);                                
                else                
                    m.SetSelected(false);                
            }
            gmap.Refresh();
        }
    }

    public class CustomMarker : GMapMarker
    {
        private bool mSelected = false;
 
        private static Bitmap bmpDefault = new Bitmap(@"C:\dev\crash\images\marker-blue-32.png"); // FIXME
        private static Bitmap bmpSelected = new Bitmap(@"C:\dev\crash\images\marker-red-32.png");

        public CustomMarker(PointLatLng pll) : base(pll)
        {            
        }
        
        public override void OnRender(Graphics g)
        {
            if(mSelected == false)
                g.DrawImage(bmpDefault, new Point(LocalPosition.X - bmpDefault.Width / 2, LocalPosition.Y - bmpDefault.Height / 2));
            else g.DrawImage(bmpSelected, new Point(LocalPosition.X - bmpSelected.Width / 2, LocalPosition.Y - bmpSelected.Height / 2));
        }                    

        public void SetSelected(bool state)
        {
            mSelected = state;            
        }
    }
}
