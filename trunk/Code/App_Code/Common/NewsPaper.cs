// File:    NewsPaper.cs
// Author:  Foolin
// Created: 2009年6月1日 11:03:26
// Purpose: Definition of Class NewsPaper

using System;
using System.Data;


namespace Myweb.NewsPaper
{


    /// <summary>
    /// 期刊类
    /// </summary>

    public class NewsPaper
    {
        public NewsPaper()
        { }

        public NewsPaper(DataRow row)
        {
            this.PaperID = (int)row["PaperID"];
            this.PublishDate = (DateTime)row["PublishDate"];
            this.NumOfPage = (int)row["NumOfPage"];
            this.IsShow = (bool)row["IsShow"];
        }

        private int _paperID;
        /// <summary>
        /// 期刊ID(期刊号)
        /// </summary>
        public int PaperID
        {
            get { return _paperID; }
            set { _paperID = value; }
        }

        private DateTime _publishDate;
        /// <summary>
        /// 出版日期
        /// </summary>
        public DateTime PublishDate
        {
            get { return _publishDate; }
            set { _publishDate = value; }
        }

        private int _numOfPage;
        /// <summary>
        /// 期刊版面数
        /// </summary>
        public int NumOfPage
        {
            get { return _numOfPage; }
            set { _numOfPage = value; }
        }


        private bool _isShow;
        /// <summary>
        /// 是否显示
        /// </summary>
        public bool IsShow
        {
            get { return _isShow; }
            set { _isShow = value; }
        }


    }

}