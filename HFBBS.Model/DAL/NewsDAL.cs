using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Jade;

namespace Jade.Model.MySql
{
    public class NewsDAL
    {
        HFBBSEntities Repository = new HFBBSEntities();

        public List<string> GetTaskUrls(int taskId)
        {
            return Repository.downloaddata.Where(d => d.TaskId == taskId).Select(d => d.Url).ToList();
        }

        public List<string> GetUnFetchedUrlList(int taskId)
        {
            return Repository.downloaddata.Where(d => d.TaskId == taskId && !d.IsDownload).Select(d => d.Url).ToList();
        }

        public downloaddata Get(string url)
        {
            return Repository.downloaddata.First(d => d.Url == url);
        }

        public downloaddata Get(int id)
        {
            return Repository.downloaddata.First(d => d.ID == id);
        }

        public void Add(downloaddata data)
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

        public void Update(downloaddata data)
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

        public void Delete(downloaddata data)
        {
            Repository.DeleteObject(data);
            Repository.SaveChanges();
        }

        public List<downloaddata> GetList(SearchArgs args, out int totalCount)
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
                    (!string.IsNullOrEmpty(args.Keyword) ? t.Title.Contains(args.Keyword) : true)
                );
            totalCount = query.Count();

            return query.OrderByDescending(t => t.ID).Skip((args.PageIndex - 1) * args.PageSzie).Take(args.PageSzie).ToList();

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

   
}
