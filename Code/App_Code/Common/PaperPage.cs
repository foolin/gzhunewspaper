// File:    PaperPage.cs
// Author:  Foolin
// Created: 2009��6��1�� 11:07:13
// Purpose: Definition of Class PaperPage

using System;


namespace Myweb.NewsPaper
{

    /// <summary>
    /// ������
    /// </summary>
    /// 

    public class PaperPage
    {
        public PaperPage()
        { }

        private int _pageID;
        /// <summary>
        /// ����ID
        /// </summary>
        public int PageID
        {
            get { return _pageID; }
            set { _pageID = value; }
        }

        private int _pageNO;
        /// <summary>
        /// �����
        /// </summary>
        public int PageNO
        {
            get { return _pageNO; }
            set { _pageNO = value; }
        }

        private int _paperID;
        /// <summary>
        /// �ڿ�ID���ɲ���ڿ��ţ�
        /// </summary>
        public int PaperID
        {
            get { return _paperID; }
            set { _paperID = value; }
        }

        private string _pageName;
        /// <summary>
        /// ��������
        /// </summary>
        public string PageName
        {
            get { return _pageName; }
            set { _pageName = value; }
        }

        private string _pageImage;
        /// <summary>
        /// ��������ͼƬ
        /// </summary>
        public string PageImage
        {
            get { return _pageImage; }
            set { _pageImage = value; }
        }


    }

}