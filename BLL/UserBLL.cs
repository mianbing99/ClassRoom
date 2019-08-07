using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace BLL {
   public  class UserBLL {
       private DAL.UserDAL dal = new DAL.UserDAL();
       public bool UserAdd(Model.User us) {
           return dal.UserAdd(us);
       }
       public Model.User UserLogin(Model.User Us) {
           return dal.UserLogin(Us);
       }
       /// <summary>
       /// 根据userid,openid验证账号是否存在， 重载 根据phone 验证账号是否存在
       /// </summary>
       /// <param name="Userid"></param>
       /// <param name="Openid"></param>
       /// <returns></returns>
       public bool UserYanz(int Userid, string Openid) {
           return dal.UserYanz(Userid, Openid);
       }
       public bool UserYanz(string Phone) {
           return dal.UserYanz(Phone);
       }
       public int SelectUseridByPhone(string Phone) {
           return dal.SelectUseridByPhone(Phone);
       }
       /// <summary>
       /// 根据userid 修改密码
       /// </summary>
       /// <param name="userid"></param>
       /// <param name="pwd"></param>
       /// <returns></returns>
       public bool UpdatePwd(int userid, string pwd) {
           return dal.UpdatePwd(userid,pwd);
       }
    }
}
