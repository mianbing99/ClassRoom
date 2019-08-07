<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="Xiugai.aspx.cs" Inherits="Webz.Xiugai" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <meta http-equiv="Content-Type" content="text/html; charset=utf-8" />
    <title></title>
    <link href="CSS/dicaidan.css" rel="stylesheet" />
    <style>
        * { font-size: 36px; margin: 0px; padding: 0px; }
        body { width: 100%; font-size: 36px; min-height: 2000px; background-image: url(Images/Imgs/最底部渐变色.png); background-repeat: no-repeat; background-size: 100% 100%; }
        a { text-decoration: none; color: black; }
        #yuandian { position: absolute; top: 2%; z-index: -1; width: 100%; height: 240px; }
        .Div_Text { width: 90%; height: 140px; float: left; margin: 2% 0px 0px 10%; }
        #Pr_title { width: 70%; border-radius: 15px; border: 2px solid #85DD64; background-color: #FFFFFF; height: 130px; margin-left: 15.3%; text-align: center; line-height: 130px; font-size: 45px; margin-top: 3%; margin-bottom: 2%; }
        #Pr_count { float: left; border-radius: 15px; width: 90%; margin: 0px 0px 7% 5%; background-color: #FFFFFF; min-height: 1100px; }
        #Pr_count input { margin-left: 2%; width: 70%; height: 90px; border: 5px solid #96CD80; border-radius: 10px; }
        #tishi { background-image: url(Images/Imgs/修改密码提示.png); background-repeat: no-repeat; background-size: 100% 100%; width: 80%; height: 200px; margin-left: 10%; margin-top: 10%; margin-bottom: 10%; }
        #tishi span { text-align: center; height: 100%; line-height: 200px; padding-left: 10%; color: #69B84B; }
        #quxiao { background-image: url(Images/Imgs/取消.png); width: 30%; height: 100px; background-size: 100% 100%; background-repeat: no-repeat; border-radius: 10px; }
        #queding { background-image: url(Images/Imgs/登录.png); width: 30%; height: 100px; background-size: 100% 100%; background-repeat: no-repeat; border-radius: 10px; margin-left: 20%; }
        #butt { margin-left: 15%; margin-bottom: 200px; }
        .nianjilist { width: 25.322%; height: 350px; float: left; padding: 4% 4% 0% 4%; border-bottom: solid 1px #EBEBEB; }
        .nianjilist span { float: left; height: 100px; text-align: center; width: 95%; overflow: hidden; font-size: 40px; }
        #next { background-image: url(Images/Imgs/下一步.png); width: 30%; height: 100px; background-size: 100% 100%; background-repeat: no-repeat; border-radius: 10px; margin-left: 27%; }
        #Up { background-image: url(Images/Imgs/上一步.png); width: 30%; height: 100px; background-size: 100% 100%; background-repeat: no-repeat; border-radius: 10px; }
        #baocun { background-image: url(Images/Imgs/保存.png); width: 30%; height: 100px; background-size: 100% 100%; background-repeat: no-repeat; border-radius: 10px; margin-left: 20%; }
    </style>
</head>
<body>
    <form id="form1" runat="server">
        <div>
            <img id="yuandian" src="Images/Imgs/圆点.png" />
            <div id="Pr_title">修改密码</div>
            <div id="Pr_count">
                <div id="tishi"><span>填写下面信息就可以修改密码了</span></div>
                <div class="Div_Text">
                    <span>手机号 &nbsp&nbsp </span>
                    <input type="text" id="User" value="" placeholder="请输入手机号" runat="server" />
                </div>
                <div class="Div_Text">
                    <span>原始密码 </span>
                    <input type="text" id="Pwd" value="" placeholder="请输入旧密码" runat="server" />
                </div>
                <div class="Div_Text">
                    <span>新密码 &nbsp&nbsp</span>
                    <input type="text" id="Text1" value="" placeholder="请输入新密码" runat="server" />
                </div>
                <div class="Div_Text">
                    <span>确认密码 </span>
                    <input type="text" id="Text2" value="" placeholder="请输入确认密码" runat="server" />
                </div>
            </div>
            <div id="butt">
                <input type="button" id="quxiao" />
                <input type="button" id="queding" />

            </div>
            <%-- ------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------ --%>


            <div id="caidan">
                <div id="divImg_Index">
                    <img id="Img_Index" src="Images/Imgs/首页.png" width="100%" height="100%" />
                </div>
                <div id="divImg_Class">
                    <img id="Img_class" src="Images/Imgs/我的课程按钮.png" width="100%" height="100%" />
                </div>
                <div>
                    <img id="UserInfo" src="Images/Imgs/个人中心按钮.png" width="100%" height="100%" />
                </div>
            </div>
            <div id="div_Usercaidan" >
                <a href="UserAdd.aspx">
                    <div class="but">注册激活</div>
                </a>
                <a href="Login.aspx">
                    <div class="but">登   录 </div>
                </a>
                <a href="UserClass.aspx">
                    <div class="but">课程设置</div>
                </a>
                <a>
                    <div class="but">意见反馈</div>
                </a>
                <a href="About.aspx">
                    <div class="but">联系我们</div>
                </a>
            </div>
            <div id="alert" style=" background-image: url(Images/Imgs/我的课程-对话框.png);"></div>
            <input type="hidden" id="Usercaidan" value="0" />
        </div>
        <input type="hidden" id="state" value="<%=state %>" />
        <input type="hidden" id="GrName" value="" />
        <input type="hidden" id="SuName" value="" />
        <input type="hidden" id="Hisession" value="<%=sess %>" />
    </form>
</body>
</html>
<script src="Scripts/jquery-1.8.2.min.js"></script>
<script src="js/ButJs.js"></script>
<script>
    var nianji = "";
    var kemu = "";
    var GrName = $("#GrName");
    var SuName = $("#SuName");
    $("#UserInfo").click(function () {
        var i = $("#Usercaidan").val();
        if (i == "0") {
            $("#Usercaidan").val("1");
            $("#div_Usercaidan").css("display", "block");
        } else {
            $("#Usercaidan").val("0");
            $("#div_Usercaidan").css("display", "none");
        }
    });
    $(document).ready(function () {
        var sta = $("#state").val();
        if (sta == "class") {
            $("#Pr_title").html("课程设置/请选择年级");
            nianji = "";
            var shuzu = ["一年级", "二年级", "三年级", "四年级", "五年级", "六年级", "七年级", "八年级", "九年级", "高一", "高二", "高三"];
            for (var i = 0; i < shuzu.length; i++) {
                nianji += " <div  class=\"nianjilist\"><img  src=\"Images/Imgs/" + shuzu[i] + ".png\" width=\"100%\"; height=\"70%\"  /><span>" + shuzu[i] + "</span></div>";
            }
            $("#Pr_count").html(nianji);
            $("#butt").html("<input type=\"button\" id=\"next\" />");

        }

    })
    //$("div [name=\"nianjilist\"]").click(function () {
    //    alert("123");
    //})
    $("body").on('click', '.nianjilist', function () {
        $(".nianjilist").css("background-color", "");
        $(this).css("background-color", "#9BFF75");
        if ($(this).find("span").html().indexOf("年级") >= 0) {
            var i = $(this).find("span").html();
            GrName.val(i);

        } else if ($(this).find("span").html().indexOf("高") >= 0) {
            var i = $(this).find("span").html();
            GrName.val(i);
        } else {
            var i = $(this).find("span").html();
            SuName.val(i);
        }
    })
    $("body").on('click', '#next', function () {
        $.ajax({
            url: 'ashx/userinfo.ashx',
            type: 'post',
            datatype: "json",
            data: { action: "ClassGr", nianji: GrName.val() },
            success: function (data) {
                var jsonobj = eval("(" + data + ")");
                $("#Pr_title").html("课程设置/请选择科目");
                kemu = "";
                for (var it in jsonobj) {
                    kemu += "<div class=\"nianjilist\"><img src=\"Images/Imgs/" + jsonobj[it].SuName + "图标.png\" width=\"100%\"; height=\"70%\"  /><span>" + jsonobj[it].SuName + "</span></div>";
                }
                $("#Pr_count").html(kemu);
                $("#butt").html("<input type=\"button\" id=\"Up\" /><input type=\"button\" id=\"baocun\" />");
            }
        })
    });
    $("body").on('click', '#Up', function () {
        $("#Pr_count").html(nianji);
        $("#butt").html("<input type=\"button\" id=\"next\" />");
    });
    $("body").on('click', '#baocun', function () {
        $.ajax({
            url: 'ashx/userinfo.ashx',
            type: 'post',
            data: { action: "baocun", nianji: GrName.val(), kemu: SuName.val() },
            success: function (data) {
                if (data == "100") {
                    alert_queding("请先登录");
                    window.location.href = "Login.aspx";
                } else if (data == "200") {
                    alert_queding("保存成功，跳转到我的课程");
                    window.location.href = "BooksList.aspx";
                } else {
                    alert_queding("系统繁忙！请稍后再试");
                }
            }
        })
    });
    $("#UserInfo").click(function () {
        var i = $("#Usercaidan").val();

        if (i == "0") {
            $("#Usercaidan").val("1");
            $("#div_Usercaidan").css("display", "block");
        } else {
            $("#Usercaidan").val("0");
            $("#div_Usercaidan").css("display", "none");
        }

    });
</script>
