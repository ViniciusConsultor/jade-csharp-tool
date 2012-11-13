using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Jade
{
    public static class HtmlTagCaching
    {
        private static SortedDictionary<string, List<HtmlTagType>> storeDB = new SortedDictionary<string, List<HtmlTagType>>();

        public static void Add(string name, List<HtmlTagType> value)
        {
            storeDB.Add(name, value);
        }

        public static List<HtmlTagType> Get(string name)
        {
            if (storeDB.ContainsKey(name))
                return storeDB[name];
            else
                return null;
        }
    }
}
