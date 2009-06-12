<%@ Page Language="C#" AutoEventWireup="true" CodeFile="GetPageNav.aspx.cs" Inherits="Ajax_GetPageNav" %>
<%@ Import Namespace="Myweb.NewsPaper" %>
<%@ Import Namespace="Studio.Web" %>

<ul>
<%
    int paperID = 0, pageID = 0;
    string strIsOn = "";
    
    if (QS("PaperID") != "" && WebAgent.IsInt32(QS("PaperID")))
        paperID = int.Parse(QS("PaperID"));
    if (QS("PageID") != "" && WebAgent.IsInt32(QS("PageID")))
        pageID = int.Parse(QS("PageID"));
    if (QS("NewsID") != "" && WebAgent.IsInt32(QS("NewsID")))
    {
        News news = new NewsAgent().GetNewsInfo(int.Parse(QS("NewsID")));
        if (news != null)
        {
            paperID = news.PaperID;
            pageID = news.PageID;
        }
    }
    
    ArrayList arr = new PaperPageAgent().GetPaperPageList(paperID);
    foreach (PaperPage page in arr)
    {
        if (pageID == page.PageID)
            strIsOn = "class=\"on\"";
        else
            strIsOn = "";

 %>
    <li <%=strIsOn %>><a href="#" onclick="window.location.href='#PaperID=<%=page.PaperID %>&PageID=<%=page.PageID %>';LoadData();return false;"><%=page.PageName %></a></li> 
<%
    }
     %>
</ul>
