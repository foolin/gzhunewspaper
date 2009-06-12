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

public partial class Ajax_GetNews : SiteBase
{
    public News news = null;  //全局变量

    protected void Page_Load(object sender, EventArgs e)
    {

    }

    protected override void OnLoad(EventArgs e)
    {
        if (QS("NewsID") != "" && WebAgent.IsInt32(QS("NewsID")))
        {
            news = new NewsAgent().GetNewsInfo(int.Parse(QS("NewsID")));
        }

    }
}
