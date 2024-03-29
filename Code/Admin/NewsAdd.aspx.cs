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
using System.IO;

public partial class Admin_NewsAdd : AdminBase
{
    public string imgPageUrl = "Images/NoPageImage.jpg";    //全局变量
    public string divDrawArea = "";

    protected void Page_Load(object sender, EventArgs e)
    {
        
    }

    protected override void OnPreRender(EventArgs e)
    {

        if (!IsPostBack)
        {
            txtAddUser.Text = Request.Cookies["Admin"]["AdminName"].ToString();
            ArrayList arr = new NewsPaperAgent().GetNewsPaperList();
            if (arr == null || arr.Count < 1)
                WebAgent.FailAndGo("期刊为空，请先添加期刊", "PaperAdd.aspx");
            foreach (NewsPaper p in arr)
            {
                txtPaperID.Items.Add(p.PaperID.ToString());
            }

            int paperID;
            if (int.TryParse(this.txtPaperID.SelectedValue.ToString(), out paperID) == true)
            {
                if (paperID == 0)
                {
                    Response.Redirect("NewsAdd.aspx");
                }
                else
                {
                    ArrayList arr2 = new PaperPageAgent().GetPaperPageList(paperID);
                    foreach (PaperPage p in arr2)
                    {
                        txtPageID.Items.Add(p.PageID.ToString());
                    }

                    if (arr2 != null && arr2.Count > 0)
                    {
                        PaperPage page = new PaperPageAgent().GetPaperPageInfo(paperID, int.Parse(this.txtPageID.SelectedValue.ToString()));
                        imgPageUrl = "../" + page.PageImage.ToString();
                        divDrawArea = GetHasDrawArea(page.PaperID, page.PageID, 0);
                    }
                }

            }
        }

    }

    protected void btnSave_Click(object sender, EventArgs e)
    {
        if (txtPaperID.Text == "")
        {
            WebAgent.FailAndGo("期刊为空，请先添加期刊", "PaperAdd.aspx");
        }
        if (txtPageID.Text == "")
        {

            WebAgent.ConfirmGo("更新失败！期刊【" + txtPaperID.Text + "】的版面为空，是否先添加版面？", "PageAdd.aspx", "NewsAdd.aspx");
        }
        if (txtTitle.Text == "")
        {
            WebAgent.AlertAndBack("标题不能为空!");
        }
        if (txtAuthor.Text == "")
        {
            WebAgent.AlertAndBack("作者不能为空!");
        }
        if (txtContent.Value == "")
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
        news.Title = this.txtTitle.Text.ToString();
        news.Content = this.txtContent.Value.ToString();
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
        int paperID;
        if (int.TryParse(this.txtPaperID.SelectedValue.ToString(), out paperID) == true)
        {
            if (paperID == 0)
            {
                Response.Redirect("NewsAdd.aspx");
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
                if (arr != null || arr.Count > 0)
                {
                    PaperPage page = new PaperPageAgent().GetPaperPageInfo(int.Parse(this.txtPaperID.SelectedValue.ToString()), int.Parse(this.txtPageID.SelectedValue.ToString()));
                    imgPageUrl = "../" +  page.PageImage.ToString();
                    divDrawArea = GetHasDrawArea(page.PaperID, page.PageID, 0);
                }
            }
        }

    }

    protected void txtPageID_SelectedIndexChanged(object sender, EventArgs e)
    {
        PaperPage page = new PaperPageAgent().GetPaperPageInfo(int.Parse(this.txtPaperID.SelectedValue.ToString()), int.Parse(this.txtPageID.SelectedValue.ToString()));
        imgPageUrl = "../"  +  page.PageImage.ToString();
        divDrawArea = GetHasDrawArea(page.PaperID, page.PageID, 0);
    }

    //获取已经存在新闻区域
    protected string GetHasDrawArea(int paperID, int pageID, int newsID)
    {
        int left = 0, top = 0, width = 0, height = 0;
        string[] position;
        string strTemp = "\n";
        if (newsID > 0)
        {
            News news = new NewsAgent().GetNewsInfo(newsID);
            if (news != null)
            {
                paperID = news.PaperID;
                pageID = news.PageID;
            }
        }
        ArrayList arr = new NewsAgent().GetNewsList(paperID, pageID);
        foreach (News news in arr)
        {
            if (news.NewsID != newsID)
            {
                position = news.PositionOfPage.ToString().Split('|');
                left = int.Parse(position[0]) - 2;
                top = int.Parse(position[1]) - 2;
                width = int.Parse(position[2]);
                height = int.Parse(position[3]);
                strTemp = strTemp + "\t\t<div style=\"left: " + left + "px;top:" + top + "px; width:" + width + "px; height: " + height + "px; border:red 1px solid; cursor: pointer; position: absolute;\"></div>\n\n";
            }
        }
        return strTemp;

    }
}
