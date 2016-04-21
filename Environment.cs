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
        public static string SettingsPath = Environment.GetFolderPath(Environment.SpecialFolder.CommonDocuments) + Path.DirectorySeparatorChar + "Crash";
        public static string GScriptPath = SettingsPath + Path.DirectorySeparatorChar + "GScripts";
        public static string SettingsFile = SettingsPath + Path.DirectorySeparatorChar + "settings.xml";
    }    
}
