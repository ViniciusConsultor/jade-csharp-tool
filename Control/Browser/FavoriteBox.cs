using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Drawing;
using System.Data;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using System.IO;

namespace Jade.Control.Browser
{
    public partial class FavoriteBox : UserControl
    {

        public event EventHandler FavoriteLinkClick;

        public string Url
        {
            get;
            set;
        }

        public FavoriteBox()
        {
            InitializeComponent();

            this.treeView1.DoubleClick += new EventHandler(treeView1_DoubleClick);

            try
            {
                var node = this.treeView1.Nodes[0];
                var dir = Environment.GetFolderPath(Environment.SpecialFolder.Favorites);
                InitNodes(node, dir);
                node.Expand();
            }
            catch
            {
            }
        }

        void treeView1_DoubleClick(object sender, EventArgs e)
        {
            if (this.treeView1.SelectedNode != null && this.treeView1.SelectedNode.Tag != null)
            {
                var fileName = this.treeView1.SelectedNode.Tag.ToString();
                if (fileName != "")
                {
                    var lines = File.ReadAllLines(fileName);
                    foreach (var line in lines)
                    {
                        if (line.StartsWith("URL="))
                        {
                            this.Url = line.Replace("URL=", "");
                            if (FavoriteLinkClick != null)
                            {
                                FavoriteLinkClick(sender, e);
                            }
                            break;
                        }
                    }

                }
            }
        }

        private static void InitNodes(TreeNode node, string dir)
        {
            var dirs = new DirectoryInfo(dir).GetDirectories();
            foreach (var d in dirs)
            {
                var folder = new TreeNode(d.Name);
                node.Nodes.Add(folder);
                folder.ImageIndex = 1;
                InitNodes(folder, d.FullName);
            }

            var files = new DirectoryInfo(dir).GetFiles();
            foreach (var f in files)
            {
                if (f.Name.EndsWith(".url"))
                {
                    var file = new TreeNode(f.Name.Replace(".url", ""));
                    node.Nodes.Add(file);
                    file.Tag = f.FullName;
                    file.ImageIndex = 2;
                }
            }
        }
    }
}
