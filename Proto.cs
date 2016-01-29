using System;
using System.IO;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Net.Sockets;
using Newtonsoft.Json;

namespace crash
{
    public static class Proto
    {
        public class Message
        {
            public Message(string cmd, Dictionary<string, string> args)
            {            
                command = cmd;
                arguments = new Dictionary<string, string>();
                if(args != null)
                    arguments = args;
            }
            
            public string command;
            public Dictionary<string, string> arguments;
        }   
        
        public static class IO
        {
            public static bool SendMessage(NetworkStream stream, Message msg)
            {
                string json = JsonConvert.SerializeObject(msg);

                using (MemoryStream mstream = new MemoryStream())
                {
                    using (BinaryWriter writer = new BinaryWriter(mstream))
                    {
                        byte[] encodedJson = Encoding.UTF8.GetBytes(json);
                        writer.Write(ToBigEndian(encodedJson.Length));
                        writer.Write(encodedJson);
                    }

                    byte[] request = mstream.ToArray();
                    stream.Write(request, 0, request.Length);
                    stream.Flush();
                }

                return true;
            }

            public static bool RecvMessage(NetworkStream stream, out Message msg)
            {
                msg = null;
                if (!stream.DataAvailable)
                    return false;

                MemoryStream response = null;
                BinaryReader breader = null;

                try
                {
                    int totlen = 0, len = 0;
                    response = new MemoryStream(1024 * 1024);
                    byte[] buffer = new byte[1024];

                    while (true)
                    {
                        if (!stream.DataAvailable)
                            break;

                        len = stream.Read(buffer, 0, buffer.Length);
                        if (len <= 0)
                            break;

                        response.Write(buffer, totlen, len);
                        totlen += len;
                    }

                    response.Seek(0, SeekOrigin.Begin);

                    if (totlen > 4)
                    {
                        breader = new BinaryReader(response);
                        int siz = ToLittleEndian(breader.ReadInt32());
                        byte[] bytes = new byte[siz];
                        breader.Read(bytes, 0, siz);
                        string json = Encoding.UTF8.GetString(bytes);
                        msg = JsonConvert.DeserializeObject<Proto.Message>(json);                        
                    }
                    else return false;
                }                
                finally
                {
                    if (breader != null)
                        breader.Close();
                    if(response != null)
                        response.Close();
                }                

                return true;
            }

            static byte[] ToBigEndian(int value)
            {
                byte[] retval = BitConverter.GetBytes(value);
                if (BitConverter.IsLittleEndian)
                {
                    Array.Reverse(retval);
                }
                return retval;
            }

            static int ToLittleEndian(int value)
            {
                byte[] retval = BitConverter.GetBytes(value);
                if (BitConverter.IsLittleEndian)
                {
                    Array.Reverse(retval);
                }
                return BitConverter.ToInt32(retval, 0);
            }
        }
    }
}
