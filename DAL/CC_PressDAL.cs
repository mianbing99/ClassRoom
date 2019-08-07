using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Data.SqlClient;
namespace DAL
{
    public class CC_PressDAL
    {
        #region 所有出版社
        public List<Model.Press> GetALLPressList()
        {
            List<Model.Press> list = new List<Model.Press>();
            string sql = "select * from [dbo].[Press]";
            SqlDataReader sdr = DBHerp.DBHelper.SqlExecuteReader(sql);
            while (sdr.Read())
            {
                Model.Press press = new Model.Press()
                {
                    Prid = Convert.ToInt32(sdr[0]),
                    PrName = sdr[1].ToString()
                };
                list.Add(press);
            }
            DBHerp.DBHelper.CloseConn();
            return list;
        } 
        #endregion
    }
}
