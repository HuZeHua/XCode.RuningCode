using System;

namespace XCode.RuningCode.Core.Attributes
{
    public class NavigateNameAttribute : Attribute
    {
        public static NavigateNameAttribute Empty =new NavigateNameAttribute(string.Empty);
        public NavigateNameAttribute(string name)
        {
            Name = name;
        }

        public string Name { get; private set; }
    }
}