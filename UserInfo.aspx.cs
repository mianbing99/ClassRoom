using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace Webz.WebIE {
    public partial class UserInfo : System.Web.UI.Page {
        public int ActivationState = 0;
        protected void Page_Load(object sender, EventArgs e) {
            //if (Session["Openid"] == null) {
            //    Response.Write("<script type=\"text/javascript\"> alert(\"系统繁忙\");</script>");
            //    Response.Write(" <script type=\"text/javascript\">  window.location.href =\"https://open.weixin.qq.com/connect/oauth2/authorize?appid=wx0688f75d53cbb9e1&redirect_uri=http://ftv.icoxtech.com&response_type=code&scope=snsapi_base#wechat_redirect\"</script>");
            //}
            //if (Session["Userid"] == null) {
            //    Response.Write(" <script type=\"text/javascript\">  window.location.href =\"Login.aspx\"</script>");
            //    return;
            //}
          //int Userid = Convert.ToInt32(Session["Userid"]);
          //  BLL.CardBLL CarBll = new BLL.CardBLL();
          //  if (CarBll.Select(Userid)) {
          //      ActivationState = 1;
          //  }

        }

        protected void But_ADD_Click(object sender, EventArgs e) {
            Response.Write(" <script type=\"text/javascript\">  window.location.href =\"Activation.aspx\"</script>");
        }

        protected void But_Class_Click(object sender, EventArgs e) {
            Response.Write(" <script type=\"text/javascript\">  window.location.href =\"UserClass.aspx\"</script>");
        }

        protected void But_zhinan_Click(object sender, EventArgs e) {

        }

        protected void But_App_Click(object sender, EventArgs e) {

        }

        protected void But_Info_Click(object sender, EventArgs e) {

        }

        protected void But_Out_Click(object sender, EventArgs e) {
            Response.Write(" <script type=\"text/javascript\">  window.location.href =\"Loginout.aspx\"</script>");
        }
    }
}