<%@ Page Language="C#" MasterPageFile="~/Admin/AdminPage.master" AutoEventWireup="true" CodeFile="AdminAdd.aspx.cs" Inherits="Admin_AddAdmin" Title="Untitled Page" %>
<asp:Content ID="Content1" ContentPlaceHolderID="Location" Runat="Server">
��ӹ���Ա
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentSide" Runat="Server">
<!--��Ŀ-->
    <div class="box">
      <div class="title"><span class="titletxt">����Ա����</span></div>
        <div class="content">
            <ul>
            <li><a href="AdminAdd.aspx">��ӹ���Ա</a></li>
            <li><a href="AdminList.aspx">����Ա�б�</a></li>
            </ul>
        </div>
    </div>
</asp:Content>
<asp:Content ID="Content3" ContentPlaceHolderID="ContentMain" Runat="Server">
<div style="width:98%; margin:0px auto;">
<div class="list">
    <table>
        <tr>
            <th colspan="2">��ӹ���Ա��Ϣ</th>
        </tr>
        <tr>
            <td>����Ա����</td>
            <td> 
                <asp:TextBox ID="txtAdminName" runat="server"></asp:TextBox></td>
        </tr>
        <tr>
            <td>���룺</td>
            <td>						<!--����ʵ����--begin-->
                <asp:TextBox ID="txtPassword" runat="server"></asp:TextBox></td>
        </tr>
        <tr>
            <td>Ȩ��</td>
            <td>
			    <asp:TextBox ID="txtPower" runat="server"></asp:TextBox></td>
        </tr>
        <tr>
            <td></td>
            <td>  <asp:Button ID="btnSave" runat="server" Text="����" OnClick="btnSave_Click"/>
                                <a href="AdminList.aspx">ȡ��</a> <br /></td>
        </tr>
    </table>   
</div>
</div>
    <br />
    <br />
</asp:Content>

