using System;
using System.ComponentModel;
using System.Collections.Generic;
using System.Diagnostics;
using System.Text;
using System.Windows.Forms;
using System.Drawing;
using Jade.Control.Browser;

namespace Com.iFLYTEK.WinForms.Browser
{
    public partial class BrowserToolStrip : ToolStrip
    {
        public event EventHandler FavoriteClick;

        private IBaseBrowserForm _wbForm;

        public IBaseBrowserForm WbForm
        {
            get
            {
                return _wbForm;
            }
            set
            {
                _wbForm = value;
                if (_wbForm is Form)
                {
                    var form = _wbForm as Form;
                  
                }
            }
        }

        public ToolStripComboBox UrlCombo
        {
            get
            {
                return this.urlCombo;
            }
        }

        public BrowserToolStrip()
        {
            InitializeComponent();
            InitPicture();
        }

        public BrowserToolStrip(IContainer container)
        {
            container.Add(this);

            InitializeComponent();
            InitPicture();
        }

        private void InitPicture()
        {
            Bitmap source = Jade.Properties.Resources.IeToolbar;
            source.MakeTransparent(Color.FromArgb(192, 192, 192));
            ImageList tpList = new ImageList();
            tpList.ImageSize = new Size(16, 16);
            tpList.Images.AddStrip(source);
            tpList.Images.Add(Jade.Properties.Resources.favorite);
            this.prevToolStripButton.Image = tpList.Images[0];
            this.nextToolStripButton.Image = tpList.Images[1];
            this.stopToolStripButton.Image = tpList.Images[2];
            this.refreshToolStripButton.Image = tpList.Images[4];
            this.goToolStripButton.Image = tpList.Images[10];
            this.favoriteStripButton.Image = tpList.Images[tpList.Images.Count - 1];
            this.UrlCombo.Width = this.Width - 220;

            this.Resize += new EventHandler(BrowserToolStrip_Resize);
        }

        void BrowserToolStrip_Resize(object sender, EventArgs e)
        {
            this.UrlCombo.Size = new Size(this.Width - 220, this.urlCombo.Height);
        }

        void prevToolStripButton_Click(object sender, System.EventArgs e)
        {
            if (FavoriteClick != null)
            {
                FavoriteClick(sender, e);
            }
          
        }  

        void controlToolStripButton_Click(object sender, System.EventArgs e)
        {
            if (sender == this.prevToolStripButton)
            {
                this._wbForm.GoBack();
            }
            else if (sender == this.nextToolStripButton)
            {
                this._wbForm.GoForward();
            }
            else if (sender == this.stopToolStripButton)
            {
                this._wbForm.Stop();
            }
            else if (sender == this.refreshToolStripButton)
            {
                this._wbForm.RefreshBrowser();
            }
            else if (sender == this.goToolStripButton)
            {
                this._wbForm.GoNavigate();
            }
        }
    }
}
