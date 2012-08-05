using System;
using System.Data;
using System.Text;
using System.Data.OleDb;
using Maticsoft.DBUtility;//Please add references

namespace Jade.Model.Access
{
    /// <summary>
    /// 数据访问类:DownloadData
    /// </summary>
    public partial class DownloadDataDAL
    {
        public DownloadDataDAL()
        { }

        #region  Method
        /// <summary>
        /// 是否存在该记录
        /// </summary>
        public bool Exists(int ID)
        {
            StringBuilder strSql = new StringBuilder();
            strSql.Append("select count(1) from DownloadData");
            strSql.Append(" where ID=@ID");
            OleDbParameter[] parameters = {
					new OleDbParameter("@ID", OleDbType.Integer,4)
			};
            parameters[0].Value = ID;

            return DbHelperOleDb.Exists(strSql.ToString(), parameters);
        }


        /// <summary>
        /// 增加一条数据
        /// </summary>
        public bool Add(DownloadData model)
        {
            StringBuilder strSql = new StringBuilder();
            strSql.Append("insert into DownloadData(");
            strSql.Append("TaskId,Title,SubTitle,Keywords,news_source_name,news_template_file,news_top,news_guideimage,news_guideimage2,news_description,news_link,news_down,news_right,news_left,comment_url,news_video,news_keywords2,label_base,cmspinglun,bbspinglun,ISkfbm,kfbm_id,kfbm_link,ISgfbm,gfbm_id,gfbm_link,news_abs,Content,Summary,Source,CreateTime,Other,Url,DownloadTime,EditorUserName,IsEdit,EditTime,IsDownload,IsPublish,RemoteId)");
            strSql.Append(" values (");
            strSql.Append("@TaskId,@Title,@SubTitle,@Keywords,@news_source_name,@news_template_file,@news_top,@news_guideimage,@news_guideimage2,@news_description,@news_link,@news_down,@news_right,@news_left,@comment_url,@news_video,@news_keywords2,@label_base,@cmspinglun,@bbspinglun,@ISkfbm,@kfbm_id,@kfbm_link,@ISgfbm,@gfbm_id,@gfbm_link,@news_abs,@Content,@Summary,@Source,@CreateTime,@Other,@Url,@DownloadTime,@EditorUserName,@IsEdit,@EditTime,@IsDownload,@IsPublish,@RemoteId)");
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
					new OleDbParameter("@DownloadTime", OleDbType.Date),
					new OleDbParameter("@EditorUserName", OleDbType.VarChar,0),
					new OleDbParameter("@IsEdit", OleDbType.Boolean,1),
					new OleDbParameter("@EditTime", OleDbType.Date),
					new OleDbParameter("@IsDownload", OleDbType.Boolean,1),
					new OleDbParameter("@IsPublish", OleDbType.Boolean,1),
                    new OleDbParameter("@RemoteId", OleDbType.Integer,4)};
            parameters[0].Value = model.TaskId;
            parameters[1].Value = model.Title;
            parameters[2].Value = model.SubTitle;
            parameters[3].Value = model.Keywords;
            parameters[4].Value = model.news_source_name;
            parameters[5].Value = model.news_template_file;
            parameters[6].Value = model.news_top;
            parameters[7].Value = model.news_guideimage;
            parameters[8].Value = model.news_guideimage2;
            parameters[9].Value = model.news_description;
            parameters[10].Value = model.news_link;
            parameters[11].Value = model.news_down;
            parameters[12].Value = model.news_right;
            parameters[13].Value = model.news_left;
            parameters[14].Value = model.comment_url;
            parameters[15].Value = model.news_video;
            parameters[16].Value = model.news_keywords2;
            parameters[17].Value = model.label_base;
            parameters[18].Value = model.cmspinglun;
            parameters[19].Value = model.bbspinglun;
            parameters[20].Value = model.ISkfbm;
            parameters[21].Value = model.kfbm_id;
            parameters[22].Value = model.kfbm_link;
            parameters[23].Value = model.ISgfbm;
            parameters[24].Value = model.gfbm_id;
            parameters[25].Value = model.gfbm_link;
            parameters[26].Value = model.news_abs;
            parameters[27].Value = model.Content;
            parameters[28].Value = model.Summary;
            parameters[29].Value = model.Source;
            parameters[30].Value = model.CreateTime;
            parameters[31].Value = model.Other;
            parameters[32].Value = model.Url;
            parameters[33].Value = model.DownloadTime;
            parameters[34].Value = model.EditorUserName;
            parameters[35].Value = model.IsEdit;
            parameters[36].Value = model.EditTime;
            parameters[37].Value = model.IsDownload;
            parameters[38].Value = model.IsPublish;
            parameters[39].Value = model.RemoteId;
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
        /// 更新一条数据
        /// </summary>
        public bool Update(DownloadData model)
        {
            StringBuilder strSql = new StringBuilder();
            strSql.Append("update DownloadData set ");
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
            strSql.Append("DownloadTime=@DownloadTime,");
            strSql.Append("EditorUserName=@EditorUserName,");
            strSql.Append("IsEdit=@IsEdit,");
            strSql.Append("EditTime=@EditTime,");
            strSql.Append("IsDownload=@IsDownload,");
            strSql.Append("IsPublish=@IsPublish,");
            strSql.Append("RemoteId=@RemoteId");
            strSql.Append(" where ID=@ID");
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
					new OleDbParameter("@DownloadTime", OleDbType.Date),
					new OleDbParameter("@EditorUserName", OleDbType.VarChar,0),
					new OleDbParameter("@IsEdit", OleDbType.Boolean,1),
					new OleDbParameter("@EditTime", OleDbType.Date),
					new OleDbParameter("@IsDownload", OleDbType.Boolean,1),
					new OleDbParameter("@IsPublish", OleDbType.Boolean,1),
                    new OleDbParameter("@RemoteId", OleDbType.Integer,4),
					new OleDbParameter("@ID", OleDbType.Integer,4)};
            parameters[0].Value = model.TaskId;
            parameters[1].Value = model.Title;
            parameters[2].Value = model.SubTitle;
            parameters[3].Value = model.Keywords;
            parameters[4].Value = model.news_source_name;
            parameters[5].Value = model.news_template_file;
            parameters[6].Value = model.news_top;
            parameters[7].Value = model.news_guideimage;
            parameters[8].Value = model.news_guideimage2;
            parameters[9].Value = model.news_description;
            parameters[10].Value = model.news_link;
            parameters[11].Value = model.news_down;
            parameters[12].Value = model.news_right;
            parameters[13].Value = model.news_left;
            parameters[14].Value = model.comment_url;
            parameters[15].Value = model.news_video;
            parameters[16].Value = model.news_keywords2;
            parameters[17].Value = model.label_base;
            parameters[18].Value = model.cmspinglun;
            parameters[19].Value = model.bbspinglun;
            parameters[20].Value = model.ISkfbm;
            parameters[21].Value = model.kfbm_id;
            parameters[22].Value = model.kfbm_link;
            parameters[23].Value = model.ISgfbm;
            parameters[24].Value = model.gfbm_id;
            parameters[25].Value = model.gfbm_link;
            parameters[26].Value = model.news_abs;
            parameters[27].Value = model.Content;
            parameters[28].Value = model.Summary;
            parameters[29].Value = model.Source;
            parameters[30].Value = model.CreateTime;
            parameters[31].Value = model.Other;
            parameters[32].Value = model.Url;
            parameters[33].Value = model.DownloadTime;
            parameters[34].Value = model.EditorUserName;
            parameters[35].Value = model.IsEdit;
            parameters[36].Value = model.EditTime;
            parameters[37].Value = model.IsDownload;
            parameters[38].Value = model.IsPublish;
            parameters[39].Value = model.RemoteId;
            parameters[40].Value = model.ID;

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
            strSql.Append("delete from DownloadData ");
            strSql.Append(" where ID=@ID");
            OleDbParameter[] parameters = {
					new OleDbParameter("@ID", OleDbType.Integer,4)
			};
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
        /// 批量删除数据
        /// </summary>
        public bool DeleteList(string IDlist)
        {
            StringBuilder strSql = new StringBuilder();
            strSql.Append("delete from DownloadData ");
            strSql.Append(" where ID in (" + IDlist + ")  ");
            int rows = DbHelperOleDb.ExecuteSql(strSql.ToString());
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
        public DownloadData GetModel(int ID)
        {

            StringBuilder strSql = new StringBuilder();
            strSql.Append("select ID,TaskId,Title,SubTitle,Keywords,news_source_name,news_template_file,news_top,news_guideimage,news_guideimage2,news_description,news_link,news_down,news_right,news_left,comment_url,news_video,news_keywords2,label_base,cmspinglun,bbspinglun,ISkfbm,kfbm_id,kfbm_link,ISgfbm,gfbm_id,gfbm_link,news_abs,Content,Summary,Source,CreateTime,Other,Url,DownloadTime,EditorUserName,IsEdit,EditTime,IsDownload,IsPublish,RemoteId from DownloadData ");
            strSql.Append(" where ID=@ID");
            OleDbParameter[] parameters = {
					new OleDbParameter("@ID", OleDbType.Integer,4)
			};
            parameters[0].Value = ID;

            DataSet ds = DbHelperOleDb.Query(strSql.ToString(), parameters);
            if (ds.Tables[0].Rows.Count > 0)
            {
                return GetModel(ds.Tables[0].Rows[0]);
            }

            return null;
        }

        /// <summary>
        /// 得到一个对象实体
        /// </summary>
        public DownloadData GetModel(string url)
        {

            StringBuilder strSql = new StringBuilder();
            strSql.Append("select RemoteId,ID,TaskId,Title,SubTitle,Keywords,news_source_name,news_template_file,news_top,news_guideimage,news_guideimage2,news_description,news_link,news_down,news_right,news_left,comment_url,news_video,news_keywords2,label_base,cmspinglun,bbspinglun,ISkfbm,kfbm_id,kfbm_link,ISgfbm,gfbm_id,gfbm_link,news_abs,Content,Summary,Source,CreateTime,Other,Url,DownloadTime,EditorUserName,IsEdit,EditTime,IsDownload,IsPublish from DownloadData ");
            strSql.Append(" where Url=@Url");
            OleDbParameter[] parameters = {
					new OleDbParameter("@Url", OleDbType.VarChar,0)
			};
            parameters[0].Value = url;

            DataSet ds = DbHelperOleDb.Query(strSql.ToString(), parameters);

            if (ds.Tables[0].Rows.Count > 0)
            {
                return GetModel(ds.Tables[0].Rows[0]);
            }

            return null;

        }

        public DownloadData GetModel(DataRow row)
        {
            var model = new DownloadData();
            if (row["RemoteId"] != null && row["RemoteId"].ToString() != "")
            {
                model.RemoteId = int.Parse(row["RemoteId"].ToString());
            }
            if (row["ID"] != null && row["ID"].ToString() != "")
            {
                model.ID = int.Parse(row["ID"].ToString());
            }
            if (row["TaskId"] != null && row["TaskId"].ToString() != "")
            {
                model.TaskId = int.Parse(row["TaskId"].ToString());
            }
            if (row["Title"] != null && row["Title"].ToString() != "")
            {
                model.Title = row["Title"].ToString();
            }
            if (row["SubTitle"] != null && row["SubTitle"].ToString() != "")
            {
                model.SubTitle = row["SubTitle"].ToString();
            }
            if (row["Keywords"] != null && row["Keywords"].ToString() != "")
            {
                model.Keywords = row["Keywords"].ToString();
            }
            if (row["news_source_name"] != null && row["news_source_name"].ToString() != "")
            {
                model.news_source_name = row["news_source_name"].ToString();
            }
            if (row["news_template_file"] != null && row["news_template_file"].ToString() != "")
            {
                model.news_template_file = row["news_template_file"].ToString();
            }
            if (row["news_top"] != null && row["news_top"].ToString() != "")
            {
                model.news_top = row["news_top"].ToString();
            }
            if (row["news_guideimage"] != null && row["news_guideimage"].ToString() != "")
            {
                model.news_guideimage = row["news_guideimage"].ToString();
            }
            if (row["news_guideimage2"] != null && row["news_guideimage2"].ToString() != "")
            {
                model.news_guideimage2 = row["news_guideimage2"].ToString();
            }
            if (row["news_description"] != null && row["news_description"].ToString() != "")
            {
                model.news_description = row["news_description"].ToString();
            }
            if (row["news_link"] != null && row["news_link"].ToString() != "")
            {
                model.news_link = row["news_link"].ToString();
            }
            if (row["news_down"] != null && row["news_down"].ToString() != "")
            {
                model.news_down = row["news_down"].ToString();
            }
            if (row["news_right"] != null && row["news_right"].ToString() != "")
            {
                model.news_right = row["news_right"].ToString();
            }
            if (row["news_left"] != null && row["news_left"].ToString() != "")
            {
                model.news_left = row["news_left"].ToString();
            }
            if (row["comment_url"] != null && row["comment_url"].ToString() != "")
            {
                model.comment_url = row["comment_url"].ToString();
            }
            if (row["news_video"] != null && row["news_video"].ToString() != "")
            {
                model.news_video = row["news_video"].ToString();
            }
            if (row["news_keywords2"] != null && row["news_keywords2"].ToString() != "")
            {
                model.news_keywords2 = row["news_keywords2"].ToString();
            }
            if (row["label_base"] != null && row["label_base"].ToString() != "")
            {
                model.label_base = row["label_base"].ToString();
            }
            if (row["cmspinglun"] != null && row["cmspinglun"].ToString() != "")
            {
                if ((row["cmspinglun"].ToString() == "1") || (row["cmspinglun"].ToString().ToLower() == "true"))
                {
                    model.cmspinglun = true;
                }
                else
                {
                    model.cmspinglun = false;
                }
            }
            if (row["bbspinglun"] != null && row["bbspinglun"].ToString() != "")
            {
                if ((row["bbspinglun"].ToString() == "1") || (row["bbspinglun"].ToString().ToLower() == "true"))
                {
                    model.bbspinglun = true;
                }
                else
                {
                    model.bbspinglun = false;
                }
            }
            if (row["ISkfbm"] != null && row["ISkfbm"].ToString() != "")
            {
                if ((row["ISkfbm"].ToString() == "1") || (row["ISkfbm"].ToString().ToLower() == "true"))
                {
                    model.ISkfbm = true;
                }
                else
                {
                    model.ISkfbm = false;
                }
            }
            if (row["kfbm_id"] != null && row["kfbm_id"].ToString() != "")
            {
                model.kfbm_id = row["kfbm_id"].ToString();
            }
            if (row["kfbm_link"] != null && row["kfbm_link"].ToString() != "")
            {
                model.kfbm_link = row["kfbm_link"].ToString();
            }
            if (row["ISgfbm"] != null && row["ISgfbm"].ToString() != "")
            {
                if ((row["ISgfbm"].ToString() == "1") || (row["ISgfbm"].ToString().ToLower() == "true"))
                {
                    model.ISgfbm = true;
                }
                else
                {
                    model.ISgfbm = false;
                }
            }
            if (row["gfbm_id"] != null && row["gfbm_id"].ToString() != "")
            {
                model.gfbm_id = row["gfbm_id"].ToString();
            }
            if (row["gfbm_link"] != null && row["gfbm_link"].ToString() != "")
            {
                model.gfbm_link = row["gfbm_link"].ToString();
            }
            if (row["news_abs"] != null && row["news_abs"].ToString() != "")
            {
                model.news_abs = row["news_abs"].ToString();
            }
            if (row["Content"] != null && row["Content"].ToString() != "")
            {
                model.Content = row["Content"].ToString();
            }
            if (row["Summary"] != null && row["Summary"].ToString() != "")
            {
                model.Summary = row["Summary"].ToString();
            }
            if (row["Source"] != null && row["Source"].ToString() != "")
            {
                model.Source = row["Source"].ToString();
            }
            if (row["CreateTime"] != null && row["CreateTime"].ToString() != "")
            {
                model.CreateTime = row["CreateTime"].ToString();
            }
            if (row["Other"] != null && row["Other"].ToString() != "")
            {
                model.Other = row["Other"].ToString();
            }
            if (row["Url"] != null && row["Url"].ToString() != "")
            {
                model.Url = row["Url"].ToString();
            }
            if (row["DownloadTime"] != null && row["DownloadTime"].ToString() != "")
            {
                model.DownloadTime = DateTime.Parse(row["DownloadTime"].ToString());
            }
            if (row["EditorUserName"] != null && row["EditorUserName"].ToString() != "")
            {
                model.EditorUserName = row["EditorUserName"].ToString();
            }
            if (row["IsEdit"] != null && row["IsEdit"].ToString() != "")
            {
                if ((row["IsEdit"].ToString() == "1") || (row["IsEdit"].ToString().ToLower() == "true"))
                {
                    model.IsEdit = true;
                }
                else
                {
                    model.IsEdit = false;
                }
            }
            if (row["EditTime"] != null && row["EditTime"].ToString() != "")
            {
                model.EditTime = DateTime.Parse(row["EditTime"].ToString());
            }
            if (row["IsDownload"] != null && row["IsDownload"].ToString() != "")
            {
                if ((row["IsDownload"].ToString() == "1") || (row["IsDownload"].ToString().ToLower() == "true"))
                {
                    model.IsDownload = true;
                }
                else
                {
                    model.IsDownload = false;
                }
            }
            if (row["IsPublish"] != null && row["IsPublish"].ToString() != "")
            {
                if ((row["IsPublish"].ToString() == "1") || (row["IsPublish"].ToString().ToLower() == "true"))
                {
                    model.IsPublish = true;
                }
                else
                {
                    model.IsPublish = false;
                }
            }
            return model;
        }

        /// <summary>
        /// 获得数据列表
        /// </summary>
        public DataSet GetList(string strWhere)
        {
            StringBuilder strSql = new StringBuilder();
            strSql.Append("select RemoteId,ID,TaskId,Title,SubTitle,Keywords,news_source_name,news_template_file,news_top,news_guideimage,news_guideimage2,news_description,news_link,news_down,news_right,news_left,comment_url,news_video,news_keywords2,label_base,cmspinglun,bbspinglun,ISkfbm,kfbm_id,kfbm_link,ISgfbm,gfbm_id,gfbm_link,news_abs,Content,Summary,Source,CreateTime,Other,Url,DownloadTime,EditorUserName,IsEdit,EditTime,IsDownload,IsPublish ");
            strSql.Append(" FROM DownloadData ");
            if (strWhere.Trim() != "")
            {
                strSql.Append(" where " + strWhere);
            }
            return DbHelperOleDb.Query(strSql.ToString());
        }

        /// <summary>
        /// 获取记录总数
        /// </summary>
        public int GetRecordCount(string strWhere)
        {
            StringBuilder strSql = new StringBuilder();
            strSql.Append("select count(*) FROM DownloadData ");
            if (strWhere.Trim() != "")
            {
                strSql.Append(" where " + strWhere);
            }
            object obj = DbHelperOleDb.GetSingle(strSql.ToString());
            if (obj == null)
            {
                return 0;
            }
            else
            {
                return Convert.ToInt32(obj);
            }
        }
        /// <summary>
        /// 分页获取数据列表
        /// </summary>
        public DataSet GetListByPage(string strWhere, string orderby, int startIndex, int endIndex)
        {
            StringBuilder strSql = new StringBuilder();
            strSql.Append("SELECT * FROM ( ");
            strSql.Append(" SELECT ROW_NUMBER() OVER (");
            if (!string.IsNullOrEmpty(orderby.Trim()))
            {
                strSql.Append("order by T." + orderby);
            }
            else
            {
                strSql.Append("order by T.ID desc");
            }
            strSql.Append(")AS Row, T.*  from DownloadData T ");
            if (!string.IsNullOrEmpty(strWhere.Trim()))
            {
                strSql.Append(" WHERE " + strWhere);
            }
            strSql.Append(" ) TT");
            strSql.AppendFormat(" WHERE TT.Row between {0} and {1}", startIndex, endIndex);
            return DbHelperOleDb.Query(strSql.ToString());
        }

        /*
        /// <summary>
        /// 分页获取数据列表
        /// </summary>
        public DataSet GetList(int PageSize,int PageIndex,string strWhere)
        {
            OleDbParameter[] parameters = {
                    new OleDbParameter("@tblName", OleDbType.VarChar, 255),
                    new OleDbParameter("@fldName", OleDbType.VarChar, 255),
                    new OleDbParameter("@PageSize", OleDbType.Integer),
                    new OleDbParameter("@PageIndex", OleDbType.Integer),
                    new OleDbParameter("@IsReCount", OleDbType.Boolean),
                    new OleDbParameter("@OrderType", OleDbType.Boolean),
                    new OleDbParameter("@strWhere", OleDbType.VarChar,1000),
                    };
            parameters[0].Value = "DownloadData";
            parameters[1].Value = "ID";
            parameters[2].Value = PageSize;
            parameters[3].Value = PageIndex;
            parameters[4].Value = 0;
            parameters[5].Value = 0;
            parameters[6].Value = strWhere;	
            return DbHelperOleDb.RunProcedure("UP_GetRecordByPage",parameters,"ds");
        }*/

        #endregion  Method
    }
}

