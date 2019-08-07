<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="CatalogManage.aspx.cs" Inherits="Webz.Admin.DirectoryManage" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <meta http-equiv="Content-Type" content="text/html; charset=utf-8" />
    <script src="CC/jquery-3.3.1.js"></script>
    <script src="CC/layui-v2.4.5/layui/layui.js"></script>
    <link href="CC/layui-v2.4.5/layui/css/layui.css" rel="stylesheet" media="all" />
    <link href="../CSS/AdminVideo.css" rel="stylesheet" />
    <title>教材目录管理</title>
    <style>
        body {
            /*overflow-x: hidden;*/
            overflow:auto;
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

            #tiaojian label {
                color: #fff;
            }

        .chek {
            background-image: url(Img/打勾20.png);
        }

        .cheks {
            background-image: url(Img/打勾20.png);
        }
        .layui-unselect,layui-form-checkbox {
            display:none;
        }
    </style>
</head>
<body>
    <form class="layui-form" action="" runat="server">
        <div>
            <div style="min-height: 600px;">
                <div id="rightcontent">
                    <div>
                        <div style="font-size: 12px;margin-left:12px;">教材目录管理</div>
                        <div id="tiaojian">
                            <div class="layui-inline" style=" width: 100%; padding-top: 3px;">
                                <label class="layui-form-label" style="margin-left:-25px;">ISBN：</label>
                                <input type="text" name="" autocomplete="off" class="layui-input" id="txtISBN" style="margin-left: 0px; width: 215px; float: left">
                                <label class="layui-form-label">课本名称：</label>
                                <input type="text" class="layui-input" autocomplete="off" id="txtBooksName" style="margin-left: 0px; width: 215px; float: left;">
                                <label class="layui-form-label" style="margin-left:-25px;">目录：</label>
                                <input type="text" class="layui-input" autocomplete="off" id="txtCaName" style="margin-left: 0px; width: 215px; float: left;">
                                <button type="button" id="btnFind" class="layui-btn layui-btn-normal" style="margin-right: 5%; float: right; width: 72px;">查询</button>
                            </div>
                        </div>
                        <div style="height: 20px;margin-top: 6px;">
                            <button type="button" id="btnAdd" class="layui-btn layui-btn-normal" style="margin-right: 4%; float: right; width: 72px;">删除</button>
                            <button type="button" id="btnAdds" class="layui-btn layui-btn-normal" style="margin-right: 1%; float: right; width: 72px;margin-left: 0px;">导入</button>
                            <button type="button" id="btnDelete" class="layui-btn layui-btn-normal" style="margin-right: 1%; float: right; width: 72px;">新增</button>
                        </div>
                    </div>
                    <%--<uc1:CC_Table_PageList runat="server" ID="CC_Table_PageList" />--%>
                    <div id="huadong" >
                        <table>
                            <tr style="background-color: #5DA4F9; color: #FFFFFF;">
                                <td>ID</td>
                                <td>ISBN</td>
                                <td>课本名称</td>
                                <td>目录</td>
                                <td>操作</td>
                                <td id="YL" style="width: 40px;">
                                    <input type="hidden" name="chekname" id="His" value="0" />
                                    <span class="cheks"></span>
                                    <input type="checkbox" class="chek" id="quanxuan" />
                                </td>
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
                    var ISBN = $('#txtISBN').val();
                    var BooksName = $('#txtBooksName').val();
                    var CaName = $("#txtCaName").val();
                    layui.use('laypage', function () {
                        laypage = layui.laypage;
                    });
                    $(function () {
                        aaa(PageSize,Pageindex, ISBN, BooksName, CaName);
                        function aaa(PageSize, Pageindex, ISBN, BooksName, CaName) {

                            var data = { type: "CatalogList", Pageindex: Pageindex, PageSize: PageSize, ISBN: ISBN, BooksName: BooksName, CaName: CaName };
                            $.post(url, data, SelectList, "json");
                        }
                        function SelectList(data) {
                            //ISBN = $('#txtISBN').val();
                            //BooksName = $('#txtBooksName').val();
                            //CaName = $("#txtCaName").val();
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
                                    layout: ['limit','count', 'prev', 'page', 'next', 'refresh', 'skip'],
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
                                        aaa(PageSize, Pageindex, ISBN, BooksName, CaName);
                                        //alert(obj.curr);//获取点击的页数

                                    }
                                });
                            }

                            //数据展示
                            for (var i = 0; i < data.list.length; i++) {

                                $("#huadong table").append("<tr><td>" + data.list[i].CaID + "</td>" +
                                    "<td class='tdSN'>" + data.list[i].ISBN + "</td>" +
                                    "<td class='tdAccount'>" + data.list[i].BooksName + "</td>" +
                                    "<td class='tdPassWord'>" + data.list[i].CaName + "</td>" +
                                    "<td class='tdPassWord'><a href='#' onclick='Viewdialog2(" + data.list[i].Id + ")' class='layui-btn layui-btn-sm But_Video'>修改</a></td>" +
                                    "<td>" +
                                        "<input type='hidden' name='chekname' value='0' />" +
                                        "<span class='chek'></span>" +
                                        "<input type='hidden' value='' />" +
                                        "<input type='checkbox' lay-filter='BDing' class='chek' name='chek' id='' value='' V_XId=" + data.list[i].XId + " />" +
                                        "<input type='hidden' value='' id='' />" +
                                        "</td></tr>");
                            }
                            //解除禁用
                            $('#Page').attr("disabled", false);
                            fl = 1;

                            //重新绑定事件
                            $(".chek").click(function () {
                                if ($(this).prev("input").val() == "0") {
                                    $(this).next("input").next("input").attr("checked", true);
                                    $(this).css("background-image", "url(Img/打勾-按下20.png)");
                                    $(this).prev("input").val("1");
                                } else {
                                    $(this).next("input").next("input").attr("checked", false);
                                    $(this).css("background-image", "url(Img/打勾20.png)");
                                    $(this).prev("input").val("0");
                                }

                            });
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
                                    aaa(PageSize, Pageindex, ISBN, BooksName, CaName);
                                }
                            });
                        });
                        $("#btnFind").click(function () {
                            layer.msg("加载中。。。。", {
                                icon: 16,
                                shade: 0.01,
                                time: 99999999
                            });
                            ISBN = $('#txtISBN').val();
                            BooksName = $('#txtBooksName').val();
                            CaName = $("#txtCaName").val();
                            fl = 0;
                            aaa(PageSize, Pageindex, ISBN, BooksName, CaName);
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

    //点击修改按钮跳转修改界面
    function Viewdialog2(data) {
        window.location.replace("AddVideo.aspx?CaID="+data);
    }


    //多选删除勾选框
    $(".cheks").click(function () {
        if ($("#His").val() == 0) {
            $(this).attr("checked", true);
            $(this).css("background-image", "url(Img/打勾-按下20.png)");
            $("input[name=\"chek\"]").attr("checked", true);
            $(".chek").css("background-image", "url(Img/打勾-按下20.png)");
            $("input[name=\"chekname\"]").val("1");
        } else {
            $(this).attr("checked", false);
            $(this).css("background-image", "url(Img/打勾20.png)");
            $("input[name=\"chek\"]").attr("checked", false);
            $(".chek").css("background-image", "url(Img/打勾20.png)");
            $("input[name=\"chekname\"]").val("0");
        }

    });
</script>
