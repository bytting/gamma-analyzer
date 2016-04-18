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
// Authors: Dag robole,

using System;
using System.Collections.Generic;
using System.Collections.Concurrent;
using System.Linq;
using System.Text;
using System.Threading;
using System.Net.Sockets;

namespace burn
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
        ConcurrentQueue<Message> sendq = new ConcurrentQueue<Message>();

        //! Queue with messages from server
        ConcurrentQueue<Message> recvq = new ConcurrentQueue<Message>();                

        //! Buffer to hold data streams from the network
        List<byte> recvBuffer = new List<byte>();

        /** 
         * Constructor for the NetService
         * \param sendQueue - Queue with messages from GUI client
         * \param recvQueue - Queue with messages from server
         */
        public NetService(ref ConcurrentQueue<Message> sendQueue, ref ConcurrentQueue<Message> recvQueue)
        {
            running = true;
            sendQueue = sendq;
            recvQueue = recvq;
        }

        /**
         * Thread entry point
         */
        public void DoWork()
        {            
            while (running)
            {
                Message sendMsg, recvMsg;

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
        private void dispatchSendMsg(Message msg)
        {
            switch(msg.Command)
            {
                case "connect":
                    // Try to connect to server
                    Client = new TcpClient();
                    string host = msg.Arguments["host"].ToString();
                    int port = Convert.ToInt32(msg.Arguments["port"]);

                    try
                    {
                        Client.Connect(host, port);
                    }
                    catch(Exception ex)
                    {
                        msg.Command = "connect_failed";
                        msg.Arguments.Add("message", ex.Message);
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
                        msg.Command = "connect_ok";
                        recvq.Enqueue(msg);                        
                    }
                    else
                    {
                        msg.Command = "connect_failed";
                        msg.Arguments.Add("message", "Connection failed");
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

                    msg.Command = "disconnect_ok";
                    recvq.Enqueue(msg);                    
                    break;

                default:                    
                    if (ClientStream == null)
                    {
                        Message responseMsg = new Message("error", null);
                        responseMsg.AddParameter("message", "Can not send message, not connected to peer");                        
                        recvq.Enqueue(responseMsg);
                        return;
                    }

                    // Send message to server
                    if(!sendMessage(ClientStream, msg))
                    {
                        Message responseMsg = new Message("error", null);
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
        private void dispatchRecvMsg(Message msg)
        {
            switch (msg.Command)
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
