using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Jade
{
    public interface IDataFactory
    {
        Model.IDownloadData CreateDownloadData(int id);
        Model.IDownloadData CreateDownloadData(string url, int taskId);
        Jade.DAL.IDownloadDataDAL CreateDAL();
    }

    public enum DatabaseType
    {
        SQLSERVER,
        ORACLE,
        ACCESS,
        MYSQL
    }
}
