<%@ Page Language="C#" AutoEventWireup="true" CodeFile="Default.aspx.cs" Inherits="Admin_Default" %>

<!DOCTYPE html PUBLIC "-//W3C//DTD XHTML 1.0 Transitional//EN" "http://www.w3.org/TR/xhtml1/DTD/xhtml1-transitional.dtd">

<html xmlns="http://www.w3.org/1999/xhtml" >
<head runat="server">
    <title>无标题页</title>
</head>
<body>
    <form id="form1" runat="server">
    <div>
                <table width="100%" cellspacing="0" border="0">
                    <tr bgcolor="#E6F2FF">
                        <td>
                            PaperID</td>
                        <td>
                            PaperNO</td>
                        <td>
                            PublishDate</td>
                        <td>
                            NumOfPage</td>
                    </tr>
                    <asp:Repeater ID="txtNewsPaper" runat="server">
                        <ItemTemplate>
                            <tr onmouseover="this.style.background='#E6F2FF';" onmouseout="this.style.background='#FFFFFF'">
                                <td>
                                    <a href="<%#Eval("PaperID") %>" target="_blank"><%#Eval("PaperID")%></a></td>
                                <td>
                                    <%#Eval("PaperNO") %></td>
                                <td>
                                    <%#Eval("PublishDate") %></td>
                                <td>
                                    <%#Eval("NumOfPage") %>
                                    </td>
                            </tr>
                        </ItemTemplate>
                    </asp:Repeater>
                </table>
    </div>
    </form>
</body>
</html>
