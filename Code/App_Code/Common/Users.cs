// File:    Users.cs
// Author:  Foolin
// Created: 2009年6月1日12:39:35
// Purpose: Definition of Class Users

using System;


namespace Myweb.NewsPaper
{


    /// <summary>
    /// 用户类
    /// </summary>

    public class Users
    {
        public Users()
        { }

        private int _userID;
        /// <summary>
        /// 用户ID
        /// </summary>
        public int UserID
        {
            get { return _userID; }
            set { _userID = value; }
        }

        private string _userName;
        /// <summary>
        /// 用户名
        /// </summary>
        public string UserName
        {
            get { return _userName; }
            set { _userName = value; }
        }

        private string _password;
        /// <summary>
        /// 用户密码
        /// </summary>
        public string Password
        {
            get { return _password; }
            set { _password = value; }
        }


        private string _nickName;
        /// <summary>
        /// 用户昵称
        /// </summary>
        public string NickName
        {
            get { return _nickName; }
            set { _nickName = value; }
        }

        private string _email;
        /// <summary>
        /// 用户E-mail
        /// </summary>
        public string Email
        {
            get { return _email; }
            set { _email = value; }
        }

        private int _loginCount;
        /// <summary>
        /// 用户登录次数
        /// </summary>
        public int LoginCount
        {
            get { return _loginCount; }
            set { _loginCount = value; }
        }


        private DateTime _lastLoginTime;
        /// <summary>
        /// 用户最后登录时间
        /// </summary>
        public DateTime LastLoginTime
        {
            get { return _lastLoginTime; }
            set { _lastLoginTime = value; }
        }



        private string _lastLoginIP;
        /// <summary>
        /// 用户最后登录IP
        /// </summary>
        public string LastLoginIP
        {
            get { return _lastLoginIP; }
            set { _lastLoginIP = value; }
        }

    }

}