using System;
using System.Collections.Generic;
using System.Web;
using Studio.Web;
using Myweb.NewsPaper;

/// <summary>
/// AdminBase 的摘要说明
/// </summary>
public class AdminBase : System.Web.UI.Page
{
	public AdminBase()
	{
		//
		// TODO: 在此处添加构造函数逻辑
		//
	}

    protected override void OnLoad(EventArgs e)
    {
        if (Request.Cookies["Admin"] == null || Request.Cookies["Admin"]["AdminName"] == "")
        {
            WebAgent.FailAndGo("您未登陆禁止查看该页！", "Login.aspx");
        }
        if (!IsPostBack)
        {
            if (Request.UrlReferrer == null)
            {
                ViewState["BACK"] = "Default.aspx";
            }
            else
            {
                ViewState["BACK"] = Request.UrlReferrer.ToString();
            }
        }
    }

}
