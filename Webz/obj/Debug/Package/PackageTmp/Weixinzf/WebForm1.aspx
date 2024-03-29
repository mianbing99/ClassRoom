﻿<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="WebForm1.aspx.cs" Inherits="Webz.Weixinzf.WebForm1" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
<meta http-equiv="Content-Type" content="text/html; charset=utf-8"/>
    <title></title>
</head>

<body style="background-color:#EBEFF0">
    <form runat="server">
        <br />
        <div id="zfdiv">
            <table style="width:100%">
                <tr>
                    <td style="text-align:right">商品名称:</td>
                    <td id="spmc">icox高清名师课堂视频</td>
                </tr>
                <tr>
                    <td style="text-align:right">商品价格:</td>
                    <td id="spjg">0.01元</td>
                     
                </tr>
                <tr>
                    <td colspan="2" style="text-align:center">
                       <input runat="server" id="submita" onclick="callpay()" type="button"
                               value="立即支付" />
                        <input type="button" id="submit" onclick="callpay()" value="lijizhifu" runat="server" />
                    </td>
                </tr>
            </table>


        </div>
        <div style="text-align:center;color:darkgray;padding:10px;font-size:14px"><label>您也可以将下面二维码分享给朋友们,来一起观看</label></div>
        <div id="qrcode" style="text-align:center">
        </div>

    </form>
</body>
</html>
<script src="API/jquery-1.11.3.js"></script>
<script src="API/layer/layer.js"></script>
<script src="js/qrcode.js"></script>
<script type="text/javascript">
    var vid = GetQueryString("vid");

    //调用微信JS api 支付
    function jsApiCall() {
        var param = '<%=reslut%>';
        try {
            WeixinJSBridge.invoke(
            'getBrandWCPayRequest',
            <%=wxJsApiParam%> //josn串
            function (res) {
                WeixinJSBridge.log(res.err_msg);
                switch (res.err_msg) {
                    case "get_brand_wcpay_request:ok":

                        var total_fee = GetQueryString("total_fee");
                        var thisname = GetQueryString("thisname");
                        var thisacc = GetQueryString("thisacc");
                        var thisdepname = GetQueryString("thisdepname");
                        var thisphonenum = GetQueryString("thisphonenum");
                        var startzftime = GetQueryString("startzftime");
                        //开始保存支付记录
                        //layer.alert(param);
                        var obj = eval("(" + param + ")");
                        $.post(
                            "../../serverO/WxPay/wp.ashx",
                            {
                                //支付表
                                orderNumber: obj.out_trade_no,//商户订单号
                                addr: "广东省|深圳市|龙华区|深圳市金龙锋科技有限公司",//订单生成地址
                                productType: "名师课堂视频",//商品类型
                                project: "金龙锋微信企业号",//商品项目
                                userinfo: thisname + "|" + thisacc + "|" + thisdepname + "|" + thisphonenum,//付款用户信息
                                money: obj.total_fee,//付款金额
                                ispay: "是",//是否支付成功
                                payTime: getNowFormatDate(),//支付完成时间
                                createTime: startzftime,//支付开始时间
                                payType: "微信公众号支付",//支付类型
                                spid: vid,//支付商品id
                                //微信支付表
                                appid: obj.appid,//支付公众号应用id
                                mch_id: obj.mch_id,//收款商户号id
                                openid: obj.openid,//用户openid
                                out_trade_no: obj.out_trade_no,//商户订单号
                                spbill_create_ip: obj.spbill_create_ip, //用户付款ip
                                total_fee: obj.total_fee, //用户付款金额
                                trade_type: obj.trade_type//微信支付类型(JSAPI)
                            },
                            function (data) {
                                var obj2 = eval("(" + data + ")");
                                if (obj2.msg == "ok") {
                                    alert("支付成功");
                                    layerload = layer.load(1, {
                                        shade: [0.1, '#fff'] //0.1透明度的白色背景
                                    });
                                    window.location.href = "https://open.weixin.qq.com/connect/oauth2/authorize?appid=wxb19a7362ec89e661&redirect_uri=icoxedu.cn%2f1WeChatEnterprise%2fvideoPlay%2findex.aspx?vid=" + vid + "&response_type=code&scope=snsapi_base#wechat_redirect";
                                } else {
                                    alert("支付成功,插入数据失败" + obj2.errormsg);
                                }
                            });

                        break;
                    case "get_brand_wcpay_request:cancel":
                        alert("支付被取消");
                        break;
                    case "get_brand_wcpay_request:fail":
                        alert("支付失败");
                        break;
                }

            }
            );
        } catch (e) {
            alert(e);
        }
    }

    function callpay() {
        if (typeof WeixinJSBridge == "undefined") {
            if (document.addEventListener) {
                document.addEventListener('WeixinJSBridgeReady', jsApiCall, false);
            }
            else if (document.attachEvent) {
                document.attachEvent('WeixinJSBridgeReady', jsApiCall);
                document.attachEvent('onWeixinJSBridgeReady', jsApiCall);
            }
        }
        else {
            jsApiCall();
        }
    }
    function GetQueryString(name) {
        var reg = new RegExp("(^|&)" + name + "=([^&]*)(&|$)");
        var r = window.location.search.substr(1).match(reg);
        if (r != null) return unescape(r[2]); return null;
    }
    function getNowFormatDate() {
        var date = new Date();
        var seperator1 = "-";
        var seperator2 = ":";
        var month = date.getMonth() + 1;
        var strDate = date.getDate();
        if (month >= 1 && month <= 9) {
            month = "0" + month;
        }
        if (strDate >= 0 && strDate <= 9) {
            strDate = "0" + strDate;
        }
        var currentdate = date.getFullYear() + seperator1 + month + seperator1 + strDate
                + " " + date.getHours() + seperator2 + date.getMinutes()
                + seperator2 + date.getSeconds();
        return currentdate;
    }

</script>

<script>

    var vid = GetQueryString("vid");
    var qrcode = new QRCode(document.getElementById("qrcode"), {
        width: 250,//设置宽高
        height: 250
    });
    $.post(
        "../../serverO/WxPay/longurl2shorturl.ashx",
        {
            longurl: "https%3A%2F%2Fopen.weixin.qq.com%2Fconnect%2Foauth2%2Fauthorize%3Fappid%3Dwxb19a7362ec89e661%26redirect_uri%3Dicoxedu.cn%252f1WeChatEnterprise%252fvideoPlay%252fHome.aspx%26response_type%3Dcode%26scope%3Dsnsapi_base%23wechat_redirect"
        },
        function (data) {
            //layer.alert(data);
            var obj = eval("(" + data + ")");
            qrcode.makeCode(obj.short_url[0].url_short);
        }
        )

    function GetQueryString(name) {
        var reg = new RegExp("(^|&)" + name + "=([^&]*)(&|$)");
        var r = window.location.search.substr(1).match(reg);
        if (r != null) return unescape(r[2]); return null;
    }
</script>
