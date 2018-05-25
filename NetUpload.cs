using System;
using System.IO;
using System.Collections.Generic;
using System.Collections.Concurrent;
using System.Linq;
using System.Text;
using System.Threading;
using System.Net;
using log4net;
using Newtonsoft.Json;

namespace crash
{
    class NetUpload
    {
        ILog Log = null;

        private volatile bool Running;
        private string Hostname, Username, Password;

        ConcurrentQueue<Spectrum> sendq = new ConcurrentQueue<Spectrum>();

        public NetUpload(ILog log, ref ConcurrentQueue<Spectrum> sendQueue)
        {
            Log = log;
            Log.Info("Creating Net Uploader");
            Running = true;
            sendQueue = sendq;
        }

        public void DoWork()
        {
            while (Running)
            {
                // Upload spectrums to server
                while (sendq.Count > 0)
                {
                    Spectrum spec;
                    if (sendq.TryDequeue(out spec))
                    {
                        if (String.IsNullOrEmpty(Hostname))
                            continue;

                        HttpWebRequest request = null;

                        try
                        {
                            request = (HttpWebRequest)WebRequest.Create(Hostname + "/spectrums");
                            string credentials = Convert.ToBase64String(ASCIIEncoding.ASCII.GetBytes(Username + ":" + Password));
                            request.Headers.Add("Authorization", "Basic " + credentials);
                            request.Timeout = 5000;
                            request.Method = WebRequestMethods.Http.Post;
                            request.Accept = "application/json";

                            APISpectrum apiSpec = new APISpectrum(spec);
                            Log.Info("Sending " + apiSpec.SessionName + ":" + apiSpec.SessionIndex);

                            var jsonRequest = JsonConvert.SerializeObject(apiSpec);
                            var sendData = Encoding.UTF8.GetBytes(jsonRequest);
                            
                            request.ContentType = "application/json";
                            request.ContentLength = sendData.Length;

                            using (var stream = request.GetRequestStream())
                            {
                                stream.Write(sendData, 0, sendData.Length);
                            }

                            string recvData;
                            HttpStatusCode code = Utils.GetResponseData(request, out recvData);

                            if (code == HttpStatusCode.OK)
                            {
                                Log.Info(recvData);
                            }
                            else if(code == HttpStatusCode.RequestTimeout)
                            {
                                Log.Error("Request timeout");
                            }
                            else
                            {
                                Log.Error(code.ToString() + ": " + recvData);
                            }                            
                        }
                        catch(Exception ex)
                        {
                            Log.Error(ex.Message);
                        }
                    }
                }

                Thread.Sleep(50);
            }
        }        

        public void SetCredentials(string hostname, string user, string pass)
        {
            Hostname = hostname.Trim();
            Username = user.Trim();
            Password = pass;
        }

        public void RequestStop()
        {
            Running = false;
        }
        
        public bool IsRunning()
        {
            return Running;
        }
    }
}
