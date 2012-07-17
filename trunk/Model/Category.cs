using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Jade.Model
{
    public class Category : XmlDatabase.Core.IXmlStoreItem
    {
        public int ID { get; set; }

        public int ParentCategoryID { get; set; }

        public string Name { get; set; }

        public Category GetParentCategory()
        {
            if (ParentCategoryID != 0)
            {
                return CacheObject.Categories.SingleOrDefault(c => c.ID == ParentCategoryID);
            }
            return null;
        }

        #region IXmlStoreItem 成员

        public object GetPrimaryKey()
        {
            return "Category" + this.ID;
        }

        #endregion
    }
}
