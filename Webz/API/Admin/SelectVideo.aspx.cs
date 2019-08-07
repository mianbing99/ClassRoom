using System;
using System.Collections.Generic;
using System.Data;
using System.IO;
using System.Linq;
using System.Text.RegularExpressions;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Web.Caching;
using BLL;

namespace Webz.Admin
{
    public partial class SelectVideo : System.Web.UI.Page
    {
        //public string GrName = "";
        //public string SuName = "";
        //public string sem = string.Empty;
        //public string CaName = string.Empty;
        //public string PrName = string.Empty;
        //public int pages = 1;
        //public int Study = 0;
        //public bool mp4 = false;
        //public bool htv = false;
        //public bool quanbu = true;
        protected void Page_Load(object sender, EventArgs e)
        {
            //session过期提示重新登录
            if (base.Session["username"] == null || base.Session["username"].ToString().Equals(""))
            {
                Page.ClientScript.RegisterStartupScript(this.GetType(), "提示信息", "alert('账号已过期，请重新登录！');window.top.location.href='Login.aspx'", true);
            }
            base.OnInit(e);
            //if (!IsPostBack)
            //{
            //    PressBLL pb = new PressBLL();
            //    GradeBLL gb = new GradeBLL();
            //    SubjectBLL sb = new SubjectBLL();

            //    this.DropDownList2.DataSource = gb.selectgrade();
            //    this.DropDownList2.DataTextField = "GrName";
            //    this.DropDownList2.DataValueField = "Grid";
            //    this.DropDownList2.DataBind();
            //    DropDownList2.Items.Insert(0, new ListItem("请选择年级", "-1"));
            //    this.DropDownList3.DataSource = sb.SelectList();
            //    this.DropDownList3.DataTextField = "SuName";
            //    this.DropDownList3.DataValueField = "Suid";
            //    this.DropDownList3.DataBind();
            //    DropDownList3.Items.Insert(0, new ListItem("请选择课目", "-1"));
            //    this.DropDownList1.DataSource = pb.SelectList();
            //    this.DropDownList1.DataTextField = "PrName";
            //    this.DropDownList1.DataValueField = "prid";
            //    this.DropDownList1.DataBind();
            //    DropDownList1.Items.Insert(0, new ListItem("请选择出版社", "-1"));
            //    WSelects Se = new SelectVideo.WSelects(Selects);
            //    string[] Su = { "语文", "数学", "英语", "物理", "化学", "生物", "政治", "历史", "地理" };
            //    Session["SuName"] = "语文";
            //    foreach (var item in Su)
            //    {
            //        if (Session["Loadings"] != null)
            //        {
            //            string Loading = Session["Loadings"].ToString();
            //            if (Loading.IndexOf(item) < 0)
            //            {
            //                IAsyncResult res = Se.BeginInvoke(item, null, null);
            //                if (res.IsCompleted)
            //                {
            //                    Session["Loadings"] += item + "|";
            //                }
            //            }
            //        }
            //        else if (HttpRuntime.Cache.Get("语文all") != null)
            //        {
            //            Session["Loadings"] = "语文|";
            //        }
            //        else
            //        {
            //            Selects("语文");
            //        }

            //    }
            //    DataTable dt = new DataTable();
            //    string page = string.Empty;
            //    if (Request.QueryString["page"] == null)
            //    {
            //        if (page == "")
            //        {
            //            page = "1";
            //        }
            //    }
            //    else
            //    {
            //        page = Request.QueryString["page"];
            //    }
            //    int ys = int.Parse(page);
            //    pages = ys;
            //    int ts = 9;
            //    dt = Select(ts, ys);
            //    BLL.BooksCatalogBLL bll = new BLL.BooksCatalogBLL();
            //    Repeater1.DataSource = dt;
            //    Repeater1.DataBind();
            //    pgServer.RecordCount = pagecount();
            //    pgServer.PageSize = ts;
            //    pgServer.DataBind();
            //}
        }
        //    protected void Button3_Click(object sender, EventArgs e)
        //    {
        //        DataTable dt = new DataTable();
        //        string page = string.Empty;
        //        if (Request.QueryString["page"] == null)
        //        {
        //            if (page == "")
        //            {
        //                page = "1";
        //            }
        //        }
        //        else
        //        {
        //            page = Request.QueryString["page"];
        //        }
        //        CaName = TxtName.Value;
        //        GrName = DropDownList2.SelectedItem.Text;
        //        SuName = DropDownList3.SelectedItem.Text;
        //        PrName = DropDownList1.SelectedItem.Text;
        //        mp4 = CheckBox1.Checked;
        //        htv = CheckBox2.Checked;
        //        quanbu = CheckBox3.Checked;
        //        int ys = int.Parse(page);
        //        int ts = 9;
        //        ys = ys - 1;
        //        ys = ys * ts;
        //        Session["GrName"] = GrName;
        //        Session["SuName"] = SuName;
        //        Session["PrName"] = PrName;
        //        Session["CaName"] = CaName;
        //        Session["mp4"] = mp4.ToString();
        //        Session["htv"] = htv.ToString();
        //        Session["quanbu"] = quanbu.ToString();
        //        Response.Write(" <script type=\"text/javascript\">  window.location.href =\"SelectVideo.aspx?page=1\"</script>");
        //    }
        //    private delegate void WSelects(string SuName);
        //    private void Selects(string SuName)
        //    {
        //        if (HttpRuntime.Cache.Get(SuName + "all") == null)
        //        {
        //            BLL.BooksCatalogBLL bll = new BLL.BooksCatalogBLL();
        //            DataTable td = bll.SelectCaBySu(SuName);
        //            HttpRuntime.Cache.Insert(SuName + "all", td, null, DateTime.MaxValue, TimeSpan.FromSeconds(2000));
        //            if (SuName == "语文")
        //            {
        //                Session["Loadings"] = "语文|";
        //            }
        //        }
        //    }
        //    protected void Button2_Click(object sender, EventArgs e)
        //    {
        //        //int index = 0;
        //        //int last = 0;
        //        //try
        //        //{
        //        //    index = Convert.ToInt32(TxtIndex.Text);
        //        //    last = Convert.ToInt32(Txtlast.Text);
        //        //}
        //        //catch (Exception ex)
        //        //{
        //        //    Response.Write(" <script type=\"text/javascript\"> alert(\"输入数字" + ex + " \");</script>");
        //        //}
        //        //int ys = (index - 1) * 30;
        //        //int ts = ((last - 1) * 30) - ys;
        //        //if (Session["GrName"] != null)
        //        //{
        //        //    GrName = Session["GrName"].ToString();
        //        //}
        //        //if (Session["SuName"] != null)
        //        //{
        //        //    SuName = Session["SuName"].ToString();
        //        //}
        //        //if (Session["sem"] != null)
        //        //{
        //        //    sem = Session["sem"].ToString();
        //        //}
        //        //if (Session["CaName"] != null)
        //        //{
        //        //    CaName = Session["CaName"].ToString();
        //        //}
        //        //if (Session["Study"] != null)
        //        //{
        //        //    Study = Convert.ToInt32(Session["Study"]);
        //        //}
        //        //if (Session["mp4"] != null)
        //        //{
        //        //    mp4 = Convert.ToBoolean(Session["mp4"]);
        //        //}
        //        //if (Session["htv"] != null)
        //        //{
        //        //    htv = Convert.ToBoolean(Session["htv"]);
        //        //}
        //        //if (Session["quanbu"] != null)
        //        //{
        //        //    htv = Convert.ToBoolean(Session["quanbu"]);
        //        //}
        //        //weituo wt = new weituo(pipei);

