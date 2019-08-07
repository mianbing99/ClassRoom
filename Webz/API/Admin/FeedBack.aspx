<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="FeedBack.aspx.cs" Inherits="Webz.Admin.FeedBack" %>


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
    <title>意见反馈</title>
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
            height: 30px;
            line-height: 30px;
            width: 100%;
            position: relative;
            margin-left:1%;
        }
        #tiaojian select {
            padding-left: 1%;
            font-size: 13px;
            text-align: center;
            -moz-appearance: none;
            -webkit-appearance: none;
            padding-right: 14px;
            background: url(Admin\Img\下拉框课本名称未展开时.png) no-repeat scroll right center transparent;
        }
        .SelSuName {
            width:180px;
        }
        #tiaojian select::-ms-expand， {
            display: none;
        }

    </style>
</head>
<body>
    <form  action="" runat="server">
        <div>
            <div style="min-height: 600px;">
                <div id="rightcontent">
                    <div>
                        <div style="font-size: 12px; margin-left:12px">意见反馈</div>

                        <div id="tiaojian" >
                            <div  style="width:100%;">
                                <label class="layui-form-label" style="margin-top:2px;">反馈日期：</label>
                                <input type="text" class="layui-input" placeholder="起始日期" id="Startdate" style="margin-left: 0px; width: 215px; float: left;margin-top:4px;height:21px;">
                                <label class="layui-form-label" style="width: 10px;margin-top:2px;">到</label>
                                <input type="text" class="layui-input" placeholder="结束日期" id="Enddate" style="margin-left: 5px; width: 215px; float: left;margin-top:4px;height:21px;">
                                <%--<label class="layui-form-label" style="margin-left:0px;">处理状态：</label>--%>
                                <select class="SelSuName" id="Stata" style="background-image: url(Img/下拉框课本名称未展开时.png);background-size: cover;" >
                                    <option value="">请选择处理状态</option>
                                    <option value="0">已处理</option>
                                    <option value="1">未处理</option>
                                    <option value="2">反馈上级处理</option>
                                    <option value="2">无效意见</option>
                                    <input type="hidden" value="0" />
                                </select>
                                <button type="button" id="btnFind" class="layui-btn layui-btn-normal" style="margin-right:5%;float:right;width:72px;margin-top: 3px;">查询</button>
                            </div>
                            <%--<div class="layui-input-block">
                                <select name="city" lay-verify="" id="Stata" >
                                    <option value="">请选择处理状态</option>
                                    <option value="0">已处理</option>
                                    <option value="1">未处理</option>
                                    <option value="2">反馈上级处理</option>
                                </select>
                            </div>--%>
                        </div>
                    </div>
                    <%--<uc1:CC_Table_PageList runat="server" ID="CC_Table_PageList" />--%>
                    <div id="huadong">
                        <table>
                            <tr style="background-color: #5DA4F9; color: #FFFFFF;">
                                <td>ID</td>
                                <td>学段</td>
                                <td>账号（手机号）</td>
                                <td>反馈内容</td>
                                <td>反馈日期</td>
                                <td>处理结果</td>
                                <td>处理人</td>
                                <td>状态</td>
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
                    //var TbnName, GaID, SubI, PrID, PP, dataExPageList;
                    var laypage = null;
                    var form = null;
                    var url = "AjaxHelper/Ajax.ashx";
                    var CardID;
                    var Startdate = $('#Startdate').val();
                    var Enddate = $('#Enddate').val();
                    var Stata = $("#Stata option:selected").text();
                    layui.use('laypage', function () {
                        laypage = layui.laypage;
                    });
                    $(function () {
                        aaa(Pageindex, Startdate, Enddate, Stata);
                        function aaa(Pageindex,Startdate,Enddate,Stata) {

                            var data = { type: "FeedBackList", Pageindex: Pageindex, PageSize: PageSize, Startdate: Startdate, Enddate: Enddate, Stata: Stata };
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
                                        aaa(Pageindex, Startdate, Enddate, Stata);
                                        //alert(obj.curr);//获取点击的页数

                                    }
                                });
                            }
                            //数据展示
                            for (var i = 0; i < data.list.length; i++) {

                                $("#huadong table").append("<tr><td>" + data.list[i].FeedBackID + "</td>" +
                                    "<td class='tdSN'>" + data.list[i].Grade + "</td>" +
                                    "<td class='tdAccount'>" + data.list[i].Phone + "</td>" +
                                    "<td class='tdPassWord'><a href='#' onclick='Viewdialog(" + data.list[i].FeedBackID + ")' class='layui-btn layui-btn-sm But_Video'>查看详情</a></td>" +
                                    "<td class='tdCreateTime'>" + data.list[i].FeedBackDate + "</td>" +
                                    "<td class='tdPassWord'><a href='#' onclick='Viewdialog2(" + data.list[i].FeedBackID + ")' class='layui-btn layui-btn-sm But_Video'>查看处理</a></td>" +
                                    "<td class='tdCreateTime'>" + data.list[i].ProcessingName + "</td>" +
                                    "<td class='tdOutTime'>" + data.list[i].Stata + "</td> ");
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
                                    aaa(Pageindex, Startdate, Enddate, Stata);
                                }
                            });
                        });
                        $("#btnFind").click(function () {
                            layer.msg("加载中。。。。", {
                                icon: 16,
                                shade: 0.01,
                                time:99999999
                            });
                            Startdate = $('#Startdate').val();
                            Enddate = $('#Enddate').val();
                            Stata = $("#Stata option:selected").text();
                            fl = 0;
                            aaa(Pageindex, Startdate, Enddate, Stata);
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

    //查看详情界面
    function Viewdialog(data) {
        layer.open({
            type: 2,
            title:'查看处理',
            content: 'FeedBackDetails.aspx?FeedBackID=' + data //这里content是一个普通的String
            , area: ['450px', '500px']
            ,resize:false
        });
    }
    function Viewdialog2(data) {
        layer.open({
            type: 2,
            title:'反馈处理',
            content: 'FeedbackResult.aspx?FeedBackID=' + data //这里content是一个普通的String
            , area: ['450px', '320px']
            , resize: false
        });
    }

    //日期选择框
    layui.use('laydate', function () {
        var laydate = layui.laydate;

        //执行一个laydate实例
        laydate.render({
            elem: '#Startdate', //指定元素
        });
        laydate.render({
            elem: '#Enddate', //指定元素
        });
    });
    $("input[type=\"button\"]").mousedown(function () {
        $(this).css("background-color", "#044694");
    })
    $("input[type=\"button\"]").mouseup(function () {
        $(this).css("background-color", "#0F65CC");
    })
    $("select").mousedown(function () {
        var id = $(this).attr("id");
        var hi = $(this).next("input");
        if (hi.val() == "1") {
            if (id = "Select1") {
                $(this).css("background-image", "url(Img/下拉框课本名称展开时按下.png)");
            } else {
                $(this).css("background-image", "url(Img/下拉框课本名称展开时按下.png)");
            }
        } else {
            if (id = "Select1") {
                $(this).css("background-image", "url(Img/下拉框课本名称未展开时按下.png)");
            } else {
                $(this).css("background-image", "url(Img/下拉框课本名称未展开时按下.png)");
            }
        }

    })
    $("select").mouseup(function () {
        var id = $(this).attr("id");
        var hi = $(this).next("input");
        if (hi.val() == "1") {
            if (id = "Select1") {
                $(this).css("background-image", "url(Img/下拉框课本名称未展开时.png)");
            } else {
                $(this).css("background-image", "url(Img/下拉框课本名称未展开时.png)");
            }
            hi.val("0");
        } else {
            if (id = "Select1") {
                $(this).css("background-image", "url(Img/下拉框课本名称展开时.png)");
            } else {
                $(this).css("background-image", "url(Img/下拉框课本名称展开时.png)");
            }
            hi.val("1");
        }

    })
</script>
