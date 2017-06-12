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
// Authors: Dag robole,

using System;
using System.Text;
using System.IO;
using System.Drawing;
using System.Drawing.Imaging;
using System.Collections.Generic;
using System.Globalization;
using System.Xml;
using System.Xml.Serialization;
using Ionic.Zip;

namespace crash
{
    public static class SessionExporter
    {
        public static void ExportAsCSV(Session session, string filename)
        {
            // Write info for each spectrum to csv file

            using (StreamWriter writer = new StreamWriter(filename, false, Encoding.UTF8))
            {
                // Write header line
                writer.WriteLine("Session name|Session index|Time start (UTC)|Latitude|Latitude error|Longitude|Longitude error|Altitude|Altitude error|Doserate|Doserate unit");

                foreach (Spectrum s in session.Spectrums)
                {
                    double dose = s.Doserate / 1000d;
                    
                    // Write spectrum line
                    writer.WriteLine(
                        s.SessionName + "|"
                        + s.SessionIndex.ToString() + "|"
                        + s.GpsTime.ToString("yyyy-MM-ddTHH:mm:ss") + "|"                        
                        + s.Latitude.ToString(CultureInfo.InvariantCulture) + "|"
                        + s.LatitudeError.ToString(CultureInfo.InvariantCulture) + "|"
                        + s.Longitude.ToString(CultureInfo.InvariantCulture) + "|"
                        + s.LongitudeError.ToString(CultureInfo.InvariantCulture) + "|"
                        + s.Altitude.ToString(CultureInfo.InvariantCulture) + "|"
                        + s.AltitudeError.ToString(CultureInfo.InvariantCulture) + "|"
                        + dose.ToString(CultureInfo.InvariantCulture) + "|μSv/h");
                }
            }
        }

        public static void ExportAsCHN(Session session, string path)
        {
            // Generate a CHN file for each spectrum

            foreach(Spectrum s in session.Spectrums)
            {                
                string sessionPath = path + Path.DirectorySeparatorChar + session.Name + "_CHN";
                if (!Directory.Exists(sessionPath))
                    Directory.CreateDirectory(sessionPath);

                string filename = sessionPath + Path.DirectorySeparatorChar + s.SessionIndex.ToString() + ".chn";
                using (BinaryWriter writer = new BinaryWriter(File.Create(filename)))
                {
                    string dateStr = s.GpsTime.ToString("ddMMMyy") + "1";                    
                    string timeStr = s.GpsTime.ToString("HHmm");
                    string secStr = s.GpsTime.ToString("ss");

                    writer.Write(Convert.ToInt16(-1)); // signature
                    writer.Write(Convert.ToInt16(1)); // detector id
                    writer.Write(Convert.ToInt16(0)); // segment
                    writer.Write(Encoding.ASCII.GetBytes(secStr)); // seconds start
                    Int32 rt = s.Realtime / 1000; // ms                    
                    rt = rt / 20; // increments of 20 ms
                    writer.Write(rt); // realtime
                    Int32 lt = s.Livetime / 1000; // ms                    
                    lt = lt / 20; // increments of 20 ms
                    writer.Write(lt); // livetime                    
                    writer.Write(Encoding.ASCII.GetBytes(dateStr.ToUpper())); // date
                    writer.Write(Encoding.ASCII.GetBytes(timeStr)); // time
                    writer.Write(Convert.ToInt16(0)); // channel offset
                    writer.Write(Convert.ToInt16(s.NumChannels)); // number of channels

                    // Channel counts
                    foreach (float ch in s.Channels)
                        writer.Write(Convert.ToInt32(ch));
                }
            }            
        }

        // Structure representing a kml icon
        [Serializable]
        public class KmlIcon
        {
            [XmlElement(ElementName = "href")]
			public string Href { get; set; }
		}

        // Structure representing a kml icon style
        [Serializable]
        public class KmlIconStyle
        {
            public KmlIconStyle()
            {
                Icon = new KmlIcon();
            }

            [XmlElement(ElementName = "Icon")]
		    public KmlIcon Icon { get; set; }
            [XmlElement(ElementName = "scale")]
		    public string Scale { get; set; }
            [XmlElement(ElementName = "color")]
		    public string Color { get; set; }
	    }

        // Structure representing a kml label
        [Serializable]
        public class KmlLabelStyle 
        {
            [XmlElement(ElementName = "scale")]
		    public string Scale { get; set; }
	    }

        // Structure representing a kml style
        [XmlRoot(ElementName = "Style")]
        public class KmlStyle
        {
            public KmlStyle()
            {
                IconStyle = new KmlIconStyle();
                LabelStyle = new KmlLabelStyle();
            }

            [XmlAttribute("id")]
	        public string ID { get; set;}

            [XmlElement(ElementName = "IconStyle")]
            public KmlIconStyle IconStyle { get; set; }
	
            [XmlElement(ElementName = "LabelStyle")]
            public KmlLabelStyle LabelStyle { get; set; }
        }

