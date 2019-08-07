using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using Newtonsoft.Json;
using Newtonsoft.Json.Linq;
using Webz.Herp;
using System.Net;
using System.IO;
using System.Text;

namespace Webz.WebIE {
    public partial class Index : System.Web.UI.Page {
        public string Imgstr = string.Empty;
        public string Sess = string.Empty;
        protected void Page_Load(object sender, EventArgs e) {
            string openId = string.Empty;
            if (!IsPostBack) {
                if (Session["Phone"] != null) {
                    Sess = Session["Phone"].ToString();
                } else {
                    Sess = "-1";
                }
                if (Session["Openid"] == null) {
                    if (!string.IsNullOrEmpty(Request.QueryString["code"])) {
                        string code = Convert.ToString(Request.QueryString["code"]);
                        string returnStr = getOpenId(code);
                        JObject json = JObject.Parse(returnStr);
                        openId = json["openid"].ToString();
                        Session["Openid"] = openId;
                    } else {
                        Response.Write(" <script type=\"text/javascript\">  window.location.href =\"https://open.weixin.qq.com/connect/oauth2/authorize?appid=wx0688f75d53cbb9e1&redirect_uri=http://ftv.icoxtech.com&response_type=code&scope=snsapi_base#wechat_redirect\"</script>");
                    }
                } 
                BLL.GradeBLL GrBLL = new BLL.GradeBLL();
                BLL.IndexImgBLL ImgBLL = new BLL.IndexImgBLL ();
                List<Model.IndexImg> ImList = new List<Model.IndexImg>();
                ImList = ImgBLL.SelectState();
                for (int i = 0; i < ImList.Count; i++) {
                    string aFirstName = ImList[i].ImgPic.Substring(ImList[i].ImgPic.LastIndexOf("\\") + 1, (ImList[i].ImgPic.LastIndexOf(".") - ImList[i].ImgPic.LastIndexOf("\\") - 1)); //文件名
                    string aLastName = ImList[i].ImgPic.Substring(ImList[i].ImgPic.LastIndexOf(".") + 1, (ImList[i].ImgPic.Length - ImList[i].ImgPic.LastIndexOf(".") - 1)); //扩展名
                    string urlPath = "images/" + aFirstName + "." + aLastName; 
                    Imgstr += "<a href=\"" + ImList[i].Href + "\" \"><img src=\"" + urlPath + "\"  alt=\"#\"></a>";
                }
            }
        }
        public static string getOpenId(string code) {
            string studyUrl = "https://open.weixin.qq.com/connect/oauth2/authorize?appid=wx0688f75d53cbb9e1&redirect_uri=http://ftv.icoxtech.com&response_type=code&scope=snsapi_base#wechat_redirect";

            studyUrl = "https://api.weixin.qq.com/sns/oauth2/access_token?appid=wx0688f75d53cbb9e1&secret=50858d5f79702fd0c3e035e217c63f7a&code=" + code + "&grant_type=authorization_code ";

            return WxHelp.HttpGet(studyUrl, "");
        }
       
    }
}