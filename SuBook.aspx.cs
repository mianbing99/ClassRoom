using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace Webz.WebIE {
    public partial class SuBook : System.Web.UI.Page {
        public int Prid;
        public int Grid;
        public string Sess = string.Empty;
        protected void Page_Load(object sender, EventArgs e) {
            if (Session["Openid"] == null) {
                Response.Write("<script type=\"text/javascript\"> alert(\"系统繁忙\");</script>");
                Response.Write(" <script type=\"text/javascript\">  window.location.href =\"https://open.weixin.qq.com/connect/oauth2/authorize?appid=wx0688f75d53cbb9e1&redirect_uri=http://ftv.icoxtech.com&response_type=code&scope=snsapi_base#wechat_redirect\"</script>");
            }
            if (Session["Phone"] != null) {
                Sess = Session["Phone"].ToString();
            }
            if (!string.IsNullOrEmpty(Request.QueryString["Prid"]) && !string.IsNullOrEmpty(Request.QueryString["Grid"])) {
                Prid = Convert.ToInt32(Request.QueryString["Prid"]);
                Grid = Convert.ToInt32(Request.QueryString["Grid"]);
                BLL.SubjectBLL bll = new BLL.SubjectBLL();
                if (Grid > 0) {
                    RpList.DataSource = bll.SelectGrList(Prid, Grid);
                    RpList.DataBind();
                } else {
                    RpList.DataSource = bll.SelectSuList(Prid);
                    RpList.DataBind();
                }
            } else {
                Response.Write(" <script type=\"text/javascript\">  window.location.href =\"Index.aspx\"</script>");
            }
        }
        
    }
}