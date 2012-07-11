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
    public partial class CategoryForm : Form
    {
        public Category CurrentCategory;

        public CategoryForm()
        {
            InitializeComponent();
            var dataSource = new List<string>() { "根节点[ID=0]" };
            if (CacheObject.Categories.Count > 0)
            {
                dataSource.AddRange(CacheObject.Categories.Select(c => c.Name + "[ID=" + c.ID + "]").ToList());
            }
            this.comboBox1.DataSource = dataSource;

        }

        public CategoryForm(Category category)
        {
            InitializeComponent();
            CurrentCategory = category;
            var dataSource = new List<string>() { "根节点[ID=0]" };
            if (CacheObject.Categories.Count > 0)
            {
                dataSource.AddRange(CacheObject.Categories.Select(c => c.Name + "[ID=" + c.ID + "]").ToList());
            }
            this.comboBox1.DataSource = dataSource;
            var p = CurrentCategory.GetParentCategory();
            if (p != null)
            {
                this.comboBox1.SelectedText = p.Name + "[ID=" + p.ID + "]";
            }
        }

        private void CategoryForm_Load(object sender, EventArgs e)
        {
            if (CurrentCategory != null)
                this.textBox1.Text = CurrentCategory.Name;
        }

        private void button1_Click(object sender, EventArgs e)
        {
            if (CurrentCategory == null)
            {
                CurrentCategory = new Category();
                CurrentCategory.ID = CacheObject.BLL.GetNextCategoryId();
            }

            if (this.comboBox1.Text != "")
            {
                CurrentCategory.ParentCategoryID = int.Parse(this.comboBox1.Text.Substring(this.comboBox1.Text.IndexOf("=") + 1, this.comboBox1.Text.IndexOf("]") - this.comboBox1.Text.IndexOf("=") - 1));
            }

            CurrentCategory.Name = this.textBox1.Text;
            this.DialogResult = DialogResult.OK;
            this.Close();

        }

        private void button2_Click(object sender, EventArgs e)
        {
            this.DialogResult = DialogResult.Cancel;
            this.Close();
        }
    }
}
