<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="Video.aspx.cs" Inherits="Webz.Admin.Video" %>

<%@ Register Src="~/Admin/Views/CC_Table_MoHu.ascx" TagPrefix="uc1" TagName="CC_Table_MoHu" %>


<%--<%@ OutputCache Duration="2000" VaryByParam="none" %>--%>
<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <meta http-equiv="Content-Type" content="text/html; charset=utf-8" />
    <title>模糊匹配</title>
    <script src="CC/jquery-3.3.1.js"></script>
    <script src="CC/layui-v2.4.5/layui/layui.js"></script>
    <link href="CC/layui-v2.4.5/layui/css/layui.css" rel="stylesheet" />
    <link href="../CSS/AdminVideo.css" rel="stylesheet" />
    <link href="../CSS/cebianlan.css" rel="stylesheet" />
    <style>
        body {
            /*overflow-x: hidden;*/
            width: 100%;
            min-width: 1129px;
            max-width: 100%;
            height: 100%;
        }

        .chek {
            background-image: url(Img/打勾20.png);
        }

        .cheks {
            background-image: url(Img/打勾20.png);
        }

        #Button7 {
            font-size: 12px;
            position: relative;
            left: -0.5%;
            width: 75px;
            top: 0.5px;
            margin-left: -1%;
            height: 26.5px;
            background-color: #0F65CC;
            border: 1px solid #0F65CC;
            border-radius: 5px;
            color: #F2F2F2;
            left: 20px;
        }

        #Button8 {
            font-size: 12px;
            position: relative;
            left: -0.5%;
            width: 75px;
            top: 0.5px;
            margin-left: -1%;
            height: 26.5px;
            background-color: #0F65CC;
            border: 1px solid #0F65CC;
            border-radius: 5px;
            color: #F2F2F2;
            left: 40px;
        }

        #retun {
            font-size: 12px;
            position: relative;
            left: -0.5%;
            width: 75px;
            top: 0.5px;
            margin-left: -1%;
            height: 26.5px;
            background-color: #0F65CC;
            border: 1px solid #0F65CC;
            border-radius: 5px;
            color: #F2F2F2;
        }

        #ovrn {
            margin-left: 60%;
        }

        .chizhao {
            width: 600px;
            height: 100px;
        }

        #TxtName {
            margin-left: 18px;
            /*padding-left: 1%;*/
            font-size: 12px;
            line-height: 20px;
            height: 22px;
            width: 400px;
            border-top-left-radius: 5px;
            border-bottom-left-radius: 5px;
            border: 1px solid #699DEC;
        }

        #Button3 {
            font-size: 12px;
            position: relative;
            left: 10px;
            width: 80px;
            top: -0.5px;
            margin-left: -1%;
            height: 23px;
            background-color: #0F65CC;
            border: 1px solid #0F65CC;
            border-top-right-radius: 5px;
            border-bottom-right-radius: 5px;
            color: #F2F2F2;
        }
    </style>
