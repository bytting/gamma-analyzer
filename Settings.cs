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
using System.Xml;
using System.Xml.Serialization;
using System.IO;

namespace crash
{
    [Serializable()]
    public class CrashSettings
    {
        public CrashSettings() {}

        public List<DetectorType> DetectorTypes = new List<DetectorType>();
        public List<Detector> Detectors = new List<Detector>();
        public List<ROIData> ROIList = new List<ROIData>();
        public string SessionRootDirectory;        
        public string LastIP;
        public string LastPort;
        public string LastApiKey;
    }
}
