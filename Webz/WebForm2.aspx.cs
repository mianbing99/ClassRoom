using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Data.SqlClient;
using System.Text.RegularExpressions;
using System.Data;
using System.IO;
using System.Text;
using System.Reflection;

namespace Webz {
    public partial class WebForm2 : System.Web.UI.Page {
        
        protected void Page_Load(object sender, EventArgs e) {
            
           WSelects Se = new WSelects(Selects);
                string[] Su = { "语文", "数学", "英语", "物理", "化学", "生物", "政治", "历史", "地理" };
                foreach (var item in Su) {
                    if (Session["Loading"] != null) {
                        string Loading = Session["Loading"].ToString();
                        if (Loading.IndexOf(item) < 0) {
                            IAsyncResult res = Se.BeginInvoke(item, null, null);
                            if (res.IsCompleted) {
                                Session["Loading"] += item + "|";
                            }
                        }
                    } else if (HttpRuntime.Cache.Get("语文") != null) {
                        Session["Loading"] = "语文|";
                    } else {
                        Selects("语文");
                    }

                }
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
            string sql = string.Format("select  * from [dbo].[TencentUser]  where createdate >='2018-05-14 16:31:07.790'");
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

        protected void Button8_Click(object sender, EventArgs e) {
            SqlConnection conn = new SqlConnection(DBHerp.SQL.connstr);
            conn.Open();
            SqlCommand cmd = new SqlCommand();
            cmd.Connection = conn;
            string sql = string.Format("select mp4 from [dbo].[VideoRoute] GROUP BY mp4  having   count(*)>1");
            List<string> Mp4list = new List<string>();
            cmd.CommandText = sql;
            SqlDataReader re = cmd.ExecuteReader();
            while(re.Read()){
                Mp4list.Add(re["mp4"].ToString());
            }
            if (re != null) {
                re.Close();
                re.Dispose();
            }
            foreach (var item in Mp4list) {
                sql = string.Format("delete  [dbo].[VideoRoute] where roid in (select top 1 roid from [dbo].[VideoRoute] where mp4 = '{0}' order by roid desc)", item);
                cmd.CommandText = sql;
               int jg = cmd.ExecuteNonQuery();
            }
            if (conn != null) {
                conn.Close();
                conn.Dispose();
            }
        }

        protected void Button9_Click(object sender, EventArgs e) {
            DataTable td = new DataTable();
            DataTable yf = new DataTable();
            BLL.TestBLL TeBll = new BLL.TestBLL ();
            string str = string.Empty;
            if (Session["Loading"] != null) {
                str = Session["Loading"].ToString();
            }
            List<string> strs = new List<string>(str.Split('|'));
            strs.Remove(strs[strs.Count - 1]);
            foreach (var item in strs) {
                if (HttpRuntime.Cache.Get(item)!=null) {
                    yf =(DataTable)HttpRuntime.Cache.Get(item);
                    td = yf.Clone();
                    td = VideoHrep.CloneTable(yf, td);
                    td = SelectWhere(td, item);
                    for (int i = 0; i < td.Rows.Count; i++) {
                        
                    }
                }
            }
            
        }
        private delegate void WSelects(string SuName);
        private void Selects(string SuName) {
            if (Cache.Get(SuName) == null) {
                BLL.BooksCataLogBLL bll = new BLL.BooksCataLogBLL();
                DataTable td = bll.SelectSu(SuName);
                HttpRuntime.Cache.Insert(SuName, td, null, DateTime.MaxValue, TimeSpan.FromSeconds(2000));
                if (SuName == "语文") {
                    Session["Loading"] = "语文|";
                }
            }
        }
        public DataTable GetTxt(string pths) {
            StreamReader sr = new StreamReader(pths, Encoding.GetEncoding("GB2312"));
            string txt = sr.ReadToEnd().Replace("\r\n", "-");
            string[] nodes = txt.Split('-');
            DataTable dt = new DataTable();
            dt.Columns.Add("ID", typeof(string));
            foreach (string node in nodes) {
                string[] strs = node.Split('-');
                DataRow dr = dt.NewRow();
                dr["ID"] = strs[0];
                dt.Rows.Add(dr);
            }
            return dt;
        }
        private DataTable SelectWhere(DataTable dt,string CaName) {   //去掉符号和后面的括号加数字匹配视频名称
            for (int i = 0; i < dt.Rows.Count; i++) {
                string name = dt.Rows[i]["name"].ToString();
                string ab_caname = dt.Rows[i]["caname"].ToString();
                name = VideoHrep.Spit(name);
                name = System.Text.RegularExpressions.Regex.Replace(name, @"[0-9]+", "");
                if (ab_caname != name) {
                    dt.Rows.Remove(dt.Rows[i]);
                    i--;
                    continue;
                }
                if (CaName != "") {
                    string dt_caname = dt.Rows[i]["CaName"].ToString();
                    if (!dt_caname.Contains(CaName)) {
                        dt.Rows.Remove(dt.Rows[i]);
                        i--;
                        continue;
                    }
                } 
            }
            return dt;
        }
        public static IList<T> ConvertTo<T>(DataTable table) {

            if (table == null) {

                return null;

            }



            List<DataRow> rows = new List<DataRow>();



            foreach (DataRow row in table.Rows) {

                rows.Add(row);

            }



            return ConvertTo<T>(rows);

        }



        public static IList<T> ConvertTo<T>(IList<DataRow> rows) {

            IList<T> list = null;



            if (rows != null) {

                list = new List<T>();



                foreach (DataRow row in rows) {

                    T item = CreateItem<T>(row);

                    list.Add(item);

                }

            }



            return list;

        }



        public static T CreateItem<T>(DataRow row) {

            T obj = default(T);

            if (row != null) {

                obj = Activator.CreateInstance<T>();



                foreach (DataColumn column in row.Table.Columns) {

                    PropertyInfo prop = obj.GetType().GetProperty(column.ColumnName);

                    try {

                        object value = row[column.ColumnName];

                        prop.SetValue(obj, value, null);

                    } catch {  //You can log something here     

                        //throw;    

                    }

                }

            }



            return obj;

        }

        protected void Button10_Click(object sender, EventArgs e) {
            DataTable td = GetTxt(@"C:\Users\ICOX\Desktop\新增视频目录.txt");
            string col = string.Empty;
            List<string> strlist = new List<string>();
            List<string> htvlist = new List<string>();
            List<string> mp4list = new List<string>();
            List<string> namelist = new List<string>();
            List<string> kemulist = new List<string>();
            SqlConnection conn = new SqlConnection(DBHerp.SQL.connstr);
            conn.Open();
            SqlCommand cmd = new SqlCommand();
            cmd.Connection = conn;
            string[] kumushuz = { "语文", "数学", "英语", "物理", "化学", "生物", "政治", "历史", "地理" };
            foreach (DataColumn dc in td.Columns) {
                col = dc.ColumnName;
            }
            for (int i = 0; i < td.Rows.Count; i++) {
                strlist.Add(td.Rows[i][col].ToString());
            }
            foreach (var item in strlist) {
                if (item == "") { break; }
                string mp4 = item.Substring(item.IndexOf("MP4"));
                mp4list.Add(mp4);
              //  htv = item.Substring(item.IndexOf("MP4"));
                string htv = mp4.Replace("MP4", "HTV");
                htv = htv.Replace(".mp4",".htv");
                htvlist.Add(htv);
                foreach (var suz in kumushuz) {
                    if (item.IndexOf(suz)>-1) {
                        kemulist.Add(suz);
                        break;
                    }
                }
                string name = item.Substring(item.LastIndexOf("\\") + 1, item.Length - 1 - item.LastIndexOf("\\"));
                name = name.Replace(".mp4","");
                namelist.Add(name);
            }
            for (int i = 0; i < mp4list.Count; i++) {
                string sql = string.Format("insert into test values('{0}','{1}','{2}','{3}')", mp4list[i], htvlist[i], namelist[i], kemulist[i]);
                cmd.CommandText = sql;
                int jg = cmd.ExecuteNonQuery();
            }
        }
    }
}