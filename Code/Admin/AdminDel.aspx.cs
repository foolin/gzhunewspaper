using System;
using System.Data;
using System.Configuration;
using System.Collections;
using System.Web;
using System.Web.Security;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Web.UI.WebControls.WebParts;
using System.Web.UI.HtmlControls;
using Myweb.NewsPaper;
using Studio.Web;

public partial class Admin_AdminDel : AdminBase
{
    protected void Page_Load(object sender, EventArgs e)
    {

    }

    protected override void OnPreRender(EventArgs e)
    {
        if (QS("id") == "" || !WebAgent.IsInt32(QS("id")))
            WebAgent.AlertAndBack("参数错误");
        Admin admin = new AdminAgent().GetAdminInfo(int.Parse(QS("id")));
        if (Request.Cookies["Admin"]["AdminID"].ToString() == QS("id"))
            WebAgent.AlertAndBack("不能删除自己");
        if (admin == null)
            WebAgent.AlertAndBack("管理员不存在");
        if (new AdminAgent().DeleteAdmin(int.Parse(QS("id"))) > 0)
            WebAgent.SuccAndGo("删除管理员成功", "AdminList.aspx");
        else
            WebAgent.AlertAndBack("删除管理员失败");
    }
}
