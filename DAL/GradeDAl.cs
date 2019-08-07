using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Data.SqlClient;
using System.Data;

namespace DAL {
   public  class GradeDAl {
       private DBHerp.SQL Dbsql = new DBHerp.SQL();
       public  List<Model.Grade> selectName(int study) {
           string sql = string.Format("select distinct g.* from  Grade g left join  [dbo].[TextBooks] t  on t.GradeID = g.GradeID where Study={0};", study);
           return MoList(sql);
       }
       public  Model.Grade SelectByGrid(int id) {
           string sql = string.Format("select * from Grade where GradeID = '{0}'", id);
           return Mo(sql);
       }
       public List<Model.Grade> selectgrade()
       {
           string sql = string.Format("select * from  [dbo].[Grade]  ");
           return MoList(sql);
       }
       private Model.Grade Mo(string sql) {
           SqlConnection conn = new SqlConnection(DBHerp.SQL.connstr);
           conn.Open();
           SqlCommand cmd = new SqlCommand(sql, conn);
           SqlDataReader re = cmd.ExecuteReader(CommandBehavior.CloseConnection);
           Model.Grade gr = new Model.Grade();
           if (re.Read()) {
               gr.GradeID = Convert.ToInt32(re["GradeID"]);
               gr.GrName = re["grname"].ToString();
           }
           if (conn != null) {
               conn.Close();
               conn.Dispose();
           }
           return gr;
       }
       private  List<Model.Grade> MoList(string sql) {
           SqlConnection conn = new SqlConnection(DBHerp.SQL.connstr);
           conn.Open();
           SqlCommand cmd = new SqlCommand(sql, conn);
           SqlDataReader re = cmd.ExecuteReader(CommandBehavior.CloseConnection);
           List<Model.Grade> grlist = new List<Model.Grade>();
           while (re.Read()) {
               Model.Grade gr = new Model.Grade();
               gr.GradeID = Convert.ToInt32(re["GradeID"]);
               gr.GrName = re["grname"].ToString();
               grlist.Add(gr);
           }
           if (conn != null) {
               conn.Close();
               conn.Dispose();
           }
           return grlist;
       }
       public List<Model.Roles> selectRole()
       {
           string sql = string.Format("select * from Roles; ");
           return RoleList(sql);
       }
       private List<Model.Roles> RoleList(string sql)
       {
           SqlConnection conn = new SqlConnection(DBHerp.SQL.connstr);
           conn.Open();
           SqlCommand cmd = new SqlCommand(sql, conn);
           SqlDataReader re = cmd.ExecuteReader(CommandBehavior.CloseConnection);
           List<Model.Roles> grlist = new List<Model.Roles>();
           while (re.Read())
           {
               Model.Roles rl = new Model.Roles();
               rl.RolesID = Convert.ToInt32(re["RolesID"]);
               //rl.AdminName = re["AdminName"].ToString();
               rl.RoleName = re["RoleName"].ToString();
               //rl.RoleState = re["rolestate"].ToString();
               grlist.Add(rl);
           }
           if (conn != null)
           {
               conn.Close();
               conn.Dispose();
           }
           return grlist;
       }
    }
}
