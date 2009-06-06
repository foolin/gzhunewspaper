// File:    UserFavorites.cs
// Author:  Foolin
// Created: 2009��6��1�� 11:19:33
// Purpose: Definition of Class UserFavorites

using System;
using System.Data;



namespace Myweb.NewsPaper
{


    /// <summary>
    /// �û��Ѳؼ���
    /// </summary>

    public class UserFavorites
    {
        public UserFavorites()
        { }

        public UserFavorites(DataRow row)
        {
            this.FavID = (int)row["FavID"];
            this.UserID = (int)row["UserID"];
            this.FavName = (string)row["FavName"];
            this.FavUrl = (string)row["FavUrl"];
            this.FavTime = (DateTime)row["FavTime"];
            this.FavType = (int)row["FavType"];
        }

        private int _favID;
        /// <summary>
        /// �ղ�ID
        /// </summary>
        public int FavID
        {
            get { return _favID; }
            set { _favID = value; }
        }

        private int _userID;
        /// <summary>
        /// �û�ID
        /// </summary>
        public int UserID
        {
            get { return _userID; }
            set { _userID = value; }
        }


        private string _favName;
        /// <summary>
        /// �ղ�����
        /// </summary>
        public string FavName
        {
            get { return _favName; }
            set { _favName = value; }
        }


        private string _favUrl;
        /// <summary>
        /// �ղص�ַ
        /// </summary>
        public string FavUrl
        {
            get { return _favUrl; }
            set { _favUrl = value; }
        }


        private DateTime _favTime;
        /// <summary>
        /// �Ѳ�ʱ��
        /// </summary>
        public DateTime FavTime
        {
            get { return _favTime; }
            set { _favTime = value; }
        }

        private int _favType;
        /// <summary>
        /// �ղ�����
        /// </summary>
        public int FavType
        {
            get { return _favType; }
            set { _favType = value; }
        }

    }

}