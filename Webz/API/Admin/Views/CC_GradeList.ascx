<%@ Control Language="C#" AutoEventWireup="true" CodeBehind="CC_GradeList.ascx.cs" Inherits="Webz.Admin.Views.CC_SubjectList" %>
<select class="nianji">
    <option value="0">请选择年级</option>
    <%
        List<Model.Grade> list = new BLL.CC_GradeBLL().GetAllGradeList();
        foreach (var item in list)
        {
    %>
    <option value="<%=item.GradeID %>"><%=item.GrName %></option>


    <%  
    }
    %>
</select>
<input type="hidden" value="0" />