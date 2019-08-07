using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Script.Serialization;
using BLL;
using System.IO;
using Newtonsoft.Json;
using Model;
using NPOI.XSSF.UserModel;
using NPOI.SS.UserModel;
using System.Data;

namespace Webz.Admin.AjaxHelper
{
    /// <summary>
    /// Ajax 的摘要说明
    /// </summary>
    public class Ajax : IHttpHandler
    {
        //Microsoft.Office.Interop.Excel.Application excel = new Microsoft.Office.Interop.Excel.Application();
        public void ProcessRequest(HttpContext context)
        {
            BLL.CardBLL cbll = new CardBLL();
            BLL.FeedBackBLL fbbll = new FeedBackBLL();
            BLL.BooksCataLogBLL bcbll = new BooksCataLogBLL();
            BLL.AdminsBLL abll = new AdminsBLL();
            string type = null;
            JavaScriptSerializer jss = new JavaScriptSerializer();
            if (context.Request.Form["type"] != null)
            {
                type = context.Request.Form["type"];
                if (type == "AllList")
                {
                    //var data = { type: "AllList", Pageindex: Pageindex, PageSize: PageSize, TbnName: TbnName, GaID: GaID, SubI: SubI, PrID: PrID, PP: PP, Judge: Judge  };
                    int PageSizeCount = 0;
                    int Count = 0;
                    int Pageindex = Convert.ToInt32(context.Request.Form["Pageindex"]);
                    int PageSize = Convert.ToInt32(context.Request.Form["PageSize"]);
                    string TbnName = context.Request.Form["TbnName"] == null ? "" : context.Request.Form["TbnName"];

                    string GaID = context.Request.Form["GaID"] == null ? "0" : context.Request.Form["GaID"];
                    string SubI = context.Request.Form["SubI"] == null ? "0" : context.Request.Form["SubI"];
                    string PrID = context.Request.Form["PrID"] == null ? "0" : context.Request.Form["PrID"];
                    int PP = Convert.ToInt32(context.Request.Form["PP"]) == 0 ? 0 : Convert.ToInt32(context.Request.Form["PP"]);
                    int Judge = Convert.ToInt32(context.Request.Form["Judge"]) == 0 ? 0 : Convert.ToInt32(context.Request.Form["Judge"]);

                    List<Model.PageList> list = new CC_PageListBLL().SelectPageList(out PageSizeCount, out Count, Pageindex, PageSize, TbnName, GaID, SubI, PrID, PP, Judge);
                    var str = new
                    {
                        PageSizeCount = PageSizeCount,
                        Count = Count,
                        list = list
                    };

                    string json = jss.Serialize(str);
                    context.Response.Write(json);
                }
                else if (type == "CardList")//注册统计数据
                {
                    int Count = 0;
                    int Pageindex = Convert.ToInt32(context.Request.Form["Pageindex"]);
                    int PageSize = Convert.ToInt32(context.Request.Form["PageSize"]);
                    string Table = " [user] u left join [Card] c on u.Userid=c.Userid ";//表名
                    string Column = " u.Userid,u.Phone,u.RegisterTime,C.Account,C.[PassWord],C.SN,C.ActivationTime,C.OutTime ";//查询列
                    string OrderColumn = " U.RegisterTime DESC ";//根据日期降序排列
                    //拼接SQL条件
                    string Registereddate = context.Request.Form["Registereddate"].ToString();
                    Registereddate = " Convert(varchar,u.RegisterTime,120) like '%" + Registereddate + "%'";
                    string Activationdate = context.Request.Form["Activationdate"].ToString();
                    Activationdate = Activationdate == "" ? "" : " and Convert(varchar,c.ActivationTime,120) like '%" + Activationdate + "%'";
                    string Outdate = context.Request.Form["Outdate"].ToString();
                    Outdate = Outdate == "" ? "" : " and Convert(varchar,c.OutTime,120) like '%" + Outdate + "%'";
                    string Phone = context.Request.Form["Phone"].ToString();
                    Phone = Phone == "" ? "" : " and u.Phone like '%" + Phone + "%'";
                    string Account = context.Request.Form["Account"].ToString();
                    Account = Account == "" ? "" : " and C.Account like '%" + Account + "%'";
                    string Pwd = context.Request.Form["Pwd"].ToString();
                    Pwd = Pwd == "" ? "" : " and C.[PassWord] like '%" + Pwd + "%'";
                    string conditions = Registereddate + Activationdate + Outdate + Phone + Account + Pwd;

                    List<Model.PageList> list = cbll.UserList( out Count, Pageindex, PageSize,Table,Column,OrderColumn,conditions);
                    var str = new
                    {
                        Count = Count,
                        list = list
                    };

                    string json = jss.Serialize(str);
                    context.Response.Write(json);

                }
                else if (type == "FeedBackList")//反馈信息
                {
                    int currPage = Convert.ToInt32(context.Request.Form["Pageindex"]);
                    int pageSize = Convert.ToInt32(context.Request.Form["PageSize"]);
                    int Count = 0;
                    string stata = context.Request.Form["Stata"].ToString();
                    stata = stata == "请选择处理状态" ? "" : " and Stata='" + stata+"'";//下拉框没选默认为空
                    string conditionss = context.Request.Form["Startdate"].ToString();
                    conditionss = conditionss == "" ? "FeedBackDate>''" : " FeedBackDate>'" + conditionss+"'";//没选日期默认为“”=全部
                    string enddate = context.Request.Form["Enddate"].ToString();
                    enddate = enddate == "" ? "" : " and FeedBackDate<'" + enddate+"'";//没选日期默认为“”=全部
                    string Table = "FeedBack";
                    string conditions = conditionss + enddate + stata;//没条条件默认查全部

                    string OrderColumn = "FeedBackID";
                    string tiaojian = string.Format("{0} and {1}",Table,OrderColumn);
                    List<Model.FeedBack> list = fbbll.SelectPageResult(currPage, Table, conditions, OrderColumn, out Count, pageSize);
                    var str = new
                    {
                        Count = Count,
                        list=list
                    };
                    string json = jss.Serialize(str);
                    context.Response.Write(json);
                }
                else if (type == "CatalogList")//教材信息
                {
                    int currPage = Convert.ToInt32(context.Request.Form["Pageindex"]);
                    int pageSize = Convert.ToInt32(context.Request.Form["PageSize"]);
                    int Count = 0;
                    string ISBN = context.Request.Form["ISBN"].ToString();
                    ISBN = ISBN == "" ? " t.ISBN like '%' " : "  t.ISBN like '%" + ISBN + "%' ";
                    string BooksName = context.Request.Form["BooksName"].ToString();
                    if (BooksName!="" & BooksName!=null)
                    {
                        BooksName = BooksName.Substring(1);//一对中括号是模糊查询关键字，所以去掉第一个中括号
                    }
                    BooksName = BooksName == "" ? " and t.BooksName like '%' " : "  and t.BooksName like '%"+ BooksName +"%' ";//没条件默认查全部
                    string CaName = context.Request.Form["CaName"].ToString();
                    CaName = CaName == "" ? " and b.CaName like '%' " : " and b.CaName like '%" +CaName+ "%' ";
                    string Table = "BooksCatalog b left join  TextBooks t on b.TextID=t.TextID";
                    string Column = " b.CaID,t.ISBN,t.BooksName,b.CaName ";
                    string conditions = ISBN + BooksName + CaName;//没条条件默认查全部

                    string OrderColumn = "b.CaID";
                    List<Model.BooksCatalog> list = bcbll.CatalogList(currPage, Table,Column, conditions, OrderColumn, out Count, pageSize);
                    var str = new
                    {
                        Count = Count,
                        list = list
                    };
                    string json = jss.Serialize(str);
                    context.Response.Write(json);
                }
                else if (type=="UserManageList")//用户管理数据
                {
                    int currPage = Convert.ToInt32(context.Request.Form["Pageindex"]);
                    int pageSize = Convert.ToInt32(context.Request.Form["PageSize"]);
                    int Count = 0;
                    string AdminName = context.Request.Form["User"].ToString();
                    AdminName = AdminName == "" ? " a.AdminName like '%' " : "  a.AdminName like '%" + AdminName + "%' ";
                    
                    string RoleName = context.Request.Form["Roles"].ToString();
                    RoleName = RoleName == "" ? " " : " and r.RoleName like '%" +RoleName+ "%' ";
                    string Table = " Admins a left join roles r on a.RolesID=r.RolesID ";
                    string Column = " a.AdminID,a.AdminName,r.RoleName ";
                    string conditions = AdminName + RoleName;//没条条件默认查全部

                    string OrderColumn = "a.AdminID";
                    List<Model.Admins> list = abll.AdminsList(currPage, Table,Column, conditions, OrderColumn, out Count, pageSize);
                    var str = new
                    {
                        Count = Count,
                        list = list
                    };
                    string json = jss.Serialize(str);
                    context.Response.Write(json);
                }
                else if (type=="AdminDeleteByID")//根据adminid删除管理员信息
                {
                    
                    int AdminID = Convert.ToInt32(context.Request.Form["AdminID"]);
                    if (abll.AdminDeleteByID(AdminID))
                    {
                        context.Response.Write(true);
                    }
                    else
                    {
                        context.Response.Write(false);
                    }
                }
                else if (type=="CardExport")//导出注册统计数据
                {
                    int Count = 0;
                    int Pageindex = Convert.ToInt32(context.Request.Form["Pageindex"]);
                    int PageSize = Convert.ToInt32(context.Request.Form["PageSize"]);
                    string Table = " [user] u left join [Card] c on u.Userid=c.Userid ";//表名
                    string Column = " u.Userid,u.Phone,u.RegisterTime,C.Account,C.[PassWord],C.SN,C.ActivationTime,C.OutTime ";//查询列
                    string OrderColumn = " U.RegisterTime DESC ";//根据日期降序排列
                    //拼接SQL条件
                    string Registereddate = context.Request.Form["Registereddate"].ToString();
                    Registereddate = " Convert(varchar,u.RegisterTime,120) like '%" + Registereddate + "%'";
                    string Activationdate = context.Request.Form["Activationdate"].ToString();
                    Activationdate = Activationdate == "" ? "" : " and Convert(varchar,c.ActivationTime,120) like '%" + Activationdate + "%'";
                    string Outdate = context.Request.Form["Outdate"].ToString();
                    Outdate = Outdate == "" ? "" : " and Convert(varchar,c.OutTime,120) like '%" + Outdate + "%'";
                    string Phone = context.Request.Form["Phone"].ToString();
                    Phone = Phone == "" ? "" : " and u.Phone like '%" + Phone + "%'";
                    string Account = context.Request.Form["Account"].ToString();
                    Account = Account == "" ? "" : " and C.Account like '%" + Account + "%'";
                    string Pwd = context.Request.Form["Pwd"].ToString();
                    Pwd = Pwd == "" ? "" : " and C.[PassWord] like '%" + Pwd + "%'";
                    string conditions = Registereddate + Activationdate + Outdate + Phone + Account + Pwd;

                    List<Model.PageList> list = cbll.UserList(out Count, Pageindex, PageSize, Table, Column, OrderColumn, conditions);
                    int fl = 0;
                    //导出为EX表格
                    if (list.Count > 0)
                    {
                        if (CardEX1(list) == 1)
                        {
                            context.Response.Write("导出成功,将会自动为你打开！");
                        }
                        else
                        {
                            context.Response.Write("导出失败");
                        }

                    }
                    else
                    {
                        context.Response.Write("当前页没有可用数据！");
                    }

                }
                else if (type == "CurrentPageExport")
                {
                    int PageSizeCount = 0;
                    int Count = 0;
                    int Pageindex = Convert.ToInt32(context.Request.Form["Pageindex"]);
                    int PageSize = Convert.ToInt32(context.Request.Form["PageSize"]);
                    string TbnName = context.Request.Form["TbnName"] == null ? "" : context.Request.Form["TbnName"];

                    string GaID = context.Request.Form["GaID"] == null ? "0" : context.Request.Form["GaID"];
                    string SubI = context.Request.Form["SubI"] == null ? "0" : context.Request.Form["SubI"];
                    string PrID = context.Request.Form["PrID"] == null ? "0" : context.Request.Form["PrID"];
                    int PP = Convert.ToInt32(context.Request.Form["PP"]) == 0 ? 0 : Convert.ToInt32(context.Request.Form["PP"]);
                    int Judge = Convert.ToInt32(context.Request.Form["Judge"]) == 0 ? 0 : Convert.ToInt32(context.Request.Form["Judge"]);
                    //当前页数据
                    List<Model.PageList> list = new CC_PageListBLL().SelectPageList(out PageSizeCount, out Count, Pageindex, PageSize, TbnName, GaID, SubI, PrID, PP, Judge);
                    int fl = 0;
                    //导出为EX表格
                    if (list.Count > 0)
                    {
                        if (EX(list) == 1)
                        {
                            context.Response.Write("导出成功,将会自动为你打开！");
                        }
                        else
                        {
                            context.Response.Write("导出失败");
                        }

                    }
                    else
                    {
                        context.Response.Write("当前页没有可用数据！");
                    }





                }
                else if (type == "AllEX")
                {
                    List<Model.PageList> list = new BLL.CC_PageListBLL().GetAllPageList();

                    if (EX(list) > 0)
                    {
                        context.Response.Write("导出所有已完成");
                    }
                    else
                    {
                        context.Response.Write("导出失败");
                    }
                }
                else if (type == "BDing")//绑定
                {
                    try
                    {

                        int id = Convert.ToInt32(context.Request.Form["id"]);
                        //获取PageList单条信息
                        Model.PageList OnePl = new CC_PageListBLL().GetIdOnePageList(id);
                        //获取Test路径信息,OnePl.RoID路径ID
                        Model.Test test = new CC_TestBLL().GetIdOneTest(OnePl.VRID);
                        int i = new CC_VideoRouteBLL().AddVr(test, OnePl.ViID);
                        context.Response.Write("1");
                    }
                    catch (Exception)
                    {
                        //绑定出错
                        context.Response.Write("-1");
                    }

                }
                else if (type == "ShuaXdada")//刷新
                {
                    try
                    {
                        int i = new CC_PageListBLL().RefreshPageList();
                        context.Response.Write(i);
                    }
                    catch (Exception)
                    {
                        context.Response.Write("-10");
                    }

                }
                else if (type == "JBDing")//解绑
                {
                    try
                    {
                        int id = Convert.ToInt32(context.Request.Form["id"]);
                        //获取PageList单条信息
                        Model.PageList OnePl = new CC_PageListBLL().GetIdOnePageList(id);
                        int i = new CC_VideoRouteBLL().DeleteVr(OnePl.VRID);
                        context.Response.Write("1");
                    }
                    catch (Exception)
                    {
                        context.Response.Write("-1");
                    }


                }
                else if (type=="TestFenYe")
                {
                    //Pageindex: Pageindex, PageSize: PageSize, TName: TName 
                    int PageSize=Convert.ToInt32(context.Request.Form["PageSize"])!=0?Convert.ToInt32(context.Request.Form["PageSize"]):10;
                    int Pageindex = Convert.ToInt32(context.Request.Form["Pageindex"]) != 0 ? Convert.ToInt32(context.Request.Form["Pageindex"]) : 1;
                    string TName = context.Request.Form["TName"]!=null?context.Request.Form["TName"]:"%";
                    string Kemu = context.Request.Form["Kemu"] != null ? context.Request.Form["Kemu"] : "%";
                    if (Kemu!="%")
                    {
                        Kemu = Kemu.Substring(1, 2);
                    }
                    int Count = 0;
                    List<Model.Test> list = new CC_TestBLL().TestPage(out Count, PageSize, Pageindex, TName, Kemu);
                    var str=new 
                    {
                        Count=Count,
                        list=list
                    };
                    string json = jss.Serialize(str);
                    context.Response.Write(json);
                }
                else if (type=="OneBD")//模糊绑定
                {
                    //type: "OneBD", id: id, TestId: TestId
                    //Pagelist的ID
                    int id =Convert.ToInt32( context.Request.Form["id"]);
                    int testid = Convert.ToInt32(context.Request.Form["TestId"]);

                    Model.PageList pl = new BLL.CC_PageListBLL().GetIdOnePageList(id);
                    Model.Test ts = new BLL.CC_TestBLL().GetIdOneTest(testid);
                    if (new BLL.CC_VideoRouteBLL().RepeatCountVR(ts,pl)>0)
                    {
                        context.Response.Write("2");
                    }
                    else
                    {
                        int i = new BLL.CC_VideoRouteBLL().AddVr(ts, pl.ViID);
                        context.Response.Write("1");
                    }


                }
                else if (type=="MHJB")//模糊解绑
                {
                    int id = Convert.ToInt32(context.Request.Form["id"]);
                    int testid = Convert.ToInt32(context.Request.Form["TestId"]);

                    Model.PageList pl = new BLL.CC_PageListBLL().GetIdOnePageList(id);
                    Model.Test ts = new BLL.CC_TestBLL().GetIdOneTest(testid);
                    if (new BLL.CC_VideoRouteBLL().RepeatCountVR(ts, pl) > 0)
                    {
                        int i = new CC_VideoRouteBLL().DeleteVr(pl.VRID);
                        if (i>0)
                        {
                            context.Response.Write("1");
                        }
                    }
                    else
                    {
                        context.Response.Write("2");
                    }

                }
                else if (type == "videoPageInfoSelect")
                {
                    videoPageInfoSelect(context);
                }
                else if (type == "videoInfoUpdate")
                {
                    videoInfoUpdate(context);
                }
                
                

            }






        }

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

