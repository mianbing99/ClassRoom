using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace Webz {
    public partial class Xiugai : System.Web.UI.Page {
        public string state = string.Empty;
        public string sess = string.Empty;
        protected void Page_Load(object sender, EventArgs e) {
            if (Session["Phone"] != null) {
                sess = Session["Phone"].ToString();
            }
            if (Session["Openid"] == null)
            {
                Response.Write("<script type=\"text/javascript\"> alert(\"系统繁忙\");</script>");
                Response.Write(" <script type=\"text/javascript\">  window.location.href =\"https://open.weixin.qq.com/connect/oauth2/authorize?appid=wx0688f75d53cbb9e1&redirect_uri=http://ftv.icoxtech.com&response_type=code&scope=snsapi_base#wechat_redirect\"</script>");
            }
            if (!string.IsNullOrEmpty(Request.QueryString["class"])) {
                state = "class";
            } 
        }
    }
}