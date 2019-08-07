<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="Login.aspx.cs" Inherits="Webz.WebIE.Login" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head lang="zh-cmn-Hans">
    <title>个人中心</title>
    <link href="CSS/dicaidan.css" rel="stylesheet" />
    <style>
        * { margin: 0px; padding: 0px; font-size: 45px; text-align:center; }
        a { text-decoration:none; color:black;}
        body { min-height:1500px;}
        #Title { width: 100%; height: 140px; background-color: #69B84B; font-size: 55px; 
        text-align: center; line-height: 140px; color: #FFFFFF; 
        margin-bottom:20%;
        }
        #divImg_Index { border-right:2px solid #FFFFFF;}
        #divImg_Class { border-right:2px solid #FFFFFF;}
        #xiugai {background-image:url(Images/Imgs/修改密码.png) }
          #quxiao {background-image:url(Images/Imgs/取消.png) }
            #login {background-image:url(Images/Imgs/登录.png) }
        .Div_Text { width: 90%; height: 200px; float:left; margin:2% 0px 0px 3%;}
       #count input { width:70%; height:115px; border:5px solid #96CD80; border-radius:10px;}
        #foot { margin-top:30%; float:left; width:100%; height:200px;}
        #foot input { width:25%; height:50%; background-color:#69B84B; border-radius:20px; margin:0px 2% 0px 2%; color:#FFFFFF; background-size:100% 100%; background-repeat:no-repeat;}
     </style>
</head>
<body>
    <form runat="server">
    <div>
        <div id="Title">登&nbsp &nbsp 录</div>
        <div id="count">
            <div class="Div_Text">
                <span>登录账号 </span>
                <input type="text" id="User" value="" placeholder="请输入登录账号" runat="server" />
            </div>
            <div class="Div_Text">
                <span>登录密码 </span>
                <input type="text" id="Pwd" value="" placeholder="请输入登录密码" runat="server" />
            </div>
        </div>
        <div id="foot">
            <input type="button" id="quxiao" />
            <input type="button" id="xiugai" />
            <input type="button" id="login"/>
            
        </div>
    </div>

      <div id="caidan">
            <div id="divImg_Index"><img id="Img_Index" src="Images/Imgs/首页.png" width="100%" height="100%"/></div>
            <div id="divImg_Class" ><img id="Img_class" src="Images/Imgs/我的课程按钮.png"  width="100%" height="100%" /></div>
            <div ><img id="UserInfo" src="Images/Imgs/个人中心按钮.png"  width="100%" height="100%" /></div>
        </div>
            <div id="div_Usercaidan" >
        <a href="UserAdd.aspx"><div  class="but" > 注册激活</div></a>
        <a id="A_Login" href="Login.aspx"><div id="Div_But_Login" class="but"> 登   录 </div></a>
        <a href="xiugai.aspx?class=1"><div  class="but"> 课程设置</div></a>
        <a href="Feedback.aspx"><div class="but"> 意见反馈</div></a>
        <a href="About.aspx"><div  class="but"> 联系我们</div></a>
    </div>
        <input type="hidden" id="Usercaidan" value="0"/>
        <div id="alert" style=" background-image: url(Images/Imgs/我的课程-对话框.png);word-break:keep-all;"></div>
    </form>
</body>
</html>


<script src="../Scripts/jquery-1.8.2.min.js"></script>
<script src="js/ButJs.js"></script>
<script>
    $("body").on("click", "#Img_queding", function () {
        var ls = $("#alert").html();
        if (ls.indexOf("登录成功") != -1) {
            alert_queding_click("Index.aspx");
        } else {
            alert_queding_click();
        }
        
    })
    var quxiao = document.getElementById("quxiao");
    quxiao.addEventListener("touchstart", function () {
        $("#quxiao").attr("src", "Images/Imgs/取消-按下.png");
    });
    quxiao.addEventListener("touchend", function () {
        window.location.href = "Index.aspx";
        $("#quxiao").attr("src", "Images/Imgs/取消.png");
    });
    var xiugai = document.getElementById("xiugai");
    xiugai.addEventListener("touchstart", function () {
        $("#xiugai").attr("src", "Images/Imgs/修改密码-按下.png");
    });
    xiugai.addEventListener("touchend", function () {
        window.location.href = "Xiugai.aspx";
        $("#xiugai").attr("src", "Images/Imgs/修改密码.png");
    });
    var login = document.getElementById("login");
    login.addEventListener("touchstart", function () {
        $("#login").attr("src", "Images/Imgs/登录-按下.png");
    });
    login.addEventListener("touchend", function () {
        $("#login").attr("src", "Images/Imgs/登录按钮.png");
        var User = $("#User").val();
        var Pwd = $("#Pwd").val();
        if (User == "" || Pwd == "") {
            alert_queding("请输入账号或密码");
        }
        else {
            $.ajax({
                url: 'ashx/User.ashx',
                type: 'post',
                datatype: "json",
                data: { action: "Login", User: User, Pwd: Pwd },
                success: function (data) {
                    if (data == "200") {
                        alert_queding("登录成功", "Index.aspx");
                    }
                    else if (data == "201") {
                        alert_queding("账号或密码错误！");
                    }
                    else {
                        //alert_queding("该账户已被禁止使用！");
                        alert("该账户已被禁止使用，请联系管理员或者客服解除禁止！")
                    }
                }
            });
        }
        
    });
</script>

