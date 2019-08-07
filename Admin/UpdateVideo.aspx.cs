using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Data;
using Webz.Herp;
using System.IO;
using System.Text.RegularExpressions;

namespace Webz.Admin {
    public partial class UpdateVideo : System.Web.UI.Page {
        private string GrName = "";
        private string  SuName = "";
        private string sem = string.Empty;
        private string CaName = string.Empty;
        private int Study = 0;
        private bool mp4 = false;
        private bool htv = false;
        private bool quanbu = true;
        public int page = 1;
        public int Maxpage = 0;
        protected void Page_Load(object sender, EventArgs e) {
                DataTable dt = new DataTable();
                string id = Request.QueryString["page"];
                if (id == null) {
                    id = "1";
                }
                int ys = int.Parse(id);
                int ts = 30;
                ys = ys - 1;
                ys = ys * ts;
                dt = Select(ts, ys);
                BLL.BooksCatalogBLL bll = new BLL.BooksCatalogBLL();
                Repeater1.DataSource = dt;
                Repeater1.DataBind();
                Maxpage = bll.selectsum(GrName, SuName, CaName, mp4, htv, quanbu);
        }

        protected void Button1_Click(object sender, EventArgs e) {
            string id = Request.QueryString["page"];
            if (id == null) {
                id = "1";
            }
            int ys = int.Parse(id);
            int ts = 30;
            ys = ys - 1;
            ys = ys * ts;
            pipei(ts, ys);
        }
        protected void Button3_Click(object sender, EventArgs e) {
            DataTable dt = new DataTable();
            string GrName = Tnianji.Value;
            string SuName = TSuName.Value;
            string CaName = TxtName.Value;
            string id = Request.QueryString["page"];
            if (id == null) {
                id = "1";
            }
            bool mp4 = CheckBox1.Checked;
            bool htv = CheckBox2.Checked;
            bool quanbu = CheckBox3.Checked;
            int ys = int.Parse(id);
            int ts = 30;
            ys = ys - 1;
            ys = ys * ts;
            Session["GrName"] = GrName;
            Session["SuName"] = SuName;
            Session["CaName"] = CaName;
            Session["mp4"] = mp4.ToString();
            Session["htv"] = htv.ToString();
            Session["quanbu"] = quanbu.ToString();
            BLL.BooksCatalogBLL bll = new BLL.BooksCatalogBLL();
            dt = bll.select(ts, ys, GrName, SuName,  CaName,PrName, mp4, htv, quanbu);
            Repeater1.DataSource = dt;
            Repeater1.DataBind();
            Maxpage = bll.selectsum(GrName, SuName, CaName, PrName, mp4, htv, quanbu);
        }

