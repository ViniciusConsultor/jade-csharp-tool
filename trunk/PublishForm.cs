using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;
using DevExpress.XtraEditors;

namespace Jade
{
    public partial class PublishForm : DevExpress.XtraEditors.XtraForm
    {
        Model.IDownloadData currentDownloadData;
        public PublishForm(Model.IDownloadData download)
        {
            currentDownloadData = download;
            InitializeComponent();
            this.baseWebBrowser1.DocumentCompleted += new WebBrowserDocumentCompletedEventHandler(baseWebBrowser1_DocumentCompleted);
        }

        string CurrentUri = "";

        bool isLoading = false;

        void baseWebBrowser1_DocumentCompleted(object sender, WebBrowserDocumentCompletedEventArgs e)
        {
            if (e.Url.AbsoluteUri == CurrentUri)
            {
                isLoading = false;
            }
        }


        public void UploadImage()
        {
            CurrentUri = "http://newscms.house365.com/newCMS/news/addpic.php?parent_channel_id=8000000&bjq=";
            isLoading = true;
            this.baseWebBrowser1.Navigate("http://newscms.house365.com/newCMS/news/addpic.php?parent_channel_id=8000000&bjq=");
            while (isLoading)
            {
                Application.DoEvents();
            }
            var inputs = this.baseWebBrowser1.Document.GetElementsByTagName("input");
            foreach (HtmlElement input in inputs)
            {
                if (input.Name == "filename")
                {
                    break;
                }
            }

        }


    }
}