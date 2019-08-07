using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using BLL;
using System.Data;
using System.Data.SqlClient;
using Model;
using Newtonsoft.Json;
using Newtonsoft.Json.Linq;

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
                case "videoInfoUpdate":
                    videoInfoUpdate(context);
                    break;
                case "videoPageInfoSelect":
                    videoPageInfoSelect(context);
                    break;
                case "videoInfoSelect":
                    videoInfoSelect(context);
                    break;
                case "deleteVideoInfo":
                    deleteVideoInfo(context);
                    break;
            }

        }

        private void deleteVideoInfo(HttpContext context)
        {
            int vrid = Convert.ToInt32(context.Request["VRID"]);
            int result = BLL.VideoInfoBLL.deleteInfo(vrid);
        }

        public void videoInfoSelect(HttpContext context) 
        {
            int vrid = Convert.ToInt32(context.Request["VRID"]);
            vrmodel = vrbll.queryOneInfo(vrid);
            string model =  JsonConvert.SerializeObject(vrmodel);
            context.Response.Write(model);
        }

        /// <summary>
        /// 修改视频信息
        /// </summary>
        /// <param name="context"></param>
        public void videoInfoUpdate(HttpContext context)
        {
            Model.VideoRoute vr = new VideoRoute();
            vr.VRID = Convert.ToInt32(context.Request.Form["VRID"]);
            vr.Vip = Convert.ToInt32(context.Request.Form["Vip"]);
            vr.State = Convert.ToInt32(context.Request.Form["State"]);
            vr.Mp4 = context.Request.Form["Mp4"];
            vr.HTV = context.Request.Form["HTV"];
            int num = BLL.VideoInfoBLL.updateInfo(vr);
            context.Response.Write(num);
        }

        #region 查询视频路径表

        private void videoPageInfoSelect(HttpContext context)
        {
            int pageCount = 0;
            int count = 0;
            int pageIndex = Convert.ToInt32(context.Request.Form["PageIndex"]);
            int pageSize = Convert.ToInt32(context.Request.Form["PageSize"]);
            string textName = context.Request.Form["TbnName"] == null ? "" : context.Request.Form["TbnName"];
            textName.Trim();
            string gradeId = context.Request.Form["GaID"] == null ? "0" : context.Request.Form["GaID"];
            string subjectId = context.Request.Form["SubI"] == null ? "0" : context.Request.Form["SubI"];
            string publishingId = context.Request.Form["PrID"] == null ? "0" : context.Request.Form["PrID"];
            string state = context.Request.Form["State"] == null ? null : context.Request.Form["State"];
            string vip = context.Request.Form["VIP"] == null ? null : context.Request.Form["VIP"];
            int selectType = Convert.ToInt32(context.Request.Form["PP"]) == 0 ? 0 : Convert.ToInt32(context.Request.Form["PP"]);
            string table = "VideoRoute";
            string column = "ROW_NUMBER() over(order by VideoRoute.viid) viIndex,VideoRoute.ViID,VideoRoute.ViName,VideoRoute.State,VideoRoute.Vip,VideoRoute.Mp4,VideoRoute.HTV,VideoRoute.VRID";
            string conditions = null;
            string condition = null;
            string orderColumn = "VideoRoute.ViID";
            if (!(gradeId.Equals("0")) || !(subjectId.Equals("0")) || !(publishingId.Equals("0")))
                //((!(gradeId.Equals("0") || subjectId.Equals("0") || publishingId.Equals("0"))))
            {
                string subQuery = "select tp.vrid from Temp_PageList tp where";
                string subQueryCondition = null;
                if (Convert.ToInt32(gradeId) > 0)
                {
                    subQueryCondition += string.Format("and tp.GradeID = {0} ", gradeId);
                }
                if (Convert.ToInt32(subjectId) > 0)
                {
                    subQueryCondition += string.Format("and tp.Suid={0} ", subjectId);
                }
                if (Convert.ToInt32(publishingId) > 0)
                {
                    subQueryCondition += string.Format("and tp.PrID={0} ", publishingId);
                }
                if (selectType > 0)
                {
                    if (selectType == 1)
                    {
                        subQueryCondition += "and  匹配='' ";
                    }
                    else if (selectType == 2)
                    {
                        subQueryCondition += "and 未匹配='' ";
                    }
                }
                subQuery += subQueryCondition.Substring(3);
                conditions += string.Format("and vrid in({0}) ", subQuery);
            }
            if (textName != null && textName.Length > 0)
            {
                conditions += string.Format("and VideoRoute.ViName like '%{0}%' ", textName);
                //conditions += "and VideoRoute.ViName like '%' or 1=1 --";
            }
            if (state != null && state.Length > 0)
            {
                conditions += string.Format("and VideoRoute.State={0} ", state);

            }
            if (vip != null && vip.Length > 0)
            {
                conditions += string.Format("and VideoRoute.Vip={0} ", vip);
            }
            if (conditions!=null)
            {
                condition = conditions.Substring(3);
            }
            
            
            List<Model.VideoRoute> list = BLL.VideoInfoBLL.selectAllInfo(pageIndex, pageSize, out count, out pageCount, table, column, condition, orderColumn);
            var str = new
            {
                list = list,
                Count = count,
                PageSizeCount = pageCount
            };
            string json = Newtonsoft.Json.JsonConvert.SerializeObject(str);
            context.Response.Write(json);
        }
        #endregion


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