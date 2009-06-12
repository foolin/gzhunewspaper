﻿using System;
using System.Collections.Generic;
using System.Web;
using Studio.Web;
using Myweb.NewsPaper;

/// <summary>
/// SiteBase 的摘要说明
/// </summary>
public class SiteBase : System.Web.UI.Page
{
	public SiteBase()
	{
		//
		// TODO: 在此处添加构造函数逻辑
		//
	}

    protected override void OnLoad(EventArgs e)
    {
        if (!IsPostBack)
        {
            SystemConfig config = new SystemConfigAgent().GetSystemConfig();
            if (config == null)
            {
                if (new SystemConfigAgent().InitSystemConfig())
                    config = new SystemConfigAgent().GetSystemConfig();
            }

            HttpCookie co = new HttpCookie("Site");
            co["PaperName"] = config.PaperName.ToString();
            co["SiteName"] = config.SiteName.ToString();
            co["SiteUrl"] = config.SiteUrl;
            co["PaperInfo"] = config.PaperInfo;
            co["EditorName"] = config.EditorName;
            co["EditorPhone"] = config.EditorPhone;
            co["EditorAddrs"] = config.EditorAddrs;
            co["EditorFax"] = config.EditorFax;
            co["EditorEmail"] = config.EditorEmail;
            Response.SetCookie(co);
        }
        


    }


    /// <summary>
    /// 获取地址栏参数
    /// </summary>
    /// <param name="key"></param>
    /// <returns></returns>
    protected string QS(string key)
    {
        return Request.QueryString[key] + "";
    }
}