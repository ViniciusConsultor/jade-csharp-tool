using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Drawing;
using System.Data;
using System.Text;
using System.Linq;
using System.Windows.Forms;
using DevExpress.XtraEditors;
using DevExpress.XtraEditors.Repository;
using DevExpress.LookAndFeel;
using DevExpress.XtraGrid.Columns;
using Jade.Model;
using Jade.Model.MySql;
using DevExpress.XtraGrid.Views.Grid;
namespace Jade
{
    public partial class ContentListPanel : DevExpress.XtraEditors.XtraUserControl
    {
        bool m_checkStatus;

        List<SiteRule> tasks;
        public ContentListPanel()
        {
            InitializeComponent();
            gridView1.OptionsSelection.MultiSelect = true;
            //gridView1.MouseDown += new MouseEventHandler(gridView1_MouseDown);
            //gridView1.OptionsBehavior.Editable=false;
            gridView1.OptionsSelection.MultiSelectMode = DevExpress.XtraGrid.Views.Grid.GridMultiSelectMode.RowSelect;
            gridView1.DoubleClick += new EventHandler(gridView1_DoubleClick);
            //this.gridView1.RowCellClick += new RowCellClickEventHandler(gridView1_RowCellClick);
            this.gridView1.Click += new System.EventHandler(this.gridView1_Click);
            this.gridView1.CustomDrawColumnHeader += new DevExpress.XtraGrid.Views.Grid.ColumnHeaderCustomDrawEventHandler(this.gridView1_CustomDrawColumnHeader);
            this.gridView1.DataSourceChanged += new EventHandler(gridView1_DataSourceChanged);
            this.gridView1.StartSorting += new EventHandler(gridView1_StartSorting);
            this.comboBoxEdit1.TextChanged += new EventHandler(comboBox1_SelectedIndexChanged);
            tasks = CacheObject.Rules.OrderByDescending(t => t.CreateTime).ToList();
            tasks.Insert(0, new SiteRule() { Name = "全部任务" });
            this.comboBoxEdit1.Properties.DataSource = tasks;
            this.comboBoxEdit1.Properties.DisplayMember = "Name";
            this.comboBoxEdit1.EditValue = "全部任务";
            this.comboBoxEdit1.ItemIndex = 0;
            this.devPager1.PageChange += new EventPagingHandler(pager1_PageChange);
            CacheObject.ContentForm.InitDownloadData(new downloaddata());
            currentPageSize = Properties.Settings.Default.PageSize;
        }

        void gridView1_StartSorting(object sender, EventArgs e)
        {
           
        }

        void gridView1_MouseDown(object sender, MouseEventArgs e)
        {
            //DevExpress.XtraGrid.Views.Grid.ViewInfo.GridHitInfo hInfo = gridView1.CalcHitInfo(new Point(e.X, e.Y));
            //if (e.Button == MouseButtons.Left && e.Clicks == 2)
            //{
            //    //判断光标是否在行范围内  
            //    if (hInfo.InRow)
            //    {
            //        //取得选定行信息  
            //        string nodeName = gridView1.GetRowCellValue(gridView1.FocusedRowHandle, "nodeName").ToString();

            //    }
            //}  
        }

        void gridView1_DoubleClick(object sender, EventArgs e)
        {
            DevExpress.XtraGrid.Views.Grid.ViewInfo.GridHitInfo info;
            Point pt = gridView1.GridControl.PointToClient(System.Windows.Forms.Control.MousePosition);
            info = gridView1.CalcHitInfo(pt);
            if (info.InRowCell)
            {
                rowIndex = info.RowHandle;
                var dataTable = (List<IDownloadData>)this.gridView1.DataSource;
                CacheObject.ContentForm.InitDownloadData(dataTable[rowIndex]);
                if (CacheObject.ContentForm.ShowDialog() == DialogResult.OK)
                {
                    int totalCount;
                    this.gridControl1.DataSource = CacheObject.DownloadDataDAL.GetList(GetArgs(this.devPager1.CurrentPageIndex), out totalCount);
                }
            }
        }


