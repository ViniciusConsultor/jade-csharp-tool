using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;
using System.IO;
using System.Xml;
using HFBBS.Forms;
using HFBBS.Model;

namespace HFBBS
{
    public partial class URLBuilder : Form
    {
        #region Initialize
        public URLBuilder()
        {
            InitializeComponent();
        }
        #endregion

        #region Single
        private void btnSingleAdd_Click(object sender, EventArgs e)
        {
            string[] urls = this.tbxSingleUrl.Text.Split(new string[] { "\r\n" }, StringSplitOptions.RemoveEmptyEntries);
            if (urls == null || urls.Length == 0) return;
            foreach (string url in urls)
            {
                this.lbxFinishedUrl.Items.Add(url);
            }
        }

        private void tmiDeleteUrl_Click(object sender, EventArgs e)
        {
            this.lbxFinishedUrl.Items.Remove(this.lbxFinishedUrl.SelectedItem);
        }

        private void tmiCleanUrl_Click(object sender, EventArgs e)
        {
            this.lbxFinishedUrl.Items.Clear();
        }
        #endregion

        #region Multi
        private const string UrlSymbolicHolder = "[*]";

        private void lblMultiAddSymblic_Click(object sender, EventArgs e)
        {
            this.tbxMultiUrl.Text += UrlSymbolicHolder;
        }

        private void btnMultiPreview_Click(object sender, EventArgs e)
        {
            if (!CheckUrlSymbolicHolder()) return;

            this.tbxMultiUrlPreview.Clear();

            List<string> urls = ExtractUrl.ParseUrlFromParameter(
                                                this.tbxMultiUrl.Text,
                                                UrlSymbolicHolder,
                                                this.nudMultiSymbolicStart.Value,
                                                this.nudMultiSymbolicEnd.Value,
                                                this.nudMultiSymbolicIncrement.Value,
                                                this.cbxMultiAddZero.Checked,
                                                this.cbxMultiDesc.Checked);

            foreach (string url in urls)
            {
                this.tbxMultiUrlPreview.Text += url + "\r\n";
            }
        }

        private void btnMultiAdd_Click(object sender, EventArgs e)
        {
            if (!CheckUrlSymbolicHolder()) return;

            this.lbxFinishedUrl.Items.Add(
                this.tbxMultiUrl.Text.Replace(
                    UrlSymbolicHolder,
                    string.Format("<{0},{1},{2},{3},{4}>",
                                           this.nudMultiSymbolicStart.Value,
                                           this.nudMultiSymbolicEnd.Value,
                                           this.nudMultiSymbolicIncrement.Value,
                                           this.cbxMultiAddZero.Checked,
                                           this.cbxMultiDesc.Checked)
                    )
            );
        }

