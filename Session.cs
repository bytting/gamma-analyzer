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
        public float NumChannels { get; private set; }
        public float MaxChannelCount { get; private set; }
        public float MinChannelCount { get; private set; }        
        public List<Spectrum> Spectrums { get; private set; }
        public string SessionPath { get; private set; }
        public SessionInfo Info { get; private set; }
        public dynamic GEFactor = null;

        public Session()
        {
            Info = new SessionInfo();
            Spectrums = new List<Spectrum>();
        }

        public Session(string sessionPath, string name, string comment, Detector det, string geScript)
        {
            Info = new SessionInfo(name, comment, det, geScript);

            dynamic scope = Utils.PyEngine.CreateScope();
            Utils.PyEngine.Execute(Info.GEScript, scope);
            GEFactor = scope.GetVariable<Func<double, double>>("GEFactor");

            SessionPath = sessionPath + Path.DirectorySeparatorChar + Info.Name;
            Spectrums = new List<Spectrum>();

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
        }

        public bool IsLoaded
        {
            get { return Info != null && !String.IsNullOrEmpty(Info.Name); }
        }

        public bool IsEmpty
        {
            get { return Spectrums.Count == 0; }            
        }

        public void Clear()
        {
            SessionPath = String.Empty;                        
            NumChannels = 0;
            MaxChannelCount = 0;
            MinChannelCount = 0;
            Spectrums.Clear();
            Info = null;
        }

        public bool Load(string path)
        {
            Clear();
            SessionPath = path;            

            string sessionInfoFile = SessionPath + Path.DirectorySeparatorChar + "session.json";
            if (!File.Exists(sessionInfoFile))
                return false;            

            string jsonDir = SessionPath + Path.DirectorySeparatorChar + "json";
            if (!Directory.Exists(jsonDir))
                return false;            

            Info = JsonConvert.DeserializeObject<SessionInfo>(File.ReadAllText(sessionInfoFile));
            dynamic scope = Utils.PyEngine.CreateScope();
            Utils.PyEngine.Execute(Info.GEScript, scope);
            GEFactor = scope.GetVariable<Func<double, double>>("GEFactor");

            string[] files = Directory.GetFiles(jsonDir, "*.json", SearchOption.TopDirectoryOnly);
            foreach (string filename in files)
            {
                string json = File.ReadAllText(filename);
                burn.Message msg = JsonConvert.DeserializeObject<burn.Message>(json);
                Spectrum spec = new Spectrum(msg);                
                spec.CalculateDoserate(Info.Detector, GEFactor);
                Add(spec);
            }

            Spectrums.Sort((a, b) => a.SessionIndex.CompareTo(b.SessionIndex));
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

    public class SessionInfo
    {
        public SessionInfo()
        {            
        }

        public SessionInfo(string name, string comment, Detector det, string geScript)
        {
            Name = name;
            Comment = comment;
            Detector = det;
            GEScript = geScript;
        }

        public string Name { get; set; }        
        public string Comment { get; set; }
        public Detector Detector;
        public string GEScript { get; set; }        
    }
}
