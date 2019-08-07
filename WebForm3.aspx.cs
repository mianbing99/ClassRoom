using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace Webz {
    public partial class WebForm3 : System.Web.UI.Page {
        protected void Page_Load(object sender, EventArgs e) {
            string filepath = Server.MapPath("http://183.60.136.8:188/mp4/初中/七年级/语文/上册");
            string[] filenames = Directory.GetFiles(filepath);  //获取该文件夹下面的所有文件名
        }
    }
}