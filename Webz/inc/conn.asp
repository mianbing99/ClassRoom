<%

UpDir="shujukufangzheli"			'�������ݿ�����Ŀ¼(�ļ�������)��
title="ĳĳda��ѧ�ɼ���ѯϵͳ"	'���ò�ѯ����,�����㶮�ġ�

copysr="ĳĳda��ѧ"	'���õײ���Ȩ����,�����㶮�ġ�
copysu="http://www.96448.cn/"	'���õײ���Ȩ����,�����㶮�ġ�

'���ò�ѯ����
tiaojian1="����"  		'�������б��⣬��excelһ��


'**************************************************
' ֻ���޸����ϼ����������ɣ������޸���������
'**************************************************

'/**
' * ѩ�￪ͨ�ò�ѯϵͳ_AW1XF V7.7(LastEdit:2016-06-19) 
' * ======AW1XF:conn.asp======================================================================
' * ��Ȩ���� (C) XueLiKai.Com������������Ȩ����
' * �ٷ���ַ: http://Www.dbcha.com ���뱣����Ȩ��Ϣ��
' * ------AW1XF:conn.asp----------------------------------------------------------------------
' * $Author: yujianyue <admin@ewuyi.net> $
' * $LastEdit: 2016-06-19 $
' * ------AW1XF:conn.asp----------------------------------------------------------------------
' * ���벻���ܣ�����Զ��ο����Ա���ʺ�������� �������ã������������������ۡ�
' * ������������ʱ�����ƣ��ǳ�ͨ�ã�����԰�װ��ݣ���λ�����빺�������
' * ======AW1XF:conn.asp======================================================================
'*/


' * ͨ�óɼ���ѯϵͳ�������(��ͨ������):

' * ����4:΢�Ź��ں�Nѡ1����ѯ����ֱ�Ӳ�ѯ���ʡ��ɼ���ˮ��ѵ�
' * ������ͨ����:http://new.12391.net/ 
' * ��Ƶ�̳�����:http://pan.baidu.com/s/1ge6BPEr 
' * ���빺��:https://item.taobao.com/item.htm?id=520496908275 
' * �������:https://item.taobao.com/item.htm?id=529624346797 

' * ����3(��):΢�Ź��ں�һ��һ�󶨲ſ��Բ�ѯ���ʡ��ɼ���ˮ��ѵ�
' * ������ͨ����:http://add.96cha.com/ 
' * ���빺��:https://item.taobao.com/item.htm?id=44248394675 
' * �������:https://item.taobao.com/item.htm?id=528187132312 

' * ����2(��):�û����ߵ�¼��ѯ���ʳɼ�ˮ��ѵȣ��������޸�����
' * ������ͨ����:http://add.dbcha.com/ 
' * ��Ƶ�̳�����:http://pan.baidu.com/s/1boANMwv 
' * ���빺��:https://item.taobao.com/item.htm?id=43193387085 
' * �������:https://item.taobao.com/item.htm?id=528108807297 

' * ����1:ֱ��ͨ���趨�ģ�1-3������ѯ������ѯ
' * ��Ѽ�ʱ��ͨ:http://add.12391.net/ 
' * ��Ƶ�̳�����:http://pan.baidu.com/s/1eSoDn26 
' * ���빺��:https://item.taobao.com/item.htm?id=528692002051 
' * �������:https://item.taobao.com/item.htm?id=520023732507 

' * ����棺�����ܣ����������ƣ���ʱ������,һ�θ���һֱ����(ע����������վ�ռ������������)
' * ��������������� ����ռ� ������� ���輼����Ա ���豸������������,��ʱ�丶�� 


duan=tiaojian1

if len(tiaojian1)=2 then
 qianmian1=left(tiaojian1,1)&"&nbsp;&nbsp;"&right(tiaojian1,1)
else
 qianmian1=tiaojian1
end if
' * 50Ԫ:asp�����̨��(12��ѡ1):
' * https://item.taobao.com/item.htm?id=45703415332 
mdbtype=".xls"  		'ֻ����xls��ʽ�ļ�Ŷ��Ҫ�޸�
Function IsFile(FilePath)
	Set Fso=Server.CreateObject("Scri"&"pting.File"&"Sys"&"temObject")
	If (Fso.FileExists(Server.MapPath(FilePath))) Then
	IsFile=True
	Else
	IsFile=False
	End If
	Set Fso=Nothing
End Function
' * 60Ԫ:PHP�����̨��(36��ѡ1):
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
' * 108Ԫ:PHP�༶������(8��ѡ1):
' * https://item.taobao.com/item.htm?id=43263796985 
'==============================
'�� �� ���� AlertUrl(AlertStr,Url) 
'��    �ã������ת��ָ��ҳ��
'==============================
Function AlertUrl(AlertStr,Url) 
 Response.Write "<script>" &vbcrlf
 Response.Write "alert('"&AlertStr&"');" &vbcrlf
 Response.Write "location.href='"&Url&"';" &vbcrlf
 Response.Write "</script>" &vbcrlf
 Response.End()
End Function
' * Nѡ1��׼��ѯϵͳ�������(����8��68Ԫ��):
' * https://item.taobao.com/item.htm?id=520167788658
Function AlertBack(AlertStr) 
 Response.Write "<script>" &vbcrlf
 Response.Write "alert('"&AlertStr&"');" &vbcrlf
 Response.Write "history.go(-1)" &vbcrlf
 Response.Write "</script>"&vbcrlf
 Response.End()
End Function
' * Nѡ1ģ����ѯϵͳ�������(����8��68Ԫ��):
' * https://item.taobao.com/item.htm?id=520167788658 
%>