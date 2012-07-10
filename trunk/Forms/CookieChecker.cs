using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;

namespace HFBBS
{
    public partial class CookieChecker : Form
    {
        public CookieChecker()
        {
            InitializeComponent();
        }

        public CookieChecker(string url) 
        {
            InitializeComponent();
            this.tbxUrl.Text = url;
        }

        public string CookieValue
        {
            get
            {
                return tbxCookie.Text;
            }
        }

        private void btnSend_Click(object sender, EventArgs e)
        {
            Uri uri;
            if(Uri.TryCreate(this.tbxUrl.Text, UriKind.Absolute, out uri))
                this.wbbMain.Url = uri;
        }

        private void btnCookieOk_Click(object sender, EventArgs e)
        {
            this.DialogResult = DialogResult.OK;
            this.Close();
        }

        private void wbbMain_DocumentCompleted(object sender, WebBrowserDocumentCompletedEventArgs e)
        {
            this.tbxCookie.Text = this.wbbMain.Document.Cookie;
        }
    }
}