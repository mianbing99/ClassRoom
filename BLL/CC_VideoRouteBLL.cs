using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace BLL
{
    public class CC_VideoRouteBLL
    {
        #region 新增绑定路径
        public int AddVr(Model.Test ts, int Viid)
        {
            return new DAL.CC_VideoRouteDAL().AddVr(ts, Viid);
        } 
        #endregion
        #region 删除绑定
        public int DeleteVr(int id)
        {
            return new DAL.CC_VideoRouteDAL().DeleteVr(id);
        } 
        #endregion
        #region 判断重复绑定
        public int RepeatCountVR(Model.Test test, Model.PageList PL)
        {
            return new DAL.CC_VideoRouteDAL().RepeatCountVR(test,PL);
        } 
        #endregion
    }
}
