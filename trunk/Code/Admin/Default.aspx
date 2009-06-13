<%@ Page Language="C#" MasterPageFile="~/Admin/AdminPage.master" AutoEventWireup="true" CodeFile="Default.aspx.cs" Inherits="Admin_Default" Title="Untitled Page" %>
<asp:Content ID="Content1" ContentPlaceHolderID="Location" Runat="Server">
后台首页
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentSide" Runat="Server">
                        <!--栏目-->
                        <div class="box">
                          <div class="title"><span class="titletxt">系统管理</span></div>
                            <div class="content">
                                <ul>
                                <li><a href="SystemConfig.aspx">系统配置</a></li>
                                <li><a href="AdminList.aspx">团队管理</a></li>
                                <li><a href="AdminAdd.aspx">添加管理员</a></li>
                                <li><a href="#UserList.aspx">用户管理</a></li>
                                </ul>
                            </div>
                        </div>
</asp:Content>
<asp:Content ID="Content3" ContentPlaceHolderID="ContentMain" Runat="Server">

                            <!--栏目-->
                            <div class="list">
                                <table width="100%" cellspacing="0" border="0" style="text-align:center;">
                                    <tr>
                                        <th>
                                            栏目</th>
                                        <th colspan="2">
                                            便捷操作</th>
                                    </tr>

                                    <tr onmouseover="this.style.background='#FFFFFF';" onmouseout="this.style.background='#E6F2FF'">
                                        <td>
                                            <a href="PaperList.aspx">期刊管理</a></td>
                                        <td>
                                            <a href="PaperList.aspx">查看期刊列表</a></td>
                                        <td>
                                            <a href="PaperAdd.aspx">添加期刊</a></td>
                                    </tr>



                                    <tr onmouseover="this.style.background='#FFFFFF';" onmouseout="this.style.background='#E6F2FF'">
                                        <td>
                                            <a href="PageList.aspx">版面管理</a></td>
                                        <td>
                                            <a href="PageList.aspx">查看版面列表</a></td>
                                        <td>
                                            <a href="PageAdd.aspx">添加版面</a></td>
                                    </tr>
                                    
                                    
                                    <tr onmouseover="this.style.background='#FFFFFF';" onmouseout="this.style.background='#E6F2FF'">
                                        <td>
                                            <a href="NewsList.aspx">新闻管理</a></td>
                                        <td>
                                            <a href="NewsList.aspx">查看新闻列表</a></td>
                                        <td>
                                            <a href="NewsAdd.aspx">添加新闻</a></td>
                                    </tr>

                                    <tr>
                                        <td colspan="9"> 

                                           
                                                   </td>
                                    </tr>

                                </table>
                             <div style="color:green; font-size:14px; padding:3px;">操作流程：添加期刊 →  添加版面 → 添加新闻</div>   
                                 
                    </div>
                    
                    
<div style="line-height:22px; padding:10px; font-size:14px; color:Gray; border:1px solid #ACD6FF;  margin:10px 2px;">
    &nbsp;&nbsp;&nbsp;&nbsp;欢迎您使用在线校报阅读系统V1.0，你可以在授权的情况下使用本系统。在未经过作者授权的情况下，禁止对本系统进行任何商业活动。不得对本软件或与之关联的商业授权进行出租、出售、抵押或发放子许可证。
    <br />
    &nbsp;&nbsp;&nbsp;&nbsp;本站前台由刘付灵开发，后台由刘付灵、朱松辉开发。
    <hr />
<pre style="margin:0px; color:Gray;">
    <b>联系方式：</b>
    刘付灵（Foolin）：   Q Q: 252687345       E-mail: Foolin@126.com  
    朱松辉（叮噹）：     Q Q: 371796533       E-mail: zhushgo@msn.com
    主页：               http://www.eekku.com
</pre>
</div>
                    
                 

</asp:Content>

