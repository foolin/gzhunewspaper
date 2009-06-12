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

public partial class Admin_SystemConfig : AdminBase
{
    protected void Page_Load(object sender, EventArgs e)
    {

    }

    protected override void OnPreRender(EventArgs e)
    {
        if (!IsPostBack)
        {
            SystemConfig config = new SystemConfigAgent().GetSystemConfig();
            if (config != null)
            {
                txtPaperName.Text = config.PaperName.ToString();
                txtSiteName.Text = config.SiteName.ToString();
                txtSiteUrl.Text = config.SiteUrl.ToString();
                txtPaperInfo.Text = config.PaperInfo.ToString();
                if (config.IsOpenRegister == true)
                    RadioButton1.Checked = true;
                else
                    RadioButton2.Checked = true;
                txtEditorName.Text = config.EditorName.ToString();
                txtEditorAddrs.Text = config.EditorAddrs;
                txtEditorPhone.Text = config.EditorPhone.ToString();
                txtEditorFax.Text = config.EditorFax.ToString();
                txtEditorEmail.Text = config.EditorEmail.ToString();
                txtEditorPostCode.Text = config.EditorPostCode.ToString();
            }
        }
    }

    protected void btnSave_Click(object sender, EventArgs e)
    {
        SystemConfig config = new SystemConfig();
        config.PaperInfo = txtPaperInfo.Text;
        config.PaperName = txtPaperName.Text;
        config.SiteName = txtSiteName.Text;
        config.SiteUrl = txtSiteUrl.Text;
        if (this.RadioButton1.Checked != true && this.RadioButton2.Checked != true)
            WebAgent.AlertAndBack("请选择是否开放用户注册与否！");
        else if (this.RadioButton1.Checked == true)
            config.IsOpenRegister = true;
        else
            config.IsOpenRegister = false;
        config.EditorAddrs = txtEditorAddrs.Text;
        config.EditorEmail = txtEditorEmail.Text;
        config.EditorFax = txtEditorFax.Text;
        config.EditorName = txtEditorName.Text;
        config.EditorPhone = txtEditorPhone.Text;
        config.EditorPostCode = txtEditorPostCode.Text;
        SystemConfigAgent agent = new SystemConfigAgent();
        if (agent.UpdateSystemConfigInfo(config))
        {
            WebAgent.SuccAndGo("修改成功", "Systemconfig.aspx");
        }
        else
        {
            WebAgent.AlertAndBack("修改失败");
        }

    }
}
