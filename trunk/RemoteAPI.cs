using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.RegularExpressions;

namespace Jade
{
    public class RemoteAPI
    {
        static bool IsInitAPI = false;

        public static string GetNewsId()
        {
            var request = CacheObject.WebRequset;
            request.Url = "http://newscms.house365.com/newCMS/news/news_mod.php?action=add";
            request.Cookie = CacheObject.Cookie;
            request.RequestData = new RequestPostData()
            {
                PostDatas = new List<PostDataItem> { new PostDataItem{
                        Data = "channel_id="+CacheObject.channelid+"\0"
                    }}
            };
            var result = request.Post();
            // &news_id=020625642&

            var newsId = Substring(result, "&news_id=", "&");
            if (!IsInitAPI)
            {
                IsInitAPI = true;
                InitAPI(result);
            }

            return newsId;
        }


        public static void InitAPI(string html)
        {
            HtmlAgilityPack.HtmlDocument HtmlDoc = new HtmlAgilityPack.HtmlDocument();
            HtmlDoc.OptionAutoCloseOnEnd = true;
            //html = html.ToLower();
            if (!html.Contains("</BODY") && !html.Contains("</body"))
            {
                html += "</body>";
            }
            html = html.Replace("<tbody>", "").Replace("</tbody>", "").Replace("<TBODY>", "").Replace("</TBODY>", "");
            var xpath = "//*[@id=\"enorth_news\"]/tr[1]/td[2]/select[1]//option";
            HtmlDoc.LoadHtml(html);
            var nodes = HtmlDoc.DocumentNode.SelectNodes(xpath);
            if (nodes != null)
            {
                List<DisplayNameValuePair> sources = RemoteWebService.Instance.Source;
                foreach (HtmlAgilityPack.HtmlNode option in nodes)
                {
                    var value = option.Attributes["value"].Value;
                    var text = option.InnerText;
                    if (value != "")
                    {
                        if (!sources.Any(d => d.Value == value))
                        {
                            sources.Add(new DisplayNameValuePair { DisplayName = text, Value = value });
                        }
                    }
                }

            }
            nodes = HtmlDoc.DocumentNode.SelectNodes("//*[@id=\"news_template_file_1\"]//option");
            if (nodes != null)
            {
                RemoteWebService.Instance.Template.Clear();
                List<DisplayNameValuePair> sources = RemoteWebService.Instance.Template;
                foreach (HtmlAgilityPack.HtmlNode option in nodes)
                {
                    var value = option.Attributes["value"].Value;
                    var text = option.InnerText;
                    if (value != "")
                        if (!sources.Any(d => d.Value == value))
                        {
                            sources.Add(new DisplayNameValuePair { DisplayName = text, Value = value });
                        }
                }
            }
            nodes = HtmlDoc.DocumentNode.SelectNodes("//*[@id=\"labelPanel\"]/div[1]//div/input");
            if (nodes != null)
            {
                List<DisplayNameValuePair> sources = RemoteWebService.Instance.SpecilTags;
                foreach (HtmlAgilityPack.HtmlNode option in nodes)
                {
                    var value = option.Attributes["value"].Value;
                    var text = option.Attributes["alt"].Value; ;
                    if (value != "")
                        if (!sources.Any(d => d.Value == value))
                        {
                            sources.Add(new DisplayNameValuePair { DisplayName = text, Value = value });
                        }
                }
            }
            RemoteWebService.Instance.Save();
            HtmlDoc = null;
        }

        public static string Substring(string source, string start, string end)
        {
            int startIndex, endIndex;

            startIndex = source.IndexOf(start);

            if (startIndex == -1)
                return string.Empty;

            endIndex = source.IndexOf(end, startIndex + start.Length);

            return source.Substring(startIndex + start.Length, endIndex - startIndex - start.Length);
        }

        static string getLabelData(string labels, string newsid)
        {
            var result = "";
            var tags = labels.Replace("\"", "").Split('&', ',');
            foreach (var tag in tags)
            {
                if (tag != "")
                {
                    var specialTag = RemoteWebService.Instance.SpecilTags.FirstOrDefault(t => t.DisplayName.Equals(tag.Trim()));
                    if (specialTag != null)
                    {
                        //encoding("label_id[]")
                        result += "&label_id%5B%5D=" + specialTag.Value;
                        GET("http://newscms.house365.com/newCMS/news/ajax_lable.php?channel_id=" + specialTag.Value + "&news_id=" + newsid + "&pub_date=&list_order=&ty=add");
                    }
                    RemoteWebService.Instance.AddTag(tag);
                }
            }
            RemoteWebService.Instance.Save();
            return result;
        }


        static string encoding(string result)
        {
            return System.Web.HttpUtility.UrlEncode(result, Encoding.GetEncoding("gb2312"));
        }

