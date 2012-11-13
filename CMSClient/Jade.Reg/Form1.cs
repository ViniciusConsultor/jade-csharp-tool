using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;
using System.Security.Cryptography;

namespace Jade.Reg
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            var code = KeyCodeHelper.GetCode(this.textBox2.Text);
            this.textBox1.Text = code;
            Clipboard.SetText(code);
            MessageBox.Show("生成成功");
        }

        public class KeyCodeHelper
        {
            public static string  GetCode(string username)
            {
                return username + md5(Encrypt(username, "12345678")).Replace("-", "");
            }

            public static bool IsValid(string username, string keycode)
            {
                string code = username + md5(Encrypt(username, "12345678")).Replace("-", "");
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
    }
}
