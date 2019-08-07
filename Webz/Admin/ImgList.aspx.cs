using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace Webz.Admin {
    public partial class ImgList : System.Web.UI.Page {
        protected void Page_Load(object sender, EventArgs e) {
            //session过期提示重新登录
            if (base.Session["username"] == null || base.Session["username"].ToString().Equals(""))
            {
                Page.ClientScript.RegisterStartupScript(this.GetType(), "提示信息", "alert('账号已过期，请重新登录！');window.top.location.href='Login.aspx'", true);
            }
            base.OnInit(e);
            BLL.IndexImgBLL ImgBLL = new BLL.IndexImgBLL ();
            RpList.DataSource = ImgBLL.SelectList();
            RpList.DataBind();
        }

        protected void Add_Click(object sender, EventArgs e) {
            Response.Write(" <script type=\"text/javascript\">  window.location.href =\"ImgAdd.aspx\"</script>");
        }
    }
}