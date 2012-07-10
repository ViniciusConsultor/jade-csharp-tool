namespace HFBBS
{
    partial class CookieChecker
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
            this.wbbMain = new System.Windows.Forms.WebBrowser();
            this.lblCookie = new System.Windows.Forms.Label();
            this.pnlMain = new System.Windows.Forms.Panel();
            this.tbxCookie = new System.Windows.Forms.TextBox();
            this.lblUrl = new System.Windows.Forms.Label();
            this.tbxUrl = new System.Windows.Forms.TextBox();
            this.btnSend = new System.Windows.Forms.Button();
            this.btnCookieOk = new System.Windows.Forms.Button();
            this.pnlMain.SuspendLayout();
            this.SuspendLayout();
            // 
            // wbbMain
            // 
            this.wbbMain.Dock = System.Windows.Forms.DockStyle.Fill;
            this.wbbMain.Location = new System.Drawing.Point(0, 0);
            this.wbbMain.MinimumSize = new System.Drawing.Size(20, 20);
            this.wbbMain.Name = "wbbMain";
            this.wbbMain.Size = new System.Drawing.Size(668, 471);
            this.wbbMain.TabIndex = 0;
            this.wbbMain.DocumentCompleted += new System.Windows.Forms.WebBrowserDocumentCompletedEventHandler(this.wbbMain_DocumentCompleted);
            // 
            // lblCookie
            // 
            this.lblCookie.AutoSize = true;
            this.lblCookie.Font = new System.Drawing.Font("Microsoft Sans Serif", 9F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.lblCookie.Location = new System.Drawing.Point(12, 523);
            this.lblCookie.Name = "lblCookie";
            this.lblCookie.Size = new System.Drawing.Size(55, 15);
            this.lblCookie.TabIndex = 1;
            this.lblCookie.Text = "Cookie:";
            // 
            // pnlMain
            // 
            this.pnlMain.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.pnlMain.Controls.Add(this.wbbMain);
            this.pnlMain.Location = new System.Drawing.Point(12, 41);
            this.pnlMain.Name = "pnlMain";
            this.pnlMain.Size = new System.Drawing.Size(670, 473);
            this.pnlMain.TabIndex = 2;
            // 
            // tbxCookie
            // 
            this.tbxCookie.Location = new System.Drawing.Point(74, 521);
            this.tbxCookie.Name = "tbxCookie";
            this.tbxCookie.Size = new System.Drawing.Size(508, 20);
            this.tbxCookie.TabIndex = 3;
            // 
            // lblUrl
            // 
            this.lblUrl.AutoSize = true;
            this.lblUrl.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.lblUrl.Location = new System.Drawing.Point(12, 14);
            this.lblUrl.Name = "lblUrl";
            this.lblUrl.Size = new System.Drawing.Size(36, 13);
            this.lblUrl.TabIndex = 86;
            this.lblUrl.Text = "URL:";
            // 
            // tbxUrl
            // 
            this.tbxUrl.Location = new System.Drawing.Point(54, 11);
            this.tbxUrl.Name = "tbxUrl";
            this.tbxUrl.Size = new System.Drawing.Size(528, 20);
            this.tbxUrl.TabIndex = 85;
            // 
            // btnSend
            // 
            this.btnSend.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.btnSend.Location = new System.Drawing.Point(589, 11);
            this.btnSend.Name = "btnSend";
            this.btnSend.Size = new System.Drawing.Size(93, 23);
            this.btnSend.TabIndex = 84;
            this.btnSend.Text = "GO";
            this.btnSend.UseVisualStyleBackColor = true;
            this.btnSend.Click += new System.EventHandler(this.btnSend_Click);
            // 
            // btnCookieOk
            // 
            this.btnCookieOk.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.btnCookieOk.Location = new System.Drawing.Point(589, 520);
            this.btnCookieOk.Name = "btnCookieOk";
            this.btnCookieOk.Size = new System.Drawing.Size(93, 23);
            this.btnCookieOk.TabIndex = 87;
            this.btnCookieOk.Text = "提取成功";
            this.btnCookieOk.UseVisualStyleBackColor = true;
            this.btnCookieOk.Click += new System.EventHandler(this.btnCookieOk_Click);
            // 
            // CookieChecker
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(694, 549);
            this.Controls.Add(this.btnCookieOk);
            this.Controls.Add(this.lblUrl);
            this.Controls.Add(this.tbxUrl);
            this.Controls.Add(this.btnSend);
            this.Controls.Add(this.tbxCookie);
            this.Controls.Add(this.pnlMain);
            this.Controls.Add(this.lblCookie);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedToolWindow;
            this.MaximizeBox = false;
            this.MinimizeBox = false;
            this.Name = "CookieChecker";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterParent;
            this.Text = "CookieChecker";
            this.pnlMain.ResumeLayout(false);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.WebBrowser wbbMain;
        private System.Windows.Forms.Label lblCookie;
        private System.Windows.Forms.Panel pnlMain;
        private System.Windows.Forms.TextBox tbxCookie;
        private System.Windows.Forms.Label lblUrl;
        private System.Windows.Forms.TextBox tbxUrl;
        private System.Windows.Forms.Button btnSend;
        private System.Windows.Forms.Button btnCookieOk;
    }
}