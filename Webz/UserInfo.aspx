<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="UserInfo.aspx.cs" Inherits="Webz.WebIE.UserInfo" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
<meta http-equiv="Content-Type" content="text/html; charset=utf-8"/>
    <title>个人中心</title>
    <style>
        * { font-size:60px; padding:0px; margin:0px;color:#FFFFFF;font-family: PingFangSC-Medium, sans-serif }
      
        #Di div { float:left; width:60%; height:100px; margin:3% 0px 2% 25%; }
        #Di { float:left; margin-top:10%;}
        .But { background-color:#69B84B; width:85%; height:100%; border-radius:15px; }
         #caidan { position: fixed; bottom: 0; width: 100%; height: 130px; background-color: white;}
     #alert { text-align:center;line-height:250px; font-size:46px; width: 67%; height: 350px; background-image: url(Images/Imgs/我的课程-对话框.png); background-size: 100% 100%; position: fixed; top: 30%; left: 17%; display:none; }</style>
</head>
<body>
    <form id="form1" runat="server">
    <div id="Di">
        <div id="Div_ADD"> <asp:Button ID="But_ADD" runat="server" Text="注册激活" OnClick="But_ADD_Click"  CssClass="But"/></div>
         <div><asp:Button ID="But_Class" runat="server" Text="课程设置" OnClick="But_Class_Click" CssClass="But"/></div>
        <div><asp:Button ID="But_zhinan" runat="server" Text="使用指南" OnClick="But_zhinan_Click"  CssClass="But"/></div>
        <div > <asp:Button ID="But_App" runat="server" Text="APP下载" OnClick="But_App_Click"  CssClass="But"/></div>
        <div> <asp:Button ID="But_Info" runat="server" Text="联系我们" OnClick="But_Info_Click"  CssClass="But"/></div>
        <div> <asp:Button ID="But_Out" runat="server" Text="注销登录"  CssClass="But" OnClick="But_Out_Click"/></div>
    </div>
          <input type="hidden" id="But_ADD_Hid" value="<%=ActivationState %>" />
          <div id="caidan">
                <a href="Index.aspx">
                    <img src="images/xuexi.png" width="24%" height="100%" /></a>
                <a href="Books.aspx">
                    <img src="images/yizhi.png" width="24%" height="100%" /></a>
                <a href="#">
                    <img src="images/fudao.png" width="24%" height="100%" /></a>
                <a href="UserInfo.aspx">
                    <img src="images/wo.png" width="24%" height="100%" /></a>
            </div>
    </form>
</body>
</html>
<script src="../Scripts/jquery-1.8.2.min.js"></script>
<script>
    $(document).ready(function () {
        var sta = $("#But_ADD_Hid").val();
        if (sta == 1) {
            $("#Div_ADD").css("display", "none");
        } else {
            $("#Div_ADD").css("display", "block");
        }
    })
</script>
