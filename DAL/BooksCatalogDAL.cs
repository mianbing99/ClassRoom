using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Data.SqlClient;
using System.Data;
using Model;

namespace DAL
{
    public class BooksCatalogDAL
    {
        private DBHerp.SQL Dbsql = new DBHerp.SQL();
        /// <summary>
        /// 根据书本ID查询所有目录
        /// </summary>
        /// <param name="Textid"></param>
        /// <returns></returns>
        public List<Model.Catalog> seletelist(int Textid)
        {
            string sql = string.Format("select * from [dbo].[BooksCatalog] where textid={0}", Textid);
            return MoList(sql);

        }
        /// <summary>
        /// 查询此视频是否为vip视频
        /// </summary>
        /// <param name="viid"></param>
        /// <returns></returns>
        public bool VipState(int caid)
        {
            string sql = "select [State] from BooksCatalog where Caid=" + caid;
            SqlDataReader sdr=DBHerp.DBHelper.SqlExecuteReader(sql);
            if (Convert.ToInt32(sdr[0]) == 0)
            {
                return false;
            }
            else
                return true;
        }
        public List<Model.Catalog> SelectNotTid(int textid)
        {
            string sql = string.Format("select * from BooksCatalog where caid in (select tid from BooksCatalog where tid !=0) and tid!=0 and textid={0}", textid);
            return MoList(sql);
        }
        public List<Model.Catalog> Selectziji(int textid)
        {
            string sql = string.Format("select * from BooksCatalog where tid not in (select caid from booksCatalog where tid=0) and tid!=0 and textid={0}", textid);
            return MoList(sql);
        }
        /// <summary>
        /// 根据目录ID查询所有信息
        /// </summary>
        /// <param name="id"></param>
        /// <returns></returns>
        public Model.Catalog selectbyid(int id)
        {
            string sql = string.Format("select * from [dbo].[BooksCatalog] where caid={0}", id);
            return Mo(sql);

        }

