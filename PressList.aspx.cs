using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace Webz.WebIE {
    public partial class PressList : System.Web.UI.Page {
        public int Grids;
        public string Sess = string.Empty;
        protected void Page_Load(object sender, EventArgs e) {
            if (!IsPostBack) {
                if (Session["Openid"] == null) {
                    Response.Write("<script type=\"text/javascript\"> alert(\"系统繁忙\");</script>");
                    Response.Write(" <script type=\"text/javascript\">  window.location.href =\"https://open.weixin.qq.com/connect/oauth2/authorize?appid=wx0688f75d53cbb9e1&redirect_uri=http://ftv.icoxtech.com&response_type=code&scope=snsapi_base#wechat_redirect\"</script>");
                }
                if (Session["Phone"] != null) {
                    Sess = Session["Phone"].ToString();
                }
                BLL.PressBLL PrBLL = new BLL.PressBLL();
                if (string.IsNullOrEmpty(Request.QueryString["Grid"]) && string.IsNullOrEmpty(Request.QueryString["Stuid"])) {
                    Response.Write(" <script type=\"text/javascript\">  window.location.href =\"Login.aspx\"</script>");
                    return;
                } else if (!string.IsNullOrEmpty(Request.QueryString["Grid"])) {
                    string grid = Request.QueryString["Grid"].ToString();
                    int Grid = Convert.ToInt32(grid);
                    Grids = Grid;
                    RpList.DataSource = PrBLL.Selectlist(Grid);
                    RpList.DataBind();
                } else if (!string.IsNullOrEmpty(Request.QueryString["Stuid"])) {
                    Grids = -1;
                    RpList.DataSource = PrBLL.SelectStu();
                    RpList.DataBind();
                }
               
                
            }
        }
        public string GetImg(string name) {
            string str = string.Empty;
            str = name.Replace("/"," ");
            return str;
        }
    }
}