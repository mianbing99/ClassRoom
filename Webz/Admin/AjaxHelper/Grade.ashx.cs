using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace Webz.Admin.AjaxHelper
{
    /// <summary>
    /// Grade 的摘要说明
    /// </summary>
    public class Grade : IHttpHandler
    {

        public void ProcessRequest(HttpContext context)
        {
            context.Response.ContentType = "text/plain";
            context.Response.Write("Hello World");
            List<Model.Grade> list = new BLL.CC_GradeBLL().GetAllGradeList();
            string json = JsonConvert.SerializeObject(list);
            context.Response.Write(json);
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