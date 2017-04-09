using System.Collections.Generic;
using System.ComponentModel;

namespace XCode.RuningCode.Service.Dto.Blog
{
    public class CategoryDto : BaseDto
    {
        [DisplayName("名称")]
        public string Name { get; set; }

        [DisplayName("SEO关键字")]
        public string MetaKeywords { get; set; }

        [DisplayName("SEO关键字")]
        public string MetaDescription { get; set; }

        [DisplayName("SEO标题")]
        public string MetaTitle { get; set; }

        [DisplayName("父节点")]
        public int ParentId { get; set; }

        [DisplayName("封面图")]
        public int PictureId { get; set; }

        [DisplayName("展示在首页")]
        public bool ShowOnHomePage { get; set; }

        [DisplayName("包含在顶部菜单")]
        public bool IncludeInTopMenu { get; set; }

        [DisplayName("已发布")]
        public bool Published { get; set; }

        [DisplayName("排序")]
        public int DisplayOrder { get; set; }

        public IList<CategoryDto> Childrens { get; set; }
    }
}
