using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace BLL
{
    public class CC_TestBLL
    {
        #region 根据ID获取单个路径
        public Model.Test GetIdOneTest(int ID)
        {
         
            return new    DAL.CC_TestDAL().GetIdOneTest(ID);
        } 
        #endregion
        #region 分页
        public List<Model.Test> TestPage(out int PageCount, int PageSize, int PageIndex, string Name, string Kemu)
        {
            return new DAL.CC_TestDAL().TestPage(out PageCount, PageSize, PageIndex, Name,Kemu);
        } 
        #endregion
        #region 多ID查询Test
        public List<Model.Test> TestList(string arr)
        {
            return new DAL.CC_TestDAL().TestList(arr);
        } 
        #endregion

    }
}
