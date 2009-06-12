<%@ Page Language="C#" AutoEventWireup="true" CodeFile="GetNews.aspx.cs" Inherits="Ajax_GetNews" %>
<%@ Import Namespace="Myweb.NewsPaper" %>
<%@ Import Namespace="Studio.Web" %>


<div style="text-align:left; padding-bottom:10px; color:Gray;"> 你的位置：
<a href="#" onclick="window.location.href='#PaperID=<%=news.PaperID %>';LoadData();return false; ">第<%=news.PaperID %>期</a> →
<a href="#" onclick="window.location.href='#PaperID=<%=news.PaperID %>&PageID=<%=news.PageID %>';LoadData();return false; ">第<%=news.PageID %>版</a> → 新闻浏览
</div>
<h3 class="title"><%=news.Title %></h3>
<div class="info">
     期刊：<a href="#" onclick="window.location.href='#PaperID=<%=news.PaperID %>';LoadData();return false; ">第<%=news.PaperID %>期</a>  &nbsp;&nbsp;
	版面：<a href="#" onclick="window.location.href='#PaperID=<%=news.PaperID %>&PageID=<%=news.PageID %>';LoadData();return false; ">第<%=news.PageID %>版</a> &nbsp;&nbsp;&nbsp;
	[字体：<a href="javascript:fontZoom(16)">大</a> <a href="javascript:fontZoom(14)">中</a> <a href="javascript:fontZoom(12)">小</a> ] &nbsp;[<a href="javascript:window.print()">打印</a>]&nbsp;[<a href="javascript:window.close()">关闭</a>] 
	[<a href="#" onclick="window.location.href='#PaperID=<%=news.PaperID %>&PageID=<%=news.PageID %>';LoadData();return false;">返回</a>]
</div>
<div class="content" id="content">
    <%=news.Content %>
    
    <br />
    <div style="text-align:center;">【<a href="#" onclick="window.location.href='#PaperID=<%=news.PaperID %>&PageID=<%=news.PageID %>';LoadData();return false;">返回</a>】</div>
</div>
