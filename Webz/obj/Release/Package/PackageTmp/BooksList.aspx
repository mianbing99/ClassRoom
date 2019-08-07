<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="BooksList.aspx.cs" Inherits="Webz.WebIE.BooksList" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <meta http-equiv="Content-Type" content="text/html; charset=utf-8" />
    <title>名师课堂</title>
    <link href="CSS/dicaidan.css" rel="stylesheet" />
    <style>
        * { font-size: 36px; margin: 0px; padding: 0px; }
        body { width: 100%; font-size: 36px; min-height: 2000px; background-image: url(Images/Imgs/最底部渐变色.png); background-repeat: no-repeat; background-size: 100% 100%; }
        a { text-decoration: none; color: black; }
        #none { height: 200px; width: 100%; }
        #divImg_Index { border-right: 2px solid #FFFFFF; }
        #divImg_Class { border-right: 2px solid #FFFFFF; }
        #yuandian { position: absolute; top: 2%; z-index: -1; width: 100%; height: 240px; }
        #Pr_title { width: 70%; border-radius: 15px; border: 2px solid #85DD64; background-color: #FFFFFF; height: 130px; margin-left: 15.3%; text-align: center; line-height: 130px; font-size: 40px; margin-top: 3%; margin-bottom: 2%; }
        #Pr_count { float: left; border-radius: 15px; width: 90%; margin: 0px 0px 200px 5%; background-color: #FFFFFF; min-height: 700px; }
        .nianjilist { width: 40%; height: 700px; float: left; padding: 5% 2.7% 0% 7%; border-bottom: solid 1px #8BD470; }
        .nianjilist span { float: left; text-align: center; width: 95%; height: 20%; }
    </style>
</head>
<body>
    <form id="form1" runat="server">
        <div>
            <img id="yuandian" src="Images/Imgs/圆点.png" />
            <div id="Pr_title">请选择教材</div>
            <div id="Pr_count">
                <%=strs %>
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
        <div id="div_Usercaidan" >
            <a href="UserAdd.aspx">
                <div class="but">注册激活</div>
            </a>
            <a id="A_Login" href="Login.aspx">
                <div id="Div_But_Login" class="but">登   录 </div>
            </a>
            <a href="xiugai.aspx?class=1">
                <div class="but">课程设置</div>
            </a>
            <a href="Feedback.aspx">
                <div class="but">意见反馈</div>
            </a>
            <a href="About.aspx">
                <div class="but">联系我们</div>
            </a>
        </div>
        <input type="hidden" id="Usercaidan" value="0" />
        <input type="hidden" id="Hisession" value="<%=Sess %>" />
        <input type="hidden" id="Hialert" value="<%=alert %>" />
        <input type="hidden" id="HiUrl" value="<%=Url %>" />
        <div id="alert" style=" background-image: url(Images/Imgs/我的课程-对话框.png);">
           
        </div>

    </form>
</body>
</html>
<script src="Scripts/jquery-1.8.2.min.js"></script>
<script src="js/ButJs.js"></script>
<script>
    $(document).ready(function () {
        var ses = $("#Hisession").val();
        sess(ses);
        var len = $(".nianjilist").length;
        var div = $("div [class = 'nianjilist']:last")
        if (len % 2 == 1) {
            div.after("<div class=\"nianjilist\"></div>");
        }
        if ($("#Hialert").val()!= "") {
            alert_queding($("#Hialert").val());
        }
        
    })
    $("#alert").on('click', '#Img_queding', function () {
        alert_queding_click($("#HiUrl").val());
    })
</script>