        public DataTable select(int ts, int ys)
        {
            SqlConnection conn = new SqlConnection(DBHerp.SQL.connstr);
            conn.Open();
            string sql = string.Format(@"select top({0}) t.BooksName,su.suname,t.Semester, t.study, gr.GrName,pr.PrName,c.CaName,v.viid,r.routearess,r.Mp4,r.roid from [dbo].[TextBooks] t  
left join [dbo].[Subject] su  on t.suid = su.Suid left join
[dbo].[Grade] gr on t.GradeID = gr.GradeID left join
[dbo].[Press] pr  on t.PrID = pr.PrID left join
[dbo].[BooksCatalog] c on c.textid=t.textid  left join
Video v on c.viid = v.viid left join
[dbo].[VideoRoute] r on   v.Viid=r.ViID
where caid not in (select top({1}) caid from BooksCatalog where caid in (select CaID from BooksCatalog where caid not in(select caid from BooksCatalog where caid in (select tid from BooksCatalog where tid !=0)))) 
and caid  in (select CaID from BooksCatalog where caid not in(select caid from BooksCatalog where caid in (select tid from BooksCatalog where tid !=0)))", ts, ys);
            DataTable ta = new DataTable();
            SqlDataAdapter re = new SqlDataAdapter(sql, conn);
            DataSet ds = new DataSet();
            re.Fill(ds);
            ta = ds.Tables[0];
            if (conn != null)
            {
                conn.Close();
                conn.Dispose();
            }
            return ta;
        }
        public int selectsum()
        {
            string sql = string.Format(@"select count(*)  from [dbo].[TextBooks] t  
left join [dbo].[Subject] su  on t.suid = su.Suid left join
[dbo].[Grade] gr on t.GradeID = gr.GradeID left join
[dbo].[Press] pr  on t.PrID = pr.PrID left join
[dbo].[BooksCatalog] c on c.textid=t.textid  left join
Video v on c.viid = v.viid left join
[dbo].[VideoRoute] r on   v.Viid=r.ViID
where   tid!=0");
            return Dbsql.ExScalar(sql);
        }
        /// <summary>
        /// 查询所有数据
        /// </summary>
        /// <returns></returns>
        public DataTable select()
        {
            SqlConnection conn = new SqlConnection(DBHerp.SQL.connstr);
            conn.Open();
            string sql = string.Format(@"select  t.BooksName,c.CaName,s.suname,kemu, Test.Name,test.mp4 as testmp4,r.viname,r.routearess,r.mp4,CaID from textbooks t 
left join [dbo].[BooksCatalog] c on t.textid=c.TextID left join press pr on pr.prid = t.prid
left join Video v on c.Viid=v.ViID left join [dbo].[VideoRoute] r on r.viid = v.viid 
left join [dbo].[Grade] g on t.GradeID=g.GradeID left join [dbo].[Subject] s on s.Suid=t.SuID left join test on test.Name   like c.caname+'%' where   c.TID!=0 ");
            DataTable ta = new DataTable();
            SqlDataAdapter re = new SqlDataAdapter(sql, conn);
            DataSet ds = new DataSet();
            re.Fill(ds);
            ta = ds.Tables[0];
            if (conn != null)
            {
                conn.Close();
                conn.Dispose();
            }
            return ta;
        }
        public int selectsum(string GrName, string SuName, string CaName, string PrName, bool Mp4, bool htv, bool quanbu)
        {
            string where = string.Empty;
            if (GrName != "")
            {
                where += " and g.grname='" + GrName + "'";
            }
            if (CaName != "")
            {
                where += " and c.CaName like '%" + CaName + "%'";
            }
            if (SuName != "")
            {
                where += " and s.Suname='" + SuName + "'";
            }
            if (PrName != "")
            {
                where += " and pr.prname='" + PrName + "'";
            }
            if (!quanbu)
            {
                if (Mp4)
                {
                    where += " and r.mp4 is null ";
                }
                if (htv)
                {
                    where += " and r.mp4 is not null ";
                }
            }
            string sql = string.Format(@"select count(*)  from textbooks t 
left join [dbo].[BooksCatalog] c on t.textid=c.TextID left join press pr on pr.prid = t.prid
left join Video v on c.Viid=v.ViID left join [dbo].[VideoRoute] r on r.viid = v.viid 
left join [dbo].[Grade] g on t.GradeID=g.GradeID left join [dbo].[Subject] s on s.Suid=t.SuID 
where  c.TID!=0 " + where + "");
            return Dbsql.ExScalar(sql);
        }
        public DataTable select(int ts, int ys, string GrName, string SuName, string CaName, string PrName, bool Mp4, bool htv, bool quanbu)
        {
            SqlConnection conn = new SqlConnection(DBHerp.SQL.connstr);
            conn.Open();
            string where = string.Empty;
            if (GrName != "")
            {
                where += " and g.grname='" + GrName + "'";
            }
            if (CaName != "")
            {
                where += " and c.CaName like '%" + CaName + "%'";
            }
            if (SuName != "")
            {
                where += " and s.Suname='" + SuName + "' and kemu = '" + SuName + "'";
            }
            if (PrName != "")
            {
                where += " and pr.prname='" + PrName + "'";
            }
            if (!quanbu)
            {
                if (Mp4)
                {
                    where += " and r.mp4 is null ";
                }
                if (htv)
                {
                    where += " and r.mp4 is not null ";
                }
            }

            string sql = string.Format(@"select top({0}) t.BooksName,c.CaName,s.suname,kemu, Test.Name,test.mp4 as testmp4,r.viname,r.routearess,r.mp4,CaID from textbooks t 
left join [dbo].[BooksCatalog] c on t.textid=c.TextID left join press pr on pr.prid = t.prid
left join Video v on c.Viid=v.ViID left join [dbo].[VideoRoute] r on r.viid = v.viid 
left join [dbo].[Grade] g on t.GradeID=g.GradeID left join [dbo].[Subject] s on s.Suid=t.SuID left join test on test.Name   like c.caname+'%' where CaID not in (select top({1}) CaID from textbooks t 
left join [dbo].[BooksCatalog] c on t.textid=c.TextID 
left join Video v on c.Viid=v.ViID left join [dbo].[VideoRoute] r on r.viid = v.viid 
left join [dbo].[Grade] g on t.GradeID=g.GradeID left join [dbo].[Subject] s on s.Suid=t.SuID left join test on  test.Name   like c.caname+'%' where  c.TID!=0 " + where + " ) and   c.TID!=0  " + where + "", ts, ys);
            DataTable ta = new DataTable();
            SqlDataAdapter re = new SqlDataAdapter(sql, conn);
            DataSet ds = new DataSet();
            re.Fill(ds);
            ta = ds.Tables[0];
            if (conn != null)
            {
                conn.Close();
                conn.Dispose();
            }
            //for (int i = 0; i < ta.Rows.Count; i++) {
            //    if (ta.Rows[i]["kemu"].ToString() != ta.Rows[i]["suname"].ToString()) {
            //        ta.Rows.Remove(ta.Rows[i]);
            //        i = i - 1;
            //    }
            //}
            //while (ta.Rows.Count > 30) {
            //    ta.Rows.Remove(ta.Rows[ta.Rows.Count-1]);
            //}
            return ta;
        }
        public List<Model.Catalog> select(string GrName, string SuName, string CaName, bool Mp4, bool htv, bool quanbu, int ts, int ys)
        {
            string where = string.Empty;
            if (GrName != "")
            {
                where += " and g.grname='" + GrName + "'";
            }
            if (CaName != "")
            {
                where += " and c.CaName like '%" + CaName + "%'";
            }
            if (SuName != "")
            {
                where += " and s.Suname='" + SuName + "'";
            }
            if (!quanbu)
            {
                if (Mp4)
                {
                    where += " and mp4 is null ";
                }
                else
                {
                    where += " and mp4 is not null ";
                }
                if (htv)
                {
                    where += " and routearess is null ";
                    where += " and routearess is not null ";
                }
            }

            string sql = string.Format(@"select top({0}) t.BooksName,c.CaName,r.viname,r.routearess,r.mp4,CaID from textbooks t 
left join [dbo].[BooksCatalog] c on t.textid=c.TextID 
left join Video v on c.Viid=v.ViID left join [dbo].[VideoRoute] r on r.viid = v.viid 
left join [dbo].[Grade] g on t.GradeID=g.GradeID left join [dbo].[Subject] s on s.Suid=t.SuID 
where CaID not in (select top({1}) CaID from textbooks t 
left join [dbo].[BooksCatalog] c on t.textid=c.TextID 
left join Video v on c.Viid=v.ViID left join [dbo].[VideoRoute] r on r.viid = v.viid 
left join [dbo].[Grade] g on t.GradeID=g.GradeID left join [dbo].[Subject] s on s.Suid=t.SuID 
where  c.TID!=0   and g.grname='二年级' and s.Suname='语文') and   c.TID!=0    " + where + "", ts, ys);
            return MoList(sql);
        }
        public DataTable SelectSu(string SuName)
        {
            SqlConnection conn = new SqlConnection(DBHerp.SQL.connstr);
            conn.Open();
            string sql = string.Format(@"select t.BooksName,g.grname,c.CaName,s.suname,kemu, Test.Name,test.mp4 as testmp4,r.viname,r.routearess,r.mp4,CaID,pr.prname from textbooks t 
left join [dbo].[BooksCatalog] c on t.textid=c.TextID left join press pr on pr.prid = t.prid
left join Video v on c.Viid=v.ViID left join [dbo].[VideoRoute] r on r.viid = v.viid 
left join [dbo].[Grade] g on t.GradeID=g.GradeID left join [dbo].[Subject] s on s.Suid=t.SuID left join test on test.Name   like c.caname+'%' where   c.TID!=0   and s.Suname='{0}' and kemu = '{0}' order by caid
", SuName);
            DataTable ta = new DataTable();
            SqlDataAdapter re = new SqlDataAdapter(sql, conn);
            DataSet ds = new DataSet();
            re.Fill(ds);
            ta = ds.Tables[0];
            if (conn != null)
            {
                conn.Close();
                conn.Dispose();
            }
            return ta;
        }
        public DataTable SelectCaBySu(string SuName)
        {
            SqlConnection conn = new SqlConnection(DBHerp.SQL.connstr);
            conn.Open();
            string sql = string.Format(@"select t.BooksName,g.grname,c.CaName,s.suname,r.viname,r.routearess,r.mp4,CaID,pr.prname from textbooks t 
left join [dbo].[BooksCatalog] c on t.textid=c.TextID left join press pr on pr.prid = t.prid
left join Video v on c.Viid=v.ViID left join [dbo].[VideoRoute] r on r.viid = v.viid 
left join [dbo].[Grade] g on t.GradeID=g.GradeID left join [dbo].[Subject] s on s.Suid=t.SuID  where   c.TID!=0   and s.Suname='语文'  order by caid
", SuName);
            DataTable ta = new DataTable();
            SqlDataAdapter re = new SqlDataAdapter(sql, conn);
            DataSet ds = new DataSet();
            re.Fill(ds);
            ta = ds.Tables[0];
            if (conn != null)
            {
                conn.Close();
                conn.Dispose();
            }
            return ta;
        }
        /// <summary>
        /// 根据id查询tid
        /// 查询父级目录的子目录
        /// </summary>
        /// <returns></returns>
        public List<Model.Catalog> SelectForTid(int id)
        {
            string sql = string.Format("select * from BooksCatalog where TID={0}", id);
            return MoList(sql);
        }
        public bool Selectfujimulu(int id)
        {
            string sql = string.Format("select tid from bookscatalog where caid={0}", id);
            if (Convert.ToInt32(Dbsql.ExScalar(sql)) == 0)
            {
                return true;
            }
            else
            {
                return false;
            }
        }
        /// <summary>
        /// 根据tid查询单元名称
        /// </summary>
        /// <param name="id"></param>
        /// <returns></returns>
        public string SelectByTid(int id)
        {
            string sql = string.Format("select CaName from [dbo].[BooksCatalog] where CaID={0}", id);
            string str = string.Empty;
            SqlConnection conn = new SqlConnection(DBHerp.SQL.connstr);
            conn.Open();
            SqlCommand cmd = new SqlCommand(sql, conn);
            cmd.CommandTimeout = 600;
            SqlDataReader re = cmd.ExecuteReader(CommandBehavior.CloseConnection);
            if (re.Read())
            {
                str = re["caname"].ToString();
            }
            re.Close();
            re.Dispose();
            if (conn != null)
            {
                conn.Close();
                conn.Dispose();
            }
            return str;
        }
        //导出表格需要的
        public DataTable SelectAll()
        {
            SqlConnection conn = new SqlConnection(DBHerp.SQL.connstr);
            conn.Open();
            string sql = string.Format("select b.CaID,b.caname, b.[canum],b.[page],b.author,b.[State],v.ViName,b.tid,t.[Year],t.isbn,r.RouteAress from [dbo].[TextBooks] t left join [dbo].[BooksCatalog] b on t.TextID=b.TextID left join [dbo].[Video] v on b.Viid=v.ViID left join VideoRoute r on v.ViID=r.ViID where tid!=0");
            SqlCommand cmd = new SqlCommand(sql, conn);
            cmd.CommandTimeout = 600;
            SqlDataReader re = cmd.ExecuteReader();
            DataTable dt = new DataTable();
            dt.Columns.Add("ISBN"); //0
            dt.Columns.Add("年份版本"); //1
            dt.Columns.Add("单元目录");//2
            dt.Columns.Add("目录序号");//3
            dt.Columns.Add("课文类型");//4
            dt.Columns.Add("课文名称");//5
            dt.Columns.Add("作者");//6
            dt.Columns.Add("页码");//7
            dt.Columns.Add("视频名称");//8
            dt.Columns.Add("视频路径");//9
            int i = 0;
            while (re.Read())
            {
                if (i > 0)
                {
                    if (dt.Rows[i - 1][5].ToString() != re["caname"].ToString())
                    {
                        dt.Rows.Add();
                        dt.Rows[i][0] = "ISBN" + re["isbn"].ToString();
                        dt.Rows[i][1] = re["year"].ToString();
                        dt.Rows[i][2] = SelectByTid(Convert.ToInt32(re["tid"]));
                        dt.Rows[i][3] = re["canum"].ToString();
                        dt.Rows[i][4] = re["state"].ToString();
                        dt.Rows[i][5] = re["caname"].ToString();
                        dt.Rows[i][6] = re["author"].ToString();
                        dt.Rows[i][7] = re["page"].ToString();
                        //if (re["viName"] != null) {
                        dt.Rows[i][8] = re["viName"].ToString();
                        //}
                        dt.Rows[i][9] = re["routearess"];
                        i++;
                    }
                }
                else
                {
                    dt.Rows.Add();
                    dt.Rows[i][0] = "ISBN" + re["isbn"].ToString();
                    dt.Rows[i][1] = re["year"].ToString();
                    dt.Rows[i][2] = SelectByTid(Convert.ToInt32(re["tid"]));
                    dt.Rows[i][3] = re["canum"].ToString();
                    dt.Rows[i][4] = re["state"].ToString();
                    dt.Rows[i][5] = re["caname"].ToString();
                    dt.Rows[i][6] = re["author"].ToString();
                    dt.Rows[i][7] = re["page"].ToString();
                    //if (re["viName"] != null) {
                    dt.Rows[i][8] = re["viName"].ToString();
                    //}
                    dt.Rows[i][9] = re["routearess"];
                    i++;
                }
            }
            re.Close();
            re.Dispose();
            if (conn != null)
            {
                conn.Close();
                conn.Dispose();
            }
            return dt;

        }
        public bool SelectTid(int tid)
        {
            string sql = string.Format("select count(1)  from [dbo].[BooksCatalog] where tid={0}", tid);
            if (Dbsql.ExScalar(sql) > 0)
            {
                return true;
            }
            else
            {
                return false;
            }
        }
        public void Insertdaoru(string sql)
        {
            Dbsql.ExQuery(sql);
        }
        public int SelectViidByCaid(int Caid)
        {
            string sql = string.Format("select viid from  [dbo].[BooksCatalog] where caid={0}", Caid);
            return Dbsql.ExScalar(sql);
        }
        public bool UpdateViidByid(int Caid, int Viid)
        {
            string sql = string.Format("update [dbo].[BooksCatalog] set Viid={0} where CaID={1}", Viid, Caid);
            return Dbsql.ExQuery(sql);
        }
        private List<Model.Catalog> MoList(string sql)
        {
            SqlConnection conn = new SqlConnection(DBHerp.SQL.connstr);
            conn.Open();
            SqlCommand cmd = new SqlCommand(sql, conn);
            cmd.CommandTimeout = 600;
            SqlDataReader re = cmd.ExecuteReader(CommandBehavior.CloseConnection);
            List<Model.Catalog> CaList = new List<Model.Catalog>();
            while (re.Read())
            {
                Model.Catalog ca = new Model.Catalog();
                ca.Author = re["Author"].ToString();
                ca.CaID = Convert.ToInt32(re["caid"]);
                ca.CaName = Convert.ToString(re["caname"]);
                ca.CaNum = Convert.ToString(re["canum"]);
                ca.Page = Convert.ToInt32(re["page"]);
                ca.State = re["state"].ToString();
                ca.TextID = Convert.ToInt32(re["textid"]);
                ca.TID = Convert.ToInt32(re["tid"]);
                ca.Viid = Convert.ToInt32(re["viid"]);
                CaList.Add(ca);
            }
            re.Close();
            re.Dispose();
            if (conn != null)
            {
                conn.Close();
                conn.Dispose();
            }
            return CaList;
        }
        private Model.Catalog Mo(string sql)
        {
            SqlConnection conn = new SqlConnection(DBHerp.SQL.connstr);
            conn.Open();
            SqlCommand cmd = new SqlCommand(sql, conn);
            cmd.CommandTimeout = 600;
            SqlDataReader re = cmd.ExecuteReader(CommandBehavior.CloseConnection);
            Model.Catalog ca = new Model.Catalog();
            if (re.Read())
            {
                ca.Author = re["Author"].ToString();
                ca.CaID = Convert.ToInt32(re["caid"]);
                ca.CaName = Convert.ToString(re["caname"]);
                ca.CaNum = Convert.ToString(re["canum"]);
                ca.Page = Convert.ToInt32(re["page"]);
                ca.State = re["state"].ToString();
                ca.TextID = Convert.ToInt32(re["textid"]);
                ca.TID = Convert.ToInt32(re["tid"]);
                ca.Viid = Convert.ToInt32(re["viid"]);
            }
            re.Close();
            re.Dispose();
            if (conn != null)
            {
                conn.Close();
                conn.Dispose();
            }
            return ca;
        }

        /// <summary>
        /// 分页查询
        /// </summary>
        /// <param name="currPage"></param>
        /// <param name="Table"></param>
        /// <param name="Column"></param>
        /// <param name="Condition"></param>
        /// <param name="OrderColumn"></param>
        /// <param name="Count"></param>
        /// <param name="pageSize"></param>
        /// <returns></returns>
        public List<Model.BooksCatalog> CatalogList(int currPage, string Table,string Column, string Condition, string OrderColumn, out int Count, int pageSize) 
        {
            List<Model.BooksCatalog> list = new List<BooksCatalog>();
            SqlCommand PageListComm = null;

            string sqlPageList = "[dbo].[prc_GetPager]";
            PageListComm = new SqlCommand(sqlPageList, DBHerp.DBHelper.conn);
            PageListComm.CommandType = CommandType.StoredProcedure;
            PageListComm.Parameters.AddWithValue("@PageIndex", currPage);
            PageListComm.Parameters.AddWithValue("@Table", Table);
            PageListComm.Parameters.AddWithValue("@Column", Column);
            PageListComm.Parameters.AddWithValue("@Condition", Condition);
            PageListComm.Parameters.AddWithValue("@OrderColumn", OrderColumn);
            PageListComm.Parameters.AddWithValue("@TotalCount", SqlDbType.Int);
            PageListComm.Parameters.AddWithValue("@TotalPage", SqlDbType.Int);
            PageListComm.Parameters.AddWithValue("@pageSize", pageSize);
            PageListComm.Parameters["@TotalCount"].Direction = ParameterDirection.Output;
            PageListComm.Parameters["@TotalPage"].Direction = ParameterDirection.Output;
            SqlDataReader sdr = DBHerp.DBHelper.SqlExecuteReaderParameters(PageListComm);
            while (sdr.Read())
            {
                Model.BooksCatalog bc = new Model.BooksCatalog()
                {
                    CaID = Convert.ToInt32(sdr[0]),
                    ISBN = sdr[1].ToString(),
                    BooksName = sdr[2].ToString(),
                    CaName = sdr[3].ToString()
                };
                list.Add(bc);
            }
            DBHerp.DBHelper.CloseConn();
            Count = Convert.ToInt32(PageListComm.Parameters["@TotalCount"].Value);
            return list;
        }

        public int deleteInfo(int CataLogId) 
        {
            string sql = "delete from BooksCatalog where CaID = @CaID";
            SqlCommand comm = new SqlCommand(sql);
            comm.Parameters.AddWithValue("@CaID",CataLogId);
            int reader = DBHerp.DBHelper.SqlExecuteNonQueryParameters(comm);
            DBHerp.DBHelper.CloseConn();
            return reader;
        }

        public int addInfo(BooksCatalog bc) 
        {

            string sql = "";
            return 0;
        }
    }
}
