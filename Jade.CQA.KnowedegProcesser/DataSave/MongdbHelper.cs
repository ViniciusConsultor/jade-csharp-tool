using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using MongoDB.Driver;
using MongoDB.Bson;

namespace Jade.CQA.KnowedegProcesser.DataSave
{
    public static class BaseConfig
    {
        public const string UrlSeparator = "@@";
        public const string UrlTrimItemSeparator = "$$";
        private static string _mongoConnectionString = "mongodb://192.168.75.127/?socketTimeoutMS=2400000";

        /// <summary>
        /// Mongo数据库连接字符串
        /// </summary>
        public static string DBConnectionString
        {
            get
            {
                //if (string.IsNullOrEmpty(_mongoConnectionString))
                //{
                //    _mongoConnectionString = System.Configuration.ConfigurationManager.AppSettings["MongoDBConnectionString"];
                //}
                return _mongoConnectionString;
            }
        }
    }
    public class MongdbHelper : IDisposable
    {
        public MongoServer Server { get; private set; }

        public MongoDB.Driver.MongoDatabase Database { get; private set; }

        public MongoCollection<BsonDocument> DataSet { get; set; }

        public MongdbHelper(string dbName, string tableName)
        {
            Server = MongoServer.Create(BaseConfig.DBConnectionString);
            Database = Server.GetDatabase(dbName);
            DataSet = Database.GetCollection(tableName);
        }

        public MongdbHelper(string tableName)
        {
            Server = MongoServer.Create(BaseConfig.DBConnectionString);
            Database = Server.GetDatabase("CQA2");
            DataSet = Database.GetCollection(tableName);
        }

        public MongdbHelper(string serverName, string dbName, string tableName)
        {
            Server = MongoServer.Create(serverName);
            Database = Server.GetDatabase(dbName);
            DataSet = Database.GetCollection(tableName);
        }

        public void Dispose()
        {
            Server.Disconnect();
        }

        public static List<T> GetOnColumn<T>(string dbName, string tableName, string column, Func<object, T> convert)
        {
            try
            {
                using (MongdbHelper db = new MongdbHelper(dbName, tableName))
                {
                    List<T> results = new List<T>();

                    var r = db.DataSet.FindAll();
                    r.SetFields(column);
                    foreach (var c in r)
                    {
                        results.Add(convert(c[column]));
                    }

                    return results;
                }
            }
            catch
            {
                return null;
            }
        }

        public static bool IsExist(string dbName, string tableName, string column, object value)
        {
            try
            {
                using (MongdbHelper db = new MongdbHelper(dbName, tableName))
                {
                    IMongoQuery query = new QueryDocument() { { column, value.ToString() } };
                    var results = db.DataSet.FindOne(query);
                    return results != null;
                }
            }
            catch
            {
                return false;
            }
        }
    }
}
