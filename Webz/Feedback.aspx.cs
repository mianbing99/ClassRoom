using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace Webz
{
    public partial class Feedback : System.Web.UI.Page
    {
        public string state = string.Empty;
        public string sess = string.Empty;
        protected void Page_Load(object sender, EventArgs e)
        {
            if (Session["Phone"] != null)
            {
                sess = Session["Phone"].ToString();
            }
            if (!string.IsNullOrEmpty(Request.QueryString["class"]))
            {
                state = "class";
            } 
        }
    }
}