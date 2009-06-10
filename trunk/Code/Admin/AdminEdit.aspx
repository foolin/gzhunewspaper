<%@ Page Language="C#" MasterPageFile="~/Admin/AdminPage.master" AutoEventWireup="true" CodeFile="AdminEdit.aspx.cs" Inherits="Admin_AdminEdit" Title="Untitled Page" %>
<asp:Content ID="Content1" ContentPlaceHolderID="Location" Runat="Server">
编辑管理员信息
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentSide" Runat="Server">
<!--栏目-->
    <div class="box">
      <div class="title"><span class="titletxt">管理员面板</span></div>
        <div class="content">
            <ul>
            <li><a href="PaperAdd.aspx">添加管理员</a></li>
            <li><a href="PaperList.aspx">管理员列表</a></li>
            </ul>
        </div>
    </div>
</asp:Content>
<asp:Content ID="Content3" ContentPlaceHolderID="ContentMain" Runat="Server">
<div style="width:98%; margin:0px auto;">
<div class="list">
    <table>
        <tr>
            <th colspan="2">修改管理员信息</th>
        </tr>
        <tr>
            <td>管理员名：</td>
            <td> 
                <asp:TextBox ID="txtAdminName" ReadOnly="true" runat="server" Enabled="False"></asp:TextBox> <span style="color:#666">(不能修改管理员名)</span></td>
        </tr>
        <tr>
            <td>密码：</td>
            <td>
                <asp:TextBox ID="txtPassword" runat="server"></asp:TextBox>
                <asp:RequiredFieldValidator ID="RequiredFieldValidator1" runat="server" ControlToValidate="txtPassword"
                    ErrorMessage="密码不能为空"></asp:RequiredFieldValidator></td>
        </tr>
        <tr>
            <td>权限：</td>
            <td>
                <asp:TextBox ID="txtPower" runat="server"></asp:TextBox>
                <asp:RequiredFieldValidator ID="RequiredFieldValidator2" runat="server" ControlToValidate="txtPower"
                    ErrorMessage="权限不能为空"></asp:RequiredFieldValidator></td>
        </tr>
        <tr>
            <td></td>
            <td>  <asp:Button ID="btnSave" runat="server" Text="保存修改" OnClick="btnSave_Click"/>
                                <a href="AdminList.aspx">取消</a> <br /></td>
        </tr>
    </table>   
</div>
</div>
</asp:Content>

