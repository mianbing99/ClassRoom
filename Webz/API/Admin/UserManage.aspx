<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="UserManage.aspx.cs" Inherits="Webz.Admin.UserManage" %>

<!DOCTYPE html>
<%@ Register Assembly="AspNetPager" Namespace="Wuqi.Webdiyer" TagPrefix="webdiyer" %>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <meta http-equiv="Content-Type" content="text/html; charset=utf-8" />
    <script src="CC/jquery-3.3.1.js"></script>
    <script src="CC/layui-v2.4.5/layui/layui.js"></script>
    <link href="CC/layui-v2.4.5/layui/css/layui.css" rel="stylesheet" media="all" />
    <link href="../CSS/AdminVideo.css" rel="stylesheet" />
    <title>用户管理</title>
    <style>
        body {
            /*overflow-x: hidden;*/
            overflow: auto;
            width: 100%;
            min-width: 1129px;
            max-width: 100%;
            height: 100%;
        }

        #tiaojian {
            background-color: #5DA4F9;
            height: 30px;
            line-height: 30px;
            width: 100%;
            position: relative;
            margin-left: 1%;
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

        .layui-unselect, layui-form-checkbox {
            display: none;
        }
    </style>
</head>
<body>
    <form class="layui-form" action="" runat="server">
        <div>
            <div style="min-height: 600px;">
                <div id="rightcontent">
                    <div>
                        <div style="font-size: 12px; margin-left: 12px;">教材目录管理</div>
                        <div id="tiaojian">
                            <div class="layui-inline" style="width: 100%; padding-top: 3px;">
                                <label class="layui-form-label" style="margin-left: -25px;">用户名：</label>
                                <input type="text" name="" autocomplete="off" class="layui-input" id="txtUser" style="margin-left: 0px; width: 215px; float: left" />
                                <label class="layui-form-label">角色：</label>
                                <input type="text" class="layui-input" autocomplete="off" id="txtRoles" style="margin-left: 0px; width: 215px; float: left;" />
                                <button type="button" id="btnAdd" class="layui-btn layui-btn-normal" style="margin-right: 32%; float: right; width: 72px;">新增</button>
                                <button type="button" id="btnFind" class="layui-btn layui-btn-normal" style="margin-right: 2%; float: right; width: 72px;">查询</button>
                            </div>
                        </div>
                    </div>
                    <%--<uc1:CC_Table_PageList runat="server" ID="CC_Table_PageList" />--%>
                    <div id="huadong">
                        <table>
                            <tr style="background-color: #5DA4F9; color: #FFFFFF;">
                                <td>ID</td>
                                <td>用户名</td>
                                <td>角色</td>
                                <td>操作</td>
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
                    var laypage = null;
                    var url = "AjaxHelper/Ajax.ashx";
                    var User = $('#txtUser').val();
                    var Roles = $('#txtRoles').val();
                    layui.use('laypage', function () {
                        laypage = layui.laypage;
                    });
                    $(function () {
                        load();
                    });
                    function load() {
                        $(function () {
                            aaa(PageSize, Pageindex, User, Roles);
                            function aaa(PageSize, Pageindex, User, Roles) {

                                var data = { type: "UserManageList", Pageindex: Pageindex, PageSize: PageSize, User: User, Roles: Roles };
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
                                            aaa(PageSize, Pageindex, User, Roles);
                                            //alert(obj.curr);//获取点击的页数

                                        }
                                    });
                                }

                                //数据展示
                                for (var i = 0; i < data.list.length; i++) {

                                    $("#huadong table").append("<tr><td>" + data.list[i].AdminID + "</td>" +
                                        "<td class='tdSN'>" + data.list[i].AdminName + "</td>" +
                                        "<td class='tdAccount'>" + data.list[i].RoleName + "</td>" +
                                        "<td class='tdPassWord'><a href='#' onclick='GetByIDList(" + data.list[i].AdminID + ")' class='layui-btn layui-btn-sm But_Video'>查看</a>" +
                                        "<a href='#' onclick='UpdateByID(" + data.list[i].AdminID + ")' class='layui-btn layui-btn-sm But_Video'>修改</a>" +
                                        "<a href='#' onclick='DeleteByID(" + data.list[i].AdminID + ")' class='layui-btn layui-btn-sm But_Video'>删除</a></td>" +
                                        "</tr>");
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
                                        aaa(PageSize, Pageindex, User, Roles);
                                    }
                                });
                            });
                            $("#btnFind").click(function () {
                                layer.msg("加载中。。。。", {
                                    icon: 16,
                                    shade: 0.01,
                                    time: 99999999
                                });
                                User = $('#txtUser').val();
                                Roles = $('#txtRoles').val();
                                fl = 0;
                                aaa(PageSize, Pageindex, User, Roles);
                            });
                        });
                    };

                    function DeleteByID(id) {
                        layer.open({
                            content: '确认删除此条信息吗？'
                            , btn: ['确认', '取消']
                            , yes: function (index, layero) {
                                //按钮【按钮一】的回调
                                $.post('AjaxHelper/Ajax.ashx', { type: "AdminDeleteByID", AdminID: id }, function (msg) {
                                    if (msg) {

                                        layer.open({
                                            content: '删除成功！'
                                    , time: 5000
                                           , yes: function (index, layero) {
                                               //按钮【按钮一】的回调
                                               layer.close(index);
                                               load();
                                           }
                                        });
                                    } else {
                                        layer.open({
                                            content: '删除失败，请稍后再试！'
                                    , time: 5000
                                        });
                                    }
                                });
                            }
                            , btn2: function (index, layero) {
                                //按钮【按钮二】的回调

                                //return false 开启该代码可禁止点击该按钮关闭
                            }
                        , cancel: function () {
                            //右上角关闭回调

                            //return false 开启该代码可禁止点击该按钮关闭
                        }
                        });
                    }
                </script>
            </div>
        </div>
    </form>
</body>
</html>

<script src="../Scripts/jquery-1.8.2.min.js"></script>
<script>
    $('#btnAdd').click(function () {
        layer.open({
            type: 2,
            title: '查看处理',
            content: 'UserManageChange.aspx'//这里content是一个普通的String
            , area: ['450px', '500px']
            , resize: false
        });
    });
</script>
