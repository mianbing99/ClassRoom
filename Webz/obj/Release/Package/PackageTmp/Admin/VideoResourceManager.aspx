<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="VideoResourceManager.aspx.cs" Inherits="Webz.Admin.VideoResourceManager" %>

<%@ Register Assembly="AspNetPager" Namespace="Wuqi.Webdiyer" TagPrefix="webdiyer" %>
<%@ Register Src="~/Admin/Views/CC_GradeList.ascx" TagPrefix="uc1" TagName="CC_GradeList" %>
<%@ Register Src="~/Admin/Views/CC_SubjectList.ascx" TagPrefix="uc1" TagName="CC_SubjectList" %>
<%@ Register Src="~/Admin/Views/CC_PublishingList.ascx" TagPrefix="uc1" TagName="CC_PublishingList" %>
<%@ Register Src="~/Admin/Views/CC_Table_PageList.ascx" TagPrefix="uc1" TagName="CC_Table_PageList" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <%-- <meta name="viewport" content="width=device-width,initial-scale=1" />--%>
    <meta http-equiv="Content-Type" content="text/html; charset=utf-8" />
    <script src="CC/jquery-3.3.1.js"></script>
    <script src="CC/layui-v2.4.5/layui/layui.js"></script>
    <link href="CC/layui-v2.4.5/layui/css/layui.css" media="all" rel="stylesheet" />
    <link href="../CSS/AdminVideo.css" rel="stylesheet" />

    <title>视频资源管理</title>
    <style>
        body {
            width: 100%;
            min-width: 1129px;
            max-width: 100%;
            height: 100%;
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

        .textNamebox {
            display: inline-block;
            height:25px;
            margin-left:10px;
            line-height:25px;
        }
        

        .TxtName {
            width:190px;
            height:22px;
            border-top-left-radius: 5px;
            border-bottom-left-radius: 5px;
            border: 1px solid #699DEC;
        }
        .querybtn {
            width:50px;
            height:22px;
            background-color: #0F65CC;
            border: 1px solid #0F65CC;
            border-top-right-radius: 5px;
            border-bottom-right-radius: 5px;
            color: #F2F2F2;
            font-size:12px;
        }
        .querybtn:hover {
            cursor:pointer;
            opacity:.8;
            filter:alpha(opacity=80);
        }

        .videoVip, .videoState {
            width: 80px;
            height: 25px;
            border-radius: 5px;
            border: 1px solid #699DEC;
            margin-left: 10px;
            line-height:25px;
        }
        

        
    </style>
</head>
<body>
    <form id="form" runat="server">
        <div>
            <div style="min-height: 600px;">
                <div id="rightcontent">
                    <div>
                        <div style="font-size: 12px; margin-left: 12px;">当前位置：视频资源管理</div>
                        <div id="Div_pipei" style="background-color: #5DA4F9; height: 30px; line-height: 30px; width: 100%; margin-left: 12px;">
                            <%-- //年级--%>
                            <uc1:CC_GradeList runat="server" ID="CC_GradeList" />
                            <%--科目--%>
                            <uc1:CC_SubjectList runat="server" ID="CC_SubjectList" />
                            <%--出版社--%>
                            <uc1:CC_PublishingList runat="server" ID="CC_PublishingList" />

                            <select class="videoVip" runat="server">
                                <option class="" value="0">免费</option>
                                <option class="" value="1" selected="selected">VIP</option>
                            </select>
                            <select class="videoState" runat="server">
                                <option class="" value="1">启用</option>
                                <option class="" value="0">禁止</option>
                            </select>

                            <div class="textNamebox">
                                <input type="text" class="TxtName"  runat="server" placeholder="这里输入查找的课文名称" /><input type="button" class="querybtn" value="查询"/>

                            </div>
                           
                        </div>
                        <div style="margin-top: 0%; margin-bottom: -8px;">

                            <span style="margin-left: 40%;" class="layui-form">
                                <span class="chespan">
                                    <input type="hidden" name="chekname" value="1" />

                                    <input type="radio" lay-filter="chetiaojian" id="CheckBox3" name="chetiaojian" runat="server" checked="true" value="0" />
                                    <span style="font-size: 13px;">显示全部</span>
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

                            <button type="button" id="Button4" class="layui-btn layui-btn-normal">新增</button>
                            <button type="button" id="Button1" class="layui-btn layui-btn-normal btnImport">导入</button>
                            <button type="button" id="But_quanxuan" class="But_quanxuan layui-btn layui-btn-normal">删除</button>

                        </div>
                    </div>
                    <div id="huadong">
                        <table>
                            <tr style="background-color: #5DA4F9; color: #FFFFFF;">
                                <td>序号</td>
                                <td>视频ID</td>
                                <td>视频名称</td>
                                <td>状态</td>
                                <td>VIP</td>
                                <td>MP4路径</td>
                                <td>HTV路径</td>
                                <td>路径ID</td>
                                <td id="MH">操作</td>
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
                    //@TbnName varchar(50)='%',--书名
                    //@GaID varchar(50)='%',--年级ID
                    //@SubID varchar(50)='%',--科目ID
                    //@PrID varchar(50)='%',--出版社ID
                    //@PP int--判断是哪种匹配方式
                    var MP4Url = "";
                    $.ajaxSettings.async = true;
                    var fl = 0;
                    var count = 0;
                    var PageIndex = 1;
                    var PageSize = 10;
                    var TbnName, GaID, SubI, PrID, PP, dataExPageList;
                    var PPd, Judge;
                    var State,Vip;
                    var laypage = null;
                    var form = null;
                    var url = "AjaxHelper/VideoResourceManager.ashx";
                    layui.use('laypage', function () {
                        laypage = layui.laypage;
                    });
                    function load() {
                        $(function () {//加载事件
                            //grade();
                            aaa(PageIndex, TbnName, GaID, SubI, PrID, State, Vip, PP, Judge);//执行aaa方法获得数据
                            function aaa(pageIndex, tbnName, gaID, subI, prID, state, vip, pP, judge) {//定义ajax方法
                                //var data = { type: "AllList", PageIndex: PageIndex, PageSize: PageSize, TbnName: TbnName, GaID: GaID, SubI: SubI, PrID: PrID, PP: PP, Judge: Judge };
                                //$.post(url, data, SelectList, "json");

                                var data = { action: "videoPageInfoSelect", PageIndex: pageIndex, PageSize: PageSize, TbnName: tbnName, GaID: gaID, SubI: subI, PrID: prID, State: state, VIP: vip, PP: pP };
                                $.post(url, data, SelectList, "json");
                            }
                            function grade()
                            {
                                $.post("AjaxHelper/Grade.ashx", function (data) {
                                    alert(data);
                                    console.log(data.data.GaID);
                                    //for(var list in data)
                                    //{
                                    //    $(".nianji").append("<option value="+list.+">");
                                    //}
                                    
                                });
                            }
                            function SelectList(data) {
                                console.log(data);
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
                                        jump: function (obj, first) {

                                            layer.msg('加载中。。。。', {
                                                icon: 16
                                    , shade: 0.01
                                    , time: 99999999
                                            });

                                            //obj包含了当前分页的所有参数，比如：
                                            //加载禁用
                                            $('#Page').attr("disabled", true);
                                            PageIndex = obj.curr;
                                            PageSize = obj.limit;
                                            aaa(PageIndex, TbnName, GaID, SubI, PrID,State,Vip, PP, Judge);
                                            //console.log(obj)
                                            //alert(obj.curr);//获取点击的页数

                                        }
                                    });
                                }

                                //数据展示
                                for (var i = 0; i < data.list.length; i++) {

                                    $("#huadong table").append("<tr><td>" + data.list[i].ViIndex + "</td>" +
                                        "<td class='tdViID'>" + data.list[i].ViID + "</td>" +
                                        "<td class='tdViName'>" + data.list[i].ViName + "</td>" +
                                        "<td class='tdState'>" + data.list[i].State + "</td>" +
                                        "<td class='tdVip'>" + data.list[i].Vip + "</td>" +
                                        "<td class='tdMp4'>" + data.list[i].Mp4 + "</td>" +
                                        "<td class='tdHTV'>" + data.list[i].HTV + "</td>" +
                                        "<td class='tdVRID'>" + data.list[i].VRID + "</td>" +
                                        "<td><input class='layui-btn layui-btn-sm But_Video' type='button' name='' id=''  VRID='" + data.list[i].VRID + "' HTV='" + data.list[i].HTV + "' MP4= '" + data.list[i].Mp4 + "' Status='" + data.list[i].State + "' Vip='" + data.list[i].Vip + "'  value='修改'  /></td>" +
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

                                //视频资源修改
                                $(".But_Video").click(function () {
                                    //alert("PathUpdate.aspx?ViID=" + $(this).attr("ViID"));

                                    var vrid = $(this).attr("VRID");
                                    window.location.replace("VideoUpdate.aspx?VRID=" + vrid);
                                });



                                layer.closeAll();

                            }


                            //导入按钮
                            $(".btnImport").click(function () {
                                alert("功能还在开发中。。。。。。。");
                            });

                            //删除按钮
                            $(".But_quanxuan").click(function () {
                                alert("功能还在开发中。。。。。。。");
                                //var vrid = $(this).attr("VRID");
                                //var bol = confirm("确认是否删除视频记录？"+vrid);

                                //if (bol == true) {
                                //    var data = {action:"delectInfo",VRID:}
                                //    $.get("AjaxHelper/VideoResourceManager.ashx",);
                                //    alert("删除成功！");
                                //}
                            });


                            $(".querybtn").click(function () {//点击按钮执行筛选查询
                                
                                //alert(state+","+vip);
                                layer.msg('加载中。。。。', {
                                    icon: 16
                                    , shade: 0.01
                                    , time: 99999999
                                });
                                GaID = $(".nianji").val();
                                PrID = $(".Select1").val();
                                SubI = $(".SelSuName").val();
                                TbnName = $(".TxtName").val();
                                State = $(".videoState").val();
                                Vip = $(".videoVip").val();

                                //if (TbnName == null || TbnName == "" || TbnName == " ") {
                                //    TbnName = "%";
                                //}
                                fl = 0;//状态改成0，否则不执行
                                aaa(PageIndex, TbnName, GaID, SubI, PrID, State, Vip, PP, Judge);

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
                                        aaa(PageIndex, TbnName, GaID, SubI, PrID, State, Vip, PP, Judge);
                                    }

                                });
                            });

                        });
                    };
                    load();

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

    //下拉框选中事件
    $("select").change(function () {
        $(this).css("background-image", "url(Img/下拉框课本名称未展开时.png)");
        
    });

    //下拉框获取焦点事件
    $("select").focus(function () {
        $(this).css("background-image", "url(Img/下拉框课本名称展开时按下.png)");
    });
    
    //下拉框失去焦点事件
    $("select").blur(function () {
        $(this).css("background-image", "url(Img/下拉框课本名称未展开时.png)");
    });
    //测试一下
    //$("#tuichu").click(function () {
    //    //$("#Addinterface").load('AddVideo.aspx');
    //    //window.history.back();
    //    window.location.replace("VideoResourceManager.aspx");
    //});

    //打开新增界面
    $(function () {
        $("#Button4").click(function () {
            window.location.replace("AddVideo.aspx");
        });

    });


    //loadData(encode(data), "text/html;charset=UTF-8", null);
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

    });
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

    $("#Close").click(function () {
        $(".Video").css("display", "none");
        $("#Video").attr("src", "");
    })
    $("#Button3").click(function () {
        $("#Tnianji").val($("#nianji").val());
        $("#TSuName").val($("#SuName").val());
    })
</script>
