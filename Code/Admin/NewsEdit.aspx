<%@ Page Language="C#" MasterPageFile="~/Admin/AdminPage.master" AutoEventWireup="true" CodeFile="NewsEdit.aspx.cs" Inherits="Admin_NewsEdit" Title="Untitled Page" %>
<%@ Register Assembly="FredCK.FCKeditorV2" Namespace="FredCK.FCKeditorV2" TagPrefix="FCKeditorV2" %>
<asp:Content ID="Content1" ContentPlaceHolderID="Location" Runat="Server">
编辑新闻信息
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentSide" Runat="Server">
<!--栏目-->
    <div class="box">
      <div class="title"><span class="titletxt">新闻面板</span></div>
        <div class="content">
            <ul>
            <li><a href="NewsAdd.aspx">添加新闻</a></li>
            <li><a href="NewsList.aspx">新闻列表</a></li>
            </ul>
        </div>
    </div>
</asp:Content>
<asp:Content ID="Content3" ContentPlaceHolderID="ContentMain" Runat="Server">
<div class="list">
    <table>
        <tr>
            <th colspan="2">添加新闻信息</th>
        </tr>
        <tr>
            <td style="height: 25px">
                期刊：</td>
            <td style="height: 25px"> 
                第<asp:DropDownList ID="txtPaperID" runat="server" OnSelectedIndexChanged="txtPaperID_SelectedIndexChanged" AutoPostBack="True"></asp:DropDownList>期</td>
        </tr>
        <tr>
            <td>版面：</td>
            <td> 
                第<asp:DropDownList ID="txtPageID" runat="server"></asp:DropDownList>版</td>
        </tr>
        <tr>
            <td>标题：</td>
            <td>
                <asp:TextBox ID="txtTitle" Width="400" runat="server"></asp:TextBox> 
            </td>
        </tr>
        <tr>
            <td>作者：</td>
            <td>
				<asp:TextBox ID="txtAuthor" runat="server"></asp:TextBox>
            </td>
        </tr>
        <tr>
            <td>新闻内容:</td>
            <td>
				
            </td>
        </tr>
        <tr>
            <td colspan="2">
				<FCKeditorV2:FCKeditor ID="txtContent" ToolbarSet="MyBar" Height="500px" runat="server"> </FCKeditorV2:FCKeditor>
            </td>
        </tr>
        <tr>
            <td>位置：</td>
            <td>
				<asp:TextBox ID="txtPosition" runat="server"></asp:TextBox>
            </td>
        </tr>
        <tr>
            <td style="height: 27px">
                添加人：</td>
            <td style="height: 27px">
				<asp:TextBox ID="txtAddUser" ReadOnly="true" runat="server" Enabled="False"></asp:TextBox> （不能修改）
            </td>
        </tr>    
        <tr>
            <td></td>
            <td>  <asp:Button ID="btnSave" runat="server" Text="保存" OnClick="btnSave_Click"/>
                                <a href="NewsList.aspx">取消</a> <br /></td>
        </tr>
    </table>   
</div>
</asp:Content>

