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
using System.Collections;

public partial class Admin_ConfigList : System.Web.UI.Page
{
    protected void Page_Load(object sender, EventArgs e)
    {

    }

    protected override void OnPreRender(EventArgs e)
    {
        if (!IsPostBack)
        {
            /*
            SystemConfigAgent agent = new SystemConfigAgent();
            DataSet ds = new DataSet();
            ArrayList list1;
            list1 = agent.GetSystemConfigList();
             */
        }
    }

    protected void btnSave_Click(object sender, EventArgs e)
    {
        if (txtIsOpenRegister.Text != "0" && txtIsOpenRegister.Text != "1")
        {
            WebAgent.AlertAndBack("“是否开放注册”必须为0或1");
        }
        SystemConfig cofig = new SystemConfig();
        cofig.EditorAddrs = txtEditorAddrs.Text;
        cofig.EditorEmail = txtEditorEmail.Text;
        cofig.EditorFax = txtEditorFax.Text;
        cofig.EditorName = txtEditorName.Text;
        cofig.EditorPhone = txtEditorPhone.Text;
        bool toNum;
        bool.TryParse(txtIsOpenRegister.Text, out toNum);
        cofig.IsOpenRegister = toNum;
        cofig.PaperInfo = txtPaperInfo.Text;
        cofig.PaperName = txtPaperName.Text;
        cofig.SiteName = txtSiteName.Text;
        cofig.SiteUrl = txtSiteUrl.Text;
        SystemConfigAgent agent = new SystemConfigAgent();
        if (agent.UpdateSystemConfigInfo(cofig))
        {
            WebAgent.SuccAndGo("修改成功", "SystemCofig.aspx");
        }
        else
        {
            WebAgent.AlertAndBack("修改失败");
        }

    }
}
