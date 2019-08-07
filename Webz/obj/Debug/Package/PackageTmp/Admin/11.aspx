<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="VideoPathUpdate.aspx.cs" Inherits="Webz.PathUpdate" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
<meta http-equiv="Content-Type" content="text/html; charset=utf-8"/>
    <title>修改视频</title>
    <link type="text/css" rel="stylesheet" href="../CSS/VideoPathUpdate.css"/>
    
</head>

    <%-- <div class="group">
                                            <div class="group-left">
                                                <h3 class="group-title">状态：</h3>
                                                <div>
                                                    <select name="ddlRole" id="ddlRole" class="jiaose" style="width: 150px; height: 26px; border-radius: 5px; border: 1px solid #C0C0C0;background-color:#C0C0C0; background-image: url(&quot;Img/下拉框课本名称未展开时.png&quot;);">
	                                                    <option value="1">超级管理员</option>
	                                                    <option value="2">测试员</option>
                                                    </select>
                                                </div>
                                            </div>
                                            <div class="group-right">
                                            <h3 class="group-num">MPV4路径：</h3>
                                            <div>
                                                <input class="group-path" type="text" style="width:200px;height:30px;border:1px solid #C0C0C0; border-radius: 5px; background-color:#C0C0C0;" value="11111"/>
                                            </div>
                                            </div>
                                        </div>--%>

                                        <%--<div class="setringbox-left">
                                            <div class="setringboxone">
                                                <p>状态：</p>
                                                <div class="st">

                                                </div>
                                                    
                                            
                                            </div>
                                        <div class="setringbox-right">

                                        </div>
                                         </div>--%>
<body>
    <form id="form1" runat="server">
    <div>
        <%--<h1>路径修改 vid:<%=  Convert.ToInt32(Request.QueryString["ViID"])%></h1>--%>
         <div style="min-height: 600px;">

                <div id="rightcontent">
                    <div>
                        <div style="font-size: 12px;margin-left:12px;">视频源管理>修改视频：</div>

                        <div class="container">
                            <div class="container-body">
                                <div class="container-title">
                                    <div class="title">百草</div>
                                </div>

                                <div class="container-info">
                                    <div class="setringbox">
                                           <div class="status">
                                               <div class="status-title"><p>&nbsp;状态&nbsp;:</p></div>

                                               <div class="status-value">
                                                   <select name="ddlRole" id="ddlRole" class="jiaose" style="width: 150px; height: 26px; border-radius: 5px; border: 1px solid #C0C0C0;background-color:#C0C0C0; background-image: url(&quot;Img/下拉框课本名称未展开时.png&quot;);">
	                                                        <option value="1">超级管理员</option>
	                                                        <option value="2">测试员</option>
                                                    </select>
                                               </div>

                                           </div>
                                            <div class="path">
                                                <div class="path-title"><p>MP4&nbsp;路径&nbsp;:</p></div>
                                               <div class="path-value"> <input class="group-path" type="text" style="width:100%;height:30px;border:1px solid #C0C0C0; border-radius: 5px; background-color:#C0C0C0;" value="11111"/></div>
                                            </div>
                                    </div>

                                    <div class="setringbox">
                                        <div class="status">
                                                    <div class="status-title"><p>V&nbsp;I&nbsp;P&nbsp;:</p></div>

                                                    <div class="status-value">
                                                        <select name="ddlRole" id="ddlRole" class="jiaose" style="width: 150px; height: 26px; border-radius: 5px; border: 1px solid #C0C0C0;background-color:#C0C0C0; background-image: url(&quot;Img/下拉框课本名称未展开时.png&quot;);">
	                                                        <option value="1">超级管理员</option>
	                                                        <option value="2">测试员</option>
                                                        </select>
                                                    </div>
                                            </div>

                                        <div class="path">
                                            <div class="path-title"><p>HTV&nbsp;路径&nbsp;:</p></div>
                                           <div class="path-value"> <input class="group-path" type="text" style="width:100%;height:30px;border:1px solid #C0C0C0; border-radius: 5px; background-color:#C0C0C0;" value=""/></div>
                                        </div>
                                    </div>
                                </div>
                                <div class="button">
                                    <div class="btnbox">
                                        <input class='' type='button' name='' id='' Pmp4='" + data.list[i].匹配 + "' Wmp4= '" + data.list[i].未匹配 + "'  value='取消'  />
                                       
                                    </div>
                                    <div class="btnbox">
                                        <input class=' But_Video' type='button' name='' id='' Pmp4='" + data.list[i].匹配 + "' Wmp4= '" + data.list[i].未匹配 + "'  value='修改'  />
                                       
                                    </div>
                                </div>
                        </div>
                    </div>
                </div>
            </div>
        </div>
    </div>
    </form>
</body>
</html>
