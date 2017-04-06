using System;
using XCode.RuningCode.Core.Enums;

namespace XCode.RuningCode.Core.Attributes
{
    public class NavigateNameAttribute : Attribute
    {
        public static NavigateNameAttribute Empty = new NavigateNameAttribute(string.Empty);
        public NavigateNameAttribute(string name) : this(name, MenuName.None)
        {
        }

        public NavigateNameAttribute(string name, MenuName menuName)
        {
            Name = name;
            ParentName = menuName;
        }

        public string Name { get; private set; }

        public MenuName ParentName { get; private set; }
    }
}