using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using HFBBS.Helper;
using System.Data;
using HFBBS.Model;

namespace HFBBS.BLL
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

        public void Add(downloaddata data)
        {
            CacheObject.NewsDAL.Add(data);
            //AccessHelper.excuteSql(data.GetInsertSql());
        }

        public void Update(downloaddata data)
        {
            CacheObject.NewsDAL.Update(data);
            //AccessHelper.excuteSql(data.GetUpdateSql());
        }
       
    }

}
