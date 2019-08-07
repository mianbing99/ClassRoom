using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Data.SqlClient;
using System.Data;
using System.Text.RegularExpressions;
namespace DAL
{
    public class CC_PageListDAL
    {

        //        @PageSizeCount int output,--总页数
        //@Count int OUTPUT,--总条数
        //@PageIndex int,--当前页
        //@PageSize int,--显示数
        //@TbnName varchar(50)='%',--书名
        //@GaID varchar(50)='%',--年级ID
        //@SubID varchar(50)='%',--科目ID
        //@PrID varchar(50)='%',--出版社ID
        //@PP int--判断是哪种匹配方式

        #region 分页
       

        //        @PageSizeCount int output,--总页数
        //@Count int OUTPUT,--总条数
        //@PageIndex int,--当前页
        //@PageSize int,--显示数
        //@TbnName varchar(50)='%',--书名
        //@GaID varchar(50)='%',--年级ID
        //@SubID varchar(50)='%',--科目ID
        //@PrID varchar(50)='%',--出版社ID
        //@PP int--判断是哪种匹配方式

        #region 分页
        public List<Model.PageList> SelectPageList(out int PageSizeCount, out int Count, int PageIndex, int PageSize = 10, string TbnName = "0", string GaID = "0", string SubID = "0", string PrID = "0", int PP = 0, int Judge = 0)
        {

            TbnName = TbnName.Replace("]", "]%");
            TbnName = TbnName.Replace("[", "");
            TbnName = TbnName.Trim();


            List<Model.PageList> list = new List<Model.PageList>();
            

            SqlCommand PageListComm = null;

                //读取临时表中的数据

                string sqlPageList = "[dbo].[usp_PageList]";
                PageListComm = new SqlCommand(sqlPageList, DBHerp.DBHelper.conn);
                PageListComm.CommandType = CommandType.StoredProcedure;
                PageListComm.Parameters.AddWithValue("@PageSizeCount", SqlDbType.Int);
                PageListComm.Parameters.AddWithValue("@Count", SqlDbType.Int);
                PageListComm.Parameters.AddWithValue("@PageIndex", PageIndex);
                PageListComm.Parameters.AddWithValue("@PageSize", PageSize);
                PageListComm.Parameters.AddWithValue("@TbnName", TbnName);
                PageListComm.Parameters.AddWithValue("@GaID", GaID);
                PageListComm.Parameters.AddWithValue("@SubID", SubID);
                PageListComm.Parameters.AddWithValue("@PrID", PrID);
                PageListComm.Parameters.AddWithValue("@PP", PP);
                PageListComm.Parameters["@PageSizeCount"].Direction = ParameterDirection.Output;
                PageListComm.Parameters["@Count"].Direction = ParameterDirection.Output;

                SqlDataReader sdr = DBHerp.DBHelper.SqlExecuteReaderParameters(PageListComm);
                while (sdr.Read())
                {
                    Model.PageList pl = new Model.PageList()
                    {

                        num = Convert.ToInt32(sdr[0]),
                        TempID = Convert.ToInt32(sdr[1]),
                        TextID = Convert.ToInt32(sdr[2]),
                        Semester = sdr[3].ToString(),
                        GradeID = Convert.ToInt32(sdr[4]),
                        GrName = sdr[5].ToString(),
                        BooksName = sdr[6].ToString(),
                        ViID = Convert.ToInt32(sdr[7]),
                        ViName = sdr[8].ToString(),
                        匹配 = sdr[9].ToString(),
                        未匹配 = sdr[10].ToString(),
                        Suid = Convert.ToInt32(sdr[11]),
                        SuName = sdr[12].ToString(),
                        PrID = Convert.ToInt32(sdr[13]),
                        PrName = sdr[14].ToString(),
                        CaID = Convert.ToInt32(sdr[15]),
                        VRID = Convert.ToInt32(sdr[16])
                    };
                    list.Add(pl);
                }


            
            DBHerp.DBHelper.CloseConn();
            PageSizeCount = Convert.ToInt32(PageListComm.Parameters["@PageSizeCount"].Value);
            Count = Convert.ToInt32(PageListComm.Parameters["@Count"].Value);

            return list;

        }
        #endregion
        #region 所有匹配数据
        public List<Model.PageList> GetAllPageList()
        {
            List<Model.PageList> list = new List<Model.PageList>();
            string sql = "SELECT * FROM  Temp_PageList";
            SqlDataReader sdr = DBHerp.DBHelper.SqlExecuteReader(sql);
            while (sdr.Read())
            {
                Model.PageList page = new Model.PageList()
                {
                    TempID = Convert.ToInt32(sdr[0]),
                    TextID = Convert.ToInt32(sdr[1]),
                    Semester = sdr[2].ToString(),
                    GradeID = Convert.ToInt32(sdr[3]),
                    GrName = sdr[4].ToString(),
                    BooksName = sdr[5].ToString(),
                    ViID = Convert.ToInt32(sdr[6]),
                    ViName = sdr[7].ToString(),
                    匹配 = sdr[8].ToString(),
                    未匹配 = sdr[9].ToString(),
                    Suid = Convert.ToInt32(sdr[10]),
                    SuName = sdr[11].ToString(),
                    PrID = Convert.ToInt32(sdr[12]),
                    PrName = sdr[13].ToString(),
                    CaID = Convert.ToInt32(sdr[14]),
                    VRID = Convert.ToInt32(sdr[15])
                };
                list.Add(page);
            }
            DBHerp.DBHelper.CloseConn();
            return list;
        }
        #endregion
        #region 根据ID查询多条数据
        public List<Model.PageList> GetIDPageList(string str)
        {
            List<Model.PageList> list = new List<Model.PageList>();
            char[] c = new char[] { ',' };
            string[] arr = new string[] { };
            //判断是否只有一个数字

            arr = str.Split(c);

            //string数组转int数组
            int[] output = Array.ConvertAll<string, int>(arr, delegate(string s) { return int.Parse(s); });

            string sql = string.Format("SELECT * FROM Temp_PageList AS tb WHERE");
            for (int i = 0; i < output.Length; i++)
            {
                if ((i + 1) == output.Length)
                {
                    sql += string.Format(" tb.TempID={0}", output[i]);
                }
                else
                {
                    sql += string.Format(" tb.TempID={0} or", output[i]);
                }
            }
            SqlDataReader sdr = DBHerp.DBHelper.SqlExecuteReader(sql);
            while (sdr.Read())
            {
                Model.PageList page = new Model.PageList()
                {
                    TempID = Convert.ToInt32(sdr[0]),
                    TextID = Convert.ToInt32(sdr[1]),
                    Semester = sdr[2].ToString(),
                    GradeID = Convert.ToInt32(sdr[3]),
                    GrName = sdr[4].ToString(),
                    BooksName = sdr[5].ToString(),
                    ViID = Convert.ToInt32(sdr[6]),
                    ViName = sdr[7].ToString(),
                    匹配 = sdr[8].ToString(),
                    未匹配 = sdr[9].ToString(),
                    Suid = Convert.ToInt32(sdr[10]),
                    SuName = sdr[11].ToString(),
                    PrID = Convert.ToInt32(sdr[12]),
                    PrName = sdr[13].ToString(),
                    CaID = Convert.ToInt32(sdr[14]),
                    VRID = Convert.ToInt32(sdr[15])
                };
                list.Add(page);
            }
            DBHerp.DBHelper.CloseConn();
            return list;
        }
        #endregion
        #region 根据ID查询单条数据
        public Model.PageList GetIdOnePageList(int ID)
        {
            string sql = string.Format("SELECT * FROM Temp_PageList WHERE TempID={0}", ID);
            Model.PageList pl = null;
            SqlDataReader sdr = DBHerp.DBHelper.SqlExecuteReader(sql);
            while (sdr.Read())
            {
                pl = new Model.PageList()
                {
                    TempID = Convert.ToInt32(sdr[0]),
                    TextID = Convert.ToInt32(sdr[1]),
                    Semester = sdr[2].ToString(),
                    GradeID = Convert.ToInt32(sdr[3]),
                    GrName = sdr[4].ToString(),
                    BooksName = sdr[5].ToString(),
                    ViID = Convert.ToInt32(sdr[6]),
                    ViName = sdr[7].ToString(),
                    匹配 = sdr[8].ToString(),
                    未匹配 = sdr[9].ToString(),
                    Suid = Convert.ToInt32(sdr[10]),
                    SuName = sdr[11].ToString(),
                    PrID = Convert.ToInt32(sdr[12]),
                    PrName = sdr[13].ToString(),
                    CaID = Convert.ToInt32(sdr[14]),
                    VRID = Convert.ToInt32(sdr[15])
                };
            }
            DBHerp.DBHelper.CloseConn();
            return pl;

        }
        #endregion
        #region 刷新数据
        public int RefreshPageList()
        {
            string sql = "[dbo].[Usp_Temp_PageList_CC]";
            SqlCommand comm = new SqlCommand(sql, DBHerp.DBHelper.conn);
            comm.CommandType = CommandType.StoredProcedure;
            comm.Parameters.AddWithValue("@Judge", 1);
            SqlDataReader sdr = DBHerp.DBHelper.SqlExecuteReaderParameters(comm);
            int i = 0;
            while (sdr.Read())
            {
                i = Convert.ToInt32(sdr[0]);
            }

            DBHerp.DBHelper.CloseConn();
            return i;
        }
        #endregion
    }
        #endregion
}
