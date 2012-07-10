using System;
using System.Data;
using System.Text;
using System.Data.OleDb;
using Maticsoft.DBUtility;//Please add references
namespace HFBBS.Model
{
    /// <summary>
    /// 类DownloadData。
    /// </summary>
    [Serializable]
    public partial class DownloadData
    {
        public DownloadData()
        { }
        #region Model
        private int _id;
        private int? _taskid;
        private string _title;
        private string _content;
        private string _summary;
        private string _source;
        private string _createtime;
        private string _other;
        private string _url;
        private bool _isdownload;
        private bool _ispublish;
        private string _subtitle;
        private string _keywords;

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


        #region  Method

        /// <summary>
        /// 得到一个对象实体
        /// </summary>
        public DownloadData(int ID)
        {
            StringBuilder strSql = new StringBuilder();
            strSql.Append("select ID,TaskId,Title,SubTitle,Keywords,Content,Summary,Source,CreateTime,Other,Url,IsDownload,IsPublish ");
            strSql.Append(" FROM [DownloadData] ");
            strSql.Append(" where ID=@ID ");
            OleDbParameter[] parameters = {
					new OleDbParameter("@ID", OleDbType.Integer,4)};
            parameters[0].Value = ID;

            DataSet ds = DbHelperOleDb.Query(strSql.ToString(), parameters);
            if (ds.Tables[0].Rows.Count > 0)
            {
                if (ds.Tables[0].Rows[0]["ID"] != null && ds.Tables[0].Rows[0]["ID"].ToString() != "")
                {
                    this.ID = int.Parse(ds.Tables[0].Rows[0]["ID"].ToString());
                }
                if (ds.Tables[0].Rows[0]["TaskId"] != null && ds.Tables[0].Rows[0]["TaskId"].ToString() != "")
                {
                    this.TaskId = int.Parse(ds.Tables[0].Rows[0]["TaskId"].ToString());
                }
                if (ds.Tables[0].Rows[0]["Title"] != null && ds.Tables[0].Rows[0]["Title"].ToString() != "")
                {
                    this.Title = ds.Tables[0].Rows[0]["Title"].ToString();
                }
                if (ds.Tables[0].Rows[0]["SubTitle"] != null && ds.Tables[0].Rows[0]["SubTitle"].ToString() != "")
                {
                    this.SubTitle = ds.Tables[0].Rows[0]["SubTitle"].ToString();
                }
                if (ds.Tables[0].Rows[0]["Keywords"] != null && ds.Tables[0].Rows[0]["Keywords"].ToString() != "")
                {
                    this.Keywords = ds.Tables[0].Rows[0]["Keywords"].ToString();
                }
                if (ds.Tables[0].Rows[0]["Content"] != null && ds.Tables[0].Rows[0]["Content"].ToString() != "")
                {
                    this.Content = ds.Tables[0].Rows[0]["Content"].ToString();
                }
                if (ds.Tables[0].Rows[0]["Summary"] != null && ds.Tables[0].Rows[0]["Summary"].ToString() != "")
                {
                    this.Summary = ds.Tables[0].Rows[0]["Summary"].ToString();
                }
                if (ds.Tables[0].Rows[0]["Source"] != null && ds.Tables[0].Rows[0]["Source"].ToString() != "")
                {
                    this.Source = ds.Tables[0].Rows[0]["Source"].ToString();
                }
                if (ds.Tables[0].Rows[0]["CreateTime"] != null && ds.Tables[0].Rows[0]["CreateTime"].ToString() != "")
                {
                    this.CreateTime = ds.Tables[0].Rows[0]["CreateTime"].ToString();
                }
                if (ds.Tables[0].Rows[0]["Other"] != null && ds.Tables[0].Rows[0]["Other"].ToString() != "")
                {
                    this.Other = ds.Tables[0].Rows[0]["Other"].ToString();
                }
                if (ds.Tables[0].Rows[0]["Url"] != null && ds.Tables[0].Rows[0]["Url"].ToString() != "")
                {
                    this.Url = ds.Tables[0].Rows[0]["Url"].ToString();
                }
                if (ds.Tables[0].Rows[0]["IsDownload"] != null && ds.Tables[0].Rows[0]["IsDownload"].ToString() != "")
                {
                    if ((ds.Tables[0].Rows[0]["IsDownload"].ToString() == "1") || (ds.Tables[0].Rows[0]["IsDownload"].ToString().ToLower() == "true"))
                    {
                        this.IsDownload = true;
                    }
                    else
                    {
                        this.IsDownload = false;
                    }
                }
                if (ds.Tables[0].Rows[0]["IsPublish"] != null && ds.Tables[0].Rows[0]["IsPublish"].ToString() != "")
                {
                    if ((ds.Tables[0].Rows[0]["IsPublish"].ToString() == "1") || (ds.Tables[0].Rows[0]["IsPublish"].ToString().ToLower() == "true"))
                    {
                        this.IsPublish = true;
                    }
                    else
                    {
                        this.IsPublish = false;
                    }
                }
            }
        }
        /// <summary>
        /// 是否存在该记录
        /// </summary>
        public bool Exists(int ID)
        {
            StringBuilder strSql = new StringBuilder();
            strSql.Append("select count(1) from [DownloadData]");
            strSql.Append(" where ID=@ID ");

            OleDbParameter[] parameters = {
					new OleDbParameter("@ID", OleDbType.Integer,4)};
            parameters[0].Value = ID;

            return DbHelperOleDb.Exists(strSql.ToString(), parameters);
        }


