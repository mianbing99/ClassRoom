<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="SelectVideo.aspx.cs" Inherits="Webz.Admin.SelectVideo" %>

<%@ Register Assembly="AspNetPager" Namespace="Wuqi.Webdiyer" TagPrefix="webdiyer" %>



<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <meta http-equiv="Content-Type" content="text/html; charset=utf-8" />
    <title></title>
    <link href="../CSS/cebianlan.css" rel="stylesheet" />
    <style>
        table { margin-top:2%; border-right: 2px solid #2473D1; border-bottom: 2px solid #2473D1; border-collapse: collapse; width:100%; font-size:14px;}
        table td { border-left: 2px solid #2473D1; border-top: 2px solid #2473D1; }
        table tr { height:40px;}
        .tdname { width:200px;}
        .tdpath { width:227px;}
        .tdcaname { width:140px;}
          .yulan { margin-left: 10%; }
        .Video { position: fixed; top: 10%; left: 15%; width: 80%; height: 450px; background-color: aqua; display: none; }
        #tishi { width: 60px; height: 100px; position: fixed; right: 20px; top: 30%; background-color: #99CE84; }
        #Video { margin:20px 0px 20px 0px;}
        .But { margin-left:86%;}
        #TxtName {height:35px; border-radius:5px; border:1px solid #699DEC;}
        #Button4 { margin-left:3%; height:25px; background-color:#0F65CC; border:1px solid #0F65CC; border-radius:5px; color:#F2F2F2}
        #Button3 { margin-left:3%; height:35px; background-color:#0F65CC; border:1px solid #0F65CC; border-radius:5px;color:#F2F2F2}
        #Button1 { margin-left:1%; height:25px; background-color:#0F65CC; border:1px solid #0F65CC; border-radius:5px; color:#F2F2F2}
        #CheckBox3 { margin-left:2%;}
        #nianji { width:10%; height:25px; margin-left:3%; border-radius:5px; border:1px solid #699DEC;}
        #SelSuName {width:10%; height:25px; margin-left:3%; border-radius:5px; border:1px solid #699DEC;}
        #select1 { margin-left:3%; height:25px; border-radius:5px; border:1px solid #699DEC;}  
    </style>
</head>
<body>
    <form id="form1" runat="server">
         <div id="top"></div>
        <div style="min-height:600px;">
           <div id="count_l"></div>
            <div style="position:absolute; top:100px; width:80%; left:18%;">
                  <div style=" margin-top:1%;">
                <div style="background-color:#9FBFFF; height:30px; line-height:30px;">
            <select id="nianji" runat="server">
                <option value="">---全部年级---</option>
                <option value="一年级">---一年级---</option>
                <option value="二年级">---二年级---</option>
                <option value="三年级">---三年级---</option>
                <option value="四年级">---四年级---</option>
                <option value="五年级">---五年级---</option>
                <option value="六年级">---六年级---</option>
                <option value="七年级">---七年级---</option>
                <option value="八年级">---八年级---</option>
                <option value="九年级">---九年级---</option>
                <option value="高一">---高一---</option>
                <option value="高二">---高二---</option>
                <option value="高三">---高三---</option>
            </select>
            <select id="SelSuName" runat="server">
                <option value="语文">---语文---</option>
                <option value="数学">---数学---</option>
                <option value="英语">---英语---</option>
                <option value="物理">---物理---</option>
                <option value="化学">---化学---</option>
                <option value="生物">---生物---</option>
                <option value="历史">---历史---</option>
                <option value="政治">---政治---</option>
                <option value="地理">---地理---</option>
            </select>
            <select id="Select1" runat="server">
                <option value="">---全部出版社---</option>
                <option value="人民教育出版社">---人民教育出版社---</option>
                <option value="人民教育出版社 A版">---人民教育出版社 A版---</option>
                <option value="人民教育出版社 B版">---人民教育出版社 B版---</option>
                <option value="人民教育出版社(SL一年级起点)">---人民教育出版社(SL一年级起点)---</option>
                <option value="人民教育出版社(PEP三年级起点)">---人民教育出版社(PEP三年级起点)---</option>
                <option value="人民教育出版社(精通三年级起点)">---人民教育出版社(精通三年级起点)---</option>
                <option value="人民教育出版社(灵通三年级起点)">---人民教育出版社(灵通三年级起点)---</option>
                <option value="江苏凤凰教育出版社">---江苏凤凰教育出版社---</option>
                <option value="江苏凤凰科学技术出版社">---江苏凤凰科学技术出版社---</option>
                <option value="江苏教育出版社">---江苏教育出版社---</option>
                <option value="江苏人民出版社">---江苏人民出版社---</option>
                <option value="凤凰出版传媒集团/译林出版社">---凤凰出版传媒集团/译林出版社---</option>
                <option value="北京师范大学出版社">---北京师范大学出版社---</option>
                <option value="北京出版社/北京师范大学出版社">---北京出版社/北京师范大学出版社---</option>
                <option value="北京师范大学出版社(一年级起点)">---北京师范大学出版社(一年级起点)---</option>
                <option value="北京师范大学出版社(三年级起点)">---北京师范大学出版社(三年级起点)---</option>
                <option value="外语教学与研究出版社(新标准一年级起点)">---外语教学与研究出版社(新标准一年级起点)---</option>
                <option value="外语教学与研究出版社(新标准三年级起点)">---外语教学与研究出版社(新标准三年级起点)---</option>
                <option value="外语教学与研究出版社(Join In三年级起点)">---外语教学与研究出版社(Join In三年级起点)---</option>
                <option value="语文出版社">---语文出版社---</option>
                <option value="外语教学与研究出版社">---外语教学与研究出版社---</option>
                <option value="湖南师范大学出版社">---湖南师范大学出版社---</option>
                <option value="湖南教育出版社">---湖南教育出版社---</option>
                <option value="湖南少年儿童出版社(一年级起点)">---湖南少年儿童出版社(一年级起点)---</option>
                <option value="湖南少年儿童出版社(三年级起点)">---湖南少年儿童出版社(三年级起点)---</option>
                <option value="湖南教育出版社/山东教育出版社(三年级起点)">---湖南教育出版社/山东教育出版社(三年级起点)---</option>
                <option value="科学普及出版社">---科学普及出版社---</option>
                <option value="译林出版社">---译林出版社---</option>
                <option value="长春出版社">---长春出版社---</option>
                <option value="西南师范大学出版社">---西南师范大学出版社---</option>
                <option value="译林出版社(三年级起点)">---译林出版社(三年级起点)---</option>
            </select>
                     <input type="radio" id="CheckBox3" name="chetiaojian" runat="server" checked="true"  />全部
            <input type="radio" id="CheckBox1" name="chetiaojian" runat="server" />已匹配
            <input type="radio" id="CheckBox2" name="chetiaojian" runat="server" />未匹配
                    <asp:Button ID="Button4" runat="server" Text="导出当前页" OnClick="Button4_Click" />
                         <asp:Button ID="Button1" runat="server" Text="导出当前全部" OnClick="Button1_Click" />
           </div>
                <div style="margin-top:1%; margin-left:70%;">
            <input type="text" value="" id="TxtName" runat="server" placeholder="这里输入查找的课文名称" />
                     <asp:Button ID="Button3" runat="server" Width="80px" Text="查找" OnClick="Button3_Click" />
            
                    </div>
                </div>
            <table>
                <tr style="height:30px; background-color:#9FBFFF;">
                    <td style="width:40px;">序号</td>
                    <td style="width:250px;">书名</td>
                    <td style="width:160px;">课文名称</td>
                    <td style="width:200px;">已匹配路径</td>
                    <td style="width:200px;">未匹配路径</td>
                    <td style="width:100px;">模糊匹配</td>
                    <%--<td style="width:100px;"></td>--%>
                </tr>
                <asp:Repeater ID="Repeater1" runat="server">
                    <ItemTemplate>
                        <tr>
                            <td style="width:40px;"><%#Eval("Nub")%>  </td>
                            <td  style="width:250px;"><%#Eval("BooksName") %></td>
                            <td style="width:160px;"><%#Eval("CaName") %></td>
                            <td style="width:200px;"><%#Eval("mp4") %></td>
                            <td style="width:200px;"><%#Eval("testmp4") %></td>
                            <td style="width:100px;"><a href="Video?Caname=<%#Eval("Caname") %>&caid=<%#Eval("caid") %>&BooksName=<%#Eval("BooksName") %>&pages=<%=pages %>">匹配</a></td>
                          <%--  <td>
                                <input type="checkbox" name="chek" value="" /></td>--%>
                        </tr>
                    </ItemTemplate>
                </asp:Repeater>
            </table>
           <div style=" width:80%;">
               <%--<input type="button" id="bangding" value="绑定" style="width: 60px;" />--%>
            <webdiyer:AspNetPager class="arPage" PageSize="20" UrlPaging="true"
                runat="server" ID="pgServer"
                CustomInfoHTML="共%PageCount%页记录<span>|</span>每页<em>%PageSize%</em>条<span>|</span>当前第<em>%CurrentPageIndex%</em>页"
                FirstPageText="首页" LastPageText="尾页" NextPageText="下一页" PrevPageText="上一页"
                ShowCustomInfoSection="Left" Height="18px">
            </webdiyer:AspNetPager>
           </div>
            </div>
          
        </div>

    </form>
</body>
</html>
<script src="../Scripts/jquery-1.8.2.min.js"></script>
<script src="../js/cebianlan.js"></script>
<script>
    $(function () {
        loadcebian();
        $.ajax({
            url: '../ashx/Video.ashx',
            type: 'post',
            datatype: "json",
            data: { action: "chek" },
            success: function (data) {
                if (data == "yi") {
                    $("#CheckBox1").attr("checked", true);
                } else if (data == "wei") {
                    $("#CheckBox2").attr("checked", true);
                } else if (data == "quan") {
                    $("#CheckBox3").attr("checked", true);
                }
            }
        })
        $.ajax({
            url: '../ashx/UserInfo.ashx',
            type: 'post',
            datatype: "json",
            data: { action: "GrName" },
            success: function (data) {
                var jsonobj = eval("(" + data + ")");
                for (var it in jsonobj) {
                    $("#Select1").append(" <option value=" + jsonobj[it].Prs + ">---" + jsonobj[it].Prs + "---</option>");
                }
            }
        })
        $.ajax({
            url: '../ashx/Video.ashx',
            type: 'post',
            datatype: "json",
            data: { action: "LoadGr" },
            success: function (data) {
                var jie = String(data);
                var shuz = jie.split('|')
                for (var i = 0; i < shuz.length; i++) {
                    if (i == 0 && shuz[i] != "") {
                        $("#nianji  option[value='" + shuz[i] + "']").attr("selected", "selected")
                    } else if (i == 1 && shuz[i] != "") {
                        $("#SelSuName  option[value='" + shuz[i] + "']").attr("selected", "selected")
                    } else if (i == 2 && shuz[i] != "") {
                        $("#Select1  option[value='" + shuz[i] + "']").attr("selected", "selected")
                    } else if (i == 3 && shuz[i] != "") {
                        $("#TxtName").val(shuz[i]);
                    }
                }
            }
        })
        //alert($("#Tnianji").val());
        $("#nianji  option[value='" + $("#Tnianji").val() + "']").attr("selected", true)
    })

    $("body").on("click", ".xiala", function () {
        //alert($(this).html());
        $(this).find("div").animate({
            height: 'toggle'
        });
    })

    $("#Button3").click(function () {

        $("#Tnianji").val($("#nianji").val());
        $("#TSuName").val($("#SuName").val());
    })
</script>
