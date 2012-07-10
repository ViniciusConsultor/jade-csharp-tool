using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace HFBBS.Model
{
    public class Category
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
    }
}
