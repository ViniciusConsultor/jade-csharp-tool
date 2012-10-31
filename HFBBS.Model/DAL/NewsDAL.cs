using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Jade;
using System.IO;
using System.Data.SqlClient;
using System.Data.EntityClient;

namespace Jade.Model.MySql
{
    public class NewsDAL : Jade.DAL.IDownloadDataDAL
    {
        HFBBSEntities Repository;

        string connectionString = "";

        public NewsDAL(string ip, string database, string user, string pwd)
        {
            //    <add name="HFBBSEntities" 
            //connectionString="metadata=res://*/Model1.csdl|res://*/Model1.ssdl|res://*/Model1.msl;
            //provider=MySql.Data.MySqlClient;provider connection string=&quot;server=127.0.0.1;User Id=root;password=111111;Persist Security Info=True;database=hfbbs&quot;"
            //providerName="System.Data.EntityClient" />

            string providerName = "MySql.Data.MySqlClient";
            string serverName = ip;
            string databaseName = database;

            // Initialize the connection string builder for the
            // underlying provider.
            SqlConnectionStringBuilder sqlBuilder =
                new SqlConnectionStringBuilder();

            // Set the properties for the data source.
            sqlBuilder.DataSource = serverName;
            sqlBuilder.InitialCatalog = databaseName;
            sqlBuilder.IntegratedSecurity = false;
            sqlBuilder.UserID = user;
            sqlBuilder.Password = pwd;
            //sqlBuilder.MultipleActiveResultSets = true;
            // Build the SqlConnection connection string.
            string providerString = sqlBuilder.ToString();

            // Initialize the EntityConnectionStringBuilder.
            EntityConnectionStringBuilder entityBuilder =
                new EntityConnectionStringBuilder();

            //Set the provider name.
            entityBuilder.Provider = providerName;

            // Set the provider-specific connection string.
            entityBuilder.ProviderConnectionString = providerString;

            entityBuilder.Provider = providerName;

            // Set the Metadata location.
            entityBuilder.Metadata = //@"res://*"; //或从.config文件中copy
            @"res://*/Model1.csdl|
            res://*/Model1.ssdl|
            res://*/Model1.msl";
            connectionString = entityBuilder.ToString();

            Repository = new HFBBSEntities(connectionString);

        }

        public List<string> GetTaskUrls(int taskId)
        {
            lock (Repository)
            {
                return Repository.downloaddata.Where(d => d.TaskId == taskId).Select(d => d.Url).ToList();
            }
        }

        public List<string> GetUnFetchedUrlList(int taskId)
        {
            lock (Repository)
            {
                return Repository.downloaddata.Where(d => d.TaskId == taskId && !d.IsDownload).Select(d => d.Url).ToList();
            }
        }

        public downloaddata Get(string url)
        {
            lock (Repository)
            {
                return Repository.downloaddata.First(d => d.Url == url);
            }
        }

        public downloaddata Get(int id)
        {
            lock (Repository)
            {
                return Repository.downloaddata.First(d => d.ID == id);
            }
        }

        public void Add(downloaddata data)
        {
            lock (Repository)
            {
                try
                {
                    Repository.AddTodownloaddata(data);
                    Repository.SaveChanges();
                }
                catch
                {
                }
            }
        }

        public void Update(downloaddata data)
        {
            lock (Repository)
            {
                try
                {
                    if (data.EntityState == System.Data.EntityState.Detached)
                    {
                        Repository.Attach(data);
                    }
                    Repository.SaveChanges();
                }
                catch
                {
                }
            }
        }

        public void Delete(downloaddata data)
        {
            lock (Repository)
            {
                Repository.DeleteObject(data);
                Repository.SaveChanges();
            }
        }

        public List<downloaddata> GetList(SearchArgs args, out int totalCount)
        {
            lock (Repository)
            {
                //totalCount = 10;

                //return new List<downloaddata> { 
                //    new downloaddata(){Title="test 1", IsDownload = true,IsEdit = true,EditorUserName="xxx",IsPublish= false},
                //     new downloaddata(){Title="test 2", IsDownload = true,IsEdit = false,EditorUserName="xxx",IsPublish= true},
                //      new downloaddata(){Title="test3 ", IsDownload = true,IsEdit = true,EditorUserName="xxx",IsPublish= false}
                //};

                var query = Repository.downloaddata.Where(
                    t => (args.IsDownload ? t.IsDownload == true : true) &&
                        (args.IsEdit ? t.IsEdit == true : true) &&
                        (args.IsPublish ? t.IsPublish == true : true) &&
                         (args.TaskId != 0 ? t.TaskId == args.TaskId : true) &&
                          (args.TaskIds.Count != 0 ? args.TaskIds.Contains((int)t.TaskId) : true) &&
                         (!string.IsNullOrEmpty(args.EditorName) ? t.EditorUserName == args.EditorName : true) &&
                        (!string.IsNullOrEmpty(args.Keyword) ? t.Title.Contains(args.Keyword) : true)
                    );
                totalCount = query.Count();

                return query.OrderByDescending(t => t.EditTime).OrderByDescending(t => t.DownloadTime).Skip((args.PageIndex - 1) * args.PageSzie).Take(args.PageSzie).ToList();
            }
        }



