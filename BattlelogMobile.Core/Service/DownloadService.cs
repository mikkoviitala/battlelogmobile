using System;
using System.IO;
using System.IO.IsolatedStorage;
using System.Net;
using System.Threading.Tasks;
using BattlelogMobile.Core.Model;
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
                    Messenger.Default.Send(new NotificationMessage(this, Common.DeveloperInformation, message));
            }
            catch (WebException)
            {
                // Omitted
            }
        }

        public async Task<BattlelogUser> ResolveUserIdAndPlatform(string url, UserIdAndPlatformResolver userIdAndPlatformResolver)
        {
            BattlelogUser user = null;

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
                user = userIdAndPlatformResolver.Resolve(responseStream);
                response.Close();
            }
            catch (WebException we)
            {
                Messenger.Default.Send(new NotificationMessage(this, we.Message));
            }
            return user;
        }

        public async Task<bool> GetFile(string url, string isolatedStorageFile)
        {
            var client = new SharpGIS.GZipWebClient();
            try
            {
                string responseStream = await client.DownloadStringTaskAsync(new Uri(url));
                using (var writer = new StreamWriter(_isolatedStorage.OpenFile(isolatedStorageFile, FileMode.Create)))
                    await writer.WriteAsync(responseStream);
                return true;
            }
            catch (WebException we)
            {
                Messenger.Default.Send(new NotificationMessage(this, we.Message));
            }
            return false;
        }
    }
}