        private void videoPageInfoSelect(HttpContext context) {
            int pageCount = 0;
            int count = 0;
            int pageIndex = Convert.ToInt32(context.Request.Form["PageIndex"]);
            int pageSize = Convert.ToInt32(context.Request.Form["PageSize"]);
            string textName = context.Request.Form["TbnName"] == null ? "" : context.Request.Form["TbnName"];
            textName.Trim();
            string gradeId = context.Request.Form["GaID"] == null ? "0" : context.Request.Form["GaID"];
            string subjectId = context.Request.Form["SubI"] == null ? "0" : context.Request.Form["SubI"];
            string publishingId = context.Request.Form["PrID"] == null ? "0" : context.Request.Form["PrID"];
            string status = context.Request.Form["status"] == null ? null: context.Request.Form["status"];
            string vip = context.Request.Form["vip"] == null ? null : context.Request.Form["vip"];
            int selectType = Convert.ToInt32(context.Request.Form["PP"]) == 0 ? 0 : Convert.ToInt32(context.Request.Form["PP"]);
            string table = null;
            string column = "ROW_NUMBER() over(order by VideoRoute.viid) viIndex,VideoRoute.ViID,VideoRoute.ViName,VideoRoute.State,VideoRoute.Vip,VideoRoute.Mp4,VideoRoute.HTV,VideoRoute.VRID";
            string conditions = null;
            string condition = null;
            string orderColumn = "VideoRoute.ViID";
            if(Convert.ToInt32(gradeId)>0)
            {
                conditions+=string.Format("and tp.GradeID = {0} ",gradeId);
            }
            if(Convert.ToInt32(subjectId)>0)
            {
                conditions+=string.Format("and tp.Suid={0} ",subjectId);
            }
            if(Convert.ToInt32(publishingId)>0)
            {
                conditions+=string.Format("and tp.PrID={0} ",publishingId);
            }
            if(textName!=null && textName.Length>0)
            {
                conditions += string.Format("and VideoRoute.ViName like '%{0}%' ", textName);
            }
            if (status != null && status.Length>0) 
            {
                conditions += string.Format("and VideoRoute.State={0} ", status);
            
            }
            if(vip!=null && vip.Length>0)
            {
                conditions += string.Format("and VideoRoute.Vip={0} ",vip);
            }
            if(selectType>0)
            {
                if(selectType==1)
                {
                    conditions += "and VideoRoute.VRID in(select VRID from Temp_PageList  where 匹配='') ";
                }else if(selectType==2)
                {
                    conditions += "and VideoRoute.VRID in(select VRID from Temp_PageList  where 未匹配='') ";
                }
            }
            if (conditions == null)
            {
                table = "VideoRoute";
            }
            else 
            {
                table = "VideoRoute left join Temp_PageList tp on tp.VRID=VideoRoute.VRID";
                condition = conditions.Substring(3);
            }

            List<Model.VideoRoute> list = BLL.VideoInfoBLL.selectAllInfo(pageIndex, pageSize, out count, out pageCount, table, column, condition, orderColumn);
            var str = new {
                list = list,
                Count = count,
                PageSizeCount = pageCount
            };
            string json = JsonConvert.SerializeObject(str);
            context.Response.Write(json);
        }


