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

public partial class Admin_PaperList : AdminBase
{
    protected void Page_Load(object sender, EventArgs e)
    {

    }

    protected override void OnPreRender(EventArgs e)
    {
        listPaper.DataSource = new NewsPaperAgent().GetNewsPaperList();
        listPaper.DataBind();
    }

    public string SetStatus(bool bl, int id)
    {
        string strStatue = "";

        if (bl)
        {
            strStatue = "<a href=\"PaperSetStatus.aspx?id=" + id + "\"><font color=\"green\">已发布</font></a>";
        }
        else
        {
            strStatue = "<a href=\"PaperSetStatus.aspx?id=" + id + "\"><font color=\"red\">未发布</font></a>";
        }

        return strStatue;
    }

}
