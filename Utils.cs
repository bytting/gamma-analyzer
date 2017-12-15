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
// Authors: Dag Robole,

using System;
using System.Drawing;

namespace crash
{
    // Class with global helper functions and objects
    public static class Utils
    {
        public static void Swap<T>(ref T arg1, ref T arg2)
        {
            T tmp = arg1;
            arg1 = arg2;
            arg2 = tmp;
        }

        // Convert a color to an integer
        public static int ToArgb(Color color)
        {
            int a = color.A;
            int r = color.R;
            int g = color.G;
            int b = color.B;
            return a << 24 | r << 16 | g << 8 | b;
        }

        // Convert an integer to a color
        public static Color ToColor(int argb)
        {
            byte[] b = BitConverter.GetBytes(argb);
            return Color.FromArgb(b[3], b[2], b[1], b[0]);
        }

        public static Color MapColor(double min, double max, double val)
        {
            Color c = new Color();
            double f = (val - min) / (max - min);
            double a = (1.0 - f) / 0.25;
            double x = Math.Floor(a);
            double y = Math.Floor(255.0 * (a - x));

            switch ((int)x)
            {
                case 0:
                    c = Color.FromArgb(255, 255, (int)y, 0);
                    break;
                case 1:
                    c = Color.FromArgb(255 - (int)y, 255, 0);
                    break;
                case 2:
                    c = Color.FromArgb(0, 255, (int)y);
                    break;
                case 3:
                    c = Color.FromArgb(0, 255 - (int)y, 255);
                    break;
                case 4:
                    c = Color.FromArgb(0, 0, 255);
                    break;
            }
            return c;
        }
    }
}
