<%@ Page Language="C#" AutoEventWireup="true" CodeFile="Default.aspx.cs" Inherits="Install_Default" %>

<!DOCTYPE html PUBLIC "-//W3C//DTD XHTML 1.0 Transitional//EN" "http://www.w3.org/TR/xhtml1/DTD/xhtml1-transitional.dtd">

<html xmlns="http://www.w3.org/1999/xhtml" >
<head runat="server">
    <title>E酷校报管理系统-安装</title>
<style type="text/css">
<!--
body{
	font-family:"微软雅黑",Georgia, "Times New Roman", Times, serif;
	font-size:14px;
}

.wrap{
	text-align:center;
}

.footer{
	line-height:22px;
	text-align:center;
	padding-top:30px;
}
.footer p{margin:5px;}

.title{
	font-size:24px;
	font-weight:bold;
	text-align:center;
	padding-top:20px;
	padding-bottom:20px;
}
.btn{
	text-align:center;
	padding:10px;
}
.btn input{
	padding:6px;
	font-size:14px;
}


#step1{ display:block; text-align:left;}
.license {
	margin:0px auto;
	line-height:22px;
	height:450px;
	width:70%;
	padding:10px 20px;
	border:#EBEBEB 8px solid;
	overflow:scroll;
	scrollbar-face-color:#EEE ;
	scrollbar-shadow-color: #ffffff; 
	scrollbar-highlight-color:#ffffff; 
	scrollbar-3dlight-color: #ffffff;  
	scrollbar-darkshadow-color: #ffffff; 
	scrollbar-track-color:#ffffff; 
	scrollbar-arrow-color: ffffff;
	background:#F9F9F9;
}


