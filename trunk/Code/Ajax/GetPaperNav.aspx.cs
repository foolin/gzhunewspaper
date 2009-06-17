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

public partial class Ajax_GetPaperNav : SiteBase
{
    public int currentPaperID = 0, currentPageID = 0;
    public int prePaperID = 0, nextPaperID = 0;
    public int prePageID = 0, nextPageID = 0;

    protected void Page_Load(object sender, EventArgs e)
    {

    }

    protected override void OnLoad(EventArgs e)
    {
        Response.Cache.SetExpires(DateTime.Now);
        Response.Cache.AppendCacheExtension("no-cache");

        if (QS("PaperID") != "" && WebAgent.IsInt32(QS("PaperID")))
            currentPaperID = int.Parse(QS("PaperID"));
        if (QS("PageID") != "" && WebAgent.IsInt32(QS("PageID")))
            currentPageID = int.Parse(QS("PageID"));
        if (QS("NewsID") != "" && WebAgent.IsInt32(QS("NewsID")))
        {
            News news = new NewsAgent().GetNewsInfo(int.Parse(QS("NewsID")));
            if (news != null)
            {
                currentPaperID = news.PaperID;
                currentPaperID = news.PageID;
            }
        }
        
        NewsPaperAgent paper = new NewsPaperAgent();
        PaperPageAgent page = new PaperPageAgent();

        prePaperID = paper.GetPrePaperID(currentPaperID);
        if (prePaperID == 0)
            prePaperID = currentPaperID;

        nextPaperID = paper.GetNextPaperID(currentPaperID);
        if (nextPaperID == 0)
            nextPaperID = currentPaperID;

        prePageID = page.GetPrePageID(currentPaperID, currentPageID);
        if (prePageID == 0)
            prePageID = currentPageID;

        nextPageID = page.GetNextPageID(currentPaperID, currentPageID);
        if (nextPageID == 0)
            nextPageID = currentPageID;
    }

}
