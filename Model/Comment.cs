using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Model {
   public  class Comment {
       private int coid;

       public int Coid {
           get { return coid; }
           set { coid = value; }
       }
       private string substance;

       public string Substance {
           get { return substance; }
           set { substance = value; }
       }
       private int ipid;

       public int Ipid {
           get { return ipid; }
           set { ipid = value; }
       }
    }
}
