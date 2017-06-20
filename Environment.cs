﻿/*	
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
using System.IO;

namespace crash
{
    public static class GAEnvironment
    {
        // Settings path
        public static string SettingsPath = Environment.GetFolderPath(Environment.SpecialFolder.CommonDocuments) + Path.DirectorySeparatorChar + "GammaAnalyzer";

        // GE scripts path
        public static string GEScriptPath = SettingsPath + Path.DirectorySeparatorChar + "GEScripts";        

        // Settings filename
        public static string SettingsFile = SettingsPath + Path.DirectorySeparatorChar + "settings.xml";

        // Nuclide library filename
        public static string NuclideLibraryFile = SettingsPath + Path.DirectorySeparatorChar + "nuclides.lib";
    }    
}
