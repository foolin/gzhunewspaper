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

public partial class Ajax_GetPageImage : SiteBase
{
    public string strPageImage = "Images/NoPageImage.jpg";

    protected void Page_Load(object sender, EventArgs e)
    {
    }

    protected override void OnLoad(EventArgs e)
    {
        if (QS("NewsID") != "" && WebAgent.IsInt32(QS("NewsID")))
        {
            News news = new NewsAgent().GetNewsInfo(int.Parse(QS("NewsID")));
            if (news != null)
            {
                PaperPage page = new PaperPageAgent().GetPaperPageInfo(news.PaperID, news.PageID);
                if(page != null)
                    strPageImage = page.PageImage.ToString();
            }
        }
        if (QS("PaperID") != "" && WebAgent.IsInt32(QS("PaperID"))
           && QS("PageID") != "" && WebAgent.IsInt32(QS("PageID")))
        {
            PaperPage page = new PaperPageAgent().GetPaperPageInfo(int.Parse(QS("PaperID")), int.Parse(QS("PageID")));
            if (page != null)
                strPageImage = page.PageImage.ToString();
        }
        Response.Cache.SetExpires(DateTime.Now);
        Response.Cache.AppendCacheExtension("no-cache");
    }

}
