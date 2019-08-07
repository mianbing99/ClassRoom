using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace Webz.Admin {
    public partial class BooksImgUpdate : System.Web.UI.Page {
        Model.TextBooks te = new Model.TextBooks();
        string path = @"..\Images\BooksImgs\";
        protected void Page_Load(object sender, EventArgs e) {
            if (!IsPostBack) {
                TextPic.Enabled = false;
            string bid = Request.QueryString["bid"];
            if (bid == null || bid == "") {
                Response.Write(" <script type=\"text/javascript\">window.location = \"Index.aspx\";</script>");
                return;
            }
                BLL.BooksBLL BoBLL = new BLL.BooksBLL ();
                te = BoBLL.SelectByID(Convert.ToInt32(bid));
                TextPic.Text = te.Img;
                TextName.Text = te.BooksName;
            }
        }

        protected void Button1_Click(object sender, EventArgs e) {
            string bid = Request.QueryString["bid"];
            int Bid = Convert.ToInt32(bid);
            string stri = Upload1.FileName;
            if (stri == null || stri == "") {
                Response.Write(" <script type=\"text/javascript\"> history.go(-2);</script>");
                return;
            }
            Model.TextBooks Text = new Model.TextBooks();
            string jieguo = string.Empty;
            string text = TextPic.Text;
            if (Hid.Value == "1") {
                jieguo = DbImg.yanzhen(stri, path.Replace("..\\", "")); //判断图片是否存在， 是否是JPG PNG格式
                if (jieguo == "true") {  // 没有图片则上传
                    Upload1.PostedFile.SaveAs(Server.MapPath(path) + stri); //上传图片
                } else if (jieguo == "false") {
                //有图片不上传
                } else {
                    Response.Write(" <script type=\"text/javascript\"> alert(\"" + jieguo + "\");</script>");
                    return;
                }
                 Text.Textid = Bid;
                    Text.Img = path + stri;
                BLL.BooksBLL BoBLL = new BLL.BooksBLL ();
                if (BoBLL.UpdateImg(Text)) {
                        Response.Write(" <script type=\"text/javascript\"> alert(\"修改成功！\");</script>");
                    } else {
                        Response.Write(" <script type=\"text/javascript\"> alert(\"修改失败！\");</script>");
                    }
            }
            Response.Write(" <script type=\"text/javascript\">window.location = \"BooksImg.aspx\";</script>");
            // 上传新图片 修改数据库的IMG路径  如果有相同的图片则不上传  轮播图一起；
        }

        protected void Button2_Click(object sender, EventArgs e) {
            Response.Write(" <script type=\"text/javascript\">window.location = \"BooksImg.aspx\";</script>");
        }
    }
}