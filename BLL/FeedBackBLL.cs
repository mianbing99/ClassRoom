using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Data;
using System.Data.SqlClient;
using DAL;
using Model;

namespace BLL
{
    public class FeedBackBLL
    {
        DAL.FeedBackDAL dal = new FeedBackDAL();
        /// <summary>
        /// 新增意见信息
        /// </summary>
        /// <param name="Fb"></param>
        /// <returns></returns>
        public bool InsertFback(Model.FeedBack Fb)
        {
            return dal.InsertFback(Fb);
        }

        /// <summary>
        /// 反馈信息处理
        /// </summary>
        /// <param name="id"></param>
        /// <param name="processing"></param>
        /// <param name="username"></param>
        /// <returns></returns>
        public bool UpdataFBack(int FeedBackID, string processing, string username, string stata)
        {
            return dal.UpdataFBack(FeedBackID, processing, username, stata);
        }

        /// <summary>
        /// 根据ID查询反馈信息
        /// </summary>
        /// <param name="Id"></param>
        /// <returns></returns>
        public Model.FeedBack FeedBackByID(int Id) {
            return dal.FeedBackByID(Id);
        }
        public List<Model.FeedBack> SelectPageResult(int currPage, string Table, string Condition, string OrderColumn, out int Count, int pageSize)
        {
            return dal.SelectPageResult(currPage, Table, Condition, OrderColumn, out Count, pageSize);
        }
    }
}
