using System;
using System.Collections.Generic;
using System.Text;
using System.IO;
using System.Net;

namespace Jade
{
    public class HtmlPicker
    {
        public static void VisitUrl(
            Uri uri, string method, Version version, string referer,
            CookieCollection cookies, string userAgent, byte[] postData,
            string userName, string userPassword,
            string proxyName, int proxyPort, string proxyUserName, string proxyPassword,
            out MemoryStream memoryStream)
        {
            //Create web request.
            HttpWebRequest request = (HttpWebRequest)WebRequest.Create(uri);
            request.Accept = "*/*";
            request.Method = method;
            request.Expect = string.Empty;

            //Set http version.
            if (version != null)
                request.ProtocolVersion = version;

            if (postData != null)
            {
                request.ContentType = "application/x-www-form-urlencoded; charset=utf-8";
                request.ContentLength = postData.Length;
                Stream stream = request.GetRequestStream();
                stream.Write(postData, 0, postData.Length);
                stream.Flush();
                stream.Close();
            }

            //Set referer.
            if (!string.IsNullOrEmpty(referer))
                request.Referer = referer;

            //Set cookie.
            if (cookies != null)
            {
                request.CookieContainer = new CookieContainer();
                try
                {
                    request.CookieContainer.Add(uri, cookies);
                }
                catch
                {
                }
            }

            //Set User Agent.
            if (!string.IsNullOrEmpty(userAgent))
                request.UserAgent = userAgent;

            // If the feed source requires authentication.
            if (!string.IsNullOrEmpty(userName))
                request.Credentials = new NetworkCredential(userName, userPassword);

            // Set proxy settings to the web request
            if (!string.IsNullOrEmpty(proxyName))
            {
                request.Proxy = new System.Net.WebProxy(proxyName, proxyPort);
                if (!string.IsNullOrEmpty(proxyUserName))
                {
                    request.Proxy.Credentials = new System.Net.NetworkCredential(proxyUserName, proxyPassword);
                }
            }

            request.Headers.Add("Accept-Encoding", "gzip,deflate");
            request.AutomaticDecompression = DecompressionMethods.GZip | DecompressionMethods.Deflate;

            //Get Response Stream.
            using (System.Net.WebResponse webResponse = request.GetResponse())
            {
                using (var sr = webResponse.GetResponseStream())
                {
                    memoryStream = new MemoryStream(500 * 1024); //out stream.
                    byte[] buffer = new byte[1024 * 50]; // 2 KB buffer.
                    int size = 0;

                    while ((size = sr.Read(buffer, 0, buffer.Length)) > 0)
                    {
                        memoryStream.Write(buffer, 0, size);
                    }
                }
            }
        }

        public static void VisitUrl(
            Uri uri, string method, Version version, string referer,
            CookieCollection cookies, string userAgent, byte[] postData,
            out MemoryStream memoryStream)
        {
            VisitUrl(uri, method, version, referer,
                cookies, userAgent, postData,
                null, null,
                null, 0, null, null, out memoryStream);
        }

        public static string VisitUrl(
            Uri uri, string method, Version version, string referer,
            CookieCollection cookies, string userAgent, string postData, Encoding encoding,
            string userName, string userPassword,
            string proxyName, int proxyPort, string proxyUserName, string proxyPassword)
        {
            MemoryStream memoryStream;

            VisitUrl(uri, method, version, referer,
                cookies, userAgent, string.IsNullOrEmpty(postData) ? null : encoding.GetBytes(postData),
                userName, userPassword,
                proxyName, proxyPort, proxyUserName, proxyPassword, out memoryStream);

            string html = encoding.GetString(memoryStream.GetBuffer());
            memoryStream.Dispose();
            return html;
        }

        public static string SubString(string fetchStuff, string startTag, string endTag)
        {
            string result;

            int startIndex, endIndex;
            startIndex = fetchStuff.IndexOf(startTag);
            endIndex = fetchStuff.IndexOf(endTag, startIndex == -1 ? 0 : startIndex);

            if (startIndex == -1)
                result = string.Empty;
            else if (endIndex == -1)
            {
                result = fetchStuff.Substring(startIndex + startTag.Length);
            }
            else if (endIndex < startIndex)
            {
                result = string.Empty;
            }
            else
            {
                result = fetchStuff.Substring(startIndex + startTag.Length, endIndex - startIndex - startTag.Length);
            }
            return result;
        }

        public static string VisitUrl(
            Uri uri, string method, Version version, string referer,
            CookieCollection cookies, string userAgent, string postData, Encoding encoding)
        {
            try
            {
                MemoryStream memoryStream;

                VisitUrl(uri, method, version, referer,
                    cookies, userAgent, string.IsNullOrEmpty(postData) ? null : encoding.GetBytes(postData),
                    null, null,
                    null, 0, null, null, out memoryStream);

                string html = encoding.GetString(memoryStream.GetBuffer());
                html = html.Replace("\0", "");
                memoryStream.Dispose();
                return html;
            }
            catch
            {
                return string.Empty;
            }
        }
    }
}
