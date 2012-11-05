using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using MongoDB.Driver;
using MongoDB.Bson;
using Jade.CQA.Model;
using System.Threading;

namespace Jade.CQA.KnowedegProcesser.DataSave
{
    public class CQASaver
    {
        static List<FetchResult> FetchResultQueqe = new List<FetchResult>();

        static object locker = new object();

        static CQASaver()
        {
            //new Thread(() =>
            //{
            //    lock (locker)
            //    {
            //        if (FetchResultQueqe.Count > 0)
            //        {
            //            FetchResult[] toSave = new FetchResult[FetchResultQueqe.Count];

            //            FetchResultQueqe.CopyTo(toSave, 0);

            //            FetchResultQueqe.Clear();
            //        }

            //    }

            //}).Start();
        }

        public static bool IsUserExist(string userName)
        {
            using (MongdbHelper helper = new MongdbHelper("User"))
            {
                IMongoQuery query = new QueryDocument()
                        {
                            {"UserName",userName}
                         };
                return helper.DataSet.FindOne(query) != null;
            }
        }

        public static void SaveFetchResult(FetchResult result, bool isNew = true)
        {
            new Thread(() =>
              {
                  if (isNew)
                  {
                      if (result.User == null)
                      {
                          using (MongdbHelper helper = new MongdbHelper("Question"))
                          {
                              helper.DataSet.Insert(result.Question);
                              helper.Database.GetCollection("Answer").InsertBatch<Answer>(result.Answers);
                              helper.Database.GetCollection("QuestionAnswer").Insert(result.QuestionAnswer);
                          }
                      }
                      else
                      {
                          using (MongdbHelper helper = new MongdbHelper("User"))
                          {
                              IMongoQuery query = new QueryDocument()
                        {
                            {"UserName",result.User.UserName}
                         };
                              if (helper.DataSet.FindOne(query) == null)
                                  helper.DataSet.Insert(result.User);
                          }
                      }
                  }
              }).Start();
        }
    }
}
