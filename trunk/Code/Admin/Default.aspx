<%@ Page Language="C#" MasterPageFile="~/Admin/AdminPage.master" AutoEventWireup="true" CodeFile="Default.aspx.cs" Inherits="Admin_Default" Title="Untitled Page" %>
<asp:Content ID="Content1" ContentPlaceHolderID="Location" Runat="Server">
后台首页
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentSide" Runat="Server">
                        <!--栏目-->
                        <div class="box">
                          <div class="title"><span class="titletxt">控制面板</span></div>
                            <div class="content">
                               <asp:Label ID="labLoginAdmin" runat="server" Text="Label"></asp:Label>
                                <ul>
                                <li><a href="ChangePassword.aspx">修改密码</a></li>
                                <li><a href="Logout.aspx">修改密码</a></li>
                                </ul>
                            </div>
                        </div>
</asp:Content>
<asp:Content ID="Content3" ContentPlaceHolderID="ContentMain" Runat="Server">
</asp:Content>

