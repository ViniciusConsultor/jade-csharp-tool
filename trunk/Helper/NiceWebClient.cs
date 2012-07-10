using System;
using System.Collections.Generic;
using System.Text;
using System.Net;

namespace HFBBS
{
    public class NiceWebClient : WebClient
    {
        private const string RefererHeaderName = "Referer";
        public string Referer
        {
            get
            {
                return this.Headers[RefererHeaderName];
            }
            set
            {
                this.Headers.Remove(RefererHeaderName);
                this.Headers.Add(RefererHeaderName, value);
            }
        }

        private const string UserAgentHeaderName = "User-Agent";
        public string UserAgent
        {
            get
            {
                return this.Headers[UserAgentHeaderName];
            }
            set
            {
                this.Headers.Remove(UserAgentHeaderName);
                this.Headers.Add(UserAgentHeaderName, value);
            }
        }

        private const string CookieHeaderName = "Cookie";
        public string Cookie
        {
            get
            {
                return this.Headers[CookieHeaderName];
            }
            set
            {
                this.Headers.Remove(CookieHeaderName);
                this.Headers.Add(CookieHeaderName, value);
            }
        }
    }
}
