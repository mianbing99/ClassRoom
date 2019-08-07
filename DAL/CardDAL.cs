using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Data.SqlClient;
using System.Data;

namespace DAL {
    public class CardDAL {
        DBHerp.SQL Db = new DBHerp.SQL();
        public bool Select(string  Phone) {
            string sql = string.Format("select * from [card] ca left join [User] u on u.Userid = ca.Userid where Phone='{0}' ", Phone);
            if (MoList(sql).Count == 0) {
                return false;
            } else {
                return true;
            }
        }
        public string Update(string Account, string Password, int Userid) {
          string sql = string.Format("select * from [dbo].[Card] where account = '{0}'and [password]='{1}'", Account, Password);
          if (Mo(sql).Cardid == 0) {
              return "账号或密码错误！";
          } else if (Mo(sql).Userid != 0) {
          return "该账号已被使用";
          }
          DateTime todate = DateTime.Now;
          DateTime OutTime = DateTime.Now.AddYears(1);
          string sqlInsert = string.Format("update [dbo].[Card] set ActivationTime = '{0}',OutTime='{1}',Userid='{2}' where account = '{3}' and [password]='{4}'", todate, OutTime, Userid, Account, Password);
          if (Db.ExQuery(sqlInsert)) {
              return "激活成功！";
          } else {
              return "系统繁忙,请稍后再试";
          }
      }
        private List<Model.Card> MoList(string sql) {
            SqlConnection conn = new SqlConnection(DBHerp.SQL.connstr);
            conn.Open();
            SqlCommand cmd = new SqlCommand(sql, conn);
            SqlDataReader re = cmd.ExecuteReader();
            List<Model.Card> CarList = new List<Model.Card>();
            while (re.Read()) {
                Model.Card car = new Model.Card();
                if (re["Account"] != null) {
                    car.Account = re["Account"].ToString();
                }
                if (re["ActivationTime"] != null) {
                    car.ActivationTime = Convert.ToDateTime(re["ActivationTime"]);
                }
                if (re["cardid"] != null) {
                    car.Cardid = Convert.ToInt32(re["cardid"]);
                }
                if (re["CModel"] != null) {
                    car.CModel = re["cmodel"].ToString();
                }
                if (re["CreateTime"] != null) {
                    car.CreateTime = Convert.ToDateTime(re["CreateTime"]);
                }
                if (re["Customer"] != null) {
                    car.Customer = re["Customer"].ToString();
                }
                if (re["Edition"] != null) {
                    car.Edition = re["Edition"].ToString();
                }
                if (re["OutTime"] != null) {
                    car.OutTime = Convert.ToDateTime(re["OutTime"]);
                }
                if (re["Password"] != null) {
                    car.Password = re["Password"].ToString();
                }
                if (re["SN"] != null) {
                    car.SN = Convert.ToInt32(re["sn"]);
                }
                if (re["Userid"] != null) {
                    car.Userid = Convert.ToInt32(re["Userid"]);
                }
                CarList.Add(car);
            }
            return CarList;
        }
        private Model.Card Mo(string sql) {
            SqlConnection conn = new SqlConnection(DBHerp.SQL.connstr);
            conn.Open();
            SqlCommand cmd = new SqlCommand(sql, conn);
            SqlDataReader re = cmd.ExecuteReader();
            Model.Card car = new Model.Card();
            if (re.Read()) {
                if (re["Account"] != null) {
                    car.Account = re["Account"].ToString();
                }
                if (re["ActivationTime"] != null) {
                    car.ActivationTime = Convert.ToDateTime(re["ActivationTime"]);
                }
                if (re["cardid"] != null) {
                    car.Cardid = Convert.ToInt32(re["cardid"]);
                }
                if (re["CModel"] != null) {
                    car.CModel = re["cmodel"].ToString();
                }
                if (re["CreateTime"] != null) {
                    car.CreateTime = Convert.ToDateTime(re["CreateTime"]);
                }
                if (re["Customer"] != null) {
                    car.Customer = re["Customer"].ToString();
                }
                if (re["Edition"] != null) {
                    car.Edition = re["Edition"].ToString();
                }
                if (re["OutTime"] != null) {
                    car.OutTime = Convert.ToDateTime(re["OutTime"]);
                }
                if (re["Password"] != null) {
                    car.Password = re["Password"].ToString();
                }
                if (re["SN"] != null) {
                    car.SN = Convert.ToInt32(re["sn"]);
                }
                if (re["Userid"] != null) {
                    car.Userid = Convert.ToInt32(re["Userid"]);
                }
            }
            return car;
        }


        /// <summary>
        /// 分页查询注册统计
        /// </summary>
        /// <param name="PageSizeCount"></param>
        /// <param name="Count"></param>
        /// <param name="PageIndex"></param>
        /// <param name="PageSize"></param>
        /// <returns></returns>
        public List<Model.PageList> UserList(out int Count, int PageIndex, int PageSize, string Table, string Column, string OrderColumn, string Condition)
        {
            List<Model.PageList> list = new List<Model.PageList>();


            SqlCommand PageListComm = null;

            //读取临时表中的数据

            string sqlPageList = "[dbo].[prc_GetPager]";
            PageListComm = new SqlCommand(sqlPageList, DBHerp.DBHelper.conn);
            PageListComm.CommandType = CommandType.StoredProcedure;
            PageListComm.Parameters.AddWithValue("@TotalCount", SqlDbType.Int);
            PageListComm.Parameters.AddWithValue("@TotalPage", SqlDbType.Int);
            PageListComm.Parameters.AddWithValue("@PageIndex", PageIndex);
            PageListComm.Parameters.AddWithValue("@PageSize", PageSize);
            PageListComm.Parameters.AddWithValue("@Table", Table);
            PageListComm.Parameters.AddWithValue("@Column", Column);
            PageListComm.Parameters.AddWithValue("@OrderColumn", OrderColumn);
            PageListComm.Parameters.AddWithValue("@Condition", Condition);
            PageListComm.Parameters["@TotalCount"].Direction = ParameterDirection.Output;
            PageListComm.Parameters["@TotalPage"].Direction = ParameterDirection.Output;
            //DataTable dt = new DataTable();
            SqlDataReader sdr = DBHerp.DBHelper.SqlExecuteReaderParameters(PageListComm);
            //dt.Load(sdr);//返回datatable类型
            while (sdr.Read())
            {
                Model.PageList pl = new Model.PageList()
                {

                    Userid = Convert.ToInt32(sdr[0]),
                    Phone=sdr[1].ToString(),
                    RegisterTime = sdr[2].ToString(),
                    Account = sdr[3]==DBNull.Value?"未激活":sdr[3].ToString(),
                    PassWord = sdr[4] == DBNull.Value ? "未激活" : sdr[4].ToString(),
                    SN = sdr[5] == DBNull.Value ? 0 : Convert.ToInt32(sdr[5]),
                    ActivationTime = sdr[6] == DBNull.Value ? "未激活" : sdr[6].ToString(),
                    OutTime = sdr[7] == DBNull.Value ? "未激活" : sdr[7].ToString()
                };
                list.Add(pl);
            }
            DBHerp.DBHelper.CloseConn();
            Count = Convert.ToInt32(PageListComm.Parameters["@TotalCount"].Value);

            return list;
        }
    }
}
