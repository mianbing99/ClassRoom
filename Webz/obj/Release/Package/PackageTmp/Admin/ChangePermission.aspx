<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="ChangePermission.aspx.cs" Inherits="Webz.Admin.ChangePermission" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
<meta http-equiv="Content-Type" content="text/html; charset=utf-8"/>
    <title>账号管理 > 更改账号权限</title>
    <style>
        body{
            
        }
        .dd{
            width:310px;
            height:20px;
            border-radius:5px;
            background-color:#EBEBEB;
        }
        .first{
            position:absolute;
            left:50%;
            top:40px;
            text-align:center;
        }
        .cent{
            position:absolute;
            left:60px;
            top:40px;
        }
        #three{
            position:absolute;
            left:60px;
            top:80px;
            
        }
        #three select::-ms-expand {
        display: none;
         }
        #three select {
            padding-left: 1%;
            font-size: 13px;
            text-align: center;
            appearance: none;
            -moz-appearance: none;
            -webkit-appearance: none;
            background: url(Admin\Img\下拉框年级和科目未展开时.png) no-repeat scroll right center transparent;
            background-image: url(Img/下拉框年级和科目未展开时.png);
            padding-right: 14px;
        }
        .table-b{
            position:absolute;
            top:150px;
            left:60px;
        }
        .table-b table{
            border:1px;
            border-collapse:collapse;
            position:absolute;
            top:25px;
            left:70px;
        }
        .table-b table tr{
            border:1px solid #699DEC;
        }
        .table-b table td{
            border:0px solid #699DEC;
            text-align: center;
        }
        #txyiwh1{
            display:inline-block;
            width:20px;
            height:30px;
            background:url(Admin\Img\打勾16.png)  no-repeat;
            background-image: url(Img/打勾16.png);
            position: relative;
            top: 15.5px;

        }
        #txyiwh2{
            display:inline-block;
            width:20px;
            height:30px;
            background:url(Admin\Img\打勾16.png)  no-repeat;
            background-image: url(Img/打勾16.png);
            position: relative;
            top: 15.5px;

        }
        #txyiwh3{
            display:inline-block;
            width:20px;
            height:30px;
            background:url(Admin\Img\打勾16.png)  no-repeat;
            background-image: url(Img/打勾16.png);
            position: relative;
            top: 15.5px;

        }
        #txyiwh4{
            display:inline-block;
            width:20px;
            height:30px;
            background:url(Admin\Img\打勾16.png)  no-repeat;
            background-image: url(Img/打勾16.png);
            position: relative;
            top: 15.5px;

        }
        #txyiwh5{
            display:inline-block;
            width:20px;
            height:30px;
            background:url(Admin\Img\打勾16.png)  no-repeat;
            background-image: url(Img/打勾16.png);
            position: relative;
            top: 15.5px;

        }
        #txyiwh6{
            display:inline-block;
            width:20px;
            height:30px;
            background:url(Admin\Img\打勾16.png)  no-repeat;
            background-image: url(Img/打勾16.png);
            position: relative;
            top: 15.5px;

        }
        #txyiwh7{
            display:inline-block;
            width:20px;
            height:30px;
            background:url(Admin\Img\打勾16.png)  no-repeat;
            background-image: url(Img/打勾16.png);
            position: relative;
            top: 15.5px;

        }
        #txyiwh8{
            display:inline-block;
            width:20px;
            height:30px;
            background:url(Admin\Img\打勾16.png)  no-repeat;
            background-image: url(Img/打勾16.png);
            position: relative;
            top: 15.5px;
        }
        #txyiwh9{
            display:inline-block;
            width:20px;
            height:30px;
            background:url(Admin\Img\打勾16.png)  no-repeat;
            background-image: url(Img/打勾16.png);
            position: relative;
            top: 15.5px;

        }
        #txyiwh10{
            display:inline-block;
            width:20px;
            height:30px;
            background:url(Admin\Img\打勾16.png)  no-repeat;
            background-image: url(Img/打勾16.png);
            position: relative;
            top: 15.5px;

        }
        #txyiwh11{
            display:inline-block;
            width:20px;
            height:30px;
            background:url(Admin\Img\打勾16.png)  no-repeat;
            background-image: url(Img/打勾16.png);
            position: relative;
            top: 15.5px;

        }
        #txyiwh12{
            display:inline-block;
            width:20px;
            height:30px;
            background:url(Admin\Img\打勾16.png)  no-repeat;
            background-image: url(Img/打勾16.png);
            position: relative;
            top: 15.5px;

        }
        #txyiwh13{
            display:inline-block;
            width:20px;
            height:30px;
            background:url(Admin\Img\打勾16.png)  no-repeat;
            background-image: url(Img/打勾16.png);
            position: relative;
            top: 15.5px;
        }
        #txyiwh14{
            display:inline-block;
            width:20px;
            height:30px;
            background:url(Admin\Img\打勾16.png)  no-repeat;
            background-image: url(Img/打勾16.png);
            position: relative;
            top: 15.5px;
        }
        #txyiwh15{
            display:inline-block;
            width:20px;
            height:30px;
            background:url(Admin\Img\打勾16.png)  no-repeat;
            background-image: url(Img/打勾16.png);
            position: relative;
            top: 15.5px;
        }
        #txyiwh16{
            display:inline-block;
            width:20px;
            height:30px;
            background:url(Admin\Img\打勾16.png)  no-repeat;
            background-image: url(Img/打勾16.png);
            position: relative;
            top: 15.5px;
        }
        #txyiwh17{
            display:inline-block;
            width:20px;
            height:30px;
            background:url(Admin\Img\打勾16.png)  no-repeat;
            background-image: url(Img/打勾16.png);
            position: relative;
            top: 15.5px;
        }
        #txyiwh18{
            display:inline-block;
            width:20px;
            height:30px;
            background:url(Admin\Img\打勾16.png)  no-repeat;
            background-image: url(Img/打勾16.png);
            position: relative;
            top: 15.5px;
        }
        #txyiwh19{
            display:inline-block;
            width:20px;
            height:30px;
            background:url(Admin\Img\打勾16.png)  no-repeat;
            background-image: url(Img/打勾16.png);
            position: relative;
            top: 15.5px;
        }
        #txyiwh20{
            display:inline-block;
            width:20px;
            height:30px;
            background:url(Admin\Img\打勾16.png)  no-repeat;
            background-image: url(Img/打勾16.png);
            position: relative;
            top: 15.5px;
        }
        #txyiwh21{
            display:inline-block;
            width:20px;
            height:30px;
            background:url(Admin\Img\打勾16.png)  no-repeat;
            background-image: url(Img/打勾16.png);
            position: relative;
            top: 15.5px;
        }
        input[type=radio] {
            visibility: hidden;
            display: none;
        }
        #btnShow{
            width:80px;
            height:30px;
            color:white;
            text-align:center;
            background-color:#1E90FF ;
            border-radius:5px 5px 5px 5px;
            position:absolute;
            left:520px;
            top:450px;
        }
        .container {
            width:1100px;
            height:700px;
            position: absolute; width: 100%; left: 1%;
            line-height:40px;
        }

    </style>
    
