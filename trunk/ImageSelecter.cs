using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Linq;
using System.Windows.Forms;
using DevExpress.XtraEditors;
using DevExpress.XtraBars.Ribbon;
using System.IO;
using System.Security.Cryptography;
using DevExpress.Utils.Drawing;
using System.Threading;
using DevExpress.XtraSplashScreen;

namespace Jade
{
    public partial class ImageSelecter : DevExpress.XtraEditors.XtraForm
    {
        public ImageSelecter(bool onlyRemote = false)
        {
            InitializeComponent();

            //GalleryItemGroup group = new GalleryItemGroup();
            //group.Caption = "附件库";
            //group.CaptionAlignment = GalleryItemGroupCaptionAlignment.Stretch;
            mainGallery.Gallery.ImageSize = new Size(128, 128);
            mainGallery.Gallery.ShowItemText = true;
            var group = mainGallery.Gallery.Groups[0];
            //group.CaptionControl = CreateAlbumGroupCaptionControl(albumData);
            //return group;
            //mainGallery.Gallery.Groups.Add(group);
            SplashScreenManager.ShowForm(typeof(WaitForm1));

            if (!onlyRemote)
            {

                var dir = "Rencenty";
                InitDir(group, dir);

                dir = "Pic";
                InitDir(mainGallery.Gallery.Groups[1], dir);
            }
            else
            {
                mainGallery.Gallery.Groups[0].Visible = false;
                mainGallery.Gallery.Groups[1].Visible = false;
                this.navBarRencent.Visible = false;
                this.navBarItemDownload.Visible = false;
            }

            new Thread(() =>
            {
                InitRemote();
            }).Start();
        }

        delegate void DownloadImage(string url, GalleryItem item);

        void DownloadImageForItem(string url, GalleryItem item)
        {
            try
            {
                NiceWebClient client = new NiceWebClient();
                var bytes = client.DownloadData(url);
                Image img = Image.FromStream(new MemoryStream(bytes));
                item.Image = img;
            }
            catch
            {
            }
        }

        private void InitRemote()
        {
            var group = mainGallery.Gallery.Groups[2];
            var images = RemoteAPI.GetImages();
            try
            {
                this.mainGallery.BeginInvoke(new MethodInvoker(() =>
                {
                    foreach (var image in images)
                    {
                        try
                        {
                            group.Items.Add(CreateRemotePhotoGalleryItem(image));
                        }
                        catch
                        {
                        }
                    }
                }));
            }
            catch
            {
            }
            SplashScreenManager.CloseForm();
        }
        private GalleryItem CreateRemotePhotoGalleryItem(string fileName)
        {
            GalleryItem item = new GalleryItem();
            item.Caption = Path.GetFileName(fileName);
            item.Hint = fileName;
            //item.Image = ThumbnailHelper.Default.GetThumbnail(fileName, 208, ThumbPath);
            DownloadImage downloader = this.DownloadImageForItem;
            downloader.BeginInvoke(fileName, item, null, null);
            item.Tag = fileName;
            return item;
        }


        private void InitDir(GalleryItemGroup group, string dir)
        {
            group.Items.Clear();
            if (Directory.Exists(dir))
            {
                if (!(dir == "Pic" || dir == "Rencenty"))
                {
                    var parent = dir.Substring(0, dir.LastIndexOf('\\'));
                    // 添加上一
                    group.Items.Add(CreateParentItem(parent));
                }

                var dirs = Directory.GetDirectories(dir);
                foreach (var pData in dirs)
                {
                    try
                    {
                        group.Items.Add(CreateDirItem(pData));
                    }
                    catch
                    {
                    }
                }
                var files = GetImagesInFolder(dir);
                foreach (var pData in files)
                {
                    try
                    {
                        group.Items.Add(CreatePhotoGalleryItem(pData));
                    }
                    catch
                    {
                    }
                }
            }
        }

        protected List<string> GetImagesInFolder(string folder)
        {
            string strFilter = "*bmp;*tga;*.jpg;*.png;*.gif";
            string[] m_arExt = strFilter.Split(';');
            List<string> files = new List<string>();
            foreach (string filter in m_arExt)
            {
                string[] str = Directory.GetFiles(folder, filter);
                files.AddRange(str);
            }
            return files;
        }

        protected string ThumbPath { get { return "Thumbs\\"; } }

        private GalleryItem CreatePhotoGalleryItem(string fileName)
        {
            GalleryItem item = new GalleryItem();
            item.Caption = Path.GetFileName(fileName);
            item.Hint = fileName;
            item.Image = ThumbnailHelper.Default.GetThumbnail(fileName, 208, ThumbPath);
            item.Tag = fileName;
            return item;
        }

        private GalleryItem CreateDirItem(string dirName)
        {
            GalleryItem item = new GalleryItem();
            item.Caption = Path.GetDirectoryName(dirName);
            item.Hint = "文件夹：" + dirName;
            item.Image = Properties.Resources.dir;
            item.Tag = dirName;
            return item;

        }

