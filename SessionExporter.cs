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
using System.Text;
using System.IO;
using System.Collections.Generic;

namespace crash
{
    public static class SessionExporter
    {
        public static void ExportAsCHN(Session session, string path)
        {
            foreach(Spectrum s in session.Spectrums)
            {                
                string sessionPath = path + Path.DirectorySeparatorChar + session.Name + "_CHN";
                if (!Directory.Exists(sessionPath))
                    Directory.CreateDirectory(sessionPath);

                string filename = sessionPath + Path.DirectorySeparatorChar + s.SessionIndex.ToString() + ".chn";
                using (BinaryWriter writer = new BinaryWriter(File.Create(filename)))
                {
                    string dateStr = s.GpsTimeStart.ToString("ddMMMyy") + "1";
                    dateStr = dateStr.ToUpper();
                    string timeStr = s.GpsTimeStart.ToString("HHmm");

                    string secStr = s.GpsTimeStart.ToString("ss");

                    writer.Write(Convert.ToInt16(-1)); // signature
                    writer.Write(Convert.ToInt16(s.SpectralInput)); // detector id
                    writer.Write(Convert.ToInt16(0)); // segment
                    writer.Write(Encoding.ASCII.GetBytes(secStr)); // seconds start
                    Int32 rt = s.Realtime / 1000; // ms                    
                    rt = rt / 20; // increments of 20 ms
                    writer.Write(rt); // realtime
                    Int32 lt = s.Livetime / 1000; // ms                    
                    lt = lt / 20; // increments of 20 ms
                    writer.Write(lt); // livetime                    
                    writer.Write(Encoding.ASCII.GetBytes(dateStr)); // date
                    writer.Write(Encoding.ASCII.GetBytes(timeStr)); // time
                    writer.Write(Convert.ToInt16(0)); // channel offset
                    writer.Write(Convert.ToInt16(s.NumChannels)); // number of channels

                    foreach (float ch in s.Channels)
                        writer.Write(Convert.ToInt32(ch));
                }
            }            
        }
    }
}
