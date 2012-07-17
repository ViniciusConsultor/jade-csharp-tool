using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Jade.Helper;
using System.Data;
using Jade.Model;
using Jade.Model.MySql;

namespace Jade.BLL
{
    public class DataSaverManager
    {
        public DataSaverManager()
        {

        }

        public List<string> GetTaskUrls(int taskId)
        {
            var data = AccessHelper.dataTable("SELECT Url FROM DownloadData WHERE TaskId = " + taskId);
            var result = new List<string>();
            foreach (DataRow row in data.Rows)
            {
                result.Add(row["Url"].ToString());
            }
            return result;
        }

        public void Add(IDownloadData data)
        {
            CacheObject.DownloadDataDAL.Add(data);
            //AccessHelper.excuteSql(data.GetInsertSql());
        }

        public void Update(IDownloadData data)
        {
            CacheObject.DownloadDataDAL.Update(data);
            //AccessHelper.excuteSql(data.GetUpdateSql());
        }
       
    }

}
