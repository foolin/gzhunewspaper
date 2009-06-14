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

public partial class Ajax_GetNewsList : SiteBase
{
    protected void Page_Load(object sender, EventArgs e)
    {

    }
    protected override void OnLoad(EventArgs e)
    {
        if (QS("PaperID") != "" && WebAgent.IsInt32(QS("PaperID"))
           && QS("PageID") != "" && WebAgent.IsInt32(QS("PageID")))
        {
            listNews.DataSource = new NewsAgent().GetNewsList(int.Parse(QS("PaperID")), int.Parse(QS("PageID")));
            listNews.DataBind();
        }
        else
        {
            listNews.DataSource = new NewsAgent().GetNewsList();
            listNews.DataBind();
        }

        Response.Cache.SetExpires(DateTime.Now);
        Response.Cache.AppendCacheExtension("no-cache");

    }
}
