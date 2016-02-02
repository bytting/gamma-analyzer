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
        private bool sendMessage(NetworkStream stream, Proto.Message msg)
        {
            string json = JsonConvert.SerializeObject(msg);

            using (MemoryStream mstream = new MemoryStream())
            {
                using (BinaryWriter writer = new BinaryWriter(mstream))
                {
                    byte[] encodedJson = Encoding.UTF8.GetBytes(json);
                    writer.Write(hostToBig_i32(encodedJson.Length));
                    writer.Write(encodedJson);
                }

                byte[] request = mstream.ToArray();
                try
                {
                    stream.Write(request, 0, request.Length);
                    stream.Flush();
                }
                catch(SocketException ex)
                {
                    Proto.Message emsg = new Proto.Message("error_socket");
                    emsg.AddParameter("error_code", ex.ErrorCode);
                    emsg.AddParameter("message", ex.Message);                    
                    recvq.Enqueue(emsg);
                    return false;
                }
            }

            return true;
        }

        private bool recvData(NetworkStream stream)
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

        private bool recvMessage(out Proto.Message msg)
        {
            msg = null;

            if (recvBuffer.Count < 4)
                return false;
            
            byte[] byteSize = new byte[4];
            recvBuffer.CopyTo(0, byteSize, 0, 4);

            int siz = bigToHost_i32(byteSize);

            if (recvBuffer.Count < 4 + siz)
                return false;

            byte[] bjson = new byte[siz];
            recvBuffer.CopyTo(4, bjson, 0, siz);
            recvBuffer.RemoveRange(0, 4 + siz);
                
            string json = Encoding.UTF8.GetString(bjson);
            msg = JsonConvert.DeserializeObject<Proto.Message>(json);            

            return true;
        }

        byte[] hostToBig_i32(int value)
        {
            byte[] bvalue = BitConverter.GetBytes(value);
            if (BitConverter.IsLittleEndian)
                Array.Reverse(bvalue);
            return bvalue;
        }

        int bigToHost_i32(byte[] bvalue)
        {            
            if (BitConverter.IsLittleEndian)
                Array.Reverse(bvalue);
            return BitConverter.ToInt32(bvalue, 0);
        }        
    }
}
