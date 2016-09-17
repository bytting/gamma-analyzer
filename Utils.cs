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
using System.Drawing;
using IronPython.Hosting;
using IronPython.Runtime;
using Microsoft.Scripting;
using Microsoft.Scripting.Hosting;

namespace crash
{
    public static class Utils
    {        
        public static FormLog Log = new FormLog();
        public static dynamic PyEngine = Python.CreateEngine();    

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
    }
}