</head>
<body runat="server">
    <%int id = Convert.ToInt32(Request.QueryString["id"]);
      Model.PageList pl = new BLL.CC_PageListBLL().GetIdOnePageList(id);
      
    %>
    <div>
        <div style="min-height: 600px;">
            <div style="font-size: 12px;">视频匹配>模糊匹配</div>
            <div id="Div_pipei" style="background-color: #5DA4F9; height: 30px; line-height: 30px; width: 101.2%; position: relative; left: -1.2%;">
                当前的课本名称：<span><%=pl.BooksName %></span> &nbsp &nbsp &nbsp &nbsp &nbsp &nbsp 
                    当前的课文名称：<span><%=pl.ViName %></span>
                <span class="chizhao">
                    <input type="text" value="" id="TxtName" runat="server" placeholder="请输入科目名称" />
                    <button id="Button3">查找</button>
                    <%--<asp:Button ID="Button3" runat="server" Text="查找" OnClick="Button1_Click" />--%>
                </span>
            </div>
            <div id="ovrn" style="margin-top: 1%;">
                <input id="retun" class="common-btn-back" type="button" name="retun" value="返回上一层" />

                <input type="button" class="But_quanxuanBD" id="Button7" value="批量绑定" />
                <input type="button" class="But_quanxuanJC" id="Button8" value="批量解绑" />
            </div>
            <uc1:CC_Table_MoHu runat="server" ID="CC_Table_MoHu" />
        </div>
        <div id="Page" >
        </div>
    </div>
    </div>
    <div class="Video">
        <div id="Video_top" style="border-top: 5px solid #5AA6F4; border-left: 5px solid #5AA6F4; border-right: 10px solid #5AA6F4; background: #FFFFFF; width: 98%; height: 35px; position: relative; top: 5%;"></div>
        <img id="Close" src="Img/关闭按钮.png" />
        <div style="background-color: #5AA6F4;">
            <video id="Video" controls="controls" autoplay="autoplay" width="98%" height="90%" src=""></video>
        </div>

    </div>
    <input type="hidden" id="T_Caname" value="" runat="server" />
    <input type="hidden" id="T_SuName" value="" runat="server" />
    <input type="hidden" id="T_Caid" value="" runat="server" />
    <script src="CC/layui-v2.4.5/layui/layui.all.js" charset="utf-8"></script>
    <script>
        var Count, Pageindex = 1, PageSize = 10, TName = "<%=pl.ViName%>", url = "AjaxHelper/Ajax.ashx", State = "<%=pl.匹配%>", Kemu = "<%=pl.BooksName%>";
        var fl = 0;
        var id = "<%=id%>";
        var MoShi;
        //加载状态
        function Tip() {
            layui.use('layer', function () {
                var layer = layui.layer;
                layer.msg('加载中。。。。', {
                    icon: 16
                                , shade: 0.01
                                , time: 99999999
                });
            });
        }
        //状态删除
        function CloseTip() {
            layui.use('layer', function () {
                var layer = layui.layer;
                layer.closeAll();
            });
        }

        //分页绑定
        function BDFY() {

            layui.use('laypage', function () {
                var laypage = layui.laypage;
                //执行一个laypage实例
                laypage.render({
                    elem: 'Page' //注意，这里的 test1 是 ID，不用加 # 号
                  , count: Count //数据总数，从服务端得到
                    , limit: PageSize
                    , layout: ['limit', 'count', 'prev', 'page', 'next', 'refresh', 'skip'],
                    jump: function (obj) {
                        Tip();
                        //obj包含了当前分页的所有参数，比如：
                        Pageindex = obj.curr;
                        PageSize = obj.limit;
                        fl = 1;
                        TestFY(Pageindex, PageSize, TName, Kemu);

                    }
                });
            });
        }
        //分页数据加载
        function TestFY(Pageindex, PageSize, TName) {
            var data = { type: "TestFenYe", Pageindex: Pageindex, PageSize: PageSize, TName: TName, Kemu: Kemu };
            $.post(url, data, TestFenYe, "json")

        }
        function TestFenYe(data) {
            Count = data.Count;
            $("#huadong table tr:gt(0)").remove();

            for (var i = 0; i < data.list.length; i++) {
                if (State == "" || State == null) {
                    $('#btState').val("绑定");

                } else {
                    $('#btState').val("解绑");
                }
                $("#huadong table").append(
                    "<tr><td>" + (i + 1) + "</td>" +
            "<td class='tdpath'>" + data.list[i].Name + "</td>" +
                "<td>" + data.list[i].HTV + "</td>" +
                "<td>" + data.list[i].MP4 + "</td>" +
                "<td>" +
                "<input id='BF' type='button' class='input BF' value='预览' name='Video' Pmp4=" + data.list[i].MP4 + " />" +
                "<input id='btState' type='button' class='input OneBD' value='绑定' name='bangding' BDTestId=" + data.list[i].TestID + " />" +
                "<input type='hidden' name='HidMp4' value='' />" +
                "</td>" +
                "<td>" +
                "<input type='checkbox' name='chek' value='0'  BDTestId=" + data.list[i].TestID + " />" +
                " <span class='chek'></span>" +
                "<input type='hidden' value='' />" +
                "</td>" +
                "</tr>")

            }

            if (fl == 0) {
                BDFY();
                fl = 1;
            }
            CloseTip();
            MP4();
            $(".chek").click(function () {
                if ($(this).prev("input").val() == "0") {
                    $(this).prev("input").attr("checked", true);
                    $(this).css("background-image", "url(Img/打勾-按下20.png)");
                    $(this).prev("input").val("1");
                } else {
                    $(this).prev("input").attr("checked", false);
                    $(this).css("background-image", "url(Img/打勾20.png)");
                    $(this).prev("input").val("0");
                }

            })
            //重新绑定单独绑定事件
            OneBD();


        }

        function OneBD() {
            $(".OneBD").click(function () {
                //提示
                layui.use('layer', function () {
                    var layer = layui.layer;
                    layui.use('layer', function () {
                        var layer = layui.layer;
                        layer.msg('绑定中。。。。', {
                            icon: 16
                                        , shade: 0.01
                                        , time: 99999999
                        });
                    });
                });

                var TestId = $(this).attr("BDTestId");
                var data = { type: "OneBD", id: id, TestId: TestId };
                $.post(url, data, DBHuiD, "json");
            })

        }
        //绑定回调
        function DBHuiD(data) {
            if (data == "1") {
                CloseTip();
                layui.use('layer', function () {
                    var layer = layui.layer;
                    layer.alert('绑定成功', { icon: 6 }, function () {

                        DataShuaXin();
                    });
                });

            } else if (data == "2") {
                layui.use('layer', function () {
                    var layer = layui.layer;
                    layer.alert(' 重复绑定请重试', { icon: 5 });
                });
            } else {
                layui.use('layer', function () {
                    var layer = layui.layer;
                    layer.alert('绑定失败', { icon: 5 });
                });
            }
        }
        //数据刷新
        function DataShuaXin() {
            //刷新数据
            layui.use('layer', function () {
                var layer = layui.layer;
                layui.use('layer', function () {
                    var layer = layui.layer;
                    layer.msg('刷新数据中。。。。', {
                        icon: 16
                                    , shade: 0.01
                                    , time: 99999999
                    });
                });
            });
            var Shuadada = { type: "ShuaXdada" };
            $.post(url, Shuadada, ShuaXdata, "json");
        }
        function ShuaXdata(data) {
            if (data == "-10") {
                layer.closeAll();
                layer.alert('更新失败', { icon: 5 });
            } else if (data > 0) {
                layer.closeAll();
                layer.alert('更新成功', { icon: 6 }, function () {

                    window.location.href = "Video.aspx?id=" + id;
                });

            }
        }
        //批量绑定
        function AllBinding() {

            $(".But_quanxuanBD").click(function () {
                MoShi = 0;
                var AllckInput = $("input[name='chek']:checked");
                if (AllckInput.length > 0) {
                    var arr = "";

                    for (var i = 0; i < AllckInput.length; i++) {
                        if (i + 1 == AllckInput.length) {
                            arr += $(AllckInput[i]).attr("BDTestId");

                        } else {
                            arr += $(AllckInput[i]).attr("BDTestId") + ",";
                        }
                    }
                    layui.use('layer', function () {
                        var layer = layui.layer;
                        layer.open({
                            type: 2,
                            area: ['1000px', '500px'],
                            title: '绑定信息',
                            fixed: false, //不固定
                            maxmin: false,
                            content: 'BDing_Mohu.aspx?id=' + id + "&Moshi=" + MoShi + "&Arr=" + arr
                        });
                    });
                }
            });
        }
        //批量解绑
        function AllJCBinding() {

            $(".But_quanxuanJC").click(function () {
                MoShi = 1;
                var AllckInput = $("input[name='chek']:checked");
                if (AllckInput.length > 0) {
                    var arr = "";

                    for (var i = 0; i < AllckInput.length; i++) {
                        if (i + 1 == AllckInput.length) {
                            arr += $(AllckInput[i]).attr("BDTestId");

                        } else {
                            arr += $(AllckInput[i]).attr("BDTestId") + ",";
                        }
                    }
                    layui.use('layer', function () {
                        var layer = layui.layer;
                        layer.open({
                            type: 2,
                            area: ['1000px', '500px'],
                            title: '绑定信息',
                            fixed: false, //不固定
                            maxmin: false,
                            content: 'BDing_Mohu.aspx?id=' + id + "&Moshi=" + MoShi + "&Arr=" + arr
                        });
                    });

                    $(".layui-layer-close1").hide();
                    $(".layui-layer-iframe").append("<button class='layui-btn layui-btn-fluid OkBD'>确认关闭</button>");
                    $(".OkBD").click(function () {
                        location.reload();
                        layer.closeAll();

                    });
                }
            });
        }




        $(function () {
            TestFY(Pageindex, PageSize, TName);
            //查找
            $("#Button3").click(function () {
                fl = 0;
                TName = $("#TxtName").val();
                TestFY(Pageindex, PageSize, TName);
            });
            $(".common-btn-back").click(function () {
                window.location.href = "SelectVideo.aspx";
            });
            AllBinding();
            AllJCBinding();

        });
        //mp4播放
        function MP4() {
            $(".BF").click(function () {
                var Pmp4 = $(this).attr("Pmp4");
                var Dis = $(".Video").css("display");
                if (Dis == "none") {
                    $(".Video").css("display", "inline");

                    $("#Video").attr("src", "http://183.60.136.8:188/" + Pmp4);

                } else {
                    $("#Video").attr("src", "");
                    $(".Video").css("display", "none");
                }
            })


        }


    </script>


