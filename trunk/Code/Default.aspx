<%@ Page Language="C#" AutoEventWireup="true"  CodeFile="Default.aspx.cs" Inherits="_Default" %>

<!DOCTYPE html PUBLIC "-//W3C//DTD XHTML 1.0 Transitional//EN" "http://www.w3.org/TR/xhtml1/DTD/xhtml1-transitional.dtd">
<html xmlns="http://www.w3.org/1999/xhtml">
<head>
<meta http-equiv="Content-Type" content="text/html; charset=gb2312" />
<title>广州大学校报</title>
<link href="Css/Index.css" rel="stylesheet" type="text/css" />
<script language="javascript" type="text/javascript" src="Scripts/Base.js"></script>
<script language="javascript" type="text/javascript" src="Scripts/Ajax.js"></script>
<script language="javascript" type="text/javascript" src="Scripts/Paper.js"></script>
<script type="text/javascript" language="javascript">
<!--
//时间,每秒刷新
setInterval("$('nowDate').innerHTML=new Date().toLocaleString()+' 星期'+'日一二三四五六'.charAt(new Date().getDay());",1000);
function fontZoom(size){
	document.getElementById('content').style.fontSize=size+'px';

}

-->
</script>
</head>

<body>
<form id="form1"  runat="server">
<div class="wrapper">
	<div class="header">
            <div class="headLeft">
                <div class="loveFav">
                        <ul>
                        <li><a href="#" onclick="return HomePage.call(this);">
                            设为主页</a> |</li>
                        <li><a href="#" onclick="return Love();">加入收藏</a> |</li>
                        <li><a href="AboutUs.html" target="_blank">关于我们</a></li>
                        </ul>
                </div>
                <div class="clear"></div>
                <div class="paperNav">
                         <asp:DropDownList ID="selectPaper" onchange="ChangePaper(this.options[this.selectedIndex].value)" runat="server">
                            <asp:ListItem Value="0">----请选择期数----</asp:ListItem>
                          </asp:DropDownList>
                        
                        <span class="paperNO">总<asp:Label ID="paperTotal" runat="server" Text="Label"></asp:Label>期 当前期数：<span id="paperID">第期</span>
                        </span>
                </div>
            </div>
            <div class="headRight">
                    <div class="paperInfo">
                        中共广州大学委员会主办 国内统一刊号：CN44-0803/（G）
                    </div>
            </div>
            <div class="clear"></div>
    </div>
    <div class="main">
    	<div class="mainLeft">
        		<div class="pageImageBorder">
        		<div id="pageImage">
                    <!--图像显示区域--> 
                </div>
                </div>
        </div>
        <div class="mainRight">
                <div class="search">
                        新闻搜索: <input type="text" id="keyword" />
                        <input class="btnSearch" onclick="Search()" type="button" value="搜索" />
                        <span id="nowDate">当前日期：</span>

                </div>
                <div class="container">
                        <div class="pageNav">
                        	<span style="float:left; padding-left:10px;">版面导航：</span>
                            <span id="pageNav">
                                    <ul>
                                    <li class="on"><a href="#">第一版</a></li> 
                                    <li><a href="#">第二版</a></li>
                                    <li><a href="#">第三版</a></li>
                                    <li><a href="#">第四版</a></li>
                                    </ul>
                            </span>
                            <div class="clear"></div>
                        </div>
                        <div id="news">
                        
                        <!--新闻区域-->

                        </div>
                        <div class="clear"></div>
                </div>
        </div>
        <div class="clear"></div>
    </div>
    <div class="clear"></div>
    <div class="footer">广州大学校报编辑部出版  邮箱：gdnews@126.com 电话：020-87542701  传真：020-87541544<br />
地址：广州大学行政B后座六楼  邮编：510006<br /> 
版权所有&copy;2009    <a href="http://www.eekku.com/" target="_blank">E酷工作室</a>   制作:刘付灵（Foolin）、朱松辉 [<a href="Admin/Login.aspx" target="_blank">管理登录</a>]
	</div>
</div>
</form>
</body>
</html>
<script type="text/javascript" language="javascript">
<!--
LoadData(); //载入数据
-->
</script>
<!-- Web UI设计 刘付灵 E-mail:Foolin@126.com 2009年6月10日 -->

