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
using System.Globalization;
using Newtonsoft.Json;

namespace crash
{
    // Class used to store a spectrum
    public class Spectrum
    {
        // List of channels
        private List<float> mChannels;

        // Name of parent session
        public string SessionName { get; private set; }

        // This spectrums session index
        public int SessionIndex { get; private set; }

        // Label to use for this spectrum
        public string Label { get; private set; }

        // Property to access channels
        public List<float> Channels { get { return mChannels; } }

        // Number of channels used for this spectrum
        public float NumChannels { get; private set; }

        // Max count found in this spectrum
        public float MaxCount { get; private set; }

        // Min count found in this spectrum
        public float MinCount { get; private set; }

        // Total counts stored in this spectrum
        public float TotalCount { get; private set; }

        // Preview state
        public bool IsPreview { get; private set; }

        // Latitude when this spectrum was started
        public double LatitudeStart { get; private set; }

        // Longitude when this spectrum was started
        public double LongitudeStart { get; private set; }

        // Altitude when this spectrum was started
        public double AltitudeStart { get; private set; }

        // Latitude when this spectrum was stopped
        public double LatitudeEnd { get; private set; }

        // Longitude when this spectrum was stopped
        public double LongitudeEnd { get; private set; }

        // Altitude when this spectrum was stopped
        public double AltitudeEnd { get; private set; }

        // Date and time when this spectrum was started
        public DateTime GpsTimeStart { get; private set; }

        // Date and time when this spectrum was stopped
        public DateTime GpsTimeEnd { get; private set; }

        // Speed when this spectrum was started
        public float GpsSpeedStart { get; private set; }

        // Speed when this spectrum was stopped
        public float GpsSpeedEnd { get; private set; }

        // Realtime for this spectrum
        public int Realtime { get; private set; }

        // Livetime for this spectrum
        public int Livetime { get; private set; }

        // Osprey detector ID used with this spectrum (FIXME: remove this)
        public int SpectralInput { get; private set; }

        // Doserate for this spectrum in nanosievert per hour
        public double Doserate { get; private set; }        

        public Spectrum()
        {
            mChannels = new List<float>();
        }

