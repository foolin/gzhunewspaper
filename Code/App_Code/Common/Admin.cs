// File:    Admin.cs
// Author:  Foolin
// Created: 2009��6��1�� 10:31:09
// Purpose: Definition of Class Admin

using System;

namespace Myweb.NewsPaper
{

    /// <summary>
    /// ����Ա��
    /// </summary>
    public class Admin
    {
        public Admin()
        { }

        private int _adminID;
        /// <summary>
        /// ����ԱID
        /// </summary>
        public int AdminID
        {
            get { return _adminID; }
            set { _adminID = value; }
        }

        private string _adminName;
        /// <summary>
        /// ����Ա��¼��
        /// </summary>
        public string AdminName
        {
            get { return _adminName; }
            set { _adminName = value; }
        }


        private int _power;
        /// <summary>
        /// ����ԱȨ��
        /// </summary>
        public int Power
        {
            get { return _power; }
            set { _power = value; }
        }

        private int _loginCount;
        /// <summary>
        /// ��¼����
        /// </summary>
        public int LoginCount
        {
            get { return _loginCount; }
            set { _loginCount = value; }
        }


        private DateTime _lastLoginTime;
        /// <summary>
        /// ����¼ʱ��
        /// </summary>
        public DateTime LastLoginTime
        {
            get { return _lastLoginTime; }
            set { _lastLoginTime = value; }
        }

        private string _lastLoginIP;
        /// <summary>
        /// ����¼IP
        /// </summary>
        public string LastLoginIP
        {
            get { return _lastLoginIP; }
            set { _lastLoginIP = value; }
        }


    }
}