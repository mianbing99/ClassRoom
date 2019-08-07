<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="BooksCataLog.aspx.cs" Inherits="Webz.Admin.BooksCataLog" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
<meta http-equiv="Content-Type" content="text/html; charset=utf-8"/>
    <title></title>
    <link href="/CSS/BooksCataLog.css" rel="stylesheet" type="text/css" />
    <script src="CC/jquery-3.3.1.js"></script>
</head>
<body style="background-color:#f2f2f2;">
    
    <form id="form1" runat="server">
    <div class="body" style="margin:0 12px;min-width: 1120px;max-width: 1120px;">
        <div class="header" style="font-size:12px;">
            <div class="topnav">当前位置：教材目录管理><div id="navname" class="navname"></div>教材目录</div>
            <div class="withdrawbtn" ><input type="button" style="margin-right:0px;" class="dropout"   value="退出"/></div>
        </div>
        <div class="content">
            <div class="formcontent">
                <div style="display:none;" id="CaID"></div>
                <div style="display:none;" id="level"></div>
                <div class="formcontent-item">
                    <div class="form-inline">
                        <div class="formcontent-label"><label>ISBN：</label></div>
                        
                        <div class="formcontent-input">
                            <input type="text" id="ISBN"/>
                        </div>
                    </div>
                    <div class="form-inline caNamediv">
                       <div class="formcontent-label"> <label >单元目录：</label></div>
                        <div class="formcontent-input">
                            <input type="text" id="CaName"/>
                        </div>
                    </div>
                </div>
                <div class="formcontent-item">
                    <div class="form-inline textCataLogNamediv">
                       <div class="formcontent-label"> <label >课文目录：</label></div>
                        <div class="formcontent-input">
                            <input type="text" id="textCataLogName"/>
                        </div>
                    </div>
                    <div class="form-inline CaNumdiv">
                       <div class="formcontent-label"> <label >目录序号：</label></div>
                        <div class="formcontent-input">
                            <input type="text" id="CaNum"/>
                        </div>
                    </div>
                    
                    
                </div>
                <div class="formcontent-item">
                    
                    <div class="form-inline subTextNamediv">
                       <div class="formcontent-label"> <label >子课文名称：</label></div>
                        <div class="formcontent-input">
                            <input type="text" id="subTextName"/>
                        </div>
                    </div>
                    <div class="form-inline authordiv">
                        <div class="formcontent-label"> <label >作&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;者：</label></div>
                        
                        <div class="formcontent-input">
                            <input type="text" id="author"/>
                        </div>
                    </div>
                </div>
                <div class="formcontent-item">
                    <div class="form-inline pagediv">
                        <div class="formcontent-label"> <label >页&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;码：</label></div>
                        <div class="formcontent-input">
                            <input type="text" id="page"/>
                        </div>
                    </div>
                </div>
                <div class="formcontent-item">
                    <div class="formcontent-footer">
                        <input type="button" class="btnsubmit" value="保存"/>
                        <input type="button" class="btncancel" value="取消"/>
                    </div>
                </div>

            </div>
        </div>
    </div>
    </form>
    <script type="text/javascript">

        var isbn = document.getElementById("ISBN");
        var caName = document.getElementById("CaName");
        var caNum = document.getElementById("CaNum");
        var textCataLogName = document.getElementById("textCataLogName");
        var subTextName = document.getElementById("subTextName");
        var author = document.getElementById("author");
        var page = document.getElementById("page");
        $(function () {
            var caid = document.getElementById("CaID").innerHTML;
            if (caid > 0)
            {
                var level = 0;
                $.post("AjaxHelper/BooksCataLog.ashx", "action=selectOne&CaId=" + caid, function (data){
                    console.log(data);
                    document.getElementById("level").innerHTML = data.Level;
                    isbn.value = data.ISBN;
                    caName.value = data.CaName;
                    if (data.Level>1)
                    {
                        caNum.value = data.CaNum;
                        author.value = data.Author;
                        page.value = data.Page;
                        textCataLogName.value = data.TextName;
                        if (data.Level>2)
                        {
                            subTextName.value = data.SubTextName;
                        }
                    }
                    $("#ISBN").attr("disabled", "disabled");
                    if (data.Level == 1)
                    {
                        $(".textCataLogNamediv").css("display", "none");
                        $(".CaNumdiv").css("display", "none");
                        $(".subTextNamediv").css("display", "none");
                        $(".authordiv").css("display", "none");
                        $(".pagediv").css("display", "none");
                        
                    } else if (data.Level == 2)
                    {
                        $(".subTextNamediv").css("display", "none");
                        $("#CaName").attr("disabled","disabled");
                    }
                    else if (data.Level == 3)
                    {
                        $("#CaName").attr("disabled", "disabled");
                        $("#textCataLogName").attr("disabled","disabled");
                    }
                }, "json");
            }
        });
        $(".btncancel,.dropout").click(function () {
            window.location.href = "CatalogManage.aspx";
        });
       

            $(".btnsubmit").click(function () {
                
                if (checkForm()) {
                    var caid = document.getElementById("CaID").innerText;
                    var level = document.getElementById("level").innerText;
                    var isbn = document.getElementById("ISBN").value;
                    var caName = document.getElementById("CaName").value;
                    var caNum = document.getElementById("CaNum").value;
                    var textCataLogName = document.getElementById("textCataLogName").value;
                    var author = document.getElementById("author").value;
                    var subTextName = document.getElementById("subTextName").value;
                    var page = document.getElementById("page").value;
                    var url = "AjaxHelper/BooksCataLog.ashx";
                    var action = null;
                    var caid = document.getElementById("CaID").innerText;
                    if (caid.length>0) {
                        action = "updateInfo";
                    } else {
                        action = "insertInfo";
                    }
                    var data = {
                        caId: caid,
                        action: action,
                        isbn: isbn,
                        level:level,
                        caName: caName,
                        caNum: caNum,
                        textCataName: textCataLogName,
                        author: author,
                        subTextName: subTextName,
                        page: page,
                    };
                    $.ajax({
                        type: "post",
                        url: url,
                        data: data,
                        dataType: "json",
                        success: function (data) {
                            if (data.error==1) {
                                alert("ISBN错误，请输入正确ISBN");
                            }
                            if (data.insertCount>0)
                            {
                                if (data.insertCount == 1) {
                                    alert("添加成功！");
                                    //location.href = "";
                                } else if(data.insertCount==2) {
                                    alert("已有该目录！");
                                }
                            }
                            if (data.updateCount == 1) {
                                alert("修改成功");
                                //location.href = "";
                            } else if(data.updateCount<0){
                                alert("修改失败");
                            }
                        },
                        error: function (XMLHttpRequest, textStatus, errorThrown) {
                            // 状态码
                            console.log(XMLHttpRequest.status);
                            // 状态
                            console.log(XMLHttpRequest.readyState);
                            // 错误信息   
                            console.log(textStatus);
                        }
                    })
                
                }
            });
            function checkForm()
            {
                var list = ["ISBN", "CaName"];
                var bool = true;
                //for (var i = 0; i < list.length; i++)
                //{
                //    if (validateNull(list[i])==false)
                //    {
                //        bool = false;
                //    }
                //}
                var isbn = document.getElementById("ISBN");
                var caName = document.getElementById("CaName");
                var caNum = document.getElementById("CaNum");
                var textCataLogName = document.getElementById("textCataLogName");
                var subTextName = document.getElementById("subTextName");
                var author = document.getElementById("author");
                var page = document.getElementById("page");
                isbn.style.border = "1px solid #808080";
                isbn.placeholder = "";
                caName.style.border = "1px solid #808080";
                caName.placeholder = "";
                caNum.style.border = "1px solid #808080";
                caNum.placeholder = "";
                textCataLogName.style.border = "1px solid #808080";
                textCataLogName.placeholder = "";
                author.style.border = "1px solid #808080";
                author.placeholder = "";
                page.placeholder = "";
                page.style.border = "1px solid #808080";
                subTextName.placeholder = "";
                subTextName.style.border = "1px solid #808080";
                if (isbn.value.length<=0)
                {
                    isbn.placeholder = "请填写isbn!";
                    isbn.style.border = "1px solid red";
                    bool = false;
                }
                if(caName.value.length<=0)
                {
                    caName.placeholder = "请填写单元目录!";
                    caName.style.border = "1px solid red";
                    bool = false;
                }

                if (document.getElementById("level").innerHTML==3&&subTextName.value.length<=0) {
                    subTextName.placeholder = "请填写子课文名称！";
                    subTextName.style.border = "1px solid red";
                    bool = false;
                }
                if (subTextName.value.length > 0 || textCataLogName.value.length > 0)
                {
                    if (caNum.value.length <= 0)
                    {
                        caNum.placeholder = "请填写目录序号";
                        caNum.style.border = "1px solid red";
                        bool = false;
                    }
                    if (subTextName.value.length > 0 && textCataLogName.value.length <= 0) {
                        textCataLogName.placeholder = "请填写课文目录!";
                        textCataLogName.style.border = "1px solid red";
                        bool = false;
                    }
                    if (author.value.length<=0)
                    {
                        author.placeholder = "请填写作者!";
                        author.style.border = "1px solid red";
                        bool = false;
                    }
                    if (page.value.length <= 0)
                    {
                        page.placeholder = "请填写页数!";
                        page.style.border = "1px solid red";
                        bool = false;
                    }


                    

                }
                return bool;
            }

            // 不为空验证
            function validateNull(elemName) {
                var elem = document.getElementById(elemName);
                if (elem.value.length<=0) {
                    elem.placeholder = "必填";
                    elem.style.border = "1px solid red";
                    return false;
                } else {
                    elem.placeholder = "";
                    elem.style.border = "1px solid #808080";
                    return;
                }
            }


    </script>
</body>
</html>
