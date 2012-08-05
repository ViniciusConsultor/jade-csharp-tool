
//using System;
//using System.Data;
//using System.Linq;
//using System.Text;
//using System.Data.OleDb;
//using Maticsoft.DBUtility;
//using System.Collections.Generic;//Please add references

//namespace Jade.Model.Access
//{
//    public partial class DownloadData : IDownloadData
//    {
//        public DownloadData(int taskId, string url)
//            : this()
//        {
//            TaskId = taskId;
//            Url = url;
//        }

//        /// <summary>
//        /// 得到一个对象实体
//        /// </summary>
//        public DownloadData(string url)
//        {
//            StringBuilder strSql = new StringBuilder();
//            strSql.Append("select *");
//            strSql.Append(" FROM [DownloadData] ");
//            strSql.Append(" where Url=@Url ");
//            OleDbParameter[] parameters = {
//                    new OleDbParameter("@Url", OleDbType.VarChar)};
//            parameters[0].Value = url;
//            DataSet ds = DbHelperOleDb.Query(strSql.ToString(), parameters);
//            this.GetModelFromDataSet(ds);
//        }

//        /// <summary>
//        /// 获得数据列表
//        /// </summary>
//        public static List<string> GetUrlList(int taskId)
//        {
//            var result = new List<string>();
//            StringBuilder strSql = new StringBuilder();
//            strSql.Append("select Url ");
//            strSql.Append(" FROM [DownloadData] ");
//            strSql.Append(" where TaskId=@TaskId ");
//            OleDbParameter[] parameters = {
//                    new OleDbParameter("@TaskId", OleDbType.Integer)};
//            parameters[0].Value = taskId;
//            var dataSet = DbHelperOleDb.Query(strSql.ToString(), parameters);
//            if (dataSet.Tables.Count > 0)
//            {
//                foreach (DataRow row in dataSet.Tables[0].Rows)
//                {
//                    result.Add(row["Url"].ToString());
//                }

//            }

//            return result;
//        }

//        /// <summary>
//        /// 获得数据列表
//        /// </summary>
//        public static List<string> GetUnFetchedUrlList(int taskId)
//        {
//            var result = new List<string>();
//            StringBuilder strSql = new StringBuilder();
//            strSql.Append("select Url ");
//            strSql.Append(" FROM [DownloadData] ");
//            strSql.Append(" where TaskId=@TaskId AND IsDownload = 0");
//            OleDbParameter[] parameters = {
//                    new OleDbParameter("@TaskId", OleDbType.Integer)};
//            parameters[0].Value = taskId;
//            var dataSet = DbHelperOleDb.Query(strSql.ToString(), parameters);
//            if (dataSet.Tables.Count > 0)
//            {
//                foreach (DataRow row in dataSet.Tables[0].Rows)
//                {
//                    result.Add(row["Url"].ToString());
//                }

//            }

//            return result;
//        }

//        /// <summary>
//        /// 获得数据列表
//        /// </summary>
//        public DataSet GetList(string strWhere, out int totalCount, int page = 1, int pageSize = 10)
//        {
//            var sql = string.Format(
//   @"select * from (select top {0} * from (select top {1} * from [DownloadData] {2} order by ID DESC) order by ID ) order by ID DESC", pageSize, page * pageSize, strWhere == "" ? "" : "where " + strWhere);

//            var countSql = string.Format("select count(*) from [DownloadData] {0}", strWhere == "" ? "" : "where " + strWhere);

//            totalCount = (int)DbHelperOleDb.GetSingle(countSql);

//            return DbHelperOleDb.Query(sql);
//        }


//        #region IDownloadData 成员


//        public DateTime DownloadTime
//        {
//            get;
//            set;
//        }

//        public string EditorUserName
//        {
//            get;
//            set;
//        }

//        public DateTime EditTime
//        {
//            get;
//            set;
//        }

//        public bool IsEdit
//        {
//            get;
//            set;
//        }
//        #endregion

//        #region IDownloadData 成员


//        DateTime? IDownloadData.DownloadTime
//        {
//            get
//            {
//                throw new NotImplementedException();
//            }
//            set
//            {
//                throw new NotImplementedException();
//            }
//        }

