using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Jade
{
    public class SearchArgs
    {
        public List<int> TaskIds { get; set; }

        public string Keyword { get; set; }

        public bool IsDownload { get; set; }

        public bool IsEdit { get; set; }

        public bool IsPublish { get; set; }

        public int TaskId { get; set; }

        public int PageIndex { get; set; }

        public int PageSzie { get; set; }

        public string EditorName { get; set; }
    }
}
