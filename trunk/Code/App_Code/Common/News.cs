// File:    News.cs
// Author:  Foolin
// Created: 2009��6��1�� 10:44:51
// Purpose: Definition of Class News

using System;
using System.Data;

namespace Myweb.NewsPaper
{


    /// <summary>
    /// ������
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
        /// ����ID
        /// </summary>
        public int NewsID
        {
            get { return _newsID; }
            set { _newsID = value; }
        }

        private int _PaperID;
        /// <summary>
        /// �����ڿ�ID
        /// </summary>
        public int PaperID
        {
            get { return _PaperID; }
            set { _PaperID = value; }
        }

        private int _pageID;
        /// <summary>
        /// ���Ű���ID
        /// </summary>
        public int PageID
        {
            get { return _pageID; }
            set { _pageID = value; }
        }


        private string _title;
        /// <summary>
        /// ���ű���
        /// </summary>
        public string Title
        {
            get { return _title; }
            set { _title = value; }
        }


        private string _author;
        /// <summary>
        /// ��������
        /// </summary>
        public string Author
        {
            get { return _author; }
            set { _author = value; }
        }


        private string _content;
        /// <summary>
        /// ��������
        /// </summary>
        public string Content
        {
            get { return _content; }
            set { _content = value; }
        }


        private string _positionOfPage;
        /// <summary>
        /// �����ڰ���λ��
        /// </summary>
        public string PositionOfPage
        {
            get { return _positionOfPage; }
            set { _positionOfPage = value; }
        }


        private string _addUser;
        /// <summary>
        /// ������ŵ��û�
        /// </summary>
        public string AddUser
        {
            get { return _addUser; }
            set { _addUser = value; }
        }


        private DateTime _addTime;
        /// <summary>
        /// ������ŵ�ʱ��
        /// </summary>
        public DateTime AddTime
        {
            get { return _addTime; }
            set { _addTime = value; }
        }


        private int _viewCount;
        /// <summary>
        /// ��������Ĵ���
        /// </summary>
        public int ViewCount
        {
            get { return _viewCount; }
            set { _viewCount = value; }
        }


    }

}