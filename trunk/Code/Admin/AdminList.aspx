<%@ Page Language="C#" MasterPageFile="~/Admin/AdminPage.master" AutoEventWireup="true" CodeFile="AdminList.aspx.cs" Inherits="Admin_AdminList" Title="Untitled Page" %>
<asp:Content ID="Content1" ContentPlaceHolderID="Location" Runat="Server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentSide" Runat="Server">
 <!--栏目-->
    <div class="box">
      <div class="title"><span class="titletxt">管理员面板</span></div>
        <div class="content">
            <ul>
            <li><a href="AdminAdd.aspx">添加管理员</a></li>
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
                                            ID</th>
                                        <th>
                                            用户名</th>
                                        <th>
                                            权限</th>
                                        <th>
                                            登陆次数</th>
                                        <th>
                                            最后登陆时间</th>
                                        <th>
                                            最后登陆IP</th>
                                        <th>
                                            操作</th>
                                    </tr>
                                    <asp:Repeater ID="listAdmin" runat="server">
                                        <ItemTemplate>
                                            <tr onmouseover="this.style.background='#FFFFFF';" onmouseout="this.style.background='#E6F2FF'">
                                                <td>
                                                    <%#Eval("AdminID")%></td>
                                                <td>
                                                    <%#Eval("AdminName")%></td>
                                                <td>
                                                    <%#Eval("Power")%></td>
                                                <td>
                                                    <%#Eval("LoginCount")%></td>
                                                <td>
                                                    <%#Convert.ToDateTime(Eval("LastLoginTime")).ToShortDateString().ToString()%></td>
                                                <td>
                                                    <%#Eval("LastLoginIP")%></td>
                                                <td>
                                                    <a href="AdminEdit.aspx?id=<%#Eval("AdminID") %> " title="修改管理员">修改</a>
                                                    <a href="AdminDel.aspx?id=<%#Eval("AdminID") %>" onclick="return confirm('删除管理员将不能恢复！\n\n您确定要删除该管理员吗？')" title="删除">删除</a></td>
                                            </tr>
                                        </ItemTemplate>
                                    </asp:Repeater>
                                    
                                </table>
                               <div class="pagebar">[1] [2] ... [3]</div>
                    </div>
</asp:Content>

