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
        public Detector()
        {
            EnergyCurveCoefficients = new List<double>();        
        }

        public string TypeName { get; set; }
        public int CurrentHV { get; set; }
        public int CurrentNumChannels { get; set; }
        public string Serialnumber { get; set; }
        public double CurrentCoarseGain { get; set; }
        public double CurrentFineGain { get; set; }                        
        public int CurrentLivetime { get; set; }
        public int CurrentLLD { get; set; }
        public int CurrentULD { get; set; }
        [XmlArray("EnergyCurveCoefficients")]
        [XmlArrayItem("Value")]
        public List<double> EnergyCurveCoefficients { get; set; }        

        public override string ToString()
        {
 	         return Serialnumber;
        }

        public double GetEnergy(int x)
        {
            if (EnergyCurveCoefficients.Count < 2 || EnergyCurveCoefficients.Count > 5)
                return 0.0;

            double dx = (double)x;
            double E = 0.0;
            for(int i=0; i<EnergyCurveCoefficients.Count; i++)            
                E += EnergyCurveCoefficients[i] * Math.Pow(dx, (double)i);            
            return E;
        }
    }
}
