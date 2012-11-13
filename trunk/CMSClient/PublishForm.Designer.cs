namespace Jade
{
    partial class PublishForm
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
            this.baseWebBrowser1 = new Com.iFLYTEK.WinForms.Browser.BaseWebBrowser();
            this.SuspendLayout();
            // 
            // baseWebBrowser1
            // 
            this.baseWebBrowser1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.baseWebBrowser1.Location = new System.Drawing.Point(0, 0);
            this.baseWebBrowser1.MinimumSize = new System.Drawing.Size(20, 20);
            this.baseWebBrowser1.Name = "baseWebBrowser1";
            this.baseWebBrowser1.ScriptErrorsSuppressed = true;
            this.baseWebBrowser1.Size = new System.Drawing.Size(495, 301);
            this.baseWebBrowser1.TabIndex = 0;
            // 
            // PublishForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(7F, 14F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(495, 301);
            this.Controls.Add(this.baseWebBrowser1);
            this.Name = "PublishForm";
            this.Text = "PublishForm";
            this.ResumeLayout(false);

        }

        #endregion

        private Com.iFLYTEK.WinForms.Browser.BaseWebBrowser baseWebBrowser1;
    }
}