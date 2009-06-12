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

public partial class Ajax_GetPaperID : SiteBase
{
    public int paperID = 0;

    protected void Page_Load(object sender, EventArgs e)
    {
    }

    protected override void OnLoad(EventArgs e)
    {
        if (QS("NewsID") != "" && WebAgent.IsInt32(QS("NewsID")))
        {
            paperID = (new NewsAgent().GetNewsInfo(int.Parse(QS("NewsID")))).PaperID;
        }
        else
        {
            paperID = new NewsPaperAgent().GetLastPaperID();
        }

        Response.Cache.SetExpires(DateTime.Now);
        Response.Cache.AppendCacheExtension("no-cache");

    }
}
