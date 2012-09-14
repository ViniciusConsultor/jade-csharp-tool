using System;
using Jade.Model;
using System.Collections.Generic;
namespace Jade.DAL
{
    public interface IDownloadDataDAL
    {
        void Add(IDownloadData data);
        void Delete(IDownloadData data);
        IDownloadData Get(int id);
        IDownloadData Get(string url);
        global::System.Collections.Generic.List<IDownloadData> GetList(SearchArgs args, out int totalCount);
        global::System.Collections.Generic.List<string> GetTaskUrls(int taskId);
        global::System.Collections.Generic.List<string> GetUnFetchedUrlList(int taskId);
        void Update(IDownloadData data);
        void DeleteAll();
        List<IDownloadData> GetAll();
    }
}