#step2 { display:none;}
.form{margin:0px auto; border:#EBEBEB 5px solid;}
table.form { width:550px;}
table.form tr{background:#F3F3F3;}
table.form td{ padding:5px;}
td.name { text-align:right;}
td.inputtxt { width:75%; text-align:left; color:#666;}
.inputtxt input{ width:250px; height:22px; line-height:22px;}


#step3 { display:none;}
.state{ margin:0px auto; border:#EBEBEB 5px solid; width:500px; text-align:left;}
.state dl{ margin:2px; background:#F3F3F3; padding:10px;}
.state dl dt{ text-align:center; font-size:16px; font-weight:bold; background:#FFF; line-height:35px; margin-bottom:10px;}
.state dl dd{ line-height:25px; border-bottom:2px #FFF solid; margin-left:0px; padding-left:10px; }
.success{ color:green;}
.warn{ color:#00F;}
.error{ color:#F00;}


#cancel { display:none;}
.cancel{ margin:0px auto;  text-align:left; border:#EBEBEB 5px solid; width:60%; line-height:25px; padding:3px;}
.ourinfo{ background:#F9F9F9; padding:20px 10px;}

#hasInstall { display:none;}
.box{ margin:0px auto;  text-align:left; border:#EBEBEB 5px solid; width:60%; line-height:25px; padding:3px;}
-->
</style>
<script language="javascript" type="text/javascript" src="Scripts/Base.js"></script>
<script type="text/javascript" language="javascript">
<!--
function $(o){ return typeof(o)=="string" ? document.getElementById(o) : o;}
//获取URL
function GetUrl(ProtoString){
    var paraString =  ProtoString.split('#');
    if(!paraString[1]){
        return null;
    }
    var paras = paraString[1].split('&');
    var allParas = new Array(paras.length);
    for(var i = 0; i<paras.length; i++){
           allParas[GetPara(paras[i])[0]] = GetPara(paras[i])[1];
    }
    return allParas;
}

//获取Para
function GetPara(word){
    if(!word){
        return null;
    }
    var onePara = word.split('=');
    return onePara;
}

function initStep(){
    var url = document.location.href;
    var paras = new Array();
    paras = GetUrl(url);
	if(paras == null)
		step1();
	else if(paras["step"]){
		switch(paras["step"]){
			case "step1":
				step1(); break;
			case "step2":
				step2(); break;
			case "step3":
				step3(); break;
			case "hasInstall":
				hasInstall(); break;
			case "cancel":
				cancel(); break;
			default:
				step1(); break;
		}
	}
	else
		step1();
		
}

function cancel(){
	$("step1").style.display = "none";
	$("step2").style.display = "none";
	$("step3").style.display = "none";
	$("cancel").style.display = "block";
	$("hasInstall").style.display = "none";
	window.location.href='#step=cancel';return false; 
}

function step1(){
	$("step1").style.display = "block";
	$("step2").style.display = "none";
	$("step3").style.display = "none";
	$("cancel").style.display = "none";
	$("hasInstall").style.display = "none";
	window.location.href='#step=step1';return false; 
}

function step2(){
	$("step1").style.display = "none";
	$("step2").style.display = "block";
	$("step3").style.display = "none";
	$("cancel").style.display = "none";
	$("hasInstall").style.display = "none";
	window.location.href='#step=step2';return false; 
}

function step3(){
	$("step1").style.display = "none";
	$("step2").style.display = "none";
	$("step3").style.display = "block";
	$("cancel").style.display = "none";
	$("hasInstall").style.display = "none";
	window.location.href='#step=step3';
	return false; 
}

function hasInstall(){
	$("step1").style.display = "none";
	$("step2").style.display = "none";
	$("step3").style.display = "none";
	$("cancel").style.display = "none";
	$("hasInstall").style.display = "block";
	window.location.href='#step=hasInstall';return false; 
}

window.onload = initStep;
//-->
</script>
</head>
<body>
    <form id="form1" runat="server">
<div class="wrap">
    <div id="step1">
    	<div class="title">第一步：E酷校报管理系统安装协议</div>
        <div class="license">
            <p>感谢您选择E酷校报管理系统，本系统由刘付灵、朱松辉两人基于ASP.Net+MSSQL 技术开发。</p>
            <p>为了使你正确并合法的使用本软件，请你在使用前务必阅读清楚下面的协议条款：</p>
            <p><strong>一、本协议仅适用于E酷校报管理系统1.x.x 版本，E酷工作室对本协议有最终解释权。 </strong></p>
            <p><strong>二、协议许可的权利 </strong><br />
              1、您可以在完全遵守本最终用户授权协议的基础上，将本软件应用于商业或非商业用途。 <br />
              2、您可以在协议规定的约束和限制范围内修改 本系统 源代码或界面风格以适应您的网站要求。 <br />
              3、您拥有使用本软件构建的网站全部内容所有权，并独立承担与这些内容的相关法律义务。 <br />
              4、获得商业授权之后，您可以依据所购买的授权类型中确定的技术支持内容，自购买时刻起，在技术支持期限内拥有通过指定的方式获得指定范围内的技术支持服务。商业授权用户享有反映和提出意见的权力，相关意见将被作为首要考虑，但没有一定被采纳的承诺或保证。 </p>
            <p><strong>二、协议规定的约束和限制 </strong><br />
              1、不得将本软件用于国家不允许开设的网站（包括色情、反动、含有病毒，赌博类网站）。<br />
              2、未经官方许可，不得对本软件或与之关联的商业授权进行出租、出售、抵押或发放子许可证。 <br />
              3、未经官方许可，禁止在本软件的整体或任何部分基础上以发展任何派生版本、修改版本或第三方版本用于重新分发。 <br />
              4、如果您未能遵守本协议的条款，您的授权将被终止，所被许可的权利将被收回，并承担相应法律责任。 </p>
            <p><strong>三、有限担保和免责声明 </strong><br />
              1、本软件及所附带的文件是作为不提供任何明确的或隐含的赔偿或担保的形式提供的。 <br />
              2、用户出于自愿而使用本软件，您必须了解使用本软件的风险，在尚未购买产品技术服务之前，我们不承诺对免费用户提供任何形式的技术支持、使用担保，也不承担任何因使用本软件而产生问题的相关责任。 <br />
              3、电子文本形式的授权协议如同双方书面签署的协议一样，具有完全的和等同的法律效力。您一旦开始确认本协议并安装本系统，即被视为完全理解并接受本协议的各项条款，在享有上述条款授予的权力的同时，受到相关的约束和限制。协议许可范围以外的行为，将直接违反本授权协议并构成侵权，我们有权随时终止授权，责令停止损害，并保留追究相关责任的权力。 <br />
              4、如果本软件带有其它软件的整合API示范例子包，这些文件版权不属于本软件官方，并且这些文件是没经过授权发布的，请参考相关软件的使用许可合法的使用。</p>
            <p>版权所有 (c)2009-2010，E酷工作室 保留所有权利。 </p>
            <p>协议发布时间：  2009年7月26日 By Foolin (www.eekku.com) </p>
        </div>
        <div class="btn">
            <input type="button" value="同意" onclick="step2();" /> &nbsp;&nbsp;&nbsp;&nbsp;
            <input type="button" value="不同意" onclick="cancel();" />
        </div>
    </div>
    
    <div id="step2">
    	<div class="title">第二步：填写安装配置数据</div>
        <table class="form">
            <tr>
                <td class="name">登录帐号：</td><td class="inputtxt">
                    <asp:TextBox ID="username" ReadOnly="true"  runat="server" Enabled="false">admin</asp:TextBox>（请进入后台修改）</td>
            </tr>
            <tr>
                <td class="name">登录密码：</td><td  class="inputtxt"><asp:TextBox ID="passsword" ReadOnly="true" Enabled="false" runat="server">123456</asp:TextBox></td>
            </tr>
            <tr>
                <td class="name">数据库服务器：</td><td class="inputtxt"><asp:TextBox ID="DBserver" runat="server">localhost\SQL2005</asp:TextBox> (包括端口)</td>
            </tr>
            <tr>
                <td class="name">数据库名：</td><td  class="inputtxt"><asp:TextBox ID="DBname" runat="server">Newspaper</asp:TextBox> (请先建数据库)</td>
            </tr>
            <tr>
                <td class="name">数据库用户名：</td><td  class="inputtxt"><asp:TextBox ID="DBuid" runat="server">sa</asp:TextBox></td>
            </tr>
            <tr>
                <td class="name">数据库密码：</td><td  class="inputtxt"><asp:TextBox ID="DBpwd" runat="server">123456</asp:TextBox></td>
            </tr>
            <tr>
                <td class="name">当前安装目录：</td><td  class="inputtxt"><asp:TextBox ID="path" runat="server">/</asp:TextBox> <br />（后面要加“/”,例如：/paper/，根目录则为“/”。）</td>
            </tr>
            <tr>
                <td colspan="2" class="btn"> <input type="button" value="上一步" onclick="step1();"  /> &nbsp;&nbsp;&nbsp;&nbsp;
                    <asp:Button ID="btnInstall" runat="server" Text="下一步" OnClick="btnInstall_Click" /></td>
            </tr>
         </table>
    </div>  
    
    <div id="step3">
    		<div class="title">第三步：完成本系统的安装</div>
			<div class="state">
            <dl>
            	<dt> 系统安装状态 </dt>
            	<dd> 初始帐号和密码：  <span class="success"><%= Session["AdminAndPwd"]%></span></dd>
            	<dd> 当前安装目录：  <%= Session["InstallPath"]%></dd>
            	<dd> 测试连接数据库：  <%= Session["ConnectState"]%></dd>
                <dd> 生成配置文件：  <%= Session["CreateConfigState"]%></dd>
                <dd> 创建数据库表：  <%= Session["CreateTableState"]%> </dd>
                <dd> 创建数据库存储过程：  <%= Session["CreateProcState"]%></dd>
                <dd> 锁定安装文件：  <%= Session["LockInstallState"]%></dd>
                <!--<dd> 初始化管理员账号： </dd>-->
                <dd>   <span class="warn">！注意：</span> 如果出现有安装错误，请按照安装说明书进行自行配置系统。非常感谢您使用本系统！祝你旅途愉快！</dd>
                <dd class="btn"> <input type="button" value="完成" onclick="hasInstall();"   /> </dd>
            </dl>
            </div>
    </div>
    
    <div id="cancel">
    	<div class="title">您已经取消了本次系统的安装！</div>
        <div class="cancel">
        	<div class="ourinfo">
            &nbsp;&nbsp;<b>Author: Foolin </b><br />
            	&nbsp;&nbsp;&nbsp;&nbsp; QQ：970026999<br />
                &nbsp;&nbsp;&nbsp;&nbsp; E-mail：Foolin@126.com<br /><br />
            &nbsp;&nbsp;<b>Author: 叮当</b><br />
            	&nbsp;&nbsp;&nbsp;&nbsp; QQ：371796533<br />
                &nbsp;&nbsp;&nbsp;&nbsp; E-mail：zhushgo@msn.com<br /><br />
            网址：http://www.eekku.com （E酷工作室）<br /><br />
            本系统由刘付灵、朱松辉两人独立开发。如果有任何问题或者建议，请联系作者，万分感谢！<br />
            </div>
        </div>
    </div>
    
    <div id="hasInstall">
    	<div class="title">你已经安装了本系统！</div>
        <div class="box">
        	<div class="ourinfo">
            <div class="error">如果需要重新安装，请手工删除Install/目录下的Install.lock文件，然后运行本页面！【<a href="Default.aspx">点击刷新</a>】</div>
           <p>
                >><%= Session["AdminAndPwd"]%><br />
            	>> <a href="../Default.aspx">进入首页</a> <br />
              	>> <a href="../Admin/Login.aspx">进入后台管理</a>
                
                <div class="warn">!注意：如果打开首页出错，表明Web.config文件没有权限修改，请自行按照说明进行手动配置系统。</div>
           </p>
        	<br />
            &nbsp;&nbsp;<b>Author: Foolin </b><br />
            	&nbsp;&nbsp;&nbsp;&nbsp; QQ：970026999<br />
                &nbsp;&nbsp;&nbsp;&nbsp; E-mail：Foolin@126.com<br /><br />
            &nbsp;&nbsp;<b>Author: 叮当</b><br />
            	&nbsp;&nbsp;&nbsp;&nbsp; QQ：371796533<br />
                &nbsp;&nbsp;&nbsp;&nbsp; E-mail：zhushgo@msn.com<br /><br />
            网址：http://www.eekku.com （E酷工作室）<br />
            本系统由刘付灵、朱松辉两人独立开发。如果有任何问题或者建议，请联系作者，万分感谢！<br />
            </div>
        </div>
    </div>
    
    <div class="footer">
            <p>版权所有 (c)2009-2010，E酷工作室 (www.eekku.com) 保留所有权利。 </p>
            <p>本系统由刘付灵、朱松辉两人独立开发。Author: Foolin &nbsp;&nbsp; QQ: 970026999 E-mail: Foolin@126.com </p>
    </div>
</div>
    </form>
</body>
</html>
