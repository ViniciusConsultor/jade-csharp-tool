using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Drawing;
using System.Data;
using System.Linq;
using System.Text;
using System.Windows.Forms;

namespace Jade.Control
{
    public partial class LinkButtonGroup : UserControl
    {

        public event GroupClick OnClick;

        public List<LinkLabel> Labels { get; set; }

        public LinkButtonGroup()
        {
            InitializeComponent();
        }

        public List<string> DataSource
        {
            get;
            set;
        }

        public void DataBind()
        {
            if (this.Labels.Count != 0)
            {
                foreach (var label in this.Labels)
                {
                    this.Controls.Remove(label);
                    label.Dispose();
                }
            }

            var left = 10;

            foreach (var tag in this.DataSource)
            {
                var label = new LinkLabel();
                label.Left = left;
                label.Text = tag;
                label.Click += new EventHandler(label_Click);
                label.Width = (int)this.CreateGraphics().MeasureString(tag, label.Font).Width + 10;
                left += label.Width;
                this.Controls.Add(label);
                this.Labels.Add(label);
            }
        }

        void label_Click(object sender, EventArgs e)
        {
            if (this.OnClick != null)
            {
                this.OnClick(sender, new GroupClickArgs { Tag = ((LinkLabel)sender).Text });
            }
        }
    }

    public delegate void GroupClick(object sender, GroupClickArgs args);

    public class GroupClickArgs : EventArgs
    {
        public string Tag { get; set; }
    }
}
