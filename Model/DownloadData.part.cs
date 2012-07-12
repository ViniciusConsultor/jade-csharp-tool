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
        /// <summary>
        /// ID
        /// </summary>		
        private int _id;
        public int ID
        {
            get { return _id; }
            set { _id = value; }
        }
        /// <summary>
        /// news_guideimage2
        /// </summary>		
        private string _news_guideimage2 = "";
        public string news_guideimage2
        {
            get { return _news_guideimage2; }
            set { _news_guideimage2 = value; }
        }
        /// <summary>
        /// news_description
        /// </summary>		
        private string _news_description = "";
        public string news_description
        {
            get { return _news_description; }
            set { _news_description = value; }
        }
        /// <summary>
        /// news_link
        /// </summary>		
        private string _news_link = "";
        public string news_link
        {
            get { return _news_link; }
            set { _news_link = value; }
        }
        /// <summary>
        /// news_down
        /// </summary>		
        private string _news_down = "";
        public string news_down
        {
            get { return _news_down; }
            set { _news_down = value; }
        }
        /// <summary>
        /// news_right
        /// </summary>		
        private string _news_right = "";
        public string news_right
        {
            get { return _news_right; }
            set { _news_right = value; }
        }
        /// <summary>
        /// news_left
        /// </summary>		
        private string _news_left = "";
        public string news_left
        {
            get { return _news_left; }
            set { _news_left = value; }
        }
        /// <summary>
        /// comment_url
        /// </summary>		
        private string _comment_url = "";
        public string comment_url
        {
            get { return _comment_url; }
            set { _comment_url = value; }
        }
        /// <summary>
        /// news_video
        /// </summary>		
        private string _news_video = "";
        public string news_video
        {
            get { return _news_video; }
            set { _news_video = value; }
        }
        /// <summary>
        /// news_keywords2
        /// </summary>		
        private string _news_keywords2 = "";
        public string news_keywords2
        {
            get { return _news_keywords2; }
            set { _news_keywords2 = value; }
        }
        /// <summary>
        /// label_base
        /// </summary>		
        private string _label_base = "";
        public string label_base
        {
            get { return _label_base; }
            set { _label_base = value; }
        }
        /// <summary>
        /// TaskId
        /// </summary>		
        private int _taskid;
        public int TaskId
        {
            get { return _taskid; }
            set { _taskid = value; }
        }
        /// <summary>
        /// cmspinglun
        /// </summary>		
        private bool _cmspinglun;
        public bool cmspinglun
        {
            get { return _cmspinglun; }
            set { _cmspinglun = value; }
        }
        /// <summary>
        /// bbspinglun
        /// </summary>		
        private bool _bbspinglun;
        public bool bbspinglun
        {
            get { return _bbspinglun; }
            set { _bbspinglun = value; }
        }
        /// <summary>
        /// ISkfbm
        /// </summary>		
        private bool _iskfbm;
        public bool ISkfbm
        {
            get { return _iskfbm; }
            set { _iskfbm = value; }
        }
        /// <summary>
        /// kfbm_id
        /// </summary>		
        private string _kfbm_id = "";
        public string kfbm_id
        {
            get { return _kfbm_id; }
            set { _kfbm_id = value; }
        }

        /// <summary>
        /// kfbm_link
        /// </summary>		
        private string _kfbm_link = "";
        public string kfbm_link
        {
            get { return _kfbm_link; }
            set { _kfbm_link = value; }
        }

        /// <summary>
        /// ISgfbm
        /// </summary>		
        private bool _isgfbm;
        public bool ISgfbm
        {
            get { return _isgfbm; }
            set { _isgfbm = value; }
        }

        /// <summary>
        /// gfbm_id
        /// </summary>		
        private string _gfbm_id = "";
        public string gfbm_id
        {
            get { return _gfbm_id; }
            set { _gfbm_id = value; }
        }
        /// <summary>
        /// gfbm_link
        /// </summary>		
        private string _gfbm_link = "";
        public string gfbm_link
        {
            get { return _gfbm_link; }
            set { _gfbm_link = value; }
        }
        /// <summary>
        /// news_abs
        /// </summary>		
        private string _news_abs = "";
        public string news_abs
        {
            get { return _news_abs; }
            set { _news_abs = value; }
        }
        /// <summary>
        /// Content
        /// </summary>		
        private string _content = "";
        public string Content
        {
            get { return _content; }
            set { _content = value; }
        }
        /// <summary>
        /// Title
        /// </summary>		
        private string _title = "";
        public string Title
        {
            get { return _title; }
            set { _title = value; }
        }
        /// <summary>
        /// Summary
        /// </summary>		
        private string _summary = "";
        public string Summary
        {
            get { return _summary; }
            set { _summary = value; }
        }
        /// <summary>
        /// Source
        /// </summary>		
        private string _source = "";
        public string Source
        {
            get { return _source; }
            set { _source = value; }
        }
        /// <summary>
        /// CreateTime
        /// </summary>		
        private string _createtime = "";
        public string CreateTime
        {
            get { return _createtime; }
            set { _createtime = value; }
        }
        /// <summary>
        /// Other
        /// </summary>		
        private string _other = "";
        public string Other
        {
            get { return _other; }
            set { _other = value; }
        }
        /// <summary>
        /// Url
        /// </summary>		
        private string _url = "";
        public string Url
        {
            get { return _url; }
            set { _url = value; }
        }
        /// <summary>
        /// IsDownload
        /// </summary>		
        private bool _isdownload;
        public bool IsDownload
        {
            get { return _isdownload; }
            set { _isdownload = value; }
        }
        /// <summary>
        /// IsPublish
        /// </summary>		
        private bool _ispublish;
        public bool IsPublish
        {
            get { return _ispublish; }
            set { _ispublish = value; }
        }
        /// <summary>
        /// SubTitle
        /// </summary>		
        private string _subtitle = "";
        public string SubTitle
        {
            get { return _subtitle; }
            set { _subtitle = value; }
        }
        /// <summary>
        /// Keywords
        /// </summary>		
        private string _keywords = "";
        public string Keywords
        {
            get { return _keywords; }
            set { _keywords = value; }
        }
        /// <summary>
        /// news_source_name
        /// </summary>		
        private string _news_source_name = "";
        public string news_source_name
        {
            get { return _news_source_name; }
            set { _news_source_name = value; }
        }
        /// <summary>
        /// news_template_file
        /// </summary>		
        private string _news_template_file = "";
        public string news_template_file
        {
            get { return _news_template_file; }
            set { _news_template_file = value; }
        }
        /// <summary>
        /// news_top
        /// </summary>		
        private string _news_top = "";
        public string news_top
        {
            get { return _news_top; }
            set { _news_top = value; }
        }
        /// <summary>
        /// news_guideimage
        /// </summary>		
        private string _news_guideimage = "";
        public string news_guideimage
        {
            get { return _news_guideimage; }
            set { _news_guideimage = value; }
        }
        #endregion



        #region  Method

        /// <summary>
        /// 得到一个对象实体
        /// </summary>
        public DownloadData(int ID)
        {
            StringBuilder strSql = new StringBuilder();
            strSql.Append("select ID,TaskId,Title,SubTitle,Keywords,news_source_name,news_template_file,news_top,news_guideimage,news_guideimage2,news_description,news_link,news_down,news_right,news_left,comment_url,news_video,news_keywords2,label_base,cmspinglun,bbspinglun,ISkfbm,kfbm_id,kfbm_link,ISgfbm,gfbm_id,gfbm_link,news_abs,Content,Summary,Source,CreateTime,Other,Url,IsDownload,IsPublish ");
            strSql.Append(" FROM [DownloadData] ");
            strSql.Append(" where ID=@ID ");
            OleDbParameter[] parameters = {
					new OleDbParameter("@ID", OleDbType.Integer,4)};
            parameters[0].Value = ID;

            DataSet ds = DbHelperOleDb.Query(strSql.ToString(), parameters);
            GetModelFromDataSet(ds);
        }

        private void GetModelFromDataSet(DataSet ds)
        {
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
                if (ds.Tables[0].Rows[0]["news_source_name"] != null && ds.Tables[0].Rows[0]["news_source_name"].ToString() != "")
                {
                    this.news_source_name = ds.Tables[0].Rows[0]["news_source_name"].ToString();
                }
                if (ds.Tables[0].Rows[0]["news_template_file"] != null && ds.Tables[0].Rows[0]["news_template_file"].ToString() != "")
                {
                    this.news_template_file = ds.Tables[0].Rows[0]["news_template_file"].ToString();
                }
                if (ds.Tables[0].Rows[0]["news_top"] != null && ds.Tables[0].Rows[0]["news_top"].ToString() != "")
                {
                    this.news_top = ds.Tables[0].Rows[0]["news_top"].ToString();
                }
                if (ds.Tables[0].Rows[0]["news_guideimage"] != null && ds.Tables[0].Rows[0]["news_guideimage"].ToString() != "")
                {
                    this.news_guideimage = ds.Tables[0].Rows[0]["news_guideimage"].ToString();
                }
                if (ds.Tables[0].Rows[0]["news_guideimage2"] != null && ds.Tables[0].Rows[0]["news_guideimage2"].ToString() != "")
                {
                    this.news_guideimage2 = ds.Tables[0].Rows[0]["news_guideimage2"].ToString();
                }
                if (ds.Tables[0].Rows[0]["news_description"] != null && ds.Tables[0].Rows[0]["news_description"].ToString() != "")
                {
                    this.news_description = ds.Tables[0].Rows[0]["news_description"].ToString();
                }
                if (ds.Tables[0].Rows[0]["news_link"] != null && ds.Tables[0].Rows[0]["news_link"].ToString() != "")
                {
                    this.news_link = ds.Tables[0].Rows[0]["news_link"].ToString();
                }
                if (ds.Tables[0].Rows[0]["news_down"] != null && ds.Tables[0].Rows[0]["news_down"].ToString() != "")
                {
                    this.news_down = ds.Tables[0].Rows[0]["news_down"].ToString();
                }
                if (ds.Tables[0].Rows[0]["news_right"] != null && ds.Tables[0].Rows[0]["news_right"].ToString() != "")
                {
                    this.news_right = ds.Tables[0].Rows[0]["news_right"].ToString();
                }
                if (ds.Tables[0].Rows[0]["news_left"] != null && ds.Tables[0].Rows[0]["news_left"].ToString() != "")
                {
                    this.news_left = ds.Tables[0].Rows[0]["news_left"].ToString();
                }
                if (ds.Tables[0].Rows[0]["comment_url"] != null && ds.Tables[0].Rows[0]["comment_url"].ToString() != "")
                {
                    this.comment_url = ds.Tables[0].Rows[0]["comment_url"].ToString();
                }
                if (ds.Tables[0].Rows[0]["news_video"] != null && ds.Tables[0].Rows[0]["news_video"].ToString() != "")
                {
                    this.news_video = ds.Tables[0].Rows[0]["news_video"].ToString();
                }
                if (ds.Tables[0].Rows[0]["news_keywords2"] != null && ds.Tables[0].Rows[0]["news_keywords2"].ToString() != "")
                {
                    this.news_keywords2 = ds.Tables[0].Rows[0]["news_keywords2"].ToString();
                }
                if (ds.Tables[0].Rows[0]["label_base"] != null && ds.Tables[0].Rows[0]["label_base"].ToString() != "")
                {
                    this.label_base = ds.Tables[0].Rows[0]["label_base"].ToString();
                }
                if (ds.Tables[0].Rows[0]["cmspinglun"] != null && ds.Tables[0].Rows[0]["cmspinglun"].ToString() != "")
                {
                    if ((ds.Tables[0].Rows[0]["cmspinglun"].ToString() == "1") || (ds.Tables[0].Rows[0]["cmspinglun"].ToString().ToLower() == "true"))
                    {
                        this.cmspinglun = true;
                    }
                    else
                    {
                        this.cmspinglun = false;
                    }
                }
                if (ds.Tables[0].Rows[0]["bbspinglun"] != null && ds.Tables[0].Rows[0]["bbspinglun"].ToString() != "")
                {
                    if ((ds.Tables[0].Rows[0]["bbspinglun"].ToString() == "1") || (ds.Tables[0].Rows[0]["bbspinglun"].ToString().ToLower() == "true"))
                    {
                        this.bbspinglun = true;
                    }
                    else
                    {
                        this.bbspinglun = false;
                    }
                }
                if (ds.Tables[0].Rows[0]["ISkfbm"] != null && ds.Tables[0].Rows[0]["ISkfbm"].ToString() != "")
                {
                    if ((ds.Tables[0].Rows[0]["ISkfbm"].ToString() == "1") || (ds.Tables[0].Rows[0]["ISkfbm"].ToString().ToLower() == "true"))
                    {
                        this.ISkfbm = true;
                    }
                    else
                    {
                        this.ISkfbm = false;
                    }
                }
                if (ds.Tables[0].Rows[0]["kfbm_id"] != null && ds.Tables[0].Rows[0]["kfbm_id"].ToString() != "")
                {
                    this.kfbm_id = ds.Tables[0].Rows[0]["kfbm_id"].ToString();
                }
                if (ds.Tables[0].Rows[0]["kfbm_link"] != null && ds.Tables[0].Rows[0]["kfbm_link"].ToString() != "")
                {
                    this.kfbm_link = ds.Tables[0].Rows[0]["kfbm_link"].ToString();
                }
                if (ds.Tables[0].Rows[0]["ISgfbm"] != null && ds.Tables[0].Rows[0]["ISgfbm"].ToString() != "")
                {
                    if ((ds.Tables[0].Rows[0]["ISgfbm"].ToString() == "1") || (ds.Tables[0].Rows[0]["ISgfbm"].ToString().ToLower() == "true"))
                    {
                        this.ISgfbm = true;
                    }
                    else
                    {
                        this.ISgfbm = false;
                    }
                }
                if (ds.Tables[0].Rows[0]["gfbm_id"] != null && ds.Tables[0].Rows[0]["gfbm_id"].ToString() != "")
                {
                    this.gfbm_id = ds.Tables[0].Rows[0]["gfbm_id"].ToString();
                }
                if (ds.Tables[0].Rows[0]["gfbm_link"] != null && ds.Tables[0].Rows[0]["gfbm_link"].ToString() != "")
                {
                    this.gfbm_link = ds.Tables[0].Rows[0]["gfbm_link"].ToString();
                }
                if (ds.Tables[0].Rows[0]["news_abs"] != null && ds.Tables[0].Rows[0]["news_abs"].ToString() != "")
                {
                    this.news_abs = ds.Tables[0].Rows[0]["news_abs"].ToString();
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
            strSql.Append("TaskId,Title,SubTitle,Keywords,news_source_name,news_template_file,news_top,news_guideimage,news_guideimage2,news_description,news_link,news_down,news_right,news_left,comment_url,news_video,news_keywords2,label_base,cmspinglun,bbspinglun,ISkfbm,kfbm_id,kfbm_link,ISgfbm,gfbm_id,gfbm_link,news_abs,Content,Summary,Source,CreateTime,Other,Url,IsDownload,IsPublish)");
            strSql.Append(" values (");
            strSql.Append("@TaskId,@Title,@SubTitle,@Keywords,@news_source_name,@news_template_file,@news_top,@news_guideimage,@news_guideimage2,@news_description,@news_link,@news_down,@news_right,@news_left,@comment_url,@news_video,@news_keywords2,@label_base,@cmspinglun,@bbspinglun,@ISkfbm,@kfbm_id,@kfbm_link,@ISgfbm,@gfbm_id,@gfbm_link,@news_abs,@Content,@Summary,@Source,@CreateTime,@Other,@Url,@IsDownload,@IsPublish)");
            OleDbParameter[] parameters = {
					new OleDbParameter("@TaskId", OleDbType.Integer,4),
					new OleDbParameter("@Title", OleDbType.VarChar,0),
					new OleDbParameter("@SubTitle", OleDbType.VarChar,0),
					new OleDbParameter("@Keywords", OleDbType.VarChar,0),
					new OleDbParameter("@news_source_name", OleDbType.VarChar,0),
					new OleDbParameter("@news_template_file", OleDbType.VarChar,0),
					new OleDbParameter("@news_top", OleDbType.VarChar,0),
					new OleDbParameter("@news_guideimage", OleDbType.VarChar,0),
					new OleDbParameter("@news_guideimage2", OleDbType.VarChar,0),
					new OleDbParameter("@news_description", OleDbType.VarChar,0),
					new OleDbParameter("@news_link", OleDbType.VarChar,0),
					new OleDbParameter("@news_down", OleDbType.VarChar,0),
					new OleDbParameter("@news_right", OleDbType.VarChar,0),
					new OleDbParameter("@news_left", OleDbType.VarChar,0),
					new OleDbParameter("@comment_url", OleDbType.VarChar,0),
					new OleDbParameter("@news_video", OleDbType.VarChar,0),
					new OleDbParameter("@news_keywords2", OleDbType.VarChar,0),
					new OleDbParameter("@label_base", OleDbType.VarChar,0),
					new OleDbParameter("@cmspinglun", OleDbType.Boolean,1),
					new OleDbParameter("@bbspinglun", OleDbType.Boolean,1),
					new OleDbParameter("@ISkfbm", OleDbType.Boolean,1),
					new OleDbParameter("@kfbm_id", OleDbType.VarChar,0),
					new OleDbParameter("@kfbm_link", OleDbType.VarChar,0),
					new OleDbParameter("@ISgfbm", OleDbType.Boolean,1),
					new OleDbParameter("@gfbm_id", OleDbType.VarChar,0),
					new OleDbParameter("@gfbm_link", OleDbType.VarChar,0),
					new OleDbParameter("@news_abs", OleDbType.VarChar,0),
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
            parameters[4].Value = news_source_name;
            parameters[5].Value = news_template_file;
            parameters[6].Value = news_top;
            parameters[7].Value = news_guideimage;
            parameters[8].Value = news_guideimage2;
            parameters[9].Value = news_description;
            parameters[10].Value = news_link;
            parameters[11].Value = news_down;
            parameters[12].Value = news_right;
            parameters[13].Value = news_left;
            parameters[14].Value = comment_url;
            parameters[15].Value = news_video;
            parameters[16].Value = news_keywords2;
            parameters[17].Value = label_base;
            parameters[18].Value = cmspinglun;
            parameters[19].Value = bbspinglun;
            parameters[20].Value = ISkfbm;
            parameters[21].Value = kfbm_id;
            parameters[22].Value = kfbm_link;
            parameters[23].Value = ISgfbm;
            parameters[24].Value = gfbm_id;
            parameters[25].Value = gfbm_link;
            parameters[26].Value = news_abs;
            parameters[27].Value = Content;
            parameters[28].Value = Summary;
            parameters[29].Value = Source;
            parameters[30].Value = CreateTime;
            parameters[31].Value = Other;
            parameters[32].Value = Url;
            parameters[33].Value = IsDownload;
            parameters[34].Value = IsPublish;

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
            strSql.Append("news_source_name=@news_source_name,");
            strSql.Append("news_template_file=@news_template_file,");
            strSql.Append("news_top=@news_top,");
            strSql.Append("news_guideimage=@news_guideimage,");
            strSql.Append("news_guideimage2=@news_guideimage2,");
            strSql.Append("news_description=@news_description,");
            strSql.Append("news_link=@news_link,");
            strSql.Append("news_down=@news_down,");
            strSql.Append("news_right=@news_right,");
            strSql.Append("news_left=@news_left,");
            strSql.Append("comment_url=@comment_url,");
            strSql.Append("news_video=@news_video,");
            strSql.Append("news_keywords2=@news_keywords2,");
            strSql.Append("label_base=@label_base,");
            strSql.Append("cmspinglun=@cmspinglun,");
            strSql.Append("bbspinglun=@bbspinglun,");
            strSql.Append("ISkfbm=@ISkfbm,");
            strSql.Append("kfbm_id=@kfbm_id,");
            strSql.Append("kfbm_link=@kfbm_link,");
            strSql.Append("ISgfbm=@ISgfbm,");
            strSql.Append("gfbm_id=@gfbm_id,");
            strSql.Append("gfbm_link=@gfbm_link,");
            strSql.Append("news_abs=@news_abs,");
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
					new OleDbParameter("@news_source_name", OleDbType.VarChar,0),
					new OleDbParameter("@news_template_file", OleDbType.VarChar,0),
					new OleDbParameter("@news_top", OleDbType.VarChar,0),
					new OleDbParameter("@news_guideimage", OleDbType.VarChar,0),
					new OleDbParameter("@news_guideimage2", OleDbType.VarChar,0),
					new OleDbParameter("@news_description", OleDbType.VarChar,0),
					new OleDbParameter("@news_link", OleDbType.VarChar,0),
					new OleDbParameter("@news_down", OleDbType.VarChar,0),
					new OleDbParameter("@news_right", OleDbType.VarChar,0),
					new OleDbParameter("@news_left", OleDbType.VarChar,0),
					new OleDbParameter("@comment_url", OleDbType.VarChar,0),
					new OleDbParameter("@news_video", OleDbType.VarChar,0),
					new OleDbParameter("@news_keywords2", OleDbType.VarChar,0),
					new OleDbParameter("@label_base", OleDbType.VarChar,0),
					new OleDbParameter("@cmspinglun", OleDbType.Boolean,1),
					new OleDbParameter("@bbspinglun", OleDbType.Boolean,1),
					new OleDbParameter("@ISkfbm", OleDbType.Boolean,1),
					new OleDbParameter("@kfbm_id", OleDbType.VarChar,0),
					new OleDbParameter("@kfbm_link", OleDbType.VarChar,0),
					new OleDbParameter("@ISgfbm", OleDbType.Boolean,1),
					new OleDbParameter("@gfbm_id", OleDbType.VarChar,0),
					new OleDbParameter("@gfbm_link", OleDbType.VarChar,0),
					new OleDbParameter("@news_abs", OleDbType.VarChar,0),
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
            parameters[4].Value = news_source_name;
            parameters[5].Value = news_template_file;
            parameters[6].Value = news_top;
            parameters[7].Value = news_guideimage;
            parameters[8].Value = news_guideimage2;
            parameters[9].Value = news_description;
            parameters[10].Value = news_link;
            parameters[11].Value = news_down;
            parameters[12].Value = news_right;
            parameters[13].Value = news_left;
            parameters[14].Value = comment_url;
            parameters[15].Value = news_video;
            parameters[16].Value = news_keywords2;
            parameters[17].Value = label_base;
            parameters[18].Value = cmspinglun;
            parameters[19].Value = bbspinglun;
            parameters[20].Value = ISkfbm;
            parameters[21].Value = kfbm_id;
            parameters[22].Value = kfbm_link;
            parameters[23].Value = ISgfbm;
            parameters[24].Value = gfbm_id;
            parameters[25].Value = gfbm_link;
            parameters[26].Value = news_abs;
            parameters[27].Value = Content;
            parameters[28].Value = Summary;
            parameters[29].Value = Source;
            parameters[30].Value = CreateTime;
            parameters[31].Value = Other;
            parameters[32].Value = Url;
            parameters[33].Value = IsDownload;
            parameters[34].Value = IsPublish;
            parameters[35].Value = ID;

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
            strSql.Append("select ID,TaskId,Title,SubTitle,Keywords,news_source_name,news_template_file,news_top,news_guideimage,news_guideimage2,news_description,news_link,news_down,news_right,news_left,comment_url,news_video,news_keywords2,label_base,cmspinglun,bbspinglun,ISkfbm,kfbm_id,kfbm_link,ISgfbm,gfbm_id,gfbm_link,news_abs,Content,Summary,Source,CreateTime,Other,Url,IsDownload,IsPublish ");
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
                if (ds.Tables[0].Rows[0]["news_source_name"] != null && ds.Tables[0].Rows[0]["news_source_name"].ToString() != "")
                {
                    this.news_source_name = ds.Tables[0].Rows[0]["news_source_name"].ToString();
                }
                if (ds.Tables[0].Rows[0]["news_template_file"] != null && ds.Tables[0].Rows[0]["news_template_file"].ToString() != "")
                {
                    this.news_template_file = ds.Tables[0].Rows[0]["news_template_file"].ToString();
                }
                if (ds.Tables[0].Rows[0]["news_top"] != null && ds.Tables[0].Rows[0]["news_top"].ToString() != "")
                {
                    this.news_top = ds.Tables[0].Rows[0]["news_top"].ToString();
                }
                if (ds.Tables[0].Rows[0]["news_guideimage"] != null && ds.Tables[0].Rows[0]["news_guideimage"].ToString() != "")
                {
                    this.news_guideimage = ds.Tables[0].Rows[0]["news_guideimage"].ToString();
                }
                if (ds.Tables[0].Rows[0]["news_guideimage2"] != null && ds.Tables[0].Rows[0]["news_guideimage2"].ToString() != "")
                {
                    this.news_guideimage2 = ds.Tables[0].Rows[0]["news_guideimage2"].ToString();
                }
                if (ds.Tables[0].Rows[0]["news_description"] != null && ds.Tables[0].Rows[0]["news_description"].ToString() != "")
                {
                    this.news_description = ds.Tables[0].Rows[0]["news_description"].ToString();
                }
                if (ds.Tables[0].Rows[0]["news_link"] != null && ds.Tables[0].Rows[0]["news_link"].ToString() != "")
                {
                    this.news_link = ds.Tables[0].Rows[0]["news_link"].ToString();
                }
                if (ds.Tables[0].Rows[0]["news_down"] != null && ds.Tables[0].Rows[0]["news_down"].ToString() != "")
                {
                    this.news_down = ds.Tables[0].Rows[0]["news_down"].ToString();
                }
                if (ds.Tables[0].Rows[0]["news_right"] != null && ds.Tables[0].Rows[0]["news_right"].ToString() != "")
                {
                    this.news_right = ds.Tables[0].Rows[0]["news_right"].ToString();
                }
                if (ds.Tables[0].Rows[0]["news_left"] != null && ds.Tables[0].Rows[0]["news_left"].ToString() != "")
                {
                    this.news_left = ds.Tables[0].Rows[0]["news_left"].ToString();
                }
                if (ds.Tables[0].Rows[0]["comment_url"] != null && ds.Tables[0].Rows[0]["comment_url"].ToString() != "")
                {
                    this.comment_url = ds.Tables[0].Rows[0]["comment_url"].ToString();
                }
                if (ds.Tables[0].Rows[0]["news_video"] != null && ds.Tables[0].Rows[0]["news_video"].ToString() != "")
                {
                    this.news_video = ds.Tables[0].Rows[0]["news_video"].ToString();
                }
                if (ds.Tables[0].Rows[0]["news_keywords2"] != null && ds.Tables[0].Rows[0]["news_keywords2"].ToString() != "")
                {
                    this.news_keywords2 = ds.Tables[0].Rows[0]["news_keywords2"].ToString();
                }
                if (ds.Tables[0].Rows[0]["label_base"] != null && ds.Tables[0].Rows[0]["label_base"].ToString() != "")
                {
                    this.label_base = ds.Tables[0].Rows[0]["label_base"].ToString();
                }
                if (ds.Tables[0].Rows[0]["cmspinglun"] != null && ds.Tables[0].Rows[0]["cmspinglun"].ToString() != "")
                {
                    if ((ds.Tables[0].Rows[0]["cmspinglun"].ToString() == "1") || (ds.Tables[0].Rows[0]["cmspinglun"].ToString().ToLower() == "true"))
                    {
                        this.cmspinglun = true;
                    }
                    else
                    {
                        this.cmspinglun = false;
                    }
                }
                if (ds.Tables[0].Rows[0]["bbspinglun"] != null && ds.Tables[0].Rows[0]["bbspinglun"].ToString() != "")
                {
                    if ((ds.Tables[0].Rows[0]["bbspinglun"].ToString() == "1") || (ds.Tables[0].Rows[0]["bbspinglun"].ToString().ToLower() == "true"))
                    {
                        this.bbspinglun = true;
                    }
                    else
                    {
                        this.bbspinglun = false;
                    }
                }
                if (ds.Tables[0].Rows[0]["ISkfbm"] != null && ds.Tables[0].Rows[0]["ISkfbm"].ToString() != "")
                {
                    if ((ds.Tables[0].Rows[0]["ISkfbm"].ToString() == "1") || (ds.Tables[0].Rows[0]["ISkfbm"].ToString().ToLower() == "true"))
                    {
                        this.ISkfbm = true;
                    }
                    else
                    {
                        this.ISkfbm = false;
                    }
                }
                if (ds.Tables[0].Rows[0]["kfbm_id"] != null && ds.Tables[0].Rows[0]["kfbm_id"].ToString() != "")
                {
                    this.kfbm_id = ds.Tables[0].Rows[0]["kfbm_id"].ToString();
                }
                if (ds.Tables[0].Rows[0]["kfbm_link"] != null && ds.Tables[0].Rows[0]["kfbm_link"].ToString() != "")
                {
                    this.kfbm_link = ds.Tables[0].Rows[0]["kfbm_link"].ToString();
                }
                if (ds.Tables[0].Rows[0]["ISgfbm"] != null && ds.Tables[0].Rows[0]["ISgfbm"].ToString() != "")
                {
                    if ((ds.Tables[0].Rows[0]["ISgfbm"].ToString() == "1") || (ds.Tables[0].Rows[0]["ISgfbm"].ToString().ToLower() == "true"))
                    {
                        this.ISgfbm = true;
                    }
                    else
                    {
                        this.ISgfbm = false;
                    }
                }
                if (ds.Tables[0].Rows[0]["gfbm_id"] != null && ds.Tables[0].Rows[0]["gfbm_id"].ToString() != "")
                {
                    this.gfbm_id = ds.Tables[0].Rows[0]["gfbm_id"].ToString();
                }
                if (ds.Tables[0].Rows[0]["gfbm_link"] != null && ds.Tables[0].Rows[0]["gfbm_link"].ToString() != "")
                {
                    this.gfbm_link = ds.Tables[0].Rows[0]["gfbm_link"].ToString();
                }
                if (ds.Tables[0].Rows[0]["news_abs"] != null && ds.Tables[0].Rows[0]["news_abs"].ToString() != "")
                {
                    this.news_abs = ds.Tables[0].Rows[0]["news_abs"].ToString();
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

