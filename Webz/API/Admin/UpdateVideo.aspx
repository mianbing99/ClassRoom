<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="UpdateVideo.aspx.cs" Inherits="Webz.Admin.UpdateVideo" EnableSessionState="True" %>


<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
<meta http-equiv="Content-Type" content="text/html; charset=utf-8"/>
    <title></title>
</head>
<body>
    <form id="form1" runat="server">
    <div>
        <select id="nianji" runat="server">
            <option value="">---请选择年级---</option>
            <option value="一年级">---一年级---</option>
            <option value="二年级">---二年级---</option>
            <option value="三年级">---三年级---</option>
            <option value="四年级">---四年级---</option>
            <option value="五年级">---五年级---</option>
            <option value="六年级">---六年级---</option>
            <option value="七年级">---七年级---</option>
            <option value="八年级">---八年级---</option>
            <option value="九年级">---九年级---</option>
            <option value="高一">---高一---</option>
            <option value="高二">---高二---</option>
            <option value="高三">---高三---</option>
        </select>
        <input type="hidden" value="" id="Tnianji" runat="server"/>
        <select id="SuName" runat="server">
            <option value="">---科目---</option>
            <option value="语文">---语文---</option>
            <option value="数学">---数学---</option>
            <option value="英语">---英语---</option>
            <option value="物理">---物理---</option>
            <option value="化学">---化学---</option>
            <option value="生物">---生物---</option>
            <option value="历史">---历史---</option>
            <option value="政治">---政治---</option>
            <option value="地理">---地理---</option>
        </select>
        <input type="hidden" value="" id="TSuName" runat="server"/>
       <input type="text" value="" id="TxtName" runat="server" placeholder="这里输入查找的课文名称"/>
        <asp:CheckBox ID="CheckBox3" runat="server" Checked="true"/>勾选表示显示全部
        <asp:CheckBox ID="CheckBox1" runat="server"   />勾选表示显示MP4没有匹配视频的课文
        <asp:CheckBox ID="CheckBox2" runat="server"   />勾选表示显示HTV没有匹配视频的课文<br />
        <asp:Button ID="Button3" runat="server" Text="查找" OnClick="Button3_Click" />
        <asp:Button ID="Button1" runat="server" Text="匹配当前页视频" OnClick="Button1_Click" />
        <asp:Button ID="Button4" runat="server" Text="导出当前页" OnClick="Button4_Click" /><br />
        <asp:TextBox ID="TxtIndex" runat="server"></asp:TextBox><asp:TextBox ID="Txtlast" runat="server"></asp:TextBox>
        <asp:Button ID="Button2" runat="server" Text="匹配从多少页到多少页" OnClick="Button2_Click" />
        <asp:Button ID="Button5" runat="server" Text="导出多少页到多少页" OnClick="Button5_Click" />
        <table>
            <tr>
                <td>书名</td><td>学期</td><td>课文名称</td><td>HTV</td><td>MP4</td><td>模糊匹配</td>
            </tr>
            <asp:Repeater ID="Repeater1" runat="server">
                <ItemTemplate>
                    <tr>
                <td><%#Eval("BooksName") %></td> <td><%#Eval("CaName") %></td>
                        <td><%#Eval("routearess") %></td><td><%#Eval("Mp4") %></td>
                        <td><a href="Video?Caname=<%#Eval("Caname") %>&caid=<%#Eval("caid") %>">匹配</a></td>
            </tr>
                </ItemTemplate>
            </asp:Repeater>
        </table>
      <div style="margin-left:40%;"><a href="UpdateVideo.aspx?page=1">首页</a><a href="UpdateVideo.aspx?page=<%=page-1 %>">上一页</a>
          <a href="UpdateVideo.aspx?page=<%=page+1 %>">下一页</a><a href="UpdateVideo.aspx?page=<%=Maxpage/30 %>">末页</a>
          <input type="text" id="TextPage" runat="server" style="width:40px;"/>
          <asp:Button ID="ButPage" runat="server" Text="跳转" OnClick="ButPage_Click" />
      </div>
    </div>
        
    </form>
</body>
</html>
<script src="../Scripts/jquery-1.8.2.min.js"></script>
<script>
    $("#Button3").click(function () {
        $("#Tnianji").val($("#nianji").val());
        $("#TSuName").val($("#SuName").val());
    })
</script>