        private GalleryItem CreateParentItem(string dirName)
        {
            GalleryItem item = new GalleryItem();
            item.Caption = Path.GetDirectoryName(dirName);
            item.Hint = "文件夹：" + dirName;
            item.Image = Properties.Resources.folder_yellow_parent;
            item.Tag = dirName;
            return item;
        }
        private void mainGallery_Click(object sender, EventArgs e)
        {

        }

        private void navBarControl1_Click(object sender, EventArgs e)
        {

        }

        private void ImageSelecter_Load(object sender, EventArgs e)
        {

        }

        private void navBarRencent_LinkClicked(object sender, DevExpress.XtraNavBar.NavBarLinkEventArgs e)
        {
            this.mainGallery.Gallery.ScrollTo(this.mainGallery.Gallery.Groups[0], true);
        }

        private void navBarItemDownload_LinkClicked(object sender, DevExpress.XtraNavBar.NavBarLinkEventArgs e)
        {
            this.mainGallery.Gallery.ScrollTo(this.mainGallery.Gallery.Groups[1], true);
        }

        private void navBarItemRemote_LinkClicked(object sender, DevExpress.XtraNavBar.NavBarLinkEventArgs e)
        {
            this.mainGallery.Gallery.ScrollTo(this.mainGallery.Gallery.Groups[2], true);
        }

        public string SelectedFile
        {
            get;
            set;
        }

        private void galleryControlGallery1_ItemDoubleClick(object sender, GalleryItemClickEventArgs e)
        {
            e.Item.Checked = true;
            var file = e.Item.Tag.ToString();

            if (file.StartsWith("http:") || !e.Item.Hint.Contains("文件夹"))
            {
                if (file.StartsWith("http:"))
                {
                    SelectedFile = file;
                }
                else
                {
                    SelectedFile = AppDomain.CurrentDomain.BaseDirectory + "\\" + file;

                    try
                    {
                        if (!Directory.Exists("Rencenty"))
                        {
                            Directory.CreateDirectory("Rencenty");
                        }

                        // 拷贝到最近选择
                        File.Copy(SelectedFile, "Rencenty\\" + Path.GetFileName(SelectedFile), true);
                    }
                    catch
                    {
                    }
                }
                this.DialogResult = DialogResult.OK;
                this.Close();
            }
            else
            {
                InitDir(e.Item.GalleryGroup, file);
            }
        }


    }
    public class ThumbnailHelper
    {
        static ThumbnailHelper defaultHelper;
        public static ThumbnailHelper Default
        {
            get
            {
                if (defaultHelper == null)
                    defaultHelper = new ThumbnailHelper();
                return defaultHelper;
            }
        }

        Dictionary<string, Image> thumbnails;
        protected Dictionary<string, Image> Thumbnails
        {
            get
            {
                if (thumbnails == null)
                    thumbnails = new Dictionary<string, Image>();
                return thumbnails;
            }
        }

        public Image CreateThumbnail(Image image, int length)
        {
            Rectangle rect = ImageLayoutHelper.GetImageBounds(new Rectangle(0, 0, length, length), image.Size, ImageLayoutMode.ZoomInside);
            Bitmap bmp = new Bitmap(rect.Width, rect.Height);
            using (Graphics g = Graphics.FromImage(bmp))
            {
                rect.X = 0;
                rect.Y = 0;
                g.DrawImage(image, rect);
            }
            return bmp;
        }
        public Image CreateThumbnail(Image image, string fileName, int length, string thumbPath)
        {
            Image bmp = CreateThumbnail(image, length);
            string thumbFileName = length.ToString() + "_" + fileName;
            string md5hash = CalculateMD5Hash(thumbFileName);
            try
            {
                if (!Directory.Exists(thumbPath))
                {
                    Directory.CreateDirectory(thumbPath);
                }
                string finalFileName = thumbPath + md5hash;
            }
            catch (Exception e)
            {
                XtraMessageBox.Show("Error creating thumnail for image '" + fileName + "'. " + e.Message, "Thumbnail creator", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
            return bmp;
        }
        public string CalculateMD5Hash(string input)
        {
            MD5 md5 = System.Security.Cryptography.MD5.Create();
            byte[] inputBytes = System.Text.Encoding.ASCII.GetBytes(input);
            byte[] hash = md5.ComputeHash(inputBytes);

            StringBuilder sb = new StringBuilder();
            for (int i = 0; i < hash.Length; i++)
            {
                sb.Append(hash[i].ToString("X2"));
            }
            return sb.ToString();
        }
        public Image GetThumbnail(string fileName, int length, string thumbPath)
        {
            string thumbFileName = length.ToString() + "_" + fileName;
            thumbFileName = CalculateMD5Hash(thumbFileName);
            thumbFileName = thumbPath + thumbFileName;
            if (Thumbnails.ContainsKey(thumbFileName))
                return Thumbnails[thumbFileName];
            try
            {
                if (File.Exists(thumbFileName))
                    return Image.FromFile(thumbFileName);
            }
            catch (Exception e)
            {
                XtraMessageBox.Show("Error creating thumnail for image '" + fileName + "'. " + e.Message, "Thumbnail creator", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
            using (Image img = Image.FromFile(fileName))
            {
                return CreateThumbnail(img, fileName, length, thumbPath);
            }
        }
    }
}