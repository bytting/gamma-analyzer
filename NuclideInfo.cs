using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

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
