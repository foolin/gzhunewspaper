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

public partial class Admin_PaperAdd : AdminBase
{
    protected void Page_Load(object sender, EventArgs e)
    {

    }

    protected override void OnPreRender(EventArgs e)
    {
        this.ShowFalse.Checked = true;
    }


    protected void Calendar1_SelectionChanged(object sender, EventArgs e)
    {
        this.txtPublishDate.Text = this.Calendar1.SelectedDate.ToString();
        this.Calendar1.Visible = false;
    }

    protected void Button1_Click(object sender, EventArgs e)
    {
        this.Calendar1.Visible = true;
    }

    protected void btnSave_Click(object sender, EventArgs e)
    {
        if (txtPaperID.Text == "")
            WebAgent.AlertAndBack("期数不能为空");
        if (this.txtPublishDate.Text == "")
            WebAgent.AlertAndBack("日期不能为空");
        if (this.txtNumOfPage.Text == "")
            WebAgent.AlertAndBack("版面数不能为空");

        NewsPaper paper = new NewsPaper();
        int toNum;
        if (int.TryParse(this.txtPaperID.Text.ToString(), out toNum) == false)
            WebAgent.AlertAndBack("期刊必须为数字");
        else
        {
            paper.PaperID = toNum;
            if ((new NewsPaperAgent().GetNewsPaperInfo(paper.PaperID)) != null)
                WebAgent.AlertAndBack("已经存在该期刊号为[" + paper.PaperID + "]的期刊，请检查");
        }
        paper.PublishDate = DateTime.Parse(txtPublishDate.Text);
        if (int.TryParse(this.txtNumOfPage.Text.ToString(), out toNum) == false)
            WebAgent.AlertAndBack("版面数必须为数字");
        paper.NumOfPage = toNum;
        if (this.ShowTrue.Checked != true && this.ShowFalse.Checked != true)
            WebAgent.AlertAndBack("请选择是否显示！");
        else if (this.ShowTrue.Checked == true)
            paper.IsShow = true;
        else
            paper.IsShow = false;
        NewsPaperAgent agent = new NewsPaperAgent();
        if (agent.AddNewsPaper(paper))
        {
            WebAgent.SuccAndGo("添加校刊成功", "PaperList.aspx");
        }
        else
        {
            WebAgent.AlertAndBack("添加校刊失败");
        }
    }
}
