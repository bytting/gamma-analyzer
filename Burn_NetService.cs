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
using System.Net;
using System.Collections.Generic;
using System.Collections.Concurrent;
using System.Linq;
using System.Text;
using System.Threading;
using System.Net.Sockets;
using Newtonsoft.Json;

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
        private Socket socket = new Socket(AddressFamily.InterNetwork, SocketType.Dgram, ProtocolType.Udp);        
        private IPEndPoint iep = new IPEndPoint(IPAddress.Parse("10.10.10.22"), 9999); // FIXME
        private EndPoint ep = null;

        //! Queue with messages from GUI client
        ConcurrentQueue<Message> sendq = new ConcurrentQueue<Message>();

        //! Queue with messages from server
        ConcurrentQueue<Message> recvq = new ConcurrentQueue<Message>();        

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
            var buffer = new byte[65536]; // FIXME: configurable size
            socket.SetSocketOption(SocketOptionLevel.Socket, SocketOptionName.ReceiveTimeout, 100);
            ep = (EndPoint)iep;            

            while (running)
            {
                Message sendMsg, recvMsg;

                // Send messages from analyzer
                while (sendq.Count > 0)
                {
                    if (sendq.TryDequeue(out sendMsg))
                    {
                        Byte[] sendBytes = Encoding.UTF8.GetBytes(sendMsg.ToJson());
                        socket.SendTo(sendBytes, ep);
                    }                        
                }

                // Receive messages from collector
                while (socket.Available > 0)
                {
                    int nbytes = socket.ReceiveFrom(buffer, ref ep);
                    if (nbytes > 0)
                    {
                        string jdata = Encoding.UTF8.GetString(buffer, 0, nbytes);
                        recvMsg = JsonConvert.DeserializeObject<Message>(jdata);
                        recvq.Enqueue(recvMsg);
                    }
                }

                Thread.Sleep(20);
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
