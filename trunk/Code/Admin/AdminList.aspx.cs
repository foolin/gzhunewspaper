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

public partial class Admin_AdminList : AdminBase
{
    protected void Page_Load(object sender, EventArgs e)
    {

    }
    protected override void OnPreRender(EventArgs e)
    {
        listAdmin.DataSource = new AdminAgent().GetAdminList();
        listAdmin.DataBind();
    }

}
