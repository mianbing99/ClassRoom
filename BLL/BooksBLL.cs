using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace BLL {
   public  class BooksBLL {
       private DAL.BooksDAL DAL = new DAL.BooksDAL();
       public List<Model.TextBooks> SelectList(int prid, int grid, int suid) {
           return DAL.SelectList(prid, grid, suid);
       }
       public List<Model.TextBooks> SelectSuList(int Prid,int suid) {
           return DAL.SelectSuList(Prid, suid);
       }
       public List<Model.TextBooks> Select(Model.UserSet Se) {
           return DAL.Select(Se);
       }
       public  List<Model.TextBooks> Select() {
           return DAL.Select();
       }
       public List<Model.TextBooks> SelectByGrid_Prid(int Prid, int Grid) {
           return DAL.SelectByGrid_Prid(Prid, Grid);
       }
       public  bool UpdateImg(Model.TextBooks te) {
           return DAL.UpdateImg(te);
       }
       public  Model.TextBooks SelectByID(int id) {
           return DAL.SelectByID(id);
       }
       public  Model.TextBooks SelectByISBN(string isbn, int year) {
           return DAL.SelectByISBN(isbn,year);
       }
    }
}
