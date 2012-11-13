using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Thrift;
using Thrift.Transport;
using Thrift.Protocol;
using Jade.CQA.Model;
using System.Threading;

namespace HBASEDATASAVER
{
    public class HBASESaver
    {
        static byte[] table_name = Encoding.UTF8.GetBytes("vadim_test");
        static readonly byte[] ID = Encoding.UTF8.GetBytes("p");
        static readonly byte[] NAME = Encoding.UTF8.GetBytes("Name");
        static int i = 0;


        static byte[] UserTable = Encoding.UTF8.GetBytes("User");
        static readonly byte[] UserName = Encoding.UTF8.GetBytes("UserName");
        static readonly byte[] AdoptionRate = Encoding.UTF8.GetBytes("AdoptionRate");
        static readonly byte[] AnwserCount = Encoding.UTF8.GetBytes("AnwserCount");
        static readonly byte[] AdoptionCount = Encoding.UTF8.GetBytes("AdoptionCount");
        static readonly byte[] ExpertArea = Encoding.UTF8.GetBytes("ExpertArea");
        static readonly byte[] UserStage = Encoding.UTF8.GetBytes("UserStage");

        static byte[] QuestionTable = Encoding.UTF8.GetBytes("Question");
        static readonly byte[] QuestionId = Encoding.UTF8.GetBytes("ID");
        static readonly byte[] Question = Encoding.UTF8.GetBytes("Question");
        static readonly byte[] Content = Encoding.UTF8.GetBytes("Question:Content");
        static readonly byte[] Detail = Encoding.UTF8.GetBytes("Question:Detail");
        static readonly byte[] Anwsers = Encoding.UTF8.GetBytes("Anwsers");
        static readonly byte[] QuestionAndAnwsers = Encoding.UTF8.GetBytes("QuestionAndAnwsers");

        static HBASESaver()
        {
            TBufferedTransport transport = new TBufferedTransport(new TSocket("192.168.86.123", 9090));
            try
            {
                TBinaryProtocol protocol = new TBinaryProtocol(transport);
                Hbase.Client client = new Hbase.Client(protocol);
                transport.Open();

                var tables = client.getTableNames().Select(t => Encoding.UTF8.GetString(t)).ToList();

                if (!tables.Contains("User"))
                {
                    client.createTable(
                        UserTable,
                        new List<ColumnDescriptor>()
                        {
                            new ColumnDescriptor {Name = UserName, InMemory = true},
                            new ColumnDescriptor {Name = AdoptionRate, InMemory = true},
                            new ColumnDescriptor {Name = AnwserCount, InMemory = true},
                            new ColumnDescriptor {Name = AdoptionCount, InMemory = true},
                            new ColumnDescriptor {Name = ExpertArea, InMemory = true},
                            new ColumnDescriptor {Name = UserStage, InMemory = true}
                        });
                }

                if (!tables.Contains("Question"))
                {
                    client.createTable(
                        QuestionTable,
                        new List<ColumnDescriptor>()
                        {
                            new ColumnDescriptor {Name = QuestionId, InMemory = true},
                            new ColumnDescriptor {Name = Question, InMemory = true},
                            new ColumnDescriptor {Name = Content, InMemory = true},
                            new ColumnDescriptor {Name = Anwsers, InMemory = true},
                            new ColumnDescriptor {Name = QuestionAndAnwsers, InMemory = true},
                            new ColumnDescriptor {Name = Detail, InMemory = true}
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
            TBufferedTransport transport = new TBufferedTransport(new TSocket("192.168.86.123", 9090));
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
                           new Mutation{Column = QuestionId, IsDelete = false, Value = Encoding.UTF8.GetBytes(result.Question.Id)},
                           new Mutation{Column = Question, IsDelete = false, Value = Encoding.UTF8.GetBytes(result.Question.Title)},
                           new Mutation{Column = Content, IsDelete = false, Value = Encoding.UTF8.GetBytes(result.Question.Content)},
                           new Mutation{Column = Anwsers, IsDelete = false, Value = Encoding.UTF8.GetBytes(string.Join("\r\n",result.Answers.Select(a=>a.ToString()).ToArray()))},
                           new Mutation{Column = QuestionAndAnwsers, IsDelete = false, Value = Encoding.UTF8.GetBytes(result.QuestionAnswer.ToString())},
                           new Mutation{Column = Detail, IsDelete = false, Value = Encoding.UTF8.GetBytes(result.Question.ToString())}
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

        static void SaveUser(User user)
        {
            TBufferedTransport transport = new TBufferedTransport(new TSocket("192.168.86.123", 9090));
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
            TBufferedTransport transport = new TBufferedTransport(new TSocket("192.168.86.123", 9090));
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

