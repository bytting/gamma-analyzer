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
    public class NetUploadArgs
    {
        public string Hostname { get; set; }
        public string Username { get; set; }
        public string Password { get; set; }
    }

    class NetUpload
    {
        ILog Log = null;

        private volatile bool running, active;
        private int failures;
        private NetUploadArgs args = new NetUploadArgs();

        ConcurrentQueue<Spectrum> sendq = new ConcurrentQueue<Spectrum>();

        public NetUpload(ILog log, ref ConcurrentQueue<Spectrum> sendQueue)
        {
            Log = log;
            Log.Info("Creating Net Uploader");
            running = true;
            active = false;
            failures = 0;
            sendQueue = sendq;
        }

        public void DoWork()
        {
            while (running)
            {
                if (active)
                {
                    // Upload spectrums to server
                    while (sendq.Count > 0)
                    {
                        Spectrum spec;
                        if (sendq.TryDequeue(out spec))
                        {
                            if (String.IsNullOrEmpty(args.Hostname))
                                continue;

                            try
                            {
                                HttpWebRequest request = (HttpWebRequest)WebRequest.Create(args.Hostname + "/spectrums");
                                string credentials = Convert.ToBase64String(ASCIIEncoding.ASCII.GetBytes(args.Username + ":" + args.Password));
                                request.Headers.Add("Authorization", "Basic " + credentials);
                                request.Timeout = 8000;
                                request.Method = WebRequestMethods.Http.Post;
                                request.Accept = "application/json";

                                APISpectrum apiSpec = new APISpectrum(spec);
                                Log.Info("Sending " + apiSpec.SessionName + ":" + apiSpec.SessionIndex);

                                var jsonRequest = JsonConvert.SerializeObject(apiSpec);
                                var sendData = Encoding.UTF8.GetBytes(jsonRequest);

                                request.ContentType = "application/json";
                                request.ContentLength = sendData.Length;

                                using (var stream = request.GetRequestStream())
                                    stream.Write(sendData, 0, sendData.Length);

                                string recvData;
                                HttpStatusCode code = Utils.GetResponseData(request, out recvData);

                                if (code == HttpStatusCode.OK)
                                {
                                    failures = 0;
                                    Log.Info(apiSpec.SessionName + ":" + apiSpec.SessionIndex + " uploaded successfully");
                                }
                                else if (code == HttpStatusCode.RequestTimeout)
                                {
                                    failures++;
                                    Log.Error("Request timeout");

                                    if(failures > 8)
                                    {
                                        Log.Error("Request timeout has happened 8 times. Giving up uploading");
                                        Deactivate();
                                    }
                                }
                                else
                                {
                                    failures++;
                                    Log.Error(code.ToString() + ": " + recvData);

                                    if (failures > 8)
                                    {
                                        Log.Error("Upload request has failed 8 times. Giving up uploading");
                                        Deactivate();
                                    }
                                }
                            }
                            catch (Exception ex)
                            {
                                Log.Error(ex.Message);
                            }
                        }
                    }
                }
                else
                {
                    while (sendq.Count > 0)
                    {
                        Spectrum spec;
                        sendq.TryDequeue(out spec);
                    }
                }

                Thread.Sleep(50);
            }
        }        

        public void Activate(NetUploadArgs a)
        {
            args.Hostname = a.Hostname;
            args.Username = a.Username;
            args.Password = a.Password;
            active = true;
            failures = 0;
        }

        public void Deactivate()
        {
            args.Hostname = String.Empty;
            args.Username = String.Empty;
            args.Password = String.Empty;
            active = false;
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
