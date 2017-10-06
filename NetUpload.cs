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
                            request = (HttpWebRequest)WebRequest.Create("http://" + Hostname + "/add-spectrum");
                            string credentials = Convert.ToBase64String(ASCIIEncoding.ASCII.GetBytes(Username + ":" + Password));
                            request.Headers.Add("Authorization", "Basic " + credentials);
                            request.Timeout = 2000;
                            request.Method = WebRequestMethods.Http.Post;
                            request.Accept = "application/json";

                            SimpleSpectrum simpleSpec = new SimpleSpectrum(spec);
                            Log.Info("Sending " + simpleSpec.SessionName + ":" + simpleSpec.SessionIndex);

                            var jsonRequest = JsonConvert.SerializeObject(simpleSpec);
                            var data = Encoding.UTF8.GetBytes(jsonRequest);

                            request.Method = "POST";
                            request.ContentType = "application/json";
                            request.ContentLength = data.Length;

                            using (var stream = request.GetRequestStream())
                            {
                                stream.Write(data, 0, data.Length);
                            }

                            string jsonText;
                            HttpWebResponse response = (HttpWebResponse)request.GetResponse();
                            if (response == null || response.StatusCode != HttpStatusCode.OK)
                            {
                                Log.Error("Upload failed (" + response.StatusCode + ")");
                                continue;
                            }

                            using (var sr = new StreamReader(response.GetResponseStream()))
                            {
                                jsonText = sr.ReadToEnd();
                            }

                            Log.Info(jsonText);
                        }
                        catch(WebException ex)
                        {
                            if (request != null)
                                request.Abort();

                            if (ex.Status == WebExceptionStatus.Timeout)
                                Log.Error("Web request timeout");
                            else
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
