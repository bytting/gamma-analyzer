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
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace crash
{
    public class Session
    {
        public string Name { get; private set; }
        public float MaxChannelCount { get; private set; }
        public float MinChannelCount { get; private set; }
        public List<Spectrum> Spectrums { get; private set; }

        public Session(string name)
        {
            Name = name;
            Spectrums = new List<Spectrum>();
        }

        public void Add(Spectrum spec)
        {
            Spectrums.Add(spec);

            if (spec.MaxCount > MaxChannelCount)
                MaxChannelCount = spec.MaxCount;
            if (spec.MinCount < MinChannelCount)
                MinChannelCount = spec.MinCount;
        }

        public void Clear()
        {
            Spectrums.Clear();
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
