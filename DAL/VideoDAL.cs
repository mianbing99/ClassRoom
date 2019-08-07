using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Text;

namespace DAL {
   public  class VideoDAL {
       DBHerp.SQL db = new DBHerp.SQL();
       public int Insert(string Caname) {
           string sql = string.Format("insert into video values('{0}') select @@identity", Caname);
           return db.ExScalar(sql);
       }
       private Model.Video Mo(string sql ) {
           SqlConnection conn = new SqlConnection(DBHerp.SQL.connstr);
           conn.Open();
           SqlCommand cmd = new SqlCommand(sql, conn);
           SqlDataReader re = cmd.ExecuteReader(CommandBehavior.CloseConnection);
           Model.Video Vi = new Model.Video();
           while (re.Read()) {
               Vi.Viid = Convert.ToInt32(re["Viid"]);
               Vi.ViName = re["viname"].ToString();
               
           }
           return Vi;
       }
       private List<Model.Video> MoList(string sql ) {
           SqlConnection conn = new SqlConnection(DBHerp.SQL.connstr);
           conn.Open();
           SqlCommand cmd = new SqlCommand(sql, conn);
           SqlDataReader re = cmd.ExecuteReader(CommandBehavior.CloseConnection);
           List<Model.Video> ViList = new List<Model.Video>();
           while (re.Read()) {
               Model.Video Vi = new Model.Video();
               Vi.Viid = Convert.ToInt32(re["Viid"]);
               Vi.ViName = re["viname"].ToString();
               ViList.Add(Vi);
           }
           return ViList;
       }

    }
}
