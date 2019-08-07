function loadcebian() {
    var tr = "<div id=\"cebian\"><div><span>视频源管理</span></div><div><span>教材目录管理</span></div><div id=\"CB_VideoPi\" class=\"xiala\"> <span> 视频匹配</span>";
    tr += "<div class=\"border\"><span>模糊匹配</span></div><div><span>批量匹配</span></div></div><div id=\"CB_User\" class=\"xiala\">";
    tr += "<span>用户统计</span><div class=\"border\"><span>注册统计</span></div><div><span>播放统计</span></div></div><div><span>意见反馈</span></div>";
    tr += "<div id=\"CB_Admin\" class=\"xiala\"><span>账号管理</span> <div class=\"border\"><span>修改密码</span></div><div><span>更改账号权限</span></div>";
    tr += "</div><div><span>退出</span></div></div>";
    $("#count_l").html(tr);
}
function loadTop(id) {
}