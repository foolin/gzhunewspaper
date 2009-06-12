// File:    NewsPaper.cs
// Author:  Foolin
// Created: 2009��6��1�� 11:03:26
// Purpose: Definition of Class NewsPaper

using System;
using System.Data;


namespace Myweb.NewsPaper
{


    /// <summary>
    /// �ڿ���
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
        /// �ڿ�ID(�ڿ���)
        /// </summary>
        public int PaperID
        {
            get { return _paperID; }
            set { _paperID = value; }
        }

        private DateTime _publishDate;
        /// <summary>
        /// ��������
        /// </summary>
        public DateTime PublishDate
        {
            get { return _publishDate; }
            set { _publishDate = value; }
        }

        private int _numOfPage;
        /// <summary>
        /// �ڿ�������
        /// </summary>
        public int NumOfPage
        {
            get { return _numOfPage; }
            set { _numOfPage = value; }
        }


        private bool _isShow;
        /// <summary>
        /// �Ƿ���ʾ
        /// </summary>
        public bool IsShow
        {
            get { return _isShow; }
            set { _isShow = value; }
        }


    }

}