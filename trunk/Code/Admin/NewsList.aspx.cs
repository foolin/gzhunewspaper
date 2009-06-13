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
    public int currentPaperID = new NewsPaperAgent().GetLastPaperID();  //全局变量
    public int firstPaperID = new NewsPaperAgent().GetFirstPaperID();
    public int lastPaperID = new NewsPaperAgent().GetLastPaperID();
    public int prePaperID = 0;
    public int nextPaperID = 0;

    protected void Page_Load(object sender, EventArgs e)
    {

    }
    protected override void OnPreRender(EventArgs e)
    {
        if ((QS("PaperID") != "" && WebAgent.IsInt32(QS("PaperID"))))
        {
            ChangePaperID(int.Parse(QS("PaperID")));

        }
        else
        {
            ChangePaperID(currentPaperID);
        }
        if (!IsPostBack)
        {
            listNews.DataSource = new NewsAgent().GetNewsList(currentPaperID);
            listNews.DataBind();

            ArrayList arr = new NewsPaperAgent().GetNewsPaperList();
            foreach (NewsPaper p in arr)
            {
                PaperList.Items.Add(p.PaperID.ToString());
            }
            this.PaperList.Items.FindByValue(currentPaperID.ToString()).Selected = true;

            PageList.Items.Clear();
            ArrayList arr2 = new PaperPageAgent().GetPaperPageList(currentPaperID);
            if (arr2 == null || arr.Count < 1)
                WebAgent.ConfirmGo("期刊【" + currentPaperID + "】的版面为空，是否先添加版面？", "PageAdd.aspx", "NewsList.aspx");
            PageList.Items.Add("请选择");
            foreach (PaperPage p in arr2)
            {
                PageList.Items.Add(p.PageID.ToString());
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
                    WebAgent.ConfirmGo("期刊【" + paperID + "】的版面为空，是否先添加版面？", "PageAdd.aspx", "NewsList.aspx");
                PageList.Items.Add("请选择");
                foreach (PaperPage p in arr)
                {
                    PageList.Items.Add(p.PageID.ToString());
                }
                listNews.DataSource = new NewsAgent().GetNewsList(paperID);
                listNews.DataBind();
                ChangePaperID(paperID);
            }

        }
    }
    protected void PageList_SelectedIndexChanged(object sender, EventArgs e)
    {
        int toPaper, toPage;
        int.TryParse(PaperList.SelectedValue, out toPaper);
        int.TryParse(PageList.SelectedValue, out toPage);
        NewsAgent news = new NewsAgent();
        if(toPage == 0)
            listNews.DataSource = news.GetNewsList(toPaper);
        else
            listNews.DataSource = news.GetNewsList(toPaper, toPage);
        listNews.DataBind();
        ChangePaperID(toPaper);
    }

    protected void ChangePaperID(int paperID)
    {
        currentPaperID = paperID;
        prePaperID = new NewsPaperAgent().GetPrePaperID(paperID);
        if (prePaperID == 0)
            prePaperID = firstPaperID;
        nextPaperID = new NewsPaperAgent().GetNextPaperID(paperID);
        if (nextPaperID == 0)
            nextPaperID = lastPaperID;
        
    }
}
