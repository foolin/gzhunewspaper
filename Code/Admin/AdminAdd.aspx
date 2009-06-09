<%@ Page Language="C#" MasterPageFile="~/Admin/AdminPage.master" AutoEventWireup="true" CodeFile="AdminAdd.aspx.cs" Inherits="Admin_AddAdmin" Title="Untitled Page" %>
<asp:Content ID="Content1" ContentPlaceHolderID="Location" Runat="Server">
添加管理员
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentSide" Runat="Server">
<!--栏目-->
    <div class="box">
      <div class="title"><span class="titletxt">管理员管理</span></div>
        <div class="content">
            <ul>
            <li><a href="AdminAdd.aspx">添加管理员</a></li>
            <li><a href="AdminList.aspx">管理员列表</a></li>
            </ul>
        </div>
    </div>
</asp:Content>
<asp:Content ID="Content3" ContentPlaceHolderID="ContentMain" Runat="Server">
<div style="width:98%; margin:0px auto;">
<div class="list">
    <table>
        <tr>
            <th colspan="2">添加管理员信息</th>
        </tr>
        <tr>
            <td>管理员名：</td>
            <td> 
                <asp:TextBox ID="txtAdminName" runat="server"></asp:TextBox></td>
        </tr>
        <tr>
            <td>密码：</td>
            <td>						<!--日期实例化--begin-->
                <asp:TextBox ID="txtPassword" runat="server"></asp:TextBox></td>
        </tr>
        <tr>
            <td>权限</td>
            <td>
			    <asp:TextBox ID="txtPower" runat="server"></asp:TextBox></td>
        </tr>
        <tr>
            <td></td>
            <td>  <asp:Button ID="btnSave" runat="server" Text="保存" OnClick="btnSave_Click"/>
                                <a href="AdminList.aspx">取消</a> <br /></td>
        </tr>
    </table>   
</div>
</div>
    <br />
    <br />
</asp:Content>

