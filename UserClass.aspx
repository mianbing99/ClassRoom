<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="UserClass.aspx.cs" Inherits="Webz.WebIE.UserClass" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <meta http-equiv="Content-Type" content="text/html; charset=utf-8" />
    <link href="../CSS/Index.css" rel="stylesheet" />
    <title>个人中心</title>
    <style>
        * { margin:0px; padding:0px;}
        body { width: 100%; font-size: 36px; }
        a { color: black; }
        #Top_index a { color: #FFCE44; font-weight: bold; font-size: 50px; }
        #Top_login a { color: #9CDCFE; font-weight: bold; font-size: 50px; }
        #Top { width: 100%; height: 10%; }
        #Top_index { width: 31%; height: 100%; float: left; text-align: left; padding-left: 2%; }
        #Top_con { font-weight: bold; height: 100%; width: 33%; float: left; text-align: center; font-size: 50px; }
        #Top_login { width: 31%; height: 100%; float: left; text-align: right; padding-right: 2%; }
        #caidan { position: fixed; bottom: 0; width: 100%; height: 130px; background-color: white; }
    </style>
</head>
<body>
    <div id="JsonPr" style="display:none"><%=jsonPr %></div>
    <div id="JsonGr" style="display:none"><%=jsonGr %></div>
    <div id="JsonBo" style="display:none"><%=jsonBo %></div>
   <%-- <input type="hidden"  value="<%=jsonPr %>" />
    <input type="hidden" id="" value="<%=jsonGr %>" />asdasdasdasdasdasd
    <input type="hidden" id="" value="<%=jsonBo %>" />--%>
    <form id="form1" runat="server">
        <div style="margin-top:2%;">
            <div style="margin-left:7%;"><%=User %>您好<br />请选择您现就读年级及出版社</div>
            
        <input type="hidden" id="Userid" value="<%=Userid %>" />
            <div style="margin-left:25%;">
                <div>
                    <select id="Xueduan" runat="server" style="height:80px; width:60%; margin-top:5%;">
                        <option value="0">----请选择学段----</option>
                        <option value="1">----小学----</option>
                        <option value="2">----初中----</option>
                        <option value="3">----高中----</option>
                    </select>
                </div>
                <div>
                    <select id="nianji" runat="server" style="height:80px; width:60%; margin-top:5%;">
                        <option value="0">----请选择年级----</option>
                    </select>
                </div>
                <div>
                    <select id="press" runat="server" style="height:80px; width:60%; margin-top:5%;">
                        <option>----请选择出版社----</option>
                    </select>
                </div>
                <div>
                    <select id="Semester" runat="server" style="height:80px; width:60%; margin-top:5%;">
                        <option>----请选择学期----</option>
                    </select>
                </div>
                <div style="margin-top:5%;">
                    <input type="button" id="But" value="保存" />
                <asp:Button ID="ButT" runat="server" Text="保存好了？去看看" OnClick="ButT_Click" />
                </div>
                
            </div>
            <div id="caidan" >
            <a href="Index.aspx"><img src="images/xuexi.png" width="24%" height="100%"/></a>
            <a href="BooksList.aspx"><img src="images/yizhi.png"  width="24%" height="100%" /></a>
            <a href="#"><img src="images/fudao.png"  width="24%" height="100%" /></a>
            <a href="UserInfo.aspx"><img src="images/wo.png"  width="24%" height="100%" /></a>
        </div>
        </div>
        
    </form>
</body>
</html>
<script src="../Scripts/jquery-1.8.2.min.js"></script>
<script>
    $(document).ready(function () {
        var Pr = $("#JsonPr").html();
        var Gr = $("#JsonGr").html();
        var Bo = $("#JsonBo").html();
        var jsonPr = eval("(" + Pr + ")");
        for (var it in jsonPr) {
            $("#press").append("<option value='" + jsonPr[it].ID + "'>----" + jsonPr[it].Prs + "----</option>");
            $("#press").val(jsonPr[it].XZID);
        }
        var jsonGr = eval("(" + Gr + ")");
        for (var it in jsonGr) {
            $("#nianji").append("<option value='" + jsonGr[it].ID + "'>----" + jsonGr[it].nianji + "----</option>");
            $("#nianji").val(jsonGr[it].XZID);
            $("#Xueduan").val(jsonGr[it].XDID);
        }
        var jsonBo = eval("(" + Bo + ")");
        for (var it in jsonBo) {
            $("#Semester").append("<option value='" + jsonBo[it].Sem + "'>----" + jsonBo[it].Sem + "----</option>");
            $("#Semester").val(jsonBo[it].XZID);
        }
    })
    $("#Xueduan").change(function () {
        var id = parseInt($(this).val());
        $('#nianji option').not(":first").remove();
        $('#press option').not(":first").remove();
        $('#Semester option').not(":first").remove();
        $.ajax({
            url: 'ashx/UserInfo.ashx',
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
    $("#nianji").change(function () {
        var GrName = $(this).val();
        $('#press option').not(":first").remove();
        $('#Semester option').not(":first").remove();
        $.ajax({
            url: 'ashx/UserInfo.ashx',
            type: 'post',
            datatype: "json",
            data: { action: "GrName", GrName: GrName },
            success: function (data) {
                var jsonObj = eval("(" + data + ")");
                for (var it in jsonObj) {
                    $("#press").append("<option value='" + jsonObj[it].ID + "'>----" + jsonObj[it].Prs + "----</option>");
                }
            }
        })
    })
    $("#press").change(function () {
        var PrName = $(this).val();
        var GrName = $("#nianji").val();
        $('#Semester option').not(":first").remove();
        $.ajax({
            url: 'ashx/UserInfo.ashx',
            type: 'post',
            datatype: "json",
            data: { action: "PrName", GrName: GrName, PrName: PrName },
            success: function (data) {
                var jsonObj = eval("(" + data + ")");
                for (var it in jsonObj) {
                    $("#Semester").append("<option value='" + jsonObj[it].Sem + "'>----" + jsonObj[it].Sem + "----</option>");
                }
            }
        })
    })
    $("#But").click(function () {
        var PrName = $("#press").val();
        var GrName = $("#nianji").val();
        var Xueduan = $("#Xueduan").val();
        var Semester = $("#Semester").val();
        var Userid = $("#Userid").val();
        $.ajax({
            url: 'ashx/UserInfo.ashx',
            type: 'post',
            datatype: "json",
            data: { action: "But", GrName: GrName, PrName: PrName, Xueduan: Xueduan, Semester: Semester, Userid: Userid },
            success: function (data) {
                var jsonObj = eval("(" + data + ")");
                for (var it in jsonObj) {
                    if (jsonObj[it].Sem == "ture") {
                        alert("保存成功");
                    }
                    else {
                        alert("保存失败");
                    }
                }
            }
        })
    })
</script>

