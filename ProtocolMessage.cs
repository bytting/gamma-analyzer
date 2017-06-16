using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Newtonsoft.Json;

namespace burn
{
    public class ProtocolMessage
    {
        public ProtocolMessage()
        {        
        }

        public ProtocolMessage(string ip)
        {
            IPAddress = ip;
        }

        [JsonIgnore]
        public string IPAddress;

        [JsonIgnore]
        public Dictionary<string, object> Params = new Dictionary<string, object>();
    }
}
