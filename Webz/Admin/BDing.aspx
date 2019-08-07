<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="BDing.aspx.cs" Inherits="Webz.Admin.BDing" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">

<head runat="server">
    <meta http-equiv="Content-Type" content="text/html; charset=utf-8" />
    <title></title>
    <script src="CC/jquery-3.3.1.js"></script>
    <script src="CC/layui-v2.4.5/layui/layui.js"></script>
    <script src="CC/layui-v2.4.5/layui/lay/modules/layer.js"></script>
    <link href="CC/layui-v2.4.5/layui/css/modules/layer/default/layer.css" rel="stylesheet" />
    <link href="CC/layui-v2.4.5/layui/css/layui.css" rel="stylesheet" />
    
</head>
<body>

    <%
        int MoShi = Convert.ToInt32(Request.QueryString["DBMoshi"]);
        if (MoShi == 0)
        {
    %>
    
    <%--//绑定--%>
    <table class="layui-table" lay-size="sm" v_moshi="<%=MoShi %>">
        <%
            string arr = Request.QueryString["Arr"];
            List<Model.PageList> list = new BLL.CC_PageListBLL().GetIDPageList(arr);
        %>
        <thead>
            <tr>
                <th>序号</th>
                <th>课本名称</th>
                <th>目录</th>
                <th>匹配路径</th>
                <th>绑定状态</th>
            </tr>
        </thead>
        <tbody>
            <% 
            foreach (var item in list)
            {
		 
	
            %>
            <tr v_id="<%=item.TempID %>">
                <td><%=item.TempID %></td>
                <td><%=item.BooksName %></td>
                <td><%=item.ViName %></td>
                <%
                    if (item.匹配 != null && item.匹配 != "")
                    {
                %>
                <td><%=item.匹配 %></td>
                <td style="color: green" v_vlue="0">已绑定</td>
                <%    }
                    else
                    { %>
                <td><%=item.未匹配 %></td>
                <td style="color: red" v_vlue="1" name="WBD">未绑定</td>
                <%     }
                %>
            </tr>
            <%} %>
        </tbody >
    </table>
    <%
        }
        else
        {
    %>
    <%--//取消绑定--%>
        





    <table class="layui-table" lay-size="sm" v_moshi="<%=MoShi %>">
        <%
            string arr = Request.QueryString["Arr"];
            List<Model.PageList> list = new BLL.CC_PageListBLL().GetIDPageList(arr);
        %>
        <thead>
            <tr>
                <th>序号</th>
                <th>课本名称</th>
                <th>目录</th>
                <th>匹配路径</th>
                <th>绑定状态</th>
            </tr>
        </thead>
        <tbody>
            <% 
            foreach (var item in list)
            {
		 
	
            %>
            <tr v_id="<%=item.TempID %>">
                <td><%=item.TempID %></td>
                <td><%=item.BooksName %></td>
                <td><%=item.ViName %></td>
                <%
                    if (item.匹配 != null && item.匹配 != "")
                    {
                %>
                <td><%=item.匹配 %></td>
                <td style="color: green" v_vlue="0" name="YBD">已绑定</td>
                <%    }
                    else
                    { %>
                <td><%=item.未匹配 %></td>
                <td style="color: red" v_vlue="1" >未绑定</td>
                <%     }
                %>
            </tr>
            <%} %>
        </tbody >
    </table>








    <%} %>

    <script>
        $(function () {
            var BDurl="AjaxHelper/Ajax.ashx";
           
            var Moshi = $(".layui-table").attr("V_Moshi");
            //绑定对象
            var WBD = null;
            
            //需要绑定总数
            var count = null;
            var i = 0;
            var id = 0;//当前索引
            var Wbdduix = null;
            var t1 = null;
            //模式判断0.绑定，1.解绑
            if (Moshi == 0) {
                if ($("td[name='WBD']").parent().length>0) {
                    layer.msg('<span class=\'Titl\'>绑定序号:</span><span style=\'color: green\' class=\'Tip\'>未开始</span>', {
                        icon: 16
                            , shade: 0.01
                            , time: 99999999
                    });
                }
               
                DSBDing();
            } else {
                //数据解绑
                if ($("td[name='YBD']").parent().length > 0) {
                    layer.msg('<span class=\'Titl\'>解绑序号:</span><span style=\'color: green\' class=\'Tip\'>未开始</span>', {
                        icon: 16
                            , shade: 0.01
                            , time: 99999999
                    });
                }
                JBDing();
            }



            //绑定
            function DSBDing() {
                if (i!=count) {
                    t1 = window.setInterval(refreshCount, 500);
                } else {
                    $(".layui-layer-padding .Tip").html("");
                    $(".layui-layer-padding .Titl").html("正在更新数据(时间可能会很长，请耐心等待)");
                    //刷新数据
                    var Shuadada = { type: "ShuaXdada" };
                    $.post(BDurl, Shuadada, ShuaXdata, "json");

                }
            }
            //解绑
            function JBDing() {
                if (i != count) {
                    t1 = window.setInterval(JieChuBang, 500);
                } else {
                    $(".layui-layer-padding .Tip").html("");
                    $(".layui-layer-padding .Titl").html("正在更新数据(时间可能会很长，请耐心等待)");
                    //刷新数据
                    var Shuadada = { type: "ShuaXdada" };
                    $.post(BDurl, Shuadada, ShuaXdata, "json");

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

           //定时执行绑定
            function refreshCount() {
                WBD = $("td[name='WBD']").parent();
                count = WBD.length;
                //当前ID
                id = $(WBD[i]).attr("v_id");
                $(".layui-layer-padding .Tip").html(id);
                //当前对象
                Wbdduix = $(WBD[i]);
                //增加i的值
                i++;
                //去掉定时器的方法  
                window.clearInterval(t1);
                var BDdada ={type:"BDing",id:id};
                $.post(BDurl, BDdada, BDings, "json");
            }
            //定时执行解除绑定
            function JieChuBang() {
                WBD = $("td[name='YBD']").parent();
                count = WBD.length;
                //当前ID
                id = $(WBD[i]).attr("v_id");
                $(".layui-layer-padding .Tip").html(id);
                //当前对象
                Wbdduix = $(WBD[i]);
                //增加i的值
                i++;
                //去掉定时器的方法  
                window.clearInterval(t1);
                var JDings = { type: "JBDing", id: id };
                $.post(BDurl, JDings, JBDings, "json");
            }
            //绑定回调
            function BDings(data) {
                if (data == 1) {
                    $(Wbdduix).find(" td[name='WBD']").html("绑定成功").css("color", "green");
                    DSBDing();
                } else {
                    $(Wbdduix).find(" td[name='WBD']").html("绑定失败");
                    DSBDing();
                }
                
            }
            //解绑回调
            function JBDings(data) {
                if (data == 1) {
                    $(Wbdduix).find(" td[name='YBD']").html("已解除绑定").css("color", "green");
                    JBDing();
                } else {
                    $(Wbdduix).find(" td[name='YBD']").html("解除失败");
                    JBDing();
                }

            }
        })
    </script>

</body>
</html>