        //        //wt.Invoke(ts, ys, GrName, PrName, sem, CaName, Study, mp4, htv);

        //        //pipei(ts, ys, GrName, SuName, CaName, mp4, htv, quanbu);
        //        //Response.Write(" <script type=\"text/javascript\"> alert(\"成功" + hs + " \");</script>");
        //    }
        //    public void pipei(int ts, int ys, string GrName, string SuName, string CaName, bool mp4, bool htv, bool quanbu)
        //    {

        //        string pathhtv = @"http://183.60.136.8:188/HTV/";
        //        string pathmp4 = @"http://183.60.136.8:188/mp4/";
        //        DataTable dt = new DataTable();

        //        BLL.BooksCatalogBLL bll = new BLL.BooksCatalogBLL();
        //        BLL.VideoRouteBLL robll = new BLL.VideoRouteBLL();

        //        dt = bll.select(ts, ys, GrName, SuName, CaName, PrName, mp4, htv, quanbu);
        //        int hs = 0;
        //        for (int i = 0; i < dt.Rows.Count; i++)
        //        {
        //            string xueqi = string.Empty;
        //            string Htvpath = string.Empty;
        //            string mp4path = string.Empty;
        //            if (Convert.ToInt32(dt.Rows[i]["study"]) == 2)
        //            {
        //                xueqi = "初中";
        //            }
        //            else if (Convert.ToInt32(dt.Rows[i]["study"]) == 3)
        //            {
        //                xueqi = "高中";
        //            }
        //            else if (Convert.ToInt32(dt.Rows[i]["study"]) == 1)
        //            {
        //                xueqi = "小学";
        //            }
        //            if (xueqi == "高中")
        //            {
        //                Htvpath = pathhtv + xueqi + "/" + dt.Rows[i]["suname"] + "/" + dt.Rows[i]["Semester"] + "/" + dt.Rows[i]["caname"] + ".htv";
        //            }
        //            else
        //            {
        //                Htvpath = pathhtv + xueqi + "/" + dt.Rows[i]["GrName"].ToString().Trim() + "/" + dt.Rows[i]["suname"] + "/" + dt.Rows[i]["Semester"] + "/" + dt.Rows[i]["caname"] + ".htv";
        //            }
        //            if (!VideoHrep.yanzhen(Htvpath))
        //            {
        //                Htvpath = "";
        //            }
        //            if (xueqi == "高中")
        //            {
        //                mp4path = pathmp4 + xueqi + "/" + dt.Rows[i]["suname"] + "/" + dt.Rows[i]["Semester"] + "/" + dt.Rows[i]["caname"] + ".mp4";
        //            }
        //            else
        //            {
        //                mp4path = pathmp4 + xueqi + "/" + dt.Rows[i]["GrName"].ToString().Trim() + "/" + dt.Rows[i]["suname"] + "/" + dt.Rows[i]["Semester"] + "/" + dt.Rows[i]["caname"] + ".mp4";
        //            }

