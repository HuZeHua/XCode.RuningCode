using XCode.RuningCode.Entity.Base;

namespace XCode.RuningCode.Entity.Blog
{
    /// <summary>
    /// 投票
    /// </summary>
    public class Vote : BaseEntity
    {
        public string IPAddress { get; set; }

        public User Author { get; set; }

        public Article Article { get; set; }
    }
}
