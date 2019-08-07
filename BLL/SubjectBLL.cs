using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace BLL {
  public   class SubjectBLL {
      private DAL.SubjectDAL DAL = new DAL.SubjectDAL();
      public  Model.Subject SelectBySuid(int id) {
          return DAL.SelectBySuid(id);
      }
      public List<Model.Subject> SelectSuList(int prid) {
          return DAL.SelectSuList(prid);
      }
      public List<Model.Subject> SelectGrList(int Prid, int grid) {
          return DAL.SelectGrList(Prid,grid);
      }
      public List<Model.Subject> Select(string GrName) {
          return DAL.Select(GrName);
      }
      public List<Model.Subject> SelectGaozhong() {
          return DAL.SelectGaozhong();
      }
      public List<Model.Subject> SelectList()
      {
          return DAL.SelectList();
      }
    }
}
