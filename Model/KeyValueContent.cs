using System.Collections.Generic;
using System.Runtime.Serialization;

namespace HFBBS.Model
{
   
    public class KeyValueContent
    {   
        public List<KeyValue> KeyValue = new List<KeyValue>();

        public void Add(string key, string value)
        {
            KeyValue.Add(new KeyValue() { Key = key, Value = value });
        }

        public override string ToString()
        {
            string r = "";
            KeyValue.ForEach(t => r += t.Key + ":" + t.Value + ";");
            return r;
        }

        public string GetByKey(string key)
        {
            return KeyValue.Find(k => k.Key == key).Value;
        }
    }
}