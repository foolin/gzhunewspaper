<%@ Page Language="C#" MasterPageFile="~/Admin/AdminPage.master" AutoEventWireup="true" CodeFile="PageAdd.aspx.cs" Inherits="Admin_PageAdd" Title="Untitled Page" %>
<asp:Content ID="Content1" ContentPlaceHolderID="Location" Runat="Server">
    添加版面
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentSide" Runat="Server">
    <!--栏目-->
    <div class="box">
      <div class="title"><span class="titletxt">期刊版面管理</span></div>
        <div class="content">
            <ul>
            <li><a href="PageAdd.aspx">添加版面</a></li>
            <li><a href="PageList.aspx">版面列表</a></li>
            </ul>
        </div>
    </div>
</asp:Content>
<asp:Content ID="Content3" ContentPlaceHolderID="ContentMain" Runat="Server">
<div style="width:98%; margin:0px auto;">
<div class="list">
    <table>
        <tr>
            <th colspan="2">添加版面信息</th>
        </tr>
        <tr>
            <td>期数：</td>
            <td> 
                第<asp:DropDownList ID="txtPaperID" runat="server"></asp:DropDownList>期</td>
        </tr>
        <tr>
            <td>版面：</td>
            <td>
                <asp:TextBox ID="txtPageID" runat="server"></asp:TextBox> （必须为数字）
            </td>
        </tr>
        <tr>
            <td>版面名称</td>
            <td>
				<asp:TextBox ID="txtPageName" runat="server"></asp:TextBox>
            </td>
        </tr>
        <tr>
            <td>版面缩略图：</td>
            <td>
                <asp:FileUpload ID="txtPageImage" runat="server" Width="275" /> （规格至少≥：360×500px(像素)）</td>
        </tr>
        <tr>
            <td></td>
            <td>  <asp:Button ID="btnSave" runat="server" Text="保存" OnClick="btnSave_Click"/>
                                <a href="PageList.aspx">取消</a> <br /></td>
        </tr>
    </table>   
</div>
</div>
</asp:Content>

