using System;
using System.IO;
using System.IO.IsolatedStorage;
using System.Net;
using System.Text;
using BattlelogMobile.Core.Message;
using GalaSoft.MvvmLight.Messaging;

namespace BattlelogMobile.Core.Service
{
    /// <summary>
    /// Download files over http and store locally
    /// </summary>
    public class DownloadService : IDownloadService
    {
        private const string DefaultMessage = "Downloading";
        private const string Accept = "*/*";
        private const string DefaultMethod = "GET";
        private const string UserAgent = "Mozilla/5.0 (Windows NT 6.1; WOW64; rv:6.0.2) Gecko/20100101 Firefox/6.0.2";
        private readonly IsolatedStorageFile _isolatedStorage = IsolatedStorageFile.GetUserStoreForApplication();


        private DownloadService() : this(new CookieContainer())
        {}

        public DownloadService(CookieContainer cookieJar)
        {
            CookieJar = cookieJar;
        }

        public CookieContainer CookieJar { get; set; }

        public void ResolveUserIdAndPlatform(string url, IUserIdAndPlatformResolver userIdAndPlatformUserIdAndPlatformResolver)
        {
            var request = WebRequest.Create(new Uri(url)) as HttpWebRequest;
            if (request == null)
                throw new ArgumentNullException();

            request.Method = DefaultMethod;
            request.Accept = Accept;
            request.UserAgent = UserAgent;
            request.CookieContainer = CookieJar;

            request.BeginGetResponse(responseAsyncResult =>
            {
                try
                {
                    var response = (HttpWebResponse)request.EndGetResponse(responseAsyncResult);
                    var responseStream = response.GetResponseStream();
                    userIdAndPlatformUserIdAndPlatformResolver.Resolve(responseStream);
                    response.Close();
                }
                catch (WebException we)
                {
                    Messenger.Default.Send(new BattlelogResponseMessage(we.Message, false));
                }
            }, null);

            //var client = new SharpGIS.GZipWebClient();
            //client.OpenReadCompleted += (s, e) =>
            //    {
            //        try
            //        {
            //            Stream stream = e.Result;
            //            userIdAndPlatformUserIdAndPlatformResolver.Resolve(stream);
            //            stream.Close();
            //        }
            //        catch (WebException we)
            //        {
            //            Messenger.Default.Send(new BattlelogResponseMessage(we.Message, false));
            //        }
            //    };
            //client.OpenReadAsync(new Uri(url), client);
        }

        public void  GetFile(string url, string isolatedStorageFile)
        {
            var client = new SharpGIS.GZipWebClient();
            client.DownloadStringCompleted += (s, e) =>
                {
                    try
                    {
                        var responseStream = e.Result;
                        using (var writer = new StreamWriter(_isolatedStorage.OpenFile(isolatedStorageFile, FileMode.Create)))
                        {
                            writer.Write(responseStream);
                            writer.Close();
                            Messenger.Default.Send(new BattlelogResponseMessage(this, DefaultMessage, true));
                        }
                    }
                    catch (WebException we)
                    {
                        Messenger.Default.Send(new BattlelogResponseMessage(we.Message, false));
                    }
                };
            client.DownloadStringAsync(new Uri(url), client);
            client = null;
            //var request = WebRequest.Create(new Uri(url)) as HttpWebRequest;
            //if (request == null)
            //    throw new ArgumentNullException();

            //request.Method = DefaultMethod;
            //request.Accept = Accept;
            //request.UserAgent = UserAgent;
            //request.CookieContainer = CookieJar;

            //request.BeginGetResponse(responseAsyncResult =>
            //{
            //    try
            //    {
            //        var response = (HttpWebResponse)request.EndGetResponse(responseAsyncResult);
            //        var responseStream = response.GetResponseStream();
            //        using (var writer = _isolatedStorage.OpenFile(isolatedStorageFile, FileMode.Create))
            //        {
            //            byte[] bytesInStream = new byte[responseStream.Length];
            //            responseStream.Read(bytesInStream, 0, bytesInStream.Length);
            //            writer.Write(bytesInStream, 0, bytesInStream.Length);
            //            writer.Close();
            //            Messenger.Default.Send(new BattlelogResponseMessage(this, DefaultMessage, true));
            //        }
            //    }
            //    catch (WebException we)
            //    {
            //        Messenger.Default.Send(new BattlelogResponseMessage(we.Message, false));
            //    }
            //}, null);
        }
    }
}
