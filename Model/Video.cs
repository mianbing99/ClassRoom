using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Model {
   public class Video {
       private int viid;

       public int Viid {
           get { return viid; }
           set { viid = value; }
       }
       private string viName;

       public string ViName {
           get { return viName; }
           set { viName = value; }
       }
    }
}
