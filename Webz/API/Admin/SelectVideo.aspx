<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="SelectsVideo.aspx.cs" Inherits="Webz.Admin.SelectsVideo" %>

<%@ Register Assembly="AspNetPager" Namespace="Wuqi.Webdiyer" TagPrefix="webdiyer" %>
<%@ Register Src="~/Admin/Views/CC_GradeList.ascx" TagPrefix="uc1" TagName="CC_GradeList" %>
<%@ Register Src="~/Admin/Views/CC_SubjectList.ascx" TagPrefix="uc1" TagName="CC_SubjectList" %>
<%@ Register Src="~/Admin/Views/CC_PublishingList.ascx" TagPrefix="uc1" TagName="CC_PublishingList" %>
<%@ Register Src="~/Admin/Views/CC_Table_PageList.ascx" TagPrefix="uc1" TagName="CC_Table_PageList" %>







<%--<!DOCTYPE html PUBLIC"-//W3C//DTD XHTML 1.0 Transitional//EN" "http://www.w3.org/TR/xhtml1/DTD/xhtml1-transitional.dtd">

<html xmlns="http://www.w3.org/1999/xhtml">兼容--%>
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
    <title>模糊匹配</title>
    <style>
        body {
            /*overflow-x: hidden;*/
            width:100%;
            min-width:1129px;
            max-width:100%;
            height:100%;
        }
        .But_quanxuan {
            font-size: 12px;
            width: 75px;
            margin-left: 1%;
            height: 25.5px;
            background-color: #0F65CC;
            border: 1px solid #0F65CC;
            border-radius: 5px;
            color: #F2F2F2;
        }

        #Div_pipei select {
            background-image: url(Img/下拉框课本名称未展开时.png);
            background-size: cover;
        }

        .chek {
            background-image: url(Img/打勾20.png);
        }

        .cheks {
            background-image: url(Img/打勾20.png);
        }

        .rechek {
            background-image: url(Img/打勾白色16.png);
        }

        #Div_alter {
            background-image: url(Img/提示信息栏478x314.png);
        }

        #alert_but {
            background-image: url(Img/确定.png);
        }

        #txyiwh {
            display: inline-block;
            width: 20px;
            height: 30px;
            background: url(Admin\Img\打勾白色16.png) no-repeat;
            line-height: 30px;
            position: relative;
            left: 2%;
            top: 17px;
        }

        #txyiwh {
            background-image: url(Img/打勾白色16.png);
        }

        #txerwh {
            display: inline-block;
            width: 20px;
            height: 30px;
            background: url(Admin\Img\打勾白色16.png) no-repeat;
            line-height: 30px;
            position: relative;
            left: 2%;
            top: 17px;
        }

        #txerwh {
            background-image: url(Img/打勾白色16.png);
        }

        #txsanwh {
            display: inline-block;
            width: 20px;
            height: 30px;
            background: url(Admin\Img\打勾白色16.png) no-repeat;
            line-height: 30px;
            position: relative;
            left: 2%;
            top: 17px;
        }

        #txsanwh {
            background-image: url(Img/打勾白色16.png);
        }

        #Button3 {
            left: 7px;
            top: -1px;
        }
    </style>
