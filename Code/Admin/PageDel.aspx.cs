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
using Studio.Web;
using Myweb.NewsPaper;

public partial class Admin_PageDel : AdminBase
{
    protected void Page_Load(object sender, EventArgs e)
    {

    }
    protected override void OnPreRender(EventArgs e)
    {
        if (QS("PaperID") == "" || !WebAgent.IsInt32(QS("PaperID")) || QS("PageID") == "" || !WebAgent.IsInt32(QS("PageID")))
            WebAgent.AlertAndBack("参数错误");
        PaperPage page = new PaperPageAgent().GetPaperPageInfo(int.Parse(QS("PaperID")), int.Parse(QS("PageID")));
        if (page == null)
            WebAgent.AlertAndBack("期刊的版面不存在");
        if (new PaperPageAgent().DeletePaperPage(int.Parse(QS("PaperID")), int.Parse(QS("PageID"))) > 0)
            WebAgent.SuccAndGo("删除版面成功", "PageList.aspx");
        else
            WebAgent.AlertAndBack("删除版面失败");
    }
}
