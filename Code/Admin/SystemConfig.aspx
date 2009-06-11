<%@ Page Language="C#" MasterPageFile="~/Admin/AdminPage.master" AutoEventWireup="true" CodeFile="SystemConfig.aspx.cs" Inherits="Admin_SystemConfig" Title="Untitled Page" %>
<asp:Content ID="Content1" ContentPlaceHolderID="Location" Runat="Server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentSide" Runat="Server">
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
                <asp:TextBox ID="txtPaperName"  Width="200px" runat="server"></asp:TextBox> 
                <asp:RequiredFieldValidator ID="RequiredFieldValidator1" runat="server" ControlToValidate="txtPaperName"
                    ErrorMessage="不能为空"></asp:RequiredFieldValidator></td>
        </tr>
        <tr>
            <td>站点名：</td>
            <td>
                <asp:TextBox ID="txtSiteName"  Width="200px" runat="server"></asp:TextBox> 
                <asp:RequiredFieldValidator ID="RequiredFieldValidator2" runat="server" ControlToValidate="txtSiteName"
                    ErrorMessage="不能为空"></asp:RequiredFieldValidator></td>
        </tr>
        <tr>
            <td>站点URL</td>
            <td>
                <asp:TextBox ID="txtSiteUrl" runat="server" Width="300px"></asp:TextBox> 
                <asp:RequiredFieldValidator ID="RequiredFieldValidator3" runat="server" ControlToValidate="txtSiteUrl"
                    ErrorMessage="不能为空"></asp:RequiredFieldValidator></td>
        </tr>
        <tr>
            <td>报刊信息：</td>
            <td>
				<asp:TextBox ID="txtPaperInfo" runat="server" TextMode="MultiLine" Height="50px" Width="394px"></asp:TextBox>
                <asp:RequiredFieldValidator ID="RequiredFieldValidator4" runat="server" ControlToValidate="txtPaperInfo"
                    ErrorMessage="不能为空"></asp:RequiredFieldValidator></td>
        </tr>
        <tr>
            <td>是否开放注册：</td>
            <td>
                是：<asp:RadioButton ID="RadioButton1" GroupName="IsOpenRegister" runat="server" />
                &nbsp; 
                否：<asp:RadioButton ID="RadioButton2" GroupName="IsOpenRegister"  runat="server" /></td>
        </tr>
        <tr>
            <td>编辑部名称：</td>
            <td>
				<asp:TextBox ID="txtEditorName"  Width="200px" runat="server"></asp:TextBox>
                <asp:RequiredFieldValidator ID="RequiredFieldValidator6" runat="server" ControlToValidate="txtEditorAddrs"
                    ErrorMessage="不能为空"></asp:RequiredFieldValidator></td>
        </tr>
         <tr>
            <td>编辑部地址：</td>
            <td>
				<asp:TextBox ID="txtEditorAddrs" runat="server" Width="330px"></asp:TextBox>
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
            <td>  <asp:Button ID="btnSave" runat="server" Text="更新" OnClick="btnSave_Click"/>
                                <br /></td>
        </tr>
    </table>   
</div>
</asp:Content>

