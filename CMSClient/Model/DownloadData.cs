
using System;
using System.Data;
using System.Linq;
using System.Text;
using System.Data.OleDb;
using Maticsoft.DBUtility;
using System.Collections.Generic;//Please add references
namespace Jade.Model
{

    public partial class DownloadData
    {
        public DownloadData(int taskId, string url)
            : this()
        {
            TaskId = taskId;
            Url = url;
        }
      

        /// <summary>
        /// 得到一个对象实体
        /// </summary>
        public DownloadData(string url)
        {
            StringBuilder strSql = new StringBuilder();
            strSql.Append("select *");
            strSql.Append(" FROM [DownloadData] ");
            strSql.Append(" where Url=@Url ");
            OleDbParameter[] parameters = {
					new OleDbParameter("@Url", OleDbType.VarChar)};
            parameters[0].Value = url;
            DataSet ds = DbHelperOleDb.Query(strSql.ToString(), parameters);
            this.GetModelFromDataSet(ds);          
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
        
        /// <summary>
        /// 获得数据列表
        /// </summary>
        public DataSet GetList(string strWhere, out int totalCount, int page = 1, int pageSize = 10)
        {
            var sql = string.Format(
   @"select * from (select top {0} * from (select top {1} * from [DownloadData] {2} order by ID DESC) order by ID ) order by ID DESC", pageSize, page * pageSize, strWhere == "" ? "" : "where " + strWhere);

            var countSql = string.Format("select count(*) from [DownloadData] {0}", strWhere == "" ? "" : "where " + strWhere);

            totalCount = (int)DbHelperOleDb.GetSingle(countSql);

            return DbHelperOleDb.Query(sql);
        }

    }
}



