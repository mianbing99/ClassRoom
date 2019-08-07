<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="Login.aspx.cs" Inherits="Webz.Admin.Login" %>

<!DOCTYPE html PUBLIC "-//W3C//DTD XHTML 1.0 Transitional//EN" "http://www.w3.org/TR/xhtml1/DTD/xhtml1-transitional.dtd">

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <meta http-equiv="Content-Type" content="text/html; charset=utf-8" />
    <script src="CC/jquery-3.3.1.js"></script>
    <script src="CC/layui-v2.4.5/layui/layui.js"></script>
    <meta name="viewport" content="width=device-width, initial-scale=1, maximum-scale=1" />
    <title>登录页面</title>
    <style type="text/css">
        body {
            background: url(Img/登录页-背景.png) no-repeat;
            /*max-height: 100%;
            max-width: 100%;*/
            background-size: 100%;
            width: 100%;
            min-width: 1129px;
            max-width: 100%;
            height: 100%;
        }

        #diyi {
            width: 250px;
            height: 250px;
            line-height: 30px;
            background-color: white;
            text-align: center;
            position: absolute;
            left: 63%;
            top: 24%;
            border-radius: 5px 5px 5px 5px;
        }

        #Button1 {
            max-width: 30px;
            max-height: 22px;
            vertical-align: middle;
            position: absolute;
            left: 198px;
            top: 140px;
            background: url(../Admin/Img/键盘.png) no-repeat;
            background-size: 26px 18px;
            width: 30px;
            height: 22px;
        }

        #Pwd {
            width: 190px;
            height: 30px;
            border-radius: 5px 5px 5px 5px;
            background: url(../Admin/Img/密码.png) no-repeat;
            background-size: 34px 34px;
            padding-left: 35px;
            border:1px solid #808080;
        }

        #User {
            width: 190px;
            height: 30px;
            border-radius: 5px 5px 5px 5px;
            /*background: url(../Admin/Img/账号.png) no-repeat;*/
            background-size: 34px 34px;
            padding-left: 35px;
            margin-left: -6px;
            margin-top: -35px;
            border:1px solid #808080;
        }

        .user {
            background: url(../Admin/Img/账号.png) no-repeat;
            background-size: 34px 34px;
            height: 32px;
            width: 36px;
            position: relative;
            top:-2px;
            background-position: 0px center;
            margin-left: 9px;
            border-radius: 5px 5px 5px 5px;
        }

        input:-webkit-autofill,
        input:-webkit-autofill:hover,
        input:-webkit-autofill:focus,
        input:-webkit-autofill:active {
            -webkit-transition-delay: 99999s;
            -webkit-transition: color 99999s ease-out, background-color 99999s ease-out;
        }

        #Logins {
            width: 195px;
            height: 30px;
            color: white;
            background-color: #1464C7;
            border-radius: 5px 5px 5px 5px;
            border:1px solid #808080;
        }

        #Logins:hover {
            cursor:pointer;
            opacity:.8;
            filter:alpha(opacity=80);
        }

        #tupian1 {
            width: 30px;
            height: 30px;
            position: relative;
            left: 17px;
            top: -65px;
        }

        #queding {
            width: 69px;
            height: 25px;
            color: white;
            background-color: #1464C7;
            border-radius: 5px 5px 5px 5px;
            margin-left: 117px;
            margin-top: 95px;
        }

        #Aleat {
            background-image: url(Img/账号登录失败提示框.png);
            height: 138px;
            width: 291px;
            background-size: 100%;
            left: 38%;
            top: 29%;
            position: fixed;
            z-index: 999;
        }

        .hidden_div {
            margin: 0;
            position: fixed;
            overflow: auto;
            top: 0;
            right: 0;
            bottom: 0;
            left: 0;
            z-index: 998;
            outline: 0;
            opacity: 0.5;
            background: #000;
        }
        
    </style>
</head>
<body>
    <form id="form1" runat="server">
        <div class="hidden_div" runat="server" id="hiddenDivId" style="display: none;"></div>
        <div id="diyi">
            <h4 style="color: #63B8FF;">后 台 管 理 系 统</h4>
            <%--<asp:Image ID="Image1" runat="server" Height="35px" Width="33px" ImageUrl="../Admin/Img/账号.png" />--%>
            <div class="user"></div>
            <asp:TextBox ID="User" TextMode="SingleLine" runat="server" TabIndex="1"></asp:TextBox><br />
            <br />
            <asp:TextBox ID="Pwd" TextMode="Password" runat="server" TabIndex="2"></asp:TextBox>
            <%--<asp:Button ID="Button1" runat="server" Text="" OnClick="Button1_Click" />--%><br />
            <br />
            <asp:Button ID="Logins" runat="server" Text="登录" OnClick="Logins_Click" TabIndex="3" />
        </div>
        <div id="Aleat" runat="server" style="display: none;">
            <asp:Button ID="queding" runat="server" Text="确定" OnClick="queding_Click" />
        </div>
    </form>
</body>
</html>
<script src="../Scripts/jquery-1.8.2.min.js"></script>
<script>

</script>
