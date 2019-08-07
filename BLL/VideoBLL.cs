using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace BLL {
   public  class VideoBLL {
       DAL.VideoDAL dal = new DAL.VideoDAL();
       public int Insert(string Caname) {
           return dal.Insert(Caname);
       }
    }
}
