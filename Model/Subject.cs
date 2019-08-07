using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Model {
   public class Subject {
       private int suid;

       public int Suid {
           get { return suid; }
           set { suid = value; }
       }
       private string suName;

       public string SuName {
           get { return suName; }
           set { suName = value; }
       }
    }
}
