using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Model;
using System.Data.SqlClient;
using System.Data;

namespace DAL
{
    public class AdminsDAL
    {
        Admins admins = new Admins();

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
            List<Model.Admins> list = new List<Admins>();
            SqlCommand PageListComm = null;

            string sqlPageList = "[dbo].[prc_GetPager]";
            PageListComm = new SqlCommand(sqlPageList, DBHerp.DBHelper.conn);
            PageListComm.CommandType = CommandType.StoredProcedure;
            PageListComm.Parameters.AddWithValue("@PageIndex", currPage);
            PageListComm.Parameters.AddWithValue("@Table", Table);
            PageListComm.Parameters.AddWithValue("@Column", Column);
            PageListComm.Parameters.AddWithValue("@Condition", Condition);
            PageListComm.Parameters.AddWithValue("@OrderColumn", OrderColumn);
            PageListComm.Parameters.AddWithValue("@TotalCount", SqlDbType.Int);
            PageListComm.Parameters.AddWithValue("@TotalPage", SqlDbType.Int);
            PageListComm.Parameters.AddWithValue("@pageSize", pageSize);
            PageListComm.Parameters["@TotalCount"].Direction = ParameterDirection.Output;
            PageListComm.Parameters["@TotalPage"].Direction = ParameterDirection.Output;
            SqlDataReader sdr = DBHerp.DBHelper.SqlExecuteReaderParameters(PageListComm);
            while (sdr.Read())
            {
                Model.Admins bc = new Model.Admins()
                {
                    AdminID = Convert.ToInt32(sdr[0]),
                    AdminName = sdr[1].ToString(),
                    RoleName = sdr[2].ToString()
                };
                list.Add(bc);
            }
            DBHerp.DBHelper.CloseConn();
            Count = Convert.ToInt32(PageListComm.Parameters["@TotalCount"].Value);
            return list;
        }
        /// <summary>
        /// 根据id删除管理员表数据
        /// </summary>
        /// <param name="AdminID">管理员id</param>
        /// <returns></returns>
        public bool AdminDeleteByID(int AdminID)
        {
            string sql = "delete from Admins where AdminID=" + AdminID;
            int num = DBHerp.SQL.ds(sql);
            if (num>0)
            {
                return true;
            }
            else
            {
                return false;
            }
            
        }
    }
}
