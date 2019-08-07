<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="Yijian.aspx.cs" Inherits="Webz.Yijian" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
<meta http-equiv="Content-Type" content="text/html; charset=utf-8"/>
    <title>个人中心</title>
    <link href="CSS/dicaidan.css" rel="stylesheet" />
    <style>
      * { font-size: 36px; margin: 0px; padding: 0px; }
        body { width: 100%; font-size: 36px; min-height: 2000px; background-image: url(Images/Imgs/最底部渐变色.png); background-repeat: no-repeat; background-size: 100% 100%; }
        a { text-decoration: none; color: black; }
        #yuandian { position: absolute; top: 2%; z-index: -1; width: 100%; height: 240px; }
        .Div_Text { width: 90%; height: 140px; float: left; margin: 2% 0px 0px 10%; }
        #Pr_title { width: 65%; border-radius: 15px; border: 2px solid #85DD64; background-color: #FFFFFF; height: 130px; margin-left: 15.3%; text-align: center; line-height: 130px; font-size: 45px; margin-top: 3%; margin-bottom: 2%; }
        #Pr_count { float: left; border-radius: 15px; width: 90%; margin: 0px 0px 7% 5%; background-color: #FFFFFF; min-height: 1100px; }
        #Pr_count input { margin-left: 2%; width: 70%; height: 90px; border: 5px solid #96CD80; border-radius: 10px; }
        #quxiao { background-image: url(Images/Imgs/取消.png); width: 30%; height: 100px; background-size: 100% 100%; background-repeat: no-repeat; border-radius: 10px; }
        #queding { background-image: url(Images/Imgs/登录.png); width: 30%; height: 100px; background-size: 100% 100%; background-repeat: no-repeat; border-radius: 10px; margin-left: 20%; }
        #butt { margin-left: 15%; margin-bottom: 200px; }
    </style>
</head>
<body>
    <form id="form1" runat="server">
  <div>
            <img id="yuandian" src="Images/Imgs/圆点.png" />
            <div id="Pr_title">意见反馈</div>
            <div id="Pr_count">
                
            </div>
            <div id="butt">
                <input type="button" id="quxiao" />
                <input type="button" id="queding" />
            </div>
            <%-- ------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------ --%>


            <div id="caidan">
                <div id="divImg_Index">
                    <img id="Img_Index" src="Images/Imgs/首页.png" width="100%" height="100%" />
                </div>
                <div id="divImg_Class">
                    <img id="Img_class" src="Images/Imgs/我的课程按钮.png" width="100%" height="100%" />
                </div>
                <div>
                    <img id="UserInfo" src="Images/Imgs/个人中心按钮.png" width="100%" height="100%" />
                </div>
            </div>
            <div id="div_Usercaidan" >
                <a href="UserAdd.aspx">
                    <div class="but">注册激活</div>
                </a>
                <a href="Login.aspx">
                    <div class="but">登   录 </div>
                </a>
                <a href="UserClass.aspx">
                    <div class="but">课程设置</div>
                </a>
                <a>
                    <div class="but">意见反馈</div>
                </a>
                <a href="About.aspx">
                    <div class="but">联系我们</div>
                </a>
            </div>
            <div id="alert" style=" background-image: url(Images/Imgs/我的课程-对话框.png);"></div>
            <input type="hidden" id="Usercaidan" value="0" />
        </div>
        <input type="hidden" id="state" value="" />
        <input type="hidden" id="GrName" value="" />
        <input type="hidden" id="SuName" value="" />
        <input type="hidden" id="Hisession" value="" />
    </form>
</body>
</html>
