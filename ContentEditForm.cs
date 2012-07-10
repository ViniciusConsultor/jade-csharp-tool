using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using HFBBS.Model;
using System.Security.Permissions;

namespace HFBBS
{
    [PermissionSet(SecurityAction.Demand, Name = "FullTrust")]
    [System.Runtime.InteropServices.ComVisibleAttribute(true)]
    public partial class ContentEditForm : WeifenLuo.WinFormsUI.Docking.DockContent
    {
        public ContentEditForm()
        {
            InitializeComponent();
        }
        public ContentEditForm(DownloadData data)
            : this()
        {
            InitDownloadData(data);
        }

        public void InitDownloadData(DownloadData data)
        {
            this.txtContent.Text = data.Content;
        }

        private void ContentEditForm_Load(object sender, EventArgs e)
        {

        }
    }
}
