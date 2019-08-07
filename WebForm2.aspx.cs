using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Data.SqlClient;
using System.Text.RegularExpressions;
using System.Data;

namespace Webz {
    public partial class WebForm2 : System.Web.UI.Page {
        
        protected void Page_Load(object sender, EventArgs e) {
            
           // Response.Write(" <script type=\"text/javascript\"> alert(\"123 \");</script>");
        }
         
        protected void Button1_Click(object sender, EventArgs e) {
            string Texts = TextBox1.Text;
            string connstr = "server=117.48.195.219;database=iStore_DL;uid=MDB;pwd=Main@JLF955icox;Pooling=true;";
            SqlConnection conn = new SqlConnection(connstr);
            conn.Open();
            SqlCommand cmd = new SqlCommand();
            cmd.Connection = conn;
            string sql = "select top(1000) pwd from [dbo].[Download_record] where uemail = '" + Texts + "' GROUP BY pwd  having   count(*)>1";
            List<string> stringlist = new List<string>();
            cmd.CommandText = sql;
            SqlDataReader re = cmd.ExecuteReader();
            while (re.Read()) {
                string str = re["pwd"].ToString();
                stringlist.Add(str);
            }
            re.Close();
            re.Dispose();
            foreach (var i in stringlist) {
                List<int> idlist = new List<int>();
                string i_sql = string.Format("select Dlrid from [dbo].[Download_record] where pwd='{0}' and uemail = '{1}'  order by dl_date desc", i, Texts);
                cmd.CommandText = i_sql;
                SqlDataReader i_re = cmd.ExecuteReader();
                while (i_re.Read()) {
                    idlist.Add(Convert.ToInt32(i_re["Dlrid"]));
                }
                i_re.Close();
                i_re.Dispose();
                idlist.Remove(idlist[0]);
                foreach (var item in idlist) {
                    string Del_sql = string.Format("delete [dbo].[Download_record] where DlrID = '{0}'",item);
                    cmd.CommandText = Del_sql;
                   int jg= cmd.ExecuteNonQuery();
                }
            }
            if (conn != null) {
                conn.Close();
                conn.Dispose();
            }
            Response.Write(" <script type=\"text/javascript\"> alert(\"123 \");</script>");
        }

        protected void Button2_Click(object sender, EventArgs e) {
            string Texts = TextBox1.Text;
            string connstr = "server=117.48.195.219;database=icox_store;uid=MDB;pwd=Main@JLF955icox;Pooling=true;";
            SqlConnection conn = new SqlConnection(connstr);
            conn.Open();
            SqlCommand cmd = new SqlCommand();
            cmd.Connection = conn;
            string sql = "select coo_id from [dbo].[t_club_user_bind] where user_tag = '" + Texts + "' GROUP BY coo_id  having   count(*)>1";
            List<string> stringlist = new List<string>();
            cmd.CommandText = sql;
            SqlDataReader re = cmd.ExecuteReader();
            while (re.Read()) {
                string str = re["coo_id"].ToString();
                stringlist.Add(str);
            }
            re.Close();
            re.Dispose();
            foreach (var i in stringlist) {
                List<int> idlist = new List<int>();
                string i_sql = string.Format("select b_id from [dbo].[t_club_user_bind] where coo_id = '{0}' order by b_id desc", i);
                cmd.CommandText = i_sql;
                SqlDataReader i_re = cmd.ExecuteReader();
                while (i_re.Read()) {
                    idlist.Add(Convert.ToInt32(i_re["b_id"]));
                }
                i_re.Close();
                i_re.Dispose();
                //idlist.Remove(idlist[0]);
                foreach (var item in idlist) {
                    string Del_sql = string.Format("delete [dbo].[t_club_user_bind] where b_id = '{0}'", item);
                    cmd.CommandText = Del_sql;
                    int jg = cmd.ExecuteNonQuery();
                }
            }
            if (conn != null) {
                conn.Close();
                conn.Dispose();
            }
            Response.Write(" <script type=\"text/javascript\"> alert(\"123 \");</script>");
        }

