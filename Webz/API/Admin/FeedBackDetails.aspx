<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="FeedBackDetails.aspx.cs" Inherits="Webz.Admin.FeedBackDetails" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <meta http-equiv="Content-Type" content="text/html; charset=utf-8" />
    <script src="CC/jquery-3.3.1.js"></script>
    <script src="CC/layui-v2.4.5/layui/layui.js"></script>
    <link href="CC/layui-v2.4.5/layui/css/layui.css" rel="stylesheet" />
    <title></title>
    <style>
        table {
            border-collapse: collapse;
            border: none;
            width: 90%;
            margin: 0 auto;
            text-align: center;
        }

        td {
            padding-top: 10px;
        }

        #text {
            text-align: center;
            color: #1464C7;
            font-size: 20px;
            font-weight: bold;
        }

        button {
            font-size: 12px;
            margin-left: 1%;
            height: 25.5px;
            width: 75px;
            background-color: #0F65CC;
            border: 1px solid #0F65CC;
            border-radius: 5px;
            color: #F2F2F2;
        }
    </style>
</head>
<body>
    <form id="form1" runat="server" class="layui-form" action="">
        <div style="height: 436px; width: 422px; margin: 0 auto;">
            <table>
                <tr>
                    <td id="text">反馈内容</td>
                </tr>
                <tr>
                    <td>
                        <textarea id="txtrNr" name="" required lay-verify="required" disabled="disabled" class="layui-textarea" style="height: 171px; width: 360px; resize:none;border-color:#0F65CC; "></textarea>
                    </td>
                </tr>
                <tr>
                    <td id="text">处理结果</td>
                </tr>
                <tr>
                    <td>
                        <textarea id="txtrProcessing" name="" required lay-verify="required" placeholder="输入处理结果" class="layui-textarea" style="height: 117px; width: 360px; resize:none; border-color:#0F65CC;"></textarea>

                    </td>
                </tr>
                <tr>
                    <td>
                        <button type="button" id="reset" class="layui-btn layui-btn-normal">重置</button>
                        <button lay-submit lay-filter="formDemo" class="layui-btn layui-btn-normal">处理</button>
                        <button lay-submit lay-filter="formDemo2" class="layui-btn layui-btn-normal">反馈上级</button>
                        <button lay-submit id="formDemo3" class="layui-btn layui-btn-normal">忽略</button>
                    </td>
                </tr>
            </table>
        </div>
    </form>
</body>
</html>

<script src="../js/cebianlan.js"></script>
<script>


    <%int id = Convert.ToInt32(Request.QueryString["FeedBackID"]);//获取传过来的id
      //根据ID查到该条数据
      Model.FeedBack fb = new BLL.FeedBackBLL().FeedBackByID(id);
      %>
    var FeedBackNR = "<%=fb.FeedBackNR%>", txtProcessing = "<%=fb.Processing%>";
    var id = "<%=id%>";



    //赋值
    $("#txtrNr").val(FeedBackNR);
    $("#txtrProcessing").val(txtProcessing);

    //重置按钮
    $("#reset").click(function () {
        $("#txtrProcessing").val("");
    });

    //取值
    var username = "<%=Session["username"]%>";

    //提交处理
    layui.use('form', function () {

        var form = layui.form;
        //监听提交
        form.on('submit(formDemo)', function (data) {
            $.ajax({
                type: "POST",
                dataType: "JSON",
                url: "AjaxHelper/VideoResourceManager.ashx",
                data: { action: "Process", processing: $("#txtrProcessing").val(), username: username, FeedBackID: id, stata: "0" },
                success: function (success) {
                    console.log(success);
                    if (success == 1) {
                        alert("反馈信息已处理！");
                        var index = parent.layer.getFrameIndex(window.name);
                        parent.layer.close(index);//关闭当前页
                        parent.location.reload();//刷新父窗口
                    } else {
                        alert("处理信息未成功，请稍后再试！");
                    }
                }
            });
        });
    });

    //提交反馈上级
    layui.use('form', function () {

        var form = layui.form;
        //监听提交
        form.on('submit(formDemo2)', function (data) {
            $.ajax({
                type: "POST",
                dataType: "JSON",
                url: "AjaxHelper/VideoResourceManager.ashx",
                data: { action: "Process", processing: $("#txtrProcessing").val(), username: username, FeedBackID: id, stata: "1" },
                success: function (success) {
                    console.log(success);
                    if (success == 1) {
                        alert("信息已反馈上级处理，请等待！");
                        var index = parent.layer.getFrameIndex(window.name);
                        parent.layer.close(index);//关闭当前页
                        parent.location.reload();//刷新父窗口
                    } else {
                        alert("处理信息未成功，请稍后再试！");
                    }
                }
            });
        });
    });
    //提交反馈上级

    $("#formDemo3").click(function (data) {
        $("#txtrProcessing").val('无效意见！');
        $.ajax({
            type: "POST",
            dataType: "JSON",
            url: "AjaxHelper/VideoResourceManager.ashx",
            data: { action: "Process", processing: $("#txtrProcessing").val(), username: username, FeedBackID: id, stata: "2" },
            success: function (success) {
                console.log(success);
                if (success == 1) {
                    alert("此条信息已被忽略！");
                    var index = parent.layer.getFrameIndex(window.name);
                    parent.layer.close(index);//关闭当前页
                    parent.location.reload();//刷新父窗口
                } else {
                    alert("处理信息未成功，请稍后再试！");
                }
            }
        });
    });
    //layui.use('form', function () {

    //    var form = layui.form;
    //    //监听提交
    //    form.on('submit(formDemo3)', function (data) {
    //        $.ajax({
    //            type: "POST",
    //            dataType: "JSON",
    //            url: "AjaxHelper/VideoResourceManager.ashx",
    //            data: { action: "Process", processing: $("#txtrProcessing").val(), username: username, FeedBackID: id, stata: "2" },
    //            success: function (success) {
    //                console.log(success);
    //                if (success == 1) {
    //                    alert("此条信息已被忽略！");
    //                    var index = parent.layer.getFrameIndex(window.name);
    //                    parent.layer.close(index);//关闭当前页
    //                    parent.location.reload();//刷新父窗口
    //                } else {
    //                    alert("处理信息未成功，请稍后再试！");
    //                }
    //            }
    //        });
    //    });
    //});
</script>
