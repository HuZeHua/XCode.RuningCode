using System;
using XCode.RuningCode.Core.Enums;

namespace XCode.RuningCode.Core.Attributes
{
    public class NavigateNameAttribute : Attribute
    {
        public static NavigateNameAttribute Empty = new NavigateNameAttribute(string.Empty);
        public NavigateNameAttribute(string name) : this(name, MenuType.ButtonType, MenuName.None)
        {
        }

        public NavigateNameAttribute(string name, MenuType type) : this(name, type, MenuName.None)
        {
        }

        public NavigateNameAttribute(string name, MenuType type, MenuName menuName)
        {
            Name = name;
            ParentName = menuName;
            Type = type;
        }

        public string Name { get; private set; }

        public MenuName ParentName { get; private set; }

        public MenuType Type { get; private set; }
    }
}