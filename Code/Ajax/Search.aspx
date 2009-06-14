<%@ Page Language="C#" AutoEventWireup="true" CodeFile="Search.aspx.cs" Inherits="Ajax_Search" %>

<div style="text-align:center;">
    <asp:label runat="server" id="Tips" ForeColor="Red" text=""></asp:label>
</div>

<ul class="list">
<asp:Repeater ID="ListNews" runat="server">
    <ItemTemplate>
        <li><a href="#" onclick="window.location.href='#NewsID=<%#Eval("NewsID")%>';LoadData();return false; ">
            <%#Eval("Title").ToString().Replace(QS("Keyword"), "<font color=\"red\">" + QS("Keyword") + "</font>") %></a></li>
    </ItemTemplate>
</asp:Repeater>
</ul>


<div class="pagebar">
    [第<%=page.GetPageIndex() %>页/共<%=page.GetPageCount() %>页] 
    <a href="#" onclick="Search('<%=QS("Keyword")%>','<%=page.GetFirst() %>');return false; ">首页</a>
    <a href="#" onclick="Search('<%=QS("Keyword")%>','<%=page.GetPre() %>');return false; ">上一页</a>
     <a href="#" onclick="Search('<%=QS("Keyword")%>','<%=page.GetNext() %>');return false; ">下一页</a>
     <a href="#" onclick="Search('<%=QS("Keyword")%>','<%=page.GetLast() %>');return false; ">尾页</a>
</div>
