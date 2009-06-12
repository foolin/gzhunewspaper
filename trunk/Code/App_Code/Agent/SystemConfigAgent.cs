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
using System.Collections;


namespace Myweb.NewsPaper
{

    /// <summary>
    /// SystemConfigAgent 的摘要说明
    /// </summary>
    public class SystemConfigAgent : DbAgent
    {
        /// <summary>
        /// 构造函数
        /// </summary>
        public SystemConfigAgent() : base(SysSetting.GetSettings().DbType, SysSetting.GetSettings().DbConnectionString) { }

        /// <summary>
        /// 获取系统配置列表
        /// </summary>
        /// <returns></returns>
        public SystemConfig GetSystemConfig()
        {
            DataSet ds;
            using (IDbExecutor db = this.NewExecutor())
            {
                ds = db.GetDataSet(CommandType.StoredProcedure, "GetSystemConfig");
            }
            if (ds.Tables[0].Rows.Count == 0)
                return null;
            else
            {
                SystemConfig config = new SystemConfig(ds.Tables[0].Rows[0]);
                return config;
            }
        }

        /// <summary>
        /// 初始化系统配置
        /// </summary>
        /// <returns></returns>
        public bool InitSystemConfig()
        {
            using (IDbExecutor db = this.NewExecutor())
            {
                return db.ExecuteNonQuery(CommandType.StoredProcedure, "InitSystemConfig") > 0;
            }
        }

        /// <summary>
        /// 更新系统配置信息
        /// </summary>
        /// <param name="systemconfig"></param>
        /// <returns></returns>
        public bool UpdateSystemConfigInfo(SystemConfig systemconfig)
        {
            using (IDbExecutor db = this.NewExecutor())
            {
                return db.ExecuteNonQuery(CommandType.StoredProcedure, "UpdateSystemConfig",
                    this.NewParam("@PaperName", systemconfig.PaperName),
                    this.NewParam("@SiteName", systemconfig.SiteName),
                    this.NewParam("@SiteUrl", systemconfig.SiteUrl),
                    this.NewParam("@PaperInfo", systemconfig.PaperInfo),
                    this.NewParam("@IsOpenRegister", systemconfig.IsOpenRegister),
                    this.NewParam("@EditorName", systemconfig.EditorName),
                    this.NewParam("@EditorAddrs", systemconfig.EditorAddrs),
                    this.NewParam("@EditorPhone", systemconfig.EditorPhone),
                    this.NewParam("@EditorFax", systemconfig.EditorFax),
                    this.NewParam("@EditorEmail", systemconfig.EditorEmail),
                    this.NewParam("@EditorPostCode", systemconfig.EditorPostCode)
                    ) > 0;
            }
        }
    }
}
