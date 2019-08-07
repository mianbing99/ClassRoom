using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Data.SqlClient;
namespace DAL
{
    public class CC_GradeDAL
    {
        #region 获取所有年级
        public List<Model.Grade> GetAllGradeList()
        {
            List<Model.Grade> list = new List<Model.Grade>();
            string sql = "select * from [dbo].[Grade]";
            SqlDataReader sdr = DBHerp.DBHelper.SqlExecuteReader(sql);
            while (sdr.Read())
            {
                Model.Grade ga = new Model.Grade() {
                    GradeID = Convert.ToInt32(sdr[0]),
                  GrName=sdr[1].ToString()
                };
                list.Add(ga);
            }
            DBHerp.DBHelper.CloseConn();
            return list;

        } 
        #endregion
    }
}
