using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Web;

namespace Webz.Weixinzf {
    /// <summary>
    /// wp 的摘要说明
    /// </summary>
    public class wp : IHttpHandler {
        string appid, mch_id, openid, out_trade_no, spbill_create_ip, total_fee, trade_type,
            orderNumber, addr, productType, project, userinfo, money, ispay, payTime, createTime, payType, spid;
        public void ProcessRequest(HttpContext context) {
            context.Response.ContentType = "text/plain";
            SqlConnection con = new SqlConnection("server=117.48.195.219;database=WeChatETP;uid=MDB;pwd=Main@JLF955icox;Pooling=true;");
            //支付表
            orderNumber = System.Web.HttpContext.Current.Request.Form["orderNumber"];
            addr = System.Web.HttpContext.Current.Request.Form["addr"];
            productType = System.Web.HttpContext.Current.Request.Form["productType"];
            project = System.Web.HttpContext.Current.Request.Form["project"];
            userinfo = HttpUtility.UrlDecode(System.Web.HttpContext.Current.Request.Form["userinfo"]);
            money = System.Web.HttpContext.Current.Request.Form["money"];
            ispay = System.Web.HttpContext.Current.Request.Form["ispay"];
            payTime = System.Web.HttpContext.Current.Request.Form["payTime"];
            createTime = System.Web.HttpContext.Current.Request.Form["createTime"];
            payType = System.Web.HttpContext.Current.Request.Form["payType"];
            spid = System.Web.HttpContext.Current.Request.Form["spid"];

            //微信支付表
            appid = System.Web.HttpContext.Current.Request.Form["appid"];
            mch_id = System.Web.HttpContext.Current.Request.Form["mch_id"];
            openid = System.Web.HttpContext.Current.Request.Form["openid"];
            out_trade_no = System.Web.HttpContext.Current.Request.Form["out_trade_no"];
            spbill_create_ip = System.Web.HttpContext.Current.Request.Form["spbill_create_ip"];
            total_fee = System.Web.HttpContext.Current.Request.Form["total_fee"];
            trade_type = System.Web.HttpContext.Current.Request.Form["trade_type"];
            try {
                if (con.State == ConnectionState.Closed) {
                    con.Open();
                }
                string ipsql = string.Format(@"insert into Pay(orderNumber,addr,productType,project,userinfo,money,ispay,payTime,createTime,payType,spid)
values('{0}','{1}','{2}','{3}','{4}','{5}','{6}','{7}','{8}','{9}','{10}') 
insert into WeChatPay(appid,mch_id,openid,out_trade_no,spbill_create_ip,total_fee,trade_type)
values('{11}','{12}','{13}','{14}','{15}','{16}','{17}')"
                    , orderNumber, addr, productType, project, userinfo, money, ispay, payTime, createTime, payType, spid
                    , appid, mch_id, openid, out_trade_no, spbill_create_ip, total_fee, trade_type);
                SqlCommand icmd = new SqlCommand(ipsql, con);
                if (icmd.ExecuteNonQuery() > 0) {
                    context.Response.Write("{\"msg\":\"ok\",\"data\":\"ok\"}");
                }

            } catch (Exception e) {
                context.Response.Write("{\"msg\":\"error\",\"errormsg\":\"" + e.Message + "\"}");
            } finally {
                if (con.State == ConnectionState.Open) {
                    con.Close();
                }
            }

        }

        public bool IsReusable {
            get {
                return false;
            }
        }
    }
}