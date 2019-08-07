using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Data.SqlClient;

namespace DAL {
    public  class TestDAL {
        public List<Model.Test> Select() {
            string sql = string.Format("Select * from Test");
            return MoList(sql);
        }
        public List<Model.Test> SelectBySu(string SuName) {
            string sql = string.Format("Select * from Test where kemu = '{0}'",SuName);
            return MoList(sql);
        }
        private List<Model.Test> MoList(string sql) {
            SqlConnection conn = new SqlConnection(DBHerp.SQL.connstr);
            conn.Open();
            SqlCommand cmd = new SqlCommand(sql,conn);
            SqlDataReader re = cmd.ExecuteReader();
            List<Model.Test> TeList = new List<Model.Test>();
            while(re.Read()){
                Model.Test te = new Model.Test();
                te.TestID = Convert.ToInt32(re["TestID"]);
                if (re["Htv"] == null) {
                    te.HTV = "";
                } else {
                    te.HTV = re["Htv"].ToString();
                }
                if (re["Mp4"] == null) {
                    te.MP4 = "";
                } else {
                    te.MP4 = re["mp4"].ToString();
                }
                if (re["Name"] == null) {
                    te.Name = "";
                } else {
                    te.Name = re["name"].ToString();
                }
                if (re["kemu"] == null) {
                    te.Kemu = "";
                } else {
                    te.Kemu = re["kemu"].ToString();
                }
                TeList.Add(te);
            }
            return TeList;
        }
        private Model.Test Mo(string sql) {
            SqlConnection conn = new SqlConnection(DBHerp.SQL.connstr);
            conn.Open();
            SqlCommand cmd = new SqlCommand(sql, conn);
            SqlDataReader re = cmd.ExecuteReader();
            Model.Test te = new Model.Test();
            if (re.Read()) {
                if (re["TestID"] == null)
                {
                    te.TestID = 0;
                } else {
                    te.TestID = Convert.ToInt32(re["TestID"]);
                }
                if (re["Htv"] == null) {
                    te.HTV = "";
                } else {
                    te.HTV = re["Htv"].ToString();
                }
                if (re["Mp4"] == null) {
                    te.MP4 = "";
                } else {
                    te.MP4 = re["mp4"].ToString();
                }
                if (re["Name"] == null) {
                    te.Name = "";
                } else {
                    te.Name = re["name"].ToString();
                }
                if (re["kemu"] == null) {
                    te.Kemu = "";
                } else {
                    te.Kemu = re["kemu"].ToString();
                }
            }
            return te;
        }
    }
    
}
