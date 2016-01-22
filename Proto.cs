using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

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
    }
}