        #endregion


        #region EX表格导出视频信息
        /// <summary>
        /// EX表格导出视频信息
        /// </summary>
        /// <param name="list"></param>
        /// <returns></returns>
        public int EX(List<Model.PageList> list)
        {
            try
            {
                System.Reflection.Missing miss = System.Reflection.Missing.Value;
                //实例化一个Excel.Application对象
                Microsoft.Office.Interop.Excel.Application excel = new Microsoft.Office.Interop.Excel.Application();
                excel.Application.Workbooks.Add(true);
                excel.Visible = false;//若是true，则在导出的时候会显示EXcel界面。
                Microsoft.Office.Interop.Excel.Workbooks books = (Microsoft.Office.Interop.Excel.Workbooks)excel.Workbooks;
                Microsoft.Office.Interop.Excel.Workbook book = (Microsoft.Office.Interop.Excel.Workbook)(books.Add(miss));
                Microsoft.Office.Interop.Excel.Worksheet sheet = (Microsoft.Office.Interop.Excel.Worksheet)book.ActiveSheet;
                string[] str = { "书名", "年级", "册", "科目", "目录", "已匹配路径", "未匹配路径", "出版社" };
                for (int i = 0; i < str.Length; i++)
                {
                    //首列
                    excel.Cells[1, i + 1] = str[i];
                }
                for (int i = 0; i < list.Count(); i++)
                {
                    //列，行

                    excel.Cells[i + 2, 1] = list[i].BooksName;
                    excel.Cells[i + 2, 2] = list[i].GrName;
                    excel.Cells[i + 2, 3] = list[i].Semester;
                    excel.Cells[i + 2, 4] = list[i].SuName;
                    excel.Cells[i + 2, 5] = list[i].ViName;
                    excel.Cells[i + 2, 6] = list[i].匹配;
                    excel.Cells[i + 2, 7] = list[i].未匹配;
                    excel.Cells[i + 2, 8] = list[i].PrName;

                }
                sheet.Columns.EntireColumn.AutoFit();
                string time = DateTime.Now.ToString("yyyyMMddHHmmss");
                sheet.SaveAs("E:\\" + time + ".xlsx", miss, miss, miss, miss, miss, Microsoft.Office.Interop.Excel.XlSaveAsAccessMode.xlNoChange, miss, miss, miss);
                book.Close(false, miss, miss);
                books.Close();
                excel.Quit();
                System.Runtime.InteropServices.Marshal.ReleaseComObject(sheet);
                System.Runtime.InteropServices.Marshal.ReleaseComObject(book);
                System.Runtime.InteropServices.Marshal.ReleaseComObject(books);
                System.Runtime.InteropServices.Marshal.ReleaseComObject(excel);
                GC.Collect();
                System.Diagnostics.Process.Start("E:\\" + time + ".xlsx");
                return 1;
            }
            catch (Exception)
            {
                return 0;
            }



        }
        #endregion



