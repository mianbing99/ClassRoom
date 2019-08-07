using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Data.SqlClient;
using System.Data;
using Model;

namespace DAL
{
    public class FeedBackDAL
    {
        DBHerp.SQL Dbherp = new DBHerp.SQL();
        /// <summary>
        /// 新增意见信息
        /// </summary>
        /// <param name="Fb"></param>
        /// <returns></returns>
        public bool InsertFback(Model.FeedBack Fb)
        {
            string sql = string.Format("insert into FeedBack values('{0}','{1}','{2}','{3}','{4}','{5}','{6}')",Fb.Grade,Fb.Phone,Fb.FeedBackNR,Fb.FeedBackDate,Fb.Processing,Fb.ProcessingName,Fb.Stata);
            return Dbherp.ExQuery(sql);
        }

        /// <summary>
        /// 处理反馈信息
        /// </summary>
        /// <param name="id"></param>
        /// <param name="processing"></param>
        /// <param name="username"></param>
        /// <returns></returns>
        public bool UpdataFBack(int FeedBackID, string processing, string username, string stata)
        {
            string sql = string.Format("update FeedBack set Processing='{0}',ProcessingName='{1}',Stata='{2}' where FeedBackID={3}", processing, username, stata, FeedBackID);
            return Dbherp.ExQuery(sql);
        }

        /// <summary>
        /// 根据ID查询信息
        /// </summary>
        /// <param name="Id"></param>
        /// <returns></returns>
        public Model.FeedBack FeedBackByID(int Id)
        {
            string sql = string.Format("select * from FeedBack where FeedBackID={0}", Id);
            Model.FeedBack fb = new FeedBack();
            SqlDataReader sdr = DBHerp.DBHelper.SqlExecuteReader(sql);
            while (sdr.Read())
            {
                fb.FeedBackNR = sdr[3].ToString();
                fb.Processing = sdr[5].ToString();
            }
            DBHerp.DBHelper.CloseConn();
            return fb;
        }
        //public Model.PageList GetIdOnePageList(int ID)
        //{
        //    string sql = string.Format("SELECT * FROM Temp_PageList WHERE XId={0}", ID);
        //    Model.PageList pl = null;
        //    SqlDataReader sdr = DBHerp.DBHelper.SqlExecuteReader(sql);
        //    while (sdr.Read())
        //    {
        //        pl = new Model.PageList()
        //        {
        //            XId = Convert.ToInt32(sdr[0]),
        //            TextID = Convert.ToInt32(sdr[1]),
        //            Semester = sdr[2].ToString(),
        //            GrID = Convert.ToInt32(sdr[3]),
        //            GrName = sdr[4].ToString(),
        //            BooksName = sdr[5].ToString(),
        //            ViID = Convert.ToInt32(sdr[6]),
        //            ViName = sdr[7].ToString(),
        //            匹配 = sdr[8].ToString(),
        //            未匹配 = sdr[9].ToString(),
        //            Suid = Convert.ToInt32(sdr[10]),
        //            SuName = sdr[11].ToString(),
        //            PrID = Convert.ToInt32(sdr[12]),
        //            PrName = sdr[13].ToString(),
        //            CaID = Convert.ToInt32(sdr[14]),
        //            RoID = Convert.ToInt32(sdr[15])
        //        };
        //    }
        //    DBHerp.DBHelper.CloseConn();
        //    return pl;

        //}

        /// <summary>
        /// 分页查询信息
        /// </summary>
        /// <param name="currPage"></param>
        /// <param name="showColumn"></param>
        /// <param name="tabName"></param>
        /// <param name="strCondition"></param>
        /// <param name="ascColumn"></param>
        /// <param name="bitOrderType"></param>
        /// <param name="pkColumn"></param>
        /// <param name="pageSize"></param>
        /// <returns></returns>
        public List<Model.FeedBack> SelectPageResult(int currPage, string Table, string Condition, string OrderColumn, out int Count, int pageSize)
        {
            List<Model.FeedBack> list = new List<Model.FeedBack>();
            SqlCommand PageListComm = null;
            DateTime dt = DateTime.Now;
            //读取临时表中的数据

            string sqlPageList = "[dbo].[prc_GetPager]";
            PageListComm = new SqlCommand(sqlPageList, DBHerp.DBHelper.conn);
            PageListComm.CommandType = CommandType.StoredProcedure;
            PageListComm.Parameters.AddWithValue("@PageIndex", currPage);
            PageListComm.Parameters.AddWithValue("@Table", Table);
            PageListComm.Parameters.AddWithValue("@Condition", Condition);
            PageListComm.Parameters.AddWithValue("@OrderColumn", OrderColumn);
            PageListComm.Parameters.AddWithValue("@TotalCount", SqlDbType.Int);
            PageListComm.Parameters.AddWithValue("@TotalPage", SqlDbType.Int);
            PageListComm.Parameters.AddWithValue("@pageSize", pageSize);
            PageListComm.Parameters["@TotalCount"].Direction = ParameterDirection.Output;
            PageListComm.Parameters["@TotalPage"].Direction = ParameterDirection.Output;
            SqlDataReader sdr = DBHerp.DBHelper.SqlExecuteReaderParameters(PageListComm);
            while (sdr.Read())
            {
                Model.FeedBack fb = new Model.FeedBack()
                {

                    FeedBackID = Convert.ToInt32(sdr[0]),
                    Grade = sdr[1].ToString(),
                    Phone = sdr[2].ToString(),
                    FeedBackNR = sdr[3].ToString(),
                    FeedBackDate = sdr[4].ToString(),
                    Processing = sdr[5].ToString(),
                    ProcessingName = sdr[6].ToString(),
                    Stata = sdr[7].ToString()
                };
                list.Add(fb);
            }
            DBHerp.DBHelper.CloseConn();
            Count = Convert.ToInt32(PageListComm.Parameters["@TotalCount"].Value);
            return list;

        }
    }
}
