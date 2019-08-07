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
        <select class="nianji">
            <option value="0">111</option>

            </select>
    </div>
    </form>
</body>
</html>
<script src="../Scripts/jquery-1.8.2.min.js"></script>
<script>
    $(document).ready(function () {
        //$.ajax({
        //    url: 'ashx/AdminBooks.ashx',
        //    type: 'post',
        //    datatype: "json",
        //    data: { action: "grade", id: id },
        //    success: function (data) {
        //        alert(data);
        //        //var jsonObj = eval("(" + data + ")");
        //        //for (var it in jsonObj) {
        //        //    $(".nianji").append("<option value='" + jsonObj[it].ID + "'>----" + jsonObj[it].nianji + "----</option>");
        //        //}
        //    }
        //})
        
        $.ajax({
            url: "/ashx/AdminBooks.ashx",
            type: "post",
            dataType: "json",
            data: "action=grade",
            success: function (data) {
                console.log(data);
                //for (var i=0; i<data.length;i++) {
                //    $(".nianji").append("<option value='" + data[i].GradeID + "'>" + data[i].GrName + "</option>");
                //}
                for (var i = 0; i < data.list.length; i++) {
                    $(".nianji").append("<option value='" + data.list[i].GradeID + "'>" + data.list[i].GrName + "</option>");
                }
            }
        });
    })
    
    </script>