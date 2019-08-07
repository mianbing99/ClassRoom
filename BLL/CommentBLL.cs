using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace BLL {
  public   class CommentBLL {
      DAL.CommentDAL Dal = new DAL.CommentDAL();
      public bool Insert(string Substance, int Userid) {
          return Dal.Insert(Substance,Userid);
      }
    }
}
