using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using BLL;
using System.Data;
using System.Data.SqlClient;
using Model;

namespace Webz.Admin.AjaxHelper
{
    /// <summary>
    /// VideoResourceManager 的摘要说明
    /// </summary>
    public class VideoResourceManager : IHttpHandler
    {
        BLL.VideoRouteBLL vrbll = new VideoRouteBLL();
        Model.VideoRoute vrmodel = new VideoRoute();
        BLL.FeedBackBLL fb = new FeedBackBLL();
        public void ProcessRequest(HttpContext context)
        {
            context.Response.ContentType = "text/plain";
            string action = context.Request["action"].ToString();
            switch (action)
            {
                case "AddVideoRoute":
                    AddVideoRoute(context);
                    break;
                case "Process":
                    Process(context);
                    break;
            }

        }
        /// <summary>
        /// 新增视频信息
        /// </summary>
        /// <param name="context"></param>
        private void AddVideoRoute(HttpContext context)
        {
            string json = string.Empty;
            string Mp4 = context.Request["mp4"];
            int Viid = Convert.ToInt32(context.Request["ISBN"]);
            string ViName = context.Request["bookname"];
            string RouteAress = context.Request["htv"];
            //string Mp4 = context.Request.Form["mp4"];//表单式提交取值方法【】中是name名
            if (vrbll.insert(RouteAress,Mp4,Viid,ViName))
            {
                json = "200";
            }
            else
            {
                json = "301";
            }
            context.Response.Write(json);
            context.Response.End(); 
        }
        /// <summary>
        /// 处理反馈信息
        /// </summary>
        /// <param name="context"></param>
        private void Process(HttpContext context)
        {
            string json = string.Empty;
            string processing = context.Request["processing"];
            string username = context.Request["username"];
            int FeedBackID = int.Parse(context.Request["FeedBackID"]);
            string zhuangtai = context.Request["stata"];
            string stata = "";
            if (zhuangtai=="0")
            {
                stata = "已处理";
            }
            else if(zhuangtai=="1")
            {
                stata = "反馈上级处理";
            }
            else
            {
                stata = "无效意见";
            }
            if (fb.UpdataFBack(FeedBackID, processing, username,stata))
            {
                json = "1";
            }
            else
            {
                json = "2";
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