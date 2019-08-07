using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.SessionState;

namespace Webz.NewFolder1 {
    /// <summary>
    /// UserInfo 的摘要说明
    /// </summary>
    public class UserInfo : IHttpHandler,IRequiresSessionState {

        public void ProcessRequest(HttpContext context) {
            context.Response.ContentType = "text/plain";
            string action = context.Request["action"].ToString();
            switch (action) {
                case "xueduan":
                    Xueduan(context);
                    break;
                case "GrName":
                    Gr(context);
                    break;
                case "PrName":
                    Pr(context);
                    break;
                case "tiyan":
                    tiyan(context);
                    break;
                case "jihuo":
                    jihuo(context);
                    break;
                case "yanzhen":
                    yanzhen(context);
                    break;
                case "baocun":
                    baocun(context);
                    break;
                case "ClassGr":
                    ClassGr(context);
                    break;
                case "iflogin":
                    iflogin(context);
                    break;
                case "sejihuo":
                    sejihuo(context);
                    break;
                case "pinglun":
                    pinglun(context);
                    break;
            }
        }
        /// 根据选择学段查询相应学段的年级信息
        /// 
        /// </summary>
        /// <param name="context"></param>
        private void Xueduan(HttpContext context) {
            int ID = Convert.ToInt32(context.Request["id"]);
            BLL.GradeBLL Grbll = new BLL.GradeBLL();
            List<Model.Grade> GrList = new List<Model.Grade>();
            GrList = Grbll.SeleteName(ID);
            string json = string.Empty;
            for (int i = 0; i < GrList.Count; i++) {
                if (GrList.Count == 1) {
                    json += "{\"nianji\":\"" + GrList[i].GrName.Trim() + "\",\"ID\":\"" + GrList[i].Grid + "\"}";
                } else {
                    if (i == 0) {
                        json += "[{\"nianji\":\"" + GrList[i].GrName.Trim() + "\",\"ID\":\"" + GrList[i].Grid + "\"},";
                    } else if (i == GrList.Count - 1) {
                        json += "{\"nianji\":\"" + GrList[i].GrName.Trim() + "\",\"ID\":\"" + GrList[i].Grid + "\"}]";
                    } else {
                        json += "{\"nianji\":\"" + GrList[i].GrName.Trim() + "\",\"ID\":\"" + GrList[i].Grid + "\"},";
                    }
                }
            }
            context.Response.Write(json);
            context.Response.End();
        }
        /// 根据年级 查询相关出版社信息
        /// 
        /// </summary>
        /// <param name="context"></param>
        private void Gr(HttpContext context) {
            int Grid = Convert.ToInt32(context.Request["GrName"]);
            BLL.PressBLL bll = new BLL.PressBLL();
            List<Model.Press> prlist = new List<Model.Press>();
            prlist = bll.SelectList();
            string json = string.Empty;
            for (int i = 0; i < prlist.Count; i++) {
                if (prlist.Count == 1) {
                    json = "[{\"Prs\":\"" + prlist[i].PrName.Trim() + "\",\"ID\":\"" + prlist[i].Prid + "\"}]";
                } else {
                    if (i == 0) {
                        json += "[{\"Prs\":\"" + prlist[i].PrName.Trim() + "\",\"ID\":\"" + prlist[i].Prid + "\"},";
                    } else if (i == prlist.Count - 1) {
                        json += "{\"Prs\":\"" + prlist[i].PrName.Trim() + "\",\"ID\":\"" + prlist[i].Prid + "\"}]";
                    } else {
                        json += "{\"Prs\":\"" + prlist[i].PrName.Trim() + "\",\"ID\":\"" + prlist[i].Prid + "\"},";
                    }
                }
            }
            context.Response.Write(json);
            context.Response.End();
        }
        /// 根据出版社查询相关的学期信息
        /// 
        /// </summary>
        /// <param name="context"></param>
        private void Pr(HttpContext context) {
            int Grid = Convert.ToInt32(context.Request["GrName"]);
            int Prid = Convert.ToInt32(context.Request["PrName"]);
            BLL.BooksBLL bll = new BLL.BooksBLL();
            List<Model.TextBooks> Bolist = new List<Model.TextBooks>();
            Bolist = bll.SelectByGrid_Prid(Prid, Grid);
            string json = string.Empty;
            for (int i = 0; i < Bolist.Count; i++) {
                if (Bolist[i].Semester.Trim() == "") {
                    Bolist[i].Semester = "全一册";
                }
                if (Bolist.Count == 1) {
                    json = "[{\"Sem\":\"" + Bolist[i].Semester.Trim() + "\"}]";
                } else {
                    if (i == 0) {
                        json += "[{\"Sem\":\"" + Bolist[i].Semester.Trim() + "\"},";
                    } else if (i == Bolist.Count - 1) {
                        json += "{\"Sem\":\"" + Bolist[i].Semester.Trim() + "\"}]";
                    } else {
                        json += "{\"Sem\":\"" + Bolist[i].Semester.Trim() + "\"},";
                    }
                }

            }
            context.Response.Write(json);
            context.Response.End();
        }
        private void yanzhen(HttpContext context) {
            string Phone = context.Request["Phone"].ToString();
            string Pwd = context.Request["Pwd"].ToString();
            BLL.UserBLL UserBll = new BLL.UserBLL();
            string json = string.Empty;
            Model.User UsModel = new Model.User();
            UsModel.Phone = Phone;
            UsModel.Pwd = Pwd;
            Model.User mo = UserBll.UserLogin(UsModel);
            if (mo.UserID==0) {
                json = "null";
            }else{
                json = "true";
            }
            context.Response.Write(json);
            context.Response.End();
        }
        private void tiyan(HttpContext context) {

            string Phone = context.Request["Phone"].ToString();
            string Pwd = context.Request["Pwd"].ToString();
            string json = string.Empty;
            if (Zhuce(context, Phone, Pwd)) {
                json = "true";
                context.Session["Phone"] = Phone;
            } else {
                json = "false";
            }
            context.Response.Write(json);
            context.Response.End();
        }
        private void jihuo(HttpContext context) {
            string Phone = context.Request["Phone"].ToString();
            string Pwd = context.Request["Pwd"].ToString();
            string User = context.Request["User"].ToString();
            string PassWord = context.Request["PassWord"].ToString();
            string json = string.Empty;
            Model.User UsModel = new Model.User();
            UsModel.Phone = Phone;
            UsModel.Pwd = Pwd;
            if (Zhuce(context, Phone, Pwd)) {
                context.Session["Phone"] = Phone;
                BLL.UserBLL UserBll = new BLL.UserBLL();
                UsModel = UserBll.UserLogin(UsModel);
                BLL.CardBLL CarBll = new BLL.CardBLL();
                json = CarBll.Update(User, PassWord, UsModel.UserID);
            } else {
                json = "系统繁忙,请稍后再试";
            }
            context.Response.Write(json);
            context.Response.End();
        }
        private void sejihuo(HttpContext context) {
            var Phone = string.Empty;
            if (context.Session["Phone"] != null) {
                Phone = context.Session["Phone"].ToString();
            }
            string User = context.Request["User"].ToString().ToUpper();
            string PassWord = context.Request["PassWord"].ToString();
            string json = string.Empty;
            Model.User UsModel = new Model.User();
            BLL.UserBLL UserBll = new BLL.UserBLL();
            BLL.CardBLL CarBll = new BLL.CardBLL();
            int Userid = UserBll.SelectUseridByPhone(Phone);
            if (Userid != 0) {
                json = CarBll.Update(User, PassWord, Userid);
            } else {
                json = "系统繁忙,请稍后再试";
            }
            context.Response.Write(json);
            context.Response.End();
        }
        private void ClassGr(HttpContext context) {
            string nianji = context.Request["nianji"].ToString();
           string ga = nianji.Replace("年级","");
           BLL.SubjectBLL Subll = new BLL.SubjectBLL();
           string json = string.Empty;
           if (ga != nianji) {
               json = Herp.JsonHelper.SerializeObject(Subll.Select(nianji));
           } else {
               json = Herp.JsonHelper.SerializeObject(Subll.SelectGaozhong());
           }
           context.Response.Write(json);
           context.Response.End();
        }
        private void baocun(HttpContext context) {
            string json = string.Empty;
            if (context.Request["nianji"] == null || context.Request["kemu"]==null) {
                json = "190";
                context.Response.Write(json);
                context.Response.End();
                return;
            }
            if(context.Session["Phone"]==null){
                json = "100";
                context.Response.Write(json);
                context.Response.End();
                return;
            }
            string nianji = context.Request["nianji"].ToString();
            string kemu = context.Request["kemu"].ToString();
            int Userid = Convert.ToInt32(context.Session["Userid"]);
            BLL.UserSetBLL Bll = new BLL.UserSetBLL();
            if (Bll.Insert(nianji, kemu, Userid)) {
                json = "200";
            } else {
                json = "201";
            }
            context.Response.Write(json);
            context.Response.End();
        }
        /// <summary>
        /// 评论 、、未写完
        /// </summary>
        /// <param name="context"></param>
        private void pinglun(HttpContext context) {
            string text = context.Request["text"].ToString();
            string Phone = string.Empty;
            string json = string.Empty;
            if (context.Session["Phone"] != null) {
                Phone = context.Session["Phone"].ToString();
            }
            BLL.UserBLL UsBLL = new BLL.UserBLL();
            BLL.CommentBLL ComBll = new BLL.CommentBLL();
            int Userid = UsBLL.SelectUseridByPhone(Phone);
            if (Userid == 0) {
                json = "系统繁忙";//刷新页面  获取Session 如果没有 提示登录
            } else {
                if (ComBll.Insert(text, Userid)) {
                    json = "提交成功";
                }
            }
        }
        private void iflogin(HttpContext context) {
            string json = string.Empty;
            if (context.Session["Phone"] != null) {
                json = context.Session["Phone"].ToString();
            }
            context.Response.Write(json);
            context.Response.End();
        }
       
        private bool Zhuce(HttpContext context,string Phone,string Pwd) {
            
            BLL.UserBLL UserBll = new BLL.UserBLL();
            Model.User Model = new Model.User();
            Model.Phone = Phone;
            Model.Pwd = Pwd;
            Model.CreateTime = DateTime.Now;
            Model.DeviceID = "";
            if (context.Session["Openid"] != null) {
                Model.OpenID = context.Session["Openid"].ToString();
            }
            return UserBll.UserAdd(Model);
        }

       
        public bool IsReusable {
            get {
                return false;
            }
        }
    }
}