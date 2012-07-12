using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Drawing;
using System.Data;
using System.Data.SqlClient;
using System.Text;
using System.Windows.Forms;

namespace HFBBS
{
    /// <summary>
    /// 申明委托
    /// </summary>
    /// <param name="e"></param>
    /// <returns></returns>
    public delegate void EventPagingHandler(EventPagingArg e);

    /// <summary>
    /// 分页控件呈现
    /// </summary>
    public partial class Pager : UserControl
    {
        public Pager()
        {
            InitializeComponent();
        }

        public event EventPagingHandler PageChange;

        /// <summary>
        /// 每页显示记录数
        /// </summary>
        private int _pageSize = 20;
        /// <summary>
        /// 每页显示记录数
        /// </summary>
        public int PageSize
        {
            get { return _pageSize; }
            set
            {
                _pageSize = value;
                GetPageCount();
            }
        }

        private int _nMax = 0;
        /// <summary>
        /// 总记录数
        /// </summary>
        public int TotalCount
        {
            get { return _nMax; }
            set
            {
                _nMax = value;
                GetPageCount();
            }
        }

        private int _pageCount = 0;
        /// <summary>
        /// 页数=总记录数/每页显示记录数
        /// </summary>
        public int PageCount
        {
            get { return _pageCount; }
            set { _pageCount = value; }
        }

        private int _pageCurrent = 0;
        /// <summary>
        /// 当前页号
        /// </summary>
        public int CurrentPageIndex
        {
            get { return _pageCurrent; }
            set { _pageCurrent = value; }
        }

        public BindingNavigator ToolBar
        {
            get { return this.bindingNavigator; }
        }

        private void GetPageCount()
        {
            if (this.TotalCount > 0)
            {
                this.PageCount = Convert.ToInt32(Math.Ceiling(Convert.ToDouble(this.TotalCount) / Convert.ToDouble(this.PageSize)));
            }
            else
            {
                this.PageCount = 0;
            }
        }

        /// <summary>
        /// 翻页控件数据绑定的方法
        /// </summary>
        public void Bind()
        {

            if (this.CurrentPageIndex > this.PageCount)
            {
                this.CurrentPageIndex = this.PageCount;
            }
            if (this.PageCount == 1)
            {
                this.CurrentPageIndex = 1;
            }
            lblPageCount.Text = this.PageCount.ToString();
            this.bindingNavigatorCountItem.Text = "of " + PageCount;
            this.lblMaxPage.Text = "共" + this.TotalCount.ToString() + "条记录";
            this.bindingNavigatorPositionItem.Text = this.txtCurrentPage.Text = this.CurrentPageIndex.ToString();

            if (this.CurrentPageIndex == 1)
            {
                this.btnPrev.Enabled = false;
                this.btnFirst.Enabled = false;
                this.bindingNavigatorMovePreviousItem.Enabled = false;
                this.bindingNavigatorMoveFirstItem.Enabled = false;
            }
            else
            {
                btnPrev.Enabled = true;
                btnFirst.Enabled = true;
                this.bindingNavigatorMovePreviousItem.Enabled = true;
                this.bindingNavigatorMoveFirstItem.Enabled = true;
            }

            if (this.CurrentPageIndex == this.PageCount)
            {
                this.btnLast.Enabled = false;
                this.btnNext.Enabled = false;
                this.bindingNavigatorMoveNextItem.Enabled = this.bindingNavigatorMoveLastItem.Enabled = false;
            }
            else
            {
                btnLast.Enabled = true;
                btnNext.Enabled = true;
                this.bindingNavigatorMoveNextItem.Enabled = this.bindingNavigatorMoveLastItem.Enabled = true;
            }

            if (this.TotalCount == 0)
            {
                btnNext.Enabled = false;
                btnLast.Enabled = false;
                btnFirst.Enabled = false;
                btnPrev.Enabled = false;
                this.bindingNavigatorMovePreviousItem.Enabled = false;
                this.bindingNavigatorMoveFirstItem.Enabled = false;
                this.bindingNavigatorMoveNextItem.Enabled = this.bindingNavigatorMoveLastItem.Enabled = false;
            }
        }

        void NotifyPageChange()
        {
            if (this.PageChange != null)
            {
                this.PageChange(new EventPagingArg(this.CurrentPageIndex));
            }
            this.Bind();
        }

        private void btnFirst_Click(object sender, EventArgs e)
        {
            CurrentPageIndex = 1;
            this.NotifyPageChange();
        }

        private void btnPrev_Click(object sender, EventArgs e)
        {
            CurrentPageIndex -= 1;
            if (CurrentPageIndex <= 0)
            {
                CurrentPageIndex = 1;
            }
            this.NotifyPageChange();
        }

        private void btnNext_Click(object sender, EventArgs e)
        {
            this.CurrentPageIndex += 1;
            if (CurrentPageIndex > PageCount)
            {
                CurrentPageIndex = PageCount;
            }
            this.NotifyPageChange();
        }

        private void btnLast_Click(object sender, EventArgs e)
        {
            CurrentPageIndex = PageCount;
            this.NotifyPageChange();
        }

        private void btnGo_Click(object sender, EventArgs e)
        {
            if (this.txtCurrentPage.Text != null && txtCurrentPage.Text != "")
            {
                if (Int32.TryParse(txtCurrentPage.Text, out _pageCurrent))
                {
                    this.NotifyPageChange();
                }
                else
                {
                    MessageBox.Show("输入数字格式错误！");
                }
            }
        }

        private void txtCurrentPage_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Enter)
            {
                this.NotifyPageChange();
            }
        }


        internal void InitPageInfo(int pageIndex, int totalCount, int currentPageSize)
        {
            this.CurrentPageIndex = pageIndex;
            this.PageSize = currentPageSize;
            this.TotalCount = totalCount;
            this.Bind();
        }
    }
    /// <summary>
    /// 自定义事件数据基类
    /// </summary>
    public class EventPagingArg : EventArgs
    {
        private int _intPageIndex;

        public EventPagingArg(int PageIndex)
        {
            _intPageIndex = PageIndex;
        }
    }
}
