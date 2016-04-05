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
