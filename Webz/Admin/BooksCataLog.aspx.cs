using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace Webz.Admin
{
    public partial class BooksCataLog : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            string type = Request.QueryString["type"];
            string caid = Request.QueryString["CaID"];
            if (type!=null&&type.Equals("add"))
            {
                this.Page.ClientScript.RegisterStartupScript(this.Page.GetType(), "", "<script>document.getElementById('navname').innerHTML='新增';</script>", false);
            }
            else if (type!=null&&type.Equals("update"))
            {
                this.Page.ClientScript.RegisterStartupScript(this.Page.GetType(), "", "<script>document.getElementById('navname').innerHTML='修改';document.getElementById('CaID').innerHTML='" + caid + "';</script>", false);
            }
        }
    }
}