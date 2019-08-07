using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using DAL;
namespace BLL
{
    public class CC_PageListBLL
    {
        #region 匹配分页
        /// <summary>
        /// 批量匹配
        /// </summary>
        /// <param name="PageSizeCount"></param>
        /// <param name="Count"></param>
        /// <param name="PageIndex"></param>
        /// <param name="PageSize"></param>
        /// <param name="TbnName"></param>
        /// <param name="GaID"></param>
        /// <param name="SubID"></param>
        /// <param name="PrID"></param>
        /// <param name="PP"></param>
        /// <param name="Judge"></param>
        /// <returns></returns>
        public List<Model.PageList> SelectPageList(out int PageSizeCount, out int Count, int PageIndex, int PageSize, string TbnName = "0", string GaID = "0", string SubID = "0", string PrID = "0", int PP = 0, int Judge = 0)
        {
            return new CC_PageListDAL().SelectPageList(out PageSizeCount, out Count, PageIndex, PageSize, TbnName, GaID, SubID, PrID, PP, Judge);
        } 
        #endregion
        #region 所有匹配数据
        public List<Model.PageList> GetAllPageList()
        {
            return new CC_PageListDAL().GetAllPageList();
        } 
        #endregion
        #region 根据ID查询多条数据
        public List<Model.PageList> GetIDPageList(string str)
        {
            return new CC_PageListDAL().GetIDPageList(str);
        } 
        #endregion
        #region 根据ID查询单条数据
        public Model.PageList GetIdOnePageList(int ID)
        {
            return new CC_PageListDAL().GetIdOnePageList(ID);
        } 
        #endregion
        #region 刷新数据
        public int RefreshPageList()
        {
            return new CC_PageListDAL().RefreshPageList();
        } 
        #endregion

    }
}
