using System;
using System.Collections.Generic;
using System.Text;
using System.IO;
using System.Xml;

namespace HFBBS
{
    public class RssPicker
    {
        public static List<string> GetRssLinks(string html, Encoding encoding)
        {
            try
            {
                MemoryStream memoryStream = new MemoryStream(encoding.GetBytes(html));
                return GetRssLinks(memoryStream, encoding);
            }
            catch
            {
                MemoryStream memoryStream = new MemoryStream(Encoding.GetEncoding("gb2312").GetBytes(UTF8_GB2312(html)));
                return GetRssLinks(memoryStream, encoding);
            }
        }

        //读出时进行转换   
        public static string UTF8_GB2312(string read)
        {
            //声明字符集   
            System.Text.Encoding utf8, gb2312;
            //iso8859   
            utf8 = System.Text.Encoding.GetEncoding("utf-8");
            //国标2312   
            gb2312 = System.Text.Encoding.GetEncoding("gb2312");
            byte[] iso;
            iso = utf8.GetBytes(read);
            //返回转换后的字符   
            var result = gb2312.GetString(iso);
            return result;
        }

        public static System.Text.Encoding GetType(string html)
        {
            /*
            byte[] Unicode=new byte[]{0xFF,0xFE}; 
            byte[] UnicodeBIG=new byte[]{0xFE,0xFF}; 
            byte[] UTF8=new byte[]{0xEF,0xBB,0xBF};*/
            BinaryReader r = new BinaryReader(new MemoryStream(Encoding.Default.GetBytes(html)));
            byte[] ss = r.ReadBytes(3);
            r.Close(); //编码类型 Coding=编码类型.ASCII; 
            if (ss[0] >= 0xEF)
            {
                if (ss[0] == 0xEF && ss[1] == 0xBB && ss[2] == 0xBF)
                {
                    return System.Text.Encoding.UTF8;
                }
                else if (ss[0] == 0xFE && ss[1] == 0xFF)
                {
                    return System.Text.Encoding.BigEndianUnicode;
                }
                else if (ss[0] == 0xFF && ss[1] == 0xFE)
                {
                    return System.Text.Encoding.Unicode;
                }
                else { return System.Text.Encoding.Default; }
            }
            else { return System.Text.Encoding.Default; }
        }

        public static List<string> GetRssLinks(Stream stream, Encoding encoding)
        {
            List<string> urlList = new List<string>();
            stream.Position = 0;
            XmlTextReader xmlReader = new XmlTextReader(new StreamReader(stream, encoding));
            xmlReader.Namespaces = false;
            while (xmlReader.Read())
            {
                if (xmlReader.NodeType == XmlNodeType.Element)
                {
                    string name = xmlReader.Name.ToLower();
                    switch (name)
                    {
                        case "atom:feed":	// We have Atom Feed
                        case "feed":	// We have Atom Feed
                            ProcessAtomFeed(xmlReader, urlList);
                            break;
                        case "rdf:rdf":		// We have rdf feed
                        case "rdf":		// We have rdf feed
                            ProcessRdfFeed(xmlReader, urlList);
                            break;
                        case "rss:rss":		// We have rss feed
                        case "rss":		// We have rss feed
                            ProcessRssFeed(xmlReader, urlList);
                            break;
                    }
                }
            }
            return urlList;
        }

        private static void ProcessAtomFeed(XmlReader reader, List<string> list)
        {
            while (reader.Read())
            {
                if (reader.NodeType == XmlNodeType.Element && reader.Name == "link")
                {
                    reader.MoveToAttribute("href");
                    if (reader.ReadAttributeValue())
                    {
                        list.Add(reader.Value);
                    }
                }
            }
        }

        private static void ProcessRdfFeed(XmlReader reader, List<string> list)
        {
            while (reader.Read())
            {
                if (reader.NodeType == XmlNodeType.Element && reader.Name == "link")
                {
                    list.Add(ReadString(reader));
                }
            }
        }

        private static void ProcessRssFeed(XmlReader reader, List<string> list)
        {
            while (reader.Read())
            {
                if (reader.NodeType == XmlNodeType.Element && reader.Name == "link")
                {
                    list.Add(ReadString(reader));
                }
            }
        }

        private static string ReadString(XmlReader reader)
        {
            /// Reuse existing buffer in order to prevent frequent StringBuffer allocation
            StringBuilder buffer = new StringBuilder(100);
            /// Empty elements have no content
            if (reader.IsEmptyElement) return string.Empty;

            /// Skip the begin tag and all white spaces before the first character of content is found
            while (!reader.EOF
                && (reader.NodeType == XmlNodeType.Element
                || reader.NodeType == XmlNodeType.Whitespace))
                reader.Read();

            /// Read and store in buffer when we are getting text and CDATA sections. But stop immediately
            /// whenever we read the end element.
            while (reader.NodeType == XmlNodeType.CDATA
                || reader.NodeType == XmlNodeType.Text
                && reader.NodeType != XmlNodeType.EndElement)
            {
                buffer.Append(reader.Value);
                reader.Read();
            }

            /// Now the read is poting to the EndElement. Return the content of the buffer
            /// we have prepared for this node
            return buffer.ToString();
        }
    }
}
