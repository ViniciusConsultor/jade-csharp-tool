using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Data.OleDb;
using System.Data;
using System.IO;

namespace HFBBS.Helper
{
    /// <summary>
    /// AccessHelper 的摘要说明
    /// </summary>
    public class AccessHelper
    {

        public static bool CreateMDBDataBase(string taskName = "hfbbs")
        {
            try
            {
                if (!File.Exists(AppDomain.CurrentDomain.BaseDirectory + "\\" + taskName + ".mdb"))
                {
                    ADOX.CatalogClass cat = new ADOX.CatalogClass();

                    cat.Create(
                    "Provider=Microsoft.Jet.OLEDB.4.0;Data Source="
                    + AppDomain.CurrentDomain.BaseDirectory + "\\" + taskName + ".mdb;");

                    cat = null;
                    var sql = @"Create Table DownloadData(
                        ID integer identity(1,1) primary key,
                        TaskId integer,
                        Title text ,
                        SubTitle text ,
                        Keywords text ,news_source_name text,
                        news_template_file text,
                        news_top text,
                        news_guideimage text,
                        news_guideimage2 text,
                        news_description text,
                        news_link text,
                        news_down text,
                        news_right text,
                        news_left text,
                        comment_url text,
                        news_video text,
                        news_keywords2 text,
                        label_base text,
                        cmspinglun bit,
                        bbspinglun bit,
                        ISkfbm bit,
                        kfbm_id text,
                        kfbm_link text,
                        ISgfbm bit,
                        gfbm_id bit,
                        gfbm_link text,
                        news_abs text,
                        Content text,
                        Summary text,
                        Source text,
                        CreateTime text,
                        Other text,
                        Url text,
                        IsDownload bit,
                        IsPublish bit)";

                    excuteSql(sql);
                }
                return true;
            }
            //C#操作Access之创建mdb库
            catch
            {
                return false;
            }
        }

        protected static OleDbConnection conn = new OleDbConnection();
        protected static OleDbCommand comm = new OleDbCommand();
        public AccessHelper()
        {
            //
            // TODO: 在此处添加构造函数逻辑
            //
        }
        /// <summary>
        /// 打开数据库
        /// </summary>
        private static void openConnection(string taskName = "hfbbs")
        {
            if (conn.State == ConnectionState.Closed)
            {
                conn.ConnectionString = @"Provider=Microsoft.Jet.OleDb.4.0;Data Source=" + AppDomain.CurrentDomain.BaseDirectory + "\\" + taskName + ".mdb";
                comm.Connection = conn;
                try
                {
                    conn.Open();
                }
                catch (Exception e)
                { throw new Exception(e.Message); }
            }
        }
        /// <summary>
        /// 关闭数据库
        /// </summary>
        private static void closeConnection()
        {
            if (conn.State == ConnectionState.Open)
            {
                conn.Close();
                conn.Dispose();
                comm.Dispose();
            }
        }
        /// <summary>
        /// 执行sql语句
        /// </summary>
        /// <param name="sqlstr"></param>
        public static void excuteSql(string sqlstr)
        {
            try
            {
                openConnection();
                comm.CommandType = CommandType.Text;
                comm.CommandText = sqlstr;
                comm.ExecuteNonQuery();
            }
            catch (Exception e)
            {
                Console.WriteLine(e.Message);
            }
            finally
            { closeConnection(); }
        }

