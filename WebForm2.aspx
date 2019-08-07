<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="WebForm2.aspx.cs" Inherits="Webz.WebForm2" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
<meta http-equiv="Content-Type" content="text/html; charset=utf-8"/>
    <title></title>
</head>
<body>
    <form id="form1" runat="server">
    <div>
        <asp:TextBox ID="TextBox1" runat="server"></asp:TextBox>
        <span id="aspan" >看不清，换一张</span>
        <img id="yzm" runat="server" alt="看不清，换一张" title="看不清，换一张" src="ValidateCode.aspx" style="cursor:pointer" onclick="this.src=this.src+'?r='+Math.random()" />
        <asp:Button ID="Button1" runat="server" Text="Button" OnClick="Button1_Click" />
        <asp:Button ID="Button2" runat="server" Text="Button" OnClick="Button2_Click" />
        <asp:Button ID="Button3" runat="server" Text="删除视频表重复" OnClick="Button3_Click" />
        <asp:Button ID="Button4" runat="server" Text="Button" OnClick="Button4_Click" />
        <asp:Button ID="Button5" runat="server" Text="删除没有视频的" OnClick="Button5_Click" />
        <asp:Button ID="Button6" runat="server" Text="导出表格" OnClick="Button6_Click" />

        <asp:Button ID="Button7" runat="server" Text="替换操作" OnClick="Button7_Click" /></div>
    </form>
</body>
</html>
<script src="Scripts/jquery-1.8.2.min.js"></script>
<script>
    $(function () {
        alert(getCookie("ValidateCode"));
    })
    $("#yzm").click(function () {
        alert(getCookie("ValidateCode"));
    })
    $("#aspan").click(function () {
        alert("123");
        ValidateCode.aspx = ValidateCode.aspx + '?r=' + Math.random();
    })
    
</script>

