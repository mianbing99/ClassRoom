using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace BLL {
   public  class TestBLL {
       DAL.TestDAL Dal = new DAL.TestDAL();
       public List<Model.Test> Select() {
           return Dal.Select();
       }
       public List<Model.Test> SelectBySu(string SuName) {
           return Dal.SelectBySu(SuName);
       }
    }
}
