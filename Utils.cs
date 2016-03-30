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
            byte[] b = BitConverter.GetBytes(argb);
            return Color.FromArgb(b[3], b[2], b[1], b[0]);
        }

        public static FormLog Log = new FormLog();
    }
}
