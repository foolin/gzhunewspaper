<%@ Page Language="C#" MasterPageFile="~/Admin/AdminPage.master" AutoEventWireup="true" CodeFile="SystemCofig.aspx.cs" Inherits="Admin_ConfigEdit" Title="Untitled Page" %>
<asp:Content ID="Content1" ContentPlaceHolderID="Location" Runat="Server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentSide" Runat="Server">
<!--栏目-->
    <div class="box">
      <div class="title"><span class="titletxt">配置面板</span></div>
        <div class="content">
            <ul>
            <li><a href="SystemCofigEdit.aspx">修改配置</a></li>
	        <li><a href="SystemCofig.aspx">配置清单</a></li>
            </ul>
        </div>
    </div>
</asp:Content>
<asp:Content ID="Content3" ContentPlaceHolderID="ContentMain" Runat="Server">
<!--栏目-->
                            <div class="list">
                                <table width="100%" cellspacing="0" border="0">
                                    <tr>
                                        <th>
                                            报刊名</th>
                                        <th>
                                            站点名</th>
                                        <th>
                                            站点URL</th>
                                        <th>
                                            报刊信息</th>
                                        <th>
                                            是否开放注册</th>
                                        <th>
                                            编辑部名</th>
                                        <th>
                                            编辑部地址</th>
                                        <th>
                                            电话</th>
                                        <th>
                                            传真</th>
                                        <th>
                                            邮箱</th>
                                        <th>
                                            操作</th>
                                    </tr>
                                    <asp:Repeater ID="listConfig" runat="server">
                                        <ItemTemplate>
                                            <tr onmouseover="this.style.background='#FFFFFF';" onmouseout="this.style.background='#E6F2FF'">
                                                <td>
                                                    <%#Eval("PaperName")%></td>
                                                <td>
                                                    <%#Eval("SiteName")%></td>
                                                <td>
                                                    <%#Eval("SiteUrl")%></td>
                                                <td>
                                                    <%#Eval("PaperInfo")%></td>
                                                <td>
                                                    <%#Eval("IsOpenRegister")%></td>
                                                <td>
                                                    <%#Eval("EditorName")%></td>
                                                <td>
                                                    <%#Eval("EditorAddrs")%></td>
                                                <td>
                                                    <%#Eval("EditorPhone")%></td>
                                                <td>
                                                    <%#Eval("EditorFax")%></td>
                                                <td>
                                                    <%#Eval("EditorEmail")%></td>
                                                <td>
                                                    <a href="SystemCofigEdit.aspx?id=<%#Eval("PaperName") %> " title="修改系统信息">修改</a>
                                            </tr>
                                        </ItemTemplate>
                                    </asp:Repeater>
                                    
                                </table>
                               
                    </div>
</asp:Content>

