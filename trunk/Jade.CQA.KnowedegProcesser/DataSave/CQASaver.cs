using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using MongoDB.Driver;
using MongoDB.Bson;
using Jade.CQA.Model;

namespace Jade.CQA.KnowedegProcesser.DataSave
{
    public class CQASaver
    {
        public static void SaveFetchResult(FetchResult result, bool isNew = true)
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
                        helper.DataSet.Insert(result.User);
                    }
                }
            }
        }
    }
}
