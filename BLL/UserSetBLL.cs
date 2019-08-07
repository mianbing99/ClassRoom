using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace BLL {
   public  class UserSetBLL {
       private DAL.UserSetDAL dal = new DAL.UserSetDAL();
       public bool Insert(Model.UserSet se) {
           return dal.Insert(se);
       }
       public Model.UserSet SelectByUserid(int UserID) {
           return dal.SelectByUserid(UserID);
       }    
       public bool UpdateByUserid(Model.UserSet Se) {
           return dal.UpdateByUserid(Se);
       }
       public bool Insert(string GrName, string SuName, int Userid) {
           return dal.Insert(GrName, SuName, Userid);
       }

       public System.Data.DataTable SelectUserSet(int Userid)
       {
           throw new NotImplementedException();
       }
   }
}
