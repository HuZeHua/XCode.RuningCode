using XCode.RuningCode.Entity.Base;

namespace XCode.RuningCode.Entity.Blog
{
    public class SiteSetting : BaseEntity
    {
        /// <summary>
        /// 网站名称
        /// </summary>
        public string Title { get; set; }

        /// <summary>
        /// 标题分隔符
        /// </summary>
        public string Separator { get; set; }

        /// <summary>
        /// SEO标题
        /// </summary>
        public string MetaTitle { get; set; }

        /// <summary>
        /// SEO关键字
        /// </summary>
        public string MetaKeywords { get; set; }

        /// <summary>
        /// SEO描述
        /// </summary>
        public string MetaDescription { get; set; }
    }
}
