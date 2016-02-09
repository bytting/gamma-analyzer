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
using System.Collections.Generic;
using System.Collections.Concurrent;
using System.Linq;
using System.Text;
using System.Threading;
using System.Net.Sockets;

namespace crash
{        
    /**
     * NetService - Threaded class for network communication
     */
    public partial class NetService
    {
        //! Running state for this service
        private volatile bool running;

        //! Network utilities
        private TcpClient Client = null;
        private NetworkStream ClientStream = null;

        //! Queue with messages from GUI client
        private ConcurrentQueue<Proto.Message> sendq = null;

        //! Queue with messages from server
        private ConcurrentQueue<Proto.Message> recvq = null;

        //! Buffer to hold data streams from the network
        List<byte> recvBuffer = new List<byte>();

        /** 
         * Constructor for the NetService
         * \param sendQueue - Queue with messages from GUI client
         * \param recvQueue - Queue with messages from server
         */
        public NetService(ConcurrentQueue<Proto.Message> sendQueue, ConcurrentQueue<Proto.Message> recvQueue)
        {
            running = true;
            sendq = sendQueue;
            recvq = recvQueue;
        }

        /**
         * Thread entry point
         */
        public void DoWork()
        {            
            while (running)
            {
                Proto.Message sendMsg, recvMsg;

                // Read all messages from GUI client
                while(sendq.Count > 0)                
                    if (sendq.TryDequeue(out sendMsg))
                        dispatchSendMsg(sendMsg); // Handle the messages

                // If we have a connection, read and buffer any waiting data streams
                if (ClientStream != null)
                    while (recvData(ClientStream)) ;

                // Extract messages from the network buffer
                while (recvMessage(out recvMsg))                
                    dispatchRecvMsg(recvMsg); // Handle the messages

                Thread.Sleep(5); // Play nice (FIXME)
            }            
        }

        /**
         * Function used to handle messages coming from the GUI client
         * \param msg - The message to handle
         */
        private void dispatchSendMsg(Proto.Message msg)
        {
            switch(msg.command)
            {
                case "connect":
                    // Try to connect to server
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
                        // Store the stream from the TCP client
                        ClientStream = Client.GetStream();
                        // Empty the network buffer
                        recvBuffer.Clear();
                        // Update the message to a connection response message and send it back to GUI client
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
                    // Disconnect from server and send response back to GUI client
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
                        Proto.Message responseMsg = new Proto.Message("error");
                        responseMsg.AddParameter("message", "Can not send message, not connected to peer");                        
                        recvq.Enqueue(responseMsg);
                        return;
                    }

                    // Send message to server
                    if(!sendMessage(ClientStream, msg))
                    {
                        Proto.Message responseMsg = new Proto.Message("error");
                        responseMsg.AddParameter("message", "Unable to send message");                        
                        recvq.Enqueue(responseMsg);
                        return;
                    }
                    break;
            }            
        }

        /**
         * Function used to handle messages coming from server
         * \param msg - The message to handle
         */
        private void dispatchRecvMsg(Proto.Message msg)
        {
            switch (msg.command)
            {
                case "close_ok": // The server has received a close message and are closing down
                    if (ClientStream != null)
                        ClientStream.Close();
                    ClientStream = null;

                    if(Client != null && Client.Connected)            
                        Client.Close();                            
                    Client = null;

                    recvq.Enqueue(msg); // Pass message back to GUI client
                    break;

                default:
                    recvq.Enqueue(msg); // Pass message back to GUI client
                    break;
            }            
        }

        /**
         * Function used to stop this service         
         */
        public void RequestStop()
        {
            running = false;
        }

        /**
         * Function used to check the running state of this service
         */
        public bool IsRunning()
        {
            return running;
        }
    }
}
