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
using System.Drawing;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace crash
{
    public partial class FormMain
    {
        private bool dispatchRecvMsg(Proto.Message msg)
        {
            switch (msg.command)
            {
                case "connect_ok":
                    lblConnectionStatus.ForeColor = Color.Green;
                    lblConnectionStatus.Text = "Connected to " + msg.arguments["host"] + ":" + msg.arguments["port"];
                    log("Connected to " + msg.arguments["host"] + ":" + msg.arguments["port"]);
                    break;

                case "connect_failed":
                    lblConnectionStatus.ForeColor = Color.Red;
                    lblConnectionStatus.Text = "Connection failed for " + msg.arguments["host"] + ":" + msg.arguments["port"] + " " + msg.arguments["message"];
                    log("Connection failed for " + msg.arguments["host"] + ":" + msg.arguments["port"] + " " + msg.arguments["message"]);
                    break;

                case "disconnect_ok":
                    lblConnectionStatus.ForeColor = Color.Red;
                    lblConnectionStatus.Text = "Not connected";
                    log("Disconnected from peer");
                    break;

                case "close_ok":
                    netService.RequestStop();
                    netThread.Join();
                    lblConnectionStatus.ForeColor = Color.Red;
                    lblConnectionStatus.Text = "Not connected";
                    log("Disconnected from peer, peer closed");
                    break;

                case "new_session_ok":
                    log("New session created: " + msg.arguments["session_name"]);
                    break;

                case "new_session_failed":
                    log("New session failed: " + msg.arguments["message"]);
                    break;

                case "error":
                    log("Error: " + msg.arguments["message"]);
                    break;

                case "error_socket":
                    log("Socket error: " + msg.arguments["error_code"] + " " + msg.arguments["message"]);
                    break;

                case "fix_ok":
                    log("GPS Fix - Lat: " + msg.arguments["latitude"] + " Lon: " + msg.arguments["longitude"] + " Alt: " + msg.arguments["altitude"]);
                    break;

                default:
                    string info = msg.command + " -> ";
                    foreach (KeyValuePair<string, string> item in msg.arguments)
                        info += item.Key + ":" + item.Value + ", ";
                    log("Unhandeled command: " + info);
                    break;
            }
            return true;
        }
    }
}
