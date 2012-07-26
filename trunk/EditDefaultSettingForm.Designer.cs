namespace Jade
{
    partial class EditDefaultSettingForm
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
            this.simpleButton3 = new DevExpress.XtraEditors.SimpleButton();
            this.urlSettingBox = new DevExpress.XtraEditors.GroupControl();
            this.simpleButton2 = new DevExpress.XtraEditors.SimpleButton();
            this.simpleButton1 = new DevExpress.XtraEditors.SimpleButton();
            this.lblUrlExclude = new System.Windows.Forms.Label();
            this.lblUrlInclude = new System.Windows.Forms.Label();
            this.simpleButton4 = new DevExpress.XtraEditors.SimpleButton();
            this.label1 = new System.Windows.Forms.Label();
            this.lookUpEditSource = new DevExpress.XtraEditors.LookUpEdit();
            this.lookUpEditTemplete = new DevExpress.XtraEditors.LookUpEdit();
            this.lookUpEditLabel = new DevExpress.XtraEditors.LookUpEdit();
            ((System.ComponentModel.ISupportInitialize)(this.urlSettingBox)).BeginInit();
            this.urlSettingBox.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.lookUpEditSource.Properties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.lookUpEditTemplete.Properties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.lookUpEditLabel.Properties)).BeginInit();
            this.SuspendLayout();
            // 
            // simpleButton3
            // 
            this.simpleButton3.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
            this.simpleButton3.Location = new System.Drawing.Point(271, 168);
            this.simpleButton3.Name = "simpleButton3";
            this.simpleButton3.Size = new System.Drawing.Size(74, 23);
            this.simpleButton3.TabIndex = 96;
            this.simpleButton3.Text = "确定";
            this.simpleButton3.Click += new System.EventHandler(this.simpleButton3_Click);
            // 
            // urlSettingBox
            // 
            this.urlSettingBox.Controls.Add(this.lookUpEditLabel);
            this.urlSettingBox.Controls.Add(this.lookUpEditTemplete);
            this.urlSettingBox.Controls.Add(this.lookUpEditSource);
            this.urlSettingBox.Controls.Add(this.label1);
            this.urlSettingBox.Controls.Add(this.simpleButton2);
            this.urlSettingBox.Controls.Add(this.simpleButton1);
            this.urlSettingBox.Controls.Add(this.lblUrlExclude);
            this.urlSettingBox.Controls.Add(this.lblUrlInclude);
            this.urlSettingBox.Dock = System.Windows.Forms.DockStyle.Top;
            this.urlSettingBox.Location = new System.Drawing.Point(0, 0);
            this.urlSettingBox.Name = "urlSettingBox";
            this.urlSettingBox.Size = new System.Drawing.Size(439, 159);
            this.urlSettingBox.TabIndex = 95;
            this.urlSettingBox.Text = "内容页地址高级设置";
            // 
            // simpleButton2
            // 
            this.simpleButton2.Location = new System.Drawing.Point(367, 232);
            this.simpleButton2.Name = "simpleButton2";
            this.simpleButton2.Size = new System.Drawing.Size(75, 23);
            this.simpleButton2.TabIndex = 93;
            this.simpleButton2.Text = "取消";
            // 
            // simpleButton1
            // 
            this.simpleButton1.Location = new System.Drawing.Point(286, 232);
            this.simpleButton1.Name = "simpleButton1";
            this.simpleButton1.Size = new System.Drawing.Size(75, 23);
            this.simpleButton1.TabIndex = 92;
            this.simpleButton1.Text = "确定";
            // 
            // lblUrlExclude
            // 
            this.lblUrlExclude.AutoSize = true;
            this.lblUrlExclude.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.lblUrlExclude.Location = new System.Drawing.Point(18, 67);
            this.lblUrlExclude.Name = "lblUrlExclude";
            this.lblUrlExclude.Size = new System.Drawing.Size(82, 13);
            this.lblUrlExclude.TabIndex = 89;
            this.lblUrlExclude.Text = "默认栏目模版:";
            // 
            // lblUrlInclude
            // 
            this.lblUrlInclude.AutoSize = true;
            this.lblUrlInclude.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.lblUrlInclude.Location = new System.Drawing.Point(18, 33);
            this.lblUrlInclude.Name = "lblUrlInclude";
            this.lblUrlInclude.Size = new System.Drawing.Size(58, 13);
            this.lblUrlInclude.TabIndex = 88;
            this.lblUrlInclude.Text = "默认来源:";
            // 
            // simpleButton4
            // 
            this.simpleButton4.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
            this.simpleButton4.Location = new System.Drawing.Point(355, 168);
            this.simpleButton4.Name = "simpleButton4";
            this.simpleButton4.Size = new System.Drawing.Size(72, 23);
            this.simpleButton4.TabIndex = 97;
            this.simpleButton4.Text = "取消";
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.label1.Location = new System.Drawing.Point(18, 101);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(58, 13);
            this.label1.TabIndex = 96;
            this.label1.Text = "默认标签:";
            // 
            // lookUpEditSource
            // 
            this.lookUpEditSource.Location = new System.Drawing.Point(115, 30);
            this.lookUpEditSource.Name = "lookUpEditSource";
            this.lookUpEditSource.Properties.Buttons.AddRange(new DevExpress.XtraEditors.Controls.EditorButton[] {
            new DevExpress.XtraEditors.Controls.EditorButton(DevExpress.XtraEditors.Controls.ButtonPredefines.Combo)});
            this.lookUpEditSource.Properties.Columns.AddRange(new DevExpress.XtraEditors.Controls.LookUpColumnInfo[] {
            new DevExpress.XtraEditors.Controls.LookUpColumnInfo("DisplayName", 40, "说明"),
            new DevExpress.XtraEditors.Controls.LookUpColumnInfo("Value", 40, "值")});
            this.lookUpEditSource.Size = new System.Drawing.Size(271, 20);
            this.lookUpEditSource.TabIndex = 97;
            // 
            // lookUpEditTemplete
            // 
            this.lookUpEditTemplete.Location = new System.Drawing.Point(115, 64);
            this.lookUpEditTemplete.Name = "lookUpEditTemplete";
            this.lookUpEditTemplete.Properties.Buttons.AddRange(new DevExpress.XtraEditors.Controls.EditorButton[] {
            new DevExpress.XtraEditors.Controls.EditorButton(DevExpress.XtraEditors.Controls.ButtonPredefines.Combo)});
            this.lookUpEditTemplete.Properties.Columns.AddRange(new DevExpress.XtraEditors.Controls.LookUpColumnInfo[] {
            new DevExpress.XtraEditors.Controls.LookUpColumnInfo("DisplayName", "DisplayName"),
            new DevExpress.XtraEditors.Controls.LookUpColumnInfo("Value", "Value")});
            this.lookUpEditTemplete.Size = new System.Drawing.Size(271, 20);
            this.lookUpEditTemplete.TabIndex = 98;
            // 
            // lookUpEditLabel
            // 
            this.lookUpEditLabel.Location = new System.Drawing.Point(115, 98);
            this.lookUpEditLabel.Name = "lookUpEditLabel";
            this.lookUpEditLabel.Properties.Buttons.AddRange(new DevExpress.XtraEditors.Controls.EditorButton[] {
            new DevExpress.XtraEditors.Controls.EditorButton(DevExpress.XtraEditors.Controls.ButtonPredefines.Combo)});
            this.lookUpEditLabel.Properties.Columns.AddRange(new DevExpress.XtraEditors.Controls.LookUpColumnInfo[] {
            new DevExpress.XtraEditors.Controls.LookUpColumnInfo("DisplayName", "DisplayName"),
            new DevExpress.XtraEditors.Controls.LookUpColumnInfo("Value", "Value")});
            this.lookUpEditLabel.Size = new System.Drawing.Size(271, 20);
            this.lookUpEditLabel.TabIndex = 99;
            // 
            // EditDefaultSettingForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(7F, 14F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(439, 192);
            this.Controls.Add(this.simpleButton3);
            this.Controls.Add(this.urlSettingBox);
            this.Controls.Add(this.simpleButton4);
            this.Name = "EditDefaultSettingForm";
            this.Text = "EditDefaultSettingForm";
            ((System.ComponentModel.ISupportInitialize)(this.urlSettingBox)).EndInit();
            this.urlSettingBox.ResumeLayout(false);
            this.urlSettingBox.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.lookUpEditSource.Properties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.lookUpEditTemplete.Properties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.lookUpEditLabel.Properties)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private DevExpress.XtraEditors.SimpleButton simpleButton3;
        private DevExpress.XtraEditors.GroupControl urlSettingBox;
        private DevExpress.XtraEditors.SimpleButton simpleButton2;
        private DevExpress.XtraEditors.SimpleButton simpleButton1;
        private System.Windows.Forms.Label lblUrlExclude;
        private System.Windows.Forms.Label lblUrlInclude;
        private DevExpress.XtraEditors.SimpleButton simpleButton4;
        private System.Windows.Forms.Label label1;
        private DevExpress.XtraEditors.LookUpEdit lookUpEditLabel;
        private DevExpress.XtraEditors.LookUpEdit lookUpEditTemplete;
        private DevExpress.XtraEditors.LookUpEdit lookUpEditSource;
    }
}