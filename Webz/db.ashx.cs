using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace Webz {
    /// <summary>
    /// db1 的摘要说明
    /// </summary>
    public class db1 : IHttpHandler {

        public void ProcessRequest(HttpContext context) {
            context.Response.ContentType = "text/plain";

        }

        public bool IsReusable {
            get {
                return false;
            }
        }
    }
}