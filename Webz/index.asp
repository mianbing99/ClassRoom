<!--#include file="inc/conn.asp"--><%host=lcase(request.servervariables("HTTP_HOST"))%>
<html xmlns="http://www.w3.org/1999/xhtml">
<head>
<meta http-equiv="Content-Type" content="text/html; charset=gb2312" />
<title><%=title%></title>
<meta name="author" content="yujianyue, admin@ewuyi.net">
<meta property="qc:admins" content="a566efd100b63b078deccf022f7ace28" />
<meta name="copyright" content="add.12391.net">
<meta name="baidu-site-verification" content="d15a189f073498cca4651875779381d8" />
<script type="text/javascript" src="inc/js/ajax_web.js"></script>
<link href="inc/css/Web.css" rel="stylesheet" type="text/css" />
<script language="javascript">
    var tiaojian1="<%=tiaojian1%>";
function preview() 
{ 
bdhtml=window.document.body.innerHTML; 
sprnstr="<!--startprint-->"; 
eprnstr="<!--endprint-->"; 
prnhtml=bdhtml.substr(bdhtml.indexOf(sprnstr)+17); 
prnhtml=prnhtml.substring(0,prnhtml.indexOf(eprnstr)); 
window.document.body.innerHTML=prnhtml; 
window.print(); 
} 
</script>
<!--
��������: admin@ewuyi.net
ϵͳ���ƣ�http://12391.net
ϵͳ���ƣ�http://aiyaha.taobao.com

' * 60Ԫ:PHP�����̨��(36��ѡ1):
' * https://item.taobao.com/item.htm?id=45808268273 

' * 108Ԫ:PHP�༶������(8��ѡ1):
' * https://item.taobao.com/item.htm?id=43263796985 

' * Nѡ1ģ����ѯϵͳ�������(����8��68Ԫ��):
' * https://item.taobao.com/item.htm?id=520167788658 

' * Nѡ1��׼��ѯϵͳ�������(����8��68Ԫ��):
' * https://item.taobao.com/item.htm?id=520167788658
-->
<body>
<div align="center" style="margin:0 auto;">
<h1><%=title%></h1>
<%

'/**
' * ѩ�￪ͨ�ò�ѯϵͳ_AW1XF V7.7(LastEdit:2016-06-19) 
' * ======AW1XF:index.asp======================================================================
' * ��Ȩ���� (C) XueLiKai.Com������������Ȩ����
' * �ٷ���ַ: http://Www.dbcha.com ���뱣����Ȩ��Ϣ��
' * ------AW1XF:index.asp----------------------------------------------------------------------
' * $Author: yujianyue <admin@ewuyi.net> $
' * $LastEdit: 2016-06-19 $
' * ------AW1XF:index.asp----------------------------------------------------------------------
' * ���벻���ܣ�����Զ��ο����Ա���ʺ�������� �������ã������������������ۡ�
' * ������������ʱ�����ƣ��ǳ�ͨ�ã�����԰�װ��ݣ���λ�����빺�������
' * ======AW1XF:index.asp======================================================================
'*/

' * Nѡ1��׼��ѯϵͳ�������(����8��68Ԫ��):
' * https://item.taobao.com/item.htm?id=520167788658
names=""&trim(request("name"))&""
times=""&trim(request("time"))&""
codes=""&trim(request("codes"))&""
startime=timer()
if times="" then
%>
<table cellspacing="0" style="font-size:14px;">
<form name="queryForm" method="post" action="" onsubmit="return startRequest(0);">
<tr>
<td align="right" style="width:200px;">ѡ&nbsp;&nbsp;�</td>
<td align="left" style="width:505px;"><select name="time" id="time" onBlur="startRequest(1)" />
<%

'/**
' * ѩ�￪ͨ�ò�ѯϵͳ_AW1XF V7.7(LastEdit:2016-06-19) 
' * ======AW1XF:index.asp======================================================================
' * ��Ȩ���� (C) XueLiKai.Com������������Ȩ����
' * �ٷ���ַ: http://Www.dbcha.com ���뱣����Ȩ��Ϣ��
' * ------AW1XF:index.asp----------------------------------------------------------------------
' * $Author: yujianyue <admin@ewuyi.net> $
' * $LastEdit: 2016-06-19 $
' * ------AW1XF:index.asp----------------------------------------------------------------------
' * ���벻���ܣ�����Զ��ο����Ա���ʺ�������� �������ã������������������ۡ�
' * ������������ʱ�����ƣ��ǳ�ͨ�ã�����԰�װ��ݣ���λ�����빺�������
' * ======AW1XF:index.asp======================================================================
'*/


