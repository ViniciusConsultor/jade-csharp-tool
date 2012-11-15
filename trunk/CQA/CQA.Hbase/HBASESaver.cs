using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Thrift;
using Thrift.Transport;
using Thrift.Protocol;
using Jade.CQA.Model;
using System.Threading;
using System.IO;
using System.Xml.Serialization;

namespace HBASEDATASAVER
{
    public class HBASESaver
    {
        static byte[] table_name = Encoding.UTF8.GetBytes("vadim_test");
        static readonly byte[] ID = Encoding.UTF8.GetBytes("p");
        static readonly byte[] NAME = Encoding.UTF8.GetBytes("Name");
        static int i = 0;
        static readonly byte[] KnowedgeType = Encoding.UTF8.GetBytes("KnowedgeType");


        static byte[] UserTable = Encoding.UTF8.GetBytes("User");
        static readonly byte[] UserName = Encoding.UTF8.GetBytes("UserName");
        static readonly byte[] AdoptionRate = Encoding.UTF8.GetBytes("AdoptionRate");
        static readonly byte[] AnwserCount = Encoding.UTF8.GetBytes("AnwserCount");
        static readonly byte[] AdoptionCount = Encoding.UTF8.GetBytes("AdoptionCount");
        static readonly byte[] ExpertArea = Encoding.UTF8.GetBytes("ExpertArea");
        static readonly byte[] UserStage = Encoding.UTF8.GetBytes("UserStage");

        static byte[] QuestionTable = Encoding.UTF8.GetBytes("Question");
        static readonly byte[] QuestionId = Encoding.UTF8.GetBytes("Question:ID");
        static readonly byte[] Question = Encoding.UTF8.GetBytes("Question:Title");
        static readonly byte[] Content = Encoding.UTF8.GetBytes("Question:Content");
        static readonly byte[] Category = Encoding.UTF8.GetBytes("Question:Category");
        static readonly byte[] ViewCount = Encoding.UTF8.GetBytes("Question:ViewCount");
        static readonly byte[] CreateTime = Encoding.UTF8.GetBytes("Question:CreateTime");
        static readonly byte[] RawText = Encoding.UTF8.GetBytes("RawText:Content");
        static readonly byte[] Tags = Encoding.UTF8.GetBytes("Question:Tags");
        static readonly byte[] Url = Encoding.UTF8.GetBytes("Question:Url");
        static readonly byte[] State = Encoding.UTF8.GetBytes("Question:State");
        static readonly byte[] Anwsers = Encoding.UTF8.GetBytes("Question:Anwsers");
        static readonly byte[] SatisfiedAnswerIds = Encoding.UTF8.GetBytes("Question:SatisfiedAnswerIds");
        static readonly byte[] RecommendedAnswerIds = Encoding.UTF8.GetBytes("Question:RecommendedAnswerIds");
        static readonly byte[] RelatedQuestionIds = Encoding.UTF8.GetBytes("Question:RelatedQuestionIds");
        static readonly byte[] QuestionAndAnwsers = Encoding.UTF8.GetBytes("Question:QuestionAndAnwsers");

