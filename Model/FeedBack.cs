using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Model
{
    public class FeedBack
    {
        private int feedBackID;

        public int FeedBackID
        {  //主键ID
            get { return feedBackID; }
            set { feedBackID = value; }
        }
        private string grade;

        public string Grade
        {  //学期
            get { return grade; }
            set { grade = value; }
        }
        private string phone;

        public string Phone
        {  //提交人手机
            get { return phone; }
            set { phone = value; }
        }
        private string feedBackNR;

        public string FeedBackNR
        {//意见内容
            get { return feedBackNR; }
            set { feedBackNR = value; }
        }
        private string feedBackDate;

        public string FeedBackDate
        {//意见内容
            get { return feedBackDate; }
            set { feedBackDate = value; }
        }
        private string processing;

        public string Processing
        {//反馈内容
            get { return processing; }
            set { processing = value; }
        }
        private string processingName;

        public string ProcessingName
        {//处理人姓名
            get { return processingName; }
            set { processingName = value; }
        }
        private string stata;

        public string Stata
        {//受理状态
            get { return stata; }
            set { stata = value; }
        }
    }
}
