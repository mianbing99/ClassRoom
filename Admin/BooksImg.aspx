<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="BooksImg.aspx.cs" Inherits="Webz.Admin.BooksImg" %>

<%@ Register Assembly="AspNetPager" Namespace="Wuqi.Webdiyer" TagPrefix="webdiyer" %>

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
            <td>课本名称</td><td>图片路径</td><td>操作</td>
        </tr>
        <asp:Repeater ID="RpList" runat="server">
            <ItemTemplate>
                <tr>
                    <td><%#Eval("booksname") %></td>
                     <td class="td"><%#Eval("img") %>
                        <img src="<%#Eval("img") %>" style="display:none; position:absolute; width:200px; height:100px;"/>
                     </td> 
                    <td><a href="BooksImgUpdate.aspx?bid=<%#Eval("TextID") %>">修改图片</a></td>
                </tr>
            </ItemTemplate>
        </asp:Repeater>
    </table>
        <webdiyer:AspNetPager  class="arPage" PageSize="20" UrlPaging="true" 
            runat="server" ID="pgServer" 
            CustomInfoHTML="共%PageCount%页记录<span>|</span>每页<em>%PageSize%</em>条<span>|</span>当前第<em>%CurrentPageIndex%</em>页" 
            FirstPageText="首页" LastPageText="尾页" NextPageText="下一页" PrevPageText="上一页" 
            ShowCustomInfoSection="Left" Height="18px" >
    </webdiyer:AspNetPager>
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
