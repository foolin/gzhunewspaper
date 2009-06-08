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
using System.IO;

public partial class Admin_NewsAdd : AdminBase
{
    protected void Page_Load(object sender, EventArgs e)
    {
        
    }

    protected override void OnPreRender(EventArgs e)
    {
        ArrayList arr = new PaperPageAgent().GetPaperPageList();
        foreach (PaperPage p in arr)
        {
            txtPaperID.Items.Add(p.PaperID.ToString());
            //txtPageID.Items.Add(p.PageID.ToString());
        }

    }

    protected void btnSave_Click(object sender, EventArgs e)
    {
        if (txtPaperID.Text == "")
        {
            WebAgent.AlertAndBack("期刊数不能为空");
        }
        if (txtPageID.Text == "")
        {
            WebAgent.AlertAndBack("版面数不能为空!");
        }
        if (txtNewsName.Text == "")
        {
            WebAgent.AlertAndBack("标题不能为空!");
        }
        if (txtAuthor.Text == "")
        {
            WebAgent.AlertAndBack("作者不能为空!");
        }
        if (txtContent.Text == "")
        {
            WebAgent.AlertAndBack("内容不能为空!");
        }
        if (txtPosition.Text == "")
        {
            WebAgent.AlertAndBack("位置不能为空!");
        }
        if (txtAddUser.Text == "")
        {
            WebAgent.AlertAndBack("添加人不能为空!");
        }
        News news = new News();

        int toNum;
        if (int.TryParse(this.txtPaperID.Text.ToString(), out toNum) == false)
            WebAgent.AlertAndBack("期刊必须为数字");
        else
        {
            news.PaperID = toNum;
        }
        if (int.TryParse(this.txtPageID.Text.ToString(), out toNum) == false)
            WebAgent.AlertAndBack("版面必须为数字");
        else
        {
            news.PageID = toNum;
        }
        news.AddTime = DateTime.Now;
        news.AddUser = this.txtAddUser.Text.ToString();
        news.Author = this.txtAuthor.Text.ToString();
        news.Content = this.txtContent.Text.ToString();
        news.Title = this.txtNewsName.Text.ToString();
        news.PositionOfPage = this.txtPosition.Text.ToString();
        NewsAgent agent = new NewsAgent();
        if (agent.AddNews(news))
        {
            WebAgent.SuccAndGo("添加新闻成功", "NewsList.aspx");
        }
        else
        {
            WebAgent.AlertAndBack("添加新闻失败");
        }
    }
    /// <summary>
    /// 当期刊号选择后再进行选择期刊号对应该的版面
    /// </summary>
    /// <param name="sender"></param>
    /// <param name="e"></param>
    protected void txtPaperID_SelectedIndexChanged(object sender, EventArgs e)
    {
        /*
        ArrayList arr = new PaperPageAgent().GetPaperPageList();
        string selected = txtPaperID.SelectedValue.ToString();
        foreach (PaperPage p in arr)
        {
            txtPaperID.Items.Add(p.PaperID.ToString());
            //txtPageID.Items.Add(p.PageID.ToString());
        }
        */

    }
}
