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
using Studio.Security;


public partial class Admin_ChangePassword : System.Web.UI.Page
{
    protected void Page_Load(object sender, EventArgs e)
    {
        txtAdminName.Text = Session["AdminName"].ToString();
    }
    protected void btnSave_Click(object sender, EventArgs e)
    {
        int toNum;
        int.TryParse(Session["AdminID"].ToString(), out toNum);
        Admin admin = new AdminAgent().GetAdminInfo(toNum);
        admin.Password = Secure.Md5(txtPassword.Text);
        AdminAgent agent = new AdminAgent();
        if (agent.UpdateAdminInfo(admin))
            WebAgent.SuccAndGo("修改成功", "Default.aspx");
        else
            WebAgent.AlertAndBack("修改失败");
    }
}
