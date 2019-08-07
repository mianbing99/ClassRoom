using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace Webz.Admin.AjaxHelper
{
    /// <summary>
    /// Books 的摘要说明
    /// </summary>
    public class Books : IHttpHandler
    {

        public void ProcessRequest(HttpContext context)
        {
            context.Response.ContentType = "text/plain";
            BLL.BooksCataLogBLL BooksCaBll = new BLL.BooksCataLogBLL();
            List<Model.Catalog> YiList = BooksCaBll.SelectNotTid(65); //查询所有 有子级目录的课文
            context.Response.Write(YiList);
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