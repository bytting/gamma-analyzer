using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Xml;
using System.Xml.Serialization;

namespace crash
{    
    [Serializable()]
    public class Detector
    {
        public string TypeName { get; set; }
        public int CurrentHV { get; set; }
        public int CurrentNumChannels { get; set; }
        public string Serialnumber { get; set; }
        public int CurrentCoarseGain { get; set; }
        public double CurrentFineGain { get; set; }
        public double CurrentEnergySlope { get; set; }
        public int CurrentLivetime { get; set; }
        public int CurrentLLD { get; set; }
        public int CurrentULD { get; set; }

        public Detector()
        {
        }
    }
}
