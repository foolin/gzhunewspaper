<%@ Page Language="C#" MasterPageFile="~/Admin/AdminPage.master" AutoEventWireup="true" CodeFile="ChangePassword.aspx.cs" Inherits="Admin_ChangePassword" Title="Untitled Page" %>
<asp:Content ID="Content1" ContentPlaceHolderID="Location" Runat="Server">
修改密码
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentSide" Runat="Server">
<!--栏目-->
    <div class="box">
      <div class="title"><span class="titletxt">修改密码</span></div>
        <div class="content">
            <ul>
            <li><a href="SystemCofig.aspx">系统配置</a></li>
            </ul>
        </div>
    </div>
</asp:Content>
<asp:Content ID="Content3" ContentPlaceHolderID="ContentMain" Runat="Server">
<div style="width:98%; margin:0px auto;">
<div class="list">
    <table>
        <tr>
            <td>
                当前管理员名：</td>
            <td> 
                <asp:TextBox ID="txtAdminName" runat="server" Enabled="False"></asp:TextBox></td>
        </tr>
        <tr>
            <td>请输入新密码：</td>
            <td>						<!--日期实例化--begin-->
                <asp:TextBox ID="txtPassword" runat="server" TextMode="Password"></asp:TextBox>
                <asp:RequiredFieldValidator ID="RequiredFieldValidator1" runat="server" ControlToValidate="txtPassword"
                    ErrorMessage="不能为空"></asp:RequiredFieldValidator></td>
        </tr>
        <tr>
            <td>请再次输入新密码：</td>
            <td>
			    <asp:TextBox ID="txtPassword1" runat="server" TextMode="Password"></asp:TextBox>
                <asp:RequiredFieldValidator ID="RequiredFieldValidator2" runat="server" ControlToValidate="txtPassword1"
                    ErrorMessage="不能为空"></asp:RequiredFieldValidator></td>
        </tr>
        <tr>
            <td></td>
            <td>  <asp:Button ID="btnSave" runat="server" Text="确定" OnClick="btnSave_Click"/>
                                <a href="Default.aspx">取消</a> <br />
                <asp:CompareValidator ID="CompareValidator1" runat="server" ControlToCompare="txtPassword"
                    ControlToValidate="txtPassword1" ErrorMessage="两次输入的密码不相同"></asp:CompareValidator></td>
        </tr>
    </table>   
</div>
</div>
    <br />
    <br />
</asp:Content>

