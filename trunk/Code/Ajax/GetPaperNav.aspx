<%@ Page Language="C#" AutoEventWireup="true" CodeFile="GetPaperNav.aspx.cs" Inherits="Ajax_GetPaperNav" %>
<%
    if (prePaperID == currentPaperID)
    {
        Response.Write("上一期 ");
    }
    else
    {
        Response.Write("<a href=\"#\" onclick=\"window.location.href='#PaperID=" + prePaperID + "';LoadData();return false;\">上一期</a> ");
    }

    if (nextPaperID == currentPaperID)
    {
        Response.Write("下一期 ");
    }
    else
    {
        Response.Write("<a href=\"#\" onclick=\"window.location.href='#PaperID=" + nextPaperID + "';LoadData();return false;\">下一期</a> ");
    }
%>

 &nbsp;&nbsp; 当前：第<%=currentPaperID %>期/第<%=currentPageID %>版 &nbsp;&nbsp;    
 
<%
    if (prePageID == currentPageID)
    {
        Response.Write("上一版 ");
    }
    else
    {
        Response.Write("<a href=\"#\" onclick=\"window.location.href='#PaperID=" + currentPaperID + "&PageID=" + prePageID + "';LoadData();return false;\">上一版</a> ");
    }

    if (nextPageID == currentPageID)
    {
        Response.Write("下一版 ");
    }
    else
    {
        Response.Write("<a href=\"#\" onclick=\"window.location.href='#PaperID=" + currentPaperID + "&PageID=" + nextPageID + "';LoadData();return false;\">下一版</a> ");
    }
%> 
