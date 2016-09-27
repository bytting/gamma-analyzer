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
using System.Xml;
using System.Xml.Serialization;

namespace crash
{
    [Serializable()]
    public class DetectorType
    {
        // Detector type name
        public string Name { get; set; }

        // Max number of channels allowed for this detector type
        public int MaxNumChannels { get; set; }

        // Min allowed high voltage for this detector type
        public int MinHV { get; set; }

        // Max allowed high voltage for this detector type
        public int MaxHV { get; set; }

        // Filename of python GE script used for this detector type
        public string GEScript { get; set; }

        public DetectorType() { }

        public DetectorType(string name, int maxChannels, int minHV, int maxHV, string geScript)
        {
            Name = name;
            MaxNumChannels = maxChannels;
            MinHV = minHV;
            MaxHV = maxHV;
            GEScript = geScript;
        }

        public override string ToString()
        {
            return Name;
        }
    }
}
