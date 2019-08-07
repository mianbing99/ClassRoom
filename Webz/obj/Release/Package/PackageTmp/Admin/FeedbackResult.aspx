<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="FeedbackResult.aspx.cs" Inherits="Webz.Admin.FeedbackResult" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <meta http-equiv="Content-Type" content="text/html; charset=utf-8" />
    <script src="CC/jquery-3.3.1.js"></script>
    <script src="CC/layui-v2.4.5/layui/layui.js"></script>
    <link href="CC/layui-v2.4.5/layui/css/layui.css" rel="stylesheet" />
    <title></title>
    <style>
        table {
            border-collapse: collapse;
            border: none;
            width: 90%;
            margin: 0 auto;
            text-align: center;
        }
        td {
            padding-top:10px;
        
        }
        #text {
            text-align: center;
            color: #1464C7;
            font-size: 20px;
        }

        button {
            font-size: 12px;
            margin-left: 1%;
            height: 25.5px;
            width: 75px;
            background-color: #0F65CC;
            border: 1px solid #0F65CC;
            border-radius: 5px;
            color: #F2F2F2;
        }
    </style>
</head>
<body>
    <form id="form1" runat="server" class="layui-form" action="">
        <div style="height: 250px; width: 422px;margin:0 auto;">
            <table>
                <%--<tr>
                    <td id="text">反馈内容</td>
                </tr>
                <tr>
                    <td>
                        <textarea id="txtrNr" name="" required lay-verify="required" disabled="disabled" class="layui-textarea" style="height: 171px; width: 360px;"></textarea>
                    </td>
                </tr>--%>
                <tr>
                    <td id="text">处理结果</td>
                </tr>
                <tr>
                    <td>
                        <textarea id="txtrProcessing" name=""  required lay-verify="required" disabled="disabled" class="layui-textarea" style="height: 171px; width: 360px; resize:none; border-color:#0F65CC;"></textarea>

                    </td>
                </tr>
               <%-- <tr>
                    <td>
                        <button type="button" id="reset">重置</button>
                        <button  lay-submit lay-filter="formDemo">立即提交</button>
                    </td>
                </tr>--%>
            </table>
        </div>
    </form>
</body>
</html>

<script src="../js/cebianlan.js"></script>
<script>
    <%int id = Convert.ToInt32(Request.QueryString["FeedBackID"]);//获取传过来的id
      //根据ID查到该条数据
      Model.FeedBack fb = new BLL.FeedBackBLL().FeedBackByID(id);
      %>
    var FeedBackNR = "<%=fb.FeedBackNR%>", txtProcessing = "<%=fb.Processing%>";

    //取值
    //var Processing = $("#txtrProcessing").val();
    //赋值
    if (txtProcessing == "" || txtProcessing==null) {
        $("#txtrProcessing").val("此条反馈信息还未处理，没有结果信息！！！");
    }
    else {
        $("#txtrProcessing").val(txtProcessing);
    }
   

    //重置按钮
    //$("#reset").click(function () {
    //    $("#txtrProcessing").val("");
    //});

</script>

