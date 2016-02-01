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
using System.IO;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Net.Sockets;
using Newtonsoft.Json;

namespace crash
{
    public partial class NetService
    {
        List<byte> recvBuffer = new List<byte>();

        private bool SendMessage(NetworkStream stream, Proto.Message msg)
        {
            string json = JsonConvert.SerializeObject(msg);

            using (MemoryStream mstream = new MemoryStream())
            {
                using (BinaryWriter writer = new BinaryWriter(mstream))
                {
                    byte[] encodedJson = Encoding.UTF8.GetBytes(json);
                    writer.Write(HostToBig(encodedJson.Length));
                    writer.Write(encodedJson);
                }

                byte[] request = mstream.ToArray();
                stream.Write(request, 0, request.Length);
                stream.Flush();
            }

            return true;
        }

        private bool RecvData(NetworkStream stream)
        {            
            if (!stream.DataAvailable)
                return false;            
                                        
            byte[] buffer = new byte[1024];                
            while (true)
            {
                if (!stream.DataAvailable)
                    break;
                    
                int len = stream.Read(buffer, 0, buffer.Length);
                if (len <= 0)
                    break;

                for (int i = 0; i<len; i++)
                    recvBuffer.Add(buffer[i]);                                        
            }                                            

            return true;
        }

        private bool RecvMessage(out Proto.Message msg)
        {
            msg = null;

            if (recvBuffer.Count < 4)
                return false;
            
            byte[] byteSize = new byte[4];
            recvBuffer.CopyTo(0, byteSize, 0, 4);

            int siz = BigToHost(byteSize);

            if (recvBuffer.Count < 4 + siz)
                return false;

            byte[] bjson = new byte[siz];
            recvBuffer.CopyTo(4, bjson, 0, siz);
            recvBuffer.RemoveRange(0, 4 + siz);
                
            string json = Encoding.UTF8.GetString(bjson);
            msg = JsonConvert.DeserializeObject<Proto.Message>(json);
            recvq.Add(msg);

            return true;
        }

        static byte[] HostToBig(int value)
        {
            byte[] retval = BitConverter.GetBytes(value);
            if (BitConverter.IsLittleEndian)        
                Array.Reverse(retval);            
            return retval;
        }

        static int BigToHost(byte[] value)
        {            
            if (BitConverter.IsLittleEndian)
                Array.Reverse(value);            
            return BitConverter.ToInt32(value, 0);
        }        
    }
}
