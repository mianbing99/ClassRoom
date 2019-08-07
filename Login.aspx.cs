using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace Webz.WebIE {
    public partial class Login : System.Web.UI.Page {
        protected void Page_Load(object sender, EventArgs e) {
            if (Session["Phone"] != null || Session["Userid"] != null) {
                
            }
            if (Session["Openid"] == null) {
                Response.Write("<script type=\"text/javascript\"> alert(\"系统繁忙\");</script>");
                Response.Write(" <script type=\"text/javascript\">  window.location.href =\"https://open.weixin.qq.com/connect/oauth2/authorize?appid=wx0688f75d53cbb9e1&redirect_uri=http://ftv.icoxtech.com&response_type=code&scope=snsapi_base#wechat_redirect\"</script>");
            }
        }

        //protected void But_Login_Click(object sender, EventArgs e) {
        //    BLL.UserBLL Bll = new BLL.UserBLL();
        //    Model.User User = new Model.User ();
        //    User.Phone = Phone.Value;
        //    User.Pwd = MD5Hashing.HashString(Pwd.Value);
        //    if (Session["Openid"] == null) {
        //        Response.Write("<script type=\"text/javascript\"> alert(\"系统繁忙\");</script>");
        //        Response.Write(" <script type=\"text/javascript\">  window.location.href =\"https://open.weixin.qq.com/connect/oauth2/authorize?appid=wx0688f75d53cbb9e1&redirect_uri=http://ftv.icoxtech.com&response_type=code&scope=snsapi_base#wechat_redirect\"</script>");
        //    }
        //    User.OpenID = Session["Openid"].ToString();
        //    User = Bll.UserLogin(User);
        //    if (User.UserID == 0) {
        //        Response.Write("<script type=\"text/javascript\"> alert(\"账号或者密码不正确\");</script>");
        //        return;
        //    } else {
        //        if (Bll.UserYanz(User.UserID, User.OpenID)) {
        //            Session["Phone"] = User.Phone;
        //            Session["Userid"] = User.UserID;
        //            BLL.UserSetBLL SeBll = new BLL.UserSetBLL();
        //            Model.UserSet SeModel = new Model.UserSet();
        //            SeModel = SeBll.SelectByUserid(User.UserID);
        //            if (SeModel.UserID == 0) {
        //                Response.Write(" <script type=\"text/javascript\">  window.location.href =\"UserInfo.aspx\"</script>");
        //            } else {
        //                Session["Seid"] = SeModel.SeID;
        //                Response.Write(" <script type=\"text/javascript\">  window.location.href =\"BooksList.aspx\"</script>");
        //            }
        //        }
        //    }
        //}

        protected void But_Add_Click(object sender, EventArgs e) {

        }
    }
}