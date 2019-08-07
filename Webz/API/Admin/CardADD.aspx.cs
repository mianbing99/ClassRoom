using System;
using System.Collections.Generic;
using System.Data;
using System.Data.OleDb;
using System.Data.SqlClient;
using System.IO;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace Webz.Admin {
    public partial class CardADD : System.Web.UI.Page {
        private string[] files;
        private string path = @"D:\WebSite\DotnetTest\Upload\";
        protected void Page_Load(object sender, EventArgs e) {
            //session过期提示重新登录
            if (base.Session["username"] == null || base.Session["username"].ToString().Equals(""))
            {
                Page.ClientScript.RegisterStartupScript(this.GetType(), "提示信息", "alert('账号已过期，请重新登录！');window.top.location.href='Login.aspx'", true);
            }
            base.OnInit(e);
            if (!IsPostBack) {
                files = Directory.GetFiles(path, "*.xls");
                string fileName = string.Empty;
                for (int i = 0; i < files.Length; i++) {
                    fileName = System.IO.Path.GetFileName(files[i]);
                    Selid.Items.Add(fileName);
                }
            }
        }

        protected void Button1_Click(object sender, EventArgs e) {
            if (Selid.Value == "----请选择要导入的文件----") {
                Response.Write("<script type=\"text/javascript\"> alert(\"请选择课件，如果没有请先上传！\");</script>");
                return;
            } 
            SqlConnection conn = new SqlConnection(DBHerp.SQL.connstr);
            conn.Open();
            SqlCommand cmd = new SqlCommand();
            cmd.Connection = conn;
            List<string> sqlList = daoru();
            try {
                foreach (string sql in sqlList) {
                    cmd.CommandText = sql;
                    int r = cmd.ExecuteNonQuery();
                }
            } catch (Exception ex) {
                Response.Write("<script type=\"text/javascript\"> alert(\"" + ex + "！\");</script>");
                return;
            } finally {
                if (conn != null) {
                    conn.Close();
                    conn.Dispose();
                }
            }
        }
        private List<string> daoru() {
            
            DataTable dt_data = new DataTable();
            string filero = path + Selid.Value;
            string strConn = string.Format("Provider=Microsoft.Jet.OLEDB.4.0;Data Source={0};Extended Properties='Excel 8.0;HDR=Yes;IMEX=1;'", filero);
            OleDbConnection objConn = new OleDbConnection(strConn);
            OleDbCommand objCmd = new OleDbCommand("SELECT * FROM [Sheet1$]", objConn);
            OleDbDataAdapter objDA = new OleDbDataAdapter(objCmd);
            objDA.Fill(dt_data);
            dt_data.Columns.Add("prod_ids", typeof(string));
            dt_data.Columns.Add("publish_ids", typeof(string));
            dt_data.Columns.Add("file_size", typeof(string));
            dt_data.Columns.Add("course_ware_no", typeof(string));
            //DBHerp.SQL.connopen();
            BLL.BooksBLL BooksBLL = new BLL.BooksBLL();
            BLL.GradeBLL GrBLL = new BLL.GradeBLL();
            BLL.SubjectBLL SuBLL = new BLL.SubjectBLL();
            BLL.BooksCatalogBLL CaBLL = new BLL.BooksCatalogBLL();
            List<string> SqlList = new List<string>();
            foreach (DataRow dr in dt_data.Rows) {
                string SN = dr["SN"].ToString().Trim();
                string Account = dr["账号"].ToString().Trim();
                string PassWord = dr["密码"].ToString().Trim();
                string Edition = dr["版本"].ToString().Trim();
                string Cmodel = dr["型号"].ToString().Trim();
                string Customer = dr["客户"].ToString().Trim();
                DateTime CreateTime = DateTime.Now;
                string sqlstr = "insert into [dbo].[Card] values ('{0}','{1}','{2}','{3}','{4}','{5}','{6}','','','')";
                string sql = string.Format(sqlstr, SN, Account, PassWord, Edition, Cmodel, Customer, CreateTime);
                SqlList.Add(sql);
            }
            return SqlList;
        }
    }
}