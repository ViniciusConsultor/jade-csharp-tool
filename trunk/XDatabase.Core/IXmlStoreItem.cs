using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace XmlDatabase.Core
{
    public interface IXmlStoreItem
    {
        object GetPrimaryKey();
    }
}
