namespace Jade.Control
{
    partial class DevPager
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(DevPager));
            this.barManager1 = new DevExpress.XtraBars.BarManager(this.components);
            this.pageBar = new DevExpress.XtraBars.Bar();
            this.btnFirst = new DevExpress.XtraBars.BarButtonItem();
            this.btnPre = new DevExpress.XtraBars.BarButtonItem();
            this.btnNext = new DevExpress.XtraBars.BarButtonItem();
            this.btnLast = new DevExpress.XtraBars.BarButtonItem();
            this.barStaticItem1 = new DevExpress.XtraBars.BarStaticItem();
            this.txtPageNumber = new DevExpress.XtraBars.BarEditItem();
            this.repositoryItemTextEdit1 = new DevExpress.XtraEditors.Repository.RepositoryItemTextEdit();
            this.lblStatus = new DevExpress.XtraBars.BarStaticItem();
            this.barDockControlTop = new DevExpress.XtraBars.BarDockControl();
            this.barDockControlBottom = new DevExpress.XtraBars.BarDockControl();
            this.barDockControlLeft = new DevExpress.XtraBars.BarDockControl();
            this.barDockControlRight = new DevExpress.XtraBars.BarDockControl();
            this.imageList1 = new System.Windows.Forms.ImageList(this.components);
            ((System.ComponentModel.ISupportInitialize)(this.barManager1)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.repositoryItemTextEdit1)).BeginInit();
            this.SuspendLayout();
            // 
            // barManager1
            // 
            this.barManager1.Bars.AddRange(new DevExpress.XtraBars.Bar[] {
            this.pageBar});
            this.barManager1.DockControls.Add(this.barDockControlTop);
            this.barManager1.DockControls.Add(this.barDockControlBottom);
            this.barManager1.DockControls.Add(this.barDockControlLeft);
            this.barManager1.DockControls.Add(this.barDockControlRight);
            this.barManager1.Form = this;
            this.barManager1.Images = this.imageList1;
            this.barManager1.Items.AddRange(new DevExpress.XtraBars.BarItem[] {
            this.btnFirst,
            this.btnPre,
            this.btnNext,
            this.btnLast,
            this.barStaticItem1,
            this.txtPageNumber,
            this.lblStatus});
            this.barManager1.MaxItemId = 11;
            this.barManager1.RepositoryItems.AddRange(new DevExpress.XtraEditors.Repository.RepositoryItem[] {
            this.repositoryItemTextEdit1});
            this.barManager1.StatusBar = this.pageBar;
            // 
            // pageBar
            // 
            this.pageBar.BarName = "Status bar";
            this.pageBar.CanDockStyle = DevExpress.XtraBars.BarCanDockStyle.Bottom;
            this.pageBar.DockCol = 0;
            this.pageBar.DockRow = 0;
            this.pageBar.DockStyle = DevExpress.XtraBars.BarDockStyle.Bottom;
            this.pageBar.LinksPersistInfo.AddRange(new DevExpress.XtraBars.LinkPersistInfo[] {
            new DevExpress.XtraBars.LinkPersistInfo(DevExpress.XtraBars.BarLinkUserDefines.PaintStyle, this.btnFirst, DevExpress.XtraBars.BarItemPaintStyle.CaptionGlyph),
            new DevExpress.XtraBars.LinkPersistInfo(DevExpress.XtraBars.BarLinkUserDefines.PaintStyle, this.btnPre, DevExpress.XtraBars.BarItemPaintStyle.CaptionGlyph),
            new DevExpress.XtraBars.LinkPersistInfo(DevExpress.XtraBars.BarLinkUserDefines.PaintStyle, this.btnNext, DevExpress.XtraBars.BarItemPaintStyle.CaptionGlyph),
            new DevExpress.XtraBars.LinkPersistInfo(DevExpress.XtraBars.BarLinkUserDefines.PaintStyle, this.btnLast, DevExpress.XtraBars.BarItemPaintStyle.CaptionGlyph),
            new DevExpress.XtraBars.LinkPersistInfo(this.barStaticItem1),
            new DevExpress.XtraBars.LinkPersistInfo(this.txtPageNumber),
            new DevExpress.XtraBars.LinkPersistInfo(this.lblStatus)});
            this.pageBar.OptionsBar.AllowQuickCustomization = false;
            this.pageBar.OptionsBar.DrawDragBorder = false;
            this.pageBar.OptionsBar.UseWholeRow = true;
            this.pageBar.Text = "Status bar";
            // 
            // btnFirst
            // 
            this.btnFirst.Caption = "首页";
            this.btnFirst.Id = 0;
            this.btnFirst.ImageIndex = 2;
            this.btnFirst.Name = "btnFirst";
            this.btnFirst.ItemClick += new DevExpress.XtraBars.ItemClickEventHandler(this.btnFirst_Click);
            // 
            // btnPre
            // 
            this.btnPre.Caption = "上一页";
            this.btnPre.Id = 1;
            this.btnPre.ImageIndex = 1;
            this.btnPre.Name = "btnPre";
            this.btnPre.ItemClick += new DevExpress.XtraBars.ItemClickEventHandler(this.btnPre_Click);
            // 
            // btnNext
            // 
            this.btnNext.Caption = "下一页";
            this.btnNext.Id = 2;
            this.btnNext.ImageIndex = 0;
            this.btnNext.Name = "btnNext";
            this.btnNext.ItemClick += new DevExpress.XtraBars.ItemClickEventHandler(this.btnNext_Click);
            // 
            // btnLast
            // 
            this.btnLast.Caption = "末页";
            this.btnLast.Id = 3;
            this.btnLast.ImageIndex = 3;
            this.btnLast.Name = "btnLast";
            this.btnLast.ItemClick += new DevExpress.XtraBars.ItemClickEventHandler(this.btnLast_Click);
            // 
            // barStaticItem1
            // 
            this.barStaticItem1.Caption = "转到";
            this.barStaticItem1.Id = 4;
            this.barStaticItem1.Name = "barStaticItem1";
            this.barStaticItem1.ShowImageInToolbar = false;
            this.barStaticItem1.TextAlignment = System.Drawing.StringAlignment.Near;
            // 
            // txtPageNumber
            // 
            this.txtPageNumber.Caption = "1";
            this.txtPageNumber.Description = "1";
            this.txtPageNumber.Edit = this.repositoryItemTextEdit1;
            this.txtPageNumber.Id = 5;
            this.txtPageNumber.Name = "txtPageNumber";
            this.txtPageNumber.ShownEditor += new DevExpress.XtraBars.ItemClickEventHandler(this.txtPageNumber_ShownEditor);
            // 
            // repositoryItemTextEdit1
            // 
            this.repositoryItemTextEdit1.AutoHeight = false;
            this.repositoryItemTextEdit1.Name = "repositoryItemTextEdit1";
            this.repositoryItemTextEdit1.NullText = "1";
            this.repositoryItemTextEdit1.KeyDown += new System.Windows.Forms.KeyEventHandler(this.Edit_KeyDown);
            // 
            // lblStatus
            // 
            this.lblStatus.Caption = "共{0}页  {2}条";
            this.lblStatus.Id = 10;
            this.lblStatus.Name = "lblStatus";
            this.lblStatus.TextAlignment = System.Drawing.StringAlignment.Near;
            // 
            // barDockControlTop
            // 
            this.barDockControlTop.CausesValidation = false;
            this.barDockControlTop.Dock = System.Windows.Forms.DockStyle.Top;
            this.barDockControlTop.Location = new System.Drawing.Point(0, 0);
            this.barDockControlTop.Size = new System.Drawing.Size(700, 0);
            // 
            // barDockControlBottom
            // 
            this.barDockControlBottom.CausesValidation = false;
            this.barDockControlBottom.Dock = System.Windows.Forms.DockStyle.Bottom;
            this.barDockControlBottom.Location = new System.Drawing.Point(0, 7);
            this.barDockControlBottom.Size = new System.Drawing.Size(700, 25);
            // 
            // barDockControlLeft
            // 
            this.barDockControlLeft.CausesValidation = false;
            this.barDockControlLeft.Dock = System.Windows.Forms.DockStyle.Left;
            this.barDockControlLeft.Location = new System.Drawing.Point(0, 0);
            this.barDockControlLeft.Size = new System.Drawing.Size(0, 7);
            // 
            // barDockControlRight
            // 
            this.barDockControlRight.CausesValidation = false;
            this.barDockControlRight.Dock = System.Windows.Forms.DockStyle.Right;
            this.barDockControlRight.Location = new System.Drawing.Point(700, 0);
            this.barDockControlRight.Size = new System.Drawing.Size(0, 7);
            // 
            // imageList1
            // 
            this.imageList1.ImageStream = ((System.Windows.Forms.ImageListStreamer)(resources.GetObject("imageList1.ImageStream")));
            this.imageList1.TransparentColor = System.Drawing.Color.Transparent;
            this.imageList1.Images.SetKeyName(0, "bindingNavigatorMoveNextItem.Image.png");
            this.imageList1.Images.SetKeyName(1, "bindingNavigatorMovePreviousItem.Image.png");
            this.imageList1.Images.SetKeyName(2, "bindingNavigatorMoveFirstItem.Image.png");
            this.imageList1.Images.SetKeyName(3, "bindingNavigatorMoveLastItem.Image.png");
            // 
            // DevPager
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(7F, 14F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.Controls.Add(this.barDockControlLeft);
            this.Controls.Add(this.barDockControlRight);
            this.Controls.Add(this.barDockControlBottom);
            this.Controls.Add(this.barDockControlTop);
            this.Name = "DevPager";
            this.Size = new System.Drawing.Size(700, 32);
            ((System.ComponentModel.ISupportInitialize)(this.barManager1)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.repositoryItemTextEdit1)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private DevExpress.XtraBars.BarManager barManager1;
        private DevExpress.XtraBars.Bar pageBar;
        private DevExpress.XtraBars.BarDockControl barDockControlTop;
        private DevExpress.XtraBars.BarDockControl barDockControlBottom;
        private DevExpress.XtraBars.BarDockControl barDockControlLeft;
        private DevExpress.XtraBars.BarDockControl barDockControlRight;
        private DevExpress.XtraBars.BarButtonItem btnFirst;
        private DevExpress.XtraBars.BarButtonItem btnPre;
        private DevExpress.XtraBars.BarButtonItem btnNext;
        private DevExpress.XtraBars.BarButtonItem btnLast;
        private DevExpress.XtraBars.BarStaticItem barStaticItem1;
        private DevExpress.XtraBars.BarEditItem txtPageNumber;
        private DevExpress.XtraEditors.Repository.RepositoryItemTextEdit repositoryItemTextEdit1;
        private DevExpress.XtraBars.BarStaticItem lblStatus;
        private System.Windows.Forms.ImageList imageList1;
    }
}