        protected void Button2_Click(object sender, EventArgs e) {
            int index = 0;
            int last = 0;
            try {
                index = Convert.ToInt32(TxtIndex.Text);
                last = Convert.ToInt32(Txtlast.Text);
            } catch (Exception ex) {
                Response.Write(" <script type=\"text/javascript\"> alert(\"输入数字" + ex + " \");</script>");
            }
            int ys = (index - 1) * 30;
            int ts = ((last - 1) * 30) - ys;
            if (Session["GrName"] != null) {
                GrName = Session["GrName"].ToString();
            }
            if (Session["SuName"] != null) {
                SuName = Session["SuName"].ToString();
            }
            if (Session["sem"] != null) {
                sem = Session["sem"].ToString();
            }
            if (Session["CaName"] != null) {
                CaName = Session["CaName"].ToString();
            }
            if (Session["Study"] != null) {
                Study = Convert.ToInt32(Session["Study"]);
            }
            if (Session["mp4"] != null) {
                mp4 = Convert.ToBoolean(Session["mp4"]);
            }
            if (Session["htv"] != null) {
                htv = Convert.ToBoolean(Session["htv"]);
            }
            if (Session["quanbu"] != null) {
                htv = Convert.ToBoolean(Session["quanbu"]);
            }
            //weituo wt = new weituo(pipei); 
            
           //wt.Invoke(ts, ys, GrName, PrName, sem, CaName, Study, mp4, htv);

            pipei(ts, ys, GrName, SuName, CaName,  mp4, htv, quanbu);
            //Response.Write(" <script type=\"text/javascript\"> alert(\"成功" + hs + " \");</script>");
        }
        private delegate void weituo(int ts, int ys, string GrName, string SuName, string CaName, bool mp4, bool htv, bool quanbu);
        public void pipei(int ts, int ys,string GrName, string SuName, string CaName,  bool mp4, bool htv, bool quanbu) {
            
            string pathhtv = @"http://183.60.136.8:188/HTV/";
            string pathmp4 = @"http://183.60.136.8:188/mp4/";
            DataTable dt = new DataTable();
          
            BLL.BooksCatalogBLL bll = new BLL.BooksCatalogBLL();
            BLL.VideoRouteBLL robll = new BLL.VideoRouteBLL();

            dt = bll.select(ts, ys, GrName, SuName, CaName, PrName, mp4, htv, quanbu);
            int hs = 0;
            for (int i = 0; i < dt.Rows.Count; i++) {
                string xueqi = string.Empty;
                string Htvpath = string.Empty;
                string mp4path = string.Empty;
                if (Convert.ToInt32(dt.Rows[i]["study"]) == 2) {
                    xueqi = "初中";
                } else if (Convert.ToInt32(dt.Rows[i]["study"]) == 3) {
                    xueqi = "高中";
                } else if (Convert.ToInt32(dt.Rows[i]["study"]) == 1) {
                    xueqi = "小学";
                }
                if (xueqi == "高中") {
                    Htvpath = pathhtv + xueqi + "/" + dt.Rows[i]["suname"] + "/" + dt.Rows[i]["Semester"] + "/" + dt.Rows[i]["caname"] + ".htv";
                } else {
                    Htvpath = pathhtv + xueqi + "/" + dt.Rows[i]["GrName"].ToString().Trim() + "/" + dt.Rows[i]["suname"] + "/" + dt.Rows[i]["Semester"] + "/" + dt.Rows[i]["caname"] + ".htv";
                }
                if (!VideoHrep.yanzhen(Htvpath)) {
                    Htvpath = "";
                }
                if (xueqi == "高中") {
                    mp4path = pathmp4 + xueqi + "/" + dt.Rows[i]["suname"] + "/" + dt.Rows[i]["Semester"] + "/" + dt.Rows[i]["caname"] + ".mp4";
                } else {
                    mp4path = pathmp4 + xueqi + "/" + dt.Rows[i]["GrName"].ToString().Trim() + "/" + dt.Rows[i]["suname"] + "/" + dt.Rows[i]["Semester"] + "/" + dt.Rows[i]["caname"] + ".mp4";
                }

                if (!VideoHrep.yanzhen(mp4path)) {
                    mp4path = "";
                }
              
                if (dt.Rows[i]["viid"] == null && Htvpath == "" && mp4path == "") {
                    break;
                } else if (dt.Rows[i]["viid"] != null && Htvpath != "" || mp4path != "") {
                    string FileName = string.Empty;
                    if (dt.Rows[i]["viid"] != null) {
                        List<Model.VideoRoute> calist = robll.SelectByViid(Convert.ToInt32(dt.Rows[i]["viid"]));
                        bool cf = false;  //检查是否重复
                        if (Htvpath != "") {
                            FileName = Path.GetFileNameWithoutExtension(Htvpath);
                        }
                        if (mp4path != "") {
                            FileName = Path.GetFileNameWithoutExtension(mp4path);
                        }
                        if (calist.Count == 0) {
                            cf = true;
                        } else {
                            foreach (var item in calist) {
                                if (item.RouteAress == Htvpath && item.Mp4 == mp4path && item.ViName == FileName) {

                                } else {
                                    cf = true;
                                }
                            }
                        }
                        if (cf) {
                            if (robll.insert(Htvpath, mp4path, Convert.ToInt32(dt.Rows[i]["viid"]), FileName)) {
                                hs++;
                            }
                        }

                    }
                }

            }
            Response.Write(" <script type=\"text/javascript\"> alert(\"成功" + hs + " \");</script>");
        }
        public void pipei(int ts,int ys) {
            string pathhtv = @"http://183.60.136.8:188/HTV/";
            string pathmp4 = @"http://183.60.136.8:188/mp4/";
            DataTable dt = new DataTable();
            if (Session["GrName"] != null) {
                GrName = Session["GrName"].ToString();
            }
            if (Session["SuName"] != null) {
                SuName = Session["SuName"].ToString();
            }
            if (Session["sem"] != null) {
                sem = Session["sem"].ToString();
            }
            if (Session["CaName"] != null) {
                CaName = Session["CaName"].ToString();
            }
            if (Session["Study"] != null) {
                Study = Convert.ToInt32(Session["Study"]);
            }
            if (Session["mp4"] != null) {
                mp4 = Convert.ToBoolean(Session["mp4"]);
            }
            if (Session["htv"] != null) {
                htv = Convert.ToBoolean(Session["htv"]);
            }
            BLL.BooksCatalogBLL bll = new BLL.BooksCatalogBLL();
            BLL.VideoRouteBLL robll = new BLL.VideoRouteBLL();
            dt = bll.select(ts, ys, GrName, SuName, CaName, PrName, mp4, htv, quanbu);
            int hs = 0;
            for (int i = 0; i < dt.Rows.Count; i++) {
                string xueqi = string.Empty;
                string Htvpath = string.Empty;
                string mp4path = string.Empty;
                if (Convert.ToInt32(dt.Rows[i]["study"]) == 2) {
                    xueqi = "初中";
                } else if (Convert.ToInt32(dt.Rows[i]["study"]) == 3) {
                    xueqi = "高中";
                } else if (Convert.ToInt32(dt.Rows[i]["study"]) == 1) {
                    xueqi = "小学";
                }
                if (xueqi == "高中") {
                    Htvpath = pathhtv + xueqi + "/" + dt.Rows[i]["suname"] + "/" + dt.Rows[i]["Semester"] + "/" + dt.Rows[i]["caname"] + ".htv";
                } else {
                    Htvpath = pathhtv + xueqi + "/" + dt.Rows[i]["GrName"].ToString().Trim() + "/" + dt.Rows[i]["suname"] + "/" + dt.Rows[i]["Semester"] + "/" + dt.Rows[i]["caname"] + ".htv";
                }
                if (!VideoHrep.yanzhen(Htvpath)) {
                    Htvpath = "";
                }
                if (xueqi == "高中") {
                    mp4path = pathmp4 + xueqi + "/" + dt.Rows[i]["suname"] + "/" + dt.Rows[i]["Semester"] + "/" + dt.Rows[i]["caname"] + ".mp4";
                } else {
                    mp4path = pathmp4 + xueqi + "/" + dt.Rows[i]["GrName"].ToString().Trim() + "/" + dt.Rows[i]["suname"] + "/" + dt.Rows[i]["Semester"] + "/" + dt.Rows[i]["caname"] + ".mp4";
                }

                if (!VideoHrep.yanzhen(mp4path)) {
                    mp4path = "";
                }


                
                if (dt.Rows[i]["viid"] == null && Htvpath == "" && mp4path == "") {
                    break;
                } else if (dt.Rows[i]["viid"] != null && Htvpath != "" || mp4path != "") {
                    string FileName = string.Empty;
                    if (dt.Rows[i]["viid"] != null) {
                        List<Model.VideoRoute> calist = robll.SelectByViid(Convert.ToInt32(dt.Rows[i]["viid"]));
                        bool cf = false;  //检查是否重复
                        if (Htvpath != "") {
                            FileName = Path.GetFileNameWithoutExtension(Htvpath);
                        }
                        if (mp4path != "") {
                            FileName = Path.GetFileNameWithoutExtension(mp4path);
                        }
                        foreach (var item in calist) {
                            if (item.RouteAress == Htvpath && item.Mp4 == mp4path && item.ViName == FileName) {

                            } else {
                                cf = true;
                            }
                        }
                        if (cf) {
                            if (robll.insert(Htvpath, mp4path, Convert.ToInt32(dt.Rows[i]["viid"]), FileName)) {
                                hs++;
                            }
                        }
                        
                    }
                }

            }
            Response.Write(" <script type=\"text/javascript\"> alert(\"成功" + hs + " \");</script>");
        }
        private DataTable Select(int ts,int ys) {
            DataTable dt = new DataTable();
            if (Session["GrName"] != null) {
                GrName = Session["GrName"].ToString();
            }
            if (Session["SuName"] != null) {
                SuName = Session["SuName"].ToString();
            }
            if (Session["CaName"] != null) {
                CaName = Session["CaName"].ToString();
            }
            if (Session["mp4"] != null) {
                mp4 = Convert.ToBoolean(Session["mp4"]);
            }
            if (Session["htv"] != null) {
                htv = Convert.ToBoolean(Session["htv"]);
            }
            if (Session["quanbu"] != null) {
                htv = Convert.ToBoolean(Session["quanbu"]);
            }
            BLL.BooksCatalogBLL bll = new BLL.BooksCatalogBLL();
            dt = bll.select(ts, ys, GrName, SuName, CaName, PrName, mp4, htv, quanbu);
            return dt;
        }

        protected void Button4_Click(object sender, EventArgs e) {
            DataTable dt = new DataTable();
            string id = Request.QueryString["page"];
            if (id == null) {
                id = "1";
            }
           
            int ys = int.Parse(id);
            int ts = 30;
            ys = ys - 1;
            ys = ys * ts;
            dt = Select(ts, ys);
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
        protected void Button5_Click(object sender, EventArgs e) {
            int index = 0;
            int last = 0;
            try {
                index = Convert.ToInt32(TxtIndex.Text);
                last = Convert.ToInt32(Txtlast.Text);
            } catch (Exception ex) {
                Response.Write(" <script type=\"text/javascript\"> alert(\"输入数字" + ex + " \");</script>");
            }
            int ys = (index - 1) * 30;
            int ts = ((last - 1) * 30) - ys;
            CreateExcel(Select(ts, ys), "application/ms-excel", "Excel" + DateTime.Now.ToString("yyyy-MM-dd HHmmss") + ".xls");//调用函数 
        }

        protected void ButPage_Click(object sender, EventArgs e) {

        }
       
       
    }
}
