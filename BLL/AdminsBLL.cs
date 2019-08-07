using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace BLL
{
    public class AdminsBLL
    {
        DAL.AdminsDAL dal = new DAL.AdminsDAL();

        /// <summary>
        /// 分页查询
        /// </summary>
        /// <param name="currPage"></param>
        /// <param name="Table"></param>
        /// <param name="Column"></param>
        /// <param name="Condition"></param>
        /// <param name="OrderColumn"></param>
        /// <param name="Count"></param>
        /// <param name="pageSize"></param>
        /// <returns></returns>
        public List<Model.Admins> AdminsList(int currPage, string Table, string Column, string Condition, string OrderColumn, out int Count, int pageSize)
        {
            return dal.AdminsList(currPage, Table, Column, Condition, OrderColumn,out Count, pageSize);
        }

        /// <summary>
        /// 根据id删除管理员表数据
        /// </summary>
        /// <param name="AdminID">管理员id</param>
        /// <returns></returns>
        public bool AdminDeleteByID(int AdminID)
        {
            return dal.AdminDeleteByID(AdminID);
        }

    }
}
