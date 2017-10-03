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

        private volatile bool running;
        private string hostname;

        ConcurrentQueue<Spectrum> sendq = new ConcurrentQueue<Spectrum>();

        public NetUpload(ILog log, ref ConcurrentQueue<Spectrum> sendQueue)
        {
            Log = log;
            Log.Info("Creating Net Uploader");
            running = true;
            sendQueue = sendq;
        }

        public void DoWork()
        {
            while (running)
            {
                // Upload spectrums to server
                while (sendq.Count > 0)
                {
                    Spectrum spec;
                    if (sendq.TryDequeue(out spec))
                    {
                        if (String.IsNullOrEmpty(hostname))
                            continue;

                        HttpWebRequest request = (HttpWebRequest)WebRequest.Create("http://" + hostname + "/add-spectrum");
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
                }

                Thread.Sleep(50);
            }
        }

        public void SetHostname(string hname)
        {
            hostname = hname;
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
