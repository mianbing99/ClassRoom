using DBHerp;
using Model;
using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Text;

namespace DAL
{
    public class CataLogDAL
    {
        /// <summary>
        /// 批量删除课本目录
        /// </summary>
        /// <param name="str"></param>
        /// <returns></returns>
        public int batchDeleteInfo(string[] array)
        {
            string sql = "delete from [dbo].[BooksCatalog] where ";
            for (int i = 0; i < array.Length; i++)
            {
                if (array.Length == (i + 1))
                {
                    sql += "CaID = @CaID" + i;
                }
                else
                {
                    sql += "CaID = @CaID" + i + " or ";
                }
            }
            Console.WriteLine(sql);
            SqlCommand comm = new SqlCommand(sql, DBHelper.conn);
            for (int i = 0; i < array.Length; i++)
            {
                comm.Parameters.AddWithValue("@CaID" + i, array[i]);
            }
            DBHelper.OpdeConn();
            int num = comm.ExecuteNonQuery();

            Console.WriteLine(sql);
            DBHelper.CloseConn();
            return num;
        }


        /**
         添加教材目录
         验证是否有isbn值得课本 否返回提示课本不存在
         添加数据到BooksCatalog课本目录表
         根据isbn值查询的TextBooks课本信息表的textid
         赋值的时候如果有子课文的值
         先添加课文目录返回TId后在添加子课文
         */
        public int insertInfo(BooksCatalog bc) 
        {

            return 0;
        }

        //根据isbn值查询的TextBooks课本信息表的textid
        public Object selectTextId(string isbn) 
        {
            DBHelper.OpdeConn();
            string sql = "select TextID from TextBooks where ISBN = @ISBN;";
            SqlCommand comm = new SqlCommand(sql,DBHelper.conn);
            comm.Parameters.AddWithValue("@ISBN",isbn);
            Object textid = comm.ExecuteScalar();
            DBHelper.CloseConn();
            return textid;
        }

        public string selectisbn(int bookid)
        {
            string sql = "select isbn from TextBooks where TextID = @textId";
            SqlCommand comm = new SqlCommand(sql,DBHelper.conn);
            comm.Parameters.AddWithValue("@textId",bookid);
            DBHelper.OpdeConn();
            string isbn = Convert.ToString(comm.ExecuteScalar());
            DBHelper.CloseConn();
            return isbn;
        }

        //查询已有的主目录
        public int selectAlreadyCaID(string cataLogName, int booksID) 
        {
            string sql = "select CaID from BooksCatalog where CaName = @CataLogName and TextID = @BooksID;";
            SqlCommand comm = new SqlCommand(sql,DBHelper.conn);
            DBHelper.OpdeConn();
            comm.Parameters.AddWithValue("@CataLogName",cataLogName);
            comm.Parameters.AddWithValue("@BooksID", booksID);
            int num = Convert.ToInt32(comm.ExecuteScalar());
            DBHelper.CloseConn();
            return num;
        }

        //查询已有的课文目录
        public int selectAlreadyTextCaID(string TextCataLogName, int CataLogID)
        {
            string sql = "select CaID from BooksCatalog where CaName = @TextCataLogName and TID = @CataLogID;";
            SqlCommand comm = new SqlCommand(sql,DBHelper.conn);
            comm.Parameters.AddWithValue("@TextCataLogName", TextCataLogName);
            comm.Parameters.AddWithValue("@CataLogID", CataLogID);
            DBHelper.OpdeConn();
            int num = Convert.ToInt32(comm.ExecuteScalar());
            DBHelper.CloseConn();
            return num;
        }

        //查询已有的子课文名称
        public int selectAlreadySubTextCaID(string SubTextName, int BooksID, int TextCataLogID) 
        {
            string sql = "select CaID from BooksCatalog where CaName = @SubTextName and TextID = @BooksID and TID = @TextCataLogID;";
            SqlCommand comm = new SqlCommand(sql,DBHelper.conn);
            comm.Parameters.AddWithValue("@SubTextName", SubTextName);
            comm.Parameters.AddWithValue("@BooksID", BooksID);
            comm.Parameters.AddWithValue("@TextCataLogID", TextCataLogID);
            DBHelper.OpdeConn();
            int num = Convert.ToInt32(comm.ExecuteScalar());
            DBHelper.CloseConn();
            return num;
        }


        //查询主目录TID
        public int selectCaID(int caId)
        {
            string sql = "select TID from BooksCatalog where CaID = @CaId;";
            SqlCommand comm = new SqlCommand(sql, DBHelper.conn);
            comm.Parameters.AddWithValue("@CaId", caId);
            DBHelper.OpdeConn();
            int num = Convert.ToInt32(comm.ExecuteScalar());
            DBHelper.CloseConn();
            return num;
        }

