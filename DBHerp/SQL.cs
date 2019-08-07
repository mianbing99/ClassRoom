using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Configuration;
using System.Data.SqlClient;
using System.Data;

namespace DBHerp {
  public  class SQL {
    public static string connstr = "Data Source=182.254.134.51;Initial Catalog=Teaching;user id=MDB;password=Main@JLF955icox;Pooling=true; max pool size =\"1000\";";
     private static SqlConnection conn = new SqlConnection (); //= new SqlConnection(connstr);
     public static void connopen() {
         conn.ConnectionString = connstr;
         conn.Open();
     }
     public static void connColse() {
         conn.Close();
         conn.Dispose();
     }
     public bool ExQuery(string sql) {
         SqlConnection conn = new SqlConnection(connstr);
         conn.Open();
         SqlCommand cmd = new SqlCommand(sql, conn);
         if (cmd.ExecuteNonQuery() > 0) {
             conn.Close();
             conn.Dispose();
              return true;
          } else {
             conn.Close();
             conn.Dispose();
              return false;
          }
         
      }
     
          /// <summary>
          /// 获取数据集的第一行第一列
          /// </summary>
          /// <param name="sql"></param>
          /// <returns>返回单个值</returns>
      public  int  ExScalar(string sql) {
          SqlConnection conn = new SqlConnection(connstr);
          conn.Open();
          SqlCommand cmd = new SqlCommand(sql, conn);
          return Convert.ToInt32(cmd.ExecuteScalar()) ;
      }

      /// <summary>
      /// 获取集合数据
      /// </summary>
      /// <param name="sql"></param>
      /// <returns>返回SqlDataReader</returns>
      public SqlDataReader ExReader(string sql) {
          SqlConnection conn = new SqlConnection(connstr);
              conn.Open();
              SqlCommand cmd = new SqlCommand(sql, conn);
              return cmd.ExecuteReader(CommandBehavior.CloseConnection);
         }//CommandBehavior.CloseConnection
      private  SqlCommand Exconn(string sql) {
          //SqlConnection conn = new SqlConnection(connstr);
          //conn.Open();
          SqlCommand cmd = new SqlCommand(sql,conn);

          return cmd;
          
      }
      public static T GetModel<T>(string sql,string type) {
          SqlConnection conn = new SqlConnection(DBHerp.SQL.connstr);
          conn.Open();
          T ret = default(T);
          SqlCommand cmd = new SqlCommand(sql, conn);
          SqlDataReader re = cmd.ExecuteReader(CommandBehavior.CloseConnection);
          if (type == "VideoRote") {
              List<Model.VideoRoute> Vilist = new List<Model.VideoRoute>();
              while (re.Read()) {
                  Model.VideoRoute Vi = new Model.VideoRoute();
                  Vi.VRID = Convert.ToInt32(re["VRID"]);
                  Vi.HTV = re["HTV"].ToString();
                  Vi.ViID = Convert.ToInt32(re["viid"]);
                  Vi.ViName = re["viname"].ToString();
                  Vi.State = Convert.ToInt32(re["state"]);
                  Vi.Mp4 = re["Mp4"].ToString();
                  Vi.Vip = Convert.ToInt32(re["Vip"]);
                  Vilist.Add(Vi);
              }
              ret = (T)(object)Vilist;
          } else if (type=="Card") {
          
          }
         
          re.Close(); re.Dispose();
          if (conn != null) {
              conn.Close();
              conn.Dispose();
          }
         
          return ret;
      }
      #region 数据库操作
      //连接数据库字符串
      public static string connstrs = ConfigurationManager.ConnectionStrings["DefaultConnection"].ToString();
      public static SqlConnection conns;
      public static SqlConnection con;
      //得到SqlConnnection对象
      public static SqlConnection Getconn()
      {
          if (conns == null)
          {
              conns = new SqlConnection(connstr);
          }
          return conns;
      }

      //打开数据库连接
      public static void OpenConn()
      {
          if (conns.State == ConnectionState.Closed)
          {
              conns.Open();
          }
          if (conns.State == ConnectionState.Open)
          {
              conns.Close();
              conns.Open();
          }
      }

      //关闭数据库连接
      public static void CloseConn()
      {
          if (conns.State == ConnectionState.Broken || conns.State == ConnectionState.Open)
          {
              conns.Close();
          }
      }

      //数据表格 datatable
      public static DataTable Query(string sql)
      {
          SqlConnection con = new SqlConnection(connstr);
          SqlCommand cmd = new SqlCommand(sql, con);
          SqlDataAdapter dr = new SqlDataAdapter(cmd);
          DataTable dt = new DataTable();
          dr.Fill(dt);
          con.Close();
          return dt;
      }
      public static int ds(string sql)
      {
          SqlConnection con = new SqlConnection(connstr);
          con.Open();
          SqlCommand cmd = new SqlCommand(sql, con);
          int res = cmd.ExecuteNonQuery();
          con.Close();
          return res;
      }
      #endregion
  }
}
