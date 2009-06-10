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
using Studio.Web;
using Myweb.NewsPaper;
using System.IO;
using Studio.Security;

public partial class Admin_AdminEdit : AdminBase
{
    protected void Page_Load(object sender, EventArgs e)
    {

    }

    protected override void OnPreRender(EventArgs e)
    {
        if (!IsPostBack)
        {
            if (QS("id") == "" || !WebAgent.IsInt32(QS("id")))
                WebAgent.AlertAndBack("参数错误");
            ArrayList arr = new AdminAgent().GetAdminList();
            Admin page = new AdminAgent().GetAdminInfo(int.Parse(QS("id")));
            if (page == null)
                WebAgent.AlertAndBack("不存在该版面");
            this.txtAdminName.Text = page.AdminName;
            this.txtPower.Text = page.Power.ToString();
        }
    }

    protected void btnSave_Click(object sender, EventArgs e)
    {
        int toNum;
        if (int.TryParse(txtPower.Text.ToString(), out toNum) == false || toNum > 3)
            WebAgent.AlertAndBack("权限必须为小于等于3的整数");
        Admin admin = new AdminAgent().GetAdminInfo(int.Parse(QS("id")));
        admin.Power = toNum;
        admin.Password = Secure.Md5(txtPassword.Text);
        AdminAgent agent = new AdminAgent();
        if (agent.UpdateAdminInfo(admin))
        {
            WebAgent.SuccAndGo("修改管理员信息成功", "AdminList.aspx");
        }
        else
        {
            WebAgent.AlertAndBack("修改失败");
        }

    }
}
