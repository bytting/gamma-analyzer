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
// Authors: Dag Robole,

using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace crash
{
    public class NuclideInfo
    {
        public NuclideInfo()
        {
            Energies = new List<NuclideEnergy>();
        }

        public NuclideInfo(string name, double halfLife, string halfLifeUnit)
        {
            Name = name;
            HalfLife = halfLife;
            HalfLifeUnit = halfLifeUnit;
            Energies = new List<NuclideEnergy>();
        }

        public string Name { get; set; }
        public double HalfLife { get; set; }
        public string HalfLifeUnit { get; set; }
        public List<NuclideEnergy> Energies;

        public override string ToString()
        {
            return Name;
        }
    }

    public class NuclideEnergy
    {
        public NuclideEnergy() {}

        public NuclideEnergy(double energy, double probability)
        {
            Energy = energy;
            Probability = probability;
        }

        public double Energy { get; set; }
        public double Probability { get; set; }
    }
}
