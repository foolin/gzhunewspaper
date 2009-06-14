using System;
using System.Data;
using System.Configuration;
using System.Web;
using System.Web.Security;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Web.UI.WebControls.WebParts;
using System.Web.UI.HtmlControls;
using System.Collections;
using Myweb.NewsPaper;
using Studio.Web;

public partial class _Default :  SiteBase
{
    protected void Page_Load(object sender, EventArgs e)
    {

    }
    protected override void OnPreRender(EventArgs e)
    {
        selectPaper.Items.Clear();
        ArrayList arr = new NewsPaperAgent().GetNewsPaperList();
        if (arr == null || arr.Count < 1)
            selectPaper.Items.Add(new ListItem("暂无期刊", "0"));
        int flagTotal = 0;
        foreach (NewsPaper p in arr)
        {
            if(flagTotal == 0)
            {
                paperTotal.Text = p.PaperID.ToString();
                flagTotal = 1;
            }
            selectPaper.Items.Add(new ListItem("第" + p.PaperID.ToString() + "期  " + Convert.ToDateTime(p.PublishDate).ToLongDateString(), 
                p.PaperID.ToString()));
        }

    }

}