        //            if (!VideoHrep.yanzhen(mp4path))
        //            {
        //                mp4path = "";
        //            }

        //            if (dt.Rows[i]["viid"] == null && Htvpath == "" && mp4path == "")
        //            {
        //                break;
        //            }
        //            else if (dt.Rows[i]["viid"] != null && Htvpath != "" || mp4path != "")
        //            {
        //                string FileName = string.Empty;
        //                if (dt.Rows[i]["viid"] != null)
        //                {
        //                    List<Model.VideoRoute> calist = robll.SelectByViid(Convert.ToInt32(dt.Rows[i]["viid"]));
        //                    bool cf = false;  //检查是否重复
        //                    if (Htvpath != "")
        //                    {
        //                        FileName = Path.GetFileNameWithoutExtension(Htvpath);
        //                    }
        //                    if (mp4path != "")
        //                    {
        //                        FileName = Path.GetFileNameWithoutExtension(mp4path);
        //                    }
        //                    if (calist.Count == 0)
        //                    {
        //                        cf = true;
        //                    }
        //                    else
        //                    {
        //                        foreach (var item in calist)
        //                        {
        //                            if (item.RouteAress == Htvpath && item.Mp4 == mp4path && item.ViName == FileName)
        //                            {

        //                            }
        //                            else
        //                            {
        //                                cf = true;
        //                            }
        //                        }
        //                    }
        //                    if (cf)
        //                    {
        //                        if (robll.insert(Htvpath, mp4path, Convert.ToInt32(dt.Rows[i]["viid"]), FileName))
        //                        {
        //                            hs++;
        //                        }
        //                    }