        public Spectrum(burn.Message msg)
        {
            // FIXME: sanity checks
            SessionName = msg.Arguments["session_name"].ToString();
            SessionIndex = GetInt32(msg.Arguments["session_index"]);
            Label = "Spectrum " + SessionIndex.ToString();
            NumChannels = GetInt32(msg.Arguments["num_channels"]);
            IsPreview = msg.Arguments["preview"].ToString() == "1";
            LatitudeStart = GetDouble(msg.Arguments["latitude_start"]);
            LongitudeStart = GetDouble(msg.Arguments["longitude_start"]);
            AltitudeStart = GetDouble(msg.Arguments["altitude_start"]);
            LatitudeEnd = GetDouble(msg.Arguments["latitude_end"]);
            LongitudeEnd = GetDouble(msg.Arguments["longitude_end"]);
            AltitudeEnd = GetDouble(msg.Arguments["altitude_end"]);
            GpsTimeStart = GetDateTime(msg.Arguments["gps_time_start"]);
            GpsTimeEnd = GetDateTime(msg.Arguments["gps_time_end"]);                        
            GpsSpeedStart = GetSingle(msg.Arguments["gps_speed_start"]);
            GpsSpeedEnd = GetSingle(msg.Arguments["gps_speed_end"]);
            Realtime = GetInt32(msg.Arguments["realtime"]);
            Livetime = GetInt32(msg.Arguments["livetime"]);
            SpectralInput = GetInt32(msg.Arguments["spectral_input"]);            
            mChannels = new List<float>();
            TotalCount = 0f;
            // Split channel string and store each count in channel array
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

        private Int32 GetInt32(object o)
        {
            Int32 i;
            try
            {
                i = Convert.ToInt32(o);
            }
            catch
            {
                i = 0;
            }

            return i;
        }

        private Single GetSingle(object o)
        {
            Single s;
            try
            {
                s = Convert.ToSingle(o, CultureInfo.InvariantCulture);                
            }
            catch
            {
                s = 0f;
            }

            return s;
        }

        private Double GetDouble(object o)
        {
            Double d;
            try
            {
                d = Convert.ToDouble(o, CultureInfo.InvariantCulture);
            }
            catch
            {
                d = 0f;
            }

            return d;
        }

        private DateTime GetDateTime(object o)
        {
            DateTime dt;
            try
            {
                dt = Convert.ToDateTime(o, CultureInfo.InvariantCulture);
            }
            catch
            {
                dt = DateTime.Now;
            }

            return dt;
        }

        public float GetCountInROI(int start, int end)
        {
            // Get count for a given ROI

            if (start < 0 || start >= mChannels.Count || end < 0 || end >= mChannels.Count)
                return 0f;

            float max = 0f;
            for (int i = start; i < end; i++)            
                max += mChannels[i];            
            return max;
        }

        public double GetElevation(string apiKey)
        {
            // Request approximate altitude for this spectrum

            using (System.Net.WebClient wc = new System.Net.WebClient())
            {
                string query = "https://maps.googleapis.com/maps/api/elevation/json?locations=" 
                    + LatitudeStart.ToString(CultureInfo.InvariantCulture) + "," + LongitudeStart.ToString(CultureInfo.InvariantCulture) 
                    + "&key=" + apiKey;

                var json = wc.DownloadString(query);

                ElevationData ed = JsonConvert.DeserializeObject<ElevationData>(json);
                if (ed.Status.ToUpper() == "OK" && ed.Results.Count > 0)
                    return ed.Results[0].Elevation;
                else return double.MinValue;
            }
        }

        public override string ToString()
        {
            return SessionName + " - " + SessionIndex.ToString();
        }

        public double CalculateDoserate(Detector det, dynamic GEFactorFunc)
        {
            // Calculate doserate for this spectrum

            if (det == null || GEFactorFunc == null)
                return 0d;                        
            
            Doserate = 0.0;

            // Trim off discriminators
            int startChan = (int)((double)det.CurrentNumChannels * ((double)det.CurrentLLD / 100.0));
            int endChan = (int)((double)det.CurrentNumChannels * ((double)det.CurrentULD / 100.0));
            if(endChan > det.CurrentNumChannels) // FIXME: Can not exceed 100% atm
                endChan = det.CurrentNumChannels;

            // Accumulate doserates of each channel
            for (int i = startChan; i < endChan; i++)
            {
                float sec = (float)Livetime / 1000000f;                
                float cps = Channels[i] / sec;
                double E = det.GetEnergy(i);
                if (E < 0.05) // Energies below 0.05 are invalid
                    continue;
                double GE = GEFactorFunc(E / 1000.0);
                double chanDose = GE * (cps * 60.0);
                Doserate += chanDose;                
            }

            return Doserate;
        }

        public Spectrum Clone()
        {
            // Create a clone of this spectrum

            Spectrum res = new Spectrum();                        
            res.mChannels.AddRange(mChannels.ToArray());
            res.SessionName = SessionName;
            res.SessionIndex = SessionIndex;
            res.Label = Label;
            res.NumChannels = NumChannels;
            res.MaxCount = MaxCount;
            res.MinCount = MinCount;
            res.TotalCount = TotalCount;
            res.IsPreview = IsPreview;
            res.LatitudeStart = LatitudeStart;
            res.LongitudeStart = LongitudeStart;
            res.AltitudeStart = AltitudeStart;
            res.LatitudeEnd = LatitudeEnd;
            res.LongitudeEnd = LongitudeEnd;
            res.AltitudeEnd = AltitudeEnd;
            res.GpsTimeStart = GpsTimeStart;
            res.GpsTimeEnd = GpsTimeEnd;
            res.GpsSpeedStart = GpsSpeedStart;
            res.GpsSpeedEnd = GpsSpeedEnd;
            res.Realtime = Realtime;
            res.Livetime = Livetime;
            res.SpectralInput = SpectralInput;
            res.Doserate = Doserate;
            return res;
        }

        public void Merge(Spectrum s)
        {   
            // Merge a given spectrum

            Livetime += s.Livetime;
            Realtime += s.Realtime;
            for(int i=0; i<mChannels.Count; i++)            
                mChannels[i] += s.mChannels[i];        
        }
    }

    // Helper class for requiesting elevation
    public class ElevationResult
    {
        [JsonProperty(PropertyName = "elevation")]
        public double Elevation { get; set; }

        [JsonProperty(PropertyName = "location")]
        public Dictionary<string, object> Location { get; set; }   

        [JsonProperty(PropertyName = "resolution")]
        public double Resolution { get; set; }
    }

    // Helper class for requiesting elevation
    public class ElevationData
    {
        [JsonProperty(PropertyName = "results")]
        public List<ElevationResult> Results { get; set; }

        [JsonProperty(PropertyName = "status")]
        public string Status { get; set; }
    }
}
