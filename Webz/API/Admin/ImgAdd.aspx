<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="ImgAdd.aspx.cs" Inherits="Webz.Admin.ImgAdd" %>

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
            <td>图片标题：</td><td >
                <asp:TextBox ID="ImgName" runat="server"></asp:TextBox></td>
        </tr>
        <tr>
            <td>图片链接途径：</td><td >
                <asp:TextBox ID="ImgUrl" runat="server"></asp:TextBox></td>
        </tr>
        <tr>
            <td>选择图片：</td>
            <td >
                <asp:TextBox ID="But_pic" runat="server" style="display:none"></asp:TextBox><%--<input type="text" id="" value="" runat="server" name="picnone"  />--%>
                <input type="button" value="重新上传图片" name="picnone" style="display:none" id="butpic" runat="server" />
                <asp:FileUpload ID="Upload" runat="server" />

            </td>

        </tr>
        <tr>
            <td>是否显示：</td><td ><asp:CheckBox ID="CK1" runat="server" /></td>
        </tr>
        <tr>
            <td><asp:Button ID="But_" runat="server" Text="确定" OnClick="But__Click" />
                <input type="hidden" id="Hid" value="0" runat="server"/>
                </td>
            <td>
                <asp:Button ID="But_ret" runat="server" Text="返回" OnClick="But_ret_Click" /></td>
        </tr>
    </table>
    </div>
    </form>
</body>
</html>
<script src="../Scripts/jquery-1.8.2.min.js"></script>
<script>
    $(document).ready(function () {
       
        function GetQueryString(name) 
        {
            var result = location.search.match(new RegExp("[\?\&]" + name+ "=([^\&]+)","i"));

            if (result == null || result.length < 1) {
                return "";
            }
            return result[1];
        }
        var id = GetQueryString("imgid");
        if (id != "") {
            $("#But_pic").css("display", "inline");
            $("#butpic").css("display", "inline");
            $("#Upload").css("display", "none");
        }
    })
    $("#butpic").click(function () {
        $("#Hid").val("1");
        $("#But_pic").css("display", "none");
        $("#butpic").css("display", "none");
        $("#Upload").css("display", "inline");
    })
    
</script>

            
            
