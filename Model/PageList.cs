using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Model
{
    public class PageList
    {
        /// <summary>
        /// 视频信息
        /// </summary>
        public int num { get; set; }
        public int TempID { get; set; }
        public int TextID { get; set; }
        public string Semester { get; set; }
        public int GradeID { get; set; }
        public string GrName { get; set; }
        public string BooksName { get; set; }
        public int ViID { get; set; }
        public string ViName { get; set; }
        public string 匹配 { get; set; }
        public string 未匹配 { get; set; }
        public int Suid { get; set; }
        public string SuName { get; set; }
        public int PrID { get; set; }
        public string PrName { get; set; }
        public int CaID { get; set; }
        public int VRID { get; set; }


        /// <summary>
        /// 注册统计
        /// </summary>
        public int Userid { get; set; }
        public int SN { get; set; }
        public string Account { get; set; }
        public string PassWord { get; set; }
        public string RegisterTime { get; set; }
        public string ActivationTime { get; set; }
        public string OutTime { get; set; }

        public string Phone { get; set; }



        ///// <summary>
        ///// 意见反馈
        ///// </summary>
        //public int FeedBackID { get; set; }
        //public string Grade { get; set; }
        //public string Phone { get; set; }
        //public string FeedBackNR { get; set; }
        //public string FeedBackDate { get; set; }
        //public string Processing { get; set; }
        //public string ProcessingName { get; set; }
        //public string Stata { get; set; }
    }
}
