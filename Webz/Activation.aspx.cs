using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace Webz.WebIE {
    public partial class Activation : System.Web.UI.Page {
        private int Userid=0;
        protected void Page_Load(object sender, EventArgs e) {
            if (Session["Userid"] == null)
            {
                Response.Write(" <script type=\"text/javascript\">  window.location.href =\"Login.aspx\"</script>");
                return;
            }
            if (Session["Openid"] == null)
            {
                Response.Write("<script type=\"text/javascript\"> alert(\"系统繁忙\");</script>");
                Response.Write(" <script type=\"text/javascript\">  window.location.href =\"https://open.weixin.qq.com/connect/oauth2/authorize?appid=wx0688f75d53cbb9e1&redirect_uri=http://ftv.icoxtech.com&response_type=code&scope=snsapi_base#wechat_redirect\"</script>");
            }
            Userid = Convert.ToInt32(Session["Userid"]);
        }

        protected void But_Activation_Click(object sender, EventArgs e) {
            string Account = Txt_Account.Value;
            Account = Account.ToUpper();
            string PassWord = Txt_PassWord.Value;
            string Verify = txtVerify.Value;
            if (Verify == "") {
                Response.Write("<script type=\"text/javascript\"> alert(\"请输入验证码\");</script>");
            }
            if(Session["gif"]!=null){
                string gif = Session["gif"].ToString();
                if (gif == Verify) {
                    BLL.CardBLL carBll = new BLL.CardBLL();
                    Response.Write("<script type=\"text/javascript\"> alert(\"" + carBll.Update(Account, PassWord, Userid) + "\");</script>");
                    if (carBll.Update(Account, PassWord, Userid) != "账号或密码错误！") {
                        Response.Write(" <script type=\"text/javascript\">  window.location.href =\"Index.aspx\"</script>");
                    }
                }
            }
        } 
    }
}