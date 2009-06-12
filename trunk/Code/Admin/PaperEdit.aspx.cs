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

public partial class Admin_PaperEdit : AdminBase
{
    protected void Page_Load(object sender, EventArgs e)
    {

    }


    protected override void OnPreRender(EventArgs e)
    {
        if (!IsPostBack)
        {
            if (QS("id") == "" || !WebAgent.IsInt32(QS("id")))
                WebAgent.AlertAndBack("参数错误");
            NewsPaper paper = new NewsPaperAgent().GetNewsPaperInfo(int.Parse(QS("id")));
            this.txtPaperID.Text = paper.PaperID.ToString();
            this.txtPublishDate.Text = paper.PublishDate.ToString();
            this.txtNumOfPage.Text = paper.NumOfPage.ToString();
            if (paper.IsShow == true)
                this.ShowTrue.Checked = true;
            else
                this.ShowFalse.Checked = true;
        }
    }

    protected void btnSave_Click(object sender, EventArgs e)
    {
        if (txtPaperID.Text == "")
            WebAgent.AlertAndBack("期数不能为空");
        if (this.txtPublishDate.Text == "")
            WebAgent.AlertAndBack("日期不能为空");
        if (this.txtNumOfPage.Text == "")
            WebAgent.AlertAndBack("版面数不能为空");

        NewsPaper paper = new NewsPaperAgent().GetNewsPaperInfo(int.Parse(QS("id")));
        int toNum;
        if (int.TryParse(this.txtPaperID.Text.ToString(), out toNum) == false)
            WebAgent.AlertAndBack("期刊必须为数字");
        else
        {
            if (paper.PaperID != toNum)
            {
                    WebAgent.AlertAndBack("不能修改期刊号");
            }
            paper.PaperID = toNum;
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
        if (agent.UpdateNewsPaperInfo(paper))
        {
            WebAgent.SuccAndGo("修改校刊成功", "PaperList.aspx");
        }
        else
        {
            WebAgent.AlertAndBack("对不起，修改校刊失败");
        }
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

}
