using XCode.RuningCode.Entity.Base;

namespace XCode.RuningCode.Entity.Blog
{
    public class Notice : BaseEntity
    {
        public string Content { get; set; }

        public User Author { get; set; }
    }
}
