using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Data.SqlClient;
using System.Text.RegularExpressions;
namespace DAL
{
    public class CC_VideoRouteDAL
    {
        #region 新增绑定路径
        public int AddVr(Model.Test ts, int Viid)
        {
            string sql = string.Format("INSERT INTO [dbo].[VideoRoute](Htv, Mp4, ViID, ViName, State, Vip) VALUES('{0}','{1}','{2}','{3}',1,1)", ts.HTV, ts.MP4, Viid, ts.Name);
            int i = DBHerp.DBHelper.SqlExecuteNonQuery(sql);
            return i;
        }
        #endregion
        #region 删除绑定
        public int DeleteVr(int id)
        {
            string sql = string.Format("DELETE from [dbo].[VideoRoute] WHERE VRID={0}", id);
            return Convert.ToInt32(DBHerp.DBHelper.SqlExecuteNonQuery(sql));
        }
        #endregion
        #region 判断重复绑定
        public int RepeatCountVR(Model.Test test, Model.PageList PL)
        {
            string sql = string.Format("SELECT COUNT(0) FROM  [dbo].[VideoRoute] WHERE ViID={0} AND ViName='{1}' AND VRID={2}", PL.ViID, test.Name, PL.VRID);


            return Convert.ToInt32(DBHerp.DBHelper.SqlExecuteScalar(sql));

        }
        #endregion
    }
}