        //                }
        //            }

        //        }
        //        Response.Write(" <script type=\"text/javascript\"> alert(\"成功" + hs + " \");</script>");
        //    }
        //    public void pipei(int ts, int ys)
        //    {
        //        string pathhtv = @"http://183.60.136.8:188/HTV/";
        //        string pathmp4 = @"http://183.60.136.8:188/mp4/";
        //        DataTable dt = new DataTable();
        //        if (Session["GrName"] != null)
        //        {
        //            GrName = Session["GrName"].ToString();
        //        }
        //        if (Session["SuName"] != null)
        //        {
        //            SuName = Session["SuName"].ToString();
        //        }
        //        if (Session["sem"] != null)
        //        {
        //            sem = Session["sem"].ToString();
        //        }
        //        if (Session["CaName"] != null)
        //        {
        //            CaName = Session["CaName"].ToString();
        //        }
        //        if (Session["Study"] != null)
        //        {
        //            Study = Convert.ToInt32(Session["Study"]);
        //        }
        //        if (Session["mp4"] != null)
        //        {
        //            mp4 = Convert.ToBoolean(Session["mp4"]);
        //        }
        //        if (Session["htv"] != null)
        //        {
        //            htv = Convert.ToBoolean(Session["htv"]);
        //        }
        //        BLL.BooksCatalogBLL bll = new BLL.BooksCatalogBLL();
        //        BLL.VideoRouteBLL robll = new BLL.VideoRouteBLL();
        //        dt = bll.select(ts, ys, GrName, SuName, CaName, PrName, mp4, htv, quanbu);
        //        int hs = 0;
        //        for (int i = 0; i < dt.Rows.Count; i++)
        //        {
        //            string xueqi = string.Empty;
        //            string Htvpath = string.Empty;
        //            string mp4path = string.Empty;
        //            if (Convert.ToInt32(dt.Rows[i]["study"]) == 2)
        //            {
        //                xueqi = "初中";
        //            }
        //            else if (Convert.ToInt32(dt.Rows[i]["study"]) == 3)
        //            {
        //                xueqi = "高中";
        //            }
        //            else if (Convert.ToInt32(dt.Rows[i]["study"]) == 1)
        //            {
        //                xueqi = "小学";
        //            }
        //            if (xueqi == "高中")
        //            {
        //                Htvpath = pathhtv + xueqi + "/" + dt.Rows[i]["suname"] + "/" + dt.Rows[i]["Semester"] + "/" + dt.Rows[i]["caname"] + ".htv";
        //            }
        //            else
        //            {
        //                Htvpath = pathhtv + xueqi + "/" + dt.Rows[i]["GrName"].ToString().Trim() + "/" + dt.Rows[i]["suname"] + "/" + dt.Rows[i]["Semester"] + "/" + dt.Rows[i]["caname"] + ".htv";
        //            }
        //            if (!VideoHrep.yanzhen(Htvpath))
        //            {
        //                Htvpath = "";
        //            }
        //            if (xueqi == "高中")
        //            {
        //                mp4path = pathmp4 + xueqi + "/" + dt.Rows[i]["suname"] + "/" + dt.Rows[i]["Semester"] + "/" + dt.Rows[i]["caname"] + ".mp4";
        //            }
        //            else
        //            {
        //                mp4path = pathmp4 + xueqi + "/" + dt.Rows[i]["GrName"].ToString().Trim() + "/" + dt.Rows[i]["suname"] + "/" + dt.Rows[i]["Semester"] + "/" + dt.Rows[i]["caname"] + ".mp4";
        //            }

        //            if (!VideoHrep.yanzhen(mp4path))
        //            {
        //                mp4path = "";
        //            }



