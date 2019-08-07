<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="WebForm2.aspx.cs" Inherits="Webz.WebForm2" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
<meta http-equiv="Content-Type" content="text/html; charset=utf-8"/>
    <title></title>
    <style>
        * { margin:0px; padding:0px;}
        body { height:2000px;}
    #Div_alter { position:fixed; left:30%; top:20%; width:40%; height:350px; /*background-color:aqua;*/ background:url(Admin/Img/提示信息栏478x314.png) no-repeat; background-size:100% 100%; }
        #Div_alert_count {border:1px solid #0f65cc; background-color:#f5f5f5; text-align: center; margin-top: 10%; position: absolute; left:2.5%; height:70%; width: 95%; overflow: auto; scrollbar-face-color: #0F65CC;}
        #alert_but { background:url(Admin/Img/确定.png) no-repeat; background-size:100% 100%; width:90px; height:30px; border:none; position:relative; top:88%; left:40%}
        #Div_alter p { border-bottom:1px solid #0f65cc;}
    </style>
</head>
<body>
    <form id="form1" runat="server">
    <div>
        <asp:TextBox ID="TextBox1" runat="server"></asp:TextBox>
       <%-- <span id="aspan" >看不清，换一张</span>--%>
        <img id="yzm" runat="server" alt="看不清，换一张" title="看不清，换一张" src="ValidateCode.aspx" style="cursor:pointer" onclick="this.src=this.src+'?r='+Math.random()" />
        <asp:Button ID="Button1" runat="server" Text="Button" OnClick="Button1_Click" />
        <asp:Button ID="Button2" runat="server" Text="Button" OnClick="Button2_Click" />
        <asp:Button ID="Button3" runat="server" Text="删除视频表重复" OnClick="Button3_Click" />
        <asp:Button ID="Button4" runat="server" Text="Button" OnClick="Button4_Click" />
        <asp:Button ID="Button5" runat="server" Text="删除没有视频的" OnClick="Button5_Click" />
        <asp:Button ID="Button6" runat="server" Text="导出表格" OnClick="Button6_Click" />
        <asp:Button ID="Button7" runat="server" Text="替换操作" OnClick="Button7_Click" />
        <asp:Button ID="Button8" runat="server" Text="修复" OnClick="Button8_Click" />
        <asp:Button ID="Button9" runat="server" Text="匹配" OnClick="Button9_Click" />
        <asp:Button ID="Button10" runat="server" Text="text" OnClick="Button10_Click" />
    </div>
        <div id="Div_alter">
            <div id="Div_alert_count">
              <p>asdddddddddddddddddddddddddddddda</p>
                <p>asdddddddddddddddddddddddddddddda</p>
                <p>asdddddddddddddddddddddddddddddda</p>
                <p>asdddddddddddddddddddddddddddddda</p>
                <p>asdddddddddddddddddddddddddddddda</p>
                <p>asdddddddddddddddddddddddddddddda</p>
                <p>asdddddddddddddddddddddddddddddda</p>
                <p>asdddddddddddddddddddddddddddddda</p>
                <p>asdddddddddddddddddddddddddddddda</p>
                <p>asdddddddddddddddddddddddddddddda</p>
                <p>asdddddddddddddddddddddddddddddda</p>
                <p>asdddddddddddddddddddddddddddddda</p>
                <p>asdddddddddddddddddddddddddddddda</p>
                <p>asdddddddddddddddddddddddddddddda</p>
                <p>asdddddddddddddddddddddddddddddda</p>
                <p>asdddddddddddddddddddddddddddddda</p>
            </div>
            <input type="button" id="alert_but" />
        </div>
    </form>
</body>
</html>
<script src="Scripts/jquery-1.8.2.min.js"></script>
<script>
    //$(function () {
    //    alert(getCookie("ValidateCode"));
    //})
    $("#yzm").click(function () {
        alert(getCookie("ValidateCode"));
    })
    $("#aspan").click(function () {
        alert("123");
        ValidateCode.aspx = ValidateCode.aspx + '?r=' + Math.random();
    })
    $("#alert_but").click(function () {
        $("#Div_alter").css("display","none");
    })
</script>

