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
        if (QS("PaperID") == "" || !WebAgent.IsInt32(QS("PaperID")) || QS("PageID") == "" || !WebAgent.IsInt32(QS("PageID")))
            WebAgent.AlertAndBack("参数错误");
        ArrayList arr = new NewsPaperAgent().GetNewsPaperList();
        PaperPage page = new PaperPageAgent().GetPaperPageInfo(int.Parse(QS("PaperID")), int.Parse(QS("PageID")));
        if (page == null)
            WebAgent.AlertAndBack("不存在该版面");
        foreach (NewsPaper p in arr)
        {
            txtPaperID.Items.Add(p.PaperID.ToString());
        }

        this.txtPaperID.Items.FindByValue(page.PaperID.ToString()).Selected = true;
        this.txtPageID.Text = page.PageID.ToString();
        this.txtPageName.Text = page.PageName;

    }

    protected void btnSave_Click(object sender, EventArgs e)
    {
        if (txtPaperID.Text == "")
            WebAgent.AlertAndBack("期数不能为空");
        if (this.txtPageID.Text == "")
            WebAgent.AlertAndBack("版面不能为空");

        PaperPage page = new PaperPageAgent().GetPaperPageInfo(int.Parse(QS("PaperID")), int.Parse(QS("PageID")));
        int toNum;
        if (int.TryParse(this.txtPaperID.Text.ToString(), out toNum) == false)
            WebAgent.AlertAndBack("期刊必须为数字");
        else
            page.PaperID = toNum;
        if (int.TryParse(this.txtPageID.Text.ToString(), out toNum) == false)
            WebAgent.AlertAndBack("版面必须为数字");
        page.PageID = toNum;
        if (page.PageID > (new NewsPaperAgent().GetNewsPaperInfo(page.PaperID).NumOfPage))
            WebAgent.AlertAndBack("版面号不能超过版面数");
        if (page.PaperID != int.Parse(QS("PaperID")) || page.PaperID != int.Parse(QS("PaperID")))
        {
            if ((new PaperPageAgent().GetPaperPageInfo(page.PaperID, page.PageID)) != null)
                WebAgent.AlertAndBack("该期刊号[" + page.PaperID + "]已经存在版面号[" + page.PageID + "]的版面，请检查");
        }
        page.PageName = this.txtPageName.Text;
        if (this.txtPageImage.PostedFile.ContentLength > 0)
        {
            page.PageImage = UploadImage();
        }
        PaperPageAgent agent = new PaperPageAgent();
        if (agent.UpdatePaperPageInfo(int.Parse(QS("PaperID")), int.Parse(QS("PageID")), page))
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
            //WebAgent.SaveFile(this.txtPageImage.PostedFile, Server.MapPath(photo), 360, 1200, true);
            WebAgent.SaveFile(this.txtPageImage.PostedFile, "", Server.MapPath(photo), 360);
            return photo.Substring(3);
        }
        else
        {
            WebAgent.AlertAndBack("请选择一个文件");
            return "";
        }
    }
}
