using System.Reflection;
using Castle.Core.Internal;
using XCode.RuningCode.Core.Attributes;

namespace XCode.RuningCode.Core.Extentions
{
    public static class MethodExtensions
    {
        public static string FriendlyName(this MethodInfo  method)
        {
            var attr = method.GetAttribute<FriendlyNameAttribute>();
            return attr == null ? method.Name : attr.Name;
        }
        public static string FriendlyName(this ParameterInfo parameter)
        {
            var attr = parameter.GetAttribute<FriendlyNameAttribute>();
            return attr == null ? parameter.Name : attr.Name;
        }
    }
}