        protected void Button3_Click(object sender, EventArgs e) {
            SqlConnection conn = new SqlConnection(DBHerp.SQL.connstr);
            conn.Open();
            SqlCommand cmd = new SqlCommand();
            cmd.Connection = conn;
            string sql = string.Format("select Viname from video GROUP BY Viname  having   count(*)>1");
            cmd.CommandText = sql;
            SqlDataReader re = cmd.ExecuteReader();
            List<string> Viname = new List<string>();
            while (re.Read()) {
                Viname.Add(re["Viname"].ToString());
            }
            if (re != null) {
                re.Close();
                re.Dispose();
            }
            List<List<int>> listid = new List<List<int>>();
            foreach (var item in Viname) {
                sql = string.Format("select viid from video where ViName='{0}' order by viid desc",item);
                cmd.CommandText = sql;
                List<int> Viid = new List<int>();
                SqlDataReader viidre = cmd.ExecuteReader();
                while (viidre.Read()) {
                    Viid.Add(Convert.ToInt32(viidre["Viid"]));
                }
                if (viidre != null) {
                    viidre.Close();
                    viidre.Dispose();
                }
                int Topid = Viid[0];
                Viid.Remove(Topid);
                foreach (var id in Viid) {
                    sql = string.Format("delete video where viid='{0}'",id);
                    cmd.CommandText = sql;
                    int ii=cmd.ExecuteNonQuery();
                    sql = string.Format("update [dbo].[BooksCatalog] set viid='{0}' where viid='{1}'",Topid,id);
                    cmd.CommandText = sql;
                    ii=cmd.ExecuteNonQuery();
                    sql = string.Format("update [dbo].[VideoRoute] set viid = '{0}' where viid='{1}'",Topid,id);
                    cmd.CommandText = sql;
                    ii=cmd.ExecuteNonQuery();
                }
                

            }
        }

        protected void Button4_Click(object sender, EventArgs e) {
            string Texts = TextBox1.Text;
          Texts=  RemoveSpecialCharacter(Texts);
          Texts = System.Text.RegularExpressions.Regex.Replace(Texts, @"[0-9]+", "");
          Response.Write(" <script type=\"text/javascript\"> alert(\"123" + Texts + "\");</script>");
        }
        public static String RemoveSpecialCharacter(String hexData) {
            return Regex.Replace(hexData, "[ \\[ \\] \\^ \\-_*×――(^)$%~!@#$…&%￥—+=<>《》( )!！??？:：•`·、。，；,.;\"‘’“”-]", "").ToUpper();
        }

        protected void Button5_Click(object sender, EventArgs e) {
            SqlConnection conn = new SqlConnection(DBHerp.SQL.connstr);
            conn.Open();
            SqlCommand cmd = new SqlCommand();
            cmd.Connection = conn;
            string sql = string.Format("Select viid from BooksCatalog where viid!=0 ");
            cmd.CommandText = sql;
            SqlDataReader re = cmd.ExecuteReader();
            List<int> idlist = new List<int>();
            while (re.Read()) {
                idlist.Add(Convert.ToInt32(re["viid"]));
            }
            if (re != null) {
                re.Close();
                re.Dispose();
            }
            foreach (var item in idlist) {
                string sqls = string.Format("select  count(*)  from VideoRoute where viid = '{0}'", item);
                cmd.CommandText = sqls;
               int count=Convert.ToInt32( cmd.ExecuteScalar());
               if (count==0) {
                   string sqld = string.Format("delete video where viid = '{0}'",item);
                   cmd.CommandText = sqld;
                   cmd.ExecuteNonQuery();
                   string sqlu = string.Format("update BooksCatalog  set viid = 0 where viid='{0}'",item);
                   cmd.CommandText = sqlu;
                   cmd.ExecuteNonQuery();
                }
            }
        }
        public void CreateExcel(DataTable dt, string FileType, string FileName) {
            Response.Clear();
            Response.Charset = "UTF-8";
            Response.Buffer = true;
            Response.ContentEncoding = System.Text.Encoding.GetEncoding("GB2312");
            Response.AppendHeader("Content-Disposition", "attachment;filename=\"" + System.Web.HttpUtility.UrlEncode(FileName, System.Text.Encoding.UTF8) + "");
            Response.ContentType = FileType;
            string colHeaders = string.Empty;
            string ls_item = string.Empty;
            DataRow[] myRow = dt.Select();
            int i = 0;
            int cl = dt.Columns.Count;
            for (int j = 0; j < dt.Columns.Count; j++) {
                ls_item += dt.Columns[j].ColumnName + "\t"; //栏位：自动跳到下一单元格  
            }
            ls_item = ls_item.Substring(0, ls_item.Length - 1) + "\n";
            foreach (DataRow row in myRow) {
                for (i = 0; i < cl; i++) {
                    if (i == (cl - 1)) {
                        ls_item += row[i].ToString() + "\n";
                    } else {
                        ls_item += row[i].ToString() + "\t";
                    }
                }
                Response.Output.Write(ls_item);
                ls_item = string.Empty;
            }
            Response.Output.Flush();
            Response.End();
        }

