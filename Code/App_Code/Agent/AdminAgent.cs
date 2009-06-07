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
    /// AdminAgent 的摘要说明
    /// </summary>
    public class AdminAgent : DbAgent
    {
        public AdminAgent() : base(SysSetting.GetSettings().DbType, SysSetting.GetSettings().DbConnectionString) { }

        /// <summary>
        /// 获取管理员信息
        /// </summary>
        /// <param name="AdminID"></param>
        /// <returns></returns>
        public Admin GetAdminInfo(int AdminID)
        {
            DataSet ds;
            using (IDbExecutor db = this.NewExecutor())
            {
                ds = db.GetDataSet(CommandType.StoredProcedure, "GetAdminInfo",
                    this.NewParam("@AdminID", AdminID));
            }
            if (ds.Tables[0].Rows.Count == 0)
                return null;
            else
            {
                Admin admin = new Admin(ds.Tables[0].Rows[0]);
                return admin;
            }
        }

    }
}