        static HBASESaver()
        {
            TBufferedTransport transport = new TBufferedTransport(new TSocket("192.168.86.41", 9090));
            try
            {
                TBinaryProtocol protocol = new TBinaryProtocol(transport);
                Hbase.Client client = new Hbase.Client(protocol);
                transport.Open();
                //client.disableTable(QuestionTable);
                //client.disableTable(UserTable);
                //client.deleteTable(QuestionTable);
                //client.deleteTable(UserTable);

                var tables = client.getTableNames().Select(t => Encoding.UTF8.GetString(t)).ToList();

                if (!tables.Contains("User"))
                {
                    client.createTable(
                        UserTable,
                        new List<ColumnDescriptor>()
                        {
                            new ColumnDescriptor {Name = RawText, InMemory = true},
                            new ColumnDescriptor {Name = UserName, InMemory = true},
                            new ColumnDescriptor {Name = AdoptionRate, InMemory = true},
                            new ColumnDescriptor {Name = AnwserCount, InMemory = true},
                            new ColumnDescriptor {Name = AdoptionCount, InMemory = true},
                            new ColumnDescriptor {Name = ExpertArea, InMemory = true},
                            new ColumnDescriptor {Name = KnowedgeType, InMemory = true},
                            new ColumnDescriptor {Name = UserStage, InMemory = true}
                        });
                }

                if (!tables.Contains("Question"))
                {
                    client.createTable(
                        QuestionTable,
                        new List<ColumnDescriptor>()
                        {
                            new ColumnDescriptor {Name = RawText, InMemory = true},
                            new ColumnDescriptor {Name = KnowedgeType, InMemory = true},
                            new ColumnDescriptor {Name = QuestionId, InMemory = true},
                            new ColumnDescriptor {Name = Question, InMemory = true},
                            new ColumnDescriptor {Name = Content, InMemory = true},
                            new ColumnDescriptor {Name = Category, InMemory = true},
                            new ColumnDescriptor {Name = ViewCount, InMemory = true},
                            new ColumnDescriptor {Name = CreateTime, InMemory = true},
                            new ColumnDescriptor {Name = Tags, InMemory = true},
                            new ColumnDescriptor {Name = Url, InMemory = true},
                            new ColumnDescriptor {Name = State, InMemory = true},
                            new ColumnDescriptor {Name = Anwsers, InMemory = true},
                            new ColumnDescriptor {Name = SatisfiedAnswerIds, InMemory = true},
                            new ColumnDescriptor {Name = RecommendedAnswerIds, InMemory = true},
                            new ColumnDescriptor {Name = RelatedQuestionIds, InMemory = true}
                        });
                }

            }
            catch
            {

            }
            finally
            {
                transport.Close();
            }

        }

        public static void SaveFetchResult(FetchResult result, bool isNew = true)
        {
            new Thread(() =>
            {
                try
                {
                    if (isNew)
                    {
                        if (result.User != null)
                        {
                            SaveUser(result.User);
                        }
                        else
                        {
                            SaveQuestion(result);
                        }
                    }
                }
                catch (Exception ex)
                {
                    Console.WriteLine(ex.Message);
                    SaveFetchResult(result);
                }
            }).Start();
        }


        static void SaveQuestion(FetchResult result)
        {
            TBufferedTransport transport = new TBufferedTransport(new TSocket("192.168.86.41", 9090));
            try
            {
                TBinaryProtocol protocol = new TBinaryProtocol(transport);
                Hbase.Client client = new Hbase.Client(protocol);
                transport.Open();


                client.mutateRows(QuestionTable, new List<BatchMutation>(){
                    new BatchMutation()
                    {
                        Row = Encoding.UTF8.GetBytes(result.Question.ReversedUrl),
                        Mutations = new List<Mutation> {
                           new Mutation{Column = RawText, IsDelete = false, Value = Encoding.UTF8.GetBytes(result.Question.RawText)},
                           new Mutation{Column = KnowedgeType, IsDelete = false, Value = Encoding.UTF8.GetBytes(result.Question.KnowedgeType.ToString())},
                           new Mutation{Column = QuestionId, IsDelete = false, Value = Encoding.UTF8.GetBytes(result.Question.QuestionId)},
                           new Mutation{Column = Question, IsDelete = false, Value = Encoding.UTF8.GetBytes(result.Question.Title)},
                           new Mutation{Column = Content, IsDelete = false, Value = Encoding.UTF8.GetBytes(result.Question.Content)},
                           new Mutation{Column = Category, IsDelete = false, Value = Encoding.UTF8.GetBytes(result.Question.Category)},
                           new Mutation{Column = ViewCount, IsDelete = false, Value = Encoding.UTF8.GetBytes(result.Question.ViewCount.ToString())},
                           new Mutation{Column = CreateTime, IsDelete = false, Value = Encoding.UTF8.GetBytes(result.Question.CreateTime.ToString("yyyy-MM-dd HH:mm:ss"))},
                           new Mutation{Column = Tags, IsDelete = false, Value = Encoding.UTF8.GetBytes(result.Question.Tags)},
                           new Mutation{Column = Url, IsDelete = false, Value = Encoding.UTF8.GetBytes(result.Question.Url)},
                           new Mutation{Column = State, IsDelete = false, Value = Encoding.UTF8.GetBytes(result.Question.Status.ToString())},
                           new Mutation{Column = Anwsers, IsDelete = false, Value = Encoding.UTF8.GetBytes(TOXml(result.Answers))},
                           new Mutation{Column = SatisfiedAnswerIds, IsDelete = false, Value = Encoding.UTF8.GetBytes(string.Join(",",result.QuestionAnswer.SatisfiedAnswerIds.ToArray()))},
                           new Mutation{Column = RecommendedAnswerIds, IsDelete = false, Value = Encoding.UTF8.GetBytes(string.Join(",",result.QuestionAnswer.RecommendedAnswerIds.ToArray()))},
                           new Mutation{Column = RelatedQuestionIds, IsDelete = false, Value = Encoding.UTF8.GetBytes(string.Join(",",result.QuestionAnswer.RelatedQuestionIds.ToArray()))}
                         }
                        
                     }
                 });
            }
            catch
            {
            }
            finally
            {
                transport.Close();
            }
        }


