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
// Authors: Dag Robole,

using System;
using System.IO;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace crash
{
    public static class CrashEnvironment
    {
        public static string SettingsPath = Environment.GetFolderPath(Environment.SpecialFolder.CommonApplicationData) + Path.DirectorySeparatorChar + "Crash";
        public static string GEScriptPath = SettingsPath + Path.DirectorySeparatorChar + "GEScripts";
        public static string RegScriptPath = SettingsPath + Path.DirectorySeparatorChar + "RegressionScripts";
        public static string SettingsFile = SettingsPath + Path.DirectorySeparatorChar + "settings.xml";        
        public static string NuclidesFile = SettingsPath + Path.DirectorySeparatorChar + "nuclides.lib";
    }    
}
