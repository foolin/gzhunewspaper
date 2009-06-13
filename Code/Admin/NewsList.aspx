<%@ Page Language="C#" MasterPageFile="~/Admin/AdminPage.master" AutoEventWireup="true" CodeFile="NewsList.aspx.cs" Inherits="Admin_NewsList" Title="Untitled Page" %>
<%@ Register TagPrefix="page" Namespace="Studio.Web"%>
<asp:Content ID="Content1" ContentPlaceHolderID="Location" Runat="Server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentSide" Runat="Server">
    <!--栏目-->
    <div class="box">
      <div class="title"><span class="titletxt">新闻面板</span></div>
        <div class="content">
            <ul>
            <li><a href="NewsAdd.aspx">添加新闻</a></li>
            <li><a href="NewsList.aspx">新闻列表</a></li>
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
                                            标题</th>
                                        <th>
                                            期刊</th>
                                        <th>
                                            版面</th>
                                        <th>
                                            作者</th>
                                       <!--
                                        <th>
                                            添加人</th>
                                        <th>
                                            时间</th>
                                        -->
                                        <th>
                                            浏览</th>
                                        <th>
                                            操作</th>
                                    </tr>
                                    <asp:Repeater ID="listNews" runat="server">
                                        <ItemTemplate>
                                            <tr onmouseover="this.style.background='#FFFFFF';" onmouseout="this.style.background='#E6F2FF'">
                                                <td>
                                                    <%#Eval("NewsID")%></td>
                                                <td>
                                                    <%#Eval("Title")%></td>
                                                <td>
                                                    <%#Eval("PaperID")%>期</td>
                                                <td>
                                                    <%#Eval("PageID")%>版</td>
                                                <td>
                                                    <%#Eval("Author")%></td>
                                                <!--
                                                <td>
                                                    <%#Eval("AddUser")%></td>
                                                <td>
                                                    <%#Convert.ToDateTime(Eval("AddTime")).ToShortDateString().ToString()%></td>
                                                -->
                                                <td>
                                                    <%#Eval("ViewCount") %></td>
                                                <td>
                                                    <a href="NewsEdit.aspx?id=<%#Eval("NewsID") %>&PaperID=<%#Eval("PaperID") %>&PageID=<%#Eval("PageID") %>" title="修改新闻">修改</a>
                                                    <a href="NewsDel.aspx?id=<%#Eval("NewsID") %>" onclick="return confirm('删除新闻将不能恢复！\n\n您确定要删除该新闻吗？')" title="删除">删除</a></td>
                                            </tr>
                                        </ItemTemplate>
                                    </asp:Repeater>
                                    <tr>
                                        <td colspan="9"> 
                                        选择期刊： <asp:DropDownList ID="PaperList" runat="server"  OnSelectedIndexChanged="PaperList_SelectedIndexChanged" AutoPostBack="True">
                                                    <asp:ListItem Value="0">请选择</asp:ListItem>
                                                   </asp:DropDownList>
                                       选择版面： <asp:DropDownList ID="PageList" runat="server"  OnSelectedIndexChanged="PageList_SelectedIndexChanged" AutoPostBack="True">
                                                    <asp:ListItem Value="0">请选择</asp:ListItem>
                                                   </asp:DropDownList>
                                                   </td>
                                    </tr>

                                </table>
                               <div class="pagebar">[1] [2] ... [3]</div>
                    </div>
</asp:Content>

