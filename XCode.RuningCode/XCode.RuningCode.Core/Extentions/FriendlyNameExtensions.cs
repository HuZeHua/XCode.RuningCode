using System;
using System.Linq;
using XCode.RuningCode.Core.Attributes;

namespace XCode.RuningCode.Core.Extentions
{
    public static class FriendlyNameExtensions
    {

        public static string type_name(this object obj)
        {
            return obj.GetType().FriendlyName();
        }
        public static string value_name(this object obj) 
        {
            var type = obj.GetType();
            FriendlyNameAttribute attr=FriendlyNameAttribute.Empty;
            if (type.IsEnum)
            {
                attr = (obj as Enum).GetAttribute<FriendlyNameAttribute>();
            }
            return attr == FriendlyNameAttribute.Empty ? obj.ToString() : attr.Name;
        }

        public static T get_by_friendly_name<T>(this string friendly_name) 
        {
            var type = typeof (T);
            if (!type.IsEnum)
            {
                throw new Exception("指定类型必须为枚举类型");
            }
            var matched_enums = Enum.GetValues(type)
                                    .Cast<T>()
                                    .Where(value => (value as Enum).GetAttribute<FriendlyNameAttribute>().Name == friendly_name);
            if (!matched_enums.Any())
                throw new Exception(string.Format("{0}中未找到符合该名称的值“{1}”", type.Name, friendly_name));
            if (matched_enums.Count() != 1)
                throw new Exception(string.Format("{0}找到多个符合该名称的值“{1}”", type.Name, friendly_name));
            return matched_enums.First();
        }

        public static string type_name(this bool value)
        {
            return "布尔值";
        }
        public static string value_name(this bool value)
        {
            return value ? "是" : "否";
        }
    }
}