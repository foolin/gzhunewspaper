// File:    Users.cs
// Author:  Foolin
// Created: 2009��6��1��12:39:35
// Purpose: Definition of Class Users

using System;


namespace Myweb.NewsPaper
{


    /// <summary>
    /// �û���
    /// </summary>

    public class Users
    {
        public Users()
        { }

        private int _userID;
        /// <summary>
        /// �û�ID
        /// </summary>
        public int UserID
        {
            get { return _userID; }
            set { _userID = value; }
        }

        private string _userName;
        /// <summary>
        /// �û���
        /// </summary>
        public string UserName
        {
            get { return _userName; }
            set { _userName = value; }
        }

        private string _password;
        /// <summary>
        /// �û�����
        /// </summary>
        public string Password
        {
            get { return _password; }
            set { _password = value; }
        }


        private string _nickName;
        /// <summary>
        /// �û��ǳ�
        /// </summary>
        public string NickName
        {
            get { return _nickName; }
            set { _nickName = value; }
        }

        private string _email;
        /// <summary>
        /// �û�E-mail
        /// </summary>
        public string Email
        {
            get { return _email; }
            set { _email = value; }
        }

        private int _loginCount;
        /// <summary>
        /// �û���¼����
        /// </summary>
        public int LoginCount
        {
            get { return _loginCount; }
            set { _loginCount = value; }
        }


        private DateTime _lastLoginTime;
        /// <summary>
        /// �û�����¼ʱ��
        /// </summary>
        public DateTime LastLoginTime
        {
            get { return _lastLoginTime; }
            set { _lastLoginTime = value; }
        }



        private string _lastLoginIP;
        /// <summary>
        /// �û�����¼IP
        /// </summary>
        public string LastLoginIP
        {
            get { return _lastLoginIP; }
            set { _lastLoginIP = value; }
        }

    }

}