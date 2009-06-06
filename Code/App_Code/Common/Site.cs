using System;
using System.Data;
using System.Configuration;
using System.Web;
using System.Web.Security;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Web.UI.WebControls.WebParts;
using System.Web.UI.HtmlControls;
using System.Collections;

namespace Myweb.NewsPaper
{

    /// <summary>
    /// Site 的摘要说明
    /// </summary>
    public class Site
    {
        public Site()
        {
            //
            // TODO: 在此处添加构造函数逻辑
            //
        }

        private SystemConfig config;
        /// <summary>
        /// 系统配置信息
        /// </summary>
        public SystemConfig Config
        {
            get { return config; }
            set { config = value; }
        }

        private ArrayList _adminList;
        /// <summary>
        /// 管理员集合
        /// </summary>
        public ArrayList AdminList
        {
            get { return _adminList; }
            set { _adminList = value; }
        }

        /// <summary>
        /// 获取管理员信息
        /// </summary>
        /// <param name="AdminID"></param>
        /// <returns></returns>
        public Admin GetAdminByID(int AdminID)
        {
            foreach (Admin a in this.AdminList)
            {
                if (a.AdminID == AdminID) return a;
            }
            return null;
        }

    }

}