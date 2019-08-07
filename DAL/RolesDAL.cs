using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Model;
using System.Data;
using System.Data.SqlClient;

namespace DAL
{
    public class RolesDAL
    {
        Roles rsmodel = new Roles();

        /// <summary>
        /// 根据userid查询管理员信息
        /// </summary>
        /// <param name="userid"></param>
        /// <returns></returns>
        public Roles GetByUserID(int userid)
        {
            SqlConnection conn = null;
            try
            {
                conn = DBHerp.SQL.Getconn();
                DBHerp.SQL.OpenConn();
                string sql = "select * from Roles where RolesID=" + userid;
                SqlCommand cmd = new SqlCommand(sql, conn);
                SqlDataReader dr = cmd.ExecuteReader();
                while (dr.Read())
                {
                    rsmodel.RolesID = int.Parse(dr["RolesID"].ToString());
                    rsmodel.AdminName = dr["AdminName"].ToString();
                    rsmodel.RoleName = dr["RoleName"].ToString();
                }
            }
            catch (Exception e)
            {
                throw new Exception(e.Message);
            }
            return rsmodel;
        }

        /// <summary>
        /// 查询所有角色信息
        /// </summary>
        /// <returns></returns>
        public List<Model.Roles> GetAllRolesList()
        {
            List<Model.Roles> list = new List<Model.Roles>();
            string sql = "select RolesID,RoleName from [dbo].[Roles]";
            SqlDataReader sdr = DBHerp.DBHelper.SqlExecuteReader(sql);
            while (sdr.Read())
            {
                Model.Roles ga = new Model.Roles()
                {
                    RolesID = Convert.ToInt32(sdr[0]),
                    RoleName = sdr[1].ToString()
                };
                list.Add(ga);
            }
            DBHerp.DBHelper.CloseConn();
            return list;

        } 
    }
}
