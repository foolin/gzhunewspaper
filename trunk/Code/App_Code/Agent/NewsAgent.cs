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
    /// NewsAgent 的摘要说明
    /// </summary>
    public class NewsAgent : DbAgent
    {
        /// <summary>
        /// 构造函数，初始化数据库参数
        /// </summary>
        public NewsAgent() : base(SysSetting.GetSettings().DbType, SysSetting.GetSettings().DbConnectionString) { }

        /// <summary>
        /// 获取新闻列表
        /// </summary>
        /// <returns></returns>
        public ArrayList GetNewsList()
        {
            DataSet ds;
            using (IDbExecutor db = this.NewExecutor())
            {
                ds = db.GetDataSet(CommandType.StoredProcedure, "GetNewsList");
            }
            ArrayList list = new ArrayList();
            foreach (DataRow row in ds.Tables[0].Rows)
            {
                News news = new News(row);
                list.Add(news);
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
        /// 通过ID获取某版面新闻的信息
        /// </summary>
        /// <param name="NewsID">新闻ID</param>
        /// <returns></returns>
        public News GetNewsInfo(int NewsID)
        {
            DataSet ds;
            using (IDbExecutor db = this.NewExecutor())
            {
                ds = db.GetDataSet(CommandType.StoredProcedure, "GetNewsInfo",
                    this.NewParam("@NewsID", NewsID));
            }
            if (ds.Tables[0].Rows.Count == 0)
                return null;
            else
            {
                News news = new News(ds.Tables[0].Rows[0]);
                return news;
            }
        }



        /// <summary>
        /// 添加新闻
        /// </summary>
        /// <param name="news"></param>
        /// <returns></returns>
        public bool AddNews(News news)
        {
            using (IDbExecutor db = this.NewExecutor())
            {
                return db.ExecuteNonQuery(CommandType.StoredProcedure, "AddNews",
                    this.NewParam("@PageID", news.PageID),
                    this.NewParam("@PaperID", news.PaperID),
                    this.NewParam("@Title", news.Title),
                    this.NewParam("@Author", news.Author),
                    this.NewParam("@Content", news.Content),
                    this.NewParam("@PositionOfPage", news.PositionOfPage),
                    this.NewParam("@AddUser", news.AddUser),
                    this.NewParam("@AddTime", news.AddTime)) > 0;
            }
        }


        /// <summary>
        /// 更新新闻信息
        /// </summary>
        /// <param name="news"></param>
        /// <returns></returns>
        public bool UpdateNewsInfo(News news)
        {
            using (IDbExecutor db = this.NewExecutor())
            {
                return db.ExecuteNonQuery(CommandType.StoredProcedure, "UpdateNewsInfo",
                    this.NewParam("@NewsID", news.NewsID),
                    this.NewParam("@PageID", news.PageID),
                    this.NewParam("@PaperID", news.PaperID),
                    this.NewParam("@Title", news.Title),
                    this.NewParam("@Author", news.Author),
                    this.NewParam("@Content", news.Content),
                    this.NewParam("@PositionOfPage", news.PositionOfPage)) > 0;
            }
        }

        /// <summary>
        /// 删除新闻
        /// </summary>
        /// <param name="NewsID"></param>
        /// <returns></returns>
        public int DeletePaperPage(int NewsID)
        {
            using (IDbExecutor db = this.NewExecutor())
            {
                return db.ExecuteNonQuery(CommandType.StoredProcedure, "DeleteNews",
                    this.NewParam("@NewsID", NewsID));
            }
        }


    }

}
