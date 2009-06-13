<%@ Page Language="C#" MasterPageFile="~/Admin/AdminPage.master" AutoEventWireup="true" CodeFile="PaperAdd.aspx.cs" Inherits="Admin_PaperAdd" Title="Untitled Page" %>
<asp:Content ID="Content1" ContentPlaceHolderID="Location" Runat="Server">
    添加校刊
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentSide" Runat="Server">
    <!--栏目-->
    <div class="box">
      <div class="title"><span class="titletxt">期刊面板</span></div>
        <div class="content">
            <ul>
            <li><a href="PaperAdd.aspx">添加期刊</a></li>
            <li><a href="PaperList.aspx">期刊列表</a></li>
            </ul>
        </div>
    </div>
</asp:Content>
<asp:Content ID="Content3" ContentPlaceHolderID="ContentMain" Runat="Server">
<div style="width:98%; margin:0px auto;">
<div class="list">
    <table>
        <tr>
            <th colspan="2">添加期刊信息</th>
        </tr>
        <tr>
            <td>期数：</td>
            <td> 
                <asp:TextBox ID="txtPaperID" runat="server"></asp:TextBox> （请填数字）</td>
        </tr>
        <tr>
            <td>出版日期：</td>
            <td>
						<!--日期实例化--begin-->
                <asp:TextBox ID="txtPublishDate" runat="server"></asp:TextBox> 
                <asp:Button ID="Button1" runat="server" Text="选择日期" OnClick="Button1_Click" />
						<!--end-->
            </td>
        </tr>
        <tr>
            <td></td>
            <td>
				<!--日期实例化--begin-->
                <asp:Calendar ID="Calendar1" runat="server" OnSelectionChanged="Calendar1_SelectionChanged"></asp:Calendar>
				<!--end-->
            </td>
        </tr>
        <tr>
            <td>版面数：</td>
            <td>
                <asp:TextBox ID="txtNumOfPage" runat="server">4</asp:TextBox> （请填数字）</td>
        </tr>
        <tr>
            <td>是否显示：</td>
            <td>
                是<asp:RadioButton ID="ShowTrue" GroupName="IsShow" runat="server" />   
                否<asp:RadioButton ID="ShowFalse" GroupName="IsShow" runat="server" /></td>
        </tr>
        <tr>
            <td></td>
            <td>  <asp:Button ID="btnSave" runat="server" Text="保存校报" OnClick="btnSave_Click"/>
                                <a href="PaperList.aspx">取消</a> <br /></td>
        </tr>
    </table>   
</div>
</div>
    <br />
    <br />
</asp:Content>

