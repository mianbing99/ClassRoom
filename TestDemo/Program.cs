using BLL;
using DAL;
using Model;
using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TestDemo
{
    class Program
    {
        static void Main(string[] args)
        {
            int pageIndex = 1;
            string Table = "VideoRoute left join (select ROW_NUMBER() OVER(order by TempID) Tid,* from Temp_PageList) tp on tp.VRID=VideoRoute.VRID ";
            string Column = "tp.Tid,tp.GradeID,tp.PrID,tp.Suid,videoRoute.ViID,videoRoute.ViName,videoRoute.State,videoRoute.Vip,videoRoute.Mp4,videoRoute.HTV,videoRoute.VRID";
            string Condition = "  tp.BooksName like '%%' and tp.GradeID = 27 and tp.Suid = 14 and tp.PrID = 15 and tp.未匹配='' "; 
            string OrderColumn = "tp.Tid" ; 
            int Count = 0; 
            int pageSize = 10;
            int pageCount = 0;
            //List<Model.FeedBack> list = new List<Model.FeedBack>();
            //SqlCommand PageListComm = null;
            //DateTime dt = DateTime.Now;
            //string sqlPageList = "[dbo].[prc_GetPager]";
            //PageListComm = new SqlCommand(sqlPageList, DBHerp.DBHelper.conn);
            //PageListComm.CommandType = CommandType.StoredProcedure;
            //PageListComm.Parameters.AddWithValue("@PageIndex", pageIndex);
            //PageListComm.Parameters.AddWithValue("@Table", Table);
            //PageListComm.Parameters.AddWithValue("@Column", Column);
            //PageListComm.Parameters.AddWithValue("@Condition", Condition);
            //PageListComm.Parameters.AddWithValue("@OrderColumn", OrderColumn);
            //PageListComm.Parameters.AddWithValue("@TotalCount", SqlDbType.Int);
            //PageListComm.Parameters.AddWithValue("@TotalPage", SqlDbType.Int);
            //PageListComm.Parameters.AddWithValue("@pageSize", pageSize);
            //PageListComm.Parameters["@TotalCount"].Direction = ParameterDirection.Output;
            //PageListComm.Parameters["@TotalPage"].Direction = ParameterDirection.Output;
            //SqlDataReader sdr = DBHerp.DBHelper.SqlExecuteReaderParameters(PageListComm);
            //while (sdr.Read())
            //{
            //    Model.FeedBack fb = new Model.FeedBack()
            //  {

            //      FeedBackID = Convert.ToInt32(sdr[0]),
            //      Grade = sdr[1].ToString(),
            //      Phone = sdr[2].ToString(),
            //      FeedBackNR = sdr[3].ToString(),
            //      FeedBackDate = sdr[4].ToString(),
            //      Processing = sdr[5].ToString(),
            //      ProcessingName = sdr[6].ToString(),
            //      Stata = sdr[7].ToString()
            //  };
            //    list.Add(fb);
            //}
            //DBHerp.DBHelper.CloseConn();
            //Count = Convert.ToInt32(PageListComm.Parameters["@TotalCount"].Value);

            //List<Model.VideoRoute> list = DAL.VideoInfoDAL.selectAllInfo(pageIndex, pageSize, out Count, out pageCount, Table, Column, null, OrderColumn);

            //string TbnName = " and 1231 ";
            ////Console.WriteLine(TbnName.Substring(3));

            //TbnName = TbnName.Replace("]", "]%");
            //TbnName = TbnName.Replace("[", "");
            //TbnName = TbnName.Trim();

            //CataLogBLL bll = new CataLogBLL();
            //string[] array = new string[] { "58568" };
            //if (bll.selectTextId("")==null)
            //{

            //Console.WriteLine(bll.selectTextId("111"));

            //}

            //CataLogDAL dal = new CataLogDAL();

            //if (dal.selectAlreadyCaID("",0) == null)
            //{
            //    Console.WriteLine("为空");
            //}
            //else
            //{
            //    Console.WriteLine("9787107312441");
            //}
            //Console.WriteLine(dal.selectAlreadyCaID("", 0));

            //Console.WriteLine("当前值"+algorithm(1000));
            CataLogBLL bll = new CataLogBLL();
            Model.BooksCatalog catalog = bll.selectOne(18238);
            catalog.SubTextName = bll.selectOne(18238).CaName;
            catalog.TextName = bll.selectOne(catalog.TID).CaName;
            catalog.CaName = bll.selectOne(bll.selectCaID(catalog.TID)).CaName;

            Console.ReadLine();
        }
        
        public static int algorithm(int num)
        {
            int a = 0;
            Console.WriteLine("调用前："+num);
            if(num<0){
                a = -1;
                return -1;
            }
            if(num==0)
            {
                return 0;
            }
            if(num==1){
                return 1;
            }
            return algorithm(num - 1) + algorithm(num-2);
        }
    }
}
