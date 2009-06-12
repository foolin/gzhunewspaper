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

public partial class Ajax_GetPageID : SiteBase
{
    public int paperID;
    public int pageID;
    protected void Page_Load(object sender, EventArgs e)
    {

    }
    protected override void OnLoad(EventArgs e)
    {
        if (QS("NewsID") != "" && WebAgent.IsInt32(QS("NewsID")))
        {
            News news = new NewsAgent().GetNewsInfo(int.Parse(QS("NewsID")));
            paperID = news.PaperID;
            pageID = news.PageID;
        }
        else if (QS("PaperID") != "" && WebAgent.IsInt32(QS("PaperID")))
        {

            paperID = int.Parse(QS("PaperID"));
            pageID = new PaperPageAgent().GetFirstPageID(paperID);

        }
        else
        {
            paperID = new NewsPaperAgent().GetLastPaperID();
            pageID = new PaperPageAgent().GetFirstPageID(paperID);
        }
    }
}
