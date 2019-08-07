using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Data.SqlClient;
using System.Data;

namespace DAL {
   public  class CommentDAL {
       DBHerp.SQL db = new DBHerp.SQL();
       public bool Insert(string Substance,int Userid) {
           string sql = string.Format("insert into [dbo].[comment] values('{0}','{1}')",Substance,Userid,DateTime.Now,0);
           return db.ExQuery(sql);
       }
       private List<Model.Comment> MoList(string sql) {
           SqlConnection conn = new SqlConnection(DBHerp.SQL.connstr);
           conn.Open();
           SqlCommand cmd = new SqlCommand(sql, conn);
           SqlDataReader re = cmd.ExecuteReader();
           List<Model.Comment> CoList = new List<Model.Comment>();
           while(re.Read()){
               Model.Comment Co = new Model.Comment();
               Co.Coid = Convert.ToInt32(re["coid"]);
               Co.Ipid = Convert.ToInt32(re["Ipid"]);
               Co.Substance = re["Substance"].ToString();
               CoList.Add(Co);
           }
           return CoList;
       }
       private Model.Comment Mo(string sql) {
           SqlConnection conn = new SqlConnection(DBHerp.SQL.connstr);
           conn.Open();
           SqlCommand cmd = new SqlCommand(sql, conn);
           SqlDataReader re = cmd.ExecuteReader();
           Model.Comment Co = new Model.Comment();
           if (re.Read()) {
               Co.Coid = Convert.ToInt32(re["coid"]);
               Co.Ipid = Convert.ToInt32(re["Ipid"]);
               Co.Substance = re["Substance"].ToString();
           }
           return Co;
       }
    }
}