        #region NPOI表格导出



        /// <summary>
        /// NPOI表格导出
        /// </summary>
        /// <param name="list"></param>
        /// <returns></returns>
        public int CardEX1(List<Model.PageList> list)
        {
            try
            {
                //获取当前项目的路径
                string filepaht = AppDomain.CurrentDomain.BaseDirectory;
                //获取当前日期作为表名称
                string time = DateTime.Now.ToString("yyyyMMddHHmmss");
                //判断是否存在文件夹名称，没有的话新建一个
                if (!Directory.Exists(filepaht + "EXCEL"))
                {
                    Directory.CreateDirectory(filepaht + "EXCEL");
                }
                string url = filepaht + @"EXCEL\注册统计表" + time + ".xlsx";
                using (Stream fs = new FileStream(url, FileMode.Create, FileAccess.Write))
                {
                    //创建一个文件
                    XSSFWorkbook work = new XSSFWorkbook();
                    //创建一个sheet并命名
                    ISheet sheet = work.CreateSheet("注册统计表");
                    //添加表头 数 据
                    IRow row = sheet.CreateRow(0);
                    //创建sheet中的一行,0表示第一行

                    //下面的cell是指单元格，表示上面刚刚创建的那一行中的单元格
                    //其中0,1,2表示，这一行横着数第几个单元格，索引从0开始
                    ICell cell1 = row.CreateCell(0, CellType.String);
                    cell1.SetCellValue("ID");

                    ICell cell2 = row.CreateCell(1, CellType.String);
                    cell2.SetCellValue("手机号");

                    ICell cell3 = row.CreateCell(2, CellType.String);
                    cell3.SetCellValue("VIP账号");

                    ICell cell4 = row.CreateCell(3, CellType.String);
                    cell4.SetCellValue("VIP密码");

                    ICell cell5 = row.CreateCell(4, CellType.String);
                    cell5.SetCellValue("SN");

                    ICell cell6 = row.CreateCell(5, CellType.String);
                    cell6.SetCellValue("注册日期");

                    ICell cell7 = row.CreateCell(6, CellType.String);
                    cell7.SetCellValue("激活日期");

                    ICell cell8 = row.CreateCell(7, CellType.String);
                    cell8.SetCellValue("结束日期");

                    //添加数据，相关注释参考 表头
                    for (int i = 0; i < list.Count(); i++)
                    {
                        row = sheet.CreateRow(i + 1);

                        cell1 = row.CreateCell(0, CellType.String);
                        cell1.SetCellValue(list[i].Userid);

                        cell2 = row.CreateCell(1, CellType.String);
                        cell2.SetCellValue(list[i].Phone);

                        cell3 = row.CreateCell(2, CellType.String);
                        cell3.SetCellValue(list[i].Account);

                        cell4 = row.CreateCell(3, CellType.String);
                        cell4.SetCellValue(list[i].PassWord);

                        cell5 = row.CreateCell(4, CellType.String);
                        cell5.SetCellValue(list[i].SN);

                        cell6 = row.CreateCell(5, CellType.String);
                        cell6.SetCellValue(list[i].RegisterTime);

                        cell7 = row.CreateCell(6, CellType.String);
                        cell7.SetCellValue(list[i].ActivationTime);

                        cell8 = row.CreateCell(7, CellType.String);
                        cell8.SetCellValue(list[i].OutTime);
                    }
                    work.Write(fs);
                }
                System.Diagnostics.Process.Start(url);

                //客户端导出
                //FileStream fileopen = new FileStream(url, FileMode.Open);
                //byte[] bytes = new byte[(int)fileopen.Length];
                //fileopen.Read(bytes, 0, bytes.Length);
                //System.Web.HttpContext.Current.Response.ContentType = "application/octet-stream";
                ////页面下载时的文件名称
                //System.Web.HttpContext.Current.Response.AddHeader("Content-Disposition", "attachment; filename=" + HttpUtility.UrlEncode(url, System.Text.Encoding.UTF8));
                //System.Web.HttpContext.Current.Response.BinaryWrite(bytes);
                //fileopen.Close();
                //System.Web.HttpContext.Current.Response.Flush();
                //System.Web.HttpContext.Current.Response.End();

                return 1;
            }
            catch (Exception)
            {

                return 0;
            }
        }
        #endregion