        private bool CheckUrlSymbolicHolder()
        {
            if (this.nudMultiSymbolicStart.Value > this.nudMultiSymbolicEnd.Value)
            {
                MessageBox.Show(this, "通配符结束值应小于开始值！", "通配符设置错误", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return false;
            }
            if (this.tbxMultiUrl.Text.IndexOf(UrlSymbolicHolder) == -1)
            {
                MessageBox.Show(this, "请添加通配符！", "通配符设置错误", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return false;
            }
            return true;
        }
        #endregion

        #region From Txt
        private void btnFromTxtBrowseFile_Click(object sender, EventArgs e)
        {
            OpenFileDialog dialog = new OpenFileDialog();
            dialog.Filter = "URL地址列表文件 [*.txt]|*.txt";
            if (dialog.ShowDialog() == DialogResult.OK)
            {
                this.tbxFromTxtFile.Text = dialog.FileName;
            }
        }

        private void btnFromTxtPreviewFile_Click(object sender, EventArgs e)
        {
            if (!CheckUrlFilePath()) return;
            StreamReader reader = new StreamReader(this.tbxFromTxtFile.Text);
            while (!reader.EndOfStream)
            {
                this.tbxFromTextUrlPreview.Text += reader.ReadLine() + "\r\n";
            }
            reader.Close();
        }

        private void btnFromTxtAdd_Click(object sender, EventArgs e)
        {
            if (!CheckUrlFilePath()) return;
            StreamReader reader = new StreamReader(this.tbxFromTxtFile.Text);
            while (!reader.EndOfStream)
            {
                this.lbxFinishedUrl.Items.Add(reader.ReadLine());
            }
            reader.Close();
        }

        private bool CheckUrlFilePath()
        {
            if (string.IsNullOrEmpty(this.tbxFromTxtFile.Text)
               || !File.Exists(this.tbxFromTxtFile.Text))
            {
                MessageBox.Show(this, "URL地址列表文件错误！", "文件错误", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return false;
            }
            return true;
        }
        #endregion

        #region Url List
        public string[] FinishedUrls
        {
            get
            {
                string[] urls = new string[this.lbxFinishedUrl.Items.Count];
                this.lbxFinishedUrl.Items.CopyTo(urls, 0);
                return urls;
            }
            set
            {
                this.lbxFinishedUrl.Items.Clear();
                this.lbxFinishedUrl.Items.AddRange(value);
            }
        }
        #endregion

        #region Button Event
        private void btnFinish_Click(object sender, EventArgs e)
        {
            this.DialogResult = DialogResult.OK;
            this.Close();
        }
        private void lbxFinishedUrl_DoubleClick(object sender, EventArgs e)
        {
            if (this.lbxFinishedUrl.Items == null
                || this.lbxFinishedUrl.Items.Count == 0
                || this.lbxFinishedUrl.SelectedItem == null)
            {
                return;
            }

            if (this.tabURLBuilder.SelectedIndex == 0)
                this.tbxSingleUrl.Text = (string)this.lbxFinishedUrl.SelectedItem;
            else if (this.tabURLBuilder.SelectedIndex == 1)
                this.tbxMultiUrl.Text = (string)this.lbxFinishedUrl.SelectedItem;
        }
        #endregion

        private void button1_Click(object sender, EventArgs e)
        {
            var sinaopenml = this.textBox2.Text;
            XmlDocument doc = new XmlDocument();
            doc.Load(sinaopenml);

            var outlines = doc.SelectNodes("opml/body/outline/outline");
            foreach (XmlNode node in outlines)
            {
                var url = node.Attributes["xmlUrl"].Value;
                this.textBox1.AppendText(url + "\r\n");
            }
        }

        private void button2_Click(object sender, EventArgs e)
        {
            try
            {
                var sinaopenml = this.textBox2.Text;
                XmlDocument doc = new XmlDocument();
                doc.Load(sinaopenml);

                var outlines = doc.SelectNodes("opml/body/outline/outline");
                foreach (XmlNode node in outlines)
                {
                    var url = node.Attributes["xmlUrl"].Value;
                    this.lbxFinishedUrl.Items.Add(url);
                }
            }
            catch
            {
            }
        }

        private void button4_Click(object sender, EventArgs e)
        {
            var url = this.txtStartUrl.Text != "" ? this.txtStartUrl.Text : "http://www.hefei.cc";
            var path = "//a";
            HFBBS.Forms.XmlPathSelector xpath = new XmlPathSelector(url, path, XMLPathType.Href, XMLPathSelectType.Multiple);
            if (xpath.ShowDialog() == DialogResult.OK)
            {
                if (this.txtStartUrl.Text != "")
                {
                    this.txtXPathList.Text = this.txtStartUrl.Text;
                }
                this.txtXPathList.AppendText("\r\n");
                if (xpath.Datas.Count > 0)
                {
                    foreach (var data in xpath.Datas)
                    {
                        this.txtXPathList.AppendText(data + "\r\n");
                    }
                }
            }
        }

        private void button3_Click(object sender, EventArgs e)
        {
            string[] urls = this.txtXPathList.Text.Split(new string[] { "\r\n" }, StringSplitOptions.RemoveEmptyEntries);
            if (urls == null || urls.Length == 0) return;
            foreach (string url in urls)
            {
                this.lbxFinishedUrl.Items.Add(url);
            }
        }
    }
}