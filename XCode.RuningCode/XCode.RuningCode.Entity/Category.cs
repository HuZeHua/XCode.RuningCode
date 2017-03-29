using System.Collections.Generic;
using XCode.RuningCode.Entity.Base;

namespace XCode.RuningCode.Entity
{
    /// <summary>
    /// 类别表
    /// </summary>
    public class Category : BaseEntity
    {
        private IList<Category> categorys;

        /// <summary>
        /// 名称
        /// </summary>
        public string Name { get; set; }

        /// <summary>
        /// SEO关键字
        /// </summary>
        public string MetaKeywords { get; set; }

        /// <summary>
        /// SEO描述
        /// </summary>
        public string MetaDescription { get; set; }

        /// <summary>
        /// SEO标题
        /// </summary>
        public string MetaTitle { get; set; }

        /// <summary>
        /// 父节点
        /// </summary>
        public int ParentId { get; set; }

        /// <summary>
        /// 封面图
        /// </summary>
        public int PictureId { get; set; }

        /// <summary>
        /// 展示在首页
        /// </summary>
        public bool ShowOnHomePage { get; set; }

        /// <summary>
        /// 包含在顶部菜单
        /// </summary>
        public bool IncludeInTopMenu { get; set; }

        /// <summary>
        /// 已发布
        /// </summary>
        public bool Published { get; set; }

        /// <summary>
        /// 排序
        /// </summary>
        public int DisplayOrder { get; set; }

        /// <summary>
        /// 已删除
        /// </summary>
        public bool Deleted { get; set; }

        public IList<Category> Childrens
        {
            get { return categorys ?? (categorys = new List<Category>()); }
            protected set { categorys = value; }
        } 
    }
}
