<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="WebForm3.aspx.cs" Inherits="Webz.WebForm3" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
<meta http-equiv="Content-Type" content="text/html; charset=utf-8"/>
    <title></title>
    <style>
        * { font-size:36px; text-align:center;}
        .but {border-bottom:1px solid red; height:100px; width:100%; line-height:100px;}
     #alert { text-align:center;line-height:250px; font-size:46px; width: 67%; height: 350px; background-image: url(Images/Imgs/我的课程-对话框.png); background-size: 100% 100%; position: fixed; top: 30%; left: 17%; display:none; }</style>
</head>
<body>
    <form id="form1" runat="server">
        <div style="background-color:#6EBB4C; height:10000px;">
    <div id="iaa" style="height:500px; width:200px; background-color:aqua; position:fixed; top:50%; left:70%; display:none;">
        <div class="but" > 注册激活</div>
        <div  class="but"> denglu </div>
        <div  class="but"> yijian</div>
        <div class="but"> gerenzhongx</div>
        <div  class="but"> zhuxiao</div>
    </div>
            <div id="ge" style="position: fixed; bottom: 0; right:0; width: 33%; height: 300px; background-color: white;">个人中心</div>
        </div>
        <input type="hidden" id="aa" value="0"/>
    </form>
</body>
</html>
<script src="js/jquery.min.js"></script>
<script>
    $("#ge").click(function () {
        var i = $("#aa").val();
        
        if (i == "0") {
            $("#aa").val("1");
            $("#iaa").css("display", "block");
        } else {
            $("#aa").val("0");
            $("#iaa").css("display", "none");
        }
            
    })
    $(".but").click(function () {
        alert($(this).html());
    })
    var box = document.getElementById("ge");
    box.addEventListener("touchstart", function () {
        alert(length);
        var i = $("#aa").val();

        if (i == "0") {
            $("#aa").val("1");
            $("#iaa").css("display", "block");
        } else {
            $("#aa").val("0");
            $("#iaa").css("display", "none");
        }
        //$("#Img_Index").css("background-color", "red");
        //document.getElementById("Img_1").src = "Images/ernianji.png";
    })
    box.addEventListener("touchstart", function () {
        //alert("321");
        var i = $("#aa").val();

        if (i == "0") {
            $("#aa").val("1");
            $("#iaa").css("display", "block");
        } else {
            $("#aa").val("0");
            $("#iaa").css("display", "none");
        }
        //$("#Img_Index").css("background-color", "yellow");
        //document.getElementById("Img_1").src = "Images/gaoer.png";
    })
    //$("#Img_Index").mousedown(function () {
    //    $(this).css("background-color", "red");
    //})
    //$("#Img_Index").mouseup(function () {
    //    $(this).css("background-color", "yellow");
    //})
</script>
