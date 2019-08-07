<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="CardADD.aspx.cs" Inherits="Webz.Admin.CardADD" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
<meta http-equiv="Content-Type" content="text/html; charset=utf-8"/>
    <title></title>
</head>
<body>
    <form id="form1" runat="server">
    <div>
        <asp:FileUpload ID="FileUpload1" runat="server" /><br />
        <select id="Selid" runat="server">
            <option>---请选择要导入的文件---</option>
        </select>
        <asp:Button ID="Button1" runat="server" Text="导入" OnClick="Button1_Click" />
    </div>
    </form>
</body>
</html>
