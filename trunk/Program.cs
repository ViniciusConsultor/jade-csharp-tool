using System;
using System.Collections.Generic;
using System.Linq;
using System.Windows.Forms;
using DevExpress.XtraSplashScreen;

namespace Jade
{
    static class Program
    {
        /// <summary>
        /// The main entry point for the application.
        /// </summary>
        [STAThread]
        static void Main()
        {

            //            var post = "actions=mod&rank=null&refer_channel_id=12000000&news_source_name_1=%CF%E3%B8%DB%CE%C4%BB%E3%B1%A8&news_source_name=%CF%E3%B8%DB%CE%C4%BB%E3%B1%A8&make_topic_more_link=1&news_template_file_1=%2Fhfccbbs%2Ftemplate%2Fbbsestate.htm&news_template_file_bak=%2Fhfccbbs%2Ftemplate%2Fbbsestate.htm&news_channel_id=0&news_template_file=&news_title=20%B6%E0%CB%EA%C4%D0%D7%D3%C1%AC%D0%F8%C9%CF%CD%F8%BD%FC30%D0%A1%CA%B1++%D4%CE%B5%B9%D7%A1%D4%BA&news_type=1&news_type=1&news_keywords=%CD%F8%B0%C9%7C%B0%FC%D2%B9&news_keywords2=%CD%F8%B0%C9%23%B0%FC%D2%B9&news_sub_title=&label_id%5B%5D=12000000&label_id%5B%5D=12010000&label_id%5B%5D=12010400&label_id%5B%5D=12010500&comboText=&cmspinglun=1&bbspinglun_title=&bbspinglun_url=&kfbm_id=&kfbm_link=&gfbm_id=&gfbm_link=&viewediter=&news_content=%3Cp+style%3D%22text-indent%3A+28px%3B%22%3E%B0%B2%BB%D5%CD%F8%D1%B6%26nbsp%3B%26nbsp%3B%BD%F1%CC%EC%CF%C2%CE%E73%B5%E3%D7%F3%D3%D2%A3%AC%D2%BB20%B6%E0%CB%EA%C4%D0%D7%D3%D4%DA%CD%F8%B0%C9%C1%AC%D0%F8%C9%CF%CD%F8%BD%FC30%D0%A1%CA%B1%BA%F3%D4%CE%B5%B9%A1%A3%BE%DD%C1%CB%BD%E2%A3%AC%B8%C3%C4%D0%D7%D3%D2%D1%BE%AD%B9%A4%D7%F7%A3%AC%B3%C3%D7%C5%CB%AB%D0%DD%C8%D5%B5%BD%CD%F8%B0%C9%B0%FC%D2%B9%A3%AC%C4%BF%C7%B0%D5%FD%D4%DA%BA%CF%B7%CA%CA%D0%C8%FD%D4%BA%D7%A1%D4%BA%D6%CE%C1%C6%A1%A3%3C%2Fp%3E%0D%0A%3Cp+style%3D%22text-indent%3A+28px%3B%22%3E%D0%C2%B0%B2%CD%ED%B1%A8%A1%A2%B0%B2%BB%D5%CD%F8%BC%C7%D5%DF%26nbsp%3B%D1%EE%BF%A1%3C%2Fp%3E&news_abs=&news_top=&news_guideimage=&news_guideimage2=&news_abstract=%BA%CB%D0%C4%CC%E1%CA%BE%A3%BA%BD%F1%CC%EC%CF%C2%CE%E73%B5%E3%D7%F3%D3%D2%A3%AC%D2%BB20%B6%E0%CB%EA%C4%D0%D7%D3%D4%DA%CD%F8%B0%C9%C1%AC%D0%F8%C9%CF%CD%F8%BD%FC30%D0%A1%CA%B1%BA%F3%D4%CE%B5%B9%A1%A3%BE%DD%C1%CB%BD%E2%A3%AC%B8%C3%C4%D0%D7%D3%D2%D1%BE%AD%B9%A4%D7%F7%A3%AC%B3%C3%D7%C5%CB%AB%D0%DD%C8%D5%B5%BD%CD%F8%B0%C9%B0%FC%D2%B9%A1%A3%C4%BF%C7%B0%D5%FD%D4%DA%BA%CF%B7%CA%CA%D0%C8%FD%D4%BA%D7%A1%D4%BA%D6%CE%C1%C6%A1%A3&news_description=edrr&news_link=&news_down=&news_left=&news_right=&comment_url=&news_video=&news_id=020734862&tag2cd=100010000000&plat=edit&news_type_id=1&request_channel_id=&save.x=50&save.y=29\0";

            //            var postDatas = post.Split('&');
            //            var Dict = new Dictionary<string, string>();
            //            foreach (var postData in postDatas)
            //            {
            //                var dicItems = postData.Split(new char[] { '=' }, 2);
            //                if (!Dict.ContainsKey(dicItems[0]))
            //                {
            //                    Dict.Add(dicItems[0], dicItems[1]);
            //                }
            //            }

            //            post = 
            //"actions=mod&rank=null&refer_channel_id=12000000&news_source_name_1=%cf%e3%b8%db%ce%c4%bb%e3%b1%a8&news_source_name=%cf%e3%b8%db%ce%c4%bb%e3%b1%a8&make_topic_more_link=1&news_template_file_1=%2fhfccbbs%2ftemplate%2fbbsestate.htm&news_template_file_bak=%2fhfccbbs%2ftemplate%2fbbsestate.htm&news_channel_id=0&news_template_file=&news_title=20%b6%e0%cb%ea%c4%d0%d7%d3%c1%ac%d0%f8%c9%cf%cd%f8%bd%fc30%d0%a1%ca%b1++%d4%ce%b5%b9%d7%a1%d4%ba&news_type=1&news_type=1&news_keywords=%cd%f8%b0%c9+%7c%b0%fc%d2%b9&news_keywords2=%cd%f8%b0%c9%23%b0%fc%d2%b9&news_sub_title=&label_id%5b%5d=12020500&label_id%5b%5d=12010500&comboText=&label_id%5B%5D=12000000&label_id%5B%5D=12010000&label_id%5B%5D=12010400&label_id%5B%5D=12010500&comboText=&cmspinglun=0&bbspinglun_title=&bbspinglun_url=&kfbm_id=&kfbm_link=&gfbm_id=&gfbm_link=&viewediter=&news_content=%3cP%3e%b0%b2%bb%d5%cd%f8%d1%b6%26nbsp%3b%26nbsp%3b%bd%f1%cc%ec%cf%c2%ce%e73%b5%e3%d7%f3%d3%d2%a3%ac%d2%bb20%b6%e0%cb%ea%c4%d0%d7%d3%d4%da%cd%f8%b0%c9%c1%ac%d0%f8%c9%cf%cd%f8%bd%fc30%d0%a1%ca%b1%ba%f3%d4%ce%b5%b9%a1%a3%be%dd%c1%cb%bd%e2%a3%ac%b8%c3%c4%d0%d7%d3%d2%d1%be%ad%b9%a4%d7%f7%a3%ac%b3%c3%d7%c5%cb%ab%d0%dd%c8%d5%b5%bd%cd%f8%b0%c9%b0%fc%d2%b9%a3%ac%c4%bf%c7%b0%d5%fd%d4%da%ba%cf%b7%ca%ca%d0%c8%fd%d4%ba%d7%a1%d4%ba%d6%ce%c1%c6%a1%a3%3cBR%3e%0d%0a%3cP%3e%d0%c2%b0%b2%cd%ed%b1%a8%a1%a2%b0%b2%bb%d5%cd%f8%bc%c7%d5%df%26nbsp%3b%d1%ee%bf%a1%3c%2fP%3e&news_abs=&news_top=&news_guideimage=&news_guideimage2=&news_abstract=%ba%cb%d0%c4%cc%e1%ca%be%a3%ba%bd%f1%cc%ec%cf%c2%ce%e73%b5%e3%d7%f3%d3%d2%a3%ac%d2%bb20%b6%e0%cb%ea%c4%d0%d7%d3%d4%da%cd%f8%b0%c9%c1%ac%d0%f8%c9%cf%cd%f8%bd%fc30%d0%a1%ca%b1%ba%f3%d4%ce%b5%b9%a1%a3%be%dd%c1%cb%bd%e2%a3%ac%b8%c3%c4%d0%d7%d3%d2%d1%be%ad%b9%a4%d7%f7%a3%ac%b3%c3%d7%c5%cb%ab%d0%dd%c8%d5%b5%bd%cd%f8%b0%c9%b0%fc%d2%b9%a1%a3%c4%bf%c7%b0%d5%fd%d4%da%ba%cf%b7%ca%ca%d0%c8%fd%d4%ba%d7%a1%d4%ba%d6%ce%c1%c6%a1%a3&news_description=edrr&news_link=&news_down=&news_left=&news_right=&comment_url=&news_video=&news_id=020734862&tag2cd=&plat=&news_type_id=1&request_channel_id=&save.x=70&save.y=32\0";
            //            postDatas = post.Split('&');
            //            var dict2 = new Dictionary<string, string>();
            //            foreach (var postData in postDatas)
            //            {
            //                var dicItems = postData.Split(new char[] { '=' }, 2);
            //                if (!dict2.ContainsKey(dicItems[0]))
            //                {
            //                    dict2.Add(dicItems[0], dicItems[1]);
            //                }
            //            }

            //            foreach (var pair in Dict)
            //            {
            //                if (!dict2.ContainsKey(pair.Key))
            //                {
            //                    Console.Write(pair.Key);
            //                }
            //                else
            //                {
            //                    dict2.Remove(pair.Key);
            //                }
            //            }


            Application.SetUnhandledExceptionMode(UnhandledExceptionMode.CatchException);
            //处理UI线程异常 
            Application.ThreadException += new System.Threading.ThreadExceptionEventHandler(Application_ThreadException);
            //处理非UI线程异常 
            AppDomain.CurrentDomain.UnhandledException += new UnhandledExceptionEventHandler(CurrentDomain_UnhandledException);

            try
            {
                SplashScreenManager.ShowForm(typeof(StartScreen));
            }
            catch (Exception innerEx)
            {
                LogUnhandledException(innerEx);
            }
            Application.EnableVisualStyles();
            Application.SetCompatibleTextRenderingDefault(false);
            Application.Run(new MainForm());

        }

        static void CurrentDomain_UnhandledException(object sender, UnhandledExceptionEventArgs e)
        {
            LogUnhandledException(e.ExceptionObject);
        }

        static void Application_ThreadException(object sender, System.Threading.ThreadExceptionEventArgs e)
        {
            LogUnhandledException(e.Exception);
        }

        static void LogUnhandledException(object exceptionobj)
        {
            Exception ex = exceptionobj as Exception;
            Log4Log.Exception(ex);
            Log4Log.Close();
            //MessageBox.Show(ex.Message);
            //MessageBox.Show(ex.StackTrace);
            //if (ex.InnerException != null)
            //    MessageBox.Show(ex.InnerException.Message);
            new ExceptionForm(ex).ShowDialog();
        }
    }
}
