using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace BLL {
   public  class GradeBLL {
       private DAL.GradeDAl DAL = new DAL.GradeDAl();
       public  List<Model.Grade> SeleteName(int study) {
           return DAL.selectName(study);
       }
       public  Model.Grade SelectByGrid(int id) {
           return DAL.SelectByGrid(id);
       }
       public List<Model.Grade> selectgrade()
       {
           return DAL.selectgrade();
       }
       public List<Model.Roles> selectRole()
       {
           return DAL.selectRole();
       }
    }
}