</head>
<body>
    <form id="form1" runat="server">
        <div>
            <div style="min-height: 600px;">
                <div id="rightcontent">
                    <div>
                        <div style="font-size: 12px;">视频匹配>模糊匹配</div>
                        <div id="Div_pipei" style="background-color: #5DA4F9; height: 30px; line-height: 30px; width: 100%; position: relative; left: 1%;">
                            <%-- //年级--%>
                            <uc1:CC_GradeList runat="server" ID="CC_GradeList" />
                            <%--科目--%>
                            <uc1:CC_SubjectList runat="server" ID="CC_SubjectList" />
                            <%--出版社--%>
                            <uc1:CC_PublishingList runat="server" ID="CC_PublishingList" />
                            <%--<asp:DropDownList ID="DropDownList3" CssClass="SelSuName" runat="server"></asp:DropDownList>
                            <input type="hidden" value="0" />
                            <asp:DropDownList ID="DropDownList1" CssClass="Select1" runat="server"></asp:DropDownList>
                            <input type="hidden" value="0" />--%>
                            <input type="text" value="" id="TxtName" runat="server" placeholder="这里输入查找的课文名称" />
                            <button type="button" style="width: 80px" id="Button3" class="layui-btn layui-btn-normal">查找</button>
                            <%--<asp:Button ID="Button3" runat="server" Width="80px"   Text="查找" OnClick="Button3_Click" />--%>
                        </div>
                        <div style="margin-top: 0%;margin-bottom: -8px;">



                            <span style="margin-left: 50%;" class="layui-form">
                                <span class="chespan">
                                    <input type="hidden" name="chekname" value="1" />

                                    <input type="radio" lay-filter="chetiaojian" id="CheckBox3" name="chetiaojian" runat="server" checked="true" value="0" />
                                    <span style=" font-size: 13px;">显示全部</span>
                                </span>
                                <span class="chespan">
                                    <input type="hidden" name="chekname" value="0" />

                                    <input type="radio" lay-filter="chetiaojian" id="CheckBox1" name="chetiaojian" runat="server" value="1" />
                                    <span style="padding-left: 11px; font-size: 13px;">已匹配</span>
                                </span>
                                <span class="chespan">
                                    <input type="hidden" name="chekname" value="0" />

                                    <input type="radio" lay-filter="chetiaojian" id="CheckBox2" name="chetiaojian" runat="server" value="2" />
                                    <span style="padding-left: 11px; font-size: 13px;">未匹配</span>
                                </span>

                            </span>




                            <button type="button" id="Button4" class="layui-btn layui-btn-sm">导出当前页</button>
                            <button type="button" id="Button1" class="layui-btn layui-btn-sm">导出全部</button>
                            <%--<asp:Button ID="Button4" runat="server" Text="  导出当前页  " OnClick="Button4_Click" />
                            <asp:Button ID="Button1" runat="server" Text="  导出全部  " OnClick="Button1_Click" />--%>
                            <%-- <input type="button" class="But_quanxuan" id="bangding" value="批量绑定" onclick="" V_M="0" />

                            <input type="button" class="But_quanxuan" id="jiebang" value="批量解绑" V_M="1" />--%>
                        </div>
                    </div>
                    <uc1:CC_Table_PageList runat="server" ID="CC_Table_PageList" />
                    <%--<div id="huadong" style="height: 461px">
                        <table>
                            <tr style="background-color: #5DA4F9; color: #FFFFFF">
                                <td>序号</td>
                                <td>课文名称</td>
                                <td>目录</td>
                                <td>已匹配路径</td>
                                <td>未匹配路径</td>
                                <td>预览</td>
                                <td style="width: 40px;">
                                    <input type="hidden" name="chekname" id="His" value="0" />
                                    <span class="cheks"></span>
                                    <input type="checkbox" class="chek" id="quanxuan" />
                                </td>
                            </tr>
                            <asp:Repeater ID="Repeater1" runat="server">
                                <ItemTemplate>
                                    <tr>
                                        <td><%#Eval("Nub")%>  </td>
                                        <td class="tdname"><%#Eval("BooksName") %></td>
                                        <td class="tdcaname"><%#Eval("CaName") %></td>
                                        <td class="tdpath"><%#Eval("mp4") %></td>
                                        <td class="tdpath"><%#Eval("testmp4") %></td>
                                        <td>
                                            <input class="But_Video" type="button" name="<%#Eval("mp4") %>" id="<%#Eval("testmp4") %>" value="预览" /></td>
                                        <td>
                                            <input type="hidden" name="chekname" value="0" />
                                            <span class="chek"></span>
                                            <input type="hidden" value="<%#Eval("mp4") %>" />
                                            <input type="checkbox" checked="" class="chek" name="chek" id="<%#Eval("caid") %>" value="<%#Eval("testmp4") %>" />
                                            <input type="hidden" value="<%#Eval("CaName") %>" id="<%#Eval("Nub") %>" />
                                        </td>
                                    </tr>
                                </ItemTemplate>
                            </asp:Repeater>
                        </table>
                    </div>--%>
                    <div id="Page">
                    </div>
                </div>
                <script src="CC/layui-v2.4.5/layui/layui.all.js" charset="utf-8"></script>
                <script>
                    $("#YL").hide();
                    $("#MH").html("模糊匹配");
                    //@TbnName varchar(50)='%',--书名
                    //@GaID varchar(50)='%',--年级ID
                    //@SubID varchar(50)='%',--科目ID
                    //@PrID varchar(50)='%',--出版社ID
                    //@PP int--判断是哪种匹配方式
                    var MP4Url = "";
                    $.ajaxSettings.async = true;
                    var fl = 0;
                    var count = 0;
                    var Pageindex = 1;
                    var PageSize = 10;
                    var TbnName, GaID, SubI, PrID, PP, dataExPageList;
                    var PPd, Judge;
                    var laypage = null;
                    var form = null;
                    var url = "AjaxHelper/Ajax.ashx";
                    layui.use('laypage', function () {
                        laypage = layui.laypage;
                    });
                    $(function () {
                        aaa(Pageindex, TbnName, GaID, SubI, PrID, PP, Judge);
                        function aaa(Pageindex, TbnName, GaID, SubI, PrID, PP, Judge) {

                            var data = { type: "AllList", Pageindex: Pageindex, PageSize: PageSize, TbnName: TbnName, GaID: GaID, SubI: SubI, PrID: PrID, PP: PP, Judge: Judge };
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
                                        aaa(Pageindex, TbnName, GaID, SubI, PrID, PP, Judge);
                                        //alert(obj.curr);//获取点击的页数

                                    }
                                });
                            }

                            //数据展示
                            for (var i = 0; i < data.list.length; i++) {

                                $("#huadong table").append("<tr><td>" + data.list[i].num + "</td>" +
                                    "<td class='tdname'>" + data.list[i].BooksName + "</td>" +
                                    "<td class='tdcaname'>" + data.list[i].ViName + "</td>" +
                                    "<td class='tdpath'>" + data.list[i].匹配 + "</td>" +
                                    "<td class='tdpath'>" + data.list[i].未匹配 + "</td>" +
                                    "<td><a href='Video.aspx?id=" + data.list[i].TempID + "' class='layui-btn layui-btn-sm But_Video'>匹配</a></td> ");
                            }
                            //解除禁用
                            $('#Page').attr("disabled", false);
                            fl = 1;

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

                        $("#Button3").click(function () {
                            layer.msg('加载中。。。。', {
                                icon: 16
                                , shade: 0.01
                                , time: 99999999
                            });
                            GaID = $(".nianji").val();
                            PrID = $(".Select1").val();
                            SubI = $(".SelSuName").val();
                            TbnName = $("#TxtName").val();

                            if (TbnName == null || TbnName == "" || TbnName == " ") {
                                TbnName = "%";
                            }
                            fl = 0;
                            aaa(Pageindex, TbnName, GaID, SubI, PrID, PP, Judge);

                        });
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

                            var data = { type: "CurrentPageExport", Pageindex: Pageindex, PageSize: PageSize, TbnName: TbnName, GaID: GaID, SubI: SubI, PrID: PrID, PP: PP, Judge: Judge }
                            $.post(url, data, CurrentPageExport);
                        });
                        //导出回调
                        function CurrentPageExport(data) {
                            layer.closeAll();
                            layer.msg(data);
                        }
                        //导出所有
                        $("#Button1").click(function () {
                            layer.msg('正在导出所有匹配数据(数据量较大,请耐心等待)', {
                                icon: 16
                                , shade: 0.01
                                , time: 99999999
                            });
                            var data = { type: "AllEX" }
                            $.post(url, data, AllEX);
                        });
                        //导出所有回调
                        function AllEX(data) {
                            layer.closeAll();
                            layer.msg(data);
                        }
                        ////绑定0,解绑1
                        
                    });
                </script>
            </div>
            <%--<webdiyer:AspNetPager CssClass="paginator" PageSize="10" UrlPaging="true"
                    runat="server" ID="pgServer" Width="70%" HorizontalAlign="Center"
                    CustomInfoHTML="共%PageCount%页记录<span>|</span>每页%PageSize%条<span>|</span>当前第%CurrentPageIndex%页"
                    FirstPageText="首页" LastPageText="尾页" NextPageText="下一页" PrevPageText="上一页" NumricButtonCount="1" PageIndexBoxType="DropDownList" TextBeforePageIndexBox="转到: "
                    ShowCustomInfoSection="Left" Height="18px">
                </webdiyer:AspNetPager>--%>
        </div>
        <div class="Video">
            <div id="Video_top" style="border-top: 5px solid #5AA6F4; border-left: 5px solid #5AA6F4; border-right: 10px solid #5AA6F4; background: #FFFFFF; width: 98%; height: 35px; position: relative; top: 5%;"></div>
            <img id="Close" src="Img/关闭按钮.png" />
            <div style="background-color: #5AA6F4;">
                <video id="Video" controls="controls" autoplay="autoplay" width="98%" height="90%" src=""></video>
            </div>
        </div>
        <div id="Div_alter">
            <div id="Div_alert_count">
                <table id="sef">
                </table>
            </div>
            <input type="button" id="alert_but" />
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
                $(this).css("background-image", "url(Img/下拉框年级和科目展开时按下.png)");
            }
        } else {
            if (id = "Select1") {
                $(this).css("background-image", "url(Img/下拉框课本名称未展开时按下.png)");
            } else {
                $(this).css("background-image", "url(Img/下拉框年级和科目未展开时按下.png)");
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
                $(this).css("background-image", "url(Img/下拉框年级和科目未展开时.png)");
            }
            hi.val("0");
        } else {
            if (id = "Select1") {
                $(this).css("background-image", "url(Img/下拉框课本名称展开时.png)");
            } else {
                $(this).css("background-image", "url(Img/下拉框年级和科目展开时.png)");
            }
            hi.val("1");
        }

    })
    $(".rechek").click(function () {
        if ($(this).prev("input").val() == "0") {
            $(this).prev("input").val("1");
            $(this).css("background-image", "url(Img/打勾-按下白色16.png)");
            $(this).next("input").attr("checked", true);
        } else {
            $(this).prev("input").val("0");
            $(this).css("background-image", "url(Img/打勾白色16.png)");
            $(this).next("input").attr("checked", false);
        }

    })

    $("#txyiwh").click(function () {
        if ($(this).prev("input").val() == "0") {
            $(this).prev("input").val("1");
            $(this).css("background-image", "url(Img/打勾-按下白色16.png)");
            $(this).next("input").attr("checked", true);
            $("#txerwh").prev("input").val("0");
            $("#txerwh").css("background-image", "url(Img/打勾白色16.png)");
            $("#txerwh").next("input").attr("checked", false);
            $("#txsanwh").prev("input").val("0");
            $("#txsanwh").css("background-image", "url(Img/打勾白色16.png)");
            $("#txsanwh").next("input").attr("checked", false);
        } else {
            $(this).prev("input").val("0");
            $(this).css("background-image", "url(Img/打勾白色16.png)");
            $(this).next("input").attr("checked", false);
        }
    })
    $("#txerwh").click(function () {
        if ($(this).prev("input").val() == "0") {
            $(this).prev("input").val("1");
            $(this).css("background-image", "url(Img/打勾-按下白色16.png)");
            $(this).next("input").attr("checked", true);
            $("#txyiwh").prev("input").val("0");
            $("#txyiwh").css("background-image", "url(Img/打勾白色16.png)");
            $("#txyiwh").next("input").attr("checked", false);
            $("#txsanwh").prev("input").val("0");
            $("#txsanwh").css("background-image", "url(Img/打勾白色16.png)");
            $("#txsanwh").next("input").attr("checked", false);
        } else {
            $(this).prev("input").val("0");
            $(this).css("background-image", "url(Img/打勾白色16.png)");
            $(this).next("input").attr("checked", false);
        }
    })
    $("#txsanwh").click(function () {
        if ($(this).prev("input").val() == "0") {
            $(this).prev("input").val("1");
            $(this).css("background-image", "url(Img/打勾-按下白色16.png)");
            $(this).next("input").attr("checked", true);
            $("#txyiwh").prev("input").val("0");
            $("#txyiwh").css("background-image", "url(Img/打勾白色16.png)");
            $("#txyiwh").next("input").attr("checked", false);
            $("#txerwh").prev("input").val("0");
            $("#txerwh").css("background-image", "url(Img/打勾白色16.png)");
            $("#txerwh").next("input").attr("checked", false);
        } else {
            $(this).prev("input").val("0");
            $(this).css("background-image", "url(Img/打勾白色16.png)");
            $(this).next("input").attr("checked", false);
        }
    })
    $(function () {
        loadcebian();
        $("#pgServer").find("div").eq(0).css({ "position": "relative", "left": "-18%" });
        $("#pgServer").find("div").eq(1).css({ "position": "relative", "left": "28%", "top": "-90%", "width": "80%" });
        $.ajax({
            url: '../ashx/Video.ashx',
            type: 'post',
            datatype: "json",
            data: { action: "chek" },
            success: function (data) {
                if (data == "yi") {
                    $("#CheckBox1").attr("checked", true);
                    $("#CheckBox1").prev("span").css("background-image", "url(Img/打勾-按下白色16.png)");
                } else if (data == "wei") {
                    $("#CheckBox2").attr("checked", true);
                    $("#CheckBox2").prev("span").css("background-image", "url(Img/打勾-按下白色16.png)");
                } else if (data == "quan") {
                    $("#CheckBox3").attr("checked", true);
                    $("#CheckBox3").prev("span").css("background-image", "url(Img/打勾-按下白色16.png)");
                } else {
                    $("#CheckBox3").attr("checked", true);
                    $("#CheckBox3").prev("span").css("background-image", "url(Img/打勾-按下白色16.png)");
                }
            }
        })
        $("input[name=chek]").each(function () {
            $(this).attr("checked", false);
        })
        //$.ajax({
        //    url: '../ashx/UserInfo.ashx',
        //    type: 'post',
        //    datatype: "json",
        //    data: { action: "GrName" },
        //    success: function (data) {
        //        var jsonobj = eval("(" + data + ")");
        //        for (var it in jsonobj) {
        //            $("#Select1").append(" <option value=" + jsonobj[it].Prs + ">" + jsonobj[it].Prs + "</option>");
        //        }
        //    }
        //})
        //$.ajax({
        //    url: '../ashx/Video.ashx',
        //    type: 'post',
        //    datatype: "json",
        //    data: { action: "LoadGr" },
        //    success: function (data) {
        //        var jie = String(data);
        //        var shuz = jie.split('|')
        //        for (var i = 0; i < shuz.length; i++) {
        //            if (i == 0 && shuz[i] != "") {
        //                $("#nianji  option[value='" + shuz[i] + "']").attr("selected", "selected")
        //            } else if (i == 1 && shuz[i] != "") {
        //                $("#SelSuName  option[value='" + shuz[i] + "']").attr("selected", "selected")
        //            } else if (i == 2 && shuz[i] != "") {
        //                $("#Select1  option[value='" + shuz[i] + "']").attr("selected", "selected")
        //            } else if (i == 3 && shuz[i] != "") {
        //                $("#TxtName").val(shuz[i]);
        //            }
        //        }
        //    }
        //})
        //$("#nianji  option[value='" + $("#Tnianji").val() + "']").attr("selected", true)
    })
    $("body").on("click", ".xiala", function () {
        //alert($(this).html());
        $(this).find("div").animate({
            height: 'toggle'
        });
    })
    //$(".But_quanxuan").click(function () {
    //    if ($(".chek").val() == 1) {
    //        var mp4 = "";
    //        var id = "";
    //        var caname = "";
    //        var state = $(this).val();
    //        var dtid = "";
    //        $("input[name='chek']:checked").each(function (i, n) {
    //            mp4 += $(this).val() + "|";
    //            mp4 += $(this).prev().val() + "|";
    //            id += $(this).attr("id") + "|";
    //            caname += $(this).next().val() + "|";
    //            dtid += $(this).next().attr("id") + "|";
    //        });
    //        $.ajax({
    //            url: '../ashx/Video.ashx',
    //            url: '../ashx/Video.ashx',
    //            type: 'post',
    //            datatype: "json",
    //            data: { action: "bangdingS", mp4: mp4, id: id, caname: caname, state: state, dtid: dtid },
    //            success: function (data) {
    //                var jsonobj = eval(data);
    //                var al = "<tr style='background-color: #5DA4F9; color: #FFFFFF'><td class='yiid'>序号</td><td class='yikwen'>课文名称</td><td class='yimuru'>目录</td><td class='yipibie'>匹配的路径</td><td class='yiuddy'>解定状态</td></tr>";
    //                for (var it in jsonobj) {
    //                    if (jsonobj[it].cg != undefined) {
    //                        al += "<tr class='yise'><td  class='yiid'>" + jsonobj[it].cc + "</td><td class='yikwen'>语文</td><td class='yimuru'>" + jsonobj[it] + "</td><td  class='yipibie'>" + jsonobj[it].cg + "<td><dt class='yiuddy'>绑定成功</td></tr>";
    //                    }
    //                    if (jsonobj[it].jb != undefined) {
    //                        al += "<tr class='yise'><td  class='yiid'>001</td><td class='yikwen'>语文</td><td class='yimuru'> 春</td><td  class='yipibie'>" + jsonobj[it].jb + "<td><dt  class='yiuddy'>解绑成功</td></tr>";
    //                    }
    //                }
    //                $("#sef").html(al);
    //                $("#Div_alter").css("display", "inline-block");
    //            }
    //        })
    //    } else {
    //        $(this).html("请选择再");
    //    }
    //})
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

    })
    //$(".But_Video").click(function () {
    //    var Dis = $(".Video").css("display");
    //    if (Dis == "none") {
    //        $(".Video").css("display", "inline");
    //        if ($(this).attr("id") == "") {
    //            $("#Video").attr("src", "http://183.60.136.8:188/" + $(this).attr("name"));
    //        } else {
    //            $("#Video").attr("src", "http://183.60.136.8:188/" + $(this).attr("id"));
    //        }
    //    } else {
    //        $("#Video").attr("src", "");
    //        $(".Video").css("display", "none");
    //    }
    //})
    $("#Close").click(function () {
        $(".Video").css("display", "none");
        $("#Video").attr("src", "");
    })
    $("#Button3").click(function () {
        $("#Tnianji").val($("#nianji").val());
        $("#TSuName").val($("#SuName").val());
    })
</script>
