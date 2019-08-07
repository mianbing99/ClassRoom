using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace BLL
{
    public class VideoInfoBLL
    {
        public static List<Model.VideoRoute> selectAllInfo(int pageIndex, int pageSize, out int count, out int pageCount, string table, string column, string condition, string orderColumn)
        {
            return DAL.VideoInfoDAL.selectAllInfo(pageIndex, pageSize, out count, out pageCount, table, column, condition, orderColumn);
        }

        public static int updateInfo(Model.VideoRoute vr) 
        {
            return DAL.VideoInfoDAL.updateInfo(vr);
        }

        public static int deleteInfo(int vrid) 
        {
            return DAL.VideoInfoDAL.deleteInfo(vrid);
        }
       



        
    }
}
