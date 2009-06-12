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

public partial class Admin_NewsEdit : AdminBase
{
    public string imgPageUrl = "Images/NoPageImage.jpg";    //全局变量

    protected void Page_Load(object sender, EventArgs e)
    {

    }

    protected override void OnPreRender(EventArgs e)
    {
        if (!IsPostBack)
        {
            if (QS("id") == "" || !WebAgent.IsInt32(QS("id")))
                WebAgent.AlertAndBack("参数错误");
            News news = new NewsAgent().GetNewsInfo(int.Parse(QS("id")));
            this.txtAddUser.Text = news.AddUser.ToString();
            this.txtAuthor.Text = news.Author.ToString();
            this.txtContent.Value = news.Content.ToString();
            this.txtPosition.Text = news.PositionOfPage.ToString();
            this.txtTitle.Text = news.Title.ToString();
            //添加期刊下拉列表框数据
            ArrayList arr = new NewsPaperAgent().GetNewsPaperList();
            if (arr == null || arr.Count < 1)
                WebAgent.FailAndGo("期刊为空，请先添加期刊", "PaperAdd.aspx");
            foreach (NewsPaper p in arr)
            {
                txtPaperID.Items.Add(p.PaperID.ToString());
            }
            txtPaperID.SelectedValue = news.PaperID.ToString();
            //添加版面下拉列表框数据
            arr = new PaperPageAgent().GetPaperPageList(news.PaperID);
            foreach (PaperPage p in arr)
            {
                txtPageID.Items.Add(p.PageID.ToString());
            }
            txtPageID.SelectedValue = news.PageID.ToString();
            ///////
            PaperPage page = new PaperPageAgent().GetPaperPageInfo(news.PaperID, news.PageID);
            imgPageUrl = "../" + page.PageImage.ToString();

        }
    }

    protected void btnSave_Click(object sender, EventArgs e)
    {
        if (txtPaperID.Text == "")
            WebAgent.AlertAndBack("期数不能为空");
        if (txtPageID.Text == "")
            WebAgent.AlertAndBack("版面不能为空");
        if (txtAuthor.Text == "")
            WebAgent.AlertAndBack("作者不能为空");
        if (txtContent.Value.ToString() == "")
            WebAgent.AlertAndBack("内容不能为空");
        if (txtPosition.Text == "")
            WebAgent.AlertAndBack("位置不能为空");
        if (txtTitle.Text == "")
            WebAgent.AlertAndBack("标题不能为空");

        News news = new NewsAgent().GetNewsInfo(int.Parse(QS("id")));
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
        news.PositionOfPage = txtPosition.Text.ToString();
        news.Title = txtTitle.Text.ToString();
        news.Author = txtAuthor.Text.ToString();
        news.Content = txtContent.Value;

        NewsAgent agent = new NewsAgent();
        if (agent.UpdateNewsInfo(news))
        {
            WebAgent.SuccAndGo("修改新闻成功", "NewsList.aspx");
        }
        else
        {
            WebAgent.AlertAndBack("对不起，修改新闻失败");
        }
    }
    protected void txtPaperID_SelectedIndexChanged(object sender, EventArgs e)
    {
        int paperID;
        if (int.TryParse(this.txtPaperID.SelectedValue.ToString(), out paperID) == true)
        {
            if (paperID == 0)
            {
                Response.Redirect("NewsEdit.aspx");
            }
            else
            {
                txtPageID.Items.Clear();
                ArrayList arr = new PaperPageAgent().GetPaperPageList(paperID);
                if (arr == null || arr.Count < 1)
                    WebAgent.ConfirmGo("期刊【" + paperID + "】的版面为空，是否先添加版面？", "PageAdd.aspx", "NewsAdd.aspx");
                foreach (PaperPage p in arr)
                {
                    txtPageID.Items.Add(p.PageID.ToString());
                }
            }
        }
    }
}
