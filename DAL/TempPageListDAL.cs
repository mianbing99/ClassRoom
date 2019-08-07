using DBHerp;
using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Text;

namespace DAL
{
    public class TempPageListDAL
    {
        /// <summary>
        /// 批量删除
        /// </summary>
        /// <returns></returns>
        //public int batchDeleteInfo(string str)
        //{
        //    char[] c = new char[] { ',' };
        //    string[] array = new string[] { };
        //    array = str.Split(c);
        //    string sql = "delete from Temp_PageList where ";
        //    int[] tempId = Array.ConvertAll<string, int>(array, delegate(string s) { return int.Parse(s); });

        //    for (int i = 0; i < tempId.Length; i++)
        //    {
        //        if (tempId.Length == (i + 1))
        //        {
        //            sql += "TempID = @TempID" + i;
        //        }
        //        else
        //        {
        //            sql += "TempID = @TempID" + i + " or ";
        //        }
        //    }

        //    SqlCommand comm = new SqlCommand(sql);
        //    for (int i = 0; i < tempId.Length; i++)
        //    {
        //        comm.Parameters.AddWithValue("@TempID" + i + "=", tempId[i]);
        //    }
        //    DBHelper.OpdeConn();
        //    int num = comm.ExecuteNonQuery();

        //    Console.WriteLine(sql);
        //    DBHelper.CloseConn();
        //    return num;
        //}


        public int batchDeleteInfo(string[] str)
        {
            string[] array = new string[] { };
            string sql = "delete from Temp_PageList where ";
            for (int i = 0; i < str.Length; i++)
            {
                if (str.Length == (i + 1))
                {
                    sql += "TempID = @TempID" + i;
                }
                else
                {
                    sql += "TempID = @TempID" + i + " or ";
                }
            }
            Console.WriteLine(sql);
            SqlCommand comm = new SqlCommand(sql,DBHelper.conn);
            for (int i = 0; i < str.Length; i++)
            {
                comm.Parameters.AddWithValue("@TempID" + i, str[i]);
            }
            DBHelper.OpdeConn();
            int num = comm.ExecuteNonQuery();

            Console.WriteLine(sql);
            DBHelper.CloseConn();
            return num;
        }
    }
}
