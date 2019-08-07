using System;
using System.Collections;
using System.Collections.Generic;
using System.Data;
using System.IO;
using System.Linq;
using System.Text.RegularExpressions;
using System.Web;

namespace Webz {
    public static class VideoHrep {
        static string Videopath = @"http://dl.icoxtech.com:88/名师高清视频/";
        public static bool yanzhen(string path) { //stri  视频名称.*  path 根据表格读取的学段年级作为路径
          
            if (FTP.JudgeFileExist02(path)) {
                return true ;
            } else {
                return false;
            }
        }
        public static bool yanzhenV(string path, string FileName) {
            string[] files = Directory.GetFiles(path, FileName);
            if (files.Length == 0) {
                return false;
            } else {
                return true;
            }
        }

        public static bool StrInArray<T>(string str, List<T> strarry) {
            if (str == null)
                return false;
            if (strarry == null || strarry.Count == 0)
                return false;

            for (int i = 0; i < strarry.Count; i++) {
                if (strarry[i].ToString() == null)
                    continue;
                if (str == strarry[i].ToString())
                    return true;
            }

            return false;
        }
        public static DataTable UniteDataTable(DataTable dt1, DataTable dt2, string DTName) {
            DataTable dt3 = dt1.Clone();
            for (int i = 0; i < dt2.Columns.Count; i++) {
                dt3.Columns.Add(dt2.Columns[i].ColumnName);
            }
            object[] obj = new object[dt3.Columns.Count];

            for (int i = 0; i < dt1.Rows.Count; i++) {
                dt1.Rows[i].ItemArray.CopyTo(obj, 0);
                dt3.Rows.Add(obj);
            }

            if (dt1.Rows.Count >= dt2.Rows.Count) {
                for (int i = 0; i < dt2.Rows.Count; i++) {
                    for (int j = 0; j < dt2.Columns.Count; j++) {
                        dt3.Rows[i][j + dt1.Columns.Count] = dt2.Rows[i][j].ToString();
                    }
                }
            } else {
                DataRow dr3;
                for (int i = 0; i < dt2.Rows.Count - dt1.Rows.Count; i++) {
                    dr3 = dt3.NewRow();
                    dt3.Rows.Add(dr3);
                }
                for (int i = 0; i < dt2.Rows.Count; i++) {
                    for (int j = 0; j < dt2.Columns.Count; j++) {
                        dt3.Rows[i][j + dt1.Columns.Count] = dt2.Rows[i][j].ToString();
                    }
                }
            }
            dt3.TableName = DTName; //设置DT的名字
            return dt3;
        }
        public static DataTable getOnePageTable(DataTable dtAll, int pageNo, int pageSize) {
            var totalCount = dtAll.Rows.Count;
            var totalPage = getTotalPage(totalCount, pageSize);
            var currentPage = pageNo;
            currentPage = (currentPage > totalPage ? totalPage : currentPage);//如果PageNo过大，则较正PageNo=PageCount
            currentPage = (currentPage <= 0 ? 1 : currentPage);//如果PageNo<=0，则改为首页
            //----克隆表结构到新表
            var onePageTable = dtAll.Clone();
            //----取出1页数据到新表
            var rowBegin = (currentPage - 1) * pageSize;
            var rowEnd = currentPage * pageSize;
            rowEnd = (rowEnd > totalCount ? totalCount : rowEnd);
            for (var i = rowBegin; i <= rowEnd - 1; i++) {
                var newRow = onePageTable.NewRow();
                var oldRow = dtAll.Rows[i];
                foreach (DataColumn column in dtAll.Columns) {
                    newRow[column.ColumnName] = oldRow[column.ColumnName];
                }
                onePageTable.Rows.Add(newRow);
            }
            return onePageTable;
        }
        public static int getTotalPage(int totalCount, int pageSize) {
            var totalPage = (totalCount / pageSize) + (totalCount % pageSize > 0 ? 1 : 0);
            return totalPage;
        }
        public static string Spit(String hexData) {
            return Regex.Replace(hexData, "[ \\[ \\] \\^ \\-_*×――(^)$%~!@#$…&%￥—+=<>《》!！??？:：•`·、。，；,.;\"‘’“”-]", "").ToUpper();
        }
        public static DataTable CloneTable(DataTable fy,DataTable dt) {
            for (int i = 0; i < fy.Rows.Count; i++) {
                var newRows = dt.NewRow();
                var oldRows = fy.Rows[i];
                foreach (DataColumn column in fy.Columns) {
                    newRows[column.ColumnName] = oldRows[column.ColumnName];
                }
                dt.Rows.Add(newRows);
            }
            return dt;
        }
        public static void InsertXuhao(DataTable dt,string Name) {
            for (int i = 0; i < dt.Rows.Count; i++) {
                if (dt.Columns[Name] == null) {
                    dt.Columns.Add(Name);
                }
                dt.Rows[i][Name] = i + 1;
            }
        }

      
    }
}