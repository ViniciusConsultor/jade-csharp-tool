namespace Jade
{
    partial class ExceptionForm
    {
        /// <summary>
        /// Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Clean up any resources being used.
        /// </summary>
        /// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows Form Designer generated code

        /// <summary>
        /// Required method for Designer support - do not modify
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            this.groupControl5 = new DevExpress.XtraEditors.GroupControl();
            this.labelControl1 = new DevExpress.XtraEditors.LabelControl();
            this.txtRuleName = new DevExpress.XtraEditors.TextEdit();
            this.labelControl2 = new DevExpress.XtraEditors.LabelControl();
            this.txtReplace = new DevExpress.XtraEditors.MemoEdit();
            this.btnSelectAnotherXpath = new DevExpress.XtraEditors.SimpleButton();
            ((System.ComponentModel.ISupportInitialize)(this.groupControl5)).BeginInit();
            this.groupControl5.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.txtRuleName.Properties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.txtReplace.Properties)).BeginInit();
            this.SuspendLayout();
            // 
            // groupControl5
            // 
            this.groupControl5.Controls.Add(this.btnSelectAnotherXpath);
            this.groupControl5.Controls.Add(this.txtReplace);
            this.groupControl5.Controls.Add(this.labelControl2);
            this.groupControl5.Controls.Add(this.txtRuleName);
            this.groupControl5.Controls.Add(this.labelControl1);
            this.groupControl5.Dock = System.Windows.Forms.DockStyle.Fill;
            this.groupControl5.Location = new System.Drawing.Point(0, 0);
            this.groupControl5.Name = "groupControl5";
            this.groupControl5.Size = new System.Drawing.Size(696, 398);
            this.groupControl5.TabIndex = 28;
            this.groupControl5.Text = "程序出错了";
            // 
            // labelControl1
            // 
            this.labelControl1.Location = new System.Drawing.Point(14, 31);
            this.labelControl1.Name = "labelControl1";
            this.labelControl1.Size = new System.Drawing.Size(60, 14);
            this.labelControl1.TabIndex = 0;
            this.labelControl1.Text = "错误信息：";
            // 
            // txtRuleName
            // 
            this.txtRuleName.Location = new System.Drawing.Point(80, 28);
            this.txtRuleName.Name = "txtRuleName";
            this.txtRuleName.Size = new System.Drawing.Size(604, 20);
            this.txtRuleName.TabIndex = 2;
            // 
            // labelControl2
            // 
            this.labelControl2.Location = new System.Drawing.Point(14, 62);
            this.labelControl2.Name = "labelControl2";
            this.labelControl2.Size = new System.Drawing.Size(60, 14);
            this.labelControl2.TabIndex = 3;
            this.labelControl2.Text = "详细信息：";
            // 
            // txtReplace
            // 
            this.txtReplace.Location = new System.Drawing.Point(80, 60);
            this.txtReplace.Name = "txtReplace";
            this.txtReplace.Size = new System.Drawing.Size(604, 287);
            this.txtReplace.TabIndex = 4;
            // 
            // btnSelectAnotherXpath
            // 
            this.btnSelectAnotherXpath.Location = new System.Drawing.Point(156, 370);
            this.btnSelectAnotherXpath.Name = "btnSelectAnotherXpath";
            this.btnSelectAnotherXpath.Size = new System.Drawing.Size(373, 23);
            this.btnSelectAnotherXpath.TabIndex = 116;
            this.btnSelectAnotherXpath.Text = "拷贝错误信息用qq发送给管理员";
            this.btnSelectAnotherXpath.Click += new System.EventHandler(this.btnSelectAnotherXpath_Click);
            // 
            // ExceptionForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(7F, 14F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(696, 398);
            this.Controls.Add(this.groupControl5);
            this.Name = "ExceptionForm";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "程序出错啦！";
            ((System.ComponentModel.ISupportInitialize)(this.groupControl5)).EndInit();
            this.groupControl5.ResumeLayout(false);
            this.groupControl5.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.txtRuleName.Properties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.txtReplace.Properties)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private DevExpress.XtraEditors.GroupControl groupControl5;
        private DevExpress.XtraEditors.LabelControl labelControl1;
        private DevExpress.XtraEditors.LabelControl labelControl2;
        private DevExpress.XtraEditors.TextEdit txtRuleName;
        private DevExpress.XtraEditors.MemoEdit txtReplace;
        private DevExpress.XtraEditors.SimpleButton btnSelectAnotherXpath;
    }
}