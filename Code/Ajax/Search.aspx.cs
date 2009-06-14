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

public partial class Ajax_Search : SiteBase
{
    public Pager page = new Pager();
    protected void Page_Load(object sender, EventArgs e)
    {

    }

    protected override void OnLoad(EventArgs e)
    {
        if (QS("Page") != "" && WebAgent.IsInt32(QS("Page")))
            page.SetPageIndex(int.Parse(QS("Page")));
        if (QS("Keyword") != "")
        {
            int Record = 0;
            ListNews.DataSource = new NewsAgent().GetNewsList(QS("Keyword"), page.GetPageSize(), page.GetPageIndex(), out Record);
            ListNews.DataBind();
            page.SetTotalCount(Record);
            if (Record == 0)
                Tips.Text = "对不起，未能找到[" + QS("Keyword") + "]的记录！";
        }
        else
        {
            Tips.Text = "出错了，你未输入任何关键字！";
        }

        Response.Cache.SetExpires(DateTime.Now);
        Response.Cache.AppendCacheExtension("no-cache");

    }

}


