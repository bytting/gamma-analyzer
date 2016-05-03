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
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace crash
{
    public class SessionInfo
    {
        public SessionInfo()
        {
        }

        public SessionInfo(string name, string comment, float livetime, int iterations, Detector det, string geScript)
        {
            Name = name;
            Comment = comment;
            Livetime = livetime;
            Iterations = iterations;
            Detector = det;
            GEScript = geScript;
        }

        public string Name { get; set; }
        public string Comment { get; set; }
        public float Livetime { get; set; }
        public int Iterations { get; set; }
        public Detector Detector { get; set; }
        public string GEScript { get; set; }

        public void Clear()
        {
            Name = String.Empty;
            Comment = String.Empty;
            Detector = null;
            GEScript = String.Empty;
        }
    }
}
