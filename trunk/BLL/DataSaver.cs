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

        public void Add(DownloadData data)
        {
            data.Add();
            //AccessHelper.excuteSql(data.GetInsertSql());
        }

        public void Update(DownloadData data)
        {
            data.Update();
            //AccessHelper.excuteSql(data.GetUpdateSql());
        }
       
    }

}
