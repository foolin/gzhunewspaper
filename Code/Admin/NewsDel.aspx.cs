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

public partial class Admin_NewsDel : AdminBase
{
    protected void Page_Load(object sender, EventArgs e)
    {

    }
    protected override void OnPreRender(EventArgs e)
    {
        if (QS("id") == "" || !WebAgent.IsInt32(QS("id")))
            WebAgent.AlertAndBack("参数错误");
        News paper = new NewsAgent().GetNewsInfo(int.Parse(QS("id")));
        if (paper == null)
            WebAgent.AlertAndBack("新闻不存在");
        if (new NewsAgent().DeleteNews(int.Parse(QS("id"))) > 0)
            WebAgent.SuccAndGo("删除期刊成功", "NewsList.aspx");
        else
            WebAgent.AlertAndBack("删除期刊失败");
    }
}
