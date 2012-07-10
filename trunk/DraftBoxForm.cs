using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using HFBBS.Model;

namespace HFBBS
{
    public partial class DraftBoxForm : WeifenLuo.WinFormsUI.Docking.DockContent
    {
        public DraftBoxForm()
        {
            InitializeComponent();
            this.m_RowStyleNormal = new DataGridViewCellStyle();
            this.m_RowStyleNormal.BackColor = Color.LightBlue;
            this.m_RowStyleNormal.SelectionBackColor = Color.LightSteelBlue; CacheObject.ContentForm.InitDownloadData(new DownloadData());

            this.m_RowStyleAlternate = new DataGridViewCellStyle();
            this.m_RowStyleAlternate.BackColor = Color.LightGray;
            this.m_RowStyleAlternate.SelectionBackColor = Color.LightSlateGray;
            this.dataGridView1.AutoGenerateColumns = false;
            var tasks = CacheObject.Rules;
            tasks.Insert(0, new SiteRule() { Name = "全部任务" });
            this.comboBox1.DataSource = tasks;
            this.comboBox1.DisplayMember = "Name";
            this.comboBox1.SelectedIndex = 0;

        }

        private void DraftBoxForm_Load(object sender, EventArgs e)
        {

            CacheObject.ContentForm.InitDownloadData(new DownloadData());
        }

        private void comboBox1_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (comboBox1.SelectedItem != null)
            {
                var task = (SiteRule)comboBox1.SelectedItem;
                this.dataGridView1.DataSource = null;
                if (task.Name == "全部任务")
                {
                    this.dataGridView1.DataSource = new HFBBS.Model.DownloadData().GetList("").Tables[0];
                }
                else
                {
                    this.dataGridView1.DataSource = new HFBBS.Model.DownloadData().GetList("TaskID=" + task.SiteRuleId).Tables[0];
                }
            }
        }

        private void dataGridView1_CellContentDoubleClick(object sender, DataGridViewCellEventArgs e)
        { 
            var dataTable = (DataTable)this.dataGridView1.DataSource;
            CacheObject.ContentForm.InitDownloadData(new DownloadData((int)dataTable.Rows[e.RowIndex]["ID"]));
            CacheObject.ContentForm.ShowDialog();
        }

        //定义两种行样式
        private DataGridViewCellStyle m_RowStyleNormal;
        private DataGridViewCellStyle m_RowStyleAlternate;

        private void dataGridView1_CellFormatting(object sender, DataGridViewCellFormattingEventArgs e)
        {
            DataGridViewRow CurrentRow = this.dataGridView1.Rows[e.RowIndex];
            CurrentRow.HeaderCell.Value = Convert.ToString(e.RowIndex + 1);//显示行号，也可以设置成显示其他信息
            CurrentRow.HeaderCell.ToolTipText = "当前第" + Convert.ToString(e.RowIndex + 1) + "行";//设置ToolTip信息

            //以下为根据上一行内容判断所属组的效果
            if (e.RowIndex % 2 == 0)//首行必须特殊处理，将其设置为常规样式
            {
                CurrentRow.DefaultCellStyle = this.m_RowStyleNormal;
            }
            else
            {
                CurrentRow.DefaultCellStyle = this.m_RowStyleAlternate;
            }

        }
    }
}
