using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Data;
using System.Web.SessionState;
using BLL;
using Model;

namespace Webz.ashx
{
    /// <summary>
    /// FeedBack 的摘要说明
    /// </summary>
    public class FeedBack : IHttpHandler,IRequiresSessionState
    {
        BLL.FeedBackBLL fbbll = new FeedBackBLL();
        BLL.UserSetBLL ubll = new UserSetBLL();
        Model.FeedBack fbmodel = new Model.FeedBack();

        public void ProcessRequest(HttpContext context)
        {

            context.Response.ContentType = "text/plain";
            string action = context.Request["action"].ToString();
            switch (action)
            {
                case "InsertFback":
                    InsertFback(context);
                    break;
            }
        }
        /// <summary>
        /// 新增意见信息
        /// </summary>
        /// <param name="context"></param>
        private void InsertFback(HttpContext context)
        {
            string json = string.Empty;
            int Userid = Convert.ToInt32(context.Session["Userid"]);//得到登录用户ID
            DataTable dt = ubll.SelectUserSet(Userid);
            fbmodel.Grade = dt.Rows[0]["GrName"].ToString();
            fbmodel.Phone = dt.Rows[0]["Phone"].ToString();
            fbmodel.FeedBackNR = context.Request["FeedbackNR"].ToString();;
            fbmodel.FeedBackDate = DateTime.Now.ToString();
            fbmodel.Processing = "";
            fbmodel.ProcessingName = "";
            fbmodel.Stata = "未处理";
            if (Userid != 0 )//判断是否登录
            {
                //判断是否查询到数据
                if (dt.Rows.Count>0)
                {
                    if (fbbll.InsertFback(fbmodel))
                    {
                        json = "300";
                    }
                    else
                    {
                        json = "301";
                    }
                    //根据登录用户id查询到用户的所有信息，插入意见表时需要使用
                    
                }
                else
                {
                    json = "201";
                }
                //得到信息后传给对应参数
                //新增意见信息

            }
            else
            {
                    //未登录，返回一个结果！
                json = "100";
            }
            context.Response.Write(json);
            context.Response.End();
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