using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Text;

namespace DAL
{
    public class VideoInfoDAL
    {

        static SqlCommand comm;
        #region 分页视频路径表
        /// <summary>
        /// 分页视频路径表
        /// </summary>
        /// <param name="pageIndex"></param>
        /// <param name="pageSize"></param>
        /// <param name="count"></param>
        /// <param name="pageCount"></param>
        /// <param name="table"></param>
        /// <param name="column"></param>
        /// <param name="condition"></param>
        /// <param name="orderColumn"></param>
        /// <returns></returns>
        public static List<Model.VideoRoute> selectAllInfo(int pageIndex, int pageSize, out int count, out int pageCount, string table, string column, string condition, string orderColumn)
        {
            List<Model.VideoRoute> list = new List<Model.VideoRoute>();
            string sql = "[dbo].[prc_GetPager]";
            comm = new SqlCommand(sql, DBHerp.DBHelper.conn);

            comm.CommandType = CommandType.StoredProcedure;
            comm.Parameters.AddWithValue("@Pageindex", pageIndex);
            comm.Parameters.AddWithValue("@PageSize", pageSize);
            comm.Parameters.AddWithValue("@Table", table);
            comm.Parameters.AddWithValue("@Column", column);
            comm.Parameters.AddWithValue("@TotalCount", SqlDbType.Int);
            comm.Parameters.AddWithValue("@TotalPage", SqlDbType.Int);
            comm.Parameters.AddWithValue("@Condition", condition);
            comm.Parameters.AddWithValue("@OrderColumn", orderColumn);
            comm.Parameters["@TotalCount"].Direction = ParameterDirection.Output;
            comm.Parameters["@TotalPage"].Direction = ParameterDirection.Output;
            SqlDataReader dr = DBHerp.DBHelper.SqlExecuteReaderParameters(comm);
            while (dr.Read())
            {
                Model.VideoRoute vr = new Model.VideoRoute();

                vr.ViIndex = Convert.ToInt32(dr["viIndex"]);
                vr.VRID = Convert.ToInt32(dr["VRID"]);
                vr.ViID = Convert.ToInt32(dr["ViID"]);
                vr.State = Convert.ToInt32(dr["State"]);
                vr.Vip = Convert.ToInt32(dr["Vip"]);
                vr.Mp4 = dr["Mp4"].ToString();
                vr.HTV = dr["HTV"].ToString();
                vr.ViName = dr["ViName"].ToString();
                list.Add(vr);
            }
            DBHerp.DBHelper.CloseConn();
            count = Convert.ToInt32(comm.Parameters["@TotalCount"].Value);
            pageCount = Convert.ToInt32(comm.Parameters["@TotalPage"].Value);
            return list;
        }
        #endregion

        public static int updateInfo(Model.VideoRoute vr) 
        {
            string sql = "update VideoRoute set State=@State,Vip=@Vip,Mp4=@Mp4,HTV=@HTV where VRID = @VRID";
            comm = new SqlCommand(sql,DBHerp.DBHelper.conn);
            comm.Parameters.AddWithValue("@State",vr.State);
            comm.Parameters.AddWithValue("@Vip", vr.Vip);
            comm.Parameters.AddWithValue("@Mp4", vr.Mp4);
            comm.Parameters.AddWithValue("@HTV", vr.HTV);
            comm.Parameters.AddWithValue("@VRID", vr.VRID);
            DBHerp.DBHelper.OpdeConn();
            int num = comm.ExecuteNonQuery();
            DBHerp.DBHelper.CloseConn();
            return num;
            
        }

        public static int deleteInfo(int vrid)
        {
            string sql = "delete from VideoRoute where VRID = @VRID";
            comm = new SqlCommand(sql,DBHerp.DBHelper.conn);
            comm.Parameters.AddWithValue("@VRID",vrid);
            return comm.ExecuteNonQuery();
        }
    }
}
