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
using System.Xml;
using System.Xml.Serialization;
using System.Drawing;

namespace crash
{    
    [Serializable()]
    public class Detector
    {
        public string TypeName { get; set; }
        public int CurrentHV { get; set; }
        public int CurrentNumChannels { get; set; }
        public string Serialnumber { get; set; }
        public double CurrentCoarseGain { get; set; }
        public double CurrentFineGain { get; set; }                        
        public int CurrentLivetime { get; set; }
        public int CurrentLLD { get; set; }
        public int CurrentULD { get; set; }
        public PointF RegressionPoint1 { get; set; }
        public PointF RegressionPoint2 { get; set; }
    }
}
