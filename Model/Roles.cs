using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Model
{
    public class Roles
    {
        private int rolesID;

        /// <summary>
        /// 管理员id
        /// </summary>
        public int RolesID
        {
            get { return rolesID; }
            set { rolesID = value; }
        }

        private string adminName;
        /// <summary>
        /// 管理员姓名
        /// </summary>
        public string AdminName
        {
            get { return adminName; }
            set { adminName = value; }
        }

        private string roleName;
        /// <summary>
        /// 管理员权限
        /// </summary>
        public string RoleName
        {
            get { return roleName; }
            set { roleName = value; }
        }
    }
}
