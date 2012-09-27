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
using System.Security.Cryptography;
using Microsoft.Win32;

namespace Jade.AHExam
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }

        string viewState = "";
        Jade.AHExam.Properties.Settings setting;
        private void Form1_Load(object sender, EventArgs e)
        {
            setting = Jade.AHExam.Properties.Settings.Default;
            this.txtUser.Text = setting.UserName;
            this.txtPassword.Text = setting.Password;

            if (this.txtUser.Text == "")
            {
                this.txtUser.Focus();
            }
            else if (this.txtPassword.Text == "")
            {
                this.txtPassword.Focus();
            }
            else
            {
                this.txtValidCode.Focus();
            }

            Microsoft.Win32.RegistryKey retkey = null;
            try
            {
                retkey = Microsoft.Win32.Registry.CurrentUser.
                             OpenSubKey("software", true).CreateSubKey("jadepeng");

            }
            catch
            {
                try
                {
                    retkey = Microsoft.Win32.Registry.CurrentUser.
                         OpenSubKey("software", true).OpenSubKey("jadepeng");

                }
                catch
                {
                }
            }


            if (retkey != null)
            {
                if (IsRegeditExit("key"))
                {
                    keycode = retkey.GetValue("key").ToString();
                }
                else
                {
                    var reg = new Reg();
                    if (reg.ShowDialog() == DialogResult.OK)
                    {
                        keycode = reg.RegCode;
                        AddKey("key", reg.RegCode);
                        this.txtUser.Text = reg.UserName;
                        this.txtPassword.Focus();
                    }
                    else
                    {
                        this.DialogResult = DialogResult.Cancel;
                        this.Close();
                    }
                }

            }
            else
            {
                MessageBox.Show("请允许读取注册表");
            }

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
            try
            {
                var stream = GetStream("http://spcx.ahtvu.ah.cn/NetWorkLogin/ValidateCode.aspx");
                this.pictureBox1.Image = Image.FromStream(stream);
            }
            catch
            {
                MessageBox.Show("加载验证码出错");
            }
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
                    DownloadValidCode();
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


        void AddKey(string key, object value)
        {
            try
            {
                string[] subkeyNames;
                RegistryKey hkml = Registry.CurrentUser;
                RegistryKey software = hkml.OpenSubKey("software", true);
                RegistryKey aimdir = software.OpenSubKey("jadepeng", true);
                aimdir.SetValue(key, value);
            }
            catch(Exception ex)
            { 
            }
        }

        private bool IsRegeditExit(string name)
        {
            bool _exit = false;
            try
            {
                string[] subkeyNames;
                RegistryKey hkml = Registry.CurrentUser;
                RegistryKey software = hkml.OpenSubKey("software", true);
                RegistryKey aimdir = software.OpenSubKey("jadepeng", true);
                subkeyNames = aimdir.GetValueNames();
                foreach (string keyName in subkeyNames)
                {
                    if (keyName == name)
                    {
                        _exit = true;
                        return _exit;
                    }
                }
            }
            catch
            { }
            return _exit;
        }
        string keycode = "";
        private void button1_Click(object sender, EventArgs e)
        {
            if (!KeyCodeHelper.IsValid(this.txtUser.Text, keycode))
            {
                MessageBox.Show("你的账号与注册码不匹配，不能登录！请先注册！");
                return;
            }

            var loginUrl = "http://spcx.ahtvu.ah.cn/MainForm/login.aspx?Platform=0";
            var response = POST(loginUrl, "__VIEWSTATE=" + System.Web.HttpUtility.UrlEncode(viewState, Encoding.UTF8) + "&TxtName=" + this.txtUser.Text + "&TxtPw=" + this.txtPassword.Text + "&TxtYzm=" + this.txtValidCode.Text + "&BtnLogin.x=23&BtnLogin.y=6");
            Console.WriteLine(response);
            if (response.IndexOf("<span style=\"font-weight:bold;\">进入</span>") > 0)
            {
                //
                setting.UserName = this.txtUser.Text;
                setting.Password = this.txtPassword.Text;
                setting.Save();

                //<span id="LblLoginName" style="font-weight:bold;">Chenxiaoyu666</span>
                var start = "<span id=\"LblLoginName\" style=\"font-weight:bold;\">";
                response = response.Substring(response.IndexOf(start) + start.Length);
                response = response.Substring(0, response.IndexOf("</span"));
                CacheObject.User = response;
                this.DialogResult = DialogResult.OK;
                this.Close();
            }
            else
            {
                MessageBox.Show("登录失败");
                DownloadValidCode();
            }
        }

        课程计划 ChosePlan = new 课程计划();

        private void pictureBox1_Click(object sender, EventArgs e)
        {
            DownloadValidCode();
        }

        private void button2_Click(object sender, EventArgs e)
        {
            this.DialogResult = DialogResult.Cancel;
        }


    }

    public class KeyCodeHelper
    {
        public static bool IsValid(string username, string keycode)
        {
            var code = username + md5(Encrypt(username, "12345678")).Replace("-", "");
            return keycode == code;
        }

        /// <summary>
        /// 进行DES加密。
        /// </summary>
        /// <param name="pToEncrypt">要加密的字符串。</param>
        /// <param name="sKey">密钥，且必须为8位。</param>
        /// <returns>以Base64格式返回的加密字符串。</returns>
        public static string Encrypt(string pToEncrypt, string sKey)
        {
            using (DESCryptoServiceProvider des = new DESCryptoServiceProvider())
            {
                byte[] inputByteArray = Encoding.UTF8.GetBytes(pToEncrypt);
                des.Key = ASCIIEncoding.ASCII.GetBytes(sKey);
                des.IV = ASCIIEncoding.ASCII.GetBytes(sKey);
                System.IO.MemoryStream ms = new System.IO.MemoryStream();
                using (CryptoStream cs = new CryptoStream(ms, des.CreateEncryptor(), CryptoStreamMode.Write))
                {
                    cs.Write(inputByteArray, 0, inputByteArray.Length);
                    cs.FlushFinalBlock();
                    cs.Close();
                }
                string str = Convert.ToBase64String(ms.ToArray());
                ms.Close();
                return str;
            }
        }

        /// <summary>
        /// 进行DES解密。
        /// </summary>
        /// <param name="pToDecrypt">要解密的以Base64</param>
        /// <param name="sKey">密钥，且必须为8位。</param>
        /// <returns>已解密的字符串。</returns>
        public static string Decrypt(string pToDecrypt, string sKey)
        {
            byte[] inputByteArray = Convert.FromBase64String(pToDecrypt);
            using (DESCryptoServiceProvider des = new DESCryptoServiceProvider())
            {
                des.Key = ASCIIEncoding.ASCII.GetBytes(sKey);
                des.IV = ASCIIEncoding.ASCII.GetBytes(sKey);
                System.IO.MemoryStream ms = new System.IO.MemoryStream();
                using (CryptoStream cs = new CryptoStream(ms, des.CreateDecryptor(), CryptoStreamMode.Write))
                {
                    cs.Write(inputByteArray, 0, inputByteArray.Length);
                    cs.FlushFinalBlock();
                    cs.Close();
                }
                string str = Encoding.UTF8.GetString(ms.ToArray());
                ms.Close();
                return str;
            }
        }
        public static string md5(string str)
        {
            MD5 m = new MD5CryptoServiceProvider();
            byte[] s = m.ComputeHash(UnicodeEncoding.UTF8.GetBytes(str));
            return BitConverter.ToString(s);
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
