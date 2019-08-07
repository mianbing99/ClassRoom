using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace Webz.Admin {
    public partial class ImgAdd : System.Web.UI.Page {
        string path = @"..\WebIE\images\";
        
       // string path = @"D:\WebSite\DotnetTest\WebIE\images\";
        
        protected void Page_Load(object sender, EventArgs e) {
            //session过期提示重新登录
            if (base.Session["username"] == null || base.Session["username"].ToString().Equals(""))
            {
                Page.ClientScript.RegisterStartupScript(this.GetType(), "提示信息", "alert('账号已过期，请重新登录！');window.top.location.href='Login.aspx'", true);
            }
            base.OnInit(e);
            if(!IsPostBack){
                //textbox1.Enable = false
                But_pic.Enabled = false;
                string id = Request.QueryString["imgid"];
                BLL.IndexImgBLL ImgBLL = new BLL.IndexImgBLL ();
                Model.IndexImg im = ImgBLL.SelectByID(Convert.ToInt32(id));
                ImgName.Text = im.ImgName;
                ImgUrl.Text = im.Href;
                //Upload.FileName = im.ImgPic;
                But_pic.Text = im.ImgPic;
                if (im.State == 1) { CK1.Checked = true; }
            }
        }

        protected void But__Click(object sender, EventArgs e) {
            string tmpRootDir = HttpContext.Current.Server.MapPath(System.Web.HttpContext.Current.Request.ApplicationPath.ToString()) + path.Replace("..\\", "");
            string id = Request.QueryString["imgid"];
            Model.IndexImg im = new Model.IndexImg();
            im.ImgName = ImgName.Text;
            im.Href = ImgUrl.Text;
            bool sta = CK1.Checked;
            string stri = Upload.FileName;
            string jieguo = string.Empty;
            BLL.IndexImgBLL ImgBLL = new BLL.IndexImgBLL ();
            if (sta) {
                im.State = 1;
            } else { im.State = 0; }
            if (!string.IsNullOrEmpty(id)) {
                if (Hid.Value == "0") {
                    im.ImgPic = But_pic.Text;
                } else {
                    jieguo = DbImg.yanzhen(stri,path.Replace("..\\","")); //判断图片是否存在， 是否是JPG PNG格式
                    if (jieguo == "true") {
                        Upload.PostedFile.SaveAs(Server.MapPath(path) + stri); //上传图片
                    } else if (jieguo == "false") { } else {
                        Response.Write(" <script type=\"text/javascript\"> alert(\"" + jieguo + "\");</script>");
                        return;
                    }
                    im.ImgID = Convert.ToInt32(id);
                    im.ImgPic = path + stri;
                    if (ImgBLL.UpdateByID(im)) {
                        Response.Write(" <script type=\"text/javascript\"> alert(\"修改成功！\");</script>");
                    } else {
                        Response.Write(" <script type=\"text/javascript\"> alert(\"修改失败！\");</script>");
                    }
                }
            } else {
                jieguo = DbImg.yanzhen(stri, path.Replace("..\\", ""));
                if (jieguo == "true") {
                    Upload.PostedFile.SaveAs(Server.MapPath(path) + stri);
                } else if(jieguo=="false"){} else {
                    Response.Write(" <script type=\"text/javascript\"> alert(\""+jieguo+"\");</script>");
                    return;
                }
                im.ImgPic = path + stri;
                if (ImgBLL.Insert(im)) {
                    Response.Write(" <script type=\"text/javascript\"> alert(\"添加成功！\");</script>");
                } else {
                    Response.Write(" <script type=\"text/javascript\"> alert(\"添加失败！\");</script>");
                }
               
            }
            Response.Write(" <script type=\"text/javascript\">window.location = \"ImgList.aspx\";</script>");
            ////seleid.Items.Add(stri);
            //Response.Write(" <script type=\"text/javascript\"> alert(\"上传成功！\");</script>");
            //Response.Write(" <script type=\"text/javascript\">window.location = \"Test.aspx\";);</script>");

        }

        protected void But_ret_Click(object sender, EventArgs e) {
            Response.Write(" <script type=\"text/javascript\">window.location = \"ImgList.aspx\";</script>");
        }
        
            
       
    }
}