        //            if (dt.Rows[i]["viid"] == null && Htvpath == "" && mp4path == "")
        //            {
        //                break;
        //            }
        //            else if (dt.Rows[i]["viid"] != null && Htvpath != "" || mp4path != "")
        //            {
        //                string FileName = string.Empty;
        //                if (dt.Rows[i]["viid"] != null)
        //                {
        //                    List<Model.VideoRoute> calist = robll.SelectByViid(Convert.ToInt32(dt.Rows[i]["viid"]));
        //                    bool cf = false;  //检查是否重复
        //                    if (Htvpath != "")
        //                    {
        //                        FileName = Path.GetFileNameWithoutExtension(Htvpath);
        //                    }
        //                    if (mp4path != "")
        //                    {
        //                        FileName = Path.GetFileNameWithoutExtension(mp4path);
        //                    }
        //                    foreach (var item in calist)
        //                    {
        //                        if (item.RouteAress == Htvpath && item.Mp4 == mp4path && item.ViName == FileName)
        //                        {

        //                        }
        //                        else
        //                        {
        //                            cf = true;
        //                        }
        //                    }
        //                    if (cf)
        //                    {
        //                        if (robll.insert(Htvpath, mp4path, Convert.ToInt32(dt.Rows[i]["viid"]), FileName))
        //                        {
        //                            hs++;
        //                        }
        //                    }

        //                }
        //            }

        //        }
        //        Response.Write(" <script type=\"text/javascript\"> alert(\"成功" + hs + " \");</script>");
        //    }
        //    private DataTable Select(int ts, int ys)
        //    {
        //        return ShaixuanTable<DataTable>(ts, ys);
        //    }
        //    private int pagecount()
        //    {
        //        return ShaixuanTable<int>(0, 0);
        //    }

        //    protected void Button4_Click(object sender, EventArgs e)
        //    {
        //        DataTable dt = new DataTable();
        //        string page = string.Empty;
        //        if (Request.QueryString["page"] == null)
        //        {
        //            if (page == "")
        //            {
        //                page = "1";
        //            }
        //        }
        //        else
        //        {
        //            page = Request.QueryString["page"];
        //        }