        protected void Button6_Click(object sender, EventArgs e) {
            SqlConnection conn = new SqlConnection("server=182.254.134.51;database=Ejiaqin;uid=MDB;pwd=Main@JLF955icox;Pooling=true;");
            conn.Open();
            SqlCommand cmd = new SqlCommand();
            cmd.Connection = conn;
           // string sql = string.Format("select [GUID] from [dbo].[TencentUser]  GROUP BY [GUID]  having   count(*)>1 ");
           // cmd.CommandText = sql;
           // SqlDataReader re = cmd.ExecuteReader();
           //List<string> Guid = new List<string> ();
           // while (re.Read()) {
           //     Guid.Add(re["guid"].ToString());
           // }
           // if (re != null) {
           //     re.Close();
           //     re.Dispose();
           // }
           // string where = string.Empty;
           // for (int i = 0; i < Guid.Count; i++) {
           //     if (i == Guid.Count - 1) {
           //         where += "'" + Guid[i] + "'";
           //     } else {
           //         where += "'" + Guid[i] + "',";
           //     }
           // }
           // sql = string.Format("select * from [dbo].[TencentUser] where [GUID] in ({0})", where);
            string sql = string.Format("select * from [dbo].[TencentUser] where [GUID] in (select guid from [dbo].[TencentUser] GROUP BY [guid]  having   count(*)>1) and Version=2");
            DataTable ta = new DataTable();
            SqlDataAdapter res = new SqlDataAdapter(sql, conn);
            DataSet ds = new DataSet();
            res.Fill(ds);
            ta = ds.Tables[0];
            CreateExcel(ta, "application/ms-excel", "Excel" + DateTime.Now.ToString("yyyy-MM-dd HHmmss") + ".xls");//调用函数  
        }

        protected void Button7_Click(object sender, EventArgs e) {
            SqlConnection conn = new SqlConnection("server=182.254.134.51;database=Ejiaqin;uid=MDB;pwd=Main@JLF955icox;Pooling=true;");
            conn.Open();
            SqlCommand cmd = new SqlCommand();
            cmd.Connection = conn;
            List<int> id = new List<int>();
            List<string> OpenId = new List<string>();
            List<string> model = new List<string>();
            List<string> activatedate = new List<string>();
            string sql = string.Format("select * from [dbo].[TencentUser] where id >=97251 and id <=97648");
            cmd.CommandText = sql;
            SqlDataReader re = cmd.ExecuteReader();
            while (re.Read()){
                id.Add(Convert.ToInt32(re["id"]));
                OpenId.Add(re["OpenId"].ToString());
                model.Add(re["devmodel"].ToString());
                activatedate.Add(re["activatedate"].ToString());
            }
            if (re != null) {
                re.Close();
                re.Dispose();
            }
            for (int i = 0; i < id.Count; i++) {
                sql = string.Format("select top 1 id from [dbo].[TencentUser] where openid='' and [version] = '2'");
                cmd.CommandText = sql;
                int newid = Convert.ToInt32(cmd.ExecuteScalar());
                sql = string.Format("update [dbo].[TencentUser] set OpenId='{0}',DevModel='{1}',ActivateDate='{2}' where id='{3}'", OpenId[i], model[i], activatedate[i], newid);
                cmd.CommandText = sql;
                int jg = cmd.ExecuteNonQuery();
                if (jg > 0) {
                    sql = string.Format("delete [dbo].[TencentUser] where id = '{0}'",id[i]);
                    cmd.CommandText = sql;
                    int dele = cmd.ExecuteNonQuery();
                }
            }
        }

    }
}