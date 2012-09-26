using System;
using System.Collections.Generic;
using System.Windows.Forms;

namespace Jade.AHExam
{
    static class Program
    {
        /// <summary>
        /// 应用程序的主入口点。
        /// </summary>
        [STAThread]
        static void Main()
        {
            Application.EnableVisualStyles();
            Application.SetCompatibleTextRenderingDefault(false);
            Application.Run(new LearnForm());
        }
    }

    public class CacheObject
    {
        public static string Cookie { get; set; }

        public static List<课程> 课程列表 { get; set; }

        public static 课程计划 课程计划 { get; set; }
    }
}