        int currentPageSize = 15;
        void pager1_PageChange(EventPagingArg e)
        {
            var task = tasks[comboBoxEdit1.ItemIndex];
            this.gridControl1.DataSource = null;
            int totalCount;
            this.gridControl1.DataSource = CacheObject.DownloadDataDAL.GetList(GetArgs(devPager1.CurrentPageIndex, currentPageSize), out totalCount);
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

            //if (comboBox1.SelectedItem != null)
            //{
            //    var task = (SiteRule)comboBox1.SelectedItem;
            //    taskId = task.SiteRuleId;
            //}

            taskId = tasks[comboBoxEdit1.ItemIndex].SiteRuleId;

            return new SearchArgs
            {
                IsPublish = isPublished,
                IsEdit = IsEdited,
                Keyword = this.txtKeyword.Text,
                PageIndex = pageIndex,
                TaskId = taskId,
                EditorName = this.chkOnlyMyContent.Checked ? CacheObject.CurrentUser.Name : "",
                PageSzie = Properties.Settings.Default.PageSize
            };
        }
        private void DraftBoxForm_Load(object sender, EventArgs e)
        {
            CacheObject.ContentForm.InitDownloadData(new downloaddata());
            //this.dataGridView1.Columns[0].HeaderCell = new DataGridViewCheckBoxColumnHeeaderCell();
        }

        private void comboBox1_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (comboBoxEdit1.ItemIndex == -1)
            {
                comboBoxEdit1.ItemIndex = 0;
            }

            if (comboBoxEdit1.ItemIndex > -1)
            {
                var task = tasks[comboBoxEdit1.ItemIndex];
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

                this.devPager1.CurrentPageIndex = 1;
                this.devPager1.PageSize = currentPageSize;
                this.devPager1.TotalCount = totalCount;
                this.devPager1.Bind();
                //this.pager1.InitPageInfo(totalCount, currentPageSize);
            }
        }


        private void gridView1_Click(object sender, EventArgs e)
        {
            if (ClickGridCheckBox(this.gridView1, "IsChecked", m_checkStatus))
            {
                m_checkStatus = !m_checkStatus;
            }

            OpenLink(this.gridView1, "Url");
        }

        /// <summary>
        /// 绘制表头
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void gridView1_CustomDrawColumnHeader(object sender, DevExpress.XtraGrid.Views.Grid.ColumnHeaderCustomDrawEventArgs e)
        {
            if (e.Column != null && e.Column.FieldName == "IsChecked")
            {
                e.Info.InnerElements.Clear();
                e.Painter.DrawObject(e.Info);
                DrawCheckBox(e, m_checkStatus);
                e.Handled = true;
            }
        }

        /// <summary>
        /// 绘制单元格
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        void gridView1_DataSourceChanged(object sender, EventArgs e)
        {
            GridColumn column = this.gridView1.Columns.ColumnByFieldName("IsChecked");
            if (column != null)
            {
                column.Width = 30;
                column.OptionsColumn.ShowCaption = false;
                var c = new RepositoryItemCheckEdit();
                c.CheckedChanged += new EventHandler(c_CheckedChanged);
                column.ColumnEdit = c;
            }
        }

