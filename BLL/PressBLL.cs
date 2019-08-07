using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using DAL;
using System.Data;

namespace BLL {
   public  class PressBLL {
       private DAL.PressDAL DAL = new DAL.PressDAL();
       public  List<Model.Press> Selectlist(int Grid) {
           return DAL.Selectlist(Grid);
       }
       public List<Model.Press> SelectStu() {
           return DAL.SelectStu();
       }
       public List<Model.Press> SelectList() {
           return DAL.SelectList();
       }
       //登录查询所有管理员信息
       public static bool LoginSelect(string user, string pwd)
       {
           return PressDAL.LoginSelect(user, pwd);
       }
       //修改密码
       public static int UpdateCancel(string name, string pwd)
       {
           return PressDAL.UpdateCancel(name, pwd);
       }

       //查询用户信息
       public static DataTable SelectUser()
       {
           return PressDAL.SelectUser();
       }

       //根据用户名和角色查询用户信息
       public static DataTable MoHuselectRoleName(string username, string rolename)
       {
           return PressDAL.MoHuselectRoleName(username, rolename);
       }
       //根据用户名查询用户信息
       public static DataTable MoHuselectUser(string username)
       {
           return PressDAL.MoHuselectUser(username);
       }
       //根据角色查询用户信息
       public static DataTable MoHuselectRole(string rolename)
       {
           return PressDAL.MoHuselectRole(rolename);
       }
       //增加用户信息
       public static int InsertUser(string username, string rolename)
       {
           return PressDAL.InsertUser(username, rolename);
       }

       //删除用户信息
       public static int DeleteUser(int userid)
       {
           return PressDAL.DeleteUser(userid);
       }

       //修改用户信息
       public static int UpdateUser(string username, string rolename, int userid)
       {
           return PressDAL.UpdateUser(username, rolename, userid);
       }
    }
}
