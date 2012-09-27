using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;
using System.IO;

namespace Jade.AHExam
{
    public partial class LearnForm : Form
    {
        public LearnForm()
        {
            InitializeComponent();
        }

        void Init()
        {

            // 选择课程
            var url = "http://spcx.ahtvu.ah.cn/NetWorkIndex/MainSelectPlan.aspx";
            Success("正在选择课程" + url);
            var allCourse = GET(url);


            //<a href="Main.aspx?id=9F87A437-A014-4B37-B17F-3FB33F2B2100&type=S">进入计划</a>
            //getCource

            var xpath = "//div[@id='myStudentTable']//tr";
            HtmlAgilityPack.HtmlDocument HtmlDoc = new HtmlAgilityPack.HtmlDocument();
            //HtmlDoc.OptionAutoCloseOnEnd = true;
            HtmlDoc.OptionFixNestedTags = true;
            HtmlDoc.OptionOutputAsXml = true;
            HtmlDoc.LoadHtml(allCourse);
            var trs = HtmlDoc.DocumentNode.SelectNodes(xpath);
            if (trs != null && trs.Count == 2)
            {
                var tr = trs[1];
                CacheObject.课程计划 = new 课程计划();
                //"<td>2012-2013学年度合肥市小学教师远程培训 数学</td><td></td><td>60</td><td>小学</td><td>小学数学</td><td><a href=\"Main.aspx?id=9F87A437-A014-4B37-B17F-3FB33F2B2100&amp;type=S\">进入计划</a></td>"

                CacheObject.课程计划.名称 = tr.ChildNodes[0].InnerText;
                CacheObject.课程计划.总学时 = int.Parse(tr.ChildNodes[2].InnerText);
                CacheObject.课程计划.所属学段 = tr.ChildNodes[3].InnerText;
                CacheObject.课程计划.所属学科 = tr.ChildNodes[4].InnerText;
                CacheObject.课程计划.Url = new Uri(new Uri(url), tr.ChildNodes[5].ChildNodes[0].Attributes["href"].Value).AbsoluteUri;
                Success("正在选择课程计划" + CacheObject.课程计划.Url);
                var planHtml = GET(CacheObject.课程计划.Url);
                this.lblUser.BeginInvoke(new MethodInvoker(() =>
                {
                    this.lblPlanName.Text = CacheObject.课程计划.名称;
                    this.lblxueduan.Text = CacheObject.课程计划.所属学段;
                    this.lblxueke.Text = CacheObject.课程计划.所属学科;
                    this.lblxueshi.Text = CacheObject.课程计划.总学时.ToString() + "小时";
                }));


                Console.WriteLine(planHtml);
                Success("正在打开学习页面http://spcx.ahtvu.ah.cn/frameindex/frameNetWork.aspx");
                planHtml = GET("http://spcx.ahtvu.ah.cn/frameindex/frameNetWork.aspx");
                Console.WriteLine(planHtml);
                Success("正在打开所有课程页面http://spcx.ahtvu.ah.cn/CourseStudy/AllCourse.aspx");
                var allCourceUrl = "http://spcx.ahtvu.ah.cn/CourseStudy/AllCourse.aspx";
                var allCouseHtml = GET(allCourceUrl);
                Console.WriteLine(allCouseHtml);
                xpath = "//*[@id='_ctl0_ContentPlaceHolder1_dgData']//tr";
                HtmlDoc.LoadHtml(allCouseHtml);
                trs = HtmlDoc.DocumentNode.SelectNodes(xpath);
                Success("正在解析课程");
                if (trs != null && trs.Count > 0)
                {
                    CacheObject.课程列表 = new List<课程>();
                    var index = 0;
                    foreach (HtmlAgilityPack.HtmlNode courseTr in trs)
                    {
                        if (index++ == 0)
                        {
                            continue;
                        }
                        //课程	已学课时	教师	 课程作业	课程论坛
                        var tds = courseTr.SelectNodes("./td");
                        if (tds.Count == 5)
                        {
                            var course = new 课程();
                            course.名称 = tds[0].SelectSingleNode(".//a").InnerText.Replace("\t", "").Replace("\r", "").Trim();
                            Success("正在解析课程" + course.名称);
                            course.已学习学时数 = int.Parse(tds[1].InnerText.Replace("分钟", ""));
                            course.链接地址 = tds[0].SelectSingleNode(".//a").Attributes["href"].Value;
                            course.链接地址 = new Uri(new Uri("http://spcx.ahtvu.ah.cn/CourseStudy/AllCourse.aspx"), course.链接地址).AbsoluteUri;
                            course.课程编号 = course.链接地址.Substring(course.链接地址.IndexOf("=") + 1);
                            course.教师 = tds[2].InnerText.Replace("&nbsp;", "  ");

                            Success("正在打开课程信息页面" + course.链接地址);
                            var detailHtml = GET(course.链接地址);

                            HtmlAgilityPack.HtmlDocument detailDocumnet = new HtmlAgilityPack.HtmlDocument();
                            //HtmlDoc.OptionAutoCloseOnEnd = true;
                            detailDocumnet.OptionFixNestedTags = true;
                            detailDocumnet.OptionOutputAsXml = true;
                            detailDocumnet.LoadHtml(detailHtml);
                            //detailDocumnet.DocumentNode.SelectNodes("//table")[1].SelectNodes("./tr[5]")[0].InnerText
                            var dt = detailDocumnet.DocumentNode.SelectNodes("//table")[1];

                            course.学分 = int.Parse(dt.SelectNodes("./tr[5]/td[2]")[0].InnerText);
                            course.总学时 = int.Parse(dt.SelectNodes("./tr[6]/td[2]")[0].InnerText) * 60;

                            CacheObject.课程列表.Add(course);
                            Success("解析课程" + course.名称);
                        }
                    }

                    if (CacheObject.课程列表.Count > 0)
                    {
                        Success("正在计算需要学习什么课程");

                        课程 c = null;
                        foreach (var toStudyCourse in CacheObject.课程列表)
                        {
                            if (toStudyCourse.已学习学时数 < toStudyCourse.总学时)
                            {
                                HighlightLog(toStudyCourse.名称 + "还差" + (toStudyCourse.总学时 - toStudyCourse.已学习学时数) + "分钟");

                                if (c == null)
                                {
                                    c = toStudyCourse;
                                }
                            }
                            else
                            {
                                HighlightLog(toStudyCourse.名称 + "已学习完毕,跳过学习");
                                toStudyCourse.课程状态 = "已学习完毕";
                            }
                        }

                        if (c != null)
                        {
                            Study(c);
                        }

                        UpdateGrid();
                    }

                }
            }
        }
        #region ILog 成员

