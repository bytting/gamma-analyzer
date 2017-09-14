/*	
	Gamma Analyzer - Controlling application for Burn
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
using System.Collections.Generic;
using System.Globalization;
using NLua;

namespace crash
{
    // Class used to store a spectrum
    public class Spectrum
    {
        // List of channels
        private List<float> mChannels;

        // Name of parent session
        public string SessionName { get; set; }

        // This spectrums session index
        public int SessionIndex { get; set; }

        // Label to use for this spectrum
        public string Label { get; set; }

        // Property to access channels
        public List<float> Channels { get { return mChannels; } }

        // Number of channels used for this spectrum
        public float NumChannels { get; set; }

        // Max count found in this spectrum
        public float MaxCount { get; set; }

        // Min count found in this spectrum
        public float MinCount { get; set; }

        // Total counts stored in this spectrum
        public float TotalCount { get; set; }        

        // Latitude when this spectrum was started
        public double Latitude { get; set; }

        // Latitude error when this spectrum was started
        public double LatitudeError { get; set; }

        // Longitude when this spectrum was started
        public double Longitude { get; set; }

        // Longitude error when this spectrum was started
        public double LongitudeError { get; set; }

        // Altitude when this spectrum was started
        public double Altitude { get; set; }

        // Altitude error when this spectrum was started
        public double AltitudeError { get; set; }                

        // Date and time when this spectrum was started
        public DateTime GpsTime { get; set; }

        public float GpsTrack { get; set; }
        
        public float GpsTrackError { get; set; }

        // Speed when this spectrum was started
        public float GpsSpeed { get; set; }

        // Speed error when this spectrum was started
        public float GpsSpeedError { get; set; }

        // Climb when this spectrum was started
        public float GpsClimb { get; set; }

        // Climb error when this spectrum was started
        public float GpsClimbError { get; set; }

        // Realtime for this spectrum
        public int Realtime { get; set; }

        // Livetime for this spectrum
        public int Livetime { get; set; }        

        // Doserate for this spectrum in nanosievert per hour
        public double Doserate { get; set; }        

        public Spectrum()
        {
            mChannels = new List<float>();
        }

        public Spectrum(burn.ProtocolMessage msg)
        {                        
            SessionName = msg.Params["session_name"].ToString();
            SessionIndex = Convert.ToInt32(msg.Params["index"]);
            Label = "Spectrum " + SessionIndex;
            NumChannels = Convert.ToInt32(msg.Params["num_channels"]);
            Latitude = Convert.ToDouble(msg.Params["latitude"], CultureInfo.InvariantCulture);
            LatitudeError = Convert.ToDouble(msg.Params["latitude_error"], CultureInfo.InvariantCulture);
            Longitude = Convert.ToDouble(msg.Params["longitude"], CultureInfo.InvariantCulture);
            LongitudeError = Convert.ToDouble(msg.Params["longitude_error"], CultureInfo.InvariantCulture);
            Altitude = Convert.ToDouble(msg.Params["altitude"], CultureInfo.InvariantCulture);
            AltitudeError = Convert.ToDouble(msg.Params["altitude_error"], CultureInfo.InvariantCulture);
            GpsTime = Convert.ToDateTime(msg.Params["time"]);
            GpsTrack = Convert.ToSingle(msg.Params["track"], CultureInfo.InvariantCulture);
            GpsTrackError = Convert.ToSingle(msg.Params["track_error"], CultureInfo.InvariantCulture);
            GpsSpeed = Convert.ToSingle(msg.Params["speed"], CultureInfo.InvariantCulture);
            GpsSpeedError = Convert.ToSingle(msg.Params["speed_error"], CultureInfo.InvariantCulture);
            GpsClimb = Convert.ToSingle(msg.Params["climb"], CultureInfo.InvariantCulture);
            GpsClimbError = Convert.ToSingle(msg.Params["climb_error"], CultureInfo.InvariantCulture);
            Realtime = Convert.ToInt32(msg.Params["realtime"]);
            Livetime = Convert.ToInt32(msg.Params["livetime"]);
            TotalCount = 0f;
            Doserate = 0.0;
            mChannels = new List<float>();
            // Split channel string and store each count in channel array
            LoadSpectrumString(msg.Params["channels"].ToString());
        }

        public override string ToString()
        {
            return SessionName + " - " + SessionIndex.ToString();
        }

        public void LoadSpectrumString(string spectrums)
        {
            mChannels.Clear();
            string[] items = spectrums.Split(new char[] { ' ' }, StringSplitOptions.RemoveEmptyEntries);
            foreach (string item in items)
            {
                float ch = Convert.ToSingle(item, CultureInfo.InvariantCulture);
                mChannels.Add(ch);

                if (ch > MaxCount)
                    MaxCount = ch;
                if (ch < MinCount)
                    MinCount = ch;

                TotalCount += ch;
            }
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

        public double CalculateDoserate(Detector det, LuaFunction GEFactorFunc)
        {
            // Calculate doserate for this spectrum

            if (det == null || GEFactorFunc == null)
                return 0d;                        
            
            Doserate = 0.0;

            // Trim off discriminators
            int startChan = (int)((double)det.NumChannels * ((double)det.LLD / 100.0));
            int endChan = (int)((double)det.NumChannels * ((double)det.ULD / 100.0));
            if(endChan > det.NumChannels) // FIXME: Can not exceed 100% atm
                endChan = det.NumChannels;

            // Accumulate doserates of each channel
            for (int i = startChan; i < endChan; i++)
            {
                float sec = (float)Livetime / 1000000f;                
                float cps = Channels[i] / sec;
                double E = det.GetEnergy(i);
                if (E < 0.05) // Energies below 0.05 are invalid
                    continue;

                double GE = (double)GEFactorFunc.Call(E / 1000.0).GetValue(0);
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
            res.Latitude = Latitude;
            res.LatitudeError = LatitudeError;
            res.Longitude = Longitude;
            res.LongitudeError = LongitudeError;
            res.Altitude = Altitude;                        
            res.AltitudeError = AltitudeError;
            res.GpsTime = GpsTime;
            res.GpsTrack = GpsTrack;
            res.GpsTrackError = GpsTrackError;
            res.GpsSpeed = GpsSpeed;
            res.GpsSpeedError = GpsSpeedError;
            res.GpsClimb = GpsClimb;
            res.GpsClimbError = GpsClimbError;
            res.Realtime = Realtime;
            res.Livetime = Livetime;
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
}
