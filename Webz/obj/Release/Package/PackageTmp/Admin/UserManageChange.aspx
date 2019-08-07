<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="UserManageChange.aspx.cs" Inherits="Webz.Admin.UserManageChange" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <meta http-equiv="Content-Type" content="text/html; charset=utf-8" />
    <script src="CC/jquery-3.3.1.js"></script>
    <script src="CC/layui-v2.4.5/layui/layui.js"></script>
    <link href="CC/layui-v2.4.5/layui.css" rel="stylesheet" />
    <title></title>
    <style>
        table {
            border-collapse: collapse;
            border: 1px solid #000000;
            width: 90%;
            margin: 0 auto;
            text-align: center;
        }

        td {
            line-height: 50px;
             border: 1px solid #000000;
        }

        .text {
            text-align: right;
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
    <form id="form1" class="layui-form" action="" method="post" runat="server">
        <%--<div>
        <div class="layui-form-item">
            <label class="layui-form-label">管理员名称：</label>
            <div class="layui-input-block">
                <input type="text" name="title" required lay-verify="required" placeholder="请输入标题" autocomplete="off" class="layui-input">
            </div>
        </div>
        <div class="layui-form-item">
            <label class="layui-form-label">管理员密码：</label>
            <div class="layui-input-block">
                <input type="text" name="title" required lay-verify="required" placeholder="请输入标题" autocomplete="off" class="layui-input">
            </div>
        </div>
        <div class="layui-form-item">
            <label class="layui-form-label">管理员角色：</label>
            <div class="layui-input-block">
                <select name="city" lay-verify="required">
                    <option value="">请选择角色</option>
                    <%
                        List<Model.Roles> list = new BLL.RolesBLL().GetAllRolesList();
                        foreach (var item in list)
                        {
                    %>
                    <option value="<%=item.RolesID %>"><%=item.RoleName %></option>


                    <%  
                                }
                    %>
                </select>
            </div>
        </div>
        <div class="layui-form-item">
    <div class="layui-input-block">
         <button type="button" id="reset" class="layui-btn layui-btn-normal">重置</button>
         <button lay-submit lay-filter="formDemo" class="layui-btn layui-btn-normal">新增</button>
    </div>
  </div>
            </div>--%>
        <div style="height: 500px; width: 422px; margin: 0 auto; border:1px solid #ff0000">
        <table>
            <tr>
                <td class="text">管理员名称：</td>
                <td ">
                    <input type="text" name="title" required lay-verify="required" placeholder="请输入管理员名称" autocomplete="off" class="layui-input"></td>
            </tr>
            <tr>    
                <td class="text">管理员密码：</td>
                <td >
                    <input type="text" name="title" required lay-verify="required" placeholder="请输入管理员名称" autocomplete="off" class="layui-input"></td>
            </tr>
            <tr>
                <td class="text">管理员角色：</td>
                <td >
                    <select name="city" lay-verify="" style="display:block;height: 30px;width: 167px;">
                        <option value="0" >请选择角色</option>
                        <%
                            List<Model.Roles> list = new BLL.RolesBLL().GetAllRolesList();
                            foreach (var item in list)
                            {
                        %>
                        <option value="<%=item.RolesID %>"><%=item.RoleName %></option>


                        <%  
                                }
                        %>
                    </select>
                </td>
            </tr>
            <tr>
                <td colspan="2">
                    <button type="button" id="reset" class="layui-btn layui-btn-normal">重置</button>
                    <button lay-submit lay-filter="formDemo" class="layui-btn layui-btn-normal">新增</button>
                </td>
                
            </tr>
        </table>
            </div>
    </form>
</body>
</html>