</body>
</html>

<script src="../js/cebianlan.js"></script>
<script>
    //返回上一层页面
    //$("#retun").click(function () {
    //    window.history.go(-1);
    //});
    $(function () {
        loadcebian();
    })

    $("body").on("click", ".xiala", function () {
        //alert($(this).html());
        $(this).find("div").animate({
            height: 'toggle'
        });
    })
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
    $("input[name=\"Video\"]").click(function () {
        var Dis = $(".Video").css("display");
        if (Dis == "none") {
            $(".Video").css("display", "inline");
            $("#Video").attr("src", $(this).attr("id"));
        } else {
            $("#Video").attr("src", "");
            $(".Video").css("display", "none");
        }
    })
    $("#Close").click(function () {
        $(".Video").css("display", "none");
        $("#Video").attr("src", "");
    })
    //$("input[name=\"bangding\"]").click(function () {
    //    var caname = $("#T_Caname").val();
    //    var Caid = $("#T_Caid").val();
    //    var Mp4 = $(this).attr("id");
    //    var But = $(this);
    //    if (Caid == "0") {
    //        return false;
    //    } else {
    //        $.ajax({
    //            url: '../ashx/Books.ashx',
    //            type: 'post',
    //            datatype: "json",
    //            data: { action: "bangding", caname: caname, Caid: Caid, Mp4: Mp4 },
    //            success: function (data) {
    //                alert(data);
    //                if (data == "绑定成功") {
    //                    But.val("解绑");
    //                } else {
    //                    But.val("绑定");
    //                }
    //            }
    //        })
    //    }

    //})
</script>

