// File:    UserFavorites.cs
// Author:  Foolin
// Created: 2009年6月1日 11:19:33
// Purpose: Definition of Class UserFavorites

using System;
using System.Data;



namespace Myweb.NewsPaper
{


    /// <summary>
    /// 用户搜藏夹类
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
        /// 收藏ID
        /// </summary>
        public int FavID
        {
            get { return _favID; }
            set { _favID = value; }
        }

        private int _userID;
        /// <summary>
        /// 用户ID
        /// </summary>
        public int UserID
        {
            get { return _userID; }
            set { _userID = value; }
        }


        private string _favName;
        /// <summary>
        /// 收藏名称
        /// </summary>
        public string FavName
        {
            get { return _favName; }
            set { _favName = value; }
        }


        private string _favUrl;
        /// <summary>
        /// 收藏地址
        /// </summary>
        public string FavUrl
        {
            get { return _favUrl; }
            set { _favUrl = value; }
        }


        private DateTime _favTime;
        /// <summary>
        /// 搜藏时间
        /// </summary>
        public DateTime FavTime
        {
            get { return _favTime; }
            set { _favTime = value; }
        }

        private int _favType;
        /// <summary>
        /// 收藏类型
        /// </summary>
        public int FavType
        {
            get { return _favType; }
            set { _favType = value; }
        }

    }

}