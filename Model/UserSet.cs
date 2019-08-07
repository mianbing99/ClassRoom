using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Model {
   public  class UserSet {
       private int seID;

       public int SeID {
           get { return seID; }
           set { seID = value; }
       }
       private int userID;

       public int UserID {
           get { return userID; }
           set { userID = value; }
       }
       private int gradeID;

       public int GradeID
       {
           get { return gradeID; }
           set { gradeID = value; }
       }
       private string semester;

       public string Semester {
           get { return semester; }
           set { semester = value; }
       }
       private int study;

       public int Study {
           get { return study; }
           set { study = value; }
       }
       private int suID;

       public int SuID {
           get { return suID; }
           set { suID = value; }
       }
    }
}
