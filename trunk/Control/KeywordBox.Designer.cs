namespace Jade.Control
{
    partial class KeywordBox
    {
        /// <summary> 
        /// 必需的设计器变量。
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary> 
        /// 清理所有正在使用的资源。
        /// </summary>
        /// <param name="disposing">如果应释放托管资源，为 true；否则为 false。</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region 组件设计器生成的代码

        /// <summary> 
        /// 设计器支持所需的方法 - 不要
        /// 使用代码编辑器修改此方法的内容。
        /// </summary>
        private void InitializeComponent()
        {
            this.txtKeyword = new System.Windows.Forms.ComboBox();
            this.SuspendLayout();
            // 
            // txtKeyword
            // 
            this.txtKeyword.AutoCompleteMode = System.Windows.Forms.AutoCompleteMode.Suggest;
            this.txtKeyword.FormattingEnabled = true;
            this.txtKeyword.Location = new System.Drawing.Point(2, -1);
            this.txtKeyword.Name = "txtKeyword";
            this.txtKeyword.Size = new System.Drawing.Size(193, 20);
            this.txtKeyword.TabIndex = 0;
            this.txtKeyword.KeyDown += new System.Windows.Forms.KeyEventHandler(this.txtKeyword_KeyDown);
            this.txtKeyword.Leave += new System.EventHandler(this.txtKeyword_Leave);
            this.txtKeyword.MouseLeave += new System.EventHandler(this.txtKeyword_MouseLeave);
            // 
            // KeywordBox
            // 
            this.BackColor = System.Drawing.Color.White;
            this.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.Controls.Add(this.txtKeyword);
            this.Name = "KeywordBox";
            this.Size = new System.Drawing.Size(764, 19);
            this.Load += new System.EventHandler(this.KeywordBox_Load);
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.ComboBox txtKeyword;



    }
}
