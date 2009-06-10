<%@ Page Language="C#" MasterPageFile="~/Admin/AdminPage.master" AutoEventWireup="true" CodeFile="SystemCofigEdit.aspx.cs" Inherits="Admin_ConfigList" Title="Untitled Page" %>
<asp:Content ID="Content1" ContentPlaceHolderID="Location" Runat="Server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentSide" Runat="Server">
<!--栏目-->
    <div class="box">
      <div class="title"><span class="titletxt">配置面板</span></div>
        <div class="content">
            <ul>
            <li><a href="SystemCofigEdit.aspx">修改配置</a></li>
	        <li><a href="SystemCofig.aspx">配置清单</a></li>
            </ul>
        </div>
    </div>
</asp:Content>
<asp:Content ID="Content3" ContentPlaceHolderID="ContentMain" Runat="Server">
<div class="list">
    <table>
        <tr>
            <th colspan="2">修改系统配置信息</th>
        </tr>
        <tr>
            <td style="height: 25px">报刊名：</td>
            <td>
                <asp:TextBox ID="txtPaperName" runat="server"></asp:TextBox> 
                <asp:RequiredFieldValidator ID="RequiredFieldValidator1" runat="server" ControlToValidate="txtPaperName"
                    ErrorMessage="不能为空"></asp:RequiredFieldValidator></td>
        </tr>
        <tr>
            <td>站点名：</td>
            <td>
                <asp:TextBox ID="txtSiteName" runat="server"></asp:TextBox> 
                <asp:RequiredFieldValidator ID="RequiredFieldValidator2" runat="server" ControlToValidate="txtSiteName"
                    ErrorMessage="不能为空"></asp:RequiredFieldValidator></td>
        </tr>
        <tr>
            <td>站点URL</td>
            <td>
                <asp:TextBox ID="txtSiteUrl" runat="server"></asp:TextBox> 
                <asp:RequiredFieldValidator ID="RequiredFieldValidator3" runat="server" ControlToValidate="txtSiteUrl"
                    ErrorMessage="不能为空"></asp:RequiredFieldValidator></td>
        </tr>
        <tr>
            <td>报刊信息：</td>
            <td>
				<asp:TextBox ID="txtPaperInfo" runat="server"></asp:TextBox>
                <asp:RequiredFieldValidator ID="RequiredFieldValidator4" runat="server" ControlToValidate="txtPaperInfo"
                    ErrorMessage="不能为空"></asp:RequiredFieldValidator></td>
        </tr>
        <tr>
            <td>是否开放注册：</td>
            <td>
				<asp:TextBox ID="txtIsOpenRegister" runat="server"></asp:TextBox>
                <asp:RequiredFieldValidator ID="RequiredFieldValidator5" runat="server" ControlToValidate="txtIsOpenRegister"
                    ErrorMessage="不能为空"></asp:RequiredFieldValidator></td>
        </tr>
        <tr>
            <td>编辑部名称：</td>
            <td>
				<asp:TextBox ID="txtEditorName" runat="server"></asp:TextBox>
                <asp:RequiredFieldValidator ID="RequiredFieldValidator6" runat="server" ControlToValidate="txtEditorAddrs"
                    ErrorMessage="不能为空"></asp:RequiredFieldValidator></td>
        </tr>
         <tr>
            <td>编辑部地址：</td>
            <td>
				<asp:TextBox ID="txtEditorAddrs" runat="server"></asp:TextBox>
                <asp:RequiredFieldValidator ID="RequiredFieldValidator7" runat="server" ControlToValidate="txtEditorAddrs"
                    ErrorMessage="不能为空"></asp:RequiredFieldValidator></td>
        </tr>
        <tr>
            <td>编辑部电话：</td>
            <td>
				<asp:TextBox ID="txtEditorPhone" runat="server"></asp:TextBox>
                <asp:RequiredFieldValidator ID="RequiredFieldValidator8" runat="server" ControlToValidate="txtEditorPhone"
                    ErrorMessage="不能为空"></asp:RequiredFieldValidator></td>
        </tr>
        <tr>
            <td>编辑部传真：</td>
            <td>
				<asp:TextBox ID="txtEditorFax" runat="server"></asp:TextBox>
                <asp:RequiredFieldValidator ID="RequiredFieldValidator9" runat="server" ControlToValidate="txtEditorFax"
                    ErrorMessage="不能为空"></asp:RequiredFieldValidator></td>
        </tr>
        <tr>
            <td>编辑部邮箱：</td>
            <td>
				<asp:TextBox ID="txtEditorEmail" runat="server"></asp:TextBox>
                <asp:RequiredFieldValidator ID="RequiredFieldValidator10" runat="server" ControlToValidate="txtEditorEmail"
                    ErrorMessage="不能为空"></asp:RequiredFieldValidator></td>
        </tr>
        <tr>
            <td></td>
            <td>  <asp:Button ID="btnSave" runat="server" Text="保存" OnClick="btnSave_Click"/>
                                <a href="SystemCofig.aspx">取消</a> <br /></td>
        </tr>
    </table>   
</div>
</asp:Content>