//        DateTime? IDownloadData.EditTime
//        {
//            get
//            {
//                throw new NotImplementedException();
//            }
//            set
//            {
//                throw new NotImplementedException();
//            }
//        }

//        int? IDownloadData.TaskId
//        {
//            get
//            {
//                throw new NotImplementedException();
//            }
//            set
//            {
//                throw new NotImplementedException();
//            }
//        }

//        #endregion
//    }
//}

using System;
namespace Jade.Model.Access
{
    /// <summary>
    /// DownloadData:实体类(属性说明自动提取数据库字段的描述信息)
    /// </summary>
    [Serializable]
    public partial class DownloadData : IDownloadData
    {
        public DownloadData()
        { }
        #region Model
        private int _id;
        private int? _taskid;
        private string _title = "";
        private string _subtitle = "";
        private string _keywords = "";
        private string _news_source_name = "";
        private string _news_template_file = "";
        private string _news_top = "";
        private string _news_guideimage = "";
        private string _news_guideimage2 = "";
        private string _news_description = "";
        private string _news_link = "";
        private string _news_down = "";
        private string _news_right = "";
        private string _news_left = "";
        private string _comment_url = "";
        private string _news_video = "";
        private string _news_keywords2 = "";
        private string _label_base = "";
        private bool _cmspinglun;
        private bool _bbspinglun;
        private bool _iskfbm;
        private string _kfbm_id = "";
        private string _kfbm_link = "";
        private bool _isgfbm;
        private string _gfbm_id = "";
        private string _gfbm_link = "";
        private string _news_abs = "";
        private string _content = "";
        private string _summary = "";
        private string _source = "";
        private string _createtime = "";
        private string _other = "";
        private string _url = "";
        private DateTime? _downloadtime = DateTime.Now;
        private string _editorusername = "";
        private bool _isedit;
        private DateTime? _edittime = DateTime.MinValue;
        private bool _isdownload;
        private bool _ispublish;
        private int _remoteId = 0;
        /// <summary>
        /// 
        /// </summary>
        public int ID
        {
            set { _id = value; }
            get { return _id; }
        }
        /// <summary>
        /// 
        /// </summary>
        public int? TaskId
        {
            set { _taskid = value; }
            get { return _taskid; }
        }
        /// <summary>
        /// 
        /// </summary>
        public string Title
        {
            set { _title = value; }
            get { return _title; }
        }
        /// <summary>
        /// 
        /// </summary>
        public string SubTitle
        {
            set { _subtitle = value; }
            get { return _subtitle; }
        }
        /// <summary>
        /// 
        /// </summary>
        public string Keywords
        {
            set { _keywords = value; }
            get { return _keywords; }
        }
        /// <summary>
        /// 
        /// </summary>
        public string news_source_name
        {
            set { _news_source_name = value; }
            get { return _news_source_name; }
        }
        /// <summary>
        /// 
        /// </summary>
        public string news_template_file
        {
            set { _news_template_file = value; }
            get { return _news_template_file; }
        }
        /// <summary>
        /// 
        /// </summary>
        public string news_top
        {
            set { _news_top = value; }
            get { return _news_top; }
        }
        /// <summary>
        /// 
        /// </summary>
        public string news_guideimage
        {
            set { _news_guideimage = value; }
            get { return _news_guideimage; }
        }
        /// <summary>
        /// 
        /// </summary>
        public string news_guideimage2
        {
            set { _news_guideimage2 = value; }
            get { return _news_guideimage2; }
        }
        /// <summary>
        /// 
        /// </summary>
        public string news_description
        {
            set { _news_description = value; }
            get { return _news_description; }
        }
        /// <summary>
        /// 
        /// </summary>
        public string news_link
        {
            set { _news_link = value; }
            get { return _news_link; }
        }
        /// <summary>
        /// 
        /// </summary>
        public string news_down
        {
            set { _news_down = value; }
            get { return _news_down; }
        }
        /// <summary>
        /// 
        /// </summary>
        public string news_right
        {
            set { _news_right = value; }
            get { return _news_right; }
        }
        /// <summary>
        /// 
        /// </summary>
        public string news_left
        {
            set { _news_left = value; }
            get { return _news_left; }
        }
        /// <summary>
        /// 
        /// </summary>
        public string comment_url
        {
            set { _comment_url = value; }
            get { return _comment_url; }
        }
        /// <summary>
        /// 
        /// </summary>
        public string news_video
        {
            set { _news_video = value; }
            get { return _news_video; }
        }
        /// <summary>
        /// 
        /// </summary>
        public string news_keywords2
        {
            set { _news_keywords2 = value; }
            get { return _news_keywords2; }
        }
        /// <summary>
        /// 
        /// </summary>
        public string label_base
        {
            set { _label_base = value; }
            get { return _label_base; }
        }
        /// <summary>
        /// 
        /// </summary>
        public bool cmspinglun
        {
            set { _cmspinglun = value; }
            get { return _cmspinglun; }
        }
        /// <summary>
        /// 
        /// </summary>
        public bool bbspinglun
        {
            set { _bbspinglun = value; }
            get { return _bbspinglun; }
        }
        /// <summary>
        /// 
        /// </summary>
        public bool ISkfbm
        {
            set { _iskfbm = value; }
            get { return _iskfbm; }
        }
        /// <summary>
        /// 
        /// </summary>
        public string kfbm_id
        {
            set { _kfbm_id = value; }
            get { return _kfbm_id; }
        }
        /// <summary>
        /// 
        /// </summary>
        public string kfbm_link
        {
            set { _kfbm_link = value; }
            get { return _kfbm_link; }
        }
        /// <summary>
        /// 
        /// </summary>
        public bool ISgfbm
        {
            set { _isgfbm = value; }
            get { return _isgfbm; }
        }
        /// <summary>
        /// 
        /// </summary>
        public string gfbm_id
        {
            set { _gfbm_id = value; }
            get { return _gfbm_id; }
        }
        /// <summary>
        /// 
        /// </summary>
        public string gfbm_link
        {
            set { _gfbm_link = value; }
            get { return _gfbm_link; }
        }
        /// <summary>
        /// 
        /// </summary>
        public string news_abs
        {
            set { _news_abs = value; }
            get { return _news_abs; }
        }
        /// <summary>
        /// 
        /// </summary>
        public string Content
        {
            set { _content = value; }
            get { return _content; }
        }
        /// <summary>
        /// 
        /// </summary>
        public string Summary
        {
            set { _summary = value; }
            get { return _summary; }
        }
        /// <summary>
        /// 
        /// </summary>
        public string Source
        {
            set { _source = value; }
            get { return _source; }
        }
        /// <summary>
        /// 
        /// </summary>
        public string CreateTime
        {
            set { _createtime = value; }
            get { return _createtime; }
        }
        /// <summary>
        /// 
        /// </summary>
        public string Other
        {
            set { _other = value; }
            get { return _other; }
        }
        /// <summary>
        /// 
        /// </summary>
        public string Url
        {
            set { _url = value; }
            get { return _url; }
        }
        /// <summary>
        /// 
        /// </summary>
        public DateTime? DownloadTime
        {
            set { _downloadtime = value; }
            get { return _downloadtime; }
        }
        /// <summary>
        /// 
        /// </summary>
        public string EditorUserName
        {
            set { _editorusername = value; }
            get { return _editorusername; }
        }
        /// <summary>
        /// 
        /// </summary>
        public bool IsEdit
        {
            set { _isedit = value; }
            get { return _isedit; }
        }
        /// <summary>
        /// 
        /// </summary>
        public DateTime? EditTime
        {
            set { _edittime = value; }
            get { return _edittime; }
        }
        /// <summary>
        /// 
        /// </summary>
        public bool IsDownload
        {
            set { _isdownload = value; }
            get { return _isdownload; }
        }
        /// <summary>
        /// 
        /// </summary>
        public bool IsPublish
        {
            set { _ispublish = value; }
            get { return _ispublish; }
        }
        #endregion Model

        public DownloadData(int taskId, string url)
            : this()
        {
            TaskId = taskId;
            Url = url;
        }


        public int publishedIndex
        {
            get { return this.IsPublish ? 1 : 0; }
        }

        public int editedIndex
        {
            get { return this.IsEdit ? 1 : 0; }
        }
        public bool IsChecked { get; set; }


        public int RemoteId
        {
            get { return _remoteId; }
            set { _remoteId = value; }
        }
    }
}





