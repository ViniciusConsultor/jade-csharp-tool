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
                return string.Join("\n", SelectNews.Select(n => n.Id + ":" + n.Title).ToArray());
            }
        }

        public IDownloadData Data
        {
            get;
            set;
        }

        public RelatedNews()
        {
            InitializeComponent();
        }

        static string encoding(string result)
        {
            return System.Web.HttpUtility.UrlEncode(result, Encoding.GetEncoding("gb2312"));
        }

        private void checkedListBox1_SelectedIndexChanged(object sender, EventArgs e)
        {

        }

        private void simpleButton4_Click(object sender, EventArgs e)
        {
            var url = string.Format("http://newscms.house365.com/newCMS/news/news_correlated_frame.php?keyword={0}&date_range=a&channel_range=&news_id={1}&channel_id={2}&Submit=%CB%D1%CB%F7", encoding(Data.Keywords), "0" + Data.RemoteId, CacheObject.channelid);
            var request = CacheObject.WebRequset;
            request.Url = url;
            request.Cookie = CacheObject.Cookie;
            var html = request.Get();
            HtmlAgilityPack.HtmlDocument HtmlDoc = new HtmlAgilityPack.HtmlDocument();
            //HtmlDoc.OptionAutoCloseOnEnd = true;
            HtmlDoc.OptionFixNestedTags = true;
            HtmlDoc.OptionOutputAsXml = true;
            HtmlDoc.LoadHtml(html);
            var nodes = HtmlDoc.DocumentNode.SelectNodes("//table[1]//input[@value]");
            var news = new List<News>();
            this.checkedListBox1.Items.Clear();
            checkedListBox1.DisplayMember = "Title";
            checkedListBox1.ValueMember = "Id"; 
            foreach (HtmlAgilityPack.HtmlNode node in nodes)
            {
                var n = new News();
                n.Title = node.Attributes["value"].Value;
                n.Id = node.Attributes["id"].Value.Replace("title_", "");
                news.Add(n);
            }
            checkedListBox1.DataSource = news;
        }
    }
}