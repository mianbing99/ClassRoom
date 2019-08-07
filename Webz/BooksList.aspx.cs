using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace Webz.WebIE {
    public partial class BooksList : System.Web.UI.Page {
        public string strs = string.Empty;
        public string Sess = string.Empty;
        public string Sta = string.Empty;
        public string alert = string.Empty;
        public string Url = string.Empty;
        protected void Page_Load(object sender, EventArgs e) {
            if(!IsPostBack){
                if (Session["Openid"] == null) {
                    Response.Write("<script type=\"text/javascript\"> alert(\"系统繁忙\");</script>");
                    Response.Write(" <script type=\"text/javascript\">  window.location.href =\"https://open.weixin.qq.com/connect/oauth2/authorize?appid=wx0688f75d53cbb9e1&redirect_uri=http://ftv.icoxtech.com&response_type=code&scope=snsapi_base#wechat_redirect\"</script>");
                }
                if (Session["Phone"] != null) {
                    Sess = Session["Phone"].ToString();
                }
                if (!string.IsNullOrEmpty(Request.QueryString["Prid"]) && !string.IsNullOrEmpty(Request.QueryString["Grid"]) && !string.IsNullOrEmpty(Request.QueryString["suid"])) {
                    Sta = "名师课堂";
                    string prid = Request.QueryString["Prid"].ToString();
                    string grid = Request.QueryString["Grid"].ToString();
                    List<Model.TextBooks> Books = new List<Model.TextBooks>();
                    BLL.BooksBLL BoBLL = new BLL.BooksBLL();
                    int Prid = Convert.ToInt32(prid);
                    int Grid = Convert.ToInt32(Request.QueryString["Grid"]);
                    int suid = Convert.ToInt32(Request.QueryString["suid"]);
                    if (Grid > 0) {
                        Books = BoBLL.SelectList(Prid, Grid, suid);
                    } else {
                        Books = BoBLL.SelectSuList(Prid, suid);
                    }
                    int sum;
                    int ll = 0;
                    for (int i = 0; i < Books.Count; i++) {
                        if (Books.Count % 3 == 0) {
                            sum = Books.Count - 3;
                        } else {
                            sum = Books.Count - Books.Count % 3;
                        }
                        if (i < sum) {
                            strs += "<a href=\"Books.aspx?Booksid=" + Books[i].Textid + "\"> <div class=\"nianjilist\"><img src=\"" + img(Books[i].Img) + "\" width=\"90%\"; height=\"70%\" /><span>" + Books[i].BooksName + "</span></div></a>";
                        } else {
                            strs += "<a href=\"Books.aspx?Booksid=" + Books[i].Textid + "\"> <div class=\"nianjilist\" ><img src=\"" + img(Books[i].Img) + "\" width=\"90%\"; height=\"70%\" /><span>" + Books[i].BooksName + "</span></div></a>";
                            ll++;
                           
                            
                        }
                    }
                         
                } 
                else if (Session["Phone"] != null) {
                    Sta = "我的课程";
                    BLL.UserSetBLL Bll = new BLL.UserSetBLL();
                    BLL.SubjectBLL Subll = new BLL.SubjectBLL();
                    BLL.BooksBLL BoBLL= new BLL.BooksBLL ();
                    Model.UserSet SeModel = new Model.UserSet();
                    SeModel = Bll.SelectByUserid(Convert.ToInt32(Session["Userid"]));
                    List<Model.TextBooks> Books = BoBLL.Select(SeModel);
                    int sum;
                    if (Books.Count==0) {
                        alert = "请先设置我的课程";
                        Url="Xiugai.aspx?class=1";
                    }
                    for (int i = 0; i < Books.Count; i++) {
                        if (Books.Count % 2 == 0) {
                            sum = Books.Count - 2;
                        } else {
                            sum = Books.Count - Books.Count % 2;
                        }
                        if (i < sum) {
                            strs += "<a href=\"Books.aspx?Booksid=" + Books[i].Textid + "\"> <div class=\"nianjilist\"><img src=\"" + img(Books[i].Img) + "\" width=\"90%\"; height=\"60%\" /><span>" + Books[i].BooksName + "</span></div></a>";
                        } else {
                            strs += "<a href=\"Books.aspx?Booksid=" + Books[i].Textid + "\"> <div class=\"nianjilist\" style =\" margin-bottom:160px;\"><img src=\"" + img(Books[i].Img) + "\" width=\"90%\"; height=\"60%\" /><span>" + Books[i].BooksName + "</span></div></a>";
                        }
                    }
                } else {
                    alert = "请先登录";
                    Url="Login.aspx";
                    return;
                }
            }
        }
        public string img(string url) {
            string aFirstName = url.Substring(url.LastIndexOf("\\") + 1, (url.LastIndexOf(".") - url.LastIndexOf("\\") - 1)); //文件名
            string aLastName = url.Substring(url.LastIndexOf(".") + 1, (url.Length - url.LastIndexOf(".") - 1)); //扩展名
            return "../Images/BooksImgs/" + aFirstName + "." + aLastName; 
        }
    }
}