        课程 当前学习的课程 { get; set; }

        System.Timers.Timer timer;

        void Study(课程 要学习的课程)
        {
            当前学习的课程 = 要学习的课程;
            当前学习的课程.课程状态 = "学习中";
            UpdateGrid();

            StartStudy();

            if (timer == null)
            {
                timer = new System.Timers.Timer();
                // 3分钟
                timer.Interval = 2 * 60 * 1000;
                timer.Elapsed += new System.Timers.ElapsedEventHandler(timer_Elapsed);
                timer.Start();
            }
        }

        private void StartStudy()
        {
            Success("开始学习" + 当前学习的课程.名称);
            Success("正在打开" + "http://spcx.ahtvu.ah.cn/CourseStudy/CourseStudy.aspx?Course=" + 当前学习的课程.课程编号 + "&Resource=Resource%2fIndex.htm");
            // 打开学习页面  将id写入cookie
            var course = GET("http://spcx.ahtvu.ah.cn/CourseStudy/CourseStudy.aspx?Course=" + 当前学习的课程.课程编号 + "&Resource=Resource%2fIndex.htm");
            Console.WriteLine(course);
            //http://spcx.ahtvu.ah.cn/ajax/Discuz.Web.CourseStudy.CourseStudy,Discuz.Web.ashx?_method=RefreshStudy&_session=r
            // 开始学习
            var alive = "http://spcx.ahtvu.ah.cn/ajax/Discuz.Web.CourseStudy.CourseStudy,Discuz.Web.ashx?_method=StartStudy&_session=r";
            //Success("正在打开" + alive);
            var html = POST(alive, "");
            Success("已开始学习" + 当前学习的课程.名称 + ",开始时间:" + html);
        }

        void timer_Elapsed(object sender, System.Timers.ElapsedEventArgs e)
        {
            RefreshStudy();
        }


        int timerIndex = 0;

