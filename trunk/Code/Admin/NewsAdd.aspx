<%@ Page Language="C#" MasterPageFile="~/Admin/AdminPage.master" AutoEventWireup="true" CodeFile="NewsAdd.aspx.cs" Inherits="Admin_NewsAdd" Title="Untitled Page" %>
<asp:Content ID="Content1" ContentPlaceHolderID="Location" Runat="Server">
添加新闻
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentSide" Runat="Server">
<!--栏目-->
    <div class="box">
      <div class="title"><span class="titletxt">新闻管理</span></div>
        <div class="content">
            <ul>
            <li><a href="NewsAdd.aspx">添加新闻</a></li>
            <li><a href="NewsList.aspx">新闻列表</a></li>
            </ul>
        </div>
    </div>
</asp:Content>
<asp:Content ID="Content3" ContentPlaceHolderID="ContentMain" Runat="Server">
<div style="width:98%; margin:0px auto;">
<div class="list">
    <table>
        <tr>
            <th colspan="2">添加新闻信息</th>
        </tr>
        <tr>
            <td style="height: 25px">版面：</td>
            <td style="height: 25px"> 
                第<asp:DropDownList ID="txtPaperID" runat="server" OnSelectedIndexChanged="txtPaperID_SelectedIndexChanged" AutoPostBack="True"></asp:DropDownList>期</td>
        </tr>
        <tr>
            <td>版面：</td>
            <td> 
                第<asp:DropDownList ID="txtPageID" runat="server"></asp:DropDownList>版</td>
        </tr>
        <tr>
            <td>标题</td>
            <td>
                <asp:TextBox ID="txtTitle" runat="server"></asp:TextBox> 
            </td>
        </tr>
        <tr>
            <td>作者</td>
            <td>
				<asp:TextBox ID="txtAuthor" runat="server"></asp:TextBox>
            </td>
        </tr>
        <tr>
            <td>内容</td>
            <td>
				<asp:TextBox ID="txtContent" runat="server"></asp:TextBox>
            </td>
        </tr>
        <tr>
            <td>位置</td>
            <td>
				<asp:TextBox ID="txtPosition" runat="server"></asp:TextBox>
            </td>
        </tr>
        <tr>
            <td>
                添加人</td>
            <td>
				<asp:TextBox ID="txtAddUser" ReadOnly="true" runat="server"></asp:TextBox>
            </td>
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

