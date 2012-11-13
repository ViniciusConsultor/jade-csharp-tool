using System;
using System.Runtime.InteropServices;
using System.Text;
using System.Net;
using System.Net.Sockets;
using System.Threading;


namespace Jade.CQA.Robot
{
    public class ADSL
    {
        [DllImport("wininet.dll")]
        private extern static bool InternetAutodial(int dwFlags, System.IntPtr hwndParent);
        [DllImport("wininet.dll")]
        private extern static bool InternetAutodialHangup(int dwReserved);

        public static string ResetNetwork()
        {
            InternetAutodialHangup(0);
            Console.WriteLine("断开中，请稍后。。。");
            // 连接默认网络
            Thread.Sleep(5000);
            Console.WriteLine("连接中，请稍后。。。");
            InternetAutodial(1, IntPtr.Zero);

            IPAddress[] arrIPAddresses = Dns.GetHostAddresses(Dns.GetHostName());
            foreach (IPAddress ip in arrIPAddresses)
            {
                if (ip.AddressFamily.Equals(AddressFamily.InterNetwork))
                {
                    return ip.ToString();
                }
            }
            return "127.0.0.1";
        }
    }
}
