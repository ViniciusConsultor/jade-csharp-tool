using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;
using System.Net;
using System.IO;
using Jade.Http;

namespace Jade.AHExam
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }

        string viewState = "";

        private void Form1_Load(object sender, EventArgs e)
        {
            var login = GET("http://spcx.ahtvu.ah.cn/MainForm/login.aspx?Platform=0");
            //<input type="hidden" name="__VIEWSTATE" id="__VIEWSTATE" value="/wEPDwUJNjAwNDUzNDkwZBgBBR5fX0NvbnRyb2xzUmVxdWlyZVBvc3RCYWNrS2V5X18WAQUIQnRuTG9naW5SdzAxW8XVQ8JIw49RDcQhGkwhhg==" />
            viewState = login.Substring(login.IndexOf("id=\"__VIEWSTATE\" value=\"")).Replace("id=\"__VIEWSTATE\" value=\"", "");
            viewState = viewState.Substring(0, viewState.IndexOf("\""));
            DownloadValidCode();
        }

        private void DownloadValidCode()
        {
            //System.Net.WebClient client = new System.Net.WebClient();
            //client.DownloadDataCompleted += new DownloadDataCompletedEventHandler(client_DownloadDataCompleted);
            //client.DownloadDataAsync(new Uri("http://spcx.ahtvu.ah.cn/NetWorkLogin/ValidateCode.aspx"));
            var d = GetStream("http://spcx.ahtvu.ah.cn/NetWorkLogin/ValidateCode.aspx");
            this.pictureBox1.Image = Image.FromStream(d);
        }

        string cookie = "";
        void client_DownloadDataCompleted(object sender, DownloadDataCompletedEventArgs e)
        {
            if (e.Error == null)
            {
                try
                {

                    MemoryStream stream = new MemoryStream(e.Result, 0, e.Result.Length);
                    this.pictureBox1.Image = Image.FromStream(stream);
                    CacheObject.Cookie = (sender as System.Net.WebClient).ResponseHeaders[HttpResponseHeader.SetCookie].Replace("; path=/", "");
                    Console.WriteLine(CacheObject.Cookie);
                }
                catch
                {
                    MessageBox.Show("加载验证码出错，请选择离线操作");
                }
            }
            else
            {
                MessageBox.Show("加载验证码出错，请选择离线操作");
            }
        }

        public static Stream GetStream(string url)
        {
            var client = new Jade.Http.WebClient();
            client.Cookie = CacheObject.Cookie;
            var response = client.GetStream(url);
            CacheObject.Cookie = client.Cookie;
            return response;
        }

        public static string GET(string url)
        {
            var client = new Jade.Http.WebClient();
            client.Cookie = CacheObject.Cookie;
            client.Encoding = Encoding.UTF8;
            var response = client.OpenRead(url);
            CacheObject.Cookie = client.Cookie;
            return response;
        }

        public static string POST(string url, string data)
        {
            var client = new Jade.Http.WebClient();
            client.Cookie = CacheObject.Cookie;
            client.Encoding = Encoding.UTF8;
            var response = client.OpenRead(url, data);
            CacheObject.Cookie = client.Cookie;
            return response;
        }

        List<课程> Courses = new List<课程>();

        private void button1_Click(object sender, EventArgs e)
        {
            var loginUrl = "http://spcx.ahtvu.ah.cn/MainForm/login.aspx?Platform=0";
            var response = POST(loginUrl, "__VIEWSTATE=" + System.Web.HttpUtility.UrlEncode(viewState, Encoding.UTF8) + "&TxtName=" + this.txtUser.Text + "&TxtPw=" + this.txtPassword.Text + "&TxtYzm=" + this.txtValidCode.Text + "&BtnLogin.x=23&BtnLogin.y=6");
            Console.WriteLine(response);
            if (response.IndexOf("<span style=\"font-weight:bold;\">进入</span>") > 0)
            {
                //<span id="LblLoginName" style="font-weight:bold;">Chenxiaoyu666</span>
                var start = "<span id=\"LblLoginName\" style=\"font-weight:bold;\">";
                response = response.Substring(response.IndexOf(start) + start.Length);
                response = response.Substring(0, response.IndexOf("<span"));
                CacheObject.User = response;
                this.DialogResult = DialogResult.OK;
                this.Close();
            }
            else
            {
                MessageBox.Show("登录失败");
            }
        }

        课程计划 ChosePlan = new 课程计划();

        private void pictureBox1_Click(object sender, EventArgs e)
        {
            this.DialogResult = DialogResult.Cancel;
        }

        private void button2_Click(object sender, EventArgs e)
        {
            this.Close();
        }


    }

    public class 课程计划
    {
        public string 名称 { get; set; }

        public int 总学时 { get; set; }

        public string 所属学段 { get; set; }

        public string 所属学科 { get; set; }

        public string Url { get; set; }
    }


    public class 课程
    {
        public 课程()
        {
            课程状态 = "未开始学习";
        }

        public string 名称 { get; set; }

        public string 教师 { get; set; }

        public int 已学习学时数 { get; set; }

        public int 总学时 { get; set; }

        public int 学分 { get; set; }

        public string 链接地址 { get; set; }

        public string 课程编号 { get; set; }

        public string 课程状态 { get; set; }
    }
}
