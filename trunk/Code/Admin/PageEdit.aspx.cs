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
using Myweb.NewsPaper;
using System.IO;

public partial class Admin_PageEdit : AdminBase
{
    protected void Page_Load(object sender, EventArgs e)
    {

    }

    protected override void OnPreRender(EventArgs e)
    {
        if (QS("id") == "" || !WebAgent.IsInt32(QS("id")))
            WebAgent.AlertAndBack("参数错误");
        ArrayList arr = new NewsPaperAgent().GetNewsPaperList();
        PaperPage page = new PaperPageAgent().GetPaperPageInfo(int.Parse(QS("id")));
        if (page == null)
            WebAgent.AlertAndBack("不存在该版面");
        foreach (NewsPaper p in arr)
        {
            txtPaperID.Items.Add(p.PaperID.ToString());
        }

        this.txtPaperID.Items.FindByValue(page.PaperID.ToString()).Selected = true;
        this.txtPageNO.Text = page.PageNO.ToString();
        this.txtPageName.Text = page.PageName;

    }

    protected void btnSave_Click(object sender, EventArgs e)
    {
        if (txtPaperID.Text == "")
            WebAgent.AlertAndBack("期数不能为空");
        if (this.txtPageNO.Text == "")
            WebAgent.AlertAndBack("版面不能为空");

        PaperPage page = new PaperPageAgent().GetPaperPageInfo(int.Parse(QS("id")));
        int toNum;
        if (int.TryParse(this.txtPaperID.Text.ToString(), out toNum) == false)
            WebAgent.AlertAndBack("期刊必须为数字");
        else
            page.PaperID = toNum;
        if (int.TryParse(this.txtPageNO.Text.ToString(), out toNum) == false)
            WebAgent.AlertAndBack("版面必须为数字");
        page.PageNO = toNum;
        page.PageName = this.txtPageName.Text;
        if (this.txtPageImage.PostedFile.ContentLength > 0)
        {
            page.PageImage = UploadImage();
        }
        PaperPageAgent agent = new PaperPageAgent();
        if (agent.UpdatePaperPageInfo(page))
        {
            WebAgent.SuccAndGo("更新版面成功", "PageList.aspx");
        }
        else
        {
            WebAgent.AlertAndBack("更新版面失败");
        }

    }

    protected string UploadImage()
    {
        if (this.txtPageImage.PostedFile.ContentLength > 0)
        {
            if (this.txtPageImage.PostedFile.ContentType.IndexOf("image") == -1)
            {
                WebAgent.AlertAndBack("请选择一个文件");
                return "";
            }

            string photo = "../UploadFiles/PageImages/";
            if (!Directory.Exists(Server.MapPath(photo)))
                Directory.CreateDirectory(Server.MapPath(photo));
            photo += DateTime.Now.ToString("yyMMddHHmmssfff") + Path.GetExtension(this.txtPageImage.PostedFile.FileName);
            WebAgent.SaveFile(this.txtPageImage.PostedFile, Server.MapPath(photo), 400, 500, true);
            return photo.Substring(3);
        }
        else
        {
            WebAgent.AlertAndBack("请选择一个文件");
            return "";
        }
    }
}
