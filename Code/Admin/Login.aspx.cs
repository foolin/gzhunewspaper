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
using Studio.Web;
using Studio.Security;
using Myweb.NewsPaper;


public partial class Admin_Login : System.Web.UI.Page
{
    protected string valcode = "1234";
    protected void Page_Load(object sender, EventArgs e)
    {
        valcode = (new Random()).Next(1000, 9999).ToString();
        imgVal.ImageUrl = "Inc/Imageval.aspx?id=" + valcode;
        imgVal.ImageAlign = ImageAlign.AbsBottom;
    }

    protected void submit_Click(object sender, EventArgs e)
    {
        string valcode1 = Request.Params["valcode"] + "";
        string val1 = txtCode.Text;

        if (valcode1 != "")
        {
            if (val1 == "")
                return;
            if (Studio.Security.Secure.Md5(valcode1).Replace("-", "").Replace("A", "").Replace("B", "").Replace("C", "").Replace("D", "").Replace("E", "").Replace("F", "").Substring(0, 4) != val1)
            {
                WebAgent.AlertAndBack("验证码错误!");
            }
        }

        int AdminID = new SiteAgent().ChkAdminLogin(txtName.Text, Secure.Md5(txtPass.Text));
        if (AdminID > 0)
        {
            HttpCookie co = new HttpCookie("Admin");
            co["AdminID"] = AdminID.ToString();
            co["AdminName"] = txtName.Text;
            Response.SetCookie(co);
            Response.Redirect("Default.aspx");
        }
        else
        {
            switch (AdminID)
            {
                case 0: //用户不存在
                    WebAgent.FailAndGo("用户不存在", "Login.aspx");
                    break;
                case -1: //密码错误
                    WebAgent.FailAndGo("密码错误", "Login.aspx");
                    break;
                default: //登录失败
                    WebAgent.FailAndGo("登陆失败", "Login0..aspx");
                    break;
            }
        }


    }
}
