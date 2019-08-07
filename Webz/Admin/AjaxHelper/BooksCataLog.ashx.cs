using BLL;
using Model;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace Webz.Admin.AjaxHelper
{
    /// <summary>
    /// BooksCataLog 的摘要说明
    /// </summary>
    public class BooksCataLog : IHttpHandler
    {
        CataLogBLL bll = new CataLogBLL();
        public void ProcessRequest(HttpContext context)
        {
            context.Response.ContentType = "text/plain";
            string action = context.Request["action"].ToString();
            if (action!=null&&action.Equals("batchdelete"))
            {
                deleteInfo(context);
            }
            else if (action != null && action.Equals("insertInfo"))
            {
                operatingInfo(context);
            }
            else if (action != null && action.Equals("updateInfo")) 
            {
                operatingInfo(context);
            }else if(action!=null && action.Equals("selectOne"))
            {
                //查询三层目录
                //获取caid 查看级别 selectOneInfo(int caid)
                selectOne(context);
            }
        }

        

        public void deleteInfo(HttpContext context) 
        {
            string[] array = context.Request.Form["array"].Split(',');
            int num = bll.batchDeleteInfo(array);
            context.Response.Write(num);
        }
        public void operatingInfo(HttpContext context) 
        {
            string isbn = context.Request["isbn"]!=null?context.Request["isbn"]:"";
            Object booksid = bll.selectTextId(isbn);
            int error = 0;
            int insertCount = 0;
            int updateCount = 0;
            if (Convert.ToInt32(booksid)>0)
            {
                string type = context.Request["action"]!=null?context.Request["action"]:"";
                string caName = context.Request["caName"]!=null?context.Request["caName"]:"";
                string caNum = context.Request["caNum"]!=null?context.Request["caNum"]:"";
                string textName = context.Request["textCataName"]!=null?context.Request["textCataName"]:"";
                string author = context.Request["author"]!=null?context.Request["author"]:"";
                if (author=="")
                {
                    author = "无";
                }
                string subTextName = context.Request["subTextName"]!=null?context.Request["subTextName"]:"";
                int page = context.Request["page"].Length>0?Convert.ToInt32(context.Request["page"]):0;
                Model.BooksCatalog bc = new Model.BooksCatalog();
                bc.CaName = caName;
                bc.TextName = textName;
                bc.Page = page;
                bc.CaNum = caNum;
                bc.Author = author;
                bc.State = 1;
                bc.SubTextName = subTextName;
                bc.TextID = Convert.ToInt32(booksid);
                if (type.Equals("insertInfo"))
                {
                    if (subTextName != "" && caName != "" && textName != "")
                    {
                        if (insertInfo(3, bc) > 0)
                        {
                            insertCount = 1;
                        }
                        else
                        {
                            insertCount = 2;
                        }

                    }
                    else if (caName != "" && textName != "" && caNum != "")
                    {
                        if (insertInfo(2, bc) > 0)
                        {
                            insertCount = 1;
                        }
                        else
                        {
                            insertCount = 2;
                        }

                    }
                    else if (caName != "")
                    {
                        if (insertInfo(1, bc) > 0)
                        {
                            insertCount = 1;
                        }
                        else
                        {
                            insertCount = 2;
                        }

                    }
                }
                else if (type.Equals("updateInfo"))
                {
                    int caid = Convert.ToInt32(context.Request["caid"]);
                    int level = Convert.ToInt32(context.Request["level"]);
                    bc.CaID = caid;
                    if(level==1)
                    {
                        if (selectCaId(1, bc) <= 0)
                        {
                            bc.CaID = caid;
                            if (bll.updateCataLogNameInfo(bc) > 0)
                            {
                                updateCount = 1;
                            }
                            else
                            {
                                updateCount = 0;
                            }
                        }
                        else 
                        {
                            updateCount = 2;
                        }
                    }
                    else if(level==2)
                    {
                        bc.CaName = textName;
                        if (bll.updateInfo(bc) > 0)
                        {
                            updateCount = 1;
                        }
                        else
                        {
                            updateCount = 0;
                        }

                    }
                    
                    
                    if(level==3)
                    {
                        bc.CaName = subTextName;
                        if (bll.updateInfo(bc) > 0)
                        {
                            updateCount = 1;
                        }
                        else
                        {
                            updateCount = 0;
                        }
                    }
                }
            }
            else 
            {
                error = 1;
            }
            var str = new
            {
                insertCount = insertCount,
                updateCount = updateCount,
                error = error
            };
            string json = JsonConvert.SerializeObject(str);
            context.Response.Write(json);
        }
        ////查询 cataLogId,textId,subtextId
                    ////判断级别
                    ////判断目录id 根据书本id和单元目录查询目录id查询到已有的数据上获取主目录id 
                    ////在用主目录id 课文目录到第二层目录查询已有获取主目录id 
                    ////,没有则目录名称改为现有名称
                    ////
                    ////update isbn 单元目录 课文目录 子课文名称 作者 页数
                    ////catalogId = selectCaId(1,bc);
                    ///*
                    // * cataLogId = select(单元名称,书本名称)
                    // * if(cataLogId>0)
                    // *      textId = select(课文目录,cataLogId)
                    // *      if(textId>0)
                    // *          subtextId = select(子课文名称，textid);
                    // * 
                    // * 
                    // * 
                    // * 如果遇到已有数据修改子级下的主目录 数据重复
                    // * 
                    // * if(subtextId<0)
                    // * {
                    // *      update
                    // *      count = 1;
                    // * }
                    // * else{
                    // *      count = 2;
                    // * }
                    // */

                    ////判断更改后位置的目录是否有重复添加记录
                    ////判断目录下是否有记录
                    ////
                    ////修改主目录信息
                    

        //public int updateInfo(int level, Model.BooksCatalog bc)
        //{
        //    int textId = bll.selectCaID(bc.CaID);
        //    int catalogId = bll.selectCaID(textId);

        //    int subtextId = 0;
        //    int updateCount = 0;
        //    if (level == 1)
        //    {
        //        int num = 0;
        //        if(selectCaId(1,bc)<=0)
        //        {
        //            if (bll.selectCataLogCount(catalogId) == 1 && bll.selectCataLogCount(textId) == 1)
        //            {
        //                num = bll.updateCataLogInfo(bc);
        //            }
        //            else 
        //            {
        //                num = bll.insertCataLogInfo(bc);
        //            }
        //        }
        //        if (bll.selectCataLogCount(catalogId) == 1)
        //        {
        //            catalogId = selectCaId(1, bc);
        //            if (catalogId <= 0)
        //            {
        //                bll.updateCataLogInfo(bc);
        //            }
        //        }
        //        else 
        //        {
        //            catalogId = selectCaId(1,bc);
        //            if(catalogId<=0)
        //            {
        //                catalogId = insertInfo(1, bc);
        //            }
        //        }
        //        if (selectCaId(1, bc)<= 0)
        //        {
        //            if (bll.selectCataLogCount(catalogId) == 1)
        //            {
        //                bll.updateCataLogInfo(bc);
        //            }
        //            else 
        //            {
        //                catalogId = insertInfo(1,bc);
        //            }
                    
        //        }
        //        else
        //        {
        //            if(bll.selectCataLogCount(catalogId)>1)
        //            {
                        
        //            }
        //        }

        //    }
        //    if (level == 2)
        //    {
        //        return bll.updateTextCataLogInfo(bc);
        //    }
        //    if(level == 3)
        //    {
        //        catalogId = selectCaId(1, bc);
        //        if (catalogId <= 0)
        //        {
        //            catalogId = insertInfo(1, bc);
        //        }
        //        bc.CaID = catalogId;
        //        textId = selectCaId(2, bc);
        //        if (textId <= 0)
        //        {
        //            textId = insertInfo(2, bc);
        //        }
        //        bc.TID = textId;
        //        subtextId = selectCaId(3, bc);

        //        if (subtextId <= 0)
        //        {
        //            updateCount = bll.updateTextCataLogInfo(bc);
        //        }
        //    }
        //    if (catalogId > 0 || textId > 0)
        //    {
        //        if (bll.selectCataLogCount(textId) == 1)
        //        {
        //            deleteInfo(textId);
        //        }
        //        if (bll.selectCataLogCount(catalogId) == 1)
        //        {
        //            deleteInfo(catalogId);
        //        }
        //    }
        //    return updateCount;
        //}

        public int deleteInfo(int catalogId) 
        {
            return bll.deleteCataLogInfo(catalogId);
        }
        public void selectOne(HttpContext context) 
        {
            int caId = Convert.ToInt32(context.Request["CaId"]);
            Model.BooksCatalog catalog = bll.selectOne(caId);
            catalog.ISBN = bll.selectisbn(catalog.TextID);
            if (catalog.Level == 3)
            {
                catalog.SubTextName = catalog.CaName;
                catalog.TextName = bll.selectOne(catalog.TID).CaName;
                catalog.CaName = bll.selectOne(bll.selectOne(catalog.TID).TID).CaName;
            }
            else if (catalog.Level == 2)
            {
                catalog.TextName = catalog.CaName;
                catalog.CaName = bll.selectOne(catalog.TID).CaName;
            }
            string json = JsonConvert.SerializeObject(catalog);
            context.Response.Write(json);
        }
        //cataId = bll.selectAlreadyCaID(caName,Convert.ToInt32(booksid));
        //cataId = selectCaId(1,bc);
        //if (cataId==0)
        //{
        //    cataId = bll.insertCataLogInfo(bc);
        //}
        //textid = bll.selectAlreadyTextCaID(textCataName, cataId);
        //if (textid==0)
        //{
        //    bc.CaName = textCataName;
        //    textid = bll.insertTextCataLogInfo(bc);
        //}
        //subtextid = bll.selectAlreadySubTextCaID(subTextName,Convert.ToInt32(booksid),textid);
        //if (subtextid == 0)
        //{
        //    bc.CaName = subTextName;
        //    subtextid = bll.selectAlreadySubTextCaID(subTextName, Convert.ToInt32(booksid), textid);
        //    if (bll.insertSubTextCataLogInfo(bc) > 0)
        //    {
        //        subtextid = bll.selectAlreadySubTextCaID(subTextName, Convert.ToInt32(booksid), textid);
        //        num = subtextid;
        //    }
        //    var str = new {
        //        subtextid = num
        //    };
        //    string json = JsonConvert.SerializeObject(str);
        //    context.Response.Write(json);
        //}
        public int selectCaId(int level,Model.BooksCatalog bc) 
        {
            if (level==1)
            {
                return bll.selectAlreadyCaID(bc.CaName, bc.TextID);
            }
            if(level==2)
            {
                return bll.selectAlreadyTextCaID(bc.TextName, bc.TID);
            }
            if(level==3)
            {
                return bll.selectAlreadySubTextCaID(bc.SubTextName, bc.TextID, bc.TID);
            }
            return 0;
        }

        public int insertInfo(int level,Model.BooksCatalog bc)
        {
            int cataLogId = 0;
            int textId = 0;
            int subTextId = 0;
            if(level==1)
            {
                if (selectCaId(1,bc)==0)
                {
                    cataLogId = bll.insertCataLogInfo(bc);
                }
                return cataLogId;
            }
            if(level==2)
            {
                cataLogId = selectCaId(1,bc);
                if (cataLogId==0)
                {
                    cataLogId = insertInfo(1, bc);
                }
                bc.TID = cataLogId;
                if(selectCaId(2,bc)==0)
                {
                    textId = bll.insertTextCataLogInfo(bc);
                }
                return textId;
            }
            if(level==3)
            {
                cataLogId = selectCaId(1,bc);
                string author = bc.Author;
                if (cataLogId==0)
                {
                    cataLogId = insertInfo(1, bc);
                }

                bc.TID = cataLogId;
                textId = selectCaId(2,bc);
                if (textId==0)
                {
                    bc.Author = "";
                    textId = insertInfo(2,bc);
                }

                bc.TID = textId;
                if(selectCaId(3,bc)==0)
                {
                    bc.Author = author;
                    subTextId = bll.insertSubTextCataLogInfo(bc);
                }
                return subTextId;
            }
            return 0;
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