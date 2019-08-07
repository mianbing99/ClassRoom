using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Data.SqlClient;
using DAL;
namespace BLL
{
    public class CC_GradeBLL
    {
        #region 所有年级
        /// <summary>
        /// 所有年级
        /// </summary>
        /// <returns></returns>
        public List<Model.Grade> GetAllGradeList()
        {
            return new CC_GradeDAL().GetAllGradeList();
        }
        #endregion
    }
}
