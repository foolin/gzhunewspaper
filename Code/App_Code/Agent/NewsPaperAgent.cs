// File:    NewsPaperAgent.cs
// Author:  Foolin
// Created: 2009年6月1日12:45:04
// Updated: 2009-6-7 1:18:03
// Purpose: 期刊（NewsPaper）处理逻辑类

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

using Studio.Data;  //引入常操作命名空间

namespace Myweb.NewsPaper
{
    /// <summary>
    /// 数据库NewsPaper处理逻辑类，用于添加、修改、删除数据库表【NewsPaper】里面的记录。
    /// </summary>
    public class NewsPaperAgent : DbAgent
    {
        /// <summary>
        /// 构造函数，初始化数据库参数
        /// </summary>
        public NewsPaperAgent() : base(SysSetting.GetSettings().DbType, SysSetting.GetSettings().DbConnectionString) { }


        /// <summary>
        /// 获取期刊列表
        /// </summary>
        /// <returns></returns>
        public ArrayList GetNewsPaperList()
        {
            DataSet ds;
            using (IDbExecutor db = this.NewExecutor())
            {
                ds = db.GetDataSet(CommandType.StoredProcedure, "GetNewsPaperList");
            }
            ArrayList list = new ArrayList();
            foreach (DataRow row in ds.Tables[0].Rows)
            {
                NewsPaper paper = new NewsPaper(row);
                list.Add(paper);
            }
            return list;
        }


        /// <summary>
        /// 通过ID获取某期刊的信息
        /// </summary>
        /// <param name="PaperID">期刊ID</param>
        /// <returns></returns>
        public NewsPaper GetNewsPaperInfo(int PaperID)
        {
            DataSet ds;
            using (IDbExecutor db = this.NewExecutor())
            {
                ds = db.GetDataSet(CommandType.StoredProcedure, "GetNewsPaperInfo",
                    this.NewParam("@PaperID", PaperID));
            }
            if (ds.Tables[0].Rows.Count == 0)
                return null;
            else
            {
                NewsPaper paper = new NewsPaper(ds.Tables[0].Rows[0]);
                return paper;
            }
        }


        /// <summary>
        /// 添加期刊
        /// </summary>
        /// <param name="paper"></param>
        /// <returns></returns>
        public bool AddNewsPaper(NewsPaper paper)
        {
            using (IDbExecutor db = this.NewExecutor())
            {
                return db.ExecuteNonQuery(CommandType.StoredProcedure, "AddNewsPaper",
                    this.NewParam("@PaperID", paper.PaperID),
                    this.NewParam("@PublishDate", paper.PublishDate),
                    this.NewParam("@NumOfPage", paper.NumOfPage),
                    this.NewParam("@IsShow", paper.IsShow)) > 0;
            }
        }


        /// <summary>
        /// 更新期刊信息
        /// </summary>
        /// <param name="paper"></param>
        /// <returns></returns>
        public bool UpdateNewsPaperInfo(NewsPaper paper)
        {
            using (IDbExecutor db = this.NewExecutor())
            {
                return db.ExecuteNonQuery(CommandType.StoredProcedure, "UpdateNewsPaperInfo",
                    this.NewParam("@PaperID", paper.PaperID),
                    this.NewParam("@PublishDate", paper.PublishDate),
                    this.NewParam("@NumOfPage", paper.NumOfPage),
                    this.NewParam("@IsShow", paper.IsShow)) > 0;
            }
        }

        /// <summary>
        /// 删除期刊
        /// </summary>
        /// <param name="LinkID"></param>
        /// <returns></returns>
        public int DeleteNewsPaper(int PaperID)
        {
            using (IDbExecutor db = this.NewExecutor())
            {
                return db.ExecuteNonQuery(CommandType.StoredProcedure, "DeleteNewsPaper",
                    this.NewParam("@PaperID", PaperID));
            }
        }


        /// <summary>
        /// 获取最新的期刊ID
        /// </summary>
        /// <returns></returns>
        public int GetLastPaperID()
        {

            using (IDbExecutor db = this.NewExecutor())
            {
                return db.ExecuteProcedure("GetLastPaperID");
            }

        }

    }

}