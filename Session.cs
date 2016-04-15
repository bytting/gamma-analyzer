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
using Newtonsoft.Json;

namespace crash
{
    public class Session
    {
        public string Name { get; private set; }
        public float NumChannels { get; private set; }
        public float MaxChannelCount { get; private set; }
        public float MinChannelCount { get; private set; }        
        public List<Spectrum> Spectrums { get; private set; }
        public string SessionPath { get; private set; }

        public Session()
        {            
            Spectrums = new List<Spectrum>();
        }

        public Session(string sessionPath, string name)
        {
            Name = name;
            SessionPath = sessionPath + Path.DirectorySeparatorChar + Name;            
            Spectrums = new List<Spectrum>();

            if (!Directory.Exists(sessionPath))
                Directory.CreateDirectory(sessionPath);

            if (!Directory.Exists(SessionPath))
                Directory.CreateDirectory(SessionPath);            
        }

        public void Add(Spectrum spec)
        {
            Spectrums.Add(spec);
            NumChannels = spec.NumChannels;

            if (spec.MaxCount > MaxChannelCount)
                MaxChannelCount = spec.MaxCount;
            if (spec.MinCount < MinChannelCount)
                MinChannelCount = spec.MinCount;

            string jsonPath = SessionPath + Path.DirectorySeparatorChar + "json";
            if (!Directory.Exists(jsonPath))
                Directory.CreateDirectory(jsonPath);

            string json = JsonConvert.SerializeObject(spec, Formatting.Indented);
            TextWriter writer = new StreamWriter(jsonPath + Path.DirectorySeparatorChar + spec.SessionIndex + ".json");            
            writer.Write(json);
            writer.Close();

            /*if (cbStoreChn.Checked)
            {
                string chnPath = path + Path.DirectorySeparatorChar + "chn";
                if (!Directory.Exists(chnPath))
                    Directory.CreateDirectory(chnPath);
                filename = chnPath + Path.DirectorySeparatorChar + spec.SessionIndex + ".chn";
                burn.CHN.Write(filename, msg);
            }*/
        }

        public bool IsEmpty
        {
            get
            {
                return Spectrums.Count < 1;
            }
            private set {}            
        }

        public void Clear()
        {
            Name = String.Empty;
            NumChannels = 0;
            MaxChannelCount = 0;
            MinChannelCount = 0;
            Spectrums.Clear();
        }

        public bool Load(string sessionPath, string sessionName)
        {            
            SessionPath = sessionPath;
            Name = sessionName;
            Clear();

            string dir = sessionPath + Path.DirectorySeparatorChar + sessionName;
            if (!Directory.Exists(SessionPath))
                return false;

            if (!Directory.Exists(SessionPath + Path.DirectorySeparatorChar + Name))
                return false;

            string jsonDir = SessionPath + Path.DirectorySeparatorChar + Name + "json";

            if (!Directory.Exists(jsonDir))
                return false;            

            string detectorSettingsFile = SessionPath + Path.DirectorySeparatorChar + Name + Path.DirectorySeparatorChar + "detector.json";
            if (!File.Exists(detectorSettingsFile))
                return false;

            string detectorTypeSettingsFile = SessionPath + Path.DirectorySeparatorChar + Name + Path.DirectorySeparatorChar + "detector_type.json";
            if (!File.Exists(detectorTypeSettingsFile))
                return false;

            string jsonDetector = File.ReadAllText(detectorSettingsFile);
            Detector det = JsonConvert.DeserializeObject<Detector>(jsonDetector);

            string jsonDetectorType = File.ReadAllText(detectorTypeSettingsFile);
            DetectorType detType = JsonConvert.DeserializeObject<DetectorType>(jsonDetectorType);

            string[] files = Directory.GetFiles(jsonDir, "*.json", SearchOption.TopDirectoryOnly);

            foreach (string filename in files)
            {
                string json = File.ReadAllText(filename);
                Spectrum spec = JsonConvert.DeserializeObject<Spectrum>(json);                
                Add(spec);
            }
            return true;
        }

        public float[] GetAdjustedCounts(float livetime)
        {
            if (Spectrums.Count < 1)
                return null;

            float[] spec = new float[(int)NumChannels];

            foreach(Spectrum s in Spectrums)            
                for (int i = 0; i < s.Channels.Count; i++)                
                    spec[i] += s.Channels[i];                                     
            
            float scale = livetime / Spectrums[0].Livetime;

            for (int i = 0; i < spec.Length; i++)
            {
                spec[i] /= (float)Spectrums.Count;
                spec[i] *= scale;                
            }

            return spec;
        }

        public float GetMaxCountInROI(int start, int end)
        {
            float max = 0f;

            foreach (Spectrum s in Spectrums)
            {
                float curr = s.GetCountInROI(start, end);
                if (curr > max)
                    max = curr;
            }
            return max;
        }
    }
}
