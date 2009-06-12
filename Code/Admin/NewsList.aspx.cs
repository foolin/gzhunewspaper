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

public partial class Admin_NewsList : AdminBase
{
    protected void Page_Load(object sender, EventArgs e)
    {

    }
    protected override void OnPreRender(EventArgs e)
    {
        if (!IsPostBack)
        {
            listNews.DataSource = new NewsAgent().GetNewsList();
            listNews.DataBind();

            ArrayList arr = new NewsPaperAgent().GetNewsPaperList();
            foreach (NewsPaper p in arr)
            {
                PaperList.Items.Add(p.PaperID.ToString());
            }
        }
    }

    protected void PaperList_SelectedIndexChanged(object sender, EventArgs e)
    {
        int paperID;
        if (int.TryParse(this.PaperList.SelectedValue.ToString(), out paperID) == true)
        {
            if (paperID == 0)
            {
                Response.Redirect("NewsList.aspx");
            }
            else
            {
                PageList.Items.Clear();
                ArrayList arr = new PaperPageAgent().GetPaperPageList(paperID);
                if (arr == null || arr.Count < 1)
                    WebAgent.ConfirmGo("期刊【" + paperID + "】的版面为空，是否先添加版面？", "PageAdd.aspx", "NewsAdd.aspx");
                foreach (PaperPage p in arr)
                {
                    PageList.Items.Add(p.PageID.ToString());
                }
                listNews.DataSource = new NewsAgent().GetNewsList(paperID);
                listNews.DataBind();
            }

        }
    }
    protected void PageList_SelectedIndexChanged(object sender, EventArgs e)
    {
        int toPaper, toPage;
        int.TryParse(PaperList.SelectedValue, out toPaper);
        int.TryParse(PageList.SelectedValue, out toPage);
        NewsAgent agent = new NewsAgent();
        listNews.DataSource = agent.GetNewsList(toPaper, toPage);
        listNews.DataBind();
    }
}
