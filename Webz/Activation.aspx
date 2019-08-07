<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="Activation.aspx.cs" Inherits="Webz.WebIE.Activation" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
<meta http-equiv="Content-Type" content="text/html; charset=utf-8"/>
    <title>个人中心</title>
<%--<link rel="stylesheet" type="text/css" href="inc/aui.2.0.css"/>
<link rel="stylesheet" type="text/css" href="inc/public.css"/>
<link href="inc/style.css" type="text/css" rel="stylesheet"/>--%>
    <style>
        * { font-size:40px; margin:0px; padding:0px; }
        .ds {  border-color:red; }
         #Di { margin-top:20%;}
        #Di div { width:100%; height:100px; margin:6% 0px 6% 7.5%;}
        #Di div input {background-color:#9CDCFE; width:85%; height:100%; border-radius:15px;  }
        #Di div span { color:red;}
        .But { margin-top:5%; margin-left:35%; width:30%; height:100px;}
     #alert { text-align:center;line-height:250px; font-size:46px; width: 67%; height: 350px; background-image: url(Images/Imgs/我的课程-对话框.png); background-size: 100% 100%; position: fixed; top: 30%; left: 17%; display:none; }</style>
</head>
<body>
    <form id="form1" runat="server">
    <div id="Di">  
        <div>
            <input type="text" id="Txt_Account" placeholder="请输入账号" value="" runat="server"  /> <br /><span id="Sp_Account"></span>
        </div>
        <div>
            <input type="text" id="Txt_PassWord" placeholder="请输入密码" value="" runat="server" /><br /><span id="Sp_PassWord"></span>

        </div>
        <div>
            <input maxlength="4" style="width:35%;" ID="txtVerify" type="text" runat="server" value="" />
        <img src='ashx/Veify.ashx' style="width:20%;height:100%;" id="verify"/>
            <input type="hidden" id="Gif" runat="server" value="" />
        <a href='javascript:verify();'>看不清，换一张</a>
        </div>
        <asp:Button CssClass="But" ID="But_Activation" runat="server" Text="立即激活" OnClick="But_Activation_Click" />
    </div>
      <div id="alert" style=" background-image: url(Images/Imgs/我的课程-对话框.png);"></div>
    </form>
</body>
</html><script src="../Scripts/jquery-1.8.2.min.js"></script>
<script>
    function verify() {
        $("#verify").attr("src", "ashx/verify.ashx");
    }
    $(document).ready(function(){
        Sp_Account = $("#Sp_Account");
        Sp_PassWord = $("#Sp_PassWord");
        Sp_Account.html(""); Sp_PassWord.html("");
    })
    $("#Txt_Account").blur(function () {
        var uPattern = /^FTV+[a-zA-Z]{2}$/;
        var thisval = $(this).val().toUpperCase();
        if (!uPattern.test(thisval)) {
            Sp_Account.html("用户名输入有误！");
        } else {
            Sp_Account.html("");
        }
    })
    $("#Txt_PassWord").blur(function () {
        var uPattern = /^[0-9]{8}$/;
        var thisval = $(this).val().toUpperCase();
        if (!uPattern.test(thisval)) {
            Sp_PassWord.html("密码格式有误！");
        } else {
            Sp_PassWord.html("");
        }
    })
    $("#But_Activation").click(function () {
        if (Sp_PassWord.html() != "" || Sp_Account.html() != "") {
            alert("请检查输入格式是否正确");
            return false;
        }
    })
</script>
