using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Data.SqlClient;
using System.Data;

namespace DAL {
  public    class PressDAL {
      private DBHerp.SQL Dbsql = new DBHerp.SQL();
      public  List<Model.Press> Selectlist(int Grid) {
          string sql = string.Format("select distinct p.* from [dbo].[TextBooks] t left join [dbo].[Press] p on t.prid=p.prid where GradeID={0}", Grid);
          return Mlist(sql);
      }
      public List<Model.Press> SelectList() {
          string sql = string.Format("select * from  [dbo].[Press]  ");
          return Mlist(sql);
      }
      public List<Model.Press> SelectStu() {
          string sql = string.Format("select distinct p.* from [dbo].[TextBooks] t left join [dbo].[Press] p on t.prid=p.prid where Study=3");
          return Mlist(sql);
      }
      private List<Model.Press> Mlist(string sql) {
          SqlConnection conn = new SqlConnection(DBHerp.SQL.connstr);
          conn.Open();
          SqlCommand cmd = new SqlCommand(sql, conn);
          SqlDataReader re = cmd.ExecuteReader(CommandBehavior.CloseConnection);
          List<Model.Press> Prlist = new List<Model.Press>();
          while (re.Read()) {
              Model.Press pr = new Model.Press();
              pr.Prid = Convert.ToInt32(re["prid"]);
              pr.PrName = re["PrName"].ToString();
              Prlist.Add(pr);
          }
          return Prlist;
      }
      private Model.Press Mde(string sql ) {
          SqlConnection conn = new SqlConnection(DBHerp.SQL.connstr);
          conn.Open();
          SqlCommand cmd = new SqlCommand(sql, conn);
          SqlDataReader re = cmd.ExecuteReader(CommandBehavior.CloseConnection);
          Model.Press pr = new Model.Press();
          if (re.Read()) {
              pr.Prid = Convert.ToInt32(re["prid"]);
              pr.PrName = re["PrName"].ToString();
          }
          return pr;
      }
      //登录查询所有管理员信息SqlParameter防注入
      public static bool LoginSelect(string user, string pwd)
      {
          Model.Admins admins = new Model.Admins();
          bool isok = false;
          SqlConnection conn = null;
          try
          {
              conn = DBHerp.SQL.Getconn();
              DBHerp.SQL.OpenConn();
              string sql = "select * from Admins where AdminName=@user and AdminPwd=@pwd";
              SqlCommand cmd = new SqlCommand(sql, conn);
              SqlParameter[] par = { new SqlParameter("@user", user), new SqlParameter("@pwd", pwd) };
              cmd.Parameters.AddRange(par);
              SqlDataReader dr = cmd.ExecuteReader();
              while (dr.Read())
              {
                  admins.AdminID = int.Parse(dr["AdminID"].ToString());
                  admins.AdminName = user;
                  admins.AdminPwd = pwd;
                  admins.RolesID = int.Parse(dr["RolesID"].ToString());
                  isok = true;
              }
              return isok;
          }
          catch (Exception e)
          {
              String msg = "数据库异常！";
              throw new Exception(e.Message); 
          }
          finally
          {
              DBHerp.SQL.CloseConn();
          }
      }

      //修改密码SqlParameter防注入
      public static int UpdateCancel(string name, string pwd)
      {
          SqlConnection conn = null;
          try
          {
              conn = DBHerp.SQL.Getconn();
              string sql = "Update [User] set Pwd=@pwd where Userid=@name";
              DBHerp.SQL.OpenConn();
              SqlCommand cmd = new SqlCommand(sql, conn);
              SqlParameter[] par = { new SqlParameter("@name", name), new SqlParameter("@pwd", pwd) };
              cmd.Parameters.AddRange(par);
              int count = cmd.ExecuteNonQuery();
              if (count > 0)
              {
                  return count;
              }
              return 0;
          }
          catch (Exception)
          {

              throw;
          }
          finally
          {
              DBHerp.SQL.CloseConn();
          }

      }

      //查询用户信息
      public static DataTable SelectUser()
      {
          string sql = "select a.AdminID,a.AdminName,r.RoleName from Admins a left join Roles r on a.RolesID=r.RolesID";
          return DBHerp.SQL.Query(sql);
      }
      //根据用户名和角色查询用户信息
      public static DataTable MoHuselectRoleName(string username, string rolename)
      {
          string sql = "select * from  Roles where AdminName like '%" + username + "%' and rolename  like '%" + rolename + "%'";
          return DBHerp.SQL.Query(sql);
      }
      //根据用户名查询用户信息
      public static DataTable MoHuselectUser(string username)
      {
          string sql = "select * from  Roles where AdminName like '%" + username + "%'";
          return DBHerp.SQL.Query(sql);
      }
      //根据角色查询用户信息
      public static DataTable MoHuselectRole(string rolename)
      {
          string sql = "select * from Roles where rolename like '%" + rolename + "%'";
          return DBHerp.SQL.Query(sql);
      }
      //增加用户信息
      public static int InsertUser(string username, string rolename)
      {
          string sql = string.Format("insert into Roles values('{0}','{1}')", username, rolename);
          return DBHerp.SQL.ds(sql);
      }
      //删除用户信息
      public static int DeleteUser(int userid)
      {
          string sql = "delete from Roles where RolesID=" + userid + "";
          return DBHerp.SQL.ds(sql);
      }
      //修改用户信息
      public static int UpdateUser(string username, string rolename, int userid)
      {
          string sql = string.Format("Update Roles set AdminName='{0}',RoleName='{1}' where RolesID='{2}' ", username, rolename, userid);
          return DBHerp.SQL.ds(sql);
      }
    }
}
