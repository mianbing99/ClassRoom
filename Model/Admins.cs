using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Model
{
    public class Admins
    {
        private int adminID;

        public int AdminID {//管理员ID
            get { return adminID; }
            set { adminID = value; }
        }

        private string adminName;

        public string AdminName
        {//管理员名称
            get { return adminName; }
            set { adminName = value; }
        }

        private string adminPwd;

        public string AdminPwd
        {//管理员密码
            get { return adminPwd; }
            set { adminPwd = value; }
        }

        private int rolesID;

        public int RolesID
        {//角色id
            get { return rolesID; }
            set { rolesID = value; }
        }

        private string roleName;

        public string RoleName
        {//角色id
            get { return roleName; }
            set { roleName = value; }
        }
    }
}
