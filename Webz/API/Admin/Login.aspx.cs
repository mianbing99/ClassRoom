using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using BLL;
using System.Web.SessionState;
using Model;

namespace Webz.Admin
{
    public partial class Login : System.Web.UI.Page
    {
        Press pmodel = new Press();
        Model.Roles rsmodel = new Roles();
        protected void Page_Load(object sender, EventArgs e)
        {
            Session.Clear();//清空session
            pmodel.Userid = null;
            pmodel.Pwd = null;
            rsmodel = null;
        }
        //键盘
        protected void Button1_Click(object sender, EventArgs e)
        {
            System.Diagnostics.Process.Start("osk.exe");
        }
        //用Seesion保存账号密码，如果登录成功就跳转首页,登录失败就弹窗提示账号登录失败，请确认账号是否正确

        protected void Logins_Click(object sender, EventArgs e)
        {
            try
            {
                string users = this.User.Text;
                string pwds = this.Pwd.Text;
                if (users == null || users == "" || pwds == null || pwds == "")
                {
                    //ClientScript.RegisterStartupScript(GetType(), "message", "<script>alert('请输入账号或密码！');</script>");
                    this.Aleat.Style.Value = "display:block";
                    this.hiddenDivId.Style.Value = "display:block";
                }
                else
                {
                    bool b = PressBLL.LoginSelect(users, pwds);
                    if (b)
                    {
                        //HttpContext.Current.Session["user"] = users;
                        //HttpContext.Current.Session["pwd"] = pwds;
                        Session["username"] = users;
                        //Session["user"] = users;
                        Session["pwd"] = pwds;
                        Response.Redirect("Home.aspx");
                    }
                    else
                    {
                        //Page.ClientScript.RegisterStartupScript(this.GetType(), "提示信息", "alert('账号登录失败，请确认账号是否正确；或联系超级管理员');window.top.location.href='Login.aspx'", true);
                        this.Aleat.Style.Value = "display:block";
                        this.hiddenDivId.Style.Value = "display:block";
                    }
                }
            }
            catch (Exception ex)
            {
                ClientScript.RegisterStartupScript(GetType(), "message", "<script>alert('未知错误！');</script>");
                //throw new Exception(ex.Message);
            }
            


        }

        protected void queding_Click(object sender, EventArgs e)
        {
            this.Aleat.Style.Value = "display:none";
            this.hiddenDivId.Style.Value = "display:none";
        }
    }
}