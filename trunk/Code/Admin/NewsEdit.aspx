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
				<asp:TextBox ID="txtPosition" runat="server"></asp:TextBox> ( 左 | 上 | 宽度 | 高度 ) <input id="ctrlDragPic" type="button" value="关闭操作面板" /> 
            </td>
        </tr>
        <tr>
            <td colspan="2">
                    <script type="text/javascript" src="Inc/GetNewsPosition.js"></script>
                    <script type="text/javascript" src="Inc/Drag.js"></script>
                    <script type="text/javascript" src="Inc/Resize.js"></script>
                    <table width="100%" border="0" cellspacing="0" cellpadding="0" id="DragPicArea" style="display:block;">
                      <tr>
                        <td width="360" height="500"><div id="bgDiv">
                            <div id="dragDiv">
                              <div id="rRightDown"> </div>
                              <div id="rLeftDown"> </div>
                              <div id="rRightUp"> </div>
                              <div id="rLeftUp"> </div>
                              <div id="rRight"> </div>
                              <div id="rLeft"> </div>
                              <div id="rUp"> </div>
                              <div id="rDown"></div>
                            </div>
                          </div></td>
                        <td align="center" valign="top">
                                <div class="hr"></div>
                                操作工具栏
                                <div id="picToolbar">
                                    <input id="idOpacity" type="button" value="全透明" />
                                    <input id="idColor" type="button" value="白色背景" />
                                    <input id="idScale" type="button" value="使用比例" />
                                    <input id="idMin" type="button" value="固定最小尺寸" />
                                    <input id="idView" type="button" value="缩小预览" />
                                    <input id="getSize" type="button" value="选区位置" /><br />
                                </div>
                                <div class="hr"></div>
                                图片预览区域
                                <div id="viewDiv" style="width:280px; height:280px;"> </div>
                                <div class="hr"></div>
                                <div id="picButton">
                                    <input id="getPosition" type="button" value="确定选该区域" />
                                </div>
                      </td>
                      </tr>
                    </table>
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
<script type="text/javascript" language="javascript">
<!--
var ic = new ImgCropper("bgDiv", "dragDiv", "<%=imgPageUrl %>", {
    Width: 360, Height: 500, Color: "#000",
    Resize: true,
    Right: "rRight", Left: "rLeft", Up:	"rUp", Down: "rDown",
    RightDown: "rRightDown", LeftDown: "rLeftDown", RightUp: "rRightUp", LeftUp: "rLeftUp",
    Preview: "viewDiv", viewWidth: 280, viewHeight: 280
})

function InitPosition(left, top, width, height){
    var dragDiv = document.getElementById("dragDiv");
    dragDiv.style.left = left + "px";
    dragDiv.style.top = top + "px";
    dragDiv.style.width = width + "px";
    dragDiv.style.height = height + "px";
    ic.Init();
}

//初始化位置
InitPosition(<%=posLeft %>, <%=posTop %>, <%=posWidth %>, <%=posHeight %>);

/*
$("idSize").onclick = function(){
    if(ic.Height == 200){
        ic.Height = 500;
        this.value = "缩小显示";
    }else{
        ic.Height = 500;
        this.value = "还原显示";
    }
    ic.Init();
}
*/

$("idOpacity").onclick = function(){
    if(ic.Opacity == 0){
        ic.Opacity = 50;
        this.value = "全透明";
    }else{
        ic.Opacity = 0;
        this.value = "半透明";
    }
    ic.Init();
}

$("idColor").onclick = function(){
    if(ic.Color == "#000"){
        ic.Color = "#fff";
        this.value = "白色背景";
    }else{
        ic.Color = "#000";
        this.value = "黑色背景";
    }
    ic.Init();
}

$("idScale").onclick = function(){
    if(ic.Scale){
        ic.Scale = false;
        this.value = "使用比例";
    }else{
        ic.Scale = true;
        this.value = "取消比例";
    }
    ic.Init();
}

$("idMin").onclick = function(){
    if(ic.Min){
        ic.Min = false;
        this.value = "设置最小尺寸";
    }else{
        ic.Min = true;
        this.value = "取消最小尺寸";
    }
    ic.Init();
}

$("idView").onclick = function(){
    if(ic.viewWidth == 200){
        ic.viewWidth = 300;
        this.value = "缩小预览";
    }else{
        ic.viewWidth = 200;
        this.value = "扩大预览";
    }
    ic.Init();
}

/*
$("idImg").onclick = function(){
    if(ic.Url == "http://images.cnblogs.com/cnblogs_com/cloudgamer/143727/r_xx2.jpg"){
        ic.Url = "http://images.cnblogs.com/cnblogs_com/cloudgamer/143727/r_min.jpg";
    }else{
        ic.Url = "http://images.cnblogs.com/cnblogs_com/cloudgamer/143727/r_xx2.jpg";
    }
    ic.Init();
}

$("idPic").onclick = function(){
    if($("idPicUrl").value){
        ic.Url = $("idPicUrl").value;
    }
    ic.Init();
}
*/

$("getPosition").onclick = function(){
    $("<%=txtPosition.ClientID %>").value = ic.GetPos().Left + "|" + ic.GetPos().Top + "|"  + ic.GetPos().Width + "|"  + ic.GetPos().Height;
    $("ctrlDragPic").value = "打开操作面板";
    $("DragPicArea").style.display = "none";
}

$("getSize").onclick = function(){
    alert('左:'+ic.GetPos().Left + '\n高:'+ic.GetPos().Top + '\n宽度:'+ic.GetPos().Width + '\n高度:'+ic.GetPos().Height);
}

$("ctrlDragPic").onclick = function(){
    if($("DragPicArea").style.display =="block")
    {
        $("DragPicArea").style.display = "none";
        this.value = "打开操作面板";
    }
    else
    {
        $("DragPicArea").style.display = "block";
        this.value = "关闭操作面板";
    }
}

-->
</script>
</asp:Content>

