using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using BLL;

namespace Webz.Admin.AjaxHelper
{
    /// <summary>
    /// Roles 的摘要说明
    /// </summary>
    public class Roles : IHttpHandler
    {
        FeedBackBLL fb = new FeedBackBLL();
        public void ProcessRequest(HttpContext context)
        {
            context.Response.ContentType = "text/plain";
            string action = context.Request["action"].ToString();
            switch (action)
            {
                case "Process":
                    Process(context);
                    break;
            }
        }

        private void Process(HttpContext context)
        {
            
        }

        public bool IsReusable
        {
            get
            {
                return false;
            }
        }
    }
}