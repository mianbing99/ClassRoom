using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Data;
using System.Data.SqlClient;
using Model;
using DAL;

namespace BLL
{
    public class RolesBLL
    {
        DAL.RolesDAL dal = new RolesDAL();
        Model.Roles model = new Roles();

        /// <summary>
        /// 根据userid查询管理员信息
        /// </summary>
        /// <param name="userid"></param>
        /// <returns></returns>
        public Roles GetByUserID(int userid)
        {
            return dal.GetByUserID(userid);
        }
        /// <summary>
        /// 查询所有角色信息
        /// </summary>
        /// <returns></returns>
        public List<Model.Roles> GetAllRolesList()
        {
            return dal.GetAllRolesList();
        }
    }
}
