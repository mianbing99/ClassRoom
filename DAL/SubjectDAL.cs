using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Text;

namespace DAL {
   public  class SubjectDAL {
       private DBHerp.SQL Dbsql = new DBHerp.SQL();
       public  Model.Subject SelectBySuid(int id ) {
           string sql = string.Format("select * from subject where suid= '{0}'",id);
           return Mo(sql);
       }
       public List<Model.Subject> SelectSuList(int prid) {
           string sql = string.Format("select distinct s.* from [Subject] s left join  TextBooks t on t.suid = s.suid where t.Study=3 and PrID={0}",prid);
           return MoList(sql);
       }
       public List<Model.Subject> SelectGaozhong() {
           string sql = string.Format("select * from Subject where Suid in( select SuID from textbooks where Study=3)");
           return MoList(sql);
       }
       public List<Model.Subject> Select(string GrName) {
           string sql = string.Format("select distinct s.Suid,s.SuName from  [dbo].[TextBooks] t left join [dbo].[Grade] g on g.GradeID = t.GradeID left join [dbo].[Subject] s on s.Suid = t.SuID where g.GrName='{0}'", GrName);
           return MoList(sql);
       }
       public List<Model.Subject> SelectGrList(int Prid,int grid) {
           string sql = string.Format("select distinct s.* from [Subject] s left join  TextBooks t on t.suid = s.suid where t.GradeID={0} and PrID={1}", grid, Prid);
           return MoList(sql);
       }
       public List<Model.Subject> SelectList()
       {
           string sql = string.Format("select * from  [dbo].[Subject]  ");
           return MoList(sql);
       }
       private Model.Subject Mo(string sql) {
           SqlConnection conn = new SqlConnection(DBHerp.SQL.connstr);
           conn.Open();
           SqlCommand cmd = new SqlCommand(sql, conn);
           SqlDataReader re = cmd.ExecuteReader(CommandBehavior.CloseConnection);
           Model.Subject Su = new Model.Subject();
           if (re.Read()) {
               Su.Suid = Convert.ToInt32(re["Suid"]);
               Su.SuName = re["SuName"].ToString();
           }
           if (conn != null) {
               conn.Close();
               conn.Dispose();
           }
           return Su;
       }
       private List<Model.Subject> MoList(string sql) {
           SqlConnection conn = new SqlConnection(DBHerp.SQL.connstr);
           conn.Open();
           SqlCommand cmd = new SqlCommand(sql, conn);
           SqlDataReader re = cmd.ExecuteReader(CommandBehavior.CloseConnection);
           List<Model.Subject> Sulist = new List<Model.Subject>();
           while (re.Read()) {
               Model.Subject Su = new Model.Subject();
               Su.Suid = Convert.ToInt32(re["Suid"]);
               Su.SuName = re["SuName"].ToString();
               Sulist.Add(Su);
           }
           if (conn != null) {
               conn.Close();
               conn.Dispose();
           }
           return Sulist;
       }
    }
}
