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

namespace crash
{
    // Class to store info about a region of interest
    [Serializable()]
    public class ROIData
    {
        // Name of ROI
        public string Name { get; set; }

        // Start channel for ROI
        public float StartChannel { get; set; }

        // End channel for ROI
        public float EndChannel { get; set; }

        // Active state for ROI
        public bool Active { get; set; }

        // Color to use for this ROI
        public string ColorName { get; set; }

        public ROIData() {}

        public ROIData(string name, int startChannel, int endChannel, bool active, string colorName)
        {
            Name = name;
            StartChannel = (float)startChannel;
            EndChannel = (float)endChannel;
            Active = active;
            ColorName = colorName;
        }        
    }
}
