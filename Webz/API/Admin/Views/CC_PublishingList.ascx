<%@ Control Language="C#" AutoEventWireup="true" CodeBehind="CC_PublishingList.ascx.cs" Inherits="Webz.Admin.Views.CC_PublishingList" %>

<select class="Select1" style="width:300px;">
    <option value="0">选择出版社</option>
    <%
        List<Model.Press> list = new BLL.CC_PressBLL().GetALLPressList();
        foreach (var item in list)
        {
            
       
         %>
    <option value="<%=item.Prid %>"><%=item.PrName %></option>
    <%  }%>
</select>
<input type="hidden" value="0" />