        void c_CheckedChanged(object sender, EventArgs e)
        {
            DevExpress.XtraGrid.Views.Grid.ViewInfo.GridHitInfo info;
            Point pt = gridView1.GridControl.PointToClient(System.Windows.Forms.Control.MousePosition);
            info = gridView1.CalcHitInfo(pt);
            if (info.InRowCell)
            {
                rowIndex = info.RowHandle;
                var dataTable = (List<IDownloadData>)this.gridView1.DataSource;
                gridView1.SetRowCellValue(rowIndex, "IsChecked", !dataTable[rowIndex].IsChecked);
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

        public void OpenLink(DevExpress.XtraGrid.Views.Grid.GridView gridView, string fieldName = "Url")
        {
            if (gridView != null)
            {
                gridView.ClearSorting();//禁止排序

                gridView.PostEditor();
                DevExpress.XtraGrid.Views.Grid.ViewInfo.GridHitInfo info;
                Point pt = gridView.GridControl.PointToClient(System.Windows.Forms.Control.MousePosition);
                info = gridView.CalcHitInfo(pt);
                if (info.InRowCell && info.Column != null && info.Column.FieldName == fieldName)
                {
                    var rowIndex = info.RowHandle;
                    var dataTable = (List<IDownloadData>)this.gridView1.DataSource;
                    var url = dataTable[rowIndex].Url;
                    CacheObject.MainForm.OpenNewUrl(url);
                }
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

        private void comboBox1_SelectedIndexChanged_1(object sender, EventArgs e)
        {
            comboBox1_SelectedIndexChanged(sender, e);
        }

        private void txtKeyword_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Enter)
            {
                comboBox1_SelectedIndexChanged(sender, e);
            }
        }

        private void toolStripButton2_Click(object sender, EventArgs e)
        {
            var rowIndexes = GetSelectedRows();

            // = this.dataGridView1.GetCheckedIndexes(0);
            if (rowIndexes.Count == 0)
            {
                MessageBox.Show("请至少选中一行");
            }
            else
            {
                // todo Send
                var dataTable = (List<IDownloadData>)this.gridView1.DataSource;
                foreach (var data in rowIndexes)
                {
                    //var data = dataTable[index];
                    data.IsPublish = true;
                    data.EditTime = DateTime.Now;

                    if (data.label_base == "")
                    {
                        data.label_base = Properties.Settings.Default.DefaultTag;
                    }

                    if (data.news_source_name == "")
                    {
                        data.news_source_name = Properties.Settings.Default.DefaultSource;
                    }

                    if (data.news_template_file == "")
                    {
                        data.news_source_name = Properties.Settings.Default.DefaultTemplate;
                    }

                    RemoteAPI.Publish(data);
                    CacheObject.DownloadDataDAL.Update(data);
                }
                comboBox1_SelectedIndexChanged(null, null);

                MessageBox.Show("发布成功！");
            }
        }

        private List<IDownloadData> GetSelectedRows()
        {
            //var rowIndexes = new List<int>();
            var dataTable = (List<IDownloadData>)this.gridView1.DataSource;
            return dataTable.FindAll(d => d.IsChecked);

            //var rowIndexes = new List<int>();
            //for (int rowIndex = 0; rowIndex < this.gridView1.RowCount; rowIndex++)
            //{
            //    object objValue = this.gridView1.GetRowCellValue(rowIndex, "IsChecked");
            //    if (objValue != null)
            //    {
            //        bool check = false;
            //        bool.TryParse(objValue.ToString(), out check);
            //        if (check)
            //        {
            //            rowIndexes.Add(rowIndex);
            //        }
            //    }
            //}
            //return rowIndexes;
        }

        private void toolStripButton1_Click(object sender, EventArgs e)
        {

            var rowIndexes = GetSelectedRows();
            if (rowIndexes.Count == 0)
            {
                MessageBox.Show("请至少选中一行");
            }
            else
            {
                // todo Send
                var dataTable = (List<IDownloadData>)this.gridView1.DataSource;
                foreach (var index in rowIndexes)
                {
                    // data = dataTable[index];
                    CacheObject.DownloadDataDAL.Delete(index);
                }
                comboBox1_SelectedIndexChanged(null, null);

                MessageBox.Show("删除成功！");
            }
        }

        int rowIndex = -1;
        void gridView1_RowCellClick(object sender, RowCellClickEventArgs e)
        {
            rowIndex = e.RowHandle;
        }

        private void barButtonItem1_ItemClick(object sender, DevExpress.XtraBars.ItemClickEventArgs e)
        {
            toolStripButton1_Click(null, null);
        }

        private void barButtonItem2_ItemClick(object sender, DevExpress.XtraBars.ItemClickEventArgs e)
        {
            if (CacheObject.IsLognIn)
                toolStripButton2_Click(null, null);
            else
                MessageBox.Show("对不起，你还没有登录，不能往服务器发送内容");
        }

        private void chkOnlyMyContent_CheckedChanged(object sender, EventArgs e)
        {
            comboBox1_SelectedIndexChanged(null, null);
        }

        private void barButtonItem3_ItemClick(object sender, DevExpress.XtraBars.ItemClickEventArgs e)
        {
            if (MessageBox.Show(this,
                   "您确定要删除所有数据？",
                   "清空采集数据",
                   MessageBoxButtons.YesNo,
                   MessageBoxIcon.Question,
                   MessageBoxDefaultButton.Button2) == DialogResult.Yes)
            {
                CacheObject.DownloadDataDAL.DeleteAll(); 
                comboBox1_SelectedIndexChanged(null, null);
            }
          
        }

        private void barButtonItem4_ItemClick(object sender, DevExpress.XtraBars.ItemClickEventArgs e)
        {
            SaveFileDialog dialog = new SaveFileDialog();
            if (dialog.ShowDialog() == DialogResult.OK)
            {
                System.IO.StreamWriter sw = new System.IO.StreamWriter(dialog.FileName, false, Encoding.GetEncoding("gb2312"), 10240);
                var datas = CacheObject.DownloadDataDAL.GetAll();
                foreach (var data in datas)
                {
                    sw.WriteLine(data.Title);
                    sw.WriteLine(data.Content);
                }
                sw.Close();
                MessageBox.Show("导出成功");
            }
        }
    }
}
