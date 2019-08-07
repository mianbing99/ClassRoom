using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Model {
  public  class Card {
      private int cardid;

      public int Cardid {  //主键ID
          get { return cardid; }
          set { cardid = value; }
      }
      private int sN;

      public int SN { // 卡密编号
          get { return sN; }
          set { sN = value; }
      }
      private string account;

      public string Account { //卡密账号
          get { return account; }
          set { account = value; }
      }
      private string password;

      public string Password {  //密码
          get { return password; }
          set { password = value; }
      }
      private string edition;

      public string Edition {  //版本
          get { return edition; }
          set { edition = value; }
      }
      private string cModel;

      public string CModel {  // 型号
          get { return cModel; }
          set { cModel = value; }
      }
      private string customer;

      public string Customer {  //客户
          get { return customer; }
          set { customer = value; }
      }
      private DateTime createTime;

      public DateTime CreateTime {  //创建时间
          get { return createTime; }
          set { createTime = value; }
      }
      private DateTime activationTime;

      public DateTime ActivationTime {  // 激活时间
          get { return activationTime; }
          set { activationTime = value; }
      }
      private DateTime outTime;

      public DateTime OutTime {  //到期时间
          get { return outTime; }
          set { outTime = value; }
      }
      private int userid;

      public int Userid {  //用户表外键
          get { return userid; }
          set { userid = value; }
      }
    }
}
