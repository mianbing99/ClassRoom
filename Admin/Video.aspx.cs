using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text.RegularExpressions;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Web.Caching;
using Webz;
using System.Data;

namespace Webz.Admin {
    public partial class Video : System.Web.UI.Page {
        private string Mp4IP = "http://183.60.136.8:188/MP4/";
        private string HtvIP = "http://183.60.136.8:188/HTV/";
        public List<string> aa = new List<string>();
        public List<Model.Test> selectList = new List<Model.Test>();
        public int sum = 0;
        public string qtcaname = string.Empty;
        public string qtBooksName = string.Empty;
        protected void Page_Load(object sender, EventArgs e) {
            if (!IsPostBack) {
                string SuName = string.Empty;
                if (Session["SuName"] != null) {
                    SuName = Session["SuName"].ToString();
                }
                if (HttpRuntime.Cache.Get("telist") == null) {
                    BLL.TestBLL teBll = new BLL.TestBLL();
                    List<Model.Test> telist = teBll.Select();
                    HttpRuntime.Cache.Insert("telist", telist, null, DateTime.MaxValue, TimeSpan.FromSeconds(2000));
                }
                string Caname = string.Empty;
                int Caid = 0;
                if (!string.IsNullOrEmpty(Request.QueryString["Caname"])) {
                    Caname = Request.QueryString["Caname"].ToString();
                    qtBooksName = Request.QueryString["BooksName"].ToString();
                    Txt_CaName.Value = Caname;
                    T_Caname.Value = Caname;
                    qtcaname = Caname;
                    Caid = Convert.ToInt32(Request.QueryString["Caid"]);
                    T_Caid.Value = Caid.ToString();
                    List<Model.Test> PathList = new List<Model.Test>();
                    PathList = (List<Model.Test>)HttpRuntime.Cache.Get("telist");
                    List<Model.Test> selectList = new List<Model.Test>();
                    foreach (var item in PathList) {
                        if (item.Name.Contains(Caname) && item.Kemu == SuName) {
                            selectList.Add(item);
                        }
                    }
                    Repeater1.DataSource = selectList;
                    Repeater1.DataBind();
                }


            }// ispostback 结尾
            if (!string.IsNullOrEmpty(Request.QueryString["Caname"])) {
                qtcaname = Request.QueryString["Caname"].ToString();
                qtBooksName = Request.QueryString["BooksName"].ToString();
            }
        }// pageload 结尾

        public delegate void duquAllweituo();
        //public void duquAll() {
        //    List<string> aa = new List<string>();
        //    string Mp4path = "MP4\\";
        //    //List<string> mp4 = new List<string>(FTP.GetFileList("", Mp4path));
        //    List<string> wenjianjia = FTP.GetDirctory(Mp4path);
        //    string[] mp4 = FTP.GetFilesDetailList(Mp4path);
        //    Regex regex = new Regex(@" *([01]\d|2[01234]):([0-5]\d|60) *", RegexOptions.IgnoreCase);
        //    foreach (var item in mp4) {
        //        //string ab = item.Substring(item.LastIndexOf(@"\d ") + 1);
        //        Match mc = regex.Match(item);
        //        string ab = mc.Groups[2].Value;
        //        ab = item.Substring(item.LastIndexOf(ab) + 3);
        //        if (ab.IndexOf('.') < 1) {
        //            string[] CaName = FTP.GetFilesDetailList(Mp4path + ab + "\\");
        //            foreach (var it in CaName) {
        //                //string ad = it.Substring(it.LastIndexOf(@"\d ") + 1);
        //                Match mad = regex.Match(it);
        //                string ad = mad.Groups[2].Value;
        //                ad = it.Substring(it.LastIndexOf(ad) + 3);
        //                if (ad.IndexOf('.') < 1) {
        //                    string[] SuName = FTP.GetFilesDetailList(Mp4path + ab + "\\" + ad + "\\");
        //                    foreach (var ite in SuName) {
        //                        // string adq = ite.Substring(ite.LastIndexOf(@"\d ") + 1);
        //                        Match madq = regex.Match(ite);
        //                        string adq = madq.Groups[2].Value;
        //                        adq = ite.Substring(ite.LastIndexOf(adq) + 3);
        //                        if (adq.IndexOf('.') < 1) {
        //                            string[] Sem = FTP.GetFilesDetailList(Mp4path + ab + "\\" + ad + "\\" + adq + "\\");
        //                            foreach (var itec in Sem) {
        //                                //string adqw = itec.Substring(itec.LastIndexOf(' ') + 1);
        //                                Match madqw = regex.Match(itec);
        //                                string adqw = madqw.Groups[2].Value;
        //                                adqw = itec.Substring(itec.LastIndexOf(adqw) + 3);
        //                                if (adqw.IndexOf('.') < 1) {
        //                                    string[] VideoName;
        //                                    VideoName = FTP.GetFilesDetailList(Mp4path + ab + "\\" + ad + "\\" + adq + "\\" + adqw + "\\");
        //                                    HttpRuntime.Cache.Insert("CaCheVideo", VideoName, null, DateTime.MaxValue, TimeSpan.FromSeconds(2000));
        //                                    foreach (var itecd in VideoName) {
        //                                        Match madqwe = regex.Match(itecd);
        //                                        string adqwe = madqwe.Groups[2].Value;
        //                                        adqwe = itecd.Substring(itecd.LastIndexOf(adqwe) + 3);
        //                                        if (adqwe.IndexOf('.') < 1) {
        //                                            aa.Add(Mp4path + ab + "\\" + ad + "\\" + adq + "\\" + adqw + "\\" + adqwe);
        //                                        } else {
        //                                            aa.Add(Mp4path + ab + "\\" + ad + "\\" + adq + "\\" + adqw + "\\" + adqwe);
        //                                        }
        //                                    }
        //                                } else {
        //                                    aa.Add(Mp4path + ab + "\\" + ad + "\\" + adq + "\\" + adqw);
        //                                }
        //                            }
        //                        } else {
        //                            aa.Add(Mp4path + ab + "\\" + ad + "\\" + adq);
        //                        }
        //                    }
        //                }
        //            }
        //        }
        //    }
        //    HttpRuntime.Cache.Insert("aa", aa, null, DateTime.MaxValue, TimeSpan.FromSeconds(2000));
        //}

        protected void Button1_Click(object sender, EventArgs e) {
            string Name = Txt_CaName.Value;
            string SuName = string.Empty;
            if (Session["SuName"] != null) {
                SuName = Session["SuName"].ToString();
            }
            if (SuName == "") {
                SuName = "语文";
            }
            List<Model.Test> PathList = new List<Model.Test>();
            if (HttpRuntime.Cache.Get("telist") == null) {
                BLL.TestBLL teBll = new BLL.TestBLL();
                List<Model.Test> telist = teBll.Select();
                HttpRuntime.Cache.Insert("telist", telist, null, DateTime.MaxValue, TimeSpan.FromSeconds(2000));
            }
            PathList = (List<Model.Test>)HttpRuntime.Cache.Get("telist");
            foreach (var item in PathList) {
                if (item.Name.Contains(Name) && item.Kemu==SuName) {
                    selectList.Add(item);
                }
            }
            Repeater1.DataSource = selectList;
            Repeater1.DataBind();
        }

        protected void Button2_Click(object sender, EventArgs e) {
            int pages = 1;
            if (Request.QueryString["pages"] != null) {
                pages = Convert.ToInt32(Request.QueryString["pages"]);
            }
            Response.Write(" <script type=\"text/javascript\">window.location = \"SelectVideo.aspx?page=" + pages + "\";</script>");
        }
    }
}