</head>
<body>
    <form id="form1" runat="server">
    <div>
        <div class="ss" style="font-size: 12px;margin-left:12px;"><div>当前位置：账号管理 > 更改账号权限</div></div>
        <div class="container">
            <div class="cent">
                用户名：<asp:TextBox ID="txtName" CssClass="dd" runat="server"></asp:TextBox>
            </div>
                <div class="first">
                    &nbsp&nbsp&nbsp新密码：<asp:TextBox ID="txtXPwd" CssClass="dd" runat="server"></asp:TextBox><br/>
                    确认密码：<asp:TextBox ID="txtQuePwd" CssClass="dd" runat="server"></asp:TextBox>
                </div>
                <div id="three" >
                角&nbsp&nbsp&nbsp色：<asp:DropDownList ID="ddlRole" CssClass="jiaose" runat="server" style="width:150px;height:26px;border-radius:5px;border: 1px solid #699DEC;"></asp:DropDownList>
                                     <input type="hidden" value="1" /><br/>
                状&nbsp&nbsp&nbsp态：<asp:DropDownList ID="ddlState" CssClass="Select1" runat="server" style="width:150px;height:26px; border-radius:5px;border: 1px solid #699DEC;"></asp:DropDownList>
                                     <input type="hidden" value="0" />
                </div>
            <div class="table-b">
                <p>权&nbsp&nbsp&nbsp限：</p>
                <table width="950" border="0" cellspacing="0" cellpadding="0">
                    <tr>
                        <td width="218" style="color:white;background-color:#63B8FF;">视频资源管理：</td>
                        <td width="122"><input type="hidden" name="chekname" value="0" /><span id="txyiwh1"></span><input type="radio" id="Radio1" name="chetiaojian" runat="server"  checked="true" />新增</td>
                        <td width="122"><input type="hidden" name="chekname" value="0" /><span id="txyiwh2"></span><input type="radio" id="Radio2" name="chetiaojian" runat="server"  checked="true" />导入</td>
                        <td width="122"><input type="hidden" name="chekname" value="0" /><span id="txyiwh3"></span><input type="radio" id="Radio3" name="chetiaojian" runat="server"  checked="true" />导出</td>
                        <td width="122"><input type="hidden" name="chekname" value="0" /><span id="txyiwh4"></span><input type="radio" id="Radio4" name="chetiaojian" runat="server"  checked="true" />修改</td>
                        <td width="122"><input type="hidden" name="chekname" value="0" /><span id="txyiwh5"></span><input type="radio" id="Radio5" name="chetiaojian" runat="server"  checked="true" />删除</td>
                        <td width="122"><input type="hidden" name="chekname" value="0" /><span id="txyiwh6"></span><input type="radio" id="Radio6" name="chetiaojian" runat="server"  checked="true" />查看</td>
                    </tr>
                    <tr>
                        <td style="color:white;background-color:#63B8FF;">教材目录管理：</td>
                        <td><input type="hidden" name="chekname" value="0" /><span id="txyiwh7"></span><input type="radio" id="CheckBox1" name="chetiaojian" runat="server"  checked="true" />新增</td>
                        <td><input type="hidden" name="chekname" value="0" /><span id="txyiwh8"></span><input type="radio" id="CheckBox2" name="chetiaojian" runat="server"  />导入</td>
                        <td><input type="hidden" name="chekname" value="0" /><span id="txyiwh9"></span><input type="radio" id="CheckBox3" name="chetiaojian" runat="server" />导出</td>
                        <td><input type="hidden" name="chekname" value="0" /><span id="txyiwh10"></span><input type="radio" id="CheckBox4" name="chetiaojian" runat="server"  />修改</td>
                        <td><input type="hidden" name="chekname" value="0" /><span id="txyiwh11"></span><input type="radio" id="CheckBox5" name="chetiaojian" runat="server"  />删除</td>
                        <td><input type="hidden" name="chekname" value="0" /><span id="txyiwh12"></span><input type="radio" id="CheckBox6" name="chetiaojian" runat="server" />查看</td>
                    </tr>
                    <tr>
                        <td style="color:white;background-color:#63B8FF;">视频匹配：</td>
                        <td><input type="hidden" name="chekname" value="0" /><span id="txyiwh13"></span><input type="radio" id="CheckBox7" name="chetiaojian" runat="server"  />新增</td>
                        <td><input type="hidden" name="chekname" value="0" /><span id="txyiwh14"></span><input type="radio" id="CheckBox8" name="chetiaojian" runat="server"  />导入</td>
                        <td><input type="hidden" name="chekname" value="0" /><span id="txyiwh15"></span><input type="radio" id="CheckBox9" name="chetiaojian" runat="server" />导出</td>
                        <td><input type="hidden" name="chekname" value="0" /><span id="txyiwh16"></span><input type="radio" id="CheckBox10" name="chetiaojian" runat="server" />修改</td>
                        <td><input type="hidden" name="chekname" value="0" /><span id="txyiwh17"></span><input type="radio" id="CheckBox11" name="chetiaojian" runat="server" />删除</td>
                        <td><input type="hidden" name="chekname" value="0" /><span id="txyiwh18"></span><input type="radio" id="CheckBox12" name="chetiaojian" runat="server"  />查看</td>
                    </tr>
                    <tr>
                        <td style="color:white;background-color:#63B8FF;">用户统计：</td>
                        <td><input type="hidden" name="chekname" value="0" /><span id="txyiwh19"></span><input type="radio" id="CheckBox13" name="chetiaojian" runat="server" />导出</td>
                        <td><input type="hidden" name="chekname" value="0" /><span id="txyiwh20"></span><input type="radio" id="CheckBox14" name="chetiaojian" runat="server" />查看</td>
                        <td></td>
                        <td></td>
                        <td></td>
                        <td></td>
                    </tr>
                    <tr >
                        <td style="color:white;background-color:#63B8FF;">意见反馈：</td>
                        <td><input type="hidden" name="chekname" value="0" /><span id="txyiwh21"></span><input type="radio" id="CheckBox15" name="chetiaojian" runat="server" />查看</td>
                        <td></td>
                        <td></td>
                        <td></td>
                        <td></td>
                        <td></td>
                    </tr>
                </table>
            </div>
            <div><asp:Button ID="btnShow" runat="server" Text="新增" OnClick="btnShow_Click" /></div>
        </div>
    </div>
    </form>
</body>
</html>

<script src="../js/video.js"></script>
<script src="../Scripts/jquery-1.8.2.min.js"></script>
<script src="../js/cebianlan.js"></script>
<script src="../js/ChangePermission.js"></script>
<script>
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
</script>
