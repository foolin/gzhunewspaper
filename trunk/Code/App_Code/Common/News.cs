// File:    News.cs
// Author:  Foolin
// Created: 2009年6月1日 10:44:51
// Purpose: Definition of Class News

using System;
using System.Data;

namespace Myweb.NewsPaper
{


    /// <summary>
    /// 新闻类
    /// </summary>
    public class News
    {
        public News()
        { }

        public News(DataRow row)
        {
            this.NewsID = (int)row["NewsID"];
            this.PaperID = (int)row["PaperID"];
            this.PageID = (int)row["PageID"];
            this.Title = (string)row["Title"];
            this.Content = (string)row["Content"];
            this.PositionOfPage = (string)row["PositionOfPage"];
            this.AddUser = (string)row["AddUser"];
            this.AddTime = (DateTime)row["AddTime"];
            this.ViewCount = (int)row["ViewCount"];
        }

        private int _newsID;
        /// <summary>
        /// 新闻ID
        /// </summary>
        public int NewsID
        {
            get { return _newsID; }
            set { _newsID = value; }
        }

        private int _PaperID;
        /// <summary>
        /// 新闻期刊ID
        /// </summary>
        public int PaperID
        {
            get { return _PaperID; }
            set { _PaperID = value; }
        }

        private int _pageID;
        /// <summary>
        /// 新闻版面ID
        /// </summary>
        public int PageID
        {
            get { return _pageID; }
            set { _pageID = value; }
        }


        private string _title;
        /// <summary>
        /// 新闻标题
        /// </summary>
        public string Title
        {
            get { return _title; }
            set { _title = value; }
        }


        private string _author;
        /// <summary>
        /// 新闻作者
        /// </summary>
        public string Author
        {
            get { return _author; }
            set { _author = value; }
        }


        private string _content;
        /// <summary>
        /// 新闻内容
        /// </summary>
        public string Content
        {
            get { return _content; }
            set { _content = value; }
        }


        private string _positionOfPage;
        /// <summary>
        /// 新闻在版面位置
        /// </summary>
        public string PositionOfPage
        {
            get { return _positionOfPage; }
            set { _positionOfPage = value; }
        }


        private string _addUser;
        /// <summary>
        /// 添加新闻的用户
        /// </summary>
        public string AddUser
        {
            get { return _addUser; }
            set { _addUser = value; }
        }


        private DateTime _addTime;
        /// <summary>
        /// 添加新闻的时间
        /// </summary>
        public DateTime AddTime
        {
            get { return _addTime; }
            set { _addTime = value; }
        }


        private int _viewCount;
        /// <summary>
        /// 新闻浏览的次数
        /// </summary>
        public int ViewCount
        {
            get { return _viewCount; }
            set { _viewCount = value; }
        }


    }

}