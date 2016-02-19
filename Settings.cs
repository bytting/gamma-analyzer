using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Xml;
using System.Xml.Serialization;

namespace crash
{
    [Serializable()]
    public class Detector
    {
        public string Name;
        public string SerialNumber;
        public string Type;
        public int MaxChannels;
    }

    [Serializable()]
    public class Settings
    {        
        public List<Detector> Detectors = new List<Detector>();
        public string DefaultDetector;
        public string DefaultDetectorType;
        public int DefaultNrChannels;
        public string SessionDirectory;
    }    
}