        // Structure representing a kml timestamp
        [Serializable]
        public class KmlTimeStamp 
        {
            [XmlElement(ElementName = "when")]
		    public string When { get; set; }
	    }

        // Structure representing a kml point
        [Serializable]
        public class KmlPoint 
        {
            [XmlElement(ElementName = "coordinates")]
		    public string Coordinates { get; set; }
	    }

        // Structure representing a kml placemark
        [XmlRoot(ElementName = "Placemark")]
        public class KmlPlacemark
        {
            public KmlPlacemark()
            {
                TimeStamp = new KmlTimeStamp();
                Point = new KmlPoint();
            }

            [XmlElement(ElementName = "name")]
	        public string Name { get; set; }

            [XmlElement(ElementName = "TimeStamp")]
            public KmlTimeStamp TimeStamp { get; set; }

            [XmlElement(ElementName = "description")]
	        public string Description { get; set; }

            [XmlElement(ElementName = "Point")]
            public KmlPoint Point { get; set; }

            [XmlElement(ElementName = "styleUrl")]
            public string StyleURL { get; set; }
        }

        public static void ExportAsKMZ(Session session, string filename)
        {
            // Save session info as a KMZ file

            string kmzFile = filename;
            string kmlFile = Path.GetDirectoryName(filename) + Path.DirectorySeparatorChar + Path.GetFileNameWithoutExtension(filename) + ".kml";
            string donutFile = CrashEnvironment.SettingsPath + Path.DirectorySeparatorChar + "donut.png";

            using (XmlWriter writer = XmlWriter.Create(kmlFile))
            {
                // Initialize KML document
                writer.WriteStartDocument();                
                writer.WriteStartElement("kml");
                writer.WriteString("\n");
                writer.WriteStartElement("Document");
                writer.WriteString("\n");

                // Store KML styles
                KmlStyle s = new KmlStyle();
                string[] colors = { "FFF0B414", "FF00D214", "FF78FFF0", "FF1478FF", "FF1400FF" }; // IAEA color codes
                XmlSerializer serializer = new XmlSerializer(typeof(KmlStyle));
                XmlSerializerNamespaces ns = new XmlSerializerNamespaces();
                ns.Add("", "");
                
	            for(int i = 0; i < 5; i++) 
                {     
		            s.ID = i.ToString();
		            s.IconStyle.Icon.Href = "files/donut.png";
		            s.IconStyle.Scale = "1.0";
		            s.IconStyle.Color = colors[i];
		            s.LabelStyle.Scale = "1.0";        
                    serializer.Serialize(writer, s, ns);
                    writer.WriteString("\n");
	            }

                // Store a KML placemark for each spectrum
                serializer = new XmlSerializer(typeof(KmlPlacemark));
                KmlPlacemark p = new KmlPlacemark();
                int styleID = 0;
                
                foreach (Spectrum spec in session.Spectrums)
                {
                    double dose = spec.Doserate / 1000d; // Convert Doserate to micro

	                // Calculate the style id for this sample
	                if(dose <= 1d)                    
		                styleID = 0;
                    else if (dose <= 5)                    
		                styleID = 1;
                    else if (dose <= 10)                    
		                styleID = 2;
                    else if (dose <= 20)                    
		                styleID = 3;	                
                    else styleID = 4;

                    p.Name = "";
                    p.StyleURL = "#" + styleID.ToString();
	                p.TimeStamp.When = spec.GpsTime.ToString("yyyy-MM-ddTHH:mm:ss");
                    p.Point.Coordinates = spec.Longitude.ToString(CultureInfo.InvariantCulture) + "," + spec.Latitude.ToString(CultureInfo.InvariantCulture);
                    p.Description = "Value: " + dose.ToString("e", CultureInfo.InvariantCulture) + " μSv/h" +
                        "\nLatitude: " + spec.Latitude.ToString(CultureInfo.InvariantCulture) +
                        "\nLongitude: " + spec.Longitude.ToString(CultureInfo.InvariantCulture) +
                        "\nAltitude: " + spec.Altitude.ToString(CultureInfo.InvariantCulture) +
                        "\nTime: " + spec.GpsTime.ToString("yyyy-MM-dd HH:mm:ss") + " UTC";

                    serializer.Serialize(writer, p, ns);
                    writer.WriteString("\n");                    
                }
                
                // Finish KML document
                writer.WriteEndElement();
                writer.WriteString("\n");
                writer.WriteEndElement();                
                writer.WriteEndDocument();                
            }

            // Create a icon file to use for placemarks
            Bitmap bmpDonut = new Bitmap(crash.Properties.Resources.donut);
            bmpDonut.Save(donutFile, ImageFormat.Png);

            // Zip the KML and icon files to create a KMZ file
            using (ZipFile zip = new ZipFile())
            {
                zip.AddFile(kmlFile, "");
                zip.AddFile(donutFile, "files");                
                zip.Save(kmzFile);
            }

            // Delete temporary files
            if (File.Exists(donutFile))
                File.Delete(donutFile);

            if(File.Exists(kmlFile))
                File.Delete(kmlFile);
        }
    }
}
