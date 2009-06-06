using System;
using System.Data;
using System.Configuration;
using System.Web;
using System.Web.Security;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Web.UI.WebControls.WebParts;
using System.Web.UI.HtmlControls;
using Studio.Data;


namespace Myweb.NewsPaper
{
    /// <summary>
    /// SiteAdminAgent 的摘要说明
    /// </summary>
    public class SiteAgent : DbAgent
    {
        public SiteAgent() : base(SysSetting.GetSettings().DbType, SysSetting.GetSettings().DbConnectionString) { }

        /// <summary>
        /// 管理员登陆
        /// </summary>
        /// <param name="AdminName"></param>
        /// <param name="Password"></param>
        /// <returns></returns>
        public int ChkAdminLogin(string AdminName, string Password)
        {
            using (IDbExecutor db = this.NewExecutor())
            {
                return db.ExecuteProcedure("ChkAdminLogin",
                    this.NewParam("@AdminName", AdminName),
                    this.NewParam("@Password", Password));
            }
        }

       

    }

}
