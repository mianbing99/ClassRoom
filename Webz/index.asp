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
作者邮箱: admin@ewuyi.net
系统定制：http://12391.net
系统定制：http://aiyaha.taobao.com

' * 60元:PHP无需后台版(36款选1):
' * https://item.taobao.com/item.htm?id=45808268273 

' * 108元:PHP多级下拉版(8款选1):
' * https://item.taobao.com/item.htm?id=43263796985 

' * N选1模糊查询系统解决方案(超过8款68元起):
' * https://item.taobao.com/item.htm?id=520167788658 

' * N选1精准查询系统解决方案(超过8款68元起):
' * https://item.taobao.com/item.htm?id=520167788658
-->
<body>
<div align="center" style="margin:0 auto;">
<h1><%=title%></h1>
<%

'/**
' * 雪里开通用查询系统_AW1XF V7.7(LastEdit:2016-06-19) 
' * ======AW1XF:index.asp======================================================================
' * 版权所有 (C) XueLiKai.Com，并保留所有权利。
' * 官方网址: http://Www.dbcha.com （请保留版权信息）
' * ------AW1XF:index.asp----------------------------------------------------------------------
' * $Author: yujianyue <admin@ewuyi.net> $
' * $LastEdit: 2016-06-19 $
' * ------AW1XF:index.asp----------------------------------------------------------------------
' * 代码不加密；你可以二次开发以便更适合你的需求 ，但不得：公开发布、公开销售。
' * 代码无域名、时间限制，非常通用；你可以安装多份，单位主体请购买本软件。
' * ======AW1XF:index.asp======================================================================
'*/

' * N选1精准查询系统解决方案(超过8款68元起):
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
<td align="right" style="width:200px;">选&nbsp;&nbsp;项：</td>
<td align="left" style="width:505px;"><select name="time" id="time" onBlur="startRequest(1)" />
<%

'/**
' * 雪里开通用查询系统_AW1XF V7.7(LastEdit:2016-06-19) 
' * ======AW1XF:index.asp======================================================================
' * 版权所有 (C) XueLiKai.Com，并保留所有权利。
' * 官方网址: http://Www.dbcha.com （请保留版权信息）
' * ------AW1XF:index.asp----------------------------------------------------------------------
' * $Author: yujianyue <admin@ewuyi.net> $
' * $LastEdit: 2016-06-19 $
' * ------AW1XF:index.asp----------------------------------------------------------------------
' * 代码不加密；你可以二次开发以便更适合你的需求 ，但不得：公开发布、公开销售。
' * 代码无域名、时间限制，非常通用；你可以安装多份，单位主体请购买本软件。
' * ======AW1XF:index.asp======================================================================
'*/


' * N选1模糊查询系统解决方案(超过8款68元起):
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
'//	N选1模糊查询系统解决方案(超过8款68元起):
'//	https://item.taobao.com/item.htm?id=520167788658 
 response.write "		<option value="""&timefile&""">"&timefile&"</option>"&vbcrlf
end if
 Next
if iei <1 then
 response.write "		<option value="""">提醒:尚无数据</option>"&vbcrlf
