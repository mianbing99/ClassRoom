<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="EnrollStatistical.aspx.cs" Inherits="Webz.Admin.EnrollStatistical" %>


<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <meta http-equiv="Content-Type" content="text/html; charset=utf-8" />
    <script src="CC/jquery-3.3.1.js"></script>
    <script src="CC/layui-v2.4.5/layui/layui.js"></script>
    <link href="CC/layui-v2.4.5/layui/css/layui.css" rel="stylesheet" media="all" />
    <link href="../CSS/cebianlan.css" rel="stylesheet" />
    <link href="../CSS/content.css" rel="stylesheet" />
    <link href="../CSS/AdminVideo.css" rel="stylesheet" />
    <title>注册统计</title>
    <style>
        body {
            /*overflow-x: hidden;*/
            width:100%;
            min-width:1129px;
            max-width:100%;
            height:100%;
        }
        #tiaojian {
            background-color: #5DA4F9;
            height: 60px;
            line-height: 30px;
            width: 100%;
            position: relative;
            margin-left:1%;
        }
    </style>
</head>
<body>
    <form id="form" runat="server">
        <div>
            <div style="min-height: 600px;">
                <div id="rightcontent">
                    <div>
                        <div style="font-size: 12px;margin-left:12px;">用户统计>注册统计</div>
                        <div id="tiaojian">
                            <label class="layui-form-label" style="margin-top:2px;">注册日期：</label>
                                <input type="text" class="layui-input" autocomplete="off" placeholder="注册日期" id="Registereddate" style="margin-left: 0px; width: 215px; float: left;margin-top:4px;height:21px;">
                                <label class="layui-form-label" style="margin-top:2px;">激活日期：</label>
                                <input type="text" class="layui-input" autocomplete="off" placeholder="激活日期" id="Activationdate" style="margin-left: 5px; width: 215px; float: left;margin-top:4px;height:21px;">
                            <label class="layui-form-label" style="margin-top:2px;">结束日期：</label>
                                <input type="text" class="layui-input" autocomplete="off" placeholder="结束日期" id="Outdate" style="margin-left: 0px; width: 215px; float: left;margin-top:4px;height:21px;">
                            <button type="button" id="btnReset" class="layui-btn layui-btn-normal" style="margin-right: 8%; float: right; width: 72px;margin-top: 3px;">重置</button>
                            <br />
                            <label class="layui-form-label" style="margin-left:-705px;">手机号：</label>
                                <input type="text" name="" autocomplete="off" placeholder="请输入手机号" oninput = "value=value.replace(/[^\d]/g,'')" class="layui-input" id="txtPhone" style="margin-left: -615px; width: 215px; float: left">
                                <label class="layui-form-label" style="margin-left:-401px;">VIP账号：</label>
                                <input type="text" class="layui-input" autocomplete="off" placeholder="请输入VIP账号" id="txtAccount" style="margin-left: -305px; width: 215px; float: left;">
                                <label class="layui-form-label" style="margin-left:-90px;">VIP密码：</label>
                                <input type="text" class="layui-input" autocomplete="off" id="txtPwd" placeholder="请输入VIP密码" style="margin-left: 0px; width: 215px; float: left;">
                                <button type="button" id="btnFind" class="layui-btn layui-btn-normal" style="margin-right: 8%; float: right; width: 72px;">查询</button>
                        </div>
                        <div style="margin-top: 0%; margin-left: 90%;">
                            <button type="button" id="Button4" style="margin-top: 5px;">导出统计表</button>
                        </div>
                    </div>
                    <%--<uc1:CC_Table_PageList runat="server" ID="CC_Table_PageList" />--%>
                    <div id="huadong">
                        <table>
                            <tr style="background-color: #5DA4F9; color: #FFFFFF;">
                                <td>ID</td>
                                <td>手机号</td>
                                <td>VIP账号</td>
                                <td>VIP密码</td>
                                <td>SN</td>
                                <td>注册日期</td>
                                <td>激活日期</td>
                                <td>结束日期</td>
                            </tr>
                        </table>
                    </div>
                    <div id="Page">
                    </div>
                </div>
                <script src="CC/layui-v2.4.5/layui/layui.all.js" charset="utf-8"></script>
                <script>
                   
                    $.ajaxSettings.async = true;
                    var fl = 0;
                    var count = 0;
                    var Pageindex = 1;
                    var PageSize = 10;
                    var Registereddate, Activationdate, Outdate, txtPhone, txtAccount, txtPwd;
                    var laypage = null;
                    var form = null;
                    var url = "AjaxHelper/Ajax.ashx";
                    Registereddate = $('#Registereddate').val();
                    Activationdate = $('#Activationdate').val();
                    Outdate = $('#Outdate').val();
                    Phone = $('#txtPhone').val();
                    Account = $('#txtAccount').val();
                    Pwd = $('#txtPwd').val();
                    layui.use('laypage', function () {
                        laypage = layui.laypage;
                    });
                    $(function () {
                        aaa(Pageindex,Registereddate,Activationdate,Outdate,Phone,Account,Pwd);
                        function aaa(Pageindex, Registereddate, Activationdate, Outdate, Phone, Account, Pwd) {

                            var data = { type: "CardList", Pageindex: Pageindex, PageSize: PageSize, Registereddate: Registereddate, Activationdate: Activationdate, Outdate: Outdate, Phone: Phone, Account: Account, Pwd: Pwd };
                            $.post(url, data, SelectList, "json");

                        }
                        function SelectList(data) {

                            $("#huadong table tr:gt(0)").remove();
                            //获得总条数
                            count = data.Count;
                            //存当前页数据
                            dataExPageList = data;
                            //重新绑定分页
                            if (fl != 1) {
                                laypage.render({
                                    elem: 'Page' //注意，这里的 test1 是 ID，不用加 # 号
                          , count: count, //数据总数，从服务端得到
                                    limit: PageSize,
                                    layout: ['limit', 'count', 'prev', 'page', 'next', 'refresh', 'skip'],
                                    jump: function (obj) {
                                        layer.msg('加载中。。。。', {
                                            icon: 16
                                , shade: 0.01
                                , time: 99999999
                                        });
                                        //obj包含了当前分页的所有参数，比如：
                                        //加载禁用
                                        $('#Page').attr("disabled", true);
                                        Pageindex = obj.curr;
                                        PageSize = obj.limit;
                                        aaa(Pageindex, Registereddate, Activationdate, Outdate, Phone, Account, Pwd);
                                        //alert(obj.curr);//获取点击的页数

                                    }
                                });
                            }

                            //数据展示
                            for (var i = 0; i < data.list.length; i++) {

                                $("#huadong table").append("<tr><td>" + data.list[i].Userid + "</td>" +
                                    "<td class='tdPhone'>" + data.list[i].Phone + "</td>" +
                                    "<td class='tdAccount'>" + data.list[i].Account + "</td>" +
                                    "<td class='tdPassWord'>" + data.list[i].PassWord + "</td>" +
                                    "<td class='tdSN'>" + data.list[i].SN + "</td>" +
                                    "<td class='tdRegisterTime'>" + data.list[i].RegisterTime + "</td>" +
                                    "<td class='tdActivationTime'>" + data.list[i].ActivationTime + "</td>" +
                                    "<td class='tdOutTime'>" + data.list[i].OutTime + "</td> ");
                            }
                            //解除禁用
                            $('#Page').attr("disabled", false);
                            fl = 1;
                            layer.closeAll();
                        }

                        layui.use('form', function () {
                            form = layui.form;
                            form.on('radio(chetiaojian)', function (data) {



                                if (PP != data.value) {
                                    layer.msg('加载中。。。。', {
                                        icon: 16
                              , shade: 0.01
                              , time: 99999999
                                    });
                                    fl = 0;
                                    PP = data.value;
                                    aaa(Pageindex, TbnName, GaID, SubI, PrID, PP, Judge);
                                }
                            });
                        });
                        //导出当前页数据
                        $("#Button4").click(function () {
                            layer.msg('正在导出当前页', {
                                icon: 16
                                , shade: 0.01
                                , time: 99999999
                            });

                            var data = { type: "CardExport", Pageindex: Pageindex, PageSize: PageSize, Registereddate: Registereddate, Activationdate: Activationdate, Outdate: Outdate, Phone: Phone, Account: Account, Pwd: Pwd }
                            $.post(url, data, CurrentPageExport);
                        });
                        //导出回调
                        function CurrentPageExport(data) {
                            layer.closeAll();
                            layer.msg(data);
                        }

                        //条件查询
                        $("#btnFind").click(function () {
                            layer.msg("加载中。。。。", {
                                icon: 16,
                                shade: 0.01,
                                time: 99999999
                            });
                            Registereddate = $('#Registereddate').val();
                            Activationdate = $('#Activationdate').val();
                            Outdate = $('#Outdate').val();
                            Phone = $('#txtPhone').val();
                            Account = $('#txtAccount').val();
                            Pwd = $('#txtPwd').val();
                            fl = 0;
                            aaa(Pageindex, Registereddate, Activationdate, Outdate, Phone, Account, Pwd);
                        });

                        //重置条件
                        $("#btnReset").click(function () {
                            $('#Registereddate').val('');
                            $('#Activationdate').val('') ;
                            $('#Outdate').val('') ;
                            $('#txtPhone').val('') ;
                            $('#txtAccount').val('') ;
                            $('#txtPwd').val('');
                        });
                    });
                </script>
            </div>
        </div>
    </form>
</body>
</html>
<script src="../js/video.js"></script>
<script src="../js/cebianlan.js"></script>
<script>
    //实现使用cookie来记住用户名
    $("#alert_but").click(function () {
        $("#Div_alter").css("display", "none");
        window.location.reload();
    })
    //日期选择框
    layui.use('laydate', function () {
        var laydate = layui.laydate;

        //执行一个laydate实例
        laydate.render({
            elem: '#Registereddate', //指定元素
        });
        laydate.render({
            elem: '#Activationdate', //指定元素
        });
        laydate.render({
            elem: '#Outdate', //指定元素
        });
    });
</script>
