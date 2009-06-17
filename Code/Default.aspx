<%@ Page Language="C#" AutoEventWireup="true"  CodeFile="Default.aspx.cs" Inherits="_Default" %>

<!DOCTYPE html PUBLIC "-//W3C//DTD XHTML 1.0 Transitional//EN" "http://www.w3.org/TR/xhtml1/DTD/xhtml1-transitional.dtd">
<html xmlns="http://www.w3.org/1999/xhtml">
<head>
<meta http-equiv="Content-Type" content="text/html; charset=gb2312" />
<title><%=site.SiteName %> - <%=site.SiteUrl%></title>
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
<form id="form1" onsubmit="return Search();" runat="server">
<div class="wrapper">
	<div class="header">
            <div class="headLeft">
                <div class="loveFav">
                        <ul>
                        <li><a href="#" onclick="return HomePage.call(this);">
                            ��Ϊ��ҳ</a> |</li>
                        <li><a href="#" onclick="return Love();">�����ղ�</a> |</li>
                        <li><a href="#AboutUs.html" target="_blank">��������</a></li>
                        </ul>
                </div>
                <div class="clear"></div>
                <div class="paperNav">
                         <asp:DropDownList ID="selectPaper" onchange="ChangePaper(this.options[this.selectedIndex].value)" runat="server">
                            <asp:ListItem Value="0">----��ѡ������----</asp:ListItem>
                          </asp:DropDownList>
                        
                        <span class="paperNO">��<asp:Label ID="paperTotal" runat="server" Text=" 0 "></asp:Label>�� ��ǰ������<span id="paperID">����</span>
                        </span>
                </div>
                
            </div>
            <div class="headRight">
                    <div class="paperInfo">
                        <%=site.PaperInfo %>
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
                
                <div id="paperNavbar">
				<a href="#">��һ��</a> <a href="#">��һ��</a> ��ǰ����5��/��1��  <a href="#">��һ��</a> <a href="#">��һ��</a>
                </div>

      </div>
        <div class="mainRight">
                <div class="search">
                        ��������: <input type="text" id="keyword" />
                        <input class="btnSearch" onclick="Search()" type="button" value="����" />
                        <span id="nowDate">��ǰ����</span>

                </div>
                <div class="container">
                        <div class="pageNav">
                            <span id="currentPaperID">���浼����</span>
                            <span id="pageNav">
                            	<!--���浼��-->
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
    <div class="footer">  <%=site.EditorName %> �绰��<%=site.EditorPhone %>  ���棺<%=site.EditorFax %> <br />
���䣺<%=site.EditorEmail%>   ��ַ��<%=site.EditorAddrs %>  �ʱࣺ<%=site.EditorPostCode %> <br />  
��Ȩ����&copy;2009  <%=site.PaperName %>     <a href="http://www.eekku.com/" target="_blank">E�Ṥ����</a>   ����:�����飨Foolin�������ɻ� [<a href="Admin/Login.aspx" target="_blank">�����¼</a>]
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
<!-- Web UI & ǰ̨������ƣ������� E-mail:Foolin@126.com 2009��6��11�� -->

