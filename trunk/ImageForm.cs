using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;
using DevExpress.XtraEditors;
using System.IO;

namespace Jade
{
    public partial class ImageForm : DevExpress.XtraEditors.XtraForm
    {
        public ImageModel ImageModel
        {
            get;
            set;
        }

        public ImageForm(ImageModel model)
        {
            InitializeComponent();

            this.pictureBox1.SizeMode = PictureBoxSizeMode.Zoom;
            this.ImageModel = model;

            this.txtTitle.Text = model.Title;
            this.textEdit1.Text = model.Alt;

            if (model.Src.Contains("http"))
            {
                try
                {
                    NiceWebClient client = new NiceWebClient();
                    client.DownloadDataCompleted += new System.Net.DownloadDataCompletedEventHandler(client_DownloadDataCompleted);
                    client.DownloadDataAsync(new Uri(model.Src), null);

                }
                catch
                {
                    this.lblLoading.Text = "加载失败";
                }
            }
            else
            {
                var src = model.Src.Replace("file:///", "").Replace("//", "\\").Replace("/", "\\");
                if (System.IO.File.Exists(src))
                {
                    try
                    {
                        this.pictureBox1.Image = Image.FromFile(src);
                        this.lblLoading.Hide();
                    }
                    catch
                    {
                        this.lblLoading.Text = "加载失败";
                    }
                }
            }
        }

        void client_DownloadDataCompleted(object sender, System.Net.DownloadDataCompletedEventArgs e)
        {
            if (e.Error != null)
            {
                MessageBox.Show("加载图片失败");
                this.lblLoading.Text = "加载失败";
            }
            else
            {
                try
                {
                    this.pictureBox1.Image = Image.FromStream(new MemoryStream(e.Result));
                    this.lblLoading.Hide();
                }
                catch
                {
                    MessageBox.Show("加载图片失败");
                    this.lblLoading.Text = "加载失败";
                }
            }
        }

        void UpdateModel()
        {
            ImageModel.Title = this.txtTitle.Text;
            ImageModel.Alt = this.textEdit1.Text;
        }

        private void btnOk_Click(object sender, EventArgs e)
        {
            UpdateModel();
            this.DialogResult = DialogResult.OK;
            this.Close();
        }

        private void btnCancel_Click(object sender, EventArgs e)
        {
            this.DialogResult = DialogResult.Cancel;
            this.Close();
        }
    }

    public class ImageModel
    {
        public string Src { get; set; }

        public string Title { get; set; }

        public string Alt { get; set; }

        public override string ToString()
        {
            return "['" + Src + "','" + Title + "','" + Alt + "']";
        }
    }
}