        /// <summary>
        /// 返回指定sql语句的OleDbDataReader对象，使用时请注意关闭这个对象。
        /// </summary>
        /// <param name="sqlstr"></param>
        /// <returns></returns>
        public static OleDbDataReader dataReader(string sqlstr)
        {
            OleDbDataReader dr = null;
            try
            {
                openConnection();
                comm.CommandText = sqlstr;
                comm.CommandType = CommandType.Text;
                dr = comm.ExecuteReader(CommandBehavior.CloseConnection);
            }
            catch
            {
                try
                {
                    dr.Close();
                    closeConnection();
                }
                catch { }
            }
            return dr;
        }
        /// <summary>
        /// 返回指定sql语句的OleDbDataReader对象,使用时请注意关闭
        /// </summary>
        /// <param name="sqlstr"></param>
        /// <param name="dr"></param>
        public static void dataReader(string sqlstr, ref OleDbDataReader dr)
        {
            try
            {
                openConnection();
                comm.CommandText = sqlstr;
                comm.CommandType = CommandType.Text;
                dr = comm.ExecuteReader(CommandBehavior.CloseConnection);
            }
            catch
            {
                try
                {
                    if (dr != null && !dr.IsClosed)
                        dr.Close();
                }
                catch
                {
                }
                finally
                {
                    closeConnection();
                }
            }
        }
        /// <summary>
        /// 返回指定sql语句的dataset
        /// </summary>
        /// <param name="sqlstr"></param>
        /// <returns></returns>
        public static DataSet dataSet(string sqlstr)
        {
            DataSet ds = new DataSet();
            OleDbDataAdapter da = new OleDbDataAdapter();
            try
            {
                openConnection();
                comm.CommandType = CommandType.Text;
                comm.CommandText = sqlstr;
                da.SelectCommand = comm;
                da.Fill(ds);
            }
            catch (Exception e)
            {
                throw new Exception(e.Message);
            }
            finally
            {
                closeConnection();
            }
            return ds;
        }
        /// <summary>
        /// 返回指定sql语句的dataset
        /// </summary>
        /// <param name="sqlstr"></param>
        /// <param name="ds"></param>
        public static void dataSet(string sqlstr, ref DataSet ds)
        {
            OleDbDataAdapter da = new OleDbDataAdapter();
            try
            {
                openConnection();
                comm.CommandType = CommandType.Text;
                comm.CommandText = sqlstr;
                da.SelectCommand = comm;
                da.Fill(ds);
            }
            catch (Exception e)
            {
                throw new Exception(e.Message);
            }
            finally
            {
                closeConnection();
            }
        }
        /// <summary>
        /// 返回指定sql语句的datatable
        /// </summary>
        /// <param name="sqlstr"></param>
        /// <returns></returns>
        public static DataTable dataTable(string sqlstr)
        {
            DataTable dt = new DataTable();
            OleDbDataAdapter da = new OleDbDataAdapter();
            try
            {
                openConnection();
                comm.CommandType = CommandType.Text;
                comm.CommandText = sqlstr;
                da.SelectCommand = comm;
                da.Fill(dt);
            }
            catch (Exception e)
            {
                throw new Exception(e.Message);
            }
            finally
            {
                closeConnection();
            }
            return dt;
        }

        /// <summary>
        /// 返回指定sql语句的datatable
        /// </summary>
        /// <param name="sqlstr"></param>
        /// <param name="dt"></param>
        public static void dataTable(string sqlstr, ref DataTable dt)
        {
            OleDbDataAdapter da = new OleDbDataAdapter();
            try
            {
                openConnection();
                comm.CommandType = CommandType.Text;
                comm.CommandText = sqlstr;
                da.SelectCommand = comm;
                da.Fill(dt);
            }
            catch (Exception e)
            {
                throw new Exception(e.Message);
            }
            finally
            {
                closeConnection();
            }
        }
        /// <summary>
        /// 返回指定sql语句的dataview
        /// </summary>
        /// <param name="sqlstr"></param>
        /// <returns></returns>
        public static DataView dataView(string sqlstr)
        {
            OleDbDataAdapter da = new OleDbDataAdapter();
            DataView dv = new DataView();
            DataSet ds = new DataSet();
            try
            {
                openConnection();
                comm.CommandType = CommandType.Text;
                comm.CommandText = sqlstr;
                da.SelectCommand = comm;
                da.Fill(ds);
                dv = ds.Tables[0].DefaultView;
            }
            catch (Exception e)
            {
                throw new Exception(e.Message);
            }
            finally
            {
                closeConnection();
            }
            return dv;
        }
    }
}
