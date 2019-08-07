using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using BLL;

namespace Webz.Admin
{
    public partial class ChangePassword : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            //禁用文本框
            this.txtName.Enabled = false;
            //用Session获取用户名
            this.txtName.Text = Session["username"].ToString();
        }
        //修改的点击事件
        protected void btnShow_Click(object sender, EventArgs e)
        {
            //用Session获取到原密码，如果输入的原密码跟获取到的原密码不相等就提示原密码错误
            if (this.txtYPwd.Text != Session["pwd"].ToString())
            {
                Page.ClientScript.RegisterStartupScript(this.GetType(), "", "alert('原密码输入有误!')", true);
            }
            //新密码跟确认密码输入的不一致就提示两次输入错误
            else if (this.txtXpwd.Text != this.txtQuePwd.Text)
            {
                Page.ClientScript.RegisterStartupScript(this.GetType(), "", "alert('两次输入的密码不一致!')", true);
            }
            //密码不能为空
            else if (this.txtYPwd.Text.Trim().Length == 0 || this.txtXpwd.Text.Trim().Length == 0 || this.txtQuePwd.Text.Trim().Length == 0)
            {
                Page.ClientScript.RegisterStartupScript(this.GetType(), "", "alert('密码不能为空!')", true);

            }
             //以上条件都没输入错误就直接进入Else密码修改成功
            else
            {
                string name = this.txtName.Text;
                string pwd = this.txtXpwd.Text;
                PressBLL.UpdateCancel(name, pwd);
                Session.Clear();
                Page.ClientScript.RegisterStartupScript(this.GetType(), "", "alert('密码修改成功!');window.top.location.href='SiteSelectsVideo.aspx'", true);
                //Page.ClientScript.RegisterStartupScript(this.GetType(), "", "alert('密码修改成功,请重新登录!');window.top.location.href='Login.aspx'", true);
            }
        }
        //点击取消返回到首页
        protected void btnCancel_Click(object sender, EventArgs e)
        {
            ScriptManager.RegisterStartupScript(this, this.GetType(), "", "window.top.location.href='SelectsVideo.aspx';", true);
           
        }
    }
}