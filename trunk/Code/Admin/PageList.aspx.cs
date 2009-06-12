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
    protected void Page_Load(object sender, EventArgs e)
    {

    }

    protected override void OnPreRender(EventArgs e)
    {
        if (!IsPostBack)
        {
            listPage.DataSource = new PaperPageAgent().GetPaperPageList();
            listPage.DataBind();
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
                listPage.DataSource = new PaperPageAgent().GetPaperPageList(int.Parse(PaperList.SelectedValue));
                listPage.DataBind();
            }
        }
    }
}
