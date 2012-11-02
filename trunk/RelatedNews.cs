using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;
using DevExpress.XtraEditors;
using System.Linq;
using Jade.Model;
using System.Threading;

namespace Jade
{
    public partial class RelatedNews : DevExpress.XtraEditors.XtraForm
    {
        public class News
        {
            public string Id { get; set; }
            public string Title { get; set; }
        }

        public List<News> SelectNews
        {
            get;
            set;
        }

        public string SelectNewsStr
        {
            get
            {
                return string.Join("\r\n", SelectNews.Select(n => n.Id + ":" + n.Title).ToArray());
            }
        }
        IDownloadData data;
        public IDownloadData Data
        {
            get { return data; }
            set
            {
                data = value;
                this.txtKeyword.Text = data.Keywords;
                if (!string.IsNullOrEmpty(data.news_link))
                {
                    var lines = data.news_link.Split(new string[] { "\r\n" }, StringSplitOptions.RemoveEmptyEntries);
                    foreach (var line in lines)
                    {
                        var ns = line.Split(new char[] { ':' }, 2);
                        this.SelectNews.Add(new News { Id = ns[0], Title = ns[1] });
                    }
                    this.textBox1.Text = this.SelectNewsStr;
                }
            }
        }

        public RelatedNews()
        {
            InitializeComponent();
            this.SelectNews = new List<News>();
        }

        static string encoding(string result)
        {
            return System.Web.HttpUtility.UrlEncode(result, Encoding.GetEncoding("gb2312"));
        }

        private void checkedListBox1_SelectedIndexChanged(object sender, EventArgs e)
        {

        }
        List<News> news;
        private void simpleButton4_Click(object sender, EventArgs e)
        {
            this.label3.Text = "正在搜索中。。。";
            new Thread(() =>
            {
                try
                {
                    var url = string.Format("http://newscms.house365.com/newCMS/news/news_correlated_frame.php?keyword={0}&date_range=a&channel_range=&news_id={1}&channel_id={2}&Submit=%CB%D1%CB%F7", encoding(this.txtKeyword.Text), "0" + Data.RemoteId, CacheObject.channelid);
                    var request = CacheObject.WebRequset;
                    request.Url = url;
                    request.Cookie = CacheObject.Cookie;
                    var html = request.Get();
                    HtmlAgilityPack.HtmlDocument HtmlDoc = new HtmlAgilityPack.HtmlDocument();
                    //HtmlDoc.OptionAutoCloseOnEnd = true;
                    HtmlDoc.OptionFixNestedTags = true;
                    HtmlDoc.OptionOutputAsXml = true;
                    HtmlDoc.LoadHtml(html);
                    var nodes = HtmlDoc.DocumentNode.SelectNodes("//table[2]//input[@type='hidden']");
                    news = new List<News>();

                    if (nodes != null)
                    {
                        foreach (HtmlAgilityPack.HtmlNode node in nodes)
                        {
                            var n = new News();
                            n.Title = node.Attributes["value"].Value;
                            n.Id = node.Attributes["id"].Value.Replace("title_", "");
                            news.Add(n);
                        }
                    }

                    this.BeginInvoke(new MethodInvoker(() =>
                    {
                        isInit = true;
                        this.checkedListBox1.Items.Clear();
                        checkedListBox1.DisplayMember = "Title";
                        checkedListBox1.ValueMember = "Id";
                        checkedListBox1.DataSource = null;
                        checkedListBox1.DataSource = news;
                        checkedListBox1.DisplayMember = "Title";
                        checkedListBox1.ValueMember = "Id";
                        this.label3.Text = "搜索完成";
                        if (this.SelectNews.Count > 0)
                        {
                            foreach (var ne in SelectNews)
                            {
                                var index = news.FindIndex(n => n.Id == ne.Id);
                                if (index != -1)
                                {
                                    checkedListBox1.SetItemChecked(index, true);
                                }
                            }
                        }
                        isInit = false;
                    }));
                }
                catch
                {
                }

            }).Start();

        }

        bool isInit = false;

        private void simpleButton6_Click(object sender, EventArgs e)
        {
            this.DialogResult = DialogResult.OK;
            this.Close();
        }

        private void simpleButton5_Click(object sender, EventArgs e)
        {
            this.DialogResult = DialogResult.Cancel;
            this.Close();
        }

        private void RelatedNews_Load(object sender, EventArgs e)
        {
            if (this.Data != null)
                simpleButton4_Click(null, null);

        }

        private void checkedListBox1_ItemCheck(object sender, ItemCheckEventArgs e)
        {
            if (!isInit)
            {
                var n = news[e.Index];
                if (e.NewValue == CheckState.Checked)
                {
                    if (!SelectNews.Any(i => i.Id == n.Id))
                    {
                        SelectNews.Add(n);
                        AddNews(n);
                    }

                }
                else if (e.NewValue == CheckState.Unchecked)
                {
                    SelectNews.Remove(n);
                    Remove(n);
                }
                this.textBox1.Text = this.SelectNewsStr;
            }
        }

        private void Remove(News n)
        {
            this.label3.Text = "正在移除" + n.Title;
            var addUrl = string.Format("http://newscms.house365.com/newCMS/news/ajax_likeNews.php?news_id={0}&like_id={1}&like_title={2}&ty=del", "0" + Data.RemoteId, n.Id, encoding(n.Title));
            var request = CacheObject.WebRequset;
            request.Url = addUrl;
            request.Cookie = CacheObject.Cookie;
            var html = request.Get();
            this.label3.Text = "移除" + n.Title + "成功";
        }

        private void AddNews(News n)
        {
            this.label3.Text = "正在添加" + n.Title;
            var addUrl = string.Format("http://newscms.house365.com/newCMS/news/ajax_likeNews.php?news_id={0}&like_id={1}&like_title={2}&ty=add", "0" + Data.RemoteId, n.Id, encoding(n.Title));
            var request = CacheObject.WebRequset;
            request.Url = addUrl;
            request.Cookie = CacheObject.Cookie;
            var html = request.Get();
            this.label3.Text = "添加" + n.Title + "成功";
        }
    }
}