end if
set fso = nothing
else
 response.write "		<option value="""">提醒:路径不对</option>"&vbcrlf
end if
' * 方案1:直接通过设定的（1-3个）查询条件查询
' * 免费即时开通:http://add.12391.net/ 
' * 视频教程下载:http://pan.baidu.com/s/1eSoDn26 
' * 代码购买:https://item.taobao.com/item.htm?id=528692002051 
' * 整体服务:https://item.taobao.com/item.htm?id=520023732507 
%>		</select>
<span id="time_"></span></td>
</tr><tr>
<td align="right"><%=qianmian1%>：</td>
<td align="left">
<input name="name" type="text" size="18" maxlength="28" id="name" value="" onBlur="startRequest(2)" />
<span id="name_"></span></td></tr><tr>
<td align="right">验证码：</td><td align="left">
<input name="codes" type="text" size="4" maxlength="4" id="codes" onBlur="startRequest(4)" />
<img src="inc/Code.asp?t=<%=timer%>" id="Code" onClick="this.src='inc/Code.asp?t='+new Date();"/>
<span id="code_"></span></td></tr>
<tr><td align="center" colspan="3">
<input type="submit" name="button" id="sub" value="查&nbsp;&nbsp;询" />
<input type="reset" value="重&nbsp;&nbsp;置" id="reset" name="reset">
<div id="tishi">说明：<%=duan%><%=mamas%>都输入正确才显示结果。
</div>
</td></tr></form></table>
<%

'/**
' * 雪里开通用查询系统_AW1XF V7.7(LastEdit:2016-06-19) 
' * ======AW1XF:index.asp======================================================================
' * 版权所有 (C) XueLiKai.Com，并保留所有权利。
' * 官方网址: http://Www.dbcha.com （请保留版权信息）
' * ------AW1XF:index.asp----------------------------------------------------------------------
' * $Author: yujianyue <admin@ewuyi.net> $
' * $LastEdit: 2016-06-19 $
' * ------AW1XF:index.asp----------------------------------------------------------------------
' * 代码不加密；你可以二次开发以便更适合你的需求 ，但不得：公开发布、公开销售。
' * 代码无域名、时间限制，非常通用；你可以安装多份，单位主体请购买本软件。
' * ======AW1XF:index.asp======================================================================
'*/

else
datas=""&UpDir&"/"&times&""&mdbtype

if len(codes)<>4 or codes<>Session("GetCode") Then
 call AlertBack("请输入正确的验证码哦！") 
End if
' * 方案2(荐):用户在线登录查询工资成绩水电费等，可自助修改密码
' * 自助开通试用:http://add.dbcha.com/ 
' * 视频教程下载:http://pan.baidu.com/s/1boANMwv 
' * 代码购买:https://item.taobao.com/item.htm?id=43193387085 
' * 整体服务:https://item.taobao.com/item.htm?id=528108807297 
if filekey(times)>0 then
 call AlertBack("请检查连接字串！")
end if
if len(names)<2 and len(names)>28 Then
 call AlertBack("请认真输入"&tiaojian1&"！") 
End if
nameses="<ha>" & names & "</ha>"
' * N选1精准查询系统解决方案(超过8款68元起):
' * https://item.taobao.com/item.htm?id=520167788658
if IsFile(datas)=True then
 Response.Write ""&vbcrlf
else
 call AlertBack("数据暂时没有上传或者不存在哦！") 
end if

set conn=server.createobject("adodb.connection")
conn.open "driver={Microsoft Excel Driver (*.xls)};DBQ="&server.mappath(datas)
' * 方案3(荐):微信公众号一对一绑定才可以查询工资、成绩、水电费等
' * 自助开通试用:http://add.96cha.com/ 
' * 代码购买:https://item.taobao.com/item.htm?id=44248394675 
' * 整体服务:https://item.taobao.com/item.htm?id=528187132312 
Response.Write "<!--startprint--><table cellspacing=""0"" id=""ppp"">"&vbcrlf
Response.Write "<caption><h2 class=""h2"">查询结果</h2></caption>"&vbcrlf
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
 call AlertBack("请检查你设置的查询条件["&tiaojian1&"]是否存在！") 
end if
do while not rs.eof
rs33=rs(tiaojian1) '
if names=trim(rs33) then
 Response.Write "<!---"&names&"="&trim(rs33)&"--->"&vbcrlf
 y=y+1
' * 108元:PHP多级下拉版(8款选1):
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
' * 方案4:微信公众号N选1个查询条件直接查询工资、成绩、水电费等
' * 自助开通试用:http://new.12391.net/ 
' * 视频教程下载:http://pan.baidu.com/s/1ge6BPEr 
' * 代码购买:https://item.taobao.com/item.htm?id=520496908275 
' * 整体服务:https://item.taobao.com/item.htm?id=529624346797 
end if
rs.movenext
loop
if y<1 then
 Response.Write "<tr><td align=""center"" colspan="""&x3+1&""">"&vbcrlf
 Response.Write "<span>结果不存在，请核实你的输入！</span></td></tr>"&vbcrlf
end if
rs.close
' * 50元:asp无需后台版(12款选1):
' * https://item.taobao.com/item.htm?id=45703415332 
Response.Write "</table><!--endprint-->"&vbcrlf
Response.Write "<p><input type=""button"" name=""print"" value=""预览并打印"""
Response.Write " onclick=""preview()"" id=""pt"">&nbsp;&nbsp;<input type=""button"" "
Response.Write "name=""print"" value=""返 回"" onclick=""location.href='index.asp';"" id=""pt""></p>"
end if
' * 60元:PHP无需后台版(36款选1):
' * https://item.taobao.com/item.htm?id=45808268273 
endtime=timer()
%><!---页面执行时间：<%=FormatNumber((endtime-startime)*1000,3)%>毫秒--->
<div id="footer">&copy; <%=year(now)%>&nbsp;&nbsp;<a href="http://aiyaha.taobao.com/">技术支持</a>
&nbsp;&nbsp;<a href="<%=copysu%>"><%=copysr%></a></div>
</div></div>
</body>
</html><script type="text/javascript" src="../index_cha.js?v=ADA_W3T"></script>