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
using System.IO;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Globalization;

namespace crash
{
    public class Spectrum
    {
        private List<float> mChannels;
        public string SessionName { get; private set; }
        public int SessionIndex { get; private set; }
        public string Label { get; private set; }
        public List<float> Channels { get { return mChannels; } }
        public float NumChannels { get; private set; }
        public float MaxCount { get; private set; }
        public float MinCount { get; private set; }
        public float TotalCount { get; private set; }
        public bool IsPreview { get; private set; }
        public double LatitudeStart { get; private set; }
        public double LongitudeStart { get; private set; }
        public double AltitudeStart { get; private set; }
        public double LatitudeEnd { get; private set; }
        public double LongitudeEnd { get; private set; }
        public double AltitudeEnd { get; private set; }
        public DateTime GpsTimeStart { get; private set; }
        public DateTime GpsTimeEnd { get; private set; }
        public float GpsSpeedStart { get; private set; }
        public float GpsSpeedEnd { get; private set; }
        public int Realtime { get; private set; }
        public int Livetime { get; private set; }
        public int SpectralInput { get; private set; }
        public double Doserate { get; private set; }        

        public Spectrum()
        {
            mChannels = new List<float>();
        }

        public Spectrum(burn.Message msg)
        {
            SessionName = msg.Arguments["session_name"].ToString();
            SessionIndex = Convert.ToInt32(msg.Arguments["session_index"]);
            Label = "Spectrum " + SessionIndex.ToString();
            NumChannels = Convert.ToInt32(msg.Arguments["num_channels"]);
            IsPreview = msg.Arguments["preview"].ToString() == "1";
            LatitudeStart = Convert.ToDouble(msg.Arguments["latitude_start"], CultureInfo.InvariantCulture);
            LongitudeStart = Convert.ToDouble(msg.Arguments["longitude_start"], CultureInfo.InvariantCulture);
            AltitudeStart = Convert.ToDouble(msg.Arguments["altitude_start"], CultureInfo.InvariantCulture);
            LatitudeEnd = Convert.ToDouble(msg.Arguments["latitude_end"], CultureInfo.InvariantCulture);
            LongitudeEnd = Convert.ToDouble(msg.Arguments["longitude_end"], CultureInfo.InvariantCulture);
            AltitudeEnd = Convert.ToDouble(msg.Arguments["altitude_end"], CultureInfo.InvariantCulture);
            GpsTimeStart = Convert.ToDateTime(msg.Arguments["gps_time_start"], CultureInfo.InvariantCulture);
            GpsTimeEnd = Convert.ToDateTime(msg.Arguments["gps_time_end"], CultureInfo.InvariantCulture);
            GpsSpeedStart = Convert.ToSingle(msg.Arguments["gps_speed_start"], CultureInfo.InvariantCulture);
            GpsSpeedEnd = Convert.ToSingle(msg.Arguments["gps_speed_end"], CultureInfo.InvariantCulture);
            Realtime = Convert.ToInt32(msg.Arguments["realtime"]);
            Livetime = Convert.ToInt32(msg.Arguments["livetime"]);
            SpectralInput = Convert.ToInt32(msg.Arguments["spectral_input"]);
            mChannels = new List<float>();
            TotalCount = 0f;
            string[] items = msg.Arguments["channels"].ToString().Split(new char[] { ' ' }, StringSplitOptions.RemoveEmptyEntries);
            foreach (string item in items)
            {
                float ch = Convert.ToSingle(item);
                mChannels.Add(ch);

                if (ch > MaxCount)
                    MaxCount = ch;
                if (ch < MinCount)
                    MinCount = ch;

                TotalCount += ch;                                          
            }

            Doserate = 0.0;                        
        }

        public float GetCountInROI(int start, int end)
        {
            float max = 0f;
            for (int i = start; i < end; i++)
                max += mChannels[i];
            return max;
        }

        public override string ToString()
        {
            return SessionName + " - " + SessionIndex.ToString();
        }

        public bool CalculateDoserate(Detector det, dynamic GEFactor)
        {
            if (det == null)
                return false;            

            if ((det.RegPoint1X == 0f && det.RegPoint1Y == 0f) || (det.RegPoint2X == 0f && det.RegPoint2Y == 0f))
                return false;
            
            double slope = (det.RegPoint2Y - det.RegPoint1Y) / (det.RegPoint2X - det.RegPoint1X);            
            Doserate = 0.0;

            for (int i = det.CurrentLLD; i < det.CurrentULD; i++)
            {
                float sec = (float)Livetime / 1000000f;                
                float cps = Channels[i] / sec;
                double E = det.RegPoint1Y + ((double)i * slope - det.RegPoint1X * slope);
                double GE = GEFactor(E / 1000.0);
                Doserate += GE * cps * 60.0;
            }

            return true;
        }
    }
}
