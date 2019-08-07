using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Data.SqlClient;
namespace DAL
{
    public class CC_SubjectDAL
    {
        #region 科目
        public List<Model.Subject> GetAllSubjectLsit()
        {
            List<Model.Subject> list = new List<Model.Subject>();
            string sql = "select * from [dbo].[Subject]";
            SqlDataReader sdr = DBHerp.DBHelper.SqlExecuteReader(sql);
            while (sdr.Read())
            {
                Model.Subject sub = new Model.Subject()
                {
                    Suid = Convert.ToInt32(sdr[0]),
                    SuName = sdr[1].ToString()
                };
                list.Add(sub);
            }
            DBHerp.DBHelper.CloseConn();
            return list;

        } 
        #endregion
    }
}