        //        int ys = int.Parse(page);
        //        int ts = 9;
        //        ys = ys - 1;
        //        ys = ys * ts;
        //        dt = ShaixuanTable<DataTable>(ts, ys);
        //        CreateExcel(dt, "application/ms-excel", "Excel" + DateTime.Now.ToString("yyyy-MM-dd HHmmss") + ".xls");//调用函数  
        //    }
        //    public void CreateExcel(DataTable dt, string FileType, string FileName)
        //    {
        //        Response.Clear();
        //        Response.Charset = "UTF-8";
        //        Response.Buffer = true;
        //        Response.ContentEncoding = System.Text.Encoding.GetEncoding("GB2312");
        //        Response.AppendHeader("Content-Disposition", "attachment;filename=\"" + System.Web.HttpUtility.UrlEncode(FileName, System.Text.Encoding.UTF8) + "");
        //        Response.ContentType = FileType;
        //        string colHeaders = string.Empty;
        //        string ls_item = string.Empty;
        //        DataRow[] myRow = dt.Select();
        //        int i = 0;
        //        int cl = dt.Columns.Count;
        //        for (int j = 0; j < dt.Columns.Count; j++)
        //        {
        //            ls_item += dt.Columns[j].ColumnName + "\t"; //栏位：自动跳到下一单元格  
        //        }
        //        ls_item = ls_item.Substring(0, ls_item.Length - 1) + "\n";
        //        foreach (DataRow row in myRow)
        //        {
        //            for (i = 0; i < cl; i++)
        //            {
        //                if (i == (cl - 1))
        //                {
        //                    ls_item += row[i].ToString() + "\n";
        //                }
        //                else
        //                {
        //                    ls_item += row[i].ToString() + "\t";
        //                }
        //            }
        //            Response.Output.Write(ls_item);
        //            ls_item = string.Empty;
        //        }
        //        Response.Output.Flush();
        //        Response.End();
        //    }
        //    public T ShaixuanTable<T>(int ts, int ys)
        //    {
        //        DataTable dt = new DataTable();
        //        DataTable hc = new DataTable();
        //        DataTable fy = new DataTable();
        //        string Loading = string.Empty;
        //        if (Session["GrName"] != null)
        //        {
        //            GrName = Session["GrName"].ToString();
        //        }
        //        if (Session["SuName"] != null)
        //        {
        //            SuName = Session["SuName"].ToString();
        //        }
        //        if (Session["CaName"] != null)
        //        {
        //            CaName = Session["CaName"].ToString();
        //        }
        //        if (Session["PrName"] != null)
        //        {
        //            PrName = Session["PrName"].ToString();
        //        }
        //        if (Session["mp4"] != null)
        //        {
        //            mp4 = Convert.ToBoolean(Session["mp4"]);
        //        }
        //        if (Session["htv"] != null)
        //        {
        //            htv = Convert.ToBoolean(Session["htv"]);
        //        }
        //        if (Session["quanbu"] != null)
        //        {
        //            quanbu = Convert.ToBoolean(Session["quanbu"]);
        //        }
        //        if (SuName == "")
        //        {
        //            SuName = "语文";
        //        }
        //        if (Session["Loadings"] != null)
        //        {
        //            Loading = Session["Loadings"].ToString();
        //            if (Loading.Contains(SuName))
        //            {
        //                if (HttpRuntime.Cache.Get(SuName + "allwt") != null)
        //                {
        //                    fy = (DataTable)HttpRuntime.Cache.Get(SuName + "allwt");
        //                    if (fy.Rows.Count > 0)
        //                    {
        //                        dt = new DataTable();
        //                        dt = fy.Clone();
        //                        dt = VideoHrep.CloneTable(fy, dt);
        //                    }
        //                }
        //                else
        //                {
        //                    hc = (DataTable)HttpRuntime.Cache.Get(SuName + "all");
        //                    dt = hc.Clone();
        //                    dt = VideoHrep.CloneTable(hc, dt);
        //                    //dt = Ditquchong(dt);
        //                    HttpRuntime.Cache.Insert(SuName + "allwt", dt, null, DateTime.MaxValue, TimeSpan.FromSeconds(2000));
        //                }
        //                dt = SelectWhere(dt);
        //            }
        //            else
        //            {
        //                Selects(SuName);
        //                if (HttpRuntime.Cache.Get(SuName + "allwt") != null)
        //                {
        //                    fy = (DataTable)Cache.Get(SuName + "allwt");
        //                    if (fy.Rows.Count > 0)
        //                    {
        //                        dt = new DataTable();
        //                        dt = fy.Clone();
        //                        dt = VideoHrep.CloneTable(fy, dt);
        //                    }
        //                }
        //                else
        //                {
        //                    hc = (DataTable)HttpRuntime.Cache.Get(SuName + "all");
        //                    dt = hc.Clone();
        //                    dt = VideoHrep.CloneTable(hc, dt);
        //                    //dt = Ditquchong(dt);
        //                    HttpRuntime.Cache.Insert(SuName + "allwt", dt, null, DateTime.MaxValue, TimeSpan.FromSeconds(2000));
        //                }
        //                dt = SelectWhere(dt);
        //            }
        //        }
        //        VideoHrep.InsertXuhao(dt, "Nub");
        //        if (ts == 0)
        //        {
        //            T t = (T)(object)dt.Rows.Count;
        //            return t;
        //        }
        //        else
        //        {
        //            T t = (T)(object)VideoHrep.getOnePageTable(dt, ys, ts);
        //            return t;
        //        }
        //    }
        //    private DataTable SelectWhere(DataTable dt)
        //    {
        //        for (int i = 0; i < dt.Rows.Count; i++)
        //        {
        //            //string name1 = dt.Rows[i]["BooksName"].ToString();
        //            //string name2 = dt.Rows[i]["grname"].ToString();
        //            //string name3 = dt.Rows[i]["CaName"].ToString();
        //            //string name4 = dt.Rows[i]["suname"].ToString();
        //            //string name5 = dt.Rows[i]["mp4"].ToString();
        //            //string name6 = dt.Rows[i]["CaID"].ToString();
        //            //string name7 = dt.Rows[i]["prname"].ToString();

