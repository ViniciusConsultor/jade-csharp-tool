using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Drawing;
using System.Data;
using System.Text;
using System.Windows.Forms;
using DevExpress.XtraEditors;
using DevExpress.XtraEditors.Repository;
using DevExpress.LookAndFeel;
using DevExpress.XtraGrid.Columns;
using Jade.Model;
using Jade.Model.MySql;
namespace Jade
{
    public partial class ContentListPanel : DevExpress.XtraEditors.XtraUserControl
    {
        bool m_checkStatus;
        public ContentListPanel()
        {
            InitializeComponent();
            this.gridView1.Click += new System.EventHandler(this.gridView1_Click);
            this.gridView1.CustomDrawColumnHeader += new DevExpress.XtraGrid.Views.Grid.ColumnHeaderCustomDrawEventHandler(this.gridView1_CustomDrawColumnHeader);
            this.gridView1.DataSourceChanged += new EventHandler(gridView1_DataSourceChanged);

            this.comboBox1.SelectedIndexChanged+=new EventHandler(comboBox1_SelectedIndexChanged);

            var tasks = CacheObject.Rules;
            tasks.Insert(0, new SiteRule() { Name = "全部任务" });
            this.comboBox1.DataSource = tasks;
            this.comboBox1.DisplayMember = "Name";
            this.comboBox1.SelectedIndex = 0;
            this.pager1.PageChange += new EventPagingHandler(pager1_PageChange);
        }
        int currentPageSize = 15;
        void pager1_PageChange(EventPagingArg e)
        {
            var task = (SiteRule)comboBox1.SelectedItem;
            this.gridControl1.DataSource = null;
            int totalCount;
            this.gridControl1.DataSource = CacheObject.DownloadDataDAL.GetList(GetArgs(pager1.CurrentPageIndex, currentPageSize), out totalCount);
        }

        bool isPublished = false;
        public bool IsPublished
        {
            get
            {
                return isPublished;
            }
            set
            {
                isPublished = value;
                comboBox1_SelectedIndexChanged(null, null);
            }
        }

        bool isEdit = false;
        public bool IsEdited
        {
            get
            {
                return isEdit;
            }
            set
            {
                if (isEdit != value)
                {
                    isEdit = value;
                }
                else
                {
                    isEdit = value;
                }
            }
        }

        SearchArgs GetArgs(int pageIndex = 1, int pageSize = 15)
        {
            var taskId = 0;

            if (comboBox1.SelectedItem != null)
            {
                var task = (SiteRule)comboBox1.SelectedItem;
                taskId = task.SiteRuleId;
            }
            return new SearchArgs
            {
                IsPublish = isPublished,
                IsEdit = IsEdited,
                Keyword = this.txtKeyword.Text,
                PageIndex = pageIndex,
                TaskId = taskId,
                PageSzie = pageSize
            };
        }
        private void DraftBoxForm_Load(object sender, EventArgs e)
        {
            CacheObject.ContentForm.InitDownloadData(new downloaddata());
            //this.dataGridView1.Columns[0].HeaderCell = new DataGridViewCheckBoxColumnHeeaderCell();
        }

        private void comboBox1_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (comboBox1.SelectedItem != null)
            {
                var task = (SiteRule)comboBox1.SelectedItem;
                this.gridControl1.DataSource = null;

                int totalCount;

                this.gridControl1.DataSource = CacheObject.DownloadDataDAL.GetList(GetArgs(), out totalCount);

                //if (task.Name == "全部任务")
                //{
                //    this.dataGridView1.DataSource = new HFBBS.Model.DownloadData().GetList((IsPublished ? "IsPublish = True" : "IsPublish = False"), out totalCount, 1, currentPageSize).Tables[0];
                //}
                //else
                //{
                //    this.dataGridView1.DataSource = new HFBBS.Model.DownloadData().GetList((IsPublished ? "IsPublish = True AND " : "IsPublish = False AND ") + "TaskID=" + task.SiteRuleId, out totalCount, 1, currentPageSize).Tables[0];
                //}

                this.pager1.CurrentPageIndex = 1;
                this.pager1.PageSize = currentPageSize;
                this.pager1.TotalCount = totalCount;
                this.pager1.Bind();
                //this.pager1.InitPageInfo(totalCount, currentPageSize);
            }
        }


        private void gridView1_Click(object sender, EventArgs e)
        {
            if (ClickGridCheckBox(this.gridView1, "Check", m_checkStatus))
            {
                m_checkStatus = !m_checkStatus;
            }
        }

        private void gridView1_CustomDrawColumnHeader(object sender, DevExpress.XtraGrid.Views.Grid.ColumnHeaderCustomDrawEventArgs e)
        {
            if (e.Column != null && e.Column.FieldName == "Check")
            {
                e.Info.InnerElements.Clear();
                e.Painter.DrawObject(e.Info);
                DrawCheckBox(e, m_checkStatus);
                e.Handled = true;
            }
        }
        void gridView1_DataSourceChanged(object sender, EventArgs e)
        {
            GridColumn column = this.gridView1.Columns.ColumnByFieldName("Check");
            if (column != null)
            {
                column.Width = 80;
                column.OptionsColumn.ShowCaption = false;
                column.ColumnEdit = new RepositoryItemCheckEdit();
            }
        }
        public static void DrawCheckBox(DevExpress.XtraGrid.Views.Grid.ColumnHeaderCustomDrawEventArgs e, bool chk)
        {
            RepositoryItemCheckEdit repositoryCheck = e.Column.ColumnEdit as RepositoryItemCheckEdit;
            if (repositoryCheck != null)
            {
                Graphics g = e.Graphics;
                Rectangle r = e.Bounds;

                DevExpress.XtraEditors.ViewInfo.CheckEditViewInfo info;
                DevExpress.XtraEditors.Drawing.CheckEditPainter painter;
                DevExpress.XtraEditors.Drawing.ControlGraphicsInfoArgs args;
                info = repositoryCheck.CreateViewInfo() as DevExpress.XtraEditors.ViewInfo.CheckEditViewInfo;

                painter = repositoryCheck.CreatePainter() as DevExpress.XtraEditors.Drawing.CheckEditPainter;
                info.EditValue = chk;
                info.Bounds = r;
                info.CalcViewInfo(g);
                args = new DevExpress.XtraEditors.Drawing.ControlGraphicsInfoArgs(info, new DevExpress.Utils.Drawing.GraphicsCache(g), r);
                painter.Draw(args);
                args.Cache.Dispose();
            }
        }

        public static bool ClickGridCheckBox(DevExpress.XtraGrid.Views.Grid.GridView gridView, string fieldName, bool currentStatus)
        {
            bool result = false;
            if (gridView != null)
            {
                gridView.ClearSorting();//禁止排序

                gridView.PostEditor();
                DevExpress.XtraGrid.Views.Grid.ViewInfo.GridHitInfo info;
                Point pt = gridView.GridControl.PointToClient(System.Windows.Forms.Control.MousePosition);
                info = gridView.CalcHitInfo(pt);
                if (info.InColumn && info.Column != null && info.Column.FieldName == fieldName)
                {
                    for (int i = 0; i < gridView.RowCount; i++)
                    {
                        gridView.SetRowCellValue(i, fieldName, !currentStatus);
                    }
                    return true;
                }
            }
            return result;
        }
    }
}
