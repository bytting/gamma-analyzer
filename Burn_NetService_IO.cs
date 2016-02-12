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
using System;
using System.IO;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Net.Sockets;
using Newtonsoft.Json;

namespace burn
{
    /**
     * NetService - Continuation of the Threaded NetService class containing IO utilities
     */
    public partial class NetService
    {
        /** 
         * Function to send a message to the server
         * \param stream - The stream to write to
         * \param msg - The message to send
         * \return - Retun true on success, false on failure
         */
        private bool sendMessage(NetworkStream stream, Message msg)
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
                    Message emsg = new Message("error_socket");
                    emsg.AddParameter("error_code", ex.ErrorCode);
                    emsg.AddParameter("message", ex.Message);                    
                    recvq.Enqueue(emsg);
                    return false;
                }
            }

            return true;
        }

        /** 
         * Function to receive data streams from the server and store them in the network buffer
         * \param stream - The stream to read from
         * \return - Return true if a packet was stored in the network buffer, false if not
         */
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

        /** 
         * Function to read messages out of the network buffer
         * \param msg - Storage for any message read from the network buffer
         * \return - Return true if a complete message was extracted, false if not
         */
        private bool recvMessage(out Message msg)
        {
            msg = null;            

            // Make sure buffer hold at least a 32 bit int (netstrings)
            if (recvBuffer.Count < 4)
                return false;
            
            // Read the message size out of the buffer
            byte[] byteSize = new byte[4];
            recvBuffer.CopyTo(0, byteSize, 0, 4);

            // Convert the size to the hosts endianness
            int siz = bigToHost_i32(byteSize);

            // Make sure the message stored in the buffer are complete
            if (recvBuffer.Count < 4 + siz)
                return false;

            // Read out the message and update the buffer
            byte[] bjson = new byte[siz];
            recvBuffer.CopyTo(4, bjson, 0, siz);
            recvBuffer.RemoveRange(0, 4 + siz);
            
            // Deserialize the message            
            string json = Encoding.UTF8.GetString(bjson);
            msg = JsonConvert.DeserializeObject<Message>(json);            

            return true;
        }

        /** 
         * Function used to store an integer in a byte buffer in big endian format
         * \param value - The integer to store
         * \return - byte buffer with integer in big endian format
         */
        byte[] hostToBig_i32(int value)
        {
            byte[] bvalue = BitConverter.GetBytes(value);
            if (BitConverter.IsLittleEndian)
                Array.Reverse(bvalue);
            return bvalue;
        }

        /** 
         * Function used to store a big endian byte buffer in an integer in host endian
         * \param value - The byte buffer to store
         * \return - integer in host endian
         */
        int bigToHost_i32(byte[] bvalue)
        {            
            if (BitConverter.IsLittleEndian)
                Array.Reverse(bvalue);
            return BitConverter.ToInt32(bvalue, 0);
        }        
    }
}
