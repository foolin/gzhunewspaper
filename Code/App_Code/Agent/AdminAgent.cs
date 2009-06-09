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
    /// AdminAgent 的摘要说明
    /// </summary>
    public class AdminAgent : DbAgent
    {
        public AdminAgent() : base(SysSetting.GetSettings().DbType, SysSetting.GetSettings().DbConnectionString) { }

        /// <summary>
        /// 通过ID获取管理员信息
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

        /// <summary>
        /// 获取管理员的信息列表
        /// </summary>
        /// <returns></returns>
        public ArrayList GetAdminList()
        {
            DataSet ds;
            using (IDbExecutor db = this.NewExecutor())
            {
                ds = db.GetDataSet(CommandType.StoredProcedure, "GetAdminList");
            }
            ArrayList list = new ArrayList();
            foreach (DataRow row in ds.Tables[0].Rows)
            {
                Admin news = new Admin(row);
                list.Add(news);
            }
            return list;
        }

        /// <summary>
        /// 添加管理员
        /// </summary>
        /// <param name="admin"></param>
        /// <returns></returns>
        public bool AddAdmin(Admin admin)
        {
            using (IDbExecutor db = this.NewExecutor())
            {
                return db.ExecuteNonQuery(CommandType.StoredProcedure, "AddAdmin",
                    this.NewParam("@AdminName", admin.AdminName),
                    this.NewParam("@Password", admin.Password),
                    this.NewParam("@Power", admin.Power)) > 0;
            }
        }


        /// <summary>
        /// 更新管理员信息
        /// </summary>
        /// <param name="admin"></param>
        /// <returns></returns>
        public bool UpdateAdminInfo(Admin admin)
        {
            using (IDbExecutor db = this.NewExecutor())
            {
                return db.ExecuteNonQuery(CommandType.StoredProcedure, "UpdateAdminInfo",
                    this.NewParam("@AdminID", admin.AdminID),
                    this.NewParam("@AdminName", admin.AdminName),
                    this.NewParam("@Password", admin.Password),
                    this.NewParam("@Power", admin.Power),
                    this.NewParam("@LoginCount", admin.LoginCount),
                    this.NewParam("@LastLoginTime", admin.LastLoginTime),
                    this.NewParam("@LastLoginIP", admin.LastLoginIP)) > 0;
            }
        }

        /// <summary>
        /// 删除管理员
        /// </summary>
        /// <param name="AdminID"></param>
        /// <returns></returns>
        public int DeleteAdmin(int AdminID)
        {
            using (IDbExecutor db = this.NewExecutor())
            {
                return db.ExecuteNonQuery(CommandType.StoredProcedure, "DeleteAdmin",
                    this.NewParam("@AdminID", AdminID));
            }
        }

    }
}
