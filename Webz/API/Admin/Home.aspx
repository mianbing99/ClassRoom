<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="Home.aspx.cs" Inherits="Webz.Admin.Home" %>

<%@ Register Assembly="AspNetPager" Namespace="Wuqi.Webdiyer" TagPrefix="webdiyer" %>
<%@ Register Src="~/Admin/Views/CC_GradeList.ascx" TagPrefix="uc1" TagName="CC_GradeList" %>
<%@ Register Src="~/Admin/Views/CC_SubjectList.ascx" TagPrefix="uc1" TagName="CC_SubjectList" %>
<%@ Register Src="~/Admin/Views/CC_PublishingList.ascx" TagPrefix="uc1" TagName="CC_PublishingList" %>
<%@ Register Src="~/Admin/Views/CC_Table_PageList.ascx" TagPrefix="uc1" TagName="CC_Table_PageList" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <meta charset="utf-8" />
    <meta name="viewport" content="width=device-width, initial-scale=1, maximum-scale=1"/>
    <script src="CC/jquery-3.3.1.js"></script>
    <script src="CC/layui-v2.4.5/layui/layui.js"></script>
    <link href="CC/layui-v2.4.5/layui/css/layui.css" rel="stylesheet" media="all" />
    <%--<link href="../CSS/cebianlan.css" rel="stylesheet" />--%>
    <link href="../CSS/content.css" rel="stylesheet" />
    <link href="../CSS/AdminVideo.css" rel="stylesheet" />
    <title>首页</title>
    <style>
        #count_l1 {
            width: 15%;
            height: 640px;
            background-color: #0F65CC;
        }

        span {
            cursor: pointer;
        }

        #cebian div {
            border-bottom: 0.5px solid #ffffff;
        }

        i {
            margin-right:10px;
        }
        /*.layui-side-scroll {
            line-height: 40px !important;
        }*/
    </style>
</head>
<body>
    <form runat="server">
    <div class="layui-layout layui-layout-admin">
        <div class="layui-header" style="background:url(../Admin/Img/导航栏60.png) no-repeat;">
            <!-- 头部区域（可配合layui已有的水平导航） -->
            <ul class="layui-nav layui-layout-right">
                <li class="layui-nav-item">用户名 ：<label id="user"></label>
                </li>
            </ul>
        </div>

        <div class="layui-side layui-bg-black">
            <div class="layui-side-scroll">
                <!-- 左侧导航区域（可配合layui已有的垂直导航） -->
                <ul class="layui-nav layui-nav-tree" lay-filter="test">
                    <li class="layui-nav-item"><a href="HomeContent.aspx" target="content"><i class="layui-icon layui-icon-home"></i>首页</a></li>
                    <li class="layui-nav-item"><a href="VideoResourceManager.aspx" target="content"><i class="layui-icon layui-icon-video"></i>视频资源管理</a></li>
                    <li class="layui-nav-item"><a href="CatalogManage.aspx" target="content"><i class="layui-icon layui-icon-list"></i>教材目录管理</a></li>
                    <li class="layui-nav-item">
                        <a class="" href="javascript:;"><i class="layui-icon layui-icon-video"></i>视频匹配</a>
                        <dl class="layui-nav-child">
                            <dd><a href="SelectVideo.aspx" target="content">模糊匹配</a></dd>
                            <dd><a href="SelectsVideo.aspx" target="content">批量匹配</a></dd>
                        </dl>
                    </li>
                    <li class="layui-nav-item">
                        <a href="javascript:;"><i class="layui-icon layui-icon-user"></i>用户统计</a>
                        <dl class="layui-nav-child">
                            <dd><a href="EnrollStatistical.aspx" target="content">注册统计</a></dd>
                            <dd><a href="javascript:;">播放统计</a></dd>
                        </dl>
                    </li>
                    <li class="layui-nav-item"><a href="FeedBack.aspx" target="content"><i class="layui-icon layui-icon-survey"></i>意见反馈</a></li>
                    <li class="layui-nav-item">
                        <a href="javascript:;"><i class="layui-icon layui-icon-username"></i>账号管理</a>
                        <dl class="layui-nav-child">
                            <dd><a href="UserManage.aspx" target="content">用户管理</a></dd>
                            <dd><a href="ChangePassword.aspx" target="content">修改密码</a></dd>
                            <dd><a href="ChangePermission.aspx" target="content">更改账号权限</a></dd>
                        </dl>
                    </li>
                    <li class="layui-nav-item"><a href="Login.aspx"><i class="layui-icon layui-icon-close-fill"></i>退出</a></li>
                </ul>
            </div>
        </div>

        <div class="layui-body">
            <iframe id="content" name="content" frameborder="0" scrolling="yes" marginheight="0" marginwidth="0" src="HomeContent.aspx" style="width: 100%; height:100%;"></iframe>
        </div>
    </div>
        </form>
</body>
</html>
<script src="../js/video.js"></script>

<script>
    //获取session中登录名
    var username = "<%=Session["username"]%>";
    <%--<% int userid = Convert.ToInt32(Session["userid"]);
       Model.Roles rs = new BLL.RolesBLL().GetByUserID(userid);
       %>
    var username = "<%=rs.UserName%>";--%>
    //获取
    //显示登录名
    $("#user").html(username);

    //下拉子菜单
    $(function () {
        $("body").on("click", ".xiala", function () {
            //alert($(this).html());
            $(this).find("div").animate({
                height: 'toggle'
            });
        });
    });

    layui.use('element', function () {
        var element = layui.element;

    });
    
</script>
