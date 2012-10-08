namespace Jade
{
    partial class ImageSelecter
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
            DevExpress.XtraBars.Ribbon.GalleryItemGroup galleryItemGroup19 = new DevExpress.XtraBars.Ribbon.GalleryItemGroup();
            DevExpress.XtraBars.Ribbon.GalleryItemGroup galleryItemGroup20 = new DevExpress.XtraBars.Ribbon.GalleryItemGroup();
            DevExpress.XtraBars.Ribbon.GalleryItemGroup galleryItemGroup21 = new DevExpress.XtraBars.Ribbon.GalleryItemGroup();
            DevExpress.XtraBars.Ribbon.GalleryItemGroup galleryItemGroup22 = new DevExpress.XtraBars.Ribbon.GalleryItemGroup();
            DevExpress.XtraBars.Ribbon.GalleryItemGroup galleryItemGroup23 = new DevExpress.XtraBars.Ribbon.GalleryItemGroup();
            DevExpress.XtraBars.Ribbon.GalleryItemGroup galleryItemGroup24 = new DevExpress.XtraBars.Ribbon.GalleryItemGroup();
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(ImageSelecter));
            this.mainGallery = new DevExpress.XtraBars.Ribbon.GalleryControl();
            this.galleryControlClient1 = new DevExpress.XtraBars.Ribbon.GalleryControlClient();
            this.navBarControl1 = new DevExpress.XtraNavBar.NavBarControl();
            this.navBarGroup1 = new DevExpress.XtraNavBar.NavBarGroup();
            this.navBarDeskTop = new DevExpress.XtraNavBar.NavBarItem();
            this.navBarLocalDisk = new DevExpress.XtraNavBar.NavBarItem();
            this.navBarMyPic = new DevExpress.XtraNavBar.NavBarItem();
            this.albumGroup = new DevExpress.XtraNavBar.NavBarGroup();
            this.navBarRencent = new DevExpress.XtraNavBar.NavBarItem();
            this.navBarItemDownload = new DevExpress.XtraNavBar.NavBarItem();
            this.navBarItemRemote = new DevExpress.XtraNavBar.NavBarItem();
            this.lblStatus = new System.Windows.Forms.Label();
            ((System.ComponentModel.ISupportInitialize)(this.mainGallery)).BeginInit();
            this.mainGallery.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.navBarControl1)).BeginInit();
            this.SuspendLayout();
            // 
            // mainGallery
            // 
            this.mainGallery.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom)
                        | System.Windows.Forms.AnchorStyles.Left)
                        | System.Windows.Forms.AnchorStyles.Right)));
            this.mainGallery.Controls.Add(this.galleryControlClient1);
            this.mainGallery.DesignGalleryGroupIndex = 0;
            this.mainGallery.DesignGalleryItemIndex = 0;
            // 
            // galleryControlGallery1
            // 
            galleryItemGroup19.Caption = "最近使用";
            galleryItemGroup20.Caption = "附件库";
            galleryItemGroup21.Caption = "远程图片";
            galleryItemGroup22.Caption = "本地磁盘";
            galleryItemGroup23.Caption = "桌面";
            galleryItemGroup24.Caption = "我的图片";
            this.mainGallery.Gallery.Groups.AddRange(new DevExpress.XtraBars.Ribbon.GalleryItemGroup[] {
            galleryItemGroup19,
            galleryItemGroup20,
            galleryItemGroup21,
            galleryItemGroup22,
            galleryItemGroup23,
            galleryItemGroup24});
            this.mainGallery.Gallery.ItemDoubleClick += new DevExpress.XtraBars.Ribbon.GalleryItemClickEventHandler(this.galleryControlGallery1_ItemDoubleClick);
            this.mainGallery.Location = new System.Drawing.Point(223, 0);
            this.mainGallery.Name = "mainGallery";
            this.mainGallery.Size = new System.Drawing.Size(710, 462);
            this.mainGallery.TabIndex = 1;
            this.mainGallery.Text = "galleryControl1";
            // 
            // galleryControlClient1
            // 
            this.galleryControlClient1.GalleryControl = this.mainGallery;
            this.galleryControlClient1.Location = new System.Drawing.Point(2, 24);
            this.galleryControlClient1.Size = new System.Drawing.Size(689, 436);
            // 
            // navBarControl1
            // 
            this.navBarControl1.ActiveGroup = this.navBarGroup1;
            this.navBarControl1.AllowSelectedLink = true;
            this.navBarControl1.Dock = System.Windows.Forms.DockStyle.Left;
            this.navBarControl1.DragDropFlags = DevExpress.XtraNavBar.NavBarDragDrop.None;
            this.navBarControl1.Groups.AddRange(new DevExpress.XtraNavBar.NavBarGroup[] {
            this.albumGroup,
            this.navBarGroup1});
            this.navBarControl1.Items.AddRange(new DevExpress.XtraNavBar.NavBarItem[] {
            this.navBarRencent,
            this.navBarItemDownload,
            this.navBarItemRemote,
            this.navBarLocalDisk,
            this.navBarMyPic,
            this.navBarDeskTop});
            this.navBarControl1.Location = new System.Drawing.Point(0, 0);
            this.navBarControl1.Name = "navBarControl1";
            this.navBarControl1.OptionsNavPane.ExpandedWidth = 217;
            this.navBarControl1.OptionsNavPane.ShowExpandButton = false;
            this.navBarControl1.PaintStyleKind = DevExpress.XtraNavBar.NavBarViewKind.NavigationPane;
            this.navBarControl1.Size = new System.Drawing.Size(217, 462);
            this.navBarControl1.SkinExplorerBarViewScrollStyle = DevExpress.XtraNavBar.SkinExplorerBarViewScrollStyle.ScrollBar;
            this.navBarControl1.TabIndex = 2;
            this.navBarControl1.Text = "navBarControl1";
            this.navBarControl1.Click += new System.EventHandler(this.navBarControl1_Click);
            // 
            // navBarGroup1
            // 
            this.navBarGroup1.Caption = "我的电脑";
            this.navBarGroup1.Expanded = true;
            this.navBarGroup1.GroupStyle = DevExpress.XtraNavBar.NavBarGroupStyle.LargeIconsText;
            this.navBarGroup1.ItemLinks.AddRange(new DevExpress.XtraNavBar.NavBarItemLink[] {
            new DevExpress.XtraNavBar.NavBarItemLink(this.navBarDeskTop),
            new DevExpress.XtraNavBar.NavBarItemLink(this.navBarLocalDisk),
            new DevExpress.XtraNavBar.NavBarItemLink(this.navBarMyPic)});
            this.navBarGroup1.Name = "navBarGroup1";
            this.navBarGroup1.SelectedLinkIndex = 0;
            // 
            // navBarDeskTop
            // 
            this.navBarDeskTop.Caption = "桌面";
            this.navBarDeskTop.LargeImage = global::Jade.Properties.Resources.desktop;
            this.navBarDeskTop.Name = "navBarDeskTop";
            this.navBarDeskTop.LinkClicked += new DevExpress.XtraNavBar.NavBarLinkEventHandler(this.navBarDeskTop_LinkClicked);
            // 
            // navBarLocalDisk
            // 
            this.navBarLocalDisk.Caption = "本地磁盘";
            this.navBarLocalDisk.LargeImage = global::Jade.Properties.Resources.hdd32;
            this.navBarLocalDisk.Name = "navBarLocalDisk";
            this.navBarLocalDisk.LinkClicked += new DevExpress.XtraNavBar.NavBarLinkEventHandler(this.navBarLocalDisk_LinkClicked);
            // 
            // navBarMyPic
            // 
            this.navBarMyPic.Caption = "我的图片";
            this.navBarMyPic.LargeImage = global::Jade.Properties.Resources.my_pictures;
            this.navBarMyPic.Name = "navBarMyPic";
            this.navBarMyPic.LinkClicked += new DevExpress.XtraNavBar.NavBarLinkEventHandler(this.navBarMyPic_LinkClicked);
            // 
            // albumGroup
            // 
            this.albumGroup.Caption = "图片";
            this.albumGroup.Expanded = true;
            this.albumGroup.GroupCaptionUseImage = DevExpress.XtraNavBar.NavBarImage.Large;
            this.albumGroup.GroupStyle = DevExpress.XtraNavBar.NavBarGroupStyle.LargeIconsText;
            this.albumGroup.ItemLinks.AddRange(new DevExpress.XtraNavBar.NavBarItemLink[] {
            new DevExpress.XtraNavBar.NavBarItemLink(this.navBarRencent),
            new DevExpress.XtraNavBar.NavBarItemLink(this.navBarItemDownload),
            new DevExpress.XtraNavBar.NavBarItemLink(this.navBarItemRemote)});
            this.albumGroup.Name = "albumGroup";
            // 
            // navBarRencent
            // 
            this.navBarRencent.Caption = "最近使用";
            this.navBarRencent.Hint = "最近使用";
            this.navBarRencent.LargeImage = ((System.Drawing.Image)(resources.GetObject("navBarRencent.LargeImage")));
            this.navBarRencent.Name = "navBarRencent";
            this.navBarRencent.LinkClicked += new DevExpress.XtraNavBar.NavBarLinkEventHandler(this.navBarRencent_LinkClicked);
            // 
            // navBarItemDownload
            // 
            this.navBarItemDownload.Caption = "附件库";
            this.navBarItemDownload.Hint = "下载的图片库";
            this.navBarItemDownload.LargeImage = global::Jade.Properties.Resources.attachment_yellow;
            this.navBarItemDownload.Name = "navBarItemDownload";
            this.navBarItemDownload.LinkClicked += new DevExpress.XtraNavBar.NavBarLinkEventHandler(this.navBarItemDownload_LinkClicked);
            // 
            // navBarItemRemote
            // 
            this.navBarItemRemote.Caption = "远程图片库";
            this.navBarItemRemote.LargeImage = ((System.Drawing.Image)(resources.GetObject("navBarItemRemote.LargeImage")));
            this.navBarItemRemote.Name = "navBarItemRemote";
            this.navBarItemRemote.LinkClicked += new DevExpress.XtraNavBar.NavBarLinkEventHandler(this.navBarItemRemote_LinkClicked);
            // 
            // lblStatus
            // 
            this.lblStatus.AutoSize = true;
            this.lblStatus.Location = new System.Drawing.Point(315, 6);
            this.lblStatus.Name = "lblStatus";
            this.lblStatus.Size = new System.Drawing.Size(38, 14);
            this.lblStatus.TabIndex = 3;
            this.lblStatus.Text = "label1";
            // 
            // ImageSelecter
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(7F, 14F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(933, 462);
            this.Controls.Add(this.lblStatus);
            this.Controls.Add(this.navBarControl1);
            this.Controls.Add(this.mainGallery);
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.Name = "ImageSelecter";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "图片选择";
            this.Load += new System.EventHandler(this.ImageSelecter_Load);
            ((System.ComponentModel.ISupportInitialize)(this.mainGallery)).EndInit();
            this.mainGallery.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.navBarControl1)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private DevExpress.XtraBars.Ribbon.GalleryControl mainGallery;
        private DevExpress.XtraBars.Ribbon.GalleryControlClient galleryControlClient1;
        private DevExpress.XtraNavBar.NavBarControl navBarControl1;
        private DevExpress.XtraNavBar.NavBarGroup albumGroup;
        private DevExpress.XtraNavBar.NavBarItem navBarRencent;
        private DevExpress.XtraNavBar.NavBarItem navBarItemDownload;
        private DevExpress.XtraNavBar.NavBarItem navBarItemRemote;
        private System.Windows.Forms.Label lblStatus;
        private DevExpress.XtraNavBar.NavBarGroup navBarGroup1;
        private DevExpress.XtraNavBar.NavBarItem navBarDeskTop;
        private DevExpress.XtraNavBar.NavBarItem navBarLocalDisk;
        private DevExpress.XtraNavBar.NavBarItem navBarMyPic;
    }
}