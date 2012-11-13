namespace Jade.ConfigTool
{
    partial class UrlSelectorMarker
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

        #region Component Designer generated code

        /// <summary> 
        /// Required method for Designer support - do not modify 
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            this.xtraTabControl1 = new DevExpress.XtraTab.XtraTabControl();
            this.mainTab = new DevExpress.XtraTab.XtraTabPage();
            this.urlSelectorPanel1 = new Jade.ConfigTool.UrlSelectorPanel();
            this.contentTab = new DevExpress.XtraTab.XtraTabPage();
            this.urlSelectorPanel2 = new Jade.ConfigTool.UrlSelectorPanel();
            ((System.ComponentModel.ISupportInitialize)(this.xtraTabControl1)).BeginInit();
            this.xtraTabControl1.SuspendLayout();
            this.mainTab.SuspendLayout();
            this.contentTab.SuspendLayout();
            this.SuspendLayout();
            // 
            // xtraTabControl1
            // 
            this.xtraTabControl1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.xtraTabControl1.Location = new System.Drawing.Point(0, 0);
            this.xtraTabControl1.Name = "xtraTabControl1";
            this.xtraTabControl1.SelectedTabPage = this.mainTab;
            this.xtraTabControl1.Size = new System.Drawing.Size(869, 203);
            this.xtraTabControl1.TabIndex = 3;
            this.xtraTabControl1.TabPages.AddRange(new DevExpress.XtraTab.XtraTabPage[] {
            this.mainTab,
            this.contentTab});
            this.xtraTabControl1.SelectedPageChanged += new DevExpress.XtraTab.TabPageChangedEventHandler(this.xtraTabControl1_SelectedPageChanged);
            // 
            // mainTab
            // 
            this.mainTab.Controls.Add(this.urlSelectorPanel1);
            this.mainTab.Name = "mainTab";
            this.mainTab.Size = new System.Drawing.Size(863, 174);
            this.mainTab.Text = "链接规则";
            // 
            // urlSelectorPanel1
            // 
            this.urlSelectorPanel1.CurrentUrlSelector = null;
            this.urlSelectorPanel1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.urlSelectorPanel1.Location = new System.Drawing.Point(0, 0);
            this.urlSelectorPanel1.Name = "urlSelectorPanel1";
            this.urlSelectorPanel1.Size = new System.Drawing.Size(863, 174);
            this.urlSelectorPanel1.TabIndex = 0;
            this.urlSelectorPanel1.OnXpathSelectorClick += new System.EventHandler(this.urlSelectorPanel1_OnXpathSelectorClick);
            this.urlSelectorPanel1.OnTestClick += new System.EventHandler(this.urlSelectorPanel1_OnTestClick);
            this.urlSelectorPanel1.OnSelectUrlClick += new System.EventHandler(this.urlSelectorPanel1_OnSelectUrlClick);
            // 
            // contentTab
            // 
            this.contentTab.Controls.Add(this.urlSelectorPanel2);
            this.contentTab.Name = "contentTab";
            this.contentTab.Size = new System.Drawing.Size(863, 174);
            this.contentTab.Text = "包含的内容页规则";
            // 
            // urlSelectorPanel2
            // 
            this.urlSelectorPanel2.CurrentUrlSelector = null;
            this.urlSelectorPanel2.Dock = System.Windows.Forms.DockStyle.Fill;
            this.urlSelectorPanel2.Location = new System.Drawing.Point(0, 0);
            this.urlSelectorPanel2.Name = "urlSelectorPanel2";
            this.urlSelectorPanel2.Size = new System.Drawing.Size(863, 174);
            this.urlSelectorPanel2.TabIndex = 1;
            this.urlSelectorPanel2.OnXpathSelectorClick += new System.EventHandler(this.urlSelectorPanel1_OnXpathSelectorClick);
            this.urlSelectorPanel2.OnTestClick += new System.EventHandler(this.urlSelectorPanel1_OnTestClick);
            this.urlSelectorPanel2.OnSelectUrlClick += new System.EventHandler(this.urlSelectorPanel1_OnSelectUrlClick);
            // 
            // UrlSelectorMarker
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(7F, 14F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.Controls.Add(this.xtraTabControl1);
            this.Name = "UrlSelectorMarker";
            this.Size = new System.Drawing.Size(869, 203);
            ((System.ComponentModel.ISupportInitialize)(this.xtraTabControl1)).EndInit();
            this.xtraTabControl1.ResumeLayout(false);
            this.mainTab.ResumeLayout(false);
            this.contentTab.ResumeLayout(false);
            this.ResumeLayout(false);

        }

        #endregion

        private DevExpress.XtraTab.XtraTabControl xtraTabControl1;
        private DevExpress.XtraTab.XtraTabPage mainTab;
        private DevExpress.XtraTab.XtraTabPage contentTab;
        private UrlSelectorPanel urlSelectorPanel1;
        private UrlSelectorPanel urlSelectorPanel2;

    }
}
