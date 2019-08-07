<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="add.aspx.cs" Inherits="Webz.add" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
<meta http-equiv="Content-Type" content="text/html; charset=utf-8"/>
    <title></title>
</head>
<body>
    <form id="form1" runat="server">
    <div>
    <div>支出：</div>
        <div>内容：<input  type="text" id="count" value="" runat="server"/></div>
        <div>价格：<input  type="text" id="money" value="" runat="server"/></div>
        <input type="button" id="chu" />
    </div>
        <div>
    <div>收入：</div>
        <div>内容：<input  type="text" id="Text1" value="" runat="server"/></div>
        <div>价格：<input  type="text" id="Text2" value="" runat="server"/></div>
            <input type="button" id="ru" />
    </div>
    </form>
</body>
<script src="JS/jquery.1.7.2.min.js"></script>
    <script type="text/javascript">
        $("#chu").click(function () {
            var count = $("#count").val();
            var money = $("#money").val();

        })

    </script>
</html>
