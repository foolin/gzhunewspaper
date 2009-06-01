// File:    PaperPage.cs
// Author:  Foolin
// Created: 2009年6月1日 11:07:13
// Purpose: Definition of Class PaperPage

using System;


namespace Myweb.NewsPaper
{

    /// <summary>
    /// 版面类
    /// </summary>
    /// 

    public class PaperPage
    {
        public PaperPage()
        { }

        private int _pageID;
        /// <summary>
        /// 版面ID
        /// </summary>
        public int PageID
        {
            get { return _pageID; }
            set { _pageID = value; }
        }

        private int _pageNO;
        /// <summary>
        /// 版面号
        /// </summary>
        public int PageNO
        {
            get { return _pageNO; }
            set { _pageNO = value; }
        }

        private int _paperID;
        /// <summary>
        /// 期刊ID（可查出期刊号）
        /// </summary>
        public int PaperID
        {
            get { return _paperID; }
            set { _paperID = value; }
        }

        private string _pageName;
        /// <summary>
        /// 版面名称
        /// </summary>
        public string PageName
        {
            get { return _pageName; }
            set { _pageName = value; }
        }

        private string _pageImage;
        /// <summary>
        /// 版面缩略图片
        /// </summary>
        public string PageImage
        {
            get { return _pageImage; }
            set { _pageImage = value; }
        }


    }

}