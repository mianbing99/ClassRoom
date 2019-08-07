<%@ Control Language="C#" AutoEventWireup="true" CodeBehind="CC_SubjectList.ascx.cs" Inherits="Webz.Admin.Views.CC_SubjectList1" %>
<select class="SelSuName">
    <option value="0">请选择科目</option>
<%
    List<Model.Subject> list = new BLL.CC_SubjectBLL().GetAllSubjectLsit();
    foreach (var item in list)
    {
        %>
        <option value="<%=item.Suid %>"><%=item.SuName %></option>
    <%
    }
     %>
</select>
<input type="hidden" value="0" />