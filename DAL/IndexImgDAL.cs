using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Data.SqlClient;
using System.Data;

namespace DAL {
   public  class IndexImgDAL {
       private DBHerp.SQL Dbsql = new DBHerp.SQL();
       public  List<Model.IndexImg> SelectList() {
           string sql = string.Format("select * from IndexImg");
           return MList(sql);
       }
       public  bool Insert(Model.IndexImg im) {
           string sql = string.Format("insert into IndexImg values('{0}','{1}','{2}','{3}')",im.ImgPic,im.State,im.ImgName,im.Href);
           return Dbsql.ExQuery(sql);
       }
       public  bool UpdateByID(Model.IndexImg im) {
           string sql = string.Format("Update Indeximg set imgpic='{0}',[state]='{1}',ImgName='{2}',Href='{3}' where ImgID='{4}'", im.ImgPic, im.State, im.ImgName, im.Href, im.ImgID);
           return Dbsql.ExQuery(sql);
       }
       public  List<Model.IndexImg> SelectState() {
           string sql = string.Format("Select * from Indeximg where state='1'");
           return MList(sql);
       }
       public  Model.IndexImg SelectByID(int id) {
           string sql = string.Format("Select * from Indeximg where ImgID='{0}'", id);
           return Mod(sql);
       }
       private List<Model.IndexImg> MList(string sql) {
           SqlConnection conn = new SqlConnection(DBHerp.SQL.connstr);
           conn.Open();
           SqlCommand cmd = new SqlCommand(sql, conn);
           SqlDataReader re = cmd.ExecuteReader(CommandBehavior.CloseConnection);
           List<Model.IndexImg> Inlist = new List<Model.IndexImg>();
           while (re.Read()) {
               Model.IndexImg im = new Model.IndexImg();
               if (re["href"] != null) {
                   im.Href = re["href"].ToString();
               }
               if (re["ImgID"] != null)
               {
                   im.ImgID = Convert.ToInt32(re["ImgID"]);
               }
               if (re["imgname"] != null) {
                   im.ImgName = re["imgname"].ToString();
               }
               if (re["imgpic"] != null) {
                   im.ImgPic = re["imgpic"].ToString();
               }
               if (re["state"] != null) {
                   im.State = Convert.ToInt32(re["state"]);
               }
               Inlist.Add(im);
           }
           re.Close(); re.Dispose();
           if (conn != null) {
               conn.Close();
               conn.Dispose();
           }
           return Inlist;
       }
       private Model.IndexImg Mod(string sql) {
           SqlConnection conn = new SqlConnection(DBHerp.SQL.connstr);
           conn.Open();
           SqlCommand cmd = new SqlCommand(sql, conn);
           SqlDataReader re = cmd.ExecuteReader(CommandBehavior.CloseConnection);
           Model.IndexImg im = new Model.IndexImg();
           if (re.Read()) {
               if (re["href"] != null) {
                   im.Href = re["href"].ToString();
               }
               if (re["ImgID"] != null)
               {
                   im.ImgID = Convert.ToInt32(re["ImgID"]);
               }
               if (re["imgname"] != null) {
                   im.ImgName = re["imgname"].ToString();
               }
               if (re["imgpic"] != null) {
                   im.ImgPic = re["imgpic"].ToString();
               }
               if (re["state"] != null) {
                   im.State = Convert.ToInt32(re["state"]);
               }
           }
           re.Close(); re.Dispose();
           if (conn != null) {
               conn.Close();
               conn.Dispose();
           }
           return im;
       }
    }
}