        public void Add(IDownloadData data)
        {
            this.Add(data as downloaddata);
        }

        public void Delete(IDownloadData data)
        {
            this.Delete(data as downloaddata);
        }

        IDownloadData DAL.IDownloadDataDAL.Get(int id)
        {
            return this.Get(id);
        }

        IDownloadData DAL.IDownloadDataDAL.Get(string url)
        {
            return this.Get(url);
        }

        List<IDownloadData> DAL.IDownloadDataDAL.GetList(SearchArgs args, out int totalCount)
        {
            lock (Repository)
            {
                var result = new List<IDownloadData>();

                var datas = this.GetList(args, out totalCount);

                foreach (var row in datas)
                {
                    result.Add(row);
                }

                return result;
            }
        }

        public void Update(IDownloadData data)
        {
            this.Update(data as downloaddata);
        }

        #region IDownloadDataDAL 成员


        public void DeleteAll()
        {
            lock (Repository)
            {
                foreach (var data in Repository.downloaddata)
                {
                    Repository.DeleteObject(data);
                }
                Repository.SaveChanges();
            }
        }

        #endregion

        #region IDownloadDataDAL 成员


        public List<downloaddata> GetAll()
        {
            lock (Repository)
            {
                return Repository.downloaddata.ToList();
            }
        }

        #endregion

        #region IDownloadDataDAL 成员


        List<IDownloadData> DAL.IDownloadDataDAL.GetAll()
        {
            var result = new List<IDownloadData>();

            var datas = this.GetAll();

            foreach (var row in datas)
            {
                result.Add(row);
            }

            return result;
        }

        #endregion


        public IDownloadData Get(string url, int siteRuleId)
        {
            lock (Repository)
            {
                return Repository.downloaddata.First(d => d.Url == url && d.TaskId == siteRuleId);
            }
        }
    }

    public partial class downloaddata
    {
        public downloaddata()
        {
        }

        public downloaddata(int taskId, string url)
            : this()
        {
            TaskId = taskId;
            Url = url;
        }
    }

    public partial class imagefiles : IImageFile
    {
    }

    public class ImageSaver : IImageSaver
    {
        HFBBSEntities Repository;

        string connectionString = "";

        public ImageSaver(string ip, string database, string user, string pwd)
        {
            //    <add name="HFBBSEntities" 
            //connectionString="metadata=res://*/Model1.csdl|res://*/Model1.ssdl|res://*/Model1.msl;
            //provider=MySql.Data.MySqlClient;provider connection string=&quot;server=127.0.0.1;User Id=root;password=111111;Persist Security Info=True;database=hfbbs&quot;"
            //providerName="System.Data.EntityClient" />

            string providerName = "MySql.Data.MySqlClient";
            string serverName = ip;
            string databaseName = database;

            // Initialize the connection string builder for the
            // underlying provider.
            SqlConnectionStringBuilder sqlBuilder =
                new SqlConnectionStringBuilder();

            // Set the properties for the data source.
            sqlBuilder.DataSource = serverName;
            sqlBuilder.InitialCatalog = databaseName;
            sqlBuilder.IntegratedSecurity = false;
            sqlBuilder.UserID = user;
            sqlBuilder.Password = pwd;
            //sqlBuilder.MultipleActiveResultSets = true;
            // Build the SqlConnection connection string.
            string providerString = sqlBuilder.ToString();

            // Initialize the EntityConnectionStringBuilder.
            EntityConnectionStringBuilder entityBuilder =
                new EntityConnectionStringBuilder();

            //Set the provider name.
            entityBuilder.Provider = providerName;

            // Set the provider-specific connection string.
            entityBuilder.ProviderConnectionString = providerString;

            entityBuilder.Provider = providerName;

            // Set the Metadata location.
            entityBuilder.Metadata = //@"res://*"; //或从.config文件中copy
            @"res://*/Model1.csdl|
            res://*/Model1.ssdl|
            res://*/Model1.msl";
            connectionString = entityBuilder.ToString();

            Repository = new HFBBSEntities(connectionString);

        }
        public IImageFile Save(string url, string fileName)
        {
            lock (Repository)
            {
                imagefiles image = new imagefiles();
                image.FileName = Path.GetFileName(fileName);
                image.Url = url;
                image.Data = File.ReadAllBytes(fileName);

                Repository.imagefiles.AddObject(image);
                Repository.SaveChanges();
                return image;
            }

        }

        public IImageFile Get(string url)
        {
            lock (Repository)
            {
                return Repository.imagefiles.FirstOrDefault(i => i.Url == url);
            }
        }

        public bool Exist(string url)
        {
            lock (Repository)
            {
                return Repository.imagefiles.Any(i => i.Url == url);
            }
        }
    }
}
