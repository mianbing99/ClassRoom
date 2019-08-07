using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Model {
   public  class Press {
       private int prid;

       public int Prid {
           get { return prid; }
           set { prid = value; }
       }
       private string prName;

       public string PrName {
           get { return prName; }
           set { prName = value; }
       }
       public string Userid;
       public string Pwd;
    }
}