        public static List<DisplayNameValuePair> SearchLabel(string label)
        {
            var result = new List<DisplayNameValuePair>();
            var request = CacheObject.WebRequset;
            request.Url = "http://newscms.house365.com/newCMS/news/ajax_channel.php?keyword=" + encoding(label) + "&chengshiid=" + CacheObject.channelid;
            var html = request.Get();

            //<li onselect="this.text.value = '家在合肥'; chk_channel('8050800','家在合肥'); "> 家在合肥</li>

            var regex = new Regex("chk_channel\\('(\\d+)','([^']+)'\\)");

            var labels = regex.Matches(html);

            foreach (Match matchLabel in labels)
            {
                result.Add(new DisplayNameValuePair { DisplayName = matchLabel.Groups[2].Value.Trim(), Value = matchLabel.Groups[1].Value });
            }

            return result;
        }

        public static string UploadImage(string filename)
        {
            Log4Log.Error("开始上传" + filename);
            var client = new Jade.Http.WebClient();
            client.Cookie = CacheObject.Cookie;
            var response = client.UploadFile("http://newscms.house365.com/newCMS/news/addpic_save.php", "shuiyin=ok&sywz_ty=cb", @"filename=" + filename);
            // "附件保存成功!\r\n<script type=\"text/javascript\">\r\n\r\n\r\nfunction returnValue()\r\n{\r\nwindow.opener.document.all.src.value='http://pic.house365.com/newcms/2012/07/26/13432723935010b5c97c647.png';    //地址\r\nthis.close();\r\n}\r\n\r\nfunction returnValue2()\r\n{\r\nwindow.opener.ksfj('http://pic.house365.com/newcms/2012/07/26/13432723935010b5c97c647.png','','',0,'');\r\nthis.close();\r\n}\r\n\r\n\r\n\r\nvar refresh = \"list_pic.php?user_id=5809&parent_channel_id=&bjq=\";\r\nfunction myrefresh()\r\n{\r\nwindow.location.href=refresh;\r\n}\r\nsetTimeout('myrefresh()',1000); //指定1秒刷新一次\r\n</script>"
            if (response.Contains("附件保存成功"))
            {
                var regex = new System.Text.RegularExpressions.Regex("value='([^']+)'");
                var url = regex.Match(response).Groups[1].Value;
                Log4Log.Error("上传" + filename + "成功，url为" + url);
                return url;
            }
            else
            {
                Log4Log.Error("附件保存失败");
                Log4Log.Error(response);
            }
            return "";
        }

        public static string GET(string url)
        {
            var client = new Jade.Http.WebClient();
            client.Cookie = CacheObject.Cookie;
            var response = client.OpenRead(url);
            return response;
        }

        public static string POST(string url, string data)
        {
            var client = new Jade.Http.WebClient();
            client.Cookie = CacheObject.Cookie;
            var response = client.OpenRead(url, data);
            return response;
        }

        public static List<string> GetImages()
        {
            var result = new List<string>();
            if (CacheObject.IsLognIn)
            {
                var request = CacheObject.WebRequset;
                request.Url = "http://newscms.house365.com/newCMS/news/list_pic.php?parent_channel_id=" + CacheObject.channelid + "&which_field=keywords&search_word=&type_ename=&user_id=0&fromday=&show_mode=&bjq=&cx.x=47&cx.y=7";
                var html = request.Get();
                var xpath = "//*[@id=\"pictable\"]//img";
                HtmlAgilityPack.HtmlDocument HtmlDoc = new HtmlAgilityPack.HtmlDocument();
                HtmlDoc.OptionAutoCloseOnEnd = true;
                HtmlDoc.LoadHtml(html);
                var nodes = HtmlDoc.DocumentNode.SelectNodes(xpath);
                if (nodes != null)
                {
                    foreach (HtmlAgilityPack.HtmlNode node in nodes)
                    {
                        result.Add(node.Attributes["src"].Value);
                    }
                }
            }
            return result;
        }

        /// <summary>
        /// 
        /// "http://newscms.house365.com/newCMS/news/news_send.php?news_id=020655463&channel_id=8000000"

        ////"http://newscms.house365.com/newCMS/news/news_back.php?news_id=020655463&channel_id=8000000&wait=wait"

        ////"http://newscms.house365.com/newCMS/news/news_auto.php?news_id=020655463&channel_id=8000000"

        ////"http://newscms.house365.com/newCMS/news/news_back.php?news_id=020655463&channel_id=8000000&auto=auto"
        /// </summary>
        /// <param name="newsId"></param>
        /// <returns></returns>
        public static bool SendNews(int newsId, bool sendCheck = false)
        {
            var url = "http://newscms.house365.com/newCMS/news/news_send.php?news_id=0" + newsId + "&channel_id=" + CacheObject.channelid;
            CacheObject.MainForm.OpenNewUrlAndClose(url);
            return true;
        }

