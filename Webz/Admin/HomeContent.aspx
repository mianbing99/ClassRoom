<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="HomeContent.aspx.cs" Inherits="Webz.Admin.HomeContent" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <meta http-equiv="Content-Type" content="text/html; charset=utf-8" />
    <title></title>
    <style>
        img {
            width: 100%;
            height: 100%;
            max-width: 100%;
            max-height: 100%;
        }

        body {
            overflow-x: hidden;
            overflow-y : hidden;
            margin:0;
            padding:0;
        }

        .body-title {
            margin-left:12px;
            font-size:12px;
            margin-bottom:5px;
        }
        .body-container {
            height:220px;
            margin:0 12px;
            background: url(Img/播放器底部.png) no-repeat;
            background-size: 100% 100%;
            border-radius:10px;
            padding-top:300px;
            text-align:center;
        }
    </style>
</head>
<body>
    <form id="form1" runat="server">
        <div class="body" style="min-height: 600px;">
            <div class="body-title">
                <div class="title-container">当前位置：首页</div>
            </div>
            <div class="body-container">
                
                <div class="prompt">
                    <div class="promptvalue">正在规划开发中，敬请期待</div>
                </div>
                <%--<img src="Img/播放器底部.png" />--%>
            </div>
         </div>
        
    </form>
</body>
</html>
