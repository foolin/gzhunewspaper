using System;
using System.Data;
using System.Configuration;
// File:    PaperPagerAgent.cs
// Author:  Foolin
// Created: 2009年6月7日11:13:56
// Updated: 2009-6-7 1:18:03
// Purpose: 期刊版面（PaperPage）处理逻辑类

using System.Web;
using System.Web.Security;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Web.UI.WebControls.WebParts;
using System.Web.UI.HtmlControls;
using System.Collections;

using Studio.Data;  //引入常操作命名空间

namespace Myweb.NewsPaper
{

    /// <summary>
    /// PaperPageAgent 的摘要说明
    /// </summary>
    public class PaperPageAgent : DbAgent
    {
        /// <summary>
        /// 构造函数，初始化数据库参数
        /// </summary>
        public PaperPageAgent() : base(SysSetting.GetSettings().DbType, SysSetting.GetSettings().DbConnectionString) { }

        /// <summary>
        /// 获取期刊版面列表
        /// </summary>
        /// <returns></returns>
        public ArrayList GetPaperPageList()
        {
            DataSet ds;
            using (IDbExecutor db = this.NewExecutor())
            {
                ds = db.GetDataSet(CommandType.StoredProcedure, "GetPaperPageList");
            }
            ArrayList list = new ArrayList();
            foreach (DataRow row in ds.Tables[0].Rows)
            {
                PaperPage page = new PaperPage(row);
                list.Add(page);
            }
            return list;
        }

        /// <summary>
        /// 通过ID获取期刊版面列表
        /// </summary>
        /// <returns></returns>
        public ArrayList GetPaperPageList(int PaperID)
        {
            DataSet ds;
            using (IDbExecutor db = this.NewExecutor())
            {
                ds = db.GetDataSet(CommandType.StoredProcedure, "GetPaperPageListByPaperID", this.NewParam("@PaperID", PaperID));
            }
            ArrayList list = new ArrayList();
            foreach (DataRow row in ds.Tables[0].Rows)
            {
                PaperPage page = new PaperPage(row);
                list.Add(page);
            }
            return list;
        }

        /// <summary>
        /// 通过ID获取某期刊版面的信息
        /// </summary>
        /// <param name="PaperID">期刊ID</param>
        /// <param name="PaperID">版面ID</param>
        /// <returns></returns>
        public  PaperPage GetPaperPageInfo(int PaperID, int PageID)
        {
            DataSet ds;
            using (IDbExecutor db = this.NewExecutor())
            {
                ds = db.GetDataSet(CommandType.StoredProcedure, "GetPaperPageInfo",
                    this.NewParam("@PaperID", PaperID),
                    this.NewParam("@PageID", PageID));
            }
            if (ds.Tables[0].Rows.Count == 0)
                return null;
            else
            {
                PaperPage page = new PaperPage(ds.Tables[0].Rows[0]);
                return page;
            }
        }



        /// <summary>
        /// 添加期刊
        /// </summary>
        /// <param name="paper"></param>
        /// <returns></returns>
        public bool AddPaperPage(PaperPage page)
        {
            using (IDbExecutor db = this.NewExecutor())
            {
                return db.ExecuteNonQuery(CommandType.StoredProcedure, "AddPaperPage",
                    this.NewParam("@PaperID", page.PaperID),
                    this.NewParam("@PageID", page.PageID),
                    this.NewParam("@PageName", page.PageName),
                    this.NewParam("@PageImage", page.PageImage)) > 0;
            }
        }


        /// <summary>
        /// 更新期刊信息
        /// </summary>
        /// <param name="paper"></param>
        /// <returns></returns>
        public bool UpdatePaperPageInfo(int oldPaperID, int oldPageID, PaperPage page)
        {
            using (IDbExecutor db = this.NewExecutor())
            {
                return db.ExecuteNonQuery(CommandType.StoredProcedure, "UpdatePaperPageInfo",
                    this.NewParam("@oldPaperID", oldPaperID),
                    this.NewParam("@oldPageID", oldPageID),
                    this.NewParam("@PaperID", page.PaperID),
                    this.NewParam("@PageID", page.PageID),
                    this.NewParam("@PageName", page.PageName),
                    this.NewParam("@PageImage", page.PageImage)) > 0;
            }
        }

        /// <summary>
        /// 删除连接
        /// </summary>
        /// <param name="LinkID"></param>
        /// <returns></returns>
        public int DeletePaperPage(int PaperID, int PageID)
        {
            using (IDbExecutor db = this.NewExecutor())
            {
                return db.ExecuteNonQuery(CommandType.StoredProcedure, "DeletePaperPage",
                    this.NewParam("@PaperID", PaperID),
                    this.NewParam("@PageID", PageID));
            }
        }

        public int GetLastPageID(int PaperID)
        {

            using (IDbExecutor db = this.NewExecutor())
            {
                return db.ExecuteProcedure("GetLastPageID",
                    this.NewParam("@PaperID", PaperID));
            }

        }
    }

}
