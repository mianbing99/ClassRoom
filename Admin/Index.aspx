<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="Index.aspx.cs" Inherits="Webz.Admin.Index" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
<meta http-equiv="Content-Type" content="text/html; charset=utf-8"/>
    <title></title>
</head>
<body>
    <form id="form1" runat="server">
    <div>
        <asp:Button ID="Button1" runat="server" Text="缺失视频目录导出" OnClick="Button1_Click" />
        <asp:Button ID="Button5" runat="server" Text="导出所有视频目录" OnClick="Button5_Click" />
        <asp:Button ID="Button2" runat="server" Text="首页轮播图管理" OnClick="Button2_Click" />
        <asp:Button ID="Button3" runat="server" Text="导入资源" OnClick="Button3_Click" />
        <asp:Button ID="Button4" runat="server" OnClick="Button4_Click" Text="课本图片管理" />
        <asp:Button ID="Button6" runat="server" OnClick="Button6_Click" Text="匹配视频" />
        <asp:Button ID="Button7" runat="server" Text="导入卡密" OnClick="Button7_Click" />
        <asp:Button ID="Button8" runat="server" Text="匹配视频" OnClick="Button8_Click" />
        <asp:Button ID="Button9" runat="server" Text="Button" OnClick="Button9_Click" />
        <asp:Button ID="Button10" runat="server" Text="挨打吧" OnClick="Button10_Click" />
    </div>
    </form>
</body>
</html>
<script src="../Scripts/jquery-1.8.2.min.js"></script>
<script>
    //$(function () {
        
    //})
    //layer.prompt({
    //    title: '请输入数据！', formType: 1,
    //    "success": function () {
    //        $("div").on('keydown', function (e) {
    //            if (e.which == 13) {
    //                console.log(e.which);
    //                if ("123456" == $(this).val()) {
    //                    alert('回车');
    //                    layer.close(1);
    //                }
    //            }
    //        });
    //    }
    //});
    
    //document.onkeydown = function (e) {
    //    var ev = document.all ? window.event : e;
    //    if (ev.keyCode == 13) {
    //        if ($(".window").css("display") == "none" && $(".messager-window").css("display") != "block") {
    //            $("#searchbtn").click();
    //        }
    //        else if ($(".window").css("display") == "block" || $(".messager-window").css("display") == "block") {
    //            var object = $(".window").find(".icon-ok")[0];
    //            var messobject = $(".messager-window").find(".messager-button").find(".l-btn-text");
    //            if (messobject.length <= 0) {
    //                object.click();
    //            } else {
    //                messobject[0].click();
    //            }
    //        }
    //        return false;
    //    }
    //}
</script>
