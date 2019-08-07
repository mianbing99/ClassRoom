using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Model {
   public  class TextBooks {
       private int textid;

       public int Textid {
           get { return textid; }
           set { textid = value; }
       }
       private string iSBN;

       public string ISBN {
           get { return iSBN; }
           set { iSBN = value; }
       }
       private string booksName;

       public string BooksName {
           get { return booksName; }
           set { booksName = value; }
       }
       private int suid;

       public int Suid {
           get { return suid; }
           set { suid = value; }
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
       private int prid;

       public int Prid {
           get { return prid; }
           set { prid = value; }
       }
       private string img;

       public string Img {
           get { return img; }
           set { img = value; }
       }
       private int year;

       public int Year {
           get { return year; }
           set { year = value; }
       }
    }
}