        /// <summary>
        /// 增加一条数据
        /// </summary>
        public void Add()
        {
            StringBuilder strSql = new StringBuilder();
            strSql.Append("insert into [DownloadData] (");
            strSql.Append("TaskId,Title,SubTitle,Keywords,Content,Summary,Source,CreateTime,Other,Url,IsDownload,IsPublish)");
            strSql.Append(" values (");
            strSql.Append("@TaskId,@Title,@SubTitle,@Keywords,@Content,@Summary,@Source,@CreateTime,@Other,@Url,@IsDownload,@IsPublish)");
            OleDbParameter[] parameters = {
					new OleDbParameter("@TaskId", OleDbType.Integer,4),
					new OleDbParameter("@Title", OleDbType.VarChar,0),
					new OleDbParameter("@SubTitle", OleDbType.VarChar,0),
					new OleDbParameter("@Keywords", OleDbType.VarChar,0),
					new OleDbParameter("@Content", OleDbType.VarChar,0),
					new OleDbParameter("@Summary", OleDbType.VarChar,0),
					new OleDbParameter("@Source", OleDbType.VarChar,0),
					new OleDbParameter("@CreateTime", OleDbType.VarChar,0),
					new OleDbParameter("@Other", OleDbType.VarChar,0),
					new OleDbParameter("@Url", OleDbType.VarChar,0),
					new OleDbParameter("@IsDownload", OleDbType.Boolean,1),
					new OleDbParameter("@IsPublish", OleDbType.Boolean,1)};
            parameters[0].Value = TaskId;
            parameters[1].Value = Title;
            parameters[2].Value = SubTitle;
            parameters[3].Value = Keywords;
            parameters[4].Value = Content;
            parameters[5].Value = Summary;
            parameters[6].Value = Source;
            parameters[7].Value = CreateTime;
            parameters[8].Value = Other;
            parameters[9].Value = Url;
            parameters[10].Value = IsDownload;
            parameters[11].Value = IsPublish;

            DbHelperOleDb.ExecuteSql(strSql.ToString(), parameters);
        }
        /// <summary>
        /// 更新一条数据
        /// </summary>
        public bool Update()
        {
            StringBuilder strSql = new StringBuilder();
            strSql.Append("update [DownloadData] set ");
            strSql.Append("TaskId=@TaskId,");
            strSql.Append("Title=@Title,");
            strSql.Append("SubTitle=@SubTitle,");
            strSql.Append("Keywords=@Keywords,");
            strSql.Append("Content=@Content,");
            strSql.Append("Summary=@Summary,");
            strSql.Append("Source=@Source,");
            strSql.Append("CreateTime=@CreateTime,");
            strSql.Append("Other=@Other,");
            strSql.Append("Url=@Url,");
            strSql.Append("IsDownload=@IsDownload,");
            strSql.Append("IsPublish=@IsPublish");
            strSql.Append(" where ID=@ID ");
            OleDbParameter[] parameters = {
					new OleDbParameter("@TaskId", OleDbType.Integer,4),
					new OleDbParameter("@Title", OleDbType.VarChar,0),
					new OleDbParameter("@SubTitle", OleDbType.VarChar,0),
					new OleDbParameter("@Keywords", OleDbType.VarChar,0),
					new OleDbParameter("@Content", OleDbType.VarChar,0),
					new OleDbParameter("@Summary", OleDbType.VarChar,0),
					new OleDbParameter("@Source", OleDbType.VarChar,0),
					new OleDbParameter("@CreateTime", OleDbType.VarChar,0),
					new OleDbParameter("@Other", OleDbType.VarChar,0),
					new OleDbParameter("@Url", OleDbType.VarChar,0),
					new OleDbParameter("@IsDownload", OleDbType.Boolean,1),
					new OleDbParameter("@IsPublish", OleDbType.Boolean,1),
					new OleDbParameter("@ID", OleDbType.Integer,4)};
            parameters[0].Value = TaskId;
            parameters[1].Value = Title;
            parameters[2].Value = SubTitle;
            parameters[3].Value = Keywords;
            parameters[4].Value = Content;
            parameters[5].Value = Summary;
            parameters[6].Value = Source;
            parameters[7].Value = CreateTime;
            parameters[8].Value = Other;
            parameters[9].Value = Url;
            parameters[10].Value = IsDownload;
            parameters[11].Value = IsPublish;
            parameters[12].Value = ID;

            int rows = DbHelperOleDb.ExecuteSql(strSql.ToString(), parameters);
            if (rows > 0)
            {
                return true;
            }
            else
            {
                return false;
            }
        }

