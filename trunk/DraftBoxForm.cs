using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using Jade.Model;
using Jade.Model.MySql;

namespace Jade
{
    public partial class DraftBoxForm : WeifenLuo.WinFormsUI.Docking.DockContent
    {
        public DraftBoxForm()
        {
            InitializeComponent();
            this.m_RowStyleNormal = new DataGridViewCellStyle();
            this.m_RowStyleNormal.BackColor = Color.LightBlue;
            this.m_RowStyleNormal.SelectionBackColor = Color.LightSteelBlue;
            this.m_RowStyleAlternate = new DataGridViewCellStyle();
            this.m_RowStyleAlternate.BackColor = Color.LightGray;
            this.m_RowStyleAlternate.SelectionBackColor = Color.LightSlateGray;
            this.dataGridView1.AutoGenerateColumns = false;
            var tasks = CacheObject.Rules;
            tasks.Insert(0, new SiteRule() { Name = "全部任务" });
            this.comboBox1.DataSource = tasks;
            this.comboBox1.DisplayMember = "Name";
            this.comboBox1.SelectedIndex = 0;
            this.pager1.PageChange += new EventPagingHandler(pager1_PageChange);

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
                if (isPublished != value)
                {
                    isPublished = value;
                    comboBox1_SelectedIndexChanged(null, null);
                }
                else
                {
                    isPublished = value;
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
                Keyword = this.txtKeyword.Text,
                PageIndex = pageIndex,
                TaskId = taskId,
                PageSzie = pageSize
            };
        }

