using System;
using System.Linq;
using System.IO;
using System.Reflection;
using System.Runtime.Serialization;

namespace Jade.CQA.Robot.Extensions
{

    public static class ObjectExtensions
    {
        #region Class Methods

        /// <summary>
        /// 动态获取属性值
        /// </summary>
        /// <typeparam name="T">返回数据类型</typeparam>
        /// <param name="obj">执行对象</param>
        /// <param name="propertyName">属性名称.</param>
        /// <param name="defaultValue">默认值.</param>
        /// <returns>属性值.</returns>
        /// <example>
        /// <code>
        /// var type = Type.GetType("System.IO.FileInfo, mscorlib");
        /// var file = type.CreateInstance(@"c:\autoexec.bat");
        /// if(file.GetPropertyValue&lt;bool&gt;("Exists")) {
        ///  var reader = file.InvokeMethod&lt;StreamReader&gt;("OpenText");
        ///  Console.WriteLine(reader.ReadToEnd());
        ///  reader.Close();
        /// }
        /// </code>
        /// </example>
        public static T GetPropertyValue<T>(this object obj, string propertyName, T defaultValue)
        {
            Type type = obj.GetType();
            PropertyInfo property = type.GetProperty(propertyName);

            if (property.IsNull())
            {
                return defaultValue;
            }

            object value = property.GetValue(obj, null);
            return value is T ? (T)value : defaultValue;
        }

        /// <summary>
        /// Dynamically sets a property value.
        /// </summary>
        /// <param name="obj">The object to perform on.</param>
        /// <param name="propertyName">The Name of the property.</param>
        /// <param name="value">The value to be set.</param>
        public static void SetPropertyValue(this object obj, string propertyName, object value)
        {
            Type type = obj.GetType();
            PropertyInfo property = type.GetProperty(propertyName);

            if (!property.IsNull())
            {
                property.SetValue(obj, value, null);
            }
        }

        public static bool IsNull<T>(this T @object)
        {
            return Equals(@object, null);
        }

        public static bool IsNotNull<T>(this T @object)
        {
            return !Equals(@object, null);
        }

        public static byte[] ToBinary<T>(this T o) where T : class, new()
        {
            DataContractSerializer dc = new DataContractSerializer(typeof(T));
            using (MemoryStream ms = new MemoryStream())
            {
                dc.WriteObject(ms, o);
                return ms.ToArray();
            }
        }

        public static T FromBinary<T>(this byte[] byteArray) where T : class, new()
        {
            DataContractSerializer dc = new DataContractSerializer(typeof(T));
            using (MemoryStream ms = new MemoryStream())
            {
                ms.Write(byteArray, 0, byteArray.Length);
                ms.Seek(0, SeekOrigin.Begin);
                return dc.ReadObject(ms) as T;
            }
        }

        public static bool IsIn<T>(this T t, params T[] tt)
        {
            return tt.Contains(t);
        }

        #endregion
    }
}