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
using DevExpress.XtraGrid.Views.Grid;
using System.Text.RegularExpressions;
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
            this.gridView1.CustomColumnDisplayText += new DevExpress.XtraGrid.Views.Base.CustomColumnDisplayTextEventHandler(gridView1_CustomColumnDisplayText);
            this.comboBoxEdit1.TextChanged += new EventHandler(comboBox1_SelectedIndexChanged);
            tasks = CacheObject.Rules.OrderByDescending(t => t.CreateTime).ToList();
            tasks.Insert(0, new SiteRule() { Name = "全部任务" });
            this.comboBoxEdit1.Properties.DataSource = tasks;
            this.comboBoxEdit1.Properties.DisplayMember = "Name";
            this.comboBoxEdit1.EditValue = "全部任务";
            this.comboBoxEdit1.ItemIndex = 0;
            this.devPager1.PageChange += new EventPagingHandler(pager1_PageChange);
            CacheObject.ContentForm.InitDownloadData(new Jade.Model.Access.DownloadData());
            currentPageSize = Properties.Settings.Default.PageSize;

            var tags = CacheObject.GetTaskTags();
            tags.Insert(0, "全部");
            this.cmbTags.DataSource = tags;
        }
        public string HtmToTxt(string input)
        {
            var isImage = input.Contains("<img");
            input = new Regex(@"(?m)<script[^>]*>(\w|\W)*?</script[^>]*>", RegexOptions.Multiline | RegexOptions.IgnoreCase).Replace(input, "");
            input = new Regex(@"(?m)<style[^>]*>(\w|\W)*?</style[^>]*>", RegexOptions.Multiline | RegexOptions.IgnoreCase).Replace(input, "");
            input = new Regex(@"(?m)<select[^>]*>(\w|\W)*?</select[^>]*>", RegexOptions.Multiline | RegexOptions.IgnoreCase).Replace(input, "");
            //input = new Regex(@"(?m)<a[^>]*>(\w|\W)*?</a[^>]*>", RegexOptions.Multiline | RegexOptions.IgnoreCase).Replace(input, "");
            Regex objReg = new System.Text.RegularExpressions.Regex("(<[^>]+?>)| ", RegexOptions.Multiline | RegexOptions.IgnoreCase);
            input = objReg.Replace(input, "");
            Regex objReg2 = new System.Text.RegularExpressions.Regex("(\\s)+", RegexOptions.Multiline | RegexOptions.IgnoreCase);
            input = objReg2.Replace(input, " ");
            return isImage ? "(带图片)" + input.Replace("&nbsp;", " ") : input.Replace("&nbsp;", " ");
        }

        void gridView1_CustomColumnDisplayText(object sender, DevExpress.XtraGrid.Views.Base.CustomColumnDisplayTextEventArgs e)
        {
            try
            {
                if (e.Column.Equals(Content))
                {
                    var dataTable = (List<IDownloadData>)this.gridView1.DataSource;
                    var data = dataTable[e.RowHandle];
                    e.DisplayText = HtmToTxt(data.Content);
                }
                if (e.Column.Equals(SiteRuleName))
                {
                    var dataTable = (List<IDownloadData>)this.gridView1.DataSource;
                    var data = dataTable[e.RowHandle];
                    e.DisplayText = CacheObject.Rules.SingleOrDefault(c => c.SiteRuleId == data.TaskId).Name;
                }
                else if (e.Column.Equals(Category))
                {
                    var dataTable = (List<IDownloadData>)this.gridView1.DataSource;
                    var data = dataTable[e.RowHandle];
                    e.DisplayText = CacheObject.Rules.SingleOrDefault(c => c.SiteRuleId == data.TaskId).Tags;
                }
                else if (e.Column.Equals(GroupName))
                {
                    var dataTable = (List<IDownloadData>)this.gridView1.DataSource;
                    var data = dataTable[e.RowHandle];
                    var category = CacheObject.Categories.SingleOrDefault(c => c.ID == CacheObject.Rules.SingleOrDefault(r => r.SiteRuleId == data.TaskId).CategoryID);
                    e.DisplayText = category.Name;
                }
                else if (e.Column.Equals(EndTime))
                {
                    var dataTable = (List<IDownloadData>)this.gridView1.DataSource;
                    var data = dataTable[e.RowHandle];
                    if (data.EditTime < new DateTime(2012, 1, 1, 0, 0, 0, 0))
                        e.DisplayText = "----";
                    else
                        e.DisplayText = ((DateTime)data.EditTime).ToString("yyyy-MM-dd HH:mm:ss");
                }
            }
            catch (Exception ex)
            {
                Log4Log.Exception(ex);
            }
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
            try
            {
                DevExpress.XtraGrid.Views.Grid.ViewInfo.GridHitInfo info;
                Point pt = gridView1.GridControl.PointToClient(System.Windows.Forms.Control.MousePosition);
                info = gridView1.CalcHitInfo(pt);
                if (info.InRowCell)
                {
                    rowIndex = info.RowHandle;
                    var dataTable = (List<IDownloadData>)this.gridView1.DataSource;
                    var data = dataTable[rowIndex];
                    data = CacheObject.DownloadDataDAL.Get(data.ID);
                    if (!string.IsNullOrEmpty(data.EditorUserName) && data.EditorUserName != CacheObject.CurrentUser.Name)
                    {
                        MessageBox.Show("该新闻已被被人占有，你不能再编辑!");
                        return;
                    }

                    if (Jade.Properties.Settings.Default.IsOnline && data.EditorUserName != CacheObject.CurrentUser.Name)
                    {
                        if (MessageBox.Show("是否占有该新闻，以防止别人同时修改?", "系统提示", MessageBoxButtons.YesNo) == DialogResult.Yes)
                        {
                            try
                            {
                                data.EditorUserName = CacheObject.CurrentUser.Name;
                                data.EditTime = DateTime.Now;
                                data.IsEdit = true;
                                CacheObject.DownloadDataDAL.Update(data);
                                comboBox1_SelectedIndexChanged(null, null);
                            }
                            catch (Exception ze)
                            {
                                MessageBox.Show("占有失败");
                                Log4Log.Exception(ze);
                            }
                        }
                    }

                    CacheObject.ContentForm.InitDownloadData(dataTable[rowIndex]);
                    if (CacheObject.ContentForm.ShowDialog() == DialogResult.OK)
                    {
                        int totalCount;
                        this.gridControl1.DataSource = CacheObject.DownloadDataDAL.GetList(GetArgs(this.devPager1.CurrentPageIndex), out totalCount);
                    }
                }
            }
            catch (Exception ex)
            {
                Log4Log.Exception(ex);
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
                TaskIds = this.cmbTags.Text == "全部" ? new List<int>() : CacheObject.GetTaskIDWithTag(this.cmbTags.Text),
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
            try
            {
                CacheObject.ContentForm.InitDownloadData(new Jade.Model.Access.DownloadData());
                //this.dataGridView1.Columns[0].HeaderCell = new DataGridViewCheckBoxColumnHeeaderCell();
            }
            catch
            {
            }
        }

        private void comboBox1_SelectedIndexChanged(object sender, EventArgs e)
        {
            try
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
            catch (Exception ex)
            {
                Log4Log.Exception(ex);
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
            try
            {
                if (e.Column != null && e.Column.FieldName == "IsChecked")
                {
                    e.Info.InnerElements.Clear();
                    e.Painter.DrawObject(e.Info);
                    DrawCheckBox(e, m_checkStatus);
                    e.Handled = true;
                }
            }
            catch (Exception ex)
            {
                Log4Log.Exception(ex);
            }
        }

        /// <summary>
        /// 绘制单元格
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        void gridView1_DataSourceChanged(object sender, EventArgs e)
        {
            try
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
            catch (Exception ex)
            {
                Log4Log.Exception(ex);
            }
        }

        void c_CheckedChanged(object sender, EventArgs e)
        {
            try
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
            catch (Exception ex)
            {
                Log4Log.Exception(ex);
            }
        }

        public static void DrawCheckBox(DevExpress.XtraGrid.Views.Grid.ColumnHeaderCustomDrawEventArgs e, bool chk)
        {
            try
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
            catch (Exception ex)
            {
                Log4Log.Exception(ex);
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
            try
            {

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
            }
            catch (Exception ex)
            {
                Log4Log.Exception(ex);
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
                    data.SubTitle = "";
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
            if (MessageBox.Show(this,
                      "您确定要删除所选新闻？",
                      "清空采集数据",
                      MessageBoxButtons.YesNo,
                      MessageBoxIcon.Question,
                      MessageBoxDefaultButton.Button2) == DialogResult.Yes)
            {
                toolStripButton1_Click(null, null);
            }
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

        private void cmbTags_TextChanged(object sender, EventArgs e)
        {
            comboBox1_SelectedIndexChanged(sender, e);
        }

        private void cmbTags_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Enter)
            {
                cmbTags_TextChanged(null, null);
            }
        }

        private void btnSearch_Click(object sender, EventArgs e)
        {
            cmbTags_TextChanged(null, null);
        }

        private void barButtonItem5_ItemClick(object sender, DevExpress.XtraBars.ItemClickEventArgs e)
        {
            if (MessageBox.Show(this,
                        "您确定要占有所选新闻？",
                        "抢占新闻",
                        MessageBoxButtons.YesNo,
                        MessageBoxIcon.Question,
                        MessageBoxDefaultButton.Button2) == DialogResult.Yes)
            {
                var rowIndexes = GetSelectedRows();
                if (rowIndexes.Count == 0)
                {
                    MessageBox.Show("请至少选中一行");
                }
                else
                {
                    string msg = "";

                    foreach (var edit in rowIndexes)
                    {
                        var data = CacheObject.DownloadDataDAL.Get(edit.ID);
                        if (!string.IsNullOrEmpty(data.EditorUserName) && data.EditorUserName != CacheObject.CurrentUser.Name)
                        {
                            msg += data.Title + (" 已被被人占有，占有失败!\r\n");
                            continue;
                        }

                        // data = dataTable[index];
                        data.EditorUserName = CacheObject.CurrentUser.Name;
                        data.EditTime = DateTime.Now;
                        data.IsEdit = true;
                        CacheObject.DownloadDataDAL.Update(data);
                    }

                    comboBox1_SelectedIndexChanged(null, null);

                    if (msg != "")
                    {
                        MessageBox.Show(msg);
                    }
                    else
                    {
                        MessageBox.Show("占有成功！");
                    }
                }

            }

        }

        private void barButtonItem6_ItemClick(object sender, DevExpress.XtraBars.ItemClickEventArgs e)
        {
            var data = DatabaseFactory.Instance.CreateDownloadData("about:blank;", 1);
            new BLL.DataSaverManager().Add(data);
            CacheObject.ContentForm.InitDownloadData(data);
            if (CacheObject.ContentForm.ShowDialog() == DialogResult.OK)
            {
                int totalCount;
                this.gridControl1.DataSource = CacheObject.DownloadDataDAL.GetList(GetArgs(this.devPager1.CurrentPageIndex), out totalCount);
            }
            else
            {
                CacheObject.DownloadDataDAL.Delete(data);
            }
        }
    }
}
