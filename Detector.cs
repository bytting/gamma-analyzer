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
using System.Xml;
using System.Xml.Serialization;

namespace crash
{    
    [Serializable()]
    public class Detector
    {
        // Name of detector type
        public string TypeName { get; set; }

        // Current high voltage for detector
        public int CurrentHV { get; set; }

        // Current number of channels
        public int CurrentNumChannels { get; set; }

        // Detector serialnumber
        public string Serialnumber { get; set; }

        // Current coarse gain for detector
        public double CurrentCoarseGain { get; set; }

        // Current fine gain for detector
        public double CurrentFineGain { get; set; }

        // Current livetime for detector
        public int CurrentLivetime { get; set; }

        // Current lower level discriminator for detector
        public int CurrentLLD { get; set; }

        // Current upper level discriminator for detector
        public int CurrentULD { get; set; }

        // List of energy curve coefficients
        [XmlArray("EnergyCurveCoefficients")]
        [XmlArrayItem("Value")]
        public List<double> EnergyCurveCoefficients { get; set; }

        public Detector()
        {
            EnergyCurveCoefficients = new List<double>();        
        }

        public Detector Clone()
        {
            // Clone this detector
            Detector clone = new Detector();
            clone.TypeName = TypeName;
            clone.CurrentHV = CurrentHV;
            clone.CurrentNumChannels = CurrentNumChannels;
            clone.Serialnumber = Serialnumber;
            clone.CurrentCoarseGain = CurrentCoarseGain;
            clone.CurrentFineGain = CurrentFineGain;
            clone.CurrentLivetime = CurrentLivetime;
            clone.CurrentLLD = CurrentLLD;
            clone.CurrentULD = CurrentULD;            
            clone.EnergyCurveCoefficients.AddRange(EnergyCurveCoefficients);
            return clone;
        }        

        public override string ToString()
        {
 	         return Serialnumber;
        }

        public double GetEnergy(int x)
        {
            if (EnergyCurveCoefficients.Count < 2 || EnergyCurveCoefficients.Count > 5)
                return 0.0;

            // Calculate energy for a given channel
            double dx = (double)x;
            double E = 0.0;
            for(int i=0; i<EnergyCurveCoefficients.Count; i++)            
                E += EnergyCurveCoefficients[i] * Math.Pow(dx, (double)i);            
            return E;
        }
    }
}
