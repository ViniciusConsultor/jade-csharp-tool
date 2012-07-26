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
            this.lookUpEditSource.Properties.ValueMember = "Value";
            this.lookUpEditLabel.ItemIndex = RemoteWebService.Instance.SpecilTags.FindIndex(t => t.Value == Properties.Settings.Default.DefaultSource);

            this.lookUpEditLabel.Properties.DataSource = RemoteWebService.Instance.SpecilTags;
            this.lookUpEditLabel.Properties.DisplayMember = "DisplayName";
            this.lookUpEditLabel.Properties.ValueMember = "Value";
            this.lookUpEditLabel.ItemIndex = RemoteWebService.Instance.SpecilTags.FindIndex(t => t.Value == Properties.Settings.Default.DefaultTag);

            this.lookUpEditTemplete.Properties.DataSource = RemoteWebService.Instance.Template;
            this.lookUpEditTemplete.Properties.DisplayMember = "DisplayName";
            this.lookUpEditTemplete.Properties.ValueMember = "Value";
            this.lookUpEditTemplete.ItemIndex = RemoteWebService.Instance.Template.FindIndex(t => t.Value == Properties.Settings.Default.DefaultTemplate);

        }

        private void simpleButton3_Click(object sender, EventArgs e)
        {

        }
    }
}