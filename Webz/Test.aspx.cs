using System;
using System.Collections.Generic;
using System.Data;
using System.Data.OleDb;
using System.Linq;
using System.IO;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Data.SqlClient;
using System.Threading;
using Webz.Admin;

namespace Webz {
    public partial class Test : System.Web.UI.Page {
        string hostcs = Util.GetConfig("CourseHost");
        public string[] files;
        private DataTable dt_data = new DataTable();
       // string path = @"D:\WebSites\Test\Test\Upload\";
       // string path = @"D:\WebSites\DotnetTest\Upload\";
        string path = @"D:\WebSite\DotnetTest\Upload\";
        bool Books;
        bool Video;
        int leiji;
        //public string jindu = string.Empty;
        protected void Page_Load(object sender, EventArgs e) {
            if (!IsPostBack) {
                files = Directory.GetFiles(path, "*.xls");
                string fileName = string.Empty;
                for (int i = 0; i < files.Length; i++) {
                    fileName = System.IO.Path.GetFileName(files[i]);
                    seleid.Items.Add(fileName);
                }
            }
        }
        #region 导入课本按钮
        protected void Button1_Click(object sender, EventArgs e) {
            if (seleid.Value == "----请选择要导入的文件----") {
                Response.Write(" <script type=\"text/javascript\"> alert(\"请选择课件，如果没有请先上传！\");</script>");
                return;
            }
            SqlConnection conn = new SqlConnection(DBHerp.SQL.connstr);
            conn.Open();
            //SqlTransaction myTrans;
            SqlCommand cmd = new SqlCommand();
            cmd.Connection = conn;
            //myTrans = conn.BeginTransaction();
            //cmd.Transaction = myTrans;
            List<string> sqlList = daorukeben();
            try {
                for (int i = 0; i < sqlList.Count; i++)
			{
                cmd.CommandText = sqlList[i];
                int r = cmd.ExecuteNonQuery();
			}
              
            } catch (Exception ex) {
                Response.Write("<script type=\"text/javascript\"> alert(\"" + ex + "！\");</script>");
            } finally {
                if (conn != null) {
                    conn.Close();
                    conn.Dispose();
                }
            }
            Response.Write(" <script type=\"text/javascript\"> alert(\"成功！\");</script>");

        }
        public List<string> daorukeben() {
            string filero = path + seleid.Value;
            string strConn = string.Format("Provider=Microsoft.Jet.OLEDB.4.0;Data Source={0};Extended Properties='Excel 8.0;HDR=Yes;IMEX=1;'", filero);
            OleDbConnection objConn = new OleDbConnection(strConn);
            OleDbCommand objCmd = new OleDbCommand("SELECT * FROM [Sheet1$]", objConn);
            OleDbDataAdapter objDA = new OleDbDataAdapter(objCmd);
            objDA.Fill(dt_data);
            dt_data.Columns.Add("prod_ids", typeof(string));
            dt_data.Columns.Add("publish_ids", typeof(string));
            dt_data.Columns.Add("file_size", typeof(string));
            dt_data.Columns.Add("course_ware_no", typeof(string));
            int i;
             List<string> sqllist = new List<string>();
            for (i = 0; i < dt_data.Rows.Count; i++) {
                DataRow dr = dt_data.Rows[i];
                int iii = i + 1;
                string ISBN = dr["ISBN"].ToString().Trim();
                string GrName = dr["年级"].ToString().Trim();
                string PrName = dr["出版社"].ToString().Trim();
                string BooksName = dr["课本名称"].ToString().Trim();
                string SuName = dr["科目"].ToString().Trim();
                string Sestr = dr["学期"].ToString().Trim();
                string Ststr = dr["学段"].ToString().Trim();
                string Img = dr["图片路径"].ToString().Trim();
                string Ystr = dr["年份版本"].ToString().Trim();

                if (string.IsNullOrEmpty(ISBN)) {
                    Response.Write(" <script type=\"text/javascript\"> alert(\"第" + iii + "行ISBN为空 \");</script>");
                    break;
                }
                if (string.IsNullOrEmpty(PrName)) {
                    Response.Write(" <script type=\"text/javascript\"> alert(\"第" + iii + "行出版社为空 \");</script>");
                    break;
                }
                if (string.IsNullOrEmpty(BooksName)) {
                    Response.Write(" <script type=\"text/javascript\"> alert(\"第" + iii + "行课本为空 \");</script>");
                    break;
                }
                if (string.IsNullOrEmpty(Sestr)) {
                    if (Ststr != "高中") {
                        Response.Write(" <script type=\"text/javascript\"> alert(\"第" + iii + "行学期为空 \");</script>");
                        break;
                    } else {
                        Sestr = "";
                    }

                } if (string.IsNullOrEmpty(Ststr)) {
                    Response.Write(" <script type=\"text/javascript\"> alert(\"第" + iii + "行学段为空 \");</script>");
                    break;
                }
                if (string.IsNullOrEmpty(GrName)) {
                    if (Ststr != "高中") {
                        Response.Write(" <script type=\"text/javascript\"> alert(\"第" + iii + "行年级为空 \");</script>");
                        break;
                    } else {
                        GrName = "";
                    }

                }
                if (string.IsNullOrEmpty(Img)) {
                    Response.Write(" <script type=\"text/javascript\"> alert(\"第" + iii + "行图片路径为空 \");</script>");
                    break;
                }
                if (string.IsNullOrEmpty(Ystr)) {
                    Response.Write(" <script type=\"text/javascript\"> alert(\"第" + iii + "行年份版本为空 \");</script>");
                    break;
                }
                int Study;
                Ystr = Ystr.Replace("版", "");
                int Year = Convert.ToInt32(Ystr);

                if (Ststr == "小学") {
                    Study = 1;
                } else if (Ststr == "初中") {
                    Study = 2;
                } else if (Ststr == "高中") {
                    Study = 3;
                } else {
                    Response.Write(" <script type=\"text/javascript\"> alert(\"请检查第" + iii + "行学段输入是否规范！ \");</script>");
                    break;
                }
                string duibi = @"..\Images\BooksImgs\";
                if (!DbImg.ImgTest(duibi.Replace("..\\", ""), Img)) {
                    Response.Write(" <script type=\"text/javascript\"> alert(\"第" + iii + "行图片路径不存在！ \");</script>");
                    break;
                }
                //Response.Write(" <script type=\"text/javascript\"> alert(\"123 " + dr["科目"].ToString().Trim() + "  \");</script>");
                string strsql = "EXEC proc_add '{0}','{1}','{2}','{3}','{4}','{5}','{6}','{7}','{8}'";
                string sql = string.Format(strsql, ISBN, GrName, PrName, BooksName, SuName, Sestr, Study, Img, Year);
                //string sql = "delete [dbo].[Video]";
                sqllist.Add(sql);
                
            }
            return sqllist;
        }
        #endregion
        #region 导入目录按钮
        private Object thisLock = new Object();
        string Videopath = @"http://dl.icoxtech.com:88/名师高清视频/";
        public List<string> UrlList = new List<string>();
        protected void Button2_Click(object sender, EventArgs e) {
            if (seleid.Value == "----请选择要导入的文件----") {
                Response.Write("<script type=\"text/javascript\"> alert(\"请选择课件，如果没有请先上传！\");</script>");
                return;
            }
            // E:/dl_null Response.Write("<script type=\"text/javascript\"> alert(\"正在导入请不要关闭页面！\");</script>");
            int kj = 0;
            SqlConnection conn = new SqlConnection(DBHerp.SQL.connstr);
            conn.Open();
            SqlCommand cmd = new SqlCommand();
            cmd.Connection = conn;
            List<string> sqlList = daorumulu();
            try {
                foreach (string  sql in sqlList) {
                    //if (sql.IndexOf("Everyone had a good time.") > 0) {
                    //    cmd.CommandText = sql;
                    //    int k = cmd.ExecuteNonQuery();
                    //}
                    cmd.CommandText = sql;
                    int r = cmd.ExecuteNonQuery();
                }
            } catch(Exception ex) {
                Response.Write("<script type=\"text/javascript\"> alert(\""+ex+"！\");</script>");
                return;
            } finally {
                if (conn != null) {
                    conn.Close();
                    conn.Dispose();
                }
            }
                Response.Write("<script type=\"text/javascript\"> alert(\"导入成功！\");</script>");
        }
        #endregion
        #region 上传课件按钮
        protected void Button3_Click(object sender, EventArgs e) {
            string stri = FileUp.FileName;
            files = Directory.GetFiles(path, "*.xls");
            if (stri == "" || stri == null) {
                Response.Write(" <script type=\"text/javascript\"> alert(\"请选择课件！\");</script>");
                return;
            }
            string kuoz = System.IO.Path.GetExtension(stri);
            if (kuoz != ".xls") {
                Response.Write(" <script type=\"text/javascript\"> alert(\"请选择正确格式的文件！\");</script>");
                return;
            }
            string fileName = string.Empty;
            for (int i = 0; i < files.Length; i++) {
                fileName = System.IO.Path.GetFileName(files[i]);
                if (fileName == stri) {
                    Response.Write(" <script type=\"text/javascript\"> alert(\"已有该课件，请勿重复上传！\");</script>");
                    return;
                }
            }

            FileUp.PostedFile.SaveAs(Server.MapPath(@"\Upload\") + stri);
            //FileUp.PostedFile.SaveAs(Server.MapPath(path) + stri);
            seleid.Items.Add(stri);
            Response.Write(" <script type=\"text/javascript\"> alert(\"上传成功！\");</script>");

        }
        #endregion
        #region 课本检查按钮
        protected void Button4_Click(object sender, EventArgs e) {
            string filero = path + seleid.Value;
            if (seleid.Value == "----请选择要导入的文件----") {
                Response.Write(" <script type=\"text/javascript\"> alert(\"请选择课件，如果没有请先上传！\");</script>");
                return;
            }
            String strConn = "Provider = Microsoft.Jet.OLEDB.4.0 ;" +
                             "Data Source=" + filero + ";" +
                             "Extended Properties='Excel 8.0;'";
            OleDbConnection objConn = new OleDbConnection(strConn);
            OleDbCommand objCmd = new OleDbCommand("SELECT * FROM [Sheet1$]", objConn);
            OleDbDataAdapter objDA = new OleDbDataAdapter(objCmd);
            objDA.Fill(dt_data);
            dt_data.Columns.Add("prod_ids", typeof(string));
            dt_data.Columns.Add("publish_ids", typeof(string));
            dt_data.Columns.Add("file_size", typeof(string));
            dt_data.Columns.Add("course_ware_no", typeof(string));
            try {
                int i;
                for (i = 0; i < dt_data.Rows.Count; i++) {
                    DataRow dr = dt_data.Rows[i];
                    int iii = i + 1;
                    string ISBN = dr["ISBN"].ToString().Trim();
                    string GrName = dr["年级"].ToString().Trim();
                    string PrName = dr["出版社"].ToString().Trim();
                    string BooksName = dr["课本名称"].ToString().Trim();
                    string SuName = dr["科目"].ToString().Trim();
                    string Sestr = dr["学期"].ToString().Trim();
                    string Ststr = dr["学段"].ToString().Trim();
                    string Img = dr["图片路径"].ToString().Trim();
                    string Ystr = dr["年份版本"].ToString().Trim();
                    if (string.IsNullOrEmpty(ISBN)) {
                        Response.Write(" <script type=\"text/javascript\"> alert(\"第" + iii + "行ISBN为空 \");</script>");
                        return;
                    }
                    if (string.IsNullOrEmpty(PrName)) {
                        Response.Write(" <script type=\"text/javascript\"> alert(\"第" + iii + "行出版社为空 \");</script>");
                        return;
                    }
                    if (string.IsNullOrEmpty(BooksName)) {
                        Response.Write(" <script type=\"text/javascript\"> alert(\"第" + iii + "行课本为空 \");</script>");
                        return;
                    }
                    if (string.IsNullOrEmpty(Sestr)) {
                        if (Ststr != "高中") {
                            Response.Write(" <script type=\"text/javascript\"> alert(\"第" + iii + "行学期为空 \");</script>");
                            return;
                        } else {
                            Sestr = "";
                        }

                    } if (string.IsNullOrEmpty(Ststr)) {
                        Response.Write(" <script type=\"text/javascript\"> alert(\"第" + iii + "行学段为空 \");</script>");
                        return;
                    }
                    if (string.IsNullOrEmpty(GrName)) {
                        if (Ststr != "高中") {
                            Response.Write(" <script type=\"text/javascript\"> alert(\"第" + iii + "行年级为空 \");</script>");
                            return;
                        } else {
                            Ststr = "";
                        }

                    }
                }
                Books = true;
                Response.Write(" <script type=\"text/javascript\"> alert(\"该文件可以上传\");</script>");
            } catch (Exception ex) {
                Response.Write(" <script type=\"text/javascript\"> alert(\"该文件格式错误，请重新选择文件！\");</script>");
                Books = false;
            }



        }
        #endregion
        #region 目录检查按钮
        protected void Button5_Click(object sender, EventArgs e) {
            string filero = path + seleid.Value;
            if (seleid.Value == "----请选择要导入的文件----") {
                Response.Write(" <script type=\"text/javascript\"> alert(\"请选择课件，如果没有请先上传！\");</script>");
                return;
            }
            String strConn = "Provider = Microsoft.Jet.OLEDB.4.0 ;" +
                             "Data Source=" + filero + ";" +
                             "Extended Properties='Excel 8.0;'";
            OleDbConnection objConn = new OleDbConnection(strConn);
            OleDbCommand objCmd = new OleDbCommand("SELECT * FROM [Sheet1$]", objConn);
            OleDbDataAdapter objDA = new OleDbDataAdapter(objCmd);
            objDA.Fill(dt_data);
            dt_data.Columns.Add("prod_ids", typeof(string));
            dt_data.Columns.Add("publish_ids", typeof(string));
            dt_data.Columns.Add("file_size", typeof(string));
            dt_data.Columns.Add("course_ware_no", typeof(string));
            int i;
            try {
                for (i = 0; i < dt_data.Rows.Count; i++) {
                    int iii = 1 + i;
                    DataRow dr = dt_data.Rows[i];
                    string ISBN = dr["ISBN"].ToString().Trim();
                    string Yearstr = dr["年份版本"].ToString().Trim();
                    string caNum = dr["目录序号"].ToString().Trim();
                    string CaName = dr["单元目录"].ToString().Trim();
                    string Pagestr = dr["页码"].ToString().Trim();
                    string author = dr["作者"].ToString().Trim();
                    string State = dr["课文类型"].ToString().Trim();
                    string Text = dr["课文目录"].ToString().Trim();
                    string Texts = dr["子课文名称"].ToString().Trim();
                    int Year, Page;
                    if (string.IsNullOrEmpty(ISBN)) {
                        Response.Write(" <script type=\"text/javascript\"> alert(\"第" + iii + "行isbn为空 \");</script>");
                        break;
                    }
                    if (string.IsNullOrEmpty(Yearstr)) {
                        Response.Write(" <script type=\"text/javascript\"> alert(\"第" + iii + "行年份版本为空 \");</script>");
                        break;
                    }
                    if (string.IsNullOrEmpty(CaName)) {
                        Response.Write(" <script type=\"text/javascript\"> alert(\"第" + iii + "行单元目录为空 \");</script>");
                        break;
                    }
                    if (string.IsNullOrEmpty(Pagestr)) {
                        Page = 0;
                    } else {
                        Page = Convert.ToInt32(Pagestr);
                    }
                    if (string.IsNullOrEmpty(author)) {
                        author = "无";
                    }
                    if (string.IsNullOrEmpty(Text)) {
                        Response.Write(" <script type=\"text/javascript\"> alert(\"第" + iii + "行课文名称为空 \");</script>");
                        break;
                    }

                    ISBN = ISBN.Replace("ISBN", "");
                    Yearstr = Yearstr.Replace("版", "");
                    Year = Convert.ToInt32(Yearstr);
                }
                Video = true;
                Response.Write(" <script type=\"text/javascript\"> alert(\"该文件可以上传\");</script>");
            } catch (Exception ex) {
                Response.Write(" <script type=\"text/javascript\"> alert(\"该文件格式错误，请重新选择文件！\");</script>");
                Video = false;
            }

        }
        #endregion
        private delegate void weituo();
        private void  daoru() {
            string filero = path + seleid.Value;
            string strConn = string.Format("Provider=Microsoft.Jet.OLEDB.4.0;Data Source={0};Extended Properties='Excel 8.0;HDR=Yes;IMEX=1;'", filero);
            OleDbConnection objConn = new OleDbConnection(strConn);
            OleDbCommand objCmd = new OleDbCommand("SELECT * FROM [Sheet1$]", objConn);
            OleDbDataAdapter objDA = new OleDbDataAdapter(objCmd);
            objDA.Fill(dt_data);
            dt_data.Columns.Add("prod_ids", typeof(string));
            dt_data.Columns.Add("publish_ids", typeof(string));
            dt_data.Columns.Add("file_size", typeof(string));
            dt_data.Columns.Add("course_ware_no", typeof(string));
            SqlConnection conn = new SqlConnection(DBHerp.SQL.connstr);
            conn.Open();
            SqlCommand cmd = new SqlCommand();
            cmd.Connection = conn;
            int jg = 0;
            try {
                foreach (DataRow dr in dt_data.Rows) {
                    string ISBN = dr["isbn"].ToString().Trim();
                    string booksname = dr["booksname"].ToString().Trim();
                    string CaName = dr["caname"].ToString().Trim();
                    string viname = dr["viname"].ToString().Trim();
                    string viname1 = dr["viname1"].ToString().Trim();
                    string RouteAress = dr["RouteAress"].ToString().Trim();
                    string RouteAress1 = dr["RouteAress1"].ToString().Trim();
                    string RouteAress2 = dr["RouteAress2"].ToString().Trim();
                    string Mp4 = dr["Mp4"].ToString().Trim();
                    string Mp41 = dr["Mp41"].ToString().Trim();
                    string Mp42 = dr["Mp42"].ToString().Trim();
                    if (viname == "") {
                        continue;
                    }
                    if (RouteAress == "" && Mp4 == "") {
                        continue;
                    }
                    if (viname1 != "") {
                        viname = viname + viname1;
                    } if (RouteAress1 != "") {
                        RouteAress = RouteAress + RouteAress1;
                        if (RouteAress2 != "") {
                            RouteAress = RouteAress + RouteAress2;
                        }
                    }
                    if (Mp41 != "") {
                        Mp4 = Mp4 + Mp41;
                        if (Mp42 != "") {
                            Mp4 = Mp4 + Mp42;
                        }
                    }

                    string sql = string.Format("insert into  video values('{0}') select @@identity", CaName);
                    cmd.CommandText = sql;
                    int viid = Convert.ToInt32(cmd.ExecuteScalar());
                    if (viid == 0) {
                        continue;
                    }
                    sql = string.Format("select TextID from textbooks where isbn = '{0}' and BooksName = '{1}'", ISBN, booksname);
                    cmd.CommandText = sql;
                    int TextId = Convert.ToInt32(cmd.ExecuteScalar());
                    if (TextId == 0) { break; }
                    sql = string.Format("update [dbo].[BooksCatalog] set viid = '{0}' where CaName='{1}' and TextID='{2}'", viid, CaName, TextId);
                    cmd.CommandText = sql;
                    int Update = cmd.ExecuteNonQuery();
                    if (Update < 0) {
                        continue;
                    }
                    string[] Htv = RouteAress.Split('|');
                    string[] MP4 = Mp4.Split('|');
                    string[] ViName = viname.Split('|');
                    int jgs = 1;
                    for (int i = 1; i < ViName.Length; i++) {
                        if (ViName[i] == "第一次世界大战(8).mp4") {
                            sql = "";
                        }
                        if (Htv.Length > i && MP4.Length > i) {
                            sql = string.Format("insert into [dbo].[VideoRoute] values('{0}','{1}','{2}','{3}',1,1)", Htv[i], MP4[i], viid, ViName[i]);
                            cmd.CommandText = sql;
                            jgs += cmd.ExecuteNonQuery();
                        }

                    }

                    if (Update == ViName.Length) {
                        jg++;
                    }

                }
            } catch (Exception ex) {
                Response.Write(" <script type=\"text/javascript\"> alert(\"" + ex + "!!\");</script>");
            } finally {
                if (conn != null) {
                    conn.Close();
                    conn.Dispose();
                }
            }
            Response.Write(" <script type=\"text/javascript\"> alert(\"成功" + jg + "!!\");</script>");
            
        }
        public void daoruVideo() {
            SqlConnection conn = new SqlConnection(DBHerp.SQL.connstr);
            conn.Open();
            SqlTransaction myTrans;
            SqlCommand cmd = new SqlCommand();
            cmd.Connection = conn;
            myTrans = conn.BeginTransaction();
            cmd.Transaction = myTrans;
            foreach (string  url in UrlList) {
                    string FileName = url.Substring(url.LastIndexOf("/") + 1);
                    FileName = FileName.Replace(".htv","");
                    cmd.CommandText = string.Format("exec proc_addro '{0}','{1}'", FileName, url);
                    int jg = cmd.ExecuteNonQuery();
            }
            myTrans.Commit();
            if (conn != null) {
                conn.Close();
                conn.Dispose();
            }
            Response.Write("<script type=\"text/javascript\"> alert(\"导入视频成功！\");</script>");
        }
        private List<string> daorumulu() {
            string filero = path + seleid.Value;
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
            BLL.BooksCataLogBLL CaBLL = new BLL.BooksCataLogBLL();
            List<string> SqlList = new List<string>();
            int iii = 1;
                foreach (DataRow dr in dt_data.Rows) {
                    string ISBN = dr["ISBN"].ToString().Trim();
                    string Yearstr = dr["年份版本"].ToString().Trim();
                    string caNum = dr["目录序号"].ToString().Trim();
                    string CaName = dr["单元目录"].ToString().Trim();
                    string Pagestr = dr["页码"].ToString().Trim();
                    string author = dr["作者"].ToString().Trim();
                    string State = dr["课文类型"].ToString().Trim();
                    string Text = dr["课文目录"].ToString().Trim();
                    string Texts = dr["子课文名称"].ToString().Trim();
                    int Year, Page;
                    if (string.IsNullOrEmpty(ISBN)) {
                        Response.Write(" <script type=\"text/javascript\"> alert(\"第" + iii + "行isbn为空 \");</script>");
                        break;
                    }
                    if (string.IsNullOrEmpty(Yearstr)) {
                        Response.Write(" <script type=\"text/javascript\"> alert(\"第" + iii + "行年份版本为空 \");</script>");
                        break;
                    }
                    //if (string.IsNullOrEmpty(CaName)) {
                    //    Response.Write(" <script type=\"text/javascript\"> alert(\"第" + iii + "行单元目录为空 \");</script>");
                    //    break;
                    //}
                    if (string.IsNullOrEmpty(Pagestr)) {
                        Page = 0;
                    } else {
                        Page = Convert.ToInt32(Pagestr);
                    }
                    if (string.IsNullOrEmpty(author)) {
                        author = "无";
                    }
                    if (string.IsNullOrEmpty(Text)) {
                        Response.Write(" <script type=\"text/javascript\"> alert(\"第" + iii + "行课文名称为空 \");</script>");
                        break;
                    }

                    ISBN = ISBN.Replace("ISBN", "");
                    Yearstr = Yearstr.Replace("版", "");
                    Year = Convert.ToInt32(Yearstr);
                    string strsql = "EXEC proc_videoadd '{0}','{1}','{2}','{3}','{4}','{5}','{6}','{7}','{8}','{9}','{10}','{11}'";
                    string VideoName = Text + ".htv";
                    if (!string.IsNullOrEmpty(Texts)) {
                        VideoName = Texts + ".htv";
                    }
                    //Model.TextBooks MoText = BooksBLL.SelectByISBN(ISBN, Year);
                    //string VideoRo = string.Empty;
                    //if (MoText.Study == 1) {
                    //    VideoRo += "小学/";
                    //} else if (MoText.Study == 2) {
                    //    VideoRo += "初中/";
                    //} else {
                    //    VideoRo += "高中/";
                    //}
                    //if (MoText.Study != 3) {
                    //    VideoRo += GrBLL.SelectByGrid(MoText.Grid).GrName.Trim() + "/";
                    //    VideoRo += SuBLL.SelectBySuid(MoText.Suid).SuName.Trim() + "/";
                    //    VideoRo += MoText.Semester.Trim() + "/";
                    //} else {
                    //    VideoRo += SuBLL.SelectBySuid(MoText.Suid).SuName.Trim() + "/";
                    //    VideoRo += GrBLL.SelectByGrid(MoText.Grid).GrName.Trim() + "/";
                    //}
                    string RouteAresss = "";
                    //if (VideoHrep.yanzhen(Videopath + VideoRo+VideoName)) {
                    //    RouteAresss = Videopath + VideoRo + VideoName;
                    //}
                    string sql = string.Empty;
                    sql = string.Format(strsql, ISBN, Year, caNum, CaName, Page, author, State, System.IO.Path.GetFileNameWithoutExtension(RouteAresss), RouteAresss, Text, Texts, RouteAresss);
                    SqlList.Add(sql);
                    iii++;
                }
                return SqlList;
        }
        #region 删除按钮
        protected void Button6_Click(object sender, EventArgs e) {
            string stri = seleid.Value;
            files = Directory.GetFiles(path, "*.xls");
            File.Delete(path + stri);
            files = Directory.GetFiles(path, "*.xls");
            string fileName = string.Empty;
            for (int i = 0; i < files.Length; i++) {
                fileName = System.IO.Path.GetFileName(files[i]);
                if (fileName == stri) {
                    Response.Write("<script type=\"text/javascript\"> alert(\"删除失败！\");</script>");
                    return;
                }
            }
            seleid.Items.Remove(stri);
            Response.Write(" <script type=\"text/javascript\"> alert(\"删除成功！\");</script>");
            Response.Write(" <script type=\"text/javascript\">window.location = \"Test.aspx\";);</script>");
        }
        #endregion

        protected void Button7_Click(object sender, EventArgs e) {
            daoru();
        }

        protected void Button8_Click(object sender, EventArgs e) {
            string filero = path + seleid.Value;
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
            BLL.BooksCataLogBLL CaBLL = new BLL.BooksCataLogBLL();
            SqlConnection conn = new SqlConnection("server=182.254.134.51;database=Ejiaqin;uid=MDB;pwd=Main@JLF955icox;Pooling=true;");
            conn.Open();
            SqlCommand cmd = new SqlCommand();
            cmd.Connection = conn;
            List<string> SqlList = new List<string>();
            foreach (DataRow dr in dt_data.Rows) {
                 int Id =Convert.ToInt32( dr["Id"].ToString().Trim());
                 if (Id < 34665) {
                     continue;
                 }
                string OpenId = dr["OpenId"].ToString().Trim();
                string GUID = dr["GUID"].ToString().Trim();
                string License = dr["License"].ToString().Trim();
                string DevModel = dr["DevModel"].ToString().Trim();
                string CreateDate = dr["CreateDate"].ToString().Trim();
                string ActivateDate = dr["ActivateDate"].ToString().Trim();
                string sql = string.Format("update [dbo].[TencentUser] set OpenId='{0}',DevModel='{1}',activatedate='{2}' where id = '{3}'", OpenId, DevModel, ActivateDate, Id);
                SqlList.Add(sql);
            }
            foreach (var item in SqlList) {
                cmd.CommandText = item;
                cmd.ExecuteNonQuery();
            }
            if (conn != null) {
                conn.Close();
                conn.Dispose();
            }
            
        }

        protected void Button9_Click(object sender, EventArgs e) {
            string filero = path + seleid.Value;
            string strConn = string.Format("Provider=Microsoft.Jet.OLEDB.4.0;Data Source={0};Extended Properties='Excel 8.0;HDR=Yes;IMEX=1;'", filero);
            OleDbConnection objConn = new OleDbConnection(strConn);
            OleDbCommand objCmd = new OleDbCommand("SELECT * FROM [Sheet1$]", objConn);
            OleDbDataAdapter objDA = new OleDbDataAdapter(objCmd);
            objDA.Fill(dt_data);
            dt_data.Columns.Add("prod_ids", typeof(string));
            dt_data.Columns.Add("publish_ids", typeof(string));
            dt_data.Columns.Add("file_size", typeof(string));
            dt_data.Columns.Add("course_ware_no", typeof(string));
            SqlConnection conn = new SqlConnection("server=182.254.134.51;database=Ejiaqin;uid=MDB;pwd=Main@JLF955icox;Pooling=true;");
            conn.Open();
            SqlCommand cmd = new SqlCommand();
            cmd.Connection = conn;
            List<string> SqlList = new List<string>();
            foreach (DataRow dr in dt_data.Rows) {
                string OpenId = dr["OpenId"].ToString().Trim();
                string sql = string.Format("update  [dbo].[TencentUser]  set openid = '',DevModel='',ActivateDate='' where OpenId='{0}'", OpenId);
                SqlList.Add(sql);
            }
            foreach (var item in SqlList) {
                cmd.CommandText = item;
                cmd.ExecuteNonQuery();
            }
            if (conn != null) {
                conn.Close();
                conn.Dispose();
            }
        }
        #region 文件上传
        //protected void btn_Deal_Click(object sender, EventArgs e) {

        //    string batchFile = this.Request.Form["ddl_file"];
        //    ddl_file.SelectedValue = batchFile;  D:\WebSites\Test\Test\Upload\

        //    BusinessRules.CourseWare.CourseWareBatchBl bl = new BusinessRules.CourseWare.CourseWareBatchBl(batchFile);
        //    bl.str_err = hostcs;
        //    if (bl.CheckFileData()) {

        //        lbl_err.Text = "检查通过,程序正在处理目录文件：" + System.IO.Path.GetFileName(batchFile);

        //        GridView1.Visible = false;
        //        GridView2.Visible = true;
        //        BusinessRules.CourseWare.CourseWareBatchBl.ClearMessageShow();

        //        btn_Deal.Enabled = false;
        //        btn_check.Enabled = false;
        //        hidTimer.Enabled = true;
        //SqlConnection conn = new SqlConnection();
        //        bl.userid = Session["userid"].ToString();
        //        ThreadPool.QueueUserWorkItem(new WaitCallback(BusinessRules.CourseWare.CourseWareBatchBl.ThreadProc), bl);
        //        DataTable dt = BusinessRules.CourseWare.CourseWareBatchBl.GetMessageShow();
        //        GridView2.DataSource = dt;
        //        GridView2.DataBind();
        //    } else {
        //        lbl_err.Text = "课件批量上传目录文件: " + System.IO.Path.GetFileName(batchFile) + " 内容出错。";

        //        GridView1.Visible = true;
        //        GridView2.Visible = false;

        //        GridView1.DataSource = bl.Dt_Err;
        //        GridView1.DataBind();
        //    }
        //}
        #endregion
        #region 终止事件
        //protected void btend_Click(object sender, EventArgs e) {
        //    BusinessRules.CourseWare.CourseWareBatchBl.DelMessage();
        //    lbl_err.Text = "已终止上传";
        //    Response.Redirect("CourseWareBacth.aspx");
        //}
        #endregion
    }
}