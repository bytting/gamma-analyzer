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
                writer.WriteLine("Session name|Session index|Time start|Time end|Latitude start|Latitude end|Longitude start|Longitude end|Altitude start|Altitude end|Doserate|Doserate unit");

                foreach (Spectrum s in session.Spectrums)
                {
                    double dose = s.Doserate / 1000d;
                    
                    writer.WriteLine(
                        s.SessionName + "|"
                        + s.SessionIndex.ToString() + "|"
                        + s.GpsTimeStart.ToString("yyyy-MM-ddTHH:mm:ss") + "|"
                        + s.GpsTimeEnd.ToString("yyyy-MM-ddTHH:mm:ss") + "|"
                        + s.LatitudeStart.ToString(CultureInfo.InvariantCulture) + "|"
                        + s.LatitudeEnd.ToString(CultureInfo.InvariantCulture) + "|"
                        + s.LongitudeStart.ToString(CultureInfo.InvariantCulture) + "|"
                        + s.LongitudeEnd.ToString(CultureInfo.InvariantCulture) + "|"
                        + s.AltitudeStart.ToString(CultureInfo.InvariantCulture) + "|"
                        + s.AltitudeEnd.ToString(CultureInfo.InvariantCulture) + "|"
                        + dose.ToString(CultureInfo.InvariantCulture) + "|μSv/h");
                }
            }
        }

        public static void ExportAsCHN(Session session, string path)
        {
            foreach(Spectrum s in session.Spectrums)
            {                
                string sessionPath = path + Path.DirectorySeparatorChar + session.Name + "_CHN";
                if (!Directory.Exists(sessionPath))
                    Directory.CreateDirectory(sessionPath);

                string filename = sessionPath + Path.DirectorySeparatorChar + s.SessionIndex.ToString() + ".chn";
                using (BinaryWriter writer = new BinaryWriter(File.Create(filename)))
                {
                    string dateStr = s.GpsTimeStart.ToString("ddMMMyy") + "1";
                    dateStr = dateStr.ToUpper();
                    string timeStr = s.GpsTimeStart.ToString("HHmm");

                    string secStr = s.GpsTimeStart.ToString("ss");

                    writer.Write(Convert.ToInt16(-1)); // signature
                    writer.Write(Convert.ToInt16(s.SpectralInput)); // detector id
                    writer.Write(Convert.ToInt16(0)); // segment
                    writer.Write(Encoding.ASCII.GetBytes(secStr)); // seconds start
                    Int32 rt = s.Realtime / 1000; // ms                    
                    rt = rt / 20; // increments of 20 ms
                    writer.Write(rt); // realtime
                    Int32 lt = s.Livetime / 1000; // ms                    
                    lt = lt / 20; // increments of 20 ms
                    writer.Write(lt); // livetime                    
                    writer.Write(Encoding.ASCII.GetBytes(dateStr)); // date
                    writer.Write(Encoding.ASCII.GetBytes(timeStr)); // time
                    writer.Write(Convert.ToInt16(0)); // channel offset
                    writer.Write(Convert.ToInt16(s.NumChannels)); // number of channels

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
            string kmzFile = filename;
            string kmlFile = Path.GetDirectoryName(filename) + Path.DirectorySeparatorChar + Path.GetFileNameWithoutExtension(filename) + ".kml";
            string donutFile = CrashEnvironment.SettingsPath + Path.DirectorySeparatorChar + "donut.png";

            using (XmlWriter writer = XmlWriter.Create(kmlFile))
            {
                writer.WriteStartDocument();                
                writer.WriteStartElement("kml");
                writer.WriteString("\n");
                writer.WriteStartElement("Document");
                writer.WriteString("\n");

                KmlStyle s = new KmlStyle();
                string[] colors = { "FFF0B414", "FF00D214", "FF78FFF0", "FF1478FF", "FF1400FF" };
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

                serializer = new XmlSerializer(typeof(KmlPlacemark));
                KmlPlacemark p = new KmlPlacemark();
                int styleID = 0;

                foreach (Spectrum spec in session.Spectrums)
                {
                    double dose = spec.Doserate / 1000d;

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
	                p.TimeStamp.When = spec.GpsTimeStart.ToString("yyyy-MM-ddTHH:mm:ss");
                    p.Point.Coordinates = spec.LongitudeStart.ToString(CultureInfo.InvariantCulture) + "," + spec.LatitudeStart.ToString(CultureInfo.InvariantCulture);
                    p.Description = "Value: " + dose.ToString("e", CultureInfo.InvariantCulture) + " μSv/h" +
                        "\nLatitude: " + spec.LatitudeStart.ToString(CultureInfo.InvariantCulture) +
                        "\nLongitude: " + spec.LongitudeStart.ToString(CultureInfo.InvariantCulture) +
                        "\nAltitude: " + spec.AltitudeStart.ToString(CultureInfo.InvariantCulture) +
                        "\nTime: " + spec.GpsTimeStart.ToString("yyyy-MM-dd HH:mm:ss") + " UTC";

                    serializer.Serialize(writer, p, ns);
                    writer.WriteString("\n");                    
                }
                
                writer.WriteEndElement();
                writer.WriteString("\n");
                writer.WriteEndElement();                
                writer.WriteEndDocument();                
            }

            Bitmap bmpDonut = new Bitmap(crash.Properties.Resources.donut);
            bmpDonut.Save(donutFile, ImageFormat.Png);

            using (ZipFile zip = new ZipFile())
            {
                zip.AddFile(kmlFile, "");
                zip.AddFile(donutFile, "files");                
                zip.Save(kmzFile);
            }

            if (File.Exists(donutFile))
                File.Delete(donutFile);

            if(File.Exists(kmlFile))
                File.Delete(kmlFile);
        }
    }
}
