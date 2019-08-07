using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace BLL {
  public   class IndexImgBLL {
      private DAL.IndexImgDAL DAL = new DAL.IndexImgDAL();
      public  List<Model.IndexImg> SelectList() {
          return DAL.SelectList();
      }
      public  bool Insert(Model.IndexImg im) {
          return DAL.Insert(im);
      }
      public  bool UpdateByID(Model.IndexImg im) {
          return DAL.UpdateByID(im);
      }
      public  List<Model.IndexImg> SelectState() {
          return DAL.SelectState();
      }
      public  Model.IndexImg SelectByID(int id) {
          return DAL.SelectByID(id);
      }
    }
}
