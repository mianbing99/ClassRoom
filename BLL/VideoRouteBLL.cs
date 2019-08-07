using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Data.SqlClient;
using System.Data;

namespace BLL {
    public class VideoRouteBLL {
        /// <summary>
        /// 根据视频ID查询视频路径
        /// </summary>
        /// <param name="Viid"></param>
        /// <returns></returns>
        private DAL.VideoRouteDAL Dal = new DAL.VideoRouteDAL();
        public List<Model.VideoRoute> SelectByViid(int Viid) {
            return Dal.SelectByViid(Viid);
        }
        /// <summary>
        /// 查询没有视频的课文
        /// </summary>
        /// <returns></returns>
        public SqlDataReader Selectqushi() {
            return Dal.Selectqueshi();
        }
        public bool Select(string mp4) {
            return Dal.Select(mp4);
        }
        public List<Model.VideoRoute> SelectViid(string mp4) {
            return Dal.SelectViid(mp4);
        }
        public bool Delete(int Viid, string ViName, string Mp4) {
            return Dal.Delete(Viid, ViName, Mp4);
        }
        public bool Update(int roid, string Htv, string mp4) {
            return Dal.Update(roid, Htv, mp4);
        }
        public DataTable Daochu() {
            return Dal.Daochu();
        }
        public bool insert(string Htv, string mp4, int viid, string viname) {
            return Dal.insert(Htv, mp4, viid, viname);
        }

        public Model.VideoRoute queryOneInfo(int vrId)
        {
            return Dal.queryOneInfo(vrId);
        }

        //public static Model.VideoRoute allInfo() 
        //{
        
        //}
    }
}
