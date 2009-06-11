﻿using System;
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
    protected void Page_Load(object sender, EventArgs e)
    {

    }

    protected override void OnPreRender(EventArgs e)
    {
        if (!IsPostBack)
        {
            if (QS("id") == "" || !WebAgent.IsInt32(QS("id")))
                WebAgent.AlertAndBack("参数错误");
            News paper = new NewsAgent().GetNewsInfo(int.Parse(QS("id")));
            this.txtAddUser.Text = paper.AddUser.ToString();
            this.txtAuthor.Text = paper.Author.ToString();
            this.txtContent.Value = paper.Content.ToString();
            this.txtPosition.Text = paper.PositionOfPage.ToString();
            this.txtTitle.Text = paper.Title.ToString();

            ArrayList arr = new NewsPaperAgent().GetNewsPaperList();
            if (arr == null || arr.Count < 1)
                WebAgent.FailAndGo("期刊为空，请先添加期刊", "PaperAdd.aspx");
            foreach (NewsPaper p in arr)
            {
                txtPaperID.Items.Add(p.PaperID.ToString());
            }
            txtPaperID.SelectedValue = QS("PaperID");
            txtPageID.Items.Add(QS("PageID"));

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
