using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Net;
using System.Text;
using System.Web;

namespace Webz {
    public static class FTP {

        static string ftpUserID = "VideoUpload";
        static string ftpPassword = "4qD0ltNw";
        /// <summary>
        ///  //获取所有文件 
        /// </summary>
        /// <param name="mask"> 匹配的文件  比如*.mp4  *.txt</param>
        /// <param name="ro"> 需要匹配文件的文件夹目录</param>
        /// <returns></returns>
        public static string[] GetFileList(string mask, string ro) {
            string[] downloadFiles;
            StringBuilder result = new StringBuilder();
            string ftpURI = @"ftp://VideoUpload:4qD0ltNw@183.60.136.8/" + ro;
            FtpWebRequest reqFTP;
            try {
                reqFTP = (FtpWebRequest)FtpWebRequest.Create(new Uri(ftpURI));
                reqFTP.UseBinary = true;
                reqFTP.Credentials = new NetworkCredential(ftpUserID, ftpPassword);
                reqFTP.Method = WebRequestMethods.Ftp.ListDirectory;
                WebResponse response = reqFTP.GetResponse();
                StreamReader reader = new StreamReader(response.GetResponseStream());

                string line = reader.ReadLine();
                while (line != null) {
                    if (mask.Trim() != string.Empty && mask.Trim() != "*.*") {
                        string mask_ = mask.Substring(0, mask.IndexOf("*"));
                        if (line.Substring(0, mask_.Length) == mask_) {
                            result.Append(line);
                            result.Append("\n");
                        }
                    } else {
                        result.Append(line);
                        result.Append("\n");
                    }
                    line = reader.ReadLine();
                }
                result.Remove(result.ToString().LastIndexOf('\n'), 1);
                reader.Close();
                response.Close();
                return result.ToString().Split('\n');
            } catch (Exception ex) {
                downloadFiles = null;
                if (ex.Message.Trim() != "远程服务器返回错误: (550) 文件不可用(例如，未找到文件，无法访问文件)。") {

                }
                return downloadFiles;
            }
        }
        public static List<string> GetDirctory(string RequedstPath) {
            List<string> strs = new List<string>();
            try {
                string uri = @"ftp://VideoUpload:4qD0ltNw@183.60.136.8/" + RequedstPath;   //目标路径 path为服务器地址
                FtpWebRequest reqFTP = (FtpWebRequest)FtpWebRequest.Create(new Uri(uri));
                // ftp用户名和密码
                reqFTP.Credentials = new NetworkCredential(ftpUserID, ftpPassword);
                reqFTP.Method = WebRequestMethods.Ftp.ListDirectoryDetails;
                WebResponse response = reqFTP.GetResponse();
                StreamReader reader = new StreamReader(response.GetResponseStream());//中文文件名

                string line = reader.ReadLine();
                while (line != null) {
                    if (line.Contains("<DIR>")) {
                        string msg = line.Substring(line.LastIndexOf("<DIR>") + 5).Trim();
                        strs.Add(msg);
                    }
                    line = reader.ReadLine();
                }
                reader.Close();
                response.Close();
                return strs;
            } catch (Exception ex) {
                Console.WriteLine("获取目录出错：" + ex.Message);
            }
            return strs;
        }
        public static string[] GetFilesDetailList(string ftpURI) {
            try {
                StringBuilder result = new StringBuilder();
                FtpWebRequest ftp;
                ftpURI = @"ftp://VideoUpload:4qD0ltNw@183.60.136.8/" + ftpURI;
                ftp = (FtpWebRequest)FtpWebRequest.Create(new Uri(ftpURI));
                ftp.Credentials = new NetworkCredential(ftpUserID, ftpPassword);
                ftp.Method = WebRequestMethods.Ftp.ListDirectoryDetails;
                WebResponse response = ftp.GetResponse();
                StreamReader reader = new StreamReader(response.GetResponseStream());
                string line = reader.ReadLine();
                line = reader.ReadLine();
                line = reader.ReadLine();
                while (line != null) {
                    result.Append(line);
                    result.Append("\n");
                    line = reader.ReadLine();
                }
                result.Remove(result.ToString().LastIndexOf("\n"), 1);
                reader.Close();
                response.Close();
                return result.ToString().Split('\n');
            } catch (Exception ex) {
                throw new Exception(ex.Message);
            }
        }
        public static string[] GetFilesDirList(string Path) {

            // string[] downloadFiles;  
            try {
                StringBuilder result = new StringBuilder();//如果要修改字符串而不创建新的对象，则可以使用 System.Text.StringBuilder 类。  
                FtpWebRequest ftp;
                Path = @"ftp://VideoUpload:4qD0ltNw@183.60.136.8/" + Path;
                ftp = (FtpWebRequest)FtpWebRequest.Create(new Uri(Path));//"ftp://10.12.12.9";  
                ftp.Credentials = new NetworkCredential(ftpUserID, ftpPassword);
                ftp.Method = WebRequestMethods.Ftp.ListDirectoryDetails;//目录  
                WebResponse response = ftp.GetResponse();//response为一个ftp的WebResponse  
                StreamReader reader = new StreamReader(response.GetResponseStream(), Encoding.Default);//读入responses所创建的数据流  
                string line = reader.ReadLine();//输入流中的下一行；如果到达了输入流的末尾，则为空引用  
                while (line != null) {
                    result.Append(line);//)Append 方法可用来将文本或对象的字符串表示形式添加到由当前 StringBuilder 对象表示的字符串的结尾处。  
                    result.Append("\n");
                    line = reader.ReadLine();
                }
                result.Remove(result.ToString().LastIndexOf("\n"), 1);//移除最后的换行》？  
                reader.Close();
                response.Close();
                return result.ToString().Split('\n');
            } catch (Exception ex) {
                throw ex;
            }
        } 
        public static string[] FileExist(string RemoteFileName) {  //判断是否有文件
            string str = RemoteFileName.Substring(RemoteFileName.LastIndexOf(@"\") + 1); //获取文件名
            string strr = RemoteFileName.Replace(str, ""); //截取掉文件名 获取文件夹目录
            string[] fileList = GetFileList("*.*", strr); //获取strr目录下的 *.*文件
            return fileList;
        }
       
        public static bool JudgeFileExist02(string url) {

            bool res = false;

            //响应对象

            System.Net.WebResponse webResponse = null;

            try {

                //创建根据网络地址的请求对象

                System.Net.WebRequest webRequest = System.Net.WebRequest.Create(url);

                //获取请求对象的响应状态

                webResponse = webRequest.GetResponse();

                //判断响应对象内容

                res = webResponse == null ? false : true;

            } catch (Exception ex) { res = false; } finally {

                if (webResponse != null) { webResponse.Close(); }

            }

            return res;

        }

        public static bool JudgeFileExist(string url) {
            try {
                //创建根据网络地址的请求对象
                System.Net.HttpWebRequest httpWebRequest = (System.Net.HttpWebRequest)System.Net.WebRequest.CreateDefault(new Uri(url));
                httpWebRequest.Method = "HEAD";
                httpWebRequest.Timeout = 1000;
                //返回响应状态是否是成功比较的布尔值
                return (((System.Net.HttpWebResponse)httpWebRequest.GetResponse()).StatusCode == System.Net.HttpStatusCode.OK);
            } catch {
                return false;
            }
        }
    }
}