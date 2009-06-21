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

public partial class Admin_PaperSetStatus : AdminBase
{
    protected void Page_Load(object sender, EventArgs e)
    {

    }

    protected override void OnPreRender(EventArgs e)
    {
        if (QS("id") == "" || !WebAgent.IsInt32(QS("id")))
            WebAgent.AlertAndBack("参数错误");
        NewsPaper paper = new NewsPaperAgent().GetNewsPaperInfo(int.Parse(QS("id")));
        if (paper == null)
            WebAgent.AlertAndBack("期刊不存在");
        if (paper.IsShow == false)
            paper.IsShow = true;
        else
            paper.IsShow = false;
        if (new NewsPaperAgent().UpdateNewsPaperInfo(paper))
            Response.Redirect("PaperList.aspx");    //WebAgent.SuccAndGo("修改期刊状态成功", "PaperList.aspx");
        else
            WebAgent.AlertAndBack("修改期刊状态失败");
    }
}
