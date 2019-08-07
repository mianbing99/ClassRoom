<%@ Control Language="C#" AutoEventWireup="true" CodeBehind="CC_Table_PageList.ascx.cs" Inherits="Webz.Admin.Views.CC_Table_PageList" %>

<div id="huadong">
    <table>
        <tr style="background-color: #5DA4F9; color: #FFFFFF;">
            <td>序号</td>
            <td>课本名称</td>
            <td>目录</td>
            <td>已匹配路径</td>
            <td>未匹配路径</td>
            <td id="MH" >操作</td>
            <td id="YL" style="width: 40px;">
                <input type="hidden" name="chekname" id="His" value="0" />
                <span class="cheks"></span>
                <input type="checkbox" class="chek" id="quanxuan" />
            </td>
        </tr>
      
        
      
    </table>
</div>
