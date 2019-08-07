using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace Webz.WebIE
{
    public partial class Video : System.Web.UI.Page
    {
        public string VideoRoute = string.Empty;
        public string str = string.Empty;

        protected void Page_Load(object sender, EventArgs e)
        {
            Response.Write(" <script type=\"text/javascript\">window.alert = function(name){var iframe = document.createElement(\"IFRAME\");iframe.style.display=\"none\"; iframe.setAttribute(\"src\", 'data:text/plain,');document.documentElement.appendChild(iframe);window.frames[0].window.alert(name);iframe.parentNode.removeChild(iframe);}</script>");
            if (Session["Openid"] == null)
            {
                Response.Write("<script type=\"text/javascript\"> alert(\"系统繁忙\");</script>");
                Response.Write(" <script type=\"text/javascript\">  window.location.href =\"https://open.weixin.qq.com/connect/oauth2/authorize?appid=wx0688f75d53cbb9e1&redirect_uri=http://ftv.icoxtech.com&response_type=code&scope=snsapi_base#wechat_redirect\"</script>");
            }
            string state = Request.QueryString["state"].ToString();
            string viid = Request.QueryString["viid"].ToString();
            BLL.CardBLL carBll = new BLL.CardBLL();
            BLL.VideoRouteBLL RoBLL = new BLL.VideoRouteBLL();
            int Viid = Convert.ToInt32(viid);
            List<Model.VideoRoute> VideoRo = RoBLL.SelectByViid(Viid);

            if (state == "0")
            {
                if (Session["Phone"] == null)
                {
                    Response.Write("<script type=\"text/javascript\"> alert(\"请先登录！\");</script>");
                    Response.Write(" <script type=\"text/javascript\"> window.location.href =\"Login.aspx\"</script>");
                    return;
                }
                if (viid == null || viid == "")
                {
                    Response.Write(" <script type=\"text/javascript\"> history.go(-1);</script>");
                    return;
                }

                if (VideoRo.Count == 0)
                {
                    Response.Write("<script type=\"text/javascript\"> alert(\"该课文暂无视频！\");</script>");
                    Response.Write(" <script type=\"text/javascript\"> history.go(-1);</script>");
                }

                for (int i = 0; i < VideoRo.Count; i++)
                {
                    if (i == 0)
                    {
                        VideoRoute = "http://183.60.136.8:188/" + VideoRo[i].Mp4;
                    }
                    if (i == VideoRo.Count - 1)
                    {
                        str += "<a><p class=\"p\" style=\"margin-bottom:200px;\">" + VideoRo[i].ViName + " <input type=\"hidden\" value=\"http://183.60.136.8:188/" + VideoRo[i].Mp4 + "\" /></p></a>";
                    }
                    else
                    {
                        str += "<a><p class=\"p\">" + VideoRo[i].ViName + " <input type=\"hidden\" value=\"http://183.60.136.8:188/" + VideoRo[i].Mp4 + "\" /></p></a>";
                    }

                }
            }
            else
            {
                if (Session["Phone"] == null)
                {
                    Response.Write("<script type=\"text/javascript\"> alert(\"请先登录！\");</script>");
                    Response.Write(" <script type=\"text/javascript\"> window.location.href =\"Login.aspx\"</script>");
                    return;
                }
                if (viid == null || viid == "")
                {
                    Response.Write(" <script type=\"text/javascript\"> history.go(-1);</script>");
                    return;
                }

                string Phone = Session["Phone"].ToString();
                if (!carBll.Select(Phone))
                {
                    Response.Write("<script type=\"text/javascript\"> alert(\"尊敬的用户，此需要激活会员，请先激活会员！\");</script>");
                    Response.Write(" <script type=\"text/javascript\"> window.location.href =\"UserAdd.aspx\"</script>");
                }

                if (VideoRo.Count == 0)
                {
                    Response.Write("<script type=\"text/javascript\"> alert(\"该课文暂无视频！\");</script>");
                    Response.Write(" <script type=\"text/javascript\"> history.go(-1);</script>");
                }
                for (int i = 0; i < VideoRo.Count; i++)
                {
                    if (i == 0)
                    {
                        VideoRoute = "http://183.60.136.8:188/" + VideoRo[i].Mp4;
                    }
                    if (i == VideoRo.Count - 1)
                    {
                        str += "<a><p class=\"p\" style=\"margin-bottom:200px;\">" + VideoRo[i].ViName + " <input type=\"hidden\" value=\"http://183.60.136.8:188/" + VideoRo[i].Mp4 + "\" /></p></a>";
                    }
                    else
                    {
                        str += "<a><p class=\"p\">" + VideoRo[i].ViName + " <input type=\"hidden\" value=\"http://183.60.136.8:188/" + VideoRo[i].Mp4 + "\" /></p></a>";
                    }

                }
            }


        }
    }
}