using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Drawing;
using System.Data;
using System.Text;
using System.Windows.Forms;
using DevExpress.XtraEditors;

namespace Jade.Control
{
    public partial class DevPager : DevExpress.XtraEditors.XtraUserControl
    {
        public DevPager()
        {
            InitializeComponent();
        }

        public event EventPagingHandler PageChange;

        /// <summary>
        /// 每页显示记录数
        /// </summary>
        private int _pageSize = 15;

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

            this.repositoryItemTextEdit1.NullText = CurrentPageIndex.ToString();

            var status = "当前第{0}页 / 共{1}页   |  当前显示{3}~{4}条 / 共{2}条";

            this.lblStatus.Caption = string.Format(status, CurrentPageIndex, PageCount, TotalCount, Math.Max(0, (CurrentPageIndex - 1) * PageSize + 1),Math.Min(TotalCount,  CurrentPageIndex * PageSize));

            if (this.CurrentPageIndex == 1)
            {
                this.btnPre.Enabled = false;
                this.btnFirst.Enabled = false;
            }
            else
            {
                btnPre.Enabled = true;
                btnFirst.Enabled = true;
            }

            if (this.CurrentPageIndex == this.PageCount)
            {
                this.btnLast.Enabled = false;
                this.btnNext.Enabled = false;
            }
            else
            {
                btnLast.Enabled = true;
                btnNext.Enabled = true;
            }

            if (this.TotalCount == 0)
            {
                btnNext.Enabled = false;
                btnLast.Enabled = false;
                btnFirst.Enabled = false;
                btnPre.Enabled = false;
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

        private void btnFirst_Click(object sender, DevExpress.XtraBars.ItemClickEventArgs e)
        {
            CurrentPageIndex = 1;
            this.NotifyPageChange();
        }

        private void btnPre_Click(object sender, DevExpress.XtraBars.ItemClickEventArgs e)
        {
            CurrentPageIndex -= 1;
            if (CurrentPageIndex <= 0)
            {
                CurrentPageIndex = 1;
            }
            this.NotifyPageChange();
        }

        private void btnNext_Click(object sender, DevExpress.XtraBars.ItemClickEventArgs e)
        {
            this.CurrentPageIndex += 1;
            if (CurrentPageIndex > PageCount)
            {
                CurrentPageIndex = PageCount;
            }
            this.NotifyPageChange();
        }

        private void btnLast_Click(object sender, DevExpress.XtraBars.ItemClickEventArgs e)
        {
            CurrentPageIndex = PageCount;
            this.NotifyPageChange();
        }

        private void btnGo_Click(object sender, EventArgs e)
        {
            if (this.txtPageNumber.Caption != null && txtPageNumber.Caption != "")
            {
                if (Int32.TryParse(txtPageNumber.Caption, out _pageCurrent))
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

        private void txtPageNumber_ShownEditor(object sender, DevExpress.XtraBars.ItemClickEventArgs e)
        {
        }

        void Edit_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Enter)
            {
                if (int.TryParse((sender as TextEdit).Text, out _pageCurrent))
                {
                    this.NotifyPageChange();
                }
            }
        }

    }
}
