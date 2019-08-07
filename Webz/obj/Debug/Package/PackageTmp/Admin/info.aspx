<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="info.aspx.cs" Inherits="Webz.Admin.info" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
<meta http-equiv="Content-Type" content="text/html; charset=utf-8"/>
    <title></title>
    <script src="CC/jquery-3.3.1.js"></script>
</head>
<body>
    <form id="form1" runat="server">
    <div>
        <script src="CC/jquery-3.3.1.js"></script>
        <script type="text/javascript">
            $(function () {
                var fl = 0;
                var count = 0;
                var Pageindex = 1;
                var PageSize = 10;
                var TbnName, GaID, SubI, PrID, PP, dataExPageList;
                var PPd, Judge;
                var laypage = null;
                var form = null;
                var url = "AjaxHelper/Ajax.ashx";
                $.post("AjaxHelper/Ajax.ashx", { type: "AllList", Pageindex: Pageindex, PageSize: PageSize, TbnName: TbnName, GaID: GaID, SubI: SubI, PrID: PrID, PP: PP, Judge: Judge },
                    function (data) { console.log(data) }, "json");
            })

        </script>
    </div>
    </form>
</body>
</html>
