using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using BLL;
using System.Data;

namespace Webz.Admin
{
    public partial class UserManage : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            if (base.Session["username"] == null || base.Session["username"].ToString().Equals(""))
            {
                Page.ClientScript.RegisterStartupScript(this.GetType(), "提示信息", "alert('账号已过期，请重新登录！');window.top.location.href='Login.aspx'", true);
            }
            base.OnInit(e);
            //回传
            //if (!IsPostBack)
            //{
            //    bind();
            //}
        }
 #region 逻辑参考
        //显示用户数据
        //public void bind()
        //{
        //    DataTable dt=new DataTable();
        //    dt=PressBLL.SelectUser();
        //    this.gvShow.DataSource = dt;
        //    this.gvShow.DataBind();
        //    DataSet ds = new DataSet();
        //    ds.Tables.Add(dt);
        //    Pager(this.gvShow, this.pgServer, ds);
        //}
        ////模糊查询用户数据
        //protected void btnSelectUser_Click(object sender, EventArgs e)
        //{
        //    string name = this.txtUserNames.Text;
        //    string rolename = this.txtRoles.Text;
        //    if (this.txtUserNames.Text != "" && this.txtRoles.Text=="")
        //    {
        //        this.gvShow.DataSource = PressBLL.MoHuselectUser(name);
        //        this.gvShow.DataBind();
        //    }
        //    else if (this.txtUserNames.Text == "" && this.txtRoles.Text != "")
        //    {
        //        this.gvShow.DataSource = PressBLL.MoHuselectRole(rolename);
        //        this.gvShow.DataBind();
        //    }
        //    else if (this.txtUserNames.Text != "" && this.txtRoles.Text != "")
        //    {
        //        this.gvShow.DataSource = PressBLL.MoHuselectRoleName(name, rolename);
        //        this.gvShow.DataBind();
        //    }
        //    else
        //    {
        //        this.gvShow.DataSource = PressBLL.SelectUser();
        //        this.gvShow.DataBind();
        //    }

        //}
        ////增加用户数据
        //protected void btnInsertUser_Click(object sender, EventArgs e)
        //{
        //    string name = this.txtUserNames.Text;
        //    string rolename = this.txtRoles.Text;
        //    PressBLL.InsertUser(name, rolename);
        //    this.gvShow.DataSource = PressBLL.SelectUser();
        //    this.gvShow.DataBind();
        //}
        ////删除
        //protected void gvShow_RowDeleting(object sender, GridViewDeleteEventArgs e)
        //{
        //    int id = Convert.ToInt32(this.gvShow.DataKeys[e.RowIndex][0]);
        //    PressBLL.DeleteUser(id);
        //    if (id > 0)
        //    {
        //        this.gvShow.DataSource = PressBLL.SelectUser();
        //        this.gvShow.DataBind();
        //        Page.ClientScript.RegisterStartupScript(this.GetType(), "", "alert('删除成功!')", true);
        //    }
        //}
        ////点击编辑时触发

        //protected void gvShow_RowEditing(object sender, GridViewEditEventArgs e)
        //{
        //    this.gvShow.EditIndex = e.NewEditIndex;
        //    this.gvShow.DataSource = PressBLL.SelectUser();
        //    this.gvShow.DataBind();
        //}
        ////取消
        //protected void gvShow_RowCancelingEdit(object sender, GridViewCancelEditEventArgs e)
        //{
        //    this.gvShow.EditIndex = -1;
        //    this.gvShow.DataSource = PressBLL.SelectUser();
        //    this.gvShow.DataBind();
        //}
        ////修改
        //protected void gvShow_RowUpdating(object sender, GridViewUpdateEventArgs e)
        //{
        //    foreach (GridViewRow item in this.gvShow.Rows)
        //    {
        //        TextBox txtuserid = this.gvShow.Rows[e.RowIndex].FindControl("txtUserid") as TextBox;
        //        TextBox txtname = this.gvShow.Rows[e.RowIndex].FindControl("txtUserName") as TextBox;
        //        TextBox txtrolename = this.gvShow.Rows[e.RowIndex].FindControl("txtRole") as TextBox;
        //        int id = Convert.ToInt32(txtuserid.Text);
        //        string name = txtname.Text;
        //        string rolename = txtrolename.Text;
        //        PressBLL.UpdateUser(name, rolename, id);
        //    }
        //    this.gvShow.EditIndex = -1;
        //    this.gvShow.DataSource = PressBLL.SelectUser();
        //    this.gvShow.DataBind();
        //    foreach (GridViewRow item in this.gvShow.Rows)
        //    {
        //        TextBox txtuserid = this.gvShow.Rows[e.RowIndex].FindControl("Userid") as TextBox;
        //        this.gvShow.EditIndex = -1;
        //        this.gvShow.DataSource = PressBLL.SelectUser();
        //        this.gvShow.DataBind();
        //    }
        //}


        ////public void BindDate()
        ////{
        ////    DataTable dt = new DataTable();
        ////    dt = PressBLL.SelectUser();
        ////    this.gvShow.DataSource = dt;
        ////    this.gvShow.DataBind();
        ////}
        //public void Pager(GridView dl, Wuqi.Webdiyer.AspNetPager anp, System.Data.DataSet dst)
        //{
        //    PagedDataSource pds = new PagedDataSource();
        //    pds.DataSource = dst.Tables[0].DefaultView;
        //    pds.AllowPaging = true;

        //    anp.RecordCount = dst.Tables[0].DefaultView.Count;
        //    pds.CurrentPageIndex = anp.CurrentPageIndex - 1;
        //    pds.PageSize = anp.PageSize;

        //    dl.DataSource = pds;
        //    dl.DataBind();
        //}

        //protected void pgServer_PageChanging(object src, Wuqi.Webdiyer.PageChangingEventArgs e)
        //{
        //    pgServer.CurrentPageIndex = e.NewPageIndex;
        //    bind();
        //}
 #endregion
    }
}