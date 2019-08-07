<%

UpDir="shujukufangzheli"			'设置数据库所在目录(文件夹名称)。
title="某某da中学成绩查询系统"	'设置查询标题,相信你懂的。

copysr="某某da中学"	'设置底部版权文字,相信你懂的。
copysu="http://www.96448.cn/"	'设置底部版权连接,相信你懂的。

'设置查询条件
tiaojian1="姓名"  		'汉字是列标题，跟excel一致


'**************************************************
' 只需修改以上几个参数即可，无需修改以下内容
'**************************************************

'/**
' * 雪里开通用查询系统_AW1XF V7.7(LastEdit:2016-06-19) 
' * ======AW1XF:conn.asp======================================================================
' * 版权所有 (C) XueLiKai.Com，并保留所有权利。
' * 官方网址: http://Www.dbcha.com （请保留版权信息）
' * ------AW1XF:conn.asp----------------------------------------------------------------------
' * $Author: yujianyue <admin@ewuyi.net> $
' * $LastEdit: 2016-06-19 $
' * ------AW1XF:conn.asp----------------------------------------------------------------------
' * 代码不加密；你可以二次开发以便更适合你的需求 ，但不得：公开发布、公开销售。
' * 代码无域名、时间限制，非常通用；你可以安装多份，单位主体请购买本软件。
' * ======AW1XF:conn.asp======================================================================
'*/


' * 通用成绩查询系统解决方案(简单通用易用):

' * 方案4:微信公众号N选1个查询条件直接查询工资、成绩、水电费等
' * 自助开通试用:http://new.12391.net/ 
' * 视频教程下载:http://pan.baidu.com/s/1ge6BPEr 
' * 代码购买:https://item.taobao.com/item.htm?id=520496908275 
' * 整体服务:https://item.taobao.com/item.htm?id=529624346797 

' * 方案3(荐):微信公众号一对一绑定才可以查询工资、成绩、水电费等
' * 自助开通试用:http://add.96cha.com/ 
' * 代码购买:https://item.taobao.com/item.htm?id=44248394675 
' * 整体服务:https://item.taobao.com/item.htm?id=528187132312 

' * 方案2(荐):用户在线登录查询工资成绩水电费等，可自助修改密码
' * 自助开通试用:http://add.dbcha.com/ 
' * 视频教程下载:http://pan.baidu.com/s/1boANMwv 
' * 代码购买:https://item.taobao.com/item.htm?id=43193387085 
' * 整体服务:https://item.taobao.com/item.htm?id=528108807297 

' * 方案1:直接通过设定的（1-3个）查询条件查询
' * 免费即时开通:http://add.12391.net/ 
' * 视频教程下载:http://pan.baidu.com/s/1eSoDn26 
' * 代码购买:https://item.taobao.com/item.htm?id=528692002051 
' * 整体服务:https://item.taobao.com/item.htm?id=520023732507 

' * 代码版：不加密，无域名限制，无时间限制,一次付费一直可用(注：域名和网站空间费用另外自理)
' * 整体服务：无需域名 无需空间 无需代码 无需技术人员 无需备案，即开即用,按时间付费 


duan=tiaojian1

if len(tiaojian1)=2 then
 qianmian1=left(tiaojian1,1)&"&nbsp;&nbsp;"&right(tiaojian1,1)
else
 qianmian1=tiaojian1
end if
' * 50元:asp无需后台版(12款选1):
' * https://item.taobao.com/item.htm?id=45703415332 
mdbtype=".xls"  		'只能是xls格式文件哦不要修改
Function IsFile(FilePath)
	Set Fso=Server.CreateObject("Scri"&"pting.File"&"Sys"&"temObject")
	If (Fso.FileExists(Server.MapPath(FilePath))) Then
	IsFile=True
	Else
	IsFile=False
	End If
	Set Fso=Nothing
End Function
' * 60元:PHP无需后台版(36款选1):
' * https://item.taobao.com/item.htm?id=45808268273 
Function filekey(texts)
filekey=0
rekey="-/-\-%-@-.-"
keyes=split(rekey,"-")
nnnnn=Ubound(keyes)
For m=1 To Ubound(keyes)-1
rekeys=keyes(m)
rekeys=trim(rekeys)
if instr(texts,rekeys)>0 and len(rekeys)>0 then
filekey=filekey+1
end if
next
End Function
' * 108元:PHP多级下拉版(8款选1):
' * https://item.taobao.com/item.htm?id=43263796985 
'==============================
'函 数 名： AlertUrl(AlertStr,Url) 
'作    用：警告后转入指定页面
'==============================
Function AlertUrl(AlertStr,Url) 
 Response.Write "<script>" &vbcrlf
 Response.Write "alert('"&AlertStr&"');" &vbcrlf
 Response.Write "location.href='"&Url&"';" &vbcrlf
 Response.Write "</script>" &vbcrlf
 Response.End()
End Function
' * N选1精准查询系统解决方案(超过8款68元起):
' * https://item.taobao.com/item.htm?id=520167788658
Function AlertBack(AlertStr) 
 Response.Write "<script>" &vbcrlf
 Response.Write "alert('"&AlertStr&"');" &vbcrlf
 Response.Write "history.go(-1)" &vbcrlf
 Response.Write "</script>"&vbcrlf
 Response.End()
End Function
' * N选1模糊查询系统解决方案(超过8款68元起):
' * https://item.taobao.com/item.htm?id=520167788658 
%>