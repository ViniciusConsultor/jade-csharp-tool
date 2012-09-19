using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Drawing;
using System.Data;
using System.Text;
using System.Windows.Forms;
using DevExpress.XtraEditors;
using Jade.Model;

namespace Jade.ConfigTool
{
    public partial class UrlSelectorMarker : DevExpress.XtraEditors.XtraUserControl
    {

        UrlSelectorPanel panel;
        UrlSelector currentUrlSelector;

        public UrlSelector CurrentUrlSelector
        {
            get
            {
                UpdateUrlSelector();
                return currentUrlSelector;
            }
            set
            {
                currentUrlSelector = value;
                Init();
            }
        }

        public void UpdateUrlSelector()
        {
            urlSelectorPanel1.UpdateUrlSelector();
            urlSelectorPanel2.UpdateUrlSelector();
        }

        void Init()
        {
            if (currentUrlSelector != null)
            {
                this.urlSelectorPanel1.CurrentUrlSelector = currentUrlSelector;
                if (currentUrlSelector.ContentPageUrlSelector == null)
                {
                    currentUrlSelector.ContentPageUrlSelector = new UrlSelector();
                }
                if (currentUrlSelector.ContentPageUrlSelector == null)
                {
                    currentUrlSelector.ContentPageUrlSelector = new UrlSelector();
                }
                this.urlSelectorPanel2.CurrentUrlSelector = currentUrlSelector.ContentPageUrlSelector;
            }
        }

        public UrlSelectorMarker()
        {
            InitializeComponent();
            panel = urlSelectorPanel1;
        }

        public event EventHandler OnXpathSelectorClick;

        public event EventHandler OnTestClick;

        /// <summary>
        /// 选择URL
        /// </summary>
        public event EventHandler OnSelectUrlClick;

        /// <summary>
        /// 选择URL完毕
        /// </summary>
        /// <param name="url"></param>
        public void SelectUrlClickFinish(string url)
        {
            //string[] urls = new string[this.lbxUrls.Items.Count];
            //this.lbxUrls.Items.CopyTo(urls, 0);
            //var list = new List<string>();
            //list.AddRange(urls);
            //if (!list.Contains(url))
            panel.SelectUrlClickFinish(url);
        }

        /// <summary>
        /// 当前XMLPathType
        /// </summary>
        public XMLPathType CurrentXMLPathType
        {
            get
            {
                return panel.CurrentXMLPathType;
            }
        }

        /// <summary>
        /// 当前XMLPathSelectType
        /// </summary>
        public XMLPathSelectType CurrentXMLPathSelectType
        {
            get
            {
                return panel.CurrentXMLPathSelectType;
            }
        }

        /// <summary>
        /// 设置结果
        /// </summary>
        /// <param name="datas"></param>
        public void SetUrlResult(List<string> datas)
        {
            panel.SetUrlResult(datas);
        }

        bool onlyShowList = false;
        public bool OnlyShowList
        {
            get
            {
                return onlyShowList;
            }
            set
            {
                onlyShowList = value;

                if (onlyShowList)
                {
                    this.contentTab.Hide();
                }
            }
        }

        /// <summary>
        /// 设置XPath
        /// </summary>
        /// <param name="xpath"></param>
        public void SetXPath(string xpath)
        {
            panel.SetXPath(xpath);
        }

        public void SetTipMessage(string msg)
        {
            panel.SetTipMessage(msg);
        }

        public string TipMessage
        {
            set
            {
                SetTipMessage(value);
            }
        }

        private void urlSelectorPanel1_OnTestClick(object sender, EventArgs e)
        {
            if (OnTestClick != null)
            {
                OnTestClick(sender, e);
            }
        }

        private void urlSelectorPanel1_OnXpathSelectorClick(object sender, EventArgs e)
        {
            if (OnXpathSelectorClick != null)
            {
                OnXpathSelectorClick(sender, e);
            }
        }

        private void xtraTabControl1_SelectedPageChanged(object sender, DevExpress.XtraTab.TabPageChangedEventArgs e)
        {
            if (this.xtraTabControl1.SelectedTabPageIndex == 0)
            {
                panel = urlSelectorPanel1;
            }
            else
            {
                panel = urlSelectorPanel2;
            }
        }

        public string Xpath
        {
            get
            {
                return panel.Xpath;
            }
            set
            {
                panel.SetXPath(value);
            }
        }

        private void urlSelectorPanel1_OnSelectUrlClick(object sender, EventArgs e)
        {
            if (OnSelectUrlClick != null)
            {
                OnSelectUrlClick(sender, e);
            }
        }
    }
}
