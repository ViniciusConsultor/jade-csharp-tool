using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;
using System.IO;
using HtmlAgilityPack;

namespace Jade.AHExam
{
    public partial class LearnForm : Form
    {
        public LearnForm()
        {
            InitializeComponent();
            this.dataGridView1.AutoGenerateColumns = false;
        }

        void updateCourse()
        {
            this.lblPlanName.Text = CacheObject.课程计划.名称;
            this.lblxueduan.Text = CacheObject.课程计划.所属学段;
            this.lblxueke.Text = CacheObject.课程计划.所属学科;
            this.lblxueshi.Text = CacheObject.课程计划.总学时.ToString() + "小时";
        }

        void Init()
        {
            // 选择课程
            string url = "http://spcx.ahtvu.ah.cn/NetWorkIndex/MainSelectPlan.aspx";
            Success("正在选择课程" + url);
            string allCourse = GET(url);


            //<a href="Main.aspx?id=9F87A437-A014-4B37-B17F-3FB33F2B2100&type=S">进入计划</a>
            //getCource

            string xpath = "//div[@id='myStudentTable']//tr";
            HtmlAgilityPack.HtmlDocument HtmlDoc = new HtmlAgilityPack.HtmlDocument();
            //HtmlDoc.OptionAutoCloseOnEnd = true;
            HtmlDoc.OptionFixNestedTags = true;
            HtmlDoc.OptionOutputAsXml = true;
            HtmlDoc.LoadHtml(allCourse);
            HtmlNodeCollection trs = HtmlDoc.DocumentNode.SelectNodes(xpath);
            if (trs != null && trs.Count == 2)
            {
                HtmlNode tr = trs[1];
                CacheObject.课程计划 = new 课程计划();
                //"<td>2012-2013学年度合肥市小学教师远程培训 数学</td><td></td><td>60</td><td>小学</td><td>小学数学</td><td><a href=\"Main.aspx?id=9F87A437-A014-4B37-B17F-3FB33F2B2100&amp;type=S\">进入计划</a></td>"

                CacheObject.课程计划.名称 = tr.ChildNodes[0].InnerText;
                CacheObject.课程计划.总学时 = int.Parse(tr.ChildNodes[2].InnerText);
                CacheObject.课程计划.所属学段 = tr.ChildNodes[3].InnerText;
                CacheObject.课程计划.所属学科 = tr.ChildNodes[4].InnerText;
                CacheObject.课程计划.Url = new Uri(new Uri(url), tr.ChildNodes[5].ChildNodes[0].Attributes["href"].Value).AbsoluteUri;
                Success("正在选择课程计划" + CacheObject.课程计划.Url);
                string planHtml = GET(CacheObject.课程计划.Url);
                this.lblUser.BeginInvoke(new MethodInvoker(updateCourse));


                Console.WriteLine(planHtml);
                Success("正在打开学习页面http://spcx.ahtvu.ah.cn/frameindex/frameNetWork.aspx");
                planHtml = GET("http://spcx.ahtvu.ah.cn/frameindex/frameNetWork.aspx");
                Console.WriteLine(planHtml);
                Success("正在打开所有课程页面http://spcx.ahtvu.ah.cn/CourseStudy/AllCourse.aspx");
                string allCourceUrl = "http://spcx.ahtvu.ah.cn/CourseStudy/AllCourse.aspx";
                string allCouseHtml = GET(allCourceUrl);
                Console.WriteLine(allCouseHtml);
                xpath = "//*[@id='_ctl0_ContentPlaceHolder1_dgData']//tr";
                HtmlDoc.LoadHtml(allCouseHtml);
                trs = HtmlDoc.DocumentNode.SelectNodes(xpath);
                Success("正在解析课程");
                if (trs != null && trs.Count > 0)
                {
                    CacheObject.课程列表 = new List<Course>();
                    int index = 0;
                    foreach (HtmlAgilityPack.HtmlNode courseTr in trs)
                    {
                        if (index++ == 0)
                        {
                            continue;
                        }
                        //课程	已学课时	教师	 课程作业	课程论坛
                        HtmlNodeCollection tds = courseTr.SelectNodes("./td");
                        if (tds.Count == 5)
                        {
                            Course course = new Course();
                            course.Name = tds[0].SelectSingleNode(".//a").InnerText.Replace("\t", "").Replace("\r", "").Trim();
                            Success("正在解析课程" + course.Name);
                            course.StudiedMinutes = int.Parse(tds[1].InnerText.Replace("分钟", ""));
                            course.Link = tds[0].SelectSingleNode(".//a").Attributes["href"].Value;
                            course.Link = new Uri(new Uri("http://spcx.ahtvu.ah.cn/CourseStudy/AllCourse.aspx"), course.Link).AbsoluteUri;
                            course.CouserNo = course.Link.Substring(course.Link.IndexOf("=") + 1);
                            course.Teachers = tds[2].InnerText.Replace("&nbsp;", "  ");

                            Success("正在打开课程信息页面" + course.Link);
                            string detailHtml = GET(course.Link);

                            HtmlAgilityPack.HtmlDocument detailDocumnet = new HtmlAgilityPack.HtmlDocument();
                            //HtmlDoc.OptionAutoCloseOnEnd = true;
                            detailDocumnet.OptionFixNestedTags = true;
                            detailDocumnet.OptionOutputAsXml = true;
                            detailDocumnet.LoadHtml(detailHtml);
                            //detailDocumnet.DocumentNode.SelectNodes("//table")[1].SelectNodes("./tr[5]")[0].InnerText
                            HtmlNode dt = detailDocumnet.DocumentNode.SelectNodes("//table")[1];

                            course.Score = int.Parse(dt.SelectNodes("./tr[5]/td[2]")[0].InnerText);
                            course.TotalMinutes = int.Parse(dt.SelectNodes("./tr[6]/td[2]")[0].InnerText) * 60;

                            CacheObject.课程列表.Add(course);
                            Success("解析课程" + course.Name);
                        }
                    }

                    if (CacheObject.课程列表.Count > 0)
                    {
                        Success("正在计算需要学习什么课程");

                        Course c = null;
                        foreach (Course toStudyCourse in CacheObject.课程列表)
                        {
                            if (toStudyCourse.StudiedMinutes < toStudyCourse.TotalMinutes)
                            {
                                HighlightLog(toStudyCourse.Name + "还差" + (toStudyCourse.TotalMinutes - toStudyCourse.StudiedMinutes) + "分钟");

                                if (c == null)
                                {
                                    c = toStudyCourse;
                                }
                            }
                            else
                            {
                                HighlightLog(toStudyCourse.Name + "已学习完毕,跳过学习");
                                toStudyCourse.CourseStatus = "已学习完毕";
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

        Course 当前学习的课程;

        System.Timers.Timer timer;
        bool isStudying = false;

        void Study(Course 要学习的课程)
        {
            当前学习的课程 = 要学习的课程;
            当前学习的课程.CourseStatus = "学习中";
            UpdateGrid();
            isStudying = true;
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
            Success("开始学习" + 当前学习的课程.Name);
            Success("正在打开" + "http://spcx.ahtvu.ah.cn/CourseStudy/CourseStudy.aspx?Course=" + 当前学习的课程.CouserNo + "&Resource=Resource%2fIndex.htm");
            // 打开学习页面  将id写入cookie
            string course = GET("http://spcx.ahtvu.ah.cn/CourseStudy/CourseStudy.aspx?Course=" + 当前学习的课程.CouserNo + "&Resource=Resource%2fIndex.htm");
            Console.WriteLine(course);
            //http://spcx.ahtvu.ah.cn/ajax/Discuz.Web.CourseStudy.CourseStudy,Discuz.Web.ashx?_method=RefreshStudy&_session=r
            // 开始学习
            string alive = "http://spcx.ahtvu.ah.cn/ajax/Discuz.Web.CourseStudy.CourseStudy,Discuz.Web.ashx?_method=StartStudy&_session=r";
            //Success("正在打开" + alive);
            string html = POST(alive, "");
            Success("已开始学习" + 当前学习的课程.Name + ",开始时间:" + html);
        }

        void timer_Elapsed(object sender, System.Timers.ElapsedEventArgs e)
        {
            RefreshStudy();
        }


        int timerIndex = 0;

        void RefreshStudy()
        {
            string refresh = "http://spcx.ahtvu.ah.cn/QueryStatManage/refresh.aspx";
            Success("正在刷新登录信息");
            string refreshData = POST(refresh, "");
            if (refreshData.Contains("OK："))
            {
                HighlightLog("刷新登录信息成功");
            }

            // 每两次刷新一次
            if (timerIndex++ % 2 == 0)
            {
                string alive = "http://spcx.ahtvu.ah.cn/ajax/Discuz.Web.CourseStudy.CourseStudy,Discuz.Web.ashx?_method=RefreshStudy&_session=r";
                Success("正在刷新课程学习时间 " + 当前学习的课程.Name);

                //Success("正在打开 " + alive);
                string html = POST(alive, "_method=RefreshStudy&_session=r");
                int minute = 0;
                if (int.TryParse(html.Replace("'", "").Trim(), out minute))
                {
                    HighlightLog(当前学习的课程.Name + "的课程时间增加" + minute + "分钟");
                    当前学习的课程.StudiedMinutes += minute;

                    // 检查是否已完成
                    CheckCourseIsFinished();

                    // 更新grid
                    UpdateGrid();
                }
                else
                {
                    HighlightLog("刷新课程学习时间失败 " + 当前学习的课程.Name);
                    HighlightLog(html);
                }
            }
        }

        private void CheckCourseIsFinished()
        {
            if (当前学习的课程.StudiedMinutes > 当前学习的课程.TotalMinutes)
            {
                EndStudy();

                foreach (Course toStudyCourse in CacheObject.课程列表)
                {
                    if (toStudyCourse.StudiedMinutes < toStudyCourse.TotalMinutes)
                    {
                        Success(toStudyCourse.Name + "还差" + (toStudyCourse.TotalMinutes - toStudyCourse.StudiedMinutes) + "分钟，马上开始自动学习");
                        Study(toStudyCourse);
                        break;
                    }
                    else
                    {
                        Success(toStudyCourse.Name + "已学习完毕,跳过学习");
                        timer.Stop();
                    }
                }
            }
        }

        private void EndStudy()
        {
            isStudying = false;
            当前学习的课程.CourseStatus = "已学习完毕";
            // end
            string alive = "http://spcx.ahtvu.ah.cn/ajax/Discuz.Web.CourseStudy.CourseStudy,Discuz.Web.ashx?_method=EndStudy&_session=r";
            string result = POST(alive, "");
            HighlightLog("结束学习" + 当前学习的课程.Name);
            // 清除当前课程编号
            CacheObject.Cookie = CacheObject.Cookie.Replace("CourseCode=" + 当前学习的课程.CouserNo + ";", "");
        }

        void updateGridData()
        {
            //his.dataGridView1.DataSource = CacheObject.课程列表;
            this.课程BindingSource.DataSource = CacheObject.课程列表;
            this.课程BindingSource.ResetBindings(true);
        }

        void UpdateGrid()
        {
            this.dataGridView1.BeginInvoke(new MethodInvoker(updateGridData));
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


        void log(string msg, Color color)
        {
            InsertToRichTextbox(DateTime.Now.ToString() + " " + msg + "...", this.richTextBox1, color);
        }

        delegate void _log(string msg, Color color);

        public void Log(string msg, Color color)
        {
            try
            {
                this.richTextBox1.BeginInvoke(new _log(log), msg, color);
            }
            catch
            {
            }
        }

        #endregion
        public static Stream GetStream(string url)
        {
            Jade.Http.WebClient client = new Jade.Http.WebClient();
            client.Cookie = CacheObject.Cookie;
            Stream response = client.GetStream(url);
            CacheObject.Cookie = client.Cookie;
            return response;
        }

        public static string GET(string url)
        {
            Jade.Http.WebClient client = new Jade.Http.WebClient();
            client.Cookie = CacheObject.Cookie;
            client.Encoding = Encoding.UTF8;
            string response = client.OpenRead(url);
            CacheObject.Cookie = client.Cookie;
            return response;
        }

        public static string POST(string url, string data)
        {
            Jade.Http.WebClient client = new Jade.Http.WebClient();
            client.Cookie = CacheObject.Cookie;
            client.Encoding = Encoding.UTF8;
            string response = client.OpenRead(url, data);
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
            if (isStudying)
            {
                EndStudy();
                if (timer != null)
                {
                    timer.Stop();
                }
            }
            System.Environment.Exit(0);
        }

        private void dataGridView1_CellPainting(object sender, DataGridViewCellPaintingEventArgs e)
        {
            if (e.ColumnIndex == 2 && e.RowIndex >= 0)
            {
                if (CacheObject.课程列表 != null && e.RowIndex < CacheObject.课程列表.Count)
                {

                    var course = CacheObject.课程列表[e.RowIndex];
                    if (course != null)
                    {
                        if (course.CourseStatus == "未开始学习")
                        {
                            e.CellStyle.ForeColor = Color.Black;
                        }
                        else if (course.CourseStatus == "学习中")
                        {
                            e.CellStyle.ForeColor = Color.Red;
                        }
                        else
                        {
                            e.CellStyle.ForeColor = Color.Green;
                        }
                    }
                }
            }
        }

        private void 自定义CToolStripMenuItem_Click(object sender, EventArgs e)
        {
            StartStudy();
        }

        private void 选项OToolStripMenuItem_Click(object sender, EventArgs e)
        {
            EndStudy();
        }

        private void 退出XToolStripMenuItem_Click(object sender, EventArgs e)
        {
            button1_Click(null, null);
        }

        private void LearnForm_FormClosing(object sender, FormClosingEventArgs e)
        {
            if (isStudying)
            {
                EndStudy();
                if (timer != null)
                {
                    timer.Stop();
                }
            }
            System.Environment.Exit(0);
        }
    }
}
