using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Jade.Model;
using Jade.Model.Access;
using Jade.DAL;
using Jade.Model.MySql;

namespace Jade
{

    public class DatabaseFactory : IDataFactory
    {
        static DatabaseFactory instance;

        public static DatabaseFactory Instance
        {
            get
            {
                if (instance == null)
                {
                    instance = new DatabaseFactory();
                }
                return instance;
            }
        }

        #region IDataFactory 成员

        public Model.IDownloadData CreateDownloadData(int id)
        {
            return CacheObject.DownloadDataDAL.Get(id);
        }

        public Model.IDownloadData CreateDownloadData(string url, int taskId)
        {
            if (Properties.Settings.Default.IsOnline)
            {
                return new Model.MySql.downloaddata(taskId, url);
            }
            return new Model.Access.DownloadData(taskId, url);
        }

        public Jade.DAL.IDownloadDataDAL CreateDAL()
        {
            if (Properties.Settings.Default.IsOnline)
            {
                CacheObject.ImageSaver = new ImageSaver(Properties.Settings.Default.ServerIp, Properties.Settings.Default.ServerDatabase, Properties.Settings.Default.ServerUser, Properties.Settings.Default.ServerPasword);
                return new Model.MySql.NewsDAL(Properties.Settings.Default.ServerIp, Properties.Settings.Default.ServerDatabase, Properties.Settings.Default.ServerUser, Properties.Settings.Default.ServerPasword);
            }
            return new Model.Access.DownloadDataDAL();
        }

        #endregion
    }
}
