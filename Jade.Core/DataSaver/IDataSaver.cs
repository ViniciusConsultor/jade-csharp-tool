using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.IO;
using Jade.Model;


namespace Jade
{
    public class FilePath
    {
        public FilePath()
        {
        }

        public FilePath(string fileName)
        {
            this._fileName = fileName;
            Decomposition();
        }

        private string _fileName;

        public string Path;
        public string Name;
        public string Extension;

        public void Decomposition()
        {
            if (string.IsNullOrEmpty(_fileName))
                return;

            int index = _fileName.LastIndexOf('\\');
            Path = _fileName.Substring(0, index);

            string name = _fileName.Substring(index + 1, _fileName.Length - index - 1);

            int e = name.LastIndexOf('.');

            Name = name.Substring(0, e);
            Extension = name.Substring(e + 1, name.Length - e - 1);
        }
    }

    /// <summary>
    /// 数据保存接口
    /// </summary>
    public interface IDataSave
    {
        /// <summary>
        /// 保存数据
        /// </summary>
        /// <param name="content"></param>
        void SaveContentPage(KeyValueContent content);
    }

    /// <summary>
    /// XML 文件保存
    /// </summary>
    public class XMLFileSave : IDataSave
    {
        private string path { get; set; }
        private string currentFileName = "";
        private static object xmlLocker = new object();

        private int FileShart = 0;
        private bool IndexUpdate = false;
        private FilePath FilePath;

        private Int32 FileLength = 0;

        private string baseDir = BaseConfig.SaveFileDir;

        DateTime lastDate = DateTime.Now.Date;

        public XMLFileSave()
        {
            InitDir();
        }

        private void InitDir()
        {
            this.path = baseDir + DateTime.Now.ToString("yyyyMMdd");

            if (!Directory.Exists(path))
            {
                Directory.CreateDirectory(path);
            }

            this.path += "\\" + BaseConfig.DefaultPageTable;

            if (!Directory.Exists(path))
            {
                Directory.CreateDirectory(path);
            }
            else
            {
                // 检查是否存在文件

                var files = Directory.GetFiles(path, BaseConfig.DefaultPageTable + "AutoSave*");

                if (files.Length > 0)
                {
                    FileShart = 0;

                    foreach (var file in files)
                    {
                        var index = int.Parse(new FileInfo(file).Name.Replace(BaseConfig.DefaultPageTable + "AutoSave", "").Replace(".xml", ""));
                        if (FileShart < index)
                        {
                            FileShart = index;
                        }
                    }

                    this.currentFileName = this.path + "\\" + BaseConfig.DefaultPageTable + "AutoSave" + FileShart + ".xml";

                    if (File.Exists(currentFileName))
                    {
                        FileLength += (int)(new FileInfo(currentFileName).Length);
                    }
                }
            }

            this.path += "\\" + BaseConfig.DefaultPageTable + "AutoSave.xml";
        }

        static List<KeyValueContent> Cache = new List<KeyValueContent>();

        public void SaveContentPage(KeyValueContent content)
        {
            SaveContentPages(new List<KeyValueContent> { content });
            //SolrUtility.Add(content);
        }

        public void ForceSave()
        {
            SaveCache();
        }

        public void SaveContentPages(List<KeyValueContent> cachedNews)
        {
            lock (xmlLocker)
            {
                CheckNewDate();

                Cache.AddRange(cachedNews);

                if (Cache.Count > 10)
                {
                    SaveCache();
                }
            }
        }

        private void SaveCache()
        {
            visFile(path);
            AutoFragmentation();
            StringBuilder text = new StringBuilder();
            foreach (var kv in Cache)
            {
                text.AppendLine("   <result>");
                foreach (var column in kv.KeyValue)
                {
                    text.AppendLine(String.Format("     <{0}>{1}</{0}>", column.Key, column.Value.Replace('<', '＜').Replace('>', '＞').Replace("&", "＆")));
                }
                text.AppendLine(String.Format("     <{0}>{1}</{0}>", "CreateTime", DateTime.Now.ToString()));
                text.AppendLine("   </result>");
            }
            FileLength += text.Length;
            File.AppendAllText(currentFileName, text.ToString(), Encoding.GetEncoding("gb2312"));
            Cache.Clear();
        }

        private void CheckNewDate()
        {
            if (lastDate != DateTime.Now.Date)
            {
                lastDate = DateTime.Now.Date;
                File.AppendAllText(currentFileName, "</results>", Encoding.GetEncoding("gb2312"));
                InitDir();
                FileShart = 0;
                IndexUpdate = true;
                visFile(path);
                FileLength = 0;
            }
        }

        private void AutoFragmentation()
        {
            if (FileLength >= 10971520)
            {
                File.AppendAllText(currentFileName, "</results>", Encoding.GetEncoding("gb2312"));
                FileShart++;
                IndexUpdate = true;
                visFile(path);
                FileLength = 0;
            }
        }

        private void CreateXml()
        {
            lock (xmlLocker)
            {
                File.AppendAllText(currentFileName, "<results>\r\n", Encoding.GetEncoding("gb2312"));
            }
        }

        private void visFile(String path)
        {

            FilePath = new FilePath(path);

            if (string.IsNullOrEmpty(currentFileName) || IndexUpdate)
            {
                StringBuilder sb = new StringBuilder(FilePath.Path);
                sb.AppendFormat("\\{0}{1}", FilePath.Name, FileShart);
                sb.AppendFormat(".{0}", FilePath.Extension);
                currentFileName = sb.ToString();
                IndexUpdate = false;
            }

            if (!File.Exists(currentFileName))
            {
                if (!Directory.Exists(FilePath.Path))
                {
                    Directory.CreateDirectory(FilePath.Path);
                }
                CreateXml();
            }
        }

        public void Close()
        {
            if (!String.IsNullOrEmpty(currentFileName))
            {
                File.AppendAllText(currentFileName, "</results>", Encoding.GetEncoding("gb2312"));
            }
            FileShart = 0;
        }
    }
}
