using System;
using System.Collections.Generic;
using System.Text;
using System.Runtime.InteropServices;
using System.Text.RegularExpressions;

namespace Jade
{
    public class UrlPicker
    {
        public static List<string> GetHtmlLinks(string html)
        {
            List<string> urlList = new List<string>();

            var regex = new Regex("<a[^>]*href=[',\"]?(?<href>[^\",',>]+)[',\"]?[^>]+>", RegexOptions.Multiline | RegexOptions.IgnoreCase);

            var matches = regex.Matches(html);

            foreach (Match match in matches)
            {
                if (!string.IsNullOrEmpty(match.Groups["href"].Value) && !urlList.Contains(match.Groups["href"].Value))
                    urlList.Add(match.Groups["href"].Value);
            }

            return urlList;


            //unsafe
            //{
            //    //Here get document.
            //    mshtml.HTMLDocumentClass document = new mshtml.HTMLDocumentClass();
            //    IPersistStreamInit persist = document as IPersistStreamInit;
            //    persist.InitNew();
            //    persist = null;


            //    //Get markup service.
            //    IMarkupServices markupServices = document as IMarkupServices;

            //    IMarkupContainer container = null;
            //    IMarkupPointer start, end;

            //    markupServices.CreateMarkupPointer(out start);
            //    markupServices.CreateMarkupPointer(out end);

            //    //Get source.
            //    IntPtr source = Marshal.StringToHGlobalUni(html);

            //    //Get container.
            //    markupServices.ParseString(ref *(ushort*)source.ToPointer(), 0, out container, start, end);
            //    Marshal.Release(source);

            //    if (container != null)
            //    {
            //        IHTMLDocument2 htmlDocument = container as IHTMLDocument2;
            //        IHTMLElementCollection elementCollection = ((htmlDocument as IHTMLDocument2) as IHTMLDocument3).getElementsByTagName("Html");
            //        foreach (mshtml.IHTMLElement item in elementCollection)
            //        {
            //            if (item.parentElement == null)
            //            {
            //                AddItem(item, urlList);
            //            }
            //        }
            //    }
            //    else
            //    {
            //        return null;
            //    }
            //}
            //return urlList;
        }

        static List<string> AllowedExtensions = new List<string>() { ".gif", ".jpg", ".png", ".bmp" };

        public static Dictionary<string, string> GetImagesUrls(ref string html, string baseDir, Uri baseUrl)
        {
            Dictionary<string, string> urlList = new Dictionary<string, string>();

            var regex = new Regex("<img[^>]+src=[',\"]?(?<src>[^\",',>]+)[',\"][^>]*>", RegexOptions.Multiline | RegexOptions.IgnoreCase);

            var matches = regex.Matches(html);

            foreach (Match match in matches)
            {
                if (!string.IsNullOrEmpty(match.Groups["src"].Value) && !urlList.ContainsKey(match.Groups["src"].Value))
                {
                    var src = match.Groups["src"].Value;
                    var fileName = src;
                    var slashIndex = fileName.LastIndexOf("/");
                    if (slashIndex > -1)
                    {
                        fileName = fileName.Substring(slashIndex + 1);
                    }

                    // http://218.22.17.85:7001/cj/photoinfo/binary_middle.do?TableName=DOM_IMAGE&KeyName=REFID&FieldName=IMG_MIDDLE&KeyID=30251

                    var realFileName = fileName.ToLower();

                    if (!(realFileName.Contains(".jpg") || realFileName.Contains(".gif") || realFileName.Contains(".png") || realFileName.Contains(".bmp")))
                    {
                        fileName = Guid.NewGuid().ToString().Replace("-", "") + ".jpg";
                    }
                    urlList.Add(src, fileName);
                    if (Jade.Properties.Settings.Default.IsOnline)
                    {
                        var newImage = match.Value.Replace(match.Groups["src"].Value, "db://" + new Uri(baseUrl, match.Groups["src"].Value).AbsoluteUri);
                        //newImage = "<p style='text-align:center'>" + newImage + "</p>";
                        html = html.Replace(match.Value, newImage);
                    }
                    else
                    {
                        var newImage = match.Value.Replace(match.Groups["src"].Value, baseDir + "\\" + fileName);
                        //newImage = "<p style='text-align:center'>" + newImage + "</p>";
                        html = html.Replace(match.Value, newImage);
                    }
                }
            }

            return urlList;
        }

        //private static void AddItem(mshtml.IHTMLElement item, List<string> urlList)
        //{
        //    if (item.tagName == "A")
        //    {
        //        mshtml.HTMLAnchorElementClass link = item as mshtml.HTMLAnchorElementClass;
        //        if (!string.IsNullOrEmpty(link.href))
        //            urlList.Add(link.href);
        //    }

        //    mshtml.IHTMLElementCollection collection = item.children as mshtml.IHTMLElementCollection;
        //    if (null != collection)
        //    {
        //        foreach (mshtml.IHTMLElement child in collection)
        //        {
        //            AddItem(child, urlList);
        //        }
        //    }
        //}
    }
}
