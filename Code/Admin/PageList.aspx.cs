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

public partial class Admin_PageList : AdminBase
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
            //listPage.DataSource = new PaperPageAgent().GetPaperPageList();
            //int paperID = new NewsPaperAgent().GetLastPaperID();
            listPage.DataSource = new PaperPageAgent().GetPaperPageList(currentPaperID);
            listPage.DataBind();
            ArrayList arr = new NewsPaperAgent().GetNewsPaperList();
            foreach (NewsPaper p in arr)
            {
                PaperList.Items.Add(p.PaperID.ToString());
            }
            this.PaperList.Items.FindByValue(currentPaperID.ToString()).Selected = true;
        }

    }


    protected void PaperList_SelectedIndexChanged(object sender, EventArgs e)
    {
        int paperID;
        if (int.TryParse(this.PaperList.SelectedValue.ToString(), out paperID) == true)
        {
            if (paperID == 0)
            {
                listPage.DataSource = new PaperPageAgent().GetPaperPageList();
                listPage.DataBind();
                //Response.Redirect("NewsList.aspx");
            }
            else
            {
                listPage.DataSource = new PaperPageAgent().GetPaperPageList(int.Parse(PaperList.SelectedValue));
                listPage.DataBind();
            }
        }
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
