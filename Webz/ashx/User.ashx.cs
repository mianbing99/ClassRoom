using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.SessionState;

namespace Webz.ashx {
    /// <summary>
    /// User 的摘要说明
    /// </summary>
    public class User : IHttpHandler,IRequiresSessionState{

        public void ProcessRequest(HttpContext context) {
            context.Response.ContentType = "text/plain";
            string action = context.Request["action"].ToString();
            switch (action) {
                case "Login":
                    Login(context);
                    break;
            }
        }
        private void Login(HttpContext context) {
            Model.User Model = new Model.User();
            Model.Phone = context.Request["User"].ToString();
            Model.Pwd = context.Request["Pwd"].ToString();
            string json = string.Empty;
            BLL.UserBLL Bll = new BLL.UserBLL();
            Model = Bll.UserLogin(Model);
            if (Model.UserID != 0) {
                if (Model.Ispass==0)
                {
                    json = "202";
                }
                else
                {
                    json = "200";
                    context.Session["Userid"] = Model.UserID;
                    context.Session["Phone"] = Model.Phone;
                }
                
            } else {
                json = "201";
            }
            context.Response.Write(json);
            context.Response.End();
        }
        public bool IsReusable {
            get {
                return false;
            }
        }
    }
}