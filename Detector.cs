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
using System.Xml;
using System.Xml.Serialization;
using Newtonsoft.Json;

namespace crash
{    
    [Serializable()]
    public class Detector
    {
        // Name of detector type
        [JsonProperty("type_name")]
        public string TypeName { get; set; }

        // Filename of python GE script used for this detector
        [JsonProperty("ge_script")]
        public string GEScript { get; set; }

        // High voltage for detector
        [JsonProperty("voltage")]
        public int Voltage { get; set; }

        // Min allowed high voltage for this detector
        [JsonProperty("min_voltage")]
        public int MinVoltage { get; set; }

        // Max allowed high voltage for this detector
        [JsonProperty("max_voltage")]
        public int MaxVoltage { get; set; }

        // Number of channels
        [JsonProperty("num_channels")]
        public int NumChannels { get; set; }

        // Max number of channels allowed for this detector
        [JsonProperty("max_num_channels")]
        public int MaxNumChannels { get; set; }

        // Detector serialnumber
        [JsonProperty("serialnumber")]
        public string Serialnumber { get; set; }

        // Coarse gain for detector
        [JsonProperty("coarse_gain")]
        public double CoarseGain { get; set; }

        // Fine gain for detector
        [JsonProperty("fine_gain")]
        public double FineGain { get; set; }

        // Livetime for detector
        [JsonProperty("livetime")]
        public int Livetime { get; set; }

        // Lower level discriminator for detector
        [JsonProperty("lld")]
        public int LLD { get; set; }

        // Upper level discriminator for detector
        [JsonProperty("uld")]
        public int ULD { get; set; }

        // Name of plugin to use on gamma-collector
        [JsonProperty("plugin_name")]
        public string PluginName { get; set; }

        // List of energy curve coefficients
        [XmlArray("EnergyCurveCoefficients")]
        [XmlArrayItem("Value")]
        [JsonProperty("energy_curve_coefficients")]
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
            clone.GEScript = GEScript;
            clone.Voltage = Voltage;
            clone.MinVoltage = MinVoltage;
            clone.MaxVoltage = MaxVoltage;
            clone.NumChannels = NumChannels;
            clone.MaxNumChannels = MaxNumChannels;
            clone.Serialnumber = Serialnumber;
            clone.CoarseGain = CoarseGain;
            clone.FineGain = FineGain;
            clone.Livetime = Livetime;
            clone.LLD = LLD;
            clone.ULD = ULD;
            clone.PluginName = PluginName;
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