        //查询单条目录
        public Model.BooksCatalog selectOne(int caid) 
        {
            string sql = "select CaID,CaName,CaNum,TextID,TID,author,Page,State,level from BooksCatalog where CaID = @CaID";
            SqlCommand comm = new SqlCommand(sql,DBHelper.conn);
            comm.Parameters.AddWithValue("@CaID",caid);
            DBHelper.OpdeConn();
            SqlDataReader reader = comm.ExecuteReader();
            Model.BooksCatalog catalog = new BooksCatalog();
            if (reader.Read())
            {
                
                catalog.CaID = Convert.ToInt32(reader["CaID"]);
                catalog.CaName = reader["CaName"].ToString();
                catalog.CaNum = reader["CaNum"].ToString();
                catalog.TextID = Convert.ToInt32(reader["TextID"]);
                catalog.TID = Convert.ToInt32(reader["TID"]);
                catalog.Author = reader["author"].ToString();
                catalog.Page = Convert.ToInt32(reader["Page"]);
                catalog.State = Convert.ToInt32(reader["State"]);
                catalog.Level = Convert.ToInt32(reader["Level"]);
            }
            DBHelper.CloseConn();
            return catalog;
        }

        //查询主目录下的子目录个数
        public int selectCataLogCount(int catalogId)
        {
            string sql = "select count(1) from BooksCatalog where TID = @TID";
            SqlCommand comm = new SqlCommand(sql,DBHelper.conn);
            comm.Parameters.AddWithValue("@TID",catalogId);
            DBHelper.OpdeConn();
            int count = Convert.ToInt32(comm.ExecuteScalar());
            DBHelper.CloseConn();
            return count;
        }

        //更换目录后删除原本目录
        public int deleteCataLogInfo(int catalogId) 
        {
            string sql = "delete from BooksCatalog where CaID = @CaID";
            SqlCommand comm = new SqlCommand(sql,DBHelper.conn);
            comm.Parameters.AddWithValue("@CaID",catalogId);
            DBHelper.OpdeConn();
            int count = comm.ExecuteNonQuery();
            DBHelper.CloseConn();
            return count;
        }

        //修改主目录信息
        public int updateCataLogInfo(BooksCatalog bc) 
        {
            string sql = "update BooksCatalog set CaNum = @CaNum,CaName = @CaName,TextID = @TextID where CaID = @CaID";
            SqlCommand comm = new SqlCommand(sql,DBHelper.conn);
            comm.Parameters.AddWithValue("@CaNum",bc.CaNum);
            comm.Parameters.AddWithValue("@CaName",bc.CaName);
            comm.Parameters.AddWithValue("@TextID",bc.TextID);
            comm.Parameters.AddWithValue("@CaID",bc.CaID);
            DBHelper.OpdeConn();
            int num = comm.ExecuteNonQuery();
            DBHelper.CloseConn();
            return num;
        }

        //修改课文目录
        public int updateTextCataLogInfo(BooksCatalog bc)
        {
            string sql = "update BooksCatalog set CaNum = @CaNum,CaName = @CaName,TextID = @TextID,TID = @TID,Page = @Page,author = @author where CaID = @CaID";
            SqlCommand comm = new SqlCommand(sql,DBHelper.conn);
            comm.Parameters.AddWithValue("@CaNum",bc.CaNum);
            comm.Parameters.AddWithValue("@CaName",bc.CaName);
            comm.Parameters.AddWithValue("@TextID",bc.TextID);
            comm.Parameters.AddWithValue("@TID",bc.TID);
            comm.Parameters.AddWithValue("@Page",bc.Page);
            comm.Parameters.AddWithValue("@author",bc.Author);
            comm.Parameters.AddWithValue("@CaID", bc.TextCataLogId);
            DBHelper.OpdeConn();
            int num = comm.ExecuteNonQuery();
            DBHelper.CloseConn();
            return num;
        }

        //修改子课文目录信息
        public int updateSubTextCataLogInfo(BooksCatalog bc) 
        {
            string sql = "update BooksCatalog set CaNum = @CaNum,CaName = @CaName,TID = @TID,TextID = @TextID,Page = @Page,author = @author where CaID = @CaID";
            SqlCommand comm = new SqlCommand(sql,DBHelper.conn);
            comm.Parameters.AddWithValue("@CaNum",bc.CaNum);
            comm.Parameters.AddWithValue("@CaName",bc.CaName);
            comm.Parameters.AddWithValue("@TID",bc.TID);
            comm.Parameters.AddWithValue("@TextID",bc.TextID);
            comm.Parameters.AddWithValue("@Page",bc.Page);
            comm.Parameters.AddWithValue("@author",bc.Author);
            comm.Parameters.AddWithValue("@CaID", bc.CataLogId);
            DBHelper.OpdeConn();
            int num = comm.ExecuteNonQuery();
            DBHelper.CloseConn();
            return num;
        }

        //查询课本中已有课文名称
        public Object selectAlreadyTextName(BooksCatalog bc) 
        {
            return 0;
        }

