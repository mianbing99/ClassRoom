using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Model {
  public  class User {
      private int userID;

      public int UserID {
          get { return userID; }
          set { userID = value; }
      }
      
      private string pwd;

      public string Pwd {
          get { return pwd; }
          set { pwd = value; }
      }
      private int ispass;

      public int Ispass {
          get { return ispass; }
          set { ispass = value; }
      }
      private string phone;

      public string Phone {
          get { return phone; }
          set { phone = value; }
      }
      private string openID;

      public string OpenID {
          get { return openID; }
          set { openID = value; }
      }
      private string deviceID;

      public string DeviceID {
          get { return deviceID; }
          set { deviceID = value; }
      }
      private DateTime registerTime;

      public DateTime RegisterTime
      {
          get { return registerTime; }
          set { registerTime = value; }
      }
    }
}
