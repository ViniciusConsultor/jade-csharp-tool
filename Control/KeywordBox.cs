using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Drawing;
using System.Data;
using System.Linq;
using System.Text;
using System.Windows.Forms;

namespace Jade.Control
{
    public partial class KeywordBox : UserControl
    {

        public event Change OnChange;

        public List<string> keywords;

        /// <summary>
        /// 拆分
        /// </summary>
        [DefaultValue("|")]
        public string SplitWord
        {
            get;
            set;
        }

        /// <summary>
        /// 设置获取文本
        /// </summary>
        public new string Text
        {
            get
            {
                if (keywords == null)
                {
                    return "";
                }

                return string.Join(SplitWord, keywords.Select(w => w.Trim()).ToArray());
            }
            set
            {
                if (value != null)
                {
                    this.keywords = new List<string>();
                    this.keywords.AddRange(value.Split(new string[] { this.SplitWord }, StringSplitOptions.RemoveEmptyEntries));
                    this.Bind();
                }
            }
        }

        public void AddWord(string word)
        {
            if (keywords == null)
            {
                keywords = new List<string>();
            }
            if (!keywords.Contains(word))
            {
                this.keywords.Add(word);
                this.Bind();
            }
        }

        public KeywordBox()
        {

            InitializeComponent();
            oldColor = this.BackColor;

            this.KeyDown += new KeyEventHandler(KeywordBox_KeyDown);
            this.MouseDown += new MouseEventHandler(KeywordBox_MouseDown);
            //this.txtKeyword.Hide();          
        }

        bool isNew = false;

        void KeywordBox_MouseDown(object sender, MouseEventArgs e)
        {
            if (e.X > lastLeft)
            {
                isNew = true;
                this.txtKeyword.Left = lastLeft;
                this.txtKeyword.Width = 300;
                this.txtKeyword.Text = "";
                this.txtKeyword.Show();
                this.txtKeyword.Focus();
                isEdit = true;
            }
        }

        void KeywordBox_KeyDown(object sender, KeyEventArgs e)
        {
            if (selectedLabel != null && e.KeyCode == Keys.Back)
            {
                this.keywords.Remove(this.selectedLabel.Text);
                if (this.OnChange != null)
                {
                    this.OnChange(this, new EventArgs());
                }

                this.Bind();
            }
        }


        Label selectedLabel;

        public List<string> Keywords
        {
            get
            {
                return keywords;
            }
            set
            {
                keywords = value;
                if (keywords != null)
                {
                    this.Bind();
                }
            }
        }

        int lastLeft = 0;

        public void Bind()
        {
            this.selectedLabel = null;
            this.Controls.Clear();
            this.Controls.Add(txtKeyword);
            this.txtKeyword.Hide();
            lastLeft = 0;
            var index = 0;
            foreach (var keyword in this.Keywords)
            {
                index++;
                var label = new Label();
                label.Text = keyword;
                label.Width = (int)label.CreateGraphics().MeasureString(keyword, label.Font).Width + 2;
                label.MouseMove += new MouseEventHandler(lblText_MouseHover);
                label.MouseLeave += new EventHandler(lblText_MouseLeave);
                label.Click += new EventHandler(label_Click);
                label.DoubleClick += new EventHandler(lblText_DoubleClick);
                label.PreviewKeyDown += new PreviewKeyDownEventHandler(label_PreviewKeyDown);
                label.Left = lastLeft;
                label.Top = 3;
                this.Controls.Add(label);


                lastLeft += label.Width + 2;

                if (index != keywords.Count)
                {
                    var split = new Label();
                    split.Width = (int)label.CreateGraphics().MeasureString(SplitWord, split.Font).Width + 2;
                    split.Text = SplitWord;
                    split.Left = lastLeft;
                    split.Top = 3;
                    this.Controls.Add(split);
                    lastLeft += split.Width + 5;
                }

                this.lastLabel = label;
            }
        }

        void label_PreviewKeyDown(object sender, PreviewKeyDownEventArgs e)
        {
            if (sender == this.currentLabel)
            {
                if (e.KeyCode == Keys.Delete)
                {
                    // keywordIndex = Keywords.FindIndex(delegate(string s) { return s == currentLabel.Text; });
                    this.keywords.Remove(currentLabel.Text);
                    this.Bind();
                }
            }
        }

        void label_Click(object sender, EventArgs e)
        {
            if (selectedLabel != null)
            {
                selectedLabel.BackColor = oldColor;
            }
            selectedLabel = sender as Label;
            selectedLabel.BackColor = Color.SteelBlue;
            this.Focus();
        }

        private void comboBox1_SelectedIndexChanged(object sender, EventArgs e)
        {

        }


        Color oldColor;

        private void lblText_MouseHover(object sender, EventArgs e)
        {
            if ((sender as Label) != selectedLabel)
                (sender as Label).BackColor = Color.Silver;
        }

        private void lblText_MouseLeave(object sender, EventArgs e)
        {
            if ((sender as Label) != selectedLabel)
                (sender as Label).BackColor = oldColor;
        }

        Label currentLabel;

        Label lastLabel;

        int keywordIndex = -1;

        private void lblText_DoubleClick(object sender, EventArgs e)
        {
            isEdit = true;
            var label = (sender as Label);
            this.txtKeyword.Left = label.Left;
            this.txtKeyword.Show();
            currentLabel = label;
            txtKeyword.Text = label.Text;
            txtKeyword.Width = label.Width + 40;
            txtKeyword.Focus();
            txtKeyword.BringToFront();
            label.Hide();
            keywordIndex = Keywords.FindIndex(delegate(string s) { return s == label.Text; });
        }

        private void txtKeyword_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Enter)
            {
                if (isEdit)
                {
                    isEdit = false;
                    KeywordLeave();
                }
            }
        }

        bool isEdit = false;

        private void KeywordLeave()
        {
            this.txtKeyword.Hide();

            if (!isNew)
            {
                if (txtKeyword.Text != "")
                {
                    var words = txtKeyword.Text.Split(new string[] { this.SplitWord, " ", ",", "，" }, StringSplitOptions.RemoveEmptyEntries);
                    if (words.Length > 1)
                    {
                        this.Keywords[keywordIndex] = words[0];
                        for (var i = 1; i < words.Length; i++)
                        {
                            this.Keywords.Add(words[i]);
                        }
                    }
                    else
                    {
                        this.Keywords[keywordIndex] = txtKeyword.Text.Trim();
                    }
                }
                else
                    this.Keywords.RemoveAt(keywordIndex);
            }
            else
            {
                if (txtKeyword.Text != "")
                {
                    var words = txtKeyword.Text.Split(new string[] { this.SplitWord }, StringSplitOptions.RemoveEmptyEntries);
                    foreach (var word in words)
                    {
                        if (!string.IsNullOrEmpty(word.Trim()))
                            this.Keywords.Add(word.Trim());
                    }
                }
                isNew = false;
            }

            Bind();

            if (this.OnChange != null)
            {
                this.OnChange(this, new EventArgs());
            }

        }

        private void txtKeyword_Leave(object sender, EventArgs e)
        {
        }

        private void KeywordBox_Load(object sender, EventArgs e)
        {

        }

        private void txtKeyword_MouseLeave(object sender, EventArgs e)
        {
            //if (isEdit)
            //{
            //    isEdit = false;
            //    KeywordLeave();
            //}
        }
    }
}