        void RefreshStudy()
        {
            var refresh = "http://spcx.ahtvu.ah.cn/QueryStatManage/refresh.aspx";
            Success("正在刷新登录信息");
            var refreshData = POST(refresh, "");
            if (refreshData.Contains("OK："))
            {
                HighlightLog("刷新登录信息成功");
            }

            // 每两次刷新一次
            if (timerIndex++ % 2 == 0)
            {
                var alive = "http://spcx.ahtvu.ah.cn/ajax/Discuz.Web.CourseStudy.CourseStudy,Discuz.Web.ashx?_method=RefreshStudy&_session=r";
                Success("正在刷新课程学习时间 " + 当前学习的课程.名称);

                //Success("正在打开 " + alive);
                var html = POST(alive, "_method=RefreshStudy&_session=r");
                int minute = 0;
                if (int.TryParse(html.Replace("'", "").Trim(), out minute))
                {
                    HighlightLog(当前学习的课程.名称 + "的课程时间增加" + minute + "分钟");
                    当前学习的课程.已学习学时数 += minute;

                    // 检查是否已完成
                    CheckCourseIsFinished();

                    // 更新grid
                    UpdateGrid();
                }
                else
                {
                    HighlightLog("刷新课程学习时间失败 " + 当前学习的课程.名称);
                    HighlightLog(html);
                }
            }
        }

        private void CheckCourseIsFinished()
        {
            if (当前学习的课程.已学习学时数 > 当前学习的课程.总学时)
            {
                EndStudy();

                foreach (var toStudyCourse in CacheObject.课程列表)
                {
                    if (toStudyCourse.已学习学时数 < toStudyCourse.总学时)
                    {
                        Success(toStudyCourse.名称 + "还差" + (toStudyCourse.总学时 - toStudyCourse.已学习学时数) + "分钟，马上开始自动学习");
                        Study(toStudyCourse);
                        break;
                    }
                    else
                    {
                        Success(toStudyCourse.名称 + "已学习完毕,跳过学习");
                    }
                }
            }
        }

        private void EndStudy()
        {
            当前学习的课程.课程状态 = "已学习完毕";
            // end
            var alive = "http://spcx.ahtvu.ah.cn/ajax/Discuz.Web.CourseStudy.CourseStudy,Discuz.Web.ashx?_method=EndStudy&_session=r";
            var result = POST(alive, "");
            HighlightLog("结束学习" + 当前学习的课程.名称);
            // 清除当前课程编号
            CacheObject.Cookie = CacheObject.Cookie.Replace("CourseCode=" + 当前学习的课程.课程编号 + ";", "");
        }

        void UpdateGrid()
        {
            this.dataGridView1.BeginInvoke(new MethodInvoker(() =>
            {
                this.课程BindingSource.DataSource = CacheObject.课程列表;
                this.课程BindingSource.ResetBindings(true);
            }));
        }

        private void InsertToRichTextbox(string str, RichTextBox txtbox, Color color)
        {
            try
            {
                lock (this)
                {
                    int i = txtbox.SelectionStart;
                    txtbox.Select(i, 0);
                    txtbox.SelectionColor = color;
                    txtbox.Focus();
                    txtbox.AppendText(str + "\r\n");
                    txtbox.Select(i + str.Length + 2, 0);
                    txtbox.SelectionColor = Color.Black;
                }
            }
            catch
            {
            }
        }

        public void Info(string msg)
        {
            Log(msg, Color.Black);
        }

        public void Success(string msg)
        {
            Log(msg, Color.Green);
        }

        public void HighlightLog(string msg)
        {
            Log(msg, Color.Red);

        }

        public void Warn(string msg)
        {
            Log(msg, Color.Yellow);
        }

        public void Log(string msg, Color color)
        {
            try
            {
                this.richTextBox1.BeginInvoke(new MethodInvoker(() =>
                {
                    InsertToRichTextbox(DateTime.Now.ToString() + " " + msg + "...", this.richTextBox1, color);
                }));
            }
            catch
            {
            }
        }

        #endregion
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


        private void LearnForm_Load(object sender, EventArgs e)
        {
            if (new Form1().ShowDialog() == DialogResult.OK)
            {
                this.WindowState = FormWindowState.Maximized;
                this.lblUser.Text = CacheObject.User;
                new System.Threading.Thread(Init).Start();
            }
            else
            {
                this.Close();
            }
        }

        private void button1_Click(object sender, EventArgs e)
        {
            EndStudy();
            if (timer != null)
            {
                timer.Stop();
            }
            System.Environment.Exit(0);
        }
    }
}
