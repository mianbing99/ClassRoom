using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Model {
   public class Grade {
       private int gradeID;

       public int GradeID
       {
           get { return gradeID; }
           set { gradeID = value; }
       }
       private string grName;

       public string GrName {
           get { return grName; }
           set { grName = value; }
       }
    }
}
