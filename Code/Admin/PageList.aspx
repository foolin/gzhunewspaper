<%@ Page Language="C#" MasterPageFile="~/Admin/AdminPage.master" AutoEventWireup="true" CodeFile="PageList.aspx.cs" Inherits="Admin_PageList" Title="Untitled Page" %>
<asp:Content ID="Content1" ContentPlaceHolderID="Location" Runat="Server">
    校刊版面管理
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentSide" Runat="Server">
    <!--栏目-->
    <div class="box">
      <div class="title"><span class="titletxt">期刊版面管理</span></div>
        <div class="content">
            <ul>
            <li><a href="PageAdd.aspx">添加版面</a></li>
            <li><a href="PageList.aspx">版面列表</a></li>
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
                                            版面号</th>
                                        <th>
                                            版面名称</th>
                                        <th>
                                            版面缩略图</th>
                                        <th>
                                            操作</th>
                                    </tr>
                                    <asp:Repeater ID="listPage" runat="server">
                                        <ItemTemplate>
                                            <tr onmouseover="this.style.background='#FFFFFF';" onmouseout="this.style.background='#E6F2FF'">
                                                <td>
                                                    第<%#Eval("PaperID")%>期</td>
                                                <td>
                                                    第<%#Eval("PageID") %>版</td>
                                                <td>
                                                    <%#Eval("PageName") %></td>
                                                <td>
                                                    <img src="<%#"../" + Eval("PageImage") %> " alt="" width="120" height="100" /></td>
                                                <td>
                                                    <a href="PageEdit.aspx?PaperID=<%#Eval("PaperID") %>&PageID=<%#Eval("PageID") %>" title="修改信息">修改</a>
                                                    <a href="PageDel.aspx?PaperID=<%#Eval("PaperID") %>&PageID=<%#Eval("PageID") %>" onclick="return confirm('注意：该版面的新闻数据都将会永久性删除！\n\n您确定要删除该期刊吗？')" title="删除">删除</a></td>
                                            </tr>
                                        </ItemTemplate>
                                    </asp:Repeater>
                                    <tr>
                                        <td colspan="9"> 
                                 第<asp:DropDownList ID="PaperList" runat="server"  OnSelectedIndexChanged="PaperList_SelectedIndexChanged" AutoPostBack="True">
                                                     <asp:ListItem Value="0">请选择</asp:ListItem>
                                                   </asp:DropDownList>期 &nbsp;&nbsp;
                                            当前是第<%= currentPaperID %>期：
                                           【<a href="?PaperID=<%= firstPaperID %>">最前一期</a>】
                                           【<a href="?PaperID=<%= prePaperID %>">上一期</a>】
                                           【<a href="?PaperID=<%= nextPaperID %>">下一期</a>】
                                           【<a href="?PaperID=<%= lastPaperID %>">最新一期</a>】
                                           
                                                   </td>
                                    </tr>

                                </table>
                             <div style="color:green; font-size:14px; padding:3px;">温馨提示：请选择相应的期刊，才会显示相应的版面哦。</div>   
                                 
                    </div>
                    
                    
                    
</asp:Content>

