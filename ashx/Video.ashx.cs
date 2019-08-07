using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Web;
using System.Web.Caching;
using System.Web.SessionState;

namespace Webz.ashx {
    /// <summary>
    /// Video 的摘要说明
    /// </summary>
    public class Video : IHttpHandler, IRequiresSessionState {

        public void ProcessRequest(HttpContext context) {
            context.Response.ContentType = "text/plain";
            string action = context.Request["action"].ToString();
            switch (action) {
                case "bangdingS":
                    Bangding(context);
                    break;
                case "LoadGr":
                    Loadgr(context);
                    break;
                case "chek":
                    chek(context);
                    break;
            }
        }
        private void Bangding(HttpContext context) {
            string mp4 = context.Request["mp4"].ToString().Trim();
            string id = context.Request["id"].ToString().Trim();
            string caname = context.Request["caname"].ToString().Trim();
            mp4 = mp4.Replace("'", "''");
            mp4 = mp4.Replace(" ","");
            string htv = mp4.Replace("MP4", "HTV");
            htv = htv.Replace("mp4", "htv");
            List<string> Htv = new List<string> (htv.Split('|'));
            List<string> Mp4 = new List<string>(mp4.Split('|'));
            List<string> ID = new List<string>(id.Split('|'));
            ID.Remove(ID[ID.Count-1]);
            List<string> Caname = new List<string>(caname.Split('|'));
            Caname.Remove(Caname[Caname.Count - 1]);
            string json = string.Empty;
            for (int i = 0; i < Mp4.Count; i++) {
                if (Mp4[i] == "") {
                    Htv.Remove(Htv[i]);
                    Mp4.Remove(Mp4[i]);
                    i--;
                }
            }
            string suname = SelectSu(Mp4[0]);
            DataTable dt = (DataTable)HttpRuntime.Cache.Get(suname+"wt");
            BLL.BooksCatalogBLL CaBll = new BLL.BooksCatalogBLL();
            BLL.VideoBLL ViBLL = new BLL.VideoBLL();
            BLL.VideoRouteBLL RoBll = new BLL.VideoRouteBLL();
            List<string> chenggong = new List<string>();
            List<string> jiebang = new List<string>();
            try {
                for (int i = 0; i < Mp4.Count; i++) {
                    int Viid = CaBll.SelectViidByCaid(Convert.ToInt32(ID[i]));
                    if (Viid == 0) {
                        Viid = ViBLL.Insert(Caname[i]);
                        if (RoBll.insert(Htv[i], Mp4[i], Viid, System.IO.Path.GetFileNameWithoutExtension(Mp4[i]))) {
                            if (CaBll.UpdateViidByid(Convert.ToInt32(ID[i]), Viid)) {
                                for (int k = 0; k < dt.Rows.Count; k++) {
                                    if (dt.Rows[k]["testmp4"].ToString() == Mp4[i]) {
                                        dt.Rows[k]["mp4"] = Mp4[i];
                                        dt.Rows[k]["testmp4"] = "";
                                    }
                                }
                                Mp4[i] = Mp4[i].Replace("\\", "\\\\");
                                chenggong.Add(Mp4[i]);
                            }
                        }
                    } else {
                        var ro = RoBll.SelectByViid(Viid);
                        foreach (var item in ro) {
                            if (item.Mp4 == Mp4[i] && item.ViName == System.IO.Path.GetFileNameWithoutExtension(Mp4[i]) && item.Viid == Viid) {
                                if (RoBll.Delete(Viid, Mp4[i], item.ViName)) {
                                    for (int k = 0; k < dt.Rows.Count; k++) {
                                        if (dt.Rows[k]["mp4"].ToString() == Mp4[i]) {
                                            dt.Rows[k]["testmp4"] = Mp4[i];
                                            dt.Rows[k]["mp4"] = "";
                                        }
                                    }
                                    Mp4[i] = Mp4[i].Replace("\\", "\\\\");
                                    jiebang.Add(Mp4[i]);
                                }
                            }
                        }

                        if (!VideoHrep.StrInArray(Mp4[i], jiebang)) {
                            if (RoBll.insert(Htv[i], Mp4[i], Viid, System.IO.Path.GetFileNameWithoutExtension(Mp4[i]))) {
                                for (int k = 0; k < dt.Rows.Count; k++) {
                                    if (dt.Rows[k]["testmp4"].ToString() == Mp4[i]) {
                                        dt.Rows[k]["mp4"] = Mp4[i];
                                        dt.Rows[k]["testmp4"] = "";
                                    }
                                }
                                Mp4[i] = Mp4[i].Replace("\\", "\\\\");
                                chenggong.Add(Mp4[i]);
                            }
                        }

                    }
                }
                if (chenggong.Count + jiebang.Count == 1) {
                    if (chenggong.Count != 0) {
                        json = "[{\"cg\":\"" + chenggong[0] + "\"}]";
                    } else {
                        json = "[{\"jb\":\"" + jiebang[0] + "\"}]";
                    }
                } else {
                    for (int i = 0; i < chenggong.Count; i++) {
                        if (jiebang.Count != 0) {
                            if (i == 0) {
                                json = "[{\"cg\":\"" + chenggong[i] + "\"},";
                            } else {
                                json += "{\"cg\":\"" + chenggong[i] + "\"},";
                            }
                        } else {
                            if (i == 0) {
                                json = "[{\"cg\":\"" + chenggong[i] + "\"},";
                            } else if (i == chenggong.Count - 1) {
                                json += "{\"cg\":\"" + chenggong[i] + "\"}]";
                            } else {
                                json += "{\"cg\":\"" + chenggong[i] + "\"},";
                            }
                        }
                    }
                    for (int i = 0; i < jiebang.Count; i++) {
                        if (chenggong.Count != 0) {
                            if (jiebang.Count == 1) {
                                json += "{\"jb\":\"" + jiebang[i] + "\"}]";
                            } else if (i == 0) {
                                json += "{\"jb\":\"" + jiebang[i] + "\"},";
                            } else if (i == jiebang.Count - 1) {
                                json += "{\"jb\":\"" + jiebang[i] + "\"}]";
                            } else {
                                json += "{\"jb\":\"" + jiebang[i] + "\"},";
                            }
                        } else {
                            if (i == 0) {
                                json = "[{\"jb\":\"" + jiebang[i] + "\"},";
                            } else if (i == jiebang.Count - 1) {
                                json += "{\"jb\":\"" + jiebang[i] + "\"}]";
                            } else {
                                json += "{\"jb\":\"" + jiebang[i] + "\"},";
                            }
                        }
                    }

                }
            } catch (Exception ex) {
                json = ex.ToString();
            } finally {
                context.Response.Write(json);
                context.Response.End();
            }
        }
        private void Loadgr(HttpContext context) {
            string Gr = string.Empty;
            string Su = string.Empty;
            string Pr = string.Empty;
            string Ca = string.Empty;
            string json = string.Empty;
            if (context.Session["GrName"] != null) {
                Gr = context.Session["GrName"].ToString();
            }
            if (context.Session["SuName"] != null) {
                Su = context.Session["SuName"].ToString();
            }
            if (context.Session["PrName"] != null) {
                Pr = context.Session["PrName"].ToString();
            }
            if (context.Session["CaName"] != null) {
                Ca = context.Session["CaName"].ToString();
            }
            json = Gr + "|" + Su + "|" + Pr + "|"+Ca+"|";
            context.Response.Write(json);
            context.Response.End();
        }
        private void chek(HttpContext context) {
            string json = string.Empty;
            bool quanbu = false;
            bool yi = false;
            bool wei = false;
            if (context.Session["quanbu"] != null) {
                quanbu =Convert.ToBoolean( context.Session["quanbu"]);
            }
            if (context.Session["mp4"] != null) {
                yi = Convert.ToBoolean(context.Session["mp4"]);
            }
            if (context.Session["htv"] != null) {
                wei = Convert.ToBoolean(context.Session["htv"]);
            }
            if (quanbu) {
                json = "quanbu";
            }else if(yi ){
                json = "yi";
            } else if (wei) {
                json = "wei";
            }
            context.Response.Write(json);
            context.Response.End();
        }
        private string SelectSu(string Mp4) {
            string str = string.Empty;
            if (Mp4.IndexOf("语文") > 0) {
                str = "语文";
            }
            if (Mp4.IndexOf("数学") > 0) {
                str = "数学";
            }
            if (Mp4.IndexOf("英语") > 0) {
                str = "英语";
            }
            if (Mp4.IndexOf("物理") > 0) {
                str = "物理";
            }
            if (Mp4.IndexOf("化学") > 0) {
                str = "化学";
            }
            if (Mp4.IndexOf("生物") > 0) {
                str = "生物";
            }
            if (Mp4.IndexOf("政治") > 0) {
                str = "政治";
            }
            if (Mp4.IndexOf("历史") > 0) {
                str = "历史";
            }
            if (Mp4.IndexOf("地理") > 0) {
                str = "地理";
            }
            return str;
        }
        public bool IsReusable {
            get {
                return false;
            }
        }
    }
}