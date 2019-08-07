using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Data.SqlClient;
using System.Data;

namespace DAL {
   public  class UserSetDAL {

       DBHerp.SQL Db = new DBHerp.SQL();
       public bool Insert(Model.UserSet Se) {
           string sql = string.Format("insert into UserSet values('{0}','{1}','{2}','{3}','{4}')", Se.UserID, Se.GradeID, Se.Semester, Se.Study, Se.SuID);
       return Db.ExQuery(sql);
       }
       public bool Insert(string GrName, string SuName, int Userid) {
           string select = string.Format("select * from [UserSet] where Userid={0}",Userid);
          Model.UserSet moset= Mod(select);
          string sql = string.Empty;
          if (moset.SeID == 0) {
              sql = string.Format("insert into [dbo].[UserSet](SuID,GradeID,Study) select distinct s.suid,g.GradeID,t.Study from [dbo].[TextBooks] t left join [dbo].[Grade] g on t.GradeID=g.GradeID left join  [dbo].[Subject] s on t.SuID = s.Suid where g.GrName='{0}' and s.suname='{1}' select @@identity", GrName, SuName);
              int id = Db.ExScalar(sql);
              sql = string.Format("Update userset set Userid='{0}' where seid='{1}'",Userid,id);
          } else {
              sql = string.Format(@"update UserSet set GradeID= (select distinct g.GradeID from [dbo].[TextBooks] t left join [dbo].[Grade] g on t.GradeID=g.GradeID left join  [dbo].[Subject] s on t.SuID = s.Suid where g.GrName='{0}' and s.suname='{1}' ), 
study = (select distinct t.study from [dbo].[TextBooks] t left join [dbo].[Grade] g on t.GradeID=g.GradeID left join  [dbo].[Subject] s on t.SuID = s.Suid where g.GrName='{0}' and s.suname='{1}' ),
suid =(select distinct s.Suid from [dbo].[TextBooks] t left join [dbo].[Grade] g on t.GradeID=g.GradeID left join  [dbo].[Subject] s on t.SuID = s.Suid where g.GrName='{0}' and s.suname='{1}' ) where Userid={2}", GrName, SuName, Userid);
          }
          return Db.ExQuery(sql);
       }
       public Model.UserSet SelectByUserid(int UserID) {
           string sql = string.Format("select * from UserSet where UserID = '{0}'",UserID);
           return Mod(sql);
       }
       public bool UpdateByUserid(Model.UserSet Se) {
           string sql = string.Format("update [dbo].[UserSet] set GradeID='{0}',Semester='{1}',Study='{2}',SuID='{3}' where Userid='{4}'", Se.GradeID, Se.Semester, Se.Study, Se.SuID, Se.UserID);
           return Db.ExQuery(sql);
       }
       private List<Model.UserSet> Mlist(string sql ) {
           SqlConnection conn = new SqlConnection(DBHerp.SQL.connstr);
           conn.Open();
           SqlCommand cmd = new SqlCommand(sql, conn);
           SqlDataReader re = cmd.ExecuteReader(CommandBehavior.CloseConnection);
           List<Model.UserSet> SeList = new List<Model.UserSet> ();
           while(re.Read()){
               Model.UserSet Se = new Model.UserSet();
               if (re["seid"] != null) {
                   Se.SeID = Convert.ToInt32(re["SeID"]);
               }
               if (re["GradeID"] != null)
               {
                   Se.GradeID = Convert.ToInt32(re["GradeID"]);
               }
               if (re["SuID"] != null) {
                   Se.SuID = Convert.ToInt32(re["PrID"]);
               }
               if (re["Study"] != null) {
                   Se.Study = Convert.ToInt32(re["Study"]);
               }
               if (re["Userid"] != null) {
                   Se.UserID = Convert.ToInt32(re["Userid"]);
               }
               if (re["semester"] != null) {
                   Se.Semester = re["semester"].ToString();
               } 
               SeList.Add(Se);
           }
           return SeList;
       }
       private Model.UserSet Mod(string sql) {
           SqlConnection conn = new SqlConnection(DBHerp.SQL.connstr);
           conn.Open();
           SqlCommand cmd = new SqlCommand(sql, conn);
           SqlDataReader re = cmd.ExecuteReader(CommandBehavior.CloseConnection);
           Model.UserSet Se = new Model.UserSet();
           if(re.Read()) {
               if (re["seid"] != null) {
                   Se.SeID = Convert.ToInt32(re["SeID"]);
               }
               if (re["GradeID"] != null)
               {
                   Se.GradeID = Convert.ToInt32(re["GradeID"]);
               }
               if (re["SuID"] != null) {
                   Se.SuID = Convert.ToInt32(re["SuID"]);
               }
               if (re["Study"] != null) {
                   Se.Study = Convert.ToInt32(re["Study"]);
               }
               if (re["Userid"] != null) {
                   Se.UserID = Convert.ToInt32(re["Userid"]);
               }
               if (re["semester"] != null) {
                   Se.Semester = re["semester"].ToString();
               } 
           }
           return Se;
       }

       
    }
}
