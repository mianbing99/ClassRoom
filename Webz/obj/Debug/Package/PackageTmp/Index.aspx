<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="Index.aspx.cs" Inherits="Webz.WebIE.Index" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
<meta http-equiv="Content-Type" content="text/html; charset=utf-8"/>
    <title>名师课堂</title>
    <link href="../CSS/shutter.css" rel="stylesheet" />
    <link href="CSS/dicaidan.css" rel="stylesheet" />
    <style>
    * { padding:0px; margin:0px; font-size:36px;}
    a {text-decoration:none; color: black; }
    #xueduan div { float: left; width: 33.33%; height: 120px; line-height: 25px; text-align: center; background-color:#69B84B;}
        .titlediv { width:100%; height:100px; background-color:#9BFE76; float:left; margin-top:0%;}
        .titlefont { width:24%; height:70px; line-height:65px; border-bottom:2px solid #D48A01; margin-left:4%; text-align:center;margin-top:0.7%;}
        .titleright { width:40%; height:80px; color:#1C2D15; margin-right:2%; margin-top:0.7%; float:right; position:relative; top:-60%; left:0%; font-size:30px;}
        .nianji { width:100%; float:left; margin:0px 0px 2% 1.5%;}
        .nianjilist { width:29%; float:left; height:300px; margin:1% 2.3% 2% 2%;}
        .nianjilist span { float:left; text-align:center; width:95%;}
        #divImg_Index { border-right:2px solid #FFFFFF;}
        #divImg_Class { border-right:2px solid #FFFFFF;}
    </style>
</head>
<body>
    <form id="form1" runat="server" style="position:relative; top:-77px;">
        
    <div style="height:100%; width:100%;">
       
            <div class="shutter">
                    <div class="shutter-img"> 
                        <%=Imgstr %>
                    </div>
                          <ul class="shutter-btn">
                            <li class="prev"></li>
                            <li class="next"></li>
                          </ul>
              </div>
        <div id="xueduan"><%--学段DIV--%>
            <a href="#XxMj"><div ><img src="Images/Imgs/小学按钮.png" width="106.2%" height="100%"/></div></a>
             <a href="#CzMj"><div ><img src="Images/Imgs/初中按钮.png" width="106.2%" height="100%"/></div></a>
            <a href="#GzMj"><div><img src="Images/Imgs/高中按钮.png" width="106.2%" height="100%"/></div></a>
        </div>
        <div id="xiaoxue"><%--小学DIV--%>
            <div class="titlediv">
                <img src="Images/Imgs/小学目录.png" width="102%"; height="100%"/>
            </div>
            <div class="nianji">
                        <a href="PressList.aspx?Grid=128">
                        <div class="nianjilist">
                            <img src="Images/Imgs/一年级.png" width="100%"; height="85%"  /> 
                            <span>一年级</span>
                        </div>
                            </a>
                <a href="PressList.aspx?Grid=129">
                        <div class="nianjilist">
                            <img src="Images/Imgs/二年级.png" width="100%"; height="85%"  /> 
                             <span>二年级</span>
                        </div>
                            </a>
                <a href="PressList.aspx?Grid=130">
                        <div class="nianjilist">
                            <img src="Images/Imgs/三年级.png" width="100%"; height="85%"  /> 
                             <span>三年级</span>
                        </div>
                            </a>
                <a href="PressList.aspx?Grid=131">
                        <div class="nianjilist">
                            <img src="Images/Imgs/四年级.png" width="100%"; height="85%"  /> 
                             <span>四年级</span>
                        </div>
                            </a>
                <a href="PressList.aspx?Grid=132">
                        <div class="nianjilist">
                            <img src="Images/Imgs/五年级.png" width="100%"; height="85%"  /> 
                             <span>五年级</span>
                        </div>
                            </a>
                <a href="PressList.aspx?Grid=133">
                        <div class="nianjilist">
                            <img src="Images/Imgs/六年级.png" width="100%"; height="85%"  /> 
                             <span>六年级</span>
                        </div>
                            </a>
            </div>
        </div>
        <div id ="XxMj"></div>


          
        <div id="zhongxue"><%--中学DIV--%>
            <div  class="titlediv">
               <img src="Images/Imgs/初中目录.png" width="102%"; height="100%"/>
            </div>
            <div class="nianji">
                        <a href="PressList.aspx?Grid=27">
                        <div class="nianjilist">
                            <img src="Images/Imgs/七年级.png" width="100%"; height="85%" /> 
                             <span>七年级</span>
                        </div>
                            </a>
                 <a href="PressList.aspx?Grid=28">
                        <div class="nianjilist">
                            <img src="Images/Imgs/八年级.png" width="100%"; height="85%" />
                             <span>八年级</span>
                        </div>
                            </a>
                 <a href="PressList.aspx?Grid=29">
                        <div class="nianjilist">
                            <img src="Images/Imgs/九年级.png" width="100%"; height="85%" />
                             <span>九年级</span>
                        </div>
                            </a>
            </div>
        </div>
               <div id ="CzMj"></div>
        
        <div id="gaozhong"><%--高中DIV--%>
            <div class="titlediv">
                <img src="Images/Imgs/高中目录.png" width="102%"; height="100%" />
            </div>
            <div class="nianji" >
                        <a href="PressList.aspx?Stuid=1">
                        <div class="nianjilist" style="margin-bottom:200px;">
                            <img src="Images/Imgs/高一.png" width="100%"; height="85%"/>
                             <span>高一</span>
                        </div>
                            </a>
                 <a href="PressList.aspx?Stuid=1">
                        <div class="nianjilist" style="margin-bottom:200px;">
                            <img src="Images/Imgs/高二.png" width="100%"; height="85%"/>
                             <span>高二</span>
                        </div>
                            </a>
                 <a href="PressList.aspx?Stuid=1">
                        <div class="nianjilist" style="margin-bottom:200px;">
                            <img src="Images/Imgs/高三.png" width="100%"; height="85%" />
                             <span>高三</span>
                        </div>
                            </a>
            </div>
            
        </div>
        
        <div id="caidan">
            <div id="divImg_Index"><img id="Img_Index" src="Images/Imgs/首页.png" width="100%" height="100%"/></div>
            <div id="divImg_Class" ><img id="Img_class" src="Images/Imgs/我的课程按钮.png"  width="100%" height="100%" /></div>
            <div ><img id="UserInfo" src="Images/Imgs/个人中心按钮.png"  width="100%" height="100%" /></div>
        </div>
         <div id="div_Usercaidan" >
        <a href="UserAdd.aspx"><div  class="but" > 注册激活</div></a>
        <a id="A_Login" href="Login.aspx"><div id="Div_But_Login" class="but"> 登   录 </div></a>
        <a href="xiugai.aspx?class=1"><div  class="but"> 课程设置</div></a>
        <a  href="Feedback.aspx"><div class="but"> 意见反馈</div></a>
        <a href="About.aspx"><div  class="but"> 联系我们</div></a>
    </div>
        <input type="hidden" id="Usercaidan" value="0"/>
        <input type="hidden" id="Hisession" value="<%=Sess %>" />
    </div>
        <div id ="GzMj" style=" float:left;"></div>
        <div></div>
        <div id="alert" style=" background-image: url(Images/Imgs/我的课程-对话框.png);"></div>
    </form>
</body>
</html>
<script src="js/jquery.min.js"></script>
<script src="js/velocity.js"></script>
<script src="js/shutter.js"></script>
<script src="js/ButJs.js"></script>
<script>
    $(function () {
        var ses = $("#Hisession").val();
        sess(ses);
        $('.shutter').shutter({
            shutterW: 1000, // 容器宽度
            shutterH: 700, // 容器高度
            isAutoPlay: true, // 是否自动播放
            playInterval: 3000, // 自动播放时间
            curDisplay: 3, // 当前显示页
            fullPage: false // 是否全屏展示
        });
    });
</script>