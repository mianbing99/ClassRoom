using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Text;

namespace DAL {
   public  class UserDAL {
       DBHerp.SQL db = new DBHerp.SQL();
       /// <summary>
       /// 注册
       /// </summary>
       /// <param name="us"></param>
       /// <returns></returns>
       public bool UserAdd(Model.User us) {
           string sql = string.Format("insert into [User] values('{0}','1','{1}','{2}','{3}','{4}')", us.Pwd, us.Phone, us.OpenID, us.DeviceID, us.RegisterTime);
       return db.ExQuery(sql);
       }
       /// <summary>
       /// 登录的判断
       /// </summary>
       /// <param name="Us"></param>
       /// <returns></returns>
       public Model.User UserLogin(Model.User Us) {
           string sql = string.Format("select * from [User] where Phone='{0}' and pwd='{1}' ",Us.Phone,Us.Pwd);
           return Mo(sql);
       }
       /// <summary>
       /// 验证账号是否存在
       /// </summary>
       /// <param name="Us"></param>
       /// <returns></returns>
       public bool UserYanz(string Phone) {
           string sql = string.Format("select count(*) from [User] where Phone='{0}'", Phone);
           if (db.ExScalar(sql) > 0) {
               return false;
           } else {
               return true;
           }
       }
       /// <summary>
       /// 验证账号是否存在 +1重载 string Phone 
       /// </summary>
       /// <param name="Userid"></param>
       /// <param name="Openid"></param>
       /// <returns></returns>
       public bool UserYanz(int Userid,string Openid) {
           string sql = string.Format("select * from [dbo].[User] where Userid = '{0}' and Openid='{1}'", Userid, Openid);
           if (db.ExScalar(sql) > 0) {
               return true;
           } else {
               return  false;
           }
       }
       public int SelectUseridByPhone(string Phone) {
           string sql = string.Format("select Userid from [User] where Phone='{0}'",Phone);
           return Convert.ToInt32(db.ExScalar(sql));
       }
       /// <summary>
       /// 根据userid 修改密码
       /// </summary>
       /// <param name="userid"></param>
       /// <param name="pwd"></param>
       /// <returns></returns>
       public bool UpdatePwd(int userid, string pwd) {
           string sql = string.Format("update [user] set pwd = '{0}' where userid='{1}'",pwd,userid);
           return db.ExQuery(sql);
       }
       private List<Model.User> MoList(string sql) {
           SqlConnection conn = new SqlConnection(DBHerp.SQL.connstr);
           conn.Open();
           SqlCommand cmd = new SqlCommand(sql, conn);
           SqlDataReader re = cmd.ExecuteReader(CommandBehavior.CloseConnection);
           List<Model.User> UsList = new List<Model.User>();
           while (re.Read()) {
               Model.User Us = new Model.User();
               Us.UserID = Convert.ToInt32(re["Userid"]);
               Us.Ispass = Convert.ToInt32(re["ispass"]);
               Us.Pwd = re["pwd"].ToString();
               Us.Phone = re["Phone"].ToString();
               Us.RegisterTime = Convert.ToDateTime(re["RegisterTime"]);
               Us.DeviceID = re["deviceid"].ToString();
               Us.OpenID = re["Openid"].ToString();
               UsList.Add(Us);
           }
           return UsList;
       }
       private Model.User Mo(string sql ) {
           SqlConnection conn = new SqlConnection(DBHerp.SQL.connstr);
           conn.Open();
           SqlCommand cmd = new SqlCommand(sql, conn);
           SqlDataReader re = cmd.ExecuteReader(CommandBehavior.CloseConnection);
           Model.User Us = new Model.User();
           if (re.Read()) {
               Us.UserID = Convert.ToInt32(re["Userid"]);
               Us.Ispass = Convert.ToInt32(re["ispass"]);
               Us.Pwd = re["pwd"].ToString();
               Us.Phone = re["Phone"].ToString();
               Us.RegisterTime = Convert.ToDateTime(re["RegisterTime"]);
               Us.DeviceID = re["deviceid"].ToString();
               Us.OpenID = re["Openid"].ToString();
           }
           return Us;
       }
    }
}
