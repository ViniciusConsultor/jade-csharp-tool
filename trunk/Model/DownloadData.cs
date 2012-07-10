
using System;
using System.Data;
using System.Linq;
using System.Text;
using System.Data.OleDb;
using Maticsoft.DBUtility;
using System.Collections.Generic;//Please add references
namespace HFBBS.Model
{

    public partial class DownloadData
    {
        public DownloadData(int taskId, string url)
            : this()
        {
            TaskId = taskId;
            Url = url;
            _title = "";
            _content = "";
            _summary = "";
            _source = "";
            _createtime = "";
            _other = "";
        }
      

        /// <summary>
        /// 得到一个对象实体
        /// </summary>
        public DownloadData(string url)
        {
            StringBuilder strSql = new StringBuilder();
            strSql.Append("select ID,TaskId,Title,Content,Summary,Source,CreateTime,Other,Url,IsDownload,IsPublish ");
            strSql.Append(" FROM [DownloadData] ");
            strSql.Append(" where Url=@Url ");
            OleDbParameter[] parameters = {
					new OleDbParameter("@Url", OleDbType.VarChar)};
            parameters[0].Value = url;

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
        public static List<string> GetUrlList(int taskId)
        {
            var result = new List<string>();
            StringBuilder strSql = new StringBuilder();
            strSql.Append("select Url ");
            strSql.Append(" FROM [DownloadData] ");
            strSql.Append(" where TaskId=@TaskId ");
            OleDbParameter[] parameters = {
					new OleDbParameter("@TaskId", OleDbType.Integer)};
            parameters[0].Value = taskId;
            var dataSet = DbHelperOleDb.Query(strSql.ToString(), parameters);
            if (dataSet.Tables.Count > 0)
            {
                foreach (DataRow row in dataSet.Tables[0].Rows)
                {
                    result.Add(row["Url"].ToString());
                }

            }

            return result;
        }

        /// <summary>
        /// 获得数据列表
        /// </summary>
        public static List<string> GetUnFetchedUrlList(int taskId)
        {
            var result = new List<string>();
            StringBuilder strSql = new StringBuilder();
            strSql.Append("select Url ");
            strSql.Append(" FROM [DownloadData] ");
            strSql.Append(" where TaskId=@TaskId AND IsDownload = 0");
            OleDbParameter[] parameters = {
					new OleDbParameter("@TaskId", OleDbType.Integer)};
            parameters[0].Value = taskId;
            var dataSet = DbHelperOleDb.Query(strSql.ToString(), parameters);
            if (dataSet.Tables.Count > 0)
            {
                foreach (DataRow row in dataSet.Tables[0].Rows)
                {
                    result.Add(row["Url"].ToString());
                }

            }

            return result;
        }

    }
}



