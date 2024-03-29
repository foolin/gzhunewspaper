// File:    SystemConfig.cs
// Author:  Administrator
// Created: 2009年5月29日 12:04:31
// Purpose: Definition of Class SystemConfig

using System;
using System.Data;


namespace Myweb.NewsPaper
{


    /// <summary>
    /// 系统配置类
    /// </summary>

    public class SystemConfig
    {
        public SystemConfig()
        { }

        public SystemConfig(DataRow row)
        {
            this.PaperName = (string)row["PaperName"];
            this.SiteName = (string)row["SiteName"];
            this.SiteUrl = (string)row["SiteUrl"];
            this.PaperInfo = (string)row["PaperInfo"];
            this.IsOpenRegister = (bool)row["IsOpenRegister"];
            this.EditorName = (string)row["EditorName"];
            this.EditorAddrs = (string)row["EditorAddrs"];
            this.EditorPhone = (string)row["EditorPhone"];
            this.EditorFax = (string)row["EditorFax"];
            this.EditorEmail = (string)row["EditorEmail"];
            this.EditorPostCode = (string)row["EditorPostCode"];
        }

        private string _paperName;
        /// <summary>
        /// 期刊名称
        /// </summary>
        public string PaperName
        {
            get { return _paperName; }
            set { _paperName = value; }
        }


        private string _siteName;
        /// <summary>
        /// 网站名称
        /// </summary>
        public string SiteName
        {
            get { return _siteName; }
            set { _siteName = value; }
        }


        private string _siteUrl;
        /// <summary>
        /// 网站地址
        /// </summary>
        public string SiteUrl
        {
            get { return _siteUrl; }
            set { _siteUrl = value; }
        }


        private string _paperInfo;
        /// <summary>
        /// 期刊信息
        /// </summary>
        public string PaperInfo
        {
            get { return _paperInfo; }
            set { _paperInfo = value; }
        }


        private bool _isOpenRegister;
        /// <summary>
        /// 是否允许用户注册
        /// </summary>
        public bool IsOpenRegister
        {
            get { return _isOpenRegister; }
            set { _isOpenRegister = value; }
        }


        private string _editorName;
        /// <summary>
        /// 编辑部的名称
        /// </summary>
        public string EditorName
        {
            get { return _editorName; }
            set { _editorName = value; }
        }


        private string _editorAddrs;
        /// <summary>
        /// 编辑部地址
        /// </summary>
        public string EditorAddrs
        {
            get { return _editorAddrs; }
            set { _editorAddrs = value; }
        }

        private string _editorPhone;
        /// <summary>
        /// 编辑部的电话
        /// </summary>
        public string EditorPhone
        {
            get { return _editorPhone; }
            set { _editorPhone = value; }
        }

        private string _editorFax;
        /// <summary>
        /// 编辑部传真
        /// </summary>
        public string EditorFax
        {
            get { return _editorFax; }
            set { _editorFax = value; }
        }

        private string _editorEmail;
        /// <summary>
        /// 编辑部电子邮件
        /// </summary>
        public string EditorEmail
        {
            get { return _editorEmail; }
            set { _editorEmail = value; }
        }

        private string _editorPostCode;
        /// <summary>
        /// 邮编
        /// </summary>
        public string EditorPostCode
        {
            get { return _editorPostCode; }
            set { _editorPostCode = value; }
        }

	

    }

}