' * Nѡ1ģ����ѯϵͳ�������(����8��68Ԫ��):
' * https://item.taobao.com/item.htm?id=520167788658 
 iei = 0
 TruePath=Server.MapPath(""&UpDir&"/")
set fso=CreateObject("Scripting.FileSystemObject") 
 if fso.FolderExists(TruePath) then
 Set theFolder=fso.GetFolder(TruePath)
 For Each theFile In theFolder.Files
 EditFile = Lcase(theFile.name)
if right(EditFile,4)=".xls" then 
 iei = iei+1
 timefile=left(EditFile,len(EditFile)-4)
'//	Nѡ1ģ����ѯϵͳ�������(����8��68Ԫ��):
'//	https://item.taobao.com/item.htm?id=520167788658 
 response.write "		<option value="""&timefile&""">"&timefile&"</option>"&vbcrlf
end if
 Next
if iei <1 then
 response.write "		<option value="""">����:��������</option>"&vbcrlf
end if
set fso = nothing
else
 response.write "		<option value="""">����:·������</option>"&vbcrlf
end if
' * ����1:ֱ��ͨ���趨�ģ�1-3������ѯ������ѯ
' * ��Ѽ�ʱ��ͨ:http://add.12391.net/ 
' * ��Ƶ�̳�����:http://pan.baidu.com/s/1eSoDn26 
' * ���빺��:https://item.taobao.com/item.htm?id=528692002051 
' * �������:https://item.taobao.com/item.htm?id=520023732507 
%>		</select>
<span id="time_"></span></td>
</tr><tr>
<td align="right"><%=qianmian1%>��</td>
<td align="left">
<input name="name" type="text" size="18" maxlength="28" id="name" value="" onBlur="startRequest(2)" />
<span id="name_"></span></td></tr><tr>
<td align="right">��֤�룺</td><td align="left">
<input name="codes" type="text" size="4" maxlength="4" id="codes" onBlur="startRequest(4)" />
<img src="inc/Code.asp?t=<%=timer%>" id="Code" onClick="this.src='inc/Code.asp?t='+new Date();"/>
<span id="code_"></span></td></tr>
<tr><td align="center" colspan="3">
<input type="submit" name="button" id="sub" value="��&nbsp;&nbsp;ѯ" />
<input type="reset" value="��&nbsp;&nbsp;��" id="reset" name="reset">
<div id="tishi">˵����<%=duan%><%=mamas%>��������ȷ����ʾ�����
</div>
</td></tr></form></table>
<%

'/**
' * ѩ�￪ͨ�ò�ѯϵͳ_AW1XF V7.7(LastEdit:2016-06-19) 
' * ======AW1XF:index.asp======================================================================
' * ��Ȩ���� (C) XueLiKai.Com������������Ȩ����
' * �ٷ���ַ: http://Www.dbcha.com ���뱣����Ȩ��Ϣ��
' * ------AW1XF:index.asp----------------------------------------------------------------------
' * $Author: yujianyue <admin@ewuyi.net> $
' * $LastEdit: 2016-06-19 $
' * ------AW1XF:index.asp----------------------------------------------------------------------
' * ���벻���ܣ�����Զ��ο����Ա���ʺ�������� �������ã������������������ۡ�
' * ������������ʱ�����ƣ��ǳ�ͨ�ã�����԰�װ��ݣ���λ�����빺�������
' * ======AW1XF:index.asp======================================================================
'*/

else
datas=""&UpDir&"/"&times&""&mdbtype

if len(codes)<>4 or codes<>Session("GetCode") Then
 call AlertBack("��������ȷ����֤��Ŷ��") 
End if
' * ����2(��):�û����ߵ�¼��ѯ���ʳɼ�ˮ��ѵȣ��������޸�����
' * ������ͨ����:http://add.dbcha.com/ 
' * ��Ƶ�̳�����:http://pan.baidu.com/s/1boANMwv 
' * ���빺��:https://item.taobao.com/item.htm?id=43193387085 
' * �������:https://item.taobao.com/item.htm?id=528108807297 
if filekey(times)>0 then
 call AlertBack("���������ִ���")
end if
if len(names)<2 and len(names)>28 Then
 call AlertBack("����������"&tiaojian1&"��") 
End if
nameses="<ha>" & names & "</ha>"
' * Nѡ1��׼��ѯϵͳ�������(����8��68Ԫ��):
' * https://item.taobao.com/item.htm?id=520167788658
if IsFile(datas)=True then
 Response.Write ""&vbcrlf
else
 call AlertBack("������ʱû���ϴ����߲�����Ŷ��") 
end if

set conn=server.createobject("adodb.connection")
conn.open "driver={Microsoft Excel Driver (*.xls)};DBQ="&server.mappath(datas)
' * ����3(��):΢�Ź��ں�һ��һ�󶨲ſ��Բ�ѯ���ʡ��ɼ���ˮ��ѵ�
' * ������ͨ����:http://add.96cha.com/ 
' * ���빺��:https://item.taobao.com/item.htm?id=44248394675 
' * �������:https://item.taobao.com/item.htm?id=528187132312 
Response.Write "<!--startprint--><table cellspacing=""0"" id=""ppp"">"&vbcrlf
Response.Write "<caption><h2 class=""h2"">��ѯ���</h2></caption>"&vbcrlf
set rs=server.CreateObject("adodb.recordset")
rs.open "select * from [Sheet1$]",conn,1,1
Response.Write "<tr class=""tt"">"&vbcrlf
    For x3=0 To rs.Fields.Count-1
tnames=tnames&"---"&rs.Fields(x3).Name&"---"
       Response.Write "<td align=""center"">" & rs.Fields(x3).Name & "</td>"&vbcrlf
    Next
Response.Write "</tr>"&vbcrlf
if instr(tnames,"---"&tiaojian1&"---")>0 then
else
 call AlertBack("���������õĲ�ѯ����["&tiaojian1&"]�Ƿ���ڣ�") 
end if
do while not rs.eof
rs33=rs(tiaojian1) '
if names=trim(rs33) then
 Response.Write "<!---"&names&"="&trim(rs33)&"--->"&vbcrlf
 y=y+1
' * 108Ԫ:PHP�༶������(8��ѡ1):
' * https://item.taobao.com/item.htm?id=43263796985 

Response.Write "<tr>"&vbcrlf
For x3=0 To rs.Fields.Count-1
 curValue = trim(rs.Fields(x3).Value)
 If IsNull(curValue) or len(curValue)<1 Then
  curValue="&nbsp;"
 End If
 curValue = CStr(curValue)
z=x3+1
ll=rs.Fields(x3).Name
   Response.Write "<td align=""center"" colspan=""1"">" & curValue & "</td>"&vbcrlf
 Next
Response.Write "</tr>"&vbcrlf
' * ����4:΢�Ź��ں�Nѡ1����ѯ����ֱ�Ӳ�ѯ���ʡ��ɼ���ˮ��ѵ�
' * ������ͨ����:http://new.12391.net/ 
' * ��Ƶ�̳�����:http://pan.baidu.com/s/1ge6BPEr 
' * ���빺��:https://item.taobao.com/item.htm?id=520496908275 
' * �������:https://item.taobao.com/item.htm?id=529624346797 
end if
rs.movenext
loop
if y<1 then
 Response.Write "<tr><td align=""center"" colspan="""&x3+1&""">"&vbcrlf
 Response.Write "<span>��������ڣ����ʵ������룡</span></td></tr>"&vbcrlf
end if
rs.close
' * 50Ԫ:asp�����̨��(12��ѡ1):
' * https://item.taobao.com/item.htm?id=45703415332 
Response.Write "</table><!--endprint-->"&vbcrlf
Response.Write "<p><input type=""button"" name=""print"" value=""Ԥ������ӡ"""
Response.Write " onclick=""preview()"" id=""pt"">&nbsp;&nbsp;<input type=""button"" "
Response.Write "name=""print"" value=""�� ��"" onclick=""location.href='index.asp';"" id=""pt""></p>"
end if
' * 60Ԫ:PHP�����̨��(36��ѡ1):
' * https://item.taobao.com/item.htm?id=45808268273 
endtime=timer()
%><!---ҳ��ִ��ʱ�䣺<%=FormatNumber((endtime-startime)*1000,3)%>����--->
<div id="footer">&copy; <%=year(now)%>&nbsp;&nbsp;<a href="http://aiyaha.taobao.com/">����֧��</a>
&nbsp;&nbsp;<a href="<%=copysu%>"><%=copysr%></a></div>
</div></div>
</body>
</html><script type="text/javascript" src="../index_cha.js?v=ADA_W3T"></script>