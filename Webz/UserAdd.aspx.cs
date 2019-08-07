using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace Webz.WebIE {
    public partial class UserAdd : System.Web.UI.Page {
        public string sess = string.Empty;
        protected void Page_Load(object sender, EventArgs e) {
            if (Session["Phone"] != null) {
                sess = Session["Phone"].ToString();
            }
            if (Session["Openid"] == null) {
                Response.Write("<script type=\"text/javascript\"> alert(\"系统繁忙\");</script>");
                Response.Write(" <script type=\"text/javascript\">  window.location.href =\"https://open.weixin.qq.com/connect/oauth2/authorize?appid=wx0688f75d53cbb9e1&redirect_uri=http://ftv.icoxtech.com&response_type=code&scope=snsapi_base#wechat_redirect\"</script>");
            }
        }

        //protected void But_Add_Click(object sender, EventArgs e) {
        //    Model.User User = new Model.User();
        //    BLL.UserBLL UsBll = new BLL.UserBLL();
        //    User.Pwd = MD5Hashing.HashString(Pwd.Value);
        //    User.Phone = Phone.Value;
        //    User.CreateTime = DateTime.Now;
        //    if (Session["Openid"] != null) {
        //        User.OpenID = Session["Openid"].ToString();
        //    } else if (Session["Openid"] == null) {
        //        Response.Write("<script type=\"text/javascript\"> alert(\"系统繁忙\");</script>");
        //        Response.Write(" <script type=\"text/javascript\">  window.location.href =\"https://open.weixin.qq.com/connect/oauth2/authorize?appid=wx0688f75d53cbb9e1&redirect_uri=http://ftv.icoxtech.com&response_type=code&scope=snsapi_base#wechat_redirect\"</script>");
        //    }
        //    if (UsBll.UserYanz(User.Phone)) {
        //        if (UsBll.UserAdd(User)) {
        //            Session["Phone"] = User.Phone;
        //            Response.Write("<script type=\"text/javascript\"> alert(\"注册成功\");</script>");
        //            Response.Write(" <script type=\"text/javascript\">  window.location.href =\"UserInfo.aspx\"</script>");
        //        }
        //    } else {
        //        Response.Write("<script type=\"text/javascript\"> alert(\"该手机号已存在，请选择继续注册或登录\");</script>");
        //    }
           
        //}
    }
}