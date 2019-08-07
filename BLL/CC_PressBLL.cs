using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using DAL;
namespace BLL
{
    public class CC_PressBLL
    {
        #region 所有出版社
        /// <summary>
        /// 获取所有出版社
        /// </summary>
        /// <returns></returns>
        public List<Model.Press> GetALLPressList()
        {
            return new CC_PressDAL().GetALLPressList();
        } 
        #endregion
    }
}
