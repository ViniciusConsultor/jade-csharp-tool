using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Jade.Model.MySql
{
    public partial class downloaddata : Jade.Model.IDownloadData
    {
        public int publishedIndex
        {
            get { return this.IsPublish ? 1 : 0; }
        }

        public int editedIndex
        {
            get { return this.IsEdit ? 1 : 0; }
        }

        public bool IsChecked { get; set; }
    }
}
