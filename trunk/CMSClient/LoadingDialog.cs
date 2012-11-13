using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;

namespace Jade
{
    public partial class LoadingDialog : DevExpress.XtraEditors.XtraForm
    {
        private static Color borderColor = Color.FromArgb(0, 0, 0);
        private static Color headerColor = Color.FromArgb(211, 219, 222);
        private IWorkingThread settingForm = null;

        public LoadingDialog()
        {
            InitializeComponent();
            this.button1.Visible = false;
        }

        public LoadingDialog(IWorkingThread form)
        {
            InitializeComponent();
            this.settingForm = form;
        }

        private void SetSelfLocation()
        {
            if (this.OwnedForms == null || this.OwnedForms.Length == 0) return;

            Form owner = this.OwnedForms[0];
            if (owner == null) return;

            this.Location = new Point(owner.Location.X + owner.Size.Width / 3, owner.Location.Y + owner.Size.Height / 3);
        }

        protected override void OnPaint(PaintEventArgs e)
        {
            base.OnPaint(e);
            //ControlPaint.DrawBorder(e.Graphics, ClientRectangle, borderColor, ButtonBorderStyle.Solid);
            //e.Graphics.FillRectangle(new SolidBrush(headerColor), 1, 1, this.Size.Width - 2, 26);
        }

        public int Percentage
        {
            set
            {
                this.lblMessage.Text = "处理中，当前进度" + value + "%";
            }
        }

        public string Message
        {
            get
            {
                return this.lblMessage.Text;
            }
            set
            {
                this.lblMessage.Text = value;
            }
        }

        private void LoadingDialog_Load(object sender, EventArgs e)
        {
            SetSelfLocation();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            try
            {
                if (settingForm != null)
                {
                    settingForm.workingThread.Abort();
                }
            }
            catch
            {
            }
            finally
            {
                this.Close();
            }
        }
    }
}