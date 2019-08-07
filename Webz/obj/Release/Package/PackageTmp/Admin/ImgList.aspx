<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="ImgList.aspx.cs" Inherits="Webz.Admin.ImgList" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <meta http-equiv="Content-Type" content="text/html; charset=utf-8" />
    <title></title>
    <style>
        a {text-decoration:none;}
    </style>
</head>
<body>
    <form id="form1" runat="server">
        <div>
            <table>
                <tr>
                    <td></td> <td>图片标题</td> <td>图片路径</td> <td>图片链接</td> <td>操作</td>
                </tr>
                <asp:Repeater ID="RpList" runat="server">
                    <ItemTemplate>
                        <tr>
                            <td><input type="checkbox" name="xuanze" runat="server" /></td>
                            <td><%#Eval("ImgName") %></td><td class="td"><%#Eval("ImgPic") %>
                                <img src="<%#Eval("ImgPic") %>" style="display:none; position:absolute; width:200px; height:100px;"/>
                                                          </td>
                            <td><%#Eval("Href") %></td>
                            <td><a href="ImgAdd.aspx?imgid=<%#Eval("id") %>">编辑</a></td>
                        </tr>
                        <tr></tr>
                    </ItemTemplate>
                </asp:Repeater>
            </table>
             <asp:Button ID="Add" runat="server" Text="添加图片" OnClick="Add_Click" />
        </div>
    </form>
</body>
</html>
<script src="../Scripts/jquery-1.8.2.min.js"></script>
<script>
    $(".td").hover(function () {
        $(this).find("img").css("display", "inline");
    })
    $(".td").mouseout(function () {
        $(this).find("img").css("display", "none");
    })
</script>
