using System;
using System.Collections.Generic;
using System.Data;
using System.Data.OleDb;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Data.SqlClient;
using System.Reflection;
using System.Text.RegularExpressions;


namespace Webz.Admin {
    public partial class Index : System.Web.UI.Page {
        private DataTable dt = new DataTable();
        protected void Page_Load(object sender, EventArgs e) {
            //session过期提示重新登录
            if (base.Session["username"] == null || base.Session["username"].ToString().Equals(""))
            {
                Page.ClientScript.RegisterStartupScript(this.GetType(), "提示信息", "alert('账号已过期，请重新登录！');window.top.location.href='Login.aspx'", true);
            }
            base.OnInit(e);
        }
        public void InsertTableVideoAll() {
            BLL.BooksCatalogBLL CaBLL = new BLL.BooksCatalogBLL ();
            dt = CaBLL.SelectAll();
            CreateExcel(dt, "application/ms-excel", "Excel" + DateTime.Now.ToString("yyyy-MM-dd HHmmss") + ".xls");//调用函数  
        }
        public void InsertDataTable() {
            BLL.VideoRouteBLL ViRoBLL = new BLL.VideoRouteBLL ();
            BLL.BooksCatalogBLL CaBLL = new BLL.BooksCatalogBLL ();
            dt = ViRoBLL.Daochu();
            
            CreateExcel(dt, "application/ms-excel", "Excel" + DateTime.Now.ToString("yyyy-MM-dd HHmmss") + ".xls");//调用函数  
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
            for (int j = 0;j < dt.Columns.Count; j++) {
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

        protected void Button1_Click(object sender, EventArgs e) {
            InsertDataTable();
        }

        protected void Button2_Click(object sender, EventArgs e) {
            Response.Write(" <script type=\"text/javascript\">  window.location.href =\"ImgList.aspx\"</script>");
        }

        protected void Button3_Click(object sender, EventArgs e) {
            Response.Write(" <script type=\"text/javascript\">  window.location.href =\"../Test.aspx\"</script>");
        }

        protected void Button4_Click(object sender, EventArgs e) {
            Response.Write(" <script type=\"text/javascript\">window.location = \"BooksImg.aspx\";</script>");
        }

        protected void Button5_Click(object sender, EventArgs e) {
            //InsertTableVideoAll();
              List<string> aa = new List<string>();
              DataTable td = new DataTable();
             aa= duquAll();
             SqlConnection conn = new SqlConnection(DBHerp.SQL.connstr);
             conn.Open();
             SqlCommand cmd = new SqlCommand();
             cmd.Connection = conn;
             foreach (var item in aa) {
                 string sql = string.Empty;
                 if (item.IndexOf('\'') != -1) {
                     string it = item.Replace("'", "''");
                      sql = string.Format("insert into test values ('{0}')", it);
                 } else {
                      sql = string.Format("insert into test values ('{0}')", item);
                 }
                
                 cmd.CommandText = sql;
                 cmd.ExecuteNonQuery();
             }
             if (conn != null) {
                 conn.Close();
                 conn.Dispose();
             }
             
              //td = ToDataTable(aa);
              //CreateExcel(td, "application/ms-excel", "Excel" + DateTime.Now.ToString("yyyy-MM-dd HHmmss") + ".xls");//调用函数  
        }

        protected void Button6_Click(object sender, EventArgs e) {
            Response.Write(" <script type=\"text/javascript\">window.location = \"SelectVideo.aspx\";</script>");
        }

        protected void Button7_Click(object sender, EventArgs e) {
            Response.Write(" <script type=\"text/javascript\">window.location = \"CardADD.aspx\";</script>");
        }

        protected void Button8_Click(object sender, EventArgs e) {
            Response.Write(" <script type=\"text/javascript\">window.location = \"UpdateVideo.aspx\";</script>");
        }
        private DataTable ToDataTable<T>(List<T> items) {
            var tb = new DataTable(typeof(T).Name);

            PropertyInfo[] props = typeof(T).GetProperties(BindingFlags.Public | BindingFlags.Instance);

            foreach (PropertyInfo prop in props) {
                Type t = GetCoreType(prop.PropertyType);
                tb.Columns.Add(prop.Name, t);
            }

            foreach (T item in items) {
                var values = new object[props.Length];

                for (int i = 0; i < props.Length; i++) {
                    values[i] = props[i].GetValue(item, null);
                }

                tb.Rows.Add(values);
            }

            return tb;
        }
        public static Type GetCoreType(Type t) {
            if (t != null && IsNullable(t)) {
                if (!t.IsValueType) {
                    return t;
                } else {
                    return Nullable.GetUnderlyingType(t);
                }
            } else {
                return t;
            }
        }
        public static bool IsNullable(Type t) {
            return !t.IsValueType || (t.IsGenericType && t.GetGenericTypeDefinition() == typeof(Nullable<>));
        }
        public List<string> duquAll() {
            List<string> aa = new List<string>();
            string Mp4path = "MP4\\";
            //List<string> mp4 = new List<string>(FTP.GetFileList("", Mp4path));
            List<string> wenjianjia = FTP.GetDirctory(Mp4path);
            string[] mp4 = FTP.GetFilesDetailList(Mp4path);
            Regex regex = new Regex(@" *([01]\d|2[01234]):([0-5]\d|60) *", RegexOptions.IgnoreCase);
            foreach (var item in mp4) {
                //string ab = item.Substring(item.LastIndexOf(@"\d ") + 1);
                Match mc = regex.Match(item);
                string ab = mc.Groups[2].Value;
                ab = item.Substring(item.LastIndexOf(ab) + 3);
                if (ab.IndexOf('.') ==-1) {
                    string[] CaName = FTP.GetFilesDetailList(Mp4path + ab + "\\");
                    foreach (var it in CaName) {
                        //string ad = it.Substring(it.LastIndexOf(@"\d ") + 1);
                        Match mad = regex.Match(it);
                        string ad = mad.Groups[2].Value;
                        ad = it.Substring(it.LastIndexOf(ad) + 3);
                        if (ad.IndexOf('.') ==-1) {
                            string[] SuName = FTP.GetFilesDetailList(Mp4path + ab + "\\" + ad + "\\");
                            foreach (var ite in SuName) {
                                // string adq = ite.Substring(ite.LastIndexOf(@"\d ") + 1);
                                Match madq = regex.Match(ite);
                                string adq = madq.Groups[2].Value;
                                adq = ite.Substring(ite.LastIndexOf(adq) + 3);
                                if (adq.IndexOf('.') ==-1) {
                                    string[] Sem = FTP.GetFilesDetailList(Mp4path + ab + "\\" + ad + "\\" + adq + "\\");
                                    foreach (var itec in Sem) {
                                        //string adqw = itec.Substring(itec.LastIndexOf(' ') + 1);
                                        Match madqw = regex.Match(itec);
                                        string adqw = madqw.Groups[2].Value;
                                        adqw = itec.Substring(itec.LastIndexOf(adqw) + 3);
                                        if (adqw.IndexOf('.') ==-1) {
                                            string[] VideoName;
                                            VideoName = FTP.GetFilesDetailList(Mp4path + ab + "\\" + ad + "\\" + adq + "\\" + adqw + "\\");
                                            HttpRuntime.Cache.Insert("CaCheVideo", VideoName, null, DateTime.MaxValue, TimeSpan.FromSeconds(2000));
                                            foreach (var itecd in VideoName) {
                                                Match madqwe = regex.Match(itecd);
                                                string adqwe = madqwe.Groups[2].Value;
                                                adqwe = itecd.Substring(itecd.LastIndexOf(adqwe) + 3);
                                                if (adqwe.IndexOf('.') ==-1) {
                                                    aa.Add(Mp4path + ab + "\\" + ad + "\\" + adq + "\\" + adqw + "\\" + adqwe);
                                                } else {
                                                    aa.Add(Mp4path + ab + "\\" + ad + "\\" + adq + "\\" + adqw + "\\" + adqwe);
                                                }
                                            }
                                        } else {
                                            aa.Add(Mp4path + ab + "\\" + ad + "\\" + adq + "\\" + adqw);
                                        }
                                    }
                                } else {
                                    aa.Add(Mp4path + ab + "\\" + ad + "\\" + adq);
                                }
                            }
                        }
                    }
                }
            }
            HttpRuntime.Cache.Insert("aa", aa, null, DateTime.MaxValue, TimeSpan.FromSeconds(2000));
            return aa;
        }

        protected void Button9_Click(object sender, EventArgs e) {
            BLL.TestBLL TeBll = new BLL.TestBLL();
            List<Model.Test> TeList = TeBll.Select();
            SqlConnection conn = new SqlConnection(DBHerp.SQL.connstr);
            conn.Open();
            SqlCommand cmd = new SqlCommand();
            cmd.Connection = conn;
            int jg = 0;
            try {
                foreach (var item in TeList) {
                        string Name = item.MP4.Substring(item.MP4.LastIndexOf("\\") + 1, (item.MP4.LastIndexOf(".") - item.MP4.LastIndexOf("\\") - 1));
                        Name = Name.Replace("'", "''");
                        string Htv = item.MP4.Replace("MP4", "HTV");
                        Htv = Htv.Replace("mp4", "htv");
                        Htv = Htv.Replace("'", "''");
                        string sql = string.Format("update test set name='{0}',htv='{1}' where id='{2}'", Name, Htv, item.TestID);
                        cmd.CommandText = sql;
                        jg += cmd.ExecuteNonQuery();
                }
            } catch (Exception ex) {

            } finally {
                if (conn != null) {
                    conn.Close();
                    conn.Dispose();
                }
                
            }
            
        }

        protected void Button10_Click(object sender, EventArgs e) {
            BLL.TestBLL TeBll = new BLL.TestBLL();
            List<Model.Test> TeList = TeBll.Select();
            SqlConnection conn = new SqlConnection(DBHerp.SQL.connstr);
            conn.Open();
            SqlCommand cmd = new SqlCommand();
            cmd.Connection = conn;
            int jg = 0;
            try {
                foreach (var item in TeList) {
                    string name = string.Empty;
                    if (item.MP4.IndexOf("语文")!=-1) {
                        name = "语文";
                    }
                    if (item.MP4.IndexOf("数学") !=-1) {
                        name = "数学";
                    }
                    if (item.MP4.IndexOf("英语") !=-1) {
                        name = "英语";
                    }
                    if (item.MP4.IndexOf("物理")!=-1) {
                        name = "物理";
                    }
                    if (item.MP4.IndexOf("化学")!=-1) {
                        name = "化学";
                    }
                    if (item.MP4.IndexOf("生物") !=-1) {
                        name = "生物";
                    }
                    if (item.MP4.IndexOf("政治") !=-1) {
                        name = "政治";
                    }
                    if (item.MP4.IndexOf("历史") !=-1) {
                        name = "历史";
                    }
                    if (item.MP4.IndexOf("地理") !=-1) {
                        name = "地理";
                    }
                    string sql = string.Format("update test set kemu='{0}' where id='{1}'", name,item.TestID);
                    cmd.CommandText = sql;
                    jg += cmd.ExecuteNonQuery();
                }
            } catch (Exception ex) {

            } finally {
                if (conn != null) {
                    conn.Close();
                    conn.Dispose();
                }

            }
        }
    }
}
