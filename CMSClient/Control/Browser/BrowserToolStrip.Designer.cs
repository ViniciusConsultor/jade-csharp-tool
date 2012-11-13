namespace Com.iFLYTEK.WinForms.Browser
{
    partial class BrowserToolStrip
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(BrowserToolStrip));
            this.favoriteStripButton = new System.Windows.Forms.ToolStripButton();
            this.prevToolStripButton = new System.Windows.Forms.ToolStripButton();
            this.nextToolStripButton = new System.Windows.Forms.ToolStripButton();
            this.stopToolStripButton = new System.Windows.Forms.ToolStripButton();
            this.refreshToolStripButton = new System.Windows.Forms.ToolStripButton();
            this.toolStripSeparator1 = new System.Windows.Forms.ToolStripSeparator();
            this.toolStripLabel1 = new System.Windows.Forms.ToolStripLabel();
            this.urlCombo = new System.Windows.Forms.ToolStripComboBox();
            this.goToolStripButton = new System.Windows.Forms.ToolStripButton();
            this.SuspendLayout();
            // 
            // prevToolStripButton
            // 
            this.prevToolStripButton.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image;
            resources.ApplyResources(this.prevToolStripButton, "prevToolStripButton");
            this.prevToolStripButton.Name = "prevToolStripButton";
            this.prevToolStripButton.Click += new System.EventHandler(this.controlToolStripButton_Click);

            this.favoriteStripButton.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image;
            resources.ApplyResources(this.favoriteStripButton, "favoriteStripButton");
            this.favoriteStripButton.Name = "favoriteStripButton";
            this.favoriteStripButton.Click += new System.EventHandler(prevToolStripButton_Click);
            this.favoriteStripButton.ToolTipText = "IE ’≤ÿº–";
            // 
            // nextToolStripButton
            // 
            this.nextToolStripButton.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image;
            resources.ApplyResources(this.nextToolStripButton, "nextToolStripButton");
            this.nextToolStripButton.Name = "nextToolStripButton";
            this.nextToolStripButton.Click += new System.EventHandler(this.controlToolStripButton_Click);
            // 
            // stopToolStripButton
            // 
            this.stopToolStripButton.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image;
            resources.ApplyResources(this.stopToolStripButton, "stopToolStripButton");
            this.stopToolStripButton.Name = "stopToolStripButton";
            this.stopToolStripButton.Click += new System.EventHandler(this.controlToolStripButton_Click);
            // 
            // refreshToolStripButton
            // 
            this.refreshToolStripButton.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image;
            resources.ApplyResources(this.refreshToolStripButton, "refreshToolStripButton");
            this.refreshToolStripButton.Name = "refreshToolStripButton";
            this.refreshToolStripButton.Click += new System.EventHandler(this.controlToolStripButton_Click);
            // 
            // toolStripSeparator1
            // 
            this.toolStripSeparator1.Name = "toolStripSeparator1";
            resources.ApplyResources(this.toolStripSeparator1, "toolStripSeparator1");
            // 
            // toolStripLabel1
            // 
            this.toolStripLabel1.Name = "toolStripLabel1";
            resources.ApplyResources(this.toolStripLabel1, "toolStripLabel1");
            // 
            // urlCombo
            // 
            this.urlCombo.AutoCompleteMode = System.Windows.Forms.AutoCompleteMode.Suggest;
            this.urlCombo.AutoCompleteSource = System.Windows.Forms.AutoCompleteSource.AllUrl;
            this.urlCombo.AutoToolTip = true;
            this.urlCombo.Name = "urlCombo";
            resources.ApplyResources(this.urlCombo, "urlCombo");
            // 
            // goToolStripButton
            // 
            this.goToolStripButton.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image;
            resources.ApplyResources(this.goToolStripButton, "goToolStripButton");
            this.goToolStripButton.Name = "goToolStripButton";
            this.goToolStripButton.Click += new System.EventHandler(this.controlToolStripButton_Click);
            // 
            // BrowserToolStrip
            // 
            this.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.favoriteStripButton,
            this.prevToolStripButton,
            this.nextToolStripButton,
            this.stopToolStripButton,
            this.refreshToolStripButton,
            this.toolStripSeparator1,
            this.toolStripLabel1,
            this.urlCombo,
            this.goToolStripButton});
            this.ResumeLayout(false);

        }



        #endregion

        private System.Windows.Forms.ToolStripButton favoriteStripButton;
        private System.Windows.Forms.ToolStripButton prevToolStripButton;
        private System.Windows.Forms.ToolStripButton nextToolStripButton;
        private System.Windows.Forms.ToolStripButton stopToolStripButton;
        private System.Windows.Forms.ToolStripButton refreshToolStripButton;
        private System.Windows.Forms.ToolStripSeparator toolStripSeparator1;
        private System.Windows.Forms.ToolStripLabel toolStripLabel1;
        private System.Windows.Forms.ToolStripComboBox urlCombo;
        private System.Windows.Forms.ToolStripButton goToolStripButton;
    }
}
