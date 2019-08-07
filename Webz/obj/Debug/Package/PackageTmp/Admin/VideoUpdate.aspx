<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="VideoUpdate.aspx.cs" Inherits="Webz.Admin.VideoUpdate" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
<meta http-equiv="Content-Type" content="text/html; charset=utf-8"/>
    <title>修改视频</title>
    <link type="text/css" rel="stylesheet" href="../CSS/VideoUpdate.css"/>
    <script src="../js/jquery.min.js"></script>
</head>
<body>
    <form id="form1" runat="server">
    <div>
        <div style="min-height: 600px;">

                <div id="rightcontent">
                    <div>
                        <div style="font-size: 12px;margin-left:12px;">当前位置：视频源管理>修改视频</div>

                        <div class="container">
                            <div class="container-body">
                                <div class="container-title">
                                   
                                    <div class="title"></div>
                                    <div class="vrid" style="display:none;"></div>
                                </div>

                                <div class="container-info">
                                    <div class="setringbox">
                                           <div class="status">
                                               <div class="status-title"><p>&nbsp;状态&nbsp;:</p></div>

                                               <div class="status-value">
                                                   <select name="ddlRole" id="ddlRole" class="stateSelect" style="width: 150px; height: 26px; border-radius: 5px; border: 1px solid #C0C0C0;background-color:#C0C0C0; background-image: url(&quot;Img/下拉框课本名称未展开时.png&quot;);">
	                                                        <option value="1">启用</option>
	                                                        <option value="0">禁止</option>
                                                    </select>
                                               </div>

                                           </div>
                                            <div class="path">
                                                <div class="path-title"><p>MP4&nbsp;路径&nbsp;:</p></div>
                                               <div class="path-value"> <input class="MP4Path" type="text" style="width:400px;height:30px;border:1px solid #C0C0C0; border-radius: 5px; background-color:#C0C0C0;" value=""/></div>
                                            </div>
                                    </div>

                                    <div class="setringbox">
                                        <div class="status">
                                                    <div class="status-title"><p>V&nbsp;I&nbsp;P&nbsp;:</p></div>

                                                    <div class="status-value">
                                                        <select name="ddlRole" id="ddlRole"  class="vipSelect" style="width: 150px; height: 26px; border-radius: 5px; border: 1px solid #C0C0C0;background-color:#C0C0C0; background-image: url(&quot;Img/下拉框课本名称未展开时.png&quot;);">
	                                                        <option value="0">免费</option>
	                                                        <option value="1">VIP</option>
                                                        </select>
                                                    </div>
                                            </div>

                                        <div class="path">
                                            <div class="path-title"><p>HTV&nbsp;路径&nbsp;:</p></div>
                                           <div class="path-value"> <input class="HTVPath" type="text" style="width:400px;height:30px;border:1px solid #C0C0C0; border-radius: 5px; background-color:#C0C0C0;" value=""/></div>
                                        </div>
                                    </div>
                                </div>
                                <div class="button">
                                    <div class="btnbox">
                                        <input class="cancelbox" type="button" name='' id=''  value="取消"  />
                                       
                                    </div>
                                    <div class="btnbox">
                                        <input class="updatebox" type="button" id="updatebox"  value="修改"  />
                                       
                                    </div>
                                </div>
                        </div>
                    </div>
                </div>
            </div>
        </div>
    </div>
    </form>
    <script>
        window.onload = function ()
        {
            function load()
            {
                $.ajax({
                    type: "post",
                    url: "AjaxHelper/VideoResourceManager.ashx",
                    data: "action=videoInfoSelect&VRID=<%=Request.QueryString["VRID"]%>",
                    dataType:"json",
                    success: function (data)
                    {
                        $(".title").html(data.ViName);
                        $(".vrid").html(data.VRID);
                        $(".stateSelect option[value='" + data.State + "']").attr("selected", true);
                        $(".vipSelect").find("option[value='" + data.Vip + "']").attr("selected", true);
                        $(".MP4Path").val(data.Mp4);
                        $(".HTVPath").val(data.HTV);
                    }
                })
            }
            load();

            $(".cancelbox").on("click", function (){
                window.location.href = "videoResourceManager.aspx";
            });
            
            $(".updatebox").on("click", function () {
                var vrid = $(".vrid").html();
                var state = $(".stateSelect").find("option:selected").val();
                var vip = $(".vipSelect").find("option:selected").val();
                var mp4 = $(".MP4Path").val();
                var htv = $(".HTVPath").val();
                //alert(vrid + "," + state + "," + vip + "," + mp4 + "," + htv);
                $.ajax({
                    type:"post",
                    url: "AjaxHelper/VideoResourceManager.ashx",
                    data: { action: "videoInfoUpdate", VRID: vrid, State: state, Vip: vip, Mp4: mp4, HTV: htv },
                    dataType:"json",
                    success: function (data) {
                        if (data > 0) {
                            alert("修改成功");
                            window.location.href = "VideoResourceManager.aspx";
                        }
                        else
                        {
                            alert("修改失败");
                        }
                    }
                })
                //var data = { type: "videoInfoUpdate", VRID: 5021, State: 1, Vip: 1, Mp4: "bbb", HTV: "555" }
                //$.post("AjaxHelper/Ajax.ashx", data, updatInfo, "json");
                //alert("11");
            })
            
        }
    </script>
</body>
</html>
