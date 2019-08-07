using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace Webz.WebIE {
    public partial class Loginout : System.Web.UI.Page {
        protected void Page_Load(object sender, EventArgs e) {
            if (Session["Phone"] != null) {
                Session["Phone"] = null;
            } if (Session["UserID"] != null) {
                Session["UserID"] = null;
            }
            if (Session["SeID"] != null) {
                Session["SeID"] = null;
            }
            if (Session["Openid"] != null) {
                Session["Openid"] = null;
            }

            Response.Write(" <script type=\"text/javascript\">  window.location.href =\"https://open.weixin.qq.com/connect/oauth2/authorize?appid=wx0688f75d53cbb9e1&redirect_uri=http://ftv.icoxtech.com&response_type=code&scope=snsapi_base#wechat_redirect\"</script>");
        }
    }
}