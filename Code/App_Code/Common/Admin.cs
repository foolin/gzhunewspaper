// File:    Admin.cs
// Author:  Foolin
// Created: 2009年6月1日 10:31:09
// Purpose: Definition of Class Admin

using System;
using System.Data;

namespace Myweb.NewsPaper
{

    /// <summary>
    /// 管理员类
    /// </summary>
    public class Admin
    {
        public Admin()
        { }

        public Admin(DataRow row)
        {
            this.AdminID = (int)row["AdminID"];
            this.AdminName = (string)row["AdminName"];
            this.Password = (string)row["Password"];
            this.Power = (int)row["Power"];
            this.LoginCount = (int)row["LoginCount"];
            this.LastLoginTime = (DateTime)row["LastLoginTime"];
            this.LastLoginIP = (string)row["LastLoginIP"];
        }

        private int _adminID;
        /// <summary>
        /// 管理员ID
        /// </summary>
        public int AdminID
        {
            get { return _adminID; }
            set { _adminID = value; }
        }

        private string _adminName;
        /// <summary>
        /// 管理员登录名
        /// </summary>
        public string AdminName
        {
            get { return _adminName; }
            set { _adminName = value; }
        }

        private string _password;
        /// <summary>
        /// 管理员密码
        /// </summary>
        public string Password
        {
            get { return _password; }
            set { _password = value; }
        }


        private int _power;
        /// <summary>
        /// 管理员权限
        /// </summary>
        public int Power
        {
            get { return _power; }
            set { _power = value; }
        }

        private int _loginCount;
        /// <summary>
        /// 登录次数
        /// </summary>
        public int LoginCount
        {
            get { return _loginCount; }
            set { _loginCount = value; }
        }


        private DateTime _lastLoginTime;
        /// <summary>
        /// 最后登录时间
        /// </summary>
        public DateTime LastLoginTime
        {
            get { return _lastLoginTime; }
            set { _lastLoginTime = value; }
        }

        private string _lastLoginIP;
        /// <summary>
        /// 最后登录IP
        /// </summary>
        public string LastLoginIP
        {
            get { return _lastLoginIP; }
            set { _lastLoginIP = value; }
        }


    }
}