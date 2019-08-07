var $=function(node){
return document.getElementById(node);
}
function $(objId){
return document.getElementById(objId);
}
function changeImg(){
    $("code").src="Code.asp?"+Math.random();
}
document.onkeydown = function(e){
 if(!e) e = window.event;
 if((e.keyCode || e.which) == 13){
 document.getElementById("sub").click();
}
}
function startRequest(Num) {
var queryString;
if(Num == 1 || Num == 0){
var times=$("time").value.replace(/(^\s+)|(\s+$)/g, "");//去除前后的空格
if($("time").value == ""){
$('time').style.borderColor='red';
$("time_").innerHTML="请先选择类型选项！";
return false;
}else{
$('time').style.borderColor='green';
$("time_").innerHTML = "<img src=\"inc/img/pass.gif\" align=\"absmiddle\" />"
}
}
var names=$("name").value.replace(/(^\s+)|(\s+$)/g, "");//去除前后的空格
if(Num == 2 || Num == 0){
if($("name").value == ""){
//if (!names.match(/^[\u4e00-\u9fa5]{2,8}$/)) {
$('name').style.borderColor='red';
 $("name_").innerHTML = "<span>请认真输入"+tiaojian1+"！</span>";
return false;
}else{
$('name').style.borderColor='green';
$("name_").innerHTML = "<img src=\"inc/img/pass.gif\" align=\"absmiddle\" />"
}
}
var codes=$("codes").value.replace(/(^\s+)|(\s+$)/g, "");//去除前后的空格
if(Num == 4 || Num == 0){
if (!codes.match(/^[0-9]{4}$/)){
$('codes').style.borderColor='red';
$("code_").innerHTML="请输入4位数字验证码哦！";
return false;
}else{
$('codes').style.borderColor='green';
$("code_").innerHTML="<img src=\"inc/img/pass.gif\" align=\"absmiddle\" />";
//$("tishi").innerHTML="<div>完成输入，点击查询按钮查询！</div>";
}
}
if(Num == "0"){
$("sub").submit();
return false;
}
}