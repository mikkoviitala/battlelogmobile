using System;
using System.Net;
using SharpGIS;

namespace BattlelogMobile.Core.Service
{
    public class CookieAwareGZipWebClient : GZipWebClient
    {
        public CookieAwareGZipWebClient()
        {}
        
        public CookieAwareGZipWebClient(CookieContainer cookieCookieJar)
        {
            CookieJar = cookieCookieJar;
        }

        public CookieContainer CookieJar { get; set; }

        protected override WebRequest GetWebRequest(Uri address)
        {
            WebRequest webRequest = base.GetWebRequest(address);
            var request = webRequest as HttpWebRequest;
            if (request != null)
            {
                request.CookieContainer = CookieJar;
            }
            return webRequest;
        }
    }
}