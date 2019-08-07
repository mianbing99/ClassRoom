using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Data.SqlClient;
using System.Data;

namespace DAL {
   public   class VideoRouteDAL {
       private DBHerp.SQL Dbsql = new DBHerp.SQL();
       /// <summary>
       /// 根据视频ID查询视频路径
       /// </summary>
       /// <param name="Viid"></param>
       /// <returns></returns>
       public  List<Model.VideoRoute> SelectByViid(int Viid) {
           string sql = string.Format("select * from [dbo].[VideoRoute] where viid={0} and state=1",Viid);
           return MList(sql);
       }
       /// <summary>
       /// 查询没有视频的课文
       /// </summary>
       /// <returns></returns>
       public  SqlDataReader Selectqueshi() {
           string sql = string.Format("select b.CaID,b.caname, b.[canum],b.[page],b.author,b.[State],v.ViName,b.tid,t.[Year],t.isbn from [dbo].[TextBooks] t left join [dbo].[BooksCatalog] b on t.TextID=b.TextID left join [dbo].[Video] v on b.Viid=v.ViID where CaID not in (select caid from [dbo].[BooksCatalog] b right join [dbo].[Video] v on b.Viid = v.viid right join [dbo].[VideoRoute] r on v.ViID = r.ViID) and tid!=0");
           return Dbsql.ExReader(sql);
       }
       public DataTable Daochu() {
           SqlConnection conn = new SqlConnection(DBHerp.SQL.connstr);
           string sql = string.Format("select t.isbn,t.[Year],t.booksname,t.Study,gr.GrName, pr.prname,su.SuName,t.semester,ca.caname,ro.viname,ro.RouteAress,ro.Mp4 from [dbo].[TextBooks] t left join [dbo].[BooksCatalog] ca on t.TextID=ca.TextID left join [dbo].[Grade] gr on t.GrID=gr.GrID left join [dbo].[Press] pr on t.prid = pr.prid left join [dbo].[Subject] su on t.SuID=su.Suid left join [dbo].[Video] v on ca.Viid=v.viid left join [dbo].[VideoRoute] ro on v.ViID=ro.ViID");

           DataTable ta = new DataTable();
           SqlDataAdapter re = new SqlDataAdapter(sql, conn);
           DataSet ds = new DataSet();
           re.Fill(ds);
           ta = ds.Tables[0];
           return ta;
       }
       public bool Update(int roid,string Htv,string mp4) {
           string sql = string.Format("update [VideoRoute] set routearess='{0}',mp4='{1}' where VRID='{2}'", Htv, mp4, roid);
           return Dbsql.ExQuery(sql);
       }
       public bool insert(string Htv, string mp4,int viid,string viname) {
           string sql = string.Format("insert into VideoRoute values('{0}','{1}','{2}','{3}','1','1')", Htv, mp4,viid,viname);
           return Dbsql.ExQuery(sql);
       }
       public bool Delete(int Viid,string ViName,string Mp4) {
           string sql = string.Format("delete [dbo].[VideoRoute] where viid='{0}' and mp4='{1}' and ViName='{2}'",Viid,ViName,Mp4);
           return Dbsql.ExQuery(sql);
       }
       public bool Select(string mp4) {
           string sql = string.Format("Select * from [dbo].[VideoRoute] where mp4='{0}'", mp4);
           Model.VideoRoute ro = Mod(sql);
           if (ro.VRID != 0)
           {
               return true;
           } else {
               return false;
           }
       }
       public List<Model.VideoRoute> SelectViid(string mp4) {
           string sql = string.Format("Select * from [dbo].[VideoRoute] where mp4='{0}'", mp4);
           return MList(sql);
       }
       private List<Model.VideoRoute> MList(string sql) {
           SqlConnection conn = new SqlConnection(DBHerp.SQL.connstr);
           conn.Open();
           SqlCommand cmd = new SqlCommand(sql, conn);
           SqlDataReader re = cmd.ExecuteReader(CommandBehavior.CloseConnection);
           List<Model.VideoRoute> Vilist = new List<Model.VideoRoute>();
           while (re.Read()) {
               Model.VideoRoute Vi = new Model.VideoRoute();
               Vi.VRID = Convert.ToInt32(re["VRID"]);
               Vi.HTV = re["HTV"].ToString();
               Vi.ViID = Convert.ToInt32(re["viid"]);
               Vi.ViName = re["viname"].ToString();
               Vi.State = Convert.ToInt32(re["state"]);
               Vi.Mp4 = re["Mp4"].ToString();
               Vi.Vip = Convert.ToInt32(re["Vip"]);
               Vilist.Add(Vi);
           }
           re.Close(); re.Dispose();
           if (conn != null) {
               conn.Close();
               conn.Dispose();
           }
           return Vilist;
       }

       public Model.VideoRoute queryOneInfo(int vrid) 
       {
           string sql = string.Format("select VIID,ViName,State,Vip,Mp4,HTV,VRID from dbo.VideoRoute where VRID = {0}",vrid);
           return Mod(sql);
       }
      



       private Model.VideoRoute Mod(string sql) {
           SqlConnection conn = new SqlConnection(DBHerp.SQL.connstr);
           conn.Open();
           SqlCommand cmd = new SqlCommand(sql, conn);
           SqlDataReader re = cmd.ExecuteReader(CommandBehavior.CloseConnection);
           Model.VideoRoute Vi = new Model.VideoRoute();
           while (re.Read()) {
               Vi.VRID = Convert.ToInt32(re["VRID"]);
               Vi.HTV = re["HTV"].ToString();
               Vi.ViID = Convert.ToInt32(re["viid"]);
               Vi.ViName = re["viname"].ToString();
               Vi.State = Convert.ToInt32(re["state"]);
               Vi.Vip = Convert.ToInt32(re["Vip"]);
               Vi.Mp4 = re["Mp4"].ToString();
           }
           re.Close(); re.Dispose();
           if (conn != null) {
               conn.Close();
               conn.Dispose();
           }
           return Vi;
       }
   }
}
