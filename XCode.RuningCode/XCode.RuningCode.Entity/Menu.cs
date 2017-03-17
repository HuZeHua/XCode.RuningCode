using XCode.RuningCode.Entity.Base;

namespace XCode.RuningCode.Entity
{
    public class Menu : BaseEntity
    {

        /// <summary>
        /// 上级ID
        /// </summary>
        public int ParentId { get; set; }

        /// <summary>
        /// 类型
        /// </summary>
        public byte Type { get; set; }

        /// <summary>
        /// 名称
        /// </summary>
        public string Name { get; set; }

        /// <summary>
        /// URL
        /// </summary>
        public string Url { get; set; }

        /// <summary>
        /// 排序越大越靠后
        /// </summary>
        public int Order { get; set; }
    }
}
