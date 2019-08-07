<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="BooksList.aspx.cs" Inherits="Webz.Admin.BooksList" %>

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
            <td>ISBN</td><td>年份</td><td>课本名称</td><td>图片</td><td>是否显示</td>
        </tr>
        <tr id="Trshuju">

        </tr>
    </table>
    </div>
    </form>
</body>
</html>
<script src="../Scripts/jquery-1.8.2.min.js"></script>
<script>
    $(document).ready(function () {
        $.ajax({
            url: 'ashx/AdminBooks.ashx',
            type: 'post',
            datatype: "json",
            data: { action: "xueduan", id: id },
            success: function (data) {
                var jsonObj = eval("(" + data + ")");
                for (var it in jsonObj) {
                    $("#nianji").append("<option value='" + jsonObj[it].ID + "'>----" + jsonObj[it].nianji + "----</option>");
                }
            }
        })
    })
    
    </script>