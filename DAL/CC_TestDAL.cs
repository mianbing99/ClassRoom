using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Data.SqlClient;
using System.Data;
namespace DAL
{
    public class CC_TestDAL
    {
        #region 根据ID获取单个路径
        public Model.Test GetIdOneTest(int ID)
        {
            string sql = string.Format("select * from [dbo].[Test] WHERE TestID={0}", ID);
            SqlDataReader sdr = DBHerp.DBHelper.SqlExecuteReader(sql);
            Model.Test test = null;
            while (sdr.Read())
            {
                test = new Model.Test()
                {
                    TestID = Convert.ToInt32(sdr[0]),
                    MP4 = sdr[1].ToString(),
                    HTV = sdr[2].ToString(),
                    Name = sdr[3].ToString(),
                    Kemu = sdr[4].ToString()
                };
            }
            DBHerp.DBHelper.CloseConn();
            return test;
        }
        #endregion
        #region 分页
        public List<Model.Test> TestPage(out int PageCount, int PageSize, int PageIndex, string Name, string Kemu)
        {
            List<Model.Test> list = new List<Model.Test>();
            //            @PageCount int OUTPUT,--总条数
            //@PageSize int, --每页显示数
            //@PageIndex int,--当前页
            //@Name varchar(50)='%'
            string sql = "[dbo].[USP_TestPage]";
            SqlCommand comm = new SqlCommand(sql, DBHerp.DBHelper.conn);
            comm.CommandType = CommandType.StoredProcedure;
            comm.Parameters.AddWithValue("@PageCount", SqlDbType.Int);
            comm.Parameters.AddWithValue("@PageSize", PageSize);
            comm.Parameters.AddWithValue("@PageIndex", PageIndex);
            comm.Parameters.AddWithValue("@Name", Name);
            comm.Parameters.AddWithValue("@Kemu", Kemu);
            comm.Parameters["@PageCount"].Direction = ParameterDirection.Output;
            SqlDataReader sdr = DBHerp.DBHelper.SqlExecuteReaderParameters(comm);
            while (sdr.Read())
            {
                Model.Test ts = new Model.Test()
                {
                    TestID = Convert.ToInt32(sdr[1]),
                    MP4 = sdr[2].ToString(),
                    HTV = sdr[3].ToString(),
                    Name = sdr[4].ToString(),
                    Kemu = sdr[5].ToString()
                };
                list.Add(ts);
            }
            DBHerp.DBHelper.CloseConn();
            PageCount = Convert.ToInt32(comm.Parameters["@PageCount"].Value);
            return list;
        }
        #endregion
        #region 多ID查询Test
        public List<Model.Test> TestList(string arr)
        {
            List<Model.Test> list = new List<Model.Test>();
            char[] c = new char[] { ',' };
            string[] str = new string[] { };
            //判断是否只有一个数字
            str = arr.Split(c);
            //string数组转int数组
            int[] output = Array.ConvertAll<string, int>(str, delegate(string s) { return int.Parse(s); });
            string sql = "SELECT * FROM [dbo].[Test] WHERE";
            for (int i = 0; i < output.Length; i++)
            {
                if (i + 1 == output.Length)
                {
                    sql += string.Format(" TestID={0}", output[i]);
                }
                else
                {
                    sql += string.Format(" TestID={0} or", output[i]);
                }
            }
            SqlDataReader sdr = DBHerp.DBHelper.SqlExecuteReader(sql);
            while (sdr.Read())
            {
                Model.Test ts = new Model.Test()
                {
                    TestID = Convert.ToInt32(sdr[0]),
                    MP4 = sdr[1].ToString(),
                    HTV = sdr[2].ToString(),
                    Name = sdr[3].ToString(),
                    Kemu = sdr[4].ToString()
                };

                list.Add(ts);

            }
            DBHerp.DBHelper.CloseConn();
            return list;

        } 
        #endregion
    }
}
