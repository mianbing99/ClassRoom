<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="AddVideo.aspx.cs" Inherits="Webz.Admin.AddVideo" %>

<%--<%@ Register Assembly="AspNetPager" Namespace="Wuqi.Webdiyer" TagPrefix="webdiyer" %>
<%@ Register Src="~/Admin/Views/CC_GradeList.ascx" TagPrefix="uc1" TagName="CC_GradeList" %>
<%@ Register Src="~/Admin/Views/CC_SubjectList.ascx" TagPrefix="uc1" TagName="CC_SubjectList" %>
<%@ Register Src="~/Admin/Views/CC_PublishingList.ascx" TagPrefix="uc1" TagName="CC_PublishingList" %>
<%@ Register Src="~/Admin/Views/CC_Table_PageList.ascx" TagPrefix="uc1" TagName="CC_Table_PageList" %>--%>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <%-- <meta name="viewport" content="width=device-width,initial-scale=1" />--%>
    <meta http-equiv="Content-Type" content="text/html; charset=utf-8" />
    <script src="CC/jquery-3.3.1.js"></script>
    <script src="CC/layui-v2.4.5/layui/layui.js"></script>
    <link href="CC/layui-v2.4.5/layui/css/layui.css" rel="stylesheet" />
    <link href="../CSS/cebianlan.css" rel="stylesheet" />
    <link href="../CSS/content.css" rel="stylesheet" />
    <link href="../CSS/AdminVideo.css" rel="stylesheet" />
    <title>新增视频</title>
    <style>
        body {
            overflow-x: hidden;
            overflow-y: hidden;
        }
        .TitelSr {
            width: 500px;
        }

        .layui-input {
            background-color: #E6E6E6;
        }

        .layui-btn {
            background-color: #0F65CC;
        }

        table {
            border-collapse: collapse;
            border:none;
            background: #ffffff;
            width: 90%;
            height: 505px;
            margin: 0 auto;
            text-align: center;
        }


                table tr td {
                    border: none;
                }

        .labtd {
            text-align: right;
            width: 12%;
        }

        .texttd {
            text-align: left;
            width: 38%;
        }

        .btndetermine {
            text-align: right;
            height: 350px;
            width:15%;
        }

        .btncancel {
            text-align: center;
            height: 350px;
            width:15%;
        }
    </style>
</head>
<body>
    <form id="form1" class="layui-form" method="post" runat="server">
        <div style="background: #E6E6E6; height: 700px; width: 100%; ">
        <div style="font-size: 12px; margin-left:1%;">当前位置：视频匹配>新增视频</div>
        <div style="height:54px;">
                <button id="btnShutdown" type="button" class="layui-btn"  style="position: absolute; right: 5%; top:30px;padding:0px 18px;" >退出</button>
            
        </div>
        <div style="height:510px; background:#ffffff;width:96%; border: solid 1px #aef2f5; margin-left:1%; ">
            <table>
                <tr >
                    <td class="labtd">ISBN：</td>
                    <td >
                        <input type="text" name="ISBN" required=""  lay-verify="required|number" lay-verify="title" placeholder="请输入图书编号" autocomplete="off" class="layui-input" ></td>
                    <td class="labtd">科&nbsp &nbsp &nbsp &nbsp目：</td>
                    <td class="texttd">
                        <input type="text" name="subjects" required="" lay-verify="required" placeholder="请输入科目" autocomplete="off" class="layui-input"></td>
                </tr>
                <tr>
                    <td class="labtd">学&nbsp &nbsp &nbsp &nbsp段：</td>
                    <td class="texttd">
                        <input type="text" name="period" required="" lay-verify="required" placeholder="请输入学段" autocomplete="off" class="layui-input"></td>
                    <td class="labtd">课本名称：</td>
                    <td class="texttd">
                        <input type="text" name="bookname" required="" lay-verify="required" placeholder="请输入课本名称" autocomplete="off" class="layui-input"></td>
                </tr>
                <tr>
                    <td class="labtd">年&nbsp &nbsp &nbsp &nbsp级：</td>
                    <td class="texttd">
                        <input type="text" name="grade" required="" lay-verify="required" placeholder="请输入年级" autocomplete="off" class="layui-input"></td>
                    <td class="labtd">目&nbsp &nbsp &nbsp &nbsp录：</td>
                    <td class="texttd">
                        <input type="text" name="directory" required="" lay-verify="required" placeholder="请输入目录" autocomplete="off" class="layui-input"></td>
                </tr>
                <tr>
                    <td class="labtd">MP4路径：</td>
                    <td class="texttd">
                        <input type="text" name="mp4" required="" lay-verify="required" placeholder="请输入MP4路径" autocomplete="off" class="layui-input"></td>
                    <td class="labtd">HTV路径：</td>
                    <td class="texttd">
                        <input type="text" name="htv" required="" lay-verify="required" placeholder="请输入HTV路径" autocomplete="off" class="layui-input"></td>
                </tr>
                <tr>
                    <td style="height:350px;"></td>
                    <td class="btndetermine">
                        <button class="layui-btn" lay-submit lay-filter="*" onclick="addVideo()" style="padding:0px 18px;">确定</button></td>
                    <td class="btncancel">
                        <button id="btnCancel" class="layui-btn btnShutdown" style="color: white;padding:0px 18px;">取消</button></td>
                    <td style="height:350px;"></td>
                </tr>
            </table>
        </div>

    </div>
    </form>
</body>
</html>
<script src="../js/video.js"></script>
<script src="../js/cebianlan.js"></script>
<script>
    //非空
   
        layui.use('form', function () {
            var form = layui.form;

            //监听提交
            form.on('submit(*)', function (data) {
                layui.msg(JSON.stringify(data.field));
            })
            return false;
        });
    
    

    //实现使用cookie来记住用户名
    //$("#alert_but").click(function () {
    //    $("#Div_alter").css("display", "none");
    //    window.location.reload();
    //})
    //点击退出按钮退出新增界面并刷新数据
    $(function () {
        $("#btnShutdown").click(function () {
            window.location.href = "VideoResourceManager.aspx";
        });
    });
    


    
    //新增视频信息
    function addVideo() {
        //获取文本框的值
        var isbn = $("input:text[name='ISBN']").val();
        var subjects = $("input:text[name='subjects']").val();
        var period = $("input:text[name='period']").val();
        var bookname = $("input:text[name='bookname']").val();
        var grade = $("input:text[name='grade']").val();
        var directory = $("input:text[name='directory']").val();
        var mp4 = $("input:text[name='mp4']").val();
        var htv = $("input:text[name='htv']").val();
        if (isbn == "" || isbn == null || subjects == "" || subjects == null || period == "" || period == null || bookname == "" || bookname == null || grade == "" || grade == null || directory == "" || directory == null || mp4 == "" || mp4 == null || htv == "" || htv == null) {
        } else {
            $.ajax({
                type: "POST",
                dataType: "JSON",
                url: "AjaxHelper/VideoResourceManager.ashx",
                data: { action: "AddVideoRoute", isbn: isbn, subjects: subjects, period: period, bookname: bookname, grade: grade, directory: directory, mp4: mp4,htv:htv },
                success: function (result) {
                    console.log(result);
                    if (result.resultCode == 200) {
                        alert("新增信息成功！");
                        window.location.href = "VideoResourceManager.aspx";
                    }
                },
                error: function () {
                    alert("系统繁忙，请稍后再试！");
                }
            });
        }
           
    }
    
</script>
