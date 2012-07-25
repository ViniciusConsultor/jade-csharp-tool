namespace Jade
{
    partial class UrlSettingForm
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
            this.lblUrlInclude = new System.Windows.Forms.Label();
            this.lblUrlExclude = new System.Windows.Forms.Label();
            this.urlSettingBox = new DevExpress.XtraEditors.GroupControl();
            this.simpleButton1 = new DevExpress.XtraEditors.SimpleButton();
            this.simpleButton2 = new DevExpress.XtraEditors.SimpleButton();
            this.simpleButton3 = new DevExpress.XtraEditors.SimpleButton();
            this.simpleButton4 = new DevExpress.XtraEditors.SimpleButton();
            this.tbxUrlExclude = new DevExpress.XtraEditors.TextEdit();
            this.tbxUrlInclude = new DevExpress.XtraEditors.TextEdit();
            ((System.ComponentModel.ISupportInitialize)(this.urlSettingBox)).BeginInit();
            this.urlSettingBox.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.tbxUrlExclude.Properties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.tbxUrlInclude.Properties)).BeginInit();
            this.SuspendLayout();
            // 
            // lblUrlInclude
            // 
            this.lblUrlInclude.AutoSize = true;
            this.lblUrlInclude.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.lblUrlInclude.Location = new System.Drawing.Point(18, 33);
            this.lblUrlInclude.Name = "lblUrlInclude";
            this.lblUrlInclude.Size = new System.Drawing.Size(58, 13);
            this.lblUrlInclude.TabIndex = 88;
            this.lblUrlInclude.Text = "必须包含:";
            // 
            // lblUrlExclude
            // 
            this.lblUrlExclude.AutoSize = true;
            this.lblUrlExclude.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.lblUrlExclude.Location = new System.Drawing.Point(18, 67);
            this.lblUrlExclude.Name = "lblUrlExclude";
            this.lblUrlExclude.Size = new System.Drawing.Size(58, 13);
            this.lblUrlExclude.TabIndex = 89;
            this.lblUrlExclude.Text = "不得包含:";
            // 
            // urlSettingBox
            // 
            this.urlSettingBox.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom)
                        | System.Windows.Forms.AnchorStyles.Left)
                        | System.Windows.Forms.AnchorStyles.Right)));
            this.urlSettingBox.Controls.Add(this.tbxUrlInclude);
            this.urlSettingBox.Controls.Add(this.tbxUrlExclude);
            this.urlSettingBox.Controls.Add(this.simpleButton2);
            this.urlSettingBox.Controls.Add(this.simpleButton1);
            this.urlSettingBox.Controls.Add(this.lblUrlExclude);
            this.urlSettingBox.Controls.Add(this.lblUrlInclude);
            this.urlSettingBox.Location = new System.Drawing.Point(1, 2);
            this.urlSettingBox.Name = "urlSettingBox";
            this.urlSettingBox.Size = new System.Drawing.Size(462, 159);
            this.urlSettingBox.TabIndex = 92;
            this.urlSettingBox.Text = "内容页地址高级设置";
            // 
            // simpleButton1
            // 
            this.simpleButton1.Location = new System.Drawing.Point(286, 232);
            this.simpleButton1.Name = "simpleButton1";
            this.simpleButton1.Size = new System.Drawing.Size(75, 23);
            this.simpleButton1.TabIndex = 92;
            this.simpleButton1.Text = "确定";
            // 
            // simpleButton2
            // 
            this.simpleButton2.Location = new System.Drawing.Point(367, 232);
            this.simpleButton2.Name = "simpleButton2";
            this.simpleButton2.Size = new System.Drawing.Size(75, 23);
            this.simpleButton2.TabIndex = 93;
            this.simpleButton2.Text = "取消";
            // 
            // simpleButton3
            // 
            this.simpleButton3.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)
                        | System.Windows.Forms.AnchorStyles.Right)));
            this.simpleButton3.Location = new System.Drawing.Point(307, 167);
            this.simpleButton3.Name = "simpleButton3";
            this.simpleButton3.Size = new System.Drawing.Size(75, 23);
            this.simpleButton3.TabIndex = 93;
            this.simpleButton3.Text = "确定";
            this.simpleButton3.Click += new System.EventHandler(this.simpleButton3_Click);
            // 
            // simpleButton4
            // 
            this.simpleButton4.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)
                        | System.Windows.Forms.AnchorStyles.Right)));
            this.simpleButton4.Location = new System.Drawing.Point(388, 167);
            this.simpleButton4.Name = "simpleButton4";
            this.simpleButton4.Size = new System.Drawing.Size(75, 23);
            this.simpleButton4.TabIndex = 94;
            this.simpleButton4.Text = "取消";
            this.simpleButton4.Click += new System.EventHandler(this.simpleButton4_Click);
            // 
            // tbxUrlExclude
            // 
            this.tbxUrlExclude.Location = new System.Drawing.Point(88, 67);
            this.tbxUrlExclude.Name = "tbxUrlExclude";
            this.tbxUrlExclude.Size = new System.Drawing.Size(274, 20);
            this.tbxUrlExclude.TabIndex = 94;
            // 
            // tbxUrlInclude
            // 
            this.tbxUrlInclude.Location = new System.Drawing.Point(88, 28);
            this.tbxUrlInclude.Name = "tbxUrlInclude";
            this.tbxUrlInclude.Size = new System.Drawing.Size(274, 20);
            this.tbxUrlInclude.TabIndex = 95;
            // 
            // UrlSettingForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(7F, 14F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(463, 199);
            this.Controls.Add(this.simpleButton4);
            this.Controls.Add(this.simpleButton3);
            this.Controls.Add(this.urlSettingBox);
            this.MaximizeBox = false;
            this.MinimizeBox = false;
            this.Name = "UrlSettingForm";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterParent;
            this.Text = "链接地址高级设置";
            ((System.ComponentModel.ISupportInitialize)(this.urlSettingBox)).EndInit();
            this.urlSettingBox.ResumeLayout(false);
            this.urlSettingBox.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.tbxUrlExclude.Properties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.tbxUrlInclude.Properties)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.Label lblUrlInclude;
        private System.Windows.Forms.Label lblUrlExclude;
        private DevExpress.XtraEditors.GroupControl urlSettingBox;
        private DevExpress.XtraEditors.TextEdit tbxUrlInclude;
        private DevExpress.XtraEditors.TextEdit tbxUrlExclude;
        private DevExpress.XtraEditors.SimpleButton simpleButton2;
        private DevExpress.XtraEditors.SimpleButton simpleButton1;
        private DevExpress.XtraEditors.SimpleButton simpleButton3;
        private DevExpress.XtraEditors.SimpleButton simpleButton4;
    }
}