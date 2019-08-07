using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Configuration;
using System.Data.SqlClient;
using System.Data;
namespace DBHerp
{
    public static class DBHelper
    {
        public static string conStr = "Data Source=182.254.134.51;Initial Catalog=Teaching;user id=MDB;password=Main@JLF955icox;Pooling=true; max pool size =\"1000\";";
        //readonly static string conStr = ConfigurationManager.ConnectionStrings["MySchool"].ConnectionString;
        public static SqlConnection conn = new SqlConnection(conStr);
        public static SqlDataReader sdr = null;
        /// <summary>
        /// 打开数据库连接
        /// </summary>
        public static void OpdeConn()
        {
            if (conn!=null)
            {
                conn.Open();
            }else if(conn.State==ConnectionState.Broken){
                conn.Close();
                conn.Open();
            }
            else
            {
                throw new Exception("打开异常");
            }
        }
        /// <summary>
        /// 关闭数据库
        /// </summary>
        public static void CloseConn()
        {
            if (sdr != null)
            {
                sdr.Close();
                conn.Close();
            }
            else
            {
                if (conn.State == ConnectionState.Open)
                {
                    conn.Close();
                }else if(conn.State == ConnectionState.Broken)
                {
                    conn.Close();
                }
                else
                {
                    throw new Exception("关闭异常");
                }
            }
            
        }
        /// <summary>
        /// 返回单个值：参数化
        /// </summary>
        /// <param name="comm"></param>
        /// <returns></returns>
        public static object SqlExecuteScalarParameters(SqlCommand comm)
        {
            try
            {
                OpdeConn();
                return comm.ExecuteScalar();
            }
            catch (Exception)
            {
                throw new Exception("单个值参数化返回异常");
            }
            finally
            {
                CloseConn();
            }
        }
        /// <summary>
        /// 返回一张表数据：参数化
        /// </summary>
        /// <param name="comm"></param>
        /// <returns></returns>
        public static SqlDataReader SqlExecuteReaderParameters(SqlCommand comm)
        {
            try
            {
                OpdeConn();
                sdr = comm.ExecuteReader();
                return sdr;
            }
            catch (Exception ex)
            {
                throw new Exception("一张表数据参数化返回异常");
            }
           
        }
        /// <summary>
        /// 增删改：参数化
        /// </summary>
        /// <param name="sql"></param>
        /// <returns></returns>
        public static int SqlExecuteNonQueryParameters(SqlCommand comm)
        {
            try
            {
                OpdeConn();
                return comm.ExecuteNonQuery();
            }
            catch (Exception)
            {
                throw new Exception("增删改异常");
            }
            finally
            {
                CloseConn();
            }
        }
        /// <summary>
        /// 返回单个值
        /// </summary>
        /// <param name="sql"></param>
        /// <returns></returns>
        public static object SqlExecuteScalar(string sql)
        {
            try
            {
                OpdeConn();
                SqlCommand comm = new SqlCommand(sql,conn);
                return comm.ExecuteScalar();
            }
            catch (Exception)
            {
                throw new Exception("单个值返回异常");
            }
            finally
            {
                CloseConn();
            }

        }
        /// <summary>
        /// 返回一张表的值
        /// </summary>
        /// <param name="sql"></param>
        /// <returns></returns>
        public static SqlDataReader SqlExecuteReader(string sql)
        {
            try
            {
               
                SqlCommand comm = new SqlCommand(sql, conn);
                OpdeConn();
                sdr = comm.ExecuteReader();
                
            }
            catch (Exception)
            {
                throw new Exception("返回表异常");
            }
            return sdr;
        }
        /// <summary>
        /// 增删改
        /// </summary>
        /// <returns></returns>
        public static int SqlExecuteNonQuery(string sql)
        {
            try
            {
                SqlCommand comm = new SqlCommand(sql,conn);
                OpdeConn();
                return comm.ExecuteNonQuery();
            }
            catch (Exception)
            {
                throw new Exception("增删改异常");
            }
            finally
            {
                CloseConn();
            }
        }
    }
}
