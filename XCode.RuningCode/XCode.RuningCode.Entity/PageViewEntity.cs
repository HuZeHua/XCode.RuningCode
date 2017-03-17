using XCode.RuningCode.Entity.Base;

namespace XCode.RuningCode.Entity
{
    /// <summary>
    /// 用户实体
    /// </summary>
    public class PageViewEntity : BaseEntity
    {

        /// <summary>
        /// UserId
        /// </summary>
        public string UserId { get; set; }
        /// <summary>
        /// UserName
        /// </summary>
        public string LoginName { get; set; }
        /// <summary>
        /// Url
        /// </summary>
        public string Url { get; set; }

        /// <summary>
        /// 访问者IP
        /// </summary>
        public string IP { get; set; }
    }
}
