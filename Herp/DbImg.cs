using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Web;

namespace Webz.Admin {
    public static class DbImg {
        public static string yanzhen(string stri,string path) {
            string[] files;
            string[] filespng;
            string tmpRootDir = HttpContext.Current.Server.MapPath(System.Web.HttpContext.Current.Request.ApplicationPath.ToString())+path;
            //绝对路径 = 获取项目所在的根目录 + 相对路径
            files = Directory.GetFiles(tmpRootDir, "*.jpg");
            filespng = Directory.GetFiles(tmpRootDir, "*.png");
            if (stri == "" || stri == null) {
                return "请选择图片！";
            }
            string kuoz = System.IO.Path.GetExtension(stri);  
            if (kuoz == ".jpg" || kuoz == ".png") {
                if (kuoz == ".jpg") {
                } else if (kuoz == ".png") { } else {
                    return "请选择正确格式的图片！";
                }

            }
            
            string fileName = string.Empty;
            for (int i = 0; i < files.Length; i++) {
                fileName = System.IO.Path.GetFileName(files[i]);
                if (fileName == stri) {
                    return "false";
                }
            }
            for (int i = 0; i < filespng.Length; i++) {
                fileName = System.IO.Path.GetFileName(filespng[i]);
                if (fileName == stri) {
                    return "false";
                }
            }
            return "true";
        }
        public static bool ImgTest(string path, string stri) {
            string tmpRootDir = HttpContext.Current.Server.MapPath(System.Web.HttpContext.Current.Request.ApplicationPath.ToString()) + path;
            string[] files = Directory.GetFiles(tmpRootDir, stri);
            if (files.Length > 0) {
                return true;
            } else {
                return false;
            }
        }
    }
}