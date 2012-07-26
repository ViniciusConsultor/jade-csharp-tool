using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;
using DevExpress.XtraEditors;

namespace Jade
{
    public partial class EditDefaultSettingForm : DevExpress.XtraEditors.XtraForm
    {
        public EditDefaultSettingForm()
        {
            InitializeComponent();

            this.lookUpEditSource.Properties.DataSource = RemoteWebService.Instance.Source;
            this.lookUpEditSource.Properties.DisplayMember = "DisplayName";
            this.lookUpEditSource.Properties.ValueMember = "DisplayName";
            this.lookUpEditSource.ItemIndex = RemoteWebService.Instance.Source.FindIndex(t => t.Value == Properties.Settings.Default.DefaultSource);
            this.lookUpEditSource.EditValue = Properties.Settings.Default.DefaultSource;

            this.lookUpEditLabel.Properties.DataSource = RemoteWebService.Instance.SpecilTags;
            this.lookUpEditLabel.Properties.DisplayMember = "DisplayName";
            this.lookUpEditLabel.Properties.ValueMember = "DisplayName";
            this.lookUpEditLabel.ItemIndex = RemoteWebService.Instance.SpecilTags.FindIndex(t => t.DisplayName == Properties.Settings.Default.DefaultTag);
            this.lookUpEditLabel.EditValue = Properties.Settings.Default.DefaultTag;

            this.lookUpEditTemplete.Properties.DataSource = RemoteWebService.Instance.Template;
            this.lookUpEditTemplete.Properties.DisplayMember = "Value";
            this.lookUpEditTemplete.Properties.ValueMember = "Value";
            this.lookUpEditTemplete.ItemIndex = RemoteWebService.Instance.Template.FindIndex(t => t.Value == Properties.Settings.Default.DefaultTemplate);
            this.lookUpEditTemplete.EditValue = Properties.Settings.Default.DefaultTemplate;

        }

        private void simpleButton3_Click(object sender, EventArgs e)
        {
            Properties.Settings.Default.DefaultTag = this.lookUpEditLabel.Text;
            Properties.Settings.Default.DefaultTemplate = this.lookUpEditTemplete.Text;
            Properties.Settings.Default.DefaultSource = this.lookUpEditSource.Text;
            Properties.Settings.Default.Save();
            this.Close();
        }

        private void simpleButton4_Click(object sender, EventArgs e)
        {
            this.Close();
        }
    }
}