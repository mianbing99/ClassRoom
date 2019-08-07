using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Web;
using System.Web.SessionState;

namespace Webz.ashx {
    /// <summary>
    /// Books 的摘要说明
    /// </summary>
    public class Books : IHttpHandler,IRequiresSessionState {

        public void ProcessRequest(HttpContext context) {
            context.Response.ContentType = "text/plain";
            string action = context.Request["action"].ToString();
            switch (action) {
                case "Video":
                    Video(context);
                    break;
                case "bangding":
                    bangding(context);
                    break;
                case "But":
                    Video_Load(context);
                    break;
            }
        }

        private void Video(HttpContext context) {
            string viid = context.Request["viid"].ToString();
            if (context.Session["Phone"] == null) {
                context.Response.Write("Login");
                context.Response.End();
            }
            BLL.CardBLL carBll = new BLL.CardBLL();
            string Phone = context.Session["Phone"].ToString();
            if (!carBll.Select(Phone)) {
                context.Response.Write("jihuo");
                context.Response.End();
            }
            BLL.VideoRouteBLL RoBLL = new BLL.VideoRouteBLL();
            int Viid = Convert.ToInt32(viid);
            List<Model.VideoRoute> VideoRo = RoBLL.SelectByViid(Viid);
            if (VideoRo.Count == 0) {
                context.Response.Write("shipin");
                context.Response.End();
            }
        }
        private void bangding(HttpContext context) {
            string caname = context.Request["caname"].ToString();
            int Caid = Convert.ToInt32(context.Request["Caid"]);
            string Mp4 = context.Request["Mp4"].ToString();
            Mp4 = Mp4.Replace("'", "''");
            string Htv = Mp4.Replace("MP4", "HTV");
            Htv = Htv.Replace("mp4", "htv");
            string suname = SelectSu(Mp4);
            DataTable dt = (DataTable)HttpRuntime.Cache.Get(suname + "allwt");
            BLL.BooksCataLogBLL CaBll = new BLL.BooksCataLogBLL();
            BLL.VideoBLL ViBLL = new BLL.VideoBLL();
            BLL.VideoRouteBLL RoBll = new BLL.VideoRouteBLL();
            string json = string.Empty;
            try {
                int Viid = CaBll.SelectViidByCaid(Caid);
                if (Viid == 0) {
                    Viid = ViBLL.Insert(caname);
                    if (RoBll.insert(Htv, Mp4, Viid, System.IO.Path.GetFileNameWithoutExtension(Mp4))) {
                        if (CaBll.UpdateViidByid(Caid, Viid)) {
                            for (int k = 0; k < dt.Rows.Count; k++) {
                                if (Convert.ToInt32(dt.Rows[k]["Caid"]) == Caid) {
                                    dt.Rows[k]["mp4"] = Mp4;
                                }
                            }
                            json = "绑定成功";
                        }
                    }
                } else {
                 var ro= RoBll.SelectByViid(Viid);
                 foreach (var item in ro) {
                     if (item.Mp4 == Mp4 && item.ViName == System.IO.Path.GetFileNameWithoutExtension(Mp4) && item.ViID == Viid)
                     {
                         if (RoBll.Delete(Viid, Mp4, item.ViName)) {
                             for (int k = 0; k < dt.Rows.Count; k++) {
                                 if (Convert.ToInt32(dt.Rows[k]["Caid"]) == Caid) {
                                     dt.Rows[k]["mp4"] = "";
                                 }
                             }
                             json = "解绑成功";
                         }
                     }
                 }
                 if (json != "解绑成功") {
                     if (RoBll.insert("", Mp4, Viid, System.IO.Path.GetFileNameWithoutExtension(Mp4))) {
                         for (int k = 0; k < dt.Rows.Count; k++) {
                             if (Convert.ToInt32(dt.Rows[k]["Caid"]) == Caid) {
                                 dt.Rows[k]["mp4"] = Mp4;
                             }
                         }
                         json = "绑定成功";
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
        private void Video_Load(HttpContext context) {
            var  caname = context.Request["But"].ToString();
            foreach (var item in caname) {
                
            }
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