        //            string name = dt.Rows[i]["viname"].ToString();
        //            string ab_caname = dt.Rows[i]["caname"].ToString();
        //            name = VideoHrep.Spit(name);
        //            name = System.Text.RegularExpressions.Regex.Replace(name, @"[0-9]+", "");
        //            if (ab_caname != name)
        //            {
        //                dt.Rows.Remove(dt.Rows[i]);
        //                i--;
        //                continue;
        //            }
        //            if (GrName != "")
        //            {
        //                if (dt.Rows[i]["Grname"].ToString() != GrName)
        //                {
        //                    dt.Rows.Remove(dt.Rows[i]);
        //                    i--;
        //                    continue;
        //                }
        //            }
        //            if (CaName != "")
        //            {
        //                string dt_caname = dt.Rows[i]["CaName"].ToString();
        //                if (!dt_caname.Contains(CaName))
        //                {
        //                    dt.Rows.Remove(dt.Rows[i]);
        //                    i--;
        //                    continue;
        //                }
        //            }
        //            if (PrName != "")
        //            {
        //                if (dt.Rows[i]["PrName"].ToString() != PrName)
        //                {
        //                    dt.Rows.Remove(dt.Rows[i]);
        //                    i--;
        //                    continue;
        //                }
        //            }
        //            if (mp4)
        //            {
        //                if (dt.Rows[i]["mp4"].ToString() == "")
        //                {
        //                    dt.Rows.Remove(dt.Rows[i]);
        //                    //routearess
        //                    i--;
        //                    continue;
        //                }
        //            }
        //            if (htv)
        //            {
        //                if (dt.Rows[i]["mp4"].ToString() != "")
        //                {
        //                    dt.Rows.Remove(dt.Rows[i]);
        //                    i--;
        //                    continue;
        //                }
        //            }
        //        }
        //        return dt;
        //    }
        //    private DataTable Ditquchong(DataTable dt)
        //    {
        //        for (int i = 0; i < dt.Rows.Count; i++)
        //        {

        //            //routearess

        //            if (dt.Rows[i]["mp4"].ToString() != "")
        //            {
        //                dt.Rows[i]["testmp4"] = "";
        //            }
        //            string DBooksName = dt.Rows[i]["BooksName"].ToString();
        //            string DCaName = dt.Rows[i]["CaName"].ToString();
        //            string DMp4 = dt.Rows[i]["Mp4"].ToString();
        //            string DTestMp4 = dt.Rows[i]["testmp4"].ToString();
        //            if (i > 0)
        //            {
        //                for (int k = 0; k < i; k++)
        //                {
        //                    string DDBooksName = dt.Rows[k]["BooksName"].ToString();
        //                    string DDCaName = dt.Rows[k]["CaName"].ToString();
        //                    string DDMp4 = dt.Rows[k]["Mp4"].ToString();
        //                    string DDTestMp4 = dt.Rows[k]["testmp4"].ToString();
        //                    if (DBooksName == DDBooksName && DCaName == DDCaName && DMp4 == DDMp4 && DTestMp4 == DDTestMp4)
        //                    {
        //                        dt.Rows.Remove(dt.Rows[i]);
        //                        i--;
        //                        break;
        //                    }
        //                }
        //            }
        //        }
        //        return dt;
        //    }
        //    protected void Button1_Click(object sender, EventArgs e)
        //    {
        //        DataTable hv = new DataTable();
        //        if (Session["SuName"] != null)
        //        {
        //            SuName = Session["SuName"].ToString();
        //        }
        //        if (SuName == "")
        //        {
        //            SuName = "语文";
        //        }
        //        DataTable dt = (DataTable)HttpRuntime.Cache.Get(SuName + "allwt");
        //        dt = SelectWhere(dt);
        //        hv = dt.Clone();
        //        hv = VideoHrep.CloneTable(dt, hv);
        //        CreateExcel(dt, "application/ms-excel", "Excel" + DateTime.Now.ToString("yyyy-MM-dd HH:mm:ss") + ".xls");//调用函数  
        //    }
        //}
    }
}