        static string TOXml<T>(T obj)
        {
            MemoryStream ms = new MemoryStream();
            XmlSerializer serializer = new XmlSerializer(typeof(T));
            serializer.Serialize(ms, obj);
            var xmlReader = new StreamReader(ms);
            ms.Seek(0, SeekOrigin.Begin);
            var result = xmlReader.ReadToEnd();
            ms.Close();
            xmlReader.Close();
            return result;
        }

        static void SaveUser(User user)
        {
            TBufferedTransport transport = new TBufferedTransport(new TSocket("192.168.86.41", 9090));
            try
            {
                TBinaryProtocol protocol = new TBinaryProtocol(transport);
                Hbase.Client client = new Hbase.Client(protocol);
                transport.Open();
                client.mutateRows(UserTable, new List<BatchMutation>(){
                    new BatchMutation()
                    {
                        Row = Encoding.UTF8.GetBytes(user.ReversedUrl),
                        Mutations = new List<Mutation> {
                            new Mutation{Column = RawText, IsDelete = false, Value = Encoding.UTF8.GetBytes(user.RawText)},
                            new Mutation{Column = KnowedgeType, IsDelete = false, Value = Encoding.UTF8.GetBytes(user.KnowedgeType.ToString())},
                            new Mutation{Column = UserName, IsDelete = false, Value = Encoding.UTF8.GetBytes(user.UserName)},
                            new Mutation{Column = AdoptionRate, IsDelete = false, Value = Encoding.UTF8.GetBytes(user.AdoptionRate.ToString())},
                            new Mutation{Column = AnwserCount, IsDelete = false, Value = Encoding.UTF8.GetBytes(user.AnwserCount.ToString())},
                            new Mutation{Column = AdoptionCount, IsDelete = false, Value = Encoding.UTF8.GetBytes(user.AdoptionCount.ToString())},
                            new Mutation{Column = ExpertArea, IsDelete = false, Value = Encoding.UTF8.GetBytes(user.ExpertArea)},
                            new Mutation{Column = UserStage, IsDelete = false, Value = Encoding.UTF8.GetBytes(user.UserStage)}
                         }
                        
                     }
                 });
            }
            catch
            {
            }
            finally
            {
                transport.Close();
            }
        }

        static void Main(string[] args)
        {
            TBufferedTransport transport = new TBufferedTransport(new TSocket("192.168.86.41", 9090));
            try
            {
                TBinaryProtocol protocol = new TBinaryProtocol(transport);
                Hbase.Client client = new Hbase.Client(protocol);
                transport.Open();

                client.disableTable(table_name);
                client.deleteTable(table_name);

                client.createTable(
                    table_name,
                    new List<ColumnDescriptor>()
                    {
                        new ColumnDescriptor {Name = ID, InMemory = true},
                        new ColumnDescriptor {Name = NAME, InMemory = true}
                    }
                    );

                client.mutateRows(table_name, new List<BatchMutation>()
            {
                new BatchMutation()
                {
                    Row = Encoding.UTF8.GetBytes("com.baidu.zhidao/1.html"),
                    Mutations = new List<Mutation> {
                        new Mutation{Column = Question, IsDelete = false, Value = Encoding.UTF8.GetBytes("What's your name") }
                    }
                }
            });

                //var scanner = client.scannerOpen(table_name, Guid.Empty.ToByteArray(),
                //                                new List<byte[]>() { ID });
                //for (var entry = client.scannerGet(scanner); entry.Count > 0; entry = client.scannerGet(scanner))
                //{
                //    foreach (var rowResult in entry)
                //    {
                //        Console.Write("{0} => ", new Guid(rowResult.Row));
                //        var res = rowResult.Columns.Select(c => BitConverter.ToInt32(c.Value.Value, 0));
                //        foreach (var cell in res)
                //        {
                //            Console.WriteLine("{0}", cell);
                //        }
                //    }
                //}
            }
            catch
            {
            }
            finally
            {
                transport.Close();
            }
        }
    }
}

