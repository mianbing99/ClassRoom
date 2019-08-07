using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Data.SqlClient;
using DAL;
namespace BLL
{
    public class CC_SubjectBLL
    {
        #region 科目
        /// <summary>
        /// 获取所有科目
        /// </summary>
        /// <returns></returns>
        public List<Model.Subject> GetAllSubjectLsit()
        {
            return new CC_SubjectDAL().GetAllSubjectLsit();
        } 
        #endregion
    }
}
