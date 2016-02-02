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
using System.Collections.Concurrent;
using System.Linq;
using System.Text;
using System.Threading;
using System.Net.Sockets;

namespace crash
{
    public partial class NetService
    {
        private volatile bool running;
        private TcpClient Client = null;
        private NetworkStream ClientStream = null;
        private ConcurrentQueue<Proto.Message> sendq = null;
        private ConcurrentQueue<Proto.Message> recvq = null;

        public NetService(ConcurrentQueue<Proto.Message> sendQueue, ConcurrentQueue<Proto.Message> recvQueue)
        {
            running = true;
            sendq = sendQueue;
            recvq = recvQueue;
        }

        public void DoWork()
        {            
            while (running)
            {
                Proto.Message sendMsg, recvMsg;

                while(sendq.Count > 0)                
                    if (sendq.TryDequeue(out sendMsg))
                        dispatchSendMsg(sendMsg);                

                if (ClientStream != null)
                    while (recvData(ClientStream)) ;

                while (recvMessage(out recvMsg))                
                    dispatchRecvMsg(recvMsg);                

                Thread.Sleep(5);
            }            
        }

        private void dispatchSendMsg(Proto.Message msg)
        {
            switch(msg.command)
            {
                case "connect":                    
                    Client = new TcpClient();
                    string host = msg.arguments["host"];
                    int port = Convert.ToInt32(msg.arguments["port"]);

                    try
                    {
                        Client.Connect(host, port);
                    }
                    catch(Exception ex)
                    {
                        msg.command = "connect_failed";
                        msg.arguments.Add("message", ex.Message);
                        recvq.Enqueue(msg);                    
                        return;
                    }

                    if (Client.Connected)
                    {
                        ClientStream = Client.GetStream();
                        msg.command = "connect_ok";
                        recvq.Enqueue(msg);                        
                    }
                    else
                    {
                        msg.command = "connect_failed";
                        msg.arguments.Add("message", "Connection failed");
                        recvq.Enqueue(msg);                        
                    }
                    break;

                case "disconnect":
                    if (ClientStream != null)
                        ClientStream.Close();
                    ClientStream = null;

                    if(Client != null && Client.Connected)            
                        Client.Close();                            
                    Client = null;

                    msg.command = "disconnect_ok";
                    recvq.Enqueue(msg);                    
                    break;

                default:
                    if (ClientStream == null)
                    {
                        Proto.Message responseMsg = new Proto.Message("error", new Dictionary<string, string>() {
                            { "message", "Can not send message, not connected to peer" }
                        });
                        recvq.Enqueue(responseMsg);
                        return;
                    }

                    if(!sendMessage(ClientStream, msg))
                    {
                        Proto.Message responseMsg = new Proto.Message("error", new Dictionary<string, string>() {
                            { "message", "Unable to send message" }
                        });
                        recvq.Enqueue(responseMsg);
                        return;
                    }
                    break;
            }            
        }

        private void dispatchRecvMsg(Proto.Message msg)
        {
            switch (msg.command)
            {
                case "close_ok":
                    if (ClientStream != null)
                        ClientStream.Close();
                    ClientStream = null;

                    if(Client != null && Client.Connected)            
                        Client.Close();                            
                    Client = null;

                    recvq.Enqueue(msg);                    
                    break;

                default:
                    recvq.Enqueue(msg);
                    break;
            }            
        }

        public void RequestStop()
        {
            running = false;
        }

        public bool IsRunning()
        {
            return running;
        }
    }
}
