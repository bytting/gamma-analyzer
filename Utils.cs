using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Drawing;
using System.Threading.Tasks;

namespace crash
{
    public static class Utils
    {
        public static int ToArgb(Color color)
        {
            int a = color.A;
            int r = color.R;
            int g = color.G;
            int b = color.B;

            return a << 24 | r << 16 | g << 8 | b;
        }

        public static Color ToColor(int argb)
        {
            int a = argb >> 24;
            int r = argb << 8 >> 24;
            int g = argb << 16 >> 24;
            int b = argb << 24 >> 24;

            return Color.FromArgb(a, r, g, b);
        }
    }
}