        /// <summary>
        /// 删除一条数据
        /// </summary>
        public bool Delete(int ID)
        {
            StringBuilder strSql = new StringBuilder();
            strSql.Append("delete from [DownloadData] ");
            strSql.Append(" where ID=@ID ");
            OleDbParameter[] parameters = {
					new OleDbParameter("@ID", OleDbType.Integer,4)};
            parameters[0].Value = ID;

            int rows = DbHelperOleDb.ExecuteSql(strSql.ToString(), parameters);
            if (rows > 0)
            {
                return true;
            }
            else
            {
                return false;
            }
        }


        /// <summary>
        /// 得到一个对象实体
        /// </summary>
        public void GetModel(int ID)
        {
            StringBuilder strSql = new StringBuilder();
            strSql.Append("select ID,TaskId,Title,SubTitle,Keywords,Content,Summary,Source,CreateTime,Other,Url,IsDownload,IsPublish ");
            strSql.Append(" FROM [DownloadData] ");
            strSql.Append(" where ID=@ID ");
            OleDbParameter[] parameters = {
					new OleDbParameter("@ID", OleDbType.Integer,4)};
            parameters[0].Value = ID;

            DataSet ds = DbHelperOleDb.Query(strSql.ToString(), parameters);
            if (ds.Tables[0].Rows.Count > 0)
            {
                if (ds.Tables[0].Rows[0]["ID"] != null && ds.Tables[0].Rows[0]["ID"].ToString() != "")
                {
                    this.ID = int.Parse(ds.Tables[0].Rows[0]["ID"].ToString());
                }
                if (ds.Tables[0].Rows[0]["TaskId"] != null && ds.Tables[0].Rows[0]["TaskId"].ToString() != "")
                {
                    this.TaskId = int.Parse(ds.Tables[0].Rows[0]["TaskId"].ToString());
                }
                if (ds.Tables[0].Rows[0]["Title"] != null && ds.Tables[0].Rows[0]["Title"].ToString() != "")
                {
                    this.Title = ds.Tables[0].Rows[0]["Title"].ToString();
                }
                if (ds.Tables[0].Rows[0]["SubTitle"] != null && ds.Tables[0].Rows[0]["SubTitle"].ToString() != "")
                {
                    this.SubTitle = ds.Tables[0].Rows[0]["SubTitle"].ToString();
                }
                if (ds.Tables[0].Rows[0]["Keywords"] != null && ds.Tables[0].Rows[0]["Keywords"].ToString() != "")
                {
                    this.Keywords = ds.Tables[0].Rows[0]["Keywords"].ToString();
                }
                if (ds.Tables[0].Rows[0]["Content"] != null && ds.Tables[0].Rows[0]["Content"].ToString() != "")
                {
                    this.Content = ds.Tables[0].Rows[0]["Content"].ToString();
                }
                if (ds.Tables[0].Rows[0]["Summary"] != null && ds.Tables[0].Rows[0]["Summary"].ToString() != "")
                {
                    this.Summary = ds.Tables[0].Rows[0]["Summary"].ToString();
                }
                if (ds.Tables[0].Rows[0]["Source"] != null && ds.Tables[0].Rows[0]["Source"].ToString() != "")
                {
                    this.Source = ds.Tables[0].Rows[0]["Source"].ToString();
                }
                if (ds.Tables[0].Rows[0]["CreateTime"] != null && ds.Tables[0].Rows[0]["CreateTime"].ToString() != "")
                {
                    this.CreateTime = ds.Tables[0].Rows[0]["CreateTime"].ToString();
                }
                if (ds.Tables[0].Rows[0]["Other"] != null && ds.Tables[0].Rows[0]["Other"].ToString() != "")
                {
                    this.Other = ds.Tables[0].Rows[0]["Other"].ToString();
                }
                if (ds.Tables[0].Rows[0]["Url"] != null && ds.Tables[0].Rows[0]["Url"].ToString() != "")
                {
                    this.Url = ds.Tables[0].Rows[0]["Url"].ToString();
                }
                if (ds.Tables[0].Rows[0]["IsDownload"] != null && ds.Tables[0].Rows[0]["IsDownload"].ToString() != "")
                {
                    if ((ds.Tables[0].Rows[0]["IsDownload"].ToString() == "1") || (ds.Tables[0].Rows[0]["IsDownload"].ToString().ToLower() == "true"))
                    {
                        this.IsDownload = true;
                    }
                    else
                    {
                        this.IsDownload = false;
                    }
                }
                if (ds.Tables[0].Rows[0]["IsPublish"] != null && ds.Tables[0].Rows[0]["IsPublish"].ToString() != "")
                {
                    if ((ds.Tables[0].Rows[0]["IsPublish"].ToString() == "1") || (ds.Tables[0].Rows[0]["IsPublish"].ToString().ToLower() == "true"))
                    {
                        this.IsPublish = true;
                    }
                    else
                    {
                        this.IsPublish = false;
                    }
                }
            }
        }

        /// <summary>
        /// 获得数据列表
        /// </summary>
        public DataSet GetList(string strWhere)
        {
            StringBuilder strSql = new StringBuilder();
            strSql.Append("select * ");
            strSql.Append(" FROM [DownloadData] ");
            if (strWhere.Trim() != "")
            {
                strSql.Append(" where " + strWhere);
            }
            return DbHelperOleDb.Query(strSql.ToString());
        }

        #endregion  Method
    }
}

