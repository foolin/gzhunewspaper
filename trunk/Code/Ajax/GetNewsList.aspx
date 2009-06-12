<%@ Page Language="C#" AutoEventWireup="true" CodeFile="GetNewsList.aspx.cs" Inherits="Ajax_GetNewsList" %>

<ul class="list">
<asp:Repeater ID="listNews" runat="server">
    <ItemTemplate>
        <li><a href="#" onclick="window.location.href='#NewsID=<%#Eval("NewsID")%>';LoadData();return false; ">
            <%#Eval("Title")%></a></li>
    </ItemTemplate>
</asp:Repeater>
</ul>
