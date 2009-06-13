<%@ Page Language="C#" AutoEventWireup="true" CodeFile="GetPageImage.aspx.cs" Inherits="Ajax_GetPageImage" %>
<%@ Import Namespace="Myweb.NewsPaper" %>
<%@ Import Namespace="Studio.Web" %>

<div style="background: url(<%=strPageImage %>) no-repeat;" class="pageImage">

<!--宽度公式：Top + Height + 7px = 标题Top --->
<%
    int paperID = 0, pageID = 0;
    int left=0, top=0, width=0, height=0;
    string strShow="";
    string[] position;
    if (QS("PaperID") != "" && WebAgent.IsInt32(QS("PaperID")) && QS("PageID") != "" && WebAgent.IsInt32(QS("PageID")))
    {
        paperID = int.Parse(QS("PaperID"));
        pageID = int.Parse(QS("PageID"));
    }
    if (QS("NewsID") != "" && WebAgent.IsInt32(QS("NewsID")))
    {
        News news = new NewsAgent().GetNewsInfo(int.Parse(QS("NewsID")));
        if (news != null)
        {
            paperID = news.PaperID;
            pageID = news.PageID;
        }
    }
    ArrayList arr = new NewsAgent().GetNewsList(paperID, pageID);
    foreach (News news in arr)
    {
        position = news.PositionOfPage.ToString().Split('|');
        left = int.Parse(position[0]) -2;
        top = int.Parse(position[1]) -2;
        width = int.Parse(position[2]);
        height = int.Parse(position[3]);
        if (QS("NewsID") != "" && WebAgent.IsInt32(QS("NewsID")))
        {   
            if(news.NewsID == int.Parse(QS("NewsID")))
                strShow = "#33b9ff 2px solid";
            else
                strShow = "";
        }
        
%>
          <div style="left: <%=left %>px; top:<%=top + height + 7 %>px;" class="imgNewsTitle" id="div<%=news.NewsID %>">
                <div class="tips"><img src="Images/imgTips.gif" /></div>
                <div class="text">
                     <%=news.Title %>
                </div>
        </div> 
        <div style="left: <%=left %>px;top:<%=top %>px; width:<%=width %>px; height: <%=height %>px; border: <%=strShow %>;" 
    	     class="imgNewsArea" 
             onmouseover="this.style.border='#33b9ff 2px solid';document.getElementById('div<%=news.NewsID %>').style.display='block';"
             onmouseout="this.style.border='<%=strShow %>';document.getElementById('div<%=news.NewsID %>').style.display='none';"
             onclick="window.location.href='#NewsID=<%=news.NewsID %>';LoadData();;return false;" >
        </div> 
<%
    }
%>
    
</div>