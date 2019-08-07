using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Model {
   public class VideoRoute {

       private int viIndex;
       public int ViIndex 
       {
           get { return viIndex; }
           set { viIndex = value; } 
       }
       private int vrid;

       public int VRID
       {
           get { return vrid; }
           set { vrid = value; }
       }
       private string htv;

       public string HTV {
           get { return htv; }
           set { htv = value; }
       }
       private string viName;

       public string ViName {
           get { return viName; }
           set { viName = value; }
       }
       private int viID;

       public int ViID
       {
           get { return viID; }
           set { viID = value; }
       }

       private int state;

       public int State {
           get { return state; }
           set { state = value; }
       }
       private int vip;

       public int Vip {
           get { return vip; }
           set { vip = value; }
       }
       private string mp4;

       public string Mp4 {
           get { return mp4; }
           set { mp4 = value; }
       }
    }
}
