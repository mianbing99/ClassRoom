<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="Feedback.aspx.cs" Inherits="Webz.Feedback" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
<meta http-equiv="Content-Type" content="text/html; charset=utf-8"/>
    <title></title>
    <link href="CSS/dicaidan.css" rel="stylesheet" />
    <style>
        * { font-size: 36px; margin: 0px; padding: 0px; }
        body { width: 100%; font-size: 36px; min-height: 2000px; background-image: url(Images/Imgs/最底部渐变色.png); background-repeat: no-repeat; background-size: 100% 100%; }
        a { text-decoration: none; color: black; }
        textarea {
            resize:none;
            width:100%;
            overflow:auto;
            word-break:break-all;
            border:0;
            height:auto;
        }
        #yuandian { position: absolute; top: 2%; z-index: -1; width: 100%; height: 240px; }
        .Div_Text { width: 90%; height: 140px; float: left; margin: 2% 0px 0px 10%; }
        #Pr_title { width: 70%; border-radius: 15px; border: 2px solid #85DD64; background-color: #FFFFFF; height: 130px; margin-left: 15.3%; text-align: center; line-height: 130px; font-size: 45px; margin-top: 3%; margin-bottom: 2%; }
        #Pr_count { float: left; 
                    border-radius: 15px; 
                    width: 90%; 
                    margin: 0px 0px 7% 5%; 
                    background-color: #FFFFFF; 
                    min-height: 1100px; 
                    
        }
        #Pr_count.opinion:after {
            content:'请输入您的意见';/*提示信息*/
            color:#808080;
            font-size:12px;
        }
        #Pr_count input { margin-left: 2%; width: 70%; height: 90px; border: 5px solid #96CD80; border-radius: 10px; }
        #tishi { background-image: url(Images/Imgs/修改密码提示.png); background-repeat: no-repeat; background-size: 100% 100%; width: 80%; height: 200px; margin-left: 10%; margin-top: 10%; margin-bottom: 10%; }
        #tishi span { text-align: center; height: 100%; line-height: 200px; padding-left: 10%; color: #69B84B; }
        #quxiao { background-image: url(Images/Imgs/取消.png); width: 30%; height: 100px; background-size: 100% 100%; background-repeat: no-repeat; border-radius: 10px; }
        #tijiao { background-image: url(Images/Imgs/提交.png); width: 30%; height: 100px; background-size: 100% 100%; background-repeat: no-repeat; border-radius: 10px; margin-left: 20%; }
        #butt { margin-left: 15%; margin-bottom: 200px; }
        .nianjilist { width: 25.322%; height: 350px; float: left; padding: 4% 4% 0% 4%; border-bottom: solid 1px #EBEBEB; }
        .nianjilist span { float: left; height: 100px; text-align: center; width: 95%; overflow: hidden; font-size: 40px; }
        #next { background-image: url(Images/Imgs/下一步.png); width: 30%; height: 100px; background-size: 100% 100%; background-repeat: no-repeat; border-radius: 10px; margin-left: 27%; }
        #Up { background-image: url(Images/Imgs/上一步.png); width: 30%; height: 100px; background-size: 100% 100%; background-repeat: no-repeat; border-radius: 10px; }
        #baocun { background-image: url(Images/Imgs/保存.png); width: 30%; height: 100px; background-size: 100% 100%; background-repeat: no-repeat; border-radius: 10px; margin-left: 20%; }
    </style>
</head>
<body>
    <form id="frmFeedback" runat="server">
    <div><%--意见反馈--%>
        <img id="yuandian" src="Images/Imgs/圆点.png" />
        <div id="Pr_title">意见反馈</div>
        <div id="Pr_count" ><%--给div加一个contenteditable属性使其达到文本域的效果并且自适应高宽--%>
            <textarea name="opinion" id="frmFeedbacktxt" value="" rows="25" cols="30"  placeholder="请输入您的意见！" resiz:none ></textarea>
        </div>
        <div id="butt">
                <input type="button" id="quxiao" />
                <input type="button" id="tijiao" />

            </div>
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
                <a href="Feedback.aspx">
                    <div class="but">意见反馈</div>
                </a>
                <a href="About.aspx">
                    <div class="but">联系我们</div>
                </a>
            </div>
        <div id="alert" style=" background-image: url(Images/Imgs/我的课程-对话框.png);"></div>
            <input type="hidden" id="Usercaidan" value="0" />
    </div>

        
    </form>
</body>
</html>
<script src="Scripts/jquery-1.8.2.min.js"></script>
<script src="js/ButJs.js"></script>
<script>
    var FeedbackNR = "";//定义一个变量储存用户提交意见！
    //能达到文本域中placeholder属性的效果
    document.getElementById('Pr_count').oninput = function () {
        if (this.innerHTML.length != 0) {
            this.classList.remove('opinion');
        } else {
            this.classList.add('opinion');
        }
    }
    $("body").on("click", "#Img_queding", function () {//提示信息
        var ls = $("#alert").html();
        if (ls.indexOf("请先登录！") != -1) {
            alert_queding_click("Login.aspx");
        } else if (ls.indexOf("提交成功！") != -1) {
            alert_queding_click("BooksList.aspx");
        } else if (ls.indexOf("系统繁忙，请稍后重试！") != -1) {
            alert_queding_click("Feedback.aspx");
        } else {
            alert_queding_click();
        }

    })
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
    
    //点击取消按钮效果
    var queding = document.getElementById("quxiao");
    quxiao.addEventListener("touchstart", function () {
        $("#quxiao").css("background-image", "url(Images/Imgs/取消-按下.png)");
    });
    //点击取消跳转界面
    quxiao.addEventListener("touchend", function () {
        $("#quxiao").attr("background-image", "url(Images/Imgs/取消.png)");
        window.location.href = "Index.aspx";
    });
    //点击提交按钮效果
    var tijiao = document.getElementById("tijiao");
    tijiao.addEventListener("touchstart", function () {
        $("#tijiao").css("background-image", "url(Images/Imgs/提交-按下.png)");
    });
    tijiao.addEventListener("touchstart", function () {
        $("#tijiao").attr("background-image", "url(Images/Imgs/提交.png)");
        FeedbackNR = $("#frmFeedbacktxt").val();
        if (FeedbackNR!="" && FeedbackNR!=null) {
            $.ajax({
                url: 'ashx/FeedBack.ashx',
                type: 'post',
                data: { action: "InsertFback", FeedbackNR: FeedbackNR },
                success: function (data) {
                    if (data=="100") {
                        alert_queding("请先登录！");
                        
                    } else if (data == "300") {
                        alert_queding("提交成功！");
                    } else {
                        alert_queding("系统繁忙，请稍后重试！");
                    }
                }
            })
        } else {
            alert_queding("请填写意见后再提交！");
        }
    });
</script>
