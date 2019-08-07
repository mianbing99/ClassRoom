using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Data.SqlClient;

namespace Webz {
    public class db {
        string connstr = "";

        public bool Exc(string sql) {
            SqlConnection conn = new SqlConnection(connstr);
            conn.Open();
            SqlCommand cmd = new SqlCommand(sql,conn);
            if (cmd.ExecuteNonQuery() > 0) {
                return true;
            } else {
                return false;
            } 
        }
        public SqlDataReader Sel(string sql) {
            SqlConnection conn = new SqlConnection(connstr);
            conn.Open();
            SqlCommand cmd = new SqlCommand(sql, conn);
            return cmd.ExecuteReader();
        }

        public int selt(string sql) {
            SqlConnection conn = new SqlConnection(connstr);
            conn.Open();
            SqlCommand cmd = new SqlCommand(sql,conn);
                return Convert.ToInt32(cmd.ExecuteScalar());
        }
        public model selectid(int id) {
            string sql = string.Format("select * from zhangdan where id = '{0}'",id);
            SqlDataReader rp = Sel(sql);
            model mo = new model();
            if (rp.Read()) {
                mo.Id =Convert.ToInt32(rp["id"]);
                mo.Money = Convert.ToDouble(rp["money"]);
                mo.Count = rp["count"].ToString();
                mo.Time = Convert.ToDateTime(rp["time"]);
                mo.Zmoney = Convert.ToDouble(rp["zmoney"]);
                mo.Shouru = Convert.ToDouble(rp["shouru"]);
            }
            return mo;
        }
        public bool Add(model mo) {
            string sql = string.Format("insert into zhangdan values('{0}','{0}','{0}','{0}','{0}',)",mo.Money,mo.Count,mo.Time,mo.Zmoney,mo.Shouru);
            return Exc(sql);
        }
        public List<model> selects() {
            string sql = string.Format("select * from zhangdan");
            SqlDataReader rp = Sel(sql);
            List<model> mos = new List<model>();
            while (rp.Read()) {
                model mo = new model();
                mo.Id = Convert.ToInt32(rp["id"]);
                mo.Money = Convert.ToDouble(rp["money"]);
                mo.Count = rp["count"].ToString();
                mo.Time = Convert.ToDateTime(rp["time"]);
                mo.Zmoney = Convert.ToDouble(rp["zmoney"]);
                mo.Shouru = Convert.ToDouble(rp["shouru"]);
                mos.Add(mo);
            }
            return mos;
        }
    }
}