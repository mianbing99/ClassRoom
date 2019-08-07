<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="BDing_Mohu.aspx.cs" Inherits="Webz.Admin.BDing_Mohu" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <meta http-equiv="Content-Type" content="text/html; charset=utf-8" />
    <title></title>
    <script src="CC/jquery-3.3.1.js"></script>
    <script src="CC/layui-v2.4.5/layui/layui.js"></script>
    <link href="CC/layui-v2.4.5/layui/css/layui.css" rel="stylesheet" />
</head>
<body>
    <%
        int id = Convert.ToInt32(Request.QueryString["id"]);
        int Moshi = Convert.ToInt32(Request.QueryString["Moshi"]);
        string Arr = Request.QueryString["Arr"];
        List<Model.Test> TSList = new BLL.CC_TestBLL().TestList(Arr);
        Model.PageList pl = new BLL.CC_PageListBLL().GetIdOnePageList(id);
         %>
    <span class="layui-badge layui-bg-black"><%=pl.BooksName %>><%=pl.ViName %></span>
    <hr class="layui-bg-green">
    <%--绑定--%>
    <%
        if (Moshi == 0)
        {
           %>




<%--    //绑定块--%>
     <table class="layui-table" lay-size="sm" style="color:#000000" >
        <thead>
            <tr>
                <th>序号</th>
                <th>视频名称</th>
                <th>HTV</th>
                <th>MP4</th>
                <th>绑定状态</th>
            </tr>
        </thead>
        <tbody>

            <%
            foreach (var item in TSList)
            {
                %>
              <tr>
                <td><%=item.TestID %></td>
                <td><%=item.Name %></td>
                <td><%=item.HTV %></td>
                <td><%=item.MP4 %></td>
                <td V_ID="<%=item.TestID  %>" name="WBD" style="color:green">正在执行绑定</td>
            </tr>

            <%}
                
                %>
          
          
        </tbody>
    </table>






      <%   }
        else
        {
            %>
<%--    //解绑--%>





    <table class="layui-table" lay-size="sm">
        <thead>
            <tr>
                <th>序号</th>
                <th>视频名称</th>
                <th>HTV</th>
                <th>MP4</th>
                <th>绑定状态</th>
            </tr>
        </thead>
        <tbody>
              <%
            foreach (var item in TSList)
            {
                %>
              <tr>
                <td><%=item.TestID %></td>
                <td><%=item.Name %></td>
                <td><%=item.HTV %></td>
                <td><%=item.MP4 %></td>
                <td V_ID="<%=item.TestID  %>" name="YBD" style="color:green">正在执行解绑</td>
            </tr>

            <%}
                
                %>
          
        </tbody>
    </table>




        <%}
        
        
         %>
   
    <script>
        var MoShi = "<%=Moshi%>";
        var id = "<%=id%>";
        var TimeFun;
        var Alltr = null;
        var url = "AjaxHelper/Ajax.ashx";
        var i = 0;
        var indexTr = null;
        var OKdata = 0;


        $(function () {
            if (MoShi == 0) {
                Alltr = $("td[name='WBD']");
                layui.use('layer', function () {
                    var layer = layui.layer;
                    layer.msg('<span class=\'Titl\'>绑定序号:</span><span style=\'color: green\' class=\'Tip\'></span>', {
                        icon: 16
                         , shade: 0.01
                         , time: 99999999
                    });
                });
                TimeFun = window.setInterval(MHBDing, 500);
            } else {
                Alltr = $("td[name='YBD']");
                layui.use('layer', function () {
                    var layer = layui.layer;
                    layer.msg('<span class=\'Titl\'>解绑序号:</span><span style=\'color: green\' class=\'Tip\'></span>', {
                        icon: 16
                         , shade: 0.01
                         , time: 99999999
                    });
                });
                TimeFun = window.setInterval(JCBDing, 500);
            }
        });
        function CloseTip() {
            layui.use('layer', function () {
                var layer = layui.layer;
                layer.closeAll();
            });
        }
        //绑定定时方法
        function MHBDing() {
            if (Alltr.length!=i) {
                $(".Tip").html($(Alltr[i]).attr("V_ID"));
                window.clearInterval(TimeFun);
                var Testid = $(Alltr[i]).attr("V_ID");
                indexTr = $(Alltr[i]);
                i++;
                var data = { type: "OneBD", id: id, Testid: Testid };
                $.post(url, data, MHbangDing, "json");
            } else {
                if (OKdata > 0) {
                    window.clearInterval(TimeFun);
                    //数据刷新
                    $(".Tip").html("");
                    $(".Titl").html("正在更新数据(时间可能会很长，请耐心等待)");
                    var Shuadada = { type: "ShuaXdada" };
                    $.post(url, Shuadada, ShuaXdata, "json");
                } else {
                    window.clearInterval(TimeFun);
                    layui.use('layer', function () {
                        var layer = layui.layer;
                        layer.alert('未找到需要绑定的数据', { icon: 6 }, function () {
                            CloseTip();

                        });
                    });
                }
                
            }
        }
        //解绑
        function JCBDing() {
            if (Alltr.length != i) {
                $(".Tip").html($(Alltr[i]).attr("V_ID"));
                window.clearInterval(TimeFun);
                var Testid = $(Alltr[i]).attr("V_ID");
                indexTr = $(Alltr[i]);
                i++;
                var data = { type: "MHJB", id: id, Testid: Testid };
                $.post(url, data, JBMHbangDing, "json");
            } else {
                if (OKdata > 0) {
                    window.clearInterval(TimeFun);
                    //数据刷新
                    $(".Tip").html("");
                    $(".Titl").html("正在更新数据(时间可能会很长，请耐心等待)");
                    var Shuadada = { type: "ShuaXdada" };
                    $.post(url, Shuadada, ShuaXdata, "json");
                } else {
                    window.clearInterval(TimeFun);
                    layui.use('layer', function () {
                        var layer = layui.layer;
                        layer.alert('未找到需要解绑的数据', { icon: 6 }, function () {
                            CloseTip();
                        });
                    });
                }
               
            }
        }
        //数据刷新
        function ShuaXdata(data) {
            if (data == "-10") {
                layer.closeAll();
                layer.alert('更新失败', { icon: 5 });
            } else if (data > 0) {
                layer.closeAll();
                layer.alert('更新成功', { icon: 6 });
            }
        }
        //模糊绑定回调
        function MHbangDing(data) {
            if (data=="1") {
                $(indexTr).html("绑定成功");
                OKdata++;
            } else if(data=="2") {
                $(indexTr).html("重复绑定").css("color","red");
            }
            
            TimeFun = window.setInterval(MHBDing, 500);
        }
        //模糊解绑
        function JBMHbangDing(data) {
            if (data == "1") {
                $(indexTr).html("解绑成功");
                OKdata++;
            } else if (data == "2") {
                $(indexTr).html("未绑定").css("color", "red");
            }
            TimeFun = window.setInterval(JCBDing, 500);
        }

    </script>





</body>
</html>
