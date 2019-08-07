using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Model
{
    public class BooksCatalog
    {
        private int caID;

        /// <summary>
        /// 主键
        /// </summary>
        public int CaID {
            get { return caID; }
            set { caID = value; }
        }

        private string caNum;

        /// <summary>
        /// 课文数
        /// </summary>
        public string CaNum
        {
            get { return caNum; }
            set { caNum = value; }
        }

        private string caName;

        /// <summary>
        /// 课文名称
        /// </summary>
        public string CaName
        {
            get { return caName; }
            set { caName = value; }
        }

        private int tID;

        /// <summary>
        /// 主键
        /// </summary>
        public int TID
        {
            get { return tID; }
            set { tID = value; }
        }

        private int textID;

        /// <summary>
        /// 课本id
        /// </summary>
        public int TextID
        {
            get { return textID; }
            set { textID = value; }
        }

        private int page;

        /// <summary>
        /// 页码
        /// </summary>
        public int Page
        {
            get { return page; }
            set { page = value; }
        }

        private string author;
        public string Author 
        {
            get { return author; }
            set { author = value; }
        }

        private int state;

        /// <summary>
        /// 当前目录状态 0为不可用 1为可用
        /// </summary>

        public int State
        {
            get { return state; }
            set { state = value; }
        }

        private int viid;

        /// <summary>
        /// 会员
        /// </summary>
        public int Viid
        {
            get { return viid; }
            set { viid = value; }
        }

        private int bDid;

        /// <summary>
        /// 主键
        /// </summary>
        public int BDid
        {
            get { return bDid; }
            set { bDid = value; }
        }

        private string iSBN;

        /// <summary>
        /// ISBN
        /// </summary>
        public string ISBN
        {
            get { return iSBN; }
            set { iSBN = value; }
        }

        private string booksName;

        /// <summary>
        /// 课本名称
        /// </summary>
        public string BooksName
        {
            get { return booksName; }
            set { booksName = value; }
        }

        private string subTextBookName;

        public string SubTextBookName
        {
            get { return subTextBookName; }
            set { subTextBookName = value; }
        }

        private string textName;

        public string TextName
        {
            get { return textName; }
            set { textName = value; }
        }
        private string year;

        public string Year
        {
            get { return year; }
            set { year = value; }
        }
        private string subTextName;

        public string SubTextName
        {
            get { return subTextName; }
            set { subTextName = value; }
        }

        private int level;

        public int Level 
        {
            get { return level; }
            set { level = value; }
        }

        private int catalogId;
        public int CataLogId 
        {
            get { return catalogId; }
            set { catalogId = value; }
        }
        //子课文目录
        private int subTextCataLogId;
        public int SubTextCataLogId 
        {
            get { return subTextCataLogId; }
            set { subTextCataLogId = value; }
        }
        
        //课文目录id
        private int textCataLogId;
        public int TextCataLogId 
        {
            get { return textCataLogId; }
            set { textCataLogId = value; }
        }



    }
}
