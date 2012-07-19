﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Jade.Model;
using Jade.Model.Access;

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

        public  Model.IDownloadData CreateDownloadData(int id)
        {
            return CacheObject.DownloadDataDAL.Get(id);
        }

        public  Model.IDownloadData CreateDownloadData(string url, int taskId)
        {
            return new Model.Access.DownloadData(taskId, url);
        }

        public  Jade.DAL.IDownloadDataDAL CreateDAL()
        {
            return new Model.Access.DownloadDataDAL();
        }

        #endregion
    }
}