using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Data.SqlClient;
using System.Data;

namespace DAL {
   public  class BooksDAL {
       private DBHerp.SQL Dbsql = new DBHerp.SQL();
       /// <summary>
       /// 根据年级，出版社，科目查询所有书籍 且Ispass=1
       /// </summary>
       /// <param name="Prid"></param>
       /// <param name="Grid"></param>
       /// <param name="suid"></param>
       /// <returns></returns>
       public  List<Model.TextBooks> SelectList(int Prid,int Grid,int suid) {
           string sql = string.Format("select t.* from [dbo].[TextBooks] t left join [dbo].[Press] p on t.prid=p.prid where t.prid={0} and GradeID={1} and ispass='1'  and SuID={2}", Prid, Grid, suid);
           return MoList(sql);
       }
       /// <summary>
       /// 根据出版社，科目查询所有高中的书籍 且Ispass=1
       /// </summary>
       /// <param name="Prid"></param>
       /// <param name="suid"></param>
       /// <returns></returns>
       public List<Model.TextBooks> SelectSuList(int Prid,int suid) {
           string sql = string.Format("select t.* from [dbo].[TextBooks] t left join [dbo].[Press] p on t.prid=p.prid where t.prid={0} and Study=3 and ispass='1' and SuID={1}", Prid,suid);
           return MoList(sql);
       }
       /// <summary>
       /// 根据年级和出版社查询学期
       /// </summary>
       /// <param name="PrName"></param>
       /// <param name="GrName"></param>
       /// <returns></returns>
       public List<Model.TextBooks> SelectByGrid_Prid(int Prid, int Grid) {
           string sql = string.Format("select distinct t.semester from textbooks t left join Press p on t.PrID=p.prid left join Grade g on t.GradeID = g.GradeID where g.GradeID='{0}' and p.Prid='{1}'", Grid, Prid);
           SqlConnection conn = new SqlConnection(DBHerp.SQL.connstr);
           conn.Open();
           SqlCommand cmd = new SqlCommand(sql, conn);
           SqlDataReader re = cmd.ExecuteReader(CommandBehavior.CloseConnection);
           List<Model.TextBooks> telist = new List<Model.TextBooks>();
           while (re.Read()) {
               Model.TextBooks Books = new Model.TextBooks();
               if (re["Semester"] == null) {
                   Books.Semester = "";
               } else {
                   Books.Semester = Convert.ToString(re["Semester"]);
               }
               telist.Add(Books);
           }
           re.Close(); re.Dispose();
           if (conn != null) {
               conn.Close();
               conn.Dispose();
           }
           return telist;
       }
       public List<Model.TextBooks> SelectFy(int ts, int ys) {
           string sql = string.Format("select top({0})* from [dbo].[TextBooks] where TextID not in (select Top({1}) TextID from [dbo].[TextBooks])", ts,ys);
           return MoList(sql);
       }
       //public int SelectCount() {
       //    string sql = string.Format("");
       //}
      /// <summary>
      /// 查询所有书籍  无条件
      /// </summary>
      /// <returns></returns>
       public  List<Model.TextBooks> Select() {
           string sql = string.Format("select * from TextBooks");
           return MoList(sql);
       }
       public List<Model.TextBooks> Select(Model.UserSet Se) {
           string sql = string.Format("select * from [dbo].[TextBooks] where  GradeID = '{0}'  and SuID='{2}' and Study='{3}'", Se.GradeID, Se.Semester, Se.SuID, Se.Study);
           return MoList(sql);
       }
       /// <summary>
       /// 根据课本ID 修改课本图片
       /// </summary>
       /// <param name="te"></param>
       /// <returns></returns>
       public  bool UpdateImg(Model.TextBooks te) {
           string sql = string.Format("update textbooks set img = '{0}' where TextID={1}",te.Img,te.Textid);
           return Dbsql.ExQuery(sql);
       }
       /// <summary>
       /// 根据课本ID查询书籍
       /// </summary>
       /// <param name="id"></param>
       /// <returns></returns>
       public  Model.TextBooks SelectByID(int id) {
           string sql = string.Format("select * from textbooks where textid = '{0}'",id);
           return Mo(sql);
       }
       /// <summary>
       /// 根据isbn  和年份查询书籍
       /// </summary>
       /// <param name="isbn"></param>
       /// <param name="year"></param>
       /// <returns></returns>
       public  Model.TextBooks SelectByISBN(string isbn, int year) {
           string sql = string.Format("select * from TextBooks where isbn='{0}' and year='{1}'", isbn,year);
           return Mo(sql);
       }
       /// <summary>
       /// 下面两个是帮助方法 一个返回集合 一个返回单个model
       /// </summary>
       /// <param name="sql"></param>
       /// <returns></returns>
       private  List<Model.TextBooks> MoList(string sql) {
           SqlConnection conn = new SqlConnection(DBHerp.SQL.connstr);
           conn.Open();
           SqlCommand cmd = new SqlCommand(sql, conn);
           SqlDataReader re = cmd.ExecuteReader(CommandBehavior.CloseConnection);
           List<Model.TextBooks> telist = new List<Model.TextBooks>();
           while (re.Read()) {
               Model.TextBooks Books = new Model.TextBooks();
               if (re["BooksName"] != null) {
                   Books.BooksName = re["BooksName"].ToString();
               }
               if (re["Img"] != null) {
                   Books.Img = re["Img"].ToString();
               }
               if (re["ISBN"] != null) {
                   Books.ISBN = re["ISBN"].ToString();
               }
               if (re["Prid"] != null) {
                   Books.Prid = Convert.ToInt32(re["Prid"]);
               }
               if (re["GradeID"] != null)
               {
                   Books.GradeID = Convert.ToInt32(re["GradeID"]);
               }
               if (re["study"] != null) {
                   Books.Study = Convert.ToInt32(re["study"]);
               }
               if (re["suid"] != null) {
                   Books.Suid = Convert.ToInt32(re["suid"]);
               }
               if (re["Textid"] != null) {
                   Books.Textid = Convert.ToInt32(re["Textid"]);
               }
               if (re["year"] != null) {
                   Books.Year = Convert.ToInt32(re["year"]);
               }if (re["Semester"] == null) {
                   Books.Semester = "";
               } else {
                   Books.Semester = Convert.ToString(re["Semester"]);
               }
               telist.Add(Books);
           }
           if (conn != null) {
               conn.Close();
               conn.Dispose();
           }
           return telist;
       }
       private  Model.TextBooks Mo(string sql) {
           SqlConnection conn = new SqlConnection(DBHerp.SQL.connstr);
           conn.Open();
           SqlCommand cmd = new SqlCommand(sql, conn);
         SqlDataReader re= cmd.ExecuteReader(CommandBehavior.CloseConnection);
           Model.TextBooks Books = new Model.TextBooks();
           if (re.Read()) {
               Books.BooksName = re["BooksName"].ToString();
               Books.Img = re["Img"].ToString();
               Books.ISBN = re["ISBN"].ToString();
               Books.Prid = Convert.ToInt32(re["Prid"]);
               Books.GradeID = Convert.ToInt32(re["GradeID"]);
               Books.Semester = Convert.ToString(re["Semester"]);
               Books.Study = Convert.ToInt32(re["study"]);
               Books.Suid = Convert.ToInt32(re["suid"]);
               Books.Textid = Convert.ToInt32(re["Textid"]);
               Books.Year = Convert.ToInt32(re["year"]);
           }
           re.Close();
           re.Dispose();
           if (conn != null) {
               conn.Close();
               conn.Dispose();
           }
           return Books;
       }
    }
}