        void pager1_PageChange(EventPagingArg e)
        {
            var task = (SiteRule)comboBox1.SelectedItem;
            this.dataGridView1.DataSource = null;
            int totalCount;
            this.dataGridView1.DataSource = CacheObject.DownloadDataDAL.GetList(GetArgs(pager1.CurrentPageIndex, currentPageSize), out totalCount);
            //////if (task.Name == "全部任务")
            //////{
            //////    if (IsPublished)
            //////    {
            //////        this.dataGridView1.DataSource = new HFBBS.Model.DownloadData().GetList("IsPublish = True", out totalCount, pager1.CurrentPageIndex, currentPageSize).Tables[0];
            //////    }
            //////    else
            //////    {
            //////        this.dataGridView1.DataSource = new HFBBS.Model.DownloadData().GetList("IsPublish = False", out totalCount, pager1.CurrentPageIndex, currentPageSize).Tables[0];
            //////    }
            //////}
            //////else
            //////{
            //////    this.dataGridView1.DataSource = new HFBBS.Model.DownloadData().GetList((IsPublished ? "IsPublish = True AND " : "IsPublish = False AND ") + "TaskID=" + task.SiteRuleId, out totalCount, pager1.CurrentPageIndex, currentPageSize).Tables[0];
            //////}
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
                this.dataGridView1.DataSource = null;

                int totalCount;

                this.dataGridView1.DataSource = CacheObject.DownloadDataDAL.GetList(GetArgs(), out totalCount);

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

        private void dataGridView1_CellContentDoubleClick(object sender, DataGridViewCellEventArgs e)
        {
            var dataTable = (List<IDownloadData>)this.dataGridView1.DataSource;
            CacheObject.ContentForm.InitDownloadData(dataTable[e.RowIndex]);
            CacheObject.ContentForm.ShowDialog();
        }

        //定义两种行样式
        private DataGridViewCellStyle m_RowStyleNormal;
        private DataGridViewCellStyle m_RowStyleAlternate;

        private void dataGridView1_CellFormatting(object sender, DataGridViewCellFormattingEventArgs e)
        {
            //DataGridViewRow CurrentRow = this.dataGridView1.Rows[e.RowIndex];

        }

        int currentPageSize = 15;

        private void pager1_PageChanged(object sender, EventArgs e)
        {
            //var task = (SiteRule)comboBox1.SelectedItem;
            //this.dataGridView1.DataSource = null;
            //int totalCount;
            //if (task.Name == "全部任务")
            //{
            //    this.dataGridView1.DataSource = new HFBBS.Model.DownloadData().GetList("", out totalCount, pager1.CurrentPageIndex, currentPageSize).Tables[0];
            //}
            //else
            //{
            //    this.dataGridView1.DataSource = new HFBBS.Model.DownloadData().GetList("TaskID=" + task.SiteRuleId, out totalCount, pager1.CurrentPageIndex, currentPageSize).Tables[0];
            //}
            //this.pager1.InitPageInfo(totalCount, currentPageSize);
        }

        private void 编辑ToolStripMenuItem_Click(object sender, EventArgs e)
        {
            var dataTable = (List<IDownloadData>)this.dataGridView1.DataSource;
            CacheObject.ContentForm.InitDownloadData(dataTable[dataGridView1.CurrentRow.Index]);
            CacheObject.ContentForm.ShowDialog();
        }

        private void dataGridView1_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {

        }

        private void dataGridView1_RowsAdded(object sender, DataGridViewRowsAddedEventArgs e)
        {

        }

        private void dataGridView1_DataBindingComplete(object sender, DataGridViewBindingCompleteEventArgs e)
        {
            if (dataGridView1.RowCount > 0)
            {
                var dataTable = (List<IDownloadData>)this.dataGridView1.DataSource;

                if (dataTable == null || dataTable.Count == 0)
                {
                    return;
                }
                for (var i = 0; i < dataTable.Count; i++)
                {
                    DataGridViewRow CurrentRow = this.dataGridView1.Rows[i];
                    var data = dataTable[CurrentRow.Index];
                    CurrentRow.Cells[2].Value = data.IsPublish ? Properties.Resources.yes : Properties.Resources.no;
                    CurrentRow.Cells[3].Value = data.IsEdit ? Properties.Resources.yes : Properties.Resources.no;
                    //以下为根据上一行内容判断所属组的效果
                    if (i % 2 == 0)//首行必须特殊处理，将其设置为常规样式
                    {
                        CurrentRow.DefaultCellStyle = this.m_RowStyleNormal;
                    }
                    else
                    {
                        CurrentRow.DefaultCellStyle = this.m_RowStyleAlternate;
                    }
                    CurrentRow.HeaderCell.Value = Convert.ToString(i + 1);//显示行号，也可以设置成显示其他信息
                    CurrentRow.HeaderCell.ToolTipText = "当前第" + Convert.ToString(i + 1) + "行";//设置ToolTip信息
                }
            }
        }

        private void toolStripButton1_Click(object sender, EventArgs e)
        {

            var rowIndexes = this.dataGridView1.GetCheckedIndexes(0);
            if (rowIndexes.Count == 0)
            {
                MessageBox.Show("请至少选中一行");
            }
            else
            {
                // todo Send
                var dataTable = (List<IDownloadData>)this.dataGridView1.DataSource;
                foreach (var index in rowIndexes)
                {
                    var data = dataTable[index];
                    CacheObject.DownloadDataDAL.Delete(data);
                }
                comboBox1_SelectedIndexChanged(null, null);

                MessageBox.Show("删除成功！");
            }
        }

        private void toolStripButton2_Click(object sender, EventArgs e)
        {
            var rowIndexes = this.dataGridView1.GetCheckedIndexes(0);
            if (rowIndexes.Count == 0)
            {
                MessageBox.Show("请至少选中一行");
            }
            else
            {
                // todo Send
                var dataTable = (List<IDownloadData>)this.dataGridView1.DataSource;
                foreach (var index in rowIndexes)
                {
                    var data = dataTable[index];
                    data.IsPublish = true;
                    data.EditTime = DateTime.Now;
                    CacheObject.DownloadDataDAL.Update(data);
                }
                comboBox1_SelectedIndexChanged(null, null);

                MessageBox.Show("发布成功！");
            }
        }

    }
}