        #region 所有匹配数据
        /// <summary>
        /// EX表格导出视频信息
        /// </summary>
        /// <param name="list"></param>
        /// <returns></returns>
        public int CardEX(List<Model.PageList> list)
        {
            try
            {
                System.Reflection.Missing miss = System.Reflection.Missing.Value;
                //实例化一个Excel.Application对象
                Microsoft.Office.Interop.Excel.Application excel = new Microsoft.Office.Interop.Excel.Application();
                excel.Application.Workbooks.Add(true);
                excel.Visible = false;//若是true，则在导出的时候会显示EXcel界面。
                Microsoft.Office.Interop.Excel.Workbooks books = (Microsoft.Office.Interop.Excel.Workbooks)excel.Workbooks;
                Microsoft.Office.Interop.Excel.Workbook book = (Microsoft.Office.Interop.Excel.Workbook)(books.Add(miss));
                Microsoft.Office.Interop.Excel.Worksheet sheet = (Microsoft.Office.Interop.Excel.Worksheet)book.ActiveSheet;
                string[] str = { "ID", "SN", "账号（手机号）", "密码", "激活日期", "注册日期", "结束日期" };
                for (int i = 0; i < str.Length; i++)
                {
                    //首列
                    excel.Cells[1, i + 1] = str[i];
                }
                for (int i = 0; i < list.Count(); i++)
                {
                    //列，行

                    excel.Cells[i + 2, 1] = list[i].Userid;
                    excel.Cells[i + 2, 2] = list[i].SN;
                    excel.Cells[i + 2, 3] = list[i].Account;
                    excel.Cells[i + 2, 4] = list[i].PassWord;
                    excel.Cells[i + 2, 5] = list[i].RegisterTime;
                    excel.Cells[i + 2, 6] = list[i].ActivationTime;
                    excel.Cells[i + 2, 7] = list[i].OutTime;

                }
                sheet.Columns.EntireColumn.AutoFit();
                string time = DateTime.Now.ToString("yyyyMMddHHmmss");
                sheet.SaveAs("E:\\" + time + ".xlsx", miss, miss, miss, miss, miss, Microsoft.Office.Interop.Excel.XlSaveAsAccessMode.xlNoChange, miss, miss, miss);
                book.Close(false, miss, miss);
                books.Close();
                excel.Quit();
                System.Runtime.InteropServices.Marshal.ReleaseComObject(sheet);
                System.Runtime.InteropServices.Marshal.ReleaseComObject(book);
                System.Runtime.InteropServices.Marshal.ReleaseComObject(books);
                System.Runtime.InteropServices.Marshal.ReleaseComObject(excel);
                GC.Collect();
                System.Diagnostics.Process.Start("E:\\" + time + ".xlsx");
                return 1;
            }
            catch (Exception)
            {
                return 0;
            }



        }
        #endregion
        public bool IsReusable
        {
            get
            {
                return false;
            }
        }
    }
}