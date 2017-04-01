using System;
using XCode.RuningCode.Core.Attributes;

namespace XCode.RuningCode.Core.Extentions
{
    public static class NavigateNameExtensions
    {
        public static string nav_name(this object obj) 
        {
            var type = obj.GetType();
            var attr= NavigateNameAttribute.Empty;
            if (type.IsEnum)
            {
                attr = (obj as Enum).GetAttribute<NavigateNameAttribute>();
            }
            return attr == NavigateNameAttribute.Empty ? obj.ToString() : attr.Name;
        }
    }
}