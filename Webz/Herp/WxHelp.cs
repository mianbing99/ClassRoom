using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Net;
using System.Text;
using System.Web;

namespace Webz.Herp {
    public static class WxHelp {
        public static string getOpenId(string code) {
            string studyUrl = "https://open.weixin.qq.com/connect/oauth2/authorize?appid=wx0e7b25b6f1553eea&redirect_uri=http://v.icoxtech.com/StudyStation.aspx?response_type=code&scope=snsapi_base&state=1#wechat_redirect";

            studyUrl = "https://api.weixin.qq.com/sns/oauth2/access_token?appid=wx0e7b25b6f1553eea&secret=0b3f122b0b2b7a345f8cb4793bbcc6ad&code=" + code + "&grant_type=authorization_code ";

            return HttpGet(studyUrl, "");
        }
        public static string HttpGet(string Url, string postDataStr) {
            HttpWebRequest request = (HttpWebRequest)WebRequest.Create(Url + (postDataStr == "" ? "" : "?") + postDataStr);
            request.Method = "GET";
            request.ContentType = "text/html;charset=UTF-8";
            HttpWebResponse response = (HttpWebResponse)request.GetResponse();
            Stream myResponseStream = response.GetResponseStream();
            StreamReader myStreamReader = new StreamReader(myResponseStream, Encoding.UTF8);
            string retString = myStreamReader.ReadToEnd();
            myStreamReader.Close();
            myResponseStream.Close();
            return retString;
        }
    }
}