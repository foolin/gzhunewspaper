using System;
using System.Collections.Generic;
using System.Web;
using Studio.Web;
using Myweb.NewsPaper;

/// <summary>
/// SiteBase 的摘要说明
/// </summary>
public class SiteBase : System.Web.UI.Page
{
    public SystemConfig site;

	public SiteBase()
	{
		//
		// TODO: 在此处添加构造函数逻辑
		//
	}

    protected override void OnLoad(EventArgs e)
    {
        if (site == null)
            site = new SystemConfigAgent().GetSystemConfig();

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

    /// <summary>
    /// 读取网站信息
    /// </summary>
    /// <param name="key"></param>
    /// <returns></returns>
    protected string Site(string key)
    {
        return Request.Cookies["Site"][key].ToString() + "";
    }
}
