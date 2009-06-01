// File:    SystemConfig.cs
// Author:  Administrator
// Created: 2009��5��29�� 12:04:31
// Purpose: Definition of Class SystemConfig

using System;


namespace Myweb.NewsPaper
{


    /// <summary>
    /// ϵͳ������
    /// </summary>

    public class SystemConfig
    {
        public SystemConfig()
        { }

        private string _paperName;
        /// <summary>
        /// �ڿ�����
        /// </summary>
        public string PaperName
        {
            get { return _paperName; }
            set { _paperName = value; }
        }


        private string _siteName;
        /// <summary>
        /// ��վ����
        /// </summary>
        public string SiteName
        {
            get { return _siteName; }
            set { _siteName = value; }
        }


        private string _siteUrl;
        /// <summary>
        /// ��վ��ַ
        /// </summary>
        public string SiteUrl
        {
            get { return _siteUrl; }
            set { _siteUrl = value; }
        }


        private string _paperInfo;
        /// <summary>
        /// �ڿ���Ϣ
        /// </summary>
        public string PaperInfo
        {
            get { return _paperInfo; }
            set { _paperInfo = value; }
        }


        private bool _isOpenRegister;
        /// <summary>
        /// �Ƿ������û�ע��
        /// </summary>
        public bool IsOpenRegister
        {
            get { return _isOpenRegister; }
            set { _isOpenRegister = value; }
        }


        private string _editorName;
        /// <summary>
        /// �༭��������
        /// </summary>
        public string EditorName
        {
            get { return _editorName; }
            set { _editorName = value; }
        }


        private string _editorAddrs;
        /// <summary>
        /// �༭����ַ
        /// </summary>
        public string EditorAddrs
        {
            get { return _editorAddrs; }
            set { _editorAddrs = value; }
        }

        private string _editorPhone;
        /// <summary>
        /// �༭���ĵ绰
        /// </summary>
        public string EditorPhone
        {
            get { return _editorPhone; }
            set { _editorPhone = value; }
        }

        private string _editorFax;
        /// <summary>
        /// �༭������
        /// </summary>
        public string EditorFax
        {
            get { return _editorFax; }
            set { _editorFax = value; }
        }

        private string _editorEmail;
        /// <summary>
        /// �༭�������ʼ�
        /// </summary>
        public string EditorEmail
        {
            get { return _editorEmail; }
            set { _editorEmail = value; }
        }

    }

}