<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="UserAdd.aspx.cs"
    Inherits="Webz.WebIE.UserAdd" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head lang="zh-cmn-Hans">
    <title>个人中心</title>
    <link href="CSS/dicaidan.css" rel="stylesheet" />
    <style>
        * { margin: 0px; padding: 0px; font-size: 45px; text-align: center; font-family: PingFangSC-Regular, sans-serif; }
        a { text-decoration: none; color: #040403; }
        body { min-height: 1500px; }
        #Title { width: 100%; height: 140px; background-color: #69B84B; font-size: 55px; text-align: center; line-height: 140px; color: #FFFFFF; margin-bottom: 5%; }
        .Div_Text { width: 80%; height: 120px; float: left; margin: 1% 0px 0px 10%; }
        .DIv_span { width: 34%; }
        #VIP span { border-bottom: 4px solid #81C368; font-size: 60px; padding: 0px 2% 0px 2%; }
        #VIP { width: 100%; margin: 5% 0px 5% 0px; color: #81C368; }
        #Text { float: left; margin: 3% 5% 0px 5%; }
        #Text p { font-size: 30px; text-align: left; margin-top: 20px; }
        #count input { width: 65%; height: 80px; border: 4px solid #96CD80; border-radius: 10px; font-size: 36px; }
        #foot { margin-top: 5%; margin-bottom: 200px; float: left; width: 100%; height: 200px; }
        #foot input { width: 25%; height: 50%; border-radius: 20px; margin: 0px 2% 0px 2%; color: #FFFFFF; background-size: 100% 100%; background-repeat: no-repeat; }
        #quxiao { background-image: url(Images/Imgs/取消.png); }
        #tiyan { background-image: url(Images/Imgs/注册体验.png); }
        #jihuo { background-image: url(Images/Imgs/注册激活.png); }
        #divImg_Index { border-right: 2px solid #FFFFFF; }
        #divImg_Class { border-right: 2px solid #FFFFFF; }
    </style>
</head>
<body>
    <form runat="server">
        <div>
            <div id="Title">注&nbsp &nbsp 册</div>
            <div id="count">
                <div class="Div_Text">
                    <span class="DIv_span">登录账号 &nbsp</span>
                    <input type="text" id="User" value="" placeholder="请输入手机号作为登录账号" runat="server" />
                    <input type="hidden" value="" id="HiUser" />
                </div>
                <div class="Div_Text">
                    <span class="DIv_span">登录密码 &nbsp</span>
                    <input type="text" id="Pwd" value="" placeholder="设置密码作为登录密码" runat="server" />
                    <input type="hidden" value="" id="HiPwd" />
                </div>
                <div class="Div_Text">
                    <span class="DIv_span">&nbsp 验证码&nbsp</span>
                    <input maxlength="4" style="margin-left: 4%;" id="txtVerify" type="text" placeholder="请输入下方验证码" runat="server" value="" />
                </div>
                <div>
                     <img id="yzm" style="width: 20%; height: 100%;cursor:pointer;" runat="server" alt="看不清，换一张" title="看不清，换一张" src="ValidateCode.aspx"  onclick="this.src=this.src+'?r='+Math.random()" />
                    
                    <input type="hidden" id="Gif" runat="server" value="" />
                </div>
                <div id="VIP">
                    <span>VIP激活</span>
                </div>
                <div class="Div_Text">
                    <span class="DIv_span">激活卡账号 </span>
                    <input type="text" id="Text1" value="" placeholder="请输入VIP激活卡的账号" runat="server" />
                    <input type="hidden" value="" id="HiText1" />
                </div>
                <div class="Div_Text">
                    <span class="DIv_span">激活卡密码 </span>
                    <input type="text" id="Text2" value="" placeholder="设置密码作为登录密码" runat="server" />
                    <input type="hidden" value="" id="HiText2" />
                </div>
                <div id="Text">
                    <p>温馨提示:</p>

                    <p>1.输入登录账号和登录密码后点击"注册体验"按钮即可试看免费视频。</p>

                    <p>2.输入VIP激活卡账号和VIP激活卡密码后点击"注册激活"按钮即可免费观看VIP视频。</p>

                    <p>3.若已激活VIP，可登录观看</p>
                </div>
            </div>
            <div id="foot">
                <input type="button" id="quxiao" />
                <input type="button" id="tiyan" />
                <input type="button" id="jihuo" />
            </div>
        </div>





        <div id="caidan">
            <div id="divImg_Index">
                <img id="Img_Index" src="Images/Imgs/首页.png"
                    width="100%" height="100%" />
            </div>
            <div id="divImg_Class">
                <img id="Img_class" src="Images/Imgs/我的课程按钮.png"
                    width="100%" height="100%" />
            </div>
            <div>
                <img id="UserInfo" src="Images/Imgs/个人中心按钮.png" width="100%"
                    height="100%" />
            </div>
        </div>
        <div id="div_Usercaidan" >
            <a href="UserAdd.aspx">
                <div class="but">注册激活</div>
            </a>
            <a href="Login.aspx">
                <div class="but">登   录 </div>
            </a>
            <a href="xiugai.aspx?class=1">
                <div class="but">课程设置</div>
            </a>
            <a>
                <div class="but">意见反馈</div>
            </a>
            <a href="About.aspx">
                <div class="but">联系我们</div>
            </a>
        </div>
        <input type="hidden" id="Usercaidan" value="0" />
       <div id="alert" style=" background-image: url(Images/Imgs/我的课程-对话框.png);"></div>
        <input type="hidden" value="<%=sess %>" id="Hisess"/>
    </form>
</body>
</html>
<%----%>
<script src="../Scripts/jquery-1.8.2.min.js"></script>
<script src="js/ButJs.js"></script>
<script>
    function getCookie(name) {
        var arr, reg = new RegExp("(^| )" + name + "=([^;]*)(;|$)");
        if (arr = document.cookie.match(reg))
            return unescape(arr[2]);
        else
            return null;
    }
    $("body").on("click", "#Img_queding", function () {
        var ls = $("#alert").html();
        if (ls.indexOf("注册成功！") != -1 || ls.indexOf("激活成功！") != -1) {
            alert_queding_click("Index.aspx");
        } else {
            alert_queding_click();
        }

    })
    $(document).ready(function () {
        sess($("#Hisess").val());
        $.ajax({
            url: 'ashx/UserInfo.ashx',
            type: 'post',
            datatype: "json",
            data: { action: "iflogin"},
            success: function (data) {
                if (data != "") {
                    $("#User").val(data);
                    $("#User").attr("disabled", "disabled");
                    $("#Pwd").val("*************");
                    $("#Pwd").attr("disabled", "disabled");
                }
            }
        })
        $("#Pwd").val("");
        $("#User").val("");
        $("#Pwd").blur(function () {
            var pPattern = /^[0-9a-zA-Z_]{6,15}$/;
            if (!pPattern.test($(this).val())) {
                $("#Pwd").css("border-color", "#DC1C1C");
                $("#HiPwd").val("1");
            } else {
                $("#Pwd").css("border-color", "#99CE84");
                $("#HiPwd").val("0");
            }
        })
        $("#User").blur(function () {
            var mPattern = /^((13[0-9])|(14[5|7])|(15([0-3]|[5-9]))|(18[0,5-9]))\d{8}$/;
            if (!mPattern.test($(this).val())) {
                $("#User").css("border-color", "#DC1C1C");
                $("#HiUser").val("1");
            } else {
                $("#User").css("border-color", "#99CE84");
                $("#HiUser").val("0");
            }
        })
        $("#Text1").blur(function () {
            var uPattern = /^FTV+[a-zA-Z]{2}$/;
            var thisval = $(this).val().toUpperCase();
            if (!uPattern.test(thisval)) {
                $("#Text1").css("border-color", "#DC1C1C");
                $("#HiText1").val("1");
            } else {
                $("#Text1").css("border-color", "#99CE84");
                $("#HiText1").val("0");
            }
        })
        $("#Text2").blur(function () {
            var uPattern = /^[0-9]{8}$/;
            var thisval = $(this).val().toUpperCase();
            if (!uPattern.test(thisval)) {
                $("#Text2").css("border-color", "#DC1C1C");
                $("#HiText2").val("1");
            } else {
                $("#Text2").css("border-color", "#99CE84");
                $("#HiText2").val("0");
            }
        })
    })

  
    var quxiao = document.getElementById("quxiao");
    quxiao.addEventListener("touchstart", function () {
        $("#quxiao").attr("src", "Images/Imgs/取消-按下.png");
    });
    quxiao.addEventListener("touchend", function () {
        history.go(-1);
        $("#quxiao").attr("src", "Images/Imgs/取消.png");
    });
    var tiyan = document.getElementById("tiyan");
    tiyan.addEventListener("touchstart", function () {
        $("#tiyan").attr("src", "Images/Imgs/注册体验-按下.png");
    });
    tiyan.addEventListener("touchend", function () {
        var Phone = $("#User").val();
        var Pwd = $("#Pwd").val();
        var yzm = getCookie("ValidateCode");
        var textyzm = $("#txtVerify").val();
        if ($("#HiUser").val() == "1" || $("#HiPwd").val() == "1" ) {
            alert_queding("请检查账号或密码输入是否正确");
        } else if (textyzm != yzm) {
            alert_queding("请检查验证码输入是否正确");
        }
        else {
            $.ajax({
                url: 'ashx/UserInfo.ashx',
                type: 'post',
                datatype: "json",
                data: { action: "yanzhen", Phone: Phone, Pwd: Pwd },
                success: function (data) {
                    if (data == "null") {
                        $.ajax({
                            url: 'ashx/UserInfo.ashx',
                            type: 'post',
                            datatype: "json",
                            data: { action: "tiyan", Phone: Phone, Pwd: Pwd },
                            success: function (data) {
                                if (data == "true") {
                                    alert_queding("注册成功！");
                                    window.location.href = "Index.aspx";
                                } else {
                                    alert_queding("系统繁忙！");
                                }
                            }
                        })
                    } else {
                        alert_queding("该账号已存在！");
                    }
                }
            })

        }
        $("#tiyan").attr("src", "Images/Imgs/注册体验.png");

    });
    var jihuo = document.getElementById("jihuo");
    jihuo.addEventListener("touchstart", function () {
        $("#jihuo").attr("src", "Images/Imgs/注册激活-按下.png");
    });
    jihuo.addEventListener("touchend", function () {
        $("#jihuo").attr("src", "Images/Imgs/注册激活.png");
        var CaUser = $("#Text1").val();
        var CaPwd = $("#Text2").val();
        var Phone = $("#User").val();
        var Pwd = $("#Pwd").val();
        var yzm = getCookie("ValidateCode");
        var textyzm = $("#txtVerify").val();
        if ($("#User").attr("disabled") == "disabled") {  // 判断是否有登录  有登录直接激活
            if ($("#HiText1").val() == "1" || $("#HiText2").val() == "2") {
                alert_queding("请检查账号或密码输入是否正确");
            } else if (textyzm != yzm) {
                alert_queding("请检查验证码输入是否正确");
            }
            else {
                $.ajax({
                    url: 'ashx/UserInfo.ashx',
                    type: 'post',
                    datatype: "json",
                    data: { action: "sejihuo", User: CaUser, PassWord: CaPwd },
                    success: function (data) {
                        alert_queding(data);
                        if (data == "激活成功！") {
                            window.location.href = "Index.aspx";
                        }
                    }
                })
            }
        } else {  // 未登录  注册激活
            if ($("#HiUser").val() == "1" || $("#HiPwd").val() == "1" || $("#HiText1").val() == "1" || $("#HiText2").val() == "2") {
                alert_queding("请检查账号或密码输入是否正确");
            } else if (textyzm != yzm) {
                alert_queding("请检查验证码输入是否正确");
            } else {
                $.ajax({
                    url: 'ashx/UserInfo.ashx',
                    type: 'post',
                    datatype: "json",
                    data: { action: "yanzhen", Phone: Phone, Pwd: Pwd },
                    success: function (data) {
                        if (data == "null") {
                            $.ajax({
                                url: 'ashx/UserInfo.ashx',
                                type: 'post',
                                datatype: "json",
                                data: { action: "jihuo", Phone: Phone, Pwd: Pwd, User: CaUser, PassWord: CaPwd },
                                success: function (data) {
                                    alert_queding(data);
                                    if (data == "激活成功！") {
                                        window.location.href = "Index.aspx";
                                    }
                                }
                            })
                        } else {
                            alert_queding("该账号已存在！");
                        }
                    }
                })
            }
        }
        

    });
</script>
<%--$("#User").attr("disabled") == "disabled"--%>