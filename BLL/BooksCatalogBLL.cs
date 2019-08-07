using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using DAL;

namespace BLL {
  public   class BooksCataLogBLL {
       DAL.BooksCatalogDAL Dal = new DAL.BooksCatalogDAL();
      /// <summary>
      /// 根据书本ID查询所有目录
      /// </summary>
      /// <param name="Textid"></param>
      /// <returns></returns>
      public  List<Model.Catalog> SelectList(int Textid) {
          return Dal.seletelist(Textid);
      }
      /// <summary>
        /// 查询此视频是否为vip视频
        /// </summary>
        /// <param name="viid"></param>
        /// <returns></returns>
      public bool VipState(int caid)
      {
          return Dal.VipState(caid);
      }
      /// <summary>
      /// 根据目录ID查询所有信息
      /// </summary>
      /// <param name="id"></param>
      /// <returns></returns>
      public  Model.Catalog SelectByID(int id) {
          return Dal.selectbyid(id);
      }
      public int SelectViidByCaid(int Caid) {
          return Dal.SelectViidByCaid(Caid);
      }
      public DataTable select(int ts, int ys) {
          return Dal.select(ts, ys);
      }
      public int selectsum() {
          return Dal.selectsum();
      }
      public List<Model.Catalog> select(string GrName, string SuName, string CaName, bool Mp4, bool htv, bool quanbu, int ts, int ys) {
          return Dal.select(GrName,SuName,CaName,Mp4,htv,quanbu,ts,ys);
      }
      /// <summary>
      /// 根据tid查询单元名称
      /// </summary>
      /// <param name="id"></param>
      /// <returns></returns>
      public  string SelectByTid(int id) {
          return Dal.SelectByTid(id);
      }
      public DataTable SelectAll() {
          return Dal.SelectAll();
      }
      public  bool SelectTid(int tid) {
          return Dal.SelectTid(tid);
      }
      /// <summary>
      /// 根据目录id 查询子级的tid 
      /// </summary>
      /// <param name="id"></param>
      /// <returns></returns>
      public  List<Model.Catalog> SelectForTid(int id) {
          return Dal.SelectForTid(id);
      }
      /// <summary>
      /// 查询所有父级的目录
      /// </summary>
      /// <param name="id"></param>
      /// <returns></returns>
      public  bool Selectfujimulu(int id) {
          return Dal.Selectfujimulu(id);
      }
      public DataTable SelectSu(string SuName) {
          return Dal.SelectSu(SuName);
      }
      public DataTable SelectCaBySu(string SuName) {
          return Dal.SelectCaBySu(SuName);
      }
      public  void Insertdaoru(string sql) {
          Dal.Insertdaoru(sql);
      }
      public bool UpdateViidByid(int Caid, int Viid) {
          return Dal.UpdateViidByid(Caid, Viid);
      }
      public List<Model.Catalog> SelectNotTid(int textid) {
          return Dal.SelectNotTid(textid);
      }
      public List<Model.Catalog> Selectziji(int textid) {
          return Dal.Selectziji(textid);
      }
      /// <summary>
      /// 根据条件查询
      /// </summary>
      /// <param name="ts">每页的条数</param>
      /// <param name="ys">页数 = 当前页数-1 * 每页条数</param>
      /// <param name="GrName"> Gr 年级ID</param>
      /// <param name="PrName"> Pr 出版社id</param>
      /// <param name="Sem"> 上下册</param>
      /// <param name="Study">学段</param>
      /// <param name="CaName"> 课文名称</param>
      /// <returns></returns>
      public DataTable select(int ts, int ys, string GrName, string SuName, string CaName,string PrName, bool Mp4, bool htv, bool quanbu) {
          return Dal.select(ts, ys, GrName, SuName,  CaName,PrName, Mp4, htv, quanbu);
      }
      /// <summary>
      /// 根据条件查询所有数据条数
      /// </summary>
      /// <param name="GrName"> Gr 年级ID</param>
      /// <param name="PrName"> Pr 出版社id</param>
      /// <param name="Sem"> 上下册</param>
      /// <param name="Study">学段</param>
      /// <param name="CaName"> 课文名称</param>
      /// <returns></returns>
      public int selectsum(string GrName, string SuName, string CaName,string PrName , bool Mp4, bool htv, bool quanbu) {
          return Dal.selectsum(GrName, SuName, CaName,PrName, Mp4, htv, quanbu);
      }
      public DataTable select() {
          return Dal.select();
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
      public List<Model.BooksCatalog> CatalogList(int currPage, string Table, string Column, string Condition, string OrderColumn, out int Count, int pageSize)
      {
          return Dal.CatalogList(currPage, Table, Column, Condition, OrderColumn, out Count, pageSize);
      }


      public int deleteInfo(int CataLogId) 
      {
          return Dal.deleteInfo(CataLogId);
      }
    }
}
