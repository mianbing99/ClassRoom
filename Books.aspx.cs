using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace Webz.WebIE {
    public partial class Books : System.Web.UI.Page {
        public string str = string.Empty;
        public string Sess = string.Empty;
        protected void Page_Load(object sender, EventArgs e) {
            if (Session["Phone"] != null) {
                Sess = Session["Phone"].ToString();
            }
            if (Session["Openid"] == null) {
                Response.Write("<script type=\"text/javascript\"> alert(\"系统繁忙\");</script>");
                Response.Write(" <script type=\"text/javascript\">  window.location.href =\"https://open.weixin.qq.com/connect/oauth2/authorize?appid=wx0688f75d53cbb9e1&redirect_uri=http://ftv.icoxtech.com&response_type=code&scope=snsapi_base#wechat_redirect\"</script>");
            }
            if (string.IsNullOrEmpty(Request.QueryString["Booksid"])) {
                Response.Write(" <script type=\"text/javascript\">  window.location.href =\"Index.aspx\"</script>");
                return;
            }
            string booksid = Request.QueryString["Booksid"];
            int Booksid = Convert.ToInt32(booksid);
            //RpList.DataSource = BLL.BooksCatalogBLL.SelectList(Booksid);
            //RpList.DataBind();
            List<Model.Catalog> CaList = new List<Model.Catalog>();
            BLL.BooksCatalogBLL BooksCaBll = new BLL.BooksCatalogBLL();
            CaList = BooksCaBll.SelectList(Booksid);
            List<Model.Catalog> YiList = BooksCaBll.SelectNotTid(Booksid); //查询所有 有子级目录的课文
            List<Model.Catalog> ErList = BooksCaBll.Selectziji(Booksid); //查询所有子级目录
            for (int abc = 0; abc < CaList.Count; abc++) {  //移除所有子级目录
                foreach (Model.Catalog erl in ErList) {
                    if (erl.CaID == CaList[abc].CaID) {
                        CaList.Remove(CaList[abc]);
                        abc--;
                    }
                }
            }
            int i = 0;
            foreach (Model.Catalog Ca in CaList) {
                if (Ca.TID == 0) {
                    if (i == 0) {
                        str += "<p class=\"danyuan\">" + Ca.CaName + "</p> ";
                        str += "<div class=\"kewenk\">";
                    } else {
                        str += "</div>";
                        str += "<p class=\"danyuan\">" + Ca.CaName + "</p> ";
                        str += "<div class=\"kewenk\">";
                    }
                } else {
                    int jj = 0;
                    foreach (Model.Catalog Cab in YiList) {
                        if (Ca.CaID == Cab.CaID) {
                            str += "<p class=\"kewen\"><span class=\"span_name\">" + Ca.CaName + "</span></p>";
                            foreach (Model.Catalog Cac in ErList) {
                                if (Cab.CaID == Cac.TID) {
                                    if (Cac.State == "0") {
                                        if (Cac.Viid == 0) {
                                            str += "<p style=\"color:#808080\" class=\"kewen_z\" id=\"" + Cac.Viid + "\"><span class=\"span_name_z\">" + Cac.CaName + "</span></p>";
                                        } else {
                                            str += "<a name=\"lianjie\" href=\"Video.aspx?viid=" + Cac.Viid + "\"><p class=\"kewen_z\" id=\"" + Cac.Viid + "\"><span class=\"span_name_z\">" + Cac.CaName + "</span><img class=\"Vip\" src=\"Images/Imgs/免费.png\" /></p></a>";
                                        }
                                        
                                        jj++;
                                    } else {
                                        if (Cac.Viid == 0) {
                                            str += "<p style=\"color:#808080\" class=\"kewen_z\" id=\"" + Cac.Viid + "\"><span class=\"span_name_z\">" + Cac.CaName + "</span></p>";
                                        } else {
                                            str += "<a name=\"lianjie\" href=\"Video.aspx?viid=" + Cac.Viid + "\"><p class=\"kewen_z\" id=\"" + Cac.Viid + "\"><span class=\"span_name_z\">" + Cac.CaName + "</span><img class=\"Vip\" src=\"Images/Imgs/vip图标.png\" /></p></a>";
                                        }
                                        
                                        jj++;
                                    }
                                }
                            }
                            jj++;
                        }
                    }
                    if (jj == 0) {
                        if (Ca.CaNum == "" || Ca.CaNum == null) {
                            if (Ca.State == "0") {
                                if (Ca.Viid == 0) {
                                    str += "<p style=\"color:#808080\" class=\"kewen\" id=\"" + Ca.Viid + "\"><span class=\"span_name\">" + Ca.CaName + "</span></p>";
                                } else {
                                    str += "<a name=\"lianjie\" href=\"Video.aspx?viid=" + Ca.Viid + "\"><p class=\"kewen\" id=\"" + Ca.Viid + "\"><span class=\"span_name\">" + Ca.CaName + "</span><img class=\"Vip\" src=\"Images/Imgs/免费.png\" /></p></a>";
                                }
                                
                            } else {
                                if (Ca.Viid == 0) {
                                    str += "<p style=\"color:#808080\" class=\"kewen\" id=\"" + Ca.Viid + "\"><span class=\"span_name\">" + Ca.CaName + "</span></p>";
                                } else {
                                    str += "<a name=\"lianjie\" href=\"Video.aspx?viid=" + Ca.Viid + "\"><p class=\"kewen\" id=\"" + Ca.Viid + "\"><span class=\"span_name\">" + Ca.CaName + "</span><img class=\"Vip\" src=\"Images/Imgs/vip图标.png\" /></p></a>";
                                }
                            }
                        } else {
                            if (Ca.State == "0") {
                                if (Ca.Viid == 0) {
                                    str += "<p style=\"color:#808080\" class=\"kewen\" id=\"" + Ca.Viid + "\"><span class=\"span_num\">" + Ca.CaNum + "</span><span class=\"span_name\">" + Ca.CaName + "</span></p>";
                                } else {
                                    str += "<a name=\"lianjie\" href=\"Video.aspx?viid=" + Ca.Viid + "\"><p class=\"kewen\" id=\"" + Ca.Viid + "\"><span class=\"span_num\">" + Ca.CaNum + "</span><span class=\"span_name\">" + Ca.CaName + "</span><img class=\"Vip\" src=\"Images/Imgs/免费.png\" /></p></a>";
                                }
                                
                            } else {
                                if (Ca.Viid == 0) {
                                    str += "<p style=\"color:#808080\" class=\"kewen\" id=\"" + Ca.Viid + "\"><span class=\"span_num\">" + Ca.CaNum + "</span><span class=\"span_name\">" + Ca.CaName + "</span></p>";
                                }else{
                                    str += "<a name=\"lianjie\" href=\"Video.aspx?viid=" + Ca.Viid + "\"><p class=\"kewen\" id=\"" + Ca.Viid + "\"><span class=\"span_num\">" + Ca.CaNum + "</span><span class=\"span_name\">" + Ca.CaName + "</span><img class=\"Vip\" src=\"Images/Imgs/vip图标.png\" /></p></a>";
                                }
                                
                            }
                            
                        }

                    }

                    //List<Model.Catalog> CaList_Z = BooksCaBll.SelectForTid(Ca.CaID);
                    //if (CaList_Z.Count > 0) {
                    //    str += "<a href=\"Video.aspx?viid=" + Ca.Viid + "\"><p class=\"kewen\"><span class=\"span_num\">" + Ca.CaNum + "</span><span class=\"span_name\">" + Ca.CaName + "</span><span class=\"span_page\">(" + Ca.Page + ")</span></p></a>";
                    //    foreach (Model.Catalog Ca_z in CaList_Z) {
                    //        str += "<a href=\"Video.aspx?viid=" + Ca_z.Viid + "\"><p class=\"kewen_z\"><span class=\"span_name_z\">" + Ca_z.CaName + "</span><span class=\"span_page_z\">(" + Ca_z.Page + ")</span></p></a>";
                    //    }
                    //} else if (BooksCaBll.Selectfujimulu(Ca.TID)) {
                    //    str += "<a href=\"Video.aspx?viid=" + Ca.Viid + "\"><p class=\"kewen\"><span class=\"span_num\">" + Ca.CaNum + "</span><span class=\"span_name\">" + Ca.CaName + "</span><span class=\"span_page\">(" + Ca.Page + ")</span></p></a>";
                    //}
                }
                i++;
            }
            str += "</div>";
        }

    }
}