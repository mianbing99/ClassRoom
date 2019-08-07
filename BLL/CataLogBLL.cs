using DAL;
using Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace BLL
{
    public class CataLogBLL
    {
        CataLogDAL dal = new CataLogDAL();

        //批量删除目录
        public int batchDeleteInfo(string[] array) 
        {
            return dal.batchDeleteInfo(array);
        }

        //添加子课文名称
        public int insertSubTextCataLogInfo(BooksCatalog bc) 
        {
            return dal.insertSubTextCataLogInfo(bc);
        }

        //添加课文目录
        public int insertTextCataLogInfo(BooksCatalog bc) 
        {
            return dal.insertTextCataLogInfo(bc);
        }

        //添加单元目录
        public int insertCataLogInfo(BooksCatalog bc) 
        {
            return dal.insertCataLogInfo(bc);
        }


        //查询已有的子课文名称
        public int selectAlreadySubTextCaID(string SubTextName, int TextID, int TextCataLogID) 
        {
            return dal.selectAlreadySubTextCaID(SubTextName,TextID,TextCataLogID);
        }

        //查询已有课文目录caid
        public int selectAlreadyTextCaID(string TextCataLogName,int CataLogID) 
        {
            return dal.selectAlreadyTextCaID(TextCataLogName, CataLogID);
        }

        //查询已有单元目录
        public int selectAlreadyCaID(string CataLogName,int TextID) 
        {
            return dal.selectAlreadyCaID(CataLogName,TextID);
        }

        //查询主目录CaID
        public int selectCaID(int caId) 
        {
            return dal.selectCaID(caId);
        }

        /// <summary>
        /// 查询单条目录信息
        /// </summary>
        /// <param name="caId"></param>
        /// <returns></returns>
        public Model.BooksCatalog selectOne(int caId) 
        {
            return dal.selectOne(caId);
        }

        //查询主目录下的子目录个数
        public int selectCataLogCount(int catalogId) 
        {
            return dal.selectCataLogCount(catalogId);
        }

        //删除目录信息
        public int deleteCataLogInfo(int catalogId)
        {
            return dal.deleteCataLogInfo(catalogId);
        }

        //根据书本id查询isbn
        public string selectisbn(int bookId) 
        {
            return dal.selectisbn(bookId);
        }

        //修改主目录信息
        public int updateCataLogInfo(BooksCatalog bc) 
        {
            return dal.updateCataLogInfo(bc);
        }


        //修改课文目录信息
        public int updateTextCataLogInfo(BooksCatalog bc) 
        {
            return dal.updateTextCataLogInfo(bc);
        }
         //修改子课文目录信息
        public int updateSubTextCataLogInfo(BooksCatalog bc) 
        {
            return dal.updateSubTextCataLogInfo(bc);
        }

        public int updateCataLogNameInfo(BooksCatalog bc)
        {
            return dal.updateCataLogNameInfo(bc);
        }

        public int updateInfo(BooksCatalog bc)
        {
            return dal.updateInfo(bc);
        }



        //添加目录
        public int insertInfo(BooksCatalog bc)
        {
            return 0;
        }

        //根据isbn值查询的TextBooks课本信息表的textid
        public Object selectTextId(string isbn) 
        {
            return dal.selectTextId(isbn);
        }
    }
}
