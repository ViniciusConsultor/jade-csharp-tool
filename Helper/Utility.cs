using System;
using System.Collections.Generic;
using System.Text;
using System.Net;

namespace HFBBS
{
    public class Utility
    {
        public static CookieCollection GetCookies(string cookies)
        {
            if (string.IsNullOrEmpty(cookies))
                return null;

            CookieCollection collection = new CookieCollection();
            foreach (string cookie in cookies.Split(new char[] { ';' }, StringSplitOptions.RemoveEmptyEntries))
            {
                string[] cookieItem = cookie.Split(new char[] { '=' }, StringSplitOptions.RemoveEmptyEntries);
                if (cookieItem.Length != 2)
                {
                    continue;
                }
                collection.Add(new Cookie(cookieItem[0].Trim(), cookieItem[1].Trim()));
            }
            return collection;
        }
    }
}