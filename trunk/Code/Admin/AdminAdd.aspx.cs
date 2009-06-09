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

public partial class Admin_AddAdmin : AdminBase
{
    protected void Page_Load(object sender, EventArgs e)
    {

    }
    protected void btnSave_Click(object sender, EventArgs e)
    {
        if (txtAdminName.Text == "")
            WebAgent.AlertAndBack("管理员名不能为空");
        if (txtPassword.Text == "")
            WebAgent.AlertAndBack("密码不能为空");
        if (txtPower.Text == "")
            WebAgent.AlertAndBack("权限不能为空");
        Admin paper = new Admin();
        int toNum;
        if ((int.TryParse(this.txtPower.Text.ToString(), out toNum) == false) || toNum > 3)
            WebAgent.AlertAndBack("权限必须为数字且小于等于3");
        else
        {
            paper.Power = toNum;
        }
        paper.AdminName = txtAdminName.Text;
        paper.Password = Secure.Md5(txtPassword.Text);


        //检查管理员名是否已用
        int AdminID = new SiteAgent().ChkAdminLogin(txtAdminName.Text, Secure.Md5(txtPassword.Text));
        if (AdminID > 0)
        {
            WebAgent.AlertAndBack("管理员名已存在，请换一个！");
            
        }
        else
        {
            switch (AdminID)
            {
                case 0:
                    break;
                default: //存在
                    WebAgent.AlertAndBack("已存在该管理员名");
                    break;
                    
            }
        }

        AdminAgent agent = new AdminAgent();
        if (agent.AddAdmin(paper))
        {
            WebAgent.SuccAndGo("添加成功！","AdminList.aspx");
        }
        else
        {
            WebAgent.AlertAndBack("添加失败！");
        }
    }
}
