<%@ Page Language="C#" MasterPageFile="~/Admin/AdminPage.master" AutoEventWireup="true" CodeFile="PaperList.aspx.cs" Inherits="Admin_PaperList" Title="Untitled Page" %>
<asp:Content ID="Content1" ContentPlaceHolderID="Location" Runat="Server">
    期刊列表
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentSide" Runat="Server">
    <!--栏目-->
    <div class="box">
      <div class="title"><span class="titletxt">期刊面板</span></div>
        <div class="content">
            <ul>
            <li><a href="PaperAdd.aspx">添加期刊</a></li>
            <li><a href="PaperList.aspx">期刊列表</a></li>
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
                                            期刊号</th>
                                        <th>
                                            出版日期</th>
                                        <th>
                                            版面数量</th>
                                        <th>
                                            状态</th>
                                        <th>
                                            操作</th>
                                    </tr>
                                    <asp:Repeater ID="listPaper" runat="server">
                                        <ItemTemplate>
                                            <tr onmouseover="this.style.background='#FFFFFF';" onmouseout="this.style.background='#E6F2FF'">
                                                <td>
                                                    第<%#Eval("PaperID")%>期</td>
                                                <td>
                                                    <%#Convert.ToDateTime(Eval("PublishDate")).ToLongDateString().ToString()%></td>
                                                <td>
                                                    <%#Eval("NumOfPage") %></td>
                                                <td>
                                                    <%#SetStatus(Convert.ToBoolean(Eval("IsShow")), Convert.ToInt32(Eval("PaperID")))%></td>
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

