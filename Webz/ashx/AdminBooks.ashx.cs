using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text.RegularExpressions;
using System.Web;

namespace Webz.ashx {
    /// <summary>
    /// AdminBooks 的摘要说明
    /// </summary>
    public class AdminBooks : IHttpHandler {

        public void ProcessRequest(HttpContext context) {
            context.Response.ContentType = "text/plain";
            string action = context.Request["action"].ToString();
            switch (action) {
                case "Load":
                    Load(context);
                    break;
                case "duqu":
                    duqu(context);
                    break;
                case "grade":
                    getGrade(context);
                    break;
            }
        }

        private void getGrade(HttpContext context) 
        {
            List<Model.Grade> gradeList = new BLL.GradeBLL().selectgrade();
            var str = new
            {
                list = gradeList
            };
            context.Response.Write(JsonConvert.SerializeObject(str) );
        }

        private void Load(HttpContext context) {
          
        }
        private void duqu(HttpContext context) {
            if (HttpRuntime.Cache.Get("aa") == null) {
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
                    if (ab.IndexOf('.') < 1) {
                        string[] CaName = FTP.GetFilesDetailList(Mp4path + ab + "\\");
                        foreach (var it in CaName) {
                            //string ad = it.Substring(it.LastIndexOf(@"\d ") + 1);
                            Match mad = regex.Match(it);
                            string ad = mad.Groups[2].Value;
                            ad = it.Substring(it.LastIndexOf(ad) + 3);
                            if (ad.IndexOf('.') < 1) {
                                string[] SuName = FTP.GetFilesDetailList(Mp4path + ab + "\\" + ad + "\\");
                                foreach (var ite in SuName) {
                                    // string adq = ite.Substring(ite.LastIndexOf(@"\d ") + 1);
                                    Match madq = regex.Match(ite);
                                    string adq = madq.Groups[2].Value;
                                    adq = ite.Substring(ite.LastIndexOf(adq) + 3);
                                    if (adq.IndexOf('.') < 1) {
                                        string[] Sem = FTP.GetFilesDetailList(Mp4path + ab + "\\" + ad + "\\" + adq + "\\");
                                        foreach (var itec in Sem) {
                                            //string adqw = itec.Substring(itec.LastIndexOf(' ') + 1);
                                            Match madqw = regex.Match(itec);
                                            string adqw = madqw.Groups[2].Value;
                                            adqw = itec.Substring(itec.LastIndexOf(adqw) + 3);
                                            if (adqw.IndexOf('.') < 1) {
                                                string[] VideoName;
                                                VideoName = FTP.GetFilesDetailList(Mp4path + ab + "\\" + ad + "\\" + adq + "\\" + adqw + "\\");
                                                HttpRuntime.Cache.Insert("CaCheVideo", VideoName, null, DateTime.MaxValue, TimeSpan.FromSeconds(2000));
                                                foreach (var itecd in VideoName) {
                                                    Match madqwe = regex.Match(itecd);
                                                    string adqwe = madqwe.Groups[2].Value;
                                                    adqwe = itecd.Substring(itecd.LastIndexOf(adqwe) + 3);
                                                    if (adqwe.IndexOf('.') < 1) {
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
            }
            context.Response.Write("true");
            context.Response.End();
        }
        public bool IsReusable {
            get {
                return false;
            }
        }
    }
}