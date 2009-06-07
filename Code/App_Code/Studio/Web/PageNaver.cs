﻿using System;
using System.Threading;
using System.Globalization;
using System.Web;
using System.Collections;
using System.ComponentModel;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace Studio.Web
{
    /// <summary>
    /// Name:分页控件
    /// Description:实现列表分页浏览控件,提供几种显示样式
    /// </summary>	
    public class PageNaver : Control, INamingContainer
    {
        string _pidKey = "pid";
        int _pagesize = 2;
        int _splits = 1;
        int _pageindex = -1;
        string _urlprefix = String.Empty;
        string _pageLabel = String.Empty;
        int _records = 0;
        int _keyIndex = 1;
        int _styleid = 1;

        public PageNaver()
        {
            //this.PreRender += new EventHandler(PageNaver_PreRender);
            try
            {
                //当同一个页面存在多个PageNaver时，用Context.Items["PageSpliterCount"]区分页面关键字
                if (Context.Items["PageSpliterCount"] == null)
                {
                    Context.Items["PageSpliterCount"] = 1;
                }
                else
                {
                    Context.Items["PageSpliterCount"] = (int)Context.Items["PageSpliterCount"] + 1;
                }
                _keyIndex = (int)Context.Items["PageSpliterCount"];
            }
            catch { }
        }

        protected override void Render(HtmlTextWriter writer)
        {
            if (Context != null)
            {
                RendNavigator(writer);
                if (_keyIndex == 1)
                {
                    writer.Write("<script language='javascript'>function GoToPage(url){document.location.href=url;}</script>");
                }
            }
            else
            {
                writer.Write("AnyP Page Navigator V1.0");
            }
        }

        void RendNavigator(HtmlTextWriter writer)
        {
            switch (this.StyleID)
            {
                case 2: RendStyle2(writer); break;
                default: RendStyle1(writer); break;
            }
        }

        void RendStyle1(HtmlTextWriter writer)
        {
            if (Thread.CurrentThread.CurrentCulture != null && Thread.CurrentThread.CurrentCulture.ToString() == ("en-US"))
            {
                writer.Write("<span class='pagenaver'>{0}</span>", _pageLabel);					//[1/20]
                writer.Write("&nbsp;<span  class='pagenaver'>Page </span>&nbsp;");									//ThexPage
                writer.Write("<SELECT id='" + this.ClientID + "_pageindex' onchange='GoToPage(\"" + UrlPrefix + "\" + this.value)'>");
                for (int i = 1; i <= PageCount; i++)
                {
                    if (i == PageIndex)
                    {
                        writer.Write("<option value='" + i.ToString() + "' selected>" + i.ToString() + "</option>");
                    }
                    else
                    {
                        writer.Write("<option value='" + i.ToString() + "'>" + i.ToString() + "</option>");
                    }
                }
                writer.Write("</select>");

                if (PageIndex > 1)												//Index
                {
                    writer.Write("<a href='" + UrlPrefix + "1' class='pagenaver'>[First]</a>&nbsp;");
                    writer.Write("<a href='" + UrlPrefix + (PageIndex - 1).ToString() + "' class='pagenaver'>[Preview]</a>&nbsp;");
                }
                if (PageIndex < PageCount)										//Last,Next
                {
                    writer.Write("<a href='" + UrlPrefix + (PageIndex + 1).ToString() + "' class='pagenaver'>[Next]</a>&nbsp;");
                    writer.Write("<a href='" + UrlPrefix + PageCount.ToString() + "' class='pagenaver'>[Last]</a>&nbsp;");
                }
            }
            else
            {
                writer.Write("<span class='pagenaver'>{0}</span>", _pageLabel);					//[1/20]
                writer.Write("&nbsp;第&nbsp;");									//第x页
                writer.Write("<SELECT id='" + this.ClientID + "_pageindex' onchange='GoToPage(\"" + UrlPrefix + "\" + this.value)'>");
                for (int i = 1; i <= PageCount; i++)
                {
                    if (i == PageIndex)
                    {
                        writer.Write("<option value='" + i.ToString() + "' selected>" + i.ToString() + "</option>");
                    }
                    else
                    {
                        writer.Write("<option value='" + i.ToString() + "'>" + i.ToString() + "</option>");
                    }
                }
                writer.Write("</select>");
                writer.Write("&nbsp;<span  class='pagenaver'>页</span>&nbsp;");
                if (PageIndex > 1)												//首页,上页
                {
                    writer.Write("<a href='" + UrlPrefix + "1' class='pagenaver'>首页</a>&nbsp;");
                    writer.Write("<a href='" + UrlPrefix + (PageIndex - 1).ToString() + "' class='pagenaver'>上页</a>&nbsp;");
                }
                if (PageIndex < PageCount)										//下页,尾页
                {
                    writer.Write("<a href='" + UrlPrefix + (PageIndex + 1).ToString() + "' class='pagenaver'>下页</a>&nbsp;");
                    writer.Write("<a href='" + UrlPrefix + PageCount.ToString() + "' class='pagenaver'>尾页</a>&nbsp;");
                }
            }
        }

        void RendStyle2(HtmlTextWriter writer)
        {
            if (Thread.CurrentThread.CurrentCulture != null && Thread.CurrentThread.CurrentCulture.ToString() == ("en-US"))
            {
                int begin, end, pages = PageCount;

                writer.Write("<span>");
                writer.Write("&nbsp;<a class='pagenaver' {0}><font face='webdings' class='pagenaver'>9</font></a>", PageIndex > 1 ? String.Format("href='javascript:GoToPage(\"" + UrlPrefix + "\" + {0})' title='Goto {0} Page'", 1) : "disabled");
                writer.Write("&nbsp;<a class='pagenaver' {0}><font face='webdings' class='pagenaver'>3</font></a>", PageIndex > 1 ? String.Format("href='javascript:GoToPage(\"" + UrlPrefix + "\" + {0})' title='Goto {0} Page'", PageIndex - 1) : "disabled");

                if (PageCount > 10)
                {
                    if (PageIndex % 10 == 0)
                    {
                        begin = PageIndex - 9;
                        end = PageIndex;
                    }
                    else
                    {
                        begin = PageIndex / 10 * 10 + 1;
                        end = PageIndex / 10 * 10 + 10;
                    }

                    if (end > PageCount)
                    {
                        end = PageCount;
                    }

                    if (PageIndex > 10)
                    {
                        writer.Write("&nbsp;<a href='javascript:GoToPage(\"" + UrlPrefix + "{0}\")' title='Goto Page {0}' class='pagenaver'>...</a>", (begin - 1).ToString());
                    }
                }
                else
                {
                    begin = 1;
                    end = pages;
                }

                for (int i = begin; i <= end; i++)
                {
                    if (i == PageIndex)
                        writer.Write("&nbsp;<font color='red'><b>{0}</b></font>", i);
                    else
                        writer.Write("&nbsp;<a href='" + UrlPrefix + "{0}' title='Goto Page {0}' class='pagenaver'>{0}</a>", i);
                }

                if (PageCount > end)
                {
                    writer.Write("&nbsp;<a href='" + UrlPrefix + "{0}' title='Goto Page {0}' class='pagenaver'>...</a>", (end + 1).ToString());
                }

                writer.Write("&nbsp;<a {0} class='pagenaver'><font face='webdings'>4</font></a>", PageIndex < pages ? String.Format("href='" + UrlPrefix + "{0}' title='Goto {0} Page'", PageIndex + 1) : "disabled");
                writer.Write("&nbsp;<a {0} class='pagenaver'><font face='webdings'>:</font></a>", PageIndex < pages ? String.Format("href='" + UrlPrefix + "{0}' title='Goto {0} Page'", pages) : "disabled");

                writer.Write("&nbsp;<span><input type='text' value='{0}' style='width:25px'><input type='button' value='Go' onclick='javascript:GoToPage(\"" + UrlPrefix + "\" + this.parentElement.children[0].value);'></span>", PageIndex);
                writer.Write("</span>");
            }
            else
            {
                int begin, end, pages = PageCount;

                writer.Write("<span>");
                writer.Write("&nbsp;<a class='pagenaver' {0}><font face='webdings' class='pagenaver'>9</font></a>", PageIndex > 1 ? String.Format("href='javascript:GoToPage(\"" + UrlPrefix + "\" + {0})' title='转到第{0}页'", 1) : "disabled");
                writer.Write("&nbsp;<a class='pagenaver' {0}><font face='webdings' class='pagenaver'>3</font></a>", PageIndex > 1 ? String.Format("href='javascript:GoToPage(\"" + UrlPrefix + "\" + {0})' title='转到第{0}页'", PageIndex - 1) : "disabled");

                if (PageCount > 10)
                {
                    if (PageIndex % 10 == 0)
                    {
                        begin = PageIndex - 9;
                        end = PageIndex;
                    }
                    else
                    {
                        begin = PageIndex / 10 * 10 + 1;
                        end = PageIndex / 10 * 10 + 10;
                    }

                    if (end > PageCount)
                    {
                        end = PageCount;
                    }

                    if (PageIndex > 10)
                    {
                        writer.Write("&nbsp;<a href='javascript:GoToPage(\"" + UrlPrefix + "{0}\")' title='转到第{0}页' class='pagenaver'>...</a>", (begin - 1).ToString());
                    }
                }
                else
                {
                    begin = 1;
                    end = pages;
                }

                for (int i = begin; i <= end; i++)
                {
                    if (i == PageIndex)
                        writer.Write("&nbsp;<font color='red'><b>{0}</b></font>", i);
                    else
                        writer.Write("&nbsp;<a href='" + UrlPrefix + "{0}' title='转到第{0}页' class='pagenaver'>{0}</a>", i);
                }

                if (PageCount > end)
                {
                    writer.Write("&nbsp;<a href='" + UrlPrefix + "{0}' title='转到第{0}页' class='pagenaver'>...</a>", (end + 1).ToString());
                }

                writer.Write("&nbsp;<a {0} class='pagenaver'><font face='webdings'>4</font></a>", PageIndex < pages ? String.Format("href='" + UrlPrefix + "{0}' title='转到第{0}页'", PageIndex + 1) : "disabled");
                writer.Write("&nbsp;<a {0} class='pagenaver'><font face='webdings'>:</font></a>", PageIndex < pages ? String.Format("href='" + UrlPrefix + "{0}' title='转到第{0}页'", pages) : "disabled");

                writer.Write("&nbsp;<span><input type='text' value='{0}' style='width:25px'><input type='button' value='Go' onclick='javascript:GoToPage(\"" + UrlPrefix + "\" + this.parentElement.children[0].value);'></span>", PageIndex);
                writer.Write("</span>");
            }
        }

        /// <summary>
        /// 分页标记(url参数)
        /// </summary>
        [Description("分页标记(url参数,如\"PageNo\")"), DefaultValue("pid")]
        public string PageIDKey
        {
            get { return _pidKey; }
            set { if (value != null)_pidKey = value; }
        }

        /// <summary>
        /// 每页记录数
        /// </summary>
        [Description("每页记录数"), DefaultValue(20)]
        public int PageSize
        {
            get { return _pagesize; }
            set { if (value > 0 && value <= 50001)_pagesize = value; }
        }

        /// <summary>
        /// 页码分组时每组页码数
        /// </summary>
        [Description("页码分组时每组页码数"), DefaultValue(10)]
        public int SplitSize
        {
            get { return _splits; }
            set { _splits = value; }
        }


        /// <summary>
        /// 样式编号
        /// </summary>
        [Description("样式编号"), DefaultValue(2)]
        public int StyleID
        {
            get
            {
                return _styleid;
            }
            set { _styleid = value; }
        }

        /// <summary>
        /// 当前页编号
        /// </summary>
        [Browsable(false)]
        public int PageIndex
        {
            get
            {
                if (_pageindex == -1)
                {
                    string pageid = Context.Request.QueryString[PageIDKey + _keyIndex.ToString()] + "";
                    if (pageid == "") pageid = "1";
                    if (WebAgent.IsNumeric(pageid))
                        _pageindex = int.Parse(pageid);
                    else
                        _pageindex = 1;
                }
                return _pageindex;
            }
            set { _pageindex = value; }
        }

        /// <summary>
        /// 总页数
        /// </summary>
        [Browsable(false)]
        public int PageCount
        {
            get
            {
                double count = this.Records;
                int pCount = int.Parse(Math.Ceiling(count / this.PageSize).ToString());
                if (pCount == 0 && this.Records > 0) pCount = 1;
                return pCount;
            }
        }

        /// <summary>
        /// 总记录数
        /// </summary>
        [Browsable(false)]
        public int Records
        {
            get
            {
                return _records;
            }
            set { _records = value; }
        }

        /// <summary>
        /// 设置分页
        /// </summary>
        /// <param name="rowcount">记录总数</param>
        public void SetPage(int rowcount)
        {
            this.EnableViewState = this.Visible = rowcount > this.PageSize;
            if (rowcount <= this.PageSize)
            {
                return;
            }
            double count = rowcount;
            this.Records = rowcount;
            if (this.PageIndex > this.PageCount) this.PageIndex = 1;
            this._pageLabel = "[" + this.PageIndex.ToString() + "/" + this.PageCount.ToString() + "]";
        }

        public ArrayList GetCurrentPage(IList dataList)
        {
            int start = (this.PageIndex - 1) * this.PageSize;
            int end = this.PageIndex * this.PageSize - 1;

            if (dataList == null)
            {
                this.Visible = false;
                return null;
            }

            ArrayList list = new ArrayList(this.PageSize);
            for (int i = start; i <= end && i < dataList.Count; i++)
            {
                list.Add(dataList[i]);
            }

            this.SetPage(dataList.Count);
            return list;
        }

        public static IList GetTopN(IList list, int n)
        {
            if (list == null)
                return null;

            ArrayList result = new ArrayList();
            for (int i = 0; i < n && i < list.Count; i++)
                result.Add(list[i]);

            return result;
        }

        public static int GetPageCount(int records, int pageSize)
        {
            double count = records;
            int pCount = int.Parse(Math.Ceiling(count / pageSize).ToString());
            if (pCount == 0 && records > 0) pCount = 1;
            return pCount;
        }

        /// <summary>
        /// URL前缀
        /// </summary>
        private string UrlPrefix
        {
            get
            {
                if (_urlprefix != "") return _urlprefix;

                _urlprefix = GetUrlPrefix(Context.Request.RawUrl.ToLower(), PageIDKey.ToLower() + _keyIndex.ToString());
                return _urlprefix;
            }
        }

        private string GetUrlPrefix(string urlString, string reservedKey)
        {
            string key1 = '?' + reservedKey + '=';
            string key2 = '&' + reservedKey + '=';
            int idx = 0;
            string urlResult = String.Empty;
            if (urlString.IndexOf(key1) > 0)
            {
                idx = urlString.IndexOf('&', urlString.IndexOf(key1) + key1.Length);
                if (idx > 0)
                {
                    urlResult = urlString.Substring(0, urlString.IndexOf(key1)) + '?' + urlString.Substring(idx + 1) + '&' + key1.Substring(1);
                }
                else
                {
                    urlResult = urlString.Substring(0, urlString.IndexOf(key1) + key1.Length);
                }
                return urlResult;
            }
            if (urlString.IndexOf(key2) > 0)
            {
                idx = urlString.IndexOf('&', urlString.IndexOf(key2) + key2.Length);
                if (idx > 0)
                {
                    urlResult = urlString.Substring(0, urlString.IndexOf(key2)) + '&' + urlString.Substring(idx + 1) + key2;
                }
                else
                {
                    urlResult = urlString.Substring(0, urlString.IndexOf(key2) + key2.Length);
                }
                return urlResult;
            }
            if (urlString.IndexOf('?') > 0)
            {
                urlResult = urlString + key2;
            }
            else
            {
                urlResult = urlString + key1;
            }
            return urlResult;
        }
    }
}
