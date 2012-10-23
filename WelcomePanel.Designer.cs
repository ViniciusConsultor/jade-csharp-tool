namespace Jade
{
    partial class WelcomePanel
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
            this.components = new System.ComponentModel.Container();
            this.statusStrip1 = new System.Windows.Forms.StatusStrip();
            this.lblStatus = new System.Windows.Forms.ToolStripStatusLabel();
            this.lbllProgress = new System.Windows.Forms.ToolStripStatusLabel();
            this.favoriteBox1 = new Jade.Control.Browser.FavoriteBox();
            this.browserToolStrip1 = new Com.iFLYTEK.WinForms.Browser.BrowserToolStrip(this.components);
            this.webBrowser1 = new Com.iFLYTEK.WinForms.Browser.BaseWebBrowser(this.components);
            this.statusStrip1.SuspendLayout();
            this.SuspendLayout();
            // 
            // statusStrip1
            // 
            this.statusStrip1.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.lblStatus,
            this.lbllProgress});
            this.statusStrip1.Location = new System.Drawing.Point(0, 439);
            this.statusStrip1.Name = "statusStrip1";
            this.statusStrip1.Size = new System.Drawing.Size(813, 22);
            this.statusStrip1.TabIndex = 4;
            this.statusStrip1.Text = "statusStrip1";
            // 
            // lblStatus
            // 
            this.lblStatus.Name = "lblStatus";
            this.lblStatus.Size = new System.Drawing.Size(41, 17);
            this.lblStatus.Text = "ready";
            // 
            // lbllProgress
            // 
            this.lbllProgress.Name = "lbllProgress";
            this.lbllProgress.Size = new System.Drawing.Size(40, 17);
            this.lbllProgress.Text = "100%";
            // 
            // favoriteBox1
            // 
            this.favoriteBox1.Location = new System.Drawing.Point(0, 28);
            this.favoriteBox1.Name = "favoriteBox1";
            this.favoriteBox1.Size = new System.Drawing.Size(346, 414);
            this.favoriteBox1.TabIndex = 3;
            this.favoriteBox1.Url = null;
            // 
            // browserToolStrip1
            // 
            this.browserToolStrip1.Location = new System.Drawing.Point(0, 0);
            this.browserToolStrip1.Name = "browserToolStrip1";
            this.browserToolStrip1.Size = new System.Drawing.Size(813, 25);
            this.browserToolStrip1.TabIndex = 2;
            this.browserToolStrip1.Text = "browserToolStrip1";
            this.browserToolStrip1.WbForm = null;
            // 
            // webBrowser1
            // 
            this.webBrowser1.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom)
                        | System.Windows.Forms.AnchorStyles.Left)
                        | System.Windows.Forms.AnchorStyles.Right)));
            this.webBrowser1.Location = new System.Drawing.Point(0, 28);
            this.webBrowser1.Name = "webBrowser1";
            this.webBrowser1.ScriptErrorsSuppressed = true;
            this.webBrowser1.Size = new System.Drawing.Size(813, 412);
            this.webBrowser1.TabIndex = 1;
            // 
            // WelcomePanel
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(7F, 14F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.Controls.Add(this.favoriteBox1);
            this.Controls.Add(this.statusStrip1);
            this.Controls.Add(this.browserToolStrip1);
            this.Controls.Add(this.webBrowser1);
            this.Name = "WelcomePanel";
            this.Size = new System.Drawing.Size(813, 461);
            this.statusStrip1.ResumeLayout(false);
            this.statusStrip1.PerformLayout();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private Com.iFLYTEK.WinForms.Browser.BaseWebBrowser webBrowser1;
        private Com.iFLYTEK.WinForms.Browser.BrowserToolStrip browserToolStrip1;
        private Control.Browser.FavoriteBox favoriteBox1;
        private System.Windows.Forms.StatusStrip statusStrip1;
        private System.Windows.Forms.ToolStripStatusLabel lblStatus;
        private System.Windows.Forms.ToolStripStatusLabel lbllProgress;
    }
}
