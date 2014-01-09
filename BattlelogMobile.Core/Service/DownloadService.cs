﻿using System;
using System.IO;
using System.IO.IsolatedStorage;
using System.Net;
using System.Threading.Tasks;
using BattlelogMobile.Core.Message;
using GalaSoft.MvvmLight.Messaging;

namespace BattlelogMobile.Core.Service
{
    /// <summary>
    /// Download files over http and store locally
    /// </summary>
    public class DownloadService
    {
        private readonly IsolatedStorageFile _isolatedStorage = IsolatedStorageFile.GetUserStoreForApplication();

        public DownloadService() 
            : this(new CookieContainer())
        {}

        public DownloadService(CookieContainer cookieJar)
        {
            CookieJar = cookieJar;
        }

        public CookieContainer CookieJar { get; set; }

        public async Task RetrieveServerMessage(string url)
        {
            var request = WebRequest.Create(new Uri(url)) as HttpWebRequest;
            if (request == null)
                throw new ArgumentNullException();

            request.Method = Common.HttpGetMethod;
            request.Accept = Common.HttpAccept;
            request.UserAgent = Common.HttpUserAgent;
            request.CookieContainer = CookieJar;

            var task = request.GetResponseAsync();

            try
            {
                var response = (HttpWebResponse) await task.ConfigureAwait(false);
                var responseStream = response.GetResponseStream();
                var reader = new StreamReader(responseStream);
                string message = await reader.ReadToEndAsync().ConfigureAwait(false);
                response.Close();
                if (message.Length > 0)
                    Messenger.Default.Send(new DialogMessage(this, null, message, null));
            }
            catch (WebException)
            {
                // Omitted
            }
        }

        public async Task ResolveUserIdAndPlatform(string url, IUserIdAndPlatformResolver userIdAndPlatformResolver)
        {
            var request = WebRequest.Create(new Uri(url)) as HttpWebRequest;
            if (request == null)
                throw new ArgumentNullException();

            request.Method = Common.HttpGetMethod;
            request.Accept = Common.HttpAccept;
            request.UserAgent = Common.HttpUserAgent;
            request.CookieContainer = CookieJar;

            var task = request.GetResponseAsync();

            try
            {
                var response = (HttpWebResponse) await task.ConfigureAwait(false);
                var responseStream = response.GetResponseStream();
                userIdAndPlatformResolver.Resolve(responseStream);
                response.Close();
            }
            catch (WebException we)
            {
                Messenger.Default.Send(new BattlelogResponseMessage(we.Message, false));
            }
        }

        public async Task GetFile(string url, string isolatedStorageFile)
        {
            var client = new SharpGIS.GZipWebClient();
            try
            {
                string responseStream = await client.DownloadStringTaskAsync(new Uri(url));
                using (var writer = new StreamWriter(_isolatedStorage.OpenFile(isolatedStorageFile, FileMode.Create)))
                    await writer.WriteAsync(responseStream);
                Messenger.Default.Send(new BattlelogResponseMessage(this, Common.StatusInformationDownloading, true));
            }
            catch (WebException we)
            {
                Messenger.Default.Send(new BattlelogResponseMessage(we.Message, false));
            }
        }
    }
}
