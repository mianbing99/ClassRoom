using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace Webz.WebIE {
    public partial class UserClass : System.Web.UI.Page {
        public string User = string.Empty;
        public int Userid;
        public string jsonGr = string.Empty;
        public string jsonPr = string.Empty;
        public string jsonBo = string.Empty;
        protected void Page_Load(object sender, EventArgs e) {
            //if (Session["Openid"] == null) {
            //    Response.Write("<script type=\"text/javascript\"> alert(\"系统繁忙\");</script>");
            //    Response.Write(" <script type=\"text/javascript\">  window.location.href =\"https://open.weixin.qq.com/connect/oauth2/authorize?appid=wx0688f75d53cbb9e1&redirect_uri=http://ftv.icoxtech.com&response_type=code&scope=snsapi_base#wechat_redirect\"</script>");
            //}
            if (Session["Phone"] == null) {
                Response.Write(" <script type=\"text/javascript\">  window.location.href =\"Login.aspx\"</script>");
                return;
            }
            User = Session["Phone"].ToString();
            Userid = Convert.ToInt32(Session["Userid"]);
            BLL.UserSetBLL SeBll = new BLL.UserSetBLL();
            Model.UserSet SeModel = new Model.UserSet();
            SeModel = SeBll.SelectByUserid(Userid); // 根据UserID查询 设置信息
            JsonBo(SeModel); JsonGr(SeModel); JsonPr(SeModel);
        }
        protected void But_Click(object sender, EventArgs e) {
            BLL.UserSetBLL SeBll = new BLL.UserSetBLL();
            Model.UserSet Se = new Model.UserSet();
            Se.UserID = Convert.ToInt32(Session["Userid"]);
            Se.GrID = Convert.ToInt32(Xueduan.Value);
            Se.GrID = Convert.ToInt32(press.Value);
            Se.Semester = Semester.Value;
            Se.Study = Convert.ToInt32(Xueduan.Value);
            if (SeBll.Insert(Se)) {
                Response.Write("<script type=\"text/javascript\"> alert(\"保存成功\");</script>");
                Response.Write(" <script type=\"text/javascript\">  window.location.href =\"Index.aspx\"</script>");
            }
        }

        protected void ButT_Click(object sender, EventArgs e) {
            Response.Write(" <script type=\"text/javascript\">  window.location.href =\"BooksList.aspx\"</script>");
        }
        private void JsonGr(Model.UserSet SeModel) {
            BLL.GradeBLL Grbll = new BLL.GradeBLL();
            List<Model.Grade> GrList = new List<Model.Grade>();
            GrList = Grbll.SeleteName(SeModel.Study); //根据学段查询年级信息
            for (int i = 0; i < GrList.Count; i++) {
                if (GrList.Count == 1) {
                    jsonGr += "{\"nianji\":\"" + GrList[i].GrName.Trim() + "\",\"ID\":\"" + GrList[i].Grid + "\",\"XZID\":\"" + SeModel.GrID + "\",\"XDID\":\"" + SeModel.Study + "\"}";
                } else {
                    if (i == 0) {
                        jsonGr += "[{\"nianji\":\"" + GrList[i].GrName.Trim() + "\",\"ID\":\"" + GrList[i].Grid + "\",\"XZID\":\"" + SeModel.GrID + "\",\"XDID\":\"" + SeModel.Study + "\"},";
                    } else if (i == GrList.Count - 1) {
                        jsonGr += "{\"nianji\":\"" + GrList[i].GrName.Trim() + "\",\"ID\":\"" + GrList[i].Grid + "\",\"XZID\":\"" + SeModel.GrID + "\",\"XDID\":\"" + SeModel.Study + "\"}]";
                    } else {
                        jsonGr += "{\"nianji\":\"" + GrList[i].GrName.Trim() + "\",\"ID\":\"" + GrList[i].Grid + "\",\"XZID\":\"" + SeModel.GrID + "\",\"XDID\":\"" + SeModel.Study + "\"},";
                    }
                }
            }
        }
        private void JsonPr(Model.UserSet SeModel) {
            BLL.PressBLL Prbll = new BLL.PressBLL();
            List<Model.Press> prlist = new List<Model.Press>();
            prlist = Prbll.Selectlist(SeModel.GrID);  //根据年级信息查询出版社
            for (int i = 0; i < prlist.Count; i++) {
                if (prlist.Count == 1) {
                    jsonPr = "[{\"Prs\":\"" + prlist[i].PrName.Trim() + "\",\"ID\":\"" + prlist[i].Prid + "\",\"XZID\":\"" + SeModel.PrID + "\"}]";
                } else {
                    if (i == 0) {
                        jsonPr += "[{\"Prs\":\"" + prlist[i].PrName.Trim() + "\",\"ID\":\"" + prlist[i].Prid + "\",\"XZID\":\"" + SeModel.PrID + "\"},";
                    } else if (i == prlist.Count - 1) {
                        jsonPr += "{\"Prs\":\"" + prlist[i].PrName.Trim() + "\",\"ID\":\"" + prlist[i].Prid + "\",\"XZID\":\"" + SeModel.PrID + "\"}]";
                    } else {
                        jsonPr += "{\"Prs\":\"" + prlist[i].PrName.Trim() + "\",\"ID\":\"" + prlist[i].Prid + "\",\"XZID\":\"" + SeModel.PrID + "\"},";
                    }
                }
            }
        }
        private void JsonBo(Model.UserSet SeModel) {
            BLL.BooksBLL Bobll = new BLL.BooksBLL();
            List<Model.TextBooks> Bolist = new List<Model.TextBooks>();
            Bolist = Bobll.SelectByGrid_Prid(SeModel.SuID, SeModel.GrID);  //根据年级和出版社 查询上下册信息  }]
            for (int i = 0; i < Bolist.Count; i++) {
                if (Bolist[i].Semester.Trim() == "") {
                    Bolist[i].Semester = "全一册";
                }
                if (Bolist.Count == 1) {
                    jsonBo = "[{\"Sem\":\"" + Bolist[i].Semester.Trim() + "\",\"XZID\":\"" + SeModel.Semester + "\"}]";
                } else {
                    if (i == 0) {
                        jsonBo += "[{\"Sem\":\"" + Bolist[i].Semester.Trim() + "\",\"XZID\":\"" + SeModel.Semester + "\"},";
                    } else if (i == Bolist.Count - 1) {
                        jsonBo += "{\"Sem\":\"" + Bolist[i].Semester.Trim() + "\",\"XZID\":\"" + SeModel.Semester + "\"}]";
                    } else {
                        jsonBo += "{\"Sem\":\"" + Bolist[i].Semester.Trim() + "\",\"XZID\":\"" + SeModel.Semester + "\"},";
                    }
                }
            }
        }
    }
}