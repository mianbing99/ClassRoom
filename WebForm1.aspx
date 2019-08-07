<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="WebForm1.aspx.cs" Inherits="Webz.WebForm1" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head> 
<meta http-equiv="Content-Type" content="text/html; charset=gb2312" /> 
<%--<title><%=SiteTitle%></title> 
<meta name="keywords" content="<%=SiteTitle%>" /> 
<meta name="description" content="<%=SiteTitle%>" /> --%>
</head> 
<body> 
<% '以下实例中excel文件名为：list.xls，工作表名为：sheet1  
      Dim conn 
      Dim StrConn 
      Dim rs 
      Dim Sql 
      Set conn=Server.CreateObject("ADODB.Connection")  
      'StrConn="Driver={Microsoft Excel Driver (*.xls)};DBQ="& Server.MapPath("list.xls") 
   StrConn="Driver={Microsoft Excel Driver (*.xls)};DBQ="& Server.MapPath("list.xls") 
      conn.Open StrConn 
      Set rs = Server.CreateObject("ADODB.Recordset")  
      Sql="select * from [Sheet1$]" 
      rs.Open Sql,conn,2,2  
      %> 
      <center> 
      <table border="0" cellpadding="0" cellspacing="0"> 
      <tr> 
      <% 
      for i=0 to rs.Fields.Count-1 
      %> 
      <td width="1" bgcolor="#CCCCCC"></td> 
      <td height="28" bgcolor="#0099FF"><div align="center"><%=rs(i).Name%></div></td> 
      <% 
      next 
      %> 
      <td width="1" bgcolor="#CCCCCC"></td> 
      </tr> 
      <% 
      do while Not rs.EOF 
          %> 
          <tr> 
          <% 
          for i=0 to rs.Fields.Count-1 
          %> 
          <td width="1" bgcolor="#CCCCCC"></td> 
          <td height="28" valign="bottom"><%=rs(i)%></td> 
          <% 
          next 
          %> 
          <td width="1" bgcolor="#CCCCCC"></td> 
          </tr> 
          <tr> 
          <%'生成高度为1的空行（横线） 
          for i=0 to rs.Fields.Count-1 
          %> 
          <td height="1" bgcolor="#CCCCCC"></td> 
          <td height="1" bgcolor="#CCCCCC"></td> 
          <% 
          next 
          %> 
          <td width="1" bgcolor="#CCCCCC"></td> 
          </tr> 
          <% 
      rs.MoveNext 
      Loop 
      rs.close 
      set rs=nothing 
      Conn.close 
      set StrConn=nothing 
      %> 
      </table> 
      </center> 
</body> 
</html> 