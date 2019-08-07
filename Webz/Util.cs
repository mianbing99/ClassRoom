using System;
using System.Collections;
using System.Collections.Generic;
using System.Collections.Specialized;
using System.Configuration;
using System.Data;
using System.IO;
using System.Linq;
using System.Net;
using System.Runtime.InteropServices;
using System.Text.RegularExpressions;
using System.Web;
using System.Web.Security;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace Webz {
    public class Util {
        public static int pageindex = 1;//分页变量
        //日期格式类型
        public const string DATA_FORMAT = "20"; //"yyyy-mm-dd hh:mm:ss.ms";

        /* 方法详细参数
         *  arrayAttr[0]	1:彩色,0:黑白	arrayAttr[1]	动画指令条数
            arrayAttr[2]	多媒体个数		arrayAttr[3]	视频指令条数
            arrayAttr[4]	Flash个数		arrayAttr[5]	RPC指令数
            arrayAttr[6]	白板指令数(BBS)	arrayAttr[7]	VideoBBS指令数	
            arrayAttr[16]	试题总数		arrayAttr[17]	填空题个数
            arrayAttr[18]	选择题个数		arrayAttr[19]	完形填空个数
            arrayAttr[20]	是非题个数		arrayAttr[21]	听力题个数
            arrayAttr[22]	阅读理解个数	arrayAttr[23]	短文改错
            arrayAttr[24]	自定义测验个数
         * */
        /// <summary>
        /// 读取文件特性  //NESN.dll 最好丢到 System32 目录下
        /// </summary>
        /// <param name="fileName">积件文件路径</param>
        /// <param name="arrayAttr">返回属性集合</param>
        /// <returns></returns>
        [DllImport(@"NESN.dll", EntryPoint = "GetNpCoursewareAttribute")]
        public static extern int GetFileProperty(string fileName, [In, Out] uint[] arrayAttr);


        /// <summary>
        /// MD5字符串函数
        /// </summary>
        /// <param name="str">要转换的字符串</param>
        /// <returns>转换后的字符串</returns>
        public static string ToMD5(string str) {
            return FormsAuthentication.HashPasswordForStoringInConfigFile(str, "MD5");
        }

        /// <summary>
        /// 是否是数字字符串
        /// </summary>
        /// <param name="str"></param>
        /// <returns></returns>
        public static bool IsInteger(string str) {
            bool flag = true;

            try {
                int temp = Convert.ToInt32(str);
            } catch {
                flag = false;
            }
            return flag;

        }

        /// <summary>
        /// 判断字符串是否为整数
        /// </summary>
        /// <param name="str"></param>
        /// <returns></returns>
        public static bool IsNum(String str) {
            for (int i = 0; i < str.Length; i++) {
                if (!Char.IsNumber(str, i))
                    return false;
            }
            return true;
        }



        /// <summary>
        /// 查找控件，如果有子控件， 递归查找
        /// </summary>
        /// <param name="c"></param>
        /// <param name="name">控件ID</param>
        /// <returns></returns>
        public static Control FindControl(Control c, string name) {
            Control c0 = c.FindControl(name.ToLower());
            if (c0 != null) {
                return c0;
            }
            foreach (Control c1 in c.Controls) {
                c0 = FindControl(c1, name);
                if (c0 != null) {
                    return c0;
                }
            }
            return null;
        }


        /// <summary>
        /// 删除DataGrid中的记录
        /// </summary>
        /// <param name="dt">数据源Table</param>
        /// <param name="dg">DataGrid控件</param>
        /// <param name="chkName">选取的CheckBox名</param>
        /// <returns></returns>
        public static bool DeleteDataGridRow(DataTable dt, DataGrid dg, string chkName) {
            foreach (DataGridItem dgi in dg.Items) {
                CheckBox cb = (CheckBox)dgi.FindControl(chkName);
                if (cb.Checked) {
                    if (dgi.ItemIndex <= dt.Rows.Count - 1) {
                        dt.Rows.RemoveAt(dgi.ItemIndex);
                    } else  //当索引超出dt中的记录数，则删除dt中最后一笔记录
					{
                        dt.Rows.RemoveAt(dt.Rows.Count - 1);
                    }

                }
            }
            dg.DataSource = dt;
            dg.DataBind();

            return true;
        }

        /// <summary>
        /// 将列表中的值转换成字符串，中间以“,”隔开
        /// </summary>
        /// <param name="idList"></param>
        /// <returns>string</returns>
        public static string ConvertListToStr(IList idList, bool isStr) {
            string str = "";  //字符串

            for (int i = 0; i < idList.Count; i++)//将列表组成类似2,3,4,5的字符串便于用IN查询
			{
                if (isStr) {
                    str += "'" + idList[i].ToString() + "'";	//如果是字符型，则为'2','3','4','5'
                } else {
                    str += idList[i].ToString();				//如果不是字符，则为2,3,4,5
                }
                if (i != idList.Count - 1) {
                    str += ",";
                }
            }
            return str;
        }


        /// <summary>
        /// 检查文件夹是否存在，不存在则创建
        /// </summary>
        /// <param name="strDir">需要检查的文件夹，完整路径</param>
        /// <returns>true 则存在或创建成功，false则失败</returns>
        public static bool CheckDir(string strDir) {
            try {
                if (!Directory.Exists(strDir)) {
                    Directory.CreateDirectory(strDir);
                }
            } catch (Exception e) {
                throw e;
            }
            return true;
        }

        /// <summary>
        /// 字符递增
        /// </summary>
        /// <returns></returns>
        public static string GetNextValue(char c) {
            return (Convert.ToChar(Convert.ToInt32(c) + 1)).ToString();
        }

        public static string GetNextValue(int c) {
            int a = c + 1;
            return a.ToString();
        }

        /// <summary>
        /// 从带分号;的字符串属性组中得到需要的属性
        /// 典型的字符串如数据库的连接串
        /// </summary>
        /// <param name="url"></param>
        /// <param name="propName"></param>
        /// <returns></returns>
        public static string GetFromDbUrl(string url, string propName) {
            string[] p = url.Split(';');
            foreach (string s in p) {
                string[] s1 = s.Split('=');
                if (s1[0] == propName) {
                    return s1[1];
                }
            }
            return null;
        }

        /// <summary>
        /// 1. 根据当前日期产生 "YYYY-MM-Week"  (年-月-本月第几周)的字符号串 
        /// </summary>
        /// <param name="dt">一般使用当前系统日期</param>
        /// <returns></returns>
        public static string GetSubPathbyDatetime(DateTime dt) {
            string result;

            result = @"\" + dt.Year + "-" + dt.Month + "-" + (dt.Day / 7);
            return result;
        }

        /// <summary>
        /// 通过日期得到yyyy\week\，比如”2008\12week\“
        /// </summary>
        /// <param name="dt"></param>
        /// <returns></returns>
        public static string GetYearWeekByDay(DateTime dt) {
            string result;
            int week = dt.DayOfYear / 7;
            result = dt.ToString("yyyy") + @"\" + week.ToString() + @"week\";
            return result;
        }


        /// <summary>
        /// 2. 保存文件时，处理文件名重复问题，避免覆盖 //返回重名文件+"_N" 的新文件名称
        /// </summary>
        /// <param name="curFilePath">当前要保存的上传文件全路径文件名称</param>
        /// <param name="newFileName">新的文件名称</param>
        /// <returns>返回 文件路径+文件名+"_N"+文件扩展名的 新文件名称</returns>
        public static string GetSavingFilepath(string curFilePath, ref string newFileName) {
            string fileExt = Path.GetExtension(curFilePath);
            string dir = Path.GetDirectoryName(curFilePath);
            string fileName = Path.GetFileNameWithoutExtension(curFilePath);

            newFileName = fileName + fileExt;

            string result = curFilePath;

            int i = 0;
            while (true) {
                if (!File.Exists(result)) {
                    break;
                }
                i++;
                newFileName = fileName + "_" + i + fileExt;
                result = dir + "\\" + newFileName;
            }
            return result;
        }

        /// <summary>
        /// 1.验证日期区间是否有效,如果为空或合法返回 ErrMsg.Success,
        /// 不为空的都验证其有效性,都不为空,则验证区间前后日期合法性
        /// </summary>
        /// <param name="strBeginDate">开始日期</param>
        /// <param name="strEndDate">结束日期</param>
        /// <returns>不为空串,则验证出错</returns>
        public static string ValidateDateDuration(string strBeginDate, string strEndDate) {
            DateTime beginDate = DateTime.MinValue;
            DateTime endDate = DateTime.MaxValue;

            if (strBeginDate != "") {
                try {
                    beginDate = DateTime.Parse(strBeginDate);
                } catch {
                    return "无效的起始时间";
                }
            }

            if (strEndDate != "") {
                try {
                    beginDate = DateTime.Parse(strEndDate);
                } catch {
                    return "无效的截止时间";
                }
            }

            if (DateTime.Compare(beginDate, endDate) > 0) {
                return "时间区间不对";
            }

            return "成功";
        }

        /// <summary>
        /// 查找文件
        /// </summary>
        /// <param name="dir">给定的目录</param>
        /// <param name="filename">文件名</param>
        /// <returns>找到的文件，如果没有，返回空数组</returns>
        public static string[] Find(string dir, string filename) {
            ArrayList files = new ArrayList();
            string[] files1 = Directory.GetFiles(dir, filename);
            files.AddRange(files1);
            string[] dirs = Directory.GetDirectories(dir);
            if (dirs.Length > 0) {
                foreach (string dir1 in dirs) {
                    Find(dir1, filename, files);
                }

            }
            string[] s = new string[files.Count];
            files.CopyTo(s);
            return s;
        }

        //
        public static DataRow FindDataRowByKey(DataTable table, string ColumnName, decimal Keyvalue) {
            DataRow[] rows = table.Select(ColumnName + " = " + Keyvalue);
            if (rows.Length > 0)
                return rows[0];
            else
                return null;

        }


        public static DataRow FindDataRowByKeys(DataTable table, string[] ColumnNames, decimal[] Keyvalues) {
            string condition = "";

            for (int i = 0; i < ColumnNames.Length; i++) {
                if (condition != "") {
                    condition += " and ";
                }
                condition = ColumnNames[i] + " = " + Keyvalues[i];

            }

            DataRow[] rows = table.Select(condition);
            if (rows.Length > 0)
                return rows[0];
            else
                return null;

        }

        private static void Find(string dir, string filename, ArrayList files) {
            string[] files1 = Directory.GetFiles(dir, filename);
            if (files1.Length > 0) {
                files.AddRange(files1);
            }
            string[] dirs = Directory.GetDirectories(dir);
            if (dirs.Length > 0) {
                foreach (string dir1 in dirs) {
                    Find(dir1, filename, files);   //递归查找目录
                }
            }
        }


        /// <summary>
        /// 读取配置文件通用方法
        /// </summary>
        /// <param name="sectionName">配置节名称</param>
        /// <param name="KeyName">配置键值</param>
        /// <returns></returns>
        public static string GetConfig(string sectionName, string keyName) {
            string strValue = "";

            NameValueCollection nvc = new NameValueCollection();

            object section = ConfigurationManager.GetSection(sectionName);

            if (section != null && section is NameValueCollection) {
                nvc.Add((NameValueCollection)section);
            }

            if (nvc.Count > 0) {
                strValue = nvc.Get(keyName);
            }

            return strValue;
        }
        /// <summary>
        ///  获取 appSettings  节下的配置
        /// </summary>
        /// <param name="keyName">配置键值</param>
        /// <returns></returns>
        public static string GetConfig(string keyName) {
            return GetConfig("appSettings", keyName);
        }



        public static int ToInt(object strValue) {
            int result = 0;

            try {
                result = Convert.ToInt32(strValue);
            } catch {
                result = 0;
            }

            return result;
        }

        // 是否为有效字段域 ,如果为 Null ,0,"0" 则 为无效字段 //用于查询语句判断
        public static bool IsValidField(object oValue) {
            if (((oValue + "") == "") || ((oValue + "") == "0")) {
                return false;
            }
            return true;
        }

        // 转换SQL的单引号
        public static string ToDBString(string values) {
            return values.Replace("'", "''");
        }

        /// <summary>
        ///  移除 Table中某些行
        /// </summary>
        /// <param name="srcTable"></param>
        /// <param name="columnName"></param>
        /// <param name="values"></param>
        public static void RemoveTableRows(DataTable srcTable, string columnName, IList values) {
            if (srcTable.Rows.Count > 0) {
                for (int i = srcTable.Rows.Count - 1; i >= 0; i--) {
                    if (values.Contains(srcTable.Rows[i][columnName]))
                        srcTable.Rows.RemoveAt(i);
                }

            }
        }

        /// <summary>
        /// 获取数据表一个临时主键.
        /// </summary>
        /// <param name="table"></param>
        /// <param name="keyName"></param>
        /// <returns></returns>
        public static int GetNewTempKeyOfTable(DataTable table, string keyName) {
            int maxValue = 0;
            int tmpKeyValue = 0;

            if (!table.Columns.Contains(keyName))
                return -1;


            for (int i = 0; i < table.Rows.Count; i++) {
                tmpKeyValue = Util.ToInt(table.Rows[i][keyName]);
                if (Abs(tmpKeyValue) > maxValue) {
                    maxValue = Abs(tmpKeyValue);
                }
            }
            maxValue += 1;
            return (-maxValue);
        }

        private static int Abs(int srcValue) {
            if (srcValue < 0)
                return (-srcValue);
            else
                return srcValue;
        }
        public static string MaxLen(string srcString, int max_len) {
            string result = "";

            if (srcString.Length < max_len) {
                result = srcString;
            } else if ((srcString.Length > max_len) && (max_len > 0)) {
                result = srcString.Substring(0, max_len);
                result += "..";
            }

            return result;
        }

        #region 截取中英混合字符
        public static string getStrByChnEng(string s, int l) {
            string temp = s;
            if (Regex.Replace(temp, "[\u4e00-\u9fa5]", "zz", RegexOptions.IgnoreCase).Length <= l) {
                return temp;
            }
            for (int i = temp.Length; i >= 0; i--) {
                temp = temp.Substring(0, i);
                if (Regex.Replace(temp, "[\u4e00-\u9fa5]", "zz", RegexOptions.IgnoreCase).Length <= l - 3) {
                    return temp + "";
                }
            }
            return "";

        }
        #endregion


        #region 获得激活码(新机型)
        [DllImport("sdex2.dll", EntryPoint = "build_tq_regcode")]
        static extern int build_tq_regcode(string tqIdStr, string noahSN, System.Text.StringBuilder regCode);
        public static string BuildRegCode(string pack_code, string machine_no) {
            int result;
            string tbId = pack_code;
            string sn = machine_no;
            string ret = "";
            System.Text.StringBuilder code = new System.Text.StringBuilder(35);
            do {
                result = build_tq_regcode(tbId, sn, code);//动态链接库加密    
                ret = code.ToString();
                if (ret.Length > 0) {
                    return ret.Substring(0, 16);
                }
            } while (true);
        }
        #endregion

        #region 获取网络文件大小
        /// <summary>
        /// 获取网络文件大小
        /// </summary>
        /// <param name="url"></param>
        /// <returns></returns>
        public static string GetHttpFileSize(string url) {
            string ret = "";
            try {
                HttpWebRequest request = (HttpWebRequest)HttpWebRequest.Create(url);
                HttpWebResponse response = (System.Net.HttpWebResponse)request.GetResponse();
                long fileLength = response.ContentLength;


                string fsize = fileLength.ToString();
                return fsize;
            } catch (Exception ex) {
                return ret;
            }

        }
        #endregion


        #region 将文件大小转为字符型
        public static string GetFileSizeStr(long fsize) {
            string ret = "";
            float fs = 0;

            if (fsize == 0) return "0K";

            if (fsize < 1024) return fsize.ToString() + "B";

            if (fsize > 1024) {
                fs = fsize / 1024;
                ret = "KB";
            }

            if (fs > 1024) {
                fs = fs / 1024;
                ret = "MB";
            }

            if (fs > 1024) {
                fs = fs / 1024;
                ret = "GB";
            }

            return fs.ToString("0.00") + ret;

        }
        #endregion

    } //class
}
