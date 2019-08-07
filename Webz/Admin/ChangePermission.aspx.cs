using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using BLL;
using System.Text;

namespace Webz.Admin
{
    public partial class ChangePermission : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            //禁用文本框
            this.txtName.Enabled = false;
            //用Session获取用户名
            this.txtXPwd.Enabled = false;
            this.txtQuePwd.Enabled = false;
            this.txtName.Text = Session["username"].ToString();
            this.txtXPwd.Text = Session["pwd"].ToString();
            this.txtQuePwd.Text = Session["pwd"].ToString();
            if (!IsPostBack)
            {
                GradeBLL gb = new GradeBLL();
                selectrole(gb);
            }
            //ddlState.Items.Insert(0, new ListItem("请选择年级", "0"));
            //ddlState.Items.Insert(0, new ListItem("请选择科目", "-1"));
            // Response.Write("<script type=\"text/javascript\"> alert(\"系统繁忙\");</script>");
        }

        protected void btnShow_Click(object sender, EventArgs e)
        {
        }
        //显示角色状态下拉
        public void selectrole(GradeBLL gb)
        {
            ddlRole.Items.Clear();
            ddlRole.DataSource = gb.selectRole();
            ddlRole.DataTextField = "RoleName";
            ddlRole.DataValueField = "RolesID";
            ddlRole.DataBind();
            ddlState.Items.Clear();
            ddlState.Items.Insert(0, new ListItem("禁止", "0"));
            ddlState.Items.Insert(0, new ListItem("启用", "-1"));
        }
    }
}