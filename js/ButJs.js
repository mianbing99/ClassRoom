
function sess(session) {

    if (session == "-1" || session == "") {
        $("#A_Login").attr("href", "Login.aspx");
        $("#Div_But_Login").html("登录");
       
    } else  {
        $("#A_Login").attr("href", "Loginout.aspx");
        $("#Div_But_Login").html("注销登录");
    }
}

function alert_queding(Text, Url) {
    $("#alert").css("display", "inline");
        $("#alert").html(Text + "<img id=\"Img_queding\" src=\"Images/Imgs/确定.png\" style=\"position:absolute; bottom:15%; left:33%; width:35%; height:25%; \"  />");
    }
function alert_queding_click(Url) {
    $("#alert").css("display", "none");
    $("#alert").html("");
    if (Url != undefined) {
        window.location.href = Url;
    }

}
var Img_Index = document.getElementById("Img_Index");
Img_Index.addEventListener("touchstart", function () {
    $("#Img_Index").attr("src", "Images/Imgs/首页-按下.png");
});
Img_Index.addEventListener("touchend", function () {
    window.location.href = "Index.aspx";
    $("#Img_Index").attr("src", "Images/Imgs/首页.png");
});
var Img_class = document.getElementById("Img_class");
Img_class.addEventListener("touchstart", function () {
    $("#Img_class").attr("src", "Images/Imgs/我的课程按钮-按下.png");
});
Img_class.addEventListener("touchend", function () {
    window.location.href = "BooksList.aspx";
    $("#Img_class").attr("src", "Images/Imgs/我的课程按钮.png");
});
var UserInfo = document.getElementById("UserInfo");
UserInfo.addEventListener("touchstart", function () {
    $("#UserInfo").attr("src", "Images/Imgs/个人中心按钮-按下.png");
});
UserInfo.addEventListener("touchend", function () {
    var i = $("#Usercaidan").val();

    if (i == "0") {
        $("#Usercaidan").val("1");
        $("#div_Usercaidan").css("display", "block");
    } else {
        $("#Usercaidan").val("0");
        $("#div_Usercaidan").css("display", "none");
    }
    $("#UserInfo").attr("src", "Images/Imgs/个人中心按钮.png");
});
//$("#UserInfo").click(function () {
//    var i = $("#Usercaidan").val();

//    if (i == "0") {
//        $("#Usercaidan").val("1");
//        $("#div_Usercaidan").css("display", "block");
//    } else {
//        $("#Usercaidan").val("0");
//        $("#div_Usercaidan").css("display", "none");
//    }

//});


