using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Xml;

namespace Jade
{
    public class AutomaticTag
    {
        private string _title;
        private string _content;
        private string _time;
        private string _categories;

        private string _html;
        private XmlDocument _xml;

        private TagKey FindTag(string html)
        {
            TagKey key = new TagKey();
            int count = 0;

            for (int i = 0; i < html.Length; i++)
            {
                int m = i + 1;
                if (m > html.Length) break;

                if (html[i] == '<' && html[m] != '/')
                {
                    key.TagBeginIndex = i;
                }
            }

            return key;
        }

        private void matic()
        {
        }

        private void CoventToXml()
        {
            _xml = new XmlDocument();

            if (string.IsNullOrEmpty(_html))
                return;
        }

        private XmlNode CreateXmlNode(string tag, string html)
        {
            XmlElement root = _xml.CreateElement(tag);

            html = html.Trim().ToLower();

            bool tabStart = false;
            int tagCount = 0;
            int tagBeginIndex = -1;

            List<TagKey> TabList = new List<TagKey>();

            // 找出所有的标签对
            for (int i = 0; i < html.Length; i++)
            {
                int nextIndex = i + 1;

                if (nextIndex < html.Length)
                {
                    // 为“ <xxx” 时 标签++
                    if (html[i] == '<' && html[nextIndex] != '/')
                    {
                        if (tagBeginIndex == -1)
                        {
                            tagBeginIndex = i;
                            tabStart = true;
                        }

                        tagCount++;
                    }

                    // 为“</   />” 时 标签-- 并生成标签名
                    if (tabStart && ((html[i] == '<' && html[nextIndex] == '/')
                        || (html[i] == '/' && html[nextIndex] == '>')))
                    {

                        tagCount--;
                        if (tagCount == 0)
                        {
                            StringBuilder BefoTagname = new StringBuilder();
                            StringBuilder AfterTagname = new StringBuilder();

                            bool visTag = true;
                            int tagEnd = 0;
                            int innerHTMLBegin = 0;
                            int innerHTMLEnd = 0;

                            // 生成前标签
                            for (int j = tagBeginIndex + 1; j < nextIndex - tagBeginIndex; i++)
                            {
                                if (!visTag)
                                    break;

                                if (html[j] == ' ')
                                {
                                    tagEnd = j;
                                    break;
                                }

                                if (!IsTagChar(html[j]))
                                    visTag = false;
                                else
                                    BefoTagname.Append(html[j]);
                            }


                            // 生成后标签
                            for (int j = i - 1; j > html.Length - tagBeginIndex; i--)
                            {
                                if (html[j] == '<')
                                {
                                    innerHTMLEnd = j;
                                    break;
                                }

                                if (!IsTagChar(html[j]))
                                    visTag = false;
                                else
                                    AfterTagname.Insert(0, html[j]);
                            }


                            if (visTag && AfterTagname.ToString() == BefoTagname.ToString())
                            {
                                // 检查标签属性
                                StringBuilder tagValue = new StringBuilder();

                                for (int j = tagEnd; j < html.Length - tagEnd; j++)
                                {
                                    if (html[j] == '>')
                                    {
                                        innerHTMLBegin = j;
                                        break;
                                    }
                                    tagValue.Append(html[j]);
                                }

                                TagKey tagKey = new TagKey()
                                {
                                    TagBeginIndex = tagBeginIndex,
                                    TagEndIndex = nextIndex,
                                    Value = tagValue.ToString().Trim(),
                                    TagName = AfterTagname.ToString(),
                                    InnerHtml = html.Substring(innerHTMLBegin, html.Length - innerHTMLEnd)
                                };
                                TabList.Add(tagKey);
                                tabStart = false;
                                tagBeginIndex = -1;
                            }
                            
                        }
                    }
                }
            }

            return null;
        }

        private bool IsTagChar(char charValue)
        {
            if (charValue >= 97 && charValue <= 122)
                return true;
            return false;
        }

        public AutomaticTag(string html)
        {
            this._html = html;
        }

        public string Title
        {
            get
            {
                if (string.IsNullOrEmpty(this._title))
                    matic();
                return this._title;
            }
        }

        public string Content
        {
            get
            {
                if (string.IsNullOrEmpty(this._content))
                    matic();
                return this._content;
            }
        }

        public string Time
        {
            get
            {
                if (string.IsNullOrEmpty(this._time))
                {
                    matic();
                }
                return this._time;
            }
        }

        public string Categories
        {
            get
            {
                if (string.IsNullOrEmpty(this._categories))
                    this.matic();
                return this._categories;
            }
        }
    }

    internal class TagKey
    {
        public int TagBeginIndex { get; set; }
        public int TagEndIndex { get; set; }
        public string TagName { get; set; }
        public string Value { get; set; }

        public string InnerHtml { get; set; }
    }

    internal class TagList
    {
        public List<TagKey> TagKeyList = new List<TagKey>();
        public int Count { get; set; }
    }
}
