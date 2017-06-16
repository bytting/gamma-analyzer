using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

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

        public string IPAddress;
        public Dictionary<string, object> Params = new Dictionary<string, object>();
    }
}
