using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace XmlDatabase.Core
{
    class XChangeItem
    {
        public XChangeAction Action { get; set; }
        public IXmlStoreItem UserData { get; set; }
    }

    enum XChangeAction
    {
        AddOrUpdate,
        Delete,
        Clear
    }
}
