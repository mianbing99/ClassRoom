using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using BLL;
using DAL;

namespace BLL {
   public  class CardBLL {
       DAL.CardDAL DAL = new DAL.CardDAL();
       CardDAL dal = new CardDAL();
       public bool Select(string Phone) {
           return DAL.Select(Phone);
       }
       public string Update(string Account, string Password, int Userid) {
           return DAL.Update(Account,Password,Userid);
       }

       /// <summary>
       /// 注册统计数据
       /// </summary>
       /// <param name="PageSizeCount"></param>
       /// <param name="Count"></param>
       /// <param name="PageIndex"></param>
       /// <param name="PageSize"></param>
       /// <returns></returns>
       public List<Model.PageList> UserList(out int Count, int PageIndex, int PageSize,string Table,string Column,string OrderColumn,string Condition)
       {
           return dal.UserList(out Count, PageIndex, PageSize, Table, Column, OrderColumn, Condition);
       }
    }
}
