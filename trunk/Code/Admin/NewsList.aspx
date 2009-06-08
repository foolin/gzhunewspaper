<%@ Page Language="C#" MasterPageFile="~/Admin/AdminPage.master" AutoEventWireup="true" CodeFile="NewsList.aspx.cs" Inherits="Admin_NewsList" Title="Untitled Page" %>
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
                                            新闻号</th>
                                        <th>
                                            版面号</th>
                                        <th>
                                            标题</th>
                                        <th>
                                            作者</th>
                                        <th>
                                            内容</th>
                                        <th>
                                            具体位置</th>
                                        <th>
                                            管理员</th>
                                        <th>
                                            时间</th>
                                        <th>
                                            viewcount</th>
                                        <th>
                                            操作</th>
                                    </tr>
                                    <asp:Repeater ID="listNews" runat="server">
                                        <ItemTemplate>
                                            <tr onmouseover="this.style.background='#FFFFFF';" onmouseout="this.style.background='#E6F2FF'">
                                                <td>
                                                    <%#Eval("PaperID")%></td>
                                                <td>
                                                    <%#Convert.ToDateTime(Eval("PublishDate")).ToLongDateString().ToString()%></td>
                                                <td>
                                                    <%#Eval("NumOfPage") %></td>
                                                <td>
                                                    <a href="PaperEdit.aspx?id=<%#Eval("PaperID") %>" title="修改期刊信息">修改</a>
                                                    <a href="PaperDel.aspx?id=<%#Eval("PaperID") %>" onclick="return confirm('注意：该期刊的所有版面和新闻数据都将会永久性删除！\n\n您确定要删除该期刊吗？')" title="删除">删除</a></td>
                                            </tr>
                                        </ItemTemplate>
                                    </asp:Repeater>
                                </table>
                               <div class="pagebar">[1] [2] ... [3]</div>
                    </div>
</asp:Content>

