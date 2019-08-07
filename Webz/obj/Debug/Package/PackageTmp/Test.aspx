<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="Test.aspx.cs" Inherits="Webz.Test" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
<meta http-equiv="Content-Type" content="text/html; charset=utf-8"/>
    <title></title>
    <style>
        * { 
        margin:0px; padding:0px;
        }
        body { width:100%; height:700px;}
        #daoru { 
        width:100%;
        margin-top:5%;
        }
        #Push { 
        width:100%;
        }

     #alert { text-align:center;line-height:250px; font-size:46px; width: 67%; height: 350px; background-image: url(Images/Imgs/我的课程-对话框.png); background-size: 100% 100%; position: fixed; top: 30%; left: 17%; display:none; }</style>
</head>
<body>
    <form id="form1" runat="server">
    <div>
        <div id="Push">选择要上传的文件：
     <asp:FileUpload ID="FileUp" runat="server" /> 
            <asp:Button ID="Button3" runat="server" Text="上传" OnClick="Button3_Click" /></div>
        <div id="daoru">
             <select id="seleid" runat="server">
            <option >----请选择要导入的文件----</option>
        </select>
        <asp:Button ID="Button4" runat="server" Text="课本检查" OnClick="Button4_Click" />
        <asp:Button ID="Button5" runat="server" Text="目录及视频检查" OnClick="Button5_Click"  />
           <%-- <input type="button" id="keben" value="导入课本" />--%>
        <asp:Button ID="Button1" runat="server" Text="导入课本" OnClick="Button1_Click" />
           <%-- <input type="button" id="mulu" value="导入目录及视频" />--%>
        <asp:Button ID="Button2" runat="server" Text="导入目录及视频" OnClick="Button2_Click" />
            <asp:Button ID="Button6" runat="server" Text="删除课件" OnClick="Button6_Click" />
            <asp:Button ID="Button7" runat="server" Text="Button" OnClick="Button7_Click" />
            <asp:Button ID="Button8" runat="server" Text="Button" OnClick="Button8_Click" style="height: 21px" />
            <asp:Button ID="Button9" runat="server" Text="修复" OnClick="Button9_Click" />
        </div>
       
    </div>
    </form>
</body>
    
</html>
<script src="Scripts/jquery-1.8.2.js"></script>
 <script>
     //$("#mulu").click(function () {
     //    $ajax(function () {

     //    })
     })
</script>
