<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="Video.aspx.cs" Inherits="Webz.Admin.Video" %>

<%--<%@ OutputCache Duration="2000" VaryByParam="none" %>--%>
<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <meta http-equiv="Content-Type" content="text/html; charset=utf-8" />
    <title></title>
    <style>
        .yulan { margin-left: 10%; }
        .Video { position: fixed; top: 10%; left: 15%; width: 80%; height: 450px; background-color: aqua; display: none; }
        #tishi { width: 60px; height: 100px; position: fixed; right: 20px; top: 30%; background-color: #99CE84; }
        table { border-right: 2px solid #1E1E1E; border-bottom: 2px solid #1E1E1E; border-collapse: collapse; width:80%;margin-left:20%;}
        table td { border-left: 2px solid #1E1E1E; border-top: 2px solid #1E1E1E; height:60px; }
    </style>
</head>
<body>
    <form id="form1" runat="server">
        <div>
            <div style="width: 40%; margin-left: 30%;">
                 当前的课本名称：<span><%=qtBooksName %></span><br />
                当前的课文名称：<span><%=qtcaname %></span><br />
                查找的视频名称：<input type="text" value="" id="Txt_CaName" runat="server" />
                <asp:Button ID="Button1" runat="server" Text="查找" OnClick="Button1_Click" />
                <asp:Button ID="Button2" runat="server" Text="返回目录" OnClick="Button2_Click"/>
            </div>
            <div>

                <table style="width: 80%; margin-left: 10%;">
                    <tr>
                        <td>序号</td>
                        <td>HTV路径</td>
                        <td>MP4路径</td>
                        <td>预览</td>
                        <td>绑定</td>
                    </tr>
                    <asp:Repeater ID="Repeater1" runat="server">
                        <ItemTemplate>
                            <tr>
                                <td><%#Container.ItemIndex + 1%>  </td>
                                <td><%#Eval("Htv") %></td>
                                <td><%#Eval("Mp4") %></td>
                                 <td class="yulan"> <input id="http://183.60.136.8:188/<%#Eval("Mp4")%>" type="button" value="预览" name="Video" /></td>
                     <td><input id="<%#Eval("Mp4") %>" type="button" value="绑定" name="bangding" /><input type="hidden" name="HidMp4" value="<%#Eval("Mp4") %>" /></td>
                            </tr>
                        </ItemTemplate>
                    </asp:Repeater>

                </table>

            </div>
            <div></div>
        </div>
        <div class="Video">
            <input type="button" id="Close" value="关闭" style="position: absolute; right: 1%; top: 0px; width: 40px; height: 30px;" />

            <video id="Video" controls="controls" autoplay="autoplay" width="90%" height="100%" src=""></video>
        </div>
        <input type="hidden" id="T_Caname" value="" runat="server" />
        <input type="hidden" id="T_SuName" value="" runat="server" />
        <input type="hidden" id="T_Caid" value="" runat="server" />

    </form>
    <%--  <% int i = 1; %>
                     <%foreach (var item in select) {%>
                    <tr>
                        <td><%=i++ %></td>
               <td><%=item %></td> 
                    
                        <td class="yulan"> <input id="http://183.60.136.8:188/<%=item%>" type="button" value="预览" name="Video" /></td>
                     <td><input id="<%=item %>" type="button" value="绑定" name="bangding" /><input type="hidden" name="HidMp4" value="<%=item %>" /></td>
                           </tr>
                <% }  %>--%>
</body>
</html>
<script src="../Scripts/jquery-1.8.2.min.js"></script>
<script>
    $("input[name=\"Video\"]").click(function () {
        var Dis = $(".Video").css("display");
        if (Dis == "none") {
            $(".Video").css("display", "inline");
            $("#Video").attr("src", $(this).attr("id"));
        } else {
            $("#Video").attr("src", "");
            $(".Video").css("display", "none");
        }
    })
    $("#Close").click(function () {
        $(".Video").css("display", "none");
        $("#Video").attr("src", "");
    })
    $("input[name=\"bangding\"]").click(function () {
        var caname = $("#T_Caname").val();
        var Caid = $("#T_Caid").val();
        var Mp4 = $(this).attr("id");
        var But = $(this);
        if (Caid == "0") {
            return false;
        } else {
            $.ajax({
                url: '../ashx/Books.ashx',
                type: 'post',
                datatype: "json",
                data: { action: "bangding", caname: caname, Caid: Caid, Mp4: Mp4 },
                success: function (data) {
                    alert(data);
                    if (data == "绑定成功") {
                        But.val("解绑");
                    } else {
                        But.val("绑定");
                    }
                }
            })
        }

    })
</script>

