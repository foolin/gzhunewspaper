using System;
using System.Data;
using System.Configuration;
using System.Web;
using System.Web.Security;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Web.UI.WebControls.WebParts;
using System.Web.UI.HtmlControls;

/// <summary>
/// Pager 的摘要说明
/// </summary>
namespace Studio.Web
{
    public class Pager
    {
        protected int PageSize = 10;   //设置每页显示记录数， 默认为10
        protected int PageCount = 1;   //总页数
        protected int PageIndex = 1;   //当前页
        protected int TotalCount = 0;  //总记录数

        public Pager()
        {
        }

        public Pager(int totalCount)
        {
            this.TotalCount = totalCount;
            SetPageCount();
        }

        public Pager(int totalCount, int pageIndex)
        {
            this.PageIndex = pageIndex;
            this.TotalCount = totalCount;
            SetPageCount();
        }

        public Pager(int totalCount, int pageIndex, int pageSize)
        {
            this.PageIndex = pageIndex;
            this.TotalCount = totalCount;
            if (pageSize > 0)
                this.PageSize = pageSize;
            else
                this.PageSize = 1;
            SetPageCount();
        }

        public void SetPage(int pageIndex, int totalCount)
        {
            this.PageIndex = pageIndex;
            this.TotalCount = totalCount;
            SetPageCount();
        }



        public void SetPageSize(int pageSize)
        {
            this.PageSize = pageSize;
            SetPageCount();
        }

        public int GetPageSize()
        {
            return this.PageSize;
        }

        public void SetPageIndex(int pageIndex)
        {
            this.PageIndex = pageIndex;
            if (this.PageIndex > this.PageCount && this.PageCount != 1)
                this.PageIndex = this.PageCount;
        }

        public int GetPageIndex()
        {
            return this.PageIndex;
        }

        public void SetPageCount()
        {
            this.PageCount = (this.TotalCount % this.PageSize == 0) ? this.TotalCount / this.PageSize : this.TotalCount / this.PageSize + 1;
            if (this.PageCount < 1)
                this.PageCount = 1;
        }

        public int GetPageCount()
        {
            SetPageCount();
            return PageCount;
        }

        public void SetTotalCount(int totalCount)
        {
            this.TotalCount = totalCount;
            SetPageCount();
        }

        public int GetTotalCount()
        {
            return this.TotalCount;
        }





        public int GetPre()
        {
            if (this.PageIndex > 1)
                return this.PageIndex - 1;
            else
                return this.PageIndex;
        }

        public int GetNext()
        {
            if (this.PageIndex < this.PageCount)
                return this.PageIndex + 1;
            else
                return this.PageCount;

        }

        public int GetFirst()
        {
            return 1;
        }


        public int GetLast()
        {
            return this.PageCount;
        }





    }

}
