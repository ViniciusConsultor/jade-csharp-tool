using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;
using System.Text.RegularExpressions;

namespace HFBBS
{
    public partial class SourceGetter : Form
    {
        public SourceGetter()
        {
            InitializeComponent();
            BuildEncodingList();
        }

        public SourceGetter(string url)
        {
            InitializeComponent();
            BuildEncodingList();
            this.tbxUrl.Text = url;
        }

        private void BuildEncodingList()
        {
            this.cbbEncoding.Items.AddRange(EncodingUIBuilder.EncodingList.ToArray());
            if (cbbEncoding.Items.Count > 0)
            {
                cbbEncoding.SelectedIndex = 0;
            }
        }

        #region Event UI Method
        private void rdbGet_CheckedChanged(object sender, EventArgs e)
        {
            if (rdbGet.Checked)
            {
                this.tbxPostData.Enabled = false;
            }
        }

        private void rdbPost_CheckedChanged(object sender, EventArgs e)
        {
            if (rdbPost.Checked)
            {
                this.tbxPostData.Enabled = true;
            }
        }
        #endregion

        private void btnSend_Click(object sender, EventArgs e)
        {
            if (string.IsNullOrEmpty(this.tbxUrl.Text))
            {
                return;
            }

            Uri uri;
            if (!Uri.TryCreate(this.tbxUrl.Text, UriKind.Absolute, out uri))
            {
                return;
            }

            var html = HtmlPicker.VisitUrl(
                                     uri,
                                     rdbGet.Checked ? "GET" : "POST",
                                     null,
                                      string.IsNullOrEmpty(this.tbxReferer.Text) ? null : this.tbxReferer.Text,
                                     string.IsNullOrEmpty(this.tbxCookie.Text) ? null : Utility.GetCookies(this.tbxCookie.Text),
                                     string.IsNullOrEmpty(this.tbxUserAgent.Text) ? null : this.tbxUserAgent.Text,
                                     string.IsNullOrEmpty(this.tbxPostData.Text) ? null : this.tbxPostData.Text,
                                     System.Text.Encoding.GetEncoding((string)this.cbbEncoding.SelectedItem));

            SetHtml(html);

            return;

            //NiceWebClient webClient = new NiceWebClient();

            //if (!string.IsNullOrEmpty(this.tbxReferer.Text))
            //    webClient.Referer = this.tbxReferer.Text;

            //if (!string.IsNullOrEmpty(this.tbxCookie.Text))
            //    webClient.Cookie = this.tbxCookie.Text;

            //if (!string.IsNullOrEmpty(this.tbxUserAgent.Text))
            //    webClient.UserAgent = this.tbxUserAgent.Text;

            //webClient.Encoding = System.Text.Encoding.GetEncoding((string)this.cbbEncoding.SelectedItem);


            //if (rdbGet.Checked)
            //{
            //    //Get
            //    webClient.DownloadStringCompleted += new System.Net.DownloadStringCompletedEventHandler(webClient_DownloadStringCompleted);
            //    webClient.DownloadProgressChanged += new System.Net.DownloadProgressChangedEventHandler(webClient_DownloadProgressChanged);
            //    webClient.DownloadStringAsync(uri);
            //}
            //else
            //{
            //    //Post
            //    webClient.UploadStringCompleted += new System.Net.UploadStringCompletedEventHandler(webClient_UploadStringCompleted);
            //    webClient.UploadProgressChanged += new System.Net.UploadProgressChangedEventHandler(webClient_UploadProgressChanged);
            //    webClient.UploadStringAsync(uri, null, this.tbxPostData.Text);
            //}
            SetMessage("Doing");
        }

        void webClient_UploadProgressChanged(object sender, System.Net.UploadProgressChangedEventArgs e)
        {
            SetStatus(e.ProgressPercentage);
        }

        void webClient_DownloadProgressChanged(object sender, System.Net.DownloadProgressChangedEventArgs e)
        {
            SetStatus(e.ProgressPercentage);
        }

        void webClient_UploadStringCompleted(object sender, System.Net.UploadStringCompletedEventArgs e)
        {
            if (e.Error != null)
            {
                SetMessage("¥ÌŒÛ");
                SetStatus(0);
                return;
            }
            SetHtml(e.Result);
            SetMessage("ø’œ–");
        }

        void webClient_DownloadStringCompleted(object sender, System.Net.DownloadStringCompletedEventArgs e)
        {
            if (e.Error != null)
            {
                SetMessage("¥ÌŒÛ");
                SetStatus(0);
                return;
            }
            SetHtml(e.Result);
            SetMessage("ø’œ–");
        }

        private void SetHtml(string html)
        {
            if (!string.IsNullOrEmpty(html))
            {
                this.tbxHtml.Text = html;
                this.textBox1.Text = removeTags(html);
            }
        }

        private void SetStatus(int value)
        {
            this.psbStatus.Value = value;
        }

        private void SetMessage(string message)
        {
            this.lblStatus.Text = message;
        }

        private string removeTags(string textBody)
        {
            string docType = @"(?is)<!DOCTYPE.*?>";
            string comment = @"(?is)<!--.*?-->";
            string js = @"(?is)<script.*?>.*?</script>";
            string css = @"(?is)<style.*?>.*?</style>";
            string specialChar = @"&.{2,8};|&#.{2,8};";
            string otherTag = @"(?is)<.*?>";

            textBody = Regex.Replace(textBody, docType, "");
            textBody = Regex.Replace(textBody, comment, "");
            textBody = Regex.Replace(textBody, js, "");
            textBody = Regex.Replace(textBody, css, "");
            textBody = Regex.Replace(textBody, specialChar, "");
            textBody = Regex.Replace(textBody, otherTag, "");
            return textBody;
        }

        private void SourceGetter_Load(object sender, EventArgs e)
        {
          
        }

        private void button2_Click(object sender, EventArgs e)
        {
            this.DialogResult = System.Windows.Forms.DialogResult.Cancel;
            this.Close();
        }

        private void tbxHtml_MouseUp(object sender, MouseEventArgs e)
        {
            this.label2.Text = this.tbxHtml.SelectedText;
        }

        public string SelectText
        {
            get
            {
                return this.tbxHtml.SelectedText;
            }
        }

        private void button1_Click(object sender, EventArgs e)
        {
            this.DialogResult = System.Windows.Forms.DialogResult.OK;
            this.Close();
        }
    }
}