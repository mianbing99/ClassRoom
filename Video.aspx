<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="Video.aspx.cs" Inherits="Webz.WebIE.Video" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
<meta http-equiv="Content-Type" content="text/html; charset=utf-8"/>
    <title>名师视频</title>
    <link href="CSS/dicaidan.css" rel="stylesheet" />
    <style>
        * { padding:0px; margin:0px;}
        .p { width:98%;z-index:20; padding:3% 0px 3% 2%; border-bottom:5px solid #C8E5BD; font-size:40px;}
        #count { width:100%; float:left;}
        .count{ width:50%; float:left; }
        #pinglun_tijiao { width:30%; margin-left:35%; margin-bottom:200px;}
        #Text { width:95%; height:95%; font-size:40px; border:none; margin:2.5% 2.5% 2.5% 2.5%;}
        .text { float:left; width:95%; height:600px; margin:5% 0px 50px 2.5%; border:4px solid #C8E5BD; border-radius:5px; }
   </style>
</head>
<body>
    <form id="form1" runat="server">
    <div>
        <div>
    <video id="video" src="<%=VideoRoute %>" controls="controls" autoplay="autoplay" width="100%" >
      您的浏览器不支持 video 标签。
</video>
            </div>
        <div>
        <div class="count">
            <img id="VideoInfo" src="Images/Imgs/视频信息-选择.png"  width="101%"/></div>
            <div class="count">
                <img id="pinglun"  src="Images/Imgs/评论.png" width="100%"/></div>
        </div>
        <div id="Div_Video" style="float:left; width:100%; ">
<%=str %>
        </div>
       <div id="Div_pinglun" style="display:none;">
           <div class="text">
               <textarea id="Text" placeholder="说说你的看法" ></textarea>

           </div>
           
           <img id="pinglun_tijiao" src="Images/Imgs/提交.png" />
       </div>
    </div>
       <div id="caidan">
            <div id="divImg_Index">
                <img id="Img_Index" src="Images/Imgs/首页.png" width="100%" height="100%" /></div>
            <div id="divImg_Class">
                <img id="Img_class" src="Images/Imgs/我的课程按钮.png" width="100%" height="100%" /></div>
            <div>
                <img id="UserInfo" src="Images/Imgs/个人中心按钮.png" width="100%" height="100%" /></div>
        </div>
        <div id="div_Usercaidan" style="height: 500px; width: 200px; background-color: #FFFFFF; position: fixed; top: 53%; left: 75%; display: none; border-radius: 5px; border: 5px solid #9BFE76;">
            <a href="UserAdd.aspx">
                <div class="but">注册激活</div>
            </a>
            <a id="A_Login" href="Loginout.aspx">
                <div id="Div_But_Login" class="but">注销登录 </div>
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
        <div id="alert" style=" background-image: url(Images/Imgs/我的课程-对话框.png);"></div>
    </form>
</body>
</html>
<script src="../Scripts/jquery-1.8.2.min.js"></script>
<script src="js/ButJs.js"></script>
<script>
    $("body").on("click", "#Img_queding", function () {
        alert_queding_click();
    })
    $(".p").click(function () {
        var luj = $(this).find("input").val();
        document.getElementById("video").src = luj;
        document.getElementById("video").play();
    })
    $("#VideoInfo").click(function () {
        var src = $(this).attr("src");
        if (src != "Images/Imgs/视频信息-选择.png") {
            $(this).attr("src", "Images/Imgs/视频信息-选择.png");
            $("#pinglun").attr("src", "Images/Imgs/评论.png");
            $("#Div_Video").css("display", "inline");
            $("#Div_pinglun").css("display", "none");
        }
    })
    $("#pinglun").click(function () {
        var src = $(this).attr("src");
        if (src != "Images/Imgs/评论-选择.png") {
            $(this).attr("src", "Images/Imgs/评论-选择.png");
            $("#VideoInfo").attr("src", "Images/Imgs/视频信息.png");
            $("#Div_pinglun").css("display", "inline");
            $("#Div_Video").css("display", "none");
        }
    })
    var pinglun_tijiao = document.getElementById("pinglun_tijiao");
    pinglun_tijiao.addEventListener("touchstart", function () {
        $("#pinglun_tijiao").attr("src", "Images/Imgs/提交-按下.png");
    });
    pinglun_tijiao.addEventListener("touchend", function () {
        $("#pinglun_tijiao").attr("src", "Images/Imgs/提交.png");
        var text =$("#Text").val();
        $.ajax({
            url: 'ashx/userinfo.ashx',
            type: 'post',
            datatype: "json",
            data: { action: "pinglun", text: text },
            success: function (data) {
                if (data == "系统繁忙") {
                    alert_queding(data);
                    window.location.reload();
                } else {
                    alert_queding(data);
                }
            }
        })
    });
</script>
