using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Maticsoft.DBUtility;
using System.Data.OleDb;
using System.Data;

namespace Jade.Model.Access
{
    public partial class DownloadDataDAL : Jade.DAL.IDownloadDataDAL
    {

        #region IDownloadDataDAL 成员

        public void Add(IDownloadData data)
        {
            this.Add(data as DownloadData);
        }

        public void Delete(IDownloadData data)
        {
            this.Delete((data as DownloadData).ID);
        }

        public IDownloadData Get(int id)
        {
            return this.GetModel(id);
        }

        public IDownloadData Get(string url)
        {
            return this.GetModel(url);
        }

        public List<IDownloadData> GetList(SearchArgs args, out int totalCount)
        {
            var where = " 1=1";
            where += args.IsDownload ? " and IsDownload  = true" : " and IsDownload  = true";
            where += args.IsEdit ? " and IsEdit = true" : " ";
            where += args.IsPublish ? " and IsPublish  = true" : " and IsPublish = false";
            where += args.TaskId != 0 ? " and TaskId  = " + args.TaskId : "";
            where += !string.IsNullOrEmpty(args.Keyword) ? " and Title like '%" + args.Keyword + "%'": "";
            where += !string.IsNullOrEmpty(args.EditorName) ? " and EditorUserName = '" + args.EditorName + "'" : "";

            totalCount = GetRecordCount(where);
            var sql = string.Format(@"select * from (select top {0} * from (select top {1} * from [DownloadData] {2} order by EditTime DESC,ID DESC) order by EditTime ) order by EditTime DESC", args.PageSzie, args.PageIndex * args.PageSzie, "where " + where);
            var rows = DbHelperOleDb.Query(sql).Tables[0].Rows;

            var result = new List<IDownloadData>();

            foreach (System.Data.DataRow row in rows)
            {
                result.Add(GetModel(row));
            }

            return result;
        }

        public List<string> GetTaskUrls(int taskId)
        {
            var result = new List<string>();
            StringBuilder strSql = new StringBuilder();
            strSql.Append("select Url ");
            strSql.Append(" FROM [DownloadData] ");
            strSql.Append(" where TaskId=@TaskId");
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

        public List<string> GetUnFetchedUrlList(int taskId)
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

        public void Update(IDownloadData data)
        {
            this.Update(data as DownloadData);
        }

        #endregion

        #region IDownloadDataDAL 成员


        public void DeleteAll()
        {
            StringBuilder strSql = new StringBuilder();
            strSql.Append("delete from DownloadData ");
            DbHelperOleDb.ExecuteSql(strSql.ToString());
        }

        #endregion

        #region IDownloadDataDAL 成员


        public List<IDownloadData> GetAll()
        {
            var where = " 1=1";

            var sql = @"select * from [DownloadData] where " + where;
            var rows = DbHelperOleDb.Query(sql).Tables[0].Rows;

            var result = new List<IDownloadData>();

            foreach (System.Data.DataRow row in rows)
            {
                result.Add(GetModel(row));
            }

            return result;
        }

        #endregion
    }
}
