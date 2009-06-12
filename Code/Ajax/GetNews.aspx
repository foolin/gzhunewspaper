<%@ Page Language="C#" AutoEventWireup="true" CodeFile="GetNews.aspx.cs" Inherits="Ajax_GetNews" %>
<%@ Import Namespace="Myweb.NewsPaper" %>
<%@ Import Namespace="Studio.Web" %>


<h3 class="title">广州大学档案馆简介</h3>
<div class="info">
     期刊：<a href="#" onclick="window.location.href='#PaperID=<%=news.PaperID %>';LoadData();return false; ">第12期</a>  &nbsp;&nbsp;
	版面：<a href="#" onclick="window.location.href='#PaperID=<%=news.PaperID %>&PageID=<%=news.PageID %>';LoadData();return false; ">第2版</a> &nbsp;&nbsp;&nbsp;
	[字体：<a href="javascript:fontZoom(16)">大</a> <a href="javascript:fontZoom(14)">中</a> <a href="javascript:fontZoom(12)">小</a> ] &nbsp;[<a href="javascript:window.print()">打印</a>]&nbsp;[<a href="javascript:window.close()">关闭</a>] 
	<a href="#" onclick="window.location.href='#PaperID=<%=news.PaperID %>&PageID=<%=news.PageID %>';LoadData();return false;">【返回】</a>
</div>
<div class="content" id="content">
    <%=news.Content %>
    
    <br />
    <div style="text-align:center;">【<a href="#" onclick="window.location.href='#PaperID=<%=news.PaperID %>&PageID=<%=news.PageID %>';LoadData();return false;">返回</a>】</div>
</div>
