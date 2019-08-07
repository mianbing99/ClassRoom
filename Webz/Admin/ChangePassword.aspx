<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="ChangePassword.aspx.cs" Inherits="Webz.Admin.ChangePassword" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
<meta http-equiv="Content-Type" content="text/html; charset=utf-8"/>
    <title></title>
    <style>
        #btnCancel{
            position:absolute;
            left:1020px;
            width:80px;
            height:30px;
            color:white;
            background-color:#1E90FF ;
            border-radius:5px 5px 5px 5px;
        }
        #btnShow{
            width:80px;
            height:30px;
            color:white;
            text-align:center;
            background-color:#1E90FF ;
            border-radius:5px 5px 5px 5px;
            position:absolute;
            left:490px;
            top:450px;

        }
        body{
            position: absolute; width: 100%; left: 1%;
        }
        .send{
            line-height:40px;
            position:absolute;
            left:60px;
            top:60px;
        }
        .dd{
            width:310px;
            height:20px;
            border-radius:5px 5px 5px 5px;
        }
        .first{
            position:absolute;
            left:28px;
            top:190px;
        }
    </style>
</head>
<body>
    <form id="form1" runat="server">
    <div>
        <div class="ss" style="font-size: 12px;">当前位置：账号管理 > 修改密码</div>
            <asp:Button ID="btnCancel" runat="server" Text="取消" OnClick="btnCancel_Click" /><br/>
                <div class="send">
                    用户名：<asp:TextBox ID="txtName" CssClass="dd" runat="server"></asp:TextBox><br/>
                    原密码：<asp:TextBox ID="txtYPwd" CssClass="dd" runat="server"></asp:TextBox><br/>
                    新密码：<asp:TextBox ID="txtXpwd" CssClass="dd" runat="server"></asp:TextBox><br/>
                </div>
                 <div class="first">
                    确认新密码：<asp:TextBox ID="txtQuePwd" CssClass="dd" runat="server"></asp:TextBox><br/>
                  </div>
            <asp:Button ID="btnShow" runat="server" Text="确认" OnClick="btnShow_Click" />
    </div>
    </form>
</body>
</html>
