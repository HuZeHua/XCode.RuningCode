using System;

namespace XCode.RuningCode.Core.Attributes
{
    public class FriendlyNameAttribute:Attribute
    {
        public static FriendlyNameAttribute Empty=new FriendlyNameAttribute(string.Empty);
        public FriendlyNameAttribute(string name)
        {
            Name = name;
        }

        public string Name { get; private set; }
    }
}