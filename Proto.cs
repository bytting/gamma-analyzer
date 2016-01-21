using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace crash
{
    public static class Proto
    {
        public class Request
        {
            public Request(string srv, string cmd, string[] args)
            {
                service = srv;
                command = cmd;
                arguments = args;
            }

            public string service;
            public string command;
            public string[] arguments;
        }        
    }
}
