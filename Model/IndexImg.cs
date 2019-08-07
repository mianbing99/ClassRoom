using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Model {
   public class IndexImg {
       private int imgID;

       public int ImgID
       {
           get { return imgID; }
           set { imgID = value; }
       }
       private string imgPic;

       public string ImgPic {
           get { return imgPic; }
           set { imgPic = value; }
       }
       private string imgName;

       public string ImgName {
           get { return imgName; }
           set { imgName = value; }
       }
       private string href;

       public string Href {
           get { return href; }
           set { href = value; }
       }
       private int state;

       public int State {
           get { return state; }
           set { state = value; }
       }
    }
}
