/*	
	Crash - Controlling application for Burn
    Copyright (C) 2016  Dag Robole

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
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Newtonsoft.Json;

namespace crash
{
    namespace Proto
    {
        public class Message
        {
            public string command;
            public Dictionary<string, string> arguments = new Dictionary<string,string>();

            [JsonConstructor]
            public Message(string cmd, Dictionary<string, string> args)
            {            
                command = cmd;                
                if(args != null)
                    arguments = args;
            }

            public Message(string cmd)
            {
                command = cmd;                
            }

            public void AddParameter(string key, object value)
            {
                arguments[key] = value.ToString();
            }            
        }           
    }
}