        public static bool Publish(Model.IDownloadData data = null)
        {
            CacheObject.CurrentRequestCount++;
            //UploadImage();
            //return;
            if (data != null)
            {
                PrepareImage(data);

                try
                {
                    var isEdit = data.RemoteId != 0;
                    string newsid = !isEdit ? GetNewsId() : "0" + data.RemoteId.ToString();
                    if (!isEdit)
                    {
                        data.RemoteId = int.Parse(newsid);
                    }
                    var postData = string.Format(@"actions=mod&rank=null&refer_channel_id=" + CacheObject.channelid + "&news_source_name_1={0}&news_source_name={0}&make_topic_more_link=1&news_template_file_1={1}&news_template_file_bak={1}&news_channel_id=0&news_template_file=&news_title={2}&news_type=1&news_type=1&news_keywords={3}&news_keywords2={4}&news_sub_title={5}{6}&comboText=&cmspinglun={7}&bbspinglun_title={8}&bbspinglun_url={9}&kfbm_id={10}&kfbm_link={11}&gfbm_id={12}&gfbm_link={13}&viewediter=&news_content={14}&news_abs={15}&news_top={16}&news_guideimage={17}&news_guideimage2={18}&news_abstract={19}&news_description={20}&news_link={21}&news_down={22}&news_left={23}&news_right={24}&comment_url={25}&news_video={26}&news_id={27}&tag2cd=&plat={28}&news_type_id=1&request_channel_id=&save.x=70&save.y=32\0",
                        encoding(data.news_source_name), encoding(data.news_template_file), encoding(data.Title), encoding(data.Keywords), encoding(data.news_keywords2),
                         encoding(data.SubTitle),
                       getLabelData(data.label_base, newsid),
                        data.cmspinglun ? "1" : "0", "", "", data.kfbm_id, data.kfbm_link, data.gfbm_id, data.gfbm_link,
                        CacheObject.IsTest ? encoding("<!-- news begin-->" + data.Content + "<!-- news end-->") : encoding("" + data.Content),
                        encoding(data.news_abs), encoding(data.news_top), data.news_guideimage, data.news_guideimage2, encoding(data.Summary), encoding(data.news_description),
                        data.news_link, encoding(data.news_down),
                         encoding(data.news_left), encoding(data.news_right), data.comment_url, data.news_video, newsid,
                         isEdit ? "edit" : "");

                    var request = CacheObject.WebRequset;
                    request.Url = "http://newscms.house365.com/newCMS/news/news_save.php";
                    request.Cookie = CacheObject.Cookie;
                    request.RequestData = new RequestPostData()
                    {
                        PostDatas = new List<PostDataItem> { new PostDataItem{
                        Data = postData}}
                    };

                    var result = request.Post();
                    if (result != "" && !result.Contains("修改失败"))
                    {
                        // 生成html
                        //" <iframe src='../../newCMS/template/createhtml.php?news_id=020655566&channel_id=8000000' width=\"1\" height=\"1\" frameborder=\"0\"></iframe>\r\n\t<script>window.onload=function(){window.opener=null;window.open('','_parent','');window.close();}</script>"

                        var regex = new System.Text.RegularExpressions.Regex("src='([^']+)'");
                        var url = regex.Match(result).Groups[1].Value;
                        url = new Uri(new Uri("http://newscms.house365.com/newCMS/news/news_save.php"), url).AbsoluteUri;

                        CacheObject.MainForm.GernateHtml(url, newsid);
                        //result = GET(url);
                        ////<script type='text/javascript' src='tem_hf/estate.php?news_id=020655584'></script>
                        //var newurl = regex.Match(result).Groups[1].Value;
                        //newurl = new Uri(new Uri("http://newscms.house365.com/newCMS/news/news_save.php"), url).AbsoluteUri;
                        //result = GET(newurl);
                        //Console.WriteLine(result);
                        return true;
                    }
                    else
                    {
                        Log4Log.Error(result);
                    }
                }
                catch (Exception ex)
                {
                    Log4Log.Exception("发布新闻", ex);
                    return false;
                }
            }
            return false;
        }

        /// <summary>
        /// 准备图片
        /// </summary>
        /// <param name="data"></param>
        public static void PrepareImage(Model.IDownloadData data)
        {
            if (data.Content.IndexOf("<img") > -1 || data.Content.IndexOf("<IMG") > -1)
            {
                HtmlAgilityPack.HtmlDocument HtmlDoc = new HtmlAgilityPack.HtmlDocument();
                HtmlDoc.OptionAutoCloseOnEnd = true;

                HtmlDoc.LoadHtml(data.Content);
                var nodes = HtmlDoc.DocumentNode.SelectNodes("//img");
                if (nodes != null)
                {
                    foreach (HtmlAgilityPack.HtmlNode node in nodes)
                    {
                        var src = node.Attributes["src"].Value;
                        if (!src.Contains("http://"))
                        {
                            //"file:///D:/project/Client-1.2R2/HFBBS/release//Pic/5/n14290497.jpg"
                            var file = src.Replace("file:///", "").Replace("//", "\\").Replace("/", "\\").Replace("%20", " ");
                            if (System.IO.File.Exists(file))
                            {
                                try
                                {
                                    var real = UploadImage(file);
                                    if (real != "")
                                    {
                                        data.Content = data.Content.Replace(src, real);
                                    }
                                }
                                catch (Exception ex)
                                {
                                    Log4Log.Error("上传图片" + src + "失败");
                                }
                            }
                            else
                            {
                                Log4Log.Error("图片" + src + "不存在");
                            }
                        }
                    }
                }
                HtmlDoc = null;
            }
        }
    }
}
