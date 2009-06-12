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
using Myweb.NewsPaper;
using Studio.Web;
using System.IO;

public partial class Admin_PageAdd : AdminBase
{
    protected void Page_Load(object sender, EventArgs e)
    {

    }

    protected override void OnPreRender(EventArgs e)
    {
        if (!IsPostBack)
        {
            ArrayList arr = new NewsPaperAgent().GetNewsPaperList();
            if (arr == null || arr.Count < 1)
                WebAgent.FailAndGo("期刊为空，请先添加期刊", "PaperAdd.aspx");
            int flag = 0;
            foreach (NewsPaper p in arr)
            {
                if (flag == 0)
                {
                    txtPageID.Text = (new PaperPageAgent().GetLastPageID(p.PaperID) + 1).ToString();
                    flag = 1;
                }
                txtPaperID.Items.Add(p.PaperID.ToString());
            }
        }
        

    }

    protected void btnSave_Click(object sender, EventArgs e)
    {

        if (txtPaperID.Text == "")
            WebAgent.AlertAndBack("期数不能为空");
        if (this.txtPageID.Text == "")
            WebAgent.AlertAndBack("版面不能为空");

        PaperPage page = new PaperPage();
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
        if ((new PaperPageAgent().GetPaperPageInfo(page.PaperID, page.PageID)) != null)
            WebAgent.AlertAndBack("该期刊号[" + page.PaperID + "]已经存在版面号[" + page.PageID + "]的版面，请检查");
        page.PageName = this.txtPageName.Text;
        page.PageImage = UploadImage();


        PaperPageAgent agent = new PaperPageAgent();
        if (agent.AddPaperPage(page))
        {
            WebAgent.SuccAndGo("添加版面成功", "PageList.aspx");
        }
        else
        {
            WebAgent.AlertAndBack("添加版面失败");
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
            //WebAgent.SaveFile(this.txtPageImage.PostedFile, Server.MapPath(photo), 360, 0, true);
            WebAgent.SaveFile(this.txtPageImage.PostedFile,"" , Server.MapPath(photo), 360);
            return photo.Substring(3);
        }
        else
        {
            WebAgent.AlertAndBack("请选择一个文件");
            return "";
        }
    }

    protected void txtPaperID_SelectedIndexChanged(object sender, EventArgs e)
    {
        txtPageID.Text = (new PaperPageAgent().GetLastPageID(int.Parse(this.txtPaperID.SelectedValue.ToString())) + 1).ToString();
    }
}