        //添加主目录
        public int insertCataLogInfo(BooksCatalog bc) 
        {

            string sql = "insert into BooksCatalog(CaNum,CaName,TID,TextID,State,Level) values(@CaNum,@CaName,@TID,@BooksID,@State,@Level);SELECT SCOPE_IDENTITY();";
            SqlCommand comm = new SqlCommand(sql,DBHelper.conn);
            comm.Parameters.AddWithValue("@CaNum",bc.CaNum);
            comm.Parameters.AddWithValue("@CaName",bc.CaName);
            comm.Parameters.AddWithValue("@TID",0);
            comm.Parameters.AddWithValue("@BooksID", bc.TextID);
            comm.Parameters.AddWithValue("@State",0);
            comm.Parameters.AddWithValue("@Level",1);
            DBHelper.OpdeConn();
            int num = 0;
            int count = Convert.ToInt32(comm.ExecuteScalar());
            if (count > 0)
            {
                num = count;
            }
            DBHelper.CloseConn();
            return num; 
        }

        //添加课文目录
        public int insertTextCataLogInfo(BooksCatalog bc) 
        {
            string sql = "insert into BooksCatalog(CaNum,CaName,TID,TextID,Page,author,State,Level) values(@CaNum,@CaName,@TID,@BooksID,@Page,@author,@State,@Level);SELECT SCOPE_IDENTITY()";
            SqlCommand comm = new SqlCommand(sql,DBHelper.conn);
            comm.Parameters.AddWithValue("@CaNum",bc.CaNum);
            comm.Parameters.AddWithValue("@CaName",bc.TextName);
            comm.Parameters.AddWithValue("@TID",bc.TID);
            comm.Parameters.AddWithValue("@BooksID", bc.TextID);
            comm.Parameters.AddWithValue("@Page",bc.Page);
            comm.Parameters.AddWithValue("@author",bc.Author);
            comm.Parameters.AddWithValue("@State",bc.State);
            comm.Parameters.AddWithValue("@Level",2);
            DBHelper.OpdeConn();
            int num = 0;
            int count = Convert.ToInt32(comm.ExecuteScalar());
            if (count > 0)
            {
                num = count;
            }
            DBHelper.CloseConn();
            return num;
        }

        //添加子课文
        public int insertSubTextCataLogInfo(BooksCatalog bc) 
        {
            string sql = "insert into BooksCatalog(CaNum,CaName,TID,TextID,Page,author,State,Level) values(@CaNum,@CaName,@TID,@BooksID,@Page,@author,@State,@Level);SELECT SCOPE_IDENTITY()";
            SqlCommand comm = new SqlCommand(sql,DBHelper.conn);
            comm.Parameters.AddWithValue("@CaNum",bc.CaNum);
            comm.Parameters.AddWithValue("@CaName", bc.SubTextName);
            comm.Parameters.AddWithValue("@TID",bc.TID);
            comm.Parameters.AddWithValue("@BooksID", bc.TextID);
            comm.Parameters.AddWithValue("@Page",bc.Page);
            comm.Parameters.AddWithValue("@author",bc.Author);
            comm.Parameters.AddWithValue("@State",bc.State);
            comm.Parameters.AddWithValue("@Level",3);
            DBHelper.OpdeConn();
            int num = 0;
            int count = Convert.ToInt32(comm.ExecuteScalar());
            if (count > 0)
            {
                num = count;
            }
            DBHelper.CloseConn();
            return num;
        }


        public int updateCataLogNameInfo(BooksCatalog bc) 
        {
            string sql = "update BooksCatalog set CaName = @CaName where CaID = @CaID";
            SqlCommand comm = new SqlCommand(sql, DBHelper.conn);
            comm.Parameters.AddWithValue("@CaName", bc.CaName);
            comm.Parameters.AddWithValue("@CaID", bc.CaID);
            DBHelper.OpdeConn();
            int num = comm.ExecuteNonQuery();
            DBHelper.CloseConn();
            return num;
        }
        //修改目录信息
        public int updateInfo(BooksCatalog bc) 
        {
            string sql = "update BooksCatalog set CaNum = @CaNum,CaName = @CaName,author = @author,Page = @Page where CaID = @CaID";
            SqlCommand comm = new SqlCommand(sql, DBHelper.conn);
            comm.Parameters.AddWithValue("@CaNum", bc.CaNum);
            comm.Parameters.AddWithValue("@CaName", bc.CaName);
            comm.Parameters.AddWithValue("@Page",bc.Page);
            comm.Parameters.AddWithValue("@author", bc.Author);
            comm.Parameters.AddWithValue("@CaID", bc.CaID);
            DBHelper.OpdeConn();
            int num = comm.ExecuteNonQuery();
            DBHelper.CloseConn();
            return num;
        }


        /// <summary>
        /// 根据caid查询booksCataLog表
        /// </summary>
        /// <param name="caid"></param>
        /// <returns></returns>
        public BooksCatalog selectBooksCataLog(int caid) 
        {
            return null;
        }

        public int insertBooksCataLog(BooksCatalog bc)
        {
            return 0;
        }

    }
}
