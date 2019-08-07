<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="BooksImgUpdate.aspx.cs" Inherits="Webz.Admin.BooksImgUpdate" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
<meta http-equiv="Content-Type" content="text/html; charset=utf-8"/>
    <title></title>
</head>
<body>
    <form id="form1" runat="server">
    <div>
    <table>
        <tr>
            <td>课本名称</td><td><asp:TextBox ID="TextName" runat="server"></asp:TextBox></td>
        </tr>
        <tr>
            <td>图片路径</td><td><asp:TextBox ID="TextPic" runat="server"></asp:TextBox>
                <input type="button" id="ButPic" value="修改图片"/>
                <input type="hidden" id="Hid" value="0" runat="server" />
                <asp:FileUpload ID="Upload1" runat="server" />
                         </td>
        </tr>
        <tr>
            <td> <asp:Button ID="Button1" runat="server" Text="确定" OnClick="Button1_Click" /></td>
            <td><asp:Button ID="Button2" runat="server" Text="返回" OnClick="Button2_Click" /></td>
        </tr>
    </table>
    </div>
    </form>
</body>
</html>
<script src="../Scripts/jquery-1.8.2.min.js"></script>
<script>
    $(document).ready(function () {
        $("#Upload1").css("display", "none");
    })
    $("#ButPic").click(function () {
        $("#Hid").val("1");
        $("#TextPic").css("display", "none");
        $("#ButPic").css("display", "none");
        $("#Upload1").css("display", "inline");
    })

</script>
