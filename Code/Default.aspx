<%@ Page Language="C#" AutoEventWireup="true"  CodeFile="Default.aspx.cs" Inherits="_Default" %>

<!DOCTYPE html PUBLIC "-//W3C//DTD XHTML 1.0 Transitional//EN" "http://www.w3.org/TR/xhtml1/DTD/xhtml1-transitional.dtd">
<html xmlns="http://www.w3.org/1999/xhtml">
<head>
<meta http-equiv="Content-Type" content="text/html; charset=gb2312" />
<title>���ݴ�ѧУ��</title>
<link href="Css/Index.css" rel="stylesheet" type="text/css" />
<script language="javascript" type="text/javascript" src="Scripts/Base.js"></script>
<script language="javascript" type="text/javascript" src="Scripts/Ajax.js"></script>
<script language="javascript" type="text/javascript" src="Scripts/Paper.js"></script>
<script type="text/javascript" language="javascript">
<!--
//ʱ��,ÿ��ˢ��
setInterval("$('nowDate').innerHTML=new Date().toLocaleString()+' ����'+'��һ����������'.charAt(new Date().getDay());",1000);
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
                            ��Ϊ��ҳ</a> |</li>
                        <li><a href="#" onclick="return Love();">�����ղ�</a> |</li>
                        <li><a href="AboutUs.html" target="_blank">��������</a></li>
                        </ul>
                </div>
                <div class="clear"></div>
                <div class="paperNav">
                         <asp:DropDownList ID="selectPaper" onchange="ChangePaper(this.options[this.selectedIndex].value)" runat="server">
                            <asp:ListItem Value="0">----��ѡ������----</asp:ListItem>
                          </asp:DropDownList>
                        
                        <span class="paperNO">��<asp:Label ID="paperTotal" runat="server" Text="Label"></asp:Label>�� ��ǰ������<span id="paperID">����</span>
                        </span>
                </div>
            </div>
            <div class="headRight">
                    <div class="paperInfo">
                        �й����ݴ�ѧίԱ������ ����ͳһ���ţ�CN44-0803/��G��
                    </div>
            </div>
            <div class="clear"></div>
    </div>
    <div class="main">
    	<div class="mainLeft">
        		<div class="pageImageBorder">
        		<div id="pageImage">
                    <!--ͼ����ʾ����--> 
                </div>
                </div>
        </div>
        <div class="mainRight">
                <div class="search">
                        ��������: <input type="text" id="keyword" />
                        <input class="btnSearch" onclick="Search()" type="button" value="����" />
                        <span id="nowDate">��ǰ���ڣ�</span>

                </div>
                <div class="container">
                        <div class="pageNav">
                        	<span style="float:left; padding-left:10px;">���浼����</span>
                            <span id="pageNav">
                                    <ul>
                                    <li class="on"><a href="#">��һ��</a></li> 
                                    <li><a href="#">�ڶ���</a></li>
                                    <li><a href="#">������</a></li>
                                    <li><a href="#">���İ�</a></li>
                                    </ul>
                            </span>
                            <div class="clear"></div>
                        </div>
                        <div id="news">
                        
                        <!--��������-->

                        </div>
                        <div class="clear"></div>
                </div>
        </div>
        <div class="clear"></div>
    </div>
    <div class="clear"></div>
    <div class="footer">���ݴ�ѧУ���༭������  ���䣺gdnews@126.com �绰��020-87542701  ���棺020-87541544<br />
��ַ�����ݴ�ѧ����B������¥  �ʱࣺ510006<br /> 
��Ȩ����&copy;2009    <a href="http://www.eekku.com/" target="_blank">E�Ṥ����</a>   ����:�����飨Foolin�������ɻ� [<a href="Admin/Login.aspx" target="_blank">�����¼</a>]
	</div>
</div>
</form>
</body>
</html>
<script type="text/javascript" language="javascript">
<!--
LoadData(); //��������
-->
</script>
<!-- Web UI��� ������ E-mail:Foolin@126.com 2009